/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Scripting.APIUpdating;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.Universal", null, null)]
	public class RenderObjectsPass : ScriptableRenderPass // TypeDefIndex: 9656
	{
		// Fields
		private RenderQueueType renderQueueType; // 0x60
		private FilteringSettings m_FilteringSettings; // 0x64
		private RenderObjects.CustomCameraSettings m_CameraSettings; // 0x88
		[CompilerGenerated]
		private Material _overrideMaterial_k__BackingField; // 0x90
		[CompilerGenerated]
		private int _overrideMaterialPassIndex_k__BackingField; // 0x98
		[CompilerGenerated]
		private Shader _overrideShader_k__BackingField; // 0xA0
		[CompilerGenerated]
		private int _overrideShaderPassIndex_k__BackingField; // 0xA8
		private List<ShaderTagId> m_ShaderTagIdList; // 0xB0
		private PassData m_PassData; // 0xB8
		private bool m_DepthInputAttachment; // 0xC0
		private RenderStateBlock m_RenderStateBlock; // 0xC4
	
		// Properties
		public Material overrideMaterial { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public int overrideMaterialPassIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
		public Shader overrideShader { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public int overrideShaderPassIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806671D0-0x00000001806671E0 0x0000000181EE3C80-0x0000000181EE3C90
	
		// Nested types
		private class PassData // TypeDefIndex: 9657
		{
			// Fields
			internal RenderObjects.CustomCameraSettings cameraSettings; // 0x10
			internal RenderPassEvent renderPassEvent; // 0x18
			internal TextureHandle color; // 0x1C
			internal RendererListHandle rendererListHdl; // 0x2C
			internal DebugRendererLists debugRendererLists; // 0x38
			internal UniversalCameraData cameraData; // 0x40
			internal RendererList rendererList; // 0x48
			internal bool depthInputAttachment; // 0x60
			internal bool isActiveTargetBackBuffer; // 0x61
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9658
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__34_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEC70-0x0000000181FBECE0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__34_0(PassData data, RasterGraphContext rgContext); // 0x0000000181FBB7F0-0x0000000181FBBA30
		}
	
		// Constructors
		public RenderObjectsPass(string profilerTag, RenderPassEvent renderPassEvent, string[] shaderTags, RenderQueueType renderQueueType, int layerMask, RenderObjects.CustomCameraSettings cameraSettings); // 0x0000000181FB15D0-0x0000000181FB16E0
	
		// Methods
		[Obsolete("Use SetDepthState instead. #from(2023.1) #breakingFrom(2023.1)", true)]
		public void SetDetphState(bool writeEnabled, CompareFunction function = CompareFunction.Less /* Metadata: 0x0069EE2B */); // 0x0000000181FB13C0-0x0000000181FB1400
		public void SetDepthState(bool writeEnabled, CompareFunction function = CompareFunction.Less /* Metadata: 0x0069EE2C */); // 0x0000000181FB13C0-0x0000000181FB1400
		internal void SetDepthInputAttachment(bool enable); // 0x0000000181F64A30-0x0000000181F64A40
		public void SetStencilState(int reference, CompareFunction compareFunction, StencilOp passOp, StencilOp failOp, StencilOp zFailOp); // 0x0000000181FB1400-0x0000000181FB14E0
		public void SetStencilState(int reference, CompareFunction compareFunction, StencilOp passOp, StencilOp failOp, StencilOp zFailOp, int readMask, int writeMask); // 0x0000000181FB14E0-0x0000000181FB15D0
		internal void Init(RenderPassEvent renderPassEvent, string[] shaderTags, RenderQueueType renderQueueType, int layerMask, RenderObjects.CustomCameraSettings cameraSettings); // 0x0000000181FB00D0-0x0000000181FB0550
		private static void ExecutePass(PassData passData, RasterCommandBuffer cmd, RendererList rendererList, bool isYFlipped); // 0x0000000181FAF5F0-0x0000000181FAFC60
		private void InitPassData(UniversalCameraData cameraData, ref PassData passData, bool isActiveTargetBackBuffer = false /* Metadata: 0x0069EE2D */); // 0x0000000181FAFC60-0x0000000181FAFCF0
		private void InitRendererLists(UniversalRenderingData renderingData, UniversalLightData lightData, ref PassData passData, RenderGraph renderGraph); // 0x0000000181FAFCF0-0x0000000181FB00D0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB0550-0x0000000181FB13C0
	}
}
