namespace TMPro.Examples;

public class VertexZoom : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public List<Single> modifiedCharScale; //Field offset: 0x10
		public Comparison<Int32> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal int <AnimateVertexColors>b__0(int a, int b) { }

	}

	[CompilerGenerated]
	private sealed class <AnimateVertexColors>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VertexZoom <>4__this; //Field offset: 0x20
		private <>c__DisplayClass10_0 <>8__1; //Field offset: 0x28
		private TMP_TextInfo <textInfo>5__2; //Field offset: 0x30
		private TMP_MeshInfo[] <cachedMeshInfoVertexData>5__3; //Field offset: 0x38
		private List<Int32> <scaleSortingOrder>5__4; //Field offset: 0x40

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
		public <AnimateVertexColors>d__10(int <>1__state) { }

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

	public float AngleMultiplier; //Field offset: 0x20
	public float SpeedMultiplier; //Field offset: 0x24
	public float CurveScale; //Field offset: 0x28
	private TMP_Text m_TextComponent; //Field offset: 0x30
	private bool hasTextChanged; //Field offset: 0x38

	public VertexZoom() { }

	[IteratorStateMachine(typeof(<AnimateVertexColors>d__10))]
	private IEnumerator AnimateVertexColors() { }

	private void Awake() { }

	private void ON_TEXT_CHANGED(object obj) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void Start() { }

}

