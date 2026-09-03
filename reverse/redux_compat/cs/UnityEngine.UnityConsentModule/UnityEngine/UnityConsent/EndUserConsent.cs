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

// Image 85: UnityEngine.UnityConsentModule.dll - Assembly: UnityEngine.UnityConsentModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15967-15972

namespace UnityEngine.UnityConsent
{
	[NativeHeader("Modules/UnityConsent/EndUserConsent.h")]
	public static class EndUserConsent // TypeDefIndex: 15972
	{
		// Fields
		[CompilerGenerated]
		private static Action<ConsentState> consentStateChanged; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ConsentState> consentStateChanged {
			add; // 0x00000001825CA100-0x00000001825CA1F0
			remove; // 0x00000001825CA1F0-0x00000001825CA2E0
		}
	
		// Constructors
		static EndUserConsent(); // 0x00000001825C9FE0-0x00000001825CA100
	
		// Methods
		[NativeMethod("GetConsentStateStatic")]
		public static ConsentState GetConsentState(); // 0x00000001825C9C90-0x00000001825C9D00
		[RequiredByNativeCode]
		private static void OnConsentStateChanged(); // 0x00000001825C9D00-0x00000001825C9DE0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825C9DE0-0x00000001825C9FE0
		private static void GetConsentState_Injected(); // 0x00000001825C9C50-0x00000001825C9C90
	}
}
