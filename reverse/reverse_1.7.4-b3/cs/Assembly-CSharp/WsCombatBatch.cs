/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class WsCombatBatch // TypeDefIndex: 550
{
	// Fields
	public long srvSeq; // 0x10
	public string actorUsername; // 0x18
	public int totalDamageDisplay; // 0x20
	public List<WsCombatStepDTO> steps; // 0x28
	public Dictionary<string, int> destroyedByTag; // 0x30
	public BoardCellDTO[][] board; // 0x38
	public bool isSkill; // 0x40
	public string skillElementType; // 0x48

	// Properties
	public bool isAuditionSkill { get; } // 0x00000001803D97C0-0x00000001803D98E0 
	public bool HasDestroyedTags { get; } // 0x00000001803D98E0-0x00000001803D9900 
	public bool IsBossActor { get; } // 0x00000001803D9900-0x00000001803D99F0 

	// Constructors
	public WsCombatBatch(); // 0x000000018028A320-0x000000018028A330
}

