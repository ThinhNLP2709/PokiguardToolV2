//Type is in global namespace

[DisallowMultipleComponent]
public class WeaponTooltip : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public WeaponTooltip <>4__this; //Field offset: 0x10
		public long targetUserId; //Field offset: 0x18

		public <>c__DisplayClass29_0() { }

		internal void <FetchEquipped>b__0(EquippedWeaponResponse resp) { }

		internal void <FetchEquipped>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <FetchEquipped>d__29 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponTooltip <>4__this; //Field offset: 0x20
		public long targetUserId; //Field offset: 0x28

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
		public <FetchEquipped>d__29(int <>1__state) { }

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

	public const string PREFAB_PATH = "Prefabs/UI/WeaponTooltip"; //Field offset: 0x0
	private static WeaponTooltip _instance; //Field offset: 0x0
	[SerializeField]
	private RectTransform panel; //Field offset: 0x20
	[SerializeField]
	private Button btnBlocker; //Field offset: 0x28
	[SerializeField]
	private Button btnClose; //Field offset: 0x30
	[SerializeField]
	private Image imgIcon; //Field offset: 0x38
	[SerializeField]
	private Text txtName; //Field offset: 0x40
	[SerializeField]
	private Text txtRarity; //Field offset: 0x48
	[SerializeField]
	private Text txtStar; //Field offset: 0x50
	[SerializeField]
	private Text txtStats; //Field offset: 0x58
	[SerializeField]
	private Text txtElement; //Field offset: 0x60
	[SerializeField]
	private Text txtPower; //Field offset: 0x68
	[SerializeField]
	private Text txtSource; //Field offset: 0x70
	private CanvasGroup _panelGroup; //Field offset: 0x78
	private Coroutine _fetchCo; //Field offset: 0x80
	private bool _wired; //Field offset: 0x88

	public WeaponTooltip() { }

	[CompilerGenerated]
	private void <ClosePanel>b__25_0() { }

	private void Awake() { }

	public void BuildHierarchy() { }

	private void ClosePanel() { }

	private static GameObject CreateChild(Transform parent, string name) { }

	private static void CreateIcon(Transform parent, string name, Vector2 pos, Vector2 size) { }

	private static Text CreateLabel(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta) { }

	private void EnsureWired() { }

	[IteratorStateMachine(typeof(<FetchEquipped>d__29))]
	private IEnumerator FetchEquipped(long targetUserId) { }

	private void Fill(string name, string rarity, int star, int imageId, int atk, int hp, int mana, int crit, int resist, int rate, string element, int power, string source) { }

	private static T FindDeep(Transform root, string nodeName) { }

	private static GameObject FindOrCreate(Transform parent, string name) { }

	public static void HideTooltip() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void PositionNear(RectTransform anchor) { }

	private void Present(RectTransform anchor) { }

	private static WeaponTooltip Resolve() { }

	public static void Show(RectTransform anchor, EquippedWeaponResponse data) { }

	public static void Show(RectTransform anchor, UserWeaponDTO data) { }

	public static void ShowForUser(RectTransform anchor, long targetUserId) { }

	private static string Summarize(string name, string rarity, int star, int power) { }

}

