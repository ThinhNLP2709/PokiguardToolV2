/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class NoticeState // TypeDefIndex: 1330
{
	// Fields
	[CompilerGenerated]
	private static long _LatestKnownId_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _AutoOpenArmed_k__BackingField; // 0x08
	public static bool AutoOpenInProgress; // 0x09

	// Properties
	public static long LatestKnownId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A1210-0x00000001805A1250 0x00000001805A1290-0x00000001805A12D0
	public static bool AutoOpenArmed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A11D0-0x00000001805A1210 0x00000001805A1250-0x00000001805A1290

	// Methods
	private static string Key(int userId); // 0x00000001805A0F30-0x00000001805A0F90
	public static long GetLastSeenId(int userId); // 0x00000001805A0E80-0x00000001805A0F30
	public static void MarkSeen(int userId, long maxId); // 0x00000001805A0F90-0x00000001805A10C0
	public static void NoteLatestId(long maxId); // 0x00000001805A10C0-0x00000001805A1130
	public static void ArmAutoOpen(); // 0x00000001805A0DD0-0x00000001805A0E10
	public static bool ConsumeAutoOpen(); // 0x00000001805A0E10-0x00000001805A0E80
	public static void ResetSessionFlags(); // 0x00000001805A1130-0x00000001805A11D0
}

