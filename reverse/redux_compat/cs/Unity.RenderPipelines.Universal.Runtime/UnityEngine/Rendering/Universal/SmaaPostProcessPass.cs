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
	internal sealed class SmaaPostProcessPass : PostProcessPass // TypeDefIndex: 9623
	{
		// Fields
		public const string k_TargetName = "CameraColorSMAA"; // Metadata: 0x0069ED6C
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private Texture2D m_AreaTexture; // 0x78
		private Texture2D m_SearchTexture; // 0x80
		private GraphicsFormat m_SMAAEdgeFormat; // 0x88
		private const string k_passNameEdgeDetection = "Blit SMAA Edge Detection"; // Metadata: 0x0069ED7C
		private const string k_passNameBlendWeights = "Blit SMAA Blend Weights"; // Metadata: 0x0069ED95
	
		// Nested types
		private class SMAASetupPassData // TypeDefIndex: 9624
		{
			// Fields
			internal Vector4 metrics; // 0x10
			internal Texture2D areaTexture; // 0x20
			internal Texture2D searchTexture; // 0x28
			internal float stencilRef; // 0x30
			internal float stencilMask; // 0x34
			internal AntialiasingQuality antialiasingQuality; // 0x38
			internal Material material; // 0x40
			internal TextureHandle sourceTexture; // 0x48
	
			// Constructors
			public SMAASetupPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class SMAAPassData // TypeDefIndex: 9625
		{
			// Fields
			internal TextureHandle sourceTexture; // 0x10
			internal TextureHandle blendTexture; // 0x20
			internal Material material; // 0x30
	
			// Constructors
			public SMAAPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9626
		{
			// Fields
			public static readonly int _Metrics; // 0x00
			public static readonly int _AreaTexture; // 0x04
			public static readonly int _SearchTexture; // 0x08
			public static readonly int _BlendTexture; // 0x0C
			public static readonly int _StencilRef; // 0x10
			public static readonly int _StencilMask; // 0x14
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB5190-0x0000000181FB52C0
		}
	
		public static class ShaderPass // TypeDefIndex: 9627
		{
			// Fields
			public const int k_EdgeDetection = 0; // Metadata: 0x0069EDAD
			public const int k_BlendWeightsCalculation = 1; // Metadata: 0x0069EDAE
			public const int k_NeighborhoodBlending = 2; // Metadata: 0x0069EDAF
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9628
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<SMAASetupPassData, RasterGraphContext> __9__12_0; // 0x08
			public static BaseRenderFunc<SMAAPassData, RasterGraphContext> __9__12_1; // 0x10
			public static BaseRenderFunc<SMAAPassData, RasterGraphContext> __9__12_2; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181FBEAB0-0x0000000181FBEB20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__12_0(SMAASetupPassData data, RasterGraphContext context); // 0x0000000181FBA170-0x0000000181FBA310
			internal void _RecordRenderGraph_b__12_1(SMAAPassData data, RasterGraphContext context); // 0x0000000181FBA310-0x0000000181FBA490
			internal void _RecordRenderGraph_b__12_2(SMAAPassData data, RasterGraphContext context); // 0x0000000181FBA490-0x0000000181FBA690
		}
	
		// Constructors
		public SmaaPostProcessPass(Shader shader, Texture2D smaaAreaTexture, Texture2D smaaSearchTexture); // 0x0000000181FB6BD0-0x0000000181FB6D60
	
		// Methods
		public override void Dispose(); // 0x0000000181FB5370-0x0000000181FB53D0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB53D0-0x0000000181FB6900
		private static void SetupMaterial(SMAASetupPassData data); // 0x0000000181FB6900-0x0000000181FB6BD0
	}
}
