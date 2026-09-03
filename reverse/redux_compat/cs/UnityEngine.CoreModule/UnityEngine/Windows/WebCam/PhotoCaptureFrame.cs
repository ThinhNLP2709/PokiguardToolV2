/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Windows.WebCam
{
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
	[NativeHeader("PlatformDependent/Win/Webcam/PhotoCaptureFrame.h")]
	public sealed class PhotoCaptureFrame : IDisposable // TypeDefIndex: 7907
	{
		// Fields
		private IntPtr m_NativePtr; // 0x10
		[CompilerGenerated]
		private int _dataLength_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _hasLocationData_k__BackingField; // 0x1C
		[CompilerGenerated]
		private CapturePixelFormat _pixelFormat_k__BackingField; // 0x20
	
		// Properties
		public int dataLength { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		private bool hasLocationData { [CompilerGenerated] set; } // 0x0000000181E92340-0x0000000181E92350
		private CapturePixelFormat pixelFormat { [CompilerGenerated] set; } // 0x0000000180E332D0-0x0000000180E332E0
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7908
		{
			// Methods
			public static IntPtr ConvertToNative(PhotoCaptureFrame photoCaptureFrame); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		internal PhotoCaptureFrame(IntPtr nativePtr); // 0x0000000182208890-0x00000001822089B0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private int GetDataLength(); // 0x0000000182208790-0x00000001822087F0
		[NativeMethod(IsThreadSafe = true)]
		private bool GetHasLocationData(); // 0x0000000182208830-0x0000000182208890
		[NativeMethod(IsThreadSafe = true)]
		private CapturePixelFormat GetCapturePixelFormat(); // 0x00000001822086F0-0x0000000182208750
		private void Cleanup(); // 0x00000001822084A0-0x0000000182208540
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod(IsThreadSafe = true)]
		[NativeName("Dispose")]
		private void Dispose_Internal(); // 0x0000000182208580-0x00000001822085E0
		public void Dispose(); // 0x00000001822085E0-0x0000000182208640
		~PhotoCaptureFrame(); // 0x0000000182208640-0x00000001822086B0
		private static int GetDataLength_Injected(IntPtr _unity_self); // 0x0000000182208750-0x0000000182208790
		private static bool GetHasLocationData_Injected(IntPtr _unity_self); // 0x00000001822087F0-0x0000000182208830
		private static CapturePixelFormat GetCapturePixelFormat_Injected(IntPtr _unity_self); // 0x00000001822086B0-0x00000001822086F0
		private static void Dispose_Internal_Injected(IntPtr _unity_self); // 0x0000000182208540-0x0000000182208580
	}
}
