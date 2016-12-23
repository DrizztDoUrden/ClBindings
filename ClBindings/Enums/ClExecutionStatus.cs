using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClExecutionStatus : ulong
	{
		CL_COMPLETE                                 = 0x0,
		CL_RUNNING                                  = 0x1,
		CL_SUBMITTED                                = 0x2,
		CL_QUEUED                                   = 0x3,
    }
}
