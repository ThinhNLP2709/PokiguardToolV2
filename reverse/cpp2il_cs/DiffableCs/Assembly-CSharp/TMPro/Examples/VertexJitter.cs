namespace TMPro.Examples;

public class VertexJitter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AnimateVertexColors>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VertexJitter <>4__this; //Field offset: 0x20
		private TMP_TextInfo <textInfo>5__2; //Field offset: 0x28
		private int <loopCount>5__3; //Field offset: 0x30
		private VertexAnim[] <vertexAnim>5__4; //Field offset: 0x38
		private TMP_MeshInfo[] <cachedMeshInfo>5__5; //Field offset: 0x40

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
		public <AnimateVertexColors>d__11(int <>1__state) { }

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

	private struct VertexAnim
	{
		public float angleRange; //Field offset: 0x0
		public float angle; //Field offset: 0x4
		public float speed; //Field offset: 0x8

	}

	public float AngleMultiplier; //Field offset: 0x20
	public float SpeedMultiplier; //Field offset: 0x24
	public float CurveScale; //Field offset: 0x28
	private TMP_Text m_TextComponent; //Field offset: 0x30
	private bool hasTextChanged; //Field offset: 0x38

	public VertexJitter() { }

	[IteratorStateMachine(typeof(<AnimateVertexColors>d__11))]
	private IEnumerator AnimateVertexColors() { }

	private void Awake() { }

	private void ON_TEXT_CHANGED(object obj) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void Start() { }

}

