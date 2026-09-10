/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ElementAdvantage // TypeDefIndex: 1166
{
	// Fields
	public const int ADVANTAGE_PCT = 50; // Metadata: 0x0068C690
	public const int DISADVANTAGE_PCT = -25; // Metadata: 0x0068C691

	// Methods
	public static string Normalize(string element); // 0x0000000180560870-0x0000000180560D10
	private static bool Beats(string att, string def); // 0x0000000180560620-0x0000000180560780
	public static int Pct(string attackerElement, string defenderElement); // 0x0000000180560E50-0x0000000180560EE0
	public static int PctFromMultiplier(double multiplier); // 0x0000000180560D10-0x0000000180560E50
	public static string Label(int level, int pct); // 0x0000000180560780-0x0000000180560870
}

