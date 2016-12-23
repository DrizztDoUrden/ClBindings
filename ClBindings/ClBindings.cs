using System;
using System.Runtime.InteropServices;
using System.Text;
using ClBindings.Enums;
using ClBindings.Structs;

using cl_bool = System.Boolean;
using cl_uint = System.UInt32;
using cl_ulong = System.UInt64;
using size_t = System.UInt64;
using void_ptr = System.IntPtr;
using const_void_ptr = System.IntPtr;

using cl_command_queue = ClBindings.Handles.ClCommandQueueHandle;
using cl_context = ClBindings.Handles.ClContextHandle;
using cl_device_id = ClBindings.Handles.ClDeviceHandle;
using cl_mem = ClBindings.Handles.ClMemHandle;
using cl_platform_id = ClBindings.Handles.ClPlatformHandle;
using cl_event = ClBindings.Handles.ClEventHandle;
using const_cl_event = ClBindings.Handles.ClEventHandle;
using cl_kernel = ClBindings.Handles.ClKernelHandle;
using cl_program = ClBindings.Handles.ClProgramHandle;
using cl_sampler = ClBindings.Handles.ClSamplerHandle;

namespace ClBindings
{
	public delegate void ClErrorCallback(string errinfo, const_void_ptr private_info, size_t cb, void_ptr user_data);
	public delegate void ClMemObjectDestructorCallback(cl_mem memobj, void_ptr user_data);
	public delegate void ClProgramBuiltCallback(cl_program program, void_ptr user_data);
	public delegate void ClNativeKernelCallback(void_ptr args);
	public delegate void ClEventCallback(cl_event @event, ClExecutionStatus event_command_exec_status, void_ptr user_data);

	public static class CL
	{
#pragma warning disable IDE1006 // Стили именования
#if WINDOWS
		private const string ClPath = @"OpenCL64.dll";
#else
		private const string ClPath = @"OpenCL64.so";
#endif

		[DllImport(ClPath)]
		public static extern ClResult clGetPlatformIDs(cl_uint num_entries, [Out, MarshalAs(UnmanagedType.LPArray)] cl_platform_id[] platforms, out cl_uint num_platforms);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetPlatformIDs(cl_uint num_entries = 0, [Out, MarshalAs(UnmanagedType.LPArray)] cl_platform_id[] platforms = null, cl_uint* num_platforms = null);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern ClResult clGetPlatformInfo(cl_platform_id platform, ClPlatformInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern unsafe ClResult clGetPlatformInfo(cl_platform_id platform, ClPlatformInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceIDs(cl_platform_id platform, ClDeviceType device_type, cl_uint num_entries, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] devices, out cl_uint num_devices);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceIDs(cl_platform_id platform, ClDeviceType device_type, cl_uint num_entries = 0, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] devices = null, cl_uint* num_devices = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)] size_t[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)] size_t[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out size_t param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, size_t* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out cl_bool param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, cl_bool* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceFpConfig param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceFpConfig* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceMemCashType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceMemCashType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceLocalMemType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceLocalMemType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceExecCapabilities param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceExecCapabilities* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClCommandQueueProperties param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClCommandQueueProperties* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out cl_platform_id param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, cl_platform_id* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out cl_device_id param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, cl_device_id* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)] ClDevicePartitionProperty[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)] ClDevicePartitionProperty[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size, out ClDeviceAffinityDomain param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetDeviceInfo(cl_device_id device, ClDeviceInfo param_name, size_t param_value_size = 0, ClDeviceAffinityDomain* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clCreateSubDevices(cl_device_id in_device, ClDevicePartitionProperty[] properties, cl_uint num_devices, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] out_devices, out cl_uint num_devices_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clCreateSubDevices(cl_device_id in_device, ClDevicePartitionProperty[] properties, cl_uint num_devices = 0, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] out_devices = null, cl_uint* num_devices_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clRetainDevice(cl_device_id device);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseDevice(cl_device_id device);

		[DllImport(ClPath)]
		public static extern cl_context clCreateContext(ClContextProperties[] properties, cl_uint num_devices, cl_device_id[] devices, ClErrorCallback pfn_notify, void_ptr user_data, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern cl_context clCreateContextFromType(ClContextProperties[] properties, ClDeviceType device_type, ClErrorCallback pfn_notify, void_ptr user_data, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clRetainContext(cl_context context);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseContext(cl_context context);

		[DllImport(ClPath)]
		public static extern ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size, out uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size = 0, uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)]cl_device_id[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)]cl_device_id[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)]ClContextProperties[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetContextInfo(cl_context context, ClContextInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)]ClContextProperties[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern cl_command_queue clCreateCommandQueue(cl_context context, cl_device_id device, ClCommandQueueProperties properties, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clRetainCommandQueue(cl_command_queue command_queue);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseCommandQueue(cl_command_queue command_queue);

		[DllImport(ClPath)]
		public static extern ClResult clGetCommandQueueInfo(cl_command_queue command_queue, ClCommandQueueInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetCommandQueueInfo(cl_command_queue command_queue, ClCommandQueueInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern cl_mem clCreateBuffer(cl_context context, ClMemFlags flags, size_t size, void_ptr host_ptr, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern cl_mem clCreateSubBuffer(cl_mem buffer, ClMemFlags flags, ClBufferCreateType buffer_create_type, ref ClBufferRegion buffer_create_info, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueReadBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_read, size_t offset, size_t size, void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueReadBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_read, size_t offset, size_t size, void* ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueWriteBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_write, size_t offset, size_t size, const_void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueWriteBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_write, size_t offset, size_t size, void* ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueReadBufferRect(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_read, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t buffer_row_pitch, size_t buffer_slice_pitch, size_t host_row_pitch, size_t host_slice_pitch, void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueReadBufferRect(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_read, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t buffer_row_pitch, size_t buffer_slice_pitch, size_t host_row_pitch, size_t host_slice_pitch, void_ptr ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueWriteBufferRect(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_write, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t buffer_row_pitch, size_t buffer_slice_pitch, size_t host_row_pitch, size_t host_slice_pitch, const_void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueWriteBufferRect(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_write, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t buffer_row_pitch, size_t buffer_slice_pitch, size_t host_row_pitch, size_t host_slice_pitch, const_void_ptr ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueCopyBuffer(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_buffer, size_t src_offset, size_t dst_offset, size_t size, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueCopyBuffer(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_buffer, size_t src_offset, size_t dst_offset, size_t size, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueCopyBufferRect(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_buffer, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t src_row_pitch, size_t src_slice_pitch, size_t dst_row_pitch, size_t dst_slice_pitch, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueCopyBufferRect(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_buffer, size_t[] buffer_origin, size_t[] host_origin, size_t[] region, size_t src_row_pitch, size_t src_slice_pitch, size_t dst_row_pitch, size_t dst_slice_pitch, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueFillBuffer(cl_command_queue command_queue, cl_mem buffer, const_void_ptr pattern, size_t pattern_size, size_t offset, size_t size, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueFillBuffer(cl_command_queue command_queue, cl_mem buffer, const_void_ptr pattern, size_t pattern_size, size_t offset, size_t size, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern void_ptr clEnqueueMapBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_map, ClMapFlags map_flags, size_t offset, size_t size, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern unsafe void* clEnqueueMapBuffer(cl_command_queue command_queue, cl_mem buffer, cl_bool blocking_map, ClMapFlags map_flags, size_t offset, size_t size, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, cl_event* @event, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern cl_mem clCreateImage(cl_context context, ClMemFlags flags, ref ClImageFormat image_format, ref ClImageDesc image_desc, void_ptr host_ptr, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clGetSupportedImageFormats(cl_context context, ClMemFlags flags, ClMemObjectType image_type, cl_uint num_entries, ClImageFormat[] image_formats, out cl_uint num_image_formats);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSupportedImageFormats(cl_context context, ClMemFlags flags, ClMemObjectType image_type, cl_uint num_entries, ClImageFormat[] image_formats, cl_uint* num_image_formats);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueReadImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_read, size_t[] origin, size_t[] region, size_t row_pitch, size_t slice_pitch, void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueReadImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_read, size_t[] origin, size_t[] region, size_t row_pitch, size_t slice_pitch, void_ptr ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueWriteImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_write, size_t[] origin, size_t[] region, size_t input_row_pitch, size_t input_slice_pitch, const_void_ptr ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueWriteImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_write, size_t[] origin, size_t[] region, size_t input_row_pitch, size_t input_slice_pitch, const_void_ptr ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueCopyImage(cl_command_queue command_queue, cl_mem src_image, cl_mem dst_image, size_t[] src_origin, size_t[] dst_origin, size_t[] region, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueCopyImage(cl_command_queue command_queue, cl_mem src_image, cl_mem dst_image, size_t[] src_origin, size_t[] dst_origin, size_t[] region, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueFillImage(cl_command_queue command_queue, cl_mem image, const_void_ptr fill_color, size_t[] origin, size_t[] region, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueFillImage(cl_command_queue command_queue, cl_mem image, const_void_ptr fill_color, size_t[] origin, size_t[] region, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueCopyImageToBuffer(cl_command_queue command_queue, cl_mem src_image, cl_mem dst_buffer, size_t[] src_origin, size_t[] region, size_t dst_offset, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueCopyImageToBuffer(cl_command_queue command_queue, cl_mem src_image, cl_mem dst_buffer, size_t[] src_origin, size_t[] region, size_t dst_offset, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueCopyBufferToImage(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_image, size_t src_offset, size_t[] dst_origin, size_t[] region, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueCopyBufferToImage(cl_command_queue command_queue, cl_mem src_buffer, cl_mem dst_image, size_t src_offset, size_t[] dst_origin, size_t[] region, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern void_ptr clEnqueueMapImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_map, ClMapFlags map_flags, size_t[] origin, size_t[] region, size_t[] image_row_pitch, size_t[] image_slice_pitch, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern unsafe void_ptr clEnqueueMapImage(cl_command_queue command_queue, cl_mem image, cl_bool blocking_map, ClMapFlags map_flags, size_t[] origin, size_t[] region, size_t[] image_row_pitch, size_t[] image_slice_pitch, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, cl_event* @event, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size, out ClImageFormat param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size = 0, ClImageFormat* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size, out size_t param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size = 0, size_t* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size, out cl_mem param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size = 0, cl_mem* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetImageInfo(cl_mem image, ClImageInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clRetainMemObject(cl_mem memobj);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseMemObject(cl_mem memobj);

		[DllImport(ClPath)]
		public static extern ClResult clSetMemObjectDestructorCallback(cl_mem memobj, ClMemObjectDestructorCallback pfn_notify, void_ptr user_data);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueUnmapMemObject(cl_command_queue command_queue, cl_mem memobj, void_ptr mapped_ptr, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueUnmapMemObject(cl_command_queue command_queue, cl_mem memobj, void_ptr mapped_ptr, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueMigrateMemObjects(cl_command_queue command_queue, cl_uint num_mem_objects, cl_mem[] mem_objects, ClMemMigrationFlags flags, cl_uint num_events_in_wait_list, const_cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueMigrateMemObjects(cl_command_queue command_queue, cl_uint num_mem_objects, cl_mem[] mem_objects, ClMemMigrationFlags flags, cl_uint num_events_in_wait_list = 0, const_cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out cl_context param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, cl_context* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out cl_mem param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, cl_mem* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, void** param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out ClMemObjectType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, ClMemObjectType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out ClMemFlags param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, ClMemFlags* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out size_t param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, size_t* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetMemObjectInfo(cl_mem memobj, ClMemInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern cl_sampler clCreateSampler(cl_context context, cl_bool normalized_coords, ClAddressingMode addressing_mode, ClFilterMode filter_mode, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, out cl_context param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, cl_context* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, out cl_bool param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, cl_bool* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, out ClAddressingMode param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, ClAddressingMode* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size, out ClFilterMode param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetSamplerInfo(cl_sampler sampler, ClSamplerInfo param_name, size_t param_value_size = 0, ClFilterMode* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clRetainSampler(cl_sampler sampler);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseSampler(cl_sampler sampler);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern cl_program clCreateProgramWithSource(cl_context context, cl_uint count, string[] strings, size_t[] lengths, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern cl_program clCreateProgramWithBinary(cl_context context, cl_uint num_devices, cl_device_id[] device_list, size_t[] lengths, byte[][] binaries, ClResult[] binary_status, out ClResult errcode_ret);

		[DllImport(ClPath, CharSet = CharSet.Ansi)]
		public static extern cl_program clCreateProgramWithBuiltInKernels(cl_context context, cl_uint num_devices, cl_device_id[] device_list, string kernel_names, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clRetainProgram(cl_program program);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseProgram(cl_program program);

		[DllImport(ClPath)]
		public static extern ClResult clBuildProgram(cl_program program, cl_uint num_devices, cl_device_id[] device_list, string options, ClProgramBuiltCallback pfn_notify, void_ptr user_data);

		[DllImport(ClPath)]
		public static extern ClResult clCompileProgram(cl_program program, cl_uint num_devices, cl_device_id[] device_list, string options, cl_uint num_input_headers, cl_program[] input_headers, string[] header_include_names, ClProgramBuiltCallback pfn_notify, void_ptr user_data);

		[DllImport(ClPath)]
		public static extern cl_program clLinkProgram(cl_context context, cl_uint num_devices, cl_device_id[] device_list, string options, cl_uint num_input_programs, cl_program[] input_programs, ClProgramBuiltCallback pfn_notify, void_ptr user_data, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clUnloadPlatformCompiler(cl_platform_id platform);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, out cl_context param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, cl_context* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)] cl_device_id[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)] size_t[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)] size_t[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size, out size_t param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramInfo(cl_program program, ClProgramInfo param_name, size_t param_value_size = 0, size_t* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size, out ClBuildStatus param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size = 0, ClBuildStatus* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size, out ClProgramBinaryType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetProgramBuildInfo(cl_program program, cl_device_id device, ClProgramBuildInfo param_name, size_t param_value_size = 0, ClProgramBinaryType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern cl_kernel clCreateKernel(cl_program program, string kernel_name, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clCreateKernelsInProgram(cl_program program, cl_uint num_kernels, [Out, MarshalAs(UnmanagedType.LPArray)] cl_kernel[] kernels, out cl_uint num_kernels_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clCreateKernelsInProgram(cl_program program, cl_uint num_kernels, [Out, MarshalAs(UnmanagedType.LPArray)] cl_kernel[] kernels = null, cl_uint* num_kernels_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clRetainKernel(cl_kernel kernel);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseKernel(cl_kernel kernel);

		[DllImport(ClPath)]
		public static extern ClResult clSetKernelArg(cl_kernel kernel, cl_uint arg_index, size_t arg_size, void_ptr arg_value);

		[DllImport(ClPath)]
		public static extern ClResult clSetKernelArg(cl_kernel kernel, cl_uint arg_index, size_t arg_size, ref cl_mem arg_value);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size, out cl_context param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size = 0, cl_context* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size, out cl_program param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelInfo(cl_kernel kernel, ClKernelInfo param_name, size_t param_value_size = 0, cl_program* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size, [Out, MarshalAs(UnmanagedType.LPArray)]size_t[] param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size = 0, [Out, MarshalAs(UnmanagedType.LPArray)]size_t[] param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size, out size_t param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelWorkGroupInfo(cl_kernel kernel, cl_device_id device, ClKernelWorkGroupInfo param_name, size_t param_value_size = 0, size_t* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size, out ClKernArgAddressQualifier param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size = 0, ClKernArgAddressQualifier* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size, out ClKernArgAccessQualifier param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size = 0, ClKernArgAccessQualifier* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size, out ClKernelArgTypeQualifier param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size = 0, ClKernelArgTypeQualifier* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size, StringBuilder param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetKernelArgInfo(cl_kernel kernel, cl_uint arg_indx, ClKernArgInfo param_name, size_t param_value_size = 0, StringBuilder param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueNDRangeKernel(cl_command_queue command_queue, cl_kernel kernel, cl_uint work_dim, size_t[] global_work_offset, size_t[] global_work_size, size_t[] local_work_size, cl_uint num_events_in_wait_list, cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueNDRangeKernel(cl_command_queue command_queue, cl_kernel kernel, cl_uint work_dim, size_t[] global_work_offset, size_t[] global_work_size, size_t[] local_work_size = null, cl_uint num_events_in_wait_list = 0, cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueTask(cl_command_queue command_queue, cl_kernel kernel, cl_uint num_events_in_wait_list, cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueTask(cl_command_queue command_queue, cl_kernel kernel, cl_uint num_events_in_wait_list = 0, cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueNativeKernel(cl_command_queue command_queue, ClNativeKernelCallback user_func, void_ptr args, size_t cb_args, cl_uint num_mem_objects, [In, MarshalAs(UnmanagedType.LPArray)]cl_mem[] mem_list, IntPtr args_mem_loc, cl_uint num_events_in_wait_list, cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueNativeKernel(cl_command_queue command_queue, ClNativeKernelCallback user_func, void* args, size_t cb_args, cl_uint num_mem_objects, cl_mem* mem_list, void** args_mem_loc, cl_uint num_events_in_wait_list = 0, cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern cl_event clCreateUserEvent(cl_context context, out ClResult errcode_ret);

		[DllImport(ClPath)]
		public static extern ClResult clSetUserEventStatus(cl_event @event, ClExecutionStatus execution_status);

		[DllImport(ClPath)]
		public static extern ClResult clWaitForEvents(cl_uint num_events, [In, MarshalAs(UnmanagedType.LPArray)]cl_event[] event_list);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, void* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, out cl_command_queue param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, cl_command_queue* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, out cl_context param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, cl_context* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, out ClCommandType param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, ClCommandType* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, out ClExecutionStatus param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, ClExecutionStatus* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size, out cl_uint param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventInfo(cl_event @event, ClEventInfo param_name, size_t param_value_size = 0, cl_uint* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clSetEventCallback(cl_event @event, ClExecutionStatus command_exec_callback_type, ClEventCallback pfn_event_notify, void_ptr user_data);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clSetEventCallback(cl_event @event, ClExecutionStatus command_exec_callback_type, ClEventCallback pfn_event_notify, void* user_data);

		[DllImport(ClPath)]
		public static extern ClResult clRetainEvent(cl_event @event);

		[DllImport(ClPath)]
		public static extern ClResult clReleaseEvent(cl_event @event);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueMarkerWithWaitList(cl_command_queue command_queue, cl_uint num_events_in_wait_list, cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueMarkerWithWaitList(cl_command_queue command_queue, cl_uint num_events_in_wait_list = 0, cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clEnqueueBarrierWithWaitList(cl_command_queue command_queue, cl_uint num_events_in_wait_list, cl_event[] event_wait_list, out cl_event @event);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clEnqueueBarrierWithWaitList(cl_command_queue command_queue, cl_uint num_events_in_wait_list = 0, cl_event[] event_wait_list = null, cl_event* @event = null);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventProfilingInfo(cl_event @event, ClProfilingInfo param_name, size_t param_value_size, void_ptr param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern ClResult clGetEventProfilingInfo(cl_event @event, ClProfilingInfo param_name, size_t param_value_size, out cl_ulong param_value, out size_t param_value_size_ret);

		[DllImport(ClPath)]
		public static extern unsafe ClResult clGetEventProfilingInfo(cl_event @event, ClProfilingInfo param_name, size_t param_value_size = 0, cl_ulong* param_value = null, size_t* param_value_size_ret = null);

		[DllImport(ClPath)]
		public static extern ClResult clFlush(cl_command_queue command_queue);

		[DllImport(ClPath)]
		public static extern ClResult clFinish(cl_command_queue command_queue);

#pragma warning restore IDE1006 // Стили именования
	}
}
