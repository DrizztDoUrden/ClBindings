using System;

namespace ClBindings.Enums
{
	[Flags]
	public enum ClDeviceExecCapabilities : ulong
	{
		CL_EXEC_KERNEL                              = (1 << 0),
		CL_EXEC_NATIVE_KERNEL                       = (1 << 1),
	}
}
