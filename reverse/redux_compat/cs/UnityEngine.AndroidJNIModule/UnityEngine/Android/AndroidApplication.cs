/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine.Android
{
	[NativeHeader("Modules/AndroidJNI/Public/AndroidApplication.bindings.h")]
	[StaticAccessor("AndroidApplication", StaticAccessorType.DoubleColon)]
	public static class AndroidApplication // TypeDefIndex: 14783
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static SynchronizationContext m_MainThreadSynchronizationContext; // 0x00
		[NoAutoStaticsCleanup]
		private static AndroidJavaObjectUnityOwned m_Context; // 0x08
		[NoAutoStaticsCleanup]
		private static AndroidJavaObjectUnityOwned m_Activity; // 0x10
		[NoAutoStaticsCleanup]
		private static AndroidJavaObjectUnityOwned m_UnityPlayer; // 0x18
		[NoAutoStaticsCleanup]
		private static AndroidConfiguration m_CurrentConfiguration; // 0x20
		[NoAutoStaticsCleanup]
		private static AndroidWindowInsets m_CurrentWindowInsets; // 0x28
		[CompilerGenerated]
		private static Action<AndroidConfiguration> onConfigurationChanged; // 0x30
		[CompilerGenerated]
		private static Action<AndroidWindowInsets> onWindowInsetsChanged; // 0x38
		[CompilerGenerated]
		private static Action<bool> onMultiWindowModeChanged; // 0x40
		[NoAutoStaticsCleanup]
		private static AndroidJavaObject s_JavaFoldingFeaturesWrapper; // 0x48
		[NoAutoStaticsCleanup]
		private static bool s_WindowManagerApiMissing; // 0x50
		[NoAutoStaticsCleanup]
		private static AndroidFoldingFeatures s_AndroidFoldingFeatures; // 0x58
		[NoAutoStaticsCleanup]
		private static bool s_FoldingFeaturesInitialized; // 0x60
		[CompilerGenerated]
		private static Action<AndroidFoldingFeature[]> onFoldingFeaturesUpdatedInternal; // 0x68
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x70
	
		// Properties
		internal static IntPtr UnityPlayerRaw { [NativeMethod(IsThreadSafe = true)] get; } // 0x00000001821473A0-0x00000001821473D0 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<AndroidConfiguration> onConfigurationChanged {
			add; // 0x0000000182146FE0-0x00000001821470D0
			remove; // 0x00000001821473D0-0x00000001821474C0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<AndroidWindowInsets> onWindowInsetsChanged {
			add; // 0x00000001821472B0-0x00000001821473A0
			remove; // 0x00000001821476A0-0x0000000182147790
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> onMultiWindowModeChanged {
			add; // 0x00000001821471C0-0x00000001821472B0
			remove; // 0x00000001821475B0-0x00000001821476A0
		}
		[AutoStaticsCleanupOnCodeReload]
		internal static event Action<AndroidFoldingFeature[]> onFoldingFeaturesUpdatedInternal {
			add; // 0x00000001821470D0-0x00000001821471C0
			remove; // 0x00000001821474C0-0x00000001821475B0
		}
	
		// Nested types
		[Serializable]
		private class AndroidFoldingFeatures // TypeDefIndex: 14784
		{
			// Constructors
			public AndroidFoldingFeatures(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		static AndroidApplication(); // 0x0000000182146DC0-0x0000000182146FE0
	
		// Methods
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void AcquireMainThreadSynchronizationContext(); // 0x00000001821463A0-0x0000000182146470
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void SetCurrentConfiguration(AndroidConfiguration config); // 0x0000000182146680-0x00000001821466F0
		[RequiredByNativeCode(GenerateProxy = true)]
		private static AndroidConfiguration GetCurrentConfiguration(); // 0x00000001821465E0-0x0000000182146630
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void DispatchConfigurationChanged(bool notifySubscribers); // 0x0000000182146470-0x00000001821464F0
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void SetCurrentWindowInsets(AndroidWindowInsets insets); // 0x00000001821466F0-0x0000000182146760
		[RequiredByNativeCode(GenerateProxy = true)]
		private static AndroidWindowInsets GetCurrentWindowInsets(); // 0x0000000182146630-0x0000000182146680
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void DispatchWindowInsetsChanged(); // 0x0000000182146570-0x00000001821465E0
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void DispatchOnMultiWindowModeChanged(bool newValue); // 0x00000001821464F0-0x0000000182146570
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182146760-0x0000000182146DC0
	}
}
