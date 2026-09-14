/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WsCombatBatch // TypeDefIndex: 551
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
	public bool isAuditionSkill { get; } // 0x00000001803DA500-0x00000001803DA620 
	public bool HasDestroyedTags { get; } // 0x00000001803DA620-0x00000001803DA640 
	public bool IsBossActor { get; } // 0x00000001803DA640-0x00000001803DA730 

	// Constructors
	public WsCombatBatch(); // 0x000000018028A320-0x000000018028A330
}

