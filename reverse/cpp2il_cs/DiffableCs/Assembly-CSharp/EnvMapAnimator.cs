//Type is in global namespace

public class EnvMapAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnvMapAnimator <>4__this; //Field offset: 0x20
		private Matrix4x4 <matrix>5__2; //Field offset: 0x28

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
		public <Start>d__4(int <>1__state) { }

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

	public Vector3 RotationSpeeds; //Field offset: 0x20
	private TMP_Text m_textMeshPro; //Field offset: 0x30
	private Material m_material; //Field offset: 0x38

	public EnvMapAnimator() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Start>d__4))]
	private IEnumerator Start() { }

}

