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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerStorageView : MonoBehaviour // TypeDefIndex: 2421
	{
		// Fields
		public const string FLAG = "infoplayer.storage"; // Metadata: 0x0068EFD2
		public const string N_ROOT = "sec_StoragePanel"; // Metadata: 0x0068EFE5
		public const string N_PANEL = "img_StoragePanel"; // Metadata: 0x0068EFF6
		public const string N_TABS = "sec_StorageTabs"; // Metadata: 0x0068F007
		public const string N_TAB_ITEM = "btn_StorageTabItem"; // Metadata: 0x0068F017
		public const string N_TAB_SHARD = "btn_StorageTabShard"; // Metadata: 0x0068F02A
		public const string N_TAB_CARD = "btn_StorageTabCard"; // Metadata: 0x0068F03E
		public const string N_GRID = "sec_StorageGrid"; // Metadata: 0x0068F051
		public const string N_PAGING = "sec_StoragePaging"; // Metadata: 0x0068F061
		public const string N_INFO = "txt_StorageInfo"; // Metadata: 0x0068F073
		public const string N_EMPTY = "txt_StorageEmpty"; // Metadata: 0x0068F083
		public const string N_FILTER = "btn_StorageFilter"; // Metadata: 0x0068F094
		public const string N_TILE = "sec_TileStorage"; // Metadata: 0x0068F0A6
		public const string N_TILE_BTN = "btn_ViewStorage"; // Metadata: 0x0068F0B6
		private const string SRC_PANEL_IMG = "img_BagPanel"; // Metadata: 0x0068F0C6
		private const string SRC_TABS = "sec_CategoryTabs"; // Metadata: 0x0068F0D3
		private const string SRC_TAB = "btn_TabAll"; // Metadata: 0x0068F0E4
		private const string SRC_GRID = "sec_ItemGrid"; // Metadata: 0x0068F0EF
		private const string SRC_PAGING = "sec_Paging"; // Metadata: 0x0068F0FC
		private const string SRC_SORT = "btn_SortByPower"; // Metadata: 0x0068F107
		private const string SRC_TILES = "sec_ContentTiles"; // Metadata: 0x0068F117
		private const string SRC_TILE = "sec_TileCards"; // Metadata: 0x0068F128
		private const string N_CELL_CORNER = "txt_Corner"; // Metadata: 0x0068F136
		private const string N_CELL_SUB = "txt_Sub"; // Metadata: 0x0068F141
		private const string N_CELL_PIECE = "img_Piece"; // Metadata: 0x0068F149
		private const float CONFIRM_SEC = 4f; // Metadata: 0x0068F153
		private const float TAB_GAP = 8f; // Metadata: 0x0068F157
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
		private const string EITEM_SHEET_1 = "Image/stone/item1"; // Metadata: 0x0068F15B
		private const string EITEM_SHEET_234 = "Image/stone/item1234"; // Metadata: 0x0068F16D
		private const string CRYSTAL_SHEET = "Image/stone/imtemPoint"; // Metadata: 0x0068F182
		private const string CRYSTAL_SPRITE = "imtemPoint_0"; // Metadata: 0x0068F199
		private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0xB0
		private const float FRAME_INNER_RATIO = 0.15f; // Metadata: 0x0068F1A6
	
		// Properties
		public bool IsOpen { get; } // 0x00000001807F1590-0x00000001807F1620 
		public StorageTab Tab { get; } // 0x00000001807F1620-0x00000001807F1630 
		private bool ActiveLoading { get; } // 0x00000001807F1460-0x00000001807F14B0 
		private bool ActiveLoaded { get; } // 0x00000001807F1410-0x00000001807F1460 
		private int ActiveCount { get; } // 0x00000001807F13A0-0x00000001807F1410 
		private int ActivePage { get; } // 0x00000001807F14B0-0x00000001807F1500 
		private int ActiveTotalPages { get; } // 0x00000001807F1500-0x00000001807F1590 
	
		// Nested types
		private enum ArtMode // TypeDefIndex: 2422
		{
			None = 0,
			Icon = 1,
			InnerSquare = 2,
			Shard = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2423
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__161_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018080EDF0-0x000000018080EE60
			public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _.ctor_b__161_0(string msg); // 0x000000018080CA10-0x000000018080CA70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass128_0 // TypeDefIndex: 2424
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass128_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x000000018080CA70-0x000000018080CB50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass140_0 // TypeDefIndex: 2425
		{
			// Fields
			public InfoPlayerStorageView __4__this; // 0x10
			public PetShardDTO d; // 0x18
	
			// Constructors
			public __c__DisplayClass140_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _BuildShardModel_b__0(); // 0x000000018080CCD0-0x000000018080CE30
			internal void _BuildShardModel_b__1(); // 0x000000018080CE30-0x000000018080CE60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass149_0 // TypeDefIndex: 2426
		{
			// Fields
			public Action<StorageTab> onOpen; // 0x10
	
			// Constructors
			public __c__DisplayClass149_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _EnsureEntryTile_b__0(); // 0x000000018080CE60-0x000000018080CE80
		}
	
		// Constructors
		public InfoPlayerStorageView(); // 0x00000001807F0F60-0x00000001807F13A0
		static InfoPlayerStorageView(); // 0x00000001807F0D20-0x00000001807F0F60
	
		// Methods
		public void Init(ManagerInfoPlayer owner, EquipBagView bag); // 0x00000001807EC610-0x00000001807EC660
		private void WireStores(); // 0x00000001807F0A90-0x00000001807F0D20
		private void OnDisable(); // 0x00000001807ED440-0x00000001807ED510
		private void OnDestroy(); // 0x00000001807ED1D0-0x00000001807ED440
		public void Open(); // 0x00000001807EDE70-0x00000001807EE090
		public void Open(StorageTab tab); // 0x00000001807EDD40-0x00000001807EDE70
		public void Close(); // 0x00000001807E83A0-0x00000001807E8480
		public void ResetState(); // 0x00000001807EEEE0-0x00000001807EEFE0
		private void SwitchTab(StorageTab tab); // 0x00000001807F0110-0x00000001807F0150
		private void LoadTab(bool forceReload); // 0x00000001807ECBC0-0x00000001807ECD60
		private void OnStoreChanged(); // 0x00000001807EDB70-0x00000001807EDBC0
		private void SetActivePage(int page); // 0x00000001807EF590-0x00000001807EF650
		private void Render(); // 0x00000001807EE5B0-0x00000001807EEEE0
		private string EmptyMessage(); // 0x00000001807E8700-0x00000001807E87A0
		private string InfoText_(); // 0x00000001807EC0F0-0x00000001807EC610
		private void ClearCell(int i); // 0x00000001807E8180-0x00000001807E83A0
		private void BindItem(int i, InventoryItemDTO d); // 0x00000001807E4EC0-0x00000001807E5440
		private static Sprite ResolveKeyedIcon(InventoryItemDTO d); // 0x00000001807EEFE0-0x00000001807EF590
		private static Sprite EvolutionSheetIcon(string code); // 0x00000001807EBAD0-0x00000001807EBF40
		private static Sprite SheetSprite(string sheetPath, string subName); // 0x00000001807EFC60-0x00000001807EFEC0
		private static string DisplayName(InventoryItemDTO d); // 0x00000001807E8580-0x00000001807E8700
		private void BindCard(int i, UserCardDTO d); // 0x00000001807E49B0-0x00000001807E4EC0
		private void BindShard(int i, PetShardDTO d); // 0x00000001807E5440-0x00000001807E5A80
		private void LoadIcon(EquipBagCellView cell, int index, string path); // 0x00000001807EC830-0x00000001807ECB10
		private void PaintTabs(); // 0x00000001807EE290-0x00000001807EE310
		private void PaintTab(Image bg, UnityEngine.UI.Text lbl, bool on); // 0x00000001807EE090-0x00000001807EE290
		private void OnCellClicked(int index); // 0x00000001807ECD60-0x00000001807ED1D0
		private void OnPrev(); // 0x00000001807EDA90-0x00000001807EDB70
		private void OnNext(); // 0x00000001807ED9B0-0x00000001807EDA90
		private void OnFilter(); // 0x00000001807ED8E0-0x00000001807ED9B0
		private InfoPlayerActionTooltip.Model BuildItemModel(InventoryItemDTO d); // 0x00000001807E7470-0x00000001807E7890
		private static string UsageHint(InventoryItemDTO d); // 0x00000001807F0780-0x00000001807F0A90
		private InfoPlayerActionTooltip.Model BuildCardModel(UserCardDTO d); // 0x00000001807E5BD0-0x00000001807E61F0
		private void OpenCardUpgrade(); // 0x00000001807EDBC0-0x00000001807EDD40
		private void ShowShardTooltip(RectTransform anchor, PetShardDTO d); // 0x00000001807EFEC0-0x00000001807EFF70
		private InfoPlayerActionTooltip.Model BuildShardModel(PetShardDTO d); // 0x00000001807E7890-0x00000001807E8180
		private void OnExchangeClicked(PetShardDTO d); // 0x00000001807ED510-0x00000001807ED8E0
		private void RefreshTooltipAfterChange(); // 0x00000001807EE310-0x00000001807EE4F0
		public void EnsureBuilt(); // 0x00000001807E87A0-0x00000001807EA2F0
		private Button EnsureTab(RectTransform tabs, Transform src, string name, float x, string label, out Image bg, out UnityEngine.UI.Text lbl); // 0x00000001807EACB0-0x00000001807EB600
		private void BuildCells(); // 0x00000001807E61F0-0x00000001807E7470
		private void SetCellArt(int i, ArtMode mode); // 0x00000001807EF650-0x00000001807EFBB0
		private static void LayoutShardArt(RectTransform piece, RectTransform icon, Vector2 cellSize); // 0x00000001807EC660-0x00000001807EC830
		public void EnsureEntryTile(Action<StorageTab> onOpen); // 0x00000001807EA2F0-0x00000001807EACB0
		public void SetTileVisible(bool on); // 0x00000001807EFBB0-0x00000001807EFC60
		private static Sprite LoadSpriteSafe(string path); // 0x00000001807ECB10-0x00000001807ECBC0
		private Font BorrowFont(); // 0x00000001807E5A80-0x00000001807E5BD0
		private static void CopyRect(RectTransform from, RectTransform to); // 0x00000001807E8480-0x00000001807E8580
		private static void TopLeft(RectTransform rt, float x, float y, float w, float h); // 0x00000001807F0150-0x00000001807F0270
		private static void StripBottom(RectTransform rt, float h); // 0x00000001807EFF70-0x00000001807F0040
		private static void StripTop(RectTransform rt, float h); // 0x00000001807F0040-0x00000001807F0110
		private UnityEngine.UI.Text EnsureText(Transform parent, string node, float x, float y, float w, float h, int fontSize, Color color, TextAnchor align); // 0x00000001807EB600-0x00000001807EBAD0
		private static Button FindButton(Transform root, string name); // 0x00000001807EBF40-0x00000001807EC050
		private static void Rename(Transform root, string from, string to); // 0x00000001807EE4F0-0x00000001807EE5B0
		private static void Hook(Button b, UnityAction call); // 0x00000001807EC050-0x00000001807EC0F0
		[CompilerGenerated]
		private void _OnExchangeClicked_b__141_0(PetExchangeResponse resp); // 0x00000001807F06F0-0x00000001807F0780
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_0(); // 0x00000001807F0270-0x00000001807F03F0
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_1(); // 0x00000001807F03F0-0x00000001807F0570
		[CompilerGenerated]
		private void _EnsureBuilt_b__143_2(); // 0x00000001807F0570-0x00000001807F06F0
	}
}
