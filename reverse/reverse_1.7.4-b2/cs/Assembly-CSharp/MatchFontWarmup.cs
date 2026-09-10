/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchFontWarmup // TypeDefIndex: 1503
{
	// Fields
	private static readonly int[] NumberSizes; // 0x00
	private static readonly int[] TextSizes; // 0x08
	private const string NumberGlyphs = "0123456789+-\u00D7x*/%.,:;()[]?!\'\"# \u25B2\u25BC\u2026"; // Metadata: 0x0068D1B6
	private const string AsciiLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_"; // Metadata: 0x0068D1E0
	private const string VietnameseGlyphs = "\u00E0\u00E1\u1EA3\u00E3\u1EA1\u0103\u1EB1\u1EAF\u1EB3\u1EB5\u1EB7\u00E2\u1EA7\u1EA5\u1EA9\u1EAB\u1EAD\u00E8\u00E9\u1EBB\u1EBD\u1EB9\u00EA\u1EC1\u1EBF\u1EC3\u1EC5\u1EC7\u00EC\u00ED\u1EC9\u0129\u1ECB\u00F2\u00F3\u1ECF\u00F5\u1ECD\u00F4\u1ED3\u1ED1\u1ED5\u1ED7\u1ED9\u01A1\u1EDD\u1EDB\u1EDF\u1EE1\u1EE3\u00F9\u00FA\u1EE7\u0169\u1EE5\u01B0\u1EEB\u1EE9\u1EED\u1EEF\u1EF1\u1EF3\u00FD\u1EF7\u1EF9\u1EF5\u0111\u00C0\u00C1\u1EA2\u00C3\u1EA0\u0102\u1EB0\u1EAE\u1EB2\u1EB4\u1EB6\u00C2\u1EA6\u1EA4\u1EA8\u1EAA\u1EAC\u00C8\u00C9\u1EBA\u1EBC\u1EB8\u00CA\u1EC0\u1EBE\u1EC2\u1EC4\u1EC6\u00CC\u00CD\u1EC8\u0128\u1ECA\u00D2\u00D3\u1ECE\u00D5\u1ECC\u00D4\u1ED2\u1ED0\u1ED4\u1ED6\u1ED8\u01A0\u1EDC\u1EDA\u1EDE\u1EE0\u1EE2\u00D9\u00DA\u1EE6\u0168\u1EE4\u01AF\u1EEA\u1EE8\u1EEC\u1EEE\u1EF0\u1EF2\u00DD\u1EF6\u1EF8\u1EF4\u0110"; // Metadata: 0x0068D216
	private static bool _warmed; // 0x10

	// Constructors
	static MatchFontWarmup(); // 0x00000001805E5840-0x00000001805E5950

	// Methods
	public static void Warm(); // 0x00000001805E55F0-0x00000001805E5840
	internal static void ResetForTest(); // 0x00000001805E55A0-0x00000001805E55F0
}

