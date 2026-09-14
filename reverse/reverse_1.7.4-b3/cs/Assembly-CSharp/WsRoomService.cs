/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class WsRoomService // TypeDefIndex: 595
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

	// Properties
	public static WsRoomService Instance { get; } // 0x0000000180423FF0-0x00000001804240D0 
	public string CurrentRoomId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8A70-0x00000001802D8A80 0x00000001802D8A80-0x00000001802D8AE0
	public string CurrentRoomType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
	public string OwnerUsername { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public int MaxPlayers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804240D0-0x00000001804240E0 0x00000001804240E0-0x00000001804240F0
	public Dictionary<string, bool> Members { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA540-0x00000001802BA5A0
	public Dictionary<string, object> Properties { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x00000001802BA5B0-0x00000001802BA610
	public Dictionary<string, WsPlayerStateDTO> PlayerStates { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA610-0x00000001802BA620 0x00000001802BA620-0x00000001802BA680
	public Dictionary<string, RoomSummaryDTO> AvailableRooms { [CompilerGenerated] get; } // 0x00000001802D8B80-0x00000001802D8B90 
	public bool IsSubscribed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180424510-0x0000000180424520 0x0000000180424520-0x0000000180424530
	public bool HasRoomListSnapshot { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180424530-0x0000000180424540 0x0000000180424540-0x0000000180424550
	public bool IsInRoom { get; } // 0x0000000180424550-0x0000000180424570 
	public string LastLeaveReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456F0-0x0000000180345700 0x000000018038BE50-0x000000018038BEB0
	public bool IsHost { get; } // 0x0000000180424570-0x00000001804246B0 
	public bool IsRoomFull { get; } // 0x00000001804246B0-0x00000001804246F0 

	// Events
	public event Action<string> OnRoomEntered {
		add; // 0x00000001804246F0-0x0000000180424810
		remove; // 0x0000000180424810-0x0000000180424930
	}
	public event Action<string> OnRoomLeft {
		add; // 0x0000000180424930-0x0000000180424A50
		remove; // 0x0000000180424A50-0x0000000180424B70
	}
	public event Action<string> OnEnterFailed {
		add; // 0x0000000180424B70-0x0000000180424C90
		remove; // 0x0000000180424C90-0x0000000180424DB0
	}
	public event Action OnMembersChanged {
		add; // 0x0000000180424DB0-0x0000000180424EB0
		remove; // 0x0000000180424EB0-0x0000000180424FB0
	}
	public event Action OnPropertiesChanged {
		add; // 0x0000000180424FB0-0x00000001804250B0
		remove; // 0x00000001804250B0-0x00000001804251B0
	}
	public event Action OnPlayerStatesChanged {
		add; // 0x00000001804251B0-0x00000001804252B0
		remove; // 0x00000001804252B0-0x00000001804253B0
	}
	public event Action<string> OnKicked {
		add; // 0x00000001804253B0-0x00000001804254D0
		remove; // 0x00000001804254D0-0x00000001804255F0
	}
	public event Action<string> OnKickFailed {
		add; // 0x00000001804255F0-0x0000000180425710
		remove; // 0x0000000180425710-0x0000000180425830
	}
	public event Action<string, Dictionary<string, object>> OnMatchStarting {
		add; // 0x0000000180425830-0x0000000180425950
		remove; // 0x0000000180425950-0x0000000180425A70
	}
	public event Action OnRoomListChanged {
		add; // 0x0000000180425A70-0x0000000180425B70
		remove; // 0x0000000180425B70-0x0000000180425C70
	}

	// Constructors
	private WsRoomService(); // 0x0000000180425C70-0x0000000180425F60

	// Methods
	private static Dictionary<string, WsPlayerStateDTO> ToIgnoreCaseDict(Dictionary<string, WsPlayerStateDTO> src); // 0x00000001804240F0-0x0000000180424300
	private static Dictionary<string, bool> ToIgnoreCaseMembers(Dictionary<string, bool> src); // 0x0000000180424300-0x0000000180424510
	public void TrySubscribe(); // 0x0000000180425F60-0x0000000180427030
	public void Unsubscribe(); // 0x0000000180427030-0x0000000180427050
	private void UnsubscribeFrom(ChatService cs); // 0x0000000180427050-0x0000000180428030
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x0000000180428030-0x00000001804280D0
	public void JoinRoom(string roomId); // 0x00000001804280D0-0x00000001804282F0
	public void LeaveRoom(); // 0x00000001804282F0-0x0000000180428440
	public void KickMember(string targetUsername); // 0x0000000180428440-0x0000000180428660
	public void StartMatch(); // 0x0000000180428660-0x00000001804286C0
	public void UpdateProperties(Dictionary<string, object> props); // 0x00000001804286C0-0x00000001804287F0
	public void UpdateMyPlayerProps(WsPlayerStateDTO diff); // 0x00000001804287F0-0x0000000180428A10
	private void EchoMyPropsLocally(WsPlayerStateDTO diff); // 0x0000000180428A10-0x0000000180428BF0
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x0000000180428BF0-0x0000000180428C70
	private void SendSubscribeIfConnected(); // 0x0000000180428C70-0x0000000180428F50
	public void UnsubscribeRoomList(); // 0x0000000180428F50-0x00000001804291A0
	private void HandleRoomCreated(ChatMessageDTO m); // 0x00000001804291A0-0x00000001804291B0
	private void HandleRoomJoined(ChatMessageDTO m); // 0x00000001804291A0-0x00000001804291B0
	private void HandleEntered(ChatMessageDTO m); // 0x00000001804291B0-0x0000000180429540
	private void HandleEnterFailed(string reason); // 0x0000000180429540-0x00000001804295F0
	private void HandleMemberUpdate(ChatMessageDTO m); // 0x00000001804295F0-0x0000000180429C00
	private void HandleReadyUpdate(ChatMessageDTO m); // 0x0000000180429C00-0x0000000180429EB0
	private void HandlePropsUpdate(ChatMessageDTO m); // 0x0000000180429EB0-0x0000000180429F80
	private void HandlePlayerPropsUpdate(ChatMessageDTO m); // 0x0000000180429F80-0x000000018042A0A0
	private void HandleRoomKicked(ChatMessageDTO m); // 0x000000018042A0A0-0x000000018042A250
	private void HandleRoomKickFailed(string reason); // 0x000000018042A250-0x000000018042A300
	private void HandleMatchStarting(ChatMessageDTO m); // 0x000000018042A300-0x000000018042A3F0
	private void HandleConnectionChanged(bool connected); // 0x000000018042A3F0-0x000000018042A510
	private void HandleRoomListSnapshot(RoomSummaryDTO[] rooms); // 0x000000018042A510-0x000000018042A610
	private void HandleRoomListDelta(string action, RoomSummaryDTO room); // 0x000000018042A610-0x000000018042A800
	private void ResetState(string reason); // 0x000000018042A800-0x000000018042ABE0
}

