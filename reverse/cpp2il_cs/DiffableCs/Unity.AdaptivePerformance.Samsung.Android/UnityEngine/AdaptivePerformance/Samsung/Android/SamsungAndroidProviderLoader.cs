namespace UnityEngine.AdaptivePerformance.Samsung.Android;

public class SamsungAndroidProviderLoader : AdaptivePerformanceLoaderHelper
{
	private static List<AdaptivePerformanceSubsystemDescriptor> s_SamsungGameSDKSubsystemDescriptors; //Field offset: 0x0

	public virtual bool Initialized
	{
		 get { } //Length: 3
	}

	public virtual bool Running
	{
		 get { } //Length: 3
	}

	private static SamsungAndroidProviderLoader() { }

	public SamsungAndroidProviderLoader() { }

	public virtual bool Deinitialize() { }

	public virtual bool get_Initialized() { }

	public virtual bool get_Running() { }

	public virtual ISubsystem GetDefaultSubsystem() { }

	public virtual IAdaptivePerformanceSettings GetSettings() { }

	public virtual bool Initialize() { }

	public virtual bool Start() { }

	public virtual bool Stop() { }

}

