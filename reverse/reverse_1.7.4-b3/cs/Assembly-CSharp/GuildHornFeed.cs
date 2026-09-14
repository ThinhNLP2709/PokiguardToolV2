/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GuildHornFeed // TypeDefIndex: 952
{
	// Fields
	[CompilerGenerated]
	private static Action<ChatMessageDTO> OnAnnounce; // 0x00
	private static readonly HashSet<long> _shownThisRun; // 0x08
	public static Action<string, string> ShowHookForTest; // 0x10

	// Events
	public static event Action<ChatMessageDTO> OnAnnounce {
		add; // 0x00000001805D26F0-0x00000001805D2840
		remove; // 0x00000001805D2840-0x00000001805D2990
	}

	// Constructors
	static GuildHornFeed(); // 0x00000001805D34F0-0x00000001805D35D0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x00000001805D2990-0x00000001805D2AD0
	private static void Show(string sender, string message); // 0x00000001805D2AD0-0x00000001805D2BA0
	public static void OnPush(ChatMessageDTO m); // 0x00000001805D2BA0-0x00000001805D2D30
	public static void OfferLatest(long id, long senderUserId, string senderName, string message, long expiresInSec); // 0x00000001805D2D30-0x00000001805D2E30
	public static bool IsSeen(long id); // 0x00000001805D2E30-0x00000001805D2EE0
	private static bool MarkSeen(long id); // 0x00000001805D2EE0-0x00000001805D3190
	private static long LastSeen(); // 0x00000001805D3190-0x00000001805D32B0
	private static string PrefKey(); // 0x00000001805D32B0-0x00000001805D34F0
}

