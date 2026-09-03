/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	internal class DeferredLights // TypeDefIndex: 9882
	{
		// Fields
		internal static readonly string[] k_GBufferNames; // 0x00
		internal static readonly int[] k_GBufferShaderPropertyIDs; // 0x08
		private static readonly string[] k_StencilDeferredPassNames; // 0x10
		private static readonly string[] k_ClusterDeferredPassNames; // 0x18
		private static readonly ushort k_InvalidLightOffset; // 0x20
		private static readonly string k_SetupLights; // 0x28
		private static readonly string k_DeferredPass; // 0x30
		private static readonly string k_DeferredShadingPass; // 0x38
		private static readonly string k_DeferredStencilPass; // 0x40
		private static readonly string k_DeferredFogPass; // 0x48
		private static readonly string k_SetupLightConstants; // 0x50
		private static readonly float kStencilShapeGuard; // 0x58
		private static readonly ProfilingSampler m_ProfilingSetupLights; // 0x60
		private static readonly ProfilingSampler m_ProfilingDeferredPass; // 0x68
		private static readonly ProfilingSampler m_ProfilingSetupLightConstants; // 0x70
		[CompilerGenerated]
		private RenderingLayerUtils.MaskSize _RenderingLayerMaskSize_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _UseDecalLayers_k__BackingField; // 0x14
		[CompilerGenerated]
		private bool _HasRenderingLayerPrepass_k__BackingField; // 0x15
		[CompilerGenerated]
		private bool _AccurateGbufferNormals_k__BackingField; // 0x16
		[CompilerGenerated]
		private MixedLightingSetup _MixedLightingSetup_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _UseJobSystem_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _RenderWidth_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _RenderHeight_k__BackingField; // 0x24
		private NativeArray<ushort> m_stencilVisLights; // 0x28
		private NativeArray<ushort> m_stencilVisLightOffsets; // 0x38
		private AdditionalLightsShadowCasterPass m_AdditionalLightsShadowCasterPass; // 0x48
		private Mesh m_SphereMesh; // 0x50
		private Mesh m_HemisphereMesh; // 0x58
		private Mesh m_FullscreenMesh; // 0x60
		private Material m_StencilDeferredMaterial; // 0x68
		private Material m_ClusterDeferredMaterial; // 0x70
		private int[] m_StencilDeferredPasses; // 0x78
		private int[] m_ClusterDeferredPasses; // 0x80
		private Matrix4x4[] m_ScreenToWorld; // 0x88
		private ProfilingSampler m_ProfilingSamplerDeferredShadingPass; // 0x90
		private ProfilingSampler m_ProfilingSamplerDeferredStencilPass; // 0x98
		private ProfilingSampler m_ProfilingSamplerDeferredFogPass; // 0xA0
		private LightCookieManager m_LightCookieManager; // 0xA8
		private bool m_UseDeferredPlus; // 0xB0
		private static readonly ProfilingSampler s_SetupDeferredLights; // 0x78
		internal TextureHandle[] m_GbufferTextureHandles; // 0xB8
	
		// Properties
		internal int GBufferAlbedoIndex { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal int GBufferSpecularMetallicIndex { get; } // 0x0000000180472790-0x00000001804727A0 
		internal int GBufferNormalSmoothnessIndex { get; } // 0x0000000180476390-0x00000001804763A0 
		internal int GBufferLightingIndex { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		internal int GBufferDepthIndex { get; } // 0x00000001804CB980-0x00000001804CB990 
		internal int GBufferRenderingLayersIndex { get; } // 0x0000000182029830-0x00000001820298B0 
		internal int GBufferShadowMaskIndex { get; } // 0x00000001820298B0-0x0000000182029930 
		internal int GBufferSliceCount { get; } // 0x0000000182029930-0x00000001820299B0 
		internal int GBufferInputAttachmentCount { get; } // 0x0000000182029820-0x0000000182029830 
		internal bool UseShadowMask { get; } // 0x0000000182029A80-0x0000000182029A90 
		internal bool UseRenderingLayers { get; } // 0x0000000182029A10-0x0000000182029A80 
		internal RenderingLayerUtils.MaskSize RenderingLayerMaskSize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		internal bool UseDecalLayers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
		internal bool UseLightLayers { get; } // 0x00000001820299B0-0x0000000182029A10 
		internal bool HasRenderingLayerPrepass { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018155D200-0x000000018155D210 0x000000018155D210-0x000000018155D220
		internal bool AccurateGbufferNormals { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F978F0-0x0000000181F97900 0x0000000181F97910-0x0000000181F97920
		internal MixedLightingSetup MixedLightingSetup { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		internal bool UseJobSystem { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E30-0x0000000180E38E40 0x0000000181E92340-0x0000000181E92350
		internal int RenderWidth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		internal int RenderHeight { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
	
		// Nested types
		internal static class ShaderConstants // TypeDefIndex: 9883
		{
			// Fields
			public static readonly int _LitStencilRef; // 0x00
			public static readonly int _LitStencilReadMask; // 0x04
			public static readonly int _LitStencilWriteMask; // 0x08
			public static readonly int _SimpleLitStencilRef; // 0x0C
			public static readonly int _SimpleLitStencilReadMask; // 0x10
			public static readonly int _SimpleLitStencilWriteMask; // 0x14
			public static readonly int _StencilRef; // 0x18
			public static readonly int _StencilReadMask; // 0x1C
			public static readonly int _StencilWriteMask; // 0x20
			public static readonly int _LitPunctualStencilRef; // 0x24
			public static readonly int _LitPunctualStencilReadMask; // 0x28
			public static readonly int _LitPunctualStencilWriteMask; // 0x2C
			public static readonly int _SimpleLitPunctualStencilRef; // 0x30
			public static readonly int _SimpleLitPunctualStencilReadMask; // 0x34
			public static readonly int _SimpleLitPunctualStencilWriteMask; // 0x38
			public static readonly int _LitDirStencilRef; // 0x3C
			public static readonly int _LitDirStencilReadMask; // 0x40
			public static readonly int _LitDirStencilWriteMask; // 0x44
			public static readonly int _SimpleLitDirStencilRef; // 0x48
			public static readonly int _SimpleLitDirStencilReadMask; // 0x4C
			public static readonly int _SimpleLitDirStencilWriteMask; // 0x50
			public static readonly int _ScreenToWorld; // 0x54
			public static readonly int _MainLightPosition; // 0x58
			public static readonly int _MainLightColor; // 0x5C
			public static readonly int _MainLightLayerMask; // 0x60
			public static readonly int _SpotLightScale; // 0x64
			public static readonly int _SpotLightBias; // 0x68
			public static readonly int _SpotLightGuard; // 0x6C
			public static readonly int _LightPosWS; // 0x70
			public static readonly int _LightColor; // 0x74
			public static readonly int _LightAttenuation; // 0x78
			public static readonly int _LightOcclusionProbInfo; // 0x7C
			public static readonly int _LightDirection; // 0x80
			public static readonly int _LightFlags; // 0x84
			public static readonly int _ShadowLightIndex; // 0x88
			public static readonly int _LightLayerMask; // 0x8C
			public static readonly int _CookieLightIndex; // 0x90
	
			// Constructors
			static ShaderConstants(); // 0x000000018202FAB0-0x0000000182030120
		}
	
		internal enum StencilDeferredPasses // TypeDefIndex: 9884
		{
			StencilVolume = 0,
			PunctualLit = 1,
			PunctualSimpleLit = 2,
			DirectionalLit = 3,
			DirectionalSimpleLit = 4,
			Fog = 5,
			SSAOOnly = 6
		}
	
		internal enum ClusterDeferredPasses // TypeDefIndex: 9885
		{
			ClusteredLightsLit = 0,
			ClusteredLightsSimpleLit = 1,
			Fog = 2
		}
	
		internal struct InitParams // TypeDefIndex: 9886
		{
			// Fields
			public Material stencilDeferredMaterial; // 0x00
			public Material clusterDeferredMaterial; // 0x08
			public LightCookieManager lightCookieManager; // 0x10
			public bool deferredPlus; // 0x18
		}
	
		private class SetupLightPassData // TypeDefIndex: 9887
		{
			// Fields
			internal UniversalCameraData cameraData; // 0x10
			internal UniversalLightData lightData; // 0x18
			internal DeferredLights deferredLights; // 0x20
			internal Vector2Int cameraTargetSizeCopy; // 0x28
	
			// Constructors
			public SetupLightPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9888
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<SetupLightPassData, UnsafeGraphContext> __9__95_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820307D0-0x0000000182030840
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SetupRenderGraphLights_b__95_0(SetupLightPassData data, UnsafeGraphContext rgContext); // 0x00000001820306C0-0x0000000182030760
		}
	
		// Constructors
		internal DeferredLights(InitParams initParams); // 0x0000000182029530-0x0000000182029820
		static DeferredLights(); // 0x0000000182028C20-0x0000000182029530
	
		// Methods
		internal GraphicsFormat GetGBufferFormat(int index); // 0x0000000182024490-0x0000000182024610
		internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000182028880-0x0000000182028C10
		private void SetupLights(CommandBuffer cmd, UniversalCameraData cameraData, Vector2Int cameraTargetSizeCopy, UniversalLightData lightData); // 0x0000000182028080-0x00000001820284C0
		internal void ResolveMixedLightingMode(UniversalLightData lightData); // 0x0000000182027BC0-0x0000000182027D40
		internal void CreateGbufferTextures(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, bool hasNormalPrepass); // 0x0000000182022AC0-0x0000000182022F60
		internal bool IsRuntimeSupportedThisFrame(); // 0x0000000182025140-0x00000001820251D0
		internal void Setup(AdditionalLightsShadowCasterPass additionalLightsShadowCasterPass); // 0x00000001803780C0-0x00000001803780D0
		public void OnCameraCleanup(CommandBuffer cmd); // 0x00000001820251D0-0x0000000182025290
		internal static StencilState OverwriteStencil(StencilState s, int stencilWriteMask); // 0x00000001820254A0-0x00000001820255D0
		internal static RenderStateBlock OverwriteStencil(RenderStateBlock block, int stencilWriteMask, int stencilRef); // 0x0000000182025290-0x00000001820254A0
		internal void ExecuteDeferredPass(RasterCommandBuffer cmd, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData, TextureHandle[] gbuffer, RasterGraphContext context); // 0x0000000182023F30-0x0000000182024490
		private void SetupShaderLightConstants(CommandBuffer cmd, UniversalLightData lightData); // 0x0000000182028C10-0x0000000182028C20
		private void SetupMainLightConstants(CommandBuffer cmd, UniversalLightData lightData); // 0x00000001820284C0-0x00000001820287C0
		internal Matrix4x4[] GetScreenToWorldMatrix(UniversalCameraData cameraData, TextureUVOrigin depthTextureOrigin); // 0x0000000182024610-0x0000000182024A00
		private void SetupMatrixConstants(RasterCommandBuffer cmd, UniversalCameraData cameraData, TextureUVOrigin depthTextureOrigin); // 0x00000001820287C0-0x0000000182028880
		private void PrecomputeLights(out NativeArray<ushort> stencilVisLights, out NativeArray<ushort> stencilVisLightOffsets, ref NativeArray<VisibleLight> visibleLights, bool hasAdditionalLights); // 0x00000001820255D0-0x00000001820258E0
		private bool HasStencilLightsOfType(LightType type); // 0x0000000182024A00-0x0000000182024A70
		private void RenderClusterLights(RasterCommandBuffer cmd, UniversalShadowData shadowData); // 0x00000001820258E0-0x0000000182025CB0
		private void RenderStencilLights(RasterCommandBuffer cmd, UniversalLightData lightData, UniversalShadowData shadowData); // 0x0000000182026700-0x0000000182026A70
		private void RenderStencilDirectionalLights(RasterCommandBuffer cmd, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager, int mainLightIndex); // 0x0000000182025FF0-0x0000000182026700
		private void RenderStencilPointLights(RasterCommandBuffer cmd, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager); // 0x0000000182026A70-0x0000000182027260
		private void RenderStencilSpotLights(RasterCommandBuffer cmd, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager); // 0x0000000182027260-0x0000000182027BC0
		private void RenderSSAOBeforeShading(RasterCommandBuffer cmd); // 0x0000000182025EC0-0x0000000182025FF0
		private void RenderFog(RasterCommandBuffer cmd); // 0x0000000182025CB0-0x0000000182025EC0
		private void InitStencilDeferredMaterial(); // 0x0000000182024D10-0x0000000182025140
		private void InitClusterDeferredMaterial(); // 0x0000000182024A70-0x0000000182024D10
		private static Mesh CreateSphereMesh(); // 0x00000001820236D0-0x0000000182023F30
		private static Mesh CreateHemisphereMesh(); // 0x0000000182022F60-0x00000001820236D0
		private static Mesh CreateFullscreenMesh(); // 0x0000000182022950-0x0000000182022AC0
		private void SetRenderingLayersMask(RasterCommandBuffer cmd, Light light, int shaderPropertyID); // 0x0000000182027F40-0x0000000182027FD0
		private void SetAdditionalLightsShadowsKeyword(ref RasterCommandBuffer cmd, bool additionalLightShadowsEnabled, bool hasDeferredShadows, bool shouldOverride, ref bool lastShadowsKeyword); // 0x0000000182027D40-0x0000000182027DF0
		private void SetSoftShadowsKeyword(RasterCommandBuffer cmd, UniversalShadowData shadowData, Light light, bool hasDeferredShadows, bool shouldOverride, ref bool lastHasSoftShadow); // 0x0000000182027FD0-0x0000000182028080
		private void SetLightCookiesKeyword(RasterCommandBuffer cmd, int visLightIndex, bool hasLightCookieManager, bool shouldOverride, ref bool lastLightCookieState, ref int lastCookieLightIndex); // 0x0000000182027DF0-0x0000000182027F40
	}
}
