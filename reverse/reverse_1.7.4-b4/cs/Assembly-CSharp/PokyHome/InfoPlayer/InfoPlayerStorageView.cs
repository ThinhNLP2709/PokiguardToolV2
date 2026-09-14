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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerStorageView : MonoBehaviour // TypeDefIndex: 2873
	{
		// Fields
		public const string FLAG = "infoplayer.storage"; // Metadata: 0x005F3225
		public const string N_ROOT = "sec_StoragePanel"; // Metadata: 0x005F3238
		public const string N_PANEL = "img_StoragePanel"; // Metadata: 0x005F3249
		public const string N_TABS = "sec_StorageTabs"; // Metadata: 0x005F325A
		public const string N_TAB_ITEM = "btn_StorageTabItem"; // Metadata: 0x005F326A
		public const string N_TAB_SHARD = "btn_StorageTabShard"; // Metadata: 0x005F327D
		public const string N_TAB_CARD = "btn_StorageTabCard"; // Metadata: 0x005F3291
		public const string N_GRID = "sec_StorageGrid"; // Metadata: 0x005F32A4
		public const string N_PAGING = "sec_StoragePaging"; // Metadata: 0x005F32B4
		public const string N_INFO = "txt_StorageInfo"; // Metadata: 0x005F32C6
		public const string N_EMPTY = "txt_StorageEmpty"; // Metadata: 0x005F32D6
		public const string N_FILTER = "btn_StorageFilter"; // Metadata: 0x005F32E7
		public const string N_TILE = "sec_TileStorage"; // Metadata: 0x005F32F9
		public const string N_TILE_BTN = "btn_ViewStorage"; // Metadata: 0x005F3309
		private const string SRC_PANEL_IMG = "img_BagPanel"; // Metadata: 0x005F3319
		private const string SRC_TABS = "sec_CategoryTabs"; // Metadata: 0x005F3326
		private const string SRC_TAB = "btn_TabAll"; // Metadata: 0x005F3337
		private const string SRC_GRID = "sec_ItemGrid"; // Metadata: 0x005F3342
		private const string SRC_PAGING = "sec_Paging"; // Metadata: 0x005F334F
		private const string SRC_SORT = "btn_SortByPower"; // Metadata: 0x005F335A
		private const string SRC_TILES = "sec_ContentTiles"; // Metadata: 0x005F336A
		private const string SRC_TILE = "sec_TileCards"; // Metadata: 0x005F337B
		private const string N_CELL_CORNER = "txt_Corner"; // Metadata: 0x005F3389
		private const string N_CELL_SUB = "txt_Sub"; // Metadata: 0x005F3394
		private const string N_CELL_PIECE = "img_Piece"; // Metadata: 0x005F339C
		private const float CONFIRM_SEC = 4f; // Metadata: 0x005F33A6
		private const float TAB_GAP = 8f; // Metadata: 0x005F33AA
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
		private const string EITEM_SHEET_1 = "Image/stone/item1"; // Metadata: 0x005F33AE
		private const string EITEM_SHEET_234 = "Image/stone/item1234"; // Metadata: 0x005F33C0
		private const string CRYSTAL_SHEET = "Image/stone/imtemPoint"; // Metadata: 0x005F33D5
		private const string CRYSTAL_SPRITE = "imtemPoint_0"; // Metadata: 0x005F33EC
		private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0xB0
		private const float FRAME_INNER_RATIO = 0.15f; // Metadata: 0x005F33F9
	
		// Properties
		public bool IsOpen { get; } // 0x0000000180D154C0-0x0000000180D15620 
		public StorageTab Tab { get; } // 0x0000000180D15620-0x0000000180D15630 
		private bool ActiveLoading { get; } // 0x0000000180D16780-0x0000000180D167D0 
		private bool ActiveLoaded { get; } // 0x0000000180D167D0-0x0000000180D16820 
		private int ActiveCount { get; } // 0x0000000180D16820-0x0000000180D16890 
		private int ActivePage { get; } // 0x0000000180D16890-0x0000000180D168E0 
		private int ActiveTotalPages { get; } // 0x0000000180D168E0-0x0000000180D16960 
	
		// Nested types
		private enum ArtMode // TypeDefIndex: 2874
		{
			None = 0,
			Icon = 1,
			InnerSquare = 2,
			Shard = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2875
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__161_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D28580-0x0000000180D28620
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _.ctor_b__161_0(string msg); // 0x0000000180D28620-0x0000000180D28680
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass128_0 // TypeDefIndex: 2876
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass128_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180D28680-0x0000000180D28940
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass140_0 // TypeDefIndex: 2877
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public PetShardDTO d; // 0x18
	
			// Constructors
			public __c__DisplayClass140_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BuildShardModel_b__0(); // 0x0000000180D28940-0x0000000180D28BB0
			internal void _BuildShardModel_b__1(); // 0x0000000180D28BB0-0x0000000180D28BE0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass149_0 // TypeDefIndex: 2878
		{
			// Fields
			public Action<StorageTab> onOpen; // 0x10
	
			// Constructors
			public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EnsureEntryTile_b__0(); // 0x0000000180D28BE0-0x0000000180D28C00
		}
	
		// Constructors
		public InfoPlayerStorageView(); // 0x0000000180D27230-0x0000000180D27CA0
		static InfoPlayerStorageView(); // 0x0000000180D27CA0-0x0000000180D27EE0
	
		// Methods
		public void Init(ManagerInfoPlayer owner, EquipBagView bag); // 0x0000000180D15630-0x0000000180D156F0
		private void WireStores(); // 0x0000000180D156F0-0x0000000180D15A40
		private void OnDisable(); // 0x0000000180D15A40-0x0000000180D15C10
		private void OnDestroy(); // 0x0000000180D15C10-0x0000000180D15F50
		public void Open(); // 0x0000000180D15F50-0x0000000180D15F60
		public void Open(StorageTab tab); // 0x0000000180D15F60-0x0000000180D161C0
		public void Close(); // 0x0000000180D161C0-0x0000000180D163A0
		public void ResetState(); // 0x0000000180D163A0-0x0000000180D164E0
		private void SwitchTab(StorageTab tab); // 0x0000000180D164E0-0x0000000180D16520
		private void LoadTab(bool forceReload); // 0x0000000180D16520-0x0000000180D16700
		private void OnStoreChanged(); // 0x0000000180D16700-0x0000000180D16780
		private void SetActivePage(int page); // 0x0000000180D16960-0x0000000180D16A20
		private void Render(); // 0x0000000180D16A20-0x0000000180D17A60
		private string EmptyMessage(); // 0x0000000180D17A60-0x0000000180D17B20
		private string InfoText_(); // 0x0000000180D17B20-0x0000000180D18230
		private void ClearCell(int i); // 0x0000000180D18230-0x0000000180D18710
		private void BindItem(int i, InventoryItemDTO d); // 0x0000000180D18710-0x0000000180D18FE0
		private static Sprite ResolveKeyedIcon(InventoryItemDTO d); // 0x0000000180D18FE0-0x0000000180D19900
		private static Sprite EvolutionSheetIcon(string code); // 0x0000000180D19900-0x0000000180D19F80
		private static Sprite SheetSprite(string sheetPath, string subName); // 0x0000000180D19F80-0x0000000180D1A2C0
		private static string DisplayName(InventoryItemDTO d); // 0x0000000180D1A2C0-0x0000000180D1A4F0
		private void BindCard(int i, UserCardDTO d); // 0x0000000180D1A4F0-0x0000000180D1AEB0
		private void BindShard(int i, PetShardDTO d); // 0x0000000180D1AEB0-0x0000000180D1B9D0
		private void LoadIcon(EquipBagCellView cell, int index, string path); // 0x0000000180D1B9D0-0x0000000180D1BF70
		private void PaintTabs(); // 0x0000000180D1BF70-0x0000000180D1BFF0
		private void PaintTab(Image bg, UnityEngine.UI.Text lbl, bool on); // 0x0000000180D1BFF0-0x0000000180D1C3F0
		private void OnCellClicked(int index); // 0x0000000180D1C3F0-0x0000000180D1CA60
		private void OnPrev(); // 0x0000000180D1CA60-0x0000000180D1CB80
		private void OnNext(); // 0x0000000180D1CB80-0x0000000180D1CCA0
		private void OnFilter(); // 0x0000000180D1CCA0-0x0000000180D1CDB0
		private InfoPlayerActionTooltip.Model BuildItemModel(InventoryItemDTO d); // 0x0000000180D1CDB0-0x0000000180D1D2F0
		private static string UsageHint(InventoryItemDTO d); // 0x0000000180D1D2F0-0x0000000180D1D690
		private InfoPlayerActionTooltip.Model BuildCardModel(UserCardDTO d); // 0x0000000180D1D690-0x0000000180D1DE60
		private void OpenCardUpgrade(); // 0x0000000180D1DE60-0x0000000180D1E100
		private void ShowShardTooltip(RectTransform anchor, PetShardDTO d); // 0x0000000180D1E100-0x0000000180D1E230
		private InfoPlayerActionTooltip.Model BuildShardModel(PetShardDTO d); // 0x0000000180D1E230-0x0000000180D1EED0
		private void OnExchangeClicked(PetShardDTO d); // 0x0000000180D1EED0-0x0000000180D1F350
		private void RefreshTooltipAfterChange(); // 0x0000000180D1F350-0x0000000180D1F540
		public void EnsureBuilt(); // 0x0000000180D1F540-0x0000000180D21490
		private Button EnsureTab(RectTransform tabs, Transform src, string name, float x, string label, out Image bg, out UnityEngine.UI.Text lbl); // 0x0000000180D21490-0x0000000180D224E0
		private void BuildCells(); // 0x0000000180D224E0-0x0000000180D23E10
		private void SetCellArt(int i, ArtMode mode); // 0x0000000180D23E10-0x0000000180D24470
		private static void LayoutShardArt(RectTransform piece, RectTransform icon, Vector2 cellSize); // 0x0000000180D24470-0x0000000180D246D0
		public void EnsureEntryTile(Action<StorageTab> onOpen); // 0x0000000180D246D0-0x0000000180D258A0
		public void SetTileVisible(bool on); // 0x0000000180D258A0-0x0000000180D25A70
		private static Sprite LoadSpriteSafe(string path); // 0x0000000180D25A70-0x0000000180D25B70
		private Font BorrowFont(); // 0x0000000180D25B70-0x0000000180D25F70
		private static void CopyRect(RectTransform from, RectTransform to); // 0x0000000180D25F70-0x0000000180D26110
		private static void TopLeft(RectTransform rt, float x, float y, float w, float h); // 0x0000000180D26110-0x0000000180D26280
		private static void StripBottom(RectTransform rt, float h); // 0x0000000180D26280-0x0000000180D26350
		private static void StripTop(RectTransform rt, float h); // 0x0000000180D26350-0x0000000180D26420
		private UnityEngine.UI.Text EnsureText(Transform parent, string node, float x, float y, float w, float h, int fontSize, Color color, TextAnchor align); // 0x0000000180D26420-0x0000000180D26DD0
		private static Button FindButton(Transform root, string name); // 0x0000000180D26DD0-0x0000000180D26FE0
		private static void Rename(Transform root, string from, string to); // 0x0000000180D26FE0-0x0000000180D27120
		private static void Hook(Button b, UnityAction call); // 0x0000000180D27120-0x0000000180D27230
		[CompilerGenerated]
		private void _OnExchangeClicked_b__141_0(PetExchangeResponse resp); // 0x0000000180D27EE0-0x0000000180D28020
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_0(); // 0x0000000180D28020-0x0000000180D281E0
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_1(); // 0x0000000180D281E0-0x0000000180D283B0
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_2(); // 0x0000000180D283B0-0x0000000180D28580
	}
}
