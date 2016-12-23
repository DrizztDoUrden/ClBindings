using ClBindings;
using ClBindings.Enums;
using ClBindings.Handles;
using ClBindings.Structs;
using System;
using System.Collections.Generic;

namespace ClClasses
{
	public class ClBuffer : ClMem
    {
		public ClBuffer(ClContext context, ClMemFlags flags, ulong size, IntPtr hostptr)
		{
			_handle = CL.clCreateBuffer(context._handle, flags, size, hostptr, out var result);
			ClUtilities.Check(result);
		}

		public ClBuffer(ClContext context, ClMemFlags flags, ulong size)
		{
			_handle = CL.clCreateBuffer(context._handle, flags, size, IntPtr.Zero, out var result);
			ClUtilities.Check(result);
		}

		public ClBuffer(ClBuffer parent, ClMemFlags flags,	ClBufferCreateType type, ref ClBufferRegion region)
		{
			_handle = CL.clCreateSubBuffer(parent._handle, flags, type, ref region, out var result);
			ClUtilities.Check(result);
		}

		protected ClBuffer(ClMemHandle handle) => _handle = handle;

		public new ClBuffer Retain()
		{
			ClUtilities.Check(CL.clRetainMemObject(_handle));
			return new ClBuffer(_handle);
		}
    }
}
