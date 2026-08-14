namespace Unity.VisualScripting;

public static class SceneSingleton
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public Scene scene; //Field offset: 0x0

		public <>c__DisplayClass15_0() { }

		internal bool <FindInstances>b__0(T o) { }

	}

	private static Dictionary<Scene, T> instances; //Field offset: 0x0
	private static readonly SingletonAttribute attribute; //Field offset: 0x0

	private static bool automatic
	{
		private get { } //Length: 155
	}

	private static HideFlags hideFlags
	{
		private get { } //Length: 154
	}

	private static string name
	{
		private get { } //Length: 155
	}

	private static bool persistent
	{
		private get { } //Length: 155
	}

	private static SceneSingleton`1() { }

	public static void Awake(T instance) { }

	private static void EnsureSceneValid(Scene scene) { }

	private static T[] FindInstances(Scene scene) { }

	private static T[] FindObjectsOfType() { }

	private static T FindOrCreateInstance(Scene scene) { }

	private static bool get_automatic() { }

	private static HideFlags get_hideFlags() { }

	private static string get_name() { }

	private static bool get_persistent() { }

	public static T InstanceIn(Scene scene) { }

	public static bool InstantiatedIn(Scene scene) { }

	public static void OnDestroy(T instance) { }

}

