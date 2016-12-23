using System;
using System.Collections.Generic;
using System.Text;

namespace ClBindings.Enums
{
    [Flags]
	public enum ClMapFlags : ulong
	{
		CL_MAP_READ                                 = (1 << 0),
		CL_MAP_WRITE                                = (1 << 1),
		CL_MAP_WRITE_INVALIDATE_REGION              = (1 << 2),
    }
}
