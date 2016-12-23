using System;

namespace ClBindings.Enums
{
	[Flags]
	public enum ClDeviceFpConfig : ulong
	{
		CL_FP_DENORM                                = (1 << 0),
		CL_FP_INF_NAN                               = (1 << 1),
		CL_FP_ROUND_TO_NEAREST                      = (1 << 2),
		CL_FP_ROUND_TO_ZERO                         = (1 << 3),
		CL_FP_ROUND_TO_INF                          = (1 << 4),
		CL_FP_FMA                                   = (1 << 5),
		CL_FP_SOFT_FLOAT                            = (1 << 6),
		CL_FP_CORRECTLY_ROUNDED_DIVIDE_SQRT         = (1 << 7),
	}
}
