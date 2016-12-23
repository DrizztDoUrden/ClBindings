using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClMemObjectType : ulong
	{
		CL_MEM_OBJECT_BUFFER                        = 0x10F0,
		CL_MEM_OBJECT_IMAGE2D                       = 0x10F1,
		CL_MEM_OBJECT_IMAGE3D                       = 0x10F2,
		CL_MEM_OBJECT_IMAGE2D_ARRAY                 = 0x10F3,
		CL_MEM_OBJECT_IMAGE1D                       = 0x10F4,
		CL_MEM_OBJECT_IMAGE1D_ARRAY                 = 0x10F5,
		CL_MEM_OBJECT_IMAGE1D_BUFFER                = 0x10F6,
		CL_MEM_OBJECT_PIPE                          = 0x10F7,
    }
}
