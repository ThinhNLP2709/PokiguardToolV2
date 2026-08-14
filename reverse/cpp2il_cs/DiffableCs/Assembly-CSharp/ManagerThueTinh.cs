//Type is in global namespace

public class ManagerThueTinh : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int32, Boolean> <>9__57_0; //Field offset: 0x8
		public static Func<RequiredPetDTO, String> <>9__62_0; //Field offset: 0x10
		public static Func<RequiredPetDTO, String> <>9__62_1; //Field offset: 0x18
		public static Func<RequiredPetDTO, Boolean> <>9__63_0; //Field offset: 0x20
		public static Func<RequiredPetDTO, String> <>9__63_1; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal string <DisplayConditionPets>b__62_0(RequiredPetDTO p) { }

		internal string <DisplayConditionPets>b__62_1(RequiredPetDTO p) { }

		internal bool <DisplayStatus>b__63_0(RequiredPetDTO p) { }

		internal string <DisplayStatus>b__63_1(RequiredPetDTO p) { }

		internal bool <OpenDoiItemPanel>b__57_0(int have) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass52_0
	{
		public long capturedId; //Field offset: 0x10
		public ManagerThueTinh <>4__this; //Field offset: 0x18

		public <>c__DisplayClass52_0() { }

		internal void <DisplayPets>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public int captured; //Field offset: 0x10
		public ManagerThueTinh <>4__this; //Field offset: 0x18

		public <>c__DisplayClass56_0() { }

		internal void <DisplayCores>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <RefreshAfterAwaken>d__66 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerThueTinh <>4__this; //Field offset: 0x20

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
		public <RefreshAfterAwaken>d__66(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelMega"; //Field offset: 0x0
	private const int EITEM_COST = 4; //Field offset: 0x0
	private const int PAGE_SIZE = 8; //Field offset: 0x0
	private static readonly String[] CORE_NAMES; //Field offset: 0x0
	[Header("Main Panel")]
	public GameObject PanelThueTinh; //Field offset: 0x20
	public Button btnOpenThueTinh; //Field offset: 0x28
	public Button btnClose; //Field offset: 0x30
	[Header("Pet List - Board")]
	public Transform Board; //Field offset: 0x38
	public GameObject btnPetPrefab; //Field offset: 0x40
	[Header("Pagination")]
	public Button btnLeft; //Field offset: 0x48
	public Button btnRight; //Field offset: 0x50
	public Text txtPageInfo; //Field offset: 0x58
	[Header("Panel Body - Chi tiết")]
	public GameObject PanelBody; //Field offset: 0x60
	public Animator anmtPetMain; //Field offset: 0x68
	public Button btnThueTinh; //Field offset: 0x70
	public Text txtstatus; //Field offset: 0x78
	[Header("PanelPart1 - Pet Info")]
	public GameObject PanelPart1; //Field offset: 0x80
	public Image imgPetSource; //Field offset: 0x88
	public Text txtCurrentLevel; //Field offset: 0x90
	public Text txtNamePet; //Field offset: 0x98
	public Text txtDesReq; //Field offset: 0xA0
	[Header("PanelPart2 - Crystal")]
	public GameObject PanelPart2; //Field offset: 0xA8
	public Text txtCrystalCount; //Field offset: 0xB0
	[Header("PanelPart3 - 9 Viên Lõi")]
	public GameObject PanelPart3; //Field offset: 0xB8
	[Tooltip("9 frame lõi theo thứ tự 1→9")]
	public GameObject[] frameCores; //Field offset: 0xC0
	[Tooltip("9 Text current/required của từng lõi")]
	public Text[] txtCountCores; //Field offset: 0xC8
	[Tooltip("9 Sprite icon lõi")]
	public Sprite[] coreSprites; //Field offset: 0xD0
	[Header("Panel Condition")]
	public GameObject PanelCondition; //Field offset: 0xD8
	public Text txtCondition; //Field offset: 0xE0
	[Header("Background")]
	public Image imgBg; //Field offset: 0xE8
	[Header("Loading")]
	public GameObject loadingIndicator; //Field offset: 0xF0
	[Header("Panel Đổi Lõi - pnlDoiItem")]
	[Tooltip("pnlDoiItem — panel tổng")]
	public GameObject pnlDoiItem; //Field offset: 0xF8
	[Tooltip("btnBack — đóng panel, không đổi")]
	public Button btnBack; //Field offset: 0x100
	[Tooltip("btnDoi — xác nhận đổi (chỉ bật khi CẢ 4 loại eItem đều đủ 4)")]
	public Button btnDoi; //Field offset: 0x108
	[Tooltip("item1 — Image icon lõi đang được chọn đổi")]
	public Image imgCorePreviewed; //Field offset: 0x110
	[Tooltip("(Tuỳ chọn) Text tên lõi đang chọn")]
	public Text txtCorePreviewName; //Field offset: 0x118
	[Tooltip("4 frame eItem (frame1..frame4) trong swapitem1 > PanelPart3")]
	public GameObject[] frameEItems; //Field offset: 0x120
	[Tooltip("txtcount trong mỗi frame — hiển thị 'hiện có / 4'")]
	public Text[] txtEItemCounts; //Field offset: 0x128
	[Tooltip("4 Text trong PanelCurrent — số eItem đang có")]
	public Text[] txtCurrentEItems; //Field offset: 0x130
	private PagedMegaAwakeningResponse awakeningData; //Field offset: 0x138
	private MegaAwakeningDetailDTO currentDetail; //Field offset: 0x140
	private int userId; //Field offset: 0x148
	private long selectedPetId; //Field offset: 0x150
	private int currentPage; //Field offset: 0x158
	private int totalPages; //Field offset: 0x15C
	private List<GameObject> petButtons; //Field offset: 0x160
	private int pendingCoreIndex; //Field offset: 0x168

	private static ManagerThueTinh() { }

	public ManagerThueTinh() { }

	[CompilerGenerated]
	private void <AwakenPet>b__65_0(MegaAwakeningResultDTO result) { }

	[CompilerGenerated]
	private void <AwakenPet>b__65_1(string error) { }

	[CompilerGenerated]
	private void <LoadAwakeningPets>b__51_0(PagedMegaAwakeningResponse data) { }

	[CompilerGenerated]
	private void <LoadAwakeningPets>b__51_1(string error) { }

	[CompilerGenerated]
	private void <LoadPetDetail>b__54_0(MegaAwakeningDetailDTO detail) { }

	[CompilerGenerated]
	private void <LoadPetDetail>b__54_1(string error) { }

	[CompilerGenerated]
	private void <OnBtnDoiClick>b__58_0(SwapItemResultDTO result) { }

	[CompilerGenerated]
	private void <OnBtnDoiClick>b__58_1(string error) { }

	private void Awake() { }

	private void AwakenPet() { }

	private void BindButtons() { }

	private bool CheckCanAwakenLocal() { }

	private void CloseDoiItemPanel() { }

	public void ClosePanel() { }

	private void DisplayConditionPets(MegaAwakeningDetailDTO d) { }

	private void DisplayCores(MegaAwakeningDetailDTO d) { }

	private void DisplayDetail(MegaAwakeningDetailDTO d) { }

	private void DisplayPets(List<MegaAwakeningPetDTO> pets) { }

	private void DisplayStatus(MegaAwakeningDetailDTO d) { }

	private void HideLoading() { }

	private void LoadAwakeningPets() { }

	private void LoadPetDetail(long petId) { }

	private void NextPage() { }

	private void OnBtnDoiClick() { }

	private void OnDestroy() { }

	private void OpenDoiItemPanel(int coreIndex) { }

	public void OpenPanel() { }

	private void PatchDetailAfterSwap(SwapItemResultDTO result) { }

	private void PreviousPage() { }

	[IteratorStateMachine(typeof(<RefreshAfterAwaken>d__66))]
	private IEnumerator RefreshAfterAwaken() { }

	private void SelectPet(long petId) { }

	private void SetStatus(string msg, bool showBtn) { }

	private void ShowLoading() { }

	private bool TrySetupPetAnimation(Animator petAnimator, string petID) { }

	private void UpdatePagination() { }

}

