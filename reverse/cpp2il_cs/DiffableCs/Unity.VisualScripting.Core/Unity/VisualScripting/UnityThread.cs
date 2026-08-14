namespace Unity.VisualScripting;

public static class UnityThread
{
	public static Thread thread; //Field offset: 0x0
	public static Action<Action> editorAsync; //Field offset: 0x8
	public static ConcurrentQueue<Action> pendingQueue; //Field offset: 0x10

	public static bool allowsAPI
	{
		 get { } //Length: 534
	}

	private static UnityThread() { }

	[Conditional("UNITY_EDITOR")]
	public static void EditorAsync(Action action) { }

	public static bool get_allowsAPI() { }

	internal static void RuntimeInitialize() { }

}

