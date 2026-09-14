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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MatchService : MonoBehaviour // TypeDefIndex: 541
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
	private const float AckStuckGuardFallbackSec = 9f; // Metadata: 0x005EF5DD
	private const float AckStuckGuardMarginSec = 1.5f; // Metadata: 0x005EF5E1
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
	public const int QteUiGeneration = 3; // Metadata: 0x005EF5E5
	public const int QteUiGenerationLegacy = 2; // Metadata: 0x005EF5E6
	[CompilerGenerated]
	private long _ServerQteChallengeId_k__BackingField; // 0x2C8
	private int _qteRequestedCardId; // 0x2D0
	private float _qteRequestedAt; // 0x2D4
	private const float QteRequestStaleSec = 6f; // Metadata: 0x005EF5E7
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
	public const string WINNER_PLAYERS = "__PLAYERS__"; // Metadata: 0x005EF5EB
	public const string WINNER_BOSS = "__BOSS__"; // Metadata: 0x005EF5F7
	public const string WINNER_ABANDONED = "__abandoned"; // Metadata: 0x005EF600
	public const string WINNER_STALE = "__stale"; // Metadata: 0x005EF60C
	[CompilerGenerated]
	private bool _LastGameOverAborted_k__BackingField; // 0x310
	private const float GameOverRenderWaitMaxSec = 30f; // Metadata: 0x005EF614
	private Coroutine _gameOverFlushCo; // 0x318
	private static readonly JsonSerializer SnapshotSerializer; // 0x28

	// Properties
	public static MatchService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6A50-0x00000001803C6AB0 0x00000001803C6AB0-0x00000001803C6B60
	public static bool UseWsGameplay { get; set; } // 0x000000018028A040-0x000000018028A050 0x000000018028A320-0x000000018028A330
	public static bool UsePvpWs { get; } // 0x000000018028A040-0x000000018028A050 
	public string CurrentMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public string CurrentMatchType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA510-0x00000001802BA570
	public int BoardWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6C60-0x00000001803C6C70 0x00000001803C6C70-0x00000001803C6C80
	public int BoardHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6C80-0x00000001803C6C90 0x00000001803C6C90-0x00000001803C6CA0
	public string CurrentTurnPlayer { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x00000001802BA5E0-0x00000001802BA640
	public int TurnNumber { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6CA0-0x00000001803C6CB0 0x00000001803C6CB0-0x00000001803C6CC0
	public int TurnDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6CC0-0x00000001803C6CD0 0x00000001803C6CD0-0x00000001803C6CE0
	public int BossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA6B0-0x00000001802BA6C0 0x00000001802BA6C0-0x00000001802BA6D0
	public int BossHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6CE0-0x00000001803C6CF0 0x00000001803C6CF0-0x00000001803C6D00
	public int ServerBossPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D00-0x00000001803C6D10 0x00000001803C6D10-0x00000001803C6D20
	public long GuildRaidId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345800-0x0000000180345810 0x00000001803C6D20-0x00000001803C6D30
	public long RaidClosesAtMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039E8F0-0x000000018039E900 0x00000001803C6D30-0x00000001803C6D40
	public long RaidHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345810-0x0000000180345820 0x00000001803C6D40-0x00000001803C6D50
	public long RaidRunDamage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D50-0x00000001803C6D60 0x00000001803C6D60-0x00000001803C6D70
	public long RaidMyDamage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A86B0-0x00000001802A86C0 0x00000001803C6D70-0x00000001803C6D80
	public int RaidMyRank { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D80-0x00000001803C6D90 0x00000001803C6D90-0x00000001803C6DA0
	public int RaidAttemptsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6DA0-0x00000001803C6DB0 0x00000001803C6DB0-0x00000001803C6DC0
	public bool RaidLive { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6DC0-0x00000001803C6DD0 0x00000001803C6DD0-0x00000001803C6DE0
	public long RaidHpCurrent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8D70-0x00000001802D8D80 0x00000001803C6DE0-0x00000001803C6DF0
	public bool IsGuildBossMatch { get; } // 0x00000001803C6DF0-0x00000001803C6EE0 
	public bool FusionEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6EE0-0x00000001803C6EF0 0x00000001803C6EF0-0x00000001803C6F00
	public int FusionManaCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6F00-0x00000001803C6F10 0x00000001803C6F10-0x00000001803C6F20
	public int FusionStatPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6F20-0x00000001803C6F30 0x00000001803C6F30-0x00000001803C6F40
	public bool LocalFusionUsed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6F40-0x00000001803C6F50 0x00000001803C6F50-0x00000001803C6F60
	public int LocalFusionLastAttemptTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7060-0x00000001803C7070 0x00000001803C7070-0x00000001803C7080
	public bool LocalFusionLockedThisTurn { get; } // 0x00000001803C7080-0x00000001803C70A0 
	public long LocalFusionSelectedUserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8F30-0x00000001802D8F40 0x00000001803C70A0-0x00000001803C70B0
	public long LocalFusionSelectedPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8FA0-0x00000001802D8FB0 0x00000001803C70B0-0x00000001803C70C0
	public CardData LocalFusionSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D9010-0x00000001802D9020 0x00000001802D9020-0x00000001802D9080
	public string LocalFusionDropReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D9080-0x00000001802D9090 0x00000001802D9090-0x00000001802D90F0
	public bool FusionPityEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C70C0-0x00000001803C70D0 0x00000001803C70D0-0x00000001803C70E0
	public int FusionPityStep { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C70E0-0x00000001803C70F0 0x00000001803C70F0-0x00000001803C7100
	public int FusionPityMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7100-0x00000001803C7110 0x00000001803C7110-0x00000001803C7120
	public int FusionPityGuarantee { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7120-0x00000001803C7130 0x00000001803C7130-0x00000001803C7140
	public int LocalFusionPityPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7140-0x00000001803C7150 0x00000001803C7150-0x00000001803C7160
	public int LocalFusionPityFails { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7160-0x00000001803C7170 0x00000001803C7170-0x00000001803C7180
	public int ServerBossDisplayPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7180-0x00000001803C7190 0x00000001803C7190-0x00000001803C71A0
	public int ServerBossFinalPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C71A0-0x00000001803C71B0 0x00000001803C71B0-0x00000001803C71C0
	public bool ServerBossEvolved { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C71C0-0x00000001803C71D0 0x00000001803C71D0-0x00000001803C71E0
	public int BossMana { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C71E0-0x00000001803C71F0 0x00000001803C71F0-0x00000001803C7200
	public int BossManaMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7200-0x00000001803C7210 0x00000001803C7210-0x00000001803C7220
	public int BossPower { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7220-0x00000001803C7230 0x00000001803C7230-0x00000001803C7240
	public int BossPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7240-0x00000001803C7250 0x00000001803C7250-0x00000001803C7260
	public int BossShield { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7260-0x00000001803C7270 0x00000001803C7270-0x00000001803C7280
	public static int PrepHpBonusPct { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7280-0x00000001803C72E0 0x00000001803C72E0-0x00000001803C7340
	public static int PrepManaBonus { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7340-0x00000001803C73A0 0x00000001803C73A0-0x00000001803C7400
	public static int PrepPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C7400-0x00000001803C7460 0x00000001803C7460-0x00000001803C74C0
	public Dictionary<string, MatchPlayerSnapshotDTO> Players { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C79A0-0x00000001803C79B0 0x00000001803C79B0-0x00000001803C7A10
	public int TurnTimeRemainingSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9B90-0x00000001803C9BA0 0x00000001803C9BA0-0x00000001803C9BB0
	public int LastAnnounceHoldMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9BB0-0x00000001803C9BC0 0x00000001803C9BC0-0x00000001803C9BD0
	public int TowerFloor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9BD0-0x00000001803C9BE0 0x00000001803C9BE0-0x00000001803C9BF0
	public int TowerTurnLimit { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9BF0-0x00000001803C9C00 0x00000001803C9C00-0x00000001803C9C10
	public int TowerTurnsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C9C10-0x00000001803C9C20 0x00000001803C9C20-0x00000001803C9C30
	public bool HasBossDeadline { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345860-0x0000000180345870 0x00000001803CA050-0x00000001803CA060
	public int BossDeadlineRemainingSec { get; } // 0x00000001803CA060-0x00000001803CA0F0 
	public bool HasServerClock { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CA0F0-0x00000001803CA100 0x00000001803CA100-0x00000001803CA110
	public bool ClockPaused { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CA110-0x00000001803CA120 0x00000001803CA120-0x00000001803CA130
	public string ClockPauseReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CA130-0x00000001803CA140 0x00000001803CA140-0x00000001803CA1A0
	public bool IsStartGatePaused { get; } // 0x00000001803CA1A0-0x00000001803CA230 
	public float ServerTurnRemainingSec { get; } // 0x00000001803CA670-0x00000001803CA760 
	private bool IsLocalFxHold { get; } // 0x00000001803CA760-0x00000001803CA7C0 
	public WsCombatBatch PendingCombat { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CAFB0-0x00000001803CAFC0 0x00000001803CAFC0-0x00000001803CB020
	public int ServerAckDeadlineSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CB7D0-0x00000001803CB7E0 0x00000001803CB7E0-0x00000001803CB7F0
	private float AckStuckGuardSec { get; } // 0x00000001803CB7F0-0x00000001803CB830 
	public bool IsRenderingCombat { get; } // 0x00000001803CBC90-0x00000001803CBCA0 
	public bool IsPresentationBusy { get; } // 0x00000001803CBDA0-0x00000001803CBDE0 
	public int ServerBossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CBDE0-0x00000001803CBDF0 0x00000001803CBDF0-0x00000001803CBE00
	public Dictionary<string, ServerPlayerStats> ServerStats { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803CBE00-0x00000001803CBE10 0x00000001803CBE10-0x00000001803CBE70
	public int LastMoveFromCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0980-0x00000001803D0990 0x00000001803D0990-0x00000001803D09A0
	public int LastMoveFromRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D09A0-0x00000001803D09B0 0x00000001803D09B0-0x00000001803D09C0
	public int LastMoveToCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D09C0-0x00000001803D09D0 0x00000001803D09D0-0x00000001803D09E0
	public int LastMoveToRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D09E0-0x00000001803D09F0 0x00000001803D09F0-0x00000001803D0A00
	public long LastMoveSeqNum { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D0A00-0x00000001803D0A10 0x00000001803D0A10-0x00000001803D0A20
	public List<string> ServerQteArrows { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1500-0x00000001803D1510 0x00000001803D1510-0x00000001803D1570
	public int ServerQteDurationMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1570-0x00000001803D1580 0x00000001803D1580-0x00000001803D1590
	public QteWindow ServerQteWindow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1590-0x00000001803D15C0 0x00000001803D15C0-0x00000001803D15F0
	public string ServerQteLayout { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D17F0-0x00000001803D1800 0x00000001803D1800-0x00000001803D1860
	public int ServerQteReverseFrom { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1860-0x00000001803D1870 0x00000001803D1870-0x00000001803D1880
	public int ServerQteGreatMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1880-0x00000001803D1890 0x00000001803D1890-0x00000001803D18A0
	public float ServerQteMultPerfect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D18A0-0x00000001803D18B0 0x00000001803D18B0-0x00000001803D18C0
	public float ServerQteMultGood { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D18C0-0x00000001803D18D0 0x00000001803D18D0-0x00000001803D18E0
	public float ServerQteMultBad { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D18E0-0x00000001803D18F0 0x00000001803D18F0-0x00000001803D1900
	public long ServerQteChallengeId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D1900-0x00000001803D1910 0x00000001803D1910-0x00000001803D1920
	public string LastKnownMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D2570-0x00000001803D2580 0x00000001803D2580-0x00000001803D25E0
	public string LastResyncReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D25E0-0x00000001803D25F0 0x00000001803D25F0-0x00000001803D2650
	public int? LastRejectCardId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D5140-0x00000001803D5150 0x00000001803D5150-0x00000001803D5160
	public string LastAfkMode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D5C40-0x00000001803D5C50 0x00000001803D5C50-0x00000001803D5CB0
	public static string LastEndedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D61C0-0x00000001803D6220 0x00000001803D6220-0x00000001803D62E0
	public string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D62E0-0x00000001803D62F0 0x00000001803D62F0-0x00000001803D6350
	public bool LastGameOverAborted { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803D6570-0x00000001803D6580 0x00000001803D6580-0x00000001803D6590

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803C7A10-0x00000001803C7B30
		remove; // 0x00000001803C7B30-0x00000001803C7C50
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x00000001803C7C50-0x00000001803C7D70
		remove; // 0x00000001803C7D70-0x00000001803C7E90
	}
	public event Action<List<MatchOpDTO>> OnOpsApplied {
		add; // 0x00000001803C7E90-0x00000001803C7FB0
		remove; // 0x00000001803C7FB0-0x00000001803C80D0
	}
	public event Action<string> OnMatchReject {
		add; // 0x00000001803C80D0-0x00000001803C81F0
		remove; // 0x00000001803C81F0-0x00000001803C8310
	}
	public event Action OnTurnEnd {
		add; // 0x00000001803C8310-0x00000001803C8410
		remove; // 0x00000001803C8410-0x00000001803C8510
	}
	public event Action<string> OnGameOver {
		add; // 0x00000001803C8510-0x00000001803C8630
		remove; // 0x00000001803C8630-0x00000001803C8750
	}
	public event Action<string, bool, string> OnPlayerLeft {
		add; // 0x00000001803C8750-0x00000001803C8870
		remove; // 0x00000001803C8870-0x00000001803C8990
	}
	public event Action<string> OnPlayerRejoin {
		add; // 0x00000001803C8990-0x00000001803C8AB0
		remove; // 0x00000001803C8AB0-0x00000001803C8BD0
	}
	public event Action<string, int, int> OnAfkWarn {
		add; // 0x00000001803C8BD0-0x00000001803C8CF0
		remove; // 0x00000001803C8CF0-0x00000001803C8E10
	}
	public event Action<string, int> OnAfkForfeit {
		add; // 0x00000001803C8E10-0x00000001803C8F30
		remove; // 0x00000001803C8F30-0x00000001803C9050
	}
	public event Action<string, int, int> OnTimerTick {
		add; // 0x00000001803C9050-0x00000001803C9170
		remove; // 0x00000001803C9170-0x00000001803C9290
	}
	public event Action<ChatMessageDTO> OnFusionList {
		add; // 0x00000001803C9290-0x00000001803C93B0
		remove; // 0x00000001803C93B0-0x00000001803C94D0
	}
	public event Action<ChatMessageDTO> OnFusionResolved {
		add; // 0x00000001803C94D0-0x00000001803C95F0
		remove; // 0x00000001803C95F0-0x00000001803C9710
	}
	public event Action<int, int, int> OnFusionPityChanged {
		add; // 0x00000001803C9710-0x00000001803C9830
		remove; // 0x00000001803C9830-0x00000001803C9950
	}
	public event Action<ChatMessageDTO> OnGuildBossHp {
		add; // 0x00000001803C9950-0x00000001803C9A70
		remove; // 0x00000001803C9A70-0x00000001803C9B90
	}
	public event Action<int> OnTowerTurnsChanged {
		add; // 0x00000001803C9C30-0x00000001803C9D50
		remove; // 0x00000001803C9D50-0x00000001803C9E70
	}
	public event Action OnStartGateClosed {
		add; // 0x00000001803CA230-0x00000001803CA330
		remove; // 0x00000001803CA330-0x00000001803CA430
	}
	public event Action<int, int> OnReadyStateChanged {
		add; // 0x00000001803CA430-0x00000001803CA550
		remove; // 0x00000001803CA550-0x00000001803CA670
	}
	public event Action<ChatMessageDTO> OnSkillCast {
		add; // 0x00000001803CAB30-0x00000001803CAC50
		remove; // 0x00000001803CAC50-0x00000001803CAD70
	}
	public event Action<ChatMessageDTO> OnBossAction {
		add; // 0x00000001803CAD70-0x00000001803CAE90
		remove; // 0x00000001803CAE90-0x00000001803CAFB0
	}
	public event Action OnServerStateChanged {
		add; // 0x00000001803CBE70-0x00000001803CBF70
		remove; // 0x00000001803CBF70-0x00000001803CC070
	}
	public event Action OnQteChallengeReady {
		add; // 0x00000001803D15F0-0x00000001803D16F0
		remove; // 0x00000001803D16F0-0x00000001803D17F0
	}

	// Nested types
	public class ServerPlayerStats // TypeDefIndex: 542
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

	public struct QteWindow // TypeDefIndex: 543
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
		public bool Valid { get; } // 0x00000001803D93C0-0x00000001803D93E0 
	}

	[CompilerGenerated]
	private sealed class _AckStuckGuard_d__338 : IEnumerator<object> // TypeDefIndex: 544
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803D93E0-0x00000001803D95E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D95E0-0x00000001803D9620
	}

	[CompilerGenerated]
	private sealed class _FetchFeatureFlags_d__374 : IEnumerator<object> // TypeDefIndex: 545
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
		void IDisposable.Dispose(); // 0x00000001803D9620-0x00000001803D9750
		private bool MoveNext(); // 0x00000001803D9750-0x00000001803D9D00
		private void __m__Finally1(); // 0x00000001803D9D00-0x00000001803D9D60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D9D60-0x00000001803D9DA0
	}

	[CompilerGenerated]
	private sealed class _FlushGameOverWhenPresentationDone_d__539 : IEnumerator<object> // TypeDefIndex: 546
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803D9DA0-0x00000001803DA1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803DA1D0-0x00000001803DA210
	}

	[CompilerGenerated]
	private sealed class _ResyncAfterReconnect_d__385 : IEnumerator<object> // TypeDefIndex: 547
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803DA210-0x00000001803DA4C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803DA4C0-0x00000001803DA500
	}

	// Constructors
	public MatchService(); // 0x00000001803D8970-0x00000001803D8D30
	static MatchService(); // 0x00000001803D8D30-0x00000001803D93C0

	// Methods
	public static void ApplyServerFlag(bool serverFlag); // 0x00000001803C6B60-0x00000001803C6BE0
	public static void ApplyPvpWsFlag(bool serverFlag); // 0x00000001803C6BE0-0x00000001803C6C60
	public int SkillCooldownLeftFor(int cardId); // 0x00000001803C6F60-0x00000001803C7060
	public static int PrepMaxHp(int baseHp); // 0x00000001803C74C0-0x00000001803C7580
	public static int PrepMaxMana(int baseMana); // 0x00000001803C7580-0x00000001803C7620
	public static void ResetPrepStatFrame(); // 0x00000001803C7620-0x00000001803C7760
	public static void ApplyPrepStatFrame(int? hpBonusPct, int? manaBonus, int? powerMax); // 0x00000001803C7760-0x00000001803C7920
	public static void ApplyPrepStatFrame(MatchPrepDataDTO prep); // 0x00000001803C7920-0x00000001803C79A0
	private void ApplyTowerFields(Dictionary<string, object> p, bool reset = false /* Metadata: 0x005EF5BF */); // 0x00000001803C9E70-0x00000001803CA050
	public void BeginLocalFxHold(float sec); // 0x00000001803CA7C0-0x00000001803CA8E0
	private void ClearLocalFxHold(); // 0x00000001803CA8E0-0x00000001803CA8F0
	private void ApplyTimingFields(Dictionary<string, object> p); // 0x00000001803CA8F0-0x00000001803CAB30
	public WsCombatBatch ConsumePendingCombat(); // 0x00000001803CB020-0x00000001803CB090
	private WsCombatBatch ParseCombatBatch(ChatMessageDTO m, string kind); // 0x00000001803CB090-0x00000001803CB7D0
	private void BeginAnimAck(long srvSeq, bool hasWork); // 0x00000001803CB830-0x00000001803CB920
	[IteratorStateMachine(typeof(_AckStuckGuard_d__338))]
	private IEnumerator AckStuckGuard(long srvSeq); // 0x00000001803CB920-0x00000001803CB9E0
	public void NotifyRenderComplete(long srvSeq); // 0x00000001803CB9E0-0x00000001803CBA00
	public void NotifyRenderAckEarly(long srvSeq); // 0x00000001803CBA00-0x00000001803CBA10
	private void SendAnimAck(long srvSeq); // 0x00000001803CBA10-0x00000001803CBC90
	public void RegisterRendererBusyProbe(Func<bool> probe); // 0x00000001803CBCA0-0x00000001803CBD00
	public void UnregisterRendererBusyProbe(Func<bool> probe); // 0x00000001803CBD00-0x00000001803CBDA0
	public void ApplyServerStat(string username, string stat, int newValue); // 0x00000001803CC070-0x00000001803CC4D0
	public void ApplyServerBossHp(int newHp); // 0x00000001803CC4D0-0x00000001803CC500
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803CC500-0x00000001803CC6D0
	private void Awake(); // 0x00000001803CC6D0-0x00000001803CCA80
	private void TrySubscribeWsConfig(); // 0x00000001803CCA80-0x00000001803CCD50
	private void TrySubscribeGuildBossHp(); // 0x00000001803CCD50-0x00000001803CD020
	private void UnsubscribeGuildBossHp(); // 0x00000001803CD020-0x00000001803CD2B0
	private void HandleGuildBossHpMessage(ChatMessageDTO m); // 0x00000001803CD2B0-0x00000001803CD310
	private void ApplyGuildRaidFields(Dictionary<string, object> p); // 0x00000001803CD310-0x00000001803CD4D0
	private void ApplyGuildRaidEndStats(ChatMessageDTO m); // 0x00000001803CD4D0-0x00000001803CD800
	private void HandleWsConfig(ChatMessageDTO m); // 0x00000001803CD800-0x00000001803CD960
	[IteratorStateMachine(typeof(_FetchFeatureFlags_d__374))]
	private IEnumerator FetchFeatureFlags(); // 0x00000001803CD960-0x00000001803CD9A0
	private void Start(); // 0x00000001803CD9A0-0x00000001803CD9B0
	private void OnEnable(); // 0x00000001803CD9A0-0x00000001803CD9B0
	private void OnDisable(); // 0x00000001803CD9B0-0x00000001803CD9C0
	private void OnDestroy(); // 0x00000001803CD9C0-0x00000001803CDB80
	private void TrySubscribeChat(); // 0x00000001803CDB80-0x00000001803CF110
	private void UnsubscribeChat(); // 0x00000001803CF110-0x00000001803D0670
	private void HandleConnectionChanged(bool connected); // 0x00000001803D0670-0x00000001803D07B0
	[IteratorStateMachine(typeof(_ResyncAfterReconnect_d__385))]
	private IEnumerator ResyncAfterReconnect(); // 0x00000001803D07B0-0x00000001803D0850
	public void ClearCurrentMatch(); // 0x00000001803D0850-0x00000001803D0980
	public void SendMove(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001803D0A20-0x00000001803D0C90
	private void FlushShadowReportForLastMove(long seqToReport); // 0x00000001803D0C90-0x00000001803D1300
	public void SendCardUse(int cardId, int? cardTarget = default); // 0x00000001803D1300-0x00000001803D1390
	public void SendSkillUse(int skillCardId, int correctDotCount = 0 /* Metadata: 0x005EF5C0 */, string timingResult = "BAD" /* Metadata: 0x005EF5C1 */, int dotsToDestroy = 0 /* Metadata: 0x005EF5C5 */, List<int> selectedRows = null, List<List<int>> selectedDots = null, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x00000001803D1390-0x00000001803D1500
	public void AbandonQteChallenge(); // 0x00000001803D1920-0x00000001803D1930
	private void ClearQteChallenge(); // 0x00000001803D1930-0x00000001803D1A20
	public void RequestQteChallenge(int skillCardId); // 0x00000001803D1A20-0x00000001803D1C30
	public void SendQteTap(int elapsedMs); // 0x00000001803D1C30-0x00000001803D1D20
	public void EnsureQteChallenge(int skillCardId); // 0x00000001803D1D20-0x00000001803D1DF0
	private void HandleQteChallenge(ChatMessageDTO m); // 0x00000001803D1DF0-0x00000001803D23D0
	public void SendClientReady(); // 0x00000001803D23D0-0x00000001803D2490
	public void SendDragPause(); // 0x00000001803D2490-0x00000001803D2500
	public void SendDragResume(); // 0x00000001803D2500-0x00000001803D2570
	public void RequestResync(string reason = "manual" /* Metadata: 0x005EF5C6 */); // 0x00000001803D2650-0x00000001803D2860
	public void SendFusionList(); // 0x00000001803D2860-0x00000001803D2920
	public void SendFusionUse(long fusionUserPetId); // 0x00000001803D2920-0x00000001803D29F0
	public void NotifyBossEvolved(); // 0x00000001803D29F0-0x00000001803D2A00
	public void NotifyBossEvolved(int petId); // 0x00000001803D2A00-0x00000001803D2A20
	public int ResolveBossDisplayPetId(int fallbackPetId = 0 /* Metadata: 0x005EF5CD */); // 0x00000001803D2A20-0x00000001803D2A50
	public bool TryGetFusionPity(int actorNumber, out int percent, out int fails); // 0x00000001803D2A50-0x00000001803D2BD0
	public MatchPlayerSnapshotDTO LocalSnapshot(); // 0x00000001803D2BD0-0x00000001803D2C90
	private int ResolveActorNumber(string username); // 0x00000001803D2C90-0x00000001803D2D30
	public bool TryGetFusionGhost(int actorNumber, out int fusionPetId); // 0x00000001803D2D30-0x00000001803D2EA0
	private void HandleMatchStart(ChatMessageDTO m); // 0x00000001803D2EA0-0x00000001803D32E0
	private static bool IsAnyMatchSceneLoaded(); // 0x00000001803D32E0-0x00000001803D34F0
	private void HandleMatchResync(ChatMessageDTO m); // 0x00000001803D34F0-0x00000001803D3540
	private void ApplyMatchInitFromMessage(ChatMessageDTO m); // 0x00000001803D3540-0x00000001803D4170
	private void HandleMatchMoveRes(ChatMessageDTO m); // 0x00000001803D4170-0x00000001803D41D0
	private void HandleMatchCardUseRes(ChatMessageDTO m); // 0x00000001803D41D0-0x00000001803D4230
	private void HandleMatchSkillUseRes(ChatMessageDTO m); // 0x00000001803D4230-0x00000001803D4290
	private void HandleFusionListRes(ChatMessageDTO m); // 0x00000001803D4290-0x00000001803D4310
	private void HandleFusionRes(ChatMessageDTO m); // 0x00000001803D4310-0x00000001803D4810
	private static CardData ParseFusionSkillCard(Dictionary<string, object> p, string key); // 0x00000001803D4810-0x00000001803D49F0
	private static CardData ParseFusionSkillCardFromMap(Dictionary<string, object> p, string username); // 0x00000001803D49F0-0x00000001803D4E30
	private void HandleResEnvelope(ChatMessageDTO m, string kind); // 0x00000001803D4E30-0x00000001803D5140
	private void HandleMatchReject(ChatMessageDTO m); // 0x00000001803D5160-0x00000001803D5380
	private void HandleMatchTurnEnd(ChatMessageDTO m); // 0x00000001803D5380-0x00000001803D5A00
	private void HandleMatchAfkWarn(ChatMessageDTO m); // 0x00000001803D5A00-0x00000001803D5C40
	private void HandleMatchTimerTick(ChatMessageDTO m); // 0x00000001803D5CB0-0x00000001803D5E80
	private void HandleMatchPlayerLeft(ChatMessageDTO m); // 0x00000001803D5E80-0x00000001803D60A0
	private void HandleMatchPlayerRejoin(ChatMessageDTO m); // 0x00000001803D60A0-0x00000001803D60D0
	private void HandleMatchReadyState(ChatMessageDTO m); // 0x00000001803D60D0-0x00000001803D61C0
	public static bool IsAbortedWinner(string winner); // 0x00000001803D6350-0x00000001803D6570
	private void HandleMatchGameOver(ChatMessageDTO m); // 0x00000001803D6590-0x00000001803D6C20
	[IteratorStateMachine(typeof(_FlushGameOverWhenPresentationDone_d__539))]
	private IEnumerator FlushGameOverWhenPresentationDone(); // 0x00000001803D6C20-0x00000001803D6CC0
	private void FlushDeferredGameOver(bool force = false /* Metadata: 0x005EF5CE */); // 0x00000001803D6CC0-0x00000001803D6E10
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001803D6E10-0x00000001803D6E90
	private void HandleBossAction(ChatMessageDTO m); // 0x00000001803D6E90-0x00000001803D6F10
	private void ApplyStateDelta(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x00000001803D6F10-0x00000001803D7090
	private void ParsePlayersSnapshot(Dictionary<string, object> payload, ChatMessageDTO m = null); // 0x00000001803D7090-0x00000001803D7790
	private void MergeIncomingPlayer(string playerName, MatchPlayerSnapshotDTO incoming, bool isFull); // 0x00000001803D7790-0x00000001803D7B30
	private List<MatchOpDTO> ParseOps(ChatMessageDTO m); // 0x00000001803D7B30-0x00000001803D7BF0
	private List<MatchOpDTO> ParseOps(Dictionary<string, object> payload); // 0x00000001803D7BF0-0x00000001803D7E10
	private static string ReadString(Dictionary<string, object> p, string key, string fb = null); // 0x00000001803D7E10-0x00000001803D7EC0
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x00000001803D7EC0-0x00000001803D80D0
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005EF5CF */); // 0x00000001803D80D0-0x00000001803D81F0
	private static int? ReadOptionalInt(Dictionary<string, object> p, string key); // 0x00000001803D81F0-0x00000001803D8350
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x005EF5D0 */); // 0x00000001803D8350-0x00000001803D8480
	private static bool ReadBool(Dictionary<string, object> p, string key, bool fb = false /* Metadata: 0x005EF5D8 */); // 0x00000001803D8480-0x00000001803D85F0
	private static float ReadFloat(Dictionary<string, object> p, string key, float fb = 0f /* Metadata: 0x005EF5D9 */); // 0x00000001803D85F0-0x00000001803D8850
	public bool IsLocalTurn(); // 0x00000001803D8850-0x00000001803D8970
}

