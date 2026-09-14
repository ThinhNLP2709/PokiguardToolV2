/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MatchPayloadPreparser // TypeDefIndex: 528
{
	// Fields
	private static readonly JsonSerializer SnapshotSerializer; // 0x00
	private static int _warnCount; // 0x08

	// Constructors
	static MatchPayloadPreparser(); // 0x00000001803C1930-0x00000001803C1A90

	// Methods
	public static bool ShouldPrepare(string type); // 0x00000001803C0800-0x00000001803C0A10
	public static void Prepare(ChatMessageDTO m); // 0x00000001803C0A10-0x00000001803C0AC0
	private static void PrepareOps(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C0AC0-0x00000001803C0C80
	private static void PrepareBoard(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C0C80-0x00000001803C0E40
	private static void PrepareCombatSteps(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C0E40-0x00000001803C1000
	private static void PrepareDestroyedByTag(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1000-0x00000001803C11C0
	private static void PreparePlayers(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C11C0-0x00000001803C1810
	private static void Warn(string field, Exception e); // 0x00000001803C1810-0x00000001803C1930
}

