/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WsRoomService // TypeDefIndex: 596
{
	// Fields
	private static WsRoomService _instance; // 0x00
	[CompilerGenerated]
	private string _CurrentRoomId_k__BackingField; // 0x10
	[CompilerGenerated]
	private string _CurrentRoomType_k__BackingField; // 0x18
	[CompilerGenerated]
	private string _OwnerUsername_k__BackingField; // 0x20
	[CompilerGenerated]
	private int _MaxPlayers_k__BackingField; // 0x28
	[CompilerGenerated]
	private Dictionary<string, bool> _Members_k__BackingField; // 0x30
	[CompilerGenerated]
	private Dictionary<string, object> _Properties_k__BackingField; // 0x38
	[CompilerGenerated]
	private Dictionary<string, WsPlayerStateDTO> _PlayerStates_k__BackingField; // 0x40
	[CompilerGenerated]
	private Dictionary<string, RoomSummaryDTO> _AvailableRooms_k__BackingField; // 0x48
	[CompilerGenerated]
	private bool _IsSubscribed_k__BackingField; // 0x50
	[CompilerGenerated]
	private bool _HasRoomListSnapshot_k__BackingField; // 0x51
	private RoomListFilterDTO _activeFilter; // 0x58
	private bool _wantsRoomList; // 0x60
	[CompilerGenerated]
	private string _LastLeaveReason_k__BackingField; // 0x68
	[CompilerGenerated]
	private Action<string> OnRoomEntered; // 0x70
	[CompilerGenerated]
	private Action<string> OnRoomLeft; // 0x78
	[CompilerGenerated]
	private Action<string> OnEnterFailed; // 0x80
	[CompilerGenerated]
	private Action OnMembersChanged; // 0x88
	[CompilerGenerated]
	private Action OnPropertiesChanged; // 0x90
	[CompilerGenerated]
	private Action OnPlayerStatesChanged; // 0x98
	[CompilerGenerated]
	private Action<string> OnKicked; // 0xA0
	[CompilerGenerated]
	private Action<string> OnKickFailed; // 0xA8
	[CompilerGenerated]
	private Action<string, Dictionary<string, object>> OnMatchStarting; // 0xB0
	[CompilerGenerated]
	private Action OnRoomListChanged; // 0xB8
	private bool _subscribed; // 0xC0
	private ChatService _boundChat; // 0xC8
	private bool _pendingLeaveFlush; // 0xD0
	private string _pendingLeaveRoomId; // 0xD8

	// Properties
	public static WsRoomService Instance { get; } // 0x0000000180424D50-0x0000000180424E30 
	public string CurrentRoomId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8AA0-0x00000001802D8AB0 0x00000001802D8AB0-0x00000001802D8B10
	public string CurrentRoomType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
	public string OwnerUsername { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public int MaxPlayers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180424E30-0x0000000180424E40 0x0000000180424E40-0x0000000180424E50
	public Dictionary<string, bool> Members { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA570-0x00000001802BA5D0
	public Dictionary<string, object> Properties { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x00000001802BA5E0-0x00000001802BA640
	public Dictionary<string, WsPlayerStateDTO> PlayerStates { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA640-0x00000001802BA650 0x00000001802BA650-0x00000001802BA6B0
	public Dictionary<string, RoomSummaryDTO> AvailableRooms { [CompilerGenerated] get; } // 0x00000001802D8BB0-0x00000001802D8BC0 
	public bool IsSubscribed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180425270-0x0000000180425280 0x0000000180425280-0x0000000180425290
	public bool HasRoomListSnapshot { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180425290-0x00000001804252A0 0x00000001804252A0-0x00000001804252B0
	public bool IsInRoom { get; } // 0x00000001804252B0-0x00000001804252D0 
	public string LastLeaveReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345810-0x0000000180345820 0x000000018038C000-0x000000018038C060
	public bool IsHost { get; } // 0x00000001804252D0-0x0000000180425410 
	public bool IsRoomFull { get; } // 0x0000000180425410-0x0000000180425450 

	// Events
	public event Action<string> OnRoomEntered {
		add; // 0x0000000180425450-0x0000000180425570
		remove; // 0x0000000180425570-0x0000000180425690
	}
	public event Action<string> OnRoomLeft {
		add; // 0x0000000180425690-0x00000001804257B0
		remove; // 0x00000001804257B0-0x00000001804258D0
	}
	public event Action<string> OnEnterFailed {
		add; // 0x00000001804258D0-0x00000001804259F0
		remove; // 0x00000001804259F0-0x0000000180425B10
	}
	public event Action OnMembersChanged {
		add; // 0x0000000180425B10-0x0000000180425C10
		remove; // 0x0000000180425C10-0x0000000180425D10
	}
	public event Action OnPropertiesChanged {
		add; // 0x0000000180425D10-0x0000000180425E10
		remove; // 0x0000000180425E10-0x0000000180425F10
	}
	public event Action OnPlayerStatesChanged {
		add; // 0x0000000180425F10-0x0000000180426010
		remove; // 0x0000000180426010-0x0000000180426110
	}
	public event Action<string> OnKicked {
		add; // 0x0000000180426110-0x0000000180426230
		remove; // 0x0000000180426230-0x0000000180426350
	}
	public event Action<string> OnKickFailed {
		add; // 0x0000000180426350-0x0000000180426470
		remove; // 0x0000000180426470-0x0000000180426590
	}
	public event Action<string, Dictionary<string, object>> OnMatchStarting {
		add; // 0x0000000180426590-0x00000001804266B0
		remove; // 0x00000001804266B0-0x00000001804267D0
	}
	public event Action OnRoomListChanged {
		add; // 0x00000001804267D0-0x00000001804268D0
		remove; // 0x00000001804268D0-0x00000001804269D0
	}

	// Constructors
	private WsRoomService(); // 0x00000001804269D0-0x0000000180426CC0

	// Methods
	private static Dictionary<string, WsPlayerStateDTO> ToIgnoreCaseDict(Dictionary<string, WsPlayerStateDTO> src); // 0x0000000180424E50-0x0000000180425060
	private static Dictionary<string, bool> ToIgnoreCaseMembers(Dictionary<string, bool> src); // 0x0000000180425060-0x0000000180425270
	public void TrySubscribe(); // 0x0000000180426CC0-0x0000000180427D90
	public void Unsubscribe(); // 0x0000000180427D90-0x0000000180427DB0
	private void UnsubscribeFrom(ChatService cs); // 0x0000000180427DB0-0x0000000180428D90
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x0000000180428D90-0x0000000180428E30
	public void JoinRoom(string roomId); // 0x0000000180428E30-0x0000000180429050
	public void LeaveRoom(); // 0x0000000180429050-0x0000000180429210
	public void KickMember(string targetUsername); // 0x0000000180429210-0x0000000180429430
	public void StartMatch(); // 0x0000000180429430-0x0000000180429490
	public void UpdateProperties(Dictionary<string, object> props); // 0x0000000180429490-0x00000001804295C0
	public void UpdateMyPlayerProps(WsPlayerStateDTO diff); // 0x00000001804295C0-0x00000001804297E0
	private void EchoMyPropsLocally(WsPlayerStateDTO diff); // 0x00000001804297E0-0x00000001804299C0
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x00000001804299C0-0x0000000180429A40
	private void SendSubscribeIfConnected(); // 0x0000000180429A40-0x0000000180429D20
	public void UnsubscribeRoomList(); // 0x0000000180429D20-0x0000000180429F70
	private void HandleRoomCreated(ChatMessageDTO m); // 0x0000000180429F70-0x0000000180429F80
	private void HandleRoomJoined(ChatMessageDTO m); // 0x0000000180429F70-0x0000000180429F80
	private void HandleEntered(ChatMessageDTO m); // 0x0000000180429F80-0x000000018042A310
	private void HandleEnterFailed(string reason); // 0x000000018042A310-0x000000018042A3C0
	private void HandleMemberUpdate(ChatMessageDTO m); // 0x000000018042A3C0-0x000000018042A9D0
	private void HandleReadyUpdate(ChatMessageDTO m); // 0x000000018042A9D0-0x000000018042AC80
	private void HandlePropsUpdate(ChatMessageDTO m); // 0x000000018042AC80-0x000000018042AD50
	private void HandlePlayerPropsUpdate(ChatMessageDTO m); // 0x000000018042AD50-0x000000018042AE70
	private void HandleRoomKicked(ChatMessageDTO m); // 0x000000018042AE70-0x000000018042B020
	private void HandleRoomKickFailed(string reason); // 0x000000018042B020-0x000000018042B0D0
	private void HandleMatchStarting(ChatMessageDTO m); // 0x000000018042B0D0-0x000000018042B1C0
	internal static bool ShouldSendPendingLeave(bool connected, bool hasDebt, string currentMatchId); // 0x000000018042B1C0-0x000000018042B1E0
	private void HandleConnectionChanged(bool connected); // 0x000000018042B1E0-0x000000018042B5A0
	private void HandleRoomListSnapshot(RoomSummaryDTO[] rooms); // 0x000000018042B5A0-0x000000018042B6A0
	private void HandleRoomListDelta(string action, RoomSummaryDTO room); // 0x000000018042B6A0-0x000000018042B890
	private void ResetState(string reason); // 0x000000018042B890-0x000000018042BC70
}

