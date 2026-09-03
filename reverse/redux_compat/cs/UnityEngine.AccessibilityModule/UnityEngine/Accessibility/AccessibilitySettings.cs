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

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	[NativeHeader("Modules/Accessibility/Native/AccessibilitySettings.h")]
	public static class AccessibilitySettings // TypeDefIndex: 15625
	{
		// Fields
		[CompilerGenerated]
		private static Action<float> fontScaleChanged; // 0x00
		[CompilerGenerated]
		private static Action<bool> boldTextStatusChanged; // 0x08
		[CompilerGenerated]
		private static Action<bool> closedCaptioningStatusChanged; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<float> fontScaleChanged {
			add; // 0x000000018212DB20-0x000000018212DC10
			remove; // 0x000000018212DDF0-0x000000018212DEE0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> boldTextStatusChanged {
			add; // 0x000000018212D940-0x000000018212DA30
			remove; // 0x000000018212DC10-0x000000018212DD00
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> closedCaptioningStatusChanged {
			add; // 0x000000018212DA30-0x000000018212DB20
			remove; // 0x000000018212DD00-0x000000018212DDF0
		}
	
		// Constructors
		static AccessibilitySettings(); // 0x000000018212D820-0x000000018212D940
	
		// Methods
		[RequiredByNativeCode]
		internal static void Internal_OnFontScaleChanged(float newFontScale); // 0x000000018212D0D0-0x000000018212D1D0
		[RequiredByNativeCode]
		internal static void Internal_OnBoldTextStatusChanged(bool enabled); // 0x000000018212CEA0-0x000000018212CFB0
		[RequiredByNativeCode]
		internal static void Internal_OnClosedCaptioningStatusChanged(bool enabled); // 0x000000018212CFB0-0x000000018212D0D0
		internal static void InvokeFontScaleChanged(float newFontScale); // 0x000000018212D2D0-0x000000018212D350
		internal static void InvokeBoldTextStatusChanged(bool enabled); // 0x000000018212D1D0-0x000000018212D250
		internal static void InvokeClosedCaptionStatusChanged(bool enabled); // 0x000000018212D250-0x000000018212D2D0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018212D350-0x000000018212D820
	}
}
