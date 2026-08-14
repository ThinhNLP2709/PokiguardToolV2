//Type is in global namespace

public class EnergyPurchasePopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public EnergyPurchasePopup <>4__this; //Field offset: 0x10
		public bool userDone; //Field offset: 0x18
		public string error; //Field offset: 0x20
		public bool shopDone; //Field offset: 0x28

		public <>c__DisplayClass24_0() { }

		internal void <LoadDataCoroutine>b__0(UserDTO u) { }

		internal void <LoadDataCoroutine>b__1(string e) { }

		internal void <LoadDataCoroutine>b__2(ShopDataResponse d) { }

		internal void <LoadDataCoroutine>b__3(string e) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		public EnergyPurchasePopup <>4__this; //Field offset: 0x10
		public ShopItemDTO captured; //Field offset: 0x18

		public <>c__DisplayClass27_0() { }

		internal void <BuildPackRow>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public PurchaseResponse response; //Field offset: 0x10
		public bool done; //Field offset: 0x18
		public string error; //Field offset: 0x20

		public <>c__DisplayClass33_0() { }

		internal void <BuyCoroutine>b__0(PurchaseResponse r) { }

		internal void <BuyCoroutine>b__1(string e) { }

	}

	[CompilerGenerated]
	private sealed class <BuyCoroutine>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyPurchasePopup <>4__this; //Field offset: 0x20
		public ShopItemDTO item; //Field offset: 0x28
		private <>c__DisplayClass33_0 <>8__1; //Field offset: 0x30

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
		public <BuyCoroutine>d__33(int <>1__state) { }

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
	private sealed class <LoadDataCoroutine>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyPurchasePopup <>4__this; //Field offset: 0x20
		private <>c__DisplayClass24_0 <>8__1; //Field offset: 0x28

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
		public <LoadDataCoroutine>d__24(int <>1__state) { }

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

	private const string PREFAB_PATH = "UI/EnergyShop/EnergyPurchasePopup"; //Field offset: 0x0
	private static EnergyPurchasePopup _instance; //Field offset: 0x0
	private static Font _gameFont; //Field offset: 0x8
	[Header("Refs (prefab tự wire — chỉnh layout thoải mái, giữ nguyên tên field)")]
	public GameObject canvasRoot; //Field offset: 0x20
	public GameObject panel; //Field offset: 0x28
	public Button backdropButton; //Field offset: 0x30
	public Button btnClose; //Field offset: 0x38
	public Text txtEnergyBalance; //Field offset: 0x40
	public Text txtMoneyBalance; //Field offset: 0x48
	public Text txtMessage; //Field offset: 0x50
	public Transform rowsParent; //Field offset: 0x58
	public GameObject rowTemplate; //Field offset: 0x60
	private UserDTO _user; //Field offset: 0x68
	private readonly List<ShopItemDTO> _energyItems; //Field offset: 0x70
	private readonly List<GameObject> _rows; //Field offset: 0x78
	private bool _isBuying; //Field offset: 0x80
	private Sprite _spPopupBg; //Field offset: 0x88
	private Sprite _spBtnClose; //Field offset: 0x90
	private Sprite _spBtnBuy; //Field offset: 0x98
	private Sprite _spEnergy; //Field offset: 0xA0

	public EnergyPurchasePopup() { }

	[CompilerGenerated]
	private void <Close>b__22_0() { }

	private GameObject BuildPackRow(ShopItemDTO item) { }

	private GameObject BuildRowTemplate(Transform parent) { }

	public void BuildUI() { }

	[IteratorStateMachine(typeof(<BuyCoroutine>d__33))]
	private IEnumerator BuyCoroutine(ShopItemDTO item) { }

	private void ClearRows() { }

	private void Close() { }

	private static GameObject CreateImage(Transform parent, string name, Sprite sprite, Color color) { }

	private static GameObject CreateText(Transform parent, string name, string content, int size, FontStyle style, Color color) { }

	private static Font DefaultFont() { }

	private static string FormatNumber(long n) { }

	private int GetBalanceForCurrency(string currency) { }

	private static Color GetCurrencyColor(string currency) { }

	private static string GetCurrencyDisplayName(string currency) { }

	public static void Hide() { }

	[IteratorStateMachine(typeof(<LoadDataCoroutine>d__24))]
	private IEnumerator LoadDataCoroutine() { }

	private void LoadSprites() { }

	private void OnBuyClicked(ShopItemDTO item) { }

	private void Open() { }

	private static RectTransform Place(GameObject go, Vector2 pos, Vector2 size) { }

	private void RefreshUI() { }

	public static void Show() { }

	private static void StretchFull(GameObject go) { }

	private void WireStaticButtons() { }

}

