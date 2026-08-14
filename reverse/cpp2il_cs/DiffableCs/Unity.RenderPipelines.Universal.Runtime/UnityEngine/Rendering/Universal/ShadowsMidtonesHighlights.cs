namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Shadows, Midtones, Highlights")]
public sealed class ShadowsMidtonesHighlights : VolumeComponent, IPostProcessComponent
{
	public Vector4Parameter shadows; //Field offset: 0x38
	public Vector4Parameter midtones; //Field offset: 0x40
	public Vector4Parameter highlights; //Field offset: 0x48
	[Header("Shadow Limits")]
	[Tooltip("Start point of the transition between shadows and midtones.")]
	public MinFloatParameter shadowsStart; //Field offset: 0x50
	[Tooltip("End point of the transition between shadows and midtones.")]
	public MinFloatParameter shadowsEnd; //Field offset: 0x58
	[Header("Highlight Limits")]
	[Tooltip("Start point of the transition between midtones and highlights.")]
	public MinFloatParameter highlightsStart; //Field offset: 0x60
	[Tooltip("End point of the transition between midtones and highlights.")]
	public MinFloatParameter highlightsEnd; //Field offset: 0x68

	public ShadowsMidtonesHighlights() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

}

