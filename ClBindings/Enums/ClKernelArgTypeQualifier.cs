using System;
using System.Collections.Generic;
using System.Text;

namespace ClBindings.Enums
{
	[Flags]
    public enum ClKernelArgTypeQualifier : ulong
	{
		CL_KERNEL_ARG_TYPE_NONE                     = 0		  ,
		CL_KERNEL_ARG_TYPE_CONST                    = (1 << 0),
		CL_KERNEL_ARG_TYPE_RESTRICT                 = (1 << 1),
		CL_KERNEL_ARG_TYPE_VOLATILE                 = (1 << 2),
		CL_KERNEL_ARG_TYPE_PIPE                     = (1 << 3),
    }
}
