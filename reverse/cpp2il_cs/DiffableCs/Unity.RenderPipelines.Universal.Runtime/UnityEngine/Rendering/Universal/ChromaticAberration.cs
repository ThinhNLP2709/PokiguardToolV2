namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Chromatic Aberration")]
public sealed class ChromaticAberration : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Use the slider to set the strength of the Chromatic Aberration effect.")]
	public ClampedFloatParameter intensity; //Field offset: 0x38

	public ChromaticAberration() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

