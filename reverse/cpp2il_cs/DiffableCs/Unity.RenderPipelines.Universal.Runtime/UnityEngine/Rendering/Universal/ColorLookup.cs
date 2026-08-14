namespace UnityEngine.Rendering.Universal;

[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[VolumeComponentMenu("Post-processing/Color Lookup")]
public sealed class ColorLookup : VolumeComponent, IPostProcessComponent
{
	[Tooltip("A 2D Lookup Texture (LUT) to use for color grading.")]
	public TextureParameter texture; //Field offset: 0x38
	[Tooltip("How much of the lookup texture will contribute to the color grading effect.")]
	public ClampedFloatParameter contribution; //Field offset: 0x40

	public ColorLookup() { }

	public override bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public override bool IsTileCompatible() { }

	public bool ValidateLUT() { }

}

