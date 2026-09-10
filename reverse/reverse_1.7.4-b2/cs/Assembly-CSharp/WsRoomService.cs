/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WsRoomService // TypeDefIndex: 542
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
	public static WsRoomService Instance { get; } // 0x00000001803DE850-0x00000001803DEAF0 
	public string CurrentRoomId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803199D0-0x00000001803199E0 0x0000000180317090-0x00000001803170A0
	public string CurrentRoomType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803003B0-0x00000001803003C0 0x0000000180317080-0x0000000180317090
	public string OwnerUsername { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF660-0x00000001802FF670 0x0000000180308AD0-0x0000000180308AE0
	public int MaxPlayers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DEC20-0x00000001803DEC30 0x00000001803DF3D0-0x00000001803DF3E0
	public Dictionary<string, bool> Members { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AA0-0x0000000180308AB0 0x0000000180308B00-0x0000000180308B10
	public Dictionary<string, object> Properties { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20
	public Dictionary<string, WsPlayerStateDTO> PlayerStates { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308A90-0x0000000180308AA0 0x0000000180308AF0-0x0000000180308B00
	public Dictionary<string, RoomSummaryDTO> AvailableRooms { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180319990-0x00000001803199A0 0x0000000180319CD0-0x0000000180319CE0
	public bool IsSubscribed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DEC10-0x00000001803DEC20 0x00000001803DF3C0-0x00000001803DF3D0
	public bool HasRoomListSnapshot { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DE840-0x00000001803DE850 0x00000001803DF3B0-0x00000001803DF3C0
	public bool WantsRoomList { get; } // 0x000000018039C0A0-0x000000018039C0B0 
	public bool IsInRoom { get; } // 0x00000001803DEBA0-0x00000001803DEBC0 
	public string LastLeaveReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180365440-0x0000000180365450 0x0000000180365520-0x0000000180365530
	public bool IsHost { get; } // 0x00000001803DEAF0-0x00000001803DEBA0 
	public bool IsRoomFull { get; } // 0x00000001803DEBC0-0x00000001803DEC10 
	public bool AllReady { get; } // 0x00000001803DE700-0x00000001803DE840 

	// Events
	public event Action<string> OnRoomEntered {
		add; // 0x00000001803DE4D0-0x00000001803DE590
		remove; // 0x00000001803DF180-0x00000001803DF240
	}
	public event Action<string> OnRoomLeft {
		add; // 0x00000001803DE590-0x00000001803DE650
		remove; // 0x00000001803DF240-0x00000001803DF300
	}
	public event Action<string> OnEnterFailed {
		add; // 0x00000001803DDF80-0x00000001803DE050
		remove; // 0x00000001803DEC30-0x00000001803DED00
	}
	public event Action OnMembersChanged {
		add; // 0x00000001803DE2C0-0x00000001803DE370
		remove; // 0x00000001803DEF70-0x00000001803DF020
	}
	public event Action OnPropertiesChanged {
		add; // 0x00000001803DE420-0x00000001803DE4D0
		remove; // 0x00000001803DF0D0-0x00000001803DF180
	}
	public event Action OnPlayerStatesChanged {
		add; // 0x00000001803DE370-0x00000001803DE420
		remove; // 0x00000001803DF020-0x00000001803DF0D0
	}
	public event Action<string> OnKicked {
		add; // 0x00000001803DE120-0x00000001803DE1F0
		remove; // 0x00000001803DEDD0-0x00000001803DEEA0
	}
	public event Action<string> OnKickFailed {
		add; // 0x00000001803DE050-0x00000001803DE120
		remove; // 0x00000001803DED00-0x00000001803DEDD0
	}
	public event Action<string, Dictionary<string, object>> OnMatchStarting {
		add; // 0x00000001803DE1F0-0x00000001803DE2C0
		remove; // 0x00000001803DEEA0-0x00000001803DEF70
	}
	public event Action OnRoomListChanged {
		add; // 0x00000001803DE650-0x00000001803DE700
		remove; // 0x00000001803DF300-0x00000001803DF3B0
	}

	// Constructors
	private WsRoomService(); // 0x00000001803DDD60-0x00000001803DDF80

	// Methods
	private static Dictionary<string, WsPlayerStateDTO> ToIgnoreCaseDict(Dictionary<string, WsPlayerStateDTO> src); // 0x00000001803DCF10-0x00000001803DD0F0
	private static Dictionary<string, bool> ToIgnoreCaseMembers(Dictionary<string, bool> src); // 0x00000001803DD0F0-0x00000001803DD2D0
	public void TrySubscribe(); // 0x00000001803DD2D0-0x00000001803DD770
	public void Unsubscribe(); // 0x00000001803DDC60-0x00000001803DDC80
	private void UnsubscribeFrom(ChatService cs); // 0x00000001803DD770-0x00000001803DDBB0
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x00000001803DB6B0-0x00000001803DB750
	public void JoinRoom(string roomId); // 0x00000001803DC8F0-0x00000001803DC960
	public void LeaveRoom(); // 0x00000001803DC9D0-0x00000001803DCAA0
	public void KickMember(string targetUsername); // 0x00000001803DC960-0x00000001803DC9D0
	public void SetReady(bool ready); // 0x00000001803DCE00-0x00000001803DCE60
	public void StartMatch(); // 0x00000001803DCE60-0x00000001803DCEC0
	public void UpdateProperties(Dictionary<string, object> props); // 0x00000001803DDD00-0x00000001803DDD60
	public void RequestRoomList(); // 0x00000001803DCAA0-0x00000001803DCB00
	public void UpdateMyPlayerProps(WsPlayerStateDTO diff); // 0x00000001803DDC80-0x00000001803DDD00
	private void EchoMyPropsLocally(WsPlayerStateDTO diff); // 0x00000001803DB750-0x00000001803DB930
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x00000001803DCEC0-0x00000001803DCF10
	private void SendSubscribeIfConnected(); // 0x00000001803DCD40-0x00000001803DCE00
	public void UnsubscribeRoomList(); // 0x00000001803DDBB0-0x00000001803DDC60
	private void HandleRoomCreated(ChatMessageDTO m); // 0x00000001803DC4C0-0x00000001803DC4D0
	private void HandleRoomJoined(ChatMessageDTO m); // 0x00000001803DC4C0-0x00000001803DC4D0
	private void HandleEntered(ChatMessageDTO m); // 0x00000001803DBAF0-0x00000001803DBC90
	private void HandleEnterFailed(string reason); // 0x00000001803DBA50-0x00000001803DBAF0
	private void HandleMemberUpdate(ChatMessageDTO m); // 0x00000001803DBD30-0x00000001803DC160
	private void HandleReadyUpdate(ChatMessageDTO m); // 0x00000001803DC290-0x00000001803DC4C0
	private void HandlePropsUpdate(ChatMessageDTO m); // 0x00000001803DC220-0x00000001803DC290
	private void HandlePlayerPropsUpdate(ChatMessageDTO m); // 0x00000001803DC160-0x00000001803DC220
	private void HandleRoomKicked(ChatMessageDTO m); // 0x00000001803DC570-0x00000001803DC6B0
	private void HandleRoomKickFailed(string reason); // 0x00000001803DC4D0-0x00000001803DC570
	private void HandleMatchStarting(ChatMessageDTO m); // 0x00000001803DBC90-0x00000001803DBD30
	private void HandleConnectionChanged(bool connected); // 0x00000001803DB930-0x00000001803DBA50
	private void HandleRoomListSnapshot(RoomSummaryDTO[] rooms); // 0x00000001803DC800-0x00000001803DC8F0
	private void HandleRoomListDelta(string action, RoomSummaryDTO room); // 0x00000001803DC6B0-0x00000001803DC800
	private void ResetState(string reason); // 0x00000001803DCB00-0x00000001803DCD40
}

