/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class EvolutionDetailDTO // TypeDefIndex: 487
{
	// Fields
	public long sourcePetId; // 0x10
	public string sourcePetName; // 0x18
	public int currentLevel; // 0x20
	public int requiredLevel; // 0x24
	public long targetPetId; // 0x28
	public string targetPetName; // 0x30
	public int targetMaxLevel; // 0x38
	public int currentDefeats; // 0x3C
	public int requiredDefeats; // 0x40
	public int currentCrystal; // 0x44
	public int requiredCrystal; // 0x48
	public int currentEItem1; // 0x4C
	public int requiredEItem1; // 0x50
	public int currentEItem2; // 0x54
	public int requiredEItem2; // 0x58
	public int currentEItem3; // 0x5C
	public int requiredEItem3; // 0x60
	public int currentEItem4; // 0x64
	public int requiredEItem4; // 0x68
	public List<StoneRequirementDTO> stoneRequirements; // 0x70
	public List<RequiredPetDTO> requiredPets; // 0x78
	public bool canEvolve; // 0x80
	public bool hasEvolved; // 0x81

	// Constructors
	public EvolutionDetailDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
}

