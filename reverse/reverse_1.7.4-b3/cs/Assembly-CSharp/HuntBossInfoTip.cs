/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HuntBossInfoTip // TypeDefIndex: 374
{
	// Fields
	private static readonly CultureInfo VN; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x000000018031C530-0x000000018031C5A0 

	// Nested types
	public struct State // TypeDefIndex: 375
	{
		// Fields
		public bool locked; // 0x00
		public bool cleared; // 0x01
		public int requiredOrder; // 0x04

		// Constructors
		public State(bool locked, bool cleared, int requiredOrder); // 0x000000018031D8A0-0x000000018031D8B0
	}

	// Constructors
	static HuntBossInfoTip(); // 0x000000018031D7C0-0x000000018031D8A0

	// Methods
	public static void Show(RectTransform anchor, PetEnemyDTO pet, int order, Sprite icon, int userAttack, State state); // 0x000000018031C5A0-0x000000018031C820
	private static List<RewardDisplayHelper.Entry> BuildRewards(PetEnemyDTO pet); // 0x000000018031C820-0x000000018031CB10
	private static int CtReward(PetEnemyDTO pet); // 0x000000018031CB10-0x000000018031CB30
	private static string Head(string prop, string fallback, bool rich); // 0x000000018031CB30-0x000000018031CBF0
	private static string Str(string prop, string fallback); // 0x000000018031CBF0-0x000000018031CCB0
	public static string BuildTitle(PetEnemyDTO pet, int order); // 0x000000018031CCB0-0x000000018031CDB0
	public static string BuildBody(PetEnemyDTO pet, int userAttack, State state, bool rich, bool gridUsed); // 0x000000018031CDB0-0x000000018031D690
	private static string Tint(string value, string hex, bool rich); // 0x000000018031D690-0x000000018031D7C0
}

