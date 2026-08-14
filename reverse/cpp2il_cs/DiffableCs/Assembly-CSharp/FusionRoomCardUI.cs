//Type is in global namespace

[DisallowMultipleComponent]
public class FusionRoomCardUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__25_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <InstallRoomAutoPush>b__25_0(string _) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public FusionRoomCardUI <>4__this; //Field offset: 0x10
		public float aMin; //Field offset: 0x18
		public float aMax; //Field offset: 0x1C

		public <>c__DisplayClass18_0() { }

		internal void <RefreshState>b__0(float k) { }

	}

	[CompilerGenerated]
	private sealed class <PushWhenReady>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private float <deadline>5__2; //Field offset: 0x20

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
		public <PushWhenReady>d__15(int <>1__state) { }

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

	public const string NODE_NAME = "cardFusionRoom"; //Field offset: 0x0
	public const string PREFAB_PATH = "Prefabs/UI/CardFusionRoom"; //Field offset: 0x0
	private static bool _autoPushInstalled; //Field offset: 0x0
	[SerializeField]
	private Image imgGlow; //Field offset: 0x20
	[SerializeField]
	private Image imgtCard; //Field offset: 0x28
	[SerializeField]
	private Image imgFusionPet; //Field offset: 0x30
	[SerializeField]
	private Text txtLabel; //Field offset: 0x38
	[SerializeField]
	private Text txtHint; //Field offset: 0x40
	private Color _labelBase; //Field offset: 0x48
	private float _glowBaseAlpha; //Field offset: 0x58
	private bool _baseCaptured; //Field offset: 0x5C
	private string _noticedReason; //Field offset: 0x60
	private string _hintBase; //Field offset: 0x68
	private Color _hintBaseColor; //Field offset: 0x70

	public FusionRoomCardUI() { }

	private static void AnchorBottom(GameObject go, float y, float height) { }

	private void AutoFindRefs() { }

	private void Awake() { }

	public void BuildHierarchy() { }

	private void CaptureBaseState() { }

	private static void Center(GameObject go, Vector2 offset, Vector2 size) { }

	public static FusionRoomCardUI Ensure(Transform listParent, GameObject sizeTemplate) { }

	private void EnsureClickable() { }

	private Transform FindDeep(string nodeName) { }

	private GameObject FindOrCreate(string name) { }

	private Text FindOrCreateText(string name, string content, Font font, int fontSize, Color color) { }

	private static Image GetOrAddImage(GameObject go) { }

	private static void InstallRoomAutoPush() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnRoomStatesChanged() { }

	[IteratorStateMachine(typeof(<PushWhenReady>d__15))]
	private IEnumerator PushWhenReady() { }

	private void RefreshState() { }

	private static void StretchCenter(GameObject go, float scale) { }

}

