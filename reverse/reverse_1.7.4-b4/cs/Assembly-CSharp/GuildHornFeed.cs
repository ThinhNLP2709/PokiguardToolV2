/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuildHornFeed // TypeDefIndex: 954
{
	// Fields
	[CompilerGenerated]
	private static Action<ChatMessageDTO> OnAnnounce; // 0x00
	private static readonly HashSet<long> _shownThisRun; // 0x08
	public static Action<string, string> ShowHookForTest; // 0x10

	// Events
	public static event Action<ChatMessageDTO> OnAnnounce {
		add; // 0x00000001805D4070-0x00000001805D41C0
		remove; // 0x00000001805D41C0-0x00000001805D4310
	}

	// Constructors
	static GuildHornFeed(); // 0x00000001805D4E70-0x00000001805D4F50

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x00000001805D4310-0x00000001805D4450
	private static void Show(string sender, string message); // 0x00000001805D4450-0x00000001805D4520
	public static void OnPush(ChatMessageDTO m); // 0x00000001805D4520-0x00000001805D46B0
	public static void OfferLatest(long id, long senderUserId, string senderName, string message, long expiresInSec); // 0x00000001805D46B0-0x00000001805D47B0
	public static bool IsSeen(long id); // 0x00000001805D47B0-0x00000001805D4860
	private static bool MarkSeen(long id); // 0x00000001805D4860-0x00000001805D4B10
	private static long LastSeen(); // 0x00000001805D4B10-0x00000001805D4C30
	private static string PrefKey(); // 0x00000001805D4C30-0x00000001805D4E70
}

