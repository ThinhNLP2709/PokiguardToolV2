/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerView : MonoBehaviour // TypeDefIndex: 2884
	{
		// Fields
		public const string N_NAME = "txt_PlayerName"; // Metadata: 0x005F3427
		public const string N_CLUB = "txt_ClubName"; // Metadata: 0x005F3436
		public const string N_EQUIP_POWER = "txt_EquipPowerValue"; // Metadata: 0x005F3443
		public const string N_LEVEL = "txt_Level"; // Metadata: 0x005F3457
		public const string N_POWER_TOTAL = "txt_PowerTotal"; // Metadata: 0x005F3461
		public const string N_POWER_RANK = "txt_PowerRank"; // Metadata: 0x005F3470
		public const string N_ARENA_ELO = "txt_ArenaElo"; // Metadata: 0x005F347E
		public const string N_ARENA_RANK = "txt_ArenaRank"; // Metadata: 0x005F348B
		public const string N_ATTACK = "txt_Attack"; // Metadata: 0x005F3499
		public const string N_DEFENCE = "txt_Defence"; // Metadata: 0x005F34A4
		public const string N_HEALTH = "txt_Health"; // Metadata: 0x005F34B0
		public const string N_ELEM_PREFIX = "txt_Elem"; // Metadata: 0x005F34BB
		public const string N_PET_COUNT = "txt_PetCount"; // Metadata: 0x005F34C4
		public const string N_HONOR = "txt_Honor"; // Metadata: 0x005F34D1
		public const string N_GOLD = "txt_Gold"; // Metadata: 0x005F34DB
		public const string N_STAR = "txt_StarShard"; // Metadata: 0x005F34E4
		public const string N_TICKET = "txt_Ticket"; // Metadata: 0x005F34F2
		public const string N_PERK_SUMMARY = "txt_PerkSummary"; // Metadata: 0x005F34FD
		public const string N_EQUIP_POWER_LABEL = "txt_EquipPowerLabel"; // Metadata: 0x005F350D
		public const string N_CURRENCY_BAR = "sec_CurrencyBar"; // Metadata: 0x005F3521
		public const string N_BTN_EQUIPMENT = "btn_EquipmentChar"; // Metadata: 0x005F3531
		public const string N_BTN_VIEW_PETS = "btn_ViewPets"; // Metadata: 0x005F3543
		public const string N_BTN_VIEW_CARDS = "btn_ViewCards"; // Metadata: 0x005F3550
		public const string N_BTN_VIEW_ITEMS = "btn_ViewItems"; // Metadata: 0x005F355E
		public const string N_VIP_BADGE = "img_VipBadge"; // Metadata: 0x005F356C
		public const string N_LEVEL_BADGE = "img_LevelBadge"; // Metadata: 0x005F3579
		public const string N_ELO_EMBLEM = "img_EloEmblem"; // Metadata: 0x005F3588
		public const string LEVEL_FRAME_DIR = "Image/hclv/"; // Metadata: 0x005F3596
		public const string ARENA_TIER_DIR = "Image/hc/"; // Metadata: 0x005F35A2
		[Header("Khung nh\u00E2n v\u1EADt")]
		public UnityEngine.UI.Text txtPlayerName; // 0x20
		public UnityEngine.UI.Text txtClubName; // 0x28
		public UnityEngine.UI.Text txtEquipPowerValue; // 0x30
		public UnityEngine.UI.Text txtLevel; // 0x38
		[Tooltip("D\u00F2ng li\u1EC7t k\u00EA thu\u1ED9c t\u00EDnh \u0111ang c\u00F3 \u2014 D\u1EF0NG L\u00DAC CH\u1EA0Y, \u0111\u1EC3 tr\u1ED1ng trong prefab.")]
		public UnityEngine.UI.Text txtPerkSummary; // 0x40
		[Header("Th\u00E0nh t\u00EDch")]
		public UnityEngine.UI.Text txtPowerTotal; // 0x48
		public UnityEngine.UI.Text txtPowerRank; // 0x50
		public UnityEngine.UI.Text txtArenaElo; // 0x58
		public UnityEngine.UI.Text txtArenaRank; // 0x60
		[Header("Th\u00F4ng s\u1ED1 chi\u1EBFn \u0111\u1EA5u")]
		public UnityEngine.UI.Text txtAttack; // 0x68
		[Tooltip("\uD83D\uDD34 \u00D4 GI\u1EEEA hi\u1EC3n th\u1ECB MANA, kh\u00F4ng ph\u1EA3i ph\u00F2ng th\u1EE7 (bi\u1EC3u t\u01B0\u1EE3ng l\u00E0 \u1ED1ng nghi\u1EC7m).")]
		public UnityEngine.UI.Text txtDefence; // 0x70
		public UnityEngine.UI.Text txtHealth; // 0x78
		[Tooltip("N\u0103m \u00F4 theo TH\u1EE8 T\u1EF0 HI\u1EC2N TH\u1ECA Kim\u2013M\u1ED9c\u2013Thu\u1EF7\u2013Ho\u1EA3\u2013Th\u1ED5. Kh\u00F4ng s\u1EAFp l\u1EA1i theo enum h\u1EC7.")]
		public UnityEngine.UI.Text[] txtElem; // 0x80
		[Header("\u00D4 n\u1ED9i dung + v\u00ED")]
		public UnityEngine.UI.Text txtPetCount; // 0x88
		public UnityEngine.UI.Text txtHonor; // 0x90
		public UnityEngine.UI.Text txtGold; // 0x98
		public UnityEngine.UI.Text txtStarShard; // 0xA0
		public UnityEngine.UI.Text txtTicket; // 0xA8
		[Header("\u1EA2nh \u0111\u1ED5i theo d\u1EEF li\u1EC7u")]
		public Image imgLevelBadge; // 0xB0
		public Image imgEloEmblem; // 0xB8
		public GameObject vipBadge; // 0xC0
		[Header("T\u1EAFt khi xem h\u1ED3 s\u01A1 NG\u01AF\u1EDCI KH\u00C1C (\u00A73.3)")]
		public GameObject currencyBar; // 0xC8
		public GameObject equipButton; // 0xD0
		public GameObject viewPetsButton; // 0xD8
		public GameObject viewCardsButton; // 0xE0
		public GameObject viewItemsButton; // 0xE8
		private bool _resolved; // 0xF0
		private const string PERK_VALUE_COLOR = "#FACC4D"; // Metadata: 0x005F35AC
		private const string PERK_HINT_COLOR = "#B9C6D4"; // Metadata: 0x005F35B4
		private const float PERK_LINE_MULT = 1.34f; // Metadata: 0x005F35BC
		private const float PERK_BOTTOM_GAP = 10f; // Metadata: 0x005F35C0
		private const float PERK_BADGE_GAP = 4f; // Metadata: 0x005F35C4
		private const float PERK_MIN_W = 140f; // Metadata: 0x005F35C8
		private const int PERK_LABEL_LIMIT = 28; // Metadata: 0x005F35CC
		private const int PERK_TEXT_LIMIT = 48; // Metadata: 0x005F35CD
		private const int PERK_HINT_LIMIT = 32; // Metadata: 0x005F35CE
		private static readonly Vector3[] _corners; // 0x00
		private static readonly StringBuilder _perkText; // 0x08
		private RectTransform _equipPowerLabel; // 0xF8
	
		// Constructors
		public InfoPlayerView(); // 0x0000000180D34440-0x0000000180D34520
		static InfoPlayerView(); // 0x0000000180D34520-0x0000000180D346C0
	
		// Methods
		private void Awake(); // 0x0000000180D2E840-0x0000000180D2E850
		public void ResolveNodes(); // 0x0000000180D2E850-0x0000000180D2FB30
		private UnityEngine.UI.Text Label(string node, StringBuilder missing); // 0x0000000180D2FB30-0x0000000180D2FD70
		private Image Picture(string node); // 0x0000000180D2FD70-0x0000000180D2FED0
		private GameObject Node(string node); // 0x0000000180D2FED0-0x0000000180D30010
		private void HardenTextFields(); // 0x0000000180D30010-0x0000000180D30460
		private static void ScaleText(UnityEngine.UI.Text label, float scale); // 0x0000000180D30460-0x0000000180D305B0
		public void ShowPlaceholders(); // 0x0000000180D305B0-0x0000000180D307D0
		public void ApplyProfile(ProfileDTO p); // 0x0000000180D307D0-0x0000000180D30BC0
		public void ApplyPerkSummary(EquipBookDTO book); // 0x0000000180D30BC0-0x0000000180D31000
		private void HidePerkSummary(); // 0x0000000180D31000-0x0000000180D311D0
		private static int BuildPerkSummaryText(EquipPerkDTO[] perks, string title, int maxLines, int fontSize, out int more); // 0x0000000180D311D0-0x0000000180D31930
		private static string ComposeFromLabel(EquipPerkDTO p); // 0x0000000180D31930-0x0000000180D31B00
		private static void AppendTinted(string body); // 0x0000000180D31B00-0x0000000180D31D10
		private static int LeadingPercentLength(string s); // 0x0000000180D31D10-0x0000000180D31DA0
		private bool MeasurePerkSummary(UnityEngine.UI.Text label, out Vector2 topLeft, out float width, out float available); // 0x0000000180D31DA0-0x0000000180D32480
		private static bool TryLocalRect(RectTransform space, RectTransform target, out Rect rect); // 0x0000000180D32480-0x0000000180D32880
		private UnityEngine.UI.Text EnsurePerkSummary(); // 0x0000000180D32880-0x0000000180D33370
		private void ApplyWallet(ProfileResDTO res); // 0x0000000180D33370-0x0000000180D33570
		private void ApplyBadges(ProfileDTO p); // 0x0000000180D33570-0x0000000180D337E0
		private void ApplyVipBadge(ProfileDTO p); // 0x0000000180D337E0-0x0000000180D33C60
		private static void ApplySprite(Image target, string dir, string key); // 0x0000000180D33C60-0x0000000180D33DA0
		public void SetOtherMode(bool isOther); // 0x0000000180D33DA0-0x0000000180D342C0
		private static void Set(UnityEngine.UI.Text label, string value); // 0x0000000180D342C0-0x0000000180D34440
	}
}
