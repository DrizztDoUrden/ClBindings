using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClProgramBuildInfo : ulong
	{
		CL_PROGRAM_BUILD_STATUS                     = 0x1181,
		CL_PROGRAM_BUILD_OPTIONS                    = 0x1182,
		CL_PROGRAM_BUILD_LOG                        = 0x1183,
		CL_PROGRAM_BINARY_TYPE                      = 0x1184,
		CL_PROGRAM_BUILD_GLOBAL_VARIABLE_TOTAL_SIZE = 0x1185,
    }
}
