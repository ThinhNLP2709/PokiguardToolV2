/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[Serializable]
	public class InventoryItemDTO // TypeDefIndex: 2404
	{
		// Fields
		public const string KIND_ITEM = "item"; // Metadata: 0x0068EFBC
		public const string KIND_STONE = "stone"; // Metadata: 0x0068EFC1
		public const string KIND_RESOURCE = "resource"; // Metadata: 0x0068EFC7
		public string kind; // 0x10
		public long itemId; // 0x18
		public string code; // 0x20
		public string name; // 0x28
		public string description; // 0x30
		public string iconPath; // 0x38
		public string iconType; // 0x40
		public string element; // 0x48
		public int level; // 0x50
		public string rarity; // 0x58
		public int amount; // 0x60
	
		// Properties
		public bool IsStone { get; } // 0x00000001807F1790-0x00000001807F17E0 
		public bool IsResource { get; } // 0x00000001807F1740-0x00000001807F1790 
		public bool IsItem { get; } // 0x00000001807F16B0-0x00000001807F1740 
		public int KindRank { get; } // 0x00000001807F17E0-0x00000001807F1840 
		public int RarityIndex { get; } // 0x00000001807F1840-0x00000001807F1920 
		public string RarityLabel { get; } // 0x00000001807F1920-0x00000001807F1A50 
		public string IconPathOrDefault { get; } // 0x00000001807F1630-0x00000001807F16B0 
	
		// Constructors
		public InventoryItemDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}
}
