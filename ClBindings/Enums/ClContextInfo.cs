using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClContextInfo : ulong
	{
		CL_CONTEXT_REFERENCE_COUNT                  = 0x1080,
		CL_CONTEXT_DEVICES                          = 0x1081,
		CL_CONTEXT_PROPERTIES                       = 0x1082,
		CL_CONTEXT_NUM_DEVICES                      = 0x1083,
    }
}
