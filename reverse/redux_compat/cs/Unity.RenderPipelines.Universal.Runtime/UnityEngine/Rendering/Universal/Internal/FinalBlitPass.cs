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
	public class FinalBlitPass : ScriptableRenderPass // TypeDefIndex: 9925
	{
		// Fields
		private BlitMaterialData[] m_BlitMaterialData; // 0x60
	
		// Nested types
		private static class BlitPassNames // TypeDefIndex: 9926
		{
			// Fields
			public const string NearestSampler = "NearestDebugDraw"; // Metadata: 0x0069FD9E
			public const string BilinearSampler = "BilinearDebugDraw"; // Metadata: 0x0069FDAF
		}
	
		private enum BlitType // TypeDefIndex: 9927
		{
			Core = 0,
			HDR = 1,
			Count = 2
		}
	
		private struct BlitMaterialData // TypeDefIndex: 9928
		{
			// Fields
			public Material material; // 0x00
			public int nearestSamplerPass; // 0x08
			public int bilinearSamplerPass; // 0x0C
		}
	
		private class PassData // TypeDefIndex: 9929
		{
			// Fields
			internal TextureHandle source; // 0x10
			internal TextureHandle destination; // 0x20
			internal int sourceID; // 0x30
			internal Vector4 hdrOutputLuminanceParams; // 0x34
			internal bool requireSrgbConversion; // 0x44
			internal bool enableAlphaOutput; // 0x45
			internal BlitMaterialData blitMaterialData; // 0x48
			internal UniversalCameraData cameraData; // 0x58
			internal bool useFullScreenViewport; // 0x60
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9930
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__12_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041900-0x0000000182041970
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__12_0(PassData data, RasterGraphContext context); // 0x00000001820402A0-0x0000000182040760
		}
	
		// Constructors
		public FinalBlitPass(RenderPassEvent evt, Material blitMaterial, Material blitHDRMaterial); // 0x000000018203A0E0-0x000000018203A2B0
	
		// Methods
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("Use RTHandles for colorHandle. #from(2022.1) #breakingFrom(2023.1)", true)]
		public void Setup(RenderTextureDescriptor baseDescriptor, RenderTargetHandle colorHandle); // 0x000000018203A090-0x000000018203A0E0
		public void Setup(RenderTextureDescriptor baseDescriptor, RTHandle colorHandle); // 0x00000001802E76C0-0x00000001802E76D0
		private static void SetupHDROutput(ColorGamut hdrDisplayColorGamut, Material material, HDROutputUtils.Operation hdrOperation, Vector4 hdrOutputParameters, bool rendersOverlayUI); // 0x0000000182039F90-0x000000018203A090
		private static void ExecutePass(RasterCommandBuffer cmd, PassData data, RTHandle source, RTHandle destination, UniversalCameraData cameraData, Vector4 scaleBias); // 0x0000000182039100-0x0000000182039470
		private void InitPassData(UniversalCameraData cameraData, ref PassData passData, BlitType blitType, bool enableAlphaOutput, bool useFullScreenViewport); // 0x0000000182039470-0x0000000182039540
		internal void Render(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalResourceData resourceData, TextureHandle sourceTexture, bool useFullScreenViewport = false /* Metadata: 0x0069FD9D */); // 0x0000000182039620-0x0000000182039F90
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000182039540-0x0000000182039620
	}
}
