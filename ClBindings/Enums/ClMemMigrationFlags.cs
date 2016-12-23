using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
	[Flags]
    public enum ClMemMigrationFlags : ulong
    {
		CL_MIGRATE_MEM_OBJECT_HOST                  = (1 << 0),
		CL_MIGRATE_MEM_OBJECT_CONTENT_UNDEFINED     = (1 << 1),
    }
}
