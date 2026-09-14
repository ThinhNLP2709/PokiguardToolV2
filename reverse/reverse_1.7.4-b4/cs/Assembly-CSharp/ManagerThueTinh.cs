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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerThueTinh : MonoBehaviour // TypeDefIndex: 1859
{
	// Fields
	public const string PANEL_KEY = "PanelMega"; // Metadata: 0x005F1620
	[Header("Main Panel")]
	public GameObject PanelThueTinh; // 0x20
	public Button btnOpenThueTinh; // 0x28
	public Button btnClose; // 0x30
	[Header("Pet List - Board")]
	public Transform Board; // 0x38
	public GameObject btnPetPrefab; // 0x40
	[Header("Pagination")]
	public Button btnLeft; // 0x48
	public Button btnRight; // 0x50
	public UnityEngine.UI.Text txtPageInfo; // 0x58
	[Header("Panel Body - Chi ti\u1EBFt")]
	public GameObject PanelBody; // 0x60
	public Animator anmtPetMain; // 0x68
	public Button btnThueTinh; // 0x70
	public UnityEngine.UI.Text txtstatus; // 0x78
	[Header("PanelPart1 - Pet Info")]
	public GameObject PanelPart1; // 0x80
	public Image imgPetSource; // 0x88
	public UnityEngine.UI.Text txtCurrentLevel; // 0x90
	public UnityEngine.UI.Text txtNamePet; // 0x98
	public UnityEngine.UI.Text txtDesReq; // 0xA0
	[Header("PanelPart2 - Crystal")]
	public GameObject PanelPart2; // 0xA8
	public UnityEngine.UI.Text txtCrystalCount; // 0xB0
	[Header("PanelPart3 - 9 Vi\u00EAn L\u00F5i")]
	public GameObject PanelPart3; // 0xB8
	[Tooltip("9 frame l\u00F5i theo th\u1EE9 t\u1EF1 1\u21929")]
	public GameObject[] frameCores; // 0xC0
	[Tooltip("9 Text current/required c\u1EE7a t\u1EEBng l\u00F5i")]
	public UnityEngine.UI.Text[] txtCountCores; // 0xC8
	[Tooltip("9 Sprite icon l\u00F5i")]
	public Sprite[] coreSprites; // 0xD0
	[Header("Panel Condition")]
	public GameObject PanelCondition; // 0xD8
	public UnityEngine.UI.Text txtCondition; // 0xE0
	[Header("Background")]
	public Image imgBg; // 0xE8
	[Header("Loading")]
	public GameObject loadingIndicator; // 0xF0
	[Header("Panel \u0110\u1ED5i L\u00F5i - pnlDoiItem")]
	[Tooltip("pnlDoiItem \u2014 panel t\u1ED5ng")]
	public GameObject pnlDoiItem; // 0xF8
	[Tooltip("btnBack \u2014 \u0111\u00F3ng panel, kh\u00F4ng \u0111\u1ED5i")]
	public Button btnBack; // 0x100
	[Tooltip("btnDoi \u2014 x\u00E1c nh\u1EADn \u0111\u1ED5i (ch\u1EC9 b\u1EADt khi C\u1EA2 4 lo\u1EA1i eItem \u0111\u1EC1u \u0111\u1EE7 4)")]
	public Button btnDoi; // 0x108
	[Tooltip("item1 \u2014 Image icon l\u00F5i \u0111ang \u0111\u01B0\u1EE3c ch\u1ECDn \u0111\u1ED5i")]
	public Image imgCorePreviewed; // 0x110
	[Tooltip("(Tu\u1EF3 ch\u1ECDn) Text t\u00EAn l\u00F5i \u0111ang ch\u1ECDn")]
	public UnityEngine.UI.Text txtCorePreviewName; // 0x118
	[Tooltip("4 frame eItem (frame1..frame4) trong swapitem1 > PanelPart3")]
	public GameObject[] frameEItems; // 0x120
	[Tooltip("txtcount trong m\u1ED7i frame \u2014 hi\u1EC3n th\u1ECB \'hi\u1EC7n c\u00F3 / 4\'")]
	public UnityEngine.UI.Text[] txtEItemCounts; // 0x128
	[Tooltip("4 Text trong PanelCurrent \u2014 s\u1ED1 eItem \u0111ang c\u00F3")]
	public UnityEngine.UI.Text[] txtCurrentEItems; // 0x130
	private const string FLAG_EVO_TOOLTIP = "evo.tooltip"; // Metadata: 0x005F162A
	private SkillCardBadge _cardBadge; // 0x138
	private string _srcTipTitle; // 0x140
	private string _srcTipBody; // 0x148
	private string _tgtTipTitle; // 0x150
	private string _tgtTipBody; // 0x158
	private Sprite _srcTipIcon; // 0x160
	private Sprite _tgtTipIcon; // 0x168
	private List<RewardDisplayHelper.Entry> _srcTipCard; // 0x170
	private List<RewardDisplayHelper.Entry> _tgtTipCard; // 0x178
	private Action _srcCardShow; // 0x180
	private Action _tgtCardShow; // 0x188
	private bool _srcTipFallbackWired; // 0x190
	private bool _tgtTipFallbackWired; // 0x191
	private PagedMegaAwakeningResponse awakeningData; // 0x198
	private MegaAwakeningDetailDTO currentDetail; // 0x1A0
	private int userId; // 0x1A8
	private long selectedPetId; // 0x1B0
	private int currentPage; // 0x1B8
	private int totalPages; // 0x1BC
	private const int PAGE_SIZE = 8; // Metadata: 0x005F1636
	private const int EITEM_COST = 4; // Metadata: 0x005F1637
	private List<GameObject> petButtons; // 0x1C0
	private int pendingCoreIndex; // 0x1C8
	public static readonly string[] CORE_NAMES; // 0x00
	public static readonly string[] CORE_SHEET_SPRITES; // 0x08
	public const string CORE_SHEET = "Image/stone/Object"; // Metadata: 0x005F1638
	private const float PET_FIT_W = 380f; // Metadata: 0x005F164B
	private const float PET_FIT_H = 250f; // Metadata: 0x005F164F

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1860
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, bool> __9__87_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__92_0; // 0x10
		public static Func<RequiredPetDTO, string> __9__92_1; // 0x18
		public static Func<RequiredPetDTO, bool> __9__93_0; // 0x20
		public static Func<RequiredPetDTO, string> __9__93_1; // 0x28

		// Constructors
		static __c(); // 0x0000000180918ED0-0x0000000180918F70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _OpenDoiItemPanel_b__87_0(int have); // 0x0000000180918F70-0x0000000180918F80
		internal string _DisplayConditionPets_b__92_0(RequiredPetDTO p); // 0x0000000180918F80-0x00000001809190C0
		internal string _DisplayConditionPets_b__92_1(RequiredPetDTO p); // 0x00000001809190C0-0x0000000180919200
		internal bool _DisplayStatus_b__93_0(RequiredPetDTO p); // 0x000000018048A100-0x000000018048A120
		internal string _DisplayStatus_b__93_1(RequiredPetDTO p); // 0x0000000180919200-0x0000000180919220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 1861
	{
		// Fields
		public long capturedId; // 0x10
		public GameObject capturedObj; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayPets_b__0(); // 0x0000000180919220-0x00000001809193D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 1862
	{
		// Fields
		public int captured; // 0x10
		public int have; // 0x14
		public int need; // 0x18
		public ManagerThueTinh __4__this; // 0x20
		public Action __9__2; // 0x28

		// Constructors
		public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal InfoPlayerActionTooltip.Model _DisplayCores_b__0(); // 0x00000001809193D0-0x0000000180919510
		internal void _DisplayCores_b__2(); // 0x0000000180919510-0x0000000180919540
		internal void _DisplayCores_b__1(); // 0x0000000180919510-0x0000000180919540
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass79_0 // TypeDefIndex: 1863
	{
		// Fields
		public string title; // 0x10
		public string body; // 0x18
		public Sprite icon; // 0x20

		// Constructors
		public __c__DisplayClass79_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CardShowAction_b__0(); // 0x0000000180919540-0x00000001809195D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1864
	{
		// Fields
		public int have; // 0x10
		public int need; // 0x14

		// Constructors
		public __c__DisplayClass85_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal InfoPlayerActionTooltip.Model _BindItemTooltips_b__0(); // 0x00000001809195D0-0x0000000180919640
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterAwaken_d__96 : IEnumerator<object> // TypeDefIndex: 1865
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshAfterAwaken_d__96(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180919640-0x0000000180919750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180919750-0x0000000180919790
	}

	// Constructors
	public ManagerThueTinh(); // 0x0000000180917CB0-0x0000000180918080
	static ManagerThueTinh(); // 0x0000000180918080-0x00000001809184B0

	// Methods
	private void Awake(); // 0x000000018090DE40-0x000000018090E260
	private void BindButtons(); // 0x000000018090E260-0x000000018090E910
	public void OpenPanel(); // 0x000000018090E910-0x000000018090EA70
	public void ClosePanel(); // 0x000000018090EA70-0x000000018090ECF0
	private void LoadAwakeningPets(); // 0x000000018090ECF0-0x000000018090EEA0
	private void DisplayPets(List<MegaAwakeningPetDTO> pets); // 0x000000018090EEA0-0x000000018090F8D0
	private void SelectPet(long petId); // 0x000000018090F8D0-0x000000018090F8E0
	private void LoadPetDetail(long petId); // 0x000000018090F8E0-0x000000018090FB70
	private void DisplayDetail(MegaAwakeningDetailDTO d); // 0x000000018090FB70-0x0000000180910760
	private void DisplayCores(MegaAwakeningDetailDTO d); // 0x0000000180910760-0x00000001809113F0
	private static bool EvoTipOn(); // 0x00000001809113F0-0x0000000180911460
	private Transform FindDeep(string nodeName); // 0x0000000180911460-0x0000000180911720
	private void ApplyCardAndTooltips(MegaAwakeningDetailDTO d); // 0x0000000180911720-0x0000000180911900
	private void BindSkillCardBadge(MegaAwakeningDetailDTO d); // 0x0000000180911900-0x0000000180911E70
	private void BindPetTooltips(MegaAwakeningDetailDTO d); // 0x0000000180911E70-0x0000000180912E80
	private static List<RewardDisplayHelper.Entry> CardEntry(long cardId, string cardName); // 0x0000000180912E80-0x0000000180913230
	private static Action CardShowAction(long cardId, string cardName, string desc, int mana, int power); // 0x0000000180913230-0x0000000180913550
	private static void WireFallback(GameObject go, ref bool wired, UnityAction show); // 0x0000000180913550-0x00000001809139C0
	private void ShowSourcePetTipHere(); // 0x00000001809139C0-0x00000001809139D0
	private void ShowTargetPetTipHere(); // 0x00000001809139D0-0x00000001809139E0
	public void ShowSourcePetTip(RectTransform anchor); // 0x00000001809139E0-0x0000000180913CB0
	public void ShowTargetPetTip(RectTransform anchor); // 0x0000000180913CB0-0x0000000180913FA0
	private void BindItemTooltips(MegaAwakeningDetailDTO d); // 0x0000000180913FA0-0x00000001809143C0
	private void HideAllTooltips(); // 0x00000001809143C0-0x0000000180914530
	private void OpenDoiItemPanel(int coreIndex); // 0x0000000180914530-0x00000001809151D0
	private void OnBtnDoiClick(); // 0x00000001809151D0-0x0000000180915400
	private void CloseDoiItemPanel(); // 0x0000000180915400-0x0000000180915550
	private void PatchDetailAfterSwap(SwapItemResultDTO result); // 0x0000000180915550-0x00000001809157E0
	private bool CheckCanAwakenLocal(); // 0x00000001809157E0-0x0000000180915880
	private void DisplayConditionPets(MegaAwakeningDetailDTO d); // 0x0000000180915880-0x0000000180915D90
	private void DisplayStatus(MegaAwakeningDetailDTO d); // 0x0000000180915D90-0x0000000180916380
	private void SetStatus(string msg, bool showBtn); // 0x0000000180916380-0x00000001809165B0
	private void AwakenPet(); // 0x00000001809165B0-0x0000000180916890
	[IteratorStateMachine(typeof(_RefreshAfterAwaken_d__96))]
	private IEnumerator RefreshAfterAwaken(); // 0x0000000180916890-0x0000000180916930
	private void PreviousPage(); // 0x0000000180916930-0x0000000180916950
	private void NextPage(); // 0x0000000180916950-0x0000000180916970
	private void UpdatePagination(); // 0x0000000180916970-0x0000000180916C70
	private void ShowLoading(); // 0x0000000180916C70-0x0000000180916DC0
	private void HideLoading(); // 0x0000000180916DC0-0x0000000180916F90
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180916F90-0x0000000180917830
	private PetImageFit EnsurePetFit(Image img); // 0x0000000180917830-0x0000000180917AE0
	private void OnDestroy(); // 0x0000000180917AE0-0x0000000180917CA0
	private void OnDisable(); // 0x0000000180917CA0-0x0000000180917CB0
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_0(PagedMegaAwakeningResponse data); // 0x00000001809184B0-0x00000001809185B0
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_1(string error); // 0x00000001809185B0-0x0000000180918640
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_0(MegaAwakeningDetailDTO detail); // 0x0000000180918640-0x00000001809186D0
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_1(string error); // 0x00000001809186D0-0x0000000180918760
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_0(int _); // 0x0000000180918760-0x0000000180918790
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_1(int _); // 0x0000000180918790-0x00000001809187C0
	[CompilerGenerated]
	private void _ShowSourcePetTip_b__83_0(int _); // 0x0000000180918760-0x0000000180918790
	[CompilerGenerated]
	private void _ShowTargetPetTip_b__84_0(int _); // 0x0000000180918790-0x00000001809187C0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_0(SwapItemResultDTO result); // 0x00000001809187C0-0x00000001809189E0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_1(string error); // 0x00000001809189E0-0x0000000180918A70
	[CompilerGenerated]
	private void _AwakenPet_b__95_0(MegaAwakeningResultDTO result); // 0x0000000180918A70-0x0000000180918D00
	[CompilerGenerated]
	private void _AwakenPet_b__95_1(string error); // 0x0000000180918D00-0x0000000180918ED0
}

