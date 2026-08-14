//Type is in global namespace

public class ChinhPhucDataService : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public List<GroupDTO> result; //Field offset: 0x10
		public string err; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <LoadCoroutine>b__0(List<GroupDTO> data) { }

		internal void <LoadCoroutine>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <LoadCoroutine>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChinhPhucDataService <>4__this; //Field offset: 0x20
		private <>c__DisplayClass21_0 <>8__1; //Field offset: 0x28

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
		public <LoadCoroutine>d__21(int <>1__state) { }

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
	private static ChinhPhucDataService <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private List<GroupDTO> <Data>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <IsLoading>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Action OnDataChanged; //Field offset: 0x30
	private bool _pendingForceRefresh; //Field offset: 0x38

	public event Action OnDataChanged
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public private List<GroupDTO> Data
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private static ChinhPhucDataService Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public private bool IsLoading
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public ChinhPhucDataService() { }

	[CompilerGenerated]
	public void add_OnDataChanged(Action value) { }

	private void Awake() { }

	public static ChinhPhucDataService EnsureInstance() { }

	[CompilerGenerated]
	public List<GroupDTO> get_Data() { }

	[CompilerGenerated]
	public static ChinhPhucDataService get_Instance() { }

	[CompilerGenerated]
	public bool get_IsLoading() { }

	public void Invalidate() { }

	[IteratorStateMachine(typeof(<LoadCoroutine>d__21))]
	private IEnumerator LoadCoroutine() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void remove_OnDataChanged(Action value) { }

	public void RequestLoad(bool forceRefresh = false) { }

	[CompilerGenerated]
	private void set_Data(List<GroupDTO> value) { }

	[CompilerGenerated]
	private static void set_Instance(ChinhPhucDataService value) { }

	[CompilerGenerated]
	private void set_IsLoading(bool value) { }

}

