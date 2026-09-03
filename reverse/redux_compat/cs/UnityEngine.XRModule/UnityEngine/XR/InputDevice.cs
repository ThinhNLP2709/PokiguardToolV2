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
	[UsedByNativeCode]
	public struct InputDevice : IEquatable<InputDevice> // TypeDefIndex: 15351
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static List<XRInputSubsystem> s_InputSubsystemCache; // 0x00
		private ulong m_DeviceId; // 0x00
		private bool m_Initialized; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		private ulong deviceId { get; } // 0x00000001825D39B0-0x00000001825D39D0 
	
		// Constructors
		internal InputDevice(ulong deviceId); // 0x00000001825D39A0-0x00000001825D39B0
		static InputDevice(); // 0x00000001825D3880-0x00000001825D39A0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001825D3620-0x00000001825D3730
		public bool Equals(InputDevice other); // 0x00000001825D3730-0x00000001825D37A0
		public override int GetHashCode(); // 0x00000001825D37A0-0x00000001825D3810
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825D3810-0x00000001825D3880
	}
}
