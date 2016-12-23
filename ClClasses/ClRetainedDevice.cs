using ClBindings;
using ClBindings.Handles;
using System;
using System.Collections.Generic;

namespace ClClasses
{
	public class ClRetainedDevice : ClDevice, IDisposable
    {
		public ClRetainedDevice(ClDeviceHandle handle) : base(handle) { }

		~ClRetainedDevice() => Dispose();

		public void Dispose()
		{
			if (_disposed)
				return;

			_disposed = true;
			ClUtilities.Check(CL.clReleaseDevice(_handle));
		}

		private bool _disposed;
	}
}
