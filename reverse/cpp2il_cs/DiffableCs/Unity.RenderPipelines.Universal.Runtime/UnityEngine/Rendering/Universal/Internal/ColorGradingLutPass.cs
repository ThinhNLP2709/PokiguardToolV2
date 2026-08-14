namespace UnityEngine.Rendering.Universal.Internal;

public class ColorGradingLutPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__14_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__14_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal UniversalCameraData cameraData; //Field offset: 0x10
		internal UniversalPostProcessingData postProcessingData; //Field offset: 0x18
		internal Material lutBuilderLdr; //Field offset: 0x20
		internal Material lutBuilderHdr; //Field offset: 0x28
		internal bool allowColorGradingACESHDR; //Field offset: 0x30
		internal TextureHandle internalLut; //Field offset: 0x34

		public PassData() { }

	}

	private static class ShaderConstants
	{
		public static readonly int _Lut_Params; //Field offset: 0x0
		public static readonly int _ColorBalance; //Field offset: 0x4
		public static readonly int _ColorFilter; //Field offset: 0x8
		public static readonly int _ChannelMixerRed; //Field offset: 0xC
		public static readonly int _ChannelMixerGreen; //Field offset: 0x10
		public static readonly int _ChannelMixerBlue; //Field offset: 0x14
		public static readonly int _HueSatCon; //Field offset: 0x18
		public static readonly int _Lift; //Field offset: 0x1C
		public static readonly int _Gamma; //Field offset: 0x20
		public static readonly int _Gain; //Field offset: 0x24
		public static readonly int _Shadows; //Field offset: 0x28
		public static readonly int _Midtones; //Field offset: 0x2C
		public static readonly int _Highlights; //Field offset: 0x30
		public static readonly int _ShaHiLimits; //Field offset: 0x34
		public static readonly int _SplitShadows; //Field offset: 0x38
		public static readonly int _SplitHighlights; //Field offset: 0x3C
		public static readonly int _CurveMaster; //Field offset: 0x40
		public static readonly int _CurveRed; //Field offset: 0x44
		public static readonly int _CurveGreen; //Field offset: 0x48
		public static readonly int _CurveBlue; //Field offset: 0x4C
		public static readonly int _CurveHueVsHue; //Field offset: 0x50
		public static readonly int _CurveHueVsSat; //Field offset: 0x54
		public static readonly int _CurveLumVsSat; //Field offset: 0x58
		public static readonly int _CurveSatVsSat; //Field offset: 0x5C

		private static ShaderConstants() { }

	}

	private readonly Material m_LutBuilderLdr; //Field offset: 0xB8
	private readonly Material m_LutBuilderHdr; //Field offset: 0xC0
	internal readonly GraphicsFormat m_HdrLutFormat; //Field offset: 0xC8
	internal readonly GraphicsFormat m_LdrLutFormat; //Field offset: 0xCC
	private PassData m_PassData; //Field offset: 0xD0
	private RTHandle m_InternalLut; //Field offset: 0xD8
	private bool m_AllowColorGradingACESHDR; //Field offset: 0xE0

	public ColorGradingLutPass(RenderPassEvent evt, PostProcessData data) { }

	[CompilerGenerated]
	internal static Material <.ctor>g__Load|7_0(Shader shader) { }

	public void Cleanup() { }

	public void ConfigureDescriptor(in PostProcessingData postProcessingData, out RenderTextureDescriptor descriptor, out FilterMode filterMode) { }

	public void ConfigureDescriptor(in UniversalPostProcessingData postProcessingData, out RenderTextureDescriptor descriptor, out FilterMode filterMode) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle internalLutTarget) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, out TextureHandle internalColorLut) { }

	public void Setup(in RTHandle internalLut) { }

}

