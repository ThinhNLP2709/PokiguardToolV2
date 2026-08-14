//Type is in global namespace

public class UIPanelManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadAndOpen>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string panelKey; //Field offset: 0x20
		public Action<GameObject> onReady; //Field offset: 0x28
		public UIPanelManager <>4__this; //Field offset: 0x30
		private ResourceRequest <req>5__2; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <LoadAndOpen>d__11(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static UIPanelManager <Instance>k__BackingField; //Field offset: 0x0
	private const string PREFAB_ROOT = "UIPanels/"; //Field offset: 0x0
	public Transform panelRoot; //Field offset: 0x20
	private readonly Dictionary<String, GameObject> _cache; //Field offset: 0x28
	private readonly List<String> _openOrder; //Field offset: 0x30

	public bool AnyPanelOpen
	{
		 get { } //Length: 297
	}

	public private static UIPanelManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public UIPanelManager() { }

	private void Awake() { }

	public void Close(string panelKey, bool destroy = false) { }

	public bool CloseTop() { }

	public static UIPanelManager EnsureInstance() { }

	public static Transform FindDeep(Transform root, string name) { }

	public bool get_AnyPanelOpen() { }

	[CompilerGenerated]
	public static UIPanelManager get_Instance() { }

	public bool IsOpen(string panelKey) { }

	[IteratorStateMachine(typeof(<LoadAndOpen>d__11))]
	private IEnumerator LoadAndOpen(string panelKey, Action<GameObject> onReady) { }

	public void Open(string panelKey, Action<GameObject> onReady = null, Transform parent = null) { }

	private Transform ResolvePanelRoot() { }

	[CompilerGenerated]
	private static void set_Instance(UIPanelManager value) { }

	private void TrackOpen(string panelKey) { }

	public void UnloadAll() { }

}

