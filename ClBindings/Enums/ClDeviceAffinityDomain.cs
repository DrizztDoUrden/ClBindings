using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
	[Flags]
    public enum ClDeviceAffinityDomain : ulong
	{
		CL_DEVICE_AFFINITY_DOMAIN_NUMA               = (1 << 0),
		CL_DEVICE_AFFINITY_DOMAIN_L4_CACHE           = (1 << 1),
		CL_DEVICE_AFFINITY_DOMAIN_L3_CACHE           = (1 << 2),
		CL_DEVICE_AFFINITY_DOMAIN_L2_CACHE           = (1 << 3),
		CL_DEVICE_AFFINITY_DOMAIN_L1_CACHE           = (1 << 4),
		CL_DEVICE_AFFINITY_DOMAIN_NEXT_PARTITIONABLE = (1 << 5),
    }
}
