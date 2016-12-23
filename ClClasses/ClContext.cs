using System;
using System.Collections.Generic;
using System.Linq;
using ClBindings;
using ClBindings.Enums;
using ClBindings.Handles;

namespace ClClasses
{
	public class ClContext : IDisposable
	{
		public ClDevice[] Devices => GetPropertyAsDevices(ClContextInfo.CL_CONTEXT_DEVICES);
		public ClContextProperties[] Properties => GetPropertyAsContextProperties(ClContextInfo.CL_CONTEXT_PROPERTIES);
		public uint NumDevices => GetPropertyAsUint(ClContextInfo.CL_CONTEXT_NUM_DEVICES);
		public uint ReferenceCount => GetPropertyAsUint(ClContextInfo.CL_CONTEXT_REFERENCE_COUNT);

		public ClContext(ClContextHandle handle) => _handle = handle;

		public ClContext(ClContextProperties[] properties, ClDeviceType deviceType, ClErrorCallback callback, IntPtr userdata)
		{
			_handle = CL.clCreateContextFromType(properties, deviceType, callback, userdata, out var result);
			ClUtilities.Check(result);
		}

		public ClContext(ClContextProperties[] properties, ClDeviceType deviceType, ClErrorCallback callback = null)
		{
			_handle = CL.clCreateContextFromType(properties, deviceType, callback, IntPtr.Zero, out var result);
			ClUtilities.Check(result);
		}

		public ClContext(ClContextProperties[] properties, uint numDevices, ClDevice[] devices, ClErrorCallback callback, IntPtr userdata)
		{
			_handle = CL.clCreateContext(properties, numDevices, devices.Select(d => d._handle).ToArray(), callback, userdata, out var result);
			ClUtilities.Check(result);
		}

		public ClContext(ClContextProperties[] properties, uint numDevices, ClDevice[] devices, ClErrorCallback callback = null)
		{
			_handle = CL.clCreateContext(properties, numDevices, devices.Select(d => d._handle).ToArray(), callback, IntPtr.Zero, out var result);
			ClUtilities.Check(result);
		}

		~ClContext() => Dispose();

		public ClContext Retain()
		{
			ClUtilities.Check(CL.clRetainContext(_handle));
			return new ClContext(_handle);
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_disposed = true;
			ClUtilities.Check(CL.clReleaseContext(_handle));
		}

		public unsafe uint GetPropertyAsUint(ClContextInfo property)
		{
			uint result;
			ClUtilities.Check(CL.clGetContextInfo(_handle, property, sizeof(uint), &result));
			return result;
		}
		
		public unsafe ClDevice[] GetPropertyAsDevices(ClContextInfo property)
		{
			var numDevices = NumDevices;
			var result = new ClDeviceHandle[numDevices];
			ClUtilities.Check(CL.clGetContextInfo(_handle, property, numDevices * (ulong)sizeof(IntPtr), result));
			return result.Select(d => new ClDevice(d)).ToArray();
		}

		public unsafe ClContextProperties[] GetPropertyAsContextProperties(ClContextInfo property)
		{
			ClUtilities.Check(CL.clGetContextInfo(_handle, property, 0, IntPtr.Zero, out var size));
			var result = new ClContextProperties[(int)size / sizeof(ClContextProperties)];
			ClUtilities.Check(CL.clGetContextInfo(_handle, property, size, result));
			return result;
		}

		internal ClContextHandle _handle;
		private bool _disposed = false;
	}
}
