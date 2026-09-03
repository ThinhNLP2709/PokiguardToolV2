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
	internal sealed class ScalingSetupPostProcessPass : PostProcessPass // TypeDefIndex: 9619
	{
		// Fields
		public const string k_TargetName = "SetupUpscaling"; // Metadata: 0x0069ED5D
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private HDROutputUtils.Operation m_HdrOperations; // 0x74
	
		// Nested types
		private class PostProcessingFinalSetupPassData // TypeDefIndex: 9620
		{
			// Fields
			internal TextureHandle destinationTexture; // 0x10
			internal TextureHandle sourceTexture; // 0x20
			internal Material material; // 0x30
			internal UniversalCameraData cameraData; // 0x38
			internal Tonemapping tonemapping; // 0x40
			internal HDROutputUtils.Operation hdrOperations; // 0x48
	
			// Constructors
			public PostProcessingFinalSetupPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9621
		{
			// Fields
			public static readonly int _SourceSize; // 0x00
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4A90-0x0000000181FB4AE0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9622
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PostProcessingFinalSetupPassData, RasterGraphContext> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF140-0x0000000181FBF1B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__8_0(PostProcessingFinalSetupPassData data, RasterGraphContext context); // 0x0000000181FBC2E0-0x0000000181FBC5B0
		}
	
		// Constructors
		public ScalingSetupPostProcessPass(Shader shader); // 0x0000000181FB4790-0x0000000181FB4880
	
		// Methods
		public override void Dispose(); // 0x0000000181FB3F80-0x0000000181FB3FE0
		public void Setup(HDROutputUtils.Operation hdrOperations); // 0x000000018198E760-0x000000018198E770
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB3FE0-0x0000000181FB4790
	}
}
