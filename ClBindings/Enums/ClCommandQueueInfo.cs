using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClCommandQueueInfo : ulong
	{
		CL_QUEUE_CONTEXT                            = 0x1090,
		CL_QUEUE_DEVICE                             = 0x1091,
		CL_QUEUE_REFERENCE_COUNT                    = 0x1092,
		CL_QUEUE_PROPERTIES                         = 0x1093,
		CL_QUEUE_SIZE                               = 0x1094,
    }
}
