namespace UnityEngine.Rendering;

internal struct ProbeVolumeShadingParameters
{
	public float normalBias; //Field offset: 0x0
	public float viewBias; //Field offset: 0x4
	public bool scaleBiasByMinDistanceBetweenProbes; //Field offset: 0x8
	public float samplingNoise; //Field offset: 0xC
	public float weight; //Field offset: 0x10
	public APVLeakReductionMode leakReductionMode; //Field offset: 0x14
	public int frameIndexForNoise; //Field offset: 0x18
	public float reflNormalizationLowerClamp; //Field offset: 0x1C
	public float reflNormalizationUpperClamp; //Field offset: 0x20
	public float skyOcclusionIntensity; //Field offset: 0x24
	public bool skyOcclusionShadingDirection; //Field offset: 0x28
	public int regionCount; //Field offset: 0x2C
	public uint4 regionLayerMasks; //Field offset: 0x30
	public Vector3 worldOffset; //Field offset: 0x40

}

