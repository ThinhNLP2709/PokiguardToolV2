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

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public class AdaptivePerformanceGeneralSettings : ScriptableObject // TypeDefIndex: 14179
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static string k_SettingsKey; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		internal static AdaptivePerformanceGeneralSettings s_RuntimeSettingsInstance; // 0x08
		[SerializeField]
		internal AdaptivePerformanceManagerSettings m_LoaderManagerInstance; // 0x18
		[SerializeField]
		[Tooltip("Enable this to automatically start up Adaptive Performance at runtime.")]
		internal bool m_InitManagerOnStart; // 0x20
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEditor.AdaptivePerformanceModule" })]
		internal string m_LastSelectedProvider; // 0x28
		private AdaptivePerformanceManagerSettings m_AdaptivePerformanceManager; // 0x30
		private bool m_ProviderIntialized; // 0x38
		private bool m_ProviderStarted; // 0x39
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		public AdaptivePerformanceManagerSettings Manager { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public bool IsProviderInitialized { get; } // 0x0000000180476380-0x0000000180476390 
		public bool IsProviderStarted { get; } // 0x00000001814CFF30-0x00000001814CFF40 
		public static AdaptivePerformanceGeneralSettings Instance { get; set; } // 0x0000000182131950-0x00000001821319A0 0x00000001821319A0-0x0000000182131A10
		public AdaptivePerformanceManagerSettings AssignedSettings { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public bool InitManagerOnStart { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 14180
		{
			// Fields
			public static Action _0___Quit; // 0x00
		}
	
		// Constructors
		public AdaptivePerformanceGeneralSettings(); // 0x00000001821318F0-0x0000000182131950
		static AdaptivePerformanceGeneralSettings(); // 0x0000000182131760-0x00000001821318F0
	
		// Methods
		private void Awake(); // 0x0000000182130EE0-0x0000000182131040
		private static void Quit(); // 0x0000000182131350-0x0000000182131430
		private void OnDestroy(); // 0x00000001821312D0-0x0000000182131350
		[RequiredByNativeCode(true)]
		internal static void AttemptInitializeAdaptivePerformanceGeneralSettingsOnLoad(); // 0x0000000182130D20-0x0000000182130E00
		[RequiredByNativeCode(true)]
		internal static void AttemptStartAdaptivePerformanceGeneralSettingsOnBeforeSplashScreen(); // 0x0000000182130E00-0x0000000182130EE0
		internal void InitAdaptivePerformance(); // 0x00000001821310F0-0x00000001821312D0
		internal void StartAdaptivePerformance(); // 0x0000000182131430-0x0000000182131630
		internal void StopAdaptivePerformance(); // 0x0000000182131630-0x00000001821316E0
		internal void DeInitAdaptivePerformance(); // 0x0000000182131040-0x00000001821310F0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001821316E0-0x0000000182131760
	}
}
