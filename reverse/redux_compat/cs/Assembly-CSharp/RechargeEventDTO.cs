/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class RechargeEventDTO // TypeDefIndex: 728
{
	// Fields
	public long id; // 0x10
	public string key; // 0x18
	public string type; // 0x20
	public string name; // 0x28
	public long startAt; // 0x30
	public long endAt; // 0x38
	public long resetAt; // 0x40
	public long paid; // 0x48
	public bool hasClaimable; // 0x50
	public int revolveDays; // 0x54
	public int daysRemaining; // 0x58
	public int totalReceived; // 0x5C
	public RechargeMilestoneDTO[] milestones; // 0x60

	// Constructors
	public RechargeEventDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
}

