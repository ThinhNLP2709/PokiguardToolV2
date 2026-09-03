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
	internal sealed class DepthOfFieldGaussianPostProcessPass : PostProcessPass // TypeDefIndex: 9589
	{
		// Fields
		public const string k_TargetName = "CameraColorDepthOfFieldGaussian"; // Metadata: 0x0069ECCD
		private const int k_DownSample = 2; // Metadata: 0x0069ECED
		private Material m_Material; // 0x68
		private Material m_MaterialCoc; // 0x70
		private bool m_IsValid; // 0x78
		private GraphicsFormat m_CoCFormat; // 0x7C
	
		// Nested types
		private class DoFGaussianPassData // TypeDefIndex: 9590
		{
			// Fields
			internal Material material; // 0x10
			internal Material materialCoC; // 0x18
			internal TextureHandle sourceTexture; // 0x20
			internal TextureHandle depthTexture; // 0x30
			internal TextureHandle halfCoCTexture; // 0x40
			internal TextureHandle fullCoCTexture; // 0x50
			internal TextureHandle pingTexture; // 0x60
			internal TextureHandle pongTexture; // 0x70
			internal RenderTargetIdentifier[] multipleRenderTargets; // 0x80
			internal TextureHandle destination; // 0x88
			internal Vector3 cocParams; // 0x98
			internal int downsample; // 0xA4
			internal bool highQualitySamplingValue; // 0xA8
			internal bool enableAlphaOutput; // 0xA9
	
			// Constructors
			public DoFGaussianPassData(); // 0x0000000181FA79B0-0x0000000181FA7A10
		}
	
		public static class ShaderConstants // TypeDefIndex: 9591
		{
			// Fields
			public static readonly int _ColorTexture; // 0x00
			public static readonly int _CameraDepthTextureID; // 0x04
			public static readonly int _SourceSize; // 0x08
			public static readonly int _DownSampleScaleFactor; // 0x0C
			public static readonly int _CoCParams; // 0x10
			public static readonly int _FullCoCTexture; // 0x14
			public static readonly int _HalfCoCTexture; // 0x18
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4F60-0x0000000181FB50C0
		}
	
		public static class ShaderPass // TypeDefIndex: 9592
		{
			// Fields
			public const int k_ComputeCoc = 0; // Metadata: 0x0069ECEE
			public const int k_DownscalePrefilter = 1; // Metadata: 0x0069ECEF
			public const int k_BlurH = 2; // Metadata: 0x0069ECF0
			public const int k_BlurV = 3; // Metadata: 0x0069ECF1
			public const int k_Composite = 4; // Metadata: 0x0069ECF2
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9593
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<DoFGaussianPassData, UnsafeGraphContext> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF060-0x0000000181FBF0D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__9_0(DoFGaussianPassData data, UnsafeGraphContext context); // 0x0000000181FBCBB0-0x0000000181FBD8B0
		}
	
		// Constructors
		public DepthOfFieldGaussianPostProcessPass(Shader shader); // 0x0000000181FA7710-0x0000000181FA7870
	
		// Methods
		public override void Dispose(); // 0x0000000181FA66B0-0x0000000181FA6720
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA6720-0x0000000181FA7710
	}
}
