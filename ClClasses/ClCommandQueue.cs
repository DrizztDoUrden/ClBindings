using ClBindings;
using ClBindings.Enums;
using ClBindings.Handles;
using System;
using System.Collections.Generic;

namespace ClClasses
{
	public class ClCommandQueue : IDisposable
	{
		public ClContext Context => GetPropertyAsContext(ClCommandQueueInfo.CL_QUEUE_CONTEXT);
		public ClDevice Device => GetPropertyAsDevice(ClCommandQueueInfo.CL_QUEUE_DEVICE);
		public ClCommandQueueProperties Properties => GetPropertyAsProperties(ClCommandQueueInfo.CL_QUEUE_PROPERTIES);
		public uint ReferenceCount => GetPropertyAsUint(ClCommandQueueInfo.CL_QUEUE_REFERENCE_COUNT);

		public ClCommandQueue(ClCommandQueueHandle handle) => _handle = handle;

		public ClCommandQueue(ClContext context, ClDevice device, ClCommandQueueProperties properties = 0)
		{
			_handle = CL.clCreateCommandQueue(context._handle, device._handle, properties, out var result);
			ClUtilities.Check(result);
		}

		public ClCommandQueue Retain()
		{
			ClUtilities.Check(CL.clRetainCommandQueue(_handle));
			return new ClCommandQueue(_handle);
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_disposed = true;
			ClUtilities.Check(CL.clReleaseCommandQueue(_handle));
		}

		public unsafe ClContext GetPropertyAsContext(ClCommandQueueInfo property)
		{
			ClContextHandle result;
			ClUtilities.Check(CL.clGetCommandQueueInfo(_handle, property, (ulong)sizeof(IntPtr), &result));
			return new ClContext(result);
		}

		public unsafe ClDevice GetPropertyAsDevice(ClCommandQueueInfo property)
		{
			ClDeviceHandle result;
			ClUtilities.Check(CL.clGetCommandQueueInfo(_handle, property, (ulong)sizeof(IntPtr), &result));
			return new ClDevice(result);
		}

		public unsafe uint GetPropertyAsUint(ClCommandQueueInfo property)
		{
			uint result;
			ClUtilities.Check(CL.clGetCommandQueueInfo(_handle, property, (ulong)sizeof(uint), &result));
			return result;
		}

		public unsafe ClCommandQueueProperties GetPropertyAsProperties(ClCommandQueueInfo property)
		{
			ClCommandQueueProperties result;
			ClUtilities.Check(CL.clGetCommandQueueInfo(_handle, property, (ulong)sizeof(ClCommandQueueProperties), &result));
			return result;
		}

		internal ClCommandQueueHandle _handle;
		private bool _disposed;
	}
}
