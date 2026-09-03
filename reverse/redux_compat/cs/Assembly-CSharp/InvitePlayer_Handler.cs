/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class InvitePlayer_Handler : MonoBehaviour // TypeDefIndex: 36
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
	public static InvitePlayer_Handler Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8550-0x00000001802F8590 0x00000001802F87C0-0x00000001802F8820
	public bool IsReady { get; } // 0x00000001802F8590-0x00000001802F8630 
	public IReadOnlyDictionary<string, bool> OnlineSnapshot { get; } // 0x00000001802F8630-0x00000001802F8640 

	// Events
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x00000001802F8490-0x00000001802F8550
		remove; // 0x00000001802F8700-0x00000001802F87C0
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001802F83D0-0x00000001802F8490
		remove; // 0x00000001802F8640-0x00000001802F8700
	}

	// Constructors
	public InvitePlayer_Handler(); // 0x00000001802F8260-0x00000001802F83D0

	// Methods
	public bool IsUserOnline(string username); // 0x00000001802F7600-0x00000001802F7690
	public bool IsUserBusy(string username); // 0x00000001802F7570-0x00000001802F7600
	public void RequestOnlineList(); // 0x00000001802F7B10-0x00000001802F7BC0
	public void SetMyBusyStatus(bool busy); // 0x00000001802F7EA0-0x00000001802F7F60
	public void EnsureConnected(); // 0x00000001802F6C60-0x00000001802F6D20
	private static string GetLocalLoginName(); // 0x00000001802F6D20-0x00000001802F6E00
	private void Awake(); // 0x00000001802F6000-0x00000001802F6140
	private void Start(); // 0x00000001802F7F60-0x00000001802F80E0
	private void OnDestroy(); // 0x00000001802F7690-0x00000001802F78D0
	private void SubscribeChatEvents(); // 0x00000001802F7F60-0x00000001802F80E0
	private void UnsubscribeChatEvents(); // 0x00000001802F80E0-0x00000001802F8260
	public static string DetectInviteRoomMode(); // 0x00000001802F6AE0-0x00000001802F6C60
	public bool SendInvitation(string targetUsername, string roomName); // 0x00000001802F7BC0-0x00000001802F7EA0
	public static string BuildSlotInfo(string roomName, string roomType); // 0x00000001802F6140-0x00000001802F6AE0
	private void HandleInviteReceived(string sender, object messageObj); // 0x00000001802F6E00-0x00000001802F7280
	private void ParseAndShow(string sender, string[] parts, bool full); // 0x00000001802F78D0-0x00000001802F7B10
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x00000001802F7420-0x00000001802F7570
	private void HandleOnlineListReceived(UserPresenceDTO[] users); // 0x00000001802F7280-0x00000001802F7420
}

