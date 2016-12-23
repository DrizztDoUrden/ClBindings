using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ClBindings.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ClBufferRegion
    {
		[MarshalAs(UnmanagedType.U8)] ulong Origin;
		[MarshalAs(UnmanagedType.U8)] ulong Size;
	}
}
