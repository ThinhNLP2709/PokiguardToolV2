/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class CanDauVanRollResult : CanDauVanEnvelope // TypeDefIndex: 426
{
	// Fields
	public int[] dice; // 0x20
	public int steps; // 0x28
	public int fromPos; // 0x2C
	public int toPos; // 0x30
	public int[] path; // 0x38
	public CanDauVanTile landed; // 0x40
	public RechargeEventReward granted; // 0x48
	public int rollsLeft; // 0x50
	public int roundNo; // 0x54
	public bool roundEnded; // 0x58
	public int tickets; // 0x5C
	public int rollSeq; // 0x60
	public RechargeEventReward[] tray; // 0x68
	public CanDauVanWallet wallet; // 0x70

	// Constructors
	public CanDauVanRollResult(); // 0x000000018028A320-0x000000018028A330
}

