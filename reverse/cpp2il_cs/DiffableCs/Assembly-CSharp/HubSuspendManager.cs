//Type is in global namespace

public static class HubSuspendManager
{
	private static readonly List<IHubSuspendable> _items; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsSuspended>k__BackingField; //Field offset: 0x8
	private static readonly List<Tween> _pausedTweens; //Field offset: 0x10
	private static readonly List<Tween> _tweenScratch; //Field offset: 0x18

	public private static bool IsSuspended
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	private static HubSuspendManager() { }

	[CompilerGenerated]
	public static bool get_IsSuspended() { }

	private static void PauseHubLoopTweens() { }

	public static void Register(IHubSuspendable item) { }

	public static void ResumeAll() { }

	private static int ResumeHubLoopTweens() { }

	[CompilerGenerated]
	private static void set_IsSuspended(bool value) { }

	public static void SuspendAll() { }

	private static GameObject TargetGameObject(object target) { }

	public static void Unregister(IHubSuspendable item) { }

}

