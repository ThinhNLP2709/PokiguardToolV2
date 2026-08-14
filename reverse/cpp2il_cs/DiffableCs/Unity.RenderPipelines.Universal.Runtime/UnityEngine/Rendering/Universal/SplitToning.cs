namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Split Toning")]
public sealed class SplitToning : VolumeComponent, IPostProcessComponent
{
	[Tooltip("The color to use for shadows.")]
	public ColorParameter shadows; //Field offset: 0x38
	[Tooltip("The color to use for highlights.")]
	public ColorParameter highlights; //Field offset: 0x40
	[Tooltip("Balance between the colors in the highlights and shadows.")]
	public ClampedFloatParameter balance; //Field offset: 0x48

	public SplitToning() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

