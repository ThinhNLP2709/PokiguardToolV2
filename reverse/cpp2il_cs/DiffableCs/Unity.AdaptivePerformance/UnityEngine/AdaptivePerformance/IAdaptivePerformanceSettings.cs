namespace UnityEngine.AdaptivePerformance;

public class IAdaptivePerformanceSettings : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public PropertyInfo property; //Field offset: 0x10

		public <>c__DisplayClass29_0() { }

		internal bool <ApplyScalerProfileToAllScalers>b__0(AdaptivePerformanceScaler s) { }

	}

	[SerializeField]
	[Tooltip("Enable Logging in Devmode")]
	private bool m_Logging; //Field offset: 0x18
	[SerializeField]
	[Tooltip("Automatic Performance Mode")]
	private bool m_AutomaticPerformanceModeEnabled; //Field offset: 0x19
	[SerializeField]
	[Tooltip("Automatic Game Mode")]
	private bool m_AutomaticGameModeEnabled; //Field offset: 0x1A
	[SerializeField]
	[Tooltip("Enables the CPU and GPU boost mode before engine startup to decrease startup time.")]
	private bool m_EnableBoostOnStartup; //Field offset: 0x1B
	[SerializeField]
	[Tooltip("Logging Frequency (Development mode only)")]
	private int m_StatsLoggingFrequencyInFrames; //Field offset: 0x1C
	[SerializeField]
	[Tooltip("Indexer Settings")]
	private AdaptivePerformanceIndexerSettings m_IndexerSettings; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Scaler Settings")]
	private AdaptivePerformanceScalerSettings m_ScalerSettings; //Field offset: 0x28
	[SerializeField]
	private AdaptivePerformanceScalerProfile[] m_scalerProfileList; //Field offset: 0x30
	[SerializeField]
	internal int m_DefaultScalerProfilerIndex; //Field offset: 0x38

	public bool automaticGameMode
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool automaticPerformanceMode
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public int defaultScalerProfilerIndex
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool enableBoostOnStartup
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public AdaptivePerformanceIndexerSettings indexerSettings
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool logging
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public AdaptivePerformanceScalerSettings scalerSettings
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public int statsLoggingFrequencyInFrames
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public IAdaptivePerformanceSettings() { }

	private bool ApplyScalerProfileToAllScalers() { }

	public bool get_automaticGameMode() { }

	public bool get_automaticPerformanceMode() { }

	public int get_defaultScalerProfilerIndex() { }

	public bool get_enableBoostOnStartup() { }

	public AdaptivePerformanceIndexerSettings get_indexerSettings() { }

	public bool get_logging() { }

	public AdaptivePerformanceScalerSettings get_scalerSettings() { }

	public int get_statsLoggingFrequencyInFrames() { }

	public String[] GetAvailableScalerProfiles() { }

	public void LoadScalerProfile(string scalerProfileName) { }

	public void OnEnable() { }

	public void set_automaticGameMode(bool value) { }

	public void set_automaticPerformanceMode(bool value) { }

	public void set_defaultScalerProfilerIndex(int value) { }

	public void set_enableBoostOnStartup(bool value) { }

	public void set_indexerSettings(AdaptivePerformanceIndexerSettings value) { }

	public void set_logging(bool value) { }

	public void set_scalerSettings(AdaptivePerformanceScalerSettings value) { }

	public void set_statsLoggingFrequencyInFrames(int value) { }

}

