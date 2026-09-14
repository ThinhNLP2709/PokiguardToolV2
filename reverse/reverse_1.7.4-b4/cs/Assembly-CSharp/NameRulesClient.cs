/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class NameRulesClient // TypeDefIndex: 1203
{
	// Fields
	private static readonly Regex ALLOWED; // 0x00
	private static readonly Regex HAS_ALNUM; // 0x08
	private static readonly Regex SPACES; // 0x10

	// Nested types
	public enum Code // TypeDefIndex: 1204
	{
		Ok = 0,
		Empty = 1,
		Length = 2,
		Chars = 3
	}

	// Constructors
	static NameRulesClient(); // 0x00000001806D3570-0x00000001806D37B0

	// Methods
	public static string Normalize(string raw); // 0x00000001806D2D60-0x00000001806D2F40
	public static Code Validate(string raw, out string normalized); // 0x00000001806D2F40-0x00000001806D31A0
	public static string Message(Code code); // 0x00000001806D31A0-0x00000001806D3260
	public static int CodePointCount(string s); // 0x00000001806D3260-0x00000001806D33D0
	public static string Fold(string s); // 0x00000001806D33D0-0x00000001806D3570
}

