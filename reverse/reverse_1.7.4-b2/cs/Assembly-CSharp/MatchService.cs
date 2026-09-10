/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class MatchService : MonoBehaviour // TypeDefIndex: 487
{
	// Fields
	[CompilerGenerated]
	private static MatchService _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private string _CurrentMatchId_k__BackingField; // 0x20
	[CompilerGenerated]
	private string _CurrentMatchType_k__BackingField; // 0x28
	[CompilerGenerated]
	private int _BoardWidth_k__BackingField; // 0x30
	[CompilerGenerated]
	private int _BoardHeight_k__BackingField; // 0x34
	[CompilerGenerated]
	private string _CurrentTurnPlayer_k__BackingField; // 0x38
	[CompilerGenerated]
	private int _TurnNumber_k__BackingField; // 0x40
	[CompilerGenerated]
	private int _TurnDurationSec_k__BackingField; // 0x44
	[CompilerGenerated]
	private int _BossHp_k__BackingField; // 0x48
	[CompilerGenerated]
	private int _BossHpMax_k__BackingField; // 0x4C
	[CompilerGenerated]
	private int _ServerBossPetId_k__BackingField; // 0x50
	[CompilerGenerated]
	private bool _GuildBossKillable_k__BackingField; // 0x54
	[CompilerGenerated]
	private int _GuildHuntDone_k__BackingField; // 0x58
	[CompilerGenerated]
	private int _GuildHuntRequired_k__BackingField; // 0x5C
	[CompilerGenerated]
	private bool _FusionEnabled_k__BackingField; // 0x60
	[CompilerGenerated]
	private int _FusionManaCost_k__BackingField; // 0x64
	[CompilerGenerated]
	private int _FusionStatPercent_k__BackingField; // 0x68
	[CompilerGenerated]
	private bool _LocalFusionUsed_k__BackingField; // 0x6C
	[CompilerGenerated]
	private int _LocalFusionLastAttemptTurn_k__BackingField; // 0x70
	[CompilerGenerated]
	private long _LocalFusionSelectedUserPetId_k__BackingField; // 0x78
	[CompilerGenerated]
	private long _LocalFusionSelectedPetId_k__BackingField; // 0x80
	[CompilerGenerated]
	private CardData _LocalFusionSkillCard_k__BackingField; // 0x88
	[CompilerGenerated]
	private string _LocalFusionDropReason_k__BackingField; // 0x90
	[CompilerGenerated]
	private int _ServerBossDisplayPetId_k__BackingField; // 0x98
	[CompilerGenerated]
	private int _ServerBossFinalPetId_k__BackingField; // 0x9C
	[CompilerGenerated]
	private bool _ServerBossEvolved_k__BackingField; // 0xA0
	[CompilerGenerated]
	private int _BossMana_k__BackingField; // 0xA4
	[CompilerGenerated]
	private int _BossManaMax_k__BackingField; // 0xA8
	[CompilerGenerated]
	private int _BossPower_k__BackingField; // 0xAC
	[CompilerGenerated]
	private int _BossPowerMax_k__BackingField; // 0xB0
	[CompilerGenerated]
	private int _BossShield_k__BackingField; // 0xB4
	[CompilerGenerated]
	private static int _PrepHpBonusPct_k__BackingField; // 0x08
	[CompilerGenerated]
	private static int _PrepManaBonus_k__BackingField; // 0x0C
	[CompilerGenerated]
	private static int _PrepPowerMax_k__BackingField; // 0x10
	[CompilerGenerated]
	private Dictionary<string, MatchPlayerSnapshotDTO> _Players_k__BackingField; // 0xB8
	private long _localSeqNum; // 0xC0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0xC8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0xD0
	[CompilerGenerated]
	private Action<List<MatchOpDTO>> OnOpsApplied; // 0xD8
	[CompilerGenerated]
	private Action<string> OnMatchReject; // 0xE0
	[CompilerGenerated]
	private Action OnTurnEnd; // 0xE8
	[CompilerGenerated]
	private Action<string> OnGameOver; // 0xF0
	[CompilerGenerated]
	private Action<string, bool, string> OnPlayerLeft; // 0xF8
	[CompilerGenerated]
	private Action<string> OnPlayerRejoin; // 0x100
	[CompilerGenerated]
	private Action<string, int, int> OnAfkWarn; // 0x108
	[CompilerGenerated]
	private Action<string, int> OnAfkForfeit; // 0x110
	[CompilerGenerated]
	private Action<string, int, int> OnTimerTick; // 0x118
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionList; // 0x120
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionResolved; // 0x128
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGuildBossHp; // 0x130
	[CompilerGenerated]
	private int _TurnTimeRemainingSec_k__BackingField; // 0x138
	[CompilerGenerated]
	private int _LastAnnounceHoldMs_k__BackingField; // 0x13C
	[CompilerGenerated]
	private int _TowerFloor_k__BackingField; // 0x140
	[CompilerGenerated]
	private int _TowerTurnLimit_k__BackingField; // 0x144
	[CompilerGenerated]
	private int _TowerTurnsLeft_k__BackingField; // 0x148
	[CompilerGenerated]
	private Action<int> OnTowerTurnsChanged; // 0x150
	[CompilerGenerated]
	private bool _HasBossDeadline_k__BackingField; // 0x158
	private int _bossDeadlineAnchorSec; // 0x15C
	private float _bossDeadlineAnchorAt; // 0x160
	[CompilerGenerated]
	private bool _HasServerClock_k__BackingField; // 0x164
	[CompilerGenerated]
	private bool _ClockPaused_k__BackingField; // 0x165
	[CompilerGenerated]
	private string _ClockPauseReason_k__BackingField; // 0x168
	private float _clockRemainAtAnchorSec; // 0x170
	private float _clockAnchorUnscaled; // 0x174
	private bool _startGateSeen; // 0x178
	[CompilerGenerated]
	private Action OnStartGateClosed; // 0x180
	[CompilerGenerated]
	private Action<int, int> OnReadyStateChanged; // 0x188
	private float _localFxHoldUntilUnscaled; // 0x190
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnSkillCast; // 0x198
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnBossAction; // 0x1A0
	[CompilerGenerated]
	private WsCombatBatch _PendingCombat_k__BackingField; // 0x1A8
	private int _inFlightBatches; // 0x1B0
	private readonly HashSet<long> _ackedSeqs; // 0x1B8
	[CompilerGenerated]
	private int _ServerAckDeadlineSec_k__BackingField; // 0x1C0
	private const float AckStuckGuardFallbackSec = 9f; // Metadata: 0x0068B34E
	private const float AckStuckGuardMarginSec = 1.5f; // Metadata: 0x0068B352
	private Func<bool> _rendererBusyProbe; // 0x1C8
	[CompilerGenerated]
	private int _ServerBossHp_k__BackingField; // 0x1D0
	[CompilerGenerated]
	private Dictionary<string, ServerPlayerStats> _ServerStats_k__BackingField; // 0x1D8
	[CompilerGenerated]
	private Action OnServerStateChanged; // 0x1E0
	private bool _wsCfgSubscribed; // 0x1E8
	private bool _guildBossHpSubscribed; // 0x1E9
	private bool _subscribed; // 0x1EA
	private bool _matchOver; // 0x1EB
	private Coroutine _resyncCoroutine; // 0x1F0
	[CompilerGenerated]
	private int _LastMoveFromCol_k__BackingField; // 0x1F8
	[CompilerGenerated]
	private int _LastMoveFromRow_k__BackingField; // 0x1FC
	[CompilerGenerated]
	private int _LastMoveToCol_k__BackingField; // 0x200
	[CompilerGenerated]
	private int _LastMoveToRow_k__BackingField; // 0x204
	[CompilerGenerated]
	private long _LastMoveSeqNum_k__BackingField; // 0x208
	private int _shadowDamageSnapshot; // 0x210
	private long _shadowLastReportedSeq; // 0x218
	[CompilerGenerated]
	private List<string> _ServerQteArrows_k__BackingField; // 0x220
	[CompilerGenerated]
	private int _ServerQteDurationMs_k__BackingField; // 0x228
	[CompilerGenerated]
	private QteWindow _ServerQteWindow_k__BackingField; // 0x22C
	[CompilerGenerated]
	private Action OnQteChallengeReady; // 0x248
	[CompilerGenerated]
	private long _ServerQteChallengeId_k__BackingField; // 0x250
	private int _qteRequestedCardId; // 0x258
	private float _qteRequestedAt; // 0x25C
	private const float QteRequestStaleSec = 6f; // Metadata: 0x0068B356
	[CompilerGenerated]
	private string _LastKnownMatchId_k__BackingField; // 0x260
	[CompilerGenerated]
	private string _LastResyncReason_k__BackingField; // 0x268
	private static readonly JsonSerializer _payloadSerializer; // 0x18
	[CompilerGenerated]
	private int? _LastRejectCardId_k__BackingField; // 0x270
	[CompilerGenerated]
	private string _LastAfkMode_k__BackingField; // 0x278
	private string _deferredWinner; // 0x280
	private bool _hasDeferredGameOver; // 0x288
	[CompilerGenerated]
	private static string _LastEndedMatchId_k__BackingField; // 0x20
	[CompilerGenerated]
	private string _LastEndReason_k__BackingField; // 0x290
	private const float GameOverRenderWaitMaxSec = 30f; // Metadata: 0x0068B35A
	private Coroutine _gameOverFlushCo; // 0x298
	private static readonly JsonSerializer SnapshotSerializer; // 0x28

	// Properties
	public static MatchService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C110-0x000000018039C160 0x000000018039D840-0x000000018039D8B0
	public static bool UseWsGameplay { get; set; } // 0x00000001802EB990-0x00000001802EB9A0 0x00000001802EB6C0-0x00000001802EB6D0
	public static bool UsePvpWs { get; set; } // 0x00000001802EB990-0x00000001802EB9A0 0x00000001802EB6C0-0x00000001802EB6D0
	public string CurrentMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF660-0x00000001802FF670 0x0000000180308AD0-0x0000000180308AE0
	public string CurrentMatchType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF640-0x00000001802FF650 0x0000000180308AC0-0x0000000180308AD0
	public int BoardWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF70-0x000000018039BF80 0x000000018039D720-0x000000018039D730
	public int BoardHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF60-0x000000018039BF70 0x000000018039D710-0x000000018039D720
	public string CurrentTurnPlayer { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20
	public int TurnNumber { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C660-0x000000018039C670 0x000000018039DCC0-0x000000018039DCD0
	public int TurnDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C650-0x000000018039C660 0x000000018039DCB0-0x000000018039DCC0
	public int BossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308A80-0x0000000180308A90 0x0000000180308AE0-0x0000000180308AF0
	public int BossHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C020-0x000000018039C030 0x000000018039D730-0x000000018039D740
	public int ServerBossPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C520-0x000000018039C530 0x000000018039DBE0-0x000000018039DBF0
	public bool GuildBossKillable { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0C0-0x000000018039C0D0 0x000000018039D7F0-0x000000018039D800
	public int GuildHuntDone { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0D0-0x000000018039C0E0 0x000000018039D800-0x000000018039D810
	public int GuildHuntRequired { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0E0-0x000000018039C0F0 0x000000018039D810-0x000000018039D820
	public bool IsGuildBossMatch { get; } // 0x000000018039C160-0x000000018039C1B0 
	public bool FusionEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0A0-0x000000018039C0B0 0x000000018039D7C0-0x000000018039D7D0
	public int FusionManaCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FAD60-0x00000001802FAD70 0x000000018039D7D0-0x000000018039D7E0
	public int FusionStatPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0B0-0x000000018039C0C0 0x000000018039D7E0-0x000000018039D7F0
	public bool LocalFusionUsed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C3C0-0x000000018039C3D0 0x000000018039DA40-0x000000018039DA50
	public int LocalFusionLastAttemptTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C390-0x000000018039C3A0 0x000000018039DA10-0x000000018039DA20
	public bool LocalFusionLockedThisTurn { get; } // 0x000000018039C3A0-0x000000018039C3C0 
	public long LocalFusionSelectedUserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF650-0x00000001802FF660 0x000000018039DA30-0x000000018039DA40
	public long LocalFusionSelectedPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180319930-0x0000000180319940 0x000000018039DA20-0x000000018039DA30
	public CardData LocalFusionSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180319920-0x0000000180319930 0x0000000180319C10-0x0000000180319C30
	public string LocalFusionDropReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180319910-0x0000000180319920 0x0000000180319BF0-0x0000000180319C10
	public int ServerBossDisplayPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C4E0-0x000000018039C4F0 0x000000018039DBA0-0x000000018039DBB0
	public int ServerBossFinalPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C500-0x000000018039C510 0x000000018039DBC0-0x000000018039DBD0
	public bool ServerBossEvolved { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C4F0-0x000000018039C500 0x000000018039DBB0-0x000000018039DBC0
	public int BossMana { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C040-0x000000018039C050 0x000000018039D750-0x000000018039D760
	public int BossManaMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C030-0x000000018039C040 0x000000018039D740-0x000000018039D750
	public int BossPower { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C060-0x000000018039C070 0x000000018039D770-0x000000018039D780
	public int BossPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C050-0x000000018039C060 0x000000018039D760-0x000000018039D770
	public int BossShield { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C070-0x000000018039C080 0x000000018039D780-0x000000018039D790
	public static int PrepHpBonusPct { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C3E0-0x000000018039C430 0x000000018039DA70-0x000000018039DAD0
	public static int PrepManaBonus { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C430-0x000000018039C480 0x000000018039DAD0-0x000000018039DB30
	public static int PrepPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C480-0x000000018039C4D0 0x000000018039DB30-0x000000018039DB90
	public Dictionary<string, MatchPlayerSnapshotDTO> Players { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803198F0-0x0000000180319900 0x0000000180319BB0-0x0000000180319BD0
	public int TurnTimeRemainingSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C670-0x000000018039C680 0x000000018039DCD0-0x000000018039DCE0
	public int LastAnnounceHoldMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C2A0-0x000000018039C2B0 0x000000018039D8D0-0x000000018039D8E0
	public int TowerFloor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C620-0x000000018039C630 0x000000018039DC80-0x000000018039DC90
	public int TowerTurnLimit { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C630-0x000000018039C640 0x000000018039DC90-0x000000018039DCA0
	public int TowerTurnsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C640-0x000000018039C650 0x000000018039DCA0-0x000000018039DCB0
	public bool HasBossDeadline { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0F0-0x000000018039C100 0x000000018039D820-0x000000018039D830
	public int BossDeadlineRemainingSec { get; } // 0x000000018039BF80-0x000000018039C020 
	public bool HasServerClock { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C100-0x000000018039C110 0x000000018039D830-0x000000018039D840
	public bool ClockPaused { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C090-0x000000018039C0A0 0x000000018039D7B0-0x000000018039D7C0
	public string ClockPauseReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C080-0x000000018039C090 0x000000018039D790-0x000000018039D7B0
	public bool IsStartGatePaused { get; } // 0x000000018039C230-0x000000018039C290 
	public float ServerTurnRemainingSec { get; } // 0x000000018039C5A0-0x000000018039C620 
	private bool IsLocalFxHold { get; } // 0x000000018039C1B0-0x000000018039C1E0 
	public WsCombatBatch PendingCombat { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C3D0-0x000000018039C3E0 0x000000018039DA50-0x000000018039DA70
	public int ServerAckDeadlineSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C4D0-0x000000018039C4E0 0x000000018039DB90-0x000000018039DBA0
	private float AckStuckGuardSec { get; } // 0x000000018039BF20-0x000000018039BF60 
	public bool IsRenderingCombat { get; } // 0x000000018039C220-0x000000018039C230 
	public bool IsPresentationBusy { get; } // 0x000000018039C1E0-0x000000018039C220 
	public int ServerBossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C510-0x000000018039C520 0x000000018039DBD0-0x000000018039DBE0
	public Dictionary<string, ServerPlayerStats> ServerStats { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C590-0x000000018039C5A0 0x000000018039DC60-0x000000018039DC80
	public int LastMoveFromCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C320-0x000000018039C330 0x000000018039D990-0x000000018039D9A0
	public int LastMoveFromRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C330-0x000000018039C340 0x000000018039D9A0-0x000000018039D9B0
	public int LastMoveToCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C350-0x000000018039C360 0x000000018039D9C0-0x000000018039D9D0
	public int LastMoveToRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C360-0x000000018039C370 0x000000018039D9D0-0x000000018039D9E0
	public long LastMoveSeqNum { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C340-0x000000018039C350 0x000000018039D9B0-0x000000018039D9C0
	public List<string> ServerQteArrows { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C530-0x000000018039C540 0x000000018039DBF0-0x000000018039DC10
	public int ServerQteDurationMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C550-0x000000018039C560 0x000000018039DC20-0x000000018039DC30
	public QteWindow ServerQteWindow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C560-0x000000018039C590 0x000000018039DC30-0x000000018039DC60
	public long ServerQteChallengeId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C540-0x000000018039C550 0x000000018039DC10-0x000000018039DC20
	public string LastKnownMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C310-0x000000018039C320 0x000000018039D970-0x000000018039D990
	public string LastResyncReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C380-0x000000018039C390 0x000000018039D9F0-0x000000018039DA10
	public int? LastRejectCardId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C370-0x000000018039C380 0x000000018039D9E0-0x000000018039D9F0
	public string LastAfkMode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C290-0x000000018039C2A0 0x000000018039D8B0-0x000000018039D8D0
	public static string LastEndedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C2C0-0x000000018039C310 0x000000018039D900-0x000000018039D970
	public string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C2B0-0x000000018039C2C0 0x000000018039D8E0-0x000000018039D900

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x000000018039B5E0-0x000000018039B6B0
		remove; // 0x000000018039CDD0-0x000000018039CEA0
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x000000018039B510-0x000000018039B5E0
		remove; // 0x000000018039CD00-0x000000018039CDD0
	}
	public event Action<List<MatchOpDTO>> OnOpsApplied {
		add; // 0x000000018039B6B0-0x000000018039B780
		remove; // 0x000000018039CEA0-0x000000018039CF70
	}
	public event Action<string> OnMatchReject {
		add; // 0x000000018039B440-0x000000018039B510
		remove; // 0x000000018039CC30-0x000000018039CD00
	}
	public event Action OnTurnEnd {
		add; // 0x000000018039BE70-0x000000018039BF20
		remove; // 0x000000018039D660-0x000000018039D710
	}
	public event Action<string> OnGameOver {
		add; // 0x000000018039B2A0-0x000000018039B370
		remove; // 0x000000018039CA90-0x000000018039CB60
	}
	public event Action<string, bool, string> OnPlayerLeft {
		add; // 0x000000018039B780-0x000000018039B850
		remove; // 0x000000018039CF70-0x000000018039D040
	}
	public event Action<string> OnPlayerRejoin {
		add; // 0x000000018039B850-0x000000018039B920
		remove; // 0x000000018039D040-0x000000018039D110
	}
	public event Action<string, int, int> OnAfkWarn {
		add; // 0x000000018039AF60-0x000000018039B030
		remove; // 0x000000018039C750-0x000000018039C820
	}
	public event Action<string, int> OnAfkForfeit {
		add; // 0x000000018039AE90-0x000000018039AF60
		remove; // 0x000000018039C680-0x000000018039C750
	}
	public event Action<string, int, int> OnTimerTick {
		add; // 0x000000018039BCD0-0x000000018039BDA0
		remove; // 0x000000018039D4C0-0x000000018039D590
	}
	public event Action<ChatMessageDTO> OnFusionList {
		add; // 0x000000018039B100-0x000000018039B1D0
		remove; // 0x000000018039C8F0-0x000000018039C9C0
	}
	public event Action<ChatMessageDTO> OnFusionResolved {
		add; // 0x000000018039B1D0-0x000000018039B2A0
		remove; // 0x000000018039C9C0-0x000000018039CA90
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x000000018039B370-0x000000018039B440
		remove; // 0x000000018039CB60-0x000000018039CC30
	}
	public event Action<int> OnTowerTurnsChanged {
		add; // 0x000000018039BDA0-0x000000018039BE70
		remove; // 0x000000018039D590-0x000000018039D660
	}
	public event Action OnStartGateClosed {
		add; // 0x000000018039BC20-0x000000018039BCD0
		remove; // 0x000000018039D410-0x000000018039D4C0
	}
	public event Action<int, int> OnReadyStateChanged {
		add; // 0x000000018039B9D0-0x000000018039BAA0
		remove; // 0x000000018039D1C0-0x000000018039D290
	}
	public event Action<ChatMessageDTO> OnSkillCast {
		add; // 0x000000018039BB50-0x000000018039BC20
		remove; // 0x000000018039D340-0x000000018039D410
	}
	public event Action<ChatMessageDTO> OnBossAction {
		add; // 0x000000018039B030-0x000000018039B100
		remove; // 0x000000018039C820-0x000000018039C8F0
	}
	public event Action OnServerStateChanged {
		add; // 0x000000018039BAA0-0x000000018039BB50
		remove; // 0x000000018039D290-0x000000018039D340
	}
	public event Action OnQteChallengeReady {
		add; // 0x000000018039B920-0x000000018039B9D0
		remove; // 0x000000018039D110-0x000000018039D1C0
	}

	// Nested types
	public class ServerPlayerStats // TypeDefIndex: 488
	{
		// Fields
		public int HP; // 0x10
		public int MaxHP; // 0x14
		public int Mana; // 0x18
		public int MaxMana; // 0x1C
		public int Power; // 0x20
		public int MaxPower; // 0x24
		public int Shield; // 0x28

		// Constructors
		public ServerPlayerStats(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	public struct QteWindow // TypeDefIndex: 489
	{
		// Fields
		public int durationMs; // 0x00
		public int perfectStartMs; // 0x04
		public int perfectEndMs; // 0x08
		public int goodStart1Ms; // 0x0C
		public int goodEnd1Ms; // 0x10
		public int goodStart2Ms; // 0x14
		public int goodEnd2Ms; // 0x18

		// Properties
		public bool Valid { get; } // 0x00000001803A2DD0-0x00000001803A2DF0 
	}

	[CompilerGenerated]
	private sealed class _AckStuckGuard_d__287 : IEnumerator<object> // TypeDefIndex: 490
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		public long srvSeq; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AckStuckGuard_d__287(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803A2DF0-0x00000001803A2FA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A2FA0-0x00000001803A2FE0
	}

	[CompilerGenerated]
	private sealed class _FetchFeatureFlags_d__322 : IEnumerator<object> // TypeDefIndex: 491
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchFeatureFlags_d__322(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803A3390-0x00000001803A3470
		private bool MoveNext(); // 0x00000001803A2FE0-0x00000001803A3350
		private void __m__Finally1(); // 0x00000001803A3470-0x00000001803A34C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A3350-0x00000001803A3390
	}

	[CompilerGenerated]
	private sealed class _FlushGameOverWhenPresentationDone_d__447 : IEnumerator<object> // TypeDefIndex: 492
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlushGameOverWhenPresentationDone_d__447(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803A34C0-0x00000001803A36B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A36B0-0x00000001803A36F0
	}

	[CompilerGenerated]
	private sealed class _ResyncAfterReconnect_d__333 : IEnumerator<object> // TypeDefIndex: 493
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResyncAfterReconnect_d__333(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803A6030-0x00000001803A61A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A61A0-0x00000001803A61E0
	}

	// Constructors
	public MatchService(); // 0x000000018039AC10-0x000000018039AE90
	static MatchService(); // 0x000000018039AAB0-0x000000018039AC10

	// Methods
	public static void ApplyServerFlag(bool serverFlag); // 0x0000000180393BE0-0x0000000180393C50
	public static void ApplyPvpWsFlag(bool serverFlag); // 0x0000000180393B40-0x0000000180393BB0
	public int SkillCooldownLeftFor(int cardId); // 0x0000000180399940-0x0000000180399A40
	public static int PrepMaxHp(int baseHp); // 0x0000000180398870-0x0000000180398920
	public static int PrepMaxMana(int baseMana); // 0x0000000180398920-0x00000001803989B0
	public static void ResetPrepStatFrame(); // 0x0000000180399140-0x0000000180399260
	public static void ApplyPrepStatFrame(int? hpBonusPct, int? manaBonus, int? powerMax); // 0x0000000180393830-0x0000000180393AC0
	public static void ApplyPrepStatFrame(MatchPrepDataDTO prep); // 0x0000000180393AC0-0x0000000180393B40
	private void ApplyTowerFields(Dictionary<string, object> p, bool reset = false /* Metadata: 0x0068B334 */); // 0x0000000180394200-0x00000001803943C0
	public void BeginLocalFxHold(float sec); // 0x0000000180394A20-0x0000000180394AE0
	private void ClearLocalFxHold(); // 0x0000000180394B70-0x0000000180394B80
	private void ApplyTimingFields(Dictionary<string, object> p); // 0x0000000180394030-0x0000000180394200
	public WsCombatBatch ConsumePendingCombat(); // 0x0000000180394B80-0x0000000180394BB0
	private WsCombatBatch ParseCombatBatch(ChatMessageDTO m, string kind); // 0x00000001803973E0-0x0000000180397A60
	private void BeginAnimAck(long srvSeq, bool hasWork); // 0x0000000180394950-0x0000000180394A20
	[IteratorStateMachine(typeof(_AckStuckGuard_d__287))]
	private IEnumerator AckStuckGuard(long srvSeq); // 0x0000000180392D90-0x0000000180392E10
	public void NotifyRenderComplete(long srvSeq); // 0x0000000180397180-0x00000001803971A0
	public void NotifyRenderAckEarly(long srvSeq); // 0x0000000180397170-0x0000000180397180
	private void SendAnimAck(long srvSeq); // 0x0000000180399300-0x0000000180399460
	public void RegisterRendererBusyProbe(Func<bool> probe); // 0x0000000180398F00-0x0000000180398F20
	public void UnregisterRendererBusyProbe(Func<bool> probe); // 0x000000018039A3C0-0x000000018039A400
	public void ApplyServerStat(string username, string stat, int newValue); // 0x0000000180393C50-0x0000000180393F50
	public void ApplyServerBossHp(int newHp); // 0x0000000180393BB0-0x0000000180393BE0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803943C0-0x00000001803944F0
	private void Awake(); // 0x00000001803944F0-0x0000000180394950
	private void TrySubscribeWsConfig(); // 0x000000018039A290-0x000000018039A3C0
	private void TrySubscribeGuildBossHp(); // 0x000000018039A160-0x000000018039A290
	private void UnsubscribeGuildBossHp(); // 0x000000018039A9B0-0x000000018039AAB0
	private void HandleGuildBossHpMessage(ChatMessageDTO m); // 0x0000000180395550-0x00000001803955E0
	private void ApplyGuildBossFields(Dictionary<string, object> p); // 0x0000000180392E10-0x0000000180392F50
	private void HandleWsConfig(ChatMessageDTO m); // 0x0000000180396CF0-0x0000000180396E40
	[IteratorStateMachine(typeof(_FetchFeatureFlags_d__322))]
	private IEnumerator FetchFeatureFlags(); // 0x0000000180394CD0-0x0000000180394D20
	private void Start(); // 0x00000001803973D0-0x00000001803973E0
	private void OnEnable(); // 0x00000001803973D0-0x00000001803973E0
	private void OnDisable(); // 0x00000001803973C0-0x00000001803973D0
	private void OnDestroy(); // 0x00000001803971A0-0x00000001803973C0
	private void TrySubscribeChat(); // 0x0000000180399B80-0x000000018039A160
	private void UnsubscribeChat(); // 0x000000018039A400-0x000000018039A9B0
	private void HandleConnectionChanged(bool connected); // 0x00000001803951F0-0x00000001803952F0
	[IteratorStateMachine(typeof(_ResyncAfterReconnect_d__333))]
	private IEnumerator ResyncAfterReconnect(); // 0x0000000180399290-0x0000000180399300
	public void ClearCurrentMatch(); // 0x0000000180394AE0-0x0000000180394B70
	public void SendMove(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001803996D0-0x0000000180399810
	private void FlushShadowReportForLastMove(long seqToReport); // 0x0000000180394E50-0x0000000180395190
	public void SendCardUse(int cardId, int? cardTarget = default); // 0x0000000180399460-0x00000001803994E0
	public void SendSkillUse(int skillCardId, int correctDotCount = 0 /* Metadata: 0x0068B335 */, string timingResult = "BAD" /* Metadata: 0x0068B336 */, int dotsToDestroy = 0 /* Metadata: 0x0068B33A */, List<int> selectedRows = null, List<List<int>> selectedDots = null, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x0000000180399810-0x0000000180399940
	public void AbandonQteChallenge(); // 0x0000000180392D40-0x0000000180392D90
	private void ClearQteChallenge(); // 0x0000000180392D40-0x0000000180392D90
	public void RequestQteChallenge(int skillCardId); // 0x0000000180398F20-0x0000000180398FE0
	public void EnsureQteChallenge(int skillCardId); // 0x0000000180394BB0-0x0000000180394CD0
	private void HandleQteChallenge(ChatMessageDTO m); // 0x00000001803966E0-0x0000000180396A70
	public void SendClientReady(); // 0x00000001803994E0-0x0000000180399540
	public void SendDragPause(); // 0x0000000180399540-0x00000001803995A0
	public void SendDragResume(); // 0x00000001803995A0-0x0000000180399600
	public void RequestResync(string reason = "manual" /* Metadata: 0x0068B33B */); // 0x0000000180398FE0-0x0000000180399140
	public void SendFusionList(); // 0x0000000180399600-0x0000000180399660
	public void SendFusionUse(long fusionUserPetId); // 0x0000000180399660-0x00000001803996D0
	public void NotifyBossEvolved(); // 0x0000000180397160-0x0000000180397170
	public void NotifyBossEvolved(int petId); // 0x0000000180397140-0x0000000180397160
	public int ResolveBossDisplayPetId(int fallbackPetId = 0 /* Metadata: 0x0068B342 */); // 0x0000000180399260-0x0000000180399290
	public bool TryGetFusionGhost(int actorNumber, out int fusionPetId); // 0x0000000180399A40-0x0000000180399B80
	private void HandleMatchStart(ChatMessageDTO m); // 0x0000000180395FF0-0x0000000180396120
	private void HandleMatchResync(ChatMessageDTO m); // 0x0000000180395F50-0x0000000180395FA0
	private void ApplyMatchInitFromMessage(ChatMessageDTO m); // 0x0000000180392F50-0x0000000180393830
	private void HandleMatchMoveRes(ChatMessageDTO m); // 0x0000000180395AC0-0x0000000180395B10
	private void HandleMatchCardUseRes(ChatMessageDTO m); // 0x0000000180395780-0x00000001803957D0
	private void HandleMatchSkillUseRes(ChatMessageDTO m); // 0x0000000180395FA0-0x0000000180395FF0
	private void HandleFusionListRes(ChatMessageDTO m); // 0x00000001803952F0-0x0000000180395350
	private void HandleFusionRes(ChatMessageDTO m); // 0x0000000180395350-0x0000000180395550
	private static CardData ParseFusionSkillCard(Dictionary<string, object> p, string key); // 0x0000000180397DE0-0x0000000180397FA0
	private static CardData ParseFusionSkillCardFromMap(Dictionary<string, object> p, string username); // 0x0000000180397A60-0x0000000180397DE0
	private void HandleResEnvelope(ChatMessageDTO m, string kind); // 0x0000000180396A70-0x0000000180396C90
	private void HandleMatchReject(ChatMessageDTO m); // 0x0000000180395DB0-0x0000000180395F50
	private void HandleMatchTurnEnd(ChatMessageDTO m); // 0x00000001803962A0-0x00000001803966E0
	private void HandleMatchAfkWarn(ChatMessageDTO m); // 0x00000001803955E0-0x0000000180395780
	private void HandleMatchTimerTick(ChatMessageDTO m); // 0x0000000180396120-0x00000001803962A0
	private void HandleMatchPlayerLeft(ChatMessageDTO m); // 0x0000000180395B10-0x0000000180395CB0
	private void HandleMatchPlayerRejoin(ChatMessageDTO m); // 0x0000000180395CB0-0x0000000180395CE0
	private void HandleMatchReadyState(ChatMessageDTO m); // 0x0000000180395CE0-0x0000000180395DB0
	private void HandleMatchGameOver(ChatMessageDTO m); // 0x00000001803957D0-0x0000000180395AC0
	[IteratorStateMachine(typeof(_FlushGameOverWhenPresentationDone_d__447))]
	private IEnumerator FlushGameOverWhenPresentationDone(); // 0x0000000180394DE0-0x0000000180394E50
	private void FlushDeferredGameOver(bool force = false /* Metadata: 0x0068B343 */); // 0x0000000180394D20-0x0000000180394DE0
	private void HandleSkillCast(ChatMessageDTO m); // 0x0000000180396C90-0x0000000180396CF0
	private void HandleBossAction(ChatMessageDTO m); // 0x0000000180395190-0x00000001803951F0
	private void ApplyStateDelta(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x0000000180393F50-0x0000000180394030
	private void ParsePlayersSnapshot(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x0000000180398240-0x0000000180398870
	private void MergeIncomingPlayer(string playerName, MatchPlayerSnapshotDTO incoming, bool isFull); // 0x0000000180396ED0-0x0000000180397140
	private List<MatchOpDTO> ParseOps(ChatMessageDTO m); // 0x0000000180398190-0x0000000180398240
	private List<MatchOpDTO> ParseOps(Dictionary<string, object> payload); // 0x0000000180397FA0-0x0000000180398190
	private static string ReadString(Dictionary<string, object> p, string key, string fb = null); // 0x0000000180398E60-0x0000000180398F00
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0068B344 */); // 0x0000000180398AC0-0x0000000180398BE0
	private static int? ReadOptionalInt(Dictionary<string, object> p, string key); // 0x0000000180398D00-0x0000000180398E60
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x0068B345 */); // 0x0000000180398BE0-0x0000000180398D00
	private static bool ReadBool(Dictionary<string, object> p, string key, bool fb = false /* Metadata: 0x0068B34D */); // 0x00000001803989B0-0x0000000180398AC0
	public bool IsLocalTurn(); // 0x0000000180396E40-0x0000000180396ED0
}

