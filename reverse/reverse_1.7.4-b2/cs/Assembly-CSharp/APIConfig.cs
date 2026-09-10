/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class APIConfig : MonoBehaviour // TypeDefIndex: 1164
{
	// Fields
	private const string DOMAIN = "pokiguard.online"; // Metadata: 0x0068C66A
	private static readonly bool SECURE; // 0x00
	internal static readonly string BASE_URL; // 0x08
	public const string VERSION = "1.7.4.2"; // Metadata: 0x0068C67B
	public const string DISPLAY_VERSION = "1.7.4"; // Metadata: 0x0068C683
	public static readonly string SOCKET; // 0x10
	public static string GET_ALL_PET; // 0x18
	public static string DEDUCT_GOLD; // 0x20
	public static string BATCH_UPGRADE_STONES; // 0x28
	public static readonly string POST_UNLOCK_LEGEND_PET; // 0x30
	public static readonly string POST_REGISTER; // 0x38
	public static readonly string GET_USER_INFO; // 0x40

	// Properties
	public static bool IsProductionEndpoint { get; } // 0x000000018055FD10-0x000000018055FDD0 
	public static string GET_FEATURE_FLAGS { get; } // 0x000000018055FA70-0x000000018055FAE0 
	public static string APP_TERMS { get; } // 0x000000018055F760-0x000000018055F7D0 
	public static string POST_WEBVIEW_TICKET { get; } // 0x0000000180560150-0x00000001805601C0 
	public static string POST_CLIENT_LOG { get; } // 0x000000018055FF90-0x0000000180560000 
	public static string POST_CLIENT_PERF { get; } // 0x0000000180560000-0x0000000180560070 
	public static string POST_ALL_PET_PAGINATED { get; } // 0x000000018055FF20-0x000000018055FF90 
	public static string CLAIM_EVENT_FEST { get; } // 0x000000018055F8B0-0x000000018055F920 
	public static string FLIP_EVENT_FEST { get; } // 0x000000018055F920-0x000000018055F990 
	public static string POST_USER_LOGIN { get; } // 0x00000001805600E0-0x0000000180560150 
	public static string UPGRADE_PET { get; } // 0x00000001805604D0-0x0000000180560540 
	public static string UPGRADE_STONE { get; } // 0x0000000180560540-0x00000001805605B0 
	public static string GET_ALL_LEGEND_PETS { get; } // 0x000000018055FA00-0x000000018055FA70 
	public static string POST_INLAY_STAR { get; } // 0x0000000180560070-0x00000001805600E0 
	public static string GET_TOP9_RANKING { get; } // 0x000000018055FC30-0x000000018055FCA0 
	public static string GET_TOP30_RANKING { get; } // 0x000000018055FBC0-0x000000018055FC30 
	public static string PVP_RANK_TIERS { get; } // 0x0000000180560380-0x00000001805603F0 
	public static string PVP_RANKING_TOP { get; } // 0x00000001805602A0-0x0000000180560310 
	public static string PVP_RANKING_USER { get; } // 0x0000000180560310-0x0000000180560380 
	public static string PVP_RANKING_HISTORY { get; } // 0x00000001805601C0-0x0000000180560230 
	public static string PVP_RANKING_SEASON { get; } // 0x0000000180560230-0x00000001805602A0 
	public static string USE_CARD { get; } // 0x00000001805605B0-0x0000000180560620 
	public static string GET_LIBRARY_CARDS { get; } // 0x000000018055FAE0-0x000000018055FB50 
	public static string GET_ALL_CARDS_LEGACY { get; } // 0x000000018055F990-0x000000018055FA00 
	public static string HUB_BOOTSTRAP { get; } // 0x000000018055FCA0-0x000000018055FD10 
	public static string ROOM_BOOTSTRAP { get; } // 0x00000001805603F0-0x0000000180560460 
	public static string CLAIM_DAILY_REWARD { get; } // 0x000000018055F840-0x000000018055F8B0 
	public static string GET_RANKING_REWARDS { get; } // 0x000000018055FB50-0x000000018055FBC0 
	public static string ONLINE_USERNAMES { get; } // 0x000000018055FE40-0x000000018055FEB0 
	public static string ONLINE_USERS_WITH_INFO { get; } // 0x000000018055FEB0-0x000000018055FF20 
	public static string ONLINE_STATS { get; } // 0x000000018055FDD0-0x000000018055FE40 
	public static string SHOP_AVATAR_PURCHASE { get; } // 0x0000000180560460-0x00000001805604D0 
	public static string CHAT_IMAGE_UPLOAD { get; } // 0x000000018055F7D0-0x000000018055F840 

	// Constructors
	public APIConfig(); // 0x00000001802EBA70-0x00000001802EBAF0
	static APIConfig(); // 0x000000018055F410-0x000000018055F760

	// Methods
	public static string APP_BOOTSTRAP(string platform, string appVersion); // 0x0000000180555FC0-0x0000000180556110
	public static string APP_UI_CONFIG(string platform, string appVersion); // 0x00000001805563B0-0x0000000180556500
	public static string APP_FLAGS(string platform, string appVersion); // 0x0000000180556260-0x00000001805563B0
	public static string APP_EVENTS(string platform, string appVersion); // 0x0000000180556110-0x0000000180556260
	public static string TERMS_STATUS(int userId); // 0x000000018055EB50-0x000000018055EBF0
	public static string TERMS_ACCEPT(int userId); // 0x000000018055EAB0-0x000000018055EB50
	public static string GET_PETS_ENEMYS(int id); // 0x000000018055A970-0x000000018055AA10
	public static string GET_USER(int id); // 0x000000018055BB80-0x000000018055BC20
	public static string GET_ALL_PET_USERS(int id); // 0x00000001805589E0-0x0000000180558A80
	public static string FIND_USER_BY_NAME(); // 0x0000000180557DD0-0x0000000180557E40
	public static string GET_ALL_PET_USERS_PAGINATED(int id); // 0x0000000180558940-0x00000001805589E0
	public static string GET_EVENT_FEST(int userId); // 0x0000000180559350-0x00000001805593F0
	public static string GET_PET_USERS(int id, int petId); // 0x000000018055AE60-0x000000018055AF20
	public static string GET_ROOM_USERS(int id, int idPet); // 0x000000018055B2B0-0x000000018055B370
	public static string GET_PET_USERS_MATCH(int id, int idPet, int ePetId); // 0x000000018055AC20-0x000000018055AE60
	public static string GET_ENEMYPET_USERS_MATCH(int ePetId, int idPet); // 0x0000000180559150-0x0000000180559210
	public static string GET_PVPPET_MATCH(int pvpPetId, int myPetId, int level); // 0x000000018055AF20-0x000000018055B160
	public static string DOWN_ENERGY(int id); // 0x00000001805573D0-0x0000000180557470
	public static string GET_STONES(int userId); // 0x000000018055B410-0x000000018055B4B0
	public static string CHECK_WHEEL(int userId); // 0x0000000180556A70-0x0000000180556B00
	public static string SPIN_WHEEL(int userId); // 0x000000018055E410-0x000000018055E4A0
	public static string GET_LEGEND_PET_INFO(int userId, int petId); // 0x000000018055A3C0-0x000000018055A480
	public static string GET_ALL_WORLD_BOSSES(int userId); // 0x0000000180558A80-0x0000000180558B20
	public static string BOSS_SWEEP_INFO(int userId, int petId); // 0x00000001805565D0-0x0000000180556690
	public static string BOSS_SWEEP_USE(int userId); // 0x0000000180556690-0x0000000180556730
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE(long userId, long bossScheduleId); // 0x000000018055E640-0x000000018055E710
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 l\u01B0\u1EE3t \u0111\u00E1nh tr\u1EEB t\u1EA1i ROOM_START_MATCH (WebSocket).", false)]
	public static string USE_BOSS_ATTEMPT(long userId, long bossScheduleId); // 0x000000018055F0C0-0x000000018055F190
	public static string GET_BOSS_RANKING(int userId); // 0x0000000180558ED0-0x0000000180558F70
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId); // 0x0000000180556B00-0x0000000180556BD0
	public static string CLAIM_BOSS_REWARD(int userId, int bossScheduleId, string battleDate); // 0x0000000180556BD0-0x0000000180556D20
	public static string GET_USER_DETAIL(int userId); // 0x000000018055B8A0-0x000000018055B940
	public static string GET_ENERGY(int userId); // 0x0000000180559210-0x00000001805592B0
	public static string CONSUME_ENERGY(int userId, int amount); // 0x0000000180557310-0x00000001805573D0
	public static string GET_PENDING_GIFTS(int userId); // 0x000000018055A8D0-0x000000018055A970
	public static string GET_GIFT_COUNT(int userId); // 0x000000018055A280-0x000000018055A320
	public static string CLAIM_GIFT(int giftId, int userId); // 0x0000000180556DF0-0x0000000180556EC0
	public static string GET_CLAIMED_GIFTS(int userId); // 0x0000000180559010-0x00000001805590B0
	public static string GET_SHOP_DATA(int userId); // 0x000000018055B370-0x000000018055B410
	public static string PURCHASE_ITEM(); // 0x000000018055D990-0x000000018055DA00
	public static string PURCHASE_PACKAGE(); // 0x000000018055DA00-0x000000018055DA70
	public static string GET_WHEEL_CONFIG(int userId); // 0x000000018055BFA0-0x000000018055C030
	public static string SPIN_WHEEL_FREE(int userId); // 0x000000018055E2D0-0x000000018055E370
	public static string SPIN_WHEEL_GOLD(int userId); // 0x000000018055E370-0x000000018055E410
	public static string SPIN_WHEEL_BULK(int userId); // 0x000000018055E230-0x000000018055E2D0
	public static string CHECK_FREE_SPIN(int userId); // 0x0000000180556930-0x00000001805569D0
	public static string CHECK_GOLD_SPIN(int userId); // 0x00000001805569D0-0x0000000180556A70
	public static string REDEEM_GIFT_CODE(long userId, string code); // 0x000000018055DB40-0x000000018055DBF0
	public static string GET_USER_PETS(int userId, int page = 0 /* Metadata: 0x0068C65F */, int size = 10 /* Metadata: 0x0068C660 */); // 0x000000018055B940-0x000000018055BB80
	public static string GET_USER_AVATARS(int userId, int page = 0 /* Metadata: 0x0068C661 */, int size = 3 /* Metadata: 0x0068C662 */); // 0x000000018055B5C0-0x000000018055B800
	public static string EQUIP_PET(int userId); // 0x0000000180557910-0x00000001805579B0
	public static string EQUIP_AVATAR(int userId); // 0x0000000180557510-0x00000001805575B0
	public static string GET_EQUIPMENT_COUNT(int userId); // 0x00000001805592B0-0x0000000180559350
	public static string GET_WEAPON_LIST(int userId, int page = 0 /* Metadata: 0x0068C663 */, int size = 8 /* Metadata: 0x0068C664 */); // 0x000000018055BCC0-0x000000018055BF00
	public static string WEAPON_EQUIP(int userId); // 0x000000018055F190-0x000000018055F230
	public static string WEAPON_UNEQUIP(int userId); // 0x000000018055F2D0-0x000000018055F370
	public static string WEAPON_UPGRADE(int userId); // 0x000000018055F370-0x000000018055F410
	public static string WEAPON_SALVAGE(int userId); // 0x000000018055F230-0x000000018055F2D0
	public static string GET_WEAPON_SUMMARY(int userId); // 0x000000018055BF00-0x000000018055BFA0
	public static string GET_WEAPON_EQUIPPED(long targetUserId); // 0x000000018055BC20-0x000000018055BCC0
	public static string GET_PET_SHARDS(int userId); // 0x000000018055AA10-0x000000018055AAB0
	public static string GET_PET_STARS(int userId); // 0x000000018055AAB0-0x000000018055AB50
	public static string GET_PET_STAR_INFO(int userId, long petId); // 0x000000018055AB50-0x000000018055AC20
	public static string PET_STAR_UPGRADE(int userId); // 0x000000018055D780-0x000000018055D820
	public static string PET_SHARD_EXCHANGE(int userId); // 0x000000018055D6E0-0x000000018055D780
	public static string GET_GACHA_BANNERS(int userId); // 0x000000018055A0A0-0x000000018055A140
	public static string GET_GACHA_RATES(long bannerId); // 0x000000018055A1E0-0x000000018055A280
	public static string GACHA_ROLL(int userId); // 0x00000001805588A0-0x0000000180558940
	public static string GET_GACHA_HISTORY(int userId); // 0x000000018055A140-0x000000018055A1E0
	public static string TOWER_INFO(int userId); // 0x000000018055EC90-0x000000018055ED30
	public static string TOWER_RESET_CLAIM(int userId); // 0x000000018055ED30-0x000000018055EDD0
	public static string TOWER_BUY_POWER(int userId); // 0x000000018055EBF0-0x000000018055EC90
	public static string TOWER_TOP(int userId); // 0x000000018055EDD0-0x000000018055EE70
	public static string CLAIM_PET_REWARD(int userId); // 0x0000000180557130-0x00000001805571D0
	public static string GET_DAILY_CHECKINS(int userId); // 0x00000001805590B0-0x0000000180559150
	public static string GET_MILESTONE_STATUS(int userId); // 0x000000018055A680-0x000000018055A720
	public static string CLAIM_MILESTONE(int userId, long milestoneId); // 0x0000000180556F90-0x0000000180557060
	public static string GET_FIRST_TOPUP(int userId); // 0x0000000180559700-0x00000001805597A0
	public static string CLAIM_FIRST_TOPUP(int userId, long tierId); // 0x0000000180556D20-0x0000000180556DF0
	public static string GET_TREASURE_WHEEL(int userId); // 0x000000018055B520-0x000000018055B5C0
	public static string TREASURE_WHEEL_SPIN(int userId); // 0x000000018055EF40-0x000000018055EFE0
	public static string TREASURE_WHEEL_BONUS_CLAIM(int userId, long bonusId); // 0x000000018055EE70-0x000000018055EF40
	public static string GET_RECHARGE_EVENT(int userId); // 0x000000018055B210-0x000000018055B2B0
	public static string RECHARGE_EVENT_CLAIM(int userId, long milestoneId); // 0x000000018055DA70-0x000000018055DB40
	public static string REQUEST_DAMAGE_SIGNATURE(long userId, long bossScheduleId); // 0x000000018055DBF0-0x000000018055DCC0
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 damage do server engine t\u00EDnh, kh\u00F4ng nh\u1EADn s\u1ED1 client khai.", false)]
	public static string SUBMIT_BOSS_DAMAGE_SERVER_SIGNED(long userId, long bossScheduleId); // 0x000000018055E570-0x000000018055E640
	[Obsolete("Endpoint \u0111\u00E3 b\u1ECB xo\u00E1 kh\u1ECFi server \u2014 v\u00F2i b\u01A1m damage kh\u00F4ng rate-limit, KH\u00D4NG kh\u00F4i ph\u1EE5c.", false)]
	public static string SUBMIT_BOSS_DAMAGE_CHECKPOINT(long userId, long bossScheduleId); // 0x000000018055E4A0-0x000000018055E570
	public static string GET_QUESTS(int userId, string questType); // 0x000000018055B160-0x000000018055B210
	public static string UPDATE_QUEST_PROGRESS(); // 0x000000018055EFE0-0x000000018055F050
	public static string CLAIM_QUEST(int userId, long questId); // 0x0000000180557240-0x0000000180557310
	public static string GET_EVOLUTION_PETS(int userId, int page = 0 /* Metadata: 0x0068C665 */, int size = 8 /* Metadata: 0x0068C666 */); // 0x00000001805594C0-0x0000000180559700
	public static string GET_EVOLUTION_DETAIL(int userId, long sourcePetId); // 0x00000001805593F0-0x00000001805594C0
	public static string EVOLVE_PET(int userId, long sourcePetId); // 0x0000000180557C30-0x0000000180557D00
	public static string SWAP_ITEM(int userId, int swapType); // 0x000000018055E9F0-0x000000018055EAB0
	public static string SWAP_ITEM_TT(int userId, int coreIndex, int eItemType); // 0x000000018055E7B0-0x000000018055E9F0
	public static string GET_MONTHLY_RANKING_STATUS(); // 0x000000018055A7C0-0x000000018055A830
	public static string GET_LIFETIME_MILESTONE_STATUS(int userId); // 0x000000018055A480-0x000000018055A520
	public static string GET_ONLINE_GIFT_STATUS(int userId); // 0x000000018055A830-0x000000018055A8D0
	public static string CLAIM_ONLINE_GIFT(int userId, long milestoneId); // 0x0000000180557060-0x0000000180557130
	public static string CLAIM_LIFETIME_MILESTONE(int userId, long milestoneId); // 0x0000000180556EC0-0x0000000180556F90
	public static string SUBMIT_COOP_MATCH_RESULT(int userId); // 0x000000018055E710-0x000000018055E7B0
	public static string GET_CLAIMABLE_PETS(int userId); // 0x0000000180558F70-0x0000000180559010
	public static string CLAIM_PET(); // 0x00000001805571D0-0x0000000180557240
	public static string GET_AVATAR_EXCHANGE_LIST(int userId); // 0x0000000180558B20-0x0000000180558BC0
	public static string EXCHANGE_AVATAR(int userId, long avatarId); // 0x0000000180557D00-0x0000000180557DD0
	public static string CHANGE_NAME(int userId); // 0x0000000180556730-0x00000001805567D0
	public static string GET_USER_CARDS(int userId); // 0x000000018055B800-0x000000018055B8A0
	public static string UPGRADE_CARD(); // 0x000000018055F050-0x000000018055F0C0
	public static string GET_MINIGAME_INFO(int userId); // 0x000000018055A720-0x000000018055A7C0
	public static string SPIN_MINIGAME(); // 0x000000018055E1C0-0x000000018055E230
	public static string GET_THONG_BAO(); // 0x000000018055B4B0-0x000000018055B520
	public static string GET_AWAKENING_PETS(int userId, int page = 0 /* Metadata: 0x0068C667 */, int size = 8 /* Metadata: 0x0068C668 */); // 0x0000000180558C90-0x0000000180558ED0
	public static string GET_AWAKENING_DETAIL(int userId, long sourcePetId); // 0x0000000180558BC0-0x0000000180558C90
	public static string AWAKEN_PET(int userId, long sourcePetId); // 0x0000000180556500-0x00000001805565D0
	public static string GET_FRIENDS(int userId); // 0x00000001805597A0-0x0000000180559840
	public static string GET_FRIEND_BADGE(int userId); // 0x0000000180559840-0x00000001805598E0
	public static string GET_FRIEND_REQUESTS(int userId); // 0x0000000180559EC0-0x0000000180559F60
	public static string SEARCH_FRIEND(int userId, string name); // 0x000000018055DCC0-0x000000018055DD80
	public static string GET_FRIEND_SUGGESTIONS(int userId); // 0x0000000180559F60-0x000000018055A000
	public static string GET_FRIEND_BLOCKED(int userId); // 0x00000001805598E0-0x0000000180559980
	public static string GET_FRIEND_PROFILE(int userId, long friendUserId); // 0x0000000180559DF0-0x0000000180559EC0
	public static string GET_INTIMACY_LEVELS(int userId); // 0x000000018055A320-0x000000018055A3C0
	public static string FRIEND_REQUEST_SEND(int userId, long targetUserId); // 0x0000000180558560-0x0000000180558630
	public static string FRIEND_REQUEST_ACCEPT(int userId, long requestId); // 0x00000001805582F0-0x00000001805583C0
	public static string FRIEND_REQUEST_DECLINE(int userId, long requestId); // 0x0000000180558490-0x0000000180558560
	public static string FRIEND_REQUEST_CANCEL(int userId, long requestId); // 0x00000001805583C0-0x0000000180558490
	public static string FRIEND_REMOVE(int userId, long friendUserId); // 0x0000000180558220-0x00000001805582F0
	public static string FRIEND_BLOCK(int userId, long targetUserId); // 0x0000000180557E40-0x0000000180557F10
	public static string FRIEND_UNBLOCK(int userId, long targetUserId); // 0x00000001805587D0-0x00000001805588A0
	public static string FRIEND_SET_NICKNAME(int userId, long friendUserId); // 0x0000000180558630-0x0000000180558700
	public static string FRIEND_SET_PIN(int userId, long friendUserId); // 0x0000000180558700-0x00000001805587D0
	public static string FRIEND_INTIMACY_CLAIM(int userId, long friendUserId, int level); // 0x0000000180557FE0-0x0000000180558220
	public static string FRIEND_ENERGY_GIFT(int userId, long friendUserId); // 0x0000000180557F10-0x0000000180557FE0
	public static string GET_FRIEND_MESSAGES(int userId, long friendUserId, long beforeId, int limit); // 0x0000000180559980-0x0000000180559DF0
	public static string SEND_FRIEND_MESSAGE(int userId, long friendUserId); // 0x000000018055DD80-0x000000018055DE50
	public static string MARK_FRIEND_MESSAGES_READ(int userId, long friendUserId); // 0x000000018055D430-0x000000018055D500
	public static string GET_FRIEND_UNREAD_COUNTS(int userId); // 0x000000018055A000-0x000000018055A0A0
	public static string GET_MID_AUTUMN(int userId); // 0x000000018055A5E0-0x000000018055A680
	public static string GET_MID_AUTUMN_RANKING(int userId, int limit = 30 /* Metadata: 0x0068C669 */); // 0x000000018055A520-0x000000018055A5E0
	public static string MID_AUTUMN_CLAIM(int userId); // 0x000000018055D500-0x000000018055D5A0
	public static string MID_AUTUMN_FLIP(int userId); // 0x000000018055D640-0x000000018055D6E0
	public static string MID_AUTUMN_CRAFT(int userId); // 0x000000018055D5A0-0x000000018055D640
	public static string GUILD_HOME(int userId); // 0x000000018055C740-0x000000018055C7E0
	public static string GUILD_LIST(int userId, int page, string q); // 0x000000018055C920-0x000000018055CB70
	public static string GUILD_CREATE(int userId); // 0x000000018055C490-0x000000018055C530
	public static string GUILD_INFO(int userId); // 0x000000018055C7E0-0x000000018055C880
	public static string GUILD_REQUEST_JOIN(int userId); // 0x000000018055D110-0x000000018055D1B0
	public static string GUILD_REQUEST_CANCEL(int userId); // 0x000000018055CFD0-0x000000018055D070
	public static string GUILD_REQUESTS(int userId); // 0x000000018055CE90-0x000000018055CF30
	public static string GUILD_REQUEST_ACCEPT(int userId); // 0x000000018055CF30-0x000000018055CFD0
	public static string GUILD_REQUEST_DECLINE(int userId); // 0x000000018055D070-0x000000018055D110
	public static string GUILD_MEMBER_PROMOTE(int userId); // 0x000000018055CCB0-0x000000018055CD50
	public static string GUILD_MEMBER_DEMOTE(int userId); // 0x000000018055CB70-0x000000018055CC10
	public static string GUILD_MEMBER_KICK(int userId); // 0x000000018055CC10-0x000000018055CCB0
	public static string GUILD_LEAVE(int userId); // 0x000000018055C880-0x000000018055C920
	public static string GUILD_EDIT(int userId); // 0x000000018055C6A0-0x000000018055C740
	public static string GUILD_RENAME(int userId); // 0x000000018055CDF0-0x000000018055CE90
	public static string GUILD_RECRUIT(int userId); // 0x000000018055CD50-0x000000018055CDF0
	public static string GUILD_SHOP(int userId); // 0x000000018055D2F0-0x000000018055D390
	public static string GUILD_SHOP_BUY(int userId); // 0x000000018055D1B0-0x000000018055D250
	public static string GUILD_SHOP_RESET(int userId); // 0x000000018055D250-0x000000018055D2F0
	public static string GUILD_BOSS(int userId); // 0x000000018055C350-0x000000018055C3F0
	public static string GUILD_BOSS_START(int userId); // 0x000000018055C210-0x000000018055C2B0
	public static string GUILD_BOSS_HUNT_CLAIM(int userId); // 0x000000018055C030-0x000000018055C0D0
	public static string GUILD_BOSS_RANKING(int userId); // 0x000000018055C0D0-0x000000018055C170
	public static string GUILD_BOSS_TOP_GUILDS(int userId); // 0x000000018055C2B0-0x000000018055C350
	public static string GUILD_BOSS_REWARDS(int userId); // 0x000000018055C170-0x000000018055C210
	public static string GUILD_DONATE_GOLD(int userId); // 0x000000018055C600-0x000000018055C6A0
	public static string GUILD_BUY_SLOT(int userId); // 0x000000018055C3F0-0x000000018055C490
	public static string GUILD_DETAIL(int userId, long guildId); // 0x000000018055C530-0x000000018055C600
	public static string PROFILE_GET(long userId); // 0x000000018055D820-0x000000018055D8C0
	public static string PROFILE_VIEW(long userId, long targetId); // 0x000000018055D8C0-0x000000018055D990
	public static string INVENTORY_GET(long userId); // 0x000000018055D390-0x000000018055D430
	public static string EQUIP_BOOK(long userId); // 0x0000000180557870-0x0000000180557910
	public static string EQUIP_BAG(long userId, int category, int slot, bool sort, int page); // 0x00000001805575B0-0x0000000180557870
	public static string EQUIP_WEAR(long userId); // 0x0000000180557B90-0x0000000180557C30
	public static string EQUIP_UNWEAR(long userId); // 0x0000000180557A50-0x0000000180557AF0
	public static string EQUIP_AVATAR_HIDDEN(long userId); // 0x0000000180557470-0x0000000180557510
	public static string EQUIP_UPGRADE_STAR(long userId); // 0x0000000180557AF0-0x0000000180557B90
	public static string EQUIP_SALVAGE(long userId); // 0x00000001805579B0-0x0000000180557A50
	public static string SHOP_AVATAR_PAGE(long userId, int category, int rarity, bool hideOwned, string sort, int page); // 0x000000018055DE50-0x000000018055E120
	public static string SHOP_AVATAR_PORTRAITS(long userId); // 0x000000018055E120-0x000000018055E1C0
	public static string CHAT_IMAGE(string id, bool thumb); // 0x00000001805567D0-0x0000000180556930
}

