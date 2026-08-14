//Type is in global namespace

[DisallowMultipleComponent]
public class PetShardTabController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_0
	{
		public PetShardDTO captured; //Field offset: 0x10
		public PetShardTabController <>4__this; //Field offset: 0x18

		public <>c__DisplayClass48_0() { }

		internal void <RenderPage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_1
	{
		public PetShardDTO capturedEx; //Field offset: 0x10
		public PetShardItemUI capturedCell; //Field offset: 0x18
		public PetShardTabController <>4__this; //Field offset: 0x20

		public <>c__DisplayClass48_1() { }

		internal void <RenderPage>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public PetShardTabController <>4__this; //Field offset: 0x10
		public PetShardDTO dto; //Field offset: 0x18
		public PetShardItemUI cell; //Field offset: 0x20

		public <>c__DisplayClass66_0() { }

		internal void <ExchangeCo>b__0(PetExchangeResponse resp) { }

		internal void <ExchangeCo>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass68_0
	{
		public Image piece; //Field offset: 0x10
		public Color pieceHome; //Field offset: 0x18
		public GameObject petGo; //Field offset: 0x28

		public <>c__DisplayClass68_0() { }

		internal void <SuccessFxThenReload>b__0(float v) { }

		internal void <SuccessFxThenReload>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public RectTransform rt; //Field offset: 0x10
		public Vector3 home; //Field offset: 0x18

		public <>c__DisplayClass72_0() { }

		internal void <ShakeCell>b__0(float t) { }

		internal void <ShakeCell>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ExchangeCo>d__66 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PetShardTabController <>4__this; //Field offset: 0x20
		public PetShardDTO dto; //Field offset: 0x28
		public PetShardItemUI cell; //Field offset: 0x30

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
		public <ExchangeCo>d__66(int <>1__state) { }

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
	private sealed class <LoadCo>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PetShardTabController <>4__this; //Field offset: 0x20

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
		public <LoadCo>d__44(int <>1__state) { }

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
	private sealed class <SuccessFxThenReload>d__68 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PetShardItemUI cell; //Field offset: 0x20
		private <>c__DisplayClass68_0 <>8__1; //Field offset: 0x28
		public PetShardTabController <>4__this; //Field offset: 0x30

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
		public <SuccessFxThenReload>d__68(int <>1__state) { }

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

	private const int MAX_APPEAR_TWEEN = 8; //Field offset: 0x0
	private const int PAGE_SIZE = 8; //Field offset: 0x0
	[Header("Root")]
	public GameObject panelShard; //Field offset: 0x20
	[Header("Lưới mảnh — itemTemplate PHẢI inactive")]
	public Transform gridContent; //Field offset: 0x28
	public GameObject itemTemplate; //Field offset: 0x30
	[Header("Trạng thái rỗng")]
	public Text txtEmpty; //Field offset: 0x38
	[Header("Tổng quan")]
	public Text txtSummary; //Field offset: 0x40
	[Header("Phân trang — 2 nút null ⇒ tab chạy chế độ cũ (hiện tất cả, không phân trang)")]
	public Button btnPrevPage; //Field offset: 0x48
	public Button btnNextPage; //Field offset: 0x50
	public Text txtPageInfo; //Field offset: 0x58
	[Header("Lọc nhanh")]
	public Button btnFilterReady; //Field offset: 0x60
	public Text txtFilterLabel; //Field offset: 0x68
	[Header("Popup xác nhận ĐỔI PET — inactive mặc định, null ⇒ đổi thẳng không hỏi")]
	public GameObject panelConfirm; //Field offset: 0x70
	public Transform confirmFrame; //Field offset: 0x78
	public Text txtConfirm; //Field offset: 0x80
	public Image imgPetConfirm; //Field offset: 0x88
	public Button btnConfirmYes; //Field offset: 0x90
	public Button btnConfirmNo; //Field offset: 0x98
	private int _userId; //Field offset: 0xA0
	private int _maxStar; //Field offset: 0xA4
	private bool _wired; //Field offset: 0xA8
	private bool _loading; //Field offset: 0xA9
	private int _exchangeCost; //Field offset: 0xAC
	private int _page; //Field offset: 0xB0
	private int _readyCount; //Field offset: 0xB4
	private int _upgradeCount; //Field offset: 0xB8
	private int _exchangeCount; //Field offset: 0xBC
	private int _totalShards; //Field offset: 0xC0
	private bool _filterReady; //Field offset: 0xC4
	private bool _exchanging; //Field offset: 0xC5
	private PetShardDTO _pendingDto; //Field offset: 0xC8
	private PetShardItemUI _pendingCell; //Field offset: 0xD0
	private readonly List<PetShardDTO> _sorted; //Field offset: 0xD8
	private readonly List<PetShardItemUI> _pool; //Field offset: 0xE0
	private readonly List<CanvasGroup> _poolCg; //Field offset: 0xE8
	private readonly List<Button> _poolBtn; //Field offset: 0xF0
	private ShardSwipePager _swipe; //Field offset: 0xF8

	private bool HasPagination
	{
		private get { } //Length: 142
	}

	public PetShardTabController() { }

	[CompilerGenerated]
	private void <LoadCo>b__44_0(string err) { }

	[CompilerGenerated]
	private void <WireOnce>b__40_0() { }

	[CompilerGenerated]
	private void <WireOnce>b__40_1() { }

	[CompilerGenerated]
	private void <WireOnce>b__40_2() { }

	[CompilerGenerated]
	private void <WireOnce>b__40_3() { }

	private static void AnimateAppear(GameObject go, int slot) { }

	private void Awake() { }

	private static void CancelButtonTween(Button btn) { }

	private bool CanExchange(PetShardDTO dto) { }

	private void ChangePage(int delta) { }

	public void CloseTab() { }

	private void EnsurePool(int target) { }

	[IteratorStateMachine(typeof(<ExchangeCo>d__66))]
	private IEnumerator ExchangeCo(PetShardDTO dto, PetShardItemUI cell) { }

	private int FilteredCount() { }

	private bool get_HasPagination() { }

	private void HideAllCells() { }

	private void HideCell(int i) { }

	private void HideConfirm() { }

	private bool IsActionable(PetShardDTO dto) { }

	[IteratorStateMachine(typeof(<LoadCo>d__44))]
	private IEnumerator LoadCo() { }

	private void OnConfirmYes() { }

	private void OnDisable() { }

	private void OnExchangeClicked(PetShardDTO dto, PetShardItemUI cell) { }

	private void OnExchanged(PetExchangeResponse resp, PetShardDTO dto, PetShardItemUI cell) { }

	private void OnItemClicked(PetShardDTO dto) { }

	private void OnLoaded(PetShardListResponse resp) { }

	public void OpenTab() { }

	private static void PunchButton(Button btn) { }

	private static void PunchCell(PetShardItemUI cell) { }

	private void Reload() { }

	private void RenderPage(bool animate) { }

	private static string SafeName(PetShardDTO dto) { }

	private static void SetButtonVisible(Button btn, bool show) { }

	private void SetFilterVisible(bool show) { }

	private void SetGridInteractable(bool on) { }

	private void SetPaginationVisible(bool show) { }

	private void SetSummary(int totalShards) { }

	private static void ShakeCell(PetShardItemUI cell) { }

	private void ShowConfirm(PetShardDTO dto) { }

	private void ShowEmpty(string message) { }

	private void ShowErrorState(string message) { }

	[IteratorStateMachine(typeof(<SuccessFxThenReload>d__68))]
	private IEnumerator SuccessFxThenReload(PetShardItemUI cell) { }

	private void ToggleFilter() { }

	private int TotalPages() { }

	private void UpdateFilterUI() { }

	private void UpdatePageUI() { }

	private void WireOnce() { }

}

