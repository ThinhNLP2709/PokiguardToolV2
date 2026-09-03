/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ElementAdvantage // TypeDefIndex: 969
{
	// Fields
	public const int ADVANTAGE_PCT = 50; // Metadata: 0x0064CEAB
	public const int DISADVANTAGE_PCT = -25; // Metadata: 0x0064CEAC

	// Methods
	public static string Normalize(string element); // 0x0000000180470CA0-0x0000000180470FC0
	private static bool Beats(string att, string def); // 0x0000000180470A50-0x0000000180470BB0
	public static int Pct(string attackerElement, string defenderElement); // 0x0000000180471100-0x0000000180471190
	public static int PctFromMultiplier(double multiplier); // 0x0000000180470FC0-0x0000000180471100
	public static string Label(int level, int pct); // 0x0000000180470BB0-0x0000000180470CA0
}

