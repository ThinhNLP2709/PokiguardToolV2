/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerView : MonoBehaviour // TypeDefIndex: 2432
	{
		// Fields
		public const string N_NAME = "txt_PlayerName"; // Metadata: 0x0068F2FA
		public const string N_CLUB = "txt_ClubName"; // Metadata: 0x0068F309
		public const string N_EQUIP_POWER = "txt_EquipPowerValue"; // Metadata: 0x0068F316
		public const string N_LEVEL = "txt_Level"; // Metadata: 0x0068F32A
		public const string N_POWER_TOTAL = "txt_PowerTotal"; // Metadata: 0x0068F334
		public const string N_POWER_RANK = "txt_PowerRank"; // Metadata: 0x0068F343
		public const string N_ARENA_ELO = "txt_ArenaElo"; // Metadata: 0x0068F351
		public const string N_ARENA_RANK = "txt_ArenaRank"; // Metadata: 0x0068F35E
		public const string N_ATTACK = "txt_Attack"; // Metadata: 0x0068F36C
		public const string N_DEFENCE = "txt_Defence"; // Metadata: 0x0068F377
		public const string N_HEALTH = "txt_Health"; // Metadata: 0x0068F383
		public const string N_ELEM_PREFIX = "txt_Elem"; // Metadata: 0x0068F38E
		public const string N_PET_COUNT = "txt_PetCount"; // Metadata: 0x0068F397
		public const string N_HONOR = "txt_Honor"; // Metadata: 0x0068F3A4
		public const string N_GOLD = "txt_Gold"; // Metadata: 0x0068F3AE
		public const string N_STAR = "txt_StarShard"; // Metadata: 0x0068F3B7
		public const string N_TICKET = "txt_Ticket"; // Metadata: 0x0068F3C5
		public const string N_CURRENCY_BAR = "sec_CurrencyBar"; // Metadata: 0x0068F3D0
		public const string N_BTN_EQUIPMENT = "btn_EquipmentChar"; // Metadata: 0x0068F3E0
		public const string N_BTN_VIEW_PETS = "btn_ViewPets"; // Metadata: 0x0068F3F2
		public const string N_BTN_VIEW_CARDS = "btn_ViewCards"; // Metadata: 0x0068F3FF
		public const string N_BTN_VIEW_ITEMS = "btn_ViewItems"; // Metadata: 0x0068F40D
		public const string N_VIP_BADGE = "img_VipBadge"; // Metadata: 0x0068F41B
		public const string N_LEVEL_BADGE = "img_LevelBadge"; // Metadata: 0x0068F428
		public const string N_ELO_EMBLEM = "img_EloEmblem"; // Metadata: 0x0068F437
		public const string LEVEL_FRAME_DIR = "Image/hclv/"; // Metadata: 0x0068F445
		public const string ARENA_TIER_DIR = "Image/hc/"; // Metadata: 0x0068F451
		[Header("Khung nh\u00E2n v\u1EADt")]
		public UnityEngine.UI.Text txtPlayerName; // 0x20
		public UnityEngine.UI.Text txtClubName; // 0x28
		public UnityEngine.UI.Text txtEquipPowerValue; // 0x30
		public UnityEngine.UI.Text txtLevel; // 0x38
		[Header("Th\u00E0nh t\u00EDch")]
		public UnityEngine.UI.Text txtPowerTotal; // 0x40
		public UnityEngine.UI.Text txtPowerRank; // 0x48
		public UnityEngine.UI.Text txtArenaElo; // 0x50
		public UnityEngine.UI.Text txtArenaRank; // 0x58
		[Header("Th\u00F4ng s\u1ED1 chi\u1EBFn \u0111\u1EA5u")]
		public UnityEngine.UI.Text txtAttack; // 0x60
		[Tooltip("\uD83D\uDD34 \u00D4 GI\u1EEEA hi\u1EC3n th\u1ECB MANA, kh\u00F4ng ph\u1EA3i ph\u00F2ng th\u1EE7 (bi\u1EC3u t\u01B0\u1EE3ng l\u00E0 \u1ED1ng nghi\u1EC7m).")]
		public UnityEngine.UI.Text txtDefence; // 0x68
		public UnityEngine.UI.Text txtHealth; // 0x70
		[Tooltip("N\u0103m \u00F4 theo TH\u1EE8 T\u1EF0 HI\u1EC2N TH\u1ECA Kim\u2013M\u1ED9c\u2013Thu\u1EF7\u2013Ho\u1EA3\u2013Th\u1ED5. Kh\u00F4ng s\u1EAFp l\u1EA1i theo enum h\u1EC7.")]
		public UnityEngine.UI.Text[] txtElem; // 0x78
		[Header("\u00D4 n\u1ED9i dung + v\u00ED")]
		public UnityEngine.UI.Text txtPetCount; // 0x80
		public UnityEngine.UI.Text txtHonor; // 0x88
		public UnityEngine.UI.Text txtGold; // 0x90
		public UnityEngine.UI.Text txtStarShard; // 0x98
		public UnityEngine.UI.Text txtTicket; // 0xA0
		[Header("\u1EA2nh \u0111\u1ED5i theo d\u1EEF li\u1EC7u")]
		public Image imgLevelBadge; // 0xA8
		public Image imgEloEmblem; // 0xB0
		public GameObject vipBadge; // 0xB8
		[Header("T\u1EAFt khi xem h\u1ED3 s\u01A1 NG\u01AF\u1EDCI KH\u00C1C (\u00A73.3)")]
		public GameObject currencyBar; // 0xC0
		public GameObject equipButton; // 0xC8
		public GameObject viewPetsButton; // 0xD0
		public GameObject viewCardsButton; // 0xD8
		public GameObject viewItemsButton; // 0xE0
		private bool _resolved; // 0xE8
	
		// Constructors
		public InfoPlayerView(); // 0x0000000180804A70-0x0000000180804AD0
	
		// Methods
		private void Awake(); // 0x0000000180802C70-0x0000000180802C80
		public void ResolveNodes(); // 0x0000000180803950-0x00000001808042A0
		private UnityEngine.UI.Text Label(string node, StringBuilder missing); // 0x0000000180803690-0x00000001808037C0
		private Image Picture(string node); // 0x0000000180803880-0x0000000180803950
		private GameObject Node(string node); // 0x00000001808037C0-0x0000000180803880
		private void HardenTextFields(); // 0x0000000180802C80-0x0000000180803690
		private static void ScaleText(UnityEngine.UI.Text label, float scale); // 0x00000001808042A0-0x0000000180804340
		public void ShowPlaceholders(); // 0x0000000180804550-0x0000000180804A70
		public void ApplyProfile(ProfileDTO p); // 0x00000001808023F0-0x0000000180802A40
		private void ApplyWallet(ProfileResDTO res); // 0x0000000180802B00-0x0000000180802C70
		private void ApplyBadges(ProfileDTO p); // 0x00000001808022D0-0x00000001808023F0
		private static void ApplySprite(Image target, string dir, string key); // 0x0000000180802A40-0x0000000180802B00
		public void SetOtherMode(bool isOther); // 0x0000000180804340-0x00000001808044A0
		private static void Set(UnityEngine.UI.Text label, string value); // 0x00000001808044A0-0x0000000180804550
	}
}
