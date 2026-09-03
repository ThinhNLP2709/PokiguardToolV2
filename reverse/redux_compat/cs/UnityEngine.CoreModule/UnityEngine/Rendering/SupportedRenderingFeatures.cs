/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public class SupportedRenderingFeatures // TypeDefIndex: 8444
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static SupportedRenderingFeatures s_Active; // 0x00
		[CompilerGenerated]
		private ReflectionProbeModes _reflectionProbeModes_k__BackingField; // 0x10
		[CompilerGenerated]
		private LightmapMixedBakeModes _defaultMixedLightingModes_k__BackingField; // 0x14
		[CompilerGenerated]
		private LightmapMixedBakeModes _mixedLightingModes_k__BackingField; // 0x18
		[CompilerGenerated]
		private LightmapBakeType _lightmapBakeTypes_k__BackingField; // 0x1C
		[CompilerGenerated]
		private LightmapsMode _lightmapsModes_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _enlighten_k__BackingField; // 0x24
		[CompilerGenerated]
		private bool _skyOcclusion_k__BackingField; // 0x25
		[CompilerGenerated]
		private bool _lightProbeProxyVolumes_k__BackingField; // 0x26
		[CompilerGenerated]
		private bool _motionVectors_k__BackingField; // 0x27
		[CompilerGenerated]
		private bool _receiveShadows_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _reflectionProbes_k__BackingField; // 0x29
		[CompilerGenerated]
		private bool _reflectionProbesBlendDistance_k__BackingField; // 0x2A
		[CompilerGenerated]
		private bool _rendersUIOverlay_k__BackingField; // 0x2B
		[CompilerGenerated]
		private bool _editableMaterialRenderQueue_k__BackingField; // 0x2C
		[CompilerGenerated]
		private bool _rendererProbes_k__BackingField; // 0x2D
		[CompilerGenerated]
		private bool _particleSystemInstancing_k__BackingField; // 0x2E
		[CompilerGenerated]
		private bool _ambientProbeBaking_k__BackingField; // 0x2F
		[CompilerGenerated]
		private bool _defaultReflectionProbeBaking_k__BackingField; // 0x30
		[CompilerGenerated]
		private bool _overridesLightProbeSystem_k__BackingField; // 0x31
		[CompilerGenerated]
		private bool _supportsHDR_k__BackingField; // 0x32
		[CompilerGenerated]
		private string _overridesLightProbeSystemWarningMessage_k__BackingField; // 0x38
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public static SupportedRenderingFeatures active { get; set; } // 0x000000018226F750-0x000000018226F800 0x000000018226F800-0x000000018226F870
		public ReflectionProbeModes reflectionProbeModes { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public LightmapMixedBakeModes defaultMixedLightingModes { [CompilerGenerated] get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public LightmapMixedBakeModes mixedLightingModes { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
		public LightmapBakeType lightmapBakeTypes { [CompilerGenerated] get; } // 0x0000000180B232F0-0x0000000180B23300 
		public LightmapsMode lightmapsModes { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public bool enlighten { [CompilerGenerated] get; } // 0x000000018153BC50-0x000000018153BC60 
		public bool skyOcclusion { [CompilerGenerated] set; } // 0x0000000181706040-0x0000000181706050
		public bool rendersUIOverlay { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181EE3C10-0x0000000181EE3C20 0x0000000181EE2460-0x0000000181EE2470
		public bool ambientProbeBaking { [CompilerGenerated] get; } // 0x0000000181DB5B80-0x0000000181DB5B90 
		public bool defaultReflectionProbeBaking { [CompilerGenerated] get; } // 0x00000001802E8950-0x00000001802E8960 
		public bool overridesLightProbeSystem { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180634F10-0x0000000180634F20 0x0000000181B14860-0x0000000181B14870
		public bool supportsHDR { [CompilerGenerated] set; } // 0x0000000181B14870-0x0000000181B14880
	
		// Nested types
		[Flags]
		public enum ReflectionProbeModes // TypeDefIndex: 8445
		{
			None = 0,
			Rotation = 1
		}
	
		[Flags]
		public enum LightmapMixedBakeModes // TypeDefIndex: 8446
		{
			None = 0,
			IndirectOnly = 1,
			Subtractive = 2,
			Shadowmask = 4
		}
	
		// Constructors
		public SupportedRenderingFeatures(); // 0x000000018226F6D0-0x000000018226F750
		static SupportedRenderingFeatures(); // 0x000000018226F570-0x000000018226F6D0
	
		// Methods
		[RequiredByNativeCode]
		internal static void FallbackMixedLightingModeByRef(IntPtr fallbackModePtr); // 0x000000018226EC10-0x000000018226EDE0
		internal static bool IsMixedLightingModeSupported(MixedLightingMode mixedMode); // 0x000000018226F320-0x000000018226F380
		[RequiredByNativeCode]
		internal static void IsMixedLightingModeSupportedByRef(MixedLightingMode mixedMode, IntPtr isSupportedPtr); // 0x000000018226F150-0x000000018226F320
		internal static bool IsLightmapBakeTypeSupported(LightmapBakeType bakeType); // 0x000000018226EF90-0x000000018226F0A0
		[RequiredByNativeCode]
		internal static void IsLightmapBakeTypeSupportedByRef(LightmapBakeType bakeType, IntPtr isSupportedPtr); // 0x000000018226EEC0-0x000000018226EF90
		[RequiredByNativeCode]
		internal static void IsLightmapsModeSupportedByRef(LightmapsMode mode, IntPtr isSupportedPtr); // 0x000000018226F0D0-0x000000018226F150
		[RequiredByNativeCode]
		internal static void IsLightmapperSupportedByRef(int lightmapper, IntPtr isSupportedPtr); // 0x000000018226F0A0-0x000000018226F0D0
		[RequiredByNativeCode]
		internal static void IsUIOverlayRenderedBySRP(IntPtr isSupportedPtr); // 0x000000018226F3F0-0x000000018226F460
		[RequiredByNativeCode]
		internal static void IsAmbientProbeBakingSupported(IntPtr isSupportedPtr); // 0x000000018226EDE0-0x000000018226EE50
		[RequiredByNativeCode]
		internal static void IsDefaultReflectionProbeBakingSupported(IntPtr isSupportedPtr); // 0x000000018226EE50-0x000000018226EEC0
		[RequiredByNativeCode]
		internal static void OverridesLightProbeSystem(IntPtr overridesPtr); // 0x000000018226F460-0x000000018226F4D0
		[RequiredByNativeCode]
		internal static void FallbackLightmapperByRef(IntPtr lightmapperPtr); // 0x000000018226EBF0-0x000000018226EC10
		[RequiredByNativeCode]
		internal static void IsRotatingReflectionProbesSupported(IntPtr isSupportedPtr); // 0x000000018226F380-0x000000018226F3F0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018226F4D0-0x000000018226F570
	}
}
