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
	internal sealed class MotionBlurPostProcessPass : PostProcessPass // TypeDefIndex: 9609
	{
		// Fields
		public const string k_TargetName = "CameraColorMotionBlur"; // Metadata: 0x0069ED25
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
	
		// Nested types
		private class MotionBlurPassData // TypeDefIndex: 9610
		{
			// Fields
			internal Material material; // 0x10
			internal Camera camera; // 0x18
			internal TextureHandle sourceTexture; // 0x20
			internal int passIndex; // 0x30
			internal float intensity; // 0x34
			internal float clamp; // 0x38
			internal bool enableAlphaOutput; // 0x3C
			internal XRPass xr; // 0x40
	
			// Constructors
			public MotionBlurPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9611
		{
			// Fields
			public static readonly int _ViewProjM; // 0x00
			public static readonly int _PrevViewProjM; // 0x04
			public static readonly int _ViewProjMStereo; // 0x08
			public static readonly int _PrevViewProjMStereo; // 0x0C
			public static readonly int _Intensity; // 0x10
			public static readonly int _Clamp; // 0x14
			public static readonly int _SourceSize; // 0x18
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4880-0x0000000181FB49E0
		}
	
		public static class ShaderPass // TypeDefIndex: 9612
		{
			// Fields
			public const int k_CameraMotionBlurLow = 0; // Metadata: 0x0069ED3B
			public const int k_CameraMotionBlurMedium = 1; // Metadata: 0x0069ED3C
			public const int k_CameraMotionBlurHigh = 2; // Metadata: 0x0069ED3D
			public const int k_CameraAndObjectMotionBlurLow = 3; // Metadata: 0x0069ED3E
			public const int k_CameraAndObjectMotionBlurMedium = 4; // Metadata: 0x0069ED3F
			public const int k_CameraAndObjectMotionBlurHigh = 5; // Metadata: 0x0069ED40
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9613
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<MotionBlurPassData, RasterGraphContext> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEFF0-0x0000000181FBF060
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__6_0(MotionBlurPassData data, RasterGraphContext context); // 0x0000000181FBBBB0-0x0000000181FBBE60
		}
	
		// Constructors
		public MotionBlurPostProcessPass(Shader shader); // 0x0000000181FAC650-0x0000000181FAC730
	
		// Methods
		public override void Dispose(); // 0x0000000181FABB40-0x0000000181FABBA0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FABBA0-0x0000000181FAC380
		public static void UpdateMotionBlurMatrices(Material material, Camera camera, XRPass xr); // 0x0000000181FAC380-0x0000000181FAC650
	}
}
