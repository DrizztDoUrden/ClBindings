﻿using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
	[Flags]
	public enum ClDeviceType : ulong
	{
		CL_DEVICE_TYPE_DEFAULT                      = (1 << 0),
		CL_DEVICE_TYPE_CPU                          = (1 << 1),
		CL_DEVICE_TYPE_GPU                          = (1 << 2),
		CL_DEVICE_TYPE_ACCELERATOR                  = (1 << 3),
		CL_DEVICE_TYPE_CUSTOM                       = (1 << 4),
		CL_DEVICE_TYPE_ALL                          = 0xFFFFFFFF,
	}
}
