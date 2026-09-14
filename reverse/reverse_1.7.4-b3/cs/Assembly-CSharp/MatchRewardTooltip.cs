/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MatchRewardTooltip // TypeDefIndex: 2352
{
	// Fields
	private static readonly string[] EquipRarityNames; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x0000000180B422D0-0x0000000180B42340 

	// Constructors
	static MatchRewardTooltip(); // 0x0000000180B43710-0x0000000180B43870

	// Methods
	public static MatchRewardTipTarget Attach(GameObject cell, string type, string amountText); // 0x0000000180B42340-0x0000000180B423E0
	public static MatchRewardTipTarget Attach(GameObject cell, string title, string body, string amountText); // 0x0000000180B423E0-0x0000000180B42630
	public static string TitleOf(string type); // 0x0000000180B42630-0x0000000180B42A20
	public static string BodyOf(string type); // 0x0000000180B42A20-0x0000000180B435C0
	public static string EquipRarityName(int rarityIdx); // 0x0000000180B435C0-0x0000000180B43650
	public static string Desc(string prop, string fallback); // 0x0000000180B43650-0x0000000180B43710
}

