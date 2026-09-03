/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class Vrs // TypeDefIndex: 5856
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static readonly int shadingRateFragmentSizeCount; // 0x00
		[NoAutoStaticsCleanup]
		private static VrsResources s_VrsResources; // 0x08
	
		// Nested types
		private class ConversionPassData // TypeDefIndex: 5857
		{
			// Fields
			public TextureHandle sriTextureHandle; // 0x10
			public TextureHandle mainTexHandle; // 0x20
			public TextureDimension mainTexDimension; // 0x30
			public BufferHandle mainTexLutHandle; // 0x34
			public BufferHandle validatedShadingRateFragmentSizeHandle; // 0x40
			public ComputeShader computeShader; // 0x50
			public int kernelIndex; // 0x58
			public Vector4 scaleBias; // 0x5C
			public Vector2Int dispatchSize; // 0x6C
			public bool yFlip; // 0x74
	
			// Constructors
			public ConversionPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class VisualizationPassData // TypeDefIndex: 5858
		{
			// Fields
			public Material material; // 0x10
			public TextureHandle source; // 0x18
			public BufferHandle lut; // 0x28
			public TextureHandle dummy; // 0x34
			public Vector4 visualizationParams; // 0x44
	
			// Constructors
			public VisualizationPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5859
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<ConversionPassData, ComputeGraphContext> __9__10_0; // 0x08
			public static BaseRenderFunc<VisualizationPassData, RasterGraphContext> __9__11_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181ECE6C0-0x0000000181ECE730
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ColorMaskTextureToShadingRateImage_b__10_0(ConversionPassData innerPassData, ComputeGraphContext context); // 0x0000000181ECE1E0-0x0000000181ECE250
			internal void _ShadingRateImageToColorMaskTexture_b__11_0(VisualizationPassData innerPassData, RasterGraphContext context); // 0x0000000181ECE2A0-0x0000000181ECE4A0
		}
	
		// Constructors
		static Vrs(); // 0x0000000181ED5240-0x0000000181ED52D0
	
		// Methods
		[OnCodeInitializing]
		private static void ResetStaticsOnLoad(); // 0x0000000181ED4670-0x0000000181ED4740
		public static bool IsColorMaskTextureConversionSupported(); // 0x0000000181ED4540-0x0000000181ED45A0
		public static bool IsInitialized(); // 0x0000000181ED45A0-0x0000000181ED4670
		public static void InitializeResources(); // 0x0000000181ED4380-0x0000000181ED4540
		public static void DisposeResources(); // 0x0000000181ED42F0-0x0000000181ED4380
		public static TextureHandle ColorMaskTextureToShadingRateImage(RenderGraph renderGraph, RTHandle sriRtHandle, RTHandle colorMaskRtHandle, bool yFlip); // 0x0000000181ED3D00-0x0000000181ED3FE0
		public static TextureHandle ColorMaskTextureToShadingRateImage(RenderGraph renderGraph, TextureHandle sriTextureHandle, TextureHandle colorMaskHandle, TextureDimension colorMaskDimension, bool yFlip); // 0x0000000181ED3480-0x0000000181ED3D00
		public static void ShadingRateImageToColorMaskTexture(RenderGraph renderGraph, [IsReadOnly] in TextureHandle sriTextureHandle, [IsReadOnly] in TextureHandle colorMaskHandle); // 0x0000000181ED4A60-0x0000000181ED5150
		private static void ConversionDispatch(ComputeCommandBuffer cmd, ConversionPassData conversionPassData); // 0x0000000181ED3FE0-0x0000000181ED42F0
		public static void ColorMaskTextureToShadingRateImageDispatch(CommandBuffer cmd, RTHandle sriDestination, Texture colorMaskSource, bool yFlip = true /* Metadata: 0x00661B74 */); // 0x0000000181ED2EF0-0x0000000181ED3480
		public static void ShadingRateImageToColorMaskTextureBlit(CommandBuffer cmd, RTHandle sriSource, RTHandle colorMaskDestination); // 0x0000000181ED4740-0x0000000181ED4A60
		[CompilerGenerated]
		internal static void UnityEngine_Rendering_Vrs_ResetStaticsOnLoad_RegisterLifecycleMethod(); // 0x0000000181ED5150-0x0000000181ED5240
	}
}
