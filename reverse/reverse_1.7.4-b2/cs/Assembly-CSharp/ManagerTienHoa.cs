/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerTienHoa : MonoBehaviour // TypeDefIndex: 561
{
	// Fields
	public const string PANEL_KEY = "PanelTienhoa"; // Metadata: 0x0068B66B
	[Header("Main Panel")]
	public GameObject PanelTienhoa; // 0x20
	public Button btnTienHoa; // 0x28
	public Button btnClose; // 0x30
	[Header("Pet List - Board")]
	public Transform Board; // 0x38
	public GameObject btnEVPPrefab; // 0x40
	private List<GameObject> petButtons; // 0x48
	[Header("Pagination")]
	public Button btnLeft; // 0x50
	public Button btnRight; // 0x58
	public UnityEngine.UI.Text txtInfo; // 0x60
	private int currentPage; // 0x68
	private int totalPages; // 0x6C
	private const int PAGE_SIZE = 8; // Metadata: 0x0068B678
	private int _pageSize; // 0x70
	private int _listReqSeq; // 0x74
	private int _detailReqSeq; // 0x78
	private int _pageDir; // 0x7C
	private RectTransform _boardRt; // 0x80
	private CanvasGroup _boardGroup; // 0x88
	private float _boardBaseX; // 0x90
	private readonly List<long> _petIdsOnPage; // 0x98
	private readonly List<Image> _petFrames; // 0xA0
	private static readonly Color FRAME_NORMAL; // 0x00
	private static readonly Color FRAME_SELECTED; // 0x10
	private static readonly Color FRAME_NEW; // 0x20
	private const float SELECTED_SCALE = 1.08f; // Metadata: 0x0068B679
	private const string PREF_SEEN_TOP = "EvoSeenTopSourcePet"; // Metadata: 0x0068B67D
	[Header("Body Panel")]
	public GameObject PanelBody; // 0xA8
	public Animator anmtPetMain; // 0xB0
	public Button btnTienhoa; // 0xB8
	public UnityEngine.UI.Text txtsuccess; // 0xC0
	[Header("Panel \u0110\u1ED5i Item")]
	public GameObject panelDoi; // 0xC8
	public Button btnDoi; // 0xD0
	public Button btnCloseDoi; // 0xD8
	[Header("Panel \u0110\u1ED5i - Current Items Display")]
	public GameObject PanelPart3Doi; // 0xE0
	public GameObject frame1Doi; // 0xE8
	public GameObject frame2Doi; // 0xF0
	public GameObject frame3Doi; // 0xF8
	public GameObject frame4Doi; // 0x100
	public UnityEngine.UI.Text txtCountItem1Doi; // 0x108
	public UnityEngine.UI.Text txtCountItem2Doi; // 0x110
	public UnityEngine.UI.Text txtCountItem3Doi; // 0x118
	public UnityEngine.UI.Text txtCountItem4Doi; // 0x120
	[Header("Panel \u0110\u1ED5i - Swap Items")]
	public GameObject pnllDoilitem; // 0x128
	public GameObject swapitem1; // 0x130
	public UnityEngine.UI.Text txtCountSaoDo1; // 0x138
	public Button btnDoiSwap1; // 0x140
	public GameObject swapitem2; // 0x148
	public UnityEngine.UI.Text txtCountSaoDo2; // 0x150
	public Button btnDoiSwap2; // 0x158
	public GameObject swapitem3; // 0x160
	public UnityEngine.UI.Text txtCountSaoDo3; // 0x168
	public Button btnDoiSwap3; // 0x170
	public GameObject swapitem4; // 0x178
	public UnityEngine.UI.Text txtCountSaoDo4; // 0x180
	public Button btnDoiSwap4; // 0x188
	public GameObject swapitem5; // 0x190
	public UnityEngine.UI.Text txtCountSaoTrang; // 0x198
	public Button btnDoiSwap5; // 0x1A0
	public GameObject swapitem6; // 0x1A8
	public UnityEngine.UI.Text txtCountSaoXanh; // 0x1B0
	public Button btnDoiSwap6; // 0x1B8
	[Header("Panel Items")]
	public GameObject pnlItem; // 0x1C0
	[Header("PanelPart1 - Pet Requirement")]
	public GameObject PanelPart1; // 0x1C8
	public Image imgpet; // 0x1D0
	public UnityEngine.UI.Text txtcurentlevel; // 0x1D8
	public UnityEngine.UI.Text txtNamePet; // 0x1E0
	public UnityEngine.UI.Text txtDesReq; // 0x1E8
	[Header("PanelPart2 - Crystal Requirement")]
	public GameObject PanelPart2; // 0x1F0
	public UnityEngine.UI.Text txtCrystalCount; // 0x1F8
	[Header("PanelPart3 - eItem Requirements")]
	public GameObject PanelPart3; // 0x200
	public GameObject frame1; // 0x208
	public GameObject frame2; // 0x210
	public GameObject frame3; // 0x218
	public GameObject frame4; // 0x220
	public UnityEngine.UI.Text txtCountItem1; // 0x228
	public UnityEngine.UI.Text txtCountItem2; // 0x230
	public UnityEngine.UI.Text txtCountItem3; // 0x238
	public UnityEngine.UI.Text txtCountItem4; // 0x240
	[Header("PanelPart4 - Stone Requirements")]
	public GameObject PanelPart4; // 0x248
	public Transform listStoneContainer; // 0x250
	public GameObject frameStonePrefab; // 0x258
	[Header("Stone Sprites - 5 H\u1EC7")]
	[Tooltip("\u0110\u00E1 l\u1EEDa level 7")]
	public Sprite stoneFireLv7; // 0x260
	[Tooltip("\u0110\u00E1 n\u01B0\u1EDBc level 7")]
	public Sprite stoneWaterLv7; // 0x268
	[Tooltip("\u0110\u00E1 gi\u00F3 level 7")]
	public Sprite stoneWindLv7; // 0x270
	[Tooltip("\u0110\u00E1 \u0111\u1EA5t level 7")]
	public Sprite stoneEarthLv7; // 0x278
	[Tooltip("\u0110\u00E1 s\u00E9t level 7")]
	public Sprite stoneThunderLv7; // 0x280
	[Header("Loading")]
	public GameObject loadingIndicator; // 0x288
	private const string FLAG_EVO_TOOLTIP = "evo.tooltip"; // Metadata: 0x0068B691
	private SkillCardBadge _cardBadge; // 0x290
	private string _srcTipTitle; // 0x298
	private string _srcTipBody; // 0x2A0
	private string _tgtTipTitle; // 0x2A8
	private string _tgtTipBody; // 0x2B0
	private Sprite _srcTipIcon; // 0x2B8
	private Sprite _tgtTipIcon; // 0x2C0
	private List<RewardDisplayHelper.Entry> _srcTipCard; // 0x2C8
	private List<RewardDisplayHelper.Entry> _tgtTipCard; // 0x2D0
	private Action _srcCardShow; // 0x2D8
	private Action _tgtCardShow; // 0x2E0
	private bool _srcTipFallbackWired; // 0x2E8
	private bool _tgtTipFallbackWired; // 0x2E9
	private PagedEvolutionResponse evolutionData; // 0x2F0
	private EvolutionDetailDTO currentDetail; // 0x2F8
	private int userId; // 0x300
	private long selectedPetId; // 0x308
	private int currentStarWhite; // 0x310
	private int currentStarBlue; // 0x314
	private int currentStarRed; // 0x318
	private int currentEItem1; // 0x31C
	private int currentEItem2; // 0x320
	private int currentEItem3; // 0x324
	private int currentEItem4; // 0x328

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 562
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<RequiredPetDTO, bool> __9__136_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__136_1; // 0x10
		public static Func<RequiredPetDTO, string> __9__136_2; // 0x18

		// Constructors
		static __c(); // 0x00000001803F6B00-0x00000001803F6B70
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _DisplayDetail_b__136_0(RequiredPetDTO p); // 0x00000001803F4F30-0x00000001803F4F50
		internal string _DisplayDetail_b__136_1(RequiredPetDTO p); // 0x00000001803F4F50-0x00000001803F4FB0
		internal string _DisplayDetail_b__136_2(RequiredPetDTO p); // 0x00000001803F4FB0-0x00000001803F5100
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass122_0 // TypeDefIndex: 563
	{
		// Fields
		public ManagerTienHoa __4__this; // 0x10
		public int seq; // 0x18
		public bool keepSelection; // 0x1C
		public long keepPetId; // 0x20

		// Constructors
		public __c__DisplayClass122_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadEvolutionPets_b__0(PagedEvolutionResponse data); // 0x00000001803F5240-0x00000001803F54F0
		internal void _LoadEvolutionPets_b__1(string error); // 0x00000001803F54F0-0x00000001803F55A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass126_0 // TypeDefIndex: 564
	{
		// Fields
		public long capturedPetId; // 0x10
		public GameObject capturedObj; // 0x18
		public ManagerTienHoa __4__this; // 0x20

		// Constructors
		public __c__DisplayClass126_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayPets_b__0(); // 0x00000001803F55A0-0x00000001803F56C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 565
	{
		// Fields
		public Image frame; // 0x10

		// Constructors
		public __c__DisplayClass133_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _MaybeFlashNewest_b__0(float v); // 0x00000001803F56C0-0x00000001803F5830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass135_0 // TypeDefIndex: 566
	{
		// Fields
		public ManagerTienHoa __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass135_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPetDetail_b__0(EvolutionDetailDTO detail); // 0x00000001803F5830-0x00000001803F59B0
		internal void _LoadPetDetail_b__1(string error); // 0x00000001803F59B0-0x00000001803F5A50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass137_0 // TypeDefIndex: 567
	{
		// Fields
		public long stoneId; // 0x10
		public int have; // 0x18
		public int need; // 0x1C

		// Constructors
		public __c__DisplayClass137_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal InfoPlayerActionTooltip.Model _DisplayStoneRequirements_b__0(); // 0x00000001803F5A50-0x00000001803F5AC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass144_0 // TypeDefIndex: 568
	{
		// Fields
		public string title; // 0x10
		public string body; // 0x18
		public Sprite icon; // 0x20

		// Constructors
		public __c__DisplayClass144_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CardShowAction_b__0(); // 0x00000001803F5BE0-0x00000001803F5C60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass150_0 // TypeDefIndex: 569
	{
		// Fields
		public int have; // 0x10
		public int need; // 0x14

		// Constructors
		public __c__DisplayClass150_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal InfoPlayerActionTooltip.Model _BindItemTooltips_b__0(); // 0x00000001803F5C60-0x00000001803F5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass151_0 // TypeDefIndex: 570
	{
		// Fields
		public int idx; // 0x10
		public int have; // 0x14
		public int need; // 0x18

		// Constructors
		public __c__DisplayClass151_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal InfoPlayerActionTooltip.Model _AttachEItem_b__0(); // 0x00000001803F5CC0-0x00000001803F5D30
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterEvolution_d__154 : IEnumerator<object> // TypeDefIndex: 571
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTienHoa __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshAfterEvolution_d__154(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803F4E30-0x00000001803F4EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803F4EF0-0x00000001803F4F30
	}

	// Constructors
	public ManagerTienHoa(); // 0x00000001803CBB20-0x00000001803CBC50
	static ManagerTienHoa(); // 0x00000001803CBAA0-0x00000001803CBB20

	// Methods
	private void Awake(); // 0x00000001803C43F0-0x00000001803C4C10
	private void LoadCurrentResources(); // 0x00000001803C8CF0-0x00000001803C8D80
	public void OpenPanel(); // 0x00000001803C9880-0x00000001803C9910
	public void ClosePanel(); // 0x00000001803C65B0-0x00000001803C6710
	public void OpenPanelDoi(); // 0x00000001803C97F0-0x00000001803C9880
	public void ClosePanelDoi(); // 0x00000001803C6530-0x00000001803C65B0
	private void UpdateSwapUI(); // 0x00000001803CB3E0-0x00000001803CB900
	private void SwapItem(int swapType); // 0x00000001803CA560-0x00000001803CA6C0
	private void LoadEvolutionPets(); // 0x00000001803C8D80-0x00000001803C8F50
	private void LoadEvolutionPets(bool keepSelection); // 0x00000001803C8F50-0x00000001803C9120
	private void SetPagingButtons(bool on); // 0x00000001803CA090-0x00000001803CA140
	private void CacheBoardRefs(); // 0x00000001803C5A10-0x00000001803C5BD0
	private int ComputeSlotsPerPage(); // 0x00000001803C6710-0x00000001803C6970
	private void DisplayPets(List<EvolutionPetDTO> pets); // 0x00000001803C7710-0x00000001803C7BD0
	private void ClearPetButtons(); // 0x00000001803C62E0-0x00000001803C6530
	private Vector3 RestScaleOf(int i); // 0x00000001803C9FA0-0x00000001803CA050
	private void HighlightSelected(bool animate); // 0x00000001803C8880-0x00000001803C8CF0
	private void PlayStaggerIn(); // 0x00000001803C9C00-0x00000001803C9E30
	private void PlayPageFx(int dir); // 0x00000001803C9910-0x00000001803C9C00
	private void ResetBoardPosition(); // 0x00000001803C9EC0-0x00000001803C9FA0
	private void MaybeFlashNewest(List<EvolutionPetDTO> pets); // 0x00000001803C92C0-0x00000001803C9600
	private void SelectPet(long petId); // 0x00000001803CA050-0x00000001803CA090
	private void LoadPetDetail(long petId); // 0x00000001803C9120-0x00000001803C92C0
	private void DisplayDetail(EvolutionDetailDTO detail); // 0x00000001803C6970-0x00000001803C7710
	private void DisplayStoneRequirements(List<StoneRequirementDTO> stones); // 0x00000001803C7BD0-0x00000001803C8320
	private static bool EvoTipOn(); // 0x00000001803C8320-0x00000001803C8380
	private Transform FindDeep(string nodeName); // 0x00000001803C8540-0x00000001803C8690
	private void ApplyCardAndTooltips(EvolutionDetailDTO d); // 0x00000001803C4180-0x00000001803C4290
	private void BindSkillCardBadge(EvolutionDetailDTO d); // 0x00000001803C5690-0x00000001803C5A10
	private void BindPetTooltips(EvolutionDetailDTO d); // 0x00000001803C4ED0-0x00000001803C5690
	private static List<RewardDisplayHelper.Entry> CardEntry(long cardId, string cardName); // 0x00000001803C5EA0-0x00000001803C60F0
	private static Action CardShowAction(long cardId, string cardName, string desc, int mana, int power); // 0x00000001803C60F0-0x00000001803C62E0
	private static void WireFallback(GameObject go, ref bool wired, UnityAction show); // 0x00000001803CB900-0x00000001803CBAA0
	private void ShowSourcePetTipHere(); // 0x00000001803CA1C0-0x00000001803CA1D0
	private void ShowTargetPetTipHere(); // 0x00000001803CA380-0x00000001803CA390
	public void ShowSourcePetTip(RectTransform anchor); // 0x00000001803CA1D0-0x00000001803CA380
	public void ShowTargetPetTip(RectTransform anchor); // 0x00000001803CA390-0x00000001803CA560
	private void BindItemTooltips(EvolutionDetailDTO d); // 0x00000001803C4C10-0x00000001803C4ED0
	private static void AttachEItem(GameObject frame, int idx, int have, int need); // 0x00000001803C4290-0x00000001803C43F0
	private Sprite GetStoneSpriteByElement(string elementType); // 0x00000001803C8690-0x00000001803C87D0
	private void EvolvePet(); // 0x00000001803C8380-0x00000001803C8540
	[IteratorStateMachine(typeof(_RefreshAfterEvolution_d__154))]
	private IEnumerator RefreshAfterEvolution(); // 0x00000001803C9E50-0x00000001803C9EC0
	private void PreviousPage(); // 0x00000001803C9E30-0x00000001803C9E50
	private void NextPage(); // 0x00000001803C9600-0x00000001803C9620
	private void UpdatePagination(); // 0x00000001803CB260-0x00000001803CB3E0
	private void OnDisable(); // 0x00000001803C9630-0x00000001803C97F0
	private void CancelAllTweens(); // 0x00000001803C5BD0-0x00000001803C5EA0
	private void ShowLoading(); // 0x00000001803CA140-0x00000001803CA1C0
	private void HideLoading(); // 0x00000001803C87D0-0x00000001803C8880
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x00000001803CA6C0-0x00000001803CAAD0
	private void OnDestroy(); // 0x00000001803C9620-0x00000001803C9630
	[CompilerGenerated]
	private void _Awake_b__113_0(); // 0x00000001803CAAD0-0x00000001803CAAE0
	[CompilerGenerated]
	private void _Awake_b__113_1(); // 0x00000001803CAAE0-0x00000001803CAAF0
	[CompilerGenerated]
	private void _Awake_b__113_2(); // 0x00000001803CAAF0-0x00000001803CAB00
	[CompilerGenerated]
	private void _Awake_b__113_3(); // 0x00000001803CAB00-0x00000001803CAB10
	[CompilerGenerated]
	private void _Awake_b__113_4(); // 0x00000001803CAB10-0x00000001803CAB20
	[CompilerGenerated]
	private void _Awake_b__113_5(); // 0x00000001803CAB20-0x00000001803CAB30
	[CompilerGenerated]
	private void _SwapItem_b__120_0(SwapItemResponse response); // 0x00000001803CB060-0x00000001803CB1E0
	[CompilerGenerated]
	private void _SwapItem_b__120_1(string error); // 0x00000001803CB1E0-0x00000001803CB260
	[CompilerGenerated]
	private void _PlayPageFx_b__131_0(float v); // 0x00000001803CAFB0-0x00000001803CB060
	[CompilerGenerated]
	private void _MaybeFlashNewest_b__133_1(); // 0x00000001803CAFA0-0x00000001803CAFB0
	[CompilerGenerated]
	private void _BindPetTooltips_b__142_0(int _); // 0x00000001803CAB30-0x00000001803CAB60
	[CompilerGenerated]
	private void _BindPetTooltips_b__142_1(int _); // 0x00000001803CAB60-0x00000001803CAB90
	[CompilerGenerated]
	private void _ShowSourcePetTip_b__148_0(int _); // 0x00000001803CAB30-0x00000001803CAB60
	[CompilerGenerated]
	private void _ShowTargetPetTip_b__149_0(int _); // 0x00000001803CAB60-0x00000001803CAB90
	[CompilerGenerated]
	private void _EvolvePet_b__153_0(EvolutionResultDTO result); // 0x00000001803CAB90-0x00000001803CADF0
	[CompilerGenerated]
	private void _EvolvePet_b__153_1(string error); // 0x00000001803CADF0-0x00000001803CAFA0
}

