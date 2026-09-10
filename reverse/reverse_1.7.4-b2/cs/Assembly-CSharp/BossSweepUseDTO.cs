/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class BossSweepUseDTO // TypeDefIndex: 1288
{
	// Fields
	public bool sweepSuccess; // 0x10
	public bool duplicate; // 0x11
	public int percent; // 0x14
	public bool huntedBefore; // 0x18
	public string bossBand; // 0x20
	public string tier; // 0x28
	public int ticketsLeft; // 0x30
	public BossSweepRewardDTO[] rewards; // 0x38
	public bool receivedPet; // 0x40
	public long receivedPetId; // 0x48
	public int countPass; // 0x50
	public int requestPass; // 0x54
	public int requestAttack; // 0x58
	public BossSweepConsolationDTO consolation; // 0x60
	public int energyCost; // 0x68
	public int energyLeft; // 0x6C
	public string code; // 0x70
	public string message; // 0x78

	// Properties
	public bool IsBusinessError { get; } // 0x000000018058D530-0x000000018058D550 
	public bool HasConsolation { get; } // 0x000000018058D510-0x000000018058D530 

	// Constructors
	public BossSweepUseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public List<RewardDisplayHelper.Entry> BuildEntries(); // 0x000000018058D250-0x000000018058D510
}

