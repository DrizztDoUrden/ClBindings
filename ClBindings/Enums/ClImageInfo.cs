using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClImageInfo : ulong
	{
		CL_IMAGE_FORMAT                             = 0x1110,
		CL_IMAGE_ELEMENT_SIZE                       = 0x1111,
		CL_IMAGE_ROW_PITCH                          = 0x1112,
		CL_IMAGE_SLICE_PITCH                        = 0x1113,
		CL_IMAGE_WIDTH                              = 0x1114,
		CL_IMAGE_HEIGHT                             = 0x1115,
		CL_IMAGE_DEPTH                              = 0x1116,
		CL_IMAGE_ARRAY_SIZE                         = 0x1117,
		CL_IMAGE_BUFFER                             = 0x1118,
		CL_IMAGE_NUM_MIP_LEVELS                     = 0x1119,
		CL_IMAGE_NUM_SAMPLES                        = 0x111A,
    }
}
