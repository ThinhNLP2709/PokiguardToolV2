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

public class ManagerThueTinh : MonoBehaviour // TypeDefIndex: 1474
{
	// Fields
	public const string PANEL_KEY = "PanelMega"; // Metadata: 0x0068D125
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
	private const string FLAG_EVO_TOOLTIP = "evo.tooltip"; // Metadata: 0x0068D12F
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
	private const int PAGE_SIZE = 8; // Metadata: 0x0068D13B
	private const int EITEM_COST = 4; // Metadata: 0x0068D13C
	private List<GameObject> petButtons; // 0x1C0
	private int pendingCoreIndex; // 0x1C8
	public static readonly string[] CORE_NAMES; // 0x00
	public static readonly string[] CORE_SHEET_SPRITES; // 0x08
	public const string CORE_SHEET = "Image/stone/Object"; // Metadata: 0x0068D13D
	private const float PET_FIT_W = 380f; // Metadata: 0x0068D150
	private const float PET_FIT_H = 250f; // Metadata: 0x0068D154

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1475
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, bool> __9__87_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__92_0; // 0x10
		public static Func<RequiredPetDTO, string> __9__92_1; // 0x18
		public static Func<RequiredPetDTO, bool> __9__93_0; // 0x20
		public static Func<RequiredPetDTO, string> __9__93_1; // 0x28

		// Constructors
		static __c(); // 0x00000001805EB260-0x00000001805EB2D0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _OpenDoiItemPanel_b__87_0(int have); // 0x00000001805EA430-0x00000001805EA440
		internal string _DisplayConditionPets_b__92_0(RequiredPetDTO p); // 0x00000001805EA190-0x00000001805EA2D0
		internal string _DisplayConditionPets_b__92_1(RequiredPetDTO p); // 0x00000001805EA2D0-0x00000001805EA410
		internal bool _DisplayStatus_b__93_0(RequiredPetDTO p); // 0x00000001803F4F30-0x00000001803F4F50
		internal string _DisplayStatus_b__93_1(RequiredPetDTO p); // 0x00000001805EA410-0x00000001805EA430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 1476
	{
		// Fields
		public long capturedId; // 0x10
		public GameObject capturedObj; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Constructors
		public __c__DisplayClass68_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayPets_b__0(); // 0x00000001805EAF40-0x00000001805EB060
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 1477
	{
		// Fields
		public int captured; // 0x10
		public int have; // 0x14
		public int need; // 0x18
		public ManagerThueTinh __4__this; // 0x20
		public Action __9__2; // 0x28

		// Constructors
		public __c__DisplayClass72_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal InfoPlayerActionTooltip.Model _DisplayCores_b__0(); // 0x00000001805EB060-0x00000001805EB150
		internal void _DisplayCores_b__2(); // 0x00000001805EB150-0x00000001805EB180
		internal void _DisplayCores_b__1(); // 0x00000001805EB150-0x00000001805EB180
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass79_0 // TypeDefIndex: 1478
	{
		// Fields
		public string title; // 0x10
		public string body; // 0x18
		public Sprite icon; // 0x20

		// Constructors
		public __c__DisplayClass79_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CardShowAction_b__0(); // 0x00000001805EB180-0x00000001805EB200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1479
	{
		// Fields
		public int have; // 0x10
		public int need; // 0x14

		// Constructors
		public __c__DisplayClass85_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal InfoPlayerActionTooltip.Model _BindItemTooltips_b__0(); // 0x00000001805EB200-0x00000001805EB260
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterAwaken_d__96 : IEnumerator<object> // TypeDefIndex: 1480
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshAfterAwaken_d__96(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E9670-0x00000001805E9740
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9740-0x00000001805E9780
	}

	// Constructors
	public ManagerThueTinh(); // 0x00000001805E27A0-0x00000001805E2940
	static ManagerThueTinh(); // 0x00000001805E23E0-0x00000001805E27A0

	// Methods
	private void Awake(); // 0x00000001805DC350-0x00000001805DC4B0
	private void BindButtons(); // 0x00000001805DC630-0x00000001805DC9A0
	public void OpenPanel(); // 0x00000001805E0AD0-0x00000001805E0B60
	public void ClosePanel(); // 0x00000001805DDBE0-0x00000001805DDD50
	private void LoadAwakeningPets(); // 0x00000001805DFDF0-0x00000001805DFF50
	private void DisplayPets(List<MegaAwakeningPetDTO> pets); // 0x00000001805DEF80-0x00000001805DF5B0
	private void SelectPet(long petId); // 0x00000001805E0E80-0x00000001805E0E90
	private void LoadPetDetail(long petId); // 0x00000001805DFF50-0x00000001805E00A0
	private void DisplayDetail(MegaAwakeningDetailDTO d); // 0x00000001805DE990-0x00000001805DEF80
	private void DisplayCores(MegaAwakeningDetailDTO d); // 0x00000001805DE0B0-0x00000001805DE990
	private static bool EvoTipOn(); // 0x00000001805DFAB0-0x00000001805DFB10
	private Transform FindDeep(string nodeName); // 0x00000001805DFB10-0x00000001805DFC60
	private void ApplyCardAndTooltips(MegaAwakeningDetailDTO d); // 0x00000001805DC240-0x00000001805DC350
	private void BindSkillCardBadge(MegaAwakeningDetailDTO d); // 0x00000001805DD440-0x00000001805DD680
	private void BindPetTooltips(MegaAwakeningDetailDTO d); // 0x00000001805DCBE0-0x00000001805DD440
	private static List<RewardDisplayHelper.Entry> CardEntry(long cardId, string cardName); // 0x00000001805DD680-0x00000001805DD8D0
	private static Action CardShowAction(long cardId, string cardName, string desc, int mana, int power); // 0x00000001805DD8D0-0x00000001805DDAB0
	private static void WireFallback(GameObject go, ref bool wired, UnityAction show); // 0x00000001805E2240-0x00000001805E23E0
	private void ShowSourcePetTipHere(); // 0x00000001805E0FF0-0x00000001805E1000
	private void ShowTargetPetTipHere(); // 0x00000001805E11B0-0x00000001805E11C0
	public void ShowSourcePetTip(RectTransform anchor); // 0x00000001805E1000-0x00000001805E11B0
	public void ShowTargetPetTip(RectTransform anchor); // 0x00000001805E11C0-0x00000001805E1390
	private void BindItemTooltips(MegaAwakeningDetailDTO d); // 0x00000001805DC9A0-0x00000001805DCBE0
	private void HideAllTooltips(); // 0x00000001805DFC60-0x00000001805DFD40
	private void OpenDoiItemPanel(int coreIndex); // 0x00000001805E0350-0x00000001805E0AD0
	private void OnBtnDoiClick(); // 0x00000001805E00C0-0x00000001805E0290
	private void CloseDoiItemPanel(); // 0x00000001805DDB50-0x00000001805DDBE0
	private void PatchDetailAfterSwap(SwapItemResultDTO result); // 0x00000001805E0B60-0x00000001805E0DF0
	private bool CheckCanAwakenLocal(); // 0x00000001805DDAB0-0x00000001805DDB50
	private void DisplayConditionPets(MegaAwakeningDetailDTO d); // 0x00000001805DDD50-0x00000001805DE0B0
	private void DisplayStatus(MegaAwakeningDetailDTO d); // 0x00000001805DF5B0-0x00000001805DF990
	private void SetStatus(string msg, bool showBtn); // 0x00000001805E0E90-0x00000001805E0F70
	private void AwakenPet(); // 0x00000001805DC4B0-0x00000001805DC630
	[IteratorStateMachine(typeof(_RefreshAfterAwaken_d__96))]
	private IEnumerator RefreshAfterAwaken(); // 0x00000001805E0E10-0x00000001805E0E80
	private void PreviousPage(); // 0x00000001805E0DF0-0x00000001805E0E10
	private void NextPage(); // 0x00000001805E00A0-0x00000001805E00C0
	private void UpdatePagination(); // 0x00000001805E20E0-0x00000001805E2240
	private void ShowLoading(); // 0x00000001805E0F70-0x00000001805E0FF0
	private void HideLoading(); // 0x00000001805DFD40-0x00000001805DFDF0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x00000001805E1390-0x00000001805E1880
	private PetImageFit EnsurePetFit(Image img); // 0x00000001805DF990-0x00000001805DFAB0
	private void OnDestroy(); // 0x00000001805E0290-0x00000001805E0340
	private void OnDisable(); // 0x00000001805E0340-0x00000001805E0350
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_0(PagedMegaAwakeningResponse data); // 0x00000001805E1BD0-0x00000001805E1DB0
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__67_1(string error); // 0x00000001805E1DB0-0x00000001805E1E30
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_0(MegaAwakeningDetailDTO detail); // 0x00000001805E1E30-0x00000001805E1E80
	[CompilerGenerated]
	private void _LoadPetDetail_b__70_1(string error); // 0x00000001805E1E80-0x00000001805E1F00
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_0(int _); // 0x00000001805E1B70-0x00000001805E1BA0
	[CompilerGenerated]
	private void _BindPetTooltips_b__77_1(int _); // 0x00000001805E1BA0-0x00000001805E1BD0
	[CompilerGenerated]
	private void _ShowSourcePetTip_b__83_0(int _); // 0x00000001805E1B70-0x00000001805E1BA0
	[CompilerGenerated]
	private void _ShowTargetPetTip_b__84_0(int _); // 0x00000001805E1BA0-0x00000001805E1BD0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_0(SwapItemResultDTO result); // 0x00000001805E1F00-0x00000001805E2060
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__88_1(string error); // 0x00000001805E2060-0x00000001805E20E0
	[CompilerGenerated]
	private void _AwakenPet_b__95_0(MegaAwakeningResultDTO result); // 0x00000001805E1880-0x00000001805E1A10
	[CompilerGenerated]
	private void _AwakenPet_b__95_1(string error); // 0x00000001805E1A10-0x00000001805E1B70
}

