/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class APIConfig : MonoBehaviour // TypeDefIndex: 967
{
	// Fields
	private const string DOMAIN = "pokiguard.online"; // Metadata: 0x0064CE8D
	private static readonly bool SECURE; // 0x00
	internal static readonly string BASE_URL; // 0x08
	public const string VERSION = "1.7.4"; // Metadata: 0x0064CE9E
	public static readonly string SOCKET; // 0x10
	public static string GET_ALL_PET; // 0x18
	public static string DEDUCT_GOLD; // 0x20
	public static string BATCH_UPGRADE_STONES; // 0x28
	public static readonly string POST_UNLOCK_LEGEND_PET; // 0x30
	public static readonly string POST_REGISTER; // 0x38
	public static readonly string GET_USER_INFO; // 0x40

	// Properties
	public static bool IsProductionEndpoint { get; } // 0x000000018046EA30-0x000000018046EAF0 
	public static string GET_FEATURE_FLAGS { get; } // 0x000000018046E800-0x000000018046E870 
	public static string APP_TERMS { get; } // 0x000000018046E5D0-0x000000018046E640 
	public static string POST_WEBVIEW_TICKET { get; } // 0x000000018046EE00-0x000000018046EE70 
	public static string POST_CLIENT_LOG { get; } // 0x000000018046ECB0-0x000000018046ED20 
	public static string POST_ALL_PET_PAGINATED { get; } // 0x000000018046EC40-0x000000018046ECB0 
	public static string CLAIM_EVENT_FEST { get; } // 0x000000018046E6B0-0x000000018046E720 
	public static string FLIP_EVENT_FEST { get; } // 0x000000018046E720-0x000000018046E790 
	public static string POST_USER_LOGIN { get; } // 0x000000018046ED90-0x000000018046EE00 
	public static string UPGRADE_PET { get; } // 0x000000018046F110-0x000000018046F180 
	public static string UPGRADE_STONE { get; } // 0x000000018046F180-0x000000018046F1F0 
	public static string GET_ALL_LEGEND_PETS { get; } // 0x000000018046E790-0x000000018046E800 
	public static string POST_INLAY_STAR { get; } // 0x000000018046ED20-0x000000018046ED90 
	public static string GET_TOP9_RANKING { get; } // 0x000000018046E950-0x000000018046E9C0 
	public static string GET_TOP30_RANKING { get; } // 0x000000018046E8E0-0x000000018046E950 
	public static string PVP_RANK_TIERS { get; } // 0x000000018046F030-0x000000018046F0A0 
	public static string PVP_RANKING_TOP { get; } // 0x000000018046EF50-0x000000018046EFC0 
	public static string PVP_RANKING_USER { get; } // 0x000000018046EFC0-0x000000018046F030 
	public static string PVP_RANKING_HISTORY { get; } // 0x000000018046EE70-0x000000018046EEE0 
	public static string PVP_RANKING_SEASON { get; } // 0x000000018046EEE0-0x000000018046EF50 
	public static string USE_CARD { get; } // 0x000000018046F1F0-0x000000018046F260 
	public static string HUB_BOOTSTRAP { get; } // 0x000000018046E9C0-0x000000018046EA30 
	public static string ROOM_BOOTSTRAP { get; } // 0x000000018046F0A0-0x000000018046F110 
	public static string CLAIM_DAILY_REWARD { get; } // 0x000000018046E640-0x000000018046E6B0 
	public static string GET_RANKING_REWARDS { get; } // 0x000000018046E870-0x000000018046E8E0 
	public static string ONLINE_USERNAMES { get; } // 0x000000018046EB60-0x000000018046EBD0 
	public static string ONLINE_USERS_WITH_INFO { get; } // 0x000000018046EBD0-0x000000018046EC40 
	public static string ONLINE_STATS { get; } // 0x000000018046EAF0-0x000000018046EB60 

	// Constructors
	public APIConfig(); // 0x00000001802E7A70-0x00000001802E7BC0
	static APIConfig(); // 0x000000018046E280-0x000000018046E5D0

	// Methods
	public static string APP_BOOTSTRAP(string platform, string appVersion); // 0x0000000180467050-0x00000001804671A0
	public static string APP_UI_CONFIG(string platform, string appVersion); // 0x0000000180467440-0x0000000180467590
	public static string APP_FLAGS(string platform, string appVersion); // 0x00000001804672F0-0x0000000180467440
	public static string APP_EVENTS(string platform, string appVersion); // 0x00000001804671A0-0x00000001804672F0
	public static string TERMS_STATUS(int userId); // 0x000000018046D9C0-0x000000018046DA60
	public static string TERMS_ACCEPT(int userId); // 0x000000018046D920-0x000000018046D9C0
	public static string GET_PETS_ENEMYS(int id); // 0x000000018046B0C0-0x000000018046B160
	public static string GET_USER(int id); // 0x000000018046C2D0-0x000000018046C370
	public static string GET_ALL_PET_USERS(int id); // 0x0000000180469130-0x00000001804691D0
	public static string FIND_USER_BY_NAME(); // 0x0000000180468520-0x0000000180468590
	public static string GET_ALL_PET_USERS_PAGINATED(int id); // 0x0000000180469090-0x0000000180469130
	public static string GET_EVENT_FEST(int userId); // 0x0000000180469AA0-0x0000000180469B40
	public static string GET_PET_USERS(int id, int petId); // 0x000000018046B5B0-0x000000018046B670
	public static string GET_ROOM_USERS(int id, int idPet); // 0x000000018046BA00-0x000000018046BAC0
	public static string GET_PET_USERS_MATCH(int id, int idPet, int ePetId); // 0x000000018046B370-0x000000018046B5B0
	public static string GET_ENEMYPET_USERS_MATCH(int ePetId, int idPet); // 0x00000001804698A0-0x0000000180469960
	public static string GET_PVPPET_MATCH(int pvpPetId, int myPetId, int level); // 0x000000018046B670-0x000000018046B8B0
	public static string DOWN_ENERGY(int id); // 0x00000001804681A0-0x0000000180468240
	public static string GET_STONES(int userId); // 0x000000018046BB60-0x000000018046BC00
	public static string CHECK_WHEEL(int userId); // 0x0000000180467840-0x00000001804678D0
	public static string SPIN_WHEEL(int userId); // 0x000000018046D280-0x000000018046D310
	public static string GET_LEGEND_PET_INFO(int userId, int petId); // 0x000000018046AB10-0x000000018046ABD0
	public static string GET_ALL_WORLD_BOSSES(int userId); // 0x00000001804691D0-0x0000000180469270
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE(long userId, long bossScheduleId); // 0x000000018046D4B0-0x000000018046D580
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 l\u01B0\u1EE3t \u0111\u00E1nh tr\u1EEB t\u1EA1i ROOM_START_MATCH (WebSocket).", false)]
	public static string USE_BOSS_ATTEMPT(long userId, long bossScheduleId); // 0x000000018046DF30-0x000000018046E000
	public static string GET_BOSS_RANKING(int userId); // 0x0000000180469620-0x00000001804696C0
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId); // 0x00000001804678D0-0x00000001804679A0
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId, string battleDate); // 0x00000001804679A0-0x0000000180467AF0
	public static string GET_USER_DETAIL(int userId); // 0x000000018046BFF0-0x000000018046C090
	public static string GET_ENERGY(int userId); // 0x0000000180469960-0x0000000180469A00
	public static string CONSUME_ENERGY(int userId, int amount); // 0x00000001804680E0-0x00000001804681A0
	public static string GET_PENDING_GIFTS(int userId); // 0x000000018046B020-0x000000018046B0C0
	public static string GET_GIFT_COUNT(int userId); // 0x000000018046A9D0-0x000000018046AA70
	public static string CLAIM_GIFT(int giftId, int userId); // 0x0000000180467BC0-0x0000000180467C90
	public static string GET_CLAIMED_GIFTS(int userId); // 0x0000000180469760-0x0000000180469800
	public static string GET_SHOP_DATA(int userId); // 0x000000018046BAC0-0x000000018046BB60
	public static string PURCHASE_ITEM(); // 0x000000018046CB70-0x000000018046CBE0
	public static string PURCHASE_PACKAGE(); // 0x000000018046CBE0-0x000000018046CC50
	public static string GET_WHEEL_CONFIG(int userId); // 0x000000018046C6F0-0x000000018046C780
	public static string SPIN_WHEEL_FREE(int userId); // 0x000000018046D140-0x000000018046D1E0
	public static string SPIN_WHEEL_GOLD(int userId); // 0x000000018046D1E0-0x000000018046D280
	public static string SPIN_WHEEL_BULK(int userId); // 0x000000018046D0A0-0x000000018046D140
	public static string CHECK_FREE_SPIN(int userId); // 0x0000000180467700-0x00000001804677A0
	public static string CHECK_GOLD_SPIN(int userId); // 0x00000001804677A0-0x0000000180467840
	public static string REDEEM_GIFT_CODE(long userId, string code); // 0x000000018046CD20-0x000000018046CDD0
	public static string GET_USER_PETS(int userId, int page = 0 /* Metadata: 0x0064CE82 */, int size = 10 /* Metadata: 0x0064CE83 */); // 0x000000018046C090-0x000000018046C2D0
	public static string GET_USER_AVATARS(int userId, int page = 0 /* Metadata: 0x0064CE84 */, int size = 3 /* Metadata: 0x0064CE85 */); // 0x000000018046BD10-0x000000018046BF50
	public static string EQUIP_PET(int userId); // 0x00000001804682E0-0x0000000180468380
	public static string EQUIP_AVATAR(int userId); // 0x0000000180468240-0x00000001804682E0
	public static string GET_EQUIPMENT_COUNT(int userId); // 0x0000000180469A00-0x0000000180469AA0
	public static string GET_WEAPON_LIST(int userId, int page = 0 /* Metadata: 0x0064CE86 */, int size = 8 /* Metadata: 0x0064CE87 */); // 0x000000018046C410-0x000000018046C650
	public static string WEAPON_EQUIP(int userId); // 0x000000018046E000-0x000000018046E0A0
	public static string WEAPON_UNEQUIP(int userId); // 0x000000018046E140-0x000000018046E1E0
	public static string WEAPON_UPGRADE(int userId); // 0x000000018046E1E0-0x000000018046E280
	public static string WEAPON_SALVAGE(int userId); // 0x000000018046E0A0-0x000000018046E140
	public static string GET_WEAPON_SUMMARY(int userId); // 0x000000018046C650-0x000000018046C6F0
	public static string GET_WEAPON_EQUIPPED(long targetUserId); // 0x000000018046C370-0x000000018046C410
	public static string GET_PET_SHARDS(int userId); // 0x000000018046B160-0x000000018046B200
	public static string GET_PET_STARS(int userId); // 0x000000018046B200-0x000000018046B2A0
	public static string GET_PET_STAR_INFO(int userId, long petId); // 0x000000018046B2A0-0x000000018046B370
	public static string PET_STAR_UPGRADE(int userId); // 0x000000018046CAD0-0x000000018046CB70
	public static string PET_SHARD_EXCHANGE(int userId); // 0x000000018046CA30-0x000000018046CAD0
	public static string GET_GACHA_BANNERS(int userId); // 0x000000018046A7F0-0x000000018046A890
	public static string GET_GACHA_RATES(long bannerId); // 0x000000018046A930-0x000000018046A9D0
	public static string GACHA_ROLL(int userId); // 0x0000000180468FF0-0x0000000180469090
	public static string GET_GACHA_HISTORY(int userId); // 0x000000018046A890-0x000000018046A930
	public static string TOWER_INFO(int userId); // 0x000000018046DB00-0x000000018046DBA0
	public static string TOWER_RESET_CLAIM(int userId); // 0x000000018046DBA0-0x000000018046DC40
	public static string TOWER_BUY_POWER(int userId); // 0x000000018046DA60-0x000000018046DB00
	public static string TOWER_TOP(int userId); // 0x000000018046DC40-0x000000018046DCE0
	public static string CLAIM_PET_REWARD(int userId); // 0x0000000180467F00-0x0000000180467FA0
	public static string GET_DAILY_CHECKINS(int userId); // 0x0000000180469800-0x00000001804698A0
	public static string GET_MILESTONE_STATUS(int userId); // 0x000000018046ADD0-0x000000018046AE70
	public static string CLAIM_MILESTONE(int userId, long milestoneId); // 0x0000000180467D60-0x0000000180467E30
	public static string GET_FIRST_TOPUP(int userId); // 0x0000000180469E50-0x0000000180469EF0
	public static string CLAIM_FIRST_TOPUP(int userId, long tierId); // 0x0000000180467AF0-0x0000000180467BC0
	public static string GET_TREASURE_WHEEL(int userId); // 0x000000018046BC70-0x000000018046BD10
	public static string TREASURE_WHEEL_SPIN(int userId); // 0x000000018046DDB0-0x000000018046DE50
	public static string TREASURE_WHEEL_BONUS_CLAIM(int userId, long bonusId); // 0x000000018046DCE0-0x000000018046DDB0
	public static string GET_RECHARGE_EVENT(int userId); // 0x000000018046B960-0x000000018046BA00
	public static string RECHARGE_EVENT_CLAIM(int userId, long milestoneId); // 0x000000018046CC50-0x000000018046CD20
	public static string REQUEST_DAMAGE_SIGNATURE(long userId, long bossScheduleId); // 0x000000018046CDD0-0x000000018046CEA0
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE_SERVER_SIGNED(long userId, long bossScheduleId); // 0x000000018046D3E0-0x000000018046D4B0
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 v\u00F2i b\u01A1m damage kh\u00F4ng rate-limit, KH\u00D4NG kh\u00F4i ph\u1EE5c.", false)]
	public static string SUBMIT_BOSS_DAMAGE_CHECKPOINT(long userId, long bossScheduleId); // 0x000000018046D310-0x000000018046D3E0
	public static string GET_QUESTS(int userId, string questType); // 0x000000018046B8B0-0x000000018046B960
	public static string UPDATE_QUEST_PROGRESS(); // 0x000000018046DE50-0x000000018046DEC0
	public static string CLAIM_QUEST(int userId, long questId); // 0x0000000180468010-0x00000001804680E0
	public static string GET_EVOLUTION_PETS(int userId, int page = 0 /* Metadata: 0x0064CE88 */, int size = 8 /* Metadata: 0x0064CE89 */); // 0x0000000180469C10-0x0000000180469E50
	public static string GET_EVOLUTION_DETAIL(int userId, long sourcePetId); // 0x0000000180469B40-0x0000000180469C10
	public static string EVOLVE_PET(int userId, long sourcePetId); // 0x0000000180468380-0x0000000180468450
	public static string SWAP_ITEM(int userId, int swapType); // 0x000000018046D860-0x000000018046D920
	public static string SWAP_ITEM_TT(int userId, int coreIndex, int eItemType); // 0x000000018046D620-0x000000018046D860
	public static string GET_MONTHLY_RANKING_STATUS(); // 0x000000018046AF10-0x000000018046AF80
	public static string GET_LIFETIME_MILESTONE_STATUS(int userId); // 0x000000018046ABD0-0x000000018046AC70
	public static string GET_ONLINE_GIFT_STATUS(int userId); // 0x000000018046AF80-0x000000018046B020
	public static string CLAIM_ONLINE_GIFT(int userId, long milestoneId); // 0x0000000180467E30-0x0000000180467F00
	public static string CLAIM_LIFETIME_MILESTONE(int userId, long milestoneId); // 0x0000000180467C90-0x0000000180467D60
	public static string SUBMIT_COOP_MATCH_RESULT(int userId); // 0x000000018046D580-0x000000018046D620
	public static string GET_CLAIMABLE_PETS(int userId); // 0x00000001804696C0-0x0000000180469760
	public static string CLAIM_PET(); // 0x0000000180467FA0-0x0000000180468010
	public static string GET_AVATAR_EXCHANGE_LIST(int userId); // 0x0000000180469270-0x0000000180469310
	public static string EXCHANGE_AVATAR(int userId, long avatarId); // 0x0000000180468450-0x0000000180468520
	public static string CHANGE_NAME(int userId); // 0x0000000180467660-0x0000000180467700
	public static string GET_USER_CARDS(int userId); // 0x000000018046BF50-0x000000018046BFF0
	public static string UPGRADE_CARD(); // 0x000000018046DEC0-0x000000018046DF30
	public static string GET_MINIGAME_INFO(int userId); // 0x000000018046AE70-0x000000018046AF10
	public static string SPIN_MINIGAME(); // 0x000000018046D030-0x000000018046D0A0
	public static string GET_THONG_BAO(); // 0x000000018046BC00-0x000000018046BC70
	public static string GET_AWAKENING_PETS(int userId, int page = 0 /* Metadata: 0x0064CE8A */, int size = 8 /* Metadata: 0x0064CE8B */); // 0x00000001804693E0-0x0000000180469620
	public static string GET_AWAKENING_DETAIL(int userId, long sourcePetId); // 0x0000000180469310-0x00000001804693E0
	public static string AWAKEN_PET(int userId, long sourcePetId); // 0x0000000180467590-0x0000000180467660
	public static string GET_FRIENDS(int userId); // 0x0000000180469EF0-0x0000000180469F90
	public static string GET_FRIEND_BADGE(int userId); // 0x0000000180469F90-0x000000018046A030
	public static string GET_FRIEND_REQUESTS(int userId); // 0x000000018046A610-0x000000018046A6B0
	public static string SEARCH_FRIEND(int userId, string name); // 0x000000018046CEA0-0x000000018046CF60
	public static string GET_FRIEND_SUGGESTIONS(int userId); // 0x000000018046A6B0-0x000000018046A750
	public static string GET_FRIEND_BLOCKED(int userId); // 0x000000018046A030-0x000000018046A0D0
	public static string GET_FRIEND_PROFILE(int userId, long friendUserId); // 0x000000018046A540-0x000000018046A610
	public static string GET_INTIMACY_LEVELS(int userId); // 0x000000018046AA70-0x000000018046AB10
	public static string FRIEND_REQUEST_SEND(int userId, long targetUserId); // 0x0000000180468CB0-0x0000000180468D80
	public static string FRIEND_REQUEST_ACCEPT(int userId, long requestId); // 0x0000000180468A40-0x0000000180468B10
	public static string FRIEND_REQUEST_DECLINE(int userId, long requestId); // 0x0000000180468BE0-0x0000000180468CB0
	public static string FRIEND_REQUEST_CANCEL(int userId, long requestId); // 0x0000000180468B10-0x0000000180468BE0
	public static string FRIEND_REMOVE(int userId, long friendUserId); // 0x0000000180468970-0x0000000180468A40
	public static string FRIEND_BLOCK(int userId, long targetUserId); // 0x0000000180468590-0x0000000180468660
	public static string FRIEND_UNBLOCK(int userId, long targetUserId); // 0x0000000180468F20-0x0000000180468FF0
	public static string FRIEND_SET_NICKNAME(int userId, long friendUserId); // 0x0000000180468D80-0x0000000180468E50
	public static string FRIEND_SET_PIN(int userId, long friendUserId); // 0x0000000180468E50-0x0000000180468F20
	public static string FRIEND_INTIMACY_CLAIM(int userId, long friendUserId, int level); // 0x0000000180468730-0x0000000180468970
	public static string FRIEND_ENERGY_GIFT(int userId, long friendUserId); // 0x0000000180468660-0x0000000180468730
	public static string GET_FRIEND_MESSAGES(int userId, long friendUserId, long beforeId, int limit); // 0x000000018046A0D0-0x000000018046A540
	public static string SEND_FRIEND_MESSAGE(int userId, long friendUserId); // 0x000000018046CF60-0x000000018046D030
	public static string MARK_FRIEND_MESSAGES_READ(int userId, long friendUserId); // 0x000000018046C780-0x000000018046C850
	public static string GET_FRIEND_UNREAD_COUNTS(int userId); // 0x000000018046A750-0x000000018046A7F0
	public static string GET_MID_AUTUMN(int userId); // 0x000000018046AD30-0x000000018046ADD0
	public static string GET_MID_AUTUMN_RANKING(int userId, int limit = 30 /* Metadata: 0x0064CE8C */); // 0x000000018046AC70-0x000000018046AD30
	public static string MID_AUTUMN_CLAIM(int userId); // 0x000000018046C850-0x000000018046C8F0
	public static string MID_AUTUMN_FLIP(int userId); // 0x000000018046C990-0x000000018046CA30
	public static string MID_AUTUMN_CRAFT(int userId); // 0x000000018046C8F0-0x000000018046C990
}

