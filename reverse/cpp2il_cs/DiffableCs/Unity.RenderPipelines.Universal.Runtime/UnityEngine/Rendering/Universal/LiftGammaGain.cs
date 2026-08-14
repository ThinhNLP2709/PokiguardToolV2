namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Lift, Gamma, Gain")]
public sealed class LiftGammaGain : VolumeComponent, IPostProcessComponent
{
	public Vector4Parameter lift; //Field offset: 0x38
	public Vector4Parameter gamma; //Field offset: 0x40
	public Vector4Parameter gain; //Field offset: 0x48

	public LiftGammaGain() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

