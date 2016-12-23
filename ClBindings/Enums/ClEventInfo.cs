using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClEventInfo : ulong
	{
		CL_EVENT_COMMAND_QUEUE                      = 0x11D0,
		CL_EVENT_COMMAND_TYPE                       = 0x11D1,
		CL_EVENT_REFERENCE_COUNT                    = 0x11D2,
		CL_EVENT_COMMAND_EXECUTION_STATUS           = 0x11D3,
		CL_EVENT_CONTEXT                            = 0x11D4,
    }
}
