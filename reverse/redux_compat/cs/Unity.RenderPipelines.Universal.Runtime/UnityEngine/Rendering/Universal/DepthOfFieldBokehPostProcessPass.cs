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
	internal sealed class DepthOfFieldBokehPostProcessPass : PostProcessPass // TypeDefIndex: 9584
	{
		// Fields
		public const string k_TargetName = "CameraColorDepthOfFieldBokeh"; // Metadata: 0x0069ECAA
		private const int k_DownSample = 2; // Metadata: 0x0069ECC7
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private Vector4[] m_BokehKernel; // 0x78
		private int m_BokehHash; // 0x80
		private float m_BokehMaxRadius; // 0x84
		private float m_BokehRcpAspect; // 0x88
	
		// Nested types
		private class DoFBokehPassData // TypeDefIndex: 9585
		{
			// Fields
			internal Material material; // 0x10
			internal TextureHandle sourceTexture; // 0x18
			internal TextureHandle depthTexture; // 0x28
			internal TextureHandle halfCoCTexture; // 0x38
			internal TextureHandle fullCoCTexture; // 0x48
			internal TextureHandle pingTexture; // 0x58
			internal TextureHandle pongTexture; // 0x68
			internal TextureHandle destinationTexture; // 0x78
			internal Vector4[] bokehKernel; // 0x88
			internal Vector4 cocParams; // 0x90
			internal int downSample; // 0xA0
			internal float uvMargin; // 0xA4
			internal bool useFastSRGBLinearConversion; // 0xA8
			internal bool enableAlphaOutput; // 0xA9
	
			// Constructors
			public DoFBokehPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9586
		{
			// Fields
			public static readonly int _CameraDepthTextureID; // 0x00
			public static readonly int _SourceSize; // 0x04
			public static readonly int _FullCoCTexture; // 0x08
			public static readonly int _DofTexture; // 0x0C
			public static readonly int _CoCParams; // 0x10
			public static readonly int _BokehKernel; // 0x14
			public static readonly int _BokehConstants; // 0x18
			public static readonly int _DownSampleScaleFactor; // 0x1C
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4DE0-0x0000000181FB4F60
		}
	
		public static class ShaderPass // TypeDefIndex: 9587
		{
			// Fields
			public const int k_ComputeCoc = 0; // Metadata: 0x0069ECC8
			public const int k_DownscalePrefilter = 1; // Metadata: 0x0069ECC9
			public const int k_Blur = 2; // Metadata: 0x0069ECCA
			public const int k_PostFilter = 3; // Metadata: 0x0069ECCB
			public const int k_Composite = 4; // Metadata: 0x0069ECCC
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9588
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<DoFBokehPassData, UnsafeGraphContext> __9__11_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBED50-0x0000000181FBEDC0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__11_0(DoFBokehPassData data, UnsafeGraphContext context); // 0x0000000181FB97F0-0x0000000181FBA170
		}
	
		// Constructors
		public DepthOfFieldBokehPostProcessPass(Shader shader); // 0x0000000181FA65D0-0x0000000181FA66B0
	
		// Methods
		public override void Dispose(); // 0x0000000181FA52F0-0x0000000181FA5350
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA5670-0x0000000181FA65D0
		private static void PrepareBokehKernel(ref Vector4[] bokehKernel, int bladeCount, float bladeCurvature, float bladeRotation, float maxRadius, float rcpAspect); // 0x0000000181FA5370-0x0000000181FA5670
		public static float GetMaxBokehRadiusInPixels(float viewportHeight); // 0x0000000181FA5350-0x0000000181FA5370
	}
}
