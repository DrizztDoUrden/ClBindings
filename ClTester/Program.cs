using System;
using ClBindings;
using System.Text;
using System.Runtime.InteropServices;
using ClBindings.Handles;
using ClBindings.Enums;

internal static class Program
{
	private static void Check(ClResult result)
	{
		if (result != ClResult.CL_SUCCESS)
			throw new Exception($"Cl error occured: {result.ToString()}");
	}

	private static unsafe string GetPlatformParameter(ClPlatformHandle platform, ClPlatformInfo parameter)
	{
		Check(CL.clGetPlatformInfo(platform, parameter, 0, null, out var sLen));
		var sb = new StringBuilder((int)sLen);
		Check(CL.clGetPlatformInfo(platform, parameter, sLen, sb));
		return sb.ToString();
	}

#if WINDOWS
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr LoadLibrary(string libname);

	[DllImport("kernel32.dll")]
	private static extern bool FreeLibrary(IntPtr hModule);
#endif

	private static unsafe void Main(string[] args)
	{
#if WINDOWS
		IntPtr opencl = LoadLibrary(@"C:\Program Files\NVIDIA Corporation\OpenCL\OpenCL64.dll");
		if (opencl == IntPtr.Zero)
		{
			int errorCode = Marshal.GetLastWin32Error();
			throw new Exception(string.Format("Failed to load library (ErrorCode: {0})", errorCode));
		}
#endif

		ClResult result;

		try
		{
			Check(CL.clGetPlatformIDs(0, null, out var platformsNumber));
			var platforms = new ClPlatformHandle[platformsNumber];
			Check(CL.clGetPlatformIDs(platformsNumber, platforms));
			ClPlatformHandle platform = new ClPlatformHandle();
			uint devicesNumber = 0;
			
			foreach (var p in platforms)
			{
				Check(CL.clGetDeviceIDs(p, ClDeviceType.CL_DEVICE_TYPE_GPU, 0, null, out var tDevicesNumber));

				if (tDevicesNumber > 0)
				{
					platform = p;
					devicesNumber = tDevicesNumber;

					Console.Write("Platform: ");
					Console.Write(GetPlatformParameter(p, ClPlatformInfo.CL_PLATFORM_NAME));
					Console.Write(" (");
					Console.Write(GetPlatformParameter(p, ClPlatformInfo.CL_PLATFORM_VENDOR));
					Console.WriteLine(").");
					break;
				}
			}

			if (devicesNumber == 0)
			{
				Console.WriteLine("Error: no devices found.");
				return;
			}

			var devices = new ClDeviceHandle[devicesNumber];
			Check(CL.clGetDeviceIDs(platform, ClDeviceType.CL_DEVICE_TYPE_GPU, devicesNumber, devices));
			var device = devices[0];
			Check(CL.clGetDeviceInfo(device, ClDeviceInfo.CL_DEVICE_MAX_WORK_ITEM_SIZES, 0, IntPtr.Zero, out var maxWG));
			Check(CL.clGetDeviceInfo(device, ClDeviceInfo.CL_DEVICE_NAME, 0, IntPtr.Zero, out var deviceNameSize));
			var deviceName = new StringBuilder((int)deviceNameSize);
			Check(CL.clGetDeviceInfo(device, ClDeviceInfo.CL_DEVICE_NAME, deviceNameSize, deviceName));

			Console.WriteLine($"Device: {deviceName.ToString()}, max workgroup size: {maxWG}.");

			var context = CL.clCreateContext(null, 1, devices, null, IntPtr.Zero, out result);
			Check(result);

			var queue = CL.clCreateCommandQueue(context, device, ClCommandQueueProperties.NONE, out result);
			Check(result);

			var sources = @"
kernel void VectorAdd(global const float* in0, global const float* in1, global float* out0)
{
	private size_t gid = get_global_id(0);
	out0[gid] = in0[gid] + in1[gid];
}";

			var program = CL.clCreateProgramWithSource(context, 1, new[] { sources, }, new[] { (ulong)sources.Length, }, out result);
			Check(result);

			if (CL.clBuildProgram(program, 1, new[] { device, }, "", null, IntPtr.Zero) != ClResult.CL_SUCCESS)
			{
				Check(CL.clGetProgramBuildInfo(program, device, ClProgramBuildInfo.CL_PROGRAM_BUILD_LOG, 0, IntPtr.Zero, out var logSize));
				var log = new StringBuilder((int)logSize);
				Check(CL.clGetProgramBuildInfo(program, device, ClProgramBuildInfo.CL_PROGRAM_BUILD_LOG, logSize, log, out logSize));

				Console.WriteLine($"Error building program: {log.ToString()}");
				return;
			}

			var kernel = CL.clCreateKernel(program, "VectorAdd", out result);
			Check(result);

			var rnd = new Random();
			ulong length = (ulong)rnd.Next(1000, 10000) / maxWG * maxWG;
			float[] in0 = new float[length];
			float[] in1 = new float[length];
			float[] out0 = new float[length];
			float[] testOut0 = new float[length];

			var in0Buffer = CL.clCreateBuffer(context, ClMemFlags.CL_MEM_READ_ONLY, (ulong)in0.Length * sizeof(float), IntPtr.Zero, out result);
			Check(result);
			var in1Buffer = CL.clCreateBuffer(context, ClMemFlags.CL_MEM_READ_ONLY, (ulong)in1.Length * sizeof(float), IntPtr.Zero, out result);
			Check(result);
			var out0Buffer = CL.clCreateBuffer(context, ClMemFlags.CL_MEM_WRITE_ONLY, (ulong)out0.Length * sizeof(float), IntPtr.Zero, out result);
			Check(result);

			for (var i = 0u; i < length; i++)
			{
				in0[i] = (float)rnd.NextDouble() * 100;
				in1[i] = (float)rnd.NextDouble() * 100;
				testOut0[i] = in0[i] + in1[i];
			}

			Check(CL.clSetKernelArg(kernel, 0, 8, ref in0Buffer));
			Check(CL.clSetKernelArg(kernel, 1, 8, ref in1Buffer));
			Check(CL.clSetKernelArg(kernel, 2, 8, ref out0Buffer));

			fixed (float* in0p = in0, in1p = in1, out0p = out0)
			{
				Check(CL.clEnqueueWriteBuffer(queue, in0Buffer, false, 0, (ulong)in0.Length * sizeof(float), in0p));
				Check(CL.clEnqueueWriteBuffer(queue, in1Buffer, false, 0, (ulong)in1.Length * sizeof(float), in1p));
				Check(CL.clEnqueueBarrierWithWaitList(queue));
				Check(CL.clEnqueueNDRangeKernel(queue, kernel, 1, null, new[] { length, }, new[] { maxWG, }));
				Check(CL.clEnqueueReadBuffer(queue, out0Buffer, false, 0, (ulong)out0.Length * sizeof(float), out0p));
				Check(CL.clFinish(queue));
			}

			var valid = true;
			for (var i = 0u; i < length; i++)
			{
				valid = valid && testOut0[i] == out0[i];
			}

			var validStr = valid ? "valid" : "invalid";
			Console.WriteLine($"Result is {validStr}.");

			Check(CL.clReleaseMemObject(out0Buffer));
			Check(CL.clReleaseMemObject(in1Buffer));
			Check(CL.clReleaseMemObject(in0Buffer));
			Check(CL.clReleaseKernel(kernel));
			Check(CL.clReleaseProgram(program));
			Check(CL.clReleaseCommandQueue(queue));
			Check(CL.clReleaseContext(context));
		}
		finally
		{
#if WINDOWS
			FreeLibrary(opencl);
#endif
			Console.WriteLine("Finished.");
			Console.ReadKey();
		}
	}
}
