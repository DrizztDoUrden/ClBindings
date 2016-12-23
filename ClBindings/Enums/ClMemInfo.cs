using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClMemInfo : ulong
	{
		CL_MEM_TYPE                                 = 0x1100,
		CL_MEM_FLAGS                                = 0x1101,
		CL_MEM_SIZE                                 = 0x1102,
		CL_MEM_HOST_PTR                             = 0x1103,
		CL_MEM_MAP_COUNT                            = 0x1104,
		CL_MEM_REFERENCE_COUNT                      = 0x1105,
		CL_MEM_CONTEXT                              = 0x1106,
		CL_MEM_ASSOCIATED_MEMOBJECT                 = 0x1107,
		CL_MEM_OFFSET                               = 0x1108,
		CL_MEM_USES_SVM_POINTER                     = 0x1109,
    }
}
