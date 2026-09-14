/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[Serializable]
	public class InventoryItemDTO // TypeDefIndex: 2856
	{
		// Fields
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
		public bool IsStone { get; } // 0x0000000180D11210-0x0000000180D112C0 
		public bool IsResource { get; } // 0x0000000180D112C0-0x0000000180D11370 
		public bool IsItem { get; } // 0x0000000180D11370-0x0000000180D113A0 
		public int KindRank { get; } // 0x0000000180D113A0-0x0000000180D113F0 
		public int RarityIndex { get; } // 0x0000000180D113F0-0x0000000180D11580 
		public string RarityLabel { get; } // 0x0000000180D11580-0x0000000180D11760 
		public string IconPathOrDefault { get; } // 0x0000000180D11760-0x0000000180D117F0 
	
		// Constructors
		public InventoryItemDTO(); // 0x000000018028A320-0x000000018028A330
	}
}
