/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HomeDeepLink // TypeDefIndex: 967
{
	// Fields
	public static readonly HashSet<string> Routes; // 0x00

	// Constructors
	static HomeDeepLink(); // 0x00000001805E23F0-0x00000001805E2C40

	// Methods
	public static bool IsKnown(string key); // 0x00000001805E1CF0-0x00000001805E1D90
	public static void Set(string key); // 0x00000001805E1D90-0x00000001805E1F50
	public static bool TryConsume(out string key); // 0x00000001805E1F50-0x00000001805E22A0
	public static void Clear(); // 0x00000001805E22A0-0x00000001805E2340
	private static long NowUnix(); // 0x00000001805E2340-0x00000001805E23F0
}

