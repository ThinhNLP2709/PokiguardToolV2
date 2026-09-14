/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class EventTrackRules // TypeDefIndex: 631
{
	// Fields
	public int dropPerEnergy; // 0x10
	public int dailyCap; // 0x14
	public int dailyBonus; // 0x18
	public int surgeMultiplier; // 0x1C
	public string[] surgeWindows; // 0x20
	public string[] countReasons; // 0x28

	// Constructors
	public EventTrackRules(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public bool Counts(string reason); // 0x0000000180441650-0x00000001804417A0
}

