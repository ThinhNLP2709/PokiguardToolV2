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

namespace UnityEngine
{
	[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	public static class RemoteSettings // TypeDefIndex: 15797
	{
		// Fields
		[CompilerGenerated]
		private static UpdatedEventHandler Updated; // 0x00
		[CompilerGenerated]
		private static Action BeforeFetchFromServer; // 0x08
		[CompilerGenerated]
		private static Action<bool, bool, int> Completed; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event UpdatedEventHandler Updated {
			add; // 0x00000001825C9610-0x00000001825C96E0
			remove; // 0x00000001825C98A0-0x00000001825C9970
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action BeforeFetchFromServer {
			add; // 0x00000001825C9450-0x00000001825C9520
			remove; // 0x00000001825C96E0-0x00000001825C97B0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool, bool, int> Completed {
			add; // 0x00000001825C9520-0x00000001825C9610
			remove; // 0x00000001825C97B0-0x00000001825C98A0
		}
	
		// Nested types
		public delegate void UpdatedEventHandler(); // TypeDefIndex: 15798; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		static RemoteSettings(); // 0x00000001825C9330-0x00000001825C9450
	
		// Methods
		[RequiredByNativeCode]
		internal static void RemoteSettingsUpdated(bool wasLastUpdatedFromServer); // 0x00000001825C8E20-0x00000001825C8E90
		[RequiredByNativeCode]
		internal static void RemoteSettingsBeforeFetchFromServer(); // 0x00000001825C8D10-0x00000001825C8D80
		[RequiredByNativeCode]
		internal static void RemoteSettingsUpdateCompleted(bool wasLastUpdatedFromServer, bool settingsChanged, int response); // 0x00000001825C8D80-0x00000001825C8E20
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001825C8E90-0x00000001825C9330
	}
}
