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

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_VR")]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTrackingFacade.h")]
	[RequiredByNativeCode]
	[StaticAccessor("XRInputTrackingFacade::Get()", StaticAccessorType.Dot)]
	public static class InputTracking // TypeDefIndex: 15340
	{
		// Fields
		[CompilerGenerated]
		private static Action<XRNodeState> trackingAcquired; // 0x00
		[CompilerGenerated]
		private static Action<XRNodeState> trackingLost; // 0x08
		[CompilerGenerated]
		private static Action<XRNodeState> nodeAdded; // 0x10
		[CompilerGenerated]
		private static Action<XRNodeState> nodeRemoved; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x20
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<XRNodeState> trackingAcquired {
			add; // 0x00000001825D5410-0x00000001825D5500
			remove; // 0x00000001825D57D0-0x00000001825D58C0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<XRNodeState> trackingLost {
			add; // 0x00000001825D5500-0x00000001825D55F0
			remove; // 0x00000001825D58C0-0x00000001825D59B0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<XRNodeState> nodeAdded {
			add; // 0x00000001825D5230-0x00000001825D5320
			remove; // 0x00000001825D55F0-0x00000001825D56E0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<XRNodeState> nodeRemoved {
			add; // 0x00000001825D5320-0x00000001825D5410
			remove; // 0x00000001825D56E0-0x00000001825D57D0
		}
	
		// Nested types
		private enum TrackingStateEventType // TypeDefIndex: 15341
		{
			NodeAdded = 0,
			NodeRemoved = 1,
			TrackingAcquired = 2,
			TrackingLost = 3
		}
	
		// Constructors
		static InputTracking(); // 0x00000001825D5060-0x00000001825D5230
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokeTrackingEvent(TrackingStateEventType eventType, XRNode nodeType, long uniqueID, bool tracked); // 0x00000001825D4800-0x00000001825D4A20
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825D4A20-0x00000001825D5060
	}
}
