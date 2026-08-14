//Type is in global namespace

[DisallowMultipleComponent]
public class WeaponDropPopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public WeaponDropPopup <>4__this; //Field offset: 0x10
		public Vector3 basePos; //Field offset: 0x18

		public <>c__DisplayClass45_0() { }

		internal void <PlayRevealFx>b__0(float t) { }

		internal void <PlayRevealFx>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <WatchdogCo>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponDropPopup <>4__this; //Field offset: 0x20

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
		public <WatchdogCo>d__40(int <>1__state) { }

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

	public const string PREFAB_PATH = "Prefabs/UI/WeaponDropPopup"; //Field offset: 0x0
	private const float DISMISS_DELAY_SEC = 0.6; //Field offset: 0x0
	private static WeaponDropPopup _instance; //Field offset: 0x0
	private const float WATCHDOG_SEC = 12; //Field offset: 0x0
	private static readonly Queue<WeaponDropDTO> _pending; //Field offset: 0x8
	private static int _batchIndex; //Field offset: 0x10
	private static int _batchTotal; //Field offset: 0x14
	[SerializeField]
	private RectTransform panel; //Field offset: 0x20
	[SerializeField]
	private Image imgGlow; //Field offset: 0x28
	[SerializeField]
	private Image imgTwinkle1; //Field offset: 0x30
	[SerializeField]
	private Image imgTwinkle2; //Field offset: 0x38
	[SerializeField]
	private Image imgCircle; //Field offset: 0x40
	[SerializeField]
	private Image imgWeapon; //Field offset: 0x48
	[SerializeField]
	private Text txtTitle; //Field offset: 0x50
	[SerializeField]
	private Text txtName; //Field offset: 0x58
	[SerializeField]
	private Text txtRarity; //Field offset: 0x60
	[SerializeField]
	private Text txtStats; //Field offset: 0x68
	[SerializeField]
	private Text txtNote; //Field offset: 0x70
	[SerializeField]
	private Button btnClaim; //Field offset: 0x78
	private CanvasGroup _group; //Field offset: 0x80
	private Button _btnDim; //Field offset: 0x88
	private bool _wired; //Field offset: 0x90
	private bool _showing; //Field offset: 0x91
	private bool _canDismiss; //Field offset: 0x92
	private int _shakeTweenId; //Field offset: 0x94
	private Coroutine _watchdog; //Field offset: 0x98
	private WeaponDropDTO _current; //Field offset: 0xA0
	private Vector3 _panelBaseScale; //Field offset: 0xA8
	private Vector3 _panelBasePos; //Field offset: 0xB4

	private static WeaponDropPopup() { }

	public WeaponDropPopup() { }

	[CompilerGenerated]
	private void <ClosePopup>b__48_0() { }

	private void Awake() { }

	public void BuildHierarchy() { }

	private void CancelFx() { }

	private void ClosePopup() { }

	private void EnsureWired() { }

	private static string FallbackText(WeaponDropDTO d) { }

	private void Fill(WeaponDropDTO drop) { }

	private static T FindDeep(Transform root, string nodeName) { }

	private static void MakeCenterImage(Transform parent, string name, Vector2 pos, Vector2 size, string uiSprite) { }

	private static Text MakeText(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta, TextAnchor align) { }

	private static GameObject NewChild(Transform parent, string name) { }

	private void OnDestroy() { }

	private void OnDimClicked() { }

	private void OnDisable() { }

	private void OpenPanel() { }

	private void PlayRevealFx(WeaponDropDTO drop) { }

	private void Present(WeaponDropDTO drop) { }

	private void PulseTwinkle(Image img, float delay) { }

	private void RefreshTitle() { }

	private static WeaponDropPopup Resolve() { }

	private void RestartWatchdog() { }

	public static void Show(WeaponDropDTO drop) { }

	private void StopWatchdog() { }

	private static string TitleText(WeaponDropDTO drop) { }

	private void Update() { }

	[IteratorStateMachine(typeof(<WatchdogCo>d__40))]
	private IEnumerator WatchdogCo() { }

}

