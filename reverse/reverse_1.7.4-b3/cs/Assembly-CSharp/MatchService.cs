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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class MatchService : MonoBehaviour // TypeDefIndex: 540
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
	private long _GuildRaidId_k__BackingField; // 0x58
	[CompilerGenerated]
	private long _RaidClosesAtMs_k__BackingField; // 0x60
	[CompilerGenerated]
	private long _RaidHpMax_k__BackingField; // 0x68
	[CompilerGenerated]
	private long _RaidRunDamage_k__BackingField; // 0x70
	[CompilerGenerated]
	private long _RaidMyDamage_k__BackingField; // 0x78
	[CompilerGenerated]
	private int _RaidMyRank_k__BackingField; // 0x80
	[CompilerGenerated]
	private int _RaidAttemptsLeft_k__BackingField; // 0x84
	[CompilerGenerated]
	private bool _RaidLive_k__BackingField; // 0x88
	[CompilerGenerated]
	private long _RaidHpCurrent_k__BackingField; // 0x90
	[CompilerGenerated]
	private bool _FusionEnabled_k__BackingField; // 0x98
	[CompilerGenerated]
	private int _FusionManaCost_k__BackingField; // 0x9C
	[CompilerGenerated]
	private int _FusionStatPercent_k__BackingField; // 0xA0
	[CompilerGenerated]
	private bool _LocalFusionUsed_k__BackingField; // 0xA4
	[CompilerGenerated]
	private int _LocalFusionLastAttemptTurn_k__BackingField; // 0xA8
	[CompilerGenerated]
	private long _LocalFusionSelectedUserPetId_k__BackingField; // 0xB0
	[CompilerGenerated]
	private long _LocalFusionSelectedPetId_k__BackingField; // 0xB8
	[CompilerGenerated]
	private CardData _LocalFusionSkillCard_k__BackingField; // 0xC0
	[CompilerGenerated]
	private string _LocalFusionDropReason_k__BackingField; // 0xC8
	[CompilerGenerated]
	private bool _FusionPityEnabled_k__BackingField; // 0xD0
	[CompilerGenerated]
	private int _FusionPityStep_k__BackingField; // 0xD4
	[CompilerGenerated]
	private int _FusionPityMax_k__BackingField; // 0xD8
	[CompilerGenerated]
	private int _FusionPityGuarantee_k__BackingField; // 0xDC
	[CompilerGenerated]
	private int _LocalFusionPityPercent_k__BackingField; // 0xE0
	[CompilerGenerated]
	private int _LocalFusionPityFails_k__BackingField; // 0xE4
	[CompilerGenerated]
	private int _ServerBossDisplayPetId_k__BackingField; // 0xE8
	[CompilerGenerated]
	private int _ServerBossFinalPetId_k__BackingField; // 0xEC
	[CompilerGenerated]
	private bool _ServerBossEvolved_k__BackingField; // 0xF0
	[CompilerGenerated]
	private int _BossMana_k__BackingField; // 0xF4
	[CompilerGenerated]
	private int _BossManaMax_k__BackingField; // 0xF8
	[CompilerGenerated]
	private int _BossPower_k__BackingField; // 0xFC
	[CompilerGenerated]
	private int _BossPowerMax_k__BackingField; // 0x100
	[CompilerGenerated]
	private int _BossShield_k__BackingField; // 0x104
	[CompilerGenerated]
	private static int _PrepHpBonusPct_k__BackingField; // 0x08
	[CompilerGenerated]
	private static int _PrepManaBonus_k__BackingField; // 0x0C
	[CompilerGenerated]
	private static int _PrepPowerMax_k__BackingField; // 0x10
	[CompilerGenerated]
	private Dictionary<string, MatchPlayerSnapshotDTO> _Players_k__BackingField; // 0x108
	private long _localSeqNum; // 0x110
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0x118
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0x120
	[CompilerGenerated]
	private Action<List<MatchOpDTO>> OnOpsApplied; // 0x128
	[CompilerGenerated]
	private Action<string> OnMatchReject; // 0x130
	[CompilerGenerated]
	private Action OnTurnEnd; // 0x138
	[CompilerGenerated]
	private Action<string> OnGameOver; // 0x140
	[CompilerGenerated]
	private Action<string, bool, string> OnPlayerLeft; // 0x148
	[CompilerGenerated]
	private Action<string> OnPlayerRejoin; // 0x150
	[CompilerGenerated]
	private Action<string, int, int> OnAfkWarn; // 0x158
	[CompilerGenerated]
	private Action<string, int> OnAfkForfeit; // 0x160
	[CompilerGenerated]
	private Action<string, int, int> OnTimerTick; // 0x168
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionList; // 0x170
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionResolved; // 0x178
	[CompilerGenerated]
	private Action<int, int, int> OnFusionPityChanged; // 0x180
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnGuildBossHp; // 0x188
	[CompilerGenerated]
	private int _TurnTimeRemainingSec_k__BackingField; // 0x190
	[CompilerGenerated]
	private int _LastAnnounceHoldMs_k__BackingField; // 0x194
	[CompilerGenerated]
	private int _TowerFloor_k__BackingField; // 0x198
	[CompilerGenerated]
	private int _TowerTurnLimit_k__BackingField; // 0x19C
	[CompilerGenerated]
	private int _TowerTurnsLeft_k__BackingField; // 0x1A0
	[CompilerGenerated]
	private Action<int> OnTowerTurnsChanged; // 0x1A8
	[CompilerGenerated]
	private bool _HasBossDeadline_k__BackingField; // 0x1B0
	private int _bossDeadlineAnchorSec; // 0x1B4
	private float _bossDeadlineAnchorAt; // 0x1B8
	[CompilerGenerated]
	private bool _HasServerClock_k__BackingField; // 0x1BC
	[CompilerGenerated]
	private bool _ClockPaused_k__BackingField; // 0x1BD
	[CompilerGenerated]
	private string _ClockPauseReason_k__BackingField; // 0x1C0
	private float _clockRemainAtAnchorSec; // 0x1C8
	private float _clockAnchorUnscaled; // 0x1CC
	private bool _startGateSeen; // 0x1D0
	[CompilerGenerated]
	private Action OnStartGateClosed; // 0x1D8
	[CompilerGenerated]
	private Action<int, int> OnReadyStateChanged; // 0x1E0
	private float _localFxHoldUntilUnscaled; // 0x1E8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnSkillCast; // 0x1F0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnBossAction; // 0x1F8
	[CompilerGenerated]
	private WsCombatBatch _PendingCombat_k__BackingField; // 0x200
	private int _inFlightBatches; // 0x208
	private readonly HashSet<long> _ackedSeqs; // 0x210
	[CompilerGenerated]
	private int _ServerAckDeadlineSec_k__BackingField; // 0x218
	private const float AckStuckGuardFallbackSec = 9f; // Metadata: 0x005EE20C
	private const float AckStuckGuardMarginSec = 1.5f; // Metadata: 0x005EE210
	private Func<bool> _rendererBusyProbe; // 0x220
	[CompilerGenerated]
	private int _ServerBossHp_k__BackingField; // 0x228
	[CompilerGenerated]
	private Dictionary<string, ServerPlayerStats> _ServerStats_k__BackingField; // 0x230
	[CompilerGenerated]
	private Action OnServerStateChanged; // 0x238
	private bool _wsCfgSubscribed; // 0x240
	private bool _guildBossHpSubscribed; // 0x241
	private bool _subscribed; // 0x242
	private bool _matchOver; // 0x243
	private Coroutine _resyncCoroutine; // 0x248
	[CompilerGenerated]
	private int _LastMoveFromCol_k__BackingField; // 0x250
	[CompilerGenerated]
	private int _LastMoveFromRow_k__BackingField; // 0x254
	[CompilerGenerated]
	private int _LastMoveToCol_k__BackingField; // 0x258
	[CompilerGenerated]
	private int _LastMoveToRow_k__BackingField; // 0x25C
	[CompilerGenerated]
	private long _LastMoveSeqNum_k__BackingField; // 0x260
	private int _shadowDamageSnapshot; // 0x268
	private long _shadowLastReportedSeq; // 0x270
	[CompilerGenerated]
	private List<string> _ServerQteArrows_k__BackingField; // 0x278
	[CompilerGenerated]
	private int _ServerQteDurationMs_k__BackingField; // 0x280
	[CompilerGenerated]
	private QteWindow _ServerQteWindow_k__BackingField; // 0x284
	[CompilerGenerated]
	private Action OnQteChallengeReady; // 0x2A0
	[CompilerGenerated]
	private string _ServerQteLayout_k__BackingField; // 0x2A8
	[CompilerGenerated]
	private int _ServerQteReverseFrom_k__BackingField; // 0x2B0
	[CompilerGenerated]
	private int _ServerQteGreatMs_k__BackingField; // 0x2B4
	[CompilerGenerated]
	private float _ServerQteMultPerfect_k__BackingField; // 0x2B8
	[CompilerGenerated]
	private float _ServerQteMultGood_k__BackingField; // 0x2BC
	[CompilerGenerated]
	private float _ServerQteMultBad_k__BackingField; // 0x2C0
	public const int QteUiGeneration = 3; // Metadata: 0x005EE214
	public const int QteUiGenerationLegacy = 2; // Metadata: 0x005EE215
	[CompilerGenerated]
	private long _ServerQteChallengeId_k__BackingField; // 0x2C8
	private int _qteRequestedCardId; // 0x2D0
	private float _qteRequestedAt; // 0x2D4
	private const float QteRequestStaleSec = 6f; // Metadata: 0x005EE216
	[CompilerGenerated]
	private string _LastKnownMatchId_k__BackingField; // 0x2D8
	[CompilerGenerated]
	private string _LastResyncReason_k__BackingField; // 0x2E0
	private static readonly JsonSerializer _payloadSerializer; // 0x18
	[CompilerGenerated]
	private int? _LastRejectCardId_k__BackingField; // 0x2E8
	[CompilerGenerated]
	private string _LastAfkMode_k__BackingField; // 0x2F0
	private string _deferredWinner; // 0x2F8
	private bool _hasDeferredGameOver; // 0x300
	[CompilerGenerated]
	private static string _LastEndedMatchId_k__BackingField; // 0x20
	[CompilerGenerated]
	private string _LastEndReason_k__BackingField; // 0x308
	public const string WINNER_PLAYERS = "__PLAYERS__"; // Metadata: 0x005EE21A
	public const string WINNER_BOSS = "__BOSS__"; // Metadata: 0x005EE226
	public const string WINNER_ABANDONED = "__abandoned"; // Metadata: 0x005EE22F
	public const string WINNER_STALE = "__stale"; // Metadata: 0x005EE23B
	[CompilerGenerated]
	private bool _LastGameOverAborted_k__BackingField; // 0x310
	private const float GameOverRenderWaitMaxSec = 30f; // Metadata: 0x005EE243
	private Coroutine _gameOverFlushCo; // 0x318
	private static readonly JsonSerializer SnapshotSerializer; // 0x28

	// Properties
	public static MatchService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5D80-0x00000001803C5DE0 0x00000001803C5DE0-0x00000001803C5E90
	public static bool UseWsGameplay { get; set; } // 0x000000018028A040-0x000000018028A050 0x000000018028A320-0x000000018028A330
	public static bool UsePvpWs { get; } // 0x000000018028A040-0x000000018028A050 
	public string CurrentMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public string CurrentMatchType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA4E0-0x00000001802BA540
	public int BoardWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5F90-0x00000001803C5FA0 0x00000001803C5FA0-0x00000001803C5FB0
	public int BoardHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5FB0-0x00000001803C5FC0 0x00000001803C5FC0-0x00000001803C5FD0
	public string CurrentTurnPlayer { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x00000001802BA5B0-0x00000001802BA610
	public int TurnNumber { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5FD0-0x00000001803C5FE0 0x00000001803C5FE0-0x00000001803C5FF0
	public int TurnDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5FF0-0x00000001803C6000 0x00000001803C6000-0x00000001803C6010
	public int BossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA680-0x00000001802BA690 0x00000001802BA690-0x00000001802BA6A0
	public int BossHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6010-0x00000001803C6020 0x00000001803C6020-0x00000001803C6030
	public int ServerBossPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6030-0x00000001803C6040 0x00000001803C6040-0x00000001803C6050
	public long GuildRaidId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456E0-0x00000001803456F0 0x00000001803C6050-0x00000001803C6060
	public long RaidClosesAtMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039E720-0x000000018039E730 0x00000001803C6060-0x00000001803C6070
	public long RaidHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456F0-0x0000000180345700 0x00000001803C6070-0x00000001803C6080
	public long RaidRunDamage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6080-0x00000001803C6090 0x00000001803C6090-0x00000001803C60A0
	public long RaidMyDamage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A86B0-0x00000001802A86C0 0x00000001803C60A0-0x00000001803C60B0
	public int RaidMyRank { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C60B0-0x00000001803C60C0 0x00000001803C60C0-0x00000001803C60D0
	public int RaidAttemptsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C60D0-0x00000001803C60E0 0x00000001803C60E0-0x00000001803C60F0
	public bool RaidLive { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C60F0-0x00000001803C6100 0x00000001803C6100-0x00000001803C6110
	public long RaidHpCurrent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8D40-0x00000001802D8D50 0x00000001803C6110-0x00000001803C6120
	public bool IsGuildBossMatch { get; } // 0x00000001803C6120-0x00000001803C6210 
	public bool FusionEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6210-0x00000001803C6220 0x00000001803C6220-0x00000001803C6230
	public int FusionManaCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6230-0x00000001803C6240 0x00000001803C6240-0x00000001803C6250
	public int FusionStatPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6250-0x00000001803C6260 0x00000001803C6260-0x00000001803C6270
	public bool LocalFusionUsed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6270-0x00000001803C6280 0x00000001803C6280-0x00000001803C6290
	public int LocalFusionLastAttemptTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6390-0x00000001803C63A0 0x00000001803C63A0-0x00000001803C63B0
	public bool LocalFusionLockedThisTurn { get; } // 0x00000001803C63B0-0x00000001803C63D0 
	public long LocalFusionSelectedUserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8F00-0x00000001802D8F10 0x00000001803C63D0-0x00000001803C63E0
	public long LocalFusionSelectedPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8F70-0x00000001802D8F80 0x00000001803C63E0-0x00000001803C63F0
	public CardData LocalFusionSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8FE0-0x00000001802D8FF0 0x00000001802D8FF0-0x00000001802D9050
	public string LocalFusionDropReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D9050-0x00000001802D9060 0x00000001802D9060-0x00000001802D90C0
	public bool FusionPityEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C63F0-0x00000001803C6400 0x00000001803C6400-0x00000001803C6410
	public int FusionPityStep { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6410-0x00000001803C6420 0x00000001803C6420-0x00000001803C6430
	public int FusionPityMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6430-0x00000001803C6440 0x00000001803C6440-0x00000001803C6450
	public int FusionPityGuarantee { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6450-0x00000001803C6460 0x00000001803C6460-0x00000001803C6470
	public int LocalFusionPityPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6470-0x00000001803C6480 0x00000001803C6480-0x00000001803C6490
	public int LocalFusionPityFails { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6490-0x00000001803C64A0 0x00000001803C64A0-0x00000001803C64B0
	public int ServerBossDisplayPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C64B0-0x00000001803C64C0 0x00000001803C64C0-0x00000001803C64D0
	public int ServerBossFinalPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C64D0-0x00000001803C64E0 0x00000001803C64E0-0x00000001803C64F0
	public bool ServerBossEvolved { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C64F0-0x00000001803C6500 0x00000001803C6500-0x00000001803C6510
	public int BossMana { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6510-0x00000001803C6520 0x00000001803C6520-0x00000001803C6530
	public int BossManaMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6530-0x00000001803C6540 0x00000001803C6540-0x00000001803C6550
	public int BossPower { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6550-0x00000001803C6560 0x00000001803C6560-0x00000001803C6570
	public int BossPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6570-0x00000001803C6580 0x00000001803C6580-0x00000001803C6590
	public int BossShield { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6590-0x00000001803C65A0 0x00000001803C65A0-0x00000001803C65B0
	public static int PrepHpBonusPct { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C65B0-0x00000001803C6610 0x00000001803C6610-0x00000001803C6670
	public static int PrepManaBonus { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6670-0x00000001803C66D0 0x00000001803C66D0-0x00000001803C6730
	public static int PrepPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6730-0x00000001803C6790 0x00000001803C6790-0x00000001803C67F0
	public Dictionary<string, MatchPlayerSnapshotDTO> Players { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6CD0-0x00000001803C6CE0 0x00000001803C6CE0-0x00000001803C6D40
	public int TurnTimeRemainingSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C8EC0-0x00000001803C8ED0 0x00000001803C8ED0-0x00000001803C8EE0
	public int LastAnnounceHoldMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C8EE0-0x00000001803C8EF0 0x00000001803C8EF0-0x00000001803C8F00
	public int TowerFloor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C8F00-0x00000001803C8F10 0x00000001803C8F10-0x00000001803C8F20
	public int TowerTurnLimit { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C8F20-0x00000001803C8F30 0x00000001803C8F30-0x00000001803C8F40
	public int TowerTurnsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C8F40-0x00000001803C8F50 0x00000001803C8F50-0x00000001803C8F60
	public bool HasBossDeadline { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345740-0x0000000180345750 0x00000001803C9380-0x00000001803C9390
	public int BossDeadlineRemainingSec { get; } // 0x00000001803C9390-0x00000001803C9420 
	public bool HasServerClock { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9420-0x00000001803C9430 0x00000001803C9430-0x00000001803C9440
	public bool ClockPaused { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9440-0x00000001803C9450 0x00000001803C9450-0x00000001803C9460
	public string ClockPauseReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9460-0x00000001803C9470 0x00000001803C9470-0x00000001803C94D0
	public bool IsStartGatePaused { get; } // 0x00000001803C94D0-0x00000001803C9560 
	public float ServerTurnRemainingSec { get; } // 0x00000001803C99A0-0x00000001803C9A90 
	private bool IsLocalFxHold { get; } // 0x00000001803C9A90-0x00000001803C9AF0 
	public WsCombatBatch PendingCombat { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CA2E0-0x00000001803CA2F0 0x00000001803CA2F0-0x00000001803CA350
	public int ServerAckDeadlineSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CAB00-0x00000001803CAB10 0x00000001803CAB10-0x00000001803CAB20
	private float AckStuckGuardSec { get; } // 0x00000001803CAB20-0x00000001803CAB60 
	public bool IsRenderingCombat { get; } // 0x00000001803CAFC0-0x00000001803CAFD0 
	public bool IsPresentationBusy { get; } // 0x00000001803CB0D0-0x00000001803CB110 
	public int ServerBossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CB110-0x00000001803CB120 0x00000001803CB120-0x00000001803CB130
	public Dictionary<string, ServerPlayerStats> ServerStats { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CB130-0x00000001803CB140 0x00000001803CB140-0x00000001803CB1A0
	public int LastMoveFromCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CFCB0-0x00000001803CFCC0 0x00000001803CFCC0-0x00000001803CFCD0
	public int LastMoveFromRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CFCD0-0x00000001803CFCE0 0x00000001803CFCE0-0x00000001803CFCF0
	public int LastMoveToCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CFCF0-0x00000001803CFD00 0x00000001803CFD00-0x00000001803CFD10
	public int LastMoveToRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CFD10-0x00000001803CFD20 0x00000001803CFD20-0x00000001803CFD30
	public long LastMoveSeqNum { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CFD30-0x00000001803CFD40 0x00000001803CFD40-0x00000001803CFD50
	public List<string> ServerQteArrows { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0830-0x00000001803D0840 0x00000001803D0840-0x00000001803D08A0
	public int ServerQteDurationMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D08A0-0x00000001803D08B0 0x00000001803D08B0-0x00000001803D08C0
	public QteWindow ServerQteWindow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D08C0-0x00000001803D08F0 0x00000001803D08F0-0x00000001803D0920
	public string ServerQteLayout { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0B20-0x00000001803D0B30 0x00000001803D0B30-0x00000001803D0B90
	public int ServerQteReverseFrom { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0B90-0x00000001803D0BA0 0x00000001803D0BA0-0x00000001803D0BB0
	public int ServerQteGreatMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0BB0-0x00000001803D0BC0 0x00000001803D0BC0-0x00000001803D0BD0
	public float ServerQteMultPerfect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0BD0-0x00000001803D0BE0 0x00000001803D0BE0-0x00000001803D0BF0
	public float ServerQteMultGood { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0BF0-0x00000001803D0C00 0x00000001803D0C00-0x00000001803D0C10
	public float ServerQteMultBad { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0C10-0x00000001803D0C20 0x00000001803D0C20-0x00000001803D0C30
	public long ServerQteChallengeId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0C30-0x00000001803D0C40 0x00000001803D0C40-0x00000001803D0C50
	public string LastKnownMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D18A0-0x00000001803D18B0 0x00000001803D18B0-0x00000001803D1910
	public string LastResyncReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1910-0x00000001803D1920 0x00000001803D1920-0x00000001803D1980
	public int? LastRejectCardId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D4470-0x00000001803D4480 0x00000001803D4480-0x00000001803D4490
	public string LastAfkMode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D4F00-0x00000001803D4F10 0x00000001803D4F10-0x00000001803D4F70
	public static string LastEndedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D5480-0x00000001803D54E0 0x00000001803D54E0-0x00000001803D55A0
	public string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D55A0-0x00000001803D55B0 0x00000001803D55B0-0x00000001803D5610
	public bool LastGameOverAborted { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D5830-0x00000001803D5840 0x00000001803D5840-0x00000001803D5850

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803C6D40-0x00000001803C6E60
		remove; // 0x00000001803C6E60-0x00000001803C6F80
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x00000001803C6F80-0x00000001803C70A0
		remove; // 0x00000001803C70A0-0x00000001803C71C0
	}
	public event Action<List<MatchOpDTO>> OnOpsApplied {
		add; // 0x00000001803C71C0-0x00000001803C72E0
		remove; // 0x00000001803C72E0-0x00000001803C7400
	}
	public event Action<string> OnMatchReject {
		add; // 0x00000001803C7400-0x00000001803C7520
		remove; // 0x00000001803C7520-0x00000001803C7640
	}
	public event Action OnTurnEnd {
		add; // 0x00000001803C7640-0x00000001803C7740
		remove; // 0x00000001803C7740-0x00000001803C7840
	}
	public event Action<string> OnGameOver {
		add; // 0x00000001803C7840-0x00000001803C7960
		remove; // 0x00000001803C7960-0x00000001803C7A80
	}
	public event Action<string, bool, string> OnPlayerLeft {
		add; // 0x00000001803C7A80-0x00000001803C7BA0
		remove; // 0x00000001803C7BA0-0x00000001803C7CC0
	}
	public event Action<string> OnPlayerRejoin {
		add; // 0x00000001803C7CC0-0x00000001803C7DE0
		remove; // 0x00000001803C7DE0-0x00000001803C7F00
	}
	public event Action<string, int, int> OnAfkWarn {
		add; // 0x00000001803C7F00-0x00000001803C8020
		remove; // 0x00000001803C8020-0x00000001803C8140
	}
	public event Action<string, int> OnAfkForfeit {
		add; // 0x00000001803C8140-0x00000001803C8260
		remove; // 0x00000001803C8260-0x00000001803C8380
	}
	public event Action<string, int, int> OnTimerTick {
		add; // 0x00000001803C8380-0x00000001803C84A0
		remove; // 0x00000001803C84A0-0x00000001803C85C0
	}
	public event Action<ChatMessageDTO> OnFusionList {
		add; // 0x00000001803C85C0-0x00000001803C86E0
		remove; // 0x00000001803C86E0-0x00000001803C8800
	}
	public event Action<ChatMessageDTO> OnFusionResolved {
		add; // 0x00000001803C8800-0x00000001803C8920
		remove; // 0x00000001803C8920-0x00000001803C8A40
	}
	public event Action<int, int, int> OnFusionPityChanged {
		add; // 0x00000001803C8A40-0x00000001803C8B60
		remove; // 0x00000001803C8B60-0x00000001803C8C80
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x00000001803C8C80-0x00000001803C8DA0
		remove; // 0x00000001803C8DA0-0x00000001803C8EC0
	}
	public event Action<int> OnTowerTurnsChanged {
		add; // 0x00000001803C8F60-0x00000001803C9080
		remove; // 0x00000001803C9080-0x00000001803C91A0
	}
	public event Action OnStartGateClosed {
		add; // 0x00000001803C9560-0x00000001803C9660
		remove; // 0x00000001803C9660-0x00000001803C9760
	}
	public event Action<int, int> OnReadyStateChanged {
		add; // 0x00000001803C9760-0x00000001803C9880
		remove; // 0x00000001803C9880-0x00000001803C99A0
	}
	public event Action<ChatMessageDTO> OnSkillCast {
		add; // 0x00000001803C9E60-0x00000001803C9F80
		remove; // 0x00000001803C9F80-0x00000001803CA0A0
	}
	public event Action<ChatMessageDTO> OnBossAction {
		add; // 0x00000001803CA0A0-0x00000001803CA1C0
		remove; // 0x00000001803CA1C0-0x00000001803CA2E0
	}
	public event Action OnServerStateChanged {
		add; // 0x00000001803CB1A0-0x00000001803CB2A0
		remove; // 0x00000001803CB2A0-0x00000001803CB3A0
	}
	public event Action OnQteChallengeReady {
		add; // 0x00000001803D0920-0x00000001803D0A20
		remove; // 0x00000001803D0A20-0x00000001803D0B20
	}

	// Nested types
	public class ServerPlayerStats // TypeDefIndex: 541
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
		public ServerPlayerStats(); // 0x000000018028A320-0x000000018028A330
	}

	public struct QteWindow // TypeDefIndex: 542
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
		public bool Valid { get; } // 0x00000001803D8680-0x00000001803D86A0 
	}

	[CompilerGenerated]
	private sealed class _AckStuckGuard_d__338 : IEnumerator<object> // TypeDefIndex: 543
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		public long srvSeq; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AckStuckGuard_d__338(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803D86A0-0x00000001803D88A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D88A0-0x00000001803D88E0
	}

	[CompilerGenerated]
	private sealed class _FetchFeatureFlags_d__374 : IEnumerator<object> // TypeDefIndex: 544
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchFeatureFlags_d__374(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D88E0-0x00000001803D8A10
		private bool MoveNext(); // 0x00000001803D8A10-0x00000001803D8FC0
		private void __m__Finally1(); // 0x00000001803D8FC0-0x00000001803D9020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D9020-0x00000001803D9060
	}

	[CompilerGenerated]
	private sealed class _FlushGameOverWhenPresentationDone_d__539 : IEnumerator<object> // TypeDefIndex: 545
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlushGameOverWhenPresentationDone_d__539(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803D9060-0x00000001803D9490
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D9490-0x00000001803D94D0
	}

	[CompilerGenerated]
	private sealed class _ResyncAfterReconnect_d__385 : IEnumerator<object> // TypeDefIndex: 546
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResyncAfterReconnect_d__385(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803D94D0-0x00000001803D9780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D9780-0x00000001803D97C0
	}

	// Constructors
	public MatchService(); // 0x00000001803D7C30-0x00000001803D7FF0
	static MatchService(); // 0x00000001803D7FF0-0x00000001803D8680

	// Methods
	public static void ApplyServerFlag(bool serverFlag); // 0x00000001803C5E90-0x00000001803C5F10
	public static void ApplyPvpWsFlag(bool serverFlag); // 0x00000001803C5F10-0x00000001803C5F90
	public int SkillCooldownLeftFor(int cardId); // 0x00000001803C6290-0x00000001803C6390
	public static int PrepMaxHp(int baseHp); // 0x00000001803C67F0-0x00000001803C68B0
	public static int PrepMaxMana(int baseMana); // 0x00000001803C68B0-0x00000001803C6950
	public static void ResetPrepStatFrame(); // 0x00000001803C6950-0x00000001803C6A90
	public static void ApplyPrepStatFrame(int? hpBonusPct, int? manaBonus, int? powerMax); // 0x00000001803C6A90-0x00000001803C6C50
	public static void ApplyPrepStatFrame(MatchPrepDataDTO prep); // 0x00000001803C6C50-0x00000001803C6CD0
	private void ApplyTowerFields(Dictionary<string, object> p, bool reset = false /* Metadata: 0x005EE1EE */); // 0x00000001803C91A0-0x00000001803C9380
	public void BeginLocalFxHold(float sec); // 0x00000001803C9AF0-0x00000001803C9C10
	private void ClearLocalFxHold(); // 0x00000001803C9C10-0x00000001803C9C20
	private void ApplyTimingFields(Dictionary<string, object> p); // 0x00000001803C9C20-0x00000001803C9E60
	public WsCombatBatch ConsumePendingCombat(); // 0x00000001803CA350-0x00000001803CA3C0
	private WsCombatBatch ParseCombatBatch(ChatMessageDTO m, string kind); // 0x00000001803CA3C0-0x00000001803CAB00
	private void BeginAnimAck(long srvSeq, bool hasWork); // 0x00000001803CAB60-0x00000001803CAC50
	[IteratorStateMachine(typeof(_AckStuckGuard_d__338))]
	private IEnumerator AckStuckGuard(long srvSeq); // 0x00000001803CAC50-0x00000001803CAD10
	public void NotifyRenderComplete(long srvSeq); // 0x00000001803CAD10-0x00000001803CAD30
	public void NotifyRenderAckEarly(long srvSeq); // 0x00000001803CAD30-0x00000001803CAD40
	private void SendAnimAck(long srvSeq); // 0x00000001803CAD40-0x00000001803CAFC0
	public void RegisterRendererBusyProbe(Func<bool> probe); // 0x00000001803CAFD0-0x00000001803CB030
	public void UnregisterRendererBusyProbe(Func<bool> probe); // 0x00000001803CB030-0x00000001803CB0D0
	public void ApplyServerStat(string username, string stat, int newValue); // 0x00000001803CB3A0-0x00000001803CB800
	public void ApplyServerBossHp(int newHp); // 0x00000001803CB800-0x00000001803CB830
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803CB830-0x00000001803CBA00
	private void Awake(); // 0x00000001803CBA00-0x00000001803CBDB0
	private void TrySubscribeWsConfig(); // 0x00000001803CBDB0-0x00000001803CC080
	private void TrySubscribeGuildBossHp(); // 0x00000001803CC080-0x00000001803CC350
	private void UnsubscribeGuildBossHp(); // 0x00000001803CC350-0x00000001803CC5E0
	private void HandleGuildBossHpMessage(ChatMessageDTO m); // 0x00000001803CC5E0-0x00000001803CC640
	private void ApplyGuildRaidFields(Dictionary<string, object> p); // 0x00000001803CC640-0x00000001803CC800
	private void ApplyGuildRaidEndStats(ChatMessageDTO m); // 0x00000001803CC800-0x00000001803CCB30
	private void HandleWsConfig(ChatMessageDTO m); // 0x00000001803CCB30-0x00000001803CCC90
	[IteratorStateMachine(typeof(_FetchFeatureFlags_d__374))]
	private IEnumerator FetchFeatureFlags(); // 0x00000001803CCC90-0x00000001803CCCD0
	private void Start(); // 0x00000001803CCCD0-0x00000001803CCCE0
	private void OnEnable(); // 0x00000001803CCCD0-0x00000001803CCCE0
	private void OnDisable(); // 0x00000001803CCCE0-0x00000001803CCCF0
	private void OnDestroy(); // 0x00000001803CCCF0-0x00000001803CCEB0
	private void TrySubscribeChat(); // 0x00000001803CCEB0-0x00000001803CE440
	private void UnsubscribeChat(); // 0x00000001803CE440-0x00000001803CF9A0
	private void HandleConnectionChanged(bool connected); // 0x00000001803CF9A0-0x00000001803CFAE0
	[IteratorStateMachine(typeof(_ResyncAfterReconnect_d__385))]
	private IEnumerator ResyncAfterReconnect(); // 0x00000001803CFAE0-0x00000001803CFB80
	public void ClearCurrentMatch(); // 0x00000001803CFB80-0x00000001803CFCB0
	public void SendMove(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001803CFD50-0x00000001803CFFC0
	private void FlushShadowReportForLastMove(long seqToReport); // 0x00000001803CFFC0-0x00000001803D0630
	public void SendCardUse(int cardId, int? cardTarget = default); // 0x00000001803D0630-0x00000001803D06C0
	public void SendSkillUse(int skillCardId, int correctDotCount = 0 /* Metadata: 0x005EE1EF */, string timingResult = "BAD" /* Metadata: 0x005EE1F0 */, int dotsToDestroy = 0 /* Metadata: 0x005EE1F4 */, List<int> selectedRows = null, List<List<int>> selectedDots = null, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x00000001803D06C0-0x00000001803D0830
	public void AbandonQteChallenge(); // 0x00000001803D0C50-0x00000001803D0C60
	private void ClearQteChallenge(); // 0x00000001803D0C60-0x00000001803D0D50
	public void RequestQteChallenge(int skillCardId); // 0x00000001803D0D50-0x00000001803D0F60
	public void SendQteTap(int elapsedMs); // 0x00000001803D0F60-0x00000001803D1050
	public void EnsureQteChallenge(int skillCardId); // 0x00000001803D1050-0x00000001803D1120
	private void HandleQteChallenge(ChatMessageDTO m); // 0x00000001803D1120-0x00000001803D1700
	public void SendClientReady(); // 0x00000001803D1700-0x00000001803D17C0
	public void SendDragPause(); // 0x00000001803D17C0-0x00000001803D1830
	public void SendDragResume(); // 0x00000001803D1830-0x00000001803D18A0
	public void RequestResync(string reason = "manual" /* Metadata: 0x005EE1F5 */); // 0x00000001803D1980-0x00000001803D1B90
	public void SendFusionList(); // 0x00000001803D1B90-0x00000001803D1C50
	public void SendFusionUse(long fusionUserPetId); // 0x00000001803D1C50-0x00000001803D1D20
	public void NotifyBossEvolved(); // 0x00000001803D1D20-0x00000001803D1D30
	public void NotifyBossEvolved(int petId); // 0x00000001803D1D30-0x00000001803D1D50
	public int ResolveBossDisplayPetId(int fallbackPetId = 0 /* Metadata: 0x005EE1FC */); // 0x00000001803D1D50-0x00000001803D1D80
	public bool TryGetFusionPity(int actorNumber, out int percent, out int fails); // 0x00000001803D1D80-0x00000001803D1F00
	public MatchPlayerSnapshotDTO LocalSnapshot(); // 0x00000001803D1F00-0x00000001803D1FC0
	private int ResolveActorNumber(string username); // 0x00000001803D1FC0-0x00000001803D2060
	public bool TryGetFusionGhost(int actorNumber, out int fusionPetId); // 0x00000001803D2060-0x00000001803D21D0
	private void HandleMatchStart(ChatMessageDTO m); // 0x00000001803D21D0-0x00000001803D2610
	private static bool IsAnyMatchSceneLoaded(); // 0x00000001803D2610-0x00000001803D2820
	private void HandleMatchResync(ChatMessageDTO m); // 0x00000001803D2820-0x00000001803D2870
	private void ApplyMatchInitFromMessage(ChatMessageDTO m); // 0x00000001803D2870-0x00000001803D34A0
	private void HandleMatchMoveRes(ChatMessageDTO m); // 0x00000001803D34A0-0x00000001803D3500
	private void HandleMatchCardUseRes(ChatMessageDTO m); // 0x00000001803D3500-0x00000001803D3560
	private void HandleMatchSkillUseRes(ChatMessageDTO m); // 0x00000001803D3560-0x00000001803D35C0
	private void HandleFusionListRes(ChatMessageDTO m); // 0x00000001803D35C0-0x00000001803D3640
	private void HandleFusionRes(ChatMessageDTO m); // 0x00000001803D3640-0x00000001803D3B40
	private static CardData ParseFusionSkillCard(Dictionary<string, object> p, string key); // 0x00000001803D3B40-0x00000001803D3D20
	private static CardData ParseFusionSkillCardFromMap(Dictionary<string, object> p, string username); // 0x00000001803D3D20-0x00000001803D4160
	private void HandleResEnvelope(ChatMessageDTO m, string kind); // 0x00000001803D4160-0x00000001803D4470
	private void HandleMatchReject(ChatMessageDTO m); // 0x00000001803D4490-0x00000001803D46B0
	private void HandleMatchTurnEnd(ChatMessageDTO m); // 0x00000001803D46B0-0x00000001803D4CC0
	private void HandleMatchAfkWarn(ChatMessageDTO m); // 0x00000001803D4CC0-0x00000001803D4F00
	private void HandleMatchTimerTick(ChatMessageDTO m); // 0x00000001803D4F70-0x00000001803D5140
	private void HandleMatchPlayerLeft(ChatMessageDTO m); // 0x00000001803D5140-0x00000001803D5360
	private void HandleMatchPlayerRejoin(ChatMessageDTO m); // 0x00000001803D5360-0x00000001803D5390
	private void HandleMatchReadyState(ChatMessageDTO m); // 0x00000001803D5390-0x00000001803D5480
	public static bool IsAbortedWinner(string winner); // 0x00000001803D5610-0x00000001803D5830
	private void HandleMatchGameOver(ChatMessageDTO m); // 0x00000001803D5850-0x00000001803D5EE0
	[IteratorStateMachine(typeof(_FlushGameOverWhenPresentationDone_d__539))]
	private IEnumerator FlushGameOverWhenPresentationDone(); // 0x00000001803D5EE0-0x00000001803D5F80
	private void FlushDeferredGameOver(bool force = false /* Metadata: 0x005EE1FD */); // 0x00000001803D5F80-0x00000001803D60D0
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001803D60D0-0x00000001803D6150
	private void HandleBossAction(ChatMessageDTO m); // 0x00000001803D6150-0x00000001803D61D0
	private void ApplyStateDelta(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x00000001803D61D0-0x00000001803D6350
	private void ParsePlayersSnapshot(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x00000001803D6350-0x00000001803D6A50
	private void MergeIncomingPlayer(string playerName, MatchPlayerSnapshotDTO incoming, bool isFull); // 0x00000001803D6A50-0x00000001803D6DF0
	private List<MatchOpDTO> ParseOps(ChatMessageDTO m); // 0x00000001803D6DF0-0x00000001803D6EB0
	private List<MatchOpDTO> ParseOps(Dictionary<string, object> payload); // 0x00000001803D6EB0-0x00000001803D70D0
	private static string ReadString(Dictionary<string, object> p, string key, string fb = null); // 0x00000001803D70D0-0x00000001803D7180
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x00000001803D7180-0x00000001803D7390
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005EE1FE */); // 0x00000001803D7390-0x00000001803D74B0
	private static int? ReadOptionalInt(Dictionary<string, object> p, string key); // 0x00000001803D74B0-0x00000001803D7610
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x005EE1FF */); // 0x00000001803D7610-0x00000001803D7740
	private static bool ReadBool(Dictionary<string, object> p, string key, bool fb = false /* Metadata: 0x005EE207 */); // 0x00000001803D7740-0x00000001803D78B0
	private static float ReadFloat(Dictionary<string, object> p, string key, float fb = 0f /* Metadata: 0x005EE208 */); // 0x00000001803D78B0-0x00000001803D7B10
	public bool IsLocalTurn(); // 0x00000001803D7B10-0x00000001803D7C30
}

