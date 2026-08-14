//Type is in global namespace

public class ChatService : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__311_0(object sender, ErrorEventArgs args) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass231_0
	{
		public WebSocket wsLocal; //Field offset: 0x10
		public ChatService <>4__this; //Field offset: 0x18

		public <>c__DisplayClass231_0() { }

		internal void <ConnectWebSocket>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass239_0
	{
		public WebSocket ws; //Field offset: 0x10
		public ChatService <>4__this; //Field offset: 0x18

		public <>c__DisplayClass239_0() { }

		internal void <HeartbeatLoop>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass240_0
	{
		public ChatService <>4__this; //Field offset: 0x10
		public string json; //Field offset: 0x18
		public ChatMessageDTO message; //Field offset: 0x20

		public <>c__DisplayClass240_0() { }

		internal void <OnWebSocketMessage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass250_0
	{
		public WebSocket ws; //Field offset: 0x10

		public <>c__DisplayClass250_0() { }

		internal void <CloseSocketInBackground>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <AutoReconnectLoop>d__251 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChatService <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <AutoReconnectLoop>d__251(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <HeartbeatLoop>d__239 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChatService <>4__this; //Field offset: 0x20
		private <>c__DisplayClass239_0 <>8__1; //Field offset: 0x28
		private float <elapsed>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <HeartbeatLoop>d__239(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static ChatService _instance; //Field offset: 0x0
	private const float CONNECT_GUARD_SEC = 20; //Field offset: 0x0
	private static bool _isQuitting; //Field offset: 0x8
	private static readonly JsonSerializerSettings _wsDeserializeSettings; //Field offset: 0x10
	private WebSocket webSocket; //Field offset: 0x20
	private bool isConnected; //Field offset: 0x28
	private int userId; //Field offset: 0x2C
	private string username; //Field offset: 0x30
	private List<ChatMessageDTO> messageHistory; //Field offset: 0x38
	private int maxMessages; //Field offset: 0x40
	private readonly List<ChatMessageDTO> teamMessageHistory; //Field offset: 0x48
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnTeamMessage; //Field offset: 0x50
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnTeamEmote; //Field offset: 0x58
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReadyState; //Field offset: 0x60
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMessageReceived; //Field offset: 0x68
	[CompilerGenerated]
	private Action<Boolean> OnConnectionChanged; //Field offset: 0x70
	[CompilerGenerated]
	private Action<Int32> OnReconnecting; //Field offset: 0x78
	[CompilerGenerated]
	private Action<String, Color> OnStatusChanged; //Field offset: 0x80
	[CompilerGenerated]
	private Action<String, String> OnInviteReceived; //Field offset: 0x88
	[CompilerGenerated]
	private Action<String, String> OnInviteFailed; //Field offset: 0x90
	[CompilerGenerated]
	private Action<String, Boolean, Boolean> OnPresenceChanged; //Field offset: 0x98
	[CompilerGenerated]
	private Action<UserPresenceDTO[]> OnOnlineListReceived; //Field offset: 0xA0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomCreated; //Field offset: 0xA8
	[CompilerGenerated]
	private Action<String> OnRoomCreateFailed; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomJoined; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<String> OnRoomJoinFailed; //Field offset: 0xC0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMemberUpdate; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomReadyUpdate; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomMatchStarting; //Field offset: 0xD8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomStartMatchFailed; //Field offset: 0xE0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPropsUpdate; //Field offset: 0xE8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomPlayerPropsUpdate; //Field offset: 0xF0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnRoomKicked; //Field offset: 0xF8
	[CompilerGenerated]
	private Action<String> OnRoomKickFailed; //Field offset: 0x100
	[CompilerGenerated]
	private Action<RoomBootstrapData> OnRoomBootstrapResponse; //Field offset: 0x108
	[CompilerGenerated]
	private Action<String> OnRoomBootstrapFailed; //Field offset: 0x110
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnUserEnergyDelta; //Field offset: 0x118
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGiftPush; //Field offset: 0x120
	[CompilerGenerated]
	private Action<List`1<OnlineUserInfoDTO>> OnOnlineUsersResponse; //Field offset: 0x128
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListReceived; //Field offset: 0x130
	[CompilerGenerated]
	private Action<RoomSummaryDTO[]> OnRoomListSnapshot; //Field offset: 0x138
	[CompilerGenerated]
	private Action<String, RoomSummaryDTO> OnRoomListDelta; //Field offset: 0x140
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; //Field offset: 0x148
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; //Field offset: 0x150
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchMoveRes; //Field offset: 0x158
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReject; //Field offset: 0x160
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTurnEnd; //Field offset: 0x168
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTimerTick; //Field offset: 0x170
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchCardUseRes; //Field offset: 0x178
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillUseRes; //Field offset: 0x180
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerLeft; //Field offset: 0x188
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerRejoin; //Field offset: 0x190
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchAfkWarn; //Field offset: 0x198
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillCast; //Field offset: 0x1A0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillHint; //Field offset: 0x1A8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteEvent; //Field offset: 0x1B0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchBossAction; //Field offset: 0x1B8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteChallenge; //Field offset: 0x1C0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionListRes; //Field offset: 0x1C8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionRes; //Field offset: 0x1D0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchGameOver; //Field offset: 0x1D8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchEndNotice; //Field offset: 0x1E0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResultPush; //Field offset: 0x1E8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWsConfig; //Field offset: 0x1F0
	[CompilerGenerated]
	private Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse; //Field offset: 0x1F8
	[CompilerGenerated]
	private Action<HubBootstrapData> OnHubBootstrapResponse; //Field offset: 0x200
	[CompilerGenerated]
	private Action<String> OnHubBootstrapFailed; //Field offset: 0x208
	[CompilerGenerated]
	private Action<MatchPrepDataDTO> OnMatchPrepResponse; //Field offset: 0x210
	[CompilerGenerated]
	private Action<String> OnMatchPrepFailed; //Field offset: 0x218
	[CompilerGenerated]
	private Action<PetRewardDataDTO> OnMatchRewardResponse; //Field offset: 0x220
	[CompilerGenerated]
	private Action<String> OnMatchRewardFailed; //Field offset: 0x228
	[CompilerGenerated]
	private Action<PvpProfileDTO> OnPvpProfileResponse; //Field offset: 0x230
	[CompilerGenerated]
	private Action<String> OnPvpProfileFailed; //Field offset: 0x238
	[CompilerGenerated]
	private Action<List`1<WorldBossDTO>> OnWorldBossListResponse; //Field offset: 0x240
	[CompilerGenerated]
	private Action<String> OnWorldBossListFailed; //Field offset: 0x248
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse; //Field offset: 0x250
	[CompilerGenerated]
	private Action<String> OnWorldBossDamageSubmitFailed; //Field offset: 0x258
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPvpPong; //Field offset: 0x260
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchmakingFound; //Field offset: 0x268
	[CompilerGenerated]
	private Action<String> OnMatchmakingFailed; //Field offset: 0x270
	private Coroutine _heartbeatCoroutine; //Field offset: 0x278
	private int _lastRttMs; //Field offset: 0x280
	private bool _pingInFlight; //Field offset: 0x284
	private bool _pingFailed; //Field offset: 0x285
	private bool _explicitDisconnect; //Field offset: 0x286
	private Coroutine _reconnectCoroutine; //Field offset: 0x288
	private int _reconnectAttempt; //Field offset: 0x290
	private bool _connecting; //Field offset: 0x294
	private float _connectStartedAt; //Field offset: 0x298
	private float _lastEmoteAt; //Field offset: 0x29C
	private float _historyReplayUntil; //Field offset: 0x2A0

	public event Action<Boolean> OnConnectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnGiftPush
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnHubBootstrapFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<HubBootstrapData> OnHubBootstrapResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, String> OnInviteFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, String> OnInviteReceived
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchAfkWarn
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchBossAction
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchCardUseRes
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchEndNotice
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchFusionListRes
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchFusionRes
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchGameOver
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnMatchmakingFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchmakingFound
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchMoveRes
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchPlayerLeft
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchPlayerRejoin
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnMatchPrepFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<MatchPrepDataDTO> OnMatchPrepResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchQteChallenge
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchQteEvent
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchReadyState
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchReject
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchResultPush
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchResync
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnMatchRewardFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<PetRewardDataDTO> OnMatchRewardResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchSkillCast
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchSkillHint
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchSkillUseRes
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchStart
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchTimerTick
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchTurnEnd
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMessageReceived
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<UserPresenceDTO[]> OnOnlineListReceived
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<List`1<OnlineUserInfoDTO>> OnOnlineUsersResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<PetsPaginatedDataDTO> OnPetsPaginatedResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, Boolean, Boolean> OnPresenceChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnPvpPong
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnPvpProfileFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<PvpProfileDTO> OnPvpProfileResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<Int32> OnReconnecting
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<String> OnRoomBootstrapFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<RoomBootstrapData> OnRoomBootstrapResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomCreated
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnRoomCreateFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomJoined
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnRoomJoinFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomKicked
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnRoomKickFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, RoomSummaryDTO> OnRoomListDelta
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<RoomSummaryDTO[]> OnRoomListReceived
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<RoomSummaryDTO[]> OnRoomListSnapshot
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomMatchStarting
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomMemberUpdate
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomPlayerPropsUpdate
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomPropsUpdate
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomReadyUpdate
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnRoomStartMatchFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, Color> OnStatusChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnTeamEmote
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnTeamMessage
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnUserEnergyDelta
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnWorldBossDamageSubmitFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnWorldBossDamageSubmitResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnWorldBossListFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<List`1<WorldBossDTO>> OnWorldBossListResponse
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnWsConfig
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public bool InHistoryReplayWindow
	{
		 get { } //Length: 36
	}

	public static ChatService Instance
	{
		 get { } //Length: 664
	}

	public bool IsConnected
	{
		 get { } //Length: 5
	}

	public int LastRttMs
	{
		 get { } //Length: 25
	}

	public IReadOnlyList<ChatMessageDTO> MessageHistory
	{
		 get { } //Length: 5
	}

	public IReadOnlyList<ChatMessageDTO> TeamMessageHistory
	{
		 get { } //Length: 5
	}

	public string Username
	{
		 get { } //Length: 5
	}

	private static ChatService() { }

	public ChatService() { }

	[CompilerGenerated]
	private void <OnWebSocketClose>b__242_0() { }

	[CompilerGenerated]
	private void <OnWebSocketError>b__241_0() { }

	[CompilerGenerated]
	private void <OnWebSocketOpen>b__232_0() { }

	[CompilerGenerated]
	public void add_OnConnectionChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void add_OnGiftPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnHubBootstrapFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnHubBootstrapResponse(Action<HubBootstrapData> value) { }

	[CompilerGenerated]
	public void add_OnInviteFailed(Action<String, String> value) { }

	[CompilerGenerated]
	public void add_OnInviteReceived(Action<String, String> value) { }

	[CompilerGenerated]
	public void add_OnMatchAfkWarn(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchBossAction(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchCardUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchEndNotice(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchFusionListRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchFusionRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchGameOver(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchmakingFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchmakingFound(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchMoveRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchPlayerLeft(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchPlayerRejoin(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchPrepFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchPrepResponse(Action<MatchPrepDataDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchQteChallenge(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchQteEvent(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchReadyState(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchReject(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchResultPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchRewardFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchRewardResponse(Action<PetRewardDataDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchSkillHint(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchSkillUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchTimerTick(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchTurnEnd(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMessageReceived(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnOnlineListReceived(Action<UserPresenceDTO[]> value) { }

	[CompilerGenerated]
	public void add_OnOnlineUsersResponse(Action<List`1<OnlineUserInfoDTO>> value) { }

	[CompilerGenerated]
	public void add_OnPetsPaginatedResponse(Action<PetsPaginatedDataDTO> value) { }

	[CompilerGenerated]
	public void add_OnPresenceChanged(Action<String, Boolean, Boolean> value) { }

	[CompilerGenerated]
	public void add_OnPvpPong(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnPvpProfileFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnPvpProfileResponse(Action<PvpProfileDTO> value) { }

	[CompilerGenerated]
	public void add_OnReconnecting(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnRoomBootstrapFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomBootstrapResponse(Action<RoomBootstrapData> value) { }

	[CompilerGenerated]
	public void add_OnRoomCreated(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomCreateFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomJoined(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomJoinFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomKicked(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomKickFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomListDelta(Action<String, RoomSummaryDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomListReceived(Action<RoomSummaryDTO[]> value) { }

	[CompilerGenerated]
	public void add_OnRoomListSnapshot(Action<RoomSummaryDTO[]> value) { }

	[CompilerGenerated]
	public void add_OnRoomMatchStarting(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomMemberUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomPlayerPropsUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomPropsUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomReadyUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnRoomStartMatchFailed(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnStatusChanged(Action<String, Color> value) { }

	[CompilerGenerated]
	public void add_OnTeamEmote(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnTeamMessage(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnUserEnergyDelta(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnWorldBossDamageSubmitFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnWorldBossDamageSubmitResponse(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnWorldBossListFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnWorldBossListResponse(Action<List`1<WorldBossDTO>> value) { }

	[CompilerGenerated]
	public void add_OnWsConfig(Action<ChatMessageDTO> value) { }

	[IteratorStateMachine(typeof(<AutoReconnectLoop>d__251))]
	private IEnumerator AutoReconnectLoop() { }

	private void Awake() { }

	public void ClearHistory() { }

	public void ClearTeamHistory() { }

	private static void CloseSocketInBackground(WebSocket ws) { }

	public void ConnectWebSocket(string name) { }

	public void CreateRoom(string roomType, int maxPlayers, Dictionary<String, Object> properties = null) { }

	public void Disconnect() { }

	public bool get_InHistoryReplayWindow() { }

	public static ChatService get_Instance() { }

	public bool get_IsConnected() { }

	public int get_LastRttMs() { }

	public IReadOnlyList<ChatMessageDTO> get_MessageHistory() { }

	public IReadOnlyList<ChatMessageDTO> get_TeamMessageHistory() { }

	public string get_Username() { }

	public long GetUserId() { }

	public string GetUsername() { }

	[IteratorStateMachine(typeof(<HeartbeatLoop>d__239))]
	private IEnumerator HeartbeatLoop() { }

	public void JoinRoom(string roomId) { }

	public void KickMember(string targetUsername) { }

	public void LeaveRoom() { }

	private void OnApplicationFocus(bool hasFocus) { }

	private void OnApplicationQuit() { }

	private void OnDestroy() { }

	private void OnWebSocketClose(object sender, CloseEventArgs e) { }

	private void OnWebSocketError(object sender, ErrorEventArgs e) { }

	private void OnWebSocketMessage(object sender, MessageEventArgs e) { }

	private void OnWebSocketOpen(object sender, EventArgs e) { }

	[CompilerGenerated]
	public void remove_OnConnectionChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnGiftPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnHubBootstrapFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnHubBootstrapResponse(Action<HubBootstrapData> value) { }

	[CompilerGenerated]
	public void remove_OnInviteFailed(Action<String, String> value) { }

	[CompilerGenerated]
	public void remove_OnInviteReceived(Action<String, String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchAfkWarn(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchBossAction(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchCardUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchEndNotice(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchFusionListRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchFusionRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchGameOver(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchmakingFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchmakingFound(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchMoveRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPlayerLeft(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPlayerRejoin(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPrepFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPrepResponse(Action<MatchPrepDataDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchQteChallenge(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchQteEvent(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchReadyState(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchReject(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchResultPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchRewardFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchRewardResponse(Action<PetRewardDataDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchSkillHint(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchSkillUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchTimerTick(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchTurnEnd(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMessageReceived(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnOnlineListReceived(Action<UserPresenceDTO[]> value) { }

	[CompilerGenerated]
	public void remove_OnOnlineUsersResponse(Action<List`1<OnlineUserInfoDTO>> value) { }

	[CompilerGenerated]
	public void remove_OnPetsPaginatedResponse(Action<PetsPaginatedDataDTO> value) { }

	[CompilerGenerated]
	public void remove_OnPresenceChanged(Action<String, Boolean, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnPvpPong(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnPvpProfileFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnPvpProfileResponse(Action<PvpProfileDTO> value) { }

	[CompilerGenerated]
	public void remove_OnReconnecting(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnRoomBootstrapFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomBootstrapResponse(Action<RoomBootstrapData> value) { }

	[CompilerGenerated]
	public void remove_OnRoomCreated(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomCreateFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomJoined(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomJoinFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomKicked(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomKickFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomListDelta(Action<String, RoomSummaryDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomListReceived(Action<RoomSummaryDTO[]> value) { }

	[CompilerGenerated]
	public void remove_OnRoomListSnapshot(Action<RoomSummaryDTO[]> value) { }

	[CompilerGenerated]
	public void remove_OnRoomMatchStarting(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomMemberUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomPlayerPropsUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomPropsUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomReadyUpdate(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnRoomStartMatchFailed(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnStatusChanged(Action<String, Color> value) { }

	[CompilerGenerated]
	public void remove_OnTeamEmote(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnTeamMessage(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnUserEnergyDelta(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnWorldBossDamageSubmitFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnWorldBossDamageSubmitResponse(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnWorldBossListFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnWorldBossListResponse(Action<List`1<WorldBossDTO>> value) { }

	[CompilerGenerated]
	public void remove_OnWsConfig(Action<ChatMessageDTO> value) { }

	public void RequestHubBootstrap() { }

	public void RequestMatchPrep(long userPetId, long enemyPetId, Nullable<Int64> bossScheduleId, string mode) { }

	public void RequestMatchResync(string matchId) { }

	public void RequestMatchReward(long petId, bool victory, long t, string s) { }

	public void RequestOnlineList() { }

	public void RequestOnlineUsersWithInfo() { }

	public void RequestPetsPaginated(int page, int size) { }

	public void RequestPvpProfile(Nullable<Int64> targetUserId) { }

	public void RequestRoomBootstrap(long petId, string mode) { }

	public void RequestRoomList() { }

	public void RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount) { }

	public void RequestWorldBossList() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	private static void ResetStaticsOnPlay() { }

	public void SendInvite(string targetUsername, string slotInfo) { }

	public void SendMatchAnimDone(string matchId, long ackToken) { }

	public void SendMatchCardUse(string matchId, int cardId, Nullable<Int32> cardTarget = null) { }

	public void SendMatchClientReady(string matchId) { }

	public void SendMatchDragPause(string matchId) { }

	public void SendMatchDragResume(string matchId) { }

	public void SendMatchEnergyUse() { }

	public void SendMatchFusionList(string matchId) { }

	public void SendMatchFusionUse(string matchId, long fusionUserPetId) { }

	public void SendMatchLeave() { }

	public void SendMatchmakingCancel() { }

	public void SendMatchmakingJoin(int petId) { }

	public void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum) { }

	public void SendMatchQteEvent(string matchId, Dictionary<String, Object> payload) { }

	public void SendMatchQteStart(string matchId, int skillCardId) { }

	public void SendMatchResultReq(string matchId) { }

	public void SendMatchShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter) { }

	public void SendMatchSkillHint(string matchId, Dictionary<String, Object> payload) { }

	public void SendMatchSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<Int32> selectedRows, List<List`1<Int32>> selectedDots, List<String> qtePresses = null, Nullable<Int32> qteElapsedMs = null) { }

	public void SendMessage(string text) { }

	public void SendSystemMessage(string text) { }

	public void SendTeamChat(string text) { }

	public bool SendTeamEmote(string emojiId) { }

	public void SendWebSocketMessage(ChatMessageDTO messageObj) { }

	public void SendWorldBossDamageCheckpoint(long bossScheduleId, int delta) { }

	public bool SendWorldEmote(string emojiId) { }

	public void SetBusyStatus(bool busy) { }

	public void SetRoomReady(bool ready) { }

	public void StartMatch() { }

	public void SubscribeRoomList(RoomListFilterDTO filter = null) { }

	public void UnsubscribeRoomList() { }

	public void UpdatePlayerProps(WsPlayerStateDTO diff) { }

	public void UpdateRoomProperties(Dictionary<String, Object> properties) { }

}

