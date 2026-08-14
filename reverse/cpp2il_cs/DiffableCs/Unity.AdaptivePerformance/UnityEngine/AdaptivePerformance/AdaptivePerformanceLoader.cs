namespace UnityEngine.AdaptivePerformance;

public abstract class AdaptivePerformanceLoader : ScriptableObject
{

	public abstract bool Initialized
	{
		 get { } //Length: 0
	}

	public abstract bool Running
	{
		 get { } //Length: 0
	}

	protected AdaptivePerformanceLoader() { }

	public override bool Deinitialize() { }

	public abstract bool get_Initialized() { }

	public abstract bool get_Running() { }

	public abstract ISubsystem GetDefaultSubsystem() { }

	public abstract T GetLoadedSubsystem() { }

	public abstract IAdaptivePerformanceSettings GetSettings() { }

	public override bool Initialize() { }

	public override bool Start() { }

	public override bool Stop() { }

}

