/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class NoticeState // TypeDefIndex: 1719
{
	// Fields
	[CompilerGenerated]
	private static long _LatestKnownId_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _AutoOpenArmed_k__BackingField; // 0x08
	public static bool AutoOpenInProgress; // 0x09

	// Properties
	public static long LatestKnownId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808B3C10-0x00000001808B3C50 0x00000001808B3C50-0x00000001808B3CA0
	public static bool AutoOpenArmed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808B3D20-0x00000001808B3D60 0x00000001808B3D60-0x00000001808B3DB0

	// Methods
	private static string Key(int userId); // 0x00000001808B3990-0x00000001808B3A20
	public static long GetLastSeenId(int userId); // 0x00000001808B3A20-0x00000001808B3B20
	public static void MarkSeen(int userId, long maxId); // 0x00000001808B3B20-0x00000001808B3C10
	public static void NoteLatestId(long maxId); // 0x00000001808B3CA0-0x00000001808B3D20
	public static void ArmAutoOpen(); // 0x00000001808B3DB0-0x00000001808B3DF0
	public static bool ConsumeAutoOpen(); // 0x00000001808B3DF0-0x00000001808B3E70
}

