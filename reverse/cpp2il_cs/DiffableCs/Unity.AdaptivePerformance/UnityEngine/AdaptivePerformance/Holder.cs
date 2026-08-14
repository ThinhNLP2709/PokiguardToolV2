namespace UnityEngine.AdaptivePerformance;

public static class Holder
{
	private static IAdaptivePerformance m_Instance; //Field offset: 0x0
	[CompilerGenerated]
	private static LifecycleEventHandler LifecycleEventHandler; //Field offset: 0x8

	public static event LifecycleEventHandler LifecycleEventHandler
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public internal static IAdaptivePerformance Instance
	{
		 get { } //Length: 54
		internal set { } //Length: 145
	}

	[CompilerGenerated]
	public static void add_LifecycleEventHandler(LifecycleEventHandler value) { }

	public static void Deinitialize() { }

	public static IAdaptivePerformance get_Instance() { }

	public static void Initialize() { }

	[CompilerGenerated]
	public static void remove_LifecycleEventHandler(LifecycleEventHandler value) { }

	internal static void set_Instance(IAdaptivePerformance value) { }

}

