/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal sealed class Fsr1UpscalePostProcessPass : PostProcessPass // TypeDefIndex: 9599
	{
		// Fields
		public const string k_TargetName = "CameraColorUpscaled"; // Metadata: 0x0069ECF7
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private TextureDesc m_UpscaledDesc; // 0x78
	
		// Nested types
		private class PostProcessingFinalFSRScalePassData // TypeDefIndex: 9600
		{
			// Fields
			internal Material material; // 0x10
			internal TextureHandle sourceTexture; // 0x18
			internal Vector2 fsrInputSize; // 0x28
			internal Vector2 fsrOutputSize; // 0x30
			internal bool enableAlphaOutput; // 0x38
	
			// Constructors
			public PostProcessingFinalFSRScalePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9601
		{
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9602
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PostProcessingFinalFSRScalePassData, RasterGraphContext> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF220-0x0000000181FBF290
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__8_0(PostProcessingFinalFSRScalePassData data, RasterGraphContext context); // 0x0000000181FBC080-0x0000000181FBC2E0
		}
	
		// Constructors
		public Fsr1UpscalePostProcessPass(Shader shader); // 0x0000000181FA8F20-0x0000000181FA9050
	
		// Methods
		public override void Dispose(); // 0x0000000181FA86F0-0x0000000181FA8750
		public void Setup(TextureDesc upscaledDesc); // 0x0000000181FA8EB0-0x0000000181FA8F20
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA8750-0x0000000181FA8EB0
	}
}
