/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WsRoomService // TypeDefIndex: 454
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
	private RoomListFilterDTO _activeFilter; // 0x58
	[CompilerGenerated]
	private string _LastLeaveReason_k__BackingField; // 0x60
	[CompilerGenerated]
	private Action<string> OnRoomEntered; // 0x68
	[CompilerGenerated]
	private Action<string> OnRoomLeft; // 0x70
	[CompilerGenerated]
	private Action<string> OnEnterFailed; // 0x78
	[CompilerGenerated]
	private Action OnMembersChanged; // 0x80
	[CompilerGenerated]
	private Action OnPropertiesChanged; // 0x88
	[CompilerGenerated]
	private Action OnPlayerStatesChanged; // 0x90
	[CompilerGenerated]
	private Action<string> OnKicked; // 0x98
	[CompilerGenerated]
	private Action<string> OnKickFailed; // 0xA0
	[CompilerGenerated]
	private Action<string, Dictionary<string, object>> OnMatchStarting; // 0xA8
	[CompilerGenerated]
	private Action OnRoomListChanged; // 0xB0
	private bool _subscribed; // 0xB8
	private ChatService _boundChat; // 0xC0
	private bool _pendingLeaveFlush; // 0xC8

	// Properties
	public static WsRoomService Instance { get; } // 0x0000000180377560-0x0000000180377800 
	public string CurrentRoomId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	public string CurrentRoomType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	public string OwnerUsername { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	public int MaxPlayers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
	public Dictionary<string, bool> Members { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	public Dictionary<string, object> Properties { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	public Dictionary<string, WsPlayerStateDTO> PlayerStates { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	public Dictionary<string, RoomSummaryDTO> AvailableRooms { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
	public bool IsSubscribed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
	public bool IsInRoom { get; } // 0x00000001803778B0-0x00000001803778D0 
	public string LastLeaveReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	public bool IsHost { get; } // 0x0000000180377800-0x00000001803778B0 
	public bool IsRoomFull { get; } // 0x00000001803778D0-0x0000000180377920 
	public bool AllReady { get; } // 0x0000000180377410-0x0000000180377550 

	// Events
	public event Action<string> OnRoomEntered {
		add; // 0x00000001803771E0-0x00000001803772A0
		remove; // 0x0000000180377E90-0x0000000180377F50
	}
	public event Action<string> OnRoomLeft {
		add; // 0x00000001803772A0-0x0000000180377360
		remove; // 0x0000000180377F50-0x0000000180378010
	}
	public event Action<string> OnEnterFailed {
		add; // 0x0000000180376CA0-0x0000000180376D60
		remove; // 0x0000000180377950-0x0000000180377A10
	}
	public event Action OnMembersChanged {
		add; // 0x0000000180376FD0-0x0000000180377080
		remove; // 0x0000000180377C80-0x0000000180377D30
	}
	public event Action OnPropertiesChanged {
		add; // 0x0000000180377130-0x00000001803771E0
		remove; // 0x0000000180377DE0-0x0000000180377E90
	}
	public event Action OnPlayerStatesChanged {
		add; // 0x0000000180377080-0x0000000180377130
		remove; // 0x0000000180377D30-0x0000000180377DE0
	}
	public event Action<string> OnKicked {
		add; // 0x0000000180376E30-0x0000000180376F00
		remove; // 0x0000000180377AE0-0x0000000180377BB0
	}
	public event Action<string> OnKickFailed {
		add; // 0x0000000180376D60-0x0000000180376E30
		remove; // 0x0000000180377A10-0x0000000180377AE0
	}
	public event Action<string, Dictionary<string, object>> OnMatchStarting {
		add; // 0x0000000180376F00-0x0000000180376FD0
		remove; // 0x0000000180377BB0-0x0000000180377C80
	}
	public event Action OnRoomListChanged {
		add; // 0x0000000180377360-0x0000000180377410
		remove; // 0x0000000180378010-0x00000001803780C0
	}

	// Constructors
	private WsRoomService(); // 0x0000000180376A80-0x0000000180376CA0

	// Methods
	private static Dictionary<string, WsPlayerStateDTO> ToIgnoreCaseDict(Dictionary<string, WsPlayerStateDTO> src); // 0x0000000180375C30-0x0000000180375E10
	private static Dictionary<string, bool> ToIgnoreCaseMembers(Dictionary<string, bool> src); // 0x0000000180375E10-0x0000000180375FF0
	public void TrySubscribe(); // 0x0000000180375FF0-0x0000000180376490
	public void Unsubscribe(); // 0x0000000180376980-0x00000001803769A0
	private void UnsubscribeFrom(ChatService cs); // 0x0000000180376490-0x00000001803768D0
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x0000000180374480-0x0000000180374520
	public void JoinRoom(string roomId); // 0x00000001803756A0-0x0000000180375710
	public void LeaveRoom(); // 0x0000000180375780-0x0000000180375850
	public void KickMember(string targetUsername); // 0x0000000180375710-0x0000000180375780
	public void SetReady(bool ready); // 0x0000000180375AF0-0x0000000180375B50
	public void StartMatch(); // 0x0000000180375B50-0x0000000180375BB0
	public void UpdateProperties(Dictionary<string, object> props); // 0x0000000180376A20-0x0000000180376A80
	public void RequestRoomList(); // 0x0000000180375850-0x00000001803758B0
	public void UpdateMyPlayerProps(WsPlayerStateDTO diff); // 0x00000001803769A0-0x0000000180376A20
	private void EchoMyPropsLocally(WsPlayerStateDTO diff); // 0x0000000180374520-0x0000000180374700
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x0000000180375BB0-0x0000000180375C30
	public void UnsubscribeRoomList(); // 0x00000001803768D0-0x0000000180376980
	private void HandleRoomCreated(ChatMessageDTO m); // 0x0000000180375270-0x0000000180375280
	private void HandleRoomJoined(ChatMessageDTO m); // 0x0000000180375270-0x0000000180375280
	private void HandleEntered(ChatMessageDTO m); // 0x00000001803748A0-0x0000000180374A40
	private void HandleEnterFailed(string reason); // 0x0000000180374800-0x00000001803748A0
	private void HandleMemberUpdate(ChatMessageDTO m); // 0x0000000180374AE0-0x0000000180374F10
	private void HandleReadyUpdate(ChatMessageDTO m); // 0x0000000180375040-0x0000000180375270
	private void HandlePropsUpdate(ChatMessageDTO m); // 0x0000000180374FD0-0x0000000180375040
	private void HandlePlayerPropsUpdate(ChatMessageDTO m); // 0x0000000180374F10-0x0000000180374FD0
	private void HandleRoomKicked(ChatMessageDTO m); // 0x0000000180375320-0x0000000180375460
	private void HandleRoomKickFailed(string reason); // 0x0000000180375280-0x0000000180375320
	private void HandleMatchStarting(ChatMessageDTO m); // 0x0000000180374A40-0x0000000180374AE0
	private void HandleConnectionChanged(bool connected); // 0x0000000180374700-0x0000000180374800
	private void HandleRoomListSnapshot(RoomSummaryDTO[] rooms); // 0x00000001803755B0-0x00000001803756A0
	private void HandleRoomListDelta(string action, RoomSummaryDTO room); // 0x0000000180375460-0x00000001803755B0
	private void ResetState(string reason); // 0x00000001803758B0-0x0000000180375AF0
}

