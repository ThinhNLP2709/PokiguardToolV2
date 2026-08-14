//Type is in global namespace

public static class SpecialCardFx
{
	[CompilerGenerated]
	private sealed class <PlayCenterCard>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Sprite art; //Field offset: 0x20
		private GameObject <go>5__2; //Field offset: 0x28
		private CanvasGroup <cg>5__3; //Field offset: 0x30

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
		public <PlayCenterCard>d__11(int <>1__state) { }

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

	private const string CANVAS_NAME = "CardAnimationCanvas"; //Field offset: 0x0
	private const string ART_NODE = "imgtCard"; //Field offset: 0x0
	private static readonly Vector2 CARD_SIZE; //Field offset: 0x0
	public const float CENTER_CARD_SCALE = 2; //Field offset: 0x0
	private const float SCALE_IN_SEC = 0.4; //Field offset: 0x0
	private const float HOLD_SEC = 0.9; //Field offset: 0x0
	private const float FADE_SEC = 0.25; //Field offset: 0x0
	private static readonly Vector2 CARD_ANCHORED_POS; //Field offset: 0x8
	private static Sprite _fusionArt; //Field offset: 0x10
	private static bool _fusionArtProbed; //Field offset: 0x18

	private static SpecialCardFx() { }

	private static Canvas EnsureAnimationCanvas() { }

	public static Sprite LoadFusionCardArt() { }

	[IteratorStateMachine(typeof(<PlayCenterCard>d__11))]
	public static IEnumerator PlayCenterCard(Sprite art) { }

}

