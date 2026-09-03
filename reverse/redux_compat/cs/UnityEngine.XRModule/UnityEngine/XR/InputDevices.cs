/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_VR")]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	[UsedByNativeCode]
	public class InputDevices // TypeDefIndex: 15355
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static List<InputDevice> s_InputDeviceList; // 0x00
		[CompilerGenerated]
		private static Action<InputDevice> deviceConnected; // 0x08
		[CompilerGenerated]
		private static Action<InputDevice> deviceDisconnected; // 0x10
		[CompilerGenerated]
		private static Action<InputDevice> deviceConfigChanged; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x20
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<InputDevice> deviceConnected {
			add; // 0x00000001825D41F0-0x00000001825D42E0
			remove; // 0x00000001825D44C0-0x00000001825D45B0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<InputDevice> deviceDisconnected {
			add; // 0x00000001825D42E0-0x00000001825D43D0
			remove; // 0x00000001825D45B0-0x00000001825D46A0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<InputDevice> deviceConfigChanged {
			add; // 0x00000001825D4100-0x00000001825D41F0
			remove; // 0x00000001825D43D0-0x00000001825D44C0
		}
	
		// Constructors
		static InputDevices(); // 0x00000001825D3FE0-0x00000001825D4100
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokeConnectionEvent(ulong deviceId, ConnectionChangeType change); // 0x00000001825D39D0-0x00000001825D3AE0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825D3AE0-0x00000001825D3FE0
	}
}
