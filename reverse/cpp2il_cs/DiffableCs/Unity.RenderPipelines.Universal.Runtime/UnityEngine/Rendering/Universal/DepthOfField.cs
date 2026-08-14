namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Depth Of Field")]
public sealed class DepthOfField : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Use \"Gaussian\" for a faster but non physical depth of field; \"Bokeh\" for a more realistic but slower depth of field.")]
	public DepthOfFieldModeParameter mode; //Field offset: 0x38
	[Tooltip("The distance at which the blurring will start.")]
	public MinFloatParameter gaussianStart; //Field offset: 0x40
	[Tooltip("The distance at which the blurring will reach its maximum radius.")]
	public MinFloatParameter gaussianEnd; //Field offset: 0x48
	[Tooltip("The maximum radius of the gaussian blur. Values above 1 may show under-sampling artifacts.")]
	public ClampedFloatParameter gaussianMaxRadius; //Field offset: 0x50
	[Tooltip("Use higher quality sampling to reduce flickering and improve the overall blur smoothness.")]
	public BoolParameter highQualitySampling; //Field offset: 0x58
	[Tooltip("The distance to the point of focus.")]
	public MinFloatParameter focusDistance; //Field offset: 0x60
	[Tooltip("The ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
	public ClampedFloatParameter aperture; //Field offset: 0x68
	[Tooltip("The distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
	public ClampedFloatParameter focalLength; //Field offset: 0x70
	[Tooltip("The number of aperture blades.")]
	public ClampedIntParameter bladeCount; //Field offset: 0x78
	[Tooltip("The curvature of aperture blades. The smaller the value is, the more visible aperture blades are. A value of 1 will make the bokeh perfectly circular.")]
	public ClampedFloatParameter bladeCurvature; //Field offset: 0x80
	[Tooltip("The rotation of aperture blades in degrees.")]
	public ClampedFloatParameter bladeRotation; //Field offset: 0x88

	public DepthOfField() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

