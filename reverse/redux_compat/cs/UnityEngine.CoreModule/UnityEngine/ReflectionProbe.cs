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
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("ReflectionProbe", PersistentTypeId = 215)]
	[NativeHeader("Runtime/Camera/ReflectionProbes.h")]
	public sealed class ReflectionProbe : Behaviour // TypeDefIndex: 7512
	{
		// Fields
		[CompilerGenerated]
		private static Action<ReflectionProbe, ReflectionProbeEvent> reflectionProbeChanged; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		internal static Action<Texture> s_DefaultReflectionTexture; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		public ReflectionProbeMode mode { get; } // 0x0000000182193EF0-0x0000000182193F80 
		public ReflectionProbeRefreshMode refreshMode { get; } // 0x0000000182193FC0-0x0000000182194050 
		public Texture texture { get; } // 0x0000000182194090-0x0000000182194140 
		[StaticAccessor("GetReflectionProbes()")]
		public static Vector4 defaultTextureHDRDecodeValues { get; } // 0x0000000182193D90-0x0000000182193E00 
		[StaticAccessor("GetReflectionProbes()")]
		public static Texture defaultTexture { get; } // 0x0000000182193E30-0x0000000182193EB0 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ReflectionProbe, ReflectionProbeEvent> reflectionProbeChanged {
			add; // 0x0000000182193C60-0x0000000182193D50
			remove; // 0x0000000182194140-0x0000000182194230
		}
	
		// Nested types
		public enum ReflectionProbeEvent // TypeDefIndex: 7513
		{
			ReflectionProbeAdded = 0,
			ReflectionProbeRemoved = 1
		}
	
		// Constructors
		static ReflectionProbe(); // 0x0000000182193B40-0x0000000182193C60
	
		// Methods
		[RequiredByNativeCode]
		private static void CallReflectionProbeEvent(ReflectionProbe probe, ReflectionProbeEvent probeEvent); // 0x0000000182193810-0x0000000182193890
		[RequiredByNativeCode]
		private static void CallSetDefaultReflection(Texture defaultReflectionCubemap); // 0x0000000182193890-0x0000000182193910
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182193910-0x0000000182193B40
		private static ReflectionProbeMode get_mode_Injected(IntPtr _unity_self); // 0x0000000182193EB0-0x0000000182193EF0
		private static ReflectionProbeRefreshMode get_refreshMode_Injected(IntPtr _unity_self); // 0x0000000182193F80-0x0000000182193FC0
		private static IntPtr get_texture_Injected(IntPtr _unity_self); // 0x0000000182194050-0x0000000182194090
		private static void get_defaultTextureHDRDecodeValues_Injected(); // 0x0000000182193D50-0x0000000182193D90
		private static IntPtr get_defaultTexture_Injected(); // 0x0000000182193E00-0x0000000182193E30
	}
}
