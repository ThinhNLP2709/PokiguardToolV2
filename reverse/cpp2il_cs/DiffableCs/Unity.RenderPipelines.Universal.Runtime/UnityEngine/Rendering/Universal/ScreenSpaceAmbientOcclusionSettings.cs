namespace UnityEngine.Rendering.Universal;

internal class ScreenSpaceAmbientOcclusionSettings
{
	public enum AOMethodOptions
	{
		BlueNoise = 0,
		InterleavedGradient = 1,
	}

	public enum AOSampleOption
	{
		High = 0,
		Medium = 1,
		Low = 2,
	}

	public enum BlurQualityOptions
	{
		High = 0,
		Medium = 1,
		Low = 2,
	}

	public enum DepthSource
	{
		Depth = 0,
		DepthNormals = 1,
	}

	public enum NormalQuality
	{
		Low = 0,
		Medium = 1,
		High = 2,
	}

	[SerializeField]
	internal AOMethodOptions AOMethod; //Field offset: 0x10
	[SerializeField]
	internal bool Downsample; //Field offset: 0x14
	[SerializeField]
	internal bool AfterOpaque; //Field offset: 0x15
	[SerializeField]
	internal DepthSource Source; //Field offset: 0x18
	[SerializeField]
	internal NormalQuality NormalSamples; //Field offset: 0x1C
	[SerializeField]
	internal float Intensity; //Field offset: 0x20
	[SerializeField]
	internal float DirectLightingStrength; //Field offset: 0x24
	[SerializeField]
	internal float Radius; //Field offset: 0x28
	[SerializeField]
	internal AOSampleOption Samples; //Field offset: 0x2C
	[SerializeField]
	internal BlurQualityOptions BlurQuality; //Field offset: 0x30
	[SerializeField]
	internal float Falloff; //Field offset: 0x34
	[SerializeField]
	internal int SampleCount; //Field offset: 0x38

	public ScreenSpaceAmbientOcclusionSettings() { }

}

