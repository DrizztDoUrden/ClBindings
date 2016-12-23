using System;
using System.Collections.Generic;

namespace ClBindings.Enums
{
    public enum ClCommandType : ulong
	{
		CL_COMMAND_NDRANGE_KERNEL                   = 0x11F0,
		CL_COMMAND_TASK                             = 0x11F1,
		CL_COMMAND_NATIVE_KERNEL                    = 0x11F2,
		CL_COMMAND_READ_BUFFER                      = 0x11F3,
		CL_COMMAND_WRITE_BUFFER                     = 0x11F4,
		CL_COMMAND_COPY_BUFFER                      = 0x11F5,
		CL_COMMAND_READ_IMAGE                       = 0x11F6,
		CL_COMMAND_WRITE_IMAGE                      = 0x11F7,
		CL_COMMAND_COPY_IMAGE                       = 0x11F8,
		CL_COMMAND_COPY_IMAGE_TO_BUFFER             = 0x11F9,
		CL_COMMAND_COPY_BUFFER_TO_IMAGE             = 0x11FA,
		CL_COMMAND_MAP_BUFFER                       = 0x11FB,
		CL_COMMAND_MAP_IMAGE                        = 0x11FC,
		CL_COMMAND_UNMAP_MEM_OBJECT                 = 0x11FD,
		CL_COMMAND_MARKER                           = 0x11FE,
		CL_COMMAND_ACQUIRE_GL_OBJECTS               = 0x11FF,
		CL_COMMAND_RELEASE_GL_OBJECTS               = 0x1200,
		CL_COMMAND_READ_BUFFER_RECT                 = 0x1201,
		CL_COMMAND_WRITE_BUFFER_RECT                = 0x1202,
		CL_COMMAND_COPY_BUFFER_RECT                 = 0x1203,
		CL_COMMAND_USER                             = 0x1204,
		CL_COMMAND_BARRIER                          = 0x1205,
		CL_COMMAND_MIGRATE_MEM_OBJECTS              = 0x1206,
		CL_COMMAND_FILL_BUFFER                      = 0x1207,
		CL_COMMAND_FILL_IMAGE                       = 0x1208,
		CL_COMMAND_SVM_FREE                         = 0x1209,
		CL_COMMAND_SVM_MEMCPY                       = 0x120A,
		CL_COMMAND_SVM_MEMFILL                      = 0x120B,
		CL_COMMAND_SVM_MAP                          = 0x120C,
		CL_COMMAND_SVM_UNMAP                        = 0x120D,
    }
}
