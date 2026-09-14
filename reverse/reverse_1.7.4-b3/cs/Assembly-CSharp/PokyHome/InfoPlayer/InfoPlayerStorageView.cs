/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerStorageView : MonoBehaviour // TypeDefIndex: 2866
	{
		// Fields
		public const string FLAG = "infoplayer.storage"; // Metadata: 0x005F1E0E
		public const string N_ROOT = "sec_StoragePanel"; // Metadata: 0x005F1E21
		public const string N_PANEL = "img_StoragePanel"; // Metadata: 0x005F1E32
		public const string N_TABS = "sec_StorageTabs"; // Metadata: 0x005F1E43
		public const string N_TAB_ITEM = "btn_StorageTabItem"; // Metadata: 0x005F1E53
		public const string N_TAB_SHARD = "btn_StorageTabShard"; // Metadata: 0x005F1E66
		public const string N_TAB_CARD = "btn_StorageTabCard"; // Metadata: 0x005F1E7A
		public const string N_GRID = "sec_StorageGrid"; // Metadata: 0x005F1E8D
		public const string N_PAGING = "sec_StoragePaging"; // Metadata: 0x005F1E9D
		public const string N_INFO = "txt_StorageInfo"; // Metadata: 0x005F1EAF
		public const string N_EMPTY = "txt_StorageEmpty"; // Metadata: 0x005F1EBF
		public const string N_FILTER = "btn_StorageFilter"; // Metadata: 0x005F1ED0
		public const string N_TILE = "sec_TileStorage"; // Metadata: 0x005F1EE2
		public const string N_TILE_BTN = "btn_ViewStorage"; // Metadata: 0x005F1EF2
		private const string SRC_PANEL_IMG = "img_BagPanel"; // Metadata: 0x005F1F02
		private const string SRC_TABS = "sec_CategoryTabs"; // Metadata: 0x005F1F0F
		private const string SRC_TAB = "btn_TabAll"; // Metadata: 0x005F1F20
		private const string SRC_GRID = "sec_ItemGrid"; // Metadata: 0x005F1F2B
		private const string SRC_PAGING = "sec_Paging"; // Metadata: 0x005F1F38
		private const string SRC_SORT = "btn_SortByPower"; // Metadata: 0x005F1F43
		private const string SRC_TILES = "sec_ContentTiles"; // Metadata: 0x005F1F53
		private const string SRC_TILE = "sec_TileCards"; // Metadata: 0x005F1F64
		private const string N_CELL_CORNER = "txt_Corner"; // Metadata: 0x005F1F72
		private const string N_CELL_SUB = "txt_Sub"; // Metadata: 0x005F1F7D
		private const string N_CELL_PIECE = "img_Piece"; // Metadata: 0x005F1F85
		private const float CONFIRM_SEC = 4f; // Metadata: 0x005F1F8F
		private const float TAB_GAP = 8f; // Metadata: 0x005F1F93
		private static readonly Color GoldText; // 0x00
		private static readonly Color PowerText; // 0x10
		private static readonly Color ShardText; // 0x20
		private static readonly Color CountText; // 0x30
		private static readonly Color ReadyTint; // 0x40
		private static readonly Color NotOwnedTint; // 0x50
		private static readonly Color InfoText; // 0x60
		private static readonly Color TabLabelOn; // 0x70
		private static readonly Color TabLabelOff; // 0x80
		private static readonly Color BtnDanger; // 0x90
		private static readonly Color BtnGo; // 0xA0
		private ManagerInfoPlayer _owner; // 0x20
		private EquipBagView _bag; // 0x28
		private Font _font; // 0x30
		private RectTransform _root; // 0x38
		private RectTransform _grid; // 0x40
		private Button _tabItem; // 0x48
		private Button _tabShard; // 0x50
		private Button _tabCard; // 0x58
		private Image _tabItemBg; // 0x60
		private Image _tabShardBg; // 0x68
		private Image _tabCardBg; // 0x70
		private UnityEngine.UI.Text _tabItemLbl; // 0x78
		private UnityEngine.UI.Text _tabShardLbl; // 0x80
		private UnityEngine.UI.Text _tabCardLbl; // 0x88
		private Sprite _tabOn; // 0x90
		private Sprite _tabOff; // 0x98
		private readonly List<EquipBagCellView> _cells; // 0xA0
		private readonly List<UnityEngine.UI.Text> _corner; // 0xA8
		private readonly List<UnityEngine.UI.Text> _sub; // 0xB0
		private readonly List<Image> _piece; // 0xB8
		private readonly List<ArtMode> _cellArt; // 0xC0
		private readonly List<int> _iconToken; // 0xC8
		private Vector2 _cellSize; // 0xD0
		private Vector2 _iconDefaultPos; // 0xD8
		private Vector2 _iconDefaultSize; // 0xE0
		private bool _iconDefaultKnown; // 0xE8
		private Button _prev; // 0xF0
		private Button _next; // 0xF8
		private Button _filter; // 0x100
		private UnityEngine.UI.Text _page; // 0x108
		private UnityEngine.UI.Text _info; // 0x110
		private UnityEngine.UI.Text _empty; // 0x118
		private UnityEngine.UI.Text _filterLabel; // 0x120
		private GameObject _filterCheck; // 0x128
		private GameObject _tile; // 0x130
		private readonly ItemStore _items; // 0x138
		private readonly ShardStore _shards; // 0x140
		private readonly CardStore _cards; // 0x148
		private StorageTab _tab; // 0x150
		private int _selected; // 0x154
		private bool _built; // 0x158
		private bool _storesWired; // 0x159
		private long _pendingExchangeId; // 0x160
		private float _pendingExchangeUntil; // 0x168
		private PetShardDTO _tipPayload; // 0x170
		private RectTransform _tipAnchor; // 0x178
		private readonly Action<string> _toast; // 0x180
		private const string EITEM_SHEET_1 = "Image/stone/item1"; // Metadata: 0x005F1F97
		private const string EITEM_SHEET_234 = "Image/stone/item1234"; // Metadata: 0x005F1FA9
		private const string CRYSTAL_SHEET = "Image/stone/imtemPoint"; // Metadata: 0x005F1FBE
		private const string CRYSTAL_SPRITE = "imtemPoint_0"; // Metadata: 0x005F1FD5
		private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0xB0
		private const float FRAME_INNER_RATIO = 0.15f; // Metadata: 0x005F1FE2
	
		// Properties
		public bool IsOpen { get; } // 0x0000000180D07A00-0x0000000180D07B60 
		public StorageTab Tab { get; } // 0x0000000180D07B60-0x0000000180D07B70 
		private bool ActiveLoading { get; } // 0x0000000180D08C90-0x0000000180D08CE0 
		private bool ActiveLoaded { get; } // 0x0000000180D08CE0-0x0000000180D08D30 
		private int ActiveCount { get; } // 0x0000000180D08D30-0x0000000180D08DA0 
		private int ActivePage { get; } // 0x0000000180D08DA0-0x0000000180D08DF0 
		private int ActiveTotalPages { get; } // 0x0000000180D08DF0-0x0000000180D08E70 
	
		// Nested types
		private enum ArtMode // TypeDefIndex: 2867
		{
			None = 0,
			Icon = 1,
			InnerSquare = 2,
			Shard = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2868
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__161_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D1AB10-0x0000000180D1ABB0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _.ctor_b__161_0(string msg); // 0x0000000180D1ABB0-0x0000000180D1AC10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass128_0 // TypeDefIndex: 2869
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass128_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180D1AC10-0x0000000180D1AED0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass140_0 // TypeDefIndex: 2870
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public PetShardDTO d; // 0x18
	
			// Constructors
			public __c__DisplayClass140_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BuildShardModel_b__0(); // 0x0000000180D1AED0-0x0000000180D1B140
			internal void _BuildShardModel_b__1(); // 0x0000000180D1B140-0x0000000180D1B170
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass149_0 // TypeDefIndex: 2871
		{
			// Fields
			public Action<StorageTab> onOpen; // 0x10
	
			// Constructors
			public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EnsureEntryTile_b__0(); // 0x0000000180D1B170-0x0000000180D1B190
		}
	
		// Constructors
		public InfoPlayerStorageView(); // 0x0000000180D19710-0x0000000180D1A180
		static InfoPlayerStorageView(); // 0x0000000180D1A180-0x0000000180D1A3C0
	
		// Methods
		public void Init(ManagerInfoPlayer owner, EquipBagView bag); // 0x0000000180D07B70-0x0000000180D07C30
		private void WireStores(); // 0x0000000180D07C30-0x0000000180D07F80
		private void OnDisable(); // 0x0000000180D07F80-0x0000000180D08150
		private void OnDestroy(); // 0x0000000180D08150-0x0000000180D08490
		public void Open(); // 0x0000000180D08490-0x0000000180D084A0
		public void Open(StorageTab tab); // 0x0000000180D084A0-0x0000000180D08700
		public void Close(); // 0x0000000180D08700-0x0000000180D088E0
		public void ResetState(); // 0x0000000180D088E0-0x0000000180D08A20
		private void SwitchTab(StorageTab tab); // 0x0000000180D08A20-0x0000000180D08A60
		private void LoadTab(bool forceReload); // 0x0000000180D08A60-0x0000000180D08C40
		private void OnStoreChanged(); // 0x0000000180D08C40-0x0000000180D08C90
		private void SetActivePage(int page); // 0x0000000180D08E70-0x0000000180D08F30
		private void Render(); // 0x0000000180D08F30-0x0000000180D09F70
		private string EmptyMessage(); // 0x0000000180D09F70-0x0000000180D0A030
		private string InfoText_(); // 0x0000000180D0A030-0x0000000180D0A740
		private void ClearCell(int i); // 0x0000000180D0A740-0x0000000180D0AC20
		private void BindItem(int i, InventoryItemDTO d); // 0x0000000180D0AC20-0x0000000180D0B4F0
		private static Sprite ResolveKeyedIcon(InventoryItemDTO d); // 0x0000000180D0B4F0-0x0000000180D0BE10
		private static Sprite EvolutionSheetIcon(string code); // 0x0000000180D0BE10-0x0000000180D0C490
		private static Sprite SheetSprite(string sheetPath, string subName); // 0x0000000180D0C490-0x0000000180D0C7D0
		private static string DisplayName(InventoryItemDTO d); // 0x0000000180D0C7D0-0x0000000180D0CA00
		private void BindCard(int i, UserCardDTO d); // 0x0000000180D0CA00-0x0000000180D0D3C0
		private void BindShard(int i, PetShardDTO d); // 0x0000000180D0D3C0-0x0000000180D0DEE0
		private void LoadIcon(EquipBagCellView cell, int index, string path); // 0x0000000180D0DEE0-0x0000000180D0E450
		private void PaintTabs(); // 0x0000000180D0E450-0x0000000180D0E4D0
		private void PaintTab(Image bg, UnityEngine.UI.Text lbl, bool on); // 0x0000000180D0E4D0-0x0000000180D0E8D0
		private void OnCellClicked(int index); // 0x0000000180D0E8D0-0x0000000180D0EF40
		private void OnPrev(); // 0x0000000180D0EF40-0x0000000180D0F060
		private void OnNext(); // 0x0000000180D0F060-0x0000000180D0F180
		private void OnFilter(); // 0x0000000180D0F180-0x0000000180D0F290
		private InfoPlayerActionTooltip.Model BuildItemModel(InventoryItemDTO d); // 0x0000000180D0F290-0x0000000180D0F7D0
		private static string UsageHint(InventoryItemDTO d); // 0x0000000180D0F7D0-0x0000000180D0FB70
		private InfoPlayerActionTooltip.Model BuildCardModel(UserCardDTO d); // 0x0000000180D0FB70-0x0000000180D10340
		private void OpenCardUpgrade(); // 0x0000000180D10340-0x0000000180D105E0
		private void ShowShardTooltip(RectTransform anchor, PetShardDTO d); // 0x0000000180D105E0-0x0000000180D10710
		private InfoPlayerActionTooltip.Model BuildShardModel(PetShardDTO d); // 0x0000000180D10710-0x0000000180D113B0
		private void OnExchangeClicked(PetShardDTO d); // 0x0000000180D113B0-0x0000000180D11830
		private void RefreshTooltipAfterChange(); // 0x0000000180D11830-0x0000000180D11A20
		public void EnsureBuilt(); // 0x0000000180D11A20-0x0000000180D13970
		private Button EnsureTab(RectTransform tabs, Transform src, string name, float x, string label, out Image bg, out UnityEngine.UI.Text lbl); // 0x0000000180D13970-0x0000000180D149C0
		private void BuildCells(); // 0x0000000180D149C0-0x0000000180D162F0
		private void SetCellArt(int i, ArtMode mode); // 0x0000000180D162F0-0x0000000180D16950
		private static void LayoutShardArt(RectTransform piece, RectTransform icon, Vector2 cellSize); // 0x0000000180D16950-0x0000000180D16BB0
		public void EnsureEntryTile(Action<StorageTab> onOpen); // 0x0000000180D16BB0-0x0000000180D17D80
		public void SetTileVisible(bool on); // 0x0000000180D17D80-0x0000000180D17F50
		private static Sprite LoadSpriteSafe(string path); // 0x0000000180D17F50-0x0000000180D18050
		private Font BorrowFont(); // 0x0000000180D18050-0x0000000180D18450
		private static void CopyRect(RectTransform from, RectTransform to); // 0x0000000180D18450-0x0000000180D185F0
		private static void TopLeft(RectTransform rt, float x, float y, float w, float h); // 0x0000000180D185F0-0x0000000180D18760
		private static void StripBottom(RectTransform rt, float h); // 0x0000000180D18760-0x0000000180D18830
		private static void StripTop(RectTransform rt, float h); // 0x0000000180D18830-0x0000000180D18900
		private UnityEngine.UI.Text EnsureText(Transform parent, string node, float x, float y, float w, float h, int fontSize, Color color, TextAnchor align); // 0x0000000180D18900-0x0000000180D192B0
		private static Button FindButton(Transform root, string name); // 0x0000000180D192B0-0x0000000180D194C0
		private static void Rename(Transform root, string from, string to); // 0x0000000180D194C0-0x0000000180D19600
		private static void Hook(Button b, UnityAction call); // 0x0000000180D19600-0x0000000180D19710
		[CompilerGenerated]
		private void _OnExchangeClicked_b__141_0(PetExchangeResponse resp); // 0x0000000180D1A3C0-0x0000000180D1A4E0
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_0(); // 0x0000000180D1A4E0-0x0000000180D1A6A0
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_1(); // 0x0000000180D1A6A0-0x0000000180D1A870
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_2(); // 0x0000000180D1A870-0x0000000180D1AA40
	}
}
