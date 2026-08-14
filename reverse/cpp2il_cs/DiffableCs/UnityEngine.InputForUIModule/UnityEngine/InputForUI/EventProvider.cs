namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal static class EventProvider
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<Registration> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <Subscribe>b__5_0(Registration a, Registration b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public EventConsumer handler; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <Unsubscribe>b__0(Registration x) { }

	}

	private struct Registration
	{
		public EventConsumer handler; //Field offset: 0x0
		public int priority; //Field offset: 0x8
		public Nullable<Int32> playerId; //Field offset: 0xC
		public HashSet<Type> _types; //Field offset: 0x18

	}

	private static IEventProviderImpl s_impl; //Field offset: 0x0
	private static EventSanitizer s_sanitizer; //Field offset: 0x8
	private static IEventProviderImpl s_implMockBackup; //Field offset: 0x10
	private static bool s_focusChangedRegistered; //Field offset: 0x18
	private static bool m_IsEnabled; //Field offset: 0x19
	private static bool m_IsInitialized; //Field offset: 0x1A
	private static List<Registration> _registrations; //Field offset: 0x20

	private static EventProvider() { }

	private static void Bootstrap() { }

	internal static void Dispatch(in Event ev) { }

	private static void Initialize() { }

	[RequiredByNativeCode]
	internal static void NotifyUpdate() { }

	private static void OnFocusChanged(bool focus) { }

	public static void SetEnabled(bool enable) { }

	internal static void SetInputSystemProvider(IEventProviderImpl impl) { }

	private static void Shutdown() { }

	public static void Subscribe(EventConsumer handler, int priority = 0, Nullable<Int32> playerId = null, Type[] type) { }

	public static void Unsubscribe(EventConsumer handler) { }

}

