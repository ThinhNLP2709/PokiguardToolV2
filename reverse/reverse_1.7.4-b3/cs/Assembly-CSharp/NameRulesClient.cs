/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class NameRulesClient // TypeDefIndex: 1201
{
	// Fields
	private static readonly Regex ALLOWED; // 0x00
	private static readonly Regex HAS_ALNUM; // 0x08
	private static readonly Regex SPACES; // 0x10

	// Nested types
	public enum Code // TypeDefIndex: 1202
	{
		Ok = 0,
		Empty = 1,
		Length = 2,
		Chars = 3
	}

	// Constructors
	static NameRulesClient(); // 0x00000001806D1950-0x00000001806D1B90

	// Methods
	public static string Normalize(string raw); // 0x00000001806D1140-0x00000001806D1320
	public static Code Validate(string raw, out string normalized); // 0x00000001806D1320-0x00000001806D1580
	public static string Message(Code code); // 0x00000001806D1580-0x00000001806D1640
	public static int CodePointCount(string s); // 0x00000001806D1640-0x00000001806D17B0
	public static string Fold(string s); // 0x00000001806D17B0-0x00000001806D1950
}

