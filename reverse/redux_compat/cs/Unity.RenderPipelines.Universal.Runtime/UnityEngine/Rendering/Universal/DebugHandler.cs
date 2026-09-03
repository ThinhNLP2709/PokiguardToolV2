/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DebugHandler : IDebugDisplaySettingsQuery // TypeDefIndex: 9392
	{
		// Fields
		private static readonly int k_DebugColorInvalidModePropertyId; // 0x00
		private static readonly int k_DebugCurrentRealTimeId; // 0x04
		private static readonly int k_DebugColorPropertyId; // 0x08
		private static readonly int k_DebugTexturePropertyId; // 0x0C
		private static readonly int k_DebugFontId; // 0x10
		private static readonly int k_DebugTextureNoStereoPropertyId; // 0x14
		private static readonly int k_DebugTextureDisplayRect; // 0x18
		private static readonly int k_DebugRenderTargetSupportsStereo; // 0x1C
		private static readonly int k_DebugRenderTargetRangeRemap; // 0x20
		private static readonly int k_DebugMaterialModeId; // 0x24
		private static readonly int k_DebugVertexAttributeModeId; // 0x28
		private static readonly int k_DebugMaterialValidationModeId; // 0x2C
		private static readonly int k_DebugMipInfoModeId; // 0x30
		private static readonly int k_DebugMipMapStatusModeId; // 0x34
		private static readonly int k_DebugMipMapShowStatusCodeId; // 0x38
		private static readonly int k_DebugMipMapOpacityId; // 0x3C
		private static readonly int k_DebugMipMapRecentlyUpdatedCooldownId; // 0x40
		private static readonly int k_DebugMipMapTerrainTextureModeId; // 0x44
		private static readonly int k_DebugSceneOverrideModeId; // 0x48
		private static readonly int k_DebugFullScreenModeId; // 0x4C
		private static readonly int k_DebugValidationModeId; // 0x50
		private static readonly int k_DebugValidateBelowMinThresholdColorPropertyId; // 0x54
		private static readonly int k_DebugValidateAboveMaxThresholdColorPropertyId; // 0x58
		private static readonly int k_DebugMaxPixelCost; // 0x5C
		private static readonly int k_DebugLightingModeId; // 0x60
		private static readonly int k_DebugLightingFeatureFlagsId; // 0x64
		private static readonly int k_DebugValidateAlbedoMinLuminanceId; // 0x68
		private static readonly int k_DebugValidateAlbedoMaxLuminanceId; // 0x6C
		private static readonly int k_DebugValidateAlbedoSaturationToleranceId; // 0x70
		private static readonly int k_DebugValidateAlbedoHueToleranceId; // 0x74
		private static readonly int k_DebugValidateAlbedoCompareColorId; // 0x78
		private static readonly int k_DebugValidateMetallicMinValueId; // 0x7C
		private static readonly int k_DebugValidateMetallicMaxValueId; // 0x80
		private static readonly int k_ValidationChannelsId; // 0x84
		private static readonly int k_RangeMinimumId; // 0x88
		private static readonly int k_RangeMaximumId; // 0x8C
		private static readonly ProfilingSampler s_DebugSetupSampler; // 0x90
		private static readonly ProfilingSampler s_DebugFinalValidationSampler; // 0x98
		private DebugSetupPassData s_DebugSetupPassData; // 0x10
		private DebugFinalValidationPassData s_DebugFinalValidationPassData; // 0x18
		private readonly Material m_ReplacementMaterial; // 0x20
		private readonly Material m_HDRDebugViewMaterial; // 0x28
		private readonly Material m_BatchingTypeDebugMaterial; // 0x30
		private HDRDebugViewPass m_HDRDebugViewPass; // 0x38
		private RTHandle m_DebugScreenColorHandle; // 0x40
		private RTHandle m_DebugScreenDepthHandle; // 0x48
		private readonly UniversalRenderPipelineRuntimeTextures m_RuntimeTextures; // 0x50
		private bool m_HasDebugRenderTarget; // 0x58
		private bool m_DebugRenderTargetSupportsStereo; // 0x59
		private Vector4 m_DebugRenderTargetPixelRect; // 0x5C
		private Vector4 m_DebugRenderTargetRangeRemap; // 0x6C
		private RTHandle m_DebugRenderTarget; // 0x80
		private RTHandle m_DebugFontTexture; // 0x88
		private readonly UniversalRenderPipelineDebugDisplaySettings m_DebugDisplaySettings; // 0x90
	
		// Properties
		private DebugDisplaySettingsLighting LightingSettings { get; } // 0x0000000181F70D10-0x0000000181F70D30 
		private DebugDisplaySettingsMaterial MaterialSettings { get; } // 0x0000000181F70D30-0x0000000181F70D50 
		private DebugDisplaySettingsRendering RenderingSettings { get; } // 0x0000000181F70D50-0x0000000181F70D70 
		public bool AreAnySettingsActive { get; } // 0x0000000181F70B00-0x0000000181F70B30 
		public bool IsPostProcessingAllowed { get; } // 0x0000000181F70C50-0x0000000181F70C80 
		public bool IsLightingActive { get; } // 0x0000000181F70C20-0x0000000181F70C50 
		internal bool IsActiveModeUnsupportedForDeferred { get; } // 0x0000000181F70B40-0x0000000181F70BC0 
		internal Material ReplacementMaterial { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal Material BatchingTypeDebugMaterial { get; } // 0x000000018031E110-0x000000018031E120 
		internal UniversalRenderPipelineDebugDisplaySettings DebugDisplaySettings { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		internal ref RTHandle DebugScreenColorHandle { get; } // 0x0000000181CA89C0-0x0000000181CA89D0 
		internal ref RTHandle DebugScreenDepthHandle { get; } // 0x0000000181F70B30-0x0000000181F70B40 
		internal HDRDebugViewPass hdrDebugViewPass { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal bool IsScreenClearNeeded { get; } // 0x0000000181F70CD0-0x0000000181F70D10 
		internal bool IsRenderPassSupported { get; } // 0x0000000181F70C80-0x0000000181F70CD0 
		internal bool IsDepthPrimingCompatible { get; } // 0x0000000181F70BF0-0x0000000181F70C20 
		internal int stpDebugViewIndex { get; } // 0x0000000181F70D70-0x0000000181F70DA0 
		internal bool IsBatchingTypeViewActive { get; } // 0x0000000181F70BC0-0x0000000181F70BF0 
	
		// Nested types
		private class DebugFinalValidationPassData // TypeDefIndex: 9393
		{
			// Fields
			public bool isFinalPass; // 0x10
			public bool resolveFinalTarget; // 0x11
			public bool isActiveForCamera; // 0x12
			public bool hasDebugRenderTarget; // 0x13
			public TextureHandle debugRenderTargetHandle; // 0x14
			public int debugTexturePropertyId; // 0x24
			public Vector4 debugRenderTargetPixelRect; // 0x28
			public int debugRenderTargetSupportsStereo; // 0x38
			public Vector4 debugRenderTargetRangeRemap; // 0x3C
			public TextureHandle debugFontTextureHandle; // 0x4C
			public DebugDisplaySettingsRendering renderingSettings; // 0x60
	
			// Constructors
			public DebugFinalValidationPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class DebugSetupPassData // TypeDefIndex: 9394
		{
			// Fields
			public bool isActiveForCamera; // 0x10
			public DebugDisplaySettingsMaterial materialSettings; // 0x18
			public DebugDisplaySettingsRendering renderingSettings; // 0x20
			public DebugDisplaySettingsLighting lightingSettings; // 0x28
	
			// Constructors
			public DebugSetupPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9395
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<DebugFinalValidationPassData, RasterGraphContext> __9__107_0; // 0x08
			public static BaseRenderFunc<DebugSetupPassData, RasterGraphContext> __9__112_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181F85BE0-0x0000000181F85C50
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _UpdateShaderGlobalPropertiesForFinalValidationPass_b__107_0(DebugFinalValidationPassData data, RasterGraphContext context); // 0x0000000181F858E0-0x0000000181F85940
			internal void _Setup_b__112_0(DebugSetupPassData data, RasterGraphContext context); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		internal DebugHandler(); // 0x0000000181F70780-0x0000000181F70B00
		static DebugHandler(); // 0x0000000181F70070-0x0000000181F70780
	
		// Methods
		public bool TryGetScreenClearColor(ref Color color); // 0x0000000181F6F480-0x0000000181F6F4B0
		internal bool HDRDebugViewIsActive(bool resolveFinalTarget); // 0x0000000181F6E010-0x0000000181F6E0C0
		internal bool WriteToDebugScreenTexture(bool resolveFinalTarget); // 0x0000000181F70060-0x0000000181F70070
		public void Dispose(); // 0x0000000181F6DF50-0x0000000181F6E010
		internal bool IsActiveForCamera(bool isPreviewCamera); // 0x0000000181F6E380-0x0000000181F6E3C0
		internal bool TryGetFullscreenDebugMode(out DebugFullScreenMode debugFullScreenMode); // 0x0000000181F6F3A0-0x0000000181F6F400
		internal bool TryGetFullscreenDebugMode(out DebugFullScreenMode debugFullScreenMode, out int textureHeightPercent); // 0x0000000181F6F400-0x0000000181F6F480
		internal static void ConfigureColorDescriptorForDebugScreen(ref RenderTextureDescriptor descriptor, int cameraWidth, int cameraHeight); // 0x0000000181F6DCD0-0x0000000181F6DD10
		internal static void ConfigureDepthDescriptorForDebugScreen(ref RenderTextureDescriptor descriptor, GraphicsFormat depthStencilFormat, int cameraWidth, int cameraHeight); // 0x0000000181F6DD10-0x0000000181F6DD70
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void SetupShaderProperties(RasterCommandBuffer cmd, int passIndex = 0 /* Metadata: 0x0069EA08 */); // 0x0000000181F6E560-0x0000000181F6EB80
		internal void SetDebugRenderTarget(RTHandle renderTarget, Rect displayRect, bool supportsStereo, Vector4 dataRangeRemap); // 0x0000000181F6E4C0-0x0000000181F6E560
		internal void ResetDebugRenderTarget(); // 0x0000000181F6E4B0-0x0000000181F6E4C0
		private DebugFinalValidationPassData InitDebugFinalValidationPassData(DebugFinalValidationPassData passData, UniversalCameraData cameraData, bool isFinalPass); // 0x0000000181F6E0C0-0x0000000181F6E2D0
		private static void UpdateShaderGlobalPropertiesForFinalValidationPass(RasterCommandBuffer cmd, DebugFinalValidationPassData data); // 0x0000000181F6FBB0-0x0000000181F6FEB0
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void UpdateShaderGlobalPropertiesForFinalValidationPass(CommandBuffer cmd, UniversalCameraData cameraData, bool isFinalPass); // 0x0000000181F6FEB0-0x0000000181F70060
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void UpdateShaderGlobalPropertiesForFinalValidationPass(RenderGraph renderGraph, UniversalCameraData cameraData, bool isFinalPass); // 0x0000000181F6F4B0-0x0000000181F6FBB0
		private DebugSetupPassData InitDebugSetupPassData(DebugSetupPassData passData, bool isPreviewCamera); // 0x0000000181F6E2D0-0x0000000181F6E380
		[Conditional("UNITY_ENABLE_CHECKS")]
		private static void Setup(RasterCommandBuffer cmd, DebugSetupPassData passData); // 0x0000000181F6EF30-0x0000000181F6F3A0
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void Setup(CommandBuffer cmd, bool isPreviewCamera); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void Setup(RenderGraph renderGraph, bool isPreviewCamera); // 0x0000000181F6EB80-0x0000000181F6EF30
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void Render(RenderGraph renderGraph, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle srcColor, [IsReadOnly] in TextureHandle overlayTexture, [IsReadOnly] in TextureHandle dstColor); // 0x0000000181F6E3C0-0x0000000181F6E4B0
		internal DebugRendererLists CreateRendererListsWithDebugRenderState(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock); // 0x0000000181F6DD70-0x0000000181F6DF50
	}
}
