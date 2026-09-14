/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class ChatMessageDTO // TypeDefIndex: 498
{
	// Fields
	public int? userId; // 0x10
	public string username; // 0x18
	public int? vipLevel; // 0x20
	public string message; // 0x28
	public string timestamp; // 0x30
	public string type; // 0x38
	public string target; // 0x40
	public bool? busy; // 0x48
	public bool? ready; // 0x4A
	public UserPresenceDTO[] users; // 0x50
	public string roomId; // 0x58
	public string roomType; // 0x60
	public int? maxPlayers; // 0x68
	public Dictionary<string, bool> members; // 0x70
	public Dictionary<string, object> properties; // 0x78
	public string reason; // 0x80
	public RoomSummaryDTO[] rooms; // 0x88
	public RoomListFilterDTO filter; // 0x90
	public string action; // 0x98
	public RoomSummaryDTO room; // 0xA0
	public Dictionary<string, WsPlayerStateDTO> playerStates; // 0xA8
	public WsPlayerStateDTO playerProps; // 0xB0
	public string matchId; // 0xB8
	public long? seqNum; // 0xC0
	public long? clientMonoMs; // 0xD0
	public Dictionary<string, object> matchPayload; // 0xE0
	public int? fromCol; // 0xE8
	public int? fromRow; // 0xF0
	public int? toCol; // 0xF8
	public int? toRow; // 0x100
	public int? cardId; // 0x108
	public int? cardTarget; // 0x110
	public string rejectReason; // 0x118
	public int? skillCardId; // 0x120
	public int? correctDotCount; // 0x128
	public string timingResult; // 0x130
	public int? dotsToDestroy; // 0x138
	public List<int> selectedRows; // 0x140
	public List<List<int>> selectedDots; // 0x148
	public List<string> qtePresses; // 0x150
	public int? qteElapsedMs; // 0x158
	public long? qteChallengeId; // 0x160
	public long? fusionUserPetId; // 0x170
	public long? bootstrapPetId; // 0x180
	public string bootstrapMode; // 0x190
	public RoomBootstrapData bootstrapData; // 0x198
	public int? energyCur; // 0x1A0
	public int? energyFull; // 0x1A8
	public int? energyDelta; // 0x1B0
	public string energyReason; // 0x1B8
	public long? energyNextRegenSec; // 0x1C0
	public string giftScope; // 0x1D0
	public string noticeScope; // 0x1D8
	public string friendKind; // 0x1E0
	public long? friendMsgId; // 0x1E8
	public int? intimacyLevel; // 0x1F8
	[JsonProperty("scope")]
	public string guildScope; // 0x200
	public long? msgId; // 0x208
	public string reactScope; // 0x218
	public Dictionary<string, int> reactions; // 0x220
	public string myReaction; // 0x228
	public string imageId; // 0x230
	public int? imageW; // 0x238
	public int? imageH; // 0x240
	public long? imageExpiresAt; // 0x248
	public long? bossCurrentHp; // 0x258
	public long? bossMaxHp; // 0x268
	public long? damageDelta; // 0x278
	public string damageSource; // 0x288
	public long? guildRaidId; // 0x290
	public string guildBossHpReason; // 0x2A0
	public long? guildKillerUserId; // 0x2A8
	public long? raidRunDamage; // 0x2B8
	public long? raidMyDamage; // 0x2C8
	public int? raidMyRank; // 0x2D8
	public int? raidAttemptsLeft; // 0x2E0
	public bool? raidLive; // 0x2E8
	public long? raidHpCurrent; // 0x2F0
	public List<OnlineUserInfoDTO> onlineUsersWithInfo; // 0x300
	public CoopMatchResultHelper.MatchRewardData matchResult; // 0x308
	public int? petsPage; // 0x310
	public int? petsSize; // 0x318
	public PetsPaginatedDataDTO petsPaginatedData; // 0x320
	public HubBootstrapData hubBootstrapData; // 0x328
	public long? matchUserPetId; // 0x330
	public long? matchEnemyPetId; // 0x340
	public long? matchBossScheduleId; // 0x350
	public string matchMode; // 0x360
	public MatchPrepDataDTO matchPrepData; // 0x368
	public long? rewardPetId; // 0x370
	public bool? rewardVictory; // 0x380
	public long? rewardT; // 0x388
	public string rewardS; // 0x398
	public PetRewardDataDTO rewardData; // 0x3A0
	public long? pvpProfileTargetUserId; // 0x3A8
	public PvpProfileDTO pvpProfileData; // 0x3B8
	public long? bossScheduleId; // 0x3C0
	public int? bossDamageDealt; // 0x3D0
	public bool? bossVictory; // 0x3D8
	public int? bossTurnCount; // 0x3DC
	public List<WorldBossDTO> worldBossList; // 0x3E8
	public int? shadowDamage; // 0x3F0
	public int? shadowBossHpAfter; // 0x3F8
	public int? shadowPlayerHpAfter; // 0x400
	public bool? cfgUseWsGameplay; // 0x408
	public bool? cfgUseWsRoom; // 0x40A
	public bool? cfgUsePvpWs; // 0x40C
	[JsonIgnore]
	public List<MatchOpDTO> preOps; // 0x410
	[JsonIgnore]
	public bool preOpsReady; // 0x418
	[JsonIgnore]
	public BoardCellDTO[][] preBoard; // 0x420
	[JsonIgnore]
	public bool preBoardReady; // 0x428
	[JsonIgnore]
	public List<WsCombatStepDTO> preCombatSteps; // 0x430
	[JsonIgnore]
	public bool preCombatStepsReady; // 0x438
	[JsonIgnore]
	public Dictionary<string, int> preDestroyedByTag; // 0x440
	[JsonIgnore]
	public bool preDestroyedByTagReady; // 0x448
	[JsonIgnore]
	public Dictionary<string, MatchPlayerSnapshotDTO> prePlayers; // 0x450
	[JsonIgnore]
	public bool prePlayersIsFull; // 0x458
	[JsonIgnore]
	public bool prePlayersReady; // 0x459

	// Properties
	[JsonIgnore]
	public bool HasImage { get; } // 0x000000018039C750-0x000000018039C770 

	// Constructors
	public ChatMessageDTO(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public bool ImageExpired(long nowMs); // 0x000000018039C770-0x000000018039C7A0
}

