/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipBagView : MonoBehaviour // TypeDefIndex: 2782
	{
		// Fields
		public static readonly string[] TabNodeNames; // 0x00
		public static readonly string[] FilterNodeNames; // 0x08
		public static readonly int[] FilterSlotValues; // 0x10
		public const string NODE_SORT = "btn_SortByPower"; // Metadata: 0x005F2D0F
		public const string NODE_PREV = "btn_PagePrev"; // Metadata: 0x005F2D1F
		public const string NODE_NEXT = "btn_PageNext"; // Metadata: 0x005F2D2C
		public const string NODE_PAGE_TEXT = "txt_PageIndicator"; // Metadata: 0x005F2D39
		public const string NODE_ITEM_PANEL = "sec_ItemPanel"; // Metadata: 0x005F2D4B
		public const string CELL_NAME_PREFIX = "BagCell_"; // Metadata: 0x005F2D59
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
		public EquipCategory Category { get; } // 0x0000000180CD06C0-0x0000000180CD06D0 
		public EquipSlot SlotFilter { get; } // 0x0000000180CD06D0-0x0000000180CD06E0 
		public bool SortByPower { get; } // 0x0000000180CD06E0-0x0000000180CD06F0 
		public int Page { get; } // 0x0000000180CD06F0-0x0000000180CD0700 
		public int TotalPages { get; } // 0x00000001803C7060-0x00000001803C7070 
		public EquipBagItemDTO[] Entries { get; } // 0x00000001802D8DE0-0x00000001802D8DF0 
		public int CellCount { get; } // 0x0000000180CD0700-0x0000000180CD0720 
		public int Capacity { get; } // 0x0000000180CD0720-0x0000000180CD0730 
	
		// Events
		public event Action QueryChanged {
			add; // 0x0000000180CD0280-0x0000000180CD0380
			remove; // 0x0000000180CD0380-0x0000000180CD0480
		}
		public event Action<int, RectTransform> CellClicked {
			add; // 0x0000000180CD0480-0x0000000180CD05A0
			remove; // 0x0000000180CD05A0-0x0000000180CD06C0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_0 // TypeDefIndex: 2783
		{
			// Fields
			public EquipCategory cat; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AutoWire_b__0(); // 0x0000000180CD45B0-0x0000000180CD4610
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_1 // TypeDefIndex: 2784
		{
			// Fields
			public EquipSlot slot; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AutoWire_b__1(); // 0x0000000180CD4610-0x0000000180CD4680
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2785
		{
			// Fields
			public EquipBagView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180CD4680-0x0000000180CD4850
		}
	
		// Constructors
		public EquipBagView(); // 0x0000000180CD3DE0-0x0000000180CD41A0
		static EquipBagView(); // 0x0000000180CD41A0-0x0000000180CD45B0
	
		// Methods
		private void Awake(); // 0x0000000180CD0730-0x0000000180CD0760
		private void OnDestroy(); // 0x0000000180CD0760-0x0000000180CD0820
		public void AutoWire(); // 0x0000000180CD0820-0x0000000180CD1880
		private Transform Scope(); // 0x0000000180CD1880-0x0000000180CD1B00
		private static Button FindButton(Transform scope, string name); // 0x0000000180CD1B00-0x0000000180CD1C50
		private void EnsureBuilt(); // 0x0000000180CD1C50-0x0000000180CD2250
		private void ReclaimExistingCells(RectTransform parent, int capacity); // 0x0000000180CD2250-0x0000000180CD2880
		private void Place(EquipBagCellView cell, int index); // 0x0000000180CD2880-0x0000000180CD2B30
		public void SetCategory(EquipCategory category); // 0x0000000180CD2B30-0x0000000180CD2B80
		public void ToggleSlotFilter(EquipSlot slot); // 0x0000000180CD2B80-0x0000000180CD2BE0
		public void ToggleSort(); // 0x0000000180CD2BE0-0x0000000180CD2C30
		public void PagePrev(); // 0x0000000180CD2C30-0x0000000180CD2C80
		public void PageNext(); // 0x0000000180CD2C80-0x0000000180CD2CD0
		public void ResetState(); // 0x0000000180CD2CD0-0x0000000180CD2FB0
		private void PublishState(); // 0x0000000180CD2FB0-0x0000000180CD3210
		public void ApplyPage(EquipBagDTO data); // 0x0000000180CD3210-0x0000000180CD36F0
		private void LoadIcon(EquipBagCellView cell, int index, EquipBagItemDTO entry); // 0x0000000180CD36F0-0x0000000180CD3B00
		private void OnCellClicked(int index); // 0x0000000180CD3B00-0x0000000180CD3DE0
	}
}
