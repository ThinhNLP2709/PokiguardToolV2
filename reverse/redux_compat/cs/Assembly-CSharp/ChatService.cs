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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ChatService : MonoBehaviour // TypeDefIndex: 388
{
	// Fields
	private static ChatService _instance; // 0x00
	private static bool _isQuitting; // 0x08
	private WebSocket webSocket; // 0x20
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
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReadyState; // 0x60
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMessageReceived; // 0x68
	[CompilerGenerated]
	private Action<bool> OnConnectionChanged; // 0x70
	[CompilerGenerated]
	private Action<int> OnReconnecting; // 0x78
	[CompilerGenerated]
	private Action<string, Color> OnStatusChanged; // 0x80
	[CompilerGenerated]
	private Action<string, string> OnInviteReceived; // 0x88
	[CompilerGenerated]
	private Action<string, string> OnInviteFailed; // 0x90
	[CompilerGenerated]
	private Action<string, bool, bool> OnPresenceChanged; // 0x98
	[CompilerGenerated]
	private Action<UserPresenceDTO[]> OnOnlineListReceived; // 0xA0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomCreated; // 0xA8
	[CompilerGenerated]
	private Action<string> OnRoomCreateFailed; // 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomJoined; // 0xB8
	[CompilerGenerated]
	private Action<string> OnRoomJoinFailed; // 0xC0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMemberUpdate; // 0xC8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomReadyUpdate; // 0xD0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMatchStarting; // 0xD8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomStartMatchFailed; // 0xE0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPropsUpdate; // 0xE8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPlayerPropsUpdate; // 0xF0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomKicked; // 0xF8
	[CompilerGenerated]
	private Action<string> OnRoomKickFailed; // 0x100
	[CompilerGenerated]
	private Action<RoomBootstrapData> OnRoomBootstrapResponse; // 0x108
	[CompilerGenerated]
	private Action<string> OnRoomBootstrapFailed; // 0x110
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnUserEnergyDelta; // 0x118
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGiftPush; // 0x120
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnNoticePush; // 0x128
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendPush; // 0x130
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendMsg; // 0x138
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFriendOnline; // 0x140
	[CompilerGenerated]
	private Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse; // 0x148
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListReceived; // 0x150
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListSnapshot; // 0x158
	[CompilerGenerated]
	private Action<string, RoomSummaryDTO> OnRoomListDelta; // 0x160
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0x168
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0x170
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchMoveRes; // 0x178
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReject; // 0x180
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTurnEnd; // 0x188
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTimerTick; // 0x190
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchCardUseRes; // 0x198
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillUseRes; // 0x1A0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerLeft; // 0x1A8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerRejoin; // 0x1B0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchAfkWarn; // 0x1B8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillCast; // 0x1C0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillHint; // 0x1C8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteEvent; // 0x1D0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchBossAction; // 0x1D8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteChallenge; // 0x1E0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionListRes; // 0x1E8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionRes; // 0x1F0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchGameOver; // 0x1F8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchEndNotice; // 0x200
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResultPush; // 0x208
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWsConfig; // 0x210
	[CompilerGenerated]
	private Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse; // 0x218
	[CompilerGenerated]
	private Action<HubBootstrapData> OnHubBootstrapResponse; // 0x220
	[CompilerGenerated]
	private Action<string> OnHubBootstrapFailed; // 0x228
	[CompilerGenerated]
	private Action<MatchPrepDataDTO> OnMatchPrepResponse; // 0x230
	[CompilerGenerated]
	private Action<string> OnMatchPrepFailed; // 0x238
	[CompilerGenerated]
	private Action<PetRewardDataDTO> OnMatchRewardResponse; // 0x240
	[CompilerGenerated]
	private Action<string> OnMatchRewardFailed; // 0x248
	[CompilerGenerated]
	private Action<PvpProfileDTO> OnPvpProfileResponse; // 0x250
	[CompilerGenerated]
	private Action<string> OnPvpProfileFailed; // 0x258
	[CompilerGenerated]
	private Action<List<WorldBossDTO>> OnWorldBossListResponse; // 0x260
	[CompilerGenerated]
	private Action<string> OnWorldBossListFailed; // 0x268
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse; // 0x270
	[CompilerGenerated]
	private Action<string> OnWorldBossDamageSubmitFailed; // 0x278
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPvpPong; // 0x280
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchmakingFound; // 0x288
	[CompilerGenerated]
	private Action<string> OnMatchmakingFailed; // 0x290
	private static readonly JsonSerializerSettings _wsDeserializeSettings; // 0x10
	private Coroutine _heartbeatCoroutine; // 0x298
	private int _lastRttMs; // 0x2A0
	private bool _pingInFlight; // 0x2A4
	private bool _pingFailed; // 0x2A5
	private bool _explicitDisconnect; // 0x2A6
	private Coroutine _reconnectCoroutine; // 0x2A8
	private int _reconnectAttempt; // 0x2B0
	private bool _connecting; // 0x2B4
	private float _connectStartedAt; // 0x2B8
	private const float CONNECT_GUARD_SEC = 20f; // Metadata: 0x0064C2B4
	private const int SEND_QUEUE_CAPACITY = 512; // Metadata: 0x0064C2B8
	private static readonly BlockingCollection<QueuedWsMessage> _sendQueue; // 0x18
	private static Thread _senderThread; // 0x20
	private static readonly object _senderLock; // 0x28
	private float _lastEmoteAt; // 0x2BC
	private float _historyReplayUntil; // 0x2C0

	// Properties
	public static ChatService Instance { get; } // 0x0000000180327080-0x0000000180327270 
	public IReadOnlyList<ChatMessageDTO> TeamMessageHistory { get; } // 0x00000001803272B0-0x00000001803272C0 
	public bool IsConnected { get; } // 0x0000000180327270-0x0000000180327280 
	public string Username { get; } // 0x000000018031E110-0x000000018031E120 
	public IReadOnlyList<ChatMessageDTO> MessageHistory { get; } // 0x00000001803272A0-0x00000001803272B0 
	public int LastRttMs { get; } // 0x0000000180327280-0x00000001803272A0 
	public bool InHistoryReplayWindow { get; } // 0x0000000180327050-0x0000000180327080 

	// Events
	public event Action<ChatMessageDTO> OnTeamMessage {
		add; // 0x0000000180326AB0-0x0000000180326B70
		remove; // 0x000000018032A810-0x000000018032A8D0
	}
	public event Action<ChatMessageDTO> OnTeamEmote {
		add; // 0x00000001803269F0-0x0000000180326AB0
		remove; // 0x000000018032A750-0x000000018032A810
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x0000000180324800-0x00000001803248C0
		remove; // 0x0000000180328560-0x0000000180328620
	}
	public event Action<ChatMessageDTO> OnMessageReceived {
		add; // 0x0000000180325350-0x0000000180325410
		remove; // 0x00000001803290B0-0x0000000180329170
	}
	public event Action<bool> OnConnectionChanged {
		add; // 0x0000000180323560-0x0000000180323620
		remove; // 0x00000001803272C0-0x0000000180327380
	}
	public event Action<int> OnReconnecting {
		add; // 0x0000000180325A90-0x0000000180325B50
		remove; // 0x00000001803297F0-0x00000001803298B0
	}
	public event Action<string, Color> OnStatusChanged {
		add; // 0x0000000180326920-0x00000001803269F0
		remove; // 0x000000018032A680-0x000000018032A750
	}
	public event Action<string, string> OnInviteReceived {
		add; // 0x0000000180323BD0-0x0000000180323CA0
		remove; // 0x0000000180327930-0x0000000180327A00
	}
	public event Action<string, string> OnInviteFailed {
		add; // 0x0000000180323B00-0x0000000180323BD0
		remove; // 0x0000000180327860-0x0000000180327930
	}
	public event Action<string, bool, bool> OnPresenceChanged {
		add; // 0x0000000180325750-0x0000000180325820
		remove; // 0x00000001803294B0-0x0000000180329580
	}
	public event Action<UserPresenceDTO[]> OnOnlineListReceived {
		add; // 0x00000001803254E0-0x00000001803255B0
		remove; // 0x0000000180329240-0x0000000180329310
	}
	public event Action<ChatMessageDTO> OnRoomCreated {
		add; // 0x0000000180325DC0-0x0000000180325E90
		remove; // 0x0000000180329B20-0x0000000180329BF0
	}
	public event Action<string> OnRoomCreateFailed {
		add; // 0x0000000180325CF0-0x0000000180325DC0
		remove; // 0x0000000180329A50-0x0000000180329B20
	}
	public event Action<ChatMessageDTO> OnRoomJoined {
		add; // 0x0000000180325F60-0x0000000180326030
		remove; // 0x0000000180329CC0-0x0000000180329D90
	}
	public event Action<string> OnRoomJoinFailed {
		add; // 0x0000000180325E90-0x0000000180325F60
		remove; // 0x0000000180329BF0-0x0000000180329CC0
	}
	public event Action<ChatMessageDTO> OnRoomMemberUpdate {
		add; // 0x0000000180326510-0x00000001803265E0
		remove; // 0x000000018032A270-0x000000018032A340
	}
	public event Action<ChatMessageDTO> OnRoomReadyUpdate {
		add; // 0x0000000180326780-0x0000000180326850
		remove; // 0x000000018032A4E0-0x000000018032A5B0
	}
	public event Action<ChatMessageDTO> OnRoomMatchStarting {
		add; // 0x0000000180326440-0x0000000180326510
		remove; // 0x000000018032A1A0-0x000000018032A270
	}
	public event Action<ChatMessageDTO> OnRoomStartMatchFailed {
		add; // 0x0000000180326850-0x0000000180326920
		remove; // 0x000000018032A5B0-0x000000018032A680
	}
	public event Action<ChatMessageDTO> OnRoomPropsUpdate {
		add; // 0x00000001803266B0-0x0000000180326780
		remove; // 0x000000018032A410-0x000000018032A4E0
	}
	public event Action<ChatMessageDTO> OnRoomPlayerPropsUpdate {
		add; // 0x00000001803265E0-0x00000001803266B0
		remove; // 0x000000018032A340-0x000000018032A410
	}
	public event Action<ChatMessageDTO> OnRoomKicked {
		add; // 0x0000000180326100-0x00000001803261D0
		remove; // 0x0000000180329E60-0x0000000180329F30
	}
	public event Action<string> OnRoomKickFailed {
		add; // 0x0000000180326030-0x0000000180326100
		remove; // 0x0000000180329D90-0x0000000180329E60
	}
	public event Action<RoomBootstrapData> OnRoomBootstrapResponse {
		add; // 0x0000000180325C20-0x0000000180325CF0
		remove; // 0x0000000180329980-0x0000000180329A50
	}
	public event Action<string> OnRoomBootstrapFailed {
		add; // 0x0000000180325B50-0x0000000180325C20
		remove; // 0x00000001803298B0-0x0000000180329980
	}
	public event Action<ChatMessageDTO> OnUserEnergyDelta {
		add; // 0x0000000180326B70-0x0000000180326C40
		remove; // 0x000000018032A8D0-0x000000018032A9A0
	}
	public event Action<ChatMessageDTO> OnGiftPush {
		add; // 0x0000000180323890-0x0000000180323960
		remove; // 0x00000001803275F0-0x00000001803276C0
	}
	public event Action<ChatMessageDTO> OnNoticePush {
		add; // 0x0000000180325410-0x00000001803254E0
		remove; // 0x0000000180329170-0x0000000180329240
	}
	public event Action<ChatMessageDTO> OnFriendPush {
		add; // 0x00000001803237C0-0x0000000180323890
		remove; // 0x0000000180327520-0x00000001803275F0
	}
	public event Action<ChatMessageDTO> OnFriendMsg {
		add; // 0x0000000180323620-0x00000001803236F0
		remove; // 0x0000000180327380-0x0000000180327450
	}
	public event Action<ChatMessageDTO> OnFriendOnline {
		add; // 0x00000001803236F0-0x00000001803237C0
		remove; // 0x0000000180327450-0x0000000180327520
	}
	public event Action<List<OnlineUserInfoDTO>> OnOnlineUsersResponse {
		add; // 0x00000001803255B0-0x0000000180325680
		remove; // 0x0000000180329310-0x00000001803293E0
	}
	public event Action<RoomSummaryDTO[]> OnRoomListReceived {
		add; // 0x00000001803262A0-0x0000000180326370
		remove; // 0x000000018032A000-0x000000018032A0D0
	}
	public event Action<RoomSummaryDTO[]> OnRoomListSnapshot {
		add; // 0x0000000180326370-0x0000000180326440
		remove; // 0x000000018032A0D0-0x000000018032A1A0
	}
	public event Action<string, RoomSummaryDTO> OnRoomListDelta {
		add; // 0x00000001803261D0-0x00000001803262A0
		remove; // 0x0000000180329F30-0x000000018032A000
	}
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x0000000180324F40-0x0000000180325010
		remove; // 0x0000000180328CA0-0x0000000180328D70
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x0000000180324A60-0x0000000180324B30
		remove; // 0x00000001803287C0-0x0000000180328890
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x0000000180324250-0x0000000180324320
		remove; // 0x0000000180327FB0-0x0000000180328080
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x00000001803248C0-0x0000000180324990
		remove; // 0x0000000180328620-0x00000001803286F0
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x00000001803250E0-0x00000001803251B0
		remove; // 0x0000000180328E40-0x0000000180328F10
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x0000000180325010-0x00000001803250E0
		remove; // 0x0000000180328D70-0x0000000180328E40
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x0000000180323E40-0x0000000180323F10
		remove; // 0x0000000180327BA0-0x0000000180327C70
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x0000000180324E70-0x0000000180324F40
		remove; // 0x0000000180328BD0-0x0000000180328CA0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x0000000180324320-0x00000001803243F0
		remove; // 0x0000000180328080-0x0000000180328150
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x00000001803243F0-0x00000001803244C0
		remove; // 0x0000000180328150-0x0000000180328220
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x0000000180323CA0-0x0000000180323D70
		remove; // 0x0000000180327A00-0x0000000180327AD0
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x0000000180324CD0-0x0000000180324DA0
		remove; // 0x0000000180328A30-0x0000000180328B00
	}
	public event Action<ChatMessageDTO> OnMatchSkillHint {
		add; // 0x0000000180324DA0-0x0000000180324E70
		remove; // 0x0000000180328B00-0x0000000180328BD0
	}
	public event Action<ChatMessageDTO> OnMatchQteEvent {
		add; // 0x0000000180324730-0x0000000180324800
		remove; // 0x0000000180328490-0x0000000180328560
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x0000000180323D70-0x0000000180323E40
		remove; // 0x0000000180327AD0-0x0000000180327BA0
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x0000000180324660-0x0000000180324730
		remove; // 0x00000001803283C0-0x0000000180328490
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x0000000180323FE0-0x00000001803240B0
		remove; // 0x0000000180327D40-0x0000000180327E10
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x00000001803240B0-0x0000000180324180
		remove; // 0x0000000180327E10-0x0000000180327EE0
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x0000000180324180-0x0000000180324250
		remove; // 0x0000000180327EE0-0x0000000180327FB0
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x0000000180323F10-0x0000000180323FE0
		remove; // 0x0000000180327C70-0x0000000180327D40
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x0000000180324990-0x0000000180324A60
		remove; // 0x00000001803286F0-0x00000001803287C0
	}
	public event Action<ChatMessageDTO> OnWsConfig {
		add; // 0x0000000180326F80-0x0000000180327050
		remove; // 0x000000018032ACE0-0x000000018032ADB0
	}
	public event Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse {
		add; // 0x0000000180325680-0x0000000180325750
		remove; // 0x00000001803293E0-0x00000001803294B0
	}
	public event Action<HubBootstrapData> OnHubBootstrapResponse {
		add; // 0x0000000180323A30-0x0000000180323B00
		remove; // 0x0000000180327790-0x0000000180327860
	}
	public event Action<string> OnHubBootstrapFailed {
		add; // 0x0000000180323960-0x0000000180323A30
		remove; // 0x00000001803276C0-0x0000000180327790
	}
	public event Action<MatchPrepDataDTO> OnMatchPrepResponse {
		add; // 0x0000000180324590-0x0000000180324660
		remove; // 0x00000001803282F0-0x00000001803283C0
	}
	public event Action<string> OnMatchPrepFailed {
		add; // 0x00000001803244C0-0x0000000180324590
		remove; // 0x0000000180328220-0x00000001803282F0
	}
	public event Action<PetRewardDataDTO> OnMatchRewardResponse {
		add; // 0x0000000180324C00-0x0000000180324CD0
		remove; // 0x0000000180328960-0x0000000180328A30
	}
	public event Action<string> OnMatchRewardFailed {
		add; // 0x0000000180324B30-0x0000000180324C00
		remove; // 0x0000000180328890-0x0000000180328960
	}
	public event Action<PvpProfileDTO> OnPvpProfileResponse {
		add; // 0x00000001803259C0-0x0000000180325A90
		remove; // 0x0000000180329720-0x00000001803297F0
	}
	public event Action<string> OnPvpProfileFailed {
		add; // 0x00000001803258F0-0x00000001803259C0
		remove; // 0x0000000180329650-0x0000000180329720
	}
	public event Action<List<WorldBossDTO>> OnWorldBossListResponse {
		add; // 0x0000000180326EB0-0x0000000180326F80
		remove; // 0x000000018032AC10-0x000000018032ACE0
	}
	public event Action<string> OnWorldBossListFailed {
		add; // 0x0000000180326DE0-0x0000000180326EB0
		remove; // 0x000000018032AB40-0x000000018032AC10
	}
	public event Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse {
		add; // 0x0000000180326D10-0x0000000180326DE0
		remove; // 0x000000018032AA70-0x000000018032AB40
	}
	public event Action<string> OnWorldBossDamageSubmitFailed {
		add; // 0x0000000180326C40-0x0000000180326D10
		remove; // 0x000000018032A9A0-0x000000018032AA70
	}
	public event Action<ChatMessageDTO> OnPvpPong {
		add; // 0x0000000180325820-0x00000001803258F0
		remove; // 0x0000000180329580-0x0000000180329650
	}
	public event Action<ChatMessageDTO> OnMatchmakingFound {
		add; // 0x0000000180325280-0x0000000180325350
		remove; // 0x0000000180328FE0-0x00000001803290B0
	}
	public event Action<string> OnMatchmakingFailed {
		add; // 0x00000001803251B0-0x0000000180325280
		remove; // 0x0000000180328F10-0x0000000180328FE0
	}

	// Nested types
	private struct QueuedWsMessage // TypeDefIndex: 389
	{
		// Fields
		public WebSocket Socket; // 0x00
		public string Type; // 0x08
		public string Json; // 0x10
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 390
	{
		// Fields
		public static readonly __c __9; // 0x00

		// Constructors
		static __c(); // 0x00000001803468E0-0x0000000180346950
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _.cctor_b__332_0(object sender, [Nullable(1)] Newtonsoft.Json.Serialization.ErrorEventArgs args); // 0x0000000180344510-0x00000001803445F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass243_0 // TypeDefIndex: 391
	{
		// Fields
		public WebSocket wsLocal; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass243_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ConnectWebSocket_b__0(); // 0x00000001803446E0-0x00000001803447A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass251_0 // TypeDefIndex: 392
	{
		// Fields
		public WebSocket ws; // 0x10
		public ChatService __4__this; // 0x18

		// Constructors
		public __c__DisplayClass251_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _HeartbeatLoop_b__0(); // 0x00000001803447A0-0x0000000180344990
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass252_0 // TypeDefIndex: 393
	{
		// Fields
		public ChatService __4__this; // 0x10
		public string json; // 0x18
		public ChatMessageDTO message; // 0x20

		// Constructors
		public __c__DisplayClass252_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnWebSocketMessage_b__0(); // 0x0000000180344990-0x00000001803468A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass262_0 // TypeDefIndex: 394
	{
		// Fields
		public WebSocket ws; // 0x10

		// Constructors
		public __c__DisplayClass262_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CloseSocketInBackground_b__0(); // 0x00000001803468A0-0x00000001803468D0
	}

	[CompilerGenerated]
	private sealed class _AutoReconnectLoop_d__263 : IEnumerator<object> // TypeDefIndex: 395
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoReconnectLoop_d__263(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180340270-0x0000000180340430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180340430-0x0000000180340470
	}

	[CompilerGenerated]
	private sealed class _HeartbeatLoop_d__251 : IEnumerator<object> // TypeDefIndex: 396
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatService __4__this; // 0x20
		private __c__DisplayClass251_0 __8__1; // 0x28
		private float _elapsed_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HeartbeatLoop_d__251(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180340B80-0x0000000180340E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180340E80-0x0000000180340EC0
	}

	// Constructors
	public ChatService(); // 0x0000000180323490-0x0000000180323560
	static ChatService(); // 0x00000001803232B0-0x0000000180323490

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStaticsOnPlay(); // 0x0000000180320050-0x0000000180320120
	public string GetUsername(); // 0x000000018031E110-0x000000018031E120
	public long GetUserId(); // 0x000000018031E100-0x000000018031E110
	private void Awake(); // 0x000000018031CD80-0x000000018031CE80
	public void ConnectWebSocket(string name); // 0x000000018031CFE0-0x000000018031D890
	private void OnWebSocketOpen(object sender, EventArgs e); // 0x000000018031F050-0x000000018031F120
	[IteratorStateMachine(typeof(_HeartbeatLoop_d__251))]
	private IEnumerator HeartbeatLoop(); // 0x000000018031E120-0x000000018031E190
	private void OnWebSocketMessage(object sender, MessageEventArgs e); // 0x000000018031ED80-0x000000018031F050
	private void OnWebSocketError(object sender, WebSocketSharp.ErrorEventArgs e); // 0x000000018031EAE0-0x000000018031ED80
	private void OnWebSocketClose(object sender, CloseEventArgs e); // 0x000000018031E8E0-0x000000018031EAE0
	private void OnApplicationFocus(bool hasFocus); // 0x000000018031E460-0x000000018031E660
	private static void CloseSocketInBackground(WebSocket ws); // 0x000000018031CF00-0x000000018031CFE0
	[IteratorStateMachine(typeof(_AutoReconnectLoop_d__263))]
	private IEnumerator AutoReconnectLoop(); // 0x000000018031CD10-0x000000018031CD80
	public void SendMessage(string text); // 0x00000001803218B0-0x00000001803219B0
	public void SendWebSocketMessage(ChatMessageDTO messageObj); // 0x0000000180321D40-0x00000001803220F0
	private static void EnqueueSend(WebSocket socket, string type, string json); // 0x000000018031DC30-0x000000018031DDC0
	private static void EnsureSenderThread(); // 0x000000018031DDC0-0x000000018031DFF0
	private static void SenderLoop(); // 0x00000001803223B0-0x0000000180322760
	private static void FlushSendQueue(int timeoutMs); // 0x000000018031DFF0-0x000000018031E100
	public void SendSystemMessage(string text); // 0x00000001803219B0-0x0000000180321AB0
	public void SendTeamChat(string text); // 0x0000000180321AB0-0x0000000180321BC0
	public void ClearTeamHistory(); // 0x000000018031CEC0-0x000000018031CF00
	public bool SendTeamEmote(string emojiId); // 0x0000000180321BC0-0x0000000180321D40
	public bool SendWorldEmote(string emojiId); // 0x0000000180322230-0x00000001803223B0
	public void SendInvite(string targetUsername, string slotInfo); // 0x0000000180320120-0x0000000180320250
	public void SetBusyStatus(bool busy); // 0x0000000180322760-0x0000000180322860
	public void RequestOnlineList(); // 0x000000018031F690-0x000000018031F760
	public void CreateRoom(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x000000018031D890-0x000000018031DA10
	public void JoinRoom(string roomId); // 0x000000018031E190-0x000000018031E290
	public void RequestHubBootstrap(); // 0x000000018031F120-0x000000018031F230
	public void RequestPetsPaginated(int page, int size); // 0x000000018031F870-0x000000018031F9F0
	public void SendMatchEnergyUse(); // 0x0000000180320830-0x0000000180320940
	public void SendMatchLeave(); // 0x0000000180320B60-0x0000000180320CB0
	public void SendMatchResultReq(string matchId); // 0x00000001803210D0-0x00000001803211D0
	public void RequestOnlineUsersWithInfo(); // 0x000000018031F760-0x000000018031F870
	public void RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode); // 0x000000018031F230-0x000000018031F3D0
	public void RequestWorldBossList(); // 0x000000018031FF40-0x0000000180320050
	public void SendWorldBossDamageCheckpoint(long bossScheduleId, int delta); // 0x00000001803220F0-0x0000000180322230
	public void RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount); // 0x000000018031FD60-0x000000018031FF40
	public void RequestPvpProfile(long? targetUserId); // 0x000000018031F9F0-0x000000018031FB20
	public void RequestMatchReward(long petId, bool victory, long t, string s); // 0x000000018031F4C0-0x000000018031F690
	public void RequestRoomBootstrap(long petId, string mode); // 0x000000018031FB20-0x000000018031FC90
	public void KickMember(string targetUsername); // 0x000000018031E290-0x000000018031E390
	public void LeaveRoom(); // 0x000000018031E390-0x000000018031E460
	public void SendMatchmakingJoin(int petId); // 0x0000000180321760-0x00000001803218B0
	public void SendMatchmakingCancel(); // 0x0000000180321690-0x0000000180321760
	public void SetRoomReady(bool ready); // 0x0000000180322860-0x0000000180322960
	public void StartMatch(); // 0x0000000180322960-0x0000000180322A30
	public void UpdateRoomProperties(Dictionary<string, object> properties); // 0x00000001803231A0-0x00000001803232B0
	public void UpdatePlayerProps(WsPlayerStateDTO diff); // 0x00000001803230A0-0x00000001803231A0
	public void RequestRoomList(); // 0x000000018031FC90-0x000000018031FD60
	public void SubscribeRoomList(RoomListFilterDTO filter = null); // 0x0000000180322A30-0x0000000180322B20
	public void UnsubscribeRoomList(); // 0x0000000180322FD0-0x00000001803230A0
	public void RequestMatchResync(string matchId); // 0x000000018031F3D0-0x000000018031F4C0
	public void SendMatchClientReady(string matchId); // 0x00000001803204C0-0x0000000180320650
	public void SendMatchAnimDone(string matchId, long ackToken); // 0x0000000180320250-0x0000000180320390
	public void SendMatchSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default); // 0x00000001803214A0-0x0000000180321690
	public void SendMatchQteStart(string matchId, int skillCardId); // 0x0000000180320FA0-0x00000001803210D0
	public void SendMatchSkillHint(string matchId, Dictionary<string, object> payload); // 0x0000000180321380-0x00000001803214A0
	public void SendMatchQteEvent(string matchId, Dictionary<string, object> payload); // 0x0000000180320E80-0x0000000180320FA0
	public void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x0000000180320CB0-0x0000000180320E80
	public void SendMatchCardUse(string matchId, int cardId, int? cardTarget = default); // 0x0000000180320390-0x00000001803204C0
	public void SendMatchFusionList(string matchId); // 0x0000000180320940-0x0000000180320A30
	public void SendMatchFusionUse(string matchId, long fusionUserPetId); // 0x0000000180320A30-0x0000000180320B60
	public void SendMatchDragPause(string matchId); // 0x0000000180320650-0x0000000180320740
	public void SendMatchDragResume(string matchId); // 0x0000000180320740-0x0000000180320830
	public void SendMatchShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x00000001803211D0-0x0000000180321380
	public void Disconnect(); // 0x000000018031DA10-0x000000018031DC30
	public void ClearHistory(); // 0x000000018031CE80-0x000000018031CEC0
	private void OnDestroy(); // 0x000000018031E8D0-0x000000018031E8E0
	private void OnApplicationQuit(); // 0x000000018031E660-0x000000018031E8D0
	[CompilerGenerated]
	private void _OnWebSocketOpen_b__244_0(); // 0x0000000180322D50-0x0000000180322FD0
	[CompilerGenerated]
	private void _OnWebSocketError_b__253_0(); // 0x0000000180322CB0-0x0000000180322D50
	[CompilerGenerated]
	private void _OnWebSocketClose_b__254_0(); // 0x0000000180322B20-0x0000000180322CB0
}

