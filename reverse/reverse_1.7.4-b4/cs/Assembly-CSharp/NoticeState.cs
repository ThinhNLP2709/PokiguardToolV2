/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class NoticeState // TypeDefIndex: 1721
{
	// Fields
	[CompilerGenerated]
	private static long _LatestKnownId_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _AutoOpenArmed_k__BackingField; // 0x08
	public static bool AutoOpenInProgress; // 0x09

	// Properties
	public static long LatestKnownId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808B6590-0x00000001808B65D0 0x00000001808B65D0-0x00000001808B6620
	public static bool AutoOpenArmed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808B66A0-0x00000001808B66E0 0x00000001808B66E0-0x00000001808B6730

	// Methods
	private static string Key(int userId); // 0x00000001808B6310-0x00000001808B63A0
	public static long GetLastSeenId(int userId); // 0x00000001808B63A0-0x00000001808B64A0
	public static void MarkSeen(int userId, long maxId); // 0x00000001808B64A0-0x00000001808B6590
	public static void NoteLatestId(long maxId); // 0x00000001808B6620-0x00000001808B66A0
	public static void ArmAutoOpen(); // 0x00000001808B6730-0x00000001808B6770
	public static bool ConsumeAutoOpen(); // 0x00000001808B6770-0x00000001808B67F0
}

