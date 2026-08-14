//Type is in global namespace

public class WsMatchClient : MonoBehaviour
{
	[CompilerGenerated]
	private static WsMatchClient <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; //Field offset: 0x20
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; //Field offset: 0x28
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchMoveRes; //Field offset: 0x30
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReject; //Field offset: 0x38
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTurnEnd; //Field offset: 0x40
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTimerTick; //Field offset: 0x48
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchCardUseRes; //Field offset: 0x50
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillUseRes; //Field offset: 0x58
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerLeft; //Field offset: 0x60
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerRejoin; //Field offset: 0x68
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchAfkWarn; //Field offset: 0x70
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillCast; //Field offset: 0x78
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchBossAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteChallenge; //Field offset: 0x88
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionListRes; //Field offset: 0x90
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionRes; //Field offset: 0x98
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchGameOver; //Field offset: 0xA0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchEndNotice; //Field offset: 0xA8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResultPush; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReadyState; //Field offset: 0xB8
	private bool subscribed; //Field offset: 0xC0

	public event Action<ChatMessageDTO> OnMatchAfkWarn
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
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
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
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

	public event Action<ChatMessageDTO> OnMatchMoveRes
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchPlayerLeft
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchPlayerRejoin
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchQteChallenge
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchReadyState
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchReject
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
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
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchSkillCast
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchSkillUseRes
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchStart
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchTimerTick
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ChatMessageDTO> OnMatchTurnEnd
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public private static WsMatchClient Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public bool IsConnected
	{
		 get { } //Length: 169
	}

	public WsMatchClient() { }

	[CompilerGenerated]
	private void <Subscribe>b__70_0(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_1(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_10(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_11(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_12(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_13(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_14(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_15(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_16(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_17(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_18(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_19(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_2(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_3(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_4(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_5(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_6(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_7(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_8(ChatMessageDTO e) { }

	[CompilerGenerated]
	private void <Subscribe>b__70_9(ChatMessageDTO e) { }

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
	public void add_OnMatchMoveRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchPlayerLeft(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchPlayerRejoin(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchQteChallenge(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchReadyState(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchReject(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchResultPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchSkillUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchTimerTick(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchTurnEnd(Action<ChatMessageDTO> value) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInit() { }

	private void Awake() { }

	private static Action<ChatMessageDTO> Forward(Action<ChatMessageDTO> a) { }

	[CompilerGenerated]
	public static WsMatchClient get_Instance() { }

	public bool get_IsConnected() { }

	private void OnDestroy() { }

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
	public void remove_OnMatchMoveRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPlayerLeft(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchPlayerRejoin(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchQteChallenge(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchReadyState(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchReject(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchResultPush(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchSkillUseRes(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchTimerTick(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchTurnEnd(Action<ChatMessageDTO> value) { }

	public void RequestResync(string matchId) { }

	public void SendAnimDone(string matchId, long ackToken) { }

	public void SendCardUse(string matchId, int cardId, Nullable<Int32> cardTarget = null) { }

	public void SendClientReady(string matchId) { }

	public void SendDragPause(string matchId) { }

	public void SendDragResume(string matchId) { }

	public void SendEnergyUse() { }

	public void SendFusionList(string matchId) { }

	public void SendFusionUse(string matchId, long fusionUserPetId) { }

	public void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum) { }

	public void SendQteStart(string matchId, int skillCardId) { }

	public void SendShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter) { }

	public void SendSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<Int32> selectedRows, List<List`1<Int32>> selectedDots, List<String> qtePresses = null, Nullable<Int32> qteElapsedMs = null) { }

	[CompilerGenerated]
	private static void set_Instance(WsMatchClient value) { }

	private void Subscribe() { }

	private void Unsubscribe() { }

}

