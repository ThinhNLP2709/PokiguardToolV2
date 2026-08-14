namespace Unity.VisualScripting;

public static class EventBus
{
	private static readonly Dictionary<EventHook, HashSet`1<Delegate>> events; //Field offset: 0x0

	internal static Dictionary<EventHook, HashSet`1<Delegate>> testAccessEvents
	{
		internal get { } //Length: 78
	}

	private static EventBus() { }

	internal static Dictionary<EventHook, HashSet`1<Delegate>> get_testAccessEvents() { }

	public static void Register(EventHook hook, Action<TArgs> handler) { }

	public static void Trigger(EventHook hook, TArgs args) { }

	public static void Trigger(string name, GameObject target, TArgs args) { }

	public static void Trigger(EventHook hook) { }

	public static void Trigger(string name, GameObject target) { }

	public static void Unregister(EventHook hook, Delegate handler) { }

}

