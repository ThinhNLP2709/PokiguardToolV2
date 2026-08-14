namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Lens Distortion")]
public sealed class LensDistortion : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Total distortion amount.")]
	public ClampedFloatParameter intensity; //Field offset: 0x38
	[Tooltip("Intensity multiplier on X axis. Set it to 0 to disable distortion on this axis.")]
	public ClampedFloatParameter xMultiplier; //Field offset: 0x40
	[Tooltip("Intensity multiplier on Y axis. Set it to 0 to disable distortion on this axis.")]
	public ClampedFloatParameter yMultiplier; //Field offset: 0x48
	[Tooltip("Distortion center point. 0.5,0.5 is center of the screen.")]
	public Vector2Parameter center; //Field offset: 0x50
	[Tooltip("Controls global screen scaling for the distortion effect. Use this to hide the screen borders when using high \"Intensity.\"")]
	public ClampedFloatParameter scale; //Field offset: 0x58

	public LensDistortion() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

