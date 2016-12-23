using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClAddressingMode : ulong
	{
		CL_ADDRESS_NONE                             = 0x1130,
		CL_ADDRESS_CLAMP_TO_EDGE                    = 0x1131,
		CL_ADDRESS_CLAMP                            = 0x1132,
		CL_ADDRESS_REPEAT                           = 0x1133,
		CL_ADDRESS_MIRRORED_REPEAT                  = 0x1134,
    }
}
