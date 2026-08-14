//Type is in global namespace

public class ChatMessageDTO
{
	public Nullable<Int32> userId; //Field offset: 0x10
	public string username; //Field offset: 0x18
	public string message; //Field offset: 0x20
	public string timestamp; //Field offset: 0x28
	public string type; //Field offset: 0x30
	public string target; //Field offset: 0x38
	public Nullable<Boolean> busy; //Field offset: 0x40
	public Nullable<Boolean> ready; //Field offset: 0x42
	public UserPresenceDTO[] users; //Field offset: 0x48
	public string roomId; //Field offset: 0x50
	public string roomType; //Field offset: 0x58
	public Nullable<Int32> maxPlayers; //Field offset: 0x60
	public Dictionary<String, Boolean> members; //Field offset: 0x68
	public Dictionary<String, Object> properties; //Field offset: 0x70
	public string reason; //Field offset: 0x78
	public RoomSummaryDTO[] rooms; //Field offset: 0x80
	public RoomListFilterDTO filter; //Field offset: 0x88
	public string action; //Field offset: 0x90
	public RoomSummaryDTO room; //Field offset: 0x98
	public Dictionary<String, WsPlayerStateDTO> playerStates; //Field offset: 0xA0
	public WsPlayerStateDTO playerProps; //Field offset: 0xA8
	public string matchId; //Field offset: 0xB0
	public Nullable<Int64> seqNum; //Field offset: 0xB8
	public Dictionary<String, Object> matchPayload; //Field offset: 0xC8
	public Nullable<Int32> fromCol; //Field offset: 0xD0
	public Nullable<Int32> fromRow; //Field offset: 0xD8
	public Nullable<Int32> toCol; //Field offset: 0xE0
	public Nullable<Int32> toRow; //Field offset: 0xE8
	public Nullable<Int32> cardId; //Field offset: 0xF0
	public Nullable<Int32> cardTarget; //Field offset: 0xF8
	public string rejectReason; //Field offset: 0x100
	public Nullable<Int32> skillCardId; //Field offset: 0x108
	public Nullable<Int32> correctDotCount; //Field offset: 0x110
	public string timingResult; //Field offset: 0x118
	public Nullable<Int32> dotsToDestroy; //Field offset: 0x120
	public List<Int32> selectedRows; //Field offset: 0x128
	public List<List`1<Int32>> selectedDots; //Field offset: 0x130
	public List<String> qtePresses; //Field offset: 0x138
	public Nullable<Int32> qteElapsedMs; //Field offset: 0x140
	public Nullable<Int64> fusionUserPetId; //Field offset: 0x148
	public Nullable<Int64> bootstrapPetId; //Field offset: 0x158
	public string bootstrapMode; //Field offset: 0x168
	public RoomBootstrapData bootstrapData; //Field offset: 0x170
	public Nullable<Int32> energyCur; //Field offset: 0x178
	public Nullable<Int32> energyFull; //Field offset: 0x180
	public Nullable<Int32> energyDelta; //Field offset: 0x188
	public string energyReason; //Field offset: 0x190
	public Nullable<Int64> energyNextRegenSec; //Field offset: 0x198
	public string giftScope; //Field offset: 0x1A8
	public List<OnlineUserInfoDTO> onlineUsersWithInfo; //Field offset: 0x1B0
	public MatchRewardData matchResult; //Field offset: 0x1B8
	public Nullable<Int32> petsPage; //Field offset: 0x1C0
	public Nullable<Int32> petsSize; //Field offset: 0x1C8
	public PetsPaginatedDataDTO petsPaginatedData; //Field offset: 0x1D0
	public HubBootstrapData hubBootstrapData; //Field offset: 0x1D8
	public Nullable<Int64> matchUserPetId; //Field offset: 0x1E0
	public Nullable<Int64> matchEnemyPetId; //Field offset: 0x1F0
	public Nullable<Int64> matchBossScheduleId; //Field offset: 0x200
	public string matchMode; //Field offset: 0x210
	public MatchPrepDataDTO matchPrepData; //Field offset: 0x218
	public Nullable<Int64> rewardPetId; //Field offset: 0x220
	public Nullable<Boolean> rewardVictory; //Field offset: 0x230
	public Nullable<Int64> rewardT; //Field offset: 0x238
	public string rewardS; //Field offset: 0x248
	public PetRewardDataDTO rewardData; //Field offset: 0x250
	public Nullable<Int64> pvpProfileTargetUserId; //Field offset: 0x258
	public PvpProfileDTO pvpProfileData; //Field offset: 0x268
	public Nullable<Int64> bossScheduleId; //Field offset: 0x270
	public Nullable<Int32> bossDamageDealt; //Field offset: 0x280
	public Nullable<Boolean> bossVictory; //Field offset: 0x288
	public Nullable<Int32> bossTurnCount; //Field offset: 0x28C
	public List<WorldBossDTO> worldBossList; //Field offset: 0x298
	public Nullable<Int32> shadowDamage; //Field offset: 0x2A0
	public Nullable<Int32> shadowBossHpAfter; //Field offset: 0x2A8
	public Nullable<Int32> shadowPlayerHpAfter; //Field offset: 0x2B0
	public Nullable<Boolean> cfgUseWsGameplay; //Field offset: 0x2B8
	public Nullable<Boolean> cfgUseWsRoom; //Field offset: 0x2BA
	public Nullable<Boolean> cfgUsePvpWs; //Field offset: 0x2BC

	public ChatMessageDTO() { }

}

