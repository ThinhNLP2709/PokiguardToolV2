/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class APIConfig : MonoBehaviour // TypeDefIndex: 1571
{
	// Fields
	private const string DOMAIN = "pokiguard.online"; // Metadata: 0x005F1237
	private static readonly bool SECURE; // 0x00
	internal static readonly string BASE_URL; // 0x08
	public const string VERSION = "1.7.4.5"; // Metadata: 0x005F1248
	public const string DISPLAY_VERSION = "1.7.4"; // Metadata: 0x005F1250
	public static readonly string SOCKET; // 0x10
	public static string GET_ALL_PET; // 0x18
	public static string DEDUCT_GOLD; // 0x20
	public static string BATCH_UPGRADE_STONES; // 0x28
	public static readonly string POST_UNLOCK_LEGEND_PET; // 0x30
	public static readonly string POST_REGISTER; // 0x38
	public static readonly string GET_USER_INFO; // 0x40

	// Properties
	public static bool IsProductionEndpoint { get; } // 0x000000018085A9E0-0x000000018085AAC0 
	public static string GET_FEATURE_FLAGS { get; } // 0x000000018085AAC0-0x000000018085AB40 
	public static string APP_TERMS { get; } // 0x000000018085B040-0x000000018085B0C0 
	public static string POST_WEBVIEW_TICKET { get; } // 0x000000018085B280-0x000000018085B300 
	public static string POST_WEBVIEW_GUEST_TICKET { get; } // 0x000000018085B300-0x000000018085B380 
	public static string GET_ACCOUNT_EMAIL_STATUS { get; } // 0x000000018085B380-0x000000018085B400 
	public static string POST_CLIENT_LOG { get; } // 0x000000018085B400-0x000000018085B480 
	public static string POST_CLIENT_PERF { get; } // 0x000000018085B480-0x000000018085B500 
	public static string POST_ALL_PET_PAGINATED { get; } // 0x000000018085B900-0x000000018085B980 
	public static string CLAIM_EVENT_FEST { get; } // 0x000000018085BA60-0x000000018085BAE0 
	public static string FLIP_EVENT_FEST { get; } // 0x000000018085BAE0-0x000000018085BB60 
	public static string POST_USER_LOGIN { get; } // 0x000000018085C540-0x000000018085C5C0 
	public static string POST_USER_LOGIN_TOKEN { get; } // 0x000000018085C5C0-0x000000018085C640 
	public static string UPGRADE_PET { get; } // 0x000000018085C640-0x000000018085C6C0 
	public static string UPGRADE_STONE { get; } // 0x000000018085C6C0-0x000000018085C740 
	public static string GET_ALL_LEGEND_PETS { get; } // 0x000000018085C920-0x000000018085C9A0 
	public static string POST_INLAY_STAR { get; } // 0x000000018085CAC0-0x000000018085CB40 
	public static string GET_TOP9_RANKING { get; } // 0x000000018085D400-0x000000018085D480 
	public static string GET_TOP30_RANKING { get; } // 0x000000018085D480-0x000000018085D500 
	public static string PVP_RANK_TIERS { get; } // 0x000000018085D5E0-0x000000018085D660 
	public static string PVP_RANKING_TOP { get; } // 0x000000018085D660-0x000000018085D6E0 
	public static string PVP_RANKING_USER { get; } // 0x000000018085D6E0-0x000000018085D760 
	public static string PVP_RANKING_HISTORY { get; } // 0x000000018085D760-0x000000018085D7E0 
	public static string PVP_RANKING_SEASON { get; } // 0x000000018085D7E0-0x000000018085D860 
	public static string USE_CARD { get; } // 0x000000018085E670-0x000000018085E6F0 
	public static string GET_LIBRARY_CARDS { get; } // 0x000000018085E6F0-0x000000018085E770 
	public static string GET_ALL_CARDS_LEGACY { get; } // 0x000000018085E770-0x000000018085E7F0 
	public static string HUB_BOOTSTRAP { get; } // 0x000000018085E8D0-0x000000018085E950 
	public static string ROOM_BOOTSTRAP { get; } // 0x000000018085E950-0x000000018085E9D0 
	public static string CLAIM_DAILY_REWARD { get; } // 0x0000000180860630-0x00000001808606B0 
	public static string GET_RANKING_REWARDS { get; } // 0x0000000180862850-0x00000001808628D0 
	public static string ONLINE_USERNAMES { get; } // 0x0000000180863A70-0x0000000180863AF0 
	public static string ONLINE_USERS_WITH_INFO { get; } // 0x0000000180863AF0-0x0000000180863B70 
	public static string ONLINE_STATS { get; } // 0x0000000180863B70-0x0000000180863BF0 
	public static string SHOP_AVATAR_PURCHASE { get; } // 0x0000000180868A50-0x0000000180868AD0 
	public static string CHAT_IMAGE_UPLOAD { get; } // 0x0000000180868AD0-0x0000000180868B50 

	// Constructors
	public APIConfig(); // 0x000000018028A560-0x000000018028A5B0
	static APIConfig(); // 0x0000000180868CB0-0x0000000180869280

	// Methods
	public static string APP_BOOTSTRAP(string platform, string appVersion); // 0x000000018085AB40-0x000000018085AC80
	public static string APP_UI_CONFIG(string platform, string appVersion); // 0x000000018085AC80-0x000000018085ADC0
	public static string APP_FLAGS(string platform, string appVersion); // 0x000000018085ADC0-0x000000018085AF00
	public static string APP_EVENTS(string platform, string appVersion); // 0x000000018085AF00-0x000000018085B040
	public static string TERMS_STATUS(int userId); // 0x000000018085B0C0-0x000000018085B1A0
	public static string TERMS_ACCEPT(int userId); // 0x000000018085B1A0-0x000000018085B280
	public static string GET_PETS_ENEMYS(int id); // 0x000000018085B500-0x000000018085B5E0
	public static string GET_USER(int id); // 0x000000018085B5E0-0x000000018085B6C0
	public static string GET_ALL_PET_USERS(int id); // 0x000000018085B6C0-0x000000018085B7A0
	public static string FIND_USER_BY_NAME(); // 0x000000018085B7A0-0x000000018085B820
	public static string GET_ALL_PET_USERS_PAGINATED(int id); // 0x000000018085B820-0x000000018085B900
	public static string GET_EVENT_FEST(int userId); // 0x000000018085B980-0x000000018085BA60
	public static string GET_PET_USERS(int id, int petId); // 0x000000018085BB60-0x000000018085BC80
	public static string GET_ROOM_USERS(int id, int idPet); // 0x000000018085BC80-0x000000018085BDA0
	public static string GET_PET_USERS_MATCH(int id, int idPet, int ePetId); // 0x000000018085BDA0-0x000000018085C000
	public static string GET_ENEMYPET_USERS_MATCH(int ePetId, int idPet); // 0x000000018085C000-0x000000018085C120
	public static string GET_PVPPET_MATCH(int pvpPetId, int myPetId, int level); // 0x000000018085C120-0x000000018085C380
	public static string DOWN_ENERGY(int id); // 0x000000018085C380-0x000000018085C460
	public static string GET_STONES(int userId); // 0x000000018085C460-0x000000018085C540
	public static string CHECK_WHEEL(int userId); // 0x000000018085C740-0x000000018085C830
	public static string SPIN_WHEEL(int userId); // 0x000000018085C830-0x000000018085C920
	public static string GET_LEGEND_PET_INFO(int userId, int petId); // 0x000000018085C9A0-0x000000018085CAC0
	public static string GET_ALL_WORLD_BOSSES(int userId); // 0x000000018085CB40-0x000000018085CC20
	public static string BOSS_SWEEP_INFO(int userId, int petId); // 0x000000018085CC20-0x000000018085CD40
	public static string BOSS_SWEEP_USE(int userId); // 0x000000018085CD40-0x000000018085CE20
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE(long userId, long bossScheduleId); // 0x000000018085CE20-0x000000018085CF40
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 l\u01B0\u1EE3t \u0111\u00E1nh tr\u1EEB t\u1EA1i ROOM_START_MATCH (WebSocket).", false)]
	public static string USE_BOSS_ATTEMPT(long userId, long bossScheduleId); // 0x000000018085CF40-0x000000018085D060
	public static string GET_BOSS_RANKING(int userId); // 0x000000018085D060-0x000000018085D150
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId); // 0x000000018085D150-0x000000018085D260
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId, string battleDate); // 0x000000018085D260-0x000000018085D400
	public static string GET_USER_DETAIL(int userId); // 0x000000018085D500-0x000000018085D5E0
	public static string GET_ENERGY(int userId); // 0x000000018085D860-0x000000018085D940
	public static string CONSUME_ENERGY(int userId, int amount); // 0x000000018085D940-0x000000018085DA60
	public static string GET_PENDING_GIFTS(int userId); // 0x000000018085DA60-0x000000018085DB50
	public static string GET_GIFT_COUNT(int userId); // 0x000000018085DB50-0x000000018085DC40
	public static string CLAIM_GIFT(int giftId, int userId); // 0x000000018085DC40-0x000000018085DD50
	public static string GET_CLAIMED_GIFTS(int userId); // 0x000000018085DD50-0x000000018085DE40
	public static string GET_SHOP_DATA(int userId); // 0x000000018085DE40-0x000000018085DF20
	public static string PURCHASE_ITEM(); // 0x000000018085DF20-0x000000018085DFA0
	public static string PURCHASE_PACKAGE(); // 0x000000018085DFA0-0x000000018085E020
	public static string GET_WHEEL_CONFIG(int userId); // 0x000000018085E020-0x000000018085E110
	public static string SPIN_WHEEL_FREE(int userId); // 0x000000018085E110-0x000000018085E1F0
	public static string SPIN_WHEEL_GOLD(int userId); // 0x000000018085E1F0-0x000000018085E2D0
	public static string SPIN_WHEEL_BULK(int userId); // 0x000000018085E2D0-0x000000018085E3B0
	public static string CHECK_FREE_SPIN(int userId); // 0x000000018085E3B0-0x000000018085E490
	public static string CHECK_GOLD_SPIN(int userId); // 0x000000018085E490-0x000000018085E570
	public static string REDEEM_GIFT_CODE(long userId, string code); // 0x000000018085E570-0x000000018085E670
	public static string GET_LIBRARY_AVATARS(long userId); // 0x000000018085E7F0-0x000000018085E8D0
	public static string GET_USER_PETS(int userId, int page = 0 /* Metadata: 0x005F122C */, int size = 10 /* Metadata: 0x005F122D */); // 0x000000018085E9D0-0x000000018085EC30
	public static string GET_USER_AVATARS(int userId, int page = 0 /* Metadata: 0x005F122E */, int size = 3 /* Metadata: 0x005F122F */); // 0x000000018085EC30-0x000000018085EE90
	public static string EQUIP_PET(int userId); // 0x000000018085EE90-0x000000018085EF70
	public static string EQUIP_AVATAR(int userId); // 0x000000018085EF70-0x000000018085F050
	public static string GET_EQUIPMENT_COUNT(int userId); // 0x000000018085F050-0x000000018085F130
	public static string GET_WEAPON_LIST(int userId, int page = 0 /* Metadata: 0x005F1230 */, int size = 8 /* Metadata: 0x005F1231 */); // 0x000000018085F130-0x000000018085F390
	public static string WEAPON_EQUIP(int userId); // 0x000000018085F390-0x000000018085F470
	public static string WEAPON_UNEQUIP(int userId); // 0x000000018085F470-0x000000018085F550
	public static string WEAPON_UPGRADE(int userId); // 0x000000018085F550-0x000000018085F630
	public static string WEAPON_SALVAGE(int userId); // 0x000000018085F630-0x000000018085F710
	public static string GET_WEAPON_SUMMARY(int userId); // 0x000000018085F710-0x000000018085F7F0
	public static string GET_WEAPON_EQUIPPED(long targetUserId); // 0x000000018085F7F0-0x000000018085F8D0
	public static string GET_PET_SHARDS(int userId); // 0x000000018085F8D0-0x000000018085F9B0
	public static string GET_PET_STARS(int userId); // 0x000000018085F9B0-0x000000018085FA90
	public static string GET_PET_STAR_INFO(int userId, long petId); // 0x000000018085FA90-0x000000018085FBB0
	public static string PET_STAR_UPGRADE(int userId); // 0x000000018085FBB0-0x000000018085FC90
	public static string PET_SHARD_EXCHANGE(int userId); // 0x000000018085FC90-0x000000018085FD70
	public static string GET_GACHA_BANNERS(int userId); // 0x000000018085FD70-0x000000018085FE50
	public static string GET_GACHA_RATES(long bannerId); // 0x000000018085FE50-0x000000018085FF30
	public static string GACHA_ROLL(int userId); // 0x000000018085FF30-0x0000000180860010
	public static string GET_GACHA_HISTORY(int userId); // 0x0000000180860010-0x00000001808600F0
	public static string TOWER_INFO(int userId); // 0x00000001808600F0-0x00000001808601D0
	public static string TOWER_RESET_CLAIM(int userId); // 0x00000001808601D0-0x00000001808602B0
	public static string TOWER_BUY_POWER(int userId); // 0x00000001808602B0-0x0000000180860390
	public static string TOWER_TOP(int userId); // 0x0000000180860390-0x0000000180860470
	public static string CLAIM_PET_REWARD(int userId); // 0x0000000180860470-0x0000000180860550
	public static string GET_DAILY_CHECKINS(int userId); // 0x0000000180860550-0x0000000180860630
	public static string GET_MILESTONE_STATUS(int userId); // 0x00000001808606B0-0x0000000180860790
	public static string CLAIM_MILESTONE(int userId, long milestoneId); // 0x0000000180860790-0x00000001808608B0
	public static string GET_FIRST_TOPUP(int userId); // 0x00000001808608B0-0x0000000180860990
	public static string CLAIM_FIRST_TOPUP(int userId, long tierId); // 0x0000000180860990-0x0000000180860AB0
	public static string GET_TREASURE_WHEEL(int userId); // 0x0000000180860AB0-0x0000000180860B90
	public static string TREASURE_WHEEL_SPIN(int userId); // 0x0000000180860B90-0x0000000180860C70
	public static string TREASURE_WHEEL_BONUS_CLAIM(int userId, long bonusId); // 0x0000000180860C70-0x0000000180860D90
	public static string GET_RECHARGE_EVENT(int userId); // 0x0000000180860D90-0x0000000180860E70
	public static string RECHARGE_EVENT_CLAIM(int userId, long milestoneId); // 0x0000000180860E70-0x0000000180860F90
	public static string EVENT_TRACK_STATE(string key, int userId); // 0x0000000180860F90-0x0000000180861090
	public static string EVENT_TRACK_CLAIM(string key, int userId); // 0x0000000180861090-0x0000000180861190
	public static string CAN_DAU_VAN_STATE(int userId); // 0x0000000180861190-0x0000000180861270
	public static string CAN_DAU_VAN_ROLL(int userId); // 0x0000000180861270-0x0000000180861350
	public static string CAN_DAU_VAN_BUY(int userId); // 0x0000000180861350-0x0000000180861430
	public static string THANH_TUU_STATE(long userId); // 0x0000000180861430-0x0000000180861510
	public static string THANH_TUU_CLAIM(long userId); // 0x0000000180861510-0x00000001808615F0
	public static string THANH_TUU_CHEST(long userId); // 0x00000001808615F0-0x00000001808616D0
	public static string REQUEST_DAMAGE_SIGNATURE(long userId, long bossScheduleId); // 0x00000001808616D0-0x00000001808617F0
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE_SERVER_SIGNED(long userId, long bossScheduleId); // 0x00000001808617F0-0x0000000180861910
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 v\u00F2i b\u01A1m damage kh\u00F4ng rate-limit, KH\u00D4NG kh\u00F4i ph\u1EE5c.", false)]
	public static string SUBMIT_BOSS_DAMAGE_CHECKPOINT(long userId, long bossScheduleId); // 0x0000000180861910-0x0000000180861A30
	public static string GET_QUESTS(int userId, string questType); // 0x0000000180861A30-0x0000000180861B30
	public static string UPDATE_QUEST_PROGRESS(); // 0x0000000180861B30-0x0000000180861BB0
	public static string CLAIM_QUEST(int userId, long questId); // 0x0000000180861BB0-0x0000000180861CD0
	public static string GET_EVOLUTION_PETS(int userId, int page = 0 /* Metadata: 0x005F1232 */, int size = 8 /* Metadata: 0x005F1233 */); // 0x0000000180861CD0-0x0000000180861F30
	public static string GET_EVOLUTION_DETAIL(int userId, long sourcePetId); // 0x0000000180861F30-0x0000000180862050
	public static string EVOLVE_PET(int userId, long sourcePetId); // 0x0000000180862050-0x0000000180862170
	public static string SWAP_ITEM(int userId, int swapType); // 0x0000000180862170-0x0000000180862290
	public static string SWAP_ITEM_TT(int userId, int coreIndex, int eItemType); // 0x0000000180862290-0x00000001808624F0
	public static string GET_MONTHLY_RANKING_STATUS(); // 0x00000001808624F0-0x0000000180862570
	public static string GET_LIFETIME_MILESTONE_STATUS(int userId); // 0x0000000180862570-0x0000000180862650
	public static string GET_ONLINE_GIFT_STATUS(int userId); // 0x0000000180862650-0x0000000180862730
	public static string CLAIM_ONLINE_GIFT(int userId, long milestoneId); // 0x0000000180862730-0x0000000180862850
	public static string CLAIM_LIFETIME_MILESTONE(int userId, long milestoneId); // 0x00000001808628D0-0x00000001808629F0
	public static string SUBMIT_COOP_MATCH_RESULT(int userId); // 0x00000001808629F0-0x0000000180862AD0
	public static string GET_CLAIMABLE_PETS(int userId); // 0x0000000180862AD0-0x0000000180862BB0
	public static string CLAIM_PET(); // 0x0000000180862BB0-0x0000000180862C30
	public static string GET_AVATAR_EXCHANGE_LIST(int userId); // 0x0000000180862C30-0x0000000180862D10
	public static string EXCHANGE_AVATAR(int userId, long avatarId); // 0x0000000180862D10-0x0000000180862E30
	public static string CHANGE_NAME(int userId); // 0x0000000180862E30-0x0000000180862F10
	public static string CHANGE_NAME_INFO(int userId); // 0x0000000180862F10-0x0000000180862FF0
	public static string VIP_INFO(int userId); // 0x0000000180862FF0-0x00000001808630D0
	public static string VIP_ACTIVATE(int userId); // 0x00000001808630D0-0x00000001808631B0
	public static string VIP_CLAIM(int userId); // 0x00000001808631B0-0x0000000180863290
	public static string GET_USER_CARDS(int userId); // 0x0000000180863290-0x0000000180863370
	public static string UPGRADE_CARD(); // 0x0000000180863370-0x00000001808633F0
	public static string GET_MINIGAME_INFO(int userId); // 0x00000001808633F0-0x00000001808634D0
	public static string SPIN_MINIGAME(); // 0x00000001808634D0-0x0000000180863550
	public static string GET_THONG_BAO(); // 0x0000000180863550-0x00000001808635D0
	public static string GET_AWAKENING_PETS(int userId, int page = 0 /* Metadata: 0x005F1234 */, int size = 8 /* Metadata: 0x005F1235 */); // 0x00000001808635D0-0x0000000180863830
	public static string GET_AWAKENING_DETAIL(int userId, long sourcePetId); // 0x0000000180863830-0x0000000180863950
	public static string AWAKEN_PET(int userId, long sourcePetId); // 0x0000000180863950-0x0000000180863A70
	public static string GET_FRIENDS(int userId); // 0x0000000180863BF0-0x0000000180863CD0
	public static string GET_FRIEND_BADGE(int userId); // 0x0000000180863CD0-0x0000000180863DB0
	public static string GET_FRIEND_REQUESTS(int userId); // 0x0000000180863DB0-0x0000000180863E90
	public static string SEARCH_FRIEND(int userId, string name); // 0x0000000180863E90-0x0000000180863FA0
	public static string GET_FRIEND_SUGGESTIONS(int userId); // 0x0000000180863FA0-0x0000000180864080
	public static string GET_FRIEND_BLOCKED(int userId); // 0x0000000180864080-0x0000000180864160
	public static string GET_FRIEND_PROFILE(int userId, long friendUserId); // 0x0000000180864160-0x0000000180864280
	public static string GET_INTIMACY_LEVELS(int userId); // 0x0000000180864280-0x0000000180864360
	public static string FRIEND_REQUEST_SEND(int userId, long targetUserId); // 0x0000000180864360-0x0000000180864480
	public static string FRIEND_REQUEST_ACCEPT(int userId, long requestId); // 0x0000000180864480-0x00000001808645A0
	public static string FRIEND_REQUEST_DECLINE(int userId, long requestId); // 0x00000001808645A0-0x00000001808646C0
	public static string FRIEND_REQUEST_CANCEL(int userId, long requestId); // 0x00000001808646C0-0x00000001808647E0
	public static string FRIEND_REMOVE(int userId, long friendUserId); // 0x00000001808647E0-0x0000000180864900
	public static string FRIEND_BLOCK(int userId, long targetUserId); // 0x0000000180864900-0x0000000180864A20
	public static string FRIEND_UNBLOCK(int userId, long targetUserId); // 0x0000000180864A20-0x0000000180864B40
	public static string FRIEND_SET_NICKNAME(int userId, long friendUserId); // 0x0000000180864B40-0x0000000180864C60
	public static string FRIEND_SET_PIN(int userId, long friendUserId); // 0x0000000180864C60-0x0000000180864D80
	public static string FRIEND_INTIMACY_CLAIM(int userId, long friendUserId, int level); // 0x0000000180864D80-0x0000000180864FE0
	public static string FRIEND_ENERGY_GIFT(int userId, long friendUserId); // 0x0000000180864FE0-0x0000000180865100
	public static string GET_FRIEND_MESSAGES(int userId, long friendUserId, long beforeId, int limit); // 0x0000000180865100-0x0000000180865550
	public static string SEND_FRIEND_MESSAGE(int userId, long friendUserId); // 0x0000000180865550-0x0000000180865670
	public static string MARK_FRIEND_MESSAGES_READ(int userId, long friendUserId); // 0x0000000180865670-0x0000000180865790
	public static string GET_FRIEND_UNREAD_COUNTS(int userId); // 0x0000000180865790-0x0000000180865870
	public static string GET_MID_AUTUMN(int userId); // 0x0000000180865870-0x0000000180865950
	public static string GET_MID_AUTUMN_RANKING(int userId, int limit = 30 /* Metadata: 0x005F1236 */); // 0x0000000180865950-0x0000000180865A70
	public static string MID_AUTUMN_CLAIM(int userId); // 0x0000000180865A70-0x0000000180865B50
	public static string MID_AUTUMN_FLIP(int userId); // 0x0000000180865B50-0x0000000180865C30
	public static string MID_AUTUMN_CRAFT(int userId); // 0x0000000180865C30-0x0000000180865D10
	public static string GUILD_HOME(int userId); // 0x0000000180865D10-0x0000000180865DF0
	public static string GUILD_LIST(int userId, int page, string q); // 0x0000000180865DF0-0x0000000180866050
	public static string GUILD_CREATE(int userId); // 0x0000000180866050-0x0000000180866130
	public static string GUILD_INFO(int userId); // 0x0000000180866130-0x0000000180866210
	public static string GUILD_REQUEST_JOIN(int userId); // 0x0000000180866210-0x00000001808662F0
	public static string GUILD_REQUEST_CANCEL(int userId); // 0x00000001808662F0-0x00000001808663D0
	public static string GUILD_REQUESTS(int userId); // 0x00000001808663D0-0x00000001808664B0
	public static string GUILD_REQUEST_ACCEPT(int userId); // 0x00000001808664B0-0x0000000180866590
	public static string GUILD_REQUEST_DECLINE(int userId); // 0x0000000180866590-0x0000000180866670
	public static string GUILD_MEMBER_PROMOTE(int userId); // 0x0000000180866670-0x0000000180866750
	public static string GUILD_MEMBER_DEMOTE(int userId); // 0x0000000180866750-0x0000000180866830
	public static string GUILD_MEMBER_KICK(int userId); // 0x0000000180866830-0x0000000180866910
	public static string GUILD_LEAVE(int userId); // 0x0000000180866910-0x00000001808669F0
	public static string GUILD_EDIT(int userId); // 0x00000001808669F0-0x0000000180866AD0
	public static string GUILD_RENAME(int userId); // 0x0000000180866AD0-0x0000000180866BB0
	public static string GUILD_RECRUIT(int userId); // 0x0000000180866BB0-0x0000000180866C90
	public static string GUILD_HORN(int userId); // 0x0000000180866C90-0x0000000180866D70
	public static string GUILD_HORN_SEND(int userId); // 0x0000000180866D70-0x0000000180866E50
	public static string GUILD_SHOP(int userId); // 0x0000000180866E50-0x0000000180866F30
	public static string GUILD_SHOP_BUY(int userId); // 0x0000000180866F30-0x0000000180867010
	public static string GUILD_SHOP_RESET(int userId); // 0x0000000180867010-0x00000001808670F0
	public static string GUILD_RAID(int userId); // 0x00000001808670F0-0x00000001808671D0
	public static string GUILD_RAID_RANKING(int userId); // 0x00000001808671D0-0x00000001808672B0
	public static string GUILD_RAID_SCHEDULE(int userId); // 0x00000001808672B0-0x0000000180867390
	public static string GUILD_RAID_REWARDS(int userId); // 0x0000000180867390-0x0000000180867470
	public static string GUILD_BOSS_TOP_GUILDS(int userId); // 0x0000000180867470-0x0000000180867550
	public static string GUILD_DONATE_GOLD(int userId); // 0x0000000180867550-0x0000000180867630
	public static string GUILD_BUY_SLOT(int userId); // 0x0000000180867630-0x0000000180867710
	public static string GUILD_DETAIL(int userId, long guildId); // 0x0000000180867710-0x0000000180867830
	public static string GUILD_VAULT(int userId); // 0x0000000180867830-0x0000000180867910
	public static string GUILD_VAULT_DISTRIBUTE(int userId); // 0x0000000180867910-0x00000001808679F0
	public static string PROFILE_GET(long userId); // 0x00000001808679F0-0x0000000180867AD0
	public static string PROFILE_VIEW(long userId, long targetId); // 0x0000000180867AD0-0x0000000180867BF0
	public static string INVENTORY_GET(long userId); // 0x0000000180867BF0-0x0000000180867CD0
	public static string EQUIP_BOOK(long userId); // 0x0000000180867CD0-0x0000000180867DB0
	public static string EQUIP_BAG(long userId, int category, int slot, bool sort, int page); // 0x0000000180867DB0-0x00000001808680D0
	public static string EQUIP_ITEM(long userId, long itemId); // 0x00000001808680D0-0x00000001808681F0
	public static string EQUIP_WEAR(long userId); // 0x00000001808681F0-0x00000001808682D0
	public static string EQUIP_UNWEAR(long userId); // 0x00000001808682D0-0x00000001808683B0
	public static string EQUIP_AVATAR_HIDDEN(long userId); // 0x00000001808683B0-0x0000000180868490
	public static string EQUIP_UPGRADE_STAR(long userId); // 0x0000000180868490-0x0000000180868570
	public static string EQUIP_SALVAGE(long userId); // 0x0000000180868570-0x0000000180868650
	public static string SHOP_AVATAR_PAGE(long userId, int category, int rarity, bool hideOwned, string sort, int page); // 0x0000000180868650-0x0000000180868970
	public static string SHOP_AVATAR_PORTRAITS(long userId); // 0x0000000180868970-0x0000000180868A50
	public static string CHAT_IMAGE(string id, bool thumb); // 0x0000000180868B50-0x0000000180868CB0
}

