using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClBindings.Handles;
using ClBindings;
using System.Linq;
using ClBindings.Enums;
using System.Text;

namespace ClClasses
{
    public class ClPlatform
	{
		public string Name => GetParameter(ClPlatformInfo.CL_PLATFORM_NAME);
		public string Extensions => GetParameter(ClPlatformInfo.CL_PLATFORM_EXTENSIONS);
		public string Profile => GetParameter(ClPlatformInfo.CL_PLATFORM_PROFILE);
		public string Vendor => GetParameter(ClPlatformInfo.CL_PLATFORM_VENDOR);
		public string Version => GetParameter(ClPlatformInfo.CL_PLATFORM_VERSION);

		public ClPlatform(ClPlatformHandle handle) => _handle = handle;

		public static unsafe ClPlatform[] GetPlatforms()
		{
			ClUtilities.Check(CL.clGetPlatformIDs(0, null, out var platformsNumber));
			var platforms = new ClPlatformHandle[platformsNumber];

			if (platformsNumber > 0)
				ClUtilities.Check(CL.clGetPlatformIDs(platformsNumber, platforms));

			return platforms.Select(h => new ClPlatform(h)).ToArray();
		}

		public unsafe ClDevice[] GetDevices(ClDeviceType type)
		{
			var result = CL.clGetDeviceIDs(_handle, type, 0, null, out var devicesNumber);

			if (result == ClResult.CL_DEVICE_NOT_FOUND)
				return new ClDevice[0];

			ClUtilities.Check(result);
			var devices = new ClDeviceHandle[devicesNumber];
			ClUtilities.Check(CL.clGetDeviceIDs(_handle, type, devicesNumber, devices));
			return devices.Select(h => new ClDevice(h)).ToArray();
		}

		public unsafe string GetParameter(ClPlatformInfo parameter)
		{
			ClUtilities.Check(CL.clGetPlatformInfo(_handle, parameter, 0, null, out var sLen));
			var sb = new StringBuilder((int)sLen);
			ClUtilities.Check(CL.clGetPlatformInfo(_handle, parameter, sLen, sb));
			return sb.ToString();
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal ClPlatformHandle _handle;
	}
}
