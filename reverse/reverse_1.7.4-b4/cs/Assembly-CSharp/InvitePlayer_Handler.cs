/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public static InvitePlayer_Handler Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802C36E0-0x00000001802C3720 0x00000001802C3720-0x00000001802C37C0
	public bool IsReady { get; } // 0x00000001802C37C0-0x00000001802C38E0 
	public IReadOnlyDictionary<string, bool> OnlineSnapshot { get; } // 0x00000001802A8720-0x00000001802A8730 

	// Events
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x00000001802C38E0-0x00000001802C3A00
		remove; // 0x00000001802C3A00-0x00000001802C3B20
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001802C3B20-0x00000001802C3C40
		remove; // 0x00000001802C3C40-0x00000001802C3D60
	}

	// Constructors
	public InvitePlayer_Handler(); // 0x00000001802C70D0-0x00000001802C72A0

	// Methods
	public bool IsUserOnline(string username); // 0x00000001802C3D60-0x00000001802C3E30
	public bool IsUserBusy(string username); // 0x00000001802C3E30-0x00000001802C3F00
	public void RequestOnlineList(); // 0x00000001802C3F00-0x00000001802C4040
	public void SetMyBusyStatus(bool busy); // 0x00000001802C4040-0x00000001802C4180
	public void EnsureConnected(); // 0x00000001802C4180-0x00000001802C42B0
	private static string GetLocalLoginName(); // 0x00000001802C42B0-0x00000001802C4420
	private void Awake(); // 0x00000001802C4420-0x00000001802C4690
	private void Start(); // 0x00000001802C4690-0x00000001802C46A0
	private void OnDestroy(); // 0x00000001802C46A0-0x00000001802C4810
	private void SubscribeChatEvents(); // 0x00000001802C4810-0x00000001802C4C30
	private void UnsubscribeChatEvents(); // 0x00000001802C4C30-0x00000001802C5050
	public static string DetectInviteRoomMode(); // 0x00000001802C5050-0x00000001802C5450
	public bool SendInvitation(string targetUsername, string roomName); // 0x00000001802C5450-0x00000001802C5930
	public static string BuildSlotInfo(string roomName, string roomType); // 0x00000001802C5930-0x00000001802C6270
	private void HandleInviteReceived(string sender, object messageObj); // 0x00000001802C6270-0x00000001802C68A0
	private void ParseAndShow(string sender, string[] parts, bool full); // 0x00000001802C68A0-0x00000001802C6D80
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x00000001802C6D80-0x00000001802C6F00
	private void HandleOnlineListReceived(UserPresenceDTO[] users); // 0x00000001802C6F00-0x00000001802C70D0
}

