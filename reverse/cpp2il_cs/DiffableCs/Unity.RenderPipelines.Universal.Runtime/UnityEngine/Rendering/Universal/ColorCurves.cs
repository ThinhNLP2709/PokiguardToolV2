namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Color Curves")]
public sealed class ColorCurves : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Affects the luminance across the whole image.")]
	public TextureCurveParameter master; //Field offset: 0x38
	[Tooltip("Affects the red channel intensity across the whole image.")]
	public TextureCurveParameter red; //Field offset: 0x40
	[Tooltip("Affects the green channel intensity across the whole image.")]
	public TextureCurveParameter green; //Field offset: 0x48
	[Tooltip("Affects the blue channel intensity across the whole image.")]
	public TextureCurveParameter blue; //Field offset: 0x50
	[Tooltip("Shifts the input hue (x-axis) according to the output hue (y-axis).")]
	public TextureCurveParameter hueVsHue; //Field offset: 0x58
	[Tooltip("Adjusts saturation (y-axis) according to the input hue (x-axis).")]
	public TextureCurveParameter hueVsSat; //Field offset: 0x60
	[Tooltip("Adjusts saturation (y-axis) according to the input saturation (x-axis).")]
	public TextureCurveParameter satVsSat; //Field offset: 0x68
	[Tooltip("Adjusts saturation (y-axis) according to the input luminance (x-axis).")]
	public TextureCurveParameter lumVsSat; //Field offset: 0x70

	public ColorCurves() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

