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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerThueTinh : MonoBehaviour // TypeDefIndex: 1857
{
	// Fields
	public const string PANEL_KEY = "PanelMega"; // Metadata: 0x005F024F
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
	private const string FLAG_EVO_TOOLTIP = "evo.tooltip"; // Metadata: 0x005F0259
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
	private const int PAGE_SIZE = 8; // Metadata: 0x005F0265
	private const int EITEM_COST = 4; // Metadata: 0x005F0266
	private List<GameObject> petButtons; // 0x1C0
	private int pendingCoreIndex; // 0x1C8
	public static readonly string[] CORE_NAMES; // 0x00
	public static readonly string[] CORE_SHEET_SPRITES; // 0x08
	public const string CORE_SHEET = "Image/stone/Object"; // Metadata: 0x005F0267
	private const float PET_FIT_W = 380f; // Metadata: 0x005F027A
	private const float PET_FIT_H = 250f; // Metadata: 0x005F027E

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1858
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, bool> __9__87_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__92_0; // 0x10
		public static Func<RequiredPetDTO, string> __9__92_1; // 0x18
		public static Func<RequiredPetDTO, bool> __9__93_0; // 0x20
		public static Func<RequiredPetDTO, string> __9__93_1; // 0x28

		// Constructors
		static __c(); // 0x0000000180915A70-0x0000000180915B10
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _OpenDoiItemPanel_b__87_0(int have); // 0x0000000180915B10-0x0000000180915B20
		internal string _DisplayConditionPets_b__92_0(RequiredPetDTO p); // 0x0000000180915B20-0x0000000180915C60
		internal string _DisplayConditionPets_b__92_1(RequiredPetDTO p); // 0x0000000180915C60-0x0000000180915DA0
		internal bool _DisplayStatus_b__93_0(RequiredPetDTO p); // 0x0000000180488E90-0x0000000180488EB0
		internal string _DisplayStatus_b__93_1(RequiredPetDTO p); // 0x0000000180915DA0-0x0000000180915DC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 1859
	{
		// Fields
		public long capturedId; // 0x10
		public GameObject capturedObj; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayPets_b__0(); // 0x0000000180915DC0-0x0000000180915F70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 1860
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
		internal InfoPlayerActionTooltip.Model _DisplayCores_b__0(); // 0x0000000180915F70-0x00000001809160B0
		internal void _DisplayCores_b__2(); // 0x00000001809160B0-0x00000001809160E0
		internal void _DisplayCores_b__1(); // 0x00000001809160B0-0x00000001809160E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass79_0 // TypeDefIndex: 1861
	{
		// Fields
		public string title; // 0x10
		public string body; // 0x18
		public Sprite icon; // 0x20

		// Constructors
		public __c__DisplayClass79_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CardShowAction_b__0(); // 0x00000001809160E0-0x0000000180916170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1862
	{
		// Fields
		public int have; // 0x10
		public int need; // 0x14

		// Constructors
		public __c__DisplayClass85_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal InfoPlayerActionTooltip.Model _BindItemTooltips_b__0(); // 0x0000000180916170-0x00000001809161E0
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterAwaken_d__96 : IEnumerator<object> // TypeDefIndex: 1863
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809161E0-0x00000001809162F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809162F0-0x0000000180916330
	}

	// Constructors
	public ManagerThueTinh(); // 0x00000001809148D0-0x0000000180914CA0
	static ManagerThueTinh(); // 0x0000000180914CA0-0x00000001809150D0

	// Methods
	private void Awake(); // 0x000000018090AAF0-0x000000018090AF10
	private void BindButtons(); // 0x000000018090AF10-0x000000018090B5C0
	public void OpenPanel(); // 0x000000018090B5C0-0x000000018090B720
	public void ClosePanel(); // 0x000000018090B720-0x000000018090B9A0
	private void LoadAwakeningPets(); // 0x000000018090B9A0-0x000000018090BB30
	private void DisplayPets(List<MegaAwakeningPetDTO> pets); // 0x000000018090BB30-0x000000018090C560
	private void SelectPet(long petId); // 0x000000018090C560-0x000000018090C570
	private void LoadPetDetail(long petId); // 0x000000018090C570-0x000000018090C7D0
	private void DisplayDetail(MegaAwakeningDetailDTO d); // 0x000000018090C7D0-0x000000018090D3C0
	private void DisplayCores(MegaAwakeningDetailDTO d); // 0x000000018090D3C0-0x000000018090E050
	private static bool EvoTipOn(); // 0x000000018090E050-0x000000018090E0C0
	private Transform FindDeep(string nodeName); // 0x000000018090E0C0-0x000000018090E380
	private void ApplyCardAndTooltips(MegaAwakeningDetailDTO d); // 0x000000018090E380-0x000000018090E560
	private void BindSkillCardBadge(MegaAwakeningDetailDTO d); // 0x000000018090E560-0x000000018090EAD0
	private void BindPetTooltips(MegaAwakeningDetailDTO d); // 0x000000018090EAD0-0x000000018090FAE0
	private static List<RewardDisplayHelper.Entry> CardEntry(long cardId, string cardName); // 0x000000018090FAE0-0x000000018090FE90
	private static Action CardShowAction(long cardId, string cardName, string desc, int mana, int power); // 0x000000018090FE90-0x00000001809101B0
	private static void WireFallback(GameObject go, ref bool wired, UnityAction show); // 0x00000001809101B0-0x0000000180910620
	private void ShowSourcePetTipHere(); // 0x0000000180910620-0x0000000180910630
	private void ShowTargetPetTipHere(); // 0x0000000180910630-0x0000000180910640
	public void ShowSourcePetTip(RectTransform anchor); // 0x0000000180910640-0x0000000180910910
	public void ShowTargetPetTip(RectTransform anchor); // 0x0000000180910910-0x0000000180910C00
	private void BindItemTooltips(MegaAwakeningDetailDTO d); // 0x0000000180910C00-0x0000000180911020
	private void HideAllTooltips(); // 0x0000000180911020-0x0000000180911190
	private void OpenDoiItemPanel(int coreIndex); // 0x0000000180911190-0x0000000180911E30
	private void OnBtnDoiClick(); // 0x0000000180911E30-0x0000000180912040
	private void CloseDoiItemPanel(); // 0x0000000180912040-0x0000000180912190
	private void PatchDetailAfterSwap(SwapItemResultDTO result); // 0x0000000180912190-0x0000000180912420
	private bool CheckCanAwakenLocal(); // 0x0000000180912420-0x00000001809124C0
	private void DisplayConditionPets(MegaAwakeningDetailDTO d); // 0x00000001809124C0-0x00000001809129D0
	private void DisplayStatus(MegaAwakeningDetailDTO d); // 0x00000001809129D0-0x0000000180912FC0
	private void SetStatus(string msg, bool showBtn); // 0x0000000180912FC0-0x00000001809131F0
	private void AwakenPet(); // 0x00000001809131F0-0x00000001809134B0
	[IteratorStateMachine(typeof(_RefreshAfterAwaken_d__96))]
	private IEnumerator RefreshAfterAwaken(); // 0x00000001809134B0-0x0000000180913550
	private void PreviousPage(); // 0x0000000180913550-0x0000000180913570
	private void NextPage(); // 0x0000000180913570-0x0000000180913590
	private void UpdatePagination(); // 0x0000000180913590-0x0000000180913890
	private void ShowLoading(); // 0x0000000180913890-0x00000001809139E0
	private void HideLoading(); // 0x00000001809139E0-0x0000000180913BB0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180913BB0-0x0000000180914450
	private PetImageFit EnsurePetFit(Image img); // 0x0000000180914450-0x0000000180914700
	private void OnDestroy(); // 0x0000000180914700-0x00000001809148C0
	private void OnDisable(); // 0x00000001809148C0-0x00000001809148D0
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_0(PagedMegaAwakeningResponse data); // 0x00000001809150D0-0x00000001809151D0
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_1(string error); // 0x00000001809151D0-0x0000000180915260
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_0(MegaAwakeningDetailDTO detail); // 0x0000000180915260-0x00000001809152F0
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_1(string error); // 0x00000001809152F0-0x0000000180915380
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_0(int _); // 0x0000000180915380-0x00000001809153B0
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_1(int _); // 0x00000001809153B0-0x00000001809153E0
	[CompilerGenerated]
	private void _ShowSourcePetTip_b__83_0(int _); // 0x0000000180915380-0x00000001809153B0
	[CompilerGenerated]
	private void _ShowTargetPetTip_b__84_0(int _); // 0x00000001809153B0-0x00000001809153E0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_0(SwapItemResultDTO result); // 0x00000001809153E0-0x00000001809155D0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_1(string error); // 0x00000001809155D0-0x0000000180915660
	[CompilerGenerated]
	private void _AwakenPet_b__95_0(MegaAwakeningResultDTO result); // 0x0000000180915660-0x00000001809158C0
	[CompilerGenerated]
	private void _AwakenPet_b__95_1(string error); // 0x00000001809158C0-0x0000000180915A70
}

