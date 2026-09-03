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
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

public class OnTilePostProcessPass : ScriptableRenderPass // TypeDefIndex: 9292
{
	// Fields
	internal readonly bool k_SupportsMultisampleShaderResolve; // 0x60
	internal bool m_UseTextureReadFallback; // 0x61
	private RTHandle m_UserLut; // 0x68
	private Material m_OnTileUberMaterial; // 0x70
	private static readonly int s_BlitScaleBias; // 0x00
	private static readonly int s_BlitTexture; // 0x04
	private int m_DitheringTextureIndex; // 0x78
	private PostProcessData m_PostProcessData; // 0x80
	private Texture2D[] m_FilmGrainTextures; // 0x88
	private static Vector4 s_CachedPeripheralVignetteCenter; // 0x08
	private const string m_PassName = "On Tile Post Processing"; // Metadata: 0x0069E8FA
	private const string m_FallbackPassName = "On Tile Post Processing (sampling fallback) "; // Metadata: 0x0069E912
	private int m_PassOnTile; // 0x90
	private int m_PassOnTileMsaa; // 0x94
	private int m_PassTextureSample; // 0x98
	private int m_PassOnTileVis; // 0x9C
	private int m_PassOnTileMsaaVis; // 0xA0
	private int m_PassTexureSampleVis; // 0xA4

	// Nested types
	private class PassData // TypeDefIndex: 9293
	{
		// Fields
		internal TextureHandle source; // 0x10
		internal TextureHandle destination; // 0x20
		internal TextureHandle lutTexture; // 0x30
		internal TextureHandle userLutTexture; // 0x40
		internal Material material; // 0x50
		internal int shaderPass; // 0x58
		internal Vector4 scaleBias; // 0x5C
		internal bool useXRVisibilityMesh; // 0x6C
		internal XRPass xr; // 0x70
		internal int msaaSamples; // 0x78
		internal bool useTextureReadFallback; // 0x7C

		// Constructors
		public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	private static class ShaderConstants // TypeDefIndex: 9294
	{
		// Fields
		public static readonly int _Vignette_Params1; // 0x00
		public static readonly int _Vignette_Params2; // 0x04
		public static readonly int _Vignette_ParamsXR; // 0x08
		public static readonly int _Lut_Params; // 0x0C
		public static readonly int _UserLut_Params; // 0x10
		public static readonly int _InternalLut; // 0x14
		public static readonly int _UserLut; // 0x18

		// Constructors
		static ShaderConstants(); // 0x0000000181F5F360-0x0000000181F5F4C0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 9295
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static BaseRenderFunc<PassData, RasterGraphContext> __9__21_0; // 0x08

		// Constructors
		static __c(); // 0x0000000181F62360-0x0000000181F623D0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RecordRenderGraph_b__21_0(PassData data, RasterGraphContext context); // 0x0000000181F60B80-0x0000000181F60BF0
	}

	// Constructors
	internal OnTilePostProcessPass(PostProcessData postProcessData); // 0x0000000181F5C680-0x0000000181F5C760
	static OnTilePostProcessPass(); // 0x0000000181F5C5E0-0x0000000181F5C680

	// Methods
	internal void Setup(ref Material onTileUberMaterial); // 0x0000000181F5C220-0x0000000181F5C3C0
	public void Dispose(); // 0x0000000181F59E80-0x0000000181F59EE0
	public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F5A310-0x0000000181F5B4A0
	private static void ExecuteFBFetchPass(PassData data, RasterGraphContext context); // 0x0000000181F59EE0-0x0000000181F5A310
	private TextureHandle TryGetCachedUserLutTextureHandle(ColorLookup colorLookup, RenderGraph renderGraph); // 0x0000000181F5C3C0-0x0000000181F5C5E0
	private void SetupLut(Material material, ColorLookup colorLookup, ColorAdjustments colorAdjustments, int lutSize); // 0x0000000181F5B9D0-0x0000000181F5BD20
	private void SetupVignette(Material material, XRPass xrPass, int width, int height, Vignette vignette); // 0x0000000181F5BE70-0x0000000181F5C220
	private void SetupTonemapping(Material onTileUberMaterial, Tonemapping tonemapping, bool isHdrGrading); // 0x0000000181F5BD20-0x0000000181F5BE70
	private void SetupGrain(Material onTileUberMaterial, UniversalCameraData cameraData, FilmGrain filmgrain, Texture2D[] filmGrainTextures); // 0x0000000181F5B580-0x0000000181F5B9D0
	private void SetupDithering(Material onTileUberMaterial, UniversalCameraData cameraData, PostProcessData data); // 0x0000000181F5B4A0-0x0000000181F5B580
}

