/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class GachaBannerDTO // TypeDefIndex: 633
{
	// Fields
	public const string GALAXY_BANNER_TYPE = "GALAXY"; // Metadata: 0x0068B6E1
	public long bannerId; // 0x10
	public string bannerKey; // 0x18
	public string bannerType; // 0x20
	public string name; // 0x28
	public string description; // 0x30
	public string bannerImage; // 0x38
	public string currency; // 0x40
	public int slotCount; // 0x48
	public int costPerRoll; // 0x4C
	public int bulkRollCount; // 0x50
	public int bulkCost; // 0x54
	public int bulkDiscountPercent; // 0x58
	public int softPityStart; // 0x5C
	public int hardPityCount; // 0x60
	public string pityRarity; // 0x68
	public int pityCounter; // 0x70
	public int dailyRollCapPerUser; // 0x74
	public int rollsToday; // 0x78
	public long remainingSeconds; // 0x80

	// Properties
	public bool IsFree { get; } // 0x00000001803F7DC0-0x00000001803F7E00 
	public bool HasPity { get; } // 0x00000001803F7D90-0x00000001803F7DC0 

	// Constructors
	public GachaBannerDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
}

