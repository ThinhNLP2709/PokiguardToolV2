/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchRewardTooltip // TypeDefIndex: 2359
{
	// Fields
	private static readonly string[] EquipRarityNames; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x0000000180B4F550-0x0000000180B4F5C0 

	// Constructors
	static MatchRewardTooltip(); // 0x0000000180B50990-0x0000000180B50AF0

	// Methods
	public static MatchRewardTipTarget Attach(GameObject cell, string type, string amountText); // 0x0000000180B4F5C0-0x0000000180B4F660
	public static MatchRewardTipTarget Attach(GameObject cell, string title, string body, string amountText); // 0x0000000180B4F660-0x0000000180B4F8B0
	public static string TitleOf(string type); // 0x0000000180B4F8B0-0x0000000180B4FCA0
	public static string BodyOf(string type); // 0x0000000180B4FCA0-0x0000000180B50840
	public static string EquipRarityName(int rarityIdx); // 0x0000000180B50840-0x0000000180B508D0
	public static string Desc(string prop, string fallback); // 0x0000000180B508D0-0x0000000180B50990
}

