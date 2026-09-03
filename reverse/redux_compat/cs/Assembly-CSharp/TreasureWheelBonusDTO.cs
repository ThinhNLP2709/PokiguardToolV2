/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class TreasureWheelBonusDTO // TypeDefIndex: 810
{
	// Fields
	public long id; // 0x10
	public int spinsRequired; // 0x18
	public TreasureWheelReward reward; // 0x20
	public string status; // 0x28
	public const string LOCKED = "LOCKED"; // Metadata: 0x0064C965
	public const string CAN_CLAIM = "CAN_CLAIM"; // Metadata: 0x0064C96C
	public const string CLAIMED = "CLAIMED"; // Metadata: 0x0064C976

	// Properties
	public bool CanClaim { get; } // 0x0000000180433ED0-0x0000000180433F10 
	public bool Claimed { get; } // 0x0000000180433F10-0x0000000180433F50 

	// Constructors
	public TreasureWheelBonusDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
}

