using ClBindings.Enums;
using ClClasses;
using System;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
#if WINDOWS
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr LoadLibrary(string libname);

	[DllImport("kernel32.dll")]
	private static extern bool FreeLibrary(IntPtr hModule);
#endif

	static void Main(string[] args)
	{
#if WINDOWS
		IntPtr opencl = LoadLibrary(@"C:\Program Files\NVIDIA Corporation\OpenCL\OpenCL64.dll");
		if (opencl == IntPtr.Zero)
		{
			int errorCode = Marshal.GetLastWin32Error();
			throw new Exception(string.Format("Failed to load library (ErrorCode: {0})", errorCode));
		}
#endif

		try
		{
			var platforms = ClPlatform.GetPlatforms();
			var platform = platforms.FirstOrDefault(p => p.GetDevices(ClDeviceType.CL_DEVICE_TYPE_GPU).Length > 0);

			if (platform == null)
			{
				Console.WriteLine("No platforms found");
				return;
			}

			Console.WriteLine($"Platform: {platform.Name} ({platform.Vendor})");
			var device = platform.GetDevices(ClDeviceType.CL_DEVICE_TYPE_GPU)[0];
			var maxWG = device.MaxWorkGroupSizes;
			var wg = device.MaxWorkItemSizes;
			Console.WriteLine($"Device: {device.Name}, CUs: {device.MaxComputeUnit}, max WG size: {maxWG}, max work items dim 0: {wg[0]}");
			var context = new ClContext(null, 1, new[] { device, });
			var queue = new ClCommandQueue(context, device);

			var sources = @"
kernel void VectorAdd(global const float* in0, global const float* in1, global float* out0)
{
	private size_t gid = get_global_id(0);
	out0[gid] = in0[gid] + in1[gid];
}";

			var rnd = new Random();
			var length = (ulong)rnd.Next(1000, 10000) / wg[0] * wg[0];
			var in0buffer = new ClBuffer(context, ClMemFlags.CL_MEM_READ_ONLY, length);
			var in1buffer = new ClBuffer(context, ClMemFlags.CL_MEM_READ_ONLY, length);
			var out0buffer = new ClBuffer(context, ClMemFlags.CL_MEM_WRITE_ONLY, length);

			float[] in0 = new float[length];
			float[] in1 = new float[length];
			float[] out0 = new float[length];
			float[] testOut0 = new float[length];

			for (var i = 0u; i < length; i++)
			{
				in0[i] = (float)rnd.NextDouble() * 100;
				in1[i] = (float)rnd.NextDouble() * 100;
				testOut0[i] = in0[i] + in1[i];
			}

			in0buffer.Dispose();
			in1buffer.Dispose();
			out0buffer.Dispose();
			queue.Dispose();
			context.Dispose();
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