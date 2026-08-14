//Type is in global namespace

public class ManagerTienHoa : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<RequiredPetDTO, Boolean> <>9__97_0; //Field offset: 0x8
		public static Func<RequiredPetDTO, String> <>9__97_1; //Field offset: 0x10
		public static Func<RequiredPetDTO, String> <>9__97_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <DisplayDetail>b__97_0(RequiredPetDTO p) { }

		internal string <DisplayDetail>b__97_1(RequiredPetDTO p) { }

		internal string <DisplayDetail>b__97_2(RequiredPetDTO p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass94_0
	{
		public long capturedPetId; //Field offset: 0x10
		public ManagerTienHoa <>4__this; //Field offset: 0x18

		public <>c__DisplayClass94_0() { }

		internal void <DisplayPets>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <RefreshAfterEvolution>d__101 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerTienHoa <>4__this; //Field offset: 0x20

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
		public <RefreshAfterEvolution>d__101(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelTienhoa"; //Field offset: 0x0
	private const int PAGE_SIZE = 8; //Field offset: 0x0
	[Header("Main Panel")]
	public GameObject PanelTienhoa; //Field offset: 0x20
	public Button btnTienHoa; //Field offset: 0x28
	public Button btnClose; //Field offset: 0x30
	[Header("Pet List - Board")]
	public Transform Board; //Field offset: 0x38
	public GameObject btnEVPPrefab; //Field offset: 0x40
	private List<GameObject> petButtons; //Field offset: 0x48
	[Header("Pagination")]
	public Button btnLeft; //Field offset: 0x50
	public Button btnRight; //Field offset: 0x58
	public Text txtInfo; //Field offset: 0x60
	private int currentPage; //Field offset: 0x68
	private int totalPages; //Field offset: 0x6C
	[Header("Body Panel")]
	public GameObject PanelBody; //Field offset: 0x70
	public Animator anmtPetMain; //Field offset: 0x78
	public Button btnTienhoa; //Field offset: 0x80
	public Text txtsuccess; //Field offset: 0x88
	[Header("Panel Đổi Item")]
	public GameObject panelDoi; //Field offset: 0x90
	public Button btnDoi; //Field offset: 0x98
	public Button btnCloseDoi; //Field offset: 0xA0
	[Header("Panel Đổi - Current Items Display")]
	public GameObject PanelPart3Doi; //Field offset: 0xA8
	public GameObject frame1Doi; //Field offset: 0xB0
	public GameObject frame2Doi; //Field offset: 0xB8
	public GameObject frame3Doi; //Field offset: 0xC0
	public GameObject frame4Doi; //Field offset: 0xC8
	public Text txtCountItem1Doi; //Field offset: 0xD0
	public Text txtCountItem2Doi; //Field offset: 0xD8
	public Text txtCountItem3Doi; //Field offset: 0xE0
	public Text txtCountItem4Doi; //Field offset: 0xE8
	[Header("Panel Đổi - Swap Items")]
	public GameObject pnllDoilitem; //Field offset: 0xF0
	public GameObject swapitem1; //Field offset: 0xF8
	public Text txtCountSaoDo1; //Field offset: 0x100
	public Button btnDoiSwap1; //Field offset: 0x108
	public GameObject swapitem2; //Field offset: 0x110
	public Text txtCountSaoDo2; //Field offset: 0x118
	public Button btnDoiSwap2; //Field offset: 0x120
	public GameObject swapitem3; //Field offset: 0x128
	public Text txtCountSaoDo3; //Field offset: 0x130
	public Button btnDoiSwap3; //Field offset: 0x138
	public GameObject swapitem4; //Field offset: 0x140
	public Text txtCountSaoDo4; //Field offset: 0x148
	public Button btnDoiSwap4; //Field offset: 0x150
	public GameObject swapitem5; //Field offset: 0x158
	public Text txtCountSaoTrang; //Field offset: 0x160
	public Button btnDoiSwap5; //Field offset: 0x168
	public GameObject swapitem6; //Field offset: 0x170
	public Text txtCountSaoXanh; //Field offset: 0x178
	public Button btnDoiSwap6; //Field offset: 0x180
	[Header("Panel Items")]
	public GameObject pnlItem; //Field offset: 0x188
	[Header("PanelPart1 - Pet Requirement")]
	public GameObject PanelPart1; //Field offset: 0x190
	public Image imgpet; //Field offset: 0x198
	public Text txtcurentlevel; //Field offset: 0x1A0
	public Text txtNamePet; //Field offset: 0x1A8
	public Text txtDesReq; //Field offset: 0x1B0
	[Header("PanelPart2 - Crystal Requirement")]
	public GameObject PanelPart2; //Field offset: 0x1B8
	public Text txtCrystalCount; //Field offset: 0x1C0
	[Header("PanelPart3 - eItem Requirements")]
	public GameObject PanelPart3; //Field offset: 0x1C8
	public GameObject frame1; //Field offset: 0x1D0
	public GameObject frame2; //Field offset: 0x1D8
	public GameObject frame3; //Field offset: 0x1E0
	public GameObject frame4; //Field offset: 0x1E8
	public Text txtCountItem1; //Field offset: 0x1F0
	public Text txtCountItem2; //Field offset: 0x1F8
	public Text txtCountItem3; //Field offset: 0x200
	public Text txtCountItem4; //Field offset: 0x208
	[Header("PanelPart4 - Stone Requirements")]
	public GameObject PanelPart4; //Field offset: 0x210
	public Transform listStoneContainer; //Field offset: 0x218
	public GameObject frameStonePrefab; //Field offset: 0x220
	[Header("Stone Sprites - 5 Hệ")]
	[Tooltip("Đá lửa level 7")]
	public Sprite stoneFireLv7; //Field offset: 0x228
	[Tooltip("Đá nước level 7")]
	public Sprite stoneWaterLv7; //Field offset: 0x230
	[Tooltip("Đá gió level 7")]
	public Sprite stoneWindLv7; //Field offset: 0x238
	[Tooltip("Đá đất level 7")]
	public Sprite stoneEarthLv7; //Field offset: 0x240
	[Tooltip("Đá sét level 7")]
	public Sprite stoneThunderLv7; //Field offset: 0x248
	[Header("Loading")]
	public GameObject loadingIndicator; //Field offset: 0x250
	private PagedEvolutionResponse evolutionData; //Field offset: 0x258
	private EvolutionDetailDTO currentDetail; //Field offset: 0x260
	private int userId; //Field offset: 0x268
	private long selectedPetId; //Field offset: 0x270
	private int currentStarWhite; //Field offset: 0x278
	private int currentStarBlue; //Field offset: 0x27C
	private int currentStarRed; //Field offset: 0x280
	private int currentEItem1; //Field offset: 0x284
	private int currentEItem2; //Field offset: 0x288
	private int currentEItem3; //Field offset: 0x28C
	private int currentEItem4; //Field offset: 0x290

	public ManagerTienHoa() { }

	[CompilerGenerated]
	private void <Awake>b__85_0() { }

	[CompilerGenerated]
	private void <Awake>b__85_1() { }

	[CompilerGenerated]
	private void <Awake>b__85_2() { }

	[CompilerGenerated]
	private void <Awake>b__85_3() { }

	[CompilerGenerated]
	private void <Awake>b__85_4() { }

	[CompilerGenerated]
	private void <Awake>b__85_5() { }

	[CompilerGenerated]
	private void <EvolvePet>b__100_0(EvolutionResultDTO result) { }

	[CompilerGenerated]
	private void <EvolvePet>b__100_1(string error) { }

	[CompilerGenerated]
	private void <LoadEvolutionPets>b__93_0(PagedEvolutionResponse data) { }

	[CompilerGenerated]
	private void <LoadEvolutionPets>b__93_1(string error) { }

	[CompilerGenerated]
	private void <LoadPetDetail>b__96_0(EvolutionDetailDTO detail) { }

	[CompilerGenerated]
	private void <LoadPetDetail>b__96_1(string error) { }

	[CompilerGenerated]
	private void <SwapItem>b__92_0(SwapItemResponse response) { }

	[CompilerGenerated]
	private void <SwapItem>b__92_1(string error) { }

	private void Awake() { }

	public void ClosePanel() { }

	public void ClosePanelDoi() { }

	private void DisplayDetail(EvolutionDetailDTO detail) { }

	private void DisplayPets(List<EvolutionPetDTO> pets) { }

	private void DisplayStoneRequirements(List<StoneRequirementDTO> stones) { }

	private void EvolvePet() { }

	private Sprite GetStoneSpriteByElement(string elementType) { }

	private void HideLoading() { }

	private void LoadCurrentResources() { }

	private void LoadEvolutionPets() { }

	private void LoadPetDetail(long petId) { }

	private void NextPage() { }

	private void OnDestroy() { }

	public void OpenPanel() { }

	public void OpenPanelDoi() { }

	private void PreviousPage() { }

	[IteratorStateMachine(typeof(<RefreshAfterEvolution>d__101))]
	private IEnumerator RefreshAfterEvolution() { }

	private void SelectPet(long petId) { }

	private void ShowLoading() { }

	private void SwapItem(int swapType) { }

	private bool TrySetupPetAnimation(Animator petAnimator, string petID) { }

	private void UpdatePagination() { }

	private void UpdateSwapUI() { }

}

