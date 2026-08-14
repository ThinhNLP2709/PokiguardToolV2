namespace Unity.VisualScripting;

public static class ReferenceCollector
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static UnityAction<Scene> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Initialize>b__3_0(Scene scene) { }

	}

	[CompilerGenerated]
	private static Action onSceneUnloaded; //Field offset: 0x0

	public static event Action onSceneUnloaded
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	[CompilerGenerated]
	public static void add_onSceneUnloaded(Action value) { }

	internal static void Initialize() { }

	[CompilerGenerated]
	public static void remove_onSceneUnloaded(Action value) { }

}

