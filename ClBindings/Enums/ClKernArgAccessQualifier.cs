using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClKernArgAccessQualifier : ulong
	{
		CL_KERNEL_ARG_ACCESS_READ_ONLY              = 0x11A0,
		CL_KERNEL_ARG_ACCESS_WRITE_ONLY             = 0x11A1,
		CL_KERNEL_ARG_ACCESS_READ_WRITE             = 0x11A2,
		CL_KERNEL_ARG_ACCESS_NONE                   = 0x11A3,
    }
}
