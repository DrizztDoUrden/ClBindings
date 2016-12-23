using ClBindings;
using ClBindings.Enums;
using ClBindings.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClClasses
{
    public class ClDevice
    {
		public ClDeviceType Type								=> GetPropertyAsType(ClDeviceInfo.CL_DEVICE_TYPE);
		public uint VendorId									=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_VENDOR_ID);
		public uint MaxComputeUnit								=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_COMPUTE_UNITS);
		public uint MaxWorkItemDimensions						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_WORK_ITEM_DIMENSIONS);
		public ulong[] MaxWorkItemSizes							=> GetPropertyAsUlongs(ClDeviceInfo.CL_DEVICE_MAX_WORK_ITEM_SIZES);
		public ulong MaxWorkGroupSizes							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_MAX_WORK_GROUP_SIZE);

		public uint PreferredVectorWithChar						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_CHAR);
		public uint PreferredVectorWithShort					=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_SHORT);
		public uint PreferredVectorWithInt						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_INT);
		public uint PreferredVectorWithLong						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_LONG);
		public uint PreferredVectorWithFloat					=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_FLOAT);
		public uint PreferredVectorWithDouble					=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE);
		public uint PreferredVectorWithHalf						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF);

		public uint NativeVectorWithChar						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_CHAR);
		public uint NativeVectorWithShort						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_SHORT);
		public uint NativeVectorWithInt							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_INT);
		public uint NativeVectorWithLong						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_LONG);
		public uint NativeVectorWithFloat						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_FLOAT);
		public uint NativeVectorWithDouble						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE);
		public uint NativeVectorWithHalf						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF);

		public uint MaxClockFrequency							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_CLOCK_FREQUENCY);
		public uint AddressBits									=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_ADDRESS_BITS);
		public ulong MaxMemAllocSize							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_MAX_MEM_ALLOC_SIZE);
		public bool ImageSupport								=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_IMAGE_SUPPORT);
		public uint MaxReadImageArgs							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_READ_IMAGE_ARGS);
		public uint MaxWriteImageArgs							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_WRITE_IMAGE_ARGS);
		public ulong Image2dMaxWidth							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE2D_MAX_WIDTH);
		public ulong Image2dMaxHeight							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE2D_MAX_HEIGHT);
		public ulong Image3dMaxWidth							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE3D_MAX_WIDTH);
		public ulong Image3dMaxHeight							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE3D_MAX_HEIGHT);
		public ulong Image3dMaxDepth							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE3D_MAX_DEPTH);
		public ulong ImageMaxBufferSize							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE_MAX_BUFFER_SIZE);
		public ulong ImageMaxArraySize							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_IMAGE_MAX_ARRAY_SIZE);
		public uint ImageMaxSamplers							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MAX_SAMPLERS);
		public ulong ImageMaxParameterSize						=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_MAX_PARAMETER_SIZE);
		public uint MemBaseAddressAlign							=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_MEM_BASE_ADDR_ALIGN);
		public ClDeviceFpConfig SingleFpConfig					=> GetPropertyAsFpConfig(ClDeviceInfo.CL_DEVICE_SINGLE_FP_CONFIG);
		public ClDeviceFpConfig DoubleFpConfig					=> GetPropertyAsFpConfig(ClDeviceInfo.CL_DEVICE_DOUBLE_FP_CONFIG);
		public ClDeviceMemCashType GlobalMemCacheType			=> GetPropertyAsGlobalMemCashType(ClDeviceInfo.CL_DEVICE_GLOBAL_MEM_CACHE_TYPE);
		public uint GlobalMemCashLineSize						=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_GLOBAL_MEM_CACHELINE_SIZE);
		public ulong GlobalMemCashSize							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_GLOBAL_MEM_CACHE_SIZE);
		public ulong GlobalMemSize								=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_GLOBAL_MEM_SIZE);
		public ClDeviceLocalMemType LocalMemType				=> GetPropertyAsLocalMemType(ClDeviceInfo.CL_DEVICE_LOCAL_MEM_TYPE);
		public ulong LocalMemSize								=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_LOCAL_MEM_SIZE);
		public bool ErrorCorrectionSupport						=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_ERROR_CORRECTION_SUPPORT);
		public bool HostUnifiedMemory							=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_HOST_UNIFIED_MEMORY);
		public ulong ProfilingTimerResolution					=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_PROFILING_TIMER_RESOLUTION);
		public bool EndianLittle								=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_ENDIAN_LITTLE);
		public bool Available									=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_AVAILABLE);
		public bool CompilerAvailable							=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_COMPILER_AVAILABLE);
		public bool LinkerAvailable								=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_LINKER_AVAILABLE);
		public ClDeviceExecCapabilities ExecutionCapabilities	=> GetPropertyAsExecCapabilities(ClDeviceInfo.CL_DEVICE_EXECUTION_CAPABILITIES);
		public ClCommandQueueProperties QueueProperties			=> GetPropertyAsCommandQueueProperties(ClDeviceInfo.CL_DEVICE_QUEUE_PROPERTIES);
		public string BuiltInKernels							=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_BUILT_IN_KERNELS);
		public ClPlatform Platform								=> GetPropertyAsPlatform(ClDeviceInfo.CL_DEVICE_PLATFORM);
		public string Name										=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_NAME);
		public string Vendor									=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_VENDOR);
		public string Version									=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_VERSION);
		public string Profile									=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_PROFILE);
		public string DriverVersion								=> GetPropertyAsString(ClDeviceInfo.CL_DRIVER_VERSION);
		public string OpenClCVersion							=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_OPENCL_C_VERSION);
		public string DeviceExtensions							=> GetPropertyAsString(ClDeviceInfo.CL_DEVICE_EXTENSIONS);
		public ulong PrintfBufferSize							=> GetPropertyAsUlong(ClDeviceInfo.CL_DEVICE_PRINTF_BUFFER_SIZE);
		public bool PreferredInteropUserSync					=> GetPropertyAsBool(ClDeviceInfo.CL_DEVICE_PREFERRED_INTEROP_USER_SYNC);
		public ClDevice Parent									=> GetPropertyAsDevice(ClDeviceInfo.CL_DEVICE_PARENT_DEVICE);
		public uint MaxSubDevices								=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_PARTITION_MAX_SUB_DEVICES);
		public ClDevicePartitionProperty[] PartitionProperties	=> GetPropertyAsPartitionProperties(ClDeviceInfo.CL_DEVICE_PARTITION_PROPERTIES);
		public ClDeviceAffinityDomain AffinityDomain			=> GetPropertyAsAffinityDomain(ClDeviceInfo.CL_DEVICE_PARTITION_AFFINITY_DOMAIN);
		public ClDevicePartitionProperty[] PartitionType		=> GetPropertyAsPartitionProperties(ClDeviceInfo.CL_DEVICE_PARTITION_TYPE);
		public uint ReferenceCount								=> GetPropertyAsUint(ClDeviceInfo.CL_DEVICE_REFERENCE_COUNT);

		public ClDevice(ClDeviceHandle handle) => _handle = handle;

		public ClRetainedDevice Retain()
		{
			ClUtilities.Check(CL.clRetainDevice(_handle));
			return new ClRetainedDevice(_handle);
		}

		public unsafe ClRetainedDevice[] CreateSubDevices(ClDevicePartitionProperty[] properties)
		{
			ClUtilities.Check(CL.clCreateSubDevices(_handle, properties, 0, null, out var subDeviceNumber));
			var subDevices = new ClDeviceHandle[subDeviceNumber];
			ClUtilities.Check(CL.clCreateSubDevices(_handle, properties, subDeviceNumber, subDevices));
			return subDevices.Select(h => new ClRetainedDevice(h)).ToArray();
		}

		public unsafe ClDeviceType GetPropertyAsType(ClDeviceInfo property)
		{
			ClDeviceType value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceType), &value));
			return value;
		}

		public unsafe ulong GetPropertyAsUlong(ClDeviceInfo property)
		{
			ulong value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ulong), &value));
			return value;
		}

		public unsafe uint GetPropertyAsUint(ClDeviceInfo property)
		{
			uint value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(uint), &value));
			return value;
		}

		public unsafe bool GetPropertyAsBool(ClDeviceInfo property)
		{
			bool value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(bool), &value));
			return value;
		}

		public unsafe ulong[] GetPropertyAsUlongs(ClDeviceInfo property)
		{
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, 0, IntPtr.Zero, out var size));
			ulong[] value = new ulong[size/sizeof(ulong)];
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, size, value));
			return value;
		}

		public unsafe ClDeviceFpConfig GetPropertyAsFpConfig(ClDeviceInfo property)
		{
			ClDeviceFpConfig value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceFpConfig), &value));
			return value;
		}

		public unsafe ClDeviceMemCashType GetPropertyAsGlobalMemCashType(ClDeviceInfo property)
		{
			ClDeviceMemCashType value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceMemCashType), &value));
			return value;
		}

		public unsafe ClDeviceLocalMemType GetPropertyAsLocalMemType	(ClDeviceInfo property)
		{
			ClDeviceLocalMemType value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceLocalMemType), &value));
			return value;
		}

		public unsafe ClDeviceExecCapabilities GetPropertyAsExecCapabilities(ClDeviceInfo property)
		{
			ClDeviceExecCapabilities value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceExecCapabilities), &value));
			return value;
		}

		public unsafe ClCommandQueueProperties GetPropertyAsCommandQueueProperties(ClDeviceInfo property)
		{
			ClCommandQueueProperties value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClCommandQueueProperties), &value));
			return value;
		}

		public unsafe string GetPropertyAsString(ClDeviceInfo property)
		{
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, 0, IntPtr.Zero, out var size));
			StringBuilder value = new StringBuilder((int)size);
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, size, value));
			return value.ToString();
		}

		public unsafe ClPlatform GetPropertyAsPlatform(ClDeviceInfo property)
		{
			ClPlatformHandle value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, (ulong)sizeof(IntPtr), &value));
			return value.IsValid ? new ClPlatform(value) : null;
		}

		public unsafe ClDevice GetPropertyAsDevice(ClDeviceInfo property)
		{
			ClDeviceHandle value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, (ulong)sizeof(IntPtr), &value));
			return value.IsValid ? new ClDevice(value) : null;
		}

		public unsafe ClDevicePartitionProperty[] GetPropertyAsPartitionProperties(ClDeviceInfo property)
		{
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, 0, IntPtr.Zero, out var size));
			ClDevicePartitionProperty[] value = new ClDevicePartitionProperty[size/sizeof(ulong)];
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, size, value));
			return value;
		}

		public unsafe ClDeviceAffinityDomain GetPropertyAsAffinityDomain(ClDeviceInfo property)
		{
			ClDeviceAffinityDomain value;
			ClUtilities.Check(CL.clGetDeviceInfo(_handle, property, sizeof(ClDeviceAffinityDomain), &value));
			return value;
		}

		internal ClDeviceHandle _handle;
    }
}
