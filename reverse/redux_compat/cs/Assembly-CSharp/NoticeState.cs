/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class NoticeState // TypeDefIndex: 1116
{
	// Fields
	[CompilerGenerated]
	private static long _LatestKnownId_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _AutoOpenArmed_k__BackingField; // 0x08
	public static bool AutoOpenInProgress; // 0x09

	// Properties
	public static long LatestKnownId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804A6B60-0x00000001804A6BA0 0x00000001804A6BE0-0x00000001804A6C20
	public static bool AutoOpenArmed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804A6B20-0x00000001804A6B60 0x00000001804A6BA0-0x00000001804A6BE0

	// Methods
	private static string Key(int userId); // 0x00000001804A6880-0x00000001804A68E0
	public static long GetLastSeenId(int userId); // 0x00000001804A67D0-0x00000001804A6880
	public static void MarkSeen(int userId, long maxId); // 0x00000001804A68E0-0x00000001804A6A10
	public static void NoteLatestId(long maxId); // 0x00000001804A6A10-0x00000001804A6A80
	public static void ArmAutoOpen(); // 0x00000001804A6720-0x00000001804A6760
	public static bool ConsumeAutoOpen(); // 0x00000001804A6760-0x00000001804A67D0
	public static void ResetSessionFlags(); // 0x00000001804A6A80-0x00000001804A6B20
}

