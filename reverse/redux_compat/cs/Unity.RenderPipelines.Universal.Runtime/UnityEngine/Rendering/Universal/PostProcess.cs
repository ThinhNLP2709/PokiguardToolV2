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
	internal sealed class PostProcess : IDisposable // TypeDefIndex: 9683
	{
		// Fields
		private StopNanPostProcessPass m_StopNanPostProcessPass; // 0x10
		private SmaaPostProcessPass m_SmaaPostProcessPass; // 0x18
		private DepthOfFieldGaussianPostProcessPass m_DepthOfFieldGaussianPass; // 0x20
		private DepthOfFieldBokehPostProcessPass m_DepthOfFieldBokehPass; // 0x28
		private UpscalerPostProcessPass m_UpscalerPostProcessPass; // 0x30
		private StpPostProcessPass m_StpPostProcessPass; // 0x38
		private TemporalAntiAliasingPostProcessPass m_TemporalAntiAliasingPass; // 0x40
		private MotionBlurPostProcessPass m_MotionBlurPass; // 0x48
		private PaniniProjectionPostProcessPass m_PaniniProjectionPass; // 0x50
		private BloomPostProcessPass m_BloomPass; // 0x58
		private LensFlareScreenSpacePostProcessPass m_LensFlareScreenSpacePass; // 0x60
		private LensFlareDataDrivenPostProcessPass m_LensFlareDataDrivenPass; // 0x68
		private UberPostProcessPass m_UberPass; // 0x70
		private ScalingSetupPostProcessPass m_ScalingSetupFinalPostProcessPass; // 0x78
		private Fsr1UpscalePostProcessPass m_Fsr1UpscaleFinalPostProcessPass; // 0x80
		private FinalPostProcessPass m_FinalPostProcessPass; // 0x88
		private PostProcessData m_Resources; // 0x90
		private Texture2D[] m_FilmGrainTextures; // 0x98
		private int m_DitheringTextureIndex; // 0xA0
	
		// Constructors
		public PostProcess(PostProcessData postProcessResourceAssetData); // 0x0000000181FC71B0-0x0000000181FC7870
	
		// Methods
		public void Dispose(); // 0x0000000181FC63D0-0x0000000181FC65C0
		private static bool RequireSRGBConversionBlitToBackBuffer(UniversalCameraData cameraData, bool enableColorEncodingIfNeeded); // 0x0000000181FC7140-0x0000000181FC7170
		private int GetNextDitherIndex(); // 0x0000000181FC65C0-0x0000000181FC6610
		private Texture2D GetNextDitherTexture(); // 0x0000000181FC1360-0x0000000181FC13E0
		private static void UpdateGlobalDebugHandlerPass(RenderGraph renderGraph, UniversalCameraData cameraData, bool isFinalPass); // 0x0000000181FC7170-0x0000000181FC71B0
		public void RenderPostProcessing(RenderGraph renderGraph, ContextContainer frameData, bool hasFinalPass, bool enableColorEncodingIfNeeded); // 0x0000000181FC6AE0-0x0000000181FC7140
		public void RenderFinalPostProcessing(RenderGraph renderGraph, ContextContainer frameData, bool enableColorEncodingIfNeeded); // 0x0000000181FC6610-0x0000000181FC6AE0
	}
}
