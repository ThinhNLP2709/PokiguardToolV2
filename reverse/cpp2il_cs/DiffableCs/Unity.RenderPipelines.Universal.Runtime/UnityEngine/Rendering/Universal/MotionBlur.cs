namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Motion Blur")]
public sealed class MotionBlur : VolumeComponent, IPostProcessComponent
{
	[Tooltip("The motion blur technique to use. If you don't need object motion blur, CameraOnly will result in better performance.")]
	public MotionBlurModeParameter mode; //Field offset: 0x38
	[Tooltip("The quality of the effect. Lower presets will result in better performance at the expense of visual quality.")]
	public MotionBlurQualityParameter quality; //Field offset: 0x40
	[Tooltip("The strength of the motion blur filter. Acts as a multiplier for velocities.")]
	public ClampedFloatParameter intensity; //Field offset: 0x48
	[Tooltip("Sets the maximum length, as a fraction of the screen's full resolution, that the velocity resulting from Camera rotation can have. Lower values will improve performance.")]
	public ClampedFloatParameter clamp; //Field offset: 0x50

	public MotionBlur() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

