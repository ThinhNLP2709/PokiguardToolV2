/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipBagView : MonoBehaviour // TypeDefIndex: 2340
	{
		// Fields
		public static readonly string[] TabNodeNames; // 0x00
		public static readonly string[] FilterNodeNames; // 0x08
		public static readonly int[] FilterSlotValues; // 0x10
		public const string NODE_SORT = "btn_SortByPower"; // Metadata: 0x0068EAE5
		public const string NODE_PREV = "btn_PagePrev"; // Metadata: 0x0068EAF5
		public const string NODE_NEXT = "btn_PageNext"; // Metadata: 0x0068EB02
		public const string NODE_PAGE_TEXT = "txt_PageIndicator"; // Metadata: 0x0068EB0F
		public const string NODE_ITEM_PANEL = "sec_ItemPanel"; // Metadata: 0x0068EB21
		public const string CELL_NAME_PREFIX = "BagCell_"; // Metadata: 0x0068EB2F
		[Header("\u00D4")]
		[Tooltip("Prefab m\u1ED9t \u00F4 kho (Assets/PokyHome/Prefabs/InfoPlayerBagCell.prefab). B\u1ECF tr\u1ED1ng \u21D2 d\u00F9ng \u00F4 con \u0111\u1EA7u ti\u00EAn l\u00E0m khu\u00F4n.")]
		public EquipBagCellView cellPrefab; // 0x20
		[Tooltip("Node ch\u1EE9a c\u00E1c \u00F4. B\u1ECF tr\u1ED1ng \u21D2 d\u00F9ng ch\u00EDnh node n\u00E0y.")]
		public RectTransform container; // 0x28
		[Header("L\u01B0\u1EDBi \u2014 s\u1ED1 \u0111o b\u1EA3n thi\u1EBFt k\u1EBF 1774\u00D7887")]
		public int columns; // 0x30
		public int rows; // 0x34
		public Vector2 cellSize; // 0x38
		public Vector2 spacing; // 0x40
		[Tooltip("L\u1EC1 tr\u00E1i/tr\u00EAn c\u1EE7a c\u1EE5m \u00F4 so v\u1EDBi g\u00F3c tr\u00EAn-tr\u00E1i c\u1EE7a node ch\u1EE9a.")]
		public Vector2 padding; // 0x48
		[Header("N\u00FAt")]
		public Button[] tabButtons; // 0x50
		public Button[] filterButtons; // 0x58
		public Button sortButton; // 0x60
		public Button prevButton; // 0x68
		public Button nextButton; // 0x70
		public UnityEngine.UI.Text pageIndicator; // 0x78
		[Header("Tr\u1EA1ng th\u00E1i s\u00E1ng c\u1EE7a m\u01B0\u1EDDi ba n\u00FAt")]
		public EquipBagFilterStateView filterState; // 0x80
		private readonly List<EquipBagCellView> _cells; // 0x88
		private readonly int[] _iconToken; // 0x90
		private EquipBagItemDTO[] _entries; // 0x98
		private EquipCategory _category; // 0xA0
		private EquipSlot _slot; // 0xA1
		private bool _sortByPower; // 0xA2
		private int _page; // 0xA4
		private int _totalPages; // 0xA8
		private int _selected; // 0xAC
		private bool _built; // 0xB0
		private bool _wired; // 0xB1
		[CompilerGenerated]
		private Action QueryChanged; // 0xB8
		[CompilerGenerated]
		private Action<int, RectTransform> CellClicked; // 0xC0
	
		// Properties
		public EquipCategory Category { get; } // 0x000000018039C4F0-0x000000018039C500 
		public EquipSlot SlotFilter { get; } // 0x00000001807CC3B0-0x00000001807CC3C0 
		public bool SortByPower { get; } // 0x00000001807CC3C0-0x00000001807CC3D0 
		public int Page { get; } // 0x000000018039C040-0x000000018039C050 
		public int TotalPages { get; } // 0x000000018039C030-0x000000018039C040 
		public EquipBagItemDTO[] Entries { get; } // 0x0000000180319950-0x0000000180319960 
		public int CellCount { get; } // 0x00000001807CC390-0x00000001807CC3B0 
		public int Capacity { get; } // 0x00000001807CC380-0x00000001807CC390 
	
		// Events
		public event Action QueryChanged {
			add; // 0x00000001807CC2D0-0x00000001807CC380
			remove; // 0x00000001807CC4A0-0x00000001807CC550
		}
		public event Action<int, RectTransform> CellClicked {
			add; // 0x00000001807CC200-0x00000001807CC2D0
			remove; // 0x00000001807CC3D0-0x00000001807CC4A0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_0 // TypeDefIndex: 2341
		{
			// Fields
			public EquipCategory cat; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _AutoWire_b__0(); // 0x00000001807DC610-0x00000001807DC670
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_1 // TypeDefIndex: 2342
		{
			// Fields
			public EquipSlot slot; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_1(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _AutoWire_b__1(); // 0x00000001807DC670-0x00000001807DC6E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2343
		{
			// Fields
			public EquipBagView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x00000001807DC6E0-0x00000001807DC7B0
		}
	
		// Constructors
		public EquipBagView(); // 0x00000001807CC040-0x00000001807CC200
		static EquipBagView(); // 0x00000001807CBCE0-0x00000001807CC040
	
		// Methods
		private void Awake(); // 0x00000001807CA8B0-0x00000001807CA8E0
		private void OnDestroy(); // 0x00000001807CB120-0x00000001807CB160
		public void AutoWire(); // 0x00000001807C9E40-0x00000001807CA8B0
		private Transform Scope(); // 0x00000001807CBA90-0x00000001807CBBE0
		private static Button FindButton(Transform scope, string name); // 0x00000001807CAC30-0x00000001807CAD00
		private void EnsureBuilt(); // 0x00000001807CA8E0-0x00000001807CAC30
		private void ReclaimExistingCells(RectTransform parent, int capacity); // 0x00000001807CB5C0-0x00000001807CB890
		private void Place(EquipBagCellView cell, int index); // 0x00000001807CB200-0x00000001807CB3E0
		public void SetCategory(EquipCategory category); // 0x00000001807CBBE0-0x00000001807CBC30
		public void ToggleSlotFilter(EquipSlot slot); // 0x00000001807CBC30-0x00000001807CBC90
		public void ToggleSort(); // 0x00000001807CBC90-0x00000001807CBCE0
		public void PagePrev(); // 0x00000001807CB1B0-0x00000001807CB200
		public void PageNext(); // 0x00000001807CB160-0x00000001807CB1B0
		public void ResetState(); // 0x00000001807CB890-0x00000001807CBA90
		private void PublishState(); // 0x00000001807CB3E0-0x00000001807CB5C0
		public void ApplyPage(EquipBagDTO data); // 0x00000001807C9A60-0x00000001807C9E40
		private void LoadIcon(EquipBagCellView cell, int index, EquipBagItemDTO entry); // 0x00000001807CAD00-0x00000001807CAF50
		private void OnCellClicked(int index); // 0x00000001807CAF50-0x00000001807CB120
	}
}
