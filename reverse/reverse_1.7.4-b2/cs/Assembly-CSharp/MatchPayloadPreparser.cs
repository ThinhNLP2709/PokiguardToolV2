/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchPayloadPreparser // TypeDefIndex: 473
{
	// Fields
	private static readonly JsonSerializer SnapshotSerializer; // 0x00
	private static int _warnCount; // 0x08
	private const int MAX_WARN = 6; // Metadata: 0x0068B32F

	// Constructors
	static MatchPayloadPreparser(); // 0x0000000180392910-0x00000001803929C0

	// Methods
	public static bool ShouldPrepare(string type); // 0x00000001803926C0-0x0000000180392810
	public static void Prepare(ChatMessageDTO m); // 0x0000000180392610-0x00000001803926C0
	private static void PrepareOps(ChatMessageDTO m, Dictionary<string, object> p); // 0x0000000180391EB0-0x0000000180392050
	private static void PrepareBoard(ChatMessageDTO m, Dictionary<string, object> p); // 0x00000001803919D0-0x0000000180391B70
	private static void PrepareCombatSteps(ChatMessageDTO m, Dictionary<string, object> p); // 0x0000000180391B70-0x0000000180391D10
	private static void PrepareDestroyedByTag(ChatMessageDTO m, Dictionary<string, object> p); // 0x0000000180391D10-0x0000000180391EB0
	private static void PreparePlayers(ChatMessageDTO m, Dictionary<string, object> p); // 0x0000000180392050-0x0000000180392610
	private static void Warn(string field, Exception e); // 0x0000000180392810-0x0000000180392910
}

