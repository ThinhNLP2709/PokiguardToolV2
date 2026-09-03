/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class HomeDeepLink // TypeDefIndex: 602
{
	// Fields
	private const string PREF_KEY = "HomeDeepLink"; // Metadata: 0x0064C5C7
	private const string PREF_AT = "HomeDeepLinkAt"; // Metadata: 0x0064C5D4
	private const int TTL_SECONDS = 60; // Metadata: 0x0064C5E3
	public static readonly HashSet<string> Routes; // 0x00

	// Constructors
	static HomeDeepLink(); // 0x00000001803AF390-0x00000001803AF8F0

	// Methods
	public static bool IsKnown(string key); // 0x00000001803AEF80-0x00000001803AF010
	public static void Set(string key); // 0x00000001803AF080-0x00000001803AF1A0
	public static bool TryConsume(out string key); // 0x00000001803AF1A0-0x00000001803AF390
	public static void Clear(); // 0x00000001803AEF20-0x00000001803AEF80
	private static long NowUnix(); // 0x00000001803AF010-0x00000001803AF080
}

