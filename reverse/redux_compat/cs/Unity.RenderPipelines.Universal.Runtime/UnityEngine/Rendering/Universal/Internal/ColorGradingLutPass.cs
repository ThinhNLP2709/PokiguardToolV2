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

namespace UnityEngine.Rendering.Universal.Internal
{
	public class ColorGradingLutPass : ScriptableRenderPass // TypeDefIndex: 9899
	{
		// Fields
		private const string k_InternalColorLutName = "_InternalColorGradingLut"; // Metadata: 0x0069FD64
		private readonly Material m_LutBuilderLdr; // 0x60
		private readonly Material m_LutBuilderHdr; // 0x68
		internal readonly GraphicsFormat m_HdrLutFormat; // 0x70
		internal readonly GraphicsFormat m_LdrLutFormat; // 0x74
		private bool m_AllowColorGradingACESHDR; // 0x78
	
		// Nested types
		private class PassData // TypeDefIndex: 9900
		{
			// Fields
			internal UniversalCameraData cameraData; // 0x10
			internal Material lutBuilderLdr; // 0x18
			internal Material lutBuilderHdr; // 0x20
			internal TextureHandle internalColorLut; // 0x28
			internal int lutSize; // 0x38
			internal bool hdrGrading; // 0x3C
			internal bool allowColorGradingACESHDR; // 0x3D
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private static class ShaderConstants // TypeDefIndex: 9901
		{
			// Fields
			public static readonly int _Lut_Params; // 0x00
			public static readonly int _ColorBalance; // 0x04
			public static readonly int _ColorFilter; // 0x08
			public static readonly int _ChannelMixerRed; // 0x0C
			public static readonly int _ChannelMixerGreen; // 0x10
			public static readonly int _ChannelMixerBlue; // 0x14
			public static readonly int _HueSatCon; // 0x18
			public static readonly int _Lift; // 0x1C
			public static readonly int _Gamma; // 0x20
			public static readonly int _Gain; // 0x24
			public static readonly int _Shadows; // 0x28
			public static readonly int _Midtones; // 0x2C
			public static readonly int _Highlights; // 0x30
			public static readonly int _ShaHiLimits; // 0x34
			public static readonly int _SplitShadows; // 0x38
			public static readonly int _SplitHighlights; // 0x3C
			public static readonly int _CurveMaster; // 0x40
			public static readonly int _CurveRed; // 0x44
			public static readonly int _CurveGreen; // 0x48
			public static readonly int _CurveBlue; // 0x4C
			public static readonly int _CurveHueVsHue; // 0x50
			public static readonly int _CurveHueVsSat; // 0x54
			public static readonly int _CurveLumVsSat; // 0x58
			public static readonly int _CurveSatVsSat; // 0x5C
	
			// Constructors
			static ShaderConstants(); // 0x000000018203FB70-0x000000018203FFA0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9902
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__12_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041890-0x0000000182041900
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__12_0(PassData data, RasterGraphContext context); // 0x0000000182040760-0x00000001820407F0
		}
	
		// Constructors
		public ColorGradingLutPass(RenderPassEvent evt, PostProcessData data); // 0x0000000182022690-0x0000000182022850
	
		// Methods
		public void Setup([IsReadOnly] in RTHandle internalLut); // 0x00000001802E76C0-0x00000001802E76D0
		public void ConfigureDescriptor([IsReadOnly] in PostProcessingData postProcessingData, out RenderTextureDescriptor descriptor, out FilterMode filterMode); // 0x0000000182020950-0x0000000182020A20
		public void ConfigureDescriptor([IsReadOnly] in UniversalPostProcessingData postProcessingData, out RenderTextureDescriptor descriptor, out FilterMode filterMode); // 0x00000001820208A0-0x0000000182020950
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle internalLutTarget); // 0x0000000182020A20-0x0000000182022000
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, out TextureHandle internalColorLut); // 0x00000001820220B0-0x0000000182022690
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000182022000-0x00000001820220B0
		public void Cleanup(); // 0x0000000182020830-0x00000001820208A0
	}
}
