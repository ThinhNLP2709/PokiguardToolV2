/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class CardData // TypeDefIndex: 1079
{
	// Fields
	public long id; // 0x10
	public long cardId; // 0x18
	public string name; // 0x20
	public string description; // 0x28
	public string elementTypeCard; // 0x30
	public int value; // 0x38
	public int maxLevel; // 0x3C
	public int count; // 0x40
	public int level; // 0x44
	public long conditionUse; // 0x48
	public long power; // 0x50
	public int green; // 0x58
	public int blue; // 0x5C
	public int red; // 0x60
	public int yellow; // 0x64
	public int white; // 0x68
	public int purple; // 0x6C
	public float damageMultiplier; // 0x70
	public string skillType; // 0x78
	public int manaCost; // 0x80
	public int powerCost; // 0x84
	public int cooldownTurns; // 0x88
	public bool needPerfection; // 0x8C
	public int eatPerfect; // 0x90
	public int eatGood; // 0x94
	public int eatBad; // 0x98

	// Constructors
	public CardData(); // 0x0000000180495A40-0x0000000180495A70

	// Methods
	public ElementTypeCard GetElementType(); // 0x00000001804959C0-0x0000000180495A40
	public bool CanUse(); // 0x00000001804959B0-0x00000001804959C0
}

