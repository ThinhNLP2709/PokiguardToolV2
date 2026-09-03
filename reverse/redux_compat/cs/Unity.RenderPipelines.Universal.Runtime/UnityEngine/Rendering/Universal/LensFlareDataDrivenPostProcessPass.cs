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
	internal sealed class LensFlareDataDrivenPostProcessPass : PostProcessPass // TypeDefIndex: 9603
	{
		// Fields
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private const string k_passNameOcclusion = "Blit Lens Flare Occlusion"; // Metadata: 0x0069ED0B
	
		// Nested types
		private class LensFlarePassData // TypeDefIndex: 9604
		{
			// Fields
			internal TextureHandle destinationTexture; // 0x10
			internal UniversalCameraData cameraData; // 0x20
			internal Material material; // 0x28
			internal Rect viewport; // 0x30
			internal float paniniDistance; // 0x40
			internal float paniniCropToFit; // 0x44
			internal float width; // 0x48
			internal float height; // 0x4C
			internal bool usePanini; // 0x50
	
			// Constructors
			public LensFlarePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9605
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<LensFlarePassData, UnsafeGraphContext> __9__7_0; // 0x08
			public static Func<Light, Camera, Vector3, float> __9__8_1; // 0x10
			public static Func<Light, Camera, Vector3, float> __9__8_2; // 0x18
			public static BaseRenderFunc<LensFlarePassData, UnsafeGraphContext> __9__8_0; // 0x20
	
			// Constructors
			static __c(); // 0x0000000181FBEC00-0x0000000181FBEC70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LensFlareDataDrivenComputeOcclusion_b__7_0(LensFlarePassData data, UnsafeGraphContext ctx); // 0x0000000181FB90F0-0x0000000181FB97F0
			internal void _RenderLensFlareDataDriven_b__8_0(LensFlarePassData data, UnsafeGraphContext ctx); // 0x0000000181FBDB80-0x0000000181FBE410
			internal float _RenderLensFlareDataDriven_b__8_1(Light light, Camera cam, Vector3 wo); // 0x0000000181FBE410-0x0000000181FBE450
			internal float _RenderLensFlareDataDriven_b__8_2(Light light, Camera cam, Vector3 wo); // 0x0000000181FBE410-0x0000000181FBE450
		}
	
		// Constructors
		public LensFlareDataDrivenPostProcessPass(Shader shader); // 0x0000000181FAA750-0x0000000181FAA830
	
		// Methods
		public override void Dispose(); // 0x0000000181FA9570-0x0000000181FA95D0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA9E20-0x0000000181FAA0C0
		private void LensFlareDataDrivenComputeOcclusion(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, [IsReadOnly] in TextureDesc dstDesc, PaniniProjection paniniProjection); // 0x0000000181FA9810-0x0000000181FA9E20
		private void RenderLensFlareDataDriven(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle destination, [IsReadOnly] in TextureDesc srcDesc, PaniniProjection paniniProjection); // 0x0000000181FAA0C0-0x0000000181FAA750
		public static float GetLensFlareLightAttenuation(Light light, Camera cam, Vector3 wo); // 0x0000000181FA95D0-0x0000000181FA9810
	}
}
