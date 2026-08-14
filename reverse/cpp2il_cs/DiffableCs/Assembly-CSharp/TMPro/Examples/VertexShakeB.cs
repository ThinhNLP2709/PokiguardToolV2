namespace TMPro.Examples;

public class VertexShakeB : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AnimateVertexColors>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VertexShakeB <>4__this; //Field offset: 0x20
		private TMP_TextInfo <textInfo>5__2; //Field offset: 0x28
		private Vector3[][] <copyOfVertices>5__3; //Field offset: 0x30

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

	public VertexShakeB() { }

	[IteratorStateMachine(typeof(<AnimateVertexColors>d__10))]
	private IEnumerator AnimateVertexColors() { }

	private void Awake() { }

	private void ON_TEXT_CHANGED(object obj) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void Start() { }

}

