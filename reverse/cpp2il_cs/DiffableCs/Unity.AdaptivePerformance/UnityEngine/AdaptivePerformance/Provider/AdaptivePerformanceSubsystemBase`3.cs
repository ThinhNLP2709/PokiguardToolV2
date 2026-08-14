namespace UnityEngine.AdaptivePerformance.Provider;

public abstract class AdaptivePerformanceSubsystemBase : SubsystemWithProvider<TSubsystem, TSubsystemDescriptor, TProvider>
{

	public abstract IApplicationLifecycle ApplicationLifecycle
	{
		 get { } //Length: 0
	}

	public abstract Feature Capabilities
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public abstract bool Initialized
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public abstract IDevicePerformanceLevelControl PerformanceLevelControl
	{
		 get { } //Length: 0
	}

	public abstract string Stats
	{
		 get { } //Length: 0
	}

	public abstract Version Version
	{
		 get { } //Length: 0
	}

	protected AdaptivePerformanceSubsystemBase`3() { }

	public abstract IApplicationLifecycle get_ApplicationLifecycle() { }

	public abstract Feature get_Capabilities() { }

	public abstract bool get_Initialized() { }

	public abstract IDevicePerformanceLevelControl get_PerformanceLevelControl() { }

	public abstract string get_Stats() { }

	public abstract Version get_Version() { }

	protected abstract void set_Capabilities(Feature value) { }

	protected abstract void set_Initialized(bool value) { }

	public abstract PerformanceDataRecord Update() { }

}

