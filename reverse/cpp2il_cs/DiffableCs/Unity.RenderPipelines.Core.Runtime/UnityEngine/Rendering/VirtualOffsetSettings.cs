namespace UnityEngine.Rendering;

internal struct VirtualOffsetSettings
{
	public bool useVirtualOffset; //Field offset: 0x0
	[Range(0, 0.95)]
	public float validityThreshold; //Field offset: 0x4
	[Range(0, 1)]
	public float outOfGeoOffset; //Field offset: 0x8
	[Range(0, 2)]
	public float searchMultiplier; //Field offset: 0xC
	[Range(-0.05, 0)]
	public float rayOriginBias; //Field offset: 0x10
	public LayerMask collisionMask; //Field offset: 0x14

	internal void SetDefaults() { }

	internal void UpgradeFromTo(SettingsVersion from, SettingsVersion to) { }

}

