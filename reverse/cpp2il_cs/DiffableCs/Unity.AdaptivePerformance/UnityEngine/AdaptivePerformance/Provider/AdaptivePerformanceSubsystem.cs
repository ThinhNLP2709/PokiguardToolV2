namespace UnityEngine.AdaptivePerformance.Provider;

public class AdaptivePerformanceSubsystem : AdaptivePerformanceSubsystemBase<AdaptivePerformanceSubsystem, AdaptivePerformanceSubsystemDescriptor, APProvider>
{
	internal abstract class APProvider : SubsystemProvider<AdaptivePerformanceSubsystem>
	{
		protected bool m_Running; //Field offset: 0x18

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

		public bool running
		{
			 get { } //Length: 5
		}

		public override string Stats
		{
			 get { } //Length: 44
		}

		public abstract Version Version
		{
			 get { } //Length: 0
		}

		protected APProvider() { }

		public abstract IApplicationLifecycle get_ApplicationLifecycle() { }

		public abstract Feature get_Capabilities() { }

		public abstract bool get_Initialized() { }

		public abstract IDevicePerformanceLevelControl get_PerformanceLevelControl() { }

		public bool get_running() { }

		public override string get_Stats() { }

		public abstract Version get_Version() { }

		public abstract void set_Capabilities(Feature value) { }

		public abstract void set_Initialized(bool value) { }

		public abstract PerformanceDataRecord Update() { }

	}


	public virtual IApplicationLifecycle ApplicationLifecycle
	{
		 get { } //Length: 76
	}

	public virtual Feature Capabilities
	{
		 get { } //Length: 76
		 set { } //Length: 89
	}

	public virtual bool Initialized
	{
		 get { } //Length: 76
		 set { } //Length: 92
	}

	public virtual IDevicePerformanceLevelControl PerformanceLevelControl
	{
		 get { } //Length: 76
	}

	public virtual string Stats
	{
		 get { } //Length: 76
	}

	public virtual Version Version
	{
		 get { } //Length: 76
	}

	public AdaptivePerformanceSubsystem() { }

	public virtual IApplicationLifecycle get_ApplicationLifecycle() { }

	public virtual Feature get_Capabilities() { }

	public virtual bool get_Initialized() { }

	public virtual IDevicePerformanceLevelControl get_PerformanceLevelControl() { }

	public virtual string get_Stats() { }

	public virtual Version get_Version() { }

	protected virtual void set_Capabilities(Feature value) { }

	protected virtual void set_Initialized(bool value) { }

	public virtual PerformanceDataRecord Update() { }

}

