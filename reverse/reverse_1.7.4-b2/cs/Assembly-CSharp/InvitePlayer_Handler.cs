/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class InvitePlayer_Handler : MonoBehaviour // TypeDefIndex: 45
{
	// Fields
	[CompilerGenerated]
	private static InvitePlayer_Handler _Instance_k__BackingField; // 0x00
	private readonly Dictionary<string, bool> _online; // 0x20
	private readonly Dictionary<string, bool> _busy; // 0x28
	[CompilerGenerated]
	private Action<string, bool, bool> OnPresenceChanged; // 0x30
	[CompilerGenerated]
	private Action<UserPresenceDTO[]> OnOnlineListReceived; // 0x38

	// Properties
	public static InvitePlayer_Handler Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018030B2D0-0x000000018030B310 0x000000018030B530-0x000000018030B590
	public bool IsReady { get; } // 0x000000018030B310-0x000000018030B3B0 
	public IReadOnlyDictionary<string, bool> OnlineSnapshot { get; } // 0x00000001802FF660-0x00000001802FF670 

	// Events
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x000000018030B210-0x000000018030B2D0
		remove; // 0x000000018030B470-0x000000018030B530
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x000000018030B150-0x000000018030B210
		remove; // 0x000000018030B3B0-0x000000018030B470
	}

	// Constructors
	public InvitePlayer_Handler(); // 0x000000018030AFE0-0x000000018030B150

	// Methods
	public bool IsUserOnline(string username); // 0x000000018030A2A0-0x000000018030A330
	public bool IsUserBusy(string username); // 0x000000018030A210-0x000000018030A2A0
	public void RequestOnlineList(); // 0x000000018030A7B0-0x000000018030A860
	public void SetMyBusyStatus(bool busy); // 0x000000018030AC20-0x000000018030ACE0
	public void EnsureConnected(); // 0x0000000180309900-0x00000001803099C0
	private static string GetLocalLoginName(); // 0x00000001803099C0-0x0000000180309AA0
	private void Awake(); // 0x0000000180308B20-0x0000000180308C60
	private void Start(); // 0x000000018030ACE0-0x000000018030AE60
	private void OnDestroy(); // 0x000000018030A330-0x000000018030A570
	private void SubscribeChatEvents(); // 0x000000018030ACE0-0x000000018030AE60
	private void UnsubscribeChatEvents(); // 0x000000018030AE60-0x000000018030AFE0
	public static string DetectInviteRoomMode(); // 0x0000000180309750-0x0000000180309900
	public bool SendInvitation(string targetUsername, string roomName); // 0x000000018030A860-0x000000018030AC20
	public static string BuildSlotInfo(string roomName, string roomType); // 0x0000000180308C60-0x0000000180309750
	private void HandleInviteReceived(string sender, object messageObj); // 0x0000000180309AA0-0x0000000180309F20
	private void ParseAndShow(string sender, string[] parts, bool full); // 0x000000018030A570-0x000000018030A7B0
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x000000018030A0C0-0x000000018030A210
	private void HandleOnlineListReceived(UserPresenceDTO[] users); // 0x0000000180309F20-0x000000018030A0C0
}

