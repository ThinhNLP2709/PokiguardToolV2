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
	public static class PostProcessUtils // TypeDefIndex: 9684
	{
		// Nested types
		private static class ShaderConstants // TypeDefIndex: 9685
		{
			// Fields
			public static readonly int _Grain_Texture; // 0x00
			public static readonly int _Grain_Params; // 0x04
			public static readonly int _Grain_TilingParams; // 0x08
			public static readonly int _BlueNoise_Texture; // 0x0C
			public static readonly int _Dithering_Params; // 0x10
			public static readonly int _Quad_View_Uv_Remap_scalesXR; // 0x14
			public static readonly int _Quad_View_Uv_Remap_offsetsXR; // 0x18
			public static readonly int _SourceSize; // 0x1C
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FD3F90-0x0000000181FD4110
		}
	
		// Methods
		internal static Material LoadShader(Shader shader, string passName = "" /* Metadata: 0x0069EE95 */, LogType logLevel = LogType.Warning /* Metadata: 0x0069EE96 */); // 0x0000000181FC5400-0x0000000181FC5720
		internal static TextureHandle CreateCompatibleTexture(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source, string name, bool clear, FilterMode filterMode); // 0x0000000181FC5180-0x0000000181FC52E0
		internal static TextureHandle CreateCompatibleTexture(RenderGraph renderGraph, [IsReadOnly] in TextureDesc desc, string name, bool clear, FilterMode filterMode); // 0x0000000181FC5070-0x0000000181FC5180
		internal static TextureDesc GetCompatibleDescriptor(TextureDesc desc, int width, int height, GraphicsFormat format); // 0x0000000181FC5340-0x0000000181FC53B0
		internal static TextureDesc GetCompatibleDescriptor(TextureDesc desc); // 0x0000000181FC52E0-0x0000000181FC5340
		internal static void MakeCompatible(ref TextureDesc desc); // 0x0000000181FC5720-0x0000000181FC5740
		[Obsolete("This method is obsolete. Use ConfigureDithering override that takes camera pixel width and height instead. #from(2021.1)")]
		public static int ConfigureDithering(PostProcessData data, int index, Camera camera, Material material); // 0x0000000181FC4940-0x0000000181FC4AC0
		public static int ConfigureDithering(PostProcessData data, int index, int cameraPixelWidth, int cameraPixelHeight, Material material); // 0x0000000181FC47F0-0x0000000181FC4940
		[Obsolete("This method is obsolete. Film Grain shader parameters are configured internally by the render passes. #from(2021.1)")]
		public static void ConfigureFilmGrain(PostProcessData data, FilmGrain settings, Camera camera, Material material); // 0x0000000181FC4FE0-0x0000000181FC5070
		[Obsolete("This method is obsolete. Film Grain shader parameters are configured internally by the render passes. #from(6000.6)")]
		public static void ConfigureFilmGrain(PostProcessData data, FilmGrain settings, int cameraPixelWidth, int cameraPixelHeight, Material material); // 0x0000000181FC4BD0-0x0000000181FC4FE0
		internal static Vector2 GetRandomOffset2D(); // 0x0000000181F55CB0-0x0000000181F55D30
		internal static Vector4 CalcNoiseTextureTilingParams(Texture noiseTexture, int cameraPixelWidth, int cameraPixelHeight, Vector2 offset); // 0x0000000181FC44E0-0x0000000181FC4600
		internal static void ConfigureDitheringMaterial(Material material, Texture noiseTexture, Vector4 tilingParams); // 0x0000000181FC4740-0x0000000181FC47F0
		internal static void ConfigureFilmGrainMaterial(Material material, Texture grainTexture, Vector2 grainParams, Vector4 tilingParams); // 0x0000000181FC4AC0-0x0000000181FC4BD0
		internal static bool IsFxaaEnabled(UniversalCameraData cameraData); // 0x0000000181FC53E0-0x0000000181FC5400
		internal static bool IsFsrEnabled(UniversalCameraData cameraData); // 0x0000000181FC53B0-0x0000000181FC53E0
		internal static bool RequireHDROutput(UniversalCameraData cameraData); // 0x0000000181FC5740-0x0000000181FC5780
		internal static void SetupHDROutput(Material material, HDROutputUtils.HDRDisplayInformation hdrDisplayInformation, ColorGamut hdrDisplayColorGamut, Tonemapping tonemapping, HDROutputUtils.Operation hdrOperations, bool rendersOverlayUI); // 0x0000000181FC61B0-0x0000000181FC6310
		internal static void SetupXRUVRemapping(Material material, XRPass xrPass); // 0x0000000181FC6310-0x0000000181FC63D0
		internal static Vector4 CalcShaderSourceSize(float width, float height, RenderTexture rt); // 0x0000000181FC4670-0x0000000181FC4740
		internal static Vector4 CalcShaderSourceSize(float width, float height, bool useDynamicScale); // 0x0000000181FC4600-0x0000000181FC4670
		internal static Vector4 CalcShaderSourceSize(RTHandle source); // 0x0000000181FA12D0-0x0000000181FA16D0
		internal static void SetGlobalShaderSourceSize(RasterCommandBuffer cmd, float width, float height, RenderTexture rt); // 0x0000000181FC5F90-0x0000000181FC60E0
		internal static void SetGlobalShaderSourceSize(RasterCommandBuffer cmd, float width, float height, bool useDynamicScale); // 0x0000000181FC5E00-0x0000000181FC5F00
		internal static void SetGlobalShaderSourceSize(CommandBuffer cmd, float width, float height, RenderTexture rt); // 0x0000000181FC5D70-0x0000000181FC5E00
		internal static void SetGlobalShaderSourceSize(RasterCommandBuffer cmd, RTHandle source); // 0x0000000181FC5F00-0x0000000181FC5F90
		internal static void SetGlobalShaderSourceSize(CommandBuffer cmd, RTHandle source); // 0x0000000181FC60E0-0x0000000181FC61B0
		internal static void ScaleViewport(RasterCommandBuffer cmd, RTHandle dest, UniversalCameraData cameraData, bool isActiveTargetBackBuffer); // 0x0000000181FC5B80-0x0000000181FC5D70
		internal static void ScaleViewportAndBlit(RasterGraphContext context, [IsReadOnly] in TextureHandle sourceTexture, [IsReadOnly] in TextureHandle destTexture, UniversalCameraData cameraData, Material material, bool isActiveTargetBackBuffer); // 0x0000000181FC5780-0x0000000181FC58E0
		internal static void ScaleViewportAndDrawVisibilityMesh(RasterGraphContext context, [IsReadOnly] in TextureHandle sourceTexture, [IsReadOnly] in TextureHandle destTexture, UniversalCameraData cameraData, Material material, bool isActiveTargetBackBuffer); // 0x0000000181FC58E0-0x0000000181FC5B80
	}
}
