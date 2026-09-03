/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public static class Holder // TypeDefIndex: 14143
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static IAdaptivePerformance m_Instance; // 0x00
		[CompilerGenerated]
		private static LifecycleEventHandler LifecycleEventHandler; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		public static IAdaptivePerformance Instance { get; internal set; } // 0x0000000182143150-0x00000001821431A0 0x0000000182143270-0x0000000182143340
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event LifecycleEventHandler LifecycleEventHandler {
			add; // 0x0000000182143080-0x0000000182143150
			remove; // 0x00000001821431A0-0x0000000182143270
		}
	
		// Constructors
		static Holder(); // 0x0000000182142F60-0x0000000182143080
	
		// Methods
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182142D60-0x0000000182142F60
	}
}
