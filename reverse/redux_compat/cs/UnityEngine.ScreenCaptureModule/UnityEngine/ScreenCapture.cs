/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 74: UnityEngine.ScreenCaptureModule.dll - Assembly: UnityEngine.ScreenCaptureModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15875-15879

namespace UnityEngine
{
	[NativeHeader("Modules/ScreenCapture/Public/CaptureScreenshot.h")]
	public static class ScreenCapture // TypeDefIndex: 15878
	{
		// Nested types
		public enum StereoScreenCaptureMode // TypeDefIndex: 15879
		{
			LeftEye = 1,
			RightEye = 2,
			BothEyes = 3,
			MotionVectors = 4
		}
	
		// Methods
		public static void CaptureScreenshot(string filename); // 0x00000001822E6500-0x00000001822E6510
		private static void CaptureScreenshot(string filename, [DefaultValue("1")] int superSize, [DefaultValue("1")] StereoScreenCaptureMode CaptureMode); // 0x00000001822E63A0-0x00000001822E6500
		private static void CaptureScreenshot_Injected(ref ManagedSpanWrapper filename, [DefaultValue("1")] int superSize, [DefaultValue("1")] StereoScreenCaptureMode CaptureMode); // 0x00000001822E6350-0x00000001822E63A0
	}
}
