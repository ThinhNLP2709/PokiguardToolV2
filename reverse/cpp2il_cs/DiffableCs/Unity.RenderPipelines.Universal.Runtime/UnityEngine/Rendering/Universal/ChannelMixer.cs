namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Channel Mixer")]
public sealed class ChannelMixer : VolumeComponent, IPostProcessComponent
{
	[Tooltip("Modify influence of the red channel in the overall mix.")]
	public ClampedFloatParameter redOutRedIn; //Field offset: 0x38
	[Tooltip("Modify influence of the green channel in the overall mix.")]
	public ClampedFloatParameter redOutGreenIn; //Field offset: 0x40
	[Tooltip("Modify influence of the blue channel in the overall mix.")]
	public ClampedFloatParameter redOutBlueIn; //Field offset: 0x48
	[Tooltip("Modify influence of the red channel in the overall mix.")]
	public ClampedFloatParameter greenOutRedIn; //Field offset: 0x50
	[Tooltip("Modify influence of the green channel in the overall mix.")]
	public ClampedFloatParameter greenOutGreenIn; //Field offset: 0x58
	[Tooltip("Modify influence of the blue channel in the overall mix.")]
	public ClampedFloatParameter greenOutBlueIn; //Field offset: 0x60
	[Tooltip("Modify influence of the red channel in the overall mix.")]
	public ClampedFloatParameter blueOutRedIn; //Field offset: 0x68
	[Tooltip("Modify influence of the green channel in the overall mix.")]
	public ClampedFloatParameter blueOutGreenIn; //Field offset: 0x70
	[Tooltip("Modify influence of the blue channel in the overall mix.")]
	public ClampedFloatParameter blueOutBlueIn; //Field offset: 0x78

	public ChannelMixer() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

