/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class ThanhTuuGroup // TypeDefIndex: 1279
{
	// Fields
	public int id; // 0x10
	public string key; // 0x18
	public string name; // 0x20
	public string style; // 0x28
	public int iconPetId; // 0x30
	public int claimed; // 0x34
	public int total; // 0x38
	public string chestState; // 0x40
	public bool badge; // 0x48
	public RechargeEventReward chest; // 0x50
	public ThanhTuuShortcut[] shortcuts; // 0x58
	public ThanhTuuTask[] tasks; // 0x60

	// Properties
	public bool ChestReady { get; } // 0x0000000180719ED0-0x0000000180719F80 
	public bool ChestClaimed { get; } // 0x0000000180719F80-0x000000018071A030 

	// Constructors
	public ThanhTuuGroup(); // 0x000000018028A320-0x000000018028A330
}

