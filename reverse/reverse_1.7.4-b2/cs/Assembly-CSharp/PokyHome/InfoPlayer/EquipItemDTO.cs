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
	public class EquipItemDTO // TypeDefIndex: 2382
	{
		// Fields
		public long rowId; // 0x10
		public long itemId; // 0x18
		public string name; // 0x20
		public int rarity; // 0x28
		public long iconId; // 0x30
		public int star; // 0x38
		public int maxStar; // 0x3C
		public bool canUpgradeStar; // 0x40
		public int shardCostNext; // 0x44
		public int salvageShards; // 0x48
		public bool isNew; // 0x4C
		public long power; // 0x50
		public long atk; // 0x58
		public long hp; // 0x60
		public long mana; // 0x68
		public int[] resist; // 0x70
		public int setId; // 0x78
		public string setName; // 0x80
		public string perkText; // 0x88
		public int setPiecesRequired; // 0x90
		public int setPiecesWorn; // 0x94
		public long setBonusAtk; // 0x98
		public long setBonusHp; // 0xA0
		public long setBonusMana; // 0xA8
		public int[] setBonusResist; // 0xB0
	
		// Properties
		public bool SetComplete { get; } // 0x00000001807DCF60-0x00000001807DCF90 
	
		// Constructors
		public EquipItemDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}
}
