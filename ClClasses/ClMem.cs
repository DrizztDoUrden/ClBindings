using ClBindings;
using ClBindings.Handles;
using System;
using System.Collections.Generic;

namespace ClClasses
{
	public class ClMem : IDisposable
    {
		public ClMem(ClMemHandle handle) => _handle = handle;
		protected ClMem() { }
		~ClMem() => Dispose();

		public ClMem Retain()
		{
			ClUtilities.Check(CL.clRetainMemObject(_handle));
			return new ClMem(_handle);
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_disposed = true;
			ClUtilities.Check(CL.clReleaseMemObject(_handle));
		}

		internal ClMemHandle _handle;
		private bool _disposed = false;
	}
}
