/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class TreasureWheelBonusDTO // TypeDefIndex: 1005
{
	// Fields
	public long id; // 0x10
	public int spinsRequired; // 0x18
	public TreasureWheelReward reward; // 0x20
	public string status; // 0x28
	public const string LOCKED = "LOCKED"; // Metadata: 0x0068C03B
	public const string CAN_CLAIM = "CAN_CLAIM"; // Metadata: 0x0068C042
	public const string CLAIMED = "CLAIMED"; // Metadata: 0x0068C04C

	// Properties
	public bool CanClaim { get; } // 0x000000018050C480-0x000000018050C4C0 
	public bool Claimed { get; } // 0x000000018050C4C0-0x000000018050C500 

	// Constructors
	public TreasureWheelBonusDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
}

