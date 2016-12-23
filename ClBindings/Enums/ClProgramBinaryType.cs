namespace ClBindings.Enums
{
	public enum ClProgramBinaryType : ulong
	{
		CL_PROGRAM_BINARY_TYPE_NONE                 = 0x0,
		CL_PROGRAM_BINARY_TYPE_COMPILED_OBJECT      = 0x1,
		CL_PROGRAM_BINARY_TYPE_LIBRARY              = 0x2,
		CL_PROGRAM_BINARY_TYPE_EXECUTABLE           = 0x4,
	}
}
