namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/White Balance")]
public sealed class WhiteBalance : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Sets the white balance to a custom color temperature.")]
	public ClampedFloatParameter temperature; //Field offset: 0x38
	[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
	public ClampedFloatParameter tint; //Field offset: 0x40

	public WhiteBalance() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

