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

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine
{
	[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
	[StaticAccessor("GetAudioManager()", StaticAccessorType.Dot)]
	public sealed class AudioSettings // TypeDefIndex: 14912
	{
		// Fields
		[CompilerGenerated]
		private static AudioConfigurationChangeHandler OnAudioConfigurationChanged; // 0x00
		[CompilerGenerated]
		private static Action OnAudioSystemShuttingDown; // 0x08
		[CompilerGenerated]
		private static Action OnAudioSystemStartedUp; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event AudioConfigurationChangeHandler OnAudioConfigurationChanged {
			add; // 0x0000000182167E90-0x0000000182167F60
			remove; // 0x0000000182168100-0x00000001821681D0
		}
		[AutoStaticsCleanupOnCodeReload]
		internal static event Action OnAudioSystemShuttingDown {
			add; // 0x0000000182167F60-0x0000000182168030
			remove; // 0x00000001821681D0-0x00000001821682A0
		}
		[AutoStaticsCleanupOnCodeReload]
		internal static event Action OnAudioSystemStartedUp {
			add; // 0x0000000182168030-0x0000000182168100
			remove; // 0x00000001821682A0-0x0000000182168370
		}
	
		// Nested types
		public delegate void AudioConfigurationChangeHandler(bool deviceWasChanged); // TypeDefIndex: 14913; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		static AudioSettings(); // 0x0000000182167D70-0x0000000182167E90
	
		// Methods
		[RequiredByNativeCode]
		internal static void InvokeOnAudioConfigurationChanged(bool deviceWasChanged); // 0x00000001821677B0-0x0000000182167820
		[RequiredByNativeCode]
		internal static void InvokeOnAudioSystemShuttingDown(); // 0x0000000182167820-0x0000000182167890
		[RequiredByNativeCode]
		internal static void InvokeOnAudioSystemStartedUp(); // 0x0000000182167890-0x0000000182167900
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182167900-0x0000000182167D70
	}
}
