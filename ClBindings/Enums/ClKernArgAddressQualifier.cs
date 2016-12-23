using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClKernArgAddressQualifier : ulong
	{
		CL_KERNEL_ARG_ADDRESS_GLOBAL                = 0x119B,
		CL_KERNEL_ARG_ADDRESS_LOCAL                 = 0x119C,
		CL_KERNEL_ARG_ADDRESS_CONSTANT              = 0x119D,
		CL_KERNEL_ARG_ADDRESS_PRIVATE               = 0x119E,
    }
}
