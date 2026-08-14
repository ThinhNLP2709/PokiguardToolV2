namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Tonemapping")]
public sealed class Tonemapping : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Select a tonemapping algorithm to use for the color grading process.")]
	public TonemappingModeParameter mode; //Field offset: 0x38
	[AdditionalProperty]
	[Tooltip("Specifies the range reduction mode used when HDR output is enabled and Neutral tonemapping is enabled.")]
	public NeutralRangeReductionModeParameter neutralHDRRangeReductionMode; //Field offset: 0x40
	[Tooltip("Use the ACES preset for HDR displays.")]
	public HDRACESPresetParameter acesPreset; //Field offset: 0x48
	[Tooltip("Specify how much hue to preserve. Values closer to 0 are likely to preserve hue. As values get closer to 1, Unity doesn't correct hue shifts.")]
	public ClampedFloatParameter hueShiftAmount; //Field offset: 0x50
	[Tooltip("Enable to use values detected from the output device as paper white. When enabled, output images might differ between SDR and HDR. For best accuracy, set this value manually.")]
	public BoolParameter detectPaperWhite; //Field offset: 0x58
	[Tooltip("The reference brightness of a paper white surface. This property determines the maximum brightness of UI. The brightness of the scene is scaled relative to this value. The value is in nits.")]
	public ClampedFloatParameter paperWhite; //Field offset: 0x60
	[Tooltip("Enable to use the minimum and maximum brightness values detected from the output device. For best accuracy, considering calibrating these values manually.")]
	public BoolParameter detectBrightnessLimits; //Field offset: 0x68
	[Tooltip("The minimum brightness of the screen (in nits). This value is assumed to be 0.005f with ACES Tonemap.")]
	public ClampedFloatParameter minNits; //Field offset: 0x70
	[Tooltip("The maximum brightness of the screen (in nits). This value is defined by the preset when using ACES Tonemap.")]
	public ClampedFloatParameter maxNits; //Field offset: 0x78

	public Tonemapping() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

