//Type is in global namespace

[DisallowMultipleComponent]
public class CardDisabledClickHint : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public RectTransform rt; //Field offset: 0x10
		public float x; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <PlayDeniedShake>b__0(float v) { }

		internal void <PlayDeniedShake>b__1() { }

	}

	private const float THROTTLE_SEC = 1; //Field offset: 0x0
	private static float _lastHintAt; //Field offset: 0x0
	private Button _btn; //Field offset: 0x20
	private CardUI _cardUI; //Field offset: 0x28
	private CardUIPVP _cardUIPvp; //Field offset: 0x30
	private float _baseLocalX; //Field offset: 0x38
	private bool _baseCaptured; //Field offset: 0x3C

	private static CardDisabledClickHint() { }

	public CardDisabledClickHint() { }

	private void Awake() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PlayDeniedShake() { }

}

