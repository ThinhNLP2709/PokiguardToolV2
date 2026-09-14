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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerThuVien : MonoBehaviour // TypeDefIndex: 2102
{
	// Fields
	public const string PANEL_KEY = "PanelThuVien"; // Metadata: 0x005F049B
	[Header("Pet List")]
	public GameObject petUIPrefab; // 0x20
	public Transform petListContainer; // 0x28
	[Header("Pagination")]
	public Button btnPrevPetPage; // 0x30
	public Button btnNextPetPage; // 0x38
	public UnityEngine.UI.Text txtPetPageNum; // 0x40
	public UnityEngine.UI.Text txtSummary; // 0x48
	[Header("Pet Detail")]
	public GameObject banner; // 0x50
	public UnityEngine.UI.Text namePet; // 0x58
	public UnityEngine.UI.Text txtHp; // 0x60
	public UnityEngine.UI.Text txtMana; // 0x68
	public UnityEngine.UI.Text txtDame; // 0x70
	public UnityEngine.UI.Text txtWee; // 0x78
	public UnityEngine.UI.Text txtLv; // 0x80
	public UnityEngine.UI.Text des; // 0x88
	public Image imgAtribute; // 0x90
	public Image imgAtributeOther; // 0x98
	[Header("Close")]
	public Button btnClose; // 0xA0
	private const int PETS_PER_PAGE = 20; // Metadata: 0x005F04A8
	private const string ELEMENT_BADGE = "imgElement"; // Metadata: 0x005F04A9
	private const string CELL_FRAME = "cellFrame"; // Metadata: 0x005F04B4
	private static readonly Color OwnedNameColor; // 0x00
	private static readonly Color LockedIconColor; // 0x10
	private static readonly Color LockedNameColor; // 0x20
	private static readonly Color LockedFrameColor; // 0x30
	private int currentPetPage; // 0xA8
	private PetLibraryPageResponse currentPetPageData; // 0xB0
	private bool hasLoadedPetsOnce; // 0xB8
	private bool isLoadingPetPage; // 0xB9
	public const int TAB_COUNT = 4; // Metadata: 0x005F04BE
	public const string TABS_FLAG = "thuvien.tabs"; // Metadata: 0x005F04BF
	private const string SKIN_ROOT = "PokySkin"; // Metadata: 0x005F04CC
	private const string LIB_TABS = "libTabs"; // Metadata: 0x005F04D5
	private const string TAB_PET = "tabPet"; // Metadata: 0x005F04DD
	private const string TAB_EFFECT = "tabEffect"; // Metadata: 0x005F04E4
	private const string TAB_CARD = "tabCard"; // Metadata: 0x005F04EE
	private const string TAB_AVATAR = "tabAvatar"; // Metadata: 0x005F04F6
	private const string TAB_LABEL = "lbl"; // Metadata: 0x005F0500
	private const string LIB_EFFECT_VIEW = "libEffectView"; // Metadata: 0x005F0504
	private const string LIB_CARD_VIEW = "libCardView"; // Metadata: 0x005F0512
	private const string LIB_AVATAR_VIEW = "libAvatarView"; // Metadata: 0x005F051E
	private const string PET_GRID = "PokyPetGrid"; // Metadata: 0x005F052C
	private const string HINT_LABEL = "Image/lblHint"; // Metadata: 0x005F0538
	private const string TITLE_PLATE = "Image (1)"; // Metadata: 0x005F0546
	private const string TAB_SPRITE_ON = "Image/Poky/ThuVien/btnTab_on"; // Metadata: 0x005F0550
	private const string TAB_SPRITE_OFF = "Image/Poky/ThuVien/btnTab_off"; // Metadata: 0x005F056D
	public static readonly Vector2 TITLE_LEGACY_POS; // 0x40
	public static readonly Vector2 TITLE_LEGACY_SIZE; // 0x48
	public const string TITLE_LEGACY_TEXT = "TH\u01AF VI\u1EC6N PET"; // Metadata: 0x005F058B
	public static readonly Vector2 TITLE_TABS_POS; // 0x50
	public static readonly Vector2 TITLE_TABS_SIZE; // 0x58
	public const string TITLE_TABS_TEXT = "TH\u01AF VI\u1EC6N"; // Metadata: 0x005F059B
	public static readonly Vector2 TABS_POS; // 0x60
	public static readonly Vector2 TABS_SIZE; // 0x68
	public static readonly Vector2 TAB_SIZE; // 0x70
	public const float TAB_GAP = 12f; // Metadata: 0x005F05A7
	public static readonly Vector2 LIB_VIEW_POS; // 0x78
	public static readonly Vector2 LIB_VIEW_SIZE; // 0x80
	private static readonly Color TabLabelOn; // 0x88
	private static readonly Color TabLabelOff; // 0x98
	private const float TAB_SCALE_ON = 1.06f; // Metadata: 0x005F05AB
	private const float VIEW_FX_TIME = 0.18f; // Metadata: 0x005F05AF
	private const float VIEW_FX_SLIDE = 24f; // Metadata: 0x005F05B3
	private Transform _libTabs; // 0xC0
	private Transform _libEffectView; // 0xC8
	private Transform _libCardView; // 0xD0
	private Transform _libAvatarView; // 0xD8
	private EffectLibView _effectView; // 0xE0
	private CardLibView _cardView; // 0xE8
	private AvatarLibView _avatarView; // 0xF0
	private Button _tabPet; // 0xF8
	private Button _tabEffect; // 0x100
	private Button _tabCard; // 0x108
	private Button _tabAvatar; // 0x110
	private UnityEngine.UI.Text _lblPet; // 0x118
	private UnityEngine.UI.Text _lblEffect; // 0x120
	private UnityEngine.UI.Text _lblCard; // 0x128
	private UnityEngine.UI.Text _lblAvatar; // 0x130
	private Transform _petGrid; // 0x138
	private UnityEngine.UI.Text _lblHint; // 0x140
	private RectTransform _titlePlate; // 0x148
	private UnityEngine.UI.Text _titleText; // 0x150
	private LibTab _tab; // 0x158
	private bool _tabsReady; // 0x15C
	private string _hintPet; // 0x160
	private string _summaryPet; // 0x168
	private static Sprite _spTabOn; // 0xA8
	private static Sprite _spTabOff; // 0xB0
	private static bool _spTabTried; // 0xB8
	private static Sprite _blankIcon; // 0xC0

	// Nested types
	public enum LibTab // TypeDefIndex: 2103
	{
		Pet = 0,
		Effect = 1,
		Card = 2,
		Avatar = 3
	}

	[Serializable]
	public class PetLibraryPageResponse // TypeDefIndex: 2104
	{
		// Fields
		public PetLibDTO[] content; // 0x10
		public int totalPages; // 0x18
		public int totalElements; // 0x1C
		public int number; // 0x20
		public int size; // 0x24
		public bool first; // 0x28
		public bool last; // 0x29
		public int numberOfElements; // 0x2C

		// Constructors
		public PetLibraryPageResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2105
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__106_1; // 0x08

		// Constructors
		static __c(); // 0x00000001809FD820-0x00000001809FD8C0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetsPage_b__106_1(string error); // 0x00000001809FD8C0-0x00000001809FD940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2106
	{
		// Fields
		public ManagerThuVien __4__this; // 0x10
		public Sprite capturedIcon; // 0x18
		public PetLibDTO captured; // 0x20

		// Constructors
		public __c__DisplayClass108_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _InstantiatePetItem_b__0(); // 0x00000001809FD940-0x00000001809FD970
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_1 // TypeDefIndex: 2107
	{
		// Fields
		public RectTransform cellRt; // 0x10
		public PetLibDTO forTip; // 0x18

		// Constructors
		public __c__DisplayClass108_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _InstantiatePetItem_b__1(); // 0x00000001809FD970-0x00000001809FDAF0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__106 : IEnumerator<object> // TypeDefIndex: 2108
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThuVien __4__this; // 0x20
		public int page; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__106(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809FDAF0-0x00000001809FE180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809FE180-0x00000001809FE1C0
	}

	// Constructors
	public ManagerThuVien(); // 0x00000001809FD460-0x00000001809FD510
	static ManagerThuVien(); // 0x00000001809FD510-0x00000001809FD6E0

	// Methods
	private void OnDisable(); // 0x00000001809F4420-0x00000001809F4430
	public static float TabX(int index); // 0x00000001809F4430-0x00000001809F44B0
	private void WireLibTabs(); // 0x00000001809F44B0-0x00000001809F5970
	private Button FindTab(string node, out UnityEngine.UI.Text label); // 0x00000001809F5970-0x00000001809F5D20
	private void LayoutTabsEvenly(); // 0x00000001809F5D20-0x00000001809F6A80
	public void SwitchTab(LibTab tab, bool instant = false /* Metadata: 0x005F049A */); // 0x00000001809F6A80-0x00000001809F7400
	private void ShowView(Transform view, bool show, bool instant); // 0x00000001809F7400-0x00000001809F7BF0
	private static void PaintTab(Button tab, UnityEngine.UI.Text label, bool selected); // 0x00000001809F7BF0-0x00000001809F81F0
	private static void LoadTabSprites(); // 0x00000001809F81F0-0x00000001809F83C0
	private void RefreshLibSummary(); // 0x00000001809F83C0-0x00000001809F8B20
	private void ApplyTitleGeometry(bool withTabs); // 0x00000001809F8B20-0x00000001809F8DF0
	private static bool FxOn(); // 0x00000001809F8DF0-0x00000001809F8E40
	private void Awake(); // 0x00000001809F8E40-0x00000001809F9160
	public void Open(); // 0x00000001809F9160-0x00000001809F91B0
	public void Close(); // 0x00000001809F91B0-0x00000001809F93B0
	[IteratorStateMachine(typeof(_LoadPetsPage_d__106))]
	private IEnumerator LoadPetsPage(int page); // 0x00000001809F93B0-0x00000001809F9460
	private void DisplayCurrentPetPage(); // 0x00000001809F9460-0x00000001809F9840
	private void InstantiatePetItem(PetLibDTO pet); // 0x00000001809F9840-0x00000001809FA4E0
	private void FitCellContent(Transform cell); // 0x00000001809FA4E0-0x00000001809FAC50
	private static void ApplyOwnedLook(GameObject cell, Image petIcon, UnityEngine.UI.Text txtNamePet, bool owned); // 0x00000001809FAC50-0x00000001809FB1E0
	private void AddElementBadge(Transform cell, string elementType); // 0x00000001809FB1E0-0x00000001809FB930
	private static Sprite BlankIcon(); // 0x00000001809FB930-0x00000001809FBD60
	private void UpdatePetPaginationButtons(); // 0x00000001809FBD60-0x00000001809FC280
	private void SetPetPaginationButtonsState(bool enabled); // 0x00000001809FC280-0x00000001809FC440
	private void ShowPreviousPetPage(); // 0x00000001809FC440-0x00000001809FC4A0
	private void ShowNextPetPage(); // 0x00000001809FC4A0-0x00000001809FC500
	private void OnPetClicked(Sprite petSprite, PetLibDTO pet); // 0x00000001809FC500-0x00000001809FCEB0
	private static bool StatsHidden(PetLibDTO p); // 0x00000001809FCEB0-0x00000001809FCED0
	private static string StatText(int v, bool hidden); // 0x00000001809FCED0-0x00000001809FCF80
	private static string ElementVi(string code); // 0x00000001809FCF80-0x00000001809FD020
	private static string TooltipTitle(PetLibDTO pet); // 0x00000001809FD020-0x00000001809FD0F0
	private static string TooltipBody(PetLibDTO pet); // 0x00000001809FD0F0-0x00000001809FD460
	[CompilerGenerated]
	private void _WireLibTabs_b__92_0(); // 0x00000001809FD6E0-0x00000001809FD6F0
	[CompilerGenerated]
	private void _WireLibTabs_b__92_1(); // 0x00000001809FD6F0-0x00000001809FD700
	[CompilerGenerated]
	private void _WireLibTabs_b__92_2(); // 0x00000001809FD700-0x00000001809FD710
	[CompilerGenerated]
	private void _WireLibTabs_b__92_3(); // 0x00000001809FD710-0x00000001809FD720
	[CompilerGenerated]
	private void _LoadPetsPage_b__106_0(PetLibraryPageResponse data); // 0x00000001809FD720-0x00000001809FD820
}

