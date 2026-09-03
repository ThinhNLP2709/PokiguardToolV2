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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MatchService : MonoBehaviour // TypeDefIndex: 418
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
	private bool _FusionEnabled_k__BackingField; // 0x54
	[CompilerGenerated]
	private int _FusionManaCost_k__BackingField; // 0x58
	[CompilerGenerated]
	private int _FusionStatPercent_k__BackingField; // 0x5C
	[CompilerGenerated]
	private bool _LocalFusionUsed_k__BackingField; // 0x60
	[CompilerGenerated]
	private int _LocalFusionLastAttemptTurn_k__BackingField; // 0x64
	[CompilerGenerated]
	private long _LocalFusionSelectedUserPetId_k__BackingField; // 0x68
	[CompilerGenerated]
	private long _LocalFusionSelectedPetId_k__BackingField; // 0x70
	[CompilerGenerated]
	private CardData _LocalFusionSkillCard_k__BackingField; // 0x78
	[CompilerGenerated]
	private string _LocalFusionDropReason_k__BackingField; // 0x80
	[CompilerGenerated]
	private int _ServerBossDisplayPetId_k__BackingField; // 0x88
	[CompilerGenerated]
	private int _ServerBossFinalPetId_k__BackingField; // 0x8C
	[CompilerGenerated]
	private bool _ServerBossEvolved_k__BackingField; // 0x90
	[CompilerGenerated]
	private int _BossMana_k__BackingField; // 0x94
	[CompilerGenerated]
	private int _BossManaMax_k__BackingField; // 0x98
	[CompilerGenerated]
	private int _BossPower_k__BackingField; // 0x9C
	[CompilerGenerated]
	private int _BossPowerMax_k__BackingField; // 0xA0
	[CompilerGenerated]
	private int _BossShield_k__BackingField; // 0xA4
	[CompilerGenerated]
	private static int _PrepHpBonusPct_k__BackingField; // 0x08
	[CompilerGenerated]
	private static int _PrepManaBonus_k__BackingField; // 0x0C
	[CompilerGenerated]
	private static int _PrepPowerMax_k__BackingField; // 0x10
	[CompilerGenerated]
	private Dictionary<string, MatchPlayerSnapshotDTO> _Players_k__BackingField; // 0xA8
	private long _localSeqNum; // 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0xB8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0xC0
	[CompilerGenerated]
	private Action<List<MatchOpDTO>> OnOpsApplied; // 0xC8
	[CompilerGenerated]
	private Action<string> OnMatchReject; // 0xD0
	[CompilerGenerated]
	private Action OnTurnEnd; // 0xD8
	[CompilerGenerated]
	private Action<string> OnGameOver; // 0xE0
	[CompilerGenerated]
	private Action<string, bool, string> OnPlayerLeft; // 0xE8
	[CompilerGenerated]
	private Action<string> OnPlayerRejoin; // 0xF0
	[CompilerGenerated]
	private Action<string, int, int> OnAfkWarn; // 0xF8
	[CompilerGenerated]
	private Action<string, int> OnAfkForfeit; // 0x100
	[CompilerGenerated]
	private Action<string, int, int> OnTimerTick; // 0x108
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionList; // 0x110
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionResolved; // 0x118
	[CompilerGenerated]
	private int _TurnTimeRemainingSec_k__BackingField; // 0x120
	[CompilerGenerated]
	private int _TowerFloor_k__BackingField; // 0x124
	[CompilerGenerated]
	private int _TowerTurnLimit_k__BackingField; // 0x128
	[CompilerGenerated]
	private int _TowerTurnsLeft_k__BackingField; // 0x12C
	[CompilerGenerated]
	private Action<int> OnTowerTurnsChanged; // 0x130
	[CompilerGenerated]
	private bool _HasBossDeadline_k__BackingField; // 0x138
	private int _bossDeadlineAnchorSec; // 0x13C
	private float _bossDeadlineAnchorAt; // 0x140
	[CompilerGenerated]
	private bool _HasServerClock_k__BackingField; // 0x144
	[CompilerGenerated]
	private bool _ClockPaused_k__BackingField; // 0x145
	[CompilerGenerated]
	private string _ClockPauseReason_k__BackingField; // 0x148
	private float _clockRemainAtAnchorSec; // 0x150
	private float _clockAnchorUnscaled; // 0x154
	private bool _startGateSeen; // 0x158
	[CompilerGenerated]
	private Action OnStartGateClosed; // 0x160
	[CompilerGenerated]
	private Action<int, int> OnReadyStateChanged; // 0x168
	private float _localFxHoldUntilUnscaled; // 0x170
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnSkillCast; // 0x178
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnBossAction; // 0x180
	[CompilerGenerated]
	private WsCombatBatch _PendingCombat_k__BackingField; // 0x188
	private int _inFlightBatches; // 0x190
	private readonly HashSet<long> _ackedSeqs; // 0x198
	[CompilerGenerated]
	private int _ServerAckDeadlineSec_k__BackingField; // 0x1A0
	private const float AckStuckGuardFallbackSec = 9f; // Metadata: 0x0064C2D9
	private const float AckStuckGuardMarginSec = 1.5f; // Metadata: 0x0064C2DD
	private Func<bool> _rendererBusyProbe; // 0x1A8
	[CompilerGenerated]
	private int _ServerBossHp_k__BackingField; // 0x1B0
	[CompilerGenerated]
	private Dictionary<string, ServerPlayerStats> _ServerStats_k__BackingField; // 0x1B8
	[CompilerGenerated]
	private Action OnServerStateChanged; // 0x1C0
	private bool _wsCfgSubscribed; // 0x1C8
	private bool _subscribed; // 0x1C9
	private bool _matchOver; // 0x1CA
	private Coroutine _resyncCoroutine; // 0x1D0
	[CompilerGenerated]
	private int _LastMoveFromCol_k__BackingField; // 0x1D8
	[CompilerGenerated]
	private int _LastMoveFromRow_k__BackingField; // 0x1DC
	[CompilerGenerated]
	private int _LastMoveToCol_k__BackingField; // 0x1E0
	[CompilerGenerated]
	private int _LastMoveToRow_k__BackingField; // 0x1E4
	[CompilerGenerated]
	private long _LastMoveSeqNum_k__BackingField; // 0x1E8
	private int _shadowDamageSnapshot; // 0x1F0
	private long _shadowLastReportedSeq; // 0x1F8
	[CompilerGenerated]
	private List<string> _ServerQteArrows_k__BackingField; // 0x200
	[CompilerGenerated]
	private int _ServerQteDurationMs_k__BackingField; // 0x208
	[CompilerGenerated]
	private QteWindow _ServerQteWindow_k__BackingField; // 0x20C
	[CompilerGenerated]
	private Action OnQteChallengeReady; // 0x228
	private static readonly JsonSerializer _payloadSerializer; // 0x18
	[CompilerGenerated]
	private int? _LastRejectCardId_k__BackingField; // 0x230
	[CompilerGenerated]
	private string _LastAfkMode_k__BackingField; // 0x238
	private string _deferredWinner; // 0x240
	private bool _hasDeferredGameOver; // 0x248
	[CompilerGenerated]
	private static string _LastEndedMatchId_k__BackingField; // 0x20
	[CompilerGenerated]
	private string _LastEndReason_k__BackingField; // 0x250
	private const float GameOverRenderWaitMaxSec = 30f; // Metadata: 0x0064C2E1
	private Coroutine _gameOverFlushCo; // 0x258
	private static readonly JsonSerializer SnapshotSerializer; // 0x28

	// Properties
	public static MatchService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D2A0-0x000000018033D2F0 0x000000018033E8B0-0x000000018033E920
	public static bool UseWsGameplay { get; set; } // 0x00000001802E7990-0x00000001802E79A0 0x00000001802E76C0-0x00000001802E76D0
	public static bool UsePvpWs { get; set; } // 0x00000001802E7990-0x00000001802E79A0 0x00000001802E76C0-0x00000001802E76D0
	public string CurrentMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	public string CurrentMatchType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	public int BoardWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
	public int BoardHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
	public string CurrentTurnPlayer { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	public int TurnNumber { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
	public int TurnDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D780-0x000000018033D790 0x000000018033ED00-0x000000018033ED10
	public int BossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
	public int BossHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1B0-0x000000018033D1C0 0x000000018033E790-0x000000018033E7A0
	public int ServerBossPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
	public bool FusionEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D250-0x000000018033D260 0x000000018033E860-0x000000018033E870
	public int FusionManaCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
	public int FusionStatPercent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
	public bool LocalFusionUsed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4F0-0x000000018033D500 0x000000018033EA80-0x000000018033EA90
	public int LocalFusionLastAttemptTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F2020-0x00000001802F2030 0x000000018033EA40-0x000000018033EA50
	public bool LocalFusionLockedThisTurn { get; } // 0x000000018033D4B0-0x000000018033D4D0 
	public long LocalFusionSelectedUserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x000000018033EA60-0x000000018033EA70
	public long LocalFusionSelectedPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4D0-0x000000018033D4E0 0x000000018033EA50-0x000000018033EA60
	public CardData LocalFusionSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
	public string LocalFusionDropReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
	public int ServerBossDisplayPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
	public int ServerBossFinalPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
	public bool ServerBossEvolved { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D630-0x000000018033D640 0x000000018033EC10-0x000000018033EC20
	public int BossMana { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1E0-0x000000018033D1F0 0x000000018033E7C0-0x000000018033E7D0
	public int BossManaMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
	public int BossPower { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D200-0x000000018033D210 0x000000018033E7E0-0x000000018033E7F0
	public int BossPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1F0-0x000000018033D200 0x000000018033E7D0-0x000000018033E7E0
	public int BossShield { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D210-0x000000018033D220 0x000000018033E7F0-0x000000018033E800
	public static int PrepHpBonusPct { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D520-0x000000018033D570 0x000000018033EAD0-0x000000018033EB30
	public static int PrepManaBonus { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D570-0x000000018033D5C0 0x000000018033EB30-0x000000018033EB90
	public static int PrepPowerMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D5C0-0x000000018033D610 0x000000018033EB90-0x000000018033EBF0
	public Dictionary<string, MatchPlayerSnapshotDTO> Players { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
	public int TurnTimeRemainingSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D7A0-0x000000018033D7B0 0x000000018033ED20-0x000000018033ED30
	public int TowerFloor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D750-0x000000018033D760 0x000000018033ECD0-0x000000018033ECE0
	public int TowerTurnLimit { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D760-0x000000018033D770 0x000000018033ECE0-0x000000018033ECF0
	public int TowerTurnsLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D770-0x000000018033D780 0x000000018033ECF0-0x000000018033ED00
	public bool HasBossDeadline { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D280-0x000000018033D290 0x000000018033E890-0x000000018033E8A0
	public int BossDeadlineRemainingSec { get; } // 0x000000018033D110-0x000000018033D1B0 
	public bool HasServerClock { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D290-0x000000018033D2A0 0x000000018033E8A0-0x000000018033E8B0
	public bool ClockPaused { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D230-0x000000018033D240 0x000000018033E820-0x000000018033E830
	public string ClockPauseReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D220-0x000000018033D230 0x000000018033E800-0x000000018033E820
	public bool IsStartGatePaused { get; } // 0x000000018033D370-0x000000018033D3D0 
	public float ServerTurnRemainingSec { get; } // 0x000000018033D6D0-0x000000018033D750 
	private bool IsLocalFxHold { get; } // 0x000000018033D2F0-0x000000018033D320 
	public WsCombatBatch PendingCombat { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D500-0x000000018033D510 0x000000018033EA90-0x000000018033EAB0
	public int ServerAckDeadlineSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D610-0x000000018033D620 0x000000018033EBF0-0x000000018033EC00
	private float AckStuckGuardSec { get; } // 0x000000018033D0B0-0x000000018033D0F0 
	public bool IsRenderingCombat { get; } // 0x000000018033D360-0x000000018033D370 
	public bool IsPresentationBusy { get; } // 0x000000018033D320-0x000000018033D360 
	public int ServerBossHp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D650-0x000000018033D660 0x000000018033EC30-0x000000018033EC40
	public Dictionary<string, ServerPlayerStats> ServerStats { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
	public int LastMoveFromCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D440-0x000000018033D450 0x000000018033E9D0-0x000000018033E9E0
	public int LastMoveFromRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D450-0x000000018033D460 0x000000018033E9E0-0x000000018033E9F0
	public int LastMoveToCol { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D470-0x000000018033D480 0x000000018033EA00-0x000000018033EA10
	public int LastMoveToRow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D480-0x000000018033D490 0x000000018033EA10-0x000000018033EA20
	public long LastMoveSeqNum { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D460-0x000000018033D470 0x000000018033E9F0-0x000000018033EA00
	public List<string> ServerQteArrows { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
	public int ServerQteDurationMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D680-0x000000018033D690 0x000000018033EC70-0x000000018033EC80
	public QteWindow ServerQteWindow { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D690-0x000000018033D6C0 0x000000018033EC80-0x000000018033ECB0
	public int? LastRejectCardId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D490-0x000000018033D4A0 0x000000018033EA20-0x000000018033EA30
	public string LastAfkMode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D3D0-0x000000018033D3E0 0x000000018033E920-0x000000018033E940
	public static string LastEndedMatchId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D3F0-0x000000018033D440 0x000000018033E960-0x000000018033E9D0
	public string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D3E0-0x000000018033D3F0 0x000000018033E940-0x000000018033E960

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x000000018033C770-0x000000018033C840
		remove; // 0x000000018033DE30-0x000000018033DF00
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x000000018033C6A0-0x000000018033C770
		remove; // 0x000000018033DD60-0x000000018033DE30
	}
	public event Action<List<MatchOpDTO>> OnOpsApplied {
		add; // 0x000000018033C840-0x000000018033C910
		remove; // 0x000000018033DF00-0x000000018033DFD0
	}
	public event Action<string> OnMatchReject {
		add; // 0x000000018033C5D0-0x000000018033C6A0
		remove; // 0x000000018033DC90-0x000000018033DD60
	}
	public event Action OnTurnEnd {
		add; // 0x000000018033D000-0x000000018033D0B0
		remove; // 0x000000018033E6C0-0x000000018033E770
	}
	public event Action<string> OnGameOver {
		add; // 0x000000018033C500-0x000000018033C5D0
		remove; // 0x000000018033DBC0-0x000000018033DC90
	}
	public event Action<string, bool, string> OnPlayerLeft {
		add; // 0x000000018033C910-0x000000018033C9E0
		remove; // 0x000000018033DFD0-0x000000018033E0A0
	}
	public event Action<string> OnPlayerRejoin {
		add; // 0x000000018033C9E0-0x000000018033CAB0
		remove; // 0x000000018033E0A0-0x000000018033E170
	}
	public event Action<string, int, int> OnAfkWarn {
		add; // 0x000000018033C1C0-0x000000018033C290
		remove; // 0x000000018033D880-0x000000018033D950
	}
	public event Action<string, int> OnAfkForfeit {
		add; // 0x000000018033C0F0-0x000000018033C1C0
		remove; // 0x000000018033D7B0-0x000000018033D880
	}
	public event Action<string, int, int> OnTimerTick {
		add; // 0x000000018033CE60-0x000000018033CF30
		remove; // 0x000000018033E520-0x000000018033E5F0
	}
	public event Action<ChatMessageDTO> OnFusionList {
		add; // 0x000000018033C360-0x000000018033C430
		remove; // 0x000000018033DA20-0x000000018033DAF0
	}
	public event Action<ChatMessageDTO> OnFusionResolved {
		add; // 0x000000018033C430-0x000000018033C500
		remove; // 0x000000018033DAF0-0x000000018033DBC0
	}
	public event Action<int> OnTowerTurnsChanged {
		add; // 0x000000018033CF30-0x000000018033D000
		remove; // 0x000000018033E5F0-0x000000018033E6C0
	}
	public event Action OnStartGateClosed {
		add; // 0x000000018033CDB0-0x000000018033CE60
		remove; // 0x000000018033E470-0x000000018033E520
	}
	public event Action<int, int> OnReadyStateChanged {
		add; // 0x000000018033CB60-0x000000018033CC30
		remove; // 0x000000018033E220-0x000000018033E2F0
	}
	public event Action<ChatMessageDTO> OnSkillCast {
		add; // 0x000000018033CCE0-0x000000018033CDB0
		remove; // 0x000000018033E3A0-0x000000018033E470
	}
	public event Action<ChatMessageDTO> OnBossAction {
		add; // 0x000000018033C290-0x000000018033C360
		remove; // 0x000000018033D950-0x000000018033DA20
	}
	public event Action OnServerStateChanged {
		add; // 0x000000018033CC30-0x000000018033CCE0
		remove; // 0x000000018033E2F0-0x000000018033E3A0
	}
	public event Action OnQteChallengeReady {
		add; // 0x000000018033CAB0-0x000000018033CB60
		remove; // 0x000000018033E170-0x000000018033E220
	}

	// Nested types
	public class ServerPlayerStats // TypeDefIndex: 419
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
		public ServerPlayerStats(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	public struct QteWindow // TypeDefIndex: 420
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
		public bool Valid { get; } // 0x0000000180340060-0x0000000180340080 
	}

	[CompilerGenerated]
	private sealed class _AckStuckGuard_d__266 : IEnumerator<object> // TypeDefIndex: 421
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		public long srvSeq; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AckStuckGuard_d__266(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180340080-0x0000000180340230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180340230-0x0000000180340270
	}

	[CompilerGenerated]
	private sealed class _FetchFeatureFlags_d__295 : IEnumerator<object> // TypeDefIndex: 422
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchFeatureFlags_d__295(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180340820-0x0000000180340900
		private bool MoveNext(); // 0x0000000180340470-0x00000001803407E0
		private void __m__Finally1(); // 0x0000000180340900-0x0000000180340950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803407E0-0x0000000180340820
	}

	[CompilerGenerated]
	private sealed class _FlushGameOverWhenPresentationDone_d__402 : IEnumerator<object> // TypeDefIndex: 423
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FlushGameOverWhenPresentationDone_d__402(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180340950-0x0000000180340B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180340B40-0x0000000180340B80
	}

	[CompilerGenerated]
	private sealed class _ResyncAfterReconnect_d__306 : IEnumerator<object> // TypeDefIndex: 424
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchService __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResyncAfterReconnect_d__306(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180343800-0x00000001803439A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803439A0-0x00000001803439E0
	}

	// Constructors
	public MatchService(); // 0x000000018033BEB0-0x000000018033C0F0
	static MatchService(); // 0x000000018033BD50-0x000000018033BEB0

	// Methods
	public static void ApplyServerFlag(bool serverFlag); // 0x0000000180335A30-0x0000000180335AA0
	public static void ApplyPvpWsFlag(bool serverFlag); // 0x0000000180335990-0x0000000180335A00
	public int SkillCooldownLeftFor(int cardId); // 0x000000018033AE10-0x000000018033AF10
	public static int PrepMaxHp(int baseHp); // 0x0000000180339F20-0x0000000180339FD0
	public static int PrepMaxMana(int baseMana); // 0x0000000180339FD0-0x000000018033A060
	public static void ResetPrepStatFrame(); // 0x000000018033A6C0-0x000000018033A7E0
	public static void ApplyPrepStatFrame(int? hpBonusPct, int? manaBonus, int? powerMax); // 0x0000000180335680-0x0000000180335910
	public static void ApplyPrepStatFrame(MatchPrepDataDTO prep); // 0x0000000180335910-0x0000000180335990
	private void ApplyTowerFields(Dictionary<string, object> p, bool reset = false /* Metadata: 0x0064C2C6 */); // 0x0000000180336030-0x00000001803361F0
	public void BeginLocalFxHold(float sec); // 0x0000000180336760-0x0000000180336820
	private void ClearLocalFxHold(); // 0x00000001803368B0-0x00000001803368C0
	private void ApplyTimingFields(Dictionary<string, object> p); // 0x0000000180335E60-0x0000000180336030
	public WsCombatBatch ConsumePendingCombat(); // 0x00000001803368C0-0x00000001803368F0
	private WsCombatBatch ParseCombatBatch(ChatMessageDTO m, string kind); // 0x0000000180338AE0-0x00000001803390B0
	private void BeginAnimAck(long srvSeq, bool hasWork); // 0x0000000180336690-0x0000000180336760
	[IteratorStateMachine(typeof(_AckStuckGuard_d__266))]
	private IEnumerator AckStuckGuard(long srvSeq); // 0x0000000180334D70-0x0000000180334DF0
	public void NotifyRenderComplete(long srvSeq); // 0x0000000180338960-0x0000000180338980
	private void SendAnimAck(long srvSeq); // 0x000000018033A880-0x000000018033A9C0
	public void RegisterRendererBusyProbe(Func<bool> probe); // 0x000000018033A5B0-0x000000018033A5D0
	public void UnregisterRendererBusyProbe(Func<bool> probe); // 0x000000018033B760-0x000000018033B7A0
	public void ApplyServerStat(string username, string stat, int newValue); // 0x0000000180335AA0-0x0000000180335DA0
	public void ApplyServerBossHp(int newHp); // 0x0000000180335A00-0x0000000180335A30
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803361F0-0x0000000180336320
	private void Awake(); // 0x0000000180336320-0x0000000180336690
	private void TrySubscribeWsConfig(); // 0x000000018033B630-0x000000018033B760
	private void HandleWsConfig(ChatMessageDTO m); // 0x0000000180338750-0x00000001803388A0
	[IteratorStateMachine(typeof(_FetchFeatureFlags_d__295))]
	private IEnumerator FetchFeatureFlags(); // 0x00000001803368F0-0x0000000180336940
	private void Start(); // 0x0000000180338AD0-0x0000000180338AE0
	private void OnEnable(); // 0x0000000180338AD0-0x0000000180338AE0
	private void OnDisable(); // 0x0000000180338AC0-0x0000000180338AD0
	private void OnDestroy(); // 0x0000000180338980-0x0000000180338AC0
	private void TrySubscribeChat(); // 0x000000018033B050-0x000000018033B630
	private void UnsubscribeChat(); // 0x000000018033B7A0-0x000000018033BD50
	private void HandleConnectionChanged(bool connected); // 0x0000000180336E40-0x0000000180336F40
	[IteratorStateMachine(typeof(_ResyncAfterReconnect_d__306))]
	private IEnumerator ResyncAfterReconnect(); // 0x000000018033A810-0x000000018033A880
	public void ClearCurrentMatch(); // 0x0000000180336820-0x00000001803368B0
	public void SendMove(int fromCol, int fromRow, int toCol, int toRow); // 0x000000018033AC30-0x000000018033AD20
	private void FlushShadowReportForLastMove(); // 0x0000000180336A70-0x0000000180336DE0
	public void SendCardUse(int cardId, int? cardTarget = default); // 0x000000018033A9C0-0x000000018033AA40
	public void SendSkillUse(int skillCardId, int correctDotCount = 0 /* Metadata: 0x0064C2C7 */, string timingResult = "BAD" /* Metadata: 0x0064C2C8 */, int dotsToDestroy = 0 /* Metadata: 0x0064C2CC */, List<int> selectedRows = null, List<List<int>> selectedDots = null, List<string> qtePresses = null, int? qteElapsedMs = default); // 0x000000018033AD20-0x000000018033AE10
	public void RequestQteChallenge(int skillCardId); // 0x000000018033A5D0-0x000000018033A660
	private void HandleQteChallenge(ChatMessageDTO m); // 0x00000001803381F0-0x0000000180338540
	public void SendClientReady(); // 0x000000018033AA40-0x000000018033AAA0
	public void SendDragPause(); // 0x000000018033AAA0-0x000000018033AB00
	public void SendDragResume(); // 0x000000018033AB00-0x000000018033AB60
	public void RequestResync(); // 0x000000018033A660-0x000000018033A6C0
	public void SendFusionList(); // 0x000000018033AB60-0x000000018033ABC0
	public void SendFusionUse(long fusionUserPetId); // 0x000000018033ABC0-0x000000018033AC30
	public void NotifyBossEvolved(); // 0x0000000180338950-0x0000000180338960
	public void NotifyBossEvolved(int petId); // 0x0000000180338930-0x0000000180338950
	public int ResolveBossDisplayPetId(int fallbackPetId = 0 /* Metadata: 0x0064C2CD */); // 0x000000018033A7E0-0x000000018033A810
	public bool TryGetFusionGhost(int actorNumber, out int fusionPetId); // 0x000000018033AF10-0x000000018033B050
	private void HandleMatchStart(ChatMessageDTO m); // 0x0000000180337BA0-0x0000000180337C90
	private void HandleMatchResync(ChatMessageDTO m); // 0x0000000180337B00-0x0000000180337B50
	private void ApplyMatchInitFromMessage(ChatMessageDTO m); // 0x0000000180334DF0-0x0000000180335680
	private void HandleMatchMoveRes(ChatMessageDTO m); // 0x0000000180337670-0x00000001803376C0
	private void HandleMatchCardUseRes(ChatMessageDTO m); // 0x0000000180337330-0x0000000180337380
	private void HandleMatchSkillUseRes(ChatMessageDTO m); // 0x0000000180337B50-0x0000000180337BA0
	private void HandleFusionListRes(ChatMessageDTO m); // 0x0000000180336F40-0x0000000180336FA0
	private void HandleFusionRes(ChatMessageDTO m); // 0x0000000180336FA0-0x0000000180337190
	private static CardData ParseFusionSkillCard(Dictionary<string, object> p, string key); // 0x0000000180339430-0x00000001803395F0
	private static CardData ParseFusionSkillCardFromMap(Dictionary<string, object> p, string username); // 0x00000001803390B0-0x0000000180339430
	private void HandleResEnvelope(ChatMessageDTO m, string kind); // 0x0000000180338540-0x00000001803386F0
	private void HandleMatchReject(ChatMessageDTO m); // 0x0000000180337960-0x0000000180337B00
	private void HandleMatchTurnEnd(ChatMessageDTO m); // 0x0000000180337E10-0x00000001803381F0
	private void HandleMatchAfkWarn(ChatMessageDTO m); // 0x0000000180337190-0x0000000180337330
	private void HandleMatchTimerTick(ChatMessageDTO m); // 0x0000000180337C90-0x0000000180337E10
	private void HandleMatchPlayerLeft(ChatMessageDTO m); // 0x00000001803376C0-0x0000000180337860
	private void HandleMatchPlayerRejoin(ChatMessageDTO m); // 0x0000000180337860-0x0000000180337890
	private void HandleMatchReadyState(ChatMessageDTO m); // 0x0000000180337890-0x0000000180337960
	private void HandleMatchGameOver(ChatMessageDTO m); // 0x0000000180337380-0x0000000180337670
	[IteratorStateMachine(typeof(_FlushGameOverWhenPresentationDone_d__402))]
	private IEnumerator FlushGameOverWhenPresentationDone(); // 0x0000000180336A00-0x0000000180336A70
	private void FlushDeferredGameOver(bool force = false /* Metadata: 0x0064C2CE */); // 0x0000000180336940-0x0000000180336A00
	private void HandleSkillCast(ChatMessageDTO m); // 0x00000001803386F0-0x0000000180338750
	private void HandleBossAction(ChatMessageDTO m); // 0x0000000180336DE0-0x0000000180336E40
	private void ApplyStateDelta(Dictionary<string, object> payload); // 0x0000000180335DA0-0x0000000180335E60
	private void ParsePlayersSnapshot(Dictionary<string, object> payload); // 0x00000001803397E0-0x0000000180339F20
	private List<MatchOpDTO> ParseOps(Dictionary<string, object> payload); // 0x00000001803395F0-0x00000001803397E0
	private static string ReadString(Dictionary<string, object> p, string key, string fb = null); // 0x000000018033A510-0x000000018033A5B0
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0064C2CF */); // 0x000000018033A170-0x000000018033A290
	private static int? ReadOptionalInt(Dictionary<string, object> p, string key); // 0x000000018033A3B0-0x000000018033A510
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x0064C2D0 */); // 0x000000018033A290-0x000000018033A3B0
	private static bool ReadBool(Dictionary<string, object> p, string key, bool fb = false /* Metadata: 0x0064C2D8 */); // 0x000000018033A060-0x000000018033A170
	public bool IsLocalTurn(); // 0x00000001803388A0-0x0000000180338930
}

