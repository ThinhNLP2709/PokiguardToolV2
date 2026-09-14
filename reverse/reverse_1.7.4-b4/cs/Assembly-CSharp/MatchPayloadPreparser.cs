/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchPayloadPreparser // TypeDefIndex: 529
{
	// Fields
	private static readonly JsonSerializer SnapshotSerializer; // 0x00
	private static int _warnCount; // 0x08

	// Constructors
	static MatchPayloadPreparser(); // 0x00000001803C2600-0x00000001803C2760

	// Methods
	public static bool ShouldPrepare(string type); // 0x00000001803C14D0-0x00000001803C16E0
	public static void Prepare(ChatMessageDTO m); // 0x00000001803C16E0-0x00000001803C1790
	private static void PrepareOps(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1790-0x00000001803C1950
	private static void PrepareBoard(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1950-0x00000001803C1B10
	private static void PrepareCombatSteps(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1B10-0x00000001803C1CD0
	private static void PrepareDestroyedByTag(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1CD0-0x00000001803C1E90
	private static void PreparePlayers(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803C1E90-0x00000001803C24E0
	private static void Warn(string field, Exception e); // 0x00000001803C24E0-0x00000001803C2600
}

