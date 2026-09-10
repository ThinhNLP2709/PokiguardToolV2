/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class BossSweepInfoDTO // TypeDefIndex: 1284
{
	// Fields
	public long petId; // 0x10
	public int bossLevel; // 0x18
	public string bossBand; // 0x20
	public bool huntedBefore; // 0x28
	public int huntCount; // 0x2C
	public bool locked; // 0x30
	public string lockReason; // 0x38
	public bool consumeOnFail; // 0x40
	public int energy; // 0x44
	public BossSweepTicketDTO[] tickets; // 0x48
	public string code; // 0x50
	public string message; // 0x58

	// Properties
	public bool IsBusinessError { get; } // 0x000000018058D230-0x000000018058D250 

	// Constructors
	public BossSweepInfoDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public BossSweepTicketDTO Find(string tierKey); // 0x000000018058D150-0x000000018058D230
}

