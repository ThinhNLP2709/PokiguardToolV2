/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public static class TemporalAA // TypeDefIndex: 9790
	{
		// Fields
		internal static JitterFunc s_JitterFunc; // 0x00
		private static readonly Vector2[] taaFilterOffsets; // 0x08
		private static readonly float[] taaFilterWeights; // 0x10
		internal static readonly GraphicsFormat[] AccumulationFormatList; // 0x18
	
		// Nested types
		internal static class ShaderConstants // TypeDefIndex: 9791
		{
			// Fields
			public static readonly int _TaaAccumulationTex; // 0x00
			public static readonly int _TaaMotionVectorTex; // 0x04
			public static readonly int _TaaFilterWeights; // 0x08
			public static readonly int _TaaFrameInfluence; // 0x0C
			public static readonly int _TaaVarianceClampScale; // 0x10
			public static readonly int _CameraDepthTexture; // 0x14
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FE4F20-0x0000000181FE5050
		}
	
		internal static class ShaderKeywords // TypeDefIndex: 9792
		{
			// Fields
			public static readonly string TAA_LOW_PRECISION_SOURCE; // 0x00
	
			// Constructors
			static ShaderKeywords(); // 0x0000000181FE5050-0x0000000181FE50C0
		}
	
		[Serializable]
		public struct Settings // TypeDefIndex: 9793
		{
			// Fields
			[FormerlySerializedAs("quality")]
			[SerializeField]
			internal TemporalAAQuality m_Quality; // 0x00
			[FormerlySerializedAs("frameInfluence")]
			[SerializeField]
			internal float m_FrameInfluence; // 0x04
			[FormerlySerializedAs("jitterScale")]
			[SerializeField]
			internal float m_JitterScale; // 0x08
			[FormerlySerializedAs("mipBias")]
			[SerializeField]
			internal float m_MipBias; // 0x0C
			[FormerlySerializedAs("varianceClampScale")]
			[SerializeField]
			internal float m_VarianceClampScale; // 0x10
			[FormerlySerializedAs("contrastAdaptiveSharpening")]
			[SerializeField]
			internal float m_ContrastAdaptiveSharpening; // 0x14
			[NonSerialized]
			internal int resetHistoryFrames; // 0x18
			[NonSerialized]
			internal int jitterFrameCountOffset; // 0x1C
	
			// Properties
			public TemporalAAQuality quality { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000181FE4B50-0x0000000181FE4B70
			public float baseBlendFactor { get; set; } // 0x0000000181FE4AB0-0x0000000181FE4AC0 0x0000000181FE4AC0-0x0000000181FE4AF0
			public float jitterScale { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181FE4B10-0x0000000181FE4B30
			public float mipBias { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181FE4B30-0x0000000181FE4B50
			public float varianceClampScale { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x0000000181FE4B70-0x0000000181FE4B90
			public float contrastAdaptiveSharpening { get; set; } // 0x0000000181120AA0-0x0000000181120AB0 0x0000000181FE4AF0-0x0000000181FE4B10
	
			// Methods
			public static Settings Create(); // 0x0000000181FE4A80-0x0000000181FE4AB0
		}
	
		internal delegate void JitterFunc(int frameIndex, out Vector2 jitter, out bool allowScaling); // TypeDefIndex: 9794; 0x0000000180A72B30-0x0000000180A72B50
	
		private class TaaPassData // TypeDefIndex: 9795
		{
			// Fields
			internal TextureHandle dstTex; // 0x10
			internal TextureHandle srcColorTex; // 0x20
			internal TextureHandle srcDepthTex; // 0x30
			internal TextureHandle srcMotionVectorTex; // 0x40
			internal TextureHandle srcTaaAccumTex; // 0x50
			internal Material material; // 0x60
			internal int passIndex; // 0x68
			internal float taaFrameInfluence; // 0x6C
			internal float taaVarianceClampScale; // 0x70
			internal float[] taaFilterWeights; // 0x78
			internal bool taaLowPrecisionSource; // 0x80
			internal bool taaAlphaOutput; // 0x81
	
			// Constructors
			public TaaPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9796
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<TaaPassData, RasterGraphContext> __9__16_0; // 0x08
			public static BaseRenderFunc<TaaPassData, RasterGraphContext> __9__16_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181FF4310-0x0000000181FF4380
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__16_0(TaaPassData data, RasterGraphContext context); // 0x0000000181FF3EA0-0x0000000181FF41D0
			internal void _Render_b__16_1(TaaPassData data, RasterGraphContext context); // 0x0000000181FF41D0-0x0000000181FF42F0
		}
	
		// Constructors
		static TemporalAA(); // 0x0000000181FEC5D0-0x0000000181FEC8C0
	
		// Methods
		internal static int CalculateTaaFrameIndex(ref Settings settings); // 0x0000000181FEB4B0-0x0000000181FEB4D0
		internal static Matrix4x4 CalculateJitterMatrix(UniversalCameraData cameraData, JitterFunc jitterFunc); // 0x0000000181FEB190-0x0000000181FEB360
		internal static Matrix4x4 CalculateJitterMatrix(UniversalCameraData cameraData, Vector2 subpixelJitter); // 0x0000000181FEB360-0x0000000181FEB430
		internal static void CalculateJitter(int frameIndex, out Vector2 jitter, out bool allowScaling); // 0x0000000181FEB430-0x0000000181FEB4B0
		internal static float[] CalculateFilterWeights(ref Settings settings); // 0x0000000181FEAF70-0x0000000181FEB190
		internal static RenderTextureDescriptor TemporalAADescFromCameraDesc(ref RenderTextureDescriptor cameraDesc); // 0x0000000181FEC120-0x0000000181FEC360
		internal static string ValidateAndWarn(UniversalCameraData cameraData, ref uint warnCounter, bool isSTPRequested = false /* Metadata: 0x0069F0DC */); // 0x0000000181FEC360-0x0000000181FEC5D0
		internal static void Render(RenderGraph renderGraph, Material taaMaterial, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle srcColor, [IsReadOnly] in TextureHandle srcDepth, [IsReadOnly] in TextureHandle srcMotionVectors, [IsReadOnly] in TextureHandle dstColor); // 0x0000000181FEB4D0-0x0000000181FEC120
	}
}
