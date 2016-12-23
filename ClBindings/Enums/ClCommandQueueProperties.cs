using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
	[Flags]
    public enum ClCommandQueueProperties : ulong
	{
		NONE										= 0,
		CL_QUEUE_OUT_OF_ORDER_EXEC_MODE_ENABLE      = (1 << 0),
		CL_QUEUE_PROFILING_ENABLE                   = (1 << 1),
		CL_QUEUE_ON_DEVICE                          = (1 << 2),
		CL_QUEUE_ON_DEVICE_DEFAULT                  = (1 << 3),
    }
}
