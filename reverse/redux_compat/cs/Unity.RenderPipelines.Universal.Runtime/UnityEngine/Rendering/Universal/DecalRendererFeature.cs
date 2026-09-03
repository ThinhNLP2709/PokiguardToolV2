/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisallowMultipleRendererFeature("Decal")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("With this Renderer Feature, Unity can project specific Materials (decals) onto other objects in the Scene.")]
	public class DecalRendererFeature : ScriptableRendererFeature // TypeDefIndex: 9709
	{
		// Fields
		private static SharedDecalEntityManager sharedDecalEntityManager; // 0x00
		[SerializeField]
		private DecalSettings m_Settings; // 0x28
		private DecalTechnique m_Technique; // 0x30
		private DBufferSettings m_DBufferSettings; // 0x38
		private DecalScreenSpaceSettings m_ScreenSpaceSettings; // 0x40
		private bool m_RecreateSystems; // 0x48
		private DecalPreviewPass m_DecalPreviewPass; // 0x50
		private DecalEntityManager m_DecalEntityManager; // 0x58
		private DecalUpdateCachedSystem m_DecalUpdateCachedSystem; // 0x60
		private DecalUpdateCullingGroupSystem m_DecalUpdateCullingGroupSystem; // 0x68
		private DecalUpdateCulledSystem m_DecalUpdateCulledSystem; // 0x70
		private DecalCreateDrawCallSystem m_DecalCreateDrawCallSystem; // 0x78
		private DecalDrawErrorSystem m_DrawErrorSystem; // 0x80
		private DBufferCopyDepthPass m_CopyDepthPass; // 0x88
		private DBufferRenderPass m_DBufferRenderPass; // 0x90
		private DecalForwardEmissivePass m_ForwardEmissivePass; // 0x98
		private DecalDrawDBufferSystem m_DecalDrawDBufferSystem; // 0xA0
		private DecalDrawFowardEmissiveSystem m_DecalDrawForwardEmissiveSystem; // 0xA8
		private Material m_DBufferClearMaterial; // 0xB0
		private DecalScreenSpaceRenderPass m_ScreenSpaceDecalRenderPass; // 0xB8
		private DecalDrawScreenSpaceSystem m_DecalDrawScreenSpaceSystem; // 0xC0
		private DecalSkipCulledSystem m_DecalSkipCulledSystem; // 0xC8
		private DecalGBufferRenderPass m_GBufferRenderPass; // 0xD0
		private DecalDrawGBufferSystem m_DrawGBufferSystem; // 0xD8
		private DeferredLights m_DeferredLights; // 0xE0
	
		// Properties
		internal ref DecalSettings settings { get; } // 0x0000000181FC2D50-0x0000000181FC2D60 
		internal bool intermediateRendering { get; } // 0x0000000181A6C2D0-0x0000000181A6C2E0 
		internal bool requiresDecalLayers { get; } // 0x0000000181FC2D30-0x0000000181FC2D50 
		internal static bool isGLDevice { get; } // 0x0000000181DEC220-0x0000000181DEC250 
	
		// Constructors
		public DecalRendererFeature(); // 0x0000000181FC2CC0-0x0000000181FC2D30
		static DecalRendererFeature(); // 0x0000000181FC2C40-0x0000000181FC2CC0
	
		// Methods
		public override void Create(); // 0x0000000181FC1970-0x0000000181FC19E0
		internal override bool RequireRenderingLayers(bool isDeferred, bool needsGBufferAccurateNormals, out RenderingLayerUtils.Event atEvent, out RenderingLayerUtils.MaskSize maskSize); // 0x0000000181FC2B80-0x0000000181FC2C40
		internal DBufferSettings GetDBufferSettings(); // 0x0000000181FC1C40-0x0000000181FC1CC0
		internal DecalScreenSpaceSettings GetScreenSpaceSettings(); // 0x0000000181FC1CC0-0x0000000181FC1D40
		internal DecalTechnique GetTechnique(ScriptableRendererData renderer); // 0x0000000181FC2070-0x0000000181FC21B0
		internal DecalTechnique GetTechnique(ScriptableRenderer renderer); // 0x0000000181FC1F90-0x0000000181FC2070
		internal DecalTechnique GetTechnique(bool isDeferred, bool needsGBufferAccurateNormals, bool checkForInvalidTechniques = true /* Metadata: 0x0069EEEE */); // 0x0000000181FC1D40-0x0000000181FC1F90
		private bool IsAutomaticDBuffer(); // 0x0000000181FC21B0-0x0000000181FC2230
		private bool RecreateSystemsIfNeeded(ScriptableRenderer renderer, [IsReadOnly] in CameraData cameraData); // 0x0000000181FC2390-0x0000000181FC2B80
		public override void OnCameraPreCull(ScriptableRenderer renderer, [IsReadOnly] in CameraData cameraData); // 0x0000000181FC2230-0x0000000181FC2390
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FC1680-0x0000000181FC1800
		protected override void Dispose(bool disposing); // 0x0000000181FC19E0-0x0000000181FC1C40
		[Conditional("ENABLE_ADAPTIVE_PERFORMANCE")]
		private void ChangeAdaptivePerformanceDrawDistances(); // 0x0000000181FC1800-0x0000000181FC1970
	}
}
