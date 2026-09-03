/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.VFX;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public abstract class ScriptableRenderer : IDisposable // TypeDefIndex: 9450
	{
		// Fields
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly DebugHandler _DebugHandler_k__BackingField; // 0x18
		internal static ScriptableRenderer current; // 0x00
		[CompilerGenerated]
		private RenderingFeatures _supportedRenderingFeatures_k__BackingField; // 0x20
		[CompilerGenerated]
		private GraphicsDeviceType[] _unsupportedGraphicsDeviceTypes_k__BackingField; // 0x28
		private List<ScriptableRenderPass> m_ActiveRenderPassQueue; // 0x30
		private List<ScriptableRendererFeature> m_RendererFeatures; // 0x38
		private bool m_IsPipelineExecuting; // 0x40
		private ContextContainer m_frameData; // 0x48
		private static readonly Plane[] s_Planes; // 0x08
		private static readonly Vector4[] s_VectorPlanes; // 0x10
		[CompilerGenerated]
		private bool _useDepthPriming_k__BackingField; // 0x50
		[CompilerGenerated]
		private bool _stripShadowsOffVariants_k__BackingField; // 0x51
		[CompilerGenerated]
		private bool _stripAdditionalLightOffVariants_k__BackingField; // 0x52
	
		// Properties
		internal string name { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal DebugHandler DebugHandler { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		protected List<ScriptableRendererFeature> rendererFeatures { get; } // 0x00000001803272A0-0x00000001803272B0 
		protected List<ScriptableRenderPass> activeRenderPassQueue { get; } // 0x000000018031E110-0x000000018031E120 
		public RenderingFeatures supportedRenderingFeatures { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public GraphicsDeviceType[] unsupportedGraphicsDeviceTypes { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal ContextContainer frameData { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal bool useDepthPriming { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
		internal bool stripShadowsOffVariants { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F4040-0x00000001802F4050 0x00000001802F4060-0x00000001802F4070
		internal bool stripAdditionalLightOffVariants { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001818986C0-0x00000001818986D0 0x0000000181C64010-0x0000000181C64020
		public virtual bool supportsGPUOcclusion { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		private static class Profiling // TypeDefIndex: 9451
		{
			// Fields
			private const string k_Name = "ScriptableRenderer"; // Metadata: 0x0069EB37
			public static readonly ProfilingSampler setPerCameraShaderVariables; // 0x00
			public static readonly ProfilingSampler sortRenderPasses; // 0x08
			public static readonly ProfilingSampler recordRenderGraph; // 0x10
			public static readonly ProfilingSampler setupCamera; // 0x18
			public static readonly ProfilingSampler vfxProcessCamera; // 0x20
			public static readonly ProfilingSampler addRenderPasses; // 0x28
			public static readonly ProfilingSampler clearRenderingState; // 0x30
			public static readonly ProfilingSampler internalFinishRenderingCommon; // 0x38
			public static readonly ProfilingSampler drawGizmos; // 0x40
			public static readonly ProfilingSampler drawWireOverlay; // 0x48
			internal static readonly ProfilingSampler beginXRRendering; // 0x50
			internal static readonly ProfilingSampler endXRRendering; // 0x58
			internal static readonly ProfilingSampler initRenderGraphFrame; // 0x60
			internal static readonly ProfilingSampler setEditorTarget; // 0x68
	
			// Constructors
			static Profiling(); // 0x0000000181F971B0-0x0000000181F976C0
		}
	
		public class RenderingFeatures // TypeDefIndex: 9452
		{
			// Fields
			[CompilerGenerated]
			private bool _cameraStacking_k__BackingField; // 0x10
			[CompilerGenerated]
			private bool _msaa_k__BackingField; // 0x11
			[CompilerGenerated]
			private bool _overlayCamera_k__BackingField; // 0x12
			[CompilerGenerated]
			private bool _supportsHDR_k__BackingField; // 0x13
			[CompilerGenerated]
			private bool _postProcessing_k__BackingField; // 0x14
			[CompilerGenerated]
			private bool _upscaling_k__BackingField; // 0x15
			[CompilerGenerated]
			private bool _gpuOcclusionCulling_k__BackingField; // 0x16
			[CompilerGenerated]
			private bool _antiAliasing_k__BackingField; // 0x17
			[CompilerGenerated]
			private bool _cameraOpaqueTexture_k__BackingField; // 0x18
			[CompilerGenerated]
			private bool _cameraDepthTexture_k__BackingField; // 0x19
			[CompilerGenerated]
			private bool _deferredLighting_k__BackingField; // 0x1A
	
			// Properties
			[Obsolete("cameraStacking has been deprecated use SupportedCameraRenderTypes() in ScriptableRenderer instead. #from(2022.2) #breakingFrom(2023.1)", true)]
			public bool cameraStacking { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
			public bool msaa { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
			internal bool overlayCamera { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E20-0x0000000180E38E30 0x0000000181734F30-0x0000000181734F40
			internal bool supportsHDR { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E40-0x0000000180E38E50 0x0000000181F33560-0x0000000181F33570
			internal bool postProcessing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
			internal bool upscaling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018155D200-0x000000018155D210 0x000000018155D210-0x000000018155D220
			internal bool gpuOcclusionCulling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F978F0-0x0000000181F97900 0x0000000181F97910-0x0000000181F97920
			internal bool antiAliasing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F978E0-0x0000000181F978F0 0x0000000181F97900-0x0000000181F97910
			internal bool cameraOpaqueTexture { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
			internal bool cameraDepthTexture { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
			internal bool deferredLighting { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
	
			// Constructors
			public RenderingFeatures(); // 0x0000000181F978D0-0x0000000181F978E0
		}
	
		private class VFXProcessCameraPassData // TypeDefIndex: 9453
		{
			// Fields
			internal UniversalRenderingData renderingData; // 0x10
			internal Camera camera; // 0x18
			internal VFXCameraXRSettings cameraXRSettings; // 0x20
			internal XRPass xrPass; // 0x30
	
			// Constructors
			public VFXProcessCameraPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class DrawGizmosPassData // TypeDefIndex: 9454
		{
			// Fields
			public RendererListHandle gizmoRenderList; // 0x10
			public TextureHandle color; // 0x1C
			public TextureHandle depth; // 0x2C
			public bool clampViewport; // 0x3C
			public Rect viewport; // 0x40
	
			// Constructors
			public DrawGizmosPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class DrawWireOverlayPassData // TypeDefIndex: 9455
		{
			// Fields
			public RendererListHandle wireOverlayList; // 0x10
	
			// Constructors
			public DrawWireOverlayPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class BeginXRPassData // TypeDefIndex: 9456
		{
			// Fields
			internal UniversalCameraData cameraData; // 0x10
	
			// Constructors
			public BeginXRPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class EndXRPassData // TypeDefIndex: 9457
		{
			// Fields
			public UniversalCameraData cameraData; // 0x10
	
			// Constructors
			public EndXRPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class DummyData // TypeDefIndex: 9458
		{
			// Constructors
			public DummyData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class PassData // TypeDefIndex: 9459
		{
			// Fields
			internal ScriptableRenderer renderer; // 0x10
			internal UniversalCameraData cameraData; // 0x18
			internal TextureHandle target; // 0x20
			internal Vector2Int cameraTargetSizeCopy; // 0x30
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9460
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, UnsafeGraphContext> __9__63_0; // 0x08
			public static BaseRenderFunc<VFXProcessCameraPassData, UnsafeGraphContext> __9__65_0; // 0x10
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__66_0; // 0x18
			public static BaseRenderFunc<BeginXRPassData, UnsafeGraphContext> __9__72_0; // 0x20
			public static BaseRenderFunc<EndXRPassData, RasterGraphContext> __9__74_0; // 0x28
			public static BaseRenderFunc<DummyData, UnsafeGraphContext> __9__76_0; // 0x30
	
			// Constructors
			static __c(); // 0x0000000181F9B330-0x0000000181F9B3A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _InitRenderGraphFrame_b__63_0(PassData data, UnsafeGraphContext rgContext); // 0x0000000181F9A2B0-0x0000000181F9A370
			internal void _ProcessVFXCameraCommand_b__65_0(VFXProcessCameraPassData data, UnsafeGraphContext context); // 0x0000000181F9A370-0x0000000181F9A4B0
			internal void _SetupRenderGraphCameraProperties_b__66_0(PassData data, RasterGraphContext context); // 0x0000000181F9AFF0-0x0000000181F9B1E0
			internal void _BeginRenderGraphXRRendering_b__72_0(BeginXRPassData data, UnsafeGraphContext context); // 0x0000000181F99D40-0x0000000181F99F50
			internal void _EndRenderGraphXRRendering_b__74_0(EndXRPassData data, RasterGraphContext context); // 0x0000000181F9A100-0x0000000181F9A2B0
			internal void _SetEditorTarget_b__76_0(DummyData data, UnsafeGraphContext context); // 0x0000000181F9AF70-0x0000000181F9AFF0
		}
	
		// Constructors
		public ScriptableRenderer(ScriptableRendererData data); // 0x0000000181F84EB0-0x0000000181F851A0
		static ScriptableRenderer(); // 0x0000000181F84DD0-0x0000000181F84EB0
	
		// Methods
		public virtual int SupportedCameraStackingTypes(); // 0x00000001802E7860-0x00000001802E7870
		public bool SupportsCameraStackingType(CameraRenderType cameraRenderType); // 0x0000000181F84D90-0x0000000181F84DD0
		protected internal virtual bool SupportsMotionVectors(); // 0x00000001802E7840-0x00000001802E7850
		protected internal virtual bool SupportsCameraOpaque(); // 0x00000001802E7840-0x00000001802E7850
		protected internal virtual bool SupportsCameraNormals(); // 0x00000001802E7840-0x00000001802E7850
		internal static void SetCameraMatrices(RasterCommandBuffer cmd, UniversalCameraData cameraData, bool setInverseMatrices, bool isTargetFlipped); // 0x0000000181F82A70-0x0000000181F83010
		private void SetPerCameraShaderVariables(RasterCommandBuffer cmd, UniversalCameraData cameraData, Vector2Int cameraTargetSizeCopy, bool isTargetFlipped); // 0x0000000181F83890-0x0000000181F84200
		private void SetPerCameraBillboardProperties(RasterCommandBuffer cmd, UniversalCameraData cameraData); // 0x0000000181F83300-0x0000000181F83540
		private static void CalculateBillboardProperties([IsReadOnly] in Matrix4x4 worldToCameraMatrix, out Vector3 billboardTangent, out Vector3 billboardNormal, out float cameraXZAngle); // 0x0000000181F80340-0x0000000181F80710
		private void SetPerCameraClippingPlaneProperties(RasterCommandBuffer cmd, [IsReadOnly] in UniversalCameraData cameraData, bool isTargetFlipped); // 0x0000000181F83540-0x0000000181F83890
		private static void SetShaderTimeValues(IBaseCommandBuffer cmd, float time, float deltaTime, float smoothDeltaTime); // 0x0000000181F84200-0x0000000181F84900
		internal virtual void UpdateSupportedRenderingFeatures(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Dispose(); // 0x0000000181F80E60-0x0000000181F81010
		protected virtual void Dispose(bool disposing); // 0x0000000181F81010-0x0000000181F810E0
		internal virtual void ReleaseRenderTargets(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void FinishRendering(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnBeginRenderGraphFrame(); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void OnRecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnEndRenderGraphFrame(); // 0x00000001802E76C0-0x00000001802E76D0
		private void InitRenderGraphFrame(RenderGraph renderGraph); // 0x0000000181F81850-0x0000000181F81B60
		internal void ProcessVFXCameraCommand(RenderGraph renderGraph); // 0x0000000181F81EC0-0x0000000181F82330
		internal void SetupRenderGraphCameraProperties(RenderGraph renderGraph, [IsReadOnly] in TextureHandle target); // 0x0000000181F84900-0x0000000181F84CC0
		internal void DrawRenderGraphGizmos(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle color, [IsReadOnly] in TextureHandle depth, GizmoSubset gizmoSubset); // 0x00000001802E76C0-0x00000001802E76D0
		internal void DrawRenderGraphWireOverlay(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle color); // 0x00000001802E76C0-0x00000001802E76D0
		internal void BeginRenderGraphXRRendering(RenderGraph renderGraph); // 0x0000000181F7FF50-0x0000000181F80340
		internal void EndRenderGraphXRRendering(RenderGraph renderGraph); // 0x0000000181F810E0-0x0000000181F814A0
		private void SetEditorTarget(RenderGraph renderGraph); // 0x0000000181F83010-0x0000000181F83300
		internal void RecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context); // 0x0000000181F82510-0x0000000181F82880
		internal void FinishRenderGraphRendering(CommandBuffer cmd); // 0x0000000181F81550-0x0000000181F815F0
		internal virtual void OnFinishRenderGraphRendering(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		internal void RecordCustomRenderGraphPassesInEventRange(RenderGraph renderGraph, RenderPassEvent eventStart, RenderPassEvent eventEnd); // 0x0000000181F82330-0x0000000181F82460
		internal void CalculateSplitEventRange(RenderPassEvent startInjectionPoint, RenderPassEvent targetEvent, out RenderPassEvent startEvent, out RenderPassEvent splitEvent, out RenderPassEvent endEvent); // 0x0000000181F80710-0x0000000181F80800
		internal void RecordCustomRenderGraphPasses(RenderGraph renderGraph, RenderPassEvent startInjectionPoint, RenderPassEvent endInjectionPoint); // 0x0000000181F82460-0x0000000181F824C0
		internal void RecordCustomRenderGraphPasses(RenderGraph renderGraph, RenderPassEvent injectionPoint); // 0x0000000181F824C0-0x0000000181F82510
		public void EnqueuePass(ScriptableRenderPass pass); // 0x0000000181F814A0-0x0000000181F81550
		[Obsolete("GetCameraClearFlag is no longer used and will be removed. #from(6000.6)", false)]
		protected static ClearFlag GetCameraClearFlag(ref CameraData cameraData); // 0x0000000181F817F0-0x0000000181F81850
		[Obsolete("GetCameraClearFlag is no longer used and will be removed. #from(6000.6)", false)]
		protected static ClearFlag GetCameraClearFlag(UniversalCameraData cameraData); // 0x0000000181F815F0-0x0000000181F817F0
		internal void OnPreCullRenderPasses([IsReadOnly] in CameraData cameraData); // 0x0000000181F81E20-0x0000000181F81EC0
		internal void AddRenderPasses(ref RenderingData renderingData); // 0x0000000181F7FD90-0x0000000181F7FF50
		private static void ClearRenderingState(IBaseCommandBuffer cmd); // 0x0000000181F80800-0x0000000181F80E60
		internal bool IsSceneFilteringEnabled(Camera camera); // 0x00000001802E7840-0x00000001802E7850
		private void InternalFinishRenderingCommon(CommandBuffer cmd, bool resolveFinalTarget); // 0x0000000181F81B60-0x0000000181F81CE0
		private protected void ReportRealBackbufferMSAA(UniversalCameraData cameraData, bool requiresIntermediateAttachments); // 0x0000000181F82880-0x0000000181F82A70
		private static bool NeedsRealBackbufferMSAA(UniversalCameraData cameraData, ScriptableRenderer renderer, bool requiresIntermediateAttachments); // 0x0000000181F81CE0-0x0000000181F81E20
		internal static void SortStable(List<ScriptableRenderPass> list); // 0x0000000181F84CC0-0x0000000181F84D90
	}
}
