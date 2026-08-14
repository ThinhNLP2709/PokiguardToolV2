//Type is in global namespace

public class WsDebugOverlay : MonoBehaviour
{
	private struct Entry
	{
		public string time; //Field offset: 0x0
		public bool incoming; //Field offset: 0x8
		public string type; //Field offset: 0x10
		public string summary; //Field offset: 0x18

	}

	private const int MAX_ENTRIES = 80; //Field offset: 0x0
	private const int SUMMARY_MAX_CHARS = 700; //Field offset: 0x0
	private static WsDebugOverlay _instance; //Field offset: 0x0
	private static bool _enabledCached; //Field offset: 0x8
	private static bool _enabledResolved; //Field offset: 0x9
	private readonly List<Entry> _entries; //Field offset: 0x20
	private bool _expanded; //Field offset: 0x28
	private bool _paused; //Field offset: 0x29
	private Vector2 _scroll; //Field offset: 0x2C
	private string _filter; //Field offset: 0x38
	private GUIStyle _entryStyle; //Field offset: 0x40
	private GUIStyle _headerStyle; //Field offset: 0x48

	public WsDebugOverlay() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void AutoInit() { }

	private string BuildHeader() { }

	private static void EnsureInstance() { }

	private void EnsureStyles(float s) { }

	public static bool IsEnabled() { }

	public static void LogIncoming(string type, string rawJson) { }

	public static void LogOutgoing(string type, string rawJson) { }

	private void OnGUI() { }

	private void Push(bool incoming, string type, string rawJson) { }

	public static void SetEnabled(bool on) { }

}

