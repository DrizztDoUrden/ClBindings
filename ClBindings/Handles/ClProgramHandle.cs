﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClBindings.Handles
{
    public struct ClProgramHandle
	{
		public IntPtr Value => _handle;

		public bool IsValid => _handle != IntPtr.Zero;

		public static bool operator ==(ClProgramHandle left, IntPtr right) => left._handle == right;
		public static bool operator ==(ClProgramHandle left, ClProgramHandle right) => left._handle == right._handle;
		public static bool operator ==(IntPtr left, ClProgramHandle right) => left == right._handle;
		public static bool operator !=(ClProgramHandle left, IntPtr right) => left._handle != right;
		public static bool operator !=(ClProgramHandle left, ClProgramHandle right) => left._handle != right._handle;
		public static bool operator !=(IntPtr left, ClProgramHandle right) => left != right._handle;

		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null: return _handle == IntPtr.Zero;
				case IntPtr ptr: return _handle == ptr;
				case ClProgramHandle hb: return _handle == hb._handle;
				default: return false;
			}
		}

		public override int GetHashCode() => _handle.GetHashCode();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IntPtr _handle;
	}
}
