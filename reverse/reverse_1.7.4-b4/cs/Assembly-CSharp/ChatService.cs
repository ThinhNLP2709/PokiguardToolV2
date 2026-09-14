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
using UnityEngine.Networking;
using WebSocketSharp;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ChatService : MonoBehaviour // TypeDefIndex: 508
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
	private const int PING_FAIL_STREAK_TO_DIE = 2; // Metadata: 0x005EF55B
	private int _pingFailStreak; // 0x2D0
	private bool _explicitDisconnect; // 0x2D4
	private Coroutine _reconnectCoroutine; // 0x2D8
	private int _reconnectAttempt; // 0x2E0
	private bool _connecting; // 0x2E4
	private float _connectStartedAt; // 0x2E8
	private const float CONNECT_GUARD_SEC = 20f; // Metadata: 0x005EF55C
	private const int RECONNECT_FAILS_BEFORE_AUTH_PROBE = 3; // Metadata: 0x005EF560
	private bool _authProbeRunning; // 0x2EC
	private const int SEND_QUEUE_CAPACITY = 512; // Metadata: 0x005EF561
	private static readonly BlockingCollection<QueuedWsMessage> _sendQueue; // 0x30
	private static Thread _senderThread; // 0x38
	private static readonly object _senderLock; // 0x40
	private float _lastEmoteAt; // 0x2F0
	private float _historyReplayUntil; // 0x2F4
	public const string REACT_FLAG_KEY = "chat.react"; // Metadata: 0x005EF563
	private const float ChatReactCooldown = 0.5f; // Metadata: 0x005EF56E
	private float _lastChatReactAt; // 0x2F8

	// Properties
	public static ChatService Instance { get; } // 0x000000018039E020-0x000000018039E370 
	public IReadOnlyList<ChatMessageDTO> TeamMessageHistory { get; } // 0x00000001802D8BB0-0x00000001802D8BC0 
	public IReadOnlyList<ChatMessageDTO> GuildMessageHistory { get; } // 0x000000018039E8F0-0x000000018039E900 
	public bool IsConnected { get; } // 0x00000001802B4AD0-0x00000001802B4AE0 
	public string Username { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	public IReadOnlyList<ChatMessageDTO> MessageHistory { get; } // 0x00000001802BA5D0-0x00000001802BA5E0 
	public int LastRttMs { get; } // 0x00000001803AA5B0-0x00000001803AA5C0 
	public bool InHistoryReplayWindow { get; } // 0x00000001803AD1D0-0x00000001803AD230 
	public static bool ReactEnabled { get; } // 0x00000001803ADB80-0x00000001803ADBF0 

	// Events
	public event Action<ChatMessageDTO> OnTeamMessage {
		add; // 0x000000018039E470-0x000000018039E590
		remove; // 0x000000018039E590-0x000000018039E6B0
	}
	public event Action<ChatMessageDTO> OnTeamEmote {
		add; // 0x000000018039E6B0-0x000000018039E7D0
		remove; // 0x000000018039E7D0-0x000000018039E8F0
	}
	public event Action<ChatMessageDTO> OnGuildMessage {
		add; // 0x000000018039E900-0x000000018039EA20
		remove; // 0x000000018039EA20-0x000000018039EB40
	}
	public event Action<ChatMessageDTO> OnGuildPush {
		add; // 0x000000018039EB40-0x000000018039EC60
		remove; // 0x000000018039EC60-0x000000018039ED80
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x000000018039ED80-0x000000018039EEA0
		remove; // 0x000000018039EEA0-0x000000018039EFC0
	}
	public event Action<ChatMessageDTO> OnChatReact {
		add; // 0x000000018039EFC0-0x000000018039F0E0
		remove; // 0x000000018039F0E0-0x000000018039F200
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x000000018039F200-0x000000018039F320
		remove; // 0x000000018039F320-0x000000018039F440
	}
	public event Action<ChatMessageDTO> OnMessageReceived {
		add; // 0x000000018039F440-0x000000018039F560
		remove; // 0x000000018039F560-0x000000018039F680
	}
	public event Action<bool> OnConnectionChanged {
		add; // 0x000000018039F680-0x000000018039F7A0
		remove; // 0x000000018039F7A0-0x000000018039F8C0
	}
	public event Action<int> OnReconnecting {
		add; // 0x000000018039F8C0-0x000000018039F9E0
		remove; // 0x000000018039F9E0-0x000000018039FB00
	}
	public event Action<string, Color> OnStatusChanged {
		add; // 0x000000018039FB00-0x000000018039FC20
		remove; // 0x000000018039FC20-0x000000018039FD40
	}
	public event Action<string, string> OnInviteReceived {
		add; // 0x000000018039FD40-0x000000018039FE60
		remove; // 0x000000018039FE60-0x000000018039FF80
	}
	public event Action<string, string> OnInviteFailed {
		add; // 0x000000018039FF80-0x00000001803A00A0
		remove; // 0x00000001803A00A0-0x00000001803A01C0
	}
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x00000001803A01C0-0x00000001803A02E0
		remove; // 0x00000001803A02E0-0x00000001803A0400
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001803A0400-0x00000001803A0520
		remove; // 0x00000001803A0520-0x00000001803A0640
	}
	public event Action<ChatMessageDTO> OnRoomCreated {
		add; // 0x00000001803A0640-0x00000001803A0760
		remove; // 0x00000001803A0760-0x00000001803A0880
	}
	public event Action<string> OnRoomCreateFailed {
		add; // 0x00000001803A0880-0x00000001803A09A0
		remove; // 0x00000001803A09A0-0x00000001803A0AC0
	}
	public event Action<ChatMessageDTO> OnRoomJoined {
		add; // 0x00000001803A0AC0-0x00000001803A0BE0
		remove; // 0x00000001803A0BE0-0x00000001803A0D00
	}
	public event Action<string> OnRoomJoinFailed {
		add; // 0x00000001803A0D00-0x00000001803A0E20
		remove; // 0x00000001803A0E20-0x00000001803A0F40
	}
	public event Action<ChatMessageDTO> OnRoomMemberUpdate {
		add; // 0x00000001803A0F40-0x00000001803A1060
		remove; // 0x00000001803A1060-0x00000001803A1180
	}
	public event Action<ChatMessageDTO> OnRoomReadyUpdate {
		add; // 0x00000001803A1180-0x00000001803A12A0
		remove; // 0x00000001803A12A0-0x00000001803A13C0
	}
	public event Action<ChatMessageDTO> OnRoomMatchStarting {
		add; // 0x00000001803A13C0-0x00000001803A14E0
		remove; // 0x00000001803A14E0-0x00000001803A1600
	}
	public event Action<ChatMessageDTO> OnRoomStartMatchFailed {
		add; // 0x00000001803A1600-0x00000001803A1720
		remove; // 0x00000001803A1720-0x00000001803A1840
	}
	public event Action<ChatMessageDTO> OnRoomPropsUpdate {
		add; // 0x00000001803A1840-0x00000001803A1960
		remove; // 0x00000001803A1960-0x00000001803A1A80
	}
	public event Action<ChatMessageDTO> OnRoomPlayerPropsUpdate {
		add; // 0x00000001803A1A80-0x00000001803A1BA0
		remove; // 0x00000001803A1BA0-0x00000001803A1CC0
	}
	public event Action<ChatMessageDTO> OnRoomKicked {
		add; // 0x00000001803A1CC0-0x00000001803A1DE0
		remove; // 0x00000001803A1DE0-0x00000001803A1F00
	}
	public event Action<string> OnRoomKickFailed {
		add; // 0x00000001803A1F00-0x00000001803A2020
		remove; // 0x00000001803A2020-0x00000001803A2140
	}
	public event Action<RoomBootstrapData> OnRoomBootstrapResponse {
		add; // 0x00000001803A2140-0x00000001803A2260
		remove; // 0x00000001803A2260-0x00000001803A2380
	}
	public event Action<string> OnRoomBootstrapFailed {
		add; // 0x00000001803A2380-0x00000001803A24A0
		remove; // 0x00000001803A24A0-0x00000001803A25C0
	}
	public event Action<ChatMessageDTO> OnUserEnergyDelta {
		add; // 0x00000001803A25C0-0x00000001803A26E0
		remove; // 0x00000001803A26E0-0x00000001803A2800
	}
	public event Action<ChatMessageDTO> OnGiftPush {
		add; // 0x00000001803A2800-0x00000001803A2920
		remove; // 0x00000001803A2920-0x00000001803A2A40
	}
	public event Action<ChatMessageDTO> OnNoticePush {
		add; // 0x00000001803A2A40-0x00000001803A2B60
		remove; // 0x00000001803A2B60-0x00000001803A2C80
	}
	public event Action<ChatMessageDTO> OnFriendPush {
		add; // 0x00000001803A2C80-0x00000001803A2DA0
		remove; // 0x00000001803A2DA0-0x00000001803A2EC0
	}
	public event Action<ChatMessageDTO> OnFriendMsg {
		add; // 0x00000001803A2EC0-0x00000001803A2FE0
		remove; // 0x00000001803A2FE0-0x00000001803A3100
	}
	public event Action<ChatMessageDTO> OnFriendOnline {
		add; // 0x00000001803A3100-0x00000001803A3220
		remove; // 0x00000001803A3220-0x00000001803A3340
	}
	public event Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse {
		add; // 0x00000001803A3340-0x00000001803A3460
		remove; // 0x00000001803A3460-0x00000001803A3580
	}
	public event Action<RoomSummaryDTO[]> OnRoomListReceived {
		add; // 0x00000001803A3580-0x00000001803A36A0
		remove; // 0x00000001803A36A0-0x00000001803A37C0
	}
	public event Action<RoomSummaryDTO[]> OnRoomListSnapshot {
		add; // 0x00000001803A37C0-0x00000001803A38E0
		remove; // 0x00000001803A38E0-0x00000001803A3A00
	}
	public event Action<string, RoomSummaryDTO> OnRoomListDelta {
		add; // 0x00000001803A3A00-0x00000001803A3B20
		remove; // 0x00000001803A3B20-0x00000001803A3C40
	}
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803A3C40-0x00000001803A3D60
		remove; // 0x00000001803A3D60-0x00000001803A3E80
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x00000001803A3E80-0x00000001803A3FA0
		remove; // 0x00000001803A3FA0-0x00000001803A40C0
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x00000001803A40C0-0x00000001803A41E0
		remove; // 0x00000001803A41E0-0x00000001803A4300
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x00000001803A4300-0x00000001803A4420
		remove; // 0x00000001803A4420-0x00000001803A4540
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x00000001803A4540-0x00000001803A4660
		remove; // 0x00000001803A4660-0x00000001803A4780
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x00000001803A4780-0x00000001803A48A0
		remove; // 0x00000001803A48A0-0x00000001803A49C0
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x00000001803A49C0-0x00000001803A4AE0
		remove; // 0x00000001803A4AE0-0x00000001803A4C00
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x00000001803A4C00-0x00000001803A4D20
		remove; // 0x00000001803A4D20-0x00000001803A4E40
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x00000001803A4E40-0x00000001803A4F60
		remove; // 0x00000001803A4F60-0x00000001803A5080
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x00000001803A5080-0x00000001803A51A0
		remove; // 0x00000001803A51A0-0x00000001803A52C0
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x00000001803A52C0-0x00000001803A53E0
		remove; // 0x00000001803A53E0-0x00000001803A5500
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x00000001803A5500-0x00000001803A5620
		remove; // 0x00000001803A5620-0x00000001803A5740
	}
	public event Action<ChatMessageDTO> OnMatchSkillHint {
		add; // 0x00000001803A5740-0x00000001803A5860
		remove; // 0x00000001803A5860-0x00000001803A5980
	}
	public event Action<ChatMessageDTO> OnMatchQteEvent {
		add; // 0x00000001803A5980-0x00000001803A5AA0
		remove; // 0x00000001803A5AA0-0x00000001803A5BC0
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x00000001803A5BC0-0x00000001803A5CE0
		remove; // 0x00000001803A5CE0-0x00000001803A5E00
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x00000001803A5E00-0x00000001803A5F20
		remove; // 0x00000001803A5F20-0x00000001803A6040
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x00000001803A6040-0x00000001803A6160
		remove; // 0x00000001803A6160-0x00000001803A6280
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x00000001803A6280-0x00000001803A63A0
		remove; // 0x00000001803A63A0-0x00000001803A64C0
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x00000001803A64C0-0x00000001803A65E0
		remove; // 0x00000001803A65E0-0x00000001803A6700
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x00000001803A6700-0x00000001803A6820
		remove; // 0x00000001803A6820-0x00000001803A6940
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x00000001803A6940-0x00000001803A6A60
		remove; // 0x00000001803A6A60-0x00000001803A6B80
	}
	public event Action<ChatMessageDTO> OnWsConfig {
		add; // 0x00000001803A6B80-0x00000001803A6CA0
		remove; // 0x00000001803A6CA0-0x00000001803A6DC0
	}
	public event Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse {
		add; // 0x00000001803A6DC0-0x00000001803A6EE0
		remove; // 0x00000001803A6EE0-0x00000001803A7000
	}
	public event Action<HubBootstrapData> OnHubBootstrapResponse {
		add; // 0x00000001803A7000-0x00000001803A7120
		remove; // 0x00000001803A7120-0x00000001803A7240
	}
	public event Action<string> OnHubBootstrapFailed {
		add; // 0x00000001803A7240-0x00000001803A7360
		remove; // 0x00000001803A7360-0x00000001803A7480
	}
	public event Action<MatchPrepDataDTO> OnMatchPrepResponse {
		add; // 0x00000001803A7480-0x00000001803A75A0
		remove; // 0x00000001803A75A0-0x00000001803A76C0
	}
	public event Action<string> OnMatchPrepFailed {
		add; // 0x00000001803A76C0-0x00000001803A77E0
		remove; // 0x00000001803A77E0-0x00000001803A7900
	}
	public event Action<PetRewardDataDTO> OnMatchRewardResponse {
		add; // 0x00000001803A7900-0x00000001803A7A20
		remove; // 0x00000001803A7A20-0x00000001803A7B40
	}
	public event Action<string> OnMatchRewardFailed {
		add; // 0x00000001803A7B40-0x00000001803A7C60
		remove; // 0x00000001803A7C60-0x00000001803A7D80
	}
	public event Action<PvpProfileDTO> OnPvpProfileResponse {
		add; // 0x00000001803A7D80-0x00000001803A7EA0
		remove; // 0x00000001803A7EA0-0x00000001803A7FC0
	}
	public event Action<string> OnPvpProfileFailed {
		add; // 0x00000001803A7FC0-0x00000001803A80E0
		remove; // 0x00000001803A80E0-0x00000001803A8200
	}
	public event Action<List<WorldBossDTO>> OnWorldBossListResponse {
		add; // 0x00000001803A8200-0x00000001803A8320
		remove; // 0x00000001803A8320-0x00000001803A8440
	}
	public event Action<string> OnWorldBossListFailed {
		add; // 0x00000001803A8440-0x00000001803A8560
		remove; // 0x00000001803A8560-0x00000001803A8680
	}
	public event Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse {
		add; // 0x00000001803A8680-0x00000001803A87A0
		remove; // 0x00000001803A87A0-0x00000001803A88C0
	}
	public event Action<string> OnWorldBossDamageSubmitFailed {
		add; // 0x00000001803A88C0-0x00000001803A89E0
		remove; // 0x00000001803A89E0-0x00000001803A8B00
	}
	public event Action<ChatMessageDTO> OnPvpPong {
		add; // 0x00000001803A8B00-0x00000001803A8C20
		remove; // 0x00000001803A8C20-0x00000001803A8D40
	}
	public event Action<ChatMessageDTO> OnMatchmakingFound {
		add; // 0x00000001803A8D40-0x00000001803A8E60
		remove; // 0x00000001803A8E60-0x00000001803A8F80
	}
	public event Action<string> OnMatchmakingFailed {
		add; // 0x00000001803A8F80-0x00000001803A90A0
		remove; // 0x00000001803A90A0-0x00000001803A91C0
	}

	// Nested types
	private struct QueuedWsMessage // TypeDefIndex: 509
	{
		// Fields
		public WebSocket Socket; // 0x00
		public string Type; // 0x08
		public string Json; // 0x10
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 510
	{
		// Fields
		public static readonly __c __9; // 0x00

		// Constructors
		static __c(); // 0x00000001803B50E0-0x00000001803B5180
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _.cctor_b__371_0(object sender, [Nullable(1)] Newtonsoft.Json.Serialization.ErrorEventArgs args); // 0x00000001803B5180-0x00000001803B5270
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass263_0 // TypeDefIndex: 511
	{
		// Fields
		public WebSocket wsLocal; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass263_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ConnectWebSocket_b__0(); // 0x00000001803B5270-0x00000001803B54A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass271_0 // TypeDefIndex: 512
	{
		// Fields
		public WebSocket ws; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass271_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HeartbeatLoop_b__0(); // 0x00000001803B54A0-0x00000001803B5770
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass275_0 // TypeDefIndex: 513
	{
		// Fields
		public ChatService __4__this; // 0x10
		public string json; // 0x18
		public ChatMessageDTO message; // 0x20

		// Constructors
		public __c__DisplayClass275_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnWebSocketMessage_b__0(); // 0x00000001803B5770-0x00000001803B8080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass285_0 // TypeDefIndex: 514
	{
		// Fields
		public WebSocket ws; // 0x10

		// Constructors
		public __c__DisplayClass285_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseSocketInBackground_b__0(); // 0x00000001803B8080-0x00000001803B80C0
	}

	[CompilerGenerated]
	private sealed class _AutoReconnectLoop_d__288 : IEnumerator<object> // TypeDefIndex: 515
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoReconnectLoop_d__288(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803B80C0-0x00000001803B84A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803B84A0-0x00000001803B84E0
	}

	[CompilerGenerated]
	private sealed class _HeartbeatLoop_d__271 : IEnumerator<object> // TypeDefIndex: 516
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20
		private __c__DisplayClass271_0 __8__1; // 0x28
		private float _elapsed_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HeartbeatLoop_d__271(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001803B84E0-0x00000001803B8A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803B8A00-0x00000001803B8A40
	}

	[CompilerGenerated]
	private sealed class _ProbeAuthStillValid_d__289 : IEnumerator<object> // TypeDefIndex: 517
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20
		private UnityWebRequest _req_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ProbeAuthStillValid_d__289(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803B8A40-0x00000001803B8B70
		private bool MoveNext(); // 0x00000001803B8B70-0x00000001803B91F0
		private void __m__Finally1(); // 0x00000001803B91F0-0x00000001803B9250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803B9250-0x00000001803B9290
	}

	// Constructors
	public ChatService(); // 0x00000001803B4160-0x00000001803B4370
	static ChatService(); // 0x00000001803B4370-0x00000001803B4890

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStaticsOnPlay(); // 0x000000018039DDE0-0x000000018039E020
	private static bool IsSocketOpen(WebSocket ws); // 0x000000018039E370-0x000000018039E460
	public string GetUsername(); // 0x00000001802B4AE0-0x00000001802B4AF0
	public long GetUserId(); // 0x000000018039E460-0x000000018039E470
	private void Awake(); // 0x00000001803A91C0-0x00000001803A9470
	public void ConnectWebSocket(string name); // 0x00000001803A9470-0x00000001803AA4A0
	private void OnWebSocketOpen(object sender, EventArgs e); // 0x00000001803AA4A0-0x00000001803AA5B0
	[IteratorStateMachine(typeof(_HeartbeatLoop_d__271))]
	private IEnumerator HeartbeatLoop(); // 0x00000001803AA5C0-0x00000001803AA660
	private static bool IsHeavyWsType(string type); // 0x00000001803AA660-0x00000001803AA880
	private void OnWebSocketMessage(object sender, MessageEventArgs e); // 0x00000001803AA880-0x00000001803AAE90
	private void OnWebSocketError(object sender, WebSocketSharp.ErrorEventArgs e); // 0x00000001803AAE90-0x00000001803AB160
	private void OnWebSocketClose(object sender, CloseEventArgs e); // 0x00000001803AB160-0x00000001803AB4F0
	private void OnApplicationFocus(bool hasFocus); // 0x00000001803AB4F0-0x00000001803AB670
	private static void CloseSocketInBackground(WebSocket ws); // 0x00000001803AB670-0x00000001803AB7A0
	[IteratorStateMachine(typeof(_AutoReconnectLoop_d__288))]
	private IEnumerator AutoReconnectLoop(); // 0x00000001803AB7A0-0x00000001803AB840
	[IteratorStateMachine(typeof(_ProbeAuthStillValid_d__289))]
	private IEnumerator ProbeAuthStillValid(); // 0x00000001803AB840-0x00000001803AB8E0
	public void SendMessage(string text); // 0x00000001803AB8E0-0x00000001803ABAB0
	public void SendWebSocketMessage(ChatMessageDTO messageObj); // 0x00000001803ABAB0-0x00000001803ABE60
	private static void EnqueueSend(WebSocket socket, string type, string json); // 0x00000001803ABE60-0x00000001803AC120
	private static void EnsureSenderThread(); // 0x00000001803AC120-0x00000001803AC5D0
	private static void SenderLoop(); // 0x00000001803AC5D0-0x00000001803ACBC0
	private static void FlushSendQueue(int timeoutMs); // 0x00000001803ACBC0-0x00000001803ACE70
	public void SendSystemMessage(string text); // 0x00000001803ACE70-0x00000001803AD040
	public void SendTeamChat(string text); // 0x00000001803AD040-0x00000001803AD1D0
	public void ClearTeamHistory(); // 0x00000001803AD230-0x00000001803AD270
	public void SendGuildChat(string text); // 0x00000001803AD270-0x00000001803AD400
	public void ClearGuildHistory(); // 0x00000001803AD400-0x00000001803AD440
	public bool SendImage(string channelType, string imageId, int w, int h); // 0x00000001803AD440-0x00000001803AD7A0
	public bool SendTeamEmote(string emojiId); // 0x00000001803AD7A0-0x00000001803AD990
	public bool SendWorldEmote(string emojiId); // 0x00000001803AD990-0x00000001803ADB80
	public bool SendChatReact(long msgId, string emojiId, string scope); // 0x00000001803ADBF0-0x00000001803ADD80
	private List<ChatMessageDTO> HistoryForReactScope(string scope); // 0x00000001803ADD80-0x00000001803ADFC0
	private void ApplyChatReactUpdate(ChatMessageDTO m); // 0x00000001803ADFC0-0x00000001803AE340
	public void SendInvite(string targetUsername, string slotInfo); // 0x00000001803AE340-0x00000001803AE450
	public void SetBusyStatus(bool busy); // 0x00000001803AE450-0x00000001803AE5D0
	public void RequestOnlineList(); // 0x00000001803AE5D0-0x00000001803AE730
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x00000001803AE730-0x00000001803AE9C0
	public void JoinRoom(string roomId); // 0x00000001803AE9C0-0x00000001803AEB90
	public void RequestHubBootstrap(); // 0x00000001803AEB90-0x00000001803AED40
	public void RequestPetsPaginated(int page, int size); // 0x00000001803AED40-0x00000001803AEF40
	public void SendMatchEnergyUse(); // 0x00000001803AEF40-0x00000001803AF0F0
	private static void NoticeQuitPenalty(ChatMessageDTO m); // 0x00000001803AF0F0-0x00000001803AF3C0
	public void SendMatchLeave(); // 0x00000001803AF3C0-0x00000001803AF6E0
	public void SendMatchResultReq(string matchId); // 0x00000001803AF6E0-0x00000001803AF8B0
	public void RequestOnlineUsersWithInfo(); // 0x00000001803AF8B0-0x00000001803AFA60
	public void RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode); // 0x00000001803AFA60-0x00000001803AFCD0
	public void RequestWorldBossList(); // 0x00000001803AFCD0-0x00000001803AFE80
	public void SendWorldBossDamageCheckpoint(long bossScheduleId, int delta); // 0x00000001803AFE80-0x00000001803B0040
	public void RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount); // 0x00000001803B0040-0x00000001803B0280
	public void RequestPvpProfile(long? targetUserId); // 0x00000001803B0280-0x00000001803B0440
	public void RequestMatchReward(long petId, bool victory, long t, string s); // 0x00000001803B0440-0x00000001803B06C0
	public void RequestRoomBootstrap(long petId, string mode); // 0x00000001803B06C0-0x00000001803B08F0
	public void KickMember(string targetUsername); // 0x00000001803B08F0-0x00000001803B0AC0
	public void LeaveRoom(string roomId = null); // 0x00000001803B0AC0-0x00000001803B0C80
	public void SendMatchmakingJoin(int petId); // 0x00000001803B0C80-0x00000001803B0E60
	public void SendMatchmakingCancel(); // 0x00000001803B0E60-0x00000001803B0FC0
	public void SetRoomReady(bool ready); // 0x00000001803B0FC0-0x00000001803B1140
	public void StartMatch(); // 0x00000001803B1140-0x00000001803B12A0
	public void UpdateRoomProperties(Dictionary<string, object> properties); // 0x00000001803B12A0-0x00000001803B1380
	public void UpdatePlayerProps(WsPlayerStateDTO diff); // 0x00000001803B1380-0x00000001803B1540
	public void RequestRoomList(); // 0x00000001803B1540-0x00000001803B16A0
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x00000001803B16A0-0x00000001803B1860
	public void UnsubscribeRoomList(); // 0x00000001803B1860-0x00000001803B19C0
	public void RequestMatchResync(string matchId, string reason = null); // 0x00000001803B19C0-0x00000001803B1C90
	public void SendMatchClientReady(string matchId); // 0x00000001803B1C90-0x00000001803B1F80
	public void SendMatchAnimDone(string matchId, long ackToken); // 0x00000001803B1F80-0x00000001803B21A0
	public void SendMatchSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x00000001803B21A0-0x00000001803B2570
	public void SendMatchQteStart(string matchId, int skillCardId, Dictionary<string, object> payload = null); // 0x00000001803B2570-0x00000001803B27C0
	public void SendMatchQteTap(string matchId, int elapsedMs, long challengeId); // 0x00000001803B27C0-0x00000001803B29E0
	public void SendMatchSkillHint(string matchId, Dictionary<string, object> payload); // 0x00000001803B29E0-0x00000001803B2C00
	public void SendMatchQteEvent(string matchId, Dictionary<string, object> payload); // 0x00000001803B2C00-0x00000001803B2E20
	public void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x00000001803B2E20-0x00000001803B30A0
	public void SendMatchCardUse(string matchId, int cardId, int? cardTarget = default); // 0x00000001803B30A0-0x00000001803B32A0
	public void SendMatchFusionList(string matchId); // 0x00000001803B32A0-0x00000001803B3460
	public void SendMatchFusionUse(string matchId, long fusionUserPetId); // 0x00000001803B3460-0x00000001803B3640
	public void SendMatchDragPause(string matchId); // 0x00000001803B3640-0x00000001803B3800
	public void SendMatchDragResume(string matchId); // 0x00000001803B3800-0x00000001803B39C0
	public void SendMatchShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x00000001803B39C0-0x00000001803B3C20
	public void Disconnect(); // 0x00000001803B3C20-0x00000001803B3EF0
	public void ClearHistory(); // 0x00000001803B3EF0-0x00000001803B3F70
	private void OnDestroy(); // 0x00000001803B3F70-0x00000001803B3F80
	private void OnApplicationQuit(); // 0x00000001803B3F80-0x00000001803B4160
	[CompilerGenerated]
	private void _OnWebSocketOpen_b__264_0(); // 0x00000001803B4890-0x00000001803B4D10
	[CompilerGenerated]
	private void _OnWebSocketError_b__276_0(); // 0x00000001803B4D10-0x00000001803B4E30
	[CompilerGenerated]
	private void _OnWebSocketClose_b__277_0(); // 0x00000001803B4E30-0x00000001803B50E0
}

