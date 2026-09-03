/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerTienHoa : MonoBehaviour // TypeDefIndex: 491
{
	// Fields
	public const string PANEL_KEY = "PanelTienhoa"; // Metadata: 0x0064C4CC
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
	private const int PAGE_SIZE = 8; // Metadata: 0x0064C4D9
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
	private const float SELECTED_SCALE = 1.08f; // Metadata: 0x0064C4DA
	private const string PREF_SEEN_TOP = "EvoSeenTopSourcePet"; // Metadata: 0x0064C4DE
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
	private PagedEvolutionResponse evolutionData; // 0x290
	private EvolutionDetailDTO currentDetail; // 0x298
	private int userId; // 0x2A0
	private long selectedPetId; // 0x2A8
	private int currentStarWhite; // 0x2B0
	private int currentStarBlue; // 0x2B4
	private int currentStarRed; // 0x2B8
	private int currentEItem1; // 0x2BC
	private int currentEItem2; // 0x2C0
	private int currentEItem3; // 0x2C4
	private int currentEItem4; // 0x2C8

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 492
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<RequiredPetDTO, bool> __9__122_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__122_1; // 0x10
		public static Func<RequiredPetDTO, string> __9__122_2; // 0x18

		// Constructors
		static __c(); // 0x000000018038E1E0-0x000000018038E250
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _DisplayDetail_b__122_0(RequiredPetDTO p); // 0x000000018038C8E0-0x000000018038C900
		internal string _DisplayDetail_b__122_1(RequiredPetDTO p); // 0x000000018038C900-0x000000018038C960
		internal string _DisplayDetail_b__122_2(RequiredPetDTO p); // 0x000000018038C960-0x000000018038CAB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_0 // TypeDefIndex: 493
	{
		// Fields
		public ManagerTienHoa __4__this; // 0x10
		public int seq; // 0x18
		public bool keepSelection; // 0x1C
		public long keepPetId; // 0x20

		// Constructors
		public __c__DisplayClass108_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadEvolutionPets_b__0(PagedEvolutionResponse data); // 0x000000018038CB90-0x000000018038CE40
		internal void _LoadEvolutionPets_b__1(string error); // 0x000000018038CE40-0x000000018038CEF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 494
	{
		// Fields
		public long capturedPetId; // 0x10
		public ManagerTienHoa __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayPets_b__0(); // 0x000000018038CEF0-0x000000018038CF20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass119_0 // TypeDefIndex: 495
	{
		// Fields
		public Image frame; // 0x10

		// Constructors
		public __c__DisplayClass119_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _MaybeFlashNewest_b__0(float v); // 0x000000018038CF20-0x000000018038D090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 496
	{
		// Fields
		public ManagerTienHoa __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass121_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetDetail_b__0(EvolutionDetailDTO detail); // 0x000000018038D090-0x000000018038D210
		internal void _LoadPetDetail_b__1(string error); // 0x000000018038D210-0x000000018038D2B0
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterEvolution_d__126 : IEnumerator<object> // TypeDefIndex: 497
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTienHoa __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshAfterEvolution_d__126(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018038C7E0-0x000000018038C8A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038C8A0-0x000000018038C8E0
	}

	// Constructors
	public ManagerTienHoa(); // 0x000000018036ABB0-0x000000018036ACE0
	static ManagerTienHoa(); // 0x000000018036AB30-0x000000018036ABB0

	// Methods
	private void Awake(); // 0x00000001803651B0-0x00000001803659D0
	private void LoadCurrentResources(); // 0x00000001803683E0-0x0000000180368470
	public void OpenPanel(); // 0x0000000180368EB0-0x0000000180368F40
	public void ClosePanel(); // 0x0000000180366130-0x0000000180366290
	public void OpenPanelDoi(); // 0x0000000180368E20-0x0000000180368EB0
	public void ClosePanelDoi(); // 0x00000001803660B0-0x0000000180366130
	private void UpdateSwapUI(); // 0x000000018036A610-0x000000018036AB30
	private void SwapItem(int swapType); // 0x00000001803697F0-0x0000000180369950
	private void LoadEvolutionPets(); // 0x0000000180368470-0x0000000180368640
	private void LoadEvolutionPets(bool keepSelection); // 0x0000000180368640-0x0000000180368810
	private void SetPagingButtons(bool on); // 0x00000001803696C0-0x0000000180369770
	private void CacheBoardRefs(); // 0x00000001803659D0-0x0000000180365B90
	private int ComputeSlotsPerPage(); // 0x0000000180366290-0x00000001803664B0
	private void DisplayPets(List<EvolutionPetDTO> pets); // 0x0000000180367160-0x0000000180367600
	private void ClearPetButtons(); // 0x0000000180365E60-0x00000001803660B0
	private Vector3 RestScaleOf(int i); // 0x00000001803695D0-0x0000000180369680
	private void HighlightSelected(bool animate); // 0x0000000180367F70-0x00000001803683E0
	private void PlayStaggerIn(); // 0x0000000180369230-0x0000000180369460
	private void PlayPageFx(int dir); // 0x0000000180368F40-0x0000000180369230
	private void ResetBoardPosition(); // 0x00000001803694F0-0x00000001803695D0
	private void MaybeFlashNewest(List<EvolutionPetDTO> pets); // 0x00000001803689B0-0x0000000180368CF0
	private void SelectPet(long petId); // 0x0000000180369680-0x00000001803696C0
	private void LoadPetDetail(long petId); // 0x0000000180368810-0x00000001803689B0
	private void DisplayDetail(EvolutionDetailDTO detail); // 0x00000001803664B0-0x0000000180367160
	private void DisplayStoneRequirements(List<StoneRequirementDTO> stones); // 0x0000000180367600-0x0000000180367BC0
	private Sprite GetStoneSpriteByElement(string elementType); // 0x0000000180367D80-0x0000000180367EC0
	private void EvolvePet(); // 0x0000000180367BC0-0x0000000180367D80
	[IteratorStateMachine(typeof(_RefreshAfterEvolution_d__126))]
	private IEnumerator RefreshAfterEvolution(); // 0x0000000180369480-0x00000001803694F0
	private void PreviousPage(); // 0x0000000180369460-0x0000000180369480
	private void NextPage(); // 0x0000000180368CF0-0x0000000180368D10
	private void UpdatePagination(); // 0x000000018036A490-0x000000018036A610
	private void OnDisable(); // 0x0000000180368D20-0x0000000180368E20
	private void CancelAllTweens(); // 0x0000000180365B90-0x0000000180365E60
	private void ShowLoading(); // 0x0000000180369770-0x00000001803697F0
	private void HideLoading(); // 0x0000000180367EC0-0x0000000180367F70
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180369950-0x0000000180369D60
	private void OnDestroy(); // 0x0000000180368D10-0x0000000180368D20
	[CompilerGenerated]
	private void _Awake_b__99_0(); // 0x0000000180369D60-0x0000000180369D70
	[CompilerGenerated]
	private void _Awake_b__99_1(); // 0x0000000180369D70-0x0000000180369D80
	[CompilerGenerated]
	private void _Awake_b__99_2(); // 0x0000000180369D80-0x0000000180369D90
	[CompilerGenerated]
	private void _Awake_b__99_3(); // 0x0000000180369D90-0x0000000180369DA0
	[CompilerGenerated]
	private void _Awake_b__99_4(); // 0x0000000180369DA0-0x0000000180369DB0
	[CompilerGenerated]
	private void _Awake_b__99_5(); // 0x0000000180369DB0-0x0000000180369DC0
	[CompilerGenerated]
	private void _SwapItem_b__106_0(SwapItemResponse response); // 0x000000018036A290-0x000000018036A410
	[CompilerGenerated]
	private void _SwapItem_b__106_1(string error); // 0x000000018036A410-0x000000018036A490
	[CompilerGenerated]
	private void _PlayPageFx_b__117_0(float v); // 0x000000018036A1E0-0x000000018036A290
	[CompilerGenerated]
	private void _MaybeFlashNewest_b__119_1(); // 0x000000018036A1D0-0x000000018036A1E0
	[CompilerGenerated]
	private void _EvolvePet_b__125_0(EvolutionResultDTO result); // 0x0000000180369DC0-0x000000018036A020
	[CompilerGenerated]
	private void _EvolvePet_b__125_1(string error); // 0x000000018036A020-0x000000018036A1D0
}

