using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
	public enum ClPlatformInfo : uint
	{
		CL_PLATFORM_PROFILE	   = 0x0900,
		CL_PLATFORM_VERSION	   = 0x0901,
		CL_PLATFORM_NAME	   = 0x0902,
		CL_PLATFORM_VENDOR	   = 0x0903,
		CL_PLATFORM_EXTENSIONS = 0x0904,
	}
}
