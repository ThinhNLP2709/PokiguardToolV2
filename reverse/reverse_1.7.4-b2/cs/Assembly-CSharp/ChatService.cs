/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using WebSocketSharp;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatService : MonoBehaviour // TypeDefIndex: 454
{
	// Fields
	private static ChatService _instance; // 0x00
	private static bool _isQuitting; // 0x08
	private WebSocket webSocket; // 0x20
	private static WebSocket _activeSocket; // 0x10
	private static bool _readyStateCheckOn; // 0x18
	private static bool _preParseOn; // 0x19
	private bool isConnected; // 0x28
	private int userId; // 0x2C
	private string username; // 0x30
	private List<ChatMessageDTO> messageHistory; // 0x38
	private int maxMessages; // 0x40
	private readonly List<ChatMessageDTO> teamMessageHistory; // 0x48
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnTeamMessage; // 0x50
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnTeamEmote; // 0x58
	private readonly List<ChatMessageDTO> guildMessageHistory; // 0x60
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGuildMessage; // 0x68
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGuildPush; // 0x70
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGuildBossHp; // 0x78
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnChatReact; // 0x80
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReadyState; // 0x88
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMessageReceived; // 0x90
	[CompilerGenerated]
	private Action<bool> OnConnectionChanged; // 0x98
	[CompilerGenerated]
	private Action<int> OnReconnecting; // 0xA0
	[CompilerGenerated]
	private Action<string, Color> OnStatusChanged; // 0xA8
	[CompilerGenerated]
	private Action<string, string> OnInviteReceived; // 0xB0
	[CompilerGenerated]
	private Action<string, string> OnInviteFailed; // 0xB8
	[CompilerGenerated]
	private Action<string, bool, bool> OnPresenceChanged; // 0xC0
	[CompilerGenerated]
	private Action<UserPresenceDTO[]> OnOnlineListReceived; // 0xC8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomCreated; // 0xD0
	[CompilerGenerated]
	private Action<string> OnRoomCreateFailed; // 0xD8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomJoined; // 0xE0
	[CompilerGenerated]
	private Action<string> OnRoomJoinFailed; // 0xE8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMemberUpdate; // 0xF0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomReadyUpdate; // 0xF8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMatchStarting; // 0x100
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomStartMatchFailed; // 0x108
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPropsUpdate; // 0x110
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPlayerPropsUpdate; // 0x118
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomKicked; // 0x120
	[CompilerGenerated]
	private Action<string> OnRoomKickFailed; // 0x128
	[CompilerGenerated]
	private Action<RoomBootstrapData> OnRoomBootstrapResponse; // 0x130
	[CompilerGenerated]
	private Action<string> OnRoomBootstrapFailed; // 0x138
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnUserEnergyDelta; // 0x140
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGiftPush; // 0x148
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnNoticePush; // 0x150
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendPush; // 0x158
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendMsg; // 0x160
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendOnline; // 0x168
	[CompilerGenerated]
	private Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse; // 0x170
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListReceived; // 0x178
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListSnapshot; // 0x180
	[CompilerGenerated]
	private Action<string, RoomSummaryDTO> OnRoomListDelta; // 0x188
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0x190
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0x198
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchMoveRes; // 0x1A0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReject; // 0x1A8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTurnEnd; // 0x1B0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTimerTick; // 0x1B8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchCardUseRes; // 0x1C0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillUseRes; // 0x1C8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerLeft; // 0x1D0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerRejoin; // 0x1D8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchAfkWarn; // 0x1E0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillCast; // 0x1E8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillHint; // 0x1F0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteEvent; // 0x1F8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchBossAction; // 0x200
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteChallenge; // 0x208
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionListRes; // 0x210
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionRes; // 0x218
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchGameOver; // 0x220
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchEndNotice; // 0x228
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResultPush; // 0x230
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWsConfig; // 0x238
	[CompilerGenerated]
	private Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse; // 0x240
	[CompilerGenerated]
	private Action<HubBootstrapData> OnHubBootstrapResponse; // 0x248
	[CompilerGenerated]
	private Action<string> OnHubBootstrapFailed; // 0x250
	[CompilerGenerated]
	private Action<MatchPrepDataDTO> OnMatchPrepResponse; // 0x258
	[CompilerGenerated]
	private Action<string> OnMatchPrepFailed; // 0x260
	[CompilerGenerated]
	private Action<PetRewardDataDTO> OnMatchRewardResponse; // 0x268
	[CompilerGenerated]
	private Action<string> OnMatchRewardFailed; // 0x270
	[CompilerGenerated]
	private Action<PvpProfileDTO> OnPvpProfileResponse; // 0x278
	[CompilerGenerated]
	private Action<string> OnPvpProfileFailed; // 0x280
	[CompilerGenerated]
	private Action<List<WorldBossDTO>> OnWorldBossListResponse; // 0x288
	[CompilerGenerated]
	private Action<string> OnWorldBossListFailed; // 0x290
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse; // 0x298
	[CompilerGenerated]
	private Action<string> OnWorldBossDamageSubmitFailed; // 0x2A0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPvpPong; // 0x2A8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchmakingFound; // 0x2B0
	[CompilerGenerated]
	private Action<string> OnMatchmakingFailed; // 0x2B8
	private static readonly JsonSerializerSettings _wsDeserializeSettings; // 0x20
	private static readonly JsonSerializerSettings _wsSerializeSettings; // 0x28
	private Coroutine _heartbeatCoroutine; // 0x2C0
	private int _lastRttMs; // 0x2C8
	private bool _pingInFlight; // 0x2CC
	private bool _pingFailed; // 0x2CD
	private const int PING_FAIL_STREAK_TO_DIE = 2; // Metadata: 0x0068B2CC
	private int _pingFailStreak; // 0x2D0
	private bool _explicitDisconnect; // 0x2D4
	private Coroutine _reconnectCoroutine; // 0x2D8
	private int _reconnectAttempt; // 0x2E0
	private bool _connecting; // 0x2E4
	private float _connectStartedAt; // 0x2E8
	private const float CONNECT_GUARD_SEC = 20f; // Metadata: 0x0068B2CD
	private const int SEND_QUEUE_CAPACITY = 512; // Metadata: 0x0068B2D1
	private static readonly BlockingCollection<QueuedWsMessage> _sendQueue; // 0x30
	private static Thread _senderThread; // 0x38
	private static readonly object _senderLock; // 0x40
	private float _lastEmoteAt; // 0x2EC
	private float _historyReplayUntil; // 0x2F0
	public const string REACT_FLAG_KEY = "chat.react"; // Metadata: 0x0068B2D3
	private const float ChatReactCooldown = 0.5f; // Metadata: 0x0068B2DE
	private float _lastChatReactAt; // 0x2F4

	// Properties
	public static ChatService Instance { get; } // 0x0000000180385A50-0x0000000180385C40 
	public IReadOnlyList<ChatMessageDTO> TeamMessageHistory { get; } // 0x0000000180319990-0x00000001803199A0 
	public IReadOnlyList<ChatMessageDTO> GuildMessageHistory { get; } // 0x0000000180385A10-0x0000000180385A20 
	public bool IsConnected { get; } // 0x0000000180385C40-0x0000000180385C50 
	public string Username { get; } // 0x0000000180308AA0-0x0000000180308AB0 
	public IReadOnlyList<ChatMessageDTO> MessageHistory { get; } // 0x0000000180308AB0-0x0000000180308AC0 
	public int LastRttMs { get; } // 0x0000000180385C50-0x0000000180385C70 
	public bool InHistoryReplayWindow { get; } // 0x0000000180385A20-0x0000000180385A50 
	public static bool ReactEnabled { get; } // 0x0000000180385C70-0x0000000180385CD0 

	// Events
	public event Action<ChatMessageDTO> OnTeamMessage {
		add; // 0x0000000180385470-0x0000000180385530
		remove; // 0x0000000180389570-0x0000000180389630
	}
	public event Action<ChatMessageDTO> OnTeamEmote {
		add; // 0x00000001803853B0-0x0000000180385470
		remove; // 0x00000001803894B0-0x0000000180389570
	}
	public event Action<ChatMessageDTO> OnGuildMessage {
		add; // 0x0000000180382170-0x0000000180382230
		remove; // 0x0000000180386270-0x0000000180386330
	}
	public event Action<ChatMessageDTO> OnGuildPush {
		add; // 0x0000000180382230-0x00000001803822F0
		remove; // 0x0000000180386330-0x00000001803863F0
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x00000001803820B0-0x0000000180382170
		remove; // 0x00000001803861B0-0x0000000180386270
	}
	public event Action<ChatMessageDTO> OnChatReact {
		add; // 0x0000000180381BD0-0x0000000180381CA0
		remove; // 0x0000000180385CD0-0x0000000180385DA0
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x0000000180383190-0x0000000180383260
		remove; // 0x0000000180387290-0x0000000180387360
	}
	public event Action<ChatMessageDTO> OnMessageReceived {
		add; // 0x0000000180383CF0-0x0000000180383DC0
		remove; // 0x0000000180387DF0-0x0000000180387EC0
	}
	public event Action<bool> OnConnectionChanged {
		add; // 0x0000000180381CA0-0x0000000180381D70
		remove; // 0x0000000180385DA0-0x0000000180385E70
	}
	public event Action<int> OnReconnecting {
		add; // 0x0000000180384440-0x0000000180384510
		remove; // 0x0000000180388540-0x0000000180388610
	}
	public event Action<string, Color> OnStatusChanged {
		add; // 0x00000001803852E0-0x00000001803853B0
		remove; // 0x00000001803893E0-0x00000001803894B0
	}
	public event Action<string, string> OnInviteReceived {
		add; // 0x0000000180382560-0x0000000180382630
		remove; // 0x0000000180386660-0x0000000180386730
	}
	public event Action<string, string> OnInviteFailed {
		add; // 0x0000000180382490-0x0000000180382560
		remove; // 0x0000000180386590-0x0000000180386660
	}
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x0000000180384100-0x00000001803841D0
		remove; // 0x0000000180388200-0x00000001803882D0
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x0000000180383E90-0x0000000180383F60
		remove; // 0x0000000180387F90-0x0000000180388060
	}
	public event Action<ChatMessageDTO> OnRoomCreated {
		add; // 0x0000000180384780-0x0000000180384850
		remove; // 0x0000000180388880-0x0000000180388950
	}
	public event Action<string> OnRoomCreateFailed {
		add; // 0x00000001803846B0-0x0000000180384780
		remove; // 0x00000001803887B0-0x0000000180388880
	}
	public event Action<ChatMessageDTO> OnRoomJoined {
		add; // 0x0000000180384920-0x00000001803849F0
		remove; // 0x0000000180388A20-0x0000000180388AF0
	}
	public event Action<string> OnRoomJoinFailed {
		add; // 0x0000000180384850-0x0000000180384920
		remove; // 0x0000000180388950-0x0000000180388A20
	}
	public event Action<ChatMessageDTO> OnRoomMemberUpdate {
		add; // 0x0000000180384ED0-0x0000000180384FA0
		remove; // 0x0000000180388FD0-0x00000001803890A0
	}
	public event Action<ChatMessageDTO> OnRoomReadyUpdate {
		add; // 0x0000000180385140-0x0000000180385210
		remove; // 0x0000000180389240-0x0000000180389310
	}
	public event Action<ChatMessageDTO> OnRoomMatchStarting {
		add; // 0x0000000180384E00-0x0000000180384ED0
		remove; // 0x0000000180388F00-0x0000000180388FD0
	}
	public event Action<ChatMessageDTO> OnRoomStartMatchFailed {
		add; // 0x0000000180385210-0x00000001803852E0
		remove; // 0x0000000180389310-0x00000001803893E0
	}
	public event Action<ChatMessageDTO> OnRoomPropsUpdate {
		add; // 0x0000000180385070-0x0000000180385140
		remove; // 0x0000000180389170-0x0000000180389240
	}
	public event Action<ChatMessageDTO> OnRoomPlayerPropsUpdate {
		add; // 0x0000000180384FA0-0x0000000180385070
		remove; // 0x00000001803890A0-0x0000000180389170
	}
	public event Action<ChatMessageDTO> OnRoomKicked {
		add; // 0x0000000180384AC0-0x0000000180384B90
		remove; // 0x0000000180388BC0-0x0000000180388C90
	}
	public event Action<string> OnRoomKickFailed {
		add; // 0x00000001803849F0-0x0000000180384AC0
		remove; // 0x0000000180388AF0-0x0000000180388BC0
	}
	public event Action<RoomBootstrapData> OnRoomBootstrapResponse {
		add; // 0x00000001803845E0-0x00000001803846B0
		remove; // 0x00000001803886E0-0x00000001803887B0
	}
	public event Action<string> OnRoomBootstrapFailed {
		add; // 0x0000000180384510-0x00000001803845E0
		remove; // 0x0000000180388610-0x00000001803886E0
	}
	public event Action<ChatMessageDTO> OnUserEnergyDelta {
		add; // 0x0000000180385530-0x0000000180385600
		remove; // 0x0000000180389630-0x0000000180389700
	}
	public event Action<ChatMessageDTO> OnGiftPush {
		add; // 0x0000000180381FE0-0x00000001803820B0
		remove; // 0x00000001803860E0-0x00000001803861B0
	}
	public event Action<ChatMessageDTO> OnNoticePush {
		add; // 0x0000000180383DC0-0x0000000180383E90
		remove; // 0x0000000180387EC0-0x0000000180387F90
	}
	public event Action<ChatMessageDTO> OnFriendPush {
		add; // 0x0000000180381F10-0x0000000180381FE0
		remove; // 0x0000000180386010-0x00000001803860E0
	}
	public event Action<ChatMessageDTO> OnFriendMsg {
		add; // 0x0000000180381D70-0x0000000180381E40
		remove; // 0x0000000180385E70-0x0000000180385F40
	}
	public event Action<ChatMessageDTO> OnFriendOnline {
		add; // 0x0000000180381E40-0x0000000180381F10
		remove; // 0x0000000180385F40-0x0000000180386010
	}
	public event Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse {
		add; // 0x0000000180383F60-0x0000000180384030
		remove; // 0x0000000180388060-0x0000000180388130
	}
	public event Action<RoomSummaryDTO[]> OnRoomListReceived {
		add; // 0x0000000180384C60-0x0000000180384D30
		remove; // 0x0000000180388D60-0x0000000180388E30
	}
	public event Action<RoomSummaryDTO[]> OnRoomListSnapshot {
		add; // 0x0000000180384D30-0x0000000180384E00
		remove; // 0x0000000180388E30-0x0000000180388F00
	}
	public event Action<string, RoomSummaryDTO> OnRoomListDelta {
		add; // 0x0000000180384B90-0x0000000180384C60
		remove; // 0x0000000180388C90-0x0000000180388D60
	}
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803838E0-0x00000001803839B0
		remove; // 0x00000001803879E0-0x0000000180387AB0
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x0000000180383400-0x00000001803834D0
		remove; // 0x0000000180387500-0x00000001803875D0
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x0000000180382BE0-0x0000000180382CB0
		remove; // 0x0000000180386CE0-0x0000000180386DB0
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x0000000180383260-0x0000000180383330
		remove; // 0x0000000180387360-0x0000000180387430
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x0000000180383A80-0x0000000180383B50
		remove; // 0x0000000180387B80-0x0000000180387C50
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x00000001803839B0-0x0000000180383A80
		remove; // 0x0000000180387AB0-0x0000000180387B80
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x00000001803827D0-0x00000001803828A0
		remove; // 0x00000001803868D0-0x00000001803869A0
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x0000000180383810-0x00000001803838E0
		remove; // 0x0000000180387910-0x00000001803879E0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x0000000180382CB0-0x0000000180382D80
		remove; // 0x0000000180386DB0-0x0000000180386E80
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x0000000180382D80-0x0000000180382E50
		remove; // 0x0000000180386E80-0x0000000180386F50
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x0000000180382630-0x0000000180382700
		remove; // 0x0000000180386730-0x0000000180386800
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x0000000180383670-0x0000000180383740
		remove; // 0x0000000180387770-0x0000000180387840
	}
	public event Action<ChatMessageDTO> OnMatchSkillHint {
		add; // 0x0000000180383740-0x0000000180383810
		remove; // 0x0000000180387840-0x0000000180387910
	}
	public event Action<ChatMessageDTO> OnMatchQteEvent {
		add; // 0x00000001803830C0-0x0000000180383190
		remove; // 0x00000001803871C0-0x0000000180387290
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x0000000180382700-0x00000001803827D0
		remove; // 0x0000000180386800-0x00000001803868D0
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x0000000180382FF0-0x00000001803830C0
		remove; // 0x00000001803870F0-0x00000001803871C0
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x0000000180382970-0x0000000180382A40
		remove; // 0x0000000180386A70-0x0000000180386B40
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x0000000180382A40-0x0000000180382B10
		remove; // 0x0000000180386B40-0x0000000180386C10
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x0000000180382B10-0x0000000180382BE0
		remove; // 0x0000000180386C10-0x0000000180386CE0
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x00000001803828A0-0x0000000180382970
		remove; // 0x00000001803869A0-0x0000000180386A70
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x0000000180383330-0x0000000180383400
		remove; // 0x0000000180387430-0x0000000180387500
	}
	public event Action<ChatMessageDTO> OnWsConfig {
		add; // 0x0000000180385940-0x0000000180385A10
		remove; // 0x0000000180389A40-0x0000000180389B10
	}
	public event Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse {
		add; // 0x0000000180384030-0x0000000180384100
		remove; // 0x0000000180388130-0x0000000180388200
	}
	public event Action<HubBootstrapData> OnHubBootstrapResponse {
		add; // 0x00000001803823C0-0x0000000180382490
		remove; // 0x00000001803864C0-0x0000000180386590
	}
	public event Action<string> OnHubBootstrapFailed {
		add; // 0x00000001803822F0-0x00000001803823C0
		remove; // 0x00000001803863F0-0x00000001803864C0
	}
	public event Action<MatchPrepDataDTO> OnMatchPrepResponse {
		add; // 0x0000000180382F20-0x0000000180382FF0
		remove; // 0x0000000180387020-0x00000001803870F0
	}
	public event Action<string> OnMatchPrepFailed {
		add; // 0x0000000180382E50-0x0000000180382F20
		remove; // 0x0000000180386F50-0x0000000180387020
	}
	public event Action<PetRewardDataDTO> OnMatchRewardResponse {
		add; // 0x00000001803835A0-0x0000000180383670
		remove; // 0x00000001803876A0-0x0000000180387770
	}
	public event Action<string> OnMatchRewardFailed {
		add; // 0x00000001803834D0-0x00000001803835A0
		remove; // 0x00000001803875D0-0x00000001803876A0
	}
	public event Action<PvpProfileDTO> OnPvpProfileResponse {
		add; // 0x0000000180384370-0x0000000180384440
		remove; // 0x0000000180388470-0x0000000180388540
	}
	public event Action<string> OnPvpProfileFailed {
		add; // 0x00000001803842A0-0x0000000180384370
		remove; // 0x00000001803883A0-0x0000000180388470
	}
	public event Action<List<WorldBossDTO>> OnWorldBossListResponse {
		add; // 0x0000000180385870-0x0000000180385940
		remove; // 0x0000000180389970-0x0000000180389A40
	}
	public event Action<string> OnWorldBossListFailed {
		add; // 0x00000001803857A0-0x0000000180385870
		remove; // 0x00000001803898A0-0x0000000180389970
	}
	public event Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse {
		add; // 0x00000001803856D0-0x00000001803857A0
		remove; // 0x00000001803897D0-0x00000001803898A0
	}
	public event Action<string> OnWorldBossDamageSubmitFailed {
		add; // 0x0000000180385600-0x00000001803856D0
		remove; // 0x0000000180389700-0x00000001803897D0
	}
	public event Action<ChatMessageDTO> OnPvpPong {
		add; // 0x00000001803841D0-0x00000001803842A0
		remove; // 0x00000001803882D0-0x00000001803883A0
	}
	public event Action<ChatMessageDTO> OnMatchmakingFound {
		add; // 0x0000000180383C20-0x0000000180383CF0
		remove; // 0x0000000180387D20-0x0000000180387DF0
	}
	public event Action<string> OnMatchmakingFailed {
		add; // 0x0000000180383B50-0x0000000180383C20
		remove; // 0x0000000180387C50-0x0000000180387D20
	}

	// Nested types
	private struct QueuedWsMessage // TypeDefIndex: 455
	{
		// Fields
		public WebSocket Socket; // 0x00
		public string Type; // 0x08
		public string Json; // 0x10
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 456
	{
		// Fields
		public static readonly __c __9; // 0x00

		// Constructors
		static __c(); // 0x0000000180390E40-0x0000000180390EB0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _.cctor_b__367_0(object sender, [Nullable(1)] Newtonsoft.Json.Serialization.ErrorEventArgs args); // 0x000000018038E520-0x000000018038E600
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass263_0 // TypeDefIndex: 457
	{
		// Fields
		public WebSocket wsLocal; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass263_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ConnectWebSocket_b__0(); // 0x000000018038E870-0x000000018038E930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass271_0 // TypeDefIndex: 458
	{
		// Fields
		public WebSocket ws; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass271_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _HeartbeatLoop_b__0(); // 0x000000018038E930-0x000000018038EBB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass275_0 // TypeDefIndex: 459
	{
		// Fields
		public ChatService __4__this; // 0x10
		public string json; // 0x18
		public ChatMessageDTO message; // 0x20

		// Constructors
		public __c__DisplayClass275_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnWebSocketMessage_b__0(); // 0x000000018038EBB0-0x0000000180390E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass285_0 // TypeDefIndex: 460
	{
		// Fields
		public WebSocket ws; // 0x10

		// Constructors
		public __c__DisplayClass285_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CloseSocketInBackground_b__0(); // 0x0000000180390E10-0x0000000180390E40
	}

	[CompilerGenerated]
	private sealed class _AutoReconnectLoop_d__286 : IEnumerator<object> // TypeDefIndex: 461
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoReconnectLoop_d__286(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018038D900-0x000000018038DAF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038DAF0-0x000000018038DB30
	}

	[CompilerGenerated]
	private sealed class _HeartbeatLoop_d__271 : IEnumerator<object> // TypeDefIndex: 462
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20
		private __c__DisplayClass271_0 __8__1; // 0x28
		private float _elapsed_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HeartbeatLoop_d__271(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018038DB30-0x000000018038E060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038E060-0x000000018038E0A0
	}

	// Constructors
	public ChatService(); // 0x0000000180381AC0-0x0000000180381BD0
	static ChatService(); // 0x0000000180381850-0x0000000180381AC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStaticsOnPlay(); // 0x000000018037DEC0-0x000000018037DFF0
	private static bool IsSocketOpen(WebSocket ws); // 0x000000018037BB70-0x000000018037BC10
	public string GetUsername(); // 0x0000000180308AA0-0x0000000180308AB0
	public long GetUserId(); // 0x000000018037B900-0x000000018037B910
	private void Awake(); // 0x000000018037A290-0x000000018037A390
	public void ConnectWebSocket(string name); // 0x000000018037A570-0x000000018037AFD0
	private void OnWebSocketOpen(object sender, EventArgs e); // 0x000000018037CE30-0x000000018037CEE0
	[IteratorStateMachine(typeof(_HeartbeatLoop_d__271))]
	private IEnumerator HeartbeatLoop(); // 0x000000018037B910-0x000000018037B980
	private static bool IsHeavyWsType(string type); // 0x000000018037BA70-0x000000018037BB70
	private void OnWebSocketMessage(object sender, MessageEventArgs e); // 0x000000018037C940-0x000000018037CE30
	private void OnWebSocketError(object sender, WebSocketSharp.ErrorEventArgs e); // 0x000000018037C6C0-0x000000018037C940
	private void OnWebSocketClose(object sender, CloseEventArgs e); // 0x000000018037C4E0-0x000000018037C6C0
	private void OnApplicationFocus(bool hasFocus); // 0x000000018037C0F0-0x000000018037C260
	private static void CloseSocketInBackground(WebSocket ws); // 0x000000018037A490-0x000000018037A570
	[IteratorStateMachine(typeof(_AutoReconnectLoop_d__286))]
	private IEnumerator AutoReconnectLoop(); // 0x000000018037A220-0x000000018037A290
	public void SendMessage(string text); // 0x000000018037FC40-0x000000018037FD40
	public void SendWebSocketMessage(ChatMessageDTO messageObj); // 0x00000001803800D0-0x0000000180380500
	private static void EnqueueSend(WebSocket socket, string type, string json); // 0x000000018037B430-0x000000018037B5C0
	private static void EnsureSenderThread(); // 0x000000018037B5C0-0x000000018037B7F0
	private static void SenderLoop(); // 0x00000001803807C0-0x0000000180380D10
	private static void FlushSendQueue(int timeoutMs); // 0x000000018037B7F0-0x000000018037B900
	public void SendSystemMessage(string text); // 0x000000018037FD40-0x000000018037FE40
	public void SendTeamChat(string text); // 0x000000018037FE40-0x000000018037FF50
	public void ClearTeamHistory(); // 0x000000018037A450-0x000000018037A490
	public void SendGuildChat(string text); // 0x000000018037E190-0x000000018037E2A0
	public void ClearGuildHistory(); // 0x000000018037A390-0x000000018037A3D0
	public bool SendImage(string channelType, string imageId, int w, int h); // 0x000000018037E2A0-0x000000018037E4A0
	public bool SendTeamEmote(string emojiId); // 0x000000018037FF50-0x00000001803800D0
	public bool SendWorldEmote(string emojiId); // 0x0000000180380640-0x00000001803807C0
	public bool SendChatReact(long msgId, string emojiId, string scope); // 0x000000018037DFF0-0x000000018037E190
	private List<ChatMessageDTO> HistoryForReactScope(string scope); // 0x000000018037B980-0x000000018037BA70
	private void ApplyChatReactUpdate(ChatMessageDTO m); // 0x0000000180379FA0-0x000000018037A220
	public void SendInvite(string targetUsername, string slotInfo); // 0x000000018037E4A0-0x000000018037E5D0
	public void SetBusyStatus(bool busy); // 0x0000000180380D10-0x0000000180380E10
	public void RequestOnlineList(); // 0x000000018037D500-0x000000018037D5D0
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x000000018037AFD0-0x000000018037B150
	public void JoinRoom(string roomId); // 0x000000018037BC10-0x000000018037BD10
	public void RequestHubBootstrap(); // 0x000000018037CEE0-0x000000018037CFF0
	public void RequestPetsPaginated(int page, int size); // 0x000000018037D6E0-0x000000018037D860
	public void SendMatchEnergyUse(); // 0x000000018037EBB0-0x000000018037ECC0
	private static void NoticeQuitPenalty(ChatMessageDTO m); // 0x000000018037BEE0-0x000000018037C0F0
	public void SendMatchLeave(); // 0x000000018037EEE0-0x000000018037F030
	public void SendMatchResultReq(string matchId); // 0x000000018037F450-0x000000018037F550
	public void RequestOnlineUsersWithInfo(); // 0x000000018037D5D0-0x000000018037D6E0
	public void RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode); // 0x000000018037CFF0-0x000000018037D190
	public void RequestWorldBossList(); // 0x000000018037DDB0-0x000000018037DEC0
	public void SendWorldBossDamageCheckpoint(long bossScheduleId, int delta); // 0x0000000180380500-0x0000000180380640
	public void RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount); // 0x000000018037DBD0-0x000000018037DDB0
	public void RequestPvpProfile(long? targetUserId); // 0x000000018037D860-0x000000018037D990
	public void RequestMatchReward(long petId, bool victory, long t, string s); // 0x000000018037D330-0x000000018037D500
	public void RequestRoomBootstrap(long petId, string mode); // 0x000000018037D990-0x000000018037DB00
	public void KickMember(string targetUsername); // 0x000000018037BD10-0x000000018037BE10
	public void LeaveRoom(); // 0x000000018037BE10-0x000000018037BEE0
	public void SendMatchmakingJoin(int petId); // 0x000000018037FAF0-0x000000018037FC40
	public void SendMatchmakingCancel(); // 0x000000018037FA20-0x000000018037FAF0
	public void SetRoomReady(bool ready); // 0x0000000180380E10-0x0000000180380F10
	public void StartMatch(); // 0x0000000180380F10-0x0000000180380FE0
	public void UpdateRoomProperties(Dictionary<string, object> properties); // 0x0000000180381740-0x0000000180381850
	public void UpdatePlayerProps(WsPlayerStateDTO diff); // 0x0000000180381640-0x0000000180381740
	public void RequestRoomList(); // 0x000000018037DB00-0x000000018037DBD0
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x0000000180380FE0-0x00000001803810D0
	public void UnsubscribeRoomList(); // 0x0000000180381570-0x0000000180381640
	public void RequestMatchResync(string matchId, string reason = null); // 0x000000018037D190-0x000000018037D330
	public void SendMatchClientReady(string matchId); // 0x000000018037E840-0x000000018037E9D0
	public void SendMatchAnimDone(string matchId, long ackToken); // 0x000000018037E5D0-0x000000018037E710
	public void SendMatchSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x000000018037F820-0x000000018037FA20
	public void SendMatchQteStart(string matchId, int skillCardId); // 0x000000018037F320-0x000000018037F450
	public void SendMatchSkillHint(string matchId, Dictionary<string, object> payload); // 0x000000018037F700-0x000000018037F820
	public void SendMatchQteEvent(string matchId, Dictionary<string, object> payload); // 0x000000018037F200-0x000000018037F320
	public void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x000000018037F030-0x000000018037F200
	public void SendMatchCardUse(string matchId, int cardId, int? cardTarget = default); // 0x000000018037E710-0x000000018037E840
	public void SendMatchFusionList(string matchId); // 0x000000018037ECC0-0x000000018037EDB0
	public void SendMatchFusionUse(string matchId, long fusionUserPetId); // 0x000000018037EDB0-0x000000018037EEE0
	public void SendMatchDragPause(string matchId); // 0x000000018037E9D0-0x000000018037EAC0
	public void SendMatchDragResume(string matchId); // 0x000000018037EAC0-0x000000018037EBB0
	public void SendMatchShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x000000018037F550-0x000000018037F700
	public void Disconnect(); // 0x000000018037B150-0x000000018037B430
	public void ClearHistory(); // 0x000000018037A3D0-0x000000018037A450
	private void OnDestroy(); // 0x000000018037C4D0-0x000000018037C4E0
	private void OnApplicationQuit(); // 0x000000018037C260-0x000000018037C4D0
	[CompilerGenerated]
	private void _OnWebSocketOpen_b__264_0(); // 0x0000000180381300-0x0000000180381570
	[CompilerGenerated]
	private void _OnWebSocketError_b__276_0(); // 0x0000000180381260-0x0000000180381300
	[CompilerGenerated]
	private void _OnWebSocketClose_b__277_0(); // 0x00000001803810D0-0x0000000180381260
}

