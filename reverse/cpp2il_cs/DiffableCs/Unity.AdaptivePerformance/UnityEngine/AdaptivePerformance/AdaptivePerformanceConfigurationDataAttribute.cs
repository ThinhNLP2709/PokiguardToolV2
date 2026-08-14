namespace UnityEngine.AdaptivePerformance;

[AttributeUsage(AttributeTargets::Class (4))]
public sealed class AdaptivePerformanceConfigurationDataAttribute : Attribute
{
	[CompilerGenerated]
	private string <displayName>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <buildSettingsKey>k__BackingField; //Field offset: 0x18

	public string buildSettingsKey
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public string displayName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private AdaptivePerformanceConfigurationDataAttribute() { }

	public AdaptivePerformanceConfigurationDataAttribute(string displayName, string buildSettingsKey) { }

	[CompilerGenerated]
	public string get_buildSettingsKey() { }

	[CompilerGenerated]
	public string get_displayName() { }

	[CompilerGenerated]
	public void set_buildSettingsKey(string value) { }

	[CompilerGenerated]
	public void set_displayName(string value) { }

}

