namespace UnityEngine.AdaptivePerformance;

public interface IAdaptivePerformance
{

	public bool Active
	{
		 get { } //Length: 0
	}

	public IDevelopmentSettings DevelopmentSettings
	{
		 get { } //Length: 0
	}

	public IDevicePerformanceControl DevicePerformanceControl
	{
		 get { } //Length: 0
	}

	public AdaptivePerformanceIndexer Indexer
	{
		 get { } //Length: 0
	}

	public bool Initialized
	{
		 get { } //Length: 0
	}

	public IPerformanceModeStatus PerformanceModeStatus
	{
		 get { } //Length: 0
	}

	public IPerformanceStatus PerformanceStatus
	{
		 get { } //Length: 0
	}

	public IAdaptivePerformanceSettings Settings
	{
		 get { } //Length: 0
	}

	public AdaptivePerformanceSubsystem Subsystem
	{
		 get { } //Length: 0
	}

	public IThermalStatus ThermalStatus
	{
		 get { } //Length: 0
	}

	public void DeinitializeAdaptivePerformance() { }

	public bool get_Active() { }

	public IDevelopmentSettings get_DevelopmentSettings() { }

	public IDevicePerformanceControl get_DevicePerformanceControl() { }

	public AdaptivePerformanceIndexer get_Indexer() { }

	public bool get_Initialized() { }

	public IPerformanceModeStatus get_PerformanceModeStatus() { }

	public IPerformanceStatus get_PerformanceStatus() { }

	public IAdaptivePerformanceSettings get_Settings() { }

	public AdaptivePerformanceSubsystem get_Subsystem() { }

	public IThermalStatus get_ThermalStatus() { }

	public void InitializeAdaptivePerformance() { }

	public void StartAdaptivePerformance() { }

	public void StopAdaptivePerformance() { }

	public bool SupportedFeature(Feature feature) { }

}

