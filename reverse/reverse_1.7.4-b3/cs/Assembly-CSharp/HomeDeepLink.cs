/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HomeDeepLink // TypeDefIndex: 965
{
	// Fields
	public static readonly HashSet<string> Routes; // 0x00

	// Constructors
	static HomeDeepLink(); // 0x00000001805E0A70-0x00000001805E12C0

	// Methods
	public static bool IsKnown(string key); // 0x00000001805E0370-0x00000001805E0410
	public static void Set(string key); // 0x00000001805E0410-0x00000001805E05D0
	public static bool TryConsume(out string key); // 0x00000001805E05D0-0x00000001805E0920
	public static void Clear(); // 0x00000001805E0920-0x00000001805E09C0
	private static long NowUnix(); // 0x00000001805E09C0-0x00000001805E0A70
}

