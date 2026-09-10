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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerThuVien : MonoBehaviour // TypeDefIndex: 1742
{
	// Fields
	public const string PANEL_KEY = "PanelThuVien"; // Metadata: 0x0068D66A
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
	private const int PETS_PER_PAGE = 20; // Metadata: 0x0068D677
	private const string ELEMENT_BADGE = "imgElement"; // Metadata: 0x0068D678
	private const string CELL_FRAME = "cellFrame"; // Metadata: 0x0068D683
	private static readonly Color OwnedNameColor; // 0x00
	private static readonly Color LockedIconColor; // 0x10
	private static readonly Color LockedNameColor; // 0x20
	private static readonly Color LockedFrameColor; // 0x30
	private int currentPetPage; // 0xA8
	private PetLibraryPageResponse currentPetPageData; // 0xB0
	private bool hasLoadedPetsOnce; // 0xB8
	private bool isLoadingPetPage; // 0xB9
	public const string TABS_FLAG = "thuvien.tabs"; // Metadata: 0x0068D68D
	private const string SKIN_ROOT = "PokySkin"; // Metadata: 0x0068D69A
	private const string LIB_TABS = "libTabs"; // Metadata: 0x0068D6A3
	private const string TAB_PET = "tabPet"; // Metadata: 0x0068D6AB
	private const string TAB_EFFECT = "tabEffect"; // Metadata: 0x0068D6B2
	private const string TAB_CARD = "tabCard"; // Metadata: 0x0068D6BC
	private const string TAB_LABEL = "lbl"; // Metadata: 0x0068D6C4
	private const string LIB_EFFECT_VIEW = "libEffectView"; // Metadata: 0x0068D6C8
	private const string LIB_CARD_VIEW = "libCardView"; // Metadata: 0x0068D6D6
	private const string PET_GRID = "PokyPetGrid"; // Metadata: 0x0068D6E2
	private const string HINT_LABEL = "Image/lblHint"; // Metadata: 0x0068D6EE
	private const string TITLE_PLATE = "Image (1)"; // Metadata: 0x0068D6FC
	private const string TAB_SPRITE_ON = "Image/Poky/ThuVien/btnTab_on"; // Metadata: 0x0068D706
	private const string TAB_SPRITE_OFF = "Image/Poky/ThuVien/btnTab_off"; // Metadata: 0x0068D723
	public static readonly Vector2 TITLE_LEGACY_POS; // 0x40
	public static readonly Vector2 TITLE_LEGACY_SIZE; // 0x48
	public const string TITLE_LEGACY_TEXT = "TH\u01AF VI\u1EC6N PET"; // Metadata: 0x0068D741
	public static readonly Vector2 TITLE_TABS_POS; // 0x50
	public static readonly Vector2 TITLE_TABS_SIZE; // 0x58
	public const string TITLE_TABS_TEXT = "TH\u01AF VI\u1EC6N"; // Metadata: 0x0068D751
	public static readonly Vector2 TABS_POS; // 0x60
	public static readonly Vector2 TABS_SIZE; // 0x68
	public static readonly Vector2 TAB_SIZE; // 0x70
	public const float TAB_GAP = 12f; // Metadata: 0x0068D75D
	public static readonly Vector2 LIB_VIEW_POS; // 0x78
	public static readonly Vector2 LIB_VIEW_SIZE; // 0x80
	private static readonly Color TabLabelOn; // 0x88
	private static readonly Color TabLabelOff; // 0x98
	private const float TAB_SCALE_ON = 1.06f; // Metadata: 0x0068D761
	private const float VIEW_FX_TIME = 0.18f; // Metadata: 0x0068D765
	private const float VIEW_FX_SLIDE = 24f; // Metadata: 0x0068D769
	private Transform _libTabs; // 0xC0
	private Transform _libEffectView; // 0xC8
	private Transform _libCardView; // 0xD0
	private EffectLibView _effectView; // 0xD8
	private CardLibView _cardView; // 0xE0
	private Button _tabPet; // 0xE8
	private Button _tabEffect; // 0xF0
	private Button _tabCard; // 0xF8
	private UnityEngine.UI.Text _lblPet; // 0x100
	private UnityEngine.UI.Text _lblEffect; // 0x108
	private UnityEngine.UI.Text _lblCard; // 0x110
	private Transform _petGrid; // 0x118
	private UnityEngine.UI.Text _lblHint; // 0x120
	private RectTransform _titlePlate; // 0x128
	private UnityEngine.UI.Text _titleText; // 0x130
	private LibTab _tab; // 0x138
	private bool _tabsReady; // 0x13C
	private string _hintPet; // 0x140
	private string _summaryPet; // 0x148
	private static Sprite _spTabOn; // 0xA8
	private static Sprite _spTabOff; // 0xB0
	private static bool _spTabTried; // 0xB8

	// Nested types
	public enum LibTab // TypeDefIndex: 1743
	{
		Pet = 0,
		Effect = 1,
		Card = 2
	}

	[Serializable]
	public class PetLibraryPageResponse // TypeDefIndex: 1744
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
		public PetLibraryPageResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1745
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__97_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180688070-0x00000001806880E0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPetsPage_b__97_1(string error); // 0x00000001806873C0-0x0000000180687430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 1746
	{
		// Fields
		public ManagerThuVien __4__this; // 0x10
		public Sprite capturedIcon; // 0x18
		public PetLibDTO captured; // 0x20

		// Constructors
		public __c__DisplayClass99_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _InstantiatePetItem_b__0(); // 0x0000000180687FE0-0x0000000180688010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_1 // TypeDefIndex: 1747
	{
		// Fields
		public RectTransform cellRt; // 0x10
		public PetLibDTO forTip; // 0x18

		// Constructors
		public __c__DisplayClass99_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _InstantiatePetItem_b__1(); // 0x0000000180688010-0x0000000180688070
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__97 : IEnumerator<object> // TypeDefIndex: 1748
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThuVien __4__this; // 0x20
		public int page; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__97(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180684940-0x0000000180684CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180684CD0-0x0000000180684D10
	}

	// Constructors
	public ManagerThuVien(); // 0x0000000180678E30-0x0000000180678E70
	static ManagerThuVien(); // 0x0000000180678C60-0x0000000180678E30

	// Methods
	private void OnDisable(); // 0x0000000180676780-0x0000000180676790
	private void WireLibTabs(); // 0x0000000180678440-0x0000000180678C60
	private Button FindTab(string node, out UnityEngine.UI.Text label); // 0x0000000180675B80-0x0000000180675CD0
	public void SwitchTab(LibTab tab, bool instant = false /* Metadata: 0x0068D669 */); // 0x0000000180677910-0x0000000180677C70
	private void ShowView(Transform view, bool show, bool instant); // 0x0000000180677450-0x00000001806778A0
	private static void PaintTab(Button tab, UnityEngine.UI.Text label, bool selected); // 0x0000000180676CD0-0x0000000180677000
	private static void LoadTabSprites(); // 0x0000000180676660-0x0000000180676780
	private void RefreshLibSummary(); // 0x0000000180677000-0x00000001806772E0
	private void ApplyTitleGeometry(bool withTabs); // 0x0000000180675300-0x00000001806754C0
	private static bool FxOn(); // 0x0000000180675FC0-0x0000000180676010
	private void Awake(); // 0x00000001806754C0-0x0000000180675680
	public void Open(); // 0x0000000180676C80-0x0000000180676CD0
	public void Close(); // 0x0000000180675680-0x00000001806757E0
	[IteratorStateMachine(typeof(_LoadPetsPage_d__97))]
	private IEnumerator LoadPetsPage(int page); // 0x00000001806765E0-0x0000000180676660
	private void DisplayCurrentPetPage(); // 0x00000001806757E0-0x0000000180675AE0
	private void InstantiatePetItem(PetLibDTO pet); // 0x0000000180676010-0x00000001806765E0
	private void FitCellContent(Transform cell); // 0x0000000180675CD0-0x0000000180675FC0
	private static void ApplyOwnedLook(GameObject cell, Image petIcon, UnityEngine.UI.Text txtNamePet, bool owned); // 0x0000000180675030-0x0000000180675300
	private void AddElementBadge(Transform cell, string elementType); // 0x0000000180674C00-0x0000000180675030
	private void UpdatePetPaginationButtons(); // 0x00000001806781D0-0x0000000180678440
	private void SetPetPaginationButtonsState(bool enabled); // 0x00000001806772E0-0x0000000180677390
	private void ShowPreviousPetPage(); // 0x00000001806773F0-0x0000000180677450
	private void ShowNextPetPage(); // 0x0000000180677390-0x00000001806773F0
	private void OnPetClicked(Sprite petSprite, PetLibDTO pet); // 0x0000000180676790-0x0000000180676C80
	private static bool StatsHidden(PetLibDTO p); // 0x00000001806778F0-0x0000000180677910
	private static string StatText(int v, bool hidden); // 0x00000001806778A0-0x00000001806778F0
	private static string ElementVi(string code); // 0x0000000180675AE0-0x0000000180675B80
	private static string TooltipTitle(PetLibDTO pet); // 0x0000000180678060-0x00000001806780F0
	private static string TooltipBody(PetLibDTO pet); // 0x0000000180677C70-0x0000000180678060
	[CompilerGenerated]
	private void _WireLibTabs_b__84_0(); // 0x00000001806781A0-0x00000001806781B0
	[CompilerGenerated]
	private void _WireLibTabs_b__84_1(); // 0x00000001806781B0-0x00000001806781C0
	[CompilerGenerated]
	private void _WireLibTabs_b__84_2(); // 0x00000001806781C0-0x00000001806781D0
	[CompilerGenerated]
	private void _LoadPetsPage_b__97_0(PetLibraryPageResponse data); // 0x00000001806780F0-0x00000001806781A0
}

