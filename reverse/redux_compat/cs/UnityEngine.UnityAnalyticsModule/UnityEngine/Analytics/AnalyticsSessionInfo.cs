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

// Image 64: UnityEngine.UnityAnalyticsModule.dll - Assembly: UnityEngine.UnityAnalyticsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15794-15806

namespace UnityEngine.Analytics
{
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	[RequiredByNativeCode]
	public static class AnalyticsSessionInfo // TypeDefIndex: 15804
	{
		// Fields
		[CompilerGenerated]
		private static SessionStateChanged sessionStateChanged; // 0x00
		[CompilerGenerated]
		private static IdentityTokenChanged identityTokenChanged; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event SessionStateChanged sessionStateChanged {
			add; // 0x00000001825C8A70-0x00000001825C8B40
			remove; // 0x00000001825C8C10-0x00000001825C8CE0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event IdentityTokenChanged identityTokenChanged {
			add; // 0x00000001825C89A0-0x00000001825C8A70
			remove; // 0x00000001825C8B40-0x00000001825C8C10
		}
	
		// Nested types
		public delegate void SessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged); // TypeDefIndex: 15805; 0x0000000180A73E40-0x0000000180A73E60
	
		public delegate void IdentityTokenChanged(string token); // TypeDefIndex: 15806; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		static AnalyticsSessionInfo(); // 0x00000001825C8880-0x00000001825C89A0
	
		// Methods
		[RequiredByNativeCode]
		internal static void CallSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged); // 0x00000001825C84C0-0x00000001825C8560
		[RequiredByNativeCode]
		internal static void CallIdentityTokenChanged(string token); // 0x00000001825C8440-0x00000001825C84C0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825C8560-0x00000001825C8880
	}
}
