using System;
using System.Collections.Generic;
using System.Text;

namespace ClBindings.Enums
{
    public enum ClKernelWorkGroupInfo : ulong
	{
		CL_KERNEL_WORK_GROUP_SIZE                    = 0x11B0,
		CL_KERNEL_COMPILE_WORK_GROUP_SIZE            = 0x11B1,
		CL_KERNEL_LOCAL_MEM_SIZE                     = 0x11B2,
		CL_KERNEL_PREFERRED_WORK_GROUP_SIZE_MULTIPLE = 0x11B3,
		CL_KERNEL_PRIVATE_MEM_SIZE                   = 0x11B4,
		CL_KERNEL_GLOBAL_WORK_SIZE                   = 0x11B5,
    }
}
