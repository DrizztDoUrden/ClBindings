using ClBindings.Enums;
using ClBindings.Handles;
using System;
using System.Collections.Generic;

namespace ClBindings.Structs
{
    public struct ClImageDesc
    {
		ClMemObjectType image_type;
		ulong image_width;
		ulong image_height;
		ulong image_depth;
		ulong image_array_size;
		ulong image_row_pitch;
		ulong image_slice_pitch;
		uint num_mip_levels;
		uint num_samples;
		ClMemHandle buffer;
	}
}
