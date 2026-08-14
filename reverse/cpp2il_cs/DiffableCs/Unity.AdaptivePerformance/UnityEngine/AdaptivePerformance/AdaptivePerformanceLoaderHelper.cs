namespace UnityEngine.AdaptivePerformance;

public abstract class AdaptivePerformanceLoaderHelper : AdaptivePerformanceLoader
{
	protected Dictionary<Type, ISubsystem> m_SubsystemInstanceMap; //Field offset: 0x18

	protected AdaptivePerformanceLoaderHelper() { }

	protected void CreateSubsystem(List<TDescriptor> descriptors, string id) { }

	public virtual bool Deinitialize() { }

	protected void DestroySubsystem() { }

	public virtual T GetLoadedSubsystem() { }

	protected void StartSubsystem() { }

	protected void StopSubsystem() { }

}

