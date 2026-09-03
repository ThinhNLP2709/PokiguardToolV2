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
using UnityEngine.Scripting;

// Image 65: UnityEngine.InputModule.dll - Assembly: UnityEngine.InputModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15807-15817

namespace UnityEngineInternal.Input
{
	[NativeHeader("Modules/Input/Private/InputInternal.h")]
	[NativeHeader("Modules/Input/Private/InputModuleBindings.h")]
	internal class NativeInputSystem // TypeDefIndex: 15816
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		public static NativeUpdateCallback onUpdate; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		public static Action<NativeInputUpdateType> onBeforeUpdate; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		public static Func<NativeInputUpdateType, bool> onShouldRunUpdate; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static Action<int, string> s_OnDeviceDiscoveredCallback; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x20
	
		// Properties
		public static Action<int, string> onDeviceDiscovered { get; set; } // 0x00000001822AE800-0x00000001822AE850 0x00000001822AE900-0x00000001822AE9B0
		internal static bool hasDeviceDiscoveredCallback { set; } // 0x00000001822AE880-0x00000001822AE8C0
		[NativeProperty(IsThreadSafe = true)]
		public static double currentTime { get; } // 0x00000001822AE7A0-0x00000001822AE7D0 
		[NativeProperty(IsThreadSafe = true)]
		public static double currentTimeOffsetToRealtimeSinceStartup { get; } // 0x00000001822AE770-0x00000001822AE7A0 
		[NativeProperty("NormalizeScrollWheelDelta")]
		internal static bool normalizeScrollWheelDelta { get; set; } // 0x00000001822AE7D0-0x00000001822AE800 0x00000001822AE8C0-0x00000001822AE900
		internal static bool useImplicitMouseEventScriptCallbacks { get; } // 0x00000001822AE850-0x00000001822AE880 
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15817
		{
			// Fields
			public static Action _0___Clear; // 0x00
		}
	
		// Constructors
		static NativeInputSystem(); // 0x00000001822AE650-0x00000001822AE770
	
		// Methods
		private static void Clear(); // 0x00000001822ADF50-0x00000001822ADFB0
		[RequiredByNativeCode]
		internal static void NotifyDeviceDiscovered(int deviceId, string deviceDescriptor); // 0x00000001822AE210-0x00000001822AE290
		[RequiredByNativeCode]
		internal static void NotifyBeforeUpdate(NativeInputUpdateType updateType, out int continueUpdate); // 0x00000001822AE150-0x00000001822AE210
		[RequiredByNativeCode]
		internal static void ProcessInputUpdate(NativeInputUpdateType updateType, IntPtr eventBuffer); // 0x00000001822AE290-0x00000001822AE330
		internal static void DoSendMouseEvents(bool leftButtonPressed, bool wasPressedThisFrame, float posX, float posY); // 0x00000001822ADFB0-0x00000001822AE090
		[FreeFunction("AllocateInputDeviceId")]
		public static int AllocateDeviceId(); // 0x00000001822ADF20-0x00000001822ADF50
		[NativeMethod(IsThreadSafe = true)]
		public static void QueueInputEvent(IntPtr inputEvent); // 0x00000001822AE330-0x00000001822AE370
		public static long IOCTL(int deviceId, int code, IntPtr data, int sizeInBytes); // 0x00000001822AE0F0-0x00000001822AE150
		public static void SetPollingFrequency(float hertz); // 0x00000001822AE370-0x00000001822AE3B0
		public static float GetPollingFrequency(); // 0x00000001822AE090-0x00000001822AE0C0
		public static void Update(NativeInputUpdateType updateType); // 0x00000001822AE500-0x00000001822AE540
		internal static float GetScrollWheelDeltaPerTick(); // 0x00000001822AE0C0-0x00000001822AE0F0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822AE540-0x00000001822AE650
		[CompilerGenerated]
		internal static void UnityEngineInternal_Input_NativeInputSystem_Clear_RegisterLifecycleMethod(); // 0x00000001822AE3B0-0x00000001822AE500
	}
}
