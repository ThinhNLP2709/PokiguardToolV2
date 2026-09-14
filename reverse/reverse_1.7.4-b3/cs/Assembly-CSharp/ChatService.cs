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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	private const int PING_FAIL_STREAK_TO_DIE = 2; // Metadata: 0x005EE18B
	private int _pingFailStreak; // 0x2D0
	private bool _explicitDisconnect; // 0x2D4
	private Coroutine _reconnectCoroutine; // 0x2D8
	private int _reconnectAttempt; // 0x2E0
	private bool _connecting; // 0x2E4
	private float _connectStartedAt; // 0x2E8
	private const float CONNECT_GUARD_SEC = 20f; // Metadata: 0x005EE18C
	private const int SEND_QUEUE_CAPACITY = 512; // Metadata: 0x005EE190
	private static readonly BlockingCollection<QueuedWsMessage> _sendQueue; // 0x30
	private static Thread _senderThread; // 0x38
	private static readonly object _senderLock; // 0x40
	private float _lastEmoteAt; // 0x2EC
	private float _historyReplayUntil; // 0x2F0
	public const string REACT_FLAG_KEY = "chat.react"; // Metadata: 0x005EE192
	private const float ChatReactCooldown = 0.5f; // Metadata: 0x005EE19D
	private float _lastChatReactAt; // 0x2F4

	// Properties
	public static ChatService Instance { get; } // 0x000000018039DE50-0x000000018039E1A0 
	public IReadOnlyList<ChatMessageDTO> TeamMessageHistory { get; } // 0x00000001802D8B80-0x00000001802D8B90 
	public IReadOnlyList<ChatMessageDTO> GuildMessageHistory { get; } // 0x000000018039E720-0x000000018039E730 
	public bool IsConnected { get; } // 0x00000001802B4AD0-0x00000001802B4AE0 
	public string Username { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	public IReadOnlyList<ChatMessageDTO> MessageHistory { get; } // 0x00000001802BA5A0-0x00000001802BA5B0 
	public int LastRttMs { get; } // 0x00000001803AA3E0-0x00000001803AA3F0 
	public bool InHistoryReplayWindow { get; } // 0x00000001803ACF60-0x00000001803ACFC0 
	public static bool ReactEnabled { get; } // 0x00000001803AD910-0x00000001803AD980 

	// Events
	public event Action<ChatMessageDTO> OnTeamMessage {
		add; // 0x000000018039E2A0-0x000000018039E3C0
		remove; // 0x000000018039E3C0-0x000000018039E4E0
	}
	public event Action<ChatMessageDTO> OnTeamEmote {
		add; // 0x000000018039E4E0-0x000000018039E600
		remove; // 0x000000018039E600-0x000000018039E720
	}
	public event Action<ChatMessageDTO> OnGuildMessage {
		add; // 0x000000018039E730-0x000000018039E850
		remove; // 0x000000018039E850-0x000000018039E970
	}
	public event Action<ChatMessageDTO> OnGuildPush {
		add; // 0x000000018039E970-0x000000018039EA90
		remove; // 0x000000018039EA90-0x000000018039EBB0
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x000000018039EBB0-0x000000018039ECD0
		remove; // 0x000000018039ECD0-0x000000018039EDF0
	}
	public event Action<ChatMessageDTO> OnChatReact {
		add; // 0x000000018039EDF0-0x000000018039EF10
		remove; // 0x000000018039EF10-0x000000018039F030
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x000000018039F030-0x000000018039F150
		remove; // 0x000000018039F150-0x000000018039F270
	}
	public event Action<ChatMessageDTO> OnMessageReceived {
		add; // 0x000000018039F270-0x000000018039F390
		remove; // 0x000000018039F390-0x000000018039F4B0
	}
	public event Action<bool> OnConnectionChanged {
		add; // 0x000000018039F4B0-0x000000018039F5D0
		remove; // 0x000000018039F5D0-0x000000018039F6F0
	}
	public event Action<int> OnReconnecting {
		add; // 0x000000018039F6F0-0x000000018039F810
		remove; // 0x000000018039F810-0x000000018039F930
	}
	public event Action<string, Color> OnStatusChanged {
		add; // 0x000000018039F930-0x000000018039FA50
		remove; // 0x000000018039FA50-0x000000018039FB70
	}
	public event Action<string, string> OnInviteReceived {
		add; // 0x000000018039FB70-0x000000018039FC90
		remove; // 0x000000018039FC90-0x000000018039FDB0
	}
	public event Action<string, string> OnInviteFailed {
		add; // 0x000000018039FDB0-0x000000018039FED0
		remove; // 0x000000018039FED0-0x000000018039FFF0
	}
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x000000018039FFF0-0x00000001803A0110
		remove; // 0x00000001803A0110-0x00000001803A0230
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001803A0230-0x00000001803A0350
		remove; // 0x00000001803A0350-0x00000001803A0470
	}
	public event Action<ChatMessageDTO> OnRoomCreated {
		add; // 0x00000001803A0470-0x00000001803A0590
		remove; // 0x00000001803A0590-0x00000001803A06B0
	}
	public event Action<string> OnRoomCreateFailed {
		add; // 0x00000001803A06B0-0x00000001803A07D0
		remove; // 0x00000001803A07D0-0x00000001803A08F0
	}
	public event Action<ChatMessageDTO> OnRoomJoined {
		add; // 0x00000001803A08F0-0x00000001803A0A10
		remove; // 0x00000001803A0A10-0x00000001803A0B30
	}
	public event Action<string> OnRoomJoinFailed {
		add; // 0x00000001803A0B30-0x00000001803A0C50
		remove; // 0x00000001803A0C50-0x00000001803A0D70
	}
	public event Action<ChatMessageDTO> OnRoomMemberUpdate {
		add; // 0x00000001803A0D70-0x00000001803A0E90
		remove; // 0x00000001803A0E90-0x00000001803A0FB0
	}
	public event Action<ChatMessageDTO> OnRoomReadyUpdate {
		add; // 0x00000001803A0FB0-0x00000001803A10D0
		remove; // 0x00000001803A10D0-0x00000001803A11F0
	}
	public event Action<ChatMessageDTO> OnRoomMatchStarting {
		add; // 0x00000001803A11F0-0x00000001803A1310
		remove; // 0x00000001803A1310-0x00000001803A1430
	}
	public event Action<ChatMessageDTO> OnRoomStartMatchFailed {
		add; // 0x00000001803A1430-0x00000001803A1550
		remove; // 0x00000001803A1550-0x00000001803A1670
	}
	public event Action<ChatMessageDTO> OnRoomPropsUpdate {
		add; // 0x00000001803A1670-0x00000001803A1790
		remove; // 0x00000001803A1790-0x00000001803A18B0
	}
	public event Action<ChatMessageDTO> OnRoomPlayerPropsUpdate {
		add; // 0x00000001803A18B0-0x00000001803A19D0
		remove; // 0x00000001803A19D0-0x00000001803A1AF0
	}
	public event Action<ChatMessageDTO> OnRoomKicked {
		add; // 0x00000001803A1AF0-0x00000001803A1C10
		remove; // 0x00000001803A1C10-0x00000001803A1D30
	}
	public event Action<string> OnRoomKickFailed {
		add; // 0x00000001803A1D30-0x00000001803A1E50
		remove; // 0x00000001803A1E50-0x00000001803A1F70
	}
	public event Action<RoomBootstrapData> OnRoomBootstrapResponse {
		add; // 0x00000001803A1F70-0x00000001803A2090
		remove; // 0x00000001803A2090-0x00000001803A21B0
	}
	public event Action<string> OnRoomBootstrapFailed {
		add; // 0x00000001803A21B0-0x00000001803A22D0
		remove; // 0x00000001803A22D0-0x00000001803A23F0
	}
	public event Action<ChatMessageDTO> OnUserEnergyDelta {
		add; // 0x00000001803A23F0-0x00000001803A2510
		remove; // 0x00000001803A2510-0x00000001803A2630
	}
	public event Action<ChatMessageDTO> OnGiftPush {
		add; // 0x00000001803A2630-0x00000001803A2750
		remove; // 0x00000001803A2750-0x00000001803A2870
	}
	public event Action<ChatMessageDTO> OnNoticePush {
		add; // 0x00000001803A2870-0x00000001803A2990
		remove; // 0x00000001803A2990-0x00000001803A2AB0
	}
	public event Action<ChatMessageDTO> OnFriendPush {
		add; // 0x00000001803A2AB0-0x00000001803A2BD0
		remove; // 0x00000001803A2BD0-0x00000001803A2CF0
	}
	public event Action<ChatMessageDTO> OnFriendMsg {
		add; // 0x00000001803A2CF0-0x00000001803A2E10
		remove; // 0x00000001803A2E10-0x00000001803A2F30
	}
	public event Action<ChatMessageDTO> OnFriendOnline {
		add; // 0x00000001803A2F30-0x00000001803A3050
		remove; // 0x00000001803A3050-0x00000001803A3170
	}
	public event Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse {
		add; // 0x00000001803A3170-0x00000001803A3290
		remove; // 0x00000001803A3290-0x00000001803A33B0
	}
	public event Action<RoomSummaryDTO[]> OnRoomListReceived {
		add; // 0x00000001803A33B0-0x00000001803A34D0
		remove; // 0x00000001803A34D0-0x00000001803A35F0
	}
	public event Action<RoomSummaryDTO[]> OnRoomListSnapshot {
		add; // 0x00000001803A35F0-0x00000001803A3710
		remove; // 0x00000001803A3710-0x00000001803A3830
	}
	public event Action<string, RoomSummaryDTO> OnRoomListDelta {
		add; // 0x00000001803A3830-0x00000001803A3950
		remove; // 0x00000001803A3950-0x00000001803A3A70
	}
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803A3A70-0x00000001803A3B90
		remove; // 0x00000001803A3B90-0x00000001803A3CB0
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x00000001803A3CB0-0x00000001803A3DD0
		remove; // 0x00000001803A3DD0-0x00000001803A3EF0
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x00000001803A3EF0-0x00000001803A4010
		remove; // 0x00000001803A4010-0x00000001803A4130
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x00000001803A4130-0x00000001803A4250
		remove; // 0x00000001803A4250-0x00000001803A4370
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x00000001803A4370-0x00000001803A4490
		remove; // 0x00000001803A4490-0x00000001803A45B0
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x00000001803A45B0-0x00000001803A46D0
		remove; // 0x00000001803A46D0-0x00000001803A47F0
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x00000001803A47F0-0x00000001803A4910
		remove; // 0x00000001803A4910-0x00000001803A4A30
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x00000001803A4A30-0x00000001803A4B50
		remove; // 0x00000001803A4B50-0x00000001803A4C70
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x00000001803A4C70-0x00000001803A4D90
		remove; // 0x00000001803A4D90-0x00000001803A4EB0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x00000001803A4EB0-0x00000001803A4FD0
		remove; // 0x00000001803A4FD0-0x00000001803A50F0
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x00000001803A50F0-0x00000001803A5210
		remove; // 0x00000001803A5210-0x00000001803A5330
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x00000001803A5330-0x00000001803A5450
		remove; // 0x00000001803A5450-0x00000001803A5570
	}
	public event Action<ChatMessageDTO> OnMatchSkillHint {
		add; // 0x00000001803A5570-0x00000001803A5690
		remove; // 0x00000001803A5690-0x00000001803A57B0
	}
	public event Action<ChatMessageDTO> OnMatchQteEvent {
		add; // 0x00000001803A57B0-0x00000001803A58D0
		remove; // 0x00000001803A58D0-0x00000001803A59F0
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x00000001803A59F0-0x00000001803A5B10
		remove; // 0x00000001803A5B10-0x00000001803A5C30
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x00000001803A5C30-0x00000001803A5D50
		remove; // 0x00000001803A5D50-0x00000001803A5E70
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x00000001803A5E70-0x00000001803A5F90
		remove; // 0x00000001803A5F90-0x00000001803A60B0
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x00000001803A60B0-0x00000001803A61D0
		remove; // 0x00000001803A61D0-0x00000001803A62F0
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x00000001803A62F0-0x00000001803A6410
		remove; // 0x00000001803A6410-0x00000001803A6530
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x00000001803A6530-0x00000001803A6650
		remove; // 0x00000001803A6650-0x00000001803A6770
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x00000001803A6770-0x00000001803A6890
		remove; // 0x00000001803A6890-0x00000001803A69B0
	}
	public event Action<ChatMessageDTO> OnWsConfig {
		add; // 0x00000001803A69B0-0x00000001803A6AD0
		remove; // 0x00000001803A6AD0-0x00000001803A6BF0
	}
	public event Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse {
		add; // 0x00000001803A6BF0-0x00000001803A6D10
		remove; // 0x00000001803A6D10-0x00000001803A6E30
	}
	public event Action<HubBootstrapData> OnHubBootstrapResponse {
		add; // 0x00000001803A6E30-0x00000001803A6F50
		remove; // 0x00000001803A6F50-0x00000001803A7070
	}
	public event Action<string> OnHubBootstrapFailed {
		add; // 0x00000001803A7070-0x00000001803A7190
		remove; // 0x00000001803A7190-0x00000001803A72B0
	}
	public event Action<MatchPrepDataDTO> OnMatchPrepResponse {
		add; // 0x00000001803A72B0-0x00000001803A73D0
		remove; // 0x00000001803A73D0-0x00000001803A74F0
	}
	public event Action<string> OnMatchPrepFailed {
		add; // 0x00000001803A74F0-0x00000001803A7610
		remove; // 0x00000001803A7610-0x00000001803A7730
	}
	public event Action<PetRewardDataDTO> OnMatchRewardResponse {
		add; // 0x00000001803A7730-0x00000001803A7850
		remove; // 0x00000001803A7850-0x00000001803A7970
	}
	public event Action<string> OnMatchRewardFailed {
		add; // 0x00000001803A7970-0x00000001803A7A90
		remove; // 0x00000001803A7A90-0x00000001803A7BB0
	}
	public event Action<PvpProfileDTO> OnPvpProfileResponse {
		add; // 0x00000001803A7BB0-0x00000001803A7CD0
		remove; // 0x00000001803A7CD0-0x00000001803A7DF0
	}
	public event Action<string> OnPvpProfileFailed {
		add; // 0x00000001803A7DF0-0x00000001803A7F10
		remove; // 0x00000001803A7F10-0x00000001803A8030
	}
	public event Action<List<WorldBossDTO>> OnWorldBossListResponse {
		add; // 0x00000001803A8030-0x00000001803A8150
		remove; // 0x00000001803A8150-0x00000001803A8270
	}
	public event Action<string> OnWorldBossListFailed {
		add; // 0x00000001803A8270-0x00000001803A8390
		remove; // 0x00000001803A8390-0x00000001803A84B0
	}
	public event Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse {
		add; // 0x00000001803A84B0-0x00000001803A85D0
		remove; // 0x00000001803A85D0-0x00000001803A86F0
	}
	public event Action<string> OnWorldBossDamageSubmitFailed {
		add; // 0x00000001803A86F0-0x00000001803A8810
		remove; // 0x00000001803A8810-0x00000001803A8930
	}
	public event Action<ChatMessageDTO> OnPvpPong {
		add; // 0x00000001803A8930-0x00000001803A8A50
		remove; // 0x00000001803A8A50-0x00000001803A8B70
	}
	public event Action<ChatMessageDTO> OnMatchmakingFound {
		add; // 0x00000001803A8B70-0x00000001803A8C90
		remove; // 0x00000001803A8C90-0x00000001803A8DB0
	}
	public event Action<string> OnMatchmakingFailed {
		add; // 0x00000001803A8DB0-0x00000001803A8ED0
		remove; // 0x00000001803A8ED0-0x00000001803A8FF0
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
		static __c(); // 0x00000001803B4E10-0x00000001803B4EB0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _.cctor_b__368_0(object sender, [Nullable(1)] Newtonsoft.Json.Serialization.ErrorEventArgs args); // 0x00000001803B4EB0-0x00000001803B4FA0
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
		internal void _ConnectWebSocket_b__0(); // 0x00000001803B4FA0-0x00000001803B51D0
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
		internal void _HeartbeatLoop_b__0(); // 0x00000001803B51D0-0x00000001803B54A0
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
		internal void _OnWebSocketMessage_b__0(); // 0x00000001803B54A0-0x00000001803B7DB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass285_0 // TypeDefIndex: 514
	{
		// Fields
		public WebSocket ws; // 0x10

		// Constructors
		public __c__DisplayClass285_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseSocketInBackground_b__0(); // 0x00000001803B7DB0-0x00000001803B7DF0
	}

	[CompilerGenerated]
	private sealed class _AutoReconnectLoop_d__286 : IEnumerator<object> // TypeDefIndex: 515
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
		public _AutoReconnectLoop_d__286(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803B7DF0-0x00000001803B8020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803B8020-0x00000001803B8060
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
		private bool MoveNext(); // 0x00000001803B8060-0x00000001803B8580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803B8580-0x00000001803B85C0
	}

	// Constructors
	public ChatService(); // 0x00000001803B3E90-0x00000001803B40A0
	static ChatService(); // 0x00000001803B40A0-0x00000001803B45C0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStaticsOnPlay(); // 0x000000018039DC10-0x000000018039DE50
	private static bool IsSocketOpen(WebSocket ws); // 0x000000018039E1A0-0x000000018039E290
	public string GetUsername(); // 0x00000001802B4AE0-0x00000001802B4AF0
	public long GetUserId(); // 0x000000018039E290-0x000000018039E2A0
	private void Awake(); // 0x00000001803A8FF0-0x00000001803A92A0
	public void ConnectWebSocket(string name); // 0x00000001803A92A0-0x00000001803AA2D0
	private void OnWebSocketOpen(object sender, EventArgs e); // 0x00000001803AA2D0-0x00000001803AA3E0
	[IteratorStateMachine(typeof(_HeartbeatLoop_d__271))]
	private IEnumerator HeartbeatLoop(); // 0x00000001803AA3F0-0x00000001803AA490
	private static bool IsHeavyWsType(string type); // 0x00000001803AA490-0x00000001803AA6B0
	private void OnWebSocketMessage(object sender, MessageEventArgs e); // 0x00000001803AA6B0-0x00000001803AACC0
	private void OnWebSocketError(object sender, WebSocketSharp.ErrorEventArgs e); // 0x00000001803AACC0-0x00000001803AAF90
	private void OnWebSocketClose(object sender, CloseEventArgs e); // 0x00000001803AAF90-0x00000001803AB320
	private void OnApplicationFocus(bool hasFocus); // 0x00000001803AB320-0x00000001803AB4A0
	private static void CloseSocketInBackground(WebSocket ws); // 0x00000001803AB4A0-0x00000001803AB5D0
	[IteratorStateMachine(typeof(_AutoReconnectLoop_d__286))]
	private IEnumerator AutoReconnectLoop(); // 0x00000001803AB5D0-0x00000001803AB670
	public void SendMessage(string text); // 0x00000001803AB670-0x00000001803AB840
	public void SendWebSocketMessage(ChatMessageDTO messageObj); // 0x00000001803AB840-0x00000001803ABBF0
	private static void EnqueueSend(WebSocket socket, string type, string json); // 0x00000001803ABBF0-0x00000001803ABEB0
	private static void EnsureSenderThread(); // 0x00000001803ABEB0-0x00000001803AC360
	private static void SenderLoop(); // 0x00000001803AC360-0x00000001803AC950
	private static void FlushSendQueue(int timeoutMs); // 0x00000001803AC950-0x00000001803ACC00
	public void SendSystemMessage(string text); // 0x00000001803ACC00-0x00000001803ACDD0
	public void SendTeamChat(string text); // 0x00000001803ACDD0-0x00000001803ACF60
	public void ClearTeamHistory(); // 0x00000001803ACFC0-0x00000001803AD000
	public void SendGuildChat(string text); // 0x00000001803AD000-0x00000001803AD190
	public void ClearGuildHistory(); // 0x00000001803AD190-0x00000001803AD1D0
	public bool SendImage(string channelType, string imageId, int w, int h); // 0x00000001803AD1D0-0x00000001803AD530
	public bool SendTeamEmote(string emojiId); // 0x00000001803AD530-0x00000001803AD720
	public bool SendWorldEmote(string emojiId); // 0x00000001803AD720-0x00000001803AD910
	public bool SendChatReact(long msgId, string emojiId, string scope); // 0x00000001803AD980-0x00000001803ADB10
	private List<ChatMessageDTO> HistoryForReactScope(string scope); // 0x00000001803ADB10-0x00000001803ADD50
	private void ApplyChatReactUpdate(ChatMessageDTO m); // 0x00000001803ADD50-0x00000001803AE0D0
	public void SendInvite(string targetUsername, string slotInfo); // 0x00000001803AE0D0-0x00000001803AE1E0
	public void SetBusyStatus(bool busy); // 0x00000001803AE1E0-0x00000001803AE360
	public void RequestOnlineList(); // 0x00000001803AE360-0x00000001803AE4C0
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x00000001803AE4C0-0x00000001803AE750
	public void JoinRoom(string roomId); // 0x00000001803AE750-0x00000001803AE920
	public void RequestHubBootstrap(); // 0x00000001803AE920-0x00000001803AEAD0
	public void RequestPetsPaginated(int page, int size); // 0x00000001803AEAD0-0x00000001803AECD0
	public void SendMatchEnergyUse(); // 0x00000001803AECD0-0x00000001803AEE80
	private static void NoticeQuitPenalty(ChatMessageDTO m); // 0x00000001803AEE80-0x00000001803AF150
	public void SendMatchLeave(); // 0x00000001803AF150-0x00000001803AF470
	public void SendMatchResultReq(string matchId); // 0x00000001803AF470-0x00000001803AF640
	public void RequestOnlineUsersWithInfo(); // 0x00000001803AF640-0x00000001803AF7F0
	public void RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode); // 0x00000001803AF7F0-0x00000001803AFA60
	public void RequestWorldBossList(); // 0x00000001803AFA60-0x00000001803AFC10
	public void SendWorldBossDamageCheckpoint(long bossScheduleId, int delta); // 0x00000001803AFC10-0x00000001803AFDD0
	public void RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount); // 0x00000001803AFDD0-0x00000001803B0010
	public void RequestPvpProfile(long? targetUserId); // 0x00000001803B0010-0x00000001803B01D0
	public void RequestMatchReward(long petId, bool victory, long t, string s); // 0x00000001803B01D0-0x00000001803B0450
	public void RequestRoomBootstrap(long petId, string mode); // 0x00000001803B0450-0x00000001803B0680
	public void KickMember(string targetUsername); // 0x00000001803B0680-0x00000001803B0850
	public void LeaveRoom(); // 0x00000001803B0850-0x00000001803B09B0
	public void SendMatchmakingJoin(int petId); // 0x00000001803B09B0-0x00000001803B0B90
	public void SendMatchmakingCancel(); // 0x00000001803B0B90-0x00000001803B0CF0
	public void SetRoomReady(bool ready); // 0x00000001803B0CF0-0x00000001803B0E70
	public void StartMatch(); // 0x00000001803B0E70-0x00000001803B0FD0
	public void UpdateRoomProperties(Dictionary<string, object> properties); // 0x00000001803B0FD0-0x00000001803B10B0
	public void UpdatePlayerProps(WsPlayerStateDTO diff); // 0x00000001803B10B0-0x00000001803B1270
	public void RequestRoomList(); // 0x00000001803B1270-0x00000001803B13D0
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x00000001803B13D0-0x00000001803B1590
	public void UnsubscribeRoomList(); // 0x00000001803B1590-0x00000001803B16F0
	public void RequestMatchResync(string matchId, string reason = null); // 0x00000001803B16F0-0x00000001803B19C0
	public void SendMatchClientReady(string matchId); // 0x00000001803B19C0-0x00000001803B1CB0
	public void SendMatchAnimDone(string matchId, long ackToken); // 0x00000001803B1CB0-0x00000001803B1ED0
	public void SendMatchSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x00000001803B1ED0-0x00000001803B22A0
	public void SendMatchQteStart(string matchId, int skillCardId, Dictionary<string, object> payload = null); // 0x00000001803B22A0-0x00000001803B24F0
	public void SendMatchQteTap(string matchId, int elapsedMs, long challengeId); // 0x00000001803B24F0-0x00000001803B2710
	public void SendMatchSkillHint(string matchId, Dictionary<string, object> payload); // 0x00000001803B2710-0x00000001803B2930
	public void SendMatchQteEvent(string matchId, Dictionary<string, object> payload); // 0x00000001803B2930-0x00000001803B2B50
	public void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x00000001803B2B50-0x00000001803B2DD0
	public void SendMatchCardUse(string matchId, int cardId, int? cardTarget = default); // 0x00000001803B2DD0-0x00000001803B2FD0
	public void SendMatchFusionList(string matchId); // 0x00000001803B2FD0-0x00000001803B3190
	public void SendMatchFusionUse(string matchId, long fusionUserPetId); // 0x00000001803B3190-0x00000001803B3370
	public void SendMatchDragPause(string matchId); // 0x00000001803B3370-0x00000001803B3530
	public void SendMatchDragResume(string matchId); // 0x00000001803B3530-0x00000001803B36F0
	public void SendMatchShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x00000001803B36F0-0x00000001803B3950
	public void Disconnect(); // 0x00000001803B3950-0x00000001803B3C20
	public void ClearHistory(); // 0x00000001803B3C20-0x00000001803B3CA0
	private void OnDestroy(); // 0x00000001803B3CA0-0x00000001803B3CB0
	private void OnApplicationQuit(); // 0x00000001803B3CB0-0x00000001803B3E90
	[CompilerGenerated]
	private void _OnWebSocketOpen_b__264_0(); // 0x00000001803B45C0-0x00000001803B4A40
	[CompilerGenerated]
	private void _OnWebSocketError_b__276_0(); // 0x00000001803B4A40-0x00000001803B4B60
	[CompilerGenerated]
	private void _OnWebSocketClose_b__277_0(); // 0x00000001803B4B60-0x00000001803B4E10
}

