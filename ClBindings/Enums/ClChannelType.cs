﻿using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClChannelType : ulong
	{
		CL_SNORM_INT8                               = 0x10D0,
		CL_SNORM_INT16                              = 0x10D1,
		CL_UNORM_INT8                               = 0x10D2,
		CL_UNORM_INT16                              = 0x10D3,
		CL_UNORM_SHORT_565                          = 0x10D4,
		CL_UNORM_SHORT_555                          = 0x10D5,
		CL_UNORM_INT_101010                         = 0x10D6,
		CL_SIGNED_INT8                              = 0x10D7,
		CL_SIGNED_INT16                             = 0x10D8,
		CL_SIGNED_INT32                             = 0x10D9,
		CL_UNSIGNED_INT8                            = 0x10DA,
		CL_UNSIGNED_INT16                           = 0x10DB,
		CL_UNSIGNED_INT32                           = 0x10DC,
		CL_HALF_FLOAT                               = 0x10DD,
		CL_FLOAT                                    = 0x10DE,
		CL_UNORM_INT24                              = 0x10DF,
    }
}
