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
	[NativeHeader("PlatformDependent/Win/Webcam/PhotoCapture.h")]
	[StaticAccessor("PhotoCapture", StaticAccessorType.DoubleColon)]
	public class PhotoCapture : IDisposable // TypeDefIndex: 7898
	{
		// Fields
		internal IntPtr m_NativePtr; // 0x10
		private static readonly long HR_SUCCESS; // 0x00
	
		// Nested types
		public enum CaptureResultType // TypeDefIndex: 7899
		{
			Success = 0,
			UnknownError = 1
		}
	
		public struct PhotoCaptureResult // TypeDefIndex: 7900
		{
			// Fields
			public CaptureResultType resultType; // 0x00
			public long hResult; // 0x08
		}
	
		public delegate void OnCaptureResourceCreatedCallback(PhotoCapture captureObject); // TypeDefIndex: 7901; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void OnPhotoModeStartedCallback(PhotoCaptureResult result); // TypeDefIndex: 7902; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnPhotoModeStoppedCallback(PhotoCaptureResult result); // TypeDefIndex: 7903; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnCapturedToDiskCallback(PhotoCaptureResult result); // TypeDefIndex: 7904; 0x0000000180A6FEA0-0x0000000180A6FED0
	
		public delegate void OnCapturedToMemoryCallback(PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame); // TypeDefIndex: 7905; 0x0000000180A710A0-0x0000000180A710D0
	
		internal static class BindingsMarshaller // TypeDefIndex: 7906
		{
			// Methods
			public static IntPtr ConvertToNative(PhotoCapture photoCapture); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private PhotoCapture(IntPtr nativeCaptureObject); // 0x000000018219D840-0x000000018219D870
	
		// Methods
		private static PhotoCaptureResult MakeCaptureResult(long hResult); // 0x0000000182208F30-0x0000000182208F90
		[RequiredByNativeCode]
		private static void InvokeOnCreatedResourceDelegate(OnCaptureResourceCreatedCallback callback, IntPtr nativePtr); // 0x0000000182208E80-0x0000000182208F30
		[RequiredByNativeCode]
		private static void InvokeOnPhotoModeStartedDelegate(OnPhotoModeStartedCallback callback, long hResult); // 0x0000000182208C20-0x0000000182208CB0
		[RequiredByNativeCode]
		private static void InvokeOnPhotoModeStoppedDelegate(OnPhotoModeStoppedCallback callback, long hResult); // 0x0000000182208C20-0x0000000182208CB0
		[RequiredByNativeCode]
		private static void InvokeOnCapturedPhotoToDiskDelegate(OnCapturedToDiskCallback callback, long hResult); // 0x0000000182208C20-0x0000000182208CB0
		[RequiredByNativeCode]
		private static void InvokeOnCapturedPhotoToMemoryDelegate(OnCapturedToMemoryCallback callback, long hResult, IntPtr photoCaptureFramePtr); // 0x0000000182208CB0-0x0000000182208E80
		public void Dispose(); // 0x0000000182208AF0-0x0000000182208B80
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("Dispose")]
		private void Dispose_Internal(); // 0x0000000182208A90-0x0000000182208AF0
		~PhotoCapture(); // 0x0000000182208B80-0x0000000182208C20
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod(IsThreadSafe = true)]
		[NativeName("DisposeThreaded")]
		private void DisposeThreaded_Internal(); // 0x00000001822089F0-0x0000000182208A50
		private static void Dispose_Internal_Injected(IntPtr _unity_self); // 0x0000000182208A50-0x0000000182208A90
		private static void DisposeThreaded_Internal_Injected(IntPtr _unity_self); // 0x00000001822089B0-0x00000001822089F0
	}
}
