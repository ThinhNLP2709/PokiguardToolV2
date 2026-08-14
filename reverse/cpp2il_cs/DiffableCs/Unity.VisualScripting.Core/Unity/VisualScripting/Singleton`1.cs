namespace Unity.VisualScripting;

public static class Singleton
{
	private static readonly SingletonAttribute attribute; //Field offset: 0x0
	private static readonly object _lock; //Field offset: 0x0
	private static readonly HashSet<T> awoken; //Field offset: 0x0
	private static T _instance; //Field offset: 0x0

	private static bool automatic
	{
		private get { } //Length: 154
	}

	private static HideFlags hideFlags
	{
		private get { } //Length: 153
	}

	public static T instance
	{
		 get { } //Length: 880
	}

	public static bool instantiated
	{
		 get { } //Length: 661
	}

	private static string name
	{
		private get { } //Length: 154
	}

	private static bool persistent
	{
		private get { } //Length: 154
	}

	private static Singleton`1() { }

	public static void Awake(T instance) { }

	private static T[] FindInstances() { }

	private static T[] FindObjectsOfType() { }

	private static bool get_automatic() { }

	private static HideFlags get_hideFlags() { }

	public static T get_instance() { }

	public static bool get_instantiated() { }

	private static string get_name() { }

	private static bool get_persistent() { }

	public static T Instantiate() { }

	public static void OnDestroy(T instance) { }

}

