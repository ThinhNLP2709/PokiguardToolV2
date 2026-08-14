namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Panini Projection")]
public sealed class PaniniProjection : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Panini projection distance.")]
	public ClampedFloatParameter distance; //Field offset: 0x38
	[Tooltip("Panini projection crop to fit.")]
	public ClampedFloatParameter cropToFit; //Field offset: 0x40

	public PaniniProjection() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

