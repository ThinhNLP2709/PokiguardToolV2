//Type is in global namespace

[DisallowMultipleComponent]
public class MatchTeamMemberSlotUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <TweenBarCo>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Slider slider; //Field offset: 0x20
		public float target; //Field offset: 0x28
		public MatchTeamMemberSlotUI <>4__this; //Field offset: 0x30
		private float <start>5__2; //Field offset: 0x38
		private float <elapsed>5__3; //Field offset: 0x3C

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
		public <TweenBarCo>d__25(int <>1__state) { }

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

	private const float BAR_TWEEN_SEC = 0.15; //Field offset: 0x0
	[SerializeField]
	private Slider sliderHp; //Field offset: 0x20
	[SerializeField]
	private Slider sliderMana; //Field offset: 0x28
	[SerializeField]
	private Slider sliderPower; //Field offset: 0x30
	[SerializeField]
	private Text textHp; //Field offset: 0x38
	[SerializeField]
	private Text textMana; //Field offset: 0x40
	[SerializeField]
	private Text textPower; //Field offset: 0x48
	[SerializeField]
	private Image portraitImage; //Field offset: 0x50
	[SerializeField]
	private GameObject yourTurnRoot; //Field offset: 0x58
	[SerializeField]
	private WeaponBadgeUI weaponBadge; //Field offset: 0x60
	[CompilerGenerated]
	private int <BoundActor>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private bool <MaskHpText>k__BackingField; //Field offset: 0x6C
	private readonly Dictionary<Slider, Coroutine> _barTweens; //Field offset: 0x70

	public private int BoundActor
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public bool MaskHpText
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public MatchTeamMemberSlotUI() { }

	private void Awake() { }

	public void BindActor(int actorNumber) { }

	private static Transform FindDeepChild(Transform parent, string name) { }

	private static Slider FindSlider(Transform root, string childName) { }

	private static Text FindText(Transform root, string childName) { }

	[CompilerGenerated]
	public int get_BoundActor() { }

	[CompilerGenerated]
	public bool get_MaskHpText() { }

	private static Image ResolvePortraitImage(Transform root) { }

	private static GameObject ResolveYourTurn(Transform root) { }

	[CompilerGenerated]
	private void set_BoundActor(int value) { }

	[CompilerGenerated]
	public void set_MaskHpText(bool value) { }

	public void SetBars(int curHp, int maxHp, int curMana, int maxMana, int curPow, int maxPow) { }

	public void SetDeadState(bool isDead) { }

	public void SetPortrait(Sprite sprite) { }

	public void SetWeapon(int imageId, string rarity, long userId) { }

	public void SetYourTurnVisible(bool visible) { }

	private void TweenBar(Slider slider, int value, int max) { }

	[IteratorStateMachine(typeof(<TweenBarCo>d__25))]
	private IEnumerator TweenBarCo(Slider slider, float target) { }

}

