/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Windows.WebCam
{
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	[NativeHeader("PlatformDependent/Win/Webcam/VideoCaptureBindings.h")]
	[StaticAccessor("VideoCaptureBindings", StaticAccessorType.DoubleColon)]
	public class VideoCapture : IDisposable // TypeDefIndex: 7909
	{
		// Fields
		internal IntPtr m_NativePtr; // 0x10
		private static readonly long HR_SUCCESS; // 0x00
	
		// Nested types
		public enum CaptureResultType // TypeDefIndex: 7910
		{
			Success = 0,
			UnknownError = 1
		}
	
		public struct VideoCaptureResult // TypeDefIndex: 7911
		{
			// Fields
			public CaptureResultType resultType; // 0x00
			public long hResult; // 0x08
		}
	
		public delegate void OnVideoCaptureResourceCreatedCallback(VideoCapture captureObject); // TypeDefIndex: 7912; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void OnVideoModeStartedCallback(VideoCaptureResult result); // TypeDefIndex: 7913; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnVideoModeStoppedCallback(VideoCaptureResult result); // TypeDefIndex: 7914; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnStartedRecordingVideoCallback(VideoCaptureResult result); // TypeDefIndex: 7915; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnStoppedRecordingVideoCallback(VideoCaptureResult result); // TypeDefIndex: 7916; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		internal static class BindingsMarshaller // TypeDefIndex: 7917
		{
			// Methods
			public static IntPtr ConvertToNative(VideoCapture videoCapture); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private VideoCapture(IntPtr nativeCaptureObject); // 0x000000018219D840-0x000000018219D870
	
		// Methods
		private static VideoCaptureResult MakeCaptureResult(long hResult); // 0x00000001822290E0-0x0000000182229140
		[RequiredByNativeCode]
		private static void InvokeOnCreatedVideoCaptureResourceDelegate(OnVideoCaptureResourceCreatedCallback callback, IntPtr nativePtr); // 0x0000000182228FA0-0x0000000182229050
		[RequiredByNativeCode]
		private static void InvokeOnVideoModeStartedDelegate(OnVideoModeStartedCallback callback, long hResult); // 0x0000000182229050-0x00000001822290E0
		[RequiredByNativeCode]
		private static void InvokeOnVideoModeStoppedDelegate(OnVideoModeStoppedCallback callback, long hResult); // 0x0000000182229050-0x00000001822290E0
		[RequiredByNativeCode]
		private static void InvokeOnStartedRecordingVideoToDiskDelegate(OnStartedRecordingVideoCallback callback, long hResult); // 0x0000000182229050-0x00000001822290E0
		[RequiredByNativeCode]
		private static void InvokeOnStoppedRecordingVideoToDiskDelegate(OnStoppedRecordingVideoCallback callback, long hResult); // 0x0000000182229050-0x00000001822290E0
		public void Dispose(); // 0x0000000182228E70-0x0000000182228F00
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod("VideoCaptureBindings::Dispose", HasExplicitThis = true)]
		private void Dispose_Internal(); // 0x0000000182228E10-0x0000000182228E70
		~VideoCapture(); // 0x0000000182228F00-0x0000000182228FA0
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod("VideoCaptureBindings::DisposeThreaded", HasExplicitThis = true, IsThreadSafe = true)]
		private void DisposeThreaded_Internal(); // 0x0000000182228D70-0x0000000182228DD0
		private static void Dispose_Internal_Injected(IntPtr _unity_self); // 0x0000000182228DD0-0x0000000182228E10
		private static void DisposeThreaded_Internal_Injected(IntPtr _unity_self); // 0x0000000182228D30-0x0000000182228D70
	}
}
