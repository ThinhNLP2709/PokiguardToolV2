/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class APIConfig : MonoBehaviour // TypeDefIndex: 1569
{
	// Fields
	private const string DOMAIN = "pokiguard.online"; // Metadata: 0x005EFE6A
	private static readonly bool SECURE; // 0x00
	internal static readonly string BASE_URL; // 0x08
	public const string VERSION = "1.7.4.4"; // Metadata: 0x005EFE7B
	public const string DISPLAY_VERSION = "1.7.4"; // Metadata: 0x005EFE83
	public static readonly string SOCKET; // 0x10
	public static string GET_ALL_PET; // 0x18
	public static string DEDUCT_GOLD; // 0x20
	public static string BATCH_UPGRADE_STONES; // 0x28
	public static readonly string POST_UNLOCK_LEGEND_PET; // 0x30
	public static readonly string POST_REGISTER; // 0x38
	public static readonly string GET_USER_INFO; // 0x40

	// Properties
	public static bool IsProductionEndpoint { get; } // 0x0000000180858750-0x0000000180858830 
	public static string GET_FEATURE_FLAGS { get; } // 0x0000000180858830-0x00000001808588B0 
	public static string APP_TERMS { get; } // 0x0000000180858DB0-0x0000000180858E30 
	public static string POST_WEBVIEW_TICKET { get; } // 0x0000000180858FF0-0x0000000180859070 
	public static string POST_WEBVIEW_GUEST_TICKET { get; } // 0x0000000180859070-0x00000001808590F0 
	public static string GET_ACCOUNT_EMAIL_STATUS { get; } // 0x00000001808590F0-0x0000000180859170 
	public static string POST_CLIENT_LOG { get; } // 0x0000000180859170-0x00000001808591F0 
	public static string POST_CLIENT_PERF { get; } // 0x00000001808591F0-0x0000000180859270 
	public static string POST_ALL_PET_PAGINATED { get; } // 0x0000000180859670-0x00000001808596F0 
	public static string CLAIM_EVENT_FEST { get; } // 0x00000001808597D0-0x0000000180859850 
	public static string FLIP_EVENT_FEST { get; } // 0x0000000180859850-0x00000001808598D0 
	public static string POST_USER_LOGIN { get; } // 0x000000018085A2B0-0x000000018085A330 
	public static string POST_USER_LOGIN_TOKEN { get; } // 0x000000018085A330-0x000000018085A3B0 
	public static string UPGRADE_PET { get; } // 0x000000018085A3B0-0x000000018085A430 
	public static string UPGRADE_STONE { get; } // 0x000000018085A430-0x000000018085A4B0 
	public static string GET_ALL_LEGEND_PETS { get; } // 0x000000018085A690-0x000000018085A710 
	public static string POST_INLAY_STAR { get; } // 0x000000018085A830-0x000000018085A8B0 
	public static string GET_TOP9_RANKING { get; } // 0x000000018085B170-0x000000018085B1F0 
	public static string GET_TOP30_RANKING { get; } // 0x000000018085B1F0-0x000000018085B270 
	public static string PVP_RANK_TIERS { get; } // 0x000000018085B350-0x000000018085B3D0 
	public static string PVP_RANKING_TOP { get; } // 0x000000018085B3D0-0x000000018085B450 
	public static string PVP_RANKING_USER { get; } // 0x000000018085B450-0x000000018085B4D0 
	public static string PVP_RANKING_HISTORY { get; } // 0x000000018085B4D0-0x000000018085B550 
	public static string PVP_RANKING_SEASON { get; } // 0x000000018085B550-0x000000018085B5D0 
	public static string USE_CARD { get; } // 0x000000018085C3E0-0x000000018085C460 
	public static string GET_LIBRARY_CARDS { get; } // 0x000000018085C460-0x000000018085C4E0 
	public static string GET_ALL_CARDS_LEGACY { get; } // 0x000000018085C4E0-0x000000018085C560 
	public static string HUB_BOOTSTRAP { get; } // 0x000000018085C640-0x000000018085C6C0 
	public static string ROOM_BOOTSTRAP { get; } // 0x000000018085C6C0-0x000000018085C740 
	public static string CLAIM_DAILY_REWARD { get; } // 0x000000018085E3A0-0x000000018085E420 
	public static string GET_RANKING_REWARDS { get; } // 0x00000001808605C0-0x0000000180860640 
	public static string ONLINE_USERNAMES { get; } // 0x00000001808617E0-0x0000000180861860 
	public static string ONLINE_USERS_WITH_INFO { get; } // 0x0000000180861860-0x00000001808618E0 
	public static string ONLINE_STATS { get; } // 0x00000001808618E0-0x0000000180861960 
	public static string SHOP_AVATAR_PURCHASE { get; } // 0x00000001808667C0-0x0000000180866840 
	public static string CHAT_IMAGE_UPLOAD { get; } // 0x0000000180866840-0x00000001808668C0 

	// Constructors
	public APIConfig(); // 0x000000018028A560-0x000000018028A5B0
	static APIConfig(); // 0x0000000180866A20-0x0000000180866FF0

	// Methods
	public static string APP_BOOTSTRAP(string platform, string appVersion); // 0x00000001808588B0-0x00000001808589F0
	public static string APP_UI_CONFIG(string platform, string appVersion); // 0x00000001808589F0-0x0000000180858B30
	public static string APP_FLAGS(string platform, string appVersion); // 0x0000000180858B30-0x0000000180858C70
	public static string APP_EVENTS(string platform, string appVersion); // 0x0000000180858C70-0x0000000180858DB0
	public static string TERMS_STATUS(int userId); // 0x0000000180858E30-0x0000000180858F10
	public static string TERMS_ACCEPT(int userId); // 0x0000000180858F10-0x0000000180858FF0
	public static string GET_PETS_ENEMYS(int id); // 0x0000000180859270-0x0000000180859350
	public static string GET_USER(int id); // 0x0000000180859350-0x0000000180859430
	public static string GET_ALL_PET_USERS(int id); // 0x0000000180859430-0x0000000180859510
	public static string FIND_USER_BY_NAME(); // 0x0000000180859510-0x0000000180859590
	public static string GET_ALL_PET_USERS_PAGINATED(int id); // 0x0000000180859590-0x0000000180859670
	public static string GET_EVENT_FEST(int userId); // 0x00000001808596F0-0x00000001808597D0
	public static string GET_PET_USERS(int id, int petId); // 0x00000001808598D0-0x00000001808599F0
	public static string GET_ROOM_USERS(int id, int idPet); // 0x00000001808599F0-0x0000000180859B10
	public static string GET_PET_USERS_MATCH(int id, int idPet, int ePetId); // 0x0000000180859B10-0x0000000180859D70
	public static string GET_ENEMYPET_USERS_MATCH(int ePetId, int idPet); // 0x0000000180859D70-0x0000000180859E90
	public static string GET_PVPPET_MATCH(int pvpPetId, int myPetId, int level); // 0x0000000180859E90-0x000000018085A0F0
	public static string DOWN_ENERGY(int id); // 0x000000018085A0F0-0x000000018085A1D0
	public static string GET_STONES(int userId); // 0x000000018085A1D0-0x000000018085A2B0
	public static string CHECK_WHEEL(int userId); // 0x000000018085A4B0-0x000000018085A5A0
	public static string SPIN_WHEEL(int userId); // 0x000000018085A5A0-0x000000018085A690
	public static string GET_LEGEND_PET_INFO(int userId, int petId); // 0x000000018085A710-0x000000018085A830
	public static string GET_ALL_WORLD_BOSSES(int userId); // 0x000000018085A8B0-0x000000018085A990
	public static string BOSS_SWEEP_INFO(int userId, int petId); // 0x000000018085A990-0x000000018085AAB0
	public static string BOSS_SWEEP_USE(int userId); // 0x000000018085AAB0-0x000000018085AB90
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE(long userId, long bossScheduleId); // 0x000000018085AB90-0x000000018085ACB0
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 l\u01B0\u1EE3t \u0111\u00E1nh tr\u1EEB t\u1EA1i ROOM_START_MATCH (WebSocket).", false)]
	public static string USE_BOSS_ATTEMPT(long userId, long bossScheduleId); // 0x000000018085ACB0-0x000000018085ADD0
	public static string GET_BOSS_RANKING(int userId); // 0x000000018085ADD0-0x000000018085AEC0
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId); // 0x000000018085AEC0-0x000000018085AFD0
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId, string battleDate); // 0x000000018085AFD0-0x000000018085B170
	public static string GET_USER_DETAIL(int userId); // 0x000000018085B270-0x000000018085B350
	public static string GET_ENERGY(int userId); // 0x000000018085B5D0-0x000000018085B6B0
	public static string CONSUME_ENERGY(int userId, int amount); // 0x000000018085B6B0-0x000000018085B7D0
	public static string GET_PENDING_GIFTS(int userId); // 0x000000018085B7D0-0x000000018085B8C0
	public static string GET_GIFT_COUNT(int userId); // 0x000000018085B8C0-0x000000018085B9B0
	public static string CLAIM_GIFT(int giftId, int userId); // 0x000000018085B9B0-0x000000018085BAC0
	public static string GET_CLAIMED_GIFTS(int userId); // 0x000000018085BAC0-0x000000018085BBB0
	public static string GET_SHOP_DATA(int userId); // 0x000000018085BBB0-0x000000018085BC90
	public static string PURCHASE_ITEM(); // 0x000000018085BC90-0x000000018085BD10
	public static string PURCHASE_PACKAGE(); // 0x000000018085BD10-0x000000018085BD90
	public static string GET_WHEEL_CONFIG(int userId); // 0x000000018085BD90-0x000000018085BE80
	public static string SPIN_WHEEL_FREE(int userId); // 0x000000018085BE80-0x000000018085BF60
	public static string SPIN_WHEEL_GOLD(int userId); // 0x000000018085BF60-0x000000018085C040
	public static string SPIN_WHEEL_BULK(int userId); // 0x000000018085C040-0x000000018085C120
	public static string CHECK_FREE_SPIN(int userId); // 0x000000018085C120-0x000000018085C200
	public static string CHECK_GOLD_SPIN(int userId); // 0x000000018085C200-0x000000018085C2E0
	public static string REDEEM_GIFT_CODE(long userId, string code); // 0x000000018085C2E0-0x000000018085C3E0
	public static string GET_LIBRARY_AVATARS(long userId); // 0x000000018085C560-0x000000018085C640
	public static string GET_USER_PETS(int userId, int page = 0 /* Metadata: 0x005EFE5F */, int size = 10 /* Metadata: 0x005EFE60 */); // 0x000000018085C740-0x000000018085C9A0
	public static string GET_USER_AVATARS(int userId, int page = 0 /* Metadata: 0x005EFE61 */, int size = 3 /* Metadata: 0x005EFE62 */); // 0x000000018085C9A0-0x000000018085CC00
	public static string EQUIP_PET(int userId); // 0x000000018085CC00-0x000000018085CCE0
	public static string EQUIP_AVATAR(int userId); // 0x000000018085CCE0-0x000000018085CDC0
	public static string GET_EQUIPMENT_COUNT(int userId); // 0x000000018085CDC0-0x000000018085CEA0
	public static string GET_WEAPON_LIST(int userId, int page = 0 /* Metadata: 0x005EFE63 */, int size = 8 /* Metadata: 0x005EFE64 */); // 0x000000018085CEA0-0x000000018085D100
	public static string WEAPON_EQUIP(int userId); // 0x000000018085D100-0x000000018085D1E0
	public static string WEAPON_UNEQUIP(int userId); // 0x000000018085D1E0-0x000000018085D2C0
	public static string WEAPON_UPGRADE(int userId); // 0x000000018085D2C0-0x000000018085D3A0
	public static string WEAPON_SALVAGE(int userId); // 0x000000018085D3A0-0x000000018085D480
	public static string GET_WEAPON_SUMMARY(int userId); // 0x000000018085D480-0x000000018085D560
	public static string GET_WEAPON_EQUIPPED(long targetUserId); // 0x000000018085D560-0x000000018085D640
	public static string GET_PET_SHARDS(int userId); // 0x000000018085D640-0x000000018085D720
	public static string GET_PET_STARS(int userId); // 0x000000018085D720-0x000000018085D800
	public static string GET_PET_STAR_INFO(int userId, long petId); // 0x000000018085D800-0x000000018085D920
	public static string PET_STAR_UPGRADE(int userId); // 0x000000018085D920-0x000000018085DA00
	public static string PET_SHARD_EXCHANGE(int userId); // 0x000000018085DA00-0x000000018085DAE0
	public static string GET_GACHA_BANNERS(int userId); // 0x000000018085DAE0-0x000000018085DBC0
	public static string GET_GACHA_RATES(long bannerId); // 0x000000018085DBC0-0x000000018085DCA0
	public static string GACHA_ROLL(int userId); // 0x000000018085DCA0-0x000000018085DD80
	public static string GET_GACHA_HISTORY(int userId); // 0x000000018085DD80-0x000000018085DE60
	public static string TOWER_INFO(int userId); // 0x000000018085DE60-0x000000018085DF40
	public static string TOWER_RESET_CLAIM(int userId); // 0x000000018085DF40-0x000000018085E020
	public static string TOWER_BUY_POWER(int userId); // 0x000000018085E020-0x000000018085E100
	public static string TOWER_TOP(int userId); // 0x000000018085E100-0x000000018085E1E0
	public static string CLAIM_PET_REWARD(int userId); // 0x000000018085E1E0-0x000000018085E2C0
	public static string GET_DAILY_CHECKINS(int userId); // 0x000000018085E2C0-0x000000018085E3A0
	public static string GET_MILESTONE_STATUS(int userId); // 0x000000018085E420-0x000000018085E500
	public static string CLAIM_MILESTONE(int userId, long milestoneId); // 0x000000018085E500-0x000000018085E620
	public static string GET_FIRST_TOPUP(int userId); // 0x000000018085E620-0x000000018085E700
	public static string CLAIM_FIRST_TOPUP(int userId, long tierId); // 0x000000018085E700-0x000000018085E820
	public static string GET_TREASURE_WHEEL(int userId); // 0x000000018085E820-0x000000018085E900
	public static string TREASURE_WHEEL_SPIN(int userId); // 0x000000018085E900-0x000000018085E9E0
	public static string TREASURE_WHEEL_BONUS_CLAIM(int userId, long bonusId); // 0x000000018085E9E0-0x000000018085EB00
	public static string GET_RECHARGE_EVENT(int userId); // 0x000000018085EB00-0x000000018085EBE0
	public static string RECHARGE_EVENT_CLAIM(int userId, long milestoneId); // 0x000000018085EBE0-0x000000018085ED00
	public static string EVENT_TRACK_STATE(string key, int userId); // 0x000000018085ED00-0x000000018085EE00
	public static string EVENT_TRACK_CLAIM(string key, int userId); // 0x000000018085EE00-0x000000018085EF00
	public static string CAN_DAU_VAN_STATE(int userId); // 0x000000018085EF00-0x000000018085EFE0
	public static string CAN_DAU_VAN_ROLL(int userId); // 0x000000018085EFE0-0x000000018085F0C0
	public static string CAN_DAU_VAN_BUY(int userId); // 0x000000018085F0C0-0x000000018085F1A0
	public static string THANH_TUU_STATE(long userId); // 0x000000018085F1A0-0x000000018085F280
	public static string THANH_TUU_CLAIM(long userId); // 0x000000018085F280-0x000000018085F360
	public static string THANH_TUU_CHEST(long userId); // 0x000000018085F360-0x000000018085F440
	public static string REQUEST_DAMAGE_SIGNATURE(long userId, long bossScheduleId); // 0x000000018085F440-0x000000018085F560
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE_SERVER_SIGNED(long userId, long bossScheduleId); // 0x000000018085F560-0x000000018085F680
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 v\u00F2i b\u01A1m damage kh\u00F4ng rate-limit, KH\u00D4NG kh\u00F4i ph\u1EE5c.", false)]
	public static string SUBMIT_BOSS_DAMAGE_CHECKPOINT(long userId, long bossScheduleId); // 0x000000018085F680-0x000000018085F7A0
	public static string GET_QUESTS(int userId, string questType); // 0x000000018085F7A0-0x000000018085F8A0
	public static string UPDATE_QUEST_PROGRESS(); // 0x000000018085F8A0-0x000000018085F920
	public static string CLAIM_QUEST(int userId, long questId); // 0x000000018085F920-0x000000018085FA40
	public static string GET_EVOLUTION_PETS(int userId, int page = 0 /* Metadata: 0x005EFE65 */, int size = 8 /* Metadata: 0x005EFE66 */); // 0x000000018085FA40-0x000000018085FCA0
	public static string GET_EVOLUTION_DETAIL(int userId, long sourcePetId); // 0x000000018085FCA0-0x000000018085FDC0
	public static string EVOLVE_PET(int userId, long sourcePetId); // 0x000000018085FDC0-0x000000018085FEE0
	public static string SWAP_ITEM(int userId, int swapType); // 0x000000018085FEE0-0x0000000180860000
	public static string SWAP_ITEM_TT(int userId, int coreIndex, int eItemType); // 0x0000000180860000-0x0000000180860260
	public static string GET_MONTHLY_RANKING_STATUS(); // 0x0000000180860260-0x00000001808602E0
	public static string GET_LIFETIME_MILESTONE_STATUS(int userId); // 0x00000001808602E0-0x00000001808603C0
	public static string GET_ONLINE_GIFT_STATUS(int userId); // 0x00000001808603C0-0x00000001808604A0
	public static string CLAIM_ONLINE_GIFT(int userId, long milestoneId); // 0x00000001808604A0-0x00000001808605C0
	public static string CLAIM_LIFETIME_MILESTONE(int userId, long milestoneId); // 0x0000000180860640-0x0000000180860760
	public static string SUBMIT_COOP_MATCH_RESULT(int userId); // 0x0000000180860760-0x0000000180860840
	public static string GET_CLAIMABLE_PETS(int userId); // 0x0000000180860840-0x0000000180860920
	public static string CLAIM_PET(); // 0x0000000180860920-0x00000001808609A0
	public static string GET_AVATAR_EXCHANGE_LIST(int userId); // 0x00000001808609A0-0x0000000180860A80
	public static string EXCHANGE_AVATAR(int userId, long avatarId); // 0x0000000180860A80-0x0000000180860BA0
	public static string CHANGE_NAME(int userId); // 0x0000000180860BA0-0x0000000180860C80
	public static string CHANGE_NAME_INFO(int userId); // 0x0000000180860C80-0x0000000180860D60
	public static string VIP_INFO(int userId); // 0x0000000180860D60-0x0000000180860E40
	public static string VIP_ACTIVATE(int userId); // 0x0000000180860E40-0x0000000180860F20
	public static string VIP_CLAIM(int userId); // 0x0000000180860F20-0x0000000180861000
	public static string GET_USER_CARDS(int userId); // 0x0000000180861000-0x00000001808610E0
	public static string UPGRADE_CARD(); // 0x00000001808610E0-0x0000000180861160
	public static string GET_MINIGAME_INFO(int userId); // 0x0000000180861160-0x0000000180861240
	public static string SPIN_MINIGAME(); // 0x0000000180861240-0x00000001808612C0
	public static string GET_THONG_BAO(); // 0x00000001808612C0-0x0000000180861340
	public static string GET_AWAKENING_PETS(int userId, int page = 0 /* Metadata: 0x005EFE67 */, int size = 8 /* Metadata: 0x005EFE68 */); // 0x0000000180861340-0x00000001808615A0
	public static string GET_AWAKENING_DETAIL(int userId, long sourcePetId); // 0x00000001808615A0-0x00000001808616C0
	public static string AWAKEN_PET(int userId, long sourcePetId); // 0x00000001808616C0-0x00000001808617E0
	public static string GET_FRIENDS(int userId); // 0x0000000180861960-0x0000000180861A40
	public static string GET_FRIEND_BADGE(int userId); // 0x0000000180861A40-0x0000000180861B20
	public static string GET_FRIEND_REQUESTS(int userId); // 0x0000000180861B20-0x0000000180861C00
	public static string SEARCH_FRIEND(int userId, string name); // 0x0000000180861C00-0x0000000180861D10
	public static string GET_FRIEND_SUGGESTIONS(int userId); // 0x0000000180861D10-0x0000000180861DF0
	public static string GET_FRIEND_BLOCKED(int userId); // 0x0000000180861DF0-0x0000000180861ED0
	public static string GET_FRIEND_PROFILE(int userId, long friendUserId); // 0x0000000180861ED0-0x0000000180861FF0
	public static string GET_INTIMACY_LEVELS(int userId); // 0x0000000180861FF0-0x00000001808620D0
	public static string FRIEND_REQUEST_SEND(int userId, long targetUserId); // 0x00000001808620D0-0x00000001808621F0
	public static string FRIEND_REQUEST_ACCEPT(int userId, long requestId); // 0x00000001808621F0-0x0000000180862310
	public static string FRIEND_REQUEST_DECLINE(int userId, long requestId); // 0x0000000180862310-0x0000000180862430
	public static string FRIEND_REQUEST_CANCEL(int userId, long requestId); // 0x0000000180862430-0x0000000180862550
	public static string FRIEND_REMOVE(int userId, long friendUserId); // 0x0000000180862550-0x0000000180862670
	public static string FRIEND_BLOCK(int userId, long targetUserId); // 0x0000000180862670-0x0000000180862790
	public static string FRIEND_UNBLOCK(int userId, long targetUserId); // 0x0000000180862790-0x00000001808628B0
	public static string FRIEND_SET_NICKNAME(int userId, long friendUserId); // 0x00000001808628B0-0x00000001808629D0
	public static string FRIEND_SET_PIN(int userId, long friendUserId); // 0x00000001808629D0-0x0000000180862AF0
	public static string FRIEND_INTIMACY_CLAIM(int userId, long friendUserId, int level); // 0x0000000180862AF0-0x0000000180862D50
	public static string FRIEND_ENERGY_GIFT(int userId, long friendUserId); // 0x0000000180862D50-0x0000000180862E70
	public static string GET_FRIEND_MESSAGES(int userId, long friendUserId, long beforeId, int limit); // 0x0000000180862E70-0x00000001808632C0
	public static string SEND_FRIEND_MESSAGE(int userId, long friendUserId); // 0x00000001808632C0-0x00000001808633E0
	public static string MARK_FRIEND_MESSAGES_READ(int userId, long friendUserId); // 0x00000001808633E0-0x0000000180863500
	public static string GET_FRIEND_UNREAD_COUNTS(int userId); // 0x0000000180863500-0x00000001808635E0
	public static string GET_MID_AUTUMN(int userId); // 0x00000001808635E0-0x00000001808636C0
	public static string GET_MID_AUTUMN_RANKING(int userId, int limit = 30 /* Metadata: 0x005EFE69 */); // 0x00000001808636C0-0x00000001808637E0
	public static string MID_AUTUMN_CLAIM(int userId); // 0x00000001808637E0-0x00000001808638C0
	public static string MID_AUTUMN_FLIP(int userId); // 0x00000001808638C0-0x00000001808639A0
	public static string MID_AUTUMN_CRAFT(int userId); // 0x00000001808639A0-0x0000000180863A80
	public static string GUILD_HOME(int userId); // 0x0000000180863A80-0x0000000180863B60
	public static string GUILD_LIST(int userId, int page, string q); // 0x0000000180863B60-0x0000000180863DC0
	public static string GUILD_CREATE(int userId); // 0x0000000180863DC0-0x0000000180863EA0
	public static string GUILD_INFO(int userId); // 0x0000000180863EA0-0x0000000180863F80
	public static string GUILD_REQUEST_JOIN(int userId); // 0x0000000180863F80-0x0000000180864060
	public static string GUILD_REQUEST_CANCEL(int userId); // 0x0000000180864060-0x0000000180864140
	public static string GUILD_REQUESTS(int userId); // 0x0000000180864140-0x0000000180864220
	public static string GUILD_REQUEST_ACCEPT(int userId); // 0x0000000180864220-0x0000000180864300
	public static string GUILD_REQUEST_DECLINE(int userId); // 0x0000000180864300-0x00000001808643E0
	public static string GUILD_MEMBER_PROMOTE(int userId); // 0x00000001808643E0-0x00000001808644C0
	public static string GUILD_MEMBER_DEMOTE(int userId); // 0x00000001808644C0-0x00000001808645A0
	public static string GUILD_MEMBER_KICK(int userId); // 0x00000001808645A0-0x0000000180864680
	public static string GUILD_LEAVE(int userId); // 0x0000000180864680-0x0000000180864760
	public static string GUILD_EDIT(int userId); // 0x0000000180864760-0x0000000180864840
	public static string GUILD_RENAME(int userId); // 0x0000000180864840-0x0000000180864920
	public static string GUILD_RECRUIT(int userId); // 0x0000000180864920-0x0000000180864A00
	public static string GUILD_HORN(int userId); // 0x0000000180864A00-0x0000000180864AE0
	public static string GUILD_HORN_SEND(int userId); // 0x0000000180864AE0-0x0000000180864BC0
	public static string GUILD_SHOP(int userId); // 0x0000000180864BC0-0x0000000180864CA0
	public static string GUILD_SHOP_BUY(int userId); // 0x0000000180864CA0-0x0000000180864D80
	public static string GUILD_SHOP_RESET(int userId); // 0x0000000180864D80-0x0000000180864E60
	public static string GUILD_RAID(int userId); // 0x0000000180864E60-0x0000000180864F40
	public static string GUILD_RAID_RANKING(int userId); // 0x0000000180864F40-0x0000000180865020
	public static string GUILD_RAID_SCHEDULE(int userId); // 0x0000000180865020-0x0000000180865100
	public static string GUILD_RAID_REWARDS(int userId); // 0x0000000180865100-0x00000001808651E0
	public static string GUILD_BOSS_TOP_GUILDS(int userId); // 0x00000001808651E0-0x00000001808652C0
	public static string GUILD_DONATE_GOLD(int userId); // 0x00000001808652C0-0x00000001808653A0
	public static string GUILD_BUY_SLOT(int userId); // 0x00000001808653A0-0x0000000180865480
	public static string GUILD_DETAIL(int userId, long guildId); // 0x0000000180865480-0x00000001808655A0
	public static string GUILD_VAULT(int userId); // 0x00000001808655A0-0x0000000180865680
	public static string GUILD_VAULT_DISTRIBUTE(int userId); // 0x0000000180865680-0x0000000180865760
	public static string PROFILE_GET(long userId); // 0x0000000180865760-0x0000000180865840
	public static string PROFILE_VIEW(long userId, long targetId); // 0x0000000180865840-0x0000000180865960
	public static string INVENTORY_GET(long userId); // 0x0000000180865960-0x0000000180865A40
	public static string EQUIP_BOOK(long userId); // 0x0000000180865A40-0x0000000180865B20
	public static string EQUIP_BAG(long userId, int category, int slot, bool sort, int page); // 0x0000000180865B20-0x0000000180865E40
	public static string EQUIP_ITEM(long userId, long itemId); // 0x0000000180865E40-0x0000000180865F60
	public static string EQUIP_WEAR(long userId); // 0x0000000180865F60-0x0000000180866040
	public static string EQUIP_UNWEAR(long userId); // 0x0000000180866040-0x0000000180866120
	public static string EQUIP_AVATAR_HIDDEN(long userId); // 0x0000000180866120-0x0000000180866200
	public static string EQUIP_UPGRADE_STAR(long userId); // 0x0000000180866200-0x00000001808662E0
	public static string EQUIP_SALVAGE(long userId); // 0x00000001808662E0-0x00000001808663C0
	public static string SHOP_AVATAR_PAGE(long userId, int category, int rarity, bool hideOwned, string sort, int page); // 0x00000001808663C0-0x00000001808666E0
	public static string SHOP_AVATAR_PORTRAITS(long userId); // 0x00000001808666E0-0x00000001808667C0
	public static string CHAT_IMAGE(string id, bool thumb); // 0x00000001808668C0-0x0000000180866A20
}

