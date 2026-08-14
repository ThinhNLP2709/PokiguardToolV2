namespace TMPro.Examples;

public class Benchmark01_UGUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Benchmark01_UGUI <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <Start>d__10(int <>1__state) { }

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

	private const string label01 = "The <#0050FF>count is: </color>"; //Field offset: 0x0
	private const string label02 = "The <color=#0050FF>count is: </color>"; //Field offset: 0x0
	public int BenchmarkType; //Field offset: 0x20
	public Canvas canvas; //Field offset: 0x28
	public TMP_FontAsset TMProFont; //Field offset: 0x30
	public Font TextMeshFont; //Field offset: 0x38
	private TextMeshProUGUI m_textMeshPro; //Field offset: 0x40
	private Text m_textMesh; //Field offset: 0x48
	private Material m_material01; //Field offset: 0x50
	private Material m_material02; //Field offset: 0x58

	public Benchmark01_UGUI() { }

	[IteratorStateMachine(typeof(<Start>d__10))]
	private IEnumerator Start() { }

}

