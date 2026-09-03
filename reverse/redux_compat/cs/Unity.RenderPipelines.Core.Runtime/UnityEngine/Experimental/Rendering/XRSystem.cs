/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	public static class XRSystem // TypeDefIndex: 5318
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static XRLayoutStack s_Layout; // 0x00
		[AutoStaticsCleanup]
		private static Func<XRPassCreateInfo, XRPass> s_PassAllocator; // 0x08
		[AutoStaticsCleanup]
		private static List<XRDisplaySubsystem> s_DisplayList; // 0x10
		[AutoStaticsCleanup]
		private static XRDisplaySubsystem s_Display; // 0x18
		[AutoStaticsCleanup]
		private static MSAASamples s_MSAASamples; // 0x20
		[NoAutoStaticsCleanup]
		private static float s_OcclusionMeshScaling; // 0x24
		[AutoStaticsCleanup]
		private static bool s_UseVisibilityMesh; // 0x28
		[NoAutoStaticsCleanup]
		private static Material s_OcclusionMeshMaterial; // 0x30
		[NoAutoStaticsCleanup]
		private static Material s_MirrorViewMaterial; // 0x38
		[AutoStaticsCleanup]
		private static Action<XRLayout, Camera> s_LayoutOverride; // 0x40
		[NoAutoStaticsCleanup]
		public static readonly XRPass emptyPass; // 0x48
		[CompilerGenerated]
		private static bool _singlePassAllowed_k__BackingField; // 0x50
		[CompilerGenerated]
		private static FoveatedRenderingCaps _foveatedRenderingCaps_k__BackingField; // 0x54
		[CompilerGenerated]
		private static bool _dumpDebugInfo_k__BackingField; // 0x58
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both; // 0x60
	
		// Properties
		public static bool displayActive { get; } // 0x0000000181E358F0-0x0000000181E35950 
		public static bool isHDRDisplayOutputActive { get; } // 0x0000000181E359F0-0x0000000181E35A90 
		[AutoStaticsCleanup]
		public static bool singlePassAllowed { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E35A90-0x0000000181E35AE0 0x0000000181E35BA0-0x0000000181E35C00
		[AutoStaticsCleanup]
		public static FoveatedRenderingCaps foveatedRenderingCaps { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E359A0-0x0000000181E359F0 0x0000000181E35B40-0x0000000181E35BA0
		[AutoStaticsCleanup]
		public static bool dumpDebugInfo { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E35950-0x0000000181E359A0 0x0000000181E35AE0-0x0000000181E35B40
		public static XRLayout currentLayout { get; } // 0x0000000181E35840-0x0000000181E358F0 
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass53_0 // TypeDefIndex: 5319
		{
			// Fields
			public Camera camera; // 0x00
		}
	
		// Constructors
		static XRSystem(); // 0x0000000181E354B0-0x0000000181E35840
	
		// Methods
		[OnCodeInitializing]
		private static void ResetStaticsOnLoad(); // 0x0000000181E33F60-0x0000000181E341E0
		public static XRDisplaySubsystem GetActiveDisplay(); // 0x0000000181E32F30-0x0000000181E32F80
		public static void Initialize(Func<XRPassCreateInfo, XRPass> passAllocator, Shader occlusionMeshPS, Shader mirrorViewPS); // 0x0000000181E331A0-0x0000000181E335A0
		public static void SetDisplayMSAASamples(MSAASamples msaaSamples); // 0x0000000181E342C0-0x0000000181E34480
		public static MSAASamples GetDisplayMSAASamples(); // 0x0000000181E32F80-0x0000000181E32FD0
		internal static void SetOcclusionMeshScale(float occlusionMeshScale); // 0x0000000181E34600-0x0000000181E34660
		internal static float GetOcclusionMeshScale(); // 0x0000000181E330A0-0x0000000181E330F0
		internal static void SetUseVisibilityMesh(bool useVisibilityMesh); // 0x0000000181E34910-0x0000000181E34970
		internal static bool GetUseVisibilityMesh(); // 0x0000000181E33150-0x0000000181E331A0
		internal static void SetMirrorViewMode(int mirrorBlitMode); // 0x0000000181E34590-0x0000000181E34600
		internal static int GetMirrorViewMode(); // 0x0000000181E33030-0x0000000181E330A0
		public static void SetRenderScale(float renderScale); // 0x0000000181E34660-0x0000000181E347E0
		public static float GetRenderViewportScale(); // 0x0000000181E330F0-0x0000000181E33150
		public static float GetDynamicResolutionScale(); // 0x0000000181E32FD0-0x0000000181E33030
		public static int ScaleTextureWidthForXR(RenderTexture texture); // 0x0000000181E34250-0x0000000181E342C0
		public static int ScaleTextureHeightForXR(RenderTexture texture); // 0x0000000181E341E0-0x0000000181E34250
		public static XRLayout NewLayout(); // 0x0000000181E335A0-0x0000000181E336A0
		public static void EndLayout(); // 0x0000000181E32E30-0x0000000181E32F30
		public static void RenderMirrorView(CommandBuffer cmd, Camera camera); // 0x0000000181E33EA0-0x0000000181E33F60
		public static void Dispose(); // 0x0000000181E32CA0-0x0000000181E32E30
		internal static void SetDisplayZRange(float zNear, float zFar); // 0x0000000181E34480-0x0000000181E34520
		private static void SetLayoutOverride(Action<XRLayout, Camera> action); // 0x0000000181E34520-0x0000000181E34590
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void XRSystemInit(); // 0x0000000181E35110-0x0000000181E351C0
		private static void RefreshDeviceInfo(); // 0x0000000181E33BC0-0x0000000181E33EA0
		internal static void CreateDefaultLayout(Camera camera, XRLayout layout); // 0x0000000181E31B20-0x0000000181E32CA0
		internal static void ReconfigurePass(XRPass xrPass, Camera camera); // 0x0000000181E336A0-0x0000000181E33BC0
		private static void SetSplitCullingPlanes(Camera camera, int innerCullingPassIndex, ref ScriptableCullingParameters cullingParams); // 0x0000000181E347E0-0x0000000181E34910
		private static bool CanUseSinglePass(Camera camera, XRDisplaySubsystem.XRRenderPass renderPass); // 0x0000000181E31920-0x0000000181E31B20
		private static XRView BuildView(XRDisplaySubsystem.XRRenderPass renderPass, XRDisplaySubsystem.XRRenderParameter renderParameter); // 0x0000000181E30FF0-0x0000000181E31920
		private static RenderTextureDescriptor XrRenderTextureDescToUnityRenderTextureDesc(RenderTextureDescriptor xrDesc); // 0x0000000181E351C0-0x0000000181E35250
		private static XRPassCreateInfo BuildPass(XRDisplaySubsystem.XRRenderPass xrRenderPass, ScriptableCullingParameters cullingParameters, XRLayout layout, XRLayoutType layoutType, Vector4 uvScales, Vector4 uvOffsets); // 0x0000000181E305F0-0x0000000181E30FF0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both(); // 0x0000000181E35250-0x0000000181E354B0
		[CompilerGenerated]
		internal static void UnityEngine_Experimental_Rendering_XRSystem_ResetStaticsOnLoad_RegisterLifecycleMethod(); // 0x0000000181E35020-0x0000000181E35110
		[CompilerGenerated]
		internal static void _CreateDefaultLayout_g__AddViewToPass_53_0(XRPass xrPass, XRDisplaySubsystem.XRRenderPass renderPass, int renderParamIndex, ref __c__DisplayClass53_0 param_00008463); // 0x0000000181E34970-0x0000000181E34D10
		[CompilerGenerated]
		internal static Vector4 _CreateDefaultLayout_g__ExtractFrustumBoundsFromProjection_53_1(Matrix4x4 proj); // 0x0000000181E34D10-0x0000000181E34E30
		[CompilerGenerated]
		internal static Vector4 _CreateDefaultLayout_g__ExtractViewBounds_53_2(XRDisplaySubsystem.XRRenderPass renderPass, int renderParamIndex, ref __c__DisplayClass53_0 param_00008467); // 0x0000000181E34E30-0x0000000181E35020
	}
}
