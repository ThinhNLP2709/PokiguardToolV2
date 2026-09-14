/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class InvitePlayer_Handler : MonoBehaviour // TypeDefIndex: 46
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
	public static InvitePlayer_Handler Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802C36B0-0x00000001802C36F0 0x00000001802C36F0-0x00000001802C3790
	public bool IsReady { get; } // 0x00000001802C3790-0x00000001802C38B0 
	public IReadOnlyDictionary<string, bool> OnlineSnapshot { get; } // 0x00000001802A8720-0x00000001802A8730 

	// Events
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x00000001802C38B0-0x00000001802C39D0
		remove; // 0x00000001802C39D0-0x00000001802C3AF0
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001802C3AF0-0x00000001802C3C10
		remove; // 0x00000001802C3C10-0x00000001802C3D30
	}

	// Constructors
	public InvitePlayer_Handler(); // 0x00000001802C70A0-0x00000001802C7270

	// Methods
	public bool IsUserOnline(string username); // 0x00000001802C3D30-0x00000001802C3E00
	public bool IsUserBusy(string username); // 0x00000001802C3E00-0x00000001802C3ED0
	public void RequestOnlineList(); // 0x00000001802C3ED0-0x00000001802C4010
	public void SetMyBusyStatus(bool busy); // 0x00000001802C4010-0x00000001802C4150
	public void EnsureConnected(); // 0x00000001802C4150-0x00000001802C4280
	private static string GetLocalLoginName(); // 0x00000001802C4280-0x00000001802C43F0
	private void Awake(); // 0x00000001802C43F0-0x00000001802C4660
	private void Start(); // 0x00000001802C4660-0x00000001802C4670
	private void OnDestroy(); // 0x00000001802C4670-0x00000001802C47E0
	private void SubscribeChatEvents(); // 0x00000001802C47E0-0x00000001802C4C00
	private void UnsubscribeChatEvents(); // 0x00000001802C4C00-0x00000001802C5020
	public static string DetectInviteRoomMode(); // 0x00000001802C5020-0x00000001802C5420
	public bool SendInvitation(string targetUsername, string roomName); // 0x00000001802C5420-0x00000001802C5900
	public static string BuildSlotInfo(string roomName, string roomType); // 0x00000001802C5900-0x00000001802C6240
	private void HandleInviteReceived(string sender, object messageObj); // 0x00000001802C6240-0x00000001802C6870
	private void ParseAndShow(string sender, string[] parts, bool full); // 0x00000001802C6870-0x00000001802C6D50
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x00000001802C6D50-0x00000001802C6ED0
	private void HandleOnlineListReceived(UserPresenceDTO[] users); // 0x00000001802C6ED0-0x00000001802C70A0
}

