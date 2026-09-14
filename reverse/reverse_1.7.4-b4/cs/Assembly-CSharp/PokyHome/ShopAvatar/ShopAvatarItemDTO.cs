/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	[Serializable]
	public class ShopAvatarItemDTO // TypeDefIndex: 2762
	{
		// Fields
		public long shopId; // 0x10
		public long itemId; // 0x18
		public string name; // 0x20
		public int slot; // 0x28
		public int rarity; // 0x2C
		public long iconId; // 0x30
		public long price; // 0x38
		public string currencyType; // 0x40
		public long oldPrice; // 0x48
		public int levelRequired; // 0x50
		public bool owned; // 0x54
		public bool canBuy; // 0x55
		public int lockReason; // 0x58
		public string tag; // 0x60
		public long power; // 0x68
		public long atk; // 0x70
		public long hp; // 0x78
		public long mana; // 0x80
		public int[] resist; // 0x88
		public int maxStar; // 0x90
		public int setId; // 0x94
		public string setName; // 0x98
		public int setPiecesRequired; // 0xA0
		public int setPiecesOwned; // 0xA4
		public long equippedPower; // 0xA8
		public string perkText; // 0xB0
		public EquipPerkDTO[] perks; // 0xB8
	
		// Properties
		public ShopAvatarLock Lock { get; } // 0x0000000180CB7BD0-0x0000000180CB7BE0 
	
		// Constructors
		public ShopAvatarItemDTO(); // 0x000000018028A320-0x000000018028A330
	}
}
