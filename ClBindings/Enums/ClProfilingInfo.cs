using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClProfilingInfo : ulong
	{
		CL_PROFILING_COMMAND_QUEUED                 = 0x1280,
		CL_PROFILING_COMMAND_SUBMIT                 = 0x1281,
		CL_PROFILING_COMMAND_START                  = 0x1282,
		CL_PROFILING_COMMAND_END                    = 0x1283,
		CL_PROFILING_COMMAND_COMPLETE               = 0x1284,
    }
}
