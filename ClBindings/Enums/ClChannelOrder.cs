using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClChannelOrder : ulong
	{
		CL_R                                        = 0x10B0,
		CL_A                                        = 0x10B1,
		CL_RG                                       = 0x10B2,
		CL_RA                                       = 0x10B3,
		CL_RGB                                      = 0x10B4,
		CL_RGBA                                     = 0x10B5,
		CL_BGRA                                     = 0x10B6,
		CL_ARGB                                     = 0x10B7,
		CL_INTENSITY                                = 0x10B8,
		CL_LUMINANCE                                = 0x10B9,
		CL_Rx                                       = 0x10BA,
		CL_RGx                                      = 0x10BB,
		CL_RGBx                                     = 0x10BC,
		CL_DEPTH                                    = 0x10BD,
		CL_DEPTH_STENCIL                            = 0x10BE,
		CL_sRGB                                     = 0x10BF,
		CL_sRGBx                                    = 0x10C0,
		CL_sRGBA                                    = 0x10C1,
		CL_sBGRA                                    = 0x10C2,
		CL_ABGR                                     = 0x10C3,
    }
}
