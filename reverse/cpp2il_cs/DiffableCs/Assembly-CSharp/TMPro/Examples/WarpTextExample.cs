namespace TMPro.Examples;

public class WarpTextExample : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WarpText>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WarpTextExample <>4__this; //Field offset: 0x20
		private float <old_CurveScale>5__2; //Field offset: 0x28
		private AnimationCurve <old_curve>5__3; //Field offset: 0x30

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
		public <WarpText>d__8(int <>1__state) { }

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

	private TMP_Text m_TextComponent; //Field offset: 0x20
	public AnimationCurve VertexCurve; //Field offset: 0x28
	public float AngleMultiplier; //Field offset: 0x30
	public float SpeedMultiplier; //Field offset: 0x34
	public float CurveScale; //Field offset: 0x38

	public WarpTextExample() { }

	private void Awake() { }

	private AnimationCurve CopyAnimationCurve(AnimationCurve curve) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WarpText>d__8))]
	private IEnumerator WarpText() { }

}

