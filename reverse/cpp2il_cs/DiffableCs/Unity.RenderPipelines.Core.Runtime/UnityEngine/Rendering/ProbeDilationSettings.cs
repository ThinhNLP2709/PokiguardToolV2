namespace UnityEngine.Rendering;

internal struct ProbeDilationSettings
{
	public bool enableDilation; //Field offset: 0x0
	public float dilationDistance; //Field offset: 0x4
	public float dilationValidityThreshold; //Field offset: 0x8
	public int dilationIterations; //Field offset: 0xC
	public bool squaredDistWeighting; //Field offset: 0x10

	internal void SetDefaults() { }

	internal void UpgradeFromTo(SettingsVersion from, SettingsVersion to) { }

}

