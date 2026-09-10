/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class ChatMessageDTO // TypeDefIndex: 444
{
	// Fields
	public int? userId; // 0x10
	public string username; // 0x18
	public string message; // 0x20
	public string timestamp; // 0x28
	public string type; // 0x30
	public string target; // 0x38
	public bool? busy; // 0x40
	public bool? ready; // 0x42
	public UserPresenceDTO[] users; // 0x48
	public string roomId; // 0x50
	public string roomType; // 0x58
	public int? maxPlayers; // 0x60
	public Dictionary<string, bool> members; // 0x68
	public Dictionary<string, object> properties; // 0x70
	public string reason; // 0x78
	public RoomSummaryDTO[] rooms; // 0x80
	public RoomListFilterDTO filter; // 0x88
	public string action; // 0x90
	public RoomSummaryDTO room; // 0x98
	public Dictionary<string, WsPlayerStateDTO> playerStates; // 0xA0
	public WsPlayerStateDTO playerProps; // 0xA8
	public string matchId; // 0xB0
	public long? seqNum; // 0xB8
	public Dictionary<string, object> matchPayload; // 0xC8
	public int? fromCol; // 0xD0
	public int? fromRow; // 0xD8
	public int? toCol; // 0xE0
	public int? toRow; // 0xE8
	public int? cardId; // 0xF0
	public int? cardTarget; // 0xF8
	public string rejectReason; // 0x100
	public int? skillCardId; // 0x108
	public int? correctDotCount; // 0x110
	public string timingResult; // 0x118
	public int? dotsToDestroy; // 0x120
	public List<int> selectedRows; // 0x128
	public List<List<int>> selectedDots; // 0x130
	public List<string> qtePresses; // 0x138
	public int? qteElapsedMs; // 0x140
	public long? qteChallengeId; // 0x148
	public long? fusionUserPetId; // 0x158
	public long? bootstrapPetId; // 0x168
	public string bootstrapMode; // 0x178
	public RoomBootstrapData bootstrapData; // 0x180
	public int? energyCur; // 0x188
	public int? energyFull; // 0x190
	public int? energyDelta; // 0x198
	public string energyReason; // 0x1A0
	public long? energyNextRegenSec; // 0x1A8
	public string giftScope; // 0x1B8
	public string noticeScope; // 0x1C0
	public string friendKind; // 0x1C8
	public long? friendMsgId; // 0x1D0
	public int? intimacyLevel; // 0x1E0
	[JsonProperty("scope")]
	public string guildScope; // 0x1E8
	public long? msgId; // 0x1F0
	public string reactScope; // 0x200
	public Dictionary<string, int> reactions; // 0x208
	public string myReaction; // 0x210
	public string imageId; // 0x218
	public int? imageW; // 0x220
	public int? imageH; // 0x228
	public long? imageExpiresAt; // 0x230
	public long? bossCurrentHp; // 0x240
	public long? bossMaxHp; // 0x250
	public long? damageDelta; // 0x260
	public string damageSource; // 0x270
	public bool? guildKillable; // 0x278
	public int? guildHuntDone; // 0x27C
	public int? guildHuntRequired; // 0x284
	public string guildBossHpReason; // 0x290
	public long? guildKillerUserId; // 0x298
	public List<OnlineUserInfoDTO> onlineUsersWithInfo; // 0x2A8
	public CoopMatchResultHelper.MatchRewardData matchResult; // 0x2B0
	public int? petsPage; // 0x2B8
	public int? petsSize; // 0x2C0
	public PetsPaginatedDataDTO petsPaginatedData; // 0x2C8
	public HubBootstrapData hubBootstrapData; // 0x2D0
	public long? matchUserPetId; // 0x2D8
	public long? matchEnemyPetId; // 0x2E8
	public long? matchBossScheduleId; // 0x2F8
	public string matchMode; // 0x308
	public MatchPrepDataDTO matchPrepData; // 0x310
	public long? rewardPetId; // 0x318
	public bool? rewardVictory; // 0x328
	public long? rewardT; // 0x330
	public string rewardS; // 0x340
	public PetRewardDataDTO rewardData; // 0x348
	public long? pvpProfileTargetUserId; // 0x350
	public PvpProfileDTO pvpProfileData; // 0x360
	public long? bossScheduleId; // 0x368
	public int? bossDamageDealt; // 0x378
	public bool? bossVictory; // 0x380
	public int? bossTurnCount; // 0x384
	public List<WorldBossDTO> worldBossList; // 0x390
	public int? shadowDamage; // 0x398
	public int? shadowBossHpAfter; // 0x3A0
	public int? shadowPlayerHpAfter; // 0x3A8
	public bool? cfgUseWsGameplay; // 0x3B0
	public bool? cfgUseWsRoom; // 0x3B2
	public bool? cfgUsePvpWs; // 0x3B4
	[JsonIgnore]
	public List<MatchOpDTO> preOps; // 0x3B8
	[JsonIgnore]
	public bool preOpsReady; // 0x3C0
	[JsonIgnore]
	public BoardCellDTO[][] preBoard; // 0x3C8
	[JsonIgnore]
	public bool preBoardReady; // 0x3D0
	[JsonIgnore]
	public List<WsCombatStepDTO> preCombatSteps; // 0x3D8
	[JsonIgnore]
	public bool preCombatStepsReady; // 0x3E0
	[JsonIgnore]
	public Dictionary<string, int> preDestroyedByTag; // 0x3E8
	[JsonIgnore]
	public bool preDestroyedByTagReady; // 0x3F0
	[JsonIgnore]
	public Dictionary<string, MatchPlayerSnapshotDTO> prePlayers; // 0x3F8
	[JsonIgnore]
	public bool prePlayersIsFull; // 0x400
	[JsonIgnore]
	public bool prePlayersReady; // 0x401

	// Properties
	[JsonIgnore]
	public bool HasImage { get; } // 0x00000001803790A0-0x00000001803790C0 

	// Constructors
	public ChatMessageDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public bool ImageExpired(long nowMs); // 0x0000000180379030-0x00000001803790A0
}

