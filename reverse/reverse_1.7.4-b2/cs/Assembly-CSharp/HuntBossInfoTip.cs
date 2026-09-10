/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HuntBossInfoTip // TypeDefIndex: 378
{
	// Fields
	public const string FLAG = "chinhphuc.bosstip"; // Metadata: 0x0068B14C
	private static readonly CultureInfo VN; // 0x00
	private const string HEX_GOLD = "FFD84A"; // Metadata: 0x0068B15E
	private const string HEX_GREEN = "5BE86B"; // Metadata: 0x0068B165
	private const string HEX_RED = "FF6B60"; // Metadata: 0x0068B16C
	private const string HEX_HINT = "C8CDD6"; // Metadata: 0x0068B173
	private const string UI_KEY = "bosstip"; // Metadata: 0x0068B17A

	// Properties
	public static bool Enabled { get; } // 0x000000018035B790-0x000000018035B7F0 

	// Nested types
	public struct State // TypeDefIndex: 379
	{
		// Fields
		public bool locked; // 0x00
		public bool cleared; // 0x01
		public int requiredOrder; // 0x04

		// Constructors
		public State(bool locked, bool cleared, int requiredOrder); // 0x000000018035D0A0-0x000000018035D0B0
	}

	// Constructors
	static HuntBossInfoTip(); // 0x000000018035B710-0x000000018035B790

	// Methods
	public static void Show(RectTransform anchor, PetEnemyDTO pet, int order, Sprite icon, int userAttack, State state); // 0x000000018035B320-0x000000018035B520
	private static List<RewardDisplayHelper.Entry> BuildRewards(PetEnemyDTO pet); // 0x000000018035AF80-0x000000018035B1D0
	private static int CtReward(PetEnemyDTO pet); // 0x000000018035B260-0x000000018035B280
	private static string Head(string prop, string fallback, bool rich); // 0x000000018035B280-0x000000018035B320
	private static string Str(string prop, string fallback); // 0x000000018035B520-0x000000018035B5D0
	public static string BuildTitle(PetEnemyDTO pet, int order); // 0x000000018035B1D0-0x000000018035B260
	public static string BuildBody(PetEnemyDTO pet, int userAttack, State state, bool rich); // 0x000000018035AEF0-0x000000018035AF80
	public static string BuildBody(PetEnemyDTO pet, int userAttack, State state, bool rich, bool gridUsed); // 0x000000018035A880-0x000000018035AEF0
	private static string Tint(string value, string hex, bool rich); // 0x000000018035B5D0-0x000000018035B710
}

