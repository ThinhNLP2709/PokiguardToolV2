/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HuntBossInfoTip // TypeDefIndex: 374
{
	// Fields
	private static readonly CultureInfo VN; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x000000018031C5E0-0x000000018031C650 

	// Nested types
	public struct State // TypeDefIndex: 375
	{
		// Fields
		public bool locked; // 0x00
		public bool cleared; // 0x01
		public int requiredOrder; // 0x04

		// Constructors
		public State(bool locked, bool cleared, int requiredOrder); // 0x000000018031D950-0x000000018031D960
	}

	// Constructors
	static HuntBossInfoTip(); // 0x000000018031D870-0x000000018031D950

	// Methods
	public static void Show(RectTransform anchor, PetEnemyDTO pet, int order, Sprite icon, int userAttack, State state); // 0x000000018031C650-0x000000018031C8D0
	private static List<RewardDisplayHelper.Entry> BuildRewards(PetEnemyDTO pet); // 0x000000018031C8D0-0x000000018031CBC0
	private static int CtReward(PetEnemyDTO pet); // 0x000000018031CBC0-0x000000018031CBE0
	private static string Head(string prop, string fallback, bool rich); // 0x000000018031CBE0-0x000000018031CCA0
	private static string Str(string prop, string fallback); // 0x000000018031CCA0-0x000000018031CD60
	public static string BuildTitle(PetEnemyDTO pet, int order); // 0x000000018031CD60-0x000000018031CE60
	public static string BuildBody(PetEnemyDTO pet, int userAttack, State state, bool rich, bool gridUsed); // 0x000000018031CE60-0x000000018031D740
	private static string Tint(string value, string hex, bool rich); // 0x000000018031D740-0x000000018031D870
}

