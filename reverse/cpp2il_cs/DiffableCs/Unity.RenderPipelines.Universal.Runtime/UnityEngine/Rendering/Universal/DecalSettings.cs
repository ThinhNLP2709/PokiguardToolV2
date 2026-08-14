namespace UnityEngine.Rendering.Universal;

internal class DecalSettings
{
	public DecalTechniqueOption technique; //Field offset: 0x10
	public float maxDrawDistance; //Field offset: 0x14
	public bool decalLayers; //Field offset: 0x18
	public DBufferSettings dBufferSettings; //Field offset: 0x20
	public DecalScreenSpaceSettings screenSpaceSettings; //Field offset: 0x28

	public DecalSettings() { }

}

