/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class DepthOnlyPass : ScriptableRenderPass // TypeDefIndex: 9916
	{
		// Fields
		[CompilerGenerated]
		private ShaderTagId _shaderTagId_k__BackingField; // 0x60
		private FilteringSettings m_FilteringSettings; // 0x64
		private static readonly ShaderTagId k_ShaderTagId; // 0x00
		private static readonly int s_CameraDepthTextureID; // 0x04
	
		// Properties
		internal ShaderTagId shaderTagId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
	
		// Nested types
		private class PassData // TypeDefIndex: 9917
		{
			// Fields
			internal RendererListHandle rendererList; // 0x10
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9918
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__12_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820417B0-0x0000000182041820
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__12_0(PassData data, RasterGraphContext context); // 0x00000001820407F0-0x00000001820408B0
		}
	
		// Constructors
		public DepthOnlyPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask); // 0x0000000182036460-0x00000001820365D0
		static DepthOnlyPass(); // 0x00000001820363D0-0x0000000182036460
	
		// Methods
		public void Setup(RenderTextureDescriptor baseDescriptor, RTHandle depthAttachmentHandle); // 0x00000001802E76C0-0x00000001802E76D0
		private static void ExecutePass(RasterCommandBuffer cmd, RendererList rendererList); // 0x0000000182035780-0x0000000182035880
		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000182035880-0x0000000182035B20
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle depthTexture, uint batchLayerMask, bool setGlobalDepth); // 0x0000000182035B20-0x00000001820363D0
	}
}
