/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class WheelInfoContent // TypeDefIndex: 1145
{
	// Fields
	private const string COL_HEAD = "#FFDD84"; // Metadata: 0x0068C60C
	private const string COL_HL = "#8FE3FF"; // Metadata: 0x0068C614

	// Methods
	public static string Build(WheelBoardVM vm); // 0x000000018056BEC0-0x000000018056BF80
	private static void BuildDaily(StringBuilder sb, WheelBoardVM vm); // 0x0000000180569F30-0x000000018056A6E0
	private static void BuildGalaxy(StringBuilder sb, WheelBoardVM vm); // 0x000000018056A6E0-0x000000018056ADE0
	private static void BuildTreasure(StringBuilder sb, WheelBoardVM vm); // 0x000000018056B7C0-0x000000018056BEC0
	private static void BuildPity(StringBuilder sb, WheelBoardVM vm, string extraLine); // 0x000000018056ADE0-0x000000018056B7C0
	private static void Common(StringBuilder sb); // 0x000000018056C000-0x000000018056C220
	private static string CurrencyName(string currency); // 0x000000018056C220-0x000000018056C3B0
	private static string RarityWord(string rarity); // 0x000000018056C4F0-0x000000018056C560
	private static void Head(StringBuilder sb, string text); // 0x000000018056C3B0-0x000000018056C4A0
	private static void Bullet(StringBuilder sb, string text); // 0x000000018056BF80-0x000000018056C000
	private static string Hl(string text); // 0x000000018056C4A0-0x000000018056C4F0
}

