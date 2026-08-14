namespace PokiGame.LegendPet;

public class PanelPetHT : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__61_1; //Field offset: 0x8
		public static Action<String> <>9__62_1; //Field offset: 0x10
		public static Comparison<StarSlotData> <>9__78_0; //Field offset: 0x18
		public static Comparison<StarSlotData> <>9__78_1; //Field offset: 0x20
		public static Comparison<StarSlotData> <>9__78_2; //Field offset: 0x28
		public static Comparison<Transform> <>9__81_0; //Field offset: 0x30
		public static Comparison<StarSlotData> <>9__84_0; //Field offset: 0x38
		public static Comparison<StarSlotData> <>9__84_1; //Field offset: 0x40
		public static Comparison<StarSlotData> <>9__84_2; //Field offset: 0x48
		public static TweenCallback <>9__99_0; //Field offset: 0x50
		public static TweenCallback <>9__99_1; //Field offset: 0x58
		public static Action<LegendPetListResponse> <>9__111_0; //Field offset: 0x60
		public static Action<String> <>9__111_1; //Field offset: 0x68

		private static <>c() { }

		public <>c() { }

		internal int <InitializeAllStarButtons>b__78_0(StarSlotData a, StarSlotData b) { }

		internal int <InitializeAllStarButtons>b__78_1(StarSlotData a, StarSlotData b) { }

		internal int <InitializeAllStarButtons>b__78_2(StarSlotData a, StarSlotData b) { }

		internal int <InitializeStarButtonsForImage>b__84_0(StarSlotData a, StarSlotData b) { }

		internal int <InitializeStarButtonsForImage>b__84_1(StarSlotData a, StarSlotData b) { }

		internal int <InitializeStarButtonsForImage>b__84_2(StarSlotData a, StarSlotData b) { }

		internal int <MapStarGroup>b__81_0(Transform a, Transform b) { }

		internal void <PreloadPetDetail>b__61_1(string error) { }

		internal void <PreloadUserPetStats>b__62_1(string error) { }

		internal void <ShowPetUnlockPanel>b__99_0() { }

		internal void <ShowPetUnlockPanel>b__99_1() { }

		internal void <TestAPI>b__111_0(LegendPetListResponse response) { }

		internal void <TestAPI>b__111_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass53_0
	{
		public int index; //Field offset: 0x10
		public PanelPetHT <>4__this; //Field offset: 0x18

		public <>c__DisplayClass53_0() { }

		internal void <Awake>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass61_0
	{
		public PanelPetHT <>4__this; //Field offset: 0x10
		public long petId; //Field offset: 0x18

		public <>c__DisplayClass61_0() { }

		internal void <PreloadPetDetail>b__0(LegendPetData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass62_0
	{
		public PanelPetHT <>4__this; //Field offset: 0x10
		public long petId; //Field offset: 0x18

		public <>c__DisplayClass62_0() { }

		internal void <PreloadUserPetStats>b__0(PetUserDTO pet) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass69_0
	{
		public PanelPetHT <>4__this; //Field offset: 0x10
		public long petId; //Field offset: 0x18

		public <>c__DisplayClass69_0() { }

		internal void <LoadPetDetail>b__0(LegendPetData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public PanelPetHT <>4__this; //Field offset: 0x10
		public long petId; //Field offset: 0x18

		public <>c__DisplayClass72_0() { }

		internal void <LoadAndShowPetStats>b__0(PetUserDTO pet) { }

		internal void <LoadAndShowPetStats>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass81_0
	{
		public StarSlotData slotData; //Field offset: 0x10
		public PanelPetHT <>4__this; //Field offset: 0x18

		public <>c__DisplayClass81_0() { }

		internal void <MapStarGroup>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass90_0
	{
		public PanelPetHT <>4__this; //Field offset: 0x10
		public InlayStarResponse response; //Field offset: 0x18
		public LegendPetData pet; //Field offset: 0x20
		public bool isViewing; //Field offset: 0x28
		public int petIndex; //Field offset: 0x2C
		public Action <>9__0; //Field offset: 0x30

		public <>c__DisplayClass90_0() { }

		internal void <OnInlaySuccess>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass97_0
	{
		public Action onComplete; //Field offset: 0x10

		public <>c__DisplayClass97_0() { }

		internal void <PlayStarInlayAnimation>b__0() { }

	}

	[Header("UI References")]
	[SerializeField]
	private GameObject panelObject; //Field offset: 0x20
	[SerializeField]
	private Text petNameText; //Field offset: 0x28
	[SerializeField]
	private Text progressText; //Field offset: 0x30
	[SerializeField]
	private Image progressBar; //Field offset: 0x38
	[SerializeField]
	private Button closeButton; //Field offset: 0x40
	[Header("Pet Selection Buttons")]
	[SerializeField]
	private Button[] btnHTs; //Field offset: 0x48
	[SerializeField]
	private Text[] btnHtTexts; //Field offset: 0x50
	[SerializeField]
	private Image[] btnHtIcons; //Field offset: 0x58
	[Header("Image Panels - Các ImageHT1, ImageHT2, ...")]
	[SerializeField]
	private GameObject[] imagePanels; //Field offset: 0x60
	[Header("Star Info Display")]
	[SerializeField]
	private Text starWhiteText; //Field offset: 0x68
	[SerializeField]
	private Text starBlueText; //Field offset: 0x70
	[SerializeField]
	private Text starRedText; //Field offset: 0x78
	[Header("Confirm Panel")]
	[SerializeField]
	private GameObject confirmPanelObject; //Field offset: 0x80
	[SerializeField]
	private Image confirmIcon; //Field offset: 0x88
	[SerializeField]
	private Text confirmMessageTxt; //Field offset: 0x90
	[SerializeField]
	private Button confirmBtnOK; //Field offset: 0x98
	[SerializeField]
	private Button confirmBtnCancel; //Field offset: 0xA0
	[SerializeField]
	private Sprite starWhiteIcon; //Field offset: 0xA8
	[SerializeField]
	private Sprite starBlueIcon; //Field offset: 0xB0
	[SerializeField]
	private Sprite starRedIcon; //Field offset: 0xB8
	[SerializeField]
	private CanvasGroup confirmCanvasGroup; //Field offset: 0xC0
	[Header("Other Panels")]
	[SerializeField]
	private GameObject loadingPanel; //Field offset: 0xC8
	[SerializeField]
	private GameObject petUnlockPanel; //Field offset: 0xD0
	[SerializeField]
	private GameObject PanelPetMain; //Field offset: 0xD8
	[Header("Debug")]
	[SerializeField]
	private Button btnTestAPI; //Field offset: 0xE0
	[SerializeField]
	private bool autoShowOnStart; //Field offset: 0xE8
	public GameObject PanelCardPet; //Field offset: 0xF0
	public Image imgCard; //Field offset: 0xF8
	public Text txtDescription; //Field offset: 0x100
	public Text namePet; //Field offset: 0x108
	public Text txtHp; //Field offset: 0x110
	public Text txtMana; //Field offset: 0x118
	public Text txtDame; //Field offset: 0x120
	public Text txtWee; //Field offset: 0x128
	public Text txtLv; //Field offset: 0x130
	public Text des; //Field offset: 0x138
	public Image imgAtribute; //Field offset: 0x140
	public Image imgAtributeOther; //Field offset: 0x148
	private LegendPetBasicInfo[] allPets; //Field offset: 0x150
	private LegendPetData currentPetData; //Field offset: 0x158
	private long userId; //Field offset: 0x160
	private int currentPetIndex; //Field offset: 0x168
	private int currentImageIndex; //Field offset: 0x16C
	private InlayStarRequest lastInlayRequest; //Field offset: 0x170
	private Dictionary<Int64, Button> starButtonDict; //Field offset: 0x178
	private Dictionary<Int64, Image> starImageDict; //Field offset: 0x180
	private StarSlotData currentConfirmSlotData; //Field offset: 0x188
	private LegendPetData confirmPetData; //Field offset: 0x190
	private int confirmPetIndex; //Field offset: 0x198
	private Dictionary<Int64, PetUserDTO> userPetsCache; //Field offset: 0x1A0
	private Dictionary<Int64, LegendPetData> petDetailCache; //Field offset: 0x1A8
	private PetUserDTO currentUserPetData; //Field offset: 0x1B0
	private bool isLoadingUserPet; //Field offset: 0x1B8

	public PanelPetHT() { }

	[CompilerGenerated]
	private void <Awake>b__53_0() { }

	[CompilerGenerated]
	private void <Awake>b__53_1() { }

	[CompilerGenerated]
	private void <HideConfirmPanel>b__87_0() { }

	[CompilerGenerated]
	private void <ShowPetUnlockPanel>b__99_2() { }

	[CompilerGenerated]
	private void <ShowPetUnlockPanel>b__99_3() { }

	private void Awake() { }

	private void ClearAllStarButtons() { }

	private void ClearStarsInPanel(GameObject panel) { }

	[ContextMenu("Test - Show Panel")]
	private void ContextMenu_ShowPanel() { }

	[ContextMenu("Test - Call API")]
	private void ContextMenu_TestAPI() { }

	[ContextMenu("Test - Load Fake Data")]
	private void ContextMenu_TestFakeData() { }

	private void DisplayPetStats(PetUserDTO pet) { }

	private Transform FindStarGroupContainer(Transform parent, string groupName) { }

	private long GetCurrentUserId() { }

	public void Hide() { }

	private void HideAllPetStatsUI() { }

	private void HideConfirmPanel() { }

	private void HideStarsAndChangeImageColor() { }

	private void InitializeAllStarButtons() { }

	private void InitializeStarButtonsForImage(int panelIndex, ImageHTData imageData) { }

	private void InlayStar(StarSlotData slotData) { }

	private void LoadAllPets() { }

	private void LoadAndShowPetStats(long petId) { }

	private void LoadAttributeImage(Image imageComponent, string attributeName) { }

	private void LoadPetDetail(long petId) { }

	private void LoadPetSkillCard(int skillCardId, string description) { }

	private int MapStarGroup(Transform container, List<StarSlotData> slotDataList, int starType) { }

	private void OnConfirm(bool confirmed) { }

	private void OnDestroy() { }

	private void OnInlayError(string error) { }

	private void OnInlaySuccess(InlayStarResponse response) { }

	private void OnLoadAllPetsError(string error) { }

	private void OnLoadAllPetsSuccess(LegendPetListResponse response) { }

	private void OnLoadPetDetailError(string error) { }

	private void OnLoadPetDetailSuccess(LegendPetData data) { }

	private void OnPetButtonClick(int index) { }

	private void OnPetsReceived(PetUserDTO pet) { }

	private void OnStarClicked(StarSlotData slotData) { }

	private void OnStarCountChangedHandler(int white, int blue, int red) { }

	private void PlayStarInlayAnimation(long slotId, Action onComplete) { }

	private void PreloadOtherPetsData(int skipIndex) { }

	private void PreloadPetDetail(long petId) { }

	private void PreloadUserPetStats(long petId) { }

	private void RecomputeCanInlay(ImageHTData imageData) { }

	public void RefreshData() { }

	private void SelectPet(int index) { }

	public void SelectPetById(long petId) { }

	private void SetTextIfNotNull(Text textComponent, string value) { }

	private void SetupPetButtons() { }

	public void Show() { }

	private void ShowConfirmPanel(StarSlotData slotData, int currentStarCount) { }

	private void ShowErrorMessage(string message) { }

	private void ShowImageHT(int petIndex) { }

	private void ShowLoading(bool show) { }

	private void ShowPetUnlockPanel() { }

	private void Start() { }

	public void TestAPI() { }

	public void TestWithFakeData() { }

	private void UpdateAllStarButtonStates() { }

	private void UpdatePetButtonHighlight(int selectedIndex) { }

	private void UpdatePetButtonVisual(int index, LegendPetBasicInfo pet) { }

	private void UpdatePetInfo() { }

	private void UpdateStarCount() { }

	private void UpdateStarSlotVisual(long slotId, bool inlaid) { }

	private void UpdateStarVisual(StarSlotData slotData, Image starImage, Button starButton) { }

}

