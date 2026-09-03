/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class RenderingLayerUtils // TypeDefIndex: 9763
	{
		// Nested types
		public enum Event // TypeDefIndex: 9764
		{
			DepthNormalPrePass = 0,
			Opaque = 1
		}
	
		public enum MaskSize // TypeDefIndex: 9765
		{
			Bits8 = 0,
			Bits16 = 1,
			Bits24 = 2,
			Bits32 = 3
		}
	
		// Methods
		public static void CombineRendererEvents(bool isDeferred, int msaaSampleCount, Event rendererEvent, ref Event combinedEvent); // 0x0000000181FDC170-0x0000000181FDC190
		public static bool RequireRenderingLayers(UniversalRenderer universalRenderer, List<ScriptableRendererFeature> rendererFeatures, int msaaSampleCount, out Event combinedEvent, out MaskSize combinedMaskSize); // 0x0000000181FDC300-0x0000000181FDC390
		internal static bool RequireRenderingLayers(List<ScriptableRendererFeature> rendererFeatures, RenderingMode renderingMode, bool accurateGbufferNormals, int msaaSampleCount, out Event combinedEvent, out MaskSize combinedMaskSize); // 0x0000000181FDC390-0x0000000181FDC670
		public static void SetupProperties(CommandBuffer cmd, MaskSize maskSize); // 0x0000000181FDC750-0x0000000181FDC870
		internal static void SetupProperties(RasterCommandBuffer cmd, MaskSize maskSize); // 0x0000000181FDC670-0x0000000181FDC750
		public static GraphicsFormat GetFormat(MaskSize maskSize); // 0x0000000181FDC240-0x0000000181FDC2C0
		public static uint ToValidRenderingLayers(uint renderingLayers); // 0x0000000181FDC870-0x0000000181FDC940
		internal static MaskSize GetMaskSize(int bits); // 0x0000000181FDC2C0-0x0000000181FDC300
		private static int GetBits(MaskSize maskSize); // 0x0000000181FDC1B0-0x0000000181FDC240
		private static Event Combine(Event a, Event b); // 0x0000000181FDC190-0x0000000181FDC1A0
		private static MaskSize Combine(MaskSize a, MaskSize b); // 0x0000000181FDC1A0-0x0000000181FDC1B0
	}
}
