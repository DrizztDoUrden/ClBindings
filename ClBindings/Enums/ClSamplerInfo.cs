using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClSamplerInfo : ulong
	{
		CL_SAMPLER_REFERENCE_COUNT                  = 0x1150,
		CL_SAMPLER_CONTEXT                          = 0x1151,
		CL_SAMPLER_NORMALIZED_COORDS                = 0x1152,
		CL_SAMPLER_ADDRESSING_MODE                  = 0x1153,
		CL_SAMPLER_FILTER_MODE                      = 0x1154,
		CL_SAMPLER_MIP_FILTER_MODE                  = 0x1155,
		CL_SAMPLER_LOD_MIN                          = 0x1156,
		CL_SAMPLER_LOD_MAX                          = 0x1157,
    }
}
