using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClDevicePartitionProperty : ulong
	{
		CL_DEVICE_PARTITION_EQUALLY                 = 0x1086,
		CL_DEVICE_PARTITION_BY_COUNTS               = 0x1087,
		CL_DEVICE_PARTITION_BY_COUNTS_LIST_END      = 0x0,
		CL_DEVICE_PARTITION_BY_AFFINITY_DOMAIN      = 0x1088,
    }
}
