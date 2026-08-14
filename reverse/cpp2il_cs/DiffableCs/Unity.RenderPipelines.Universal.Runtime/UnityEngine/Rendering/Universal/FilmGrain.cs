namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Film Grain")]
public sealed class FilmGrain : VolumeComponent, IPostProcessComponent
{
	[Tooltip("The type of grain to use. You can select a preset or provide your own texture by selecting Custom.")]
	public FilmGrainLookupParameter type; //Field offset: 0x38
	[Tooltip("Use the slider to set the strength of the Film Grain effect.")]
	public ClampedFloatParameter intensity; //Field offset: 0x40
	[Tooltip("Controls the noisiness response curve based on scene luminance. Higher values mean less noise in light areas.")]
	public ClampedFloatParameter response; //Field offset: 0x48
	[Tooltip("A tileable texture to use for the grain. The neutral value is 0.5 where no grain is applied.")]
	public NoInterpTextureParameter texture; //Field offset: 0x50

	public FilmGrain() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

