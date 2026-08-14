//Type is in global namespace

public class APIConfig : MonoBehaviour
{
	private const string DOMAIN = "pokiguard.online"; //Field offset: 0x0
	private static readonly bool SECURE; //Field offset: 0x0
	public const string VERSION = "1.7.1"; //Field offset: 0x0
	internal static readonly string BASE_URL; //Field offset: 0x8
	public static readonly string SOCKET; //Field offset: 0x10
	public static string GET_ALL_PET; //Field offset: 0x18
	public static string DEDUCT_GOLD; //Field offset: 0x20
	public static string BATCH_UPGRADE_STONES; //Field offset: 0x28
	public static readonly string POST_UNLOCK_LEGEND_PET; //Field offset: 0x30
	public static readonly string POST_REGISTER; //Field offset: 0x38
	public static readonly string GET_USER_INFO; //Field offset: 0x40

	public static string CLAIM_DAILY_REWARD
	{
		 get { } //Length: 102
	}

	public static string CLAIM_EVENT_FEST
	{
		 get { } //Length: 102
	}

	public static string FLIP_EVENT_FEST
	{
		 get { } //Length: 102
	}

	public static string GET_ALL_LEGEND_PETS
	{
		 get { } //Length: 102
	}

	public static string GET_FEATURE_FLAGS
	{
		 get { } //Length: 102
	}

	public static string GET_RANKING_REWARDS
	{
		 get { } //Length: 102
	}

	public static string GET_TOP30_RANKING
	{
		 get { } //Length: 102
	}

	public static string GET_TOP9_RANKING
	{
		 get { } //Length: 102
	}

	public static string HUB_BOOTSTRAP
	{
		 get { } //Length: 102
	}

	public static bool IsProductionEndpoint
	{
		 get { } //Length: 188
	}

	public static string ONLINE_STATS
	{
		 get { } //Length: 102
	}

	public static string ONLINE_USERNAMES
	{
		 get { } //Length: 102
	}

	public static string ONLINE_USERS_WITH_INFO
	{
		 get { } //Length: 102
	}

	public static string POST_ALL_PET_PAGINATED
	{
		 get { } //Length: 102
	}

	public static string POST_CLIENT_LOG
	{
		 get { } //Length: 102
	}

	public static string POST_EVENT_ACTION
	{
		 get { } //Length: 102
	}

	public static string POST_EVENT_CLAIM
	{
		 get { } //Length: 102
	}

	public static string POST_EVENT_DATA
	{
		 get { } //Length: 102
	}

	public static string POST_INLAY_STAR
	{
		 get { } //Length: 102
	}

	public static string POST_USER_LOGIN
	{
		 get { } //Length: 102
	}

	public static string PVP_RANK_TIERS
	{
		 get { } //Length: 102
	}

	public static string PVP_RANKING_HISTORY
	{
		 get { } //Length: 102
	}

	public static string PVP_RANKING_SEASON
	{
		 get { } //Length: 102
	}

	public static string PVP_RANKING_TOP
	{
		 get { } //Length: 102
	}

	public static string PVP_RANKING_USER
	{
		 get { } //Length: 102
	}

	public static string ROOM_BOOTSTRAP
	{
		 get { } //Length: 102
	}

	public static string UPGRADE_PET
	{
		 get { } //Length: 102
	}

	public static string UPGRADE_STONE
	{
		 get { } //Length: 102
	}

	public static string USE_CARD
	{
		 get { } //Length: 102
	}

	private static APIConfig() { }

	public APIConfig() { }

	public static string APP_BOOTSTRAP(string platform, string appVersion) { }

	public static string AWAKEN_PET(int userId, long sourcePetId) { }

	public static string CHANGE_NAME(int userId) { }

	public static string CHECK_EVENT_CLAIM(int userId) { }

	public static string CHECK_FREE_SPIN(int userId) { }

	public static string CHECK_GOLD_SPIN(int userId) { }

	public static string CHECK_WHEEL(int userId) { }

	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId) { }

	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId, string battleDate) { }

	public static string CLAIM_EVENT_REWARD(int userId) { }

	public static string CLAIM_GIFT(int giftId, int userId) { }

	public static string CLAIM_LIFETIME_MILESTONE(int userId, long milestoneId) { }

	public static string CLAIM_LOTTERY_PRIZES(int userId) { }

	public static string CLAIM_MILESTONE(int userId, long milestoneId) { }

	public static string CLAIM_ONLINE_GIFT(int userId, long milestoneId) { }

	public static string CLAIM_PET() { }

	public static string CLAIM_PET_REWARD(int userId) { }

	public static string CLAIM_QUEST(int userId, long questId) { }

	public static string CONSUME_ENERGY(int userId, int amount) { }

	public static string DOWN_ENERGY(int id) { }

	public static string DRAW_LOTTERY() { }

	public static string EQUIP_AVATAR(int userId) { }

	public static string EQUIP_PET(int userId) { }

	public static string EVOLVE_PET(int userId, long sourcePetId) { }

	public static string EXCHANGE_AVATAR(int userId, long avatarId) { }

	public static string FIND_USER_BY_NAME() { }

	public static string GET_ALL_PET_USERS(int id) { }

	public static string GET_ALL_PET_USERS_PAGINATED(int id) { }

	public static string GET_ALL_WORLD_BOSSES(int userId) { }

	public static string GET_AVATAR_EXCHANGE_LIST(int userId) { }

	public static string GET_AWAKENING_DETAIL(int userId, long sourcePetId) { }

	public static string GET_AWAKENING_PETS(int userId, int page = 0, int size = 8) { }

	public static string GET_BOSS_RANKING(int userId) { }

	public static string get_CLAIM_DAILY_REWARD() { }

	public static string get_CLAIM_EVENT_FEST() { }

	public static string GET_CLAIMABLE_PETS(int userId) { }

	public static string GET_DAILY_CHECKINS(int userId) { }

	public static string GET_ENEMYPET_USERS_MATCH(int ePetId, int idPet) { }

	public static string GET_ENERGY(int userId) { }

	public static string GET_EQUIPMENT_COUNT(int userId) { }

	public static string GET_EVENT_FEST(int userId) { }

	public static string GET_EVOLUTION_DETAIL(int userId, long sourcePetId) { }

	public static string GET_EVOLUTION_PETS(int userId, int page = 0, int size = 8) { }

	public static string get_FLIP_EVENT_FEST() { }

	public static string get_GET_ALL_LEGEND_PETS() { }

	public static string get_GET_FEATURE_FLAGS() { }

	public static string get_GET_RANKING_REWARDS() { }

	public static string get_GET_TOP30_RANKING() { }

	public static string get_GET_TOP9_RANKING() { }

	public static string GET_GIFT_COUNT(int userId) { }

	public static string get_HUB_BOOTSTRAP() { }

	public static bool get_IsProductionEndpoint() { }

	public static string GET_LEGEND_PET_INFO(int userId, int petId) { }

	public static string GET_LIFETIME_MILESTONE_STATUS(int userId) { }

	public static string GET_LOTTERY_INFO(int userId) { }

	public static string GET_MILESTONE_STATUS(int userId) { }

	public static string GET_MINIGAME_INFO(int userId) { }

	public static string GET_MONTHLY_RANKING_STATUS() { }

	public static string GET_ONLINE_GIFT_STATUS(int userId) { }

	public static string get_ONLINE_STATS() { }

	public static string get_ONLINE_USERNAMES() { }

	public static string get_ONLINE_USERS_WITH_INFO() { }

	public static string GET_PENDING_GIFTS(int userId) { }

	public static string GET_PET_SHARDS(int userId) { }

	public static string GET_PET_STAR_INFO(int userId, long petId) { }

	public static string GET_PET_STARS(int userId) { }

	public static string GET_PET_USERS(int id, int petId) { }

	public static string GET_PET_USERS_MATCH(int id, int idPet, int ePetId) { }

	public static string GET_PETS_ENEMYS(int id) { }

	public static string get_POST_ALL_PET_PAGINATED() { }

	public static string get_POST_CLIENT_LOG() { }

	public static string get_POST_EVENT_ACTION() { }

	public static string get_POST_EVENT_CLAIM() { }

	public static string get_POST_EVENT_DATA() { }

	public static string get_POST_INLAY_STAR() { }

	public static string get_POST_USER_LOGIN() { }

	public static string get_PVP_RANK_TIERS() { }

	public static string get_PVP_RANKING_HISTORY() { }

	public static string get_PVP_RANKING_SEASON() { }

	public static string get_PVP_RANKING_TOP() { }

	public static string get_PVP_RANKING_USER() { }

	public static string GET_PVPPET_MATCH(int pvpPetId, int myPetId, int level) { }

	public static string GET_QUESTS(int userId, string questType) { }

	public static string get_ROOM_BOOTSTRAP() { }

	public static string GET_ROOM_USERS(int id, int idPet) { }

	public static string GET_SHOP_DATA(int userId) { }

	public static string GET_STONES(int userId) { }

	public static string GET_THONG_BAO() { }

	public static string get_UPGRADE_PET() { }

	public static string get_UPGRADE_STONE() { }

	public static string get_USE_CARD() { }

	public static string GET_USER(int id) { }

	public static string GET_USER_AVATARS(int userId, int page = 0, int size = 3) { }

	public static string GET_USER_CARDS(int userId) { }

	public static string GET_USER_DETAIL(int userId) { }

	public static string GET_USER_PETS(int userId, int page = 0, int size = 10) { }

	public static string GET_WEAPON_EQUIPPED(long targetUserId) { }

	public static string GET_WEAPON_LIST(int userId, int page = 0, int size = 8) { }

	public static string GET_WEAPON_SUMMARY(int userId) { }

	public static string GET_WHEEL_CONFIG(int userId) { }

	public static string PET_SHARD_EXCHANGE(int userId) { }

	public static string PET_STAR_UPGRADE(int userId) { }

	public static string PURCHASE_ITEM() { }

	public static string PURCHASE_PACKAGE() { }

	public static string REDEEM_GIFT_CODE(long userId, string code) { }

	public static string REQUEST_DAMAGE_SIGNATURE(long userId, long bossScheduleId) { }

	public static string SELECT_LOTTERY_NUMBER() { }

	public static string SPIN_MINIGAME() { }

	public static string SPIN_WHEEL(int userId, int prizeIndex) { }

	public static string SPIN_WHEEL(int userId) { }

	public static string SPIN_WHEEL_FREE(int userId) { }

	public static string SPIN_WHEEL_GOLD(int userId) { }

	[Obsolete("Endpoint đã bị xoá khỏi server — damage do server engine tính, không nhận số client khai.", False)]
	public static string SUBMIT_BOSS_DAMAGE(long userId, long bossScheduleId) { }

	[Obsolete("Endpoint đã bị xoá khỏi server — vòi bơm damage không rate-limit, KHÔNG khôi phục.", False)]
	public static string SUBMIT_BOSS_DAMAGE_CHECKPOINT(long userId, long bossScheduleId) { }

	[Obsolete("Endpoint đã bị xoá khỏi server — damage do server engine tính, không nhận số client khai.", False)]
	public static string SUBMIT_BOSS_DAMAGE_SERVER_SIGNED(long userId, long bossScheduleId) { }

	public static string SUBMIT_COOP_MATCH_RESULT(int userId) { }

	public static string SWAP_ITEM(int userId, int swapType) { }

	public static string SWAP_ITEM_TT(int userId, int coreIndex, int eItemType) { }

	public static string UPDATE_QUEST_PROGRESS() { }

	public static string UPGRADE_CARD() { }

	[Obsolete("Endpoint đã bị xoá khỏi server — lượt đánh trừ tại ROOM_START_MATCH (WebSocket).", False)]
	public static string USE_BOSS_ATTEMPT(long userId, long bossScheduleId) { }

	public static string WEAPON_EQUIP(int userId) { }

	public static string WEAPON_SALVAGE(int userId) { }

	public static string WEAPON_UNEQUIP(int userId) { }

	public static string WEAPON_UPGRADE(int userId) { }

}

