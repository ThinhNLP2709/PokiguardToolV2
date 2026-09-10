/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class WeaponDropDTO // TypeDefIndex: 1086
{
	// Fields
	public long userWeaponId; // 0x10
	public long weaponId; // 0x18
	public int imageId; // 0x20
	public string name; // 0x28
	public string rarity; // 0x30
	public int star; // 0x38
	public int atk; // 0x3C
	public int hp; // 0x40
	public int mana; // 0x44
	public int critRate; // 0x48
	public int effectResist; // 0x4C
	public int effectRate; // 0x50
	public string element; // 0x58
	public int power; // 0x60
	public bool convertedToShards; // 0x64
	public int shardAmount; // 0x68
	public long equipId; // 0x70
	public long iconId; // 0x78
	public int slot; // 0x80
	public int rarityIdx; // 0x84

	// Properties
	public bool HasDrop { get; } // 0x0000000180523820-0x0000000180523830 
	public bool IsEquip { get; } // 0x0000000180523850-0x0000000180523870 
	public bool HasEquipIcon { get; } // 0x0000000180523830-0x0000000180523850 

	// Constructors
	public WeaponDropDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
}

