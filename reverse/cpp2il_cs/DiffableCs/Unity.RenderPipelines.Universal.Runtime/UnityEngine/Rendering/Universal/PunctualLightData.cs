namespace UnityEngine.Rendering.Universal;

public struct PunctualLightData
{
	public Vector3 wsPos; //Field offset: 0x0
	public float radius; //Field offset: 0xC
	public Vector4 color; //Field offset: 0x10
	public Vector4 attenuation; //Field offset: 0x20
	public Vector3 spotDirection; //Field offset: 0x30
	public int flags; //Field offset: 0x3C
	public Vector4 occlusionProbeInfo; //Field offset: 0x40
	public uint layerMask; //Field offset: 0x50

}

