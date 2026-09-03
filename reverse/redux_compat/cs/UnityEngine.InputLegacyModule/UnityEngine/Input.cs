/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 60: UnityEngine.InputLegacyModule.dll - Assembly: UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15737-15751

namespace UnityEngine
{
	[NativeHeader("Runtime/Input/InputBindings.h")]
	public class Input // TypeDefIndex: 15750
	{
		// Fields
		[CompilerGenerated]
		private static bool _simulateTouchEnabled_k__BackingField; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static LocationService locationServiceInstance; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static Compass compassInstance; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static Gyroscope s_MainGyro; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x20
	
		// Properties
		public static bool simulateMouseWithTouches { set; } // 0x00000001822ADE80-0x00000001822ADEC0
		[NativeMethod(ThrowsException = true)]
		public static bool anyKeyDown { get; } // 0x00000001822AD660-0x00000001822AD690 
		[NativeMethod(ThrowsException = true)]
		public static Vector3 mousePosition { get; } // 0x00000001822AD8E0-0x00000001822AD950 
		[NativeMethod(ThrowsException = true)]
		public static Vector2 mouseScrollDelta { get; } // 0x00000001822ADA50-0x00000001822ADAC0 
		public static IMECompositionMode imeCompositionMode { get; set; } // 0x00000001822AD870-0x00000001822AD8A0 0x00000001822ADE40-0x00000001822ADE80
		public static string compositionString { get; } // 0x00000001822AD780-0x00000001822AD870 
		public static Vector2 compositionCursorPos { get; set; } // 0x00000001822AD6D0-0x00000001822AD740 0x00000001822ADDD0-0x00000001822ADE40
		[AutoStaticsCleanupOnCodeReload]
		internal static bool simulateTouchEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001822ADAC0-0x00000001822ADB10 0x00000001822ADEC0-0x00000001822ADF20
		public static bool mousePresent { get; } // 0x00000001822AD950-0x00000001822ADA10 
		public static bool touchSupported { get; } // 0x00000001822ADB40-0x00000001822ADC00 
		public static int touchCount { [FreeFunction("GetTouchCount")] get; } // 0x00000001822ADB10-0x00000001822ADB40 
		public static Touch[] touches { get; } // 0x00000001822ADC00-0x00000001822ADD90 
	
		// Constructors
		static Input(); // 0x00000001822AD540-0x00000001822AD660
	
		// Methods
		public static float GetAxis(string axisName); // 0x00000001822ACFD0-0x00000001822ACFE0
		public static float GetAxisRaw(string axisName); // 0x00000001822ACFC0-0x00000001822ACFD0
		public static bool GetButtonDown(string buttonName); // 0x00000001822ACFE0-0x00000001822ACFF0
		[NativeMethod(ThrowsException = true)]
		private static bool GetKeyInt(KeyCode key); // 0x00000001822AD0A0-0x00000001822AD0E0
		[NativeMethod(ThrowsException = true)]
		private static bool GetKeyDownInt(KeyCode key); // 0x00000001822ACFF0-0x00000001822AD030
		[NativeMethod(ThrowsException = true)]
		public static bool GetMouseButton(int button); // 0x00000001822AD290-0x00000001822AD2D0
		[NativeMethod(ThrowsException = true)]
		public static bool GetMouseButtonDown(int button); // 0x00000001822AD210-0x00000001822AD250
		[NativeMethod(ThrowsException = true)]
		public static bool GetMouseButtonUp(int button); // 0x00000001822AD250-0x00000001822AD290
		[NativeMethod(ThrowsException = true)]
		public static Touch GetTouch(int index); // 0x00000001822AD370-0x00000001822AD400
		[NativeMethod(ThrowsException = true)]
		public static PenData GetLastPenContactEvent(); // 0x00000001822AD190-0x00000001822AD210
		public static bool GetKey(KeyCode key); // 0x00000001822AD0E0-0x00000001822AD150
		public static bool GetKeyDown(KeyCode key); // 0x00000001822AD030-0x00000001822AD0A0
		[FreeFunction("GetMousePresent")]
		private static bool GetMousePresentInternal(); // 0x00000001822AD2D0-0x00000001822AD300
		[FreeFunction("IsTouchSupported")]
		private static bool GetTouchSupportedInternal(); // 0x00000001822AD300-0x00000001822AD330
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822AD400-0x00000001822AD540
		private static void GetTouch_Injected(int index, ); // 0x00000001822AD330-0x00000001822AD370
		private static void GetLastPenContactEvent_Injected(); // 0x00000001822AD150-0x00000001822AD190
		private static void get_mousePosition_Injected(); // 0x00000001822AD8A0-0x00000001822AD8E0
		private static void get_mouseScrollDelta_Injected(); // 0x00000001822ADA10-0x00000001822ADA50
		private static void get_compositionString_Injected(); // 0x00000001822AD740-0x00000001822AD780
		private static void get_compositionCursorPos_Injected(); // 0x00000001822AD690-0x00000001822AD6D0
		private static void set_compositionCursorPos_Injected(in Vector2 value); // 0x00000001822ADD90-0x00000001822ADDD0
	}
}
