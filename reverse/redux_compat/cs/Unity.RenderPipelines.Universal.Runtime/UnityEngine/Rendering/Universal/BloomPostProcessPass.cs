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
	internal sealed class BloomPostProcessPass : PostProcessPass // TypeDefIndex: 9577
	{
		// Fields
		public const int k_MaxPyramidSize = 16; // Metadata: 0x0069EC6B
		private static readonly ProfilingSampler k_ProfilingSamplerKawase; // 0x00
		private static readonly ProfilingSampler k_ProfilingSamplerDual; // 0x08
		private Material m_Material; // 0x68
		private Material[] m_MaterialPyramid; // 0x70
		private MaterialParams m_PrevParams; // 0x78
		private BloomMipPyramid m_MipPyramid; // 0xA0
		private bool m_IsValid; // 0xA8
		private const string k_PassNameKawase = "Blit Bloom Mipmaps (Kawase)"; // Metadata: 0x0069EC6C
		private const string k_PassNameDual = "Blit Bloom Mipmaps (Dual)"; // Metadata: 0x0069EC88
	
		// Properties
		public BloomMipPyramid mipPyramid { get; } // 0x00000001805B5990-0x00000001805B59A0 
	
		// Nested types
		private class BloomPassData // TypeDefIndex: 9578
		{
			// Fields
			internal Material material; // 0x10
			internal Material[] mipMaterials; // 0x18
			internal TextureHandle sourceTexture; // 0x20
			internal BloomMipPyramid mipPyramid; // 0x30
	
			// Constructors
			public BloomPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public class BloomMipPyramid // TypeDefIndex: 9579
		{
			// Fields
			private int m_MipCount; // 0x10
			private TextureHandle[] m_MipDownPyramidTextures; // 0x18
			private TextureHandle[] m_MipUpPyramidTextures; // 0x20
			private string[] m_MipDownPyramidNames; // 0x28
			private string[] m_MipUpPyramidNames; // 0x30
			private BloomFilterMode m_BloomFilterMode; // 0x38
			[CompilerGenerated]
			private TextureHandle _resultTexture_k__BackingField; // 0x3C
	
			// Properties
			public int mipCapacity { get; } // 0x00000001814EA450-0x00000001814EA470 
			public int mipCount { get; } // 0x00000001802E64B0-0x00000001802E64C0 
			public TextureHandle resultTexture { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181FA2B30-0x0000000181FA2B40 0x0000000181FA2B40-0x0000000181FA2B50
			internal TextureHandle[] mipDownTextures { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			internal TextureHandle[] mipUpTextures { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			internal BloomMipPyramid(int size = 16 /* Metadata: 0x0069ECA2 */); // 0x0000000181FA2960-0x0000000181FA2B30
	
			// Methods
			public TextureHandle GetResultMip(int index); // 0x0000000181FA2140-0x0000000181FA21D0
			internal void Update(RenderGraph renderGraph, Bloom bloom, [IsReadOnly] in TextureDesc bloomSourceDesc); // 0x0000000181FA21D0-0x0000000181FA2960
		}
	
		internal struct MaterialParams // TypeDefIndex: 9580
		{
			// Fields
			internal Vector4 parameters; // 0x00
			internal Vector4 parameters2; // 0x10
			internal BloomFilterMode bloomFilter; // 0x20
			internal bool highQualityFiltering; // 0x24
			internal bool enableAlphaOutput; // 0x25
	
			// Methods
			internal bool Equals(ref MaterialParams other); // 0x0000000181FABA30-0x0000000181FABB40
		}
	
		public static class ShaderConstants // TypeDefIndex: 9581
		{
			// Fields
			public static readonly int _Params; // 0x00
			public static readonly int _Params2; // 0x04
			public static readonly int _SourceTexLowMip; // 0x08
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB49E0-0x0000000181FB4A90
		}
	
		public static class ShaderPass // TypeDefIndex: 9582
		{
			// Fields
			public const int k_Prefilter = 0; // Metadata: 0x0069ECA3
			public const int k_BlurHorizontal = 1; // Metadata: 0x0069ECA4
			public const int k_BlurVertical = 2; // Metadata: 0x0069ECA5
			public const int k_Upsample = 3; // Metadata: 0x0069ECA6
			public const int k_Kawase = 4; // Metadata: 0x0069ECA7
			public const int k_DualDownsample = 5; // Metadata: 0x0069ECA8
			public const int k_DualUpsample = 6; // Metadata: 0x0069ECA9
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9583
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<BloomPassData, UnsafeGraphContext> __9__18_0; // 0x08
			public static BaseRenderFunc<BloomPassData, UnsafeGraphContext> __9__19_0; // 0x10
			public static BaseRenderFunc<BloomPassData, UnsafeGraphContext> __9__20_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181FBECE0-0x0000000181FBED50
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BloomGaussian_b__18_0(BloomPassData data, UnsafeGraphContext context); // 0x0000000181FB8490-0x0000000181FB8C50
			internal void _BloomKawase_b__19_0(BloomPassData data, UnsafeGraphContext context); // 0x0000000181FB8C50-0x0000000181FB90F0
			internal void _BloomDual_b__20_0(BloomPassData data, UnsafeGraphContext context); // 0x0000000181FB7E80-0x0000000181FB8490
		}
	
		// Constructors
		public BloomPostProcessPass(Shader shader); // 0x0000000181FA4FB0-0x0000000181FA51F0
		static BloomPostProcessPass(); // 0x0000000181FA4EF0-0x0000000181FA4FB0
	
		// Methods
		public override void Dispose(); // 0x0000000181FA4410-0x0000000181FA44C0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA44C0-0x0000000181FA4EF0
		public static Vector2Int CalcBloomResolution(Bloom bloom, [IsReadOnly] in TextureDesc bloomSourceDesc); // 0x0000000181FA4360-0x0000000181FA4410
		public static int CalcBloomMipCount(Bloom bloom, [IsReadOnly] in Vector2Int bloomResolution); // 0x0000000181FA4240-0x0000000181FA4360
		private TextureHandle BloomGaussian(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source); // 0x0000000181FA3830-0x0000000181FA3D90
		private TextureHandle BloomKawase(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source); // 0x0000000181FA3D90-0x0000000181FA4240
		private TextureHandle BloomDual(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source); // 0x0000000181FA3290-0x0000000181FA3830
	}
}
