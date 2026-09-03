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
	public class CopyDepthPass : ScriptableRenderPass // TypeDefIndex: 9906
	{
		// Fields
		[CompilerGenerated]
		private bool _CopyToDepthXR_k__BackingField; // 0x60
		private Material m_CopyDepthMaterial; // 0x68
	
		// Properties
		internal bool CopyToDepthXR { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4F0-0x000000018033D500 0x000000018033EA80-0x000000018033EA90
	
		// Nested types
		private static class ShaderConstants // TypeDefIndex: 9907
		{
			// Fields
			public static readonly int _CameraDepthAttachment; // 0x00
			public static readonly int _CameraDepthTexture; // 0x04
			public static readonly int _ZWriteShaderHandle; // 0x08
	
			// Constructors
			static ShaderConstants(); // 0x000000018203FAC0-0x000000018203FB70
		}
	
		private class PassData // TypeDefIndex: 9908
		{
			// Fields
			internal TextureHandle source; // 0x10
			internal TextureHandle destination; // 0x20
			internal UniversalCameraData cameraData; // 0x30
			internal Material copyDepthMaterial; // 0x38
			internal bool copyResolvedDepth; // 0x40
			internal bool copyToDepth; // 0x41
			internal bool setViewport; // 0x42
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9909
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__12_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041580-0x00000001820415F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__12_0(PassData data, RasterGraphContext context); // 0x00000001820408B0-0x00000001820409A0
		}
	
		// Constructors
		public CopyDepthPass(RenderPassEvent evt, Shader copyDepthShader, bool shouldClear = false /* Metadata: 0x0069FD7E */, bool copyToDepth = false /* Metadata: 0x0069FD7F */, bool copyResolvedDepth = false /* Metadata: 0x0069FD80 */, string customPassName = null); // 0x0000000182033820-0x0000000182033970
	
		// Methods
		public void Setup(RTHandle source, RTHandle destination); // 0x00000001802E76C0-0x00000001802E76D0
		public void Dispose(); // 0x0000000182032760-0x00000001820327B0
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle source, Vector4 scaleBias); // 0x00000001820327B0-0x0000000182032BC0
		public void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle destination, TextureHandle source, bool bindAsCameraDepth = false /* Metadata: 0x0069FD81 */, string passName = "Copy Depth" /* Metadata: 0x0069FD82 */); // 0x0000000182032BC0-0x0000000182032CC0
		public void Render(RenderGraph renderGraph, TextureHandle destination, TextureHandle source, UniversalResourceData resourceData, UniversalCameraData cameraData, bool bindAsCameraDepth = false /* Metadata: 0x0069FD8D */, string passName = "Copy Depth" /* Metadata: 0x0069FD8E */); // 0x0000000182032CC0-0x0000000182033820
	}
}
