//Type is in global namespace

public class CardFight : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DisableOnAnimationAfterPlay>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CardFight <>4__this; //Field offset: 0x20

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
		public <DisableOnAnimationAfterPlay>d__18(int <>1__state) { }

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
	private sealed class <ProcessCardEffect>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CardFight <>4__this; //Field offset: 0x20
		public int cardID; //Field offset: 0x28
		public int level; //Field offset: 0x2C
		private int <value>5__2; //Field offset: 0x30

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
		public <ProcessCardEffect>d__13(int <>1__state) { }

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
	private sealed class <ShowCardEffect>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int cardID; //Field offset: 0x20
		public CardFight <>4__this; //Field offset: 0x28
		public int level; //Field offset: 0x30

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
		public <ShowCardEffect>d__15(int <>1__state) { }

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

	[Header("Cài đặt sinh card")]
	public GameObject cardPrefab; //Field offset: 0x20
	public Transform cardParent; //Field offset: 0x28
	public int cardCount; //Field offset: 0x30
	[Header("ID hình cho từng card (1 = HP, 2 = Mana, 3 = No, 4 = dameCard)")]
	private List<Int32> cardIDs; //Field offset: 0x38
	[Header("Animation References")]
	public GameObject onAnimationCardObject; //Field offset: 0x40
	[Header("Cấp độ cho card ID 4 (DameCard)")]
	[Range(1, 10)]
	public int dameCardLevel; //Field offset: 0x48
	[Header("UI References")]
	public Active active; //Field offset: 0x50
	public Board board; //Field offset: 0x58
	private List<GameObject> spawnedCards; //Field offset: 0x60
	public Animator cardAnimator; //Field offset: 0x68

	public CardFight() { }

	public void ActivateOnAnimationCard(int level) { }

	[IteratorStateMachine(typeof(<DisableOnAnimationAfterPlay>d__18))]
	private IEnumerator DisableOnAnimationAfterPlay() { }

	public void GenerateCards() { }

	private string GetSpriteNameById(int id) { }

	public void HandleCardEffect(int cardID, int level) { }

	public void OnNewTurn() { }

	private void OnValidate() { }

	public void playAnimationCard() { }

	[IteratorStateMachine(typeof(<ProcessCardEffect>d__13))]
	private IEnumerator ProcessCardEffect(int cardID, int level) { }

	[IteratorStateMachine(typeof(<ShowCardEffect>d__15))]
	private IEnumerator ShowCardEffect(int cardID, int level = 1) { }

	private void Start() { }

}

