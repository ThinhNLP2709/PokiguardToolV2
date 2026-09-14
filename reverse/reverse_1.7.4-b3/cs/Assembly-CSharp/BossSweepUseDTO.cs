/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class BossSweepUseDTO // TypeDefIndex: 1688
{
	// Fields
	public bool sweepSuccess; // 0x10
	public bool duplicate; // 0x11
	public int percent; // 0x14
	public string tier; // 0x18
	public int ticketsLeft; // 0x20
	public BossSweepRewardDTO[] rewards; // 0x28
	public bool receivedPet; // 0x30
	public int countPass; // 0x34
	public int requestPass; // 0x38
	public int requestAttack; // 0x3C
	public BossSweepConsolationDTO consolation; // 0x40
	public int energyCost; // 0x48
	public int energyLeft; // 0x4C
	public string code; // 0x50
	public string message; // 0x58

	// Properties
	public bool IsBusinessError { get; } // 0x00000001808B0040-0x00000001808B0060 
	public bool HasConsolation { get; } // 0x00000001808B01E0-0x00000001808B0200 

	// Constructors
	public BossSweepUseDTO(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public List<RewardDisplayHelper.Entry> BuildEntries(); // 0x00000001808B0200-0x00000001808B0530
}

