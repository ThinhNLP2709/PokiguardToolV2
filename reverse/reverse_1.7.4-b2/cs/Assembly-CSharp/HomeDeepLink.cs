/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HomeDeepLink // TypeDefIndex: 798
{
	// Fields
	private const string PREF_KEY = "HomeDeepLink"; // Metadata: 0x0068BBF2
	private const string PREF_AT = "HomeDeepLinkAt"; // Metadata: 0x0068BBFF
	private const int TTL_SECONDS = 60; // Metadata: 0x0068BC0E
	public static readonly HashSet<string> Routes; // 0x00

	// Constructors
	static HomeDeepLink(); // 0x000000018048EC00-0x000000018048F190

	// Methods
	public static bool IsKnown(string key); // 0x000000018048E7F0-0x000000018048E880
	public static void Set(string key); // 0x000000018048E8F0-0x000000018048EA10
	public static bool TryConsume(out string key); // 0x000000018048EA10-0x000000018048EC00
	public static void Clear(); // 0x000000018048E790-0x000000018048E7F0
	private static long NowUnix(); // 0x000000018048E880-0x000000018048E8F0
}

