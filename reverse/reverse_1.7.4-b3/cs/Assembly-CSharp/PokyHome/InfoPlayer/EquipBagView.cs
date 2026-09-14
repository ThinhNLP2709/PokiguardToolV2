/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipBagView : MonoBehaviour // TypeDefIndex: 2775
	{
		// Fields
		public static readonly string[] TabNodeNames; // 0x00
		public static readonly string[] FilterNodeNames; // 0x08
		public static readonly int[] FilterSlotValues; // 0x10
		public const string NODE_SORT = "btn_SortByPower"; // Metadata: 0x005F18F8
		public const string NODE_PREV = "btn_PagePrev"; // Metadata: 0x005F1908
		public const string NODE_NEXT = "btn_PageNext"; // Metadata: 0x005F1915
		public const string NODE_PAGE_TEXT = "txt_PageIndicator"; // Metadata: 0x005F1922
		public const string NODE_ITEM_PANEL = "sec_ItemPanel"; // Metadata: 0x005F1934
		public const string CELL_NAME_PREFIX = "BagCell_"; // Metadata: 0x005F1942
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
		public EquipCategory Category { get; } // 0x0000000180CC2EA0-0x0000000180CC2EB0 
		public EquipSlot SlotFilter { get; } // 0x0000000180CC2EB0-0x0000000180CC2EC0 
		public bool SortByPower { get; } // 0x0000000180CC2EC0-0x0000000180CC2ED0 
		public int Page { get; } // 0x0000000180CC2ED0-0x0000000180CC2EE0 
		public int TotalPages { get; } // 0x00000001803C6390-0x00000001803C63A0 
		public EquipBagItemDTO[] Entries { get; } // 0x00000001802D8DB0-0x00000001802D8DC0 
		public int CellCount { get; } // 0x0000000180CC2EE0-0x0000000180CC2F00 
		public int Capacity { get; } // 0x0000000180CC2F00-0x0000000180CC2F10 
	
		// Events
		public event Action QueryChanged {
			add; // 0x0000000180CC2A60-0x0000000180CC2B60
			remove; // 0x0000000180CC2B60-0x0000000180CC2C60
		}
		public event Action<int, RectTransform> CellClicked {
			add; // 0x0000000180CC2C60-0x0000000180CC2D80
			remove; // 0x0000000180CC2D80-0x0000000180CC2EA0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_0 // TypeDefIndex: 2776
		{
			// Fields
			public EquipCategory cat; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AutoWire_b__0(); // 0x0000000180CC6D70-0x0000000180CC6DD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_1 // TypeDefIndex: 2777
		{
			// Fields
			public EquipSlot slot; // 0x10
			public EquipBagView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass58_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AutoWire_b__1(); // 0x0000000180CC6DD0-0x0000000180CC6E40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2778
		{
			// Fields
			public EquipBagView __4__this; // 0x10
			public EquipBagCellView cell; // 0x18
			public int index; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180CC6E40-0x0000000180CC7010
		}
	
		// Constructors
		public EquipBagView(); // 0x0000000180CC65A0-0x0000000180CC6960
		static EquipBagView(); // 0x0000000180CC6960-0x0000000180CC6D70
	
		// Methods
		private void Awake(); // 0x0000000180CC2F10-0x0000000180CC2F40
		private void OnDestroy(); // 0x0000000180CC2F40-0x0000000180CC3000
		public void AutoWire(); // 0x0000000180CC3000-0x0000000180CC4060
		private Transform Scope(); // 0x0000000180CC4060-0x0000000180CC42E0
		private static Button FindButton(Transform scope, string name); // 0x0000000180CC42E0-0x0000000180CC4430
		private void EnsureBuilt(); // 0x0000000180CC4430-0x0000000180CC4A30
		private void ReclaimExistingCells(RectTransform parent, int capacity); // 0x0000000180CC4A30-0x0000000180CC5060
		private void Place(EquipBagCellView cell, int index); // 0x0000000180CC5060-0x0000000180CC5310
		public void SetCategory(EquipCategory category); // 0x0000000180CC5310-0x0000000180CC5360
		public void ToggleSlotFilter(EquipSlot slot); // 0x0000000180CC5360-0x0000000180CC53C0
		public void ToggleSort(); // 0x0000000180CC53C0-0x0000000180CC5410
		public void PagePrev(); // 0x0000000180CC5410-0x0000000180CC5460
		public void PageNext(); // 0x0000000180CC5460-0x0000000180CC54B0
		public void ResetState(); // 0x0000000180CC54B0-0x0000000180CC5790
		private void PublishState(); // 0x0000000180CC5790-0x0000000180CC59F0
		public void ApplyPage(EquipBagDTO data); // 0x0000000180CC59F0-0x0000000180CC5ED0
		private void LoadIcon(EquipBagCellView cell, int index, EquipBagItemDTO entry); // 0x0000000180CC5ED0-0x0000000180CC62C0
		private void OnCellClicked(int index); // 0x0000000180CC62C0-0x0000000180CC65A0
	}
}
