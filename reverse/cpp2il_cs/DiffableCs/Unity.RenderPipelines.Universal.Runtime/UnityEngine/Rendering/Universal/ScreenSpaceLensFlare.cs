namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Screen Space Lens Flare")]
public class ScreenSpaceLensFlare : VolumeComponent, IPostProcessComponent
{
	public MinFloatParameter intensity; //Field offset: 0x38
	public ColorParameter tintColor; //Field offset: 0x40
	[AdditionalProperty]
	public ClampedIntParameter bloomMip; //Field offset: 0x48
	[Header("Flares")]
	public MinFloatParameter firstFlareIntensity; //Field offset: 0x50
	public MinFloatParameter secondaryFlareIntensity; //Field offset: 0x58
	public MinFloatParameter warpedFlareIntensity; //Field offset: 0x60
	[AdditionalProperty]
	public Vector2Parameter warpedFlareScale; //Field offset: 0x68
	public ClampedIntParameter samples; //Field offset: 0x70
	[AdditionalProperty]
	public ClampedFloatParameter sampleDimmer; //Field offset: 0x78
	public ClampedFloatParameter vignetteEffect; //Field offset: 0x80
	public ClampedFloatParameter startingPosition; //Field offset: 0x88
	public ClampedFloatParameter scale; //Field offset: 0x90
	[Header("Streaks")]
	public MinFloatParameter streaksIntensity; //Field offset: 0x98
	public ClampedFloatParameter streaksLength; //Field offset: 0xA0
	public FloatParameter streaksOrientation; //Field offset: 0xA8
	public ClampedFloatParameter streaksThreshold; //Field offset: 0xB0
	[AdditionalProperty]
	[SerializeField]
	public ScreenSpaceLensFlareResolutionParameter resolution; //Field offset: 0xB8
	[Header("Chromatic Abberation")]
	public ClampedFloatParameter chromaticAbberationIntensity; //Field offset: 0xC0

	public ScreenSpaceLensFlare() { }

	public override bool IsActive() { }

	public bool IsStreaksActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

