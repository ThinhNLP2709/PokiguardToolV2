//Type is in global namespace

[DisallowMultipleComponent]
public class WeaponTabController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__52_0; //Field offset: 0x8
		public static Action<String> <>9__62_1; //Field offset: 0x10
		public static Action<String> <>9__64_1; //Field offset: 0x18
		public static Action<String> <>9__66_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <EquipCo>b__62_1(string err) { }

		internal void <LoadListCo>b__52_0(string err) { }

		internal void <SalvageCo>b__66_1(string err) { }

		internal void <UpgradeCo>b__64_1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public WeaponTabController <>4__this; //Field offset: 0x10
		public UserWeaponDTO captured; //Field offset: 0x18

		public <>c__DisplayClass55_0() { }

		internal void <BindItem>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass62_0
	{
		public WeaponTabController <>4__this; //Field offset: 0x10
		public bool unequip; //Field offset: 0x18

		public <>c__DisplayClass62_0() { }

		internal void <EquipCo>b__0(WeaponActionResponse resp) { }

	}

	[CompilerGenerated]
	private sealed class <EquipCo>d__62 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponTabController <>4__this; //Field offset: 0x20
		public bool unequip; //Field offset: 0x28
		public long userWeaponId; //Field offset: 0x30

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
		public <EquipCo>d__62(int <>1__state) { }

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
	private sealed class <LoadListCo>d__52 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponTabController <>4__this; //Field offset: 0x20

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
		public <LoadListCo>d__52(int <>1__state) { }

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
	private sealed class <SalvageCo>d__66 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponTabController <>4__this; //Field offset: 0x20
		public long userWeaponId; //Field offset: 0x28

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
		public <SalvageCo>d__66(int <>1__state) { }

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
	private sealed class <UpgradeCo>d__64 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeaponTabController <>4__this; //Field offset: 0x20
		public long userWeaponId; //Field offset: 0x28

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
		public <UpgradeCo>d__64(int <>1__state) { }

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

	private const int PAGE_SIZE = 8; //Field offset: 0x0
	private static readonly Color ColorAtk; //Field offset: 0x0
	private const float SALVAGE_CONFIRM_SEC = 4; //Field offset: 0x0
	private static readonly Color ColorHp; //Field offset: 0x10
	private static readonly Color ColorMana; //Field offset: 0x20
	private static readonly Color ColorCrit; //Field offset: 0x30
	private static readonly Color ColorPower; //Field offset: 0x40
	private static readonly Color ColorStar; //Field offset: 0x50
	private static readonly Color ColorShard; //Field offset: 0x60
	private static readonly Color ColorGood; //Field offset: 0x70
	private static readonly Color ColorBad; //Field offset: 0x80
	private static readonly Color ColorWarn; //Field offset: 0x90
	private static readonly Color ColorMuted; //Field offset: 0xA0
	[Header("Root")]
	public GameObject panelWeapon; //Field offset: 0x20
	[Header("Danh sách kho (grid) — itemTemplate PHẢI inactive")]
	public Transform gridContent; //Field offset: 0x28
	public GameObject itemTemplate; //Field offset: 0x30
	[Header("Phân trang")]
	public Button btnPrevPage; //Field offset: 0x38
	public Button btnNextPage; //Field offset: 0x40
	public Text txtPageInfo; //Field offset: 0x48
	[Header("Mảnh vũ khí")]
	public Text txtShardCount; //Field offset: 0x50
	public Image imgShardIcon; //Field offset: 0x58
	[Header("Khung chi tiết")]
	public Image imgDetailIcon; //Field offset: 0x60
	public Image imgDetailFrame; //Field offset: 0x68
	public Text txtDetailName; //Field offset: 0x70
	public Text txtDetailRarity; //Field offset: 0x78
	public Text txtDetailStar; //Field offset: 0x80
	public Text txtDetailStats; //Field offset: 0x88
	public Text txtDetailPower; //Field offset: 0x90
	public Text txtDetailSource; //Field offset: 0x98
	public Text txtDetailElement; //Field offset: 0xA0
	[Header("Nút thao tác")]
	public Button btnEquip; //Field offset: 0xA8
	public Text txtEquipLabel; //Field offset: 0xB0
	public Button btnUpgrade; //Field offset: 0xB8
	public Text txtUpgradeLabel; //Field offset: 0xC0
	public Button btnSalvage; //Field offset: 0xC8
	public Text txtSalvageLabel; //Field offset: 0xD0
	private int _userId; //Field offset: 0xD8
	private int _page; //Field offset: 0xDC
	private int _totalPages; //Field offset: 0xE0
	private int _shardCount; //Field offset: 0xE4
	private long _equippedId; //Field offset: 0xE8
	private bool _busy; //Field offset: 0xF0
	private readonly List<UserWeaponDTO> _weapons; //Field offset: 0xF8
	private readonly List<GameObject> _spawned; //Field offset: 0x100
	private UserWeaponDTO _selected; //Field offset: 0x108
	private bool _salvagePending; //Field offset: 0x110
	private float _salvagePendingUntil; //Field offset: 0x114

	private static WeaponTabController() { }

	public WeaponTabController() { }

	[CompilerGenerated]
	private void <Awake>b__48_0() { }

	[CompilerGenerated]
	private void <Awake>b__48_1() { }

	[CompilerGenerated]
	private void <SalvageCo>b__66_0(WeaponSalvageResponse resp) { }

	[CompilerGenerated]
	private void <UpgradeCo>b__64_0(WeaponUpgradeResponse resp) { }

	private void Awake() { }

	private void BindItem(GameObject go, UserWeaponDTO w) { }

	private void ChangePage(int delta) { }

	public void CloseTab() { }

	[IteratorStateMachine(typeof(<EquipCo>d__62))]
	private IEnumerator EquipCo(long userWeaponId, bool unequip) { }

	private static T FindDeep(Transform root, string nodeName) { }

	private static GameObject FindDeepGo(Transform root, string nodeName) { }

	private static string Hex(Color c) { }

	[IteratorStateMachine(typeof(<LoadListCo>d__52))]
	private IEnumerator LoadListCo() { }

	private void NotifyEquipChanged(int imageId, string rarity, int star) { }

	private void OnDisable() { }

	private void OnEquipClicked() { }

	private void OnListLoaded(WeaponListResponse resp) { }

	private void OnSalvageClicked() { }

	private void OnUpgradeClicked() { }

	public void OpenTab() { }

	private void Reload() { }

	private void RenderGrid() { }

	private void ResetSalvageConfirm() { }

	[IteratorStateMachine(typeof(<SalvageCo>d__66))]
	private IEnumerator SalvageCo(long userWeaponId) { }

	private void SetBusy(bool busy) { }

	private void ShowDetail(UserWeaponDTO w) { }

	private void UpdateActionButtons() { }

	private void UpdatePageUI() { }

	private void UpdateShardText() { }

	[IteratorStateMachine(typeof(<UpgradeCo>d__64))]
	private IEnumerator UpgradeCo(long userWeaponId) { }

}

