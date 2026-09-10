/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerQuangTruong : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1657
{
	// Fields
	[Header("N\u1EA1p T\u00EDch L\u0169y")]
	public Button btnNapTichLuy; // 0x20
	public Button btnNapSafia; // 0x28
	[Header("Daily Check-In")]
	public Button btnDailyCheckIn; // 0x30
	public DailyCheckInSpawner dailyCheckInSpawner; // 0x38
	[Header("Th\u01B0 vi\u1EC7n + X\u1EBFp h\u1EA1ng (lazy-load)")]
	public Button btnThuVien; // 0x40
	public Button btnXepHang; // 0x48
	[Header("Batch panel lazy-load #12-#16 (n\u00FAt hub, g\u00E1n b\u1EDFi menu 15-19)")]
	public Button btnTienHoaHub; // 0x50
	public Button btnMegaHub; // 0x58
	public Button btnNhiemVuHub; // 0x60
	public Button btnVongQuayHub; // 0x68
	public Button btnGiftCodeHub; // 0x70
	public Image flagWheel; // 0x78
	public UnityEngine.UI.Text txtVang; // 0x80
	public UnityEngine.UI.Text txtSafia; // 0x88
	public UnityEngine.UI.Text txtCt; // 0x90
	public int txtCtint; // 0x98
	public UnityEngine.UI.Text txtNl; // 0xA0
	public Image imgLvUser; // 0xA8
	private string lvUser; // 0xB0
	private int _userLevel; // 0xB8
	public UnityEngine.UI.Text txtExp; // 0xC0
	public UnityEngine.UI.Text txtName; // 0xC8
	public string petId; // 0xD0
	public Slider expslider; // 0xD8
	public UnityEngine.UI.Text txtStarWhite; // 0xE0
	public UnityEngine.UI.Text txtStarBlue; // 0xE8
	public UnityEngine.UI.Text txtStarRed; // 0xF0
	public Button btnBoss; // 0xF8
	public Button btnTower; // 0x100
	public GameObject panelBoss; // 0x108
	public static ManagerQuangTruong Instance; // 0x00
	[Header("PVP Panel")]
	public GameObject panelPVP; // 0x110
	[Header("Busy Toggle")]
	public Toggle toggleBusy; // 0x118
	[Header("Energy UI")]
	public UnityEngine.UI.Text txtEnergy; // 0x120
	public UnityEngine.UI.Text txtCountdown; // 0x128
	public Image imgEnergyBar; // 0x130
	[Header("Wheel Day")]
	public Button btnWheelDay; // 0x138
	[Header("Gacha")]
	public Button btnGacha; // 0x140
	[Header("Stone Images - 5 H\u1EC7, m\u1ED7i h\u1EC7 7 Level")]
	[Tooltip("H\u1EC7 L\u1EEDa - 7 level")]
	public Sprite[] stoneFire; // 0x148
	[Tooltip("H\u1EC7 N\u01B0\u1EDBc - 7 level")]
	public Sprite[] stoneWater; // 0x150
	[Tooltip("H\u1EC7 Gi\u00F3 - 7 level")]
	public Sprite[] stoneWind; // 0x158
	[Tooltip("H\u1EC7 \u0110\u1EA5t - 7 level")]
	public Sprite[] stoneEarth; // 0x160
	[Tooltip("H\u1EC7 S\u00E9t - 7 level")]
	public Sprite[] stoneThunder; // 0x168
	[Header("GiftBox - Main Panels")]
	public GameObject panelGiftBox; // 0x170
	public GameObject panelGiftResult; // 0x178
	[Header("GiftBox - UI Elements")]
	public UnityEngine.UI.Text txtGiftTitle; // 0x180
	public Button btnClaimGift; // 0x188
	public Transform listReward; // 0x190
	[Header("GiftBox - Reward Prefabs")]
	public GameObject petRW; // 0x198
	public GameObject avtRW; // 0x1A0
	public GameObject cardRW; // 0x1A8
	public GameObject stoneRW; // 0x1B0
	public GameObject goldRW; // 0x1B8
	public GameObject energyRW; // 0x1C0
	public GameObject redStarRW; // 0x1C8
	public GameObject whiteStarRW; // 0x1D0
	public GameObject bluestarRW; // 0x1D8
	public GameObject expRW; // 0x1E0
	public GameObject wheelRW; // 0x1E8
	public GameObject wheelDayRW; // 0x1F0
	public GameObject rubyRW; // 0x1F8
	public GameObject crystalRW; // 0x200
	public GameObject eItem1RW; // 0x208
	public GameObject eItem2RW; // 0x210
	public GameObject eItem3RW; // 0x218
	public GameObject eItem4RW; // 0x220
	public GameObject shardRW; // 0x228
	public GameObject weaponRW; // 0x230
	public GameObject stoneCardRW; // 0x238
	public GameObject guildCoinRW; // 0x240
	[Header("GiftBox - Optional")]
	public GameObject giftBoxIcon; // 0x248
	public UnityEngine.UI.Text txtGiftCount; // 0x250
	public GameObject giftBoxAnimation; // 0x258
	public Animator giftBoxAnimator; // 0x260
	private bool isClaimingGift; // 0x268
	private List<GiftDTO> pendingGifts; // 0x270
	private GiftDTO currentGift; // 0x278
	private Coroutine _giftPushRefreshCo; // 0x280
	private Coroutine _giftToastCo; // 0x288
	private int _giftCountKnown; // 0x290
	private int _giftOptimisticBump; // 0x294
	private bool _giftToastQueued; // 0x298
	private int _giftCountAtPush; // 0x29C
	private Coroutine _noticePushRefreshCo; // 0x2A0
	private Coroutine _noticeFxCo; // 0x2A8
	private long _noticeMaxIdKnown; // 0x2B0
	[Header("Shop Button")]
	public Button btnShop; // 0x2B8
	[Header("Chinh Phuc Panel")]
	public GameObject panelChinhPhuc; // 0x2C0
	public Button btnChinhPhuc; // 0x2C8
	public GameObject loadingPanel; // 0x2D0
	[Tooltip("Panel loading ri\u00EAng cho flow quay v\u1EC1 room t\u1EEB tr\u1EADn (Match \u2192 QuangTruong). N\u1EBFu g\u00E1n, s\u1EBD d\u00F9ng panel n\u00E0y thay cho loadingPanel khi return t\u1EEB match.")]
	public GameObject loadingRoom; // 0x2D8
	private int ruby; // 0x2E0
	[Header("Equipment")]
	public Button btnEquipment; // 0x2E8
	public Image HC; // 0x2F0
	public Image imgAvatar; // 0x2F8
	public WeaponBadgeUI imgWeaponBadge; // 0x300
	private Sprite _hubLegacyAvatar; // 0x308
	[Header("Background Music")]
	public AudioSource bgmAudioSource; // 0x310
	public AudioClip bgmClip; // 0x318
	[Range(0f, 1f)]
	public float bgmVolume; // 0x320
	public bool loopBGM; // 0x324
	[Header("Sound Effects")]
	public AudioClip clickSound; // 0x328
	[Range(0f, 1f)]
	public float clickVolume; // 0x330
	[Header("World Chat")]
	public Button btnWorldChat; // 0x338
	[Header("Event")]
	public Button btnEvent; // 0x340
	public Button btnFirstPay; // 0x348
	public GameObject eventBadge; // 0x350
	public Button btnEventFest; // 0x358
	[Header("Update Card")]
	public Button btnUpdateCard; // 0x360
	[Header("Mini Game")]
	public Button btnMiniGame; // 0x368
	[Header("Thong Bao")]
	public Button btnThongBao; // 0x370
	[Header("Th\u1EE9c T\u1EC9nh Mega")]
	public Button btnThueTinh; // 0x378
	[Header("H\u1ED9p qu\u00E0 online (2026-07-29)")]
	[Tooltip("N\u00FAt m\u1EDF h\u1ED9p qu\u00E0 online. B\u1ECF tr\u1ED1ng \u2192 t\u1EF1 t\u00ECm n\u00FAt t\u00EAn btnOnlineGift/btnHopQua, kh\u00F4ng c\u00F3 n\u1EEFa th\u00EC instantiate prefab Resources/Prefabs/UI/OnlineGiftButton.")]
	public Button btnOnlineGift; // 0x380
	[Tooltip("Panel/popup ph\u1EE5 khi\u1EBFn UI ch\u1EC9-hub (n\u00FAt h\u1ED9p qu\u00E0 online) ph\u1EA3i \u1EA9n. D\u00F9ng \u0111\u1EC3 m\u1EDF r\u1ED9ng IsHubViewActive() m\u00E0 kh\u00F4ng c\u1EA7n s\u1EEDa code khi th\u00EAm panel scene m\u1EDBi.")]
	public GameObject[] hubOnlyBlockers; // 0x388
	public GameObject PanelMasterLobby; // 0x390
	public GameObject BtnBackLobby_PVP; // 0x398
	public GameObject BtnBackQuangTruong_PVP; // 0x3A0
	private HubButtonRegistry _hubButtons; // 0x3A8
	private float _hubStuckCheckAt; // 0x3B0
	private bool _hubStuckReported; // 0x3B4
	public const string PANEL_TOWER = "PanelTower"; // Metadata: 0x0068D594
	public const string PANEL_TREASURE_WHEEL = "PanelTreasureWheel"; // Metadata: 0x0068D59F
	public const string PANEL_RECHARGE_EVENT = "PanelRechargeEvent"; // Metadata: 0x0068D5B2
	public const string PANEL_MID_AUTUMN = "PanelMidAutumn"; // Metadata: 0x0068D5C5
	public const string PANEL_GUILD = "PanelGuild"; // Metadata: 0x0068D5D4
	private const int LEVEL_REQUIRED_TOWER = 20; // Metadata: 0x0068D5DF
	private const int LEVEL_REQUIRED_WORLD_BOSS = 10; // Metadata: 0x0068D5E0
	private const int LEVEL_REQUIRED_EVOLUTION = 15; // Metadata: 0x0068D5E1
	private const int LEVEL_REQUIRED_AWAKENING = 25; // Metadata: 0x0068D5E2
	private const int LEVEL_REQUIRED_GUILD = 20; // Metadata: 0x0068D5E3
	private const int LEVEL_REQUIRED_WHEEL = 15; // Metadata: 0x0068D5E4
	private const string OWNER_SHOP_AVATAR_BUTTON = "btnShopAvt"; // Metadata: 0x0068D5E5
	private UnityAction _openShopAvatarFromHub; // 0x3B8
	private const float REMOTE_EVENT_DELAY = 2.5f; // Metadata: 0x0068D5F0
	private const float NOTICE_AUTO_OPEN_DELAY = 1.2f; // Metadata: 0x0068D5F4
	[CompilerGenerated]
	private string _LastGiftClaimError_k__BackingField; // 0x3C0
	private bool _refreshInFlight; // 0x3C8
	private bool _refreshPending; // 0x3C9
	private bool _refreshWantsLoading; // 0x3CA
	private Coroutine _refreshDebounceCo; // 0x3D0
	private const float REFRESH_DEBOUNCE_SEC = 0.25f; // Metadata: 0x0068D5F8
	private float _refreshStartedAt; // 0x3D8
	private const float REFRESH_STUCK_SEC = 30f; // Metadata: 0x0068D5FC
	private ManagerBoss _managerBoss; // 0x3E0
	public const string FLAG_BOSS_COVER_HEADER = "panelboss.coverheader"; // Metadata: 0x0068D600
	private const int BOSS_PANEL_ORDER = 100; // Metadata: 0x0068D616
	private static bool _bossOrderApplied; // 0x08
	private bool _honorIconApplied; // 0x3E8
	private GameObject _activeLoadingTarget; // 0x3F0
	private Coroutine _loadingWatchdog; // 0x3F8
	private const float LOADING_WATCHDOG_TIMEOUT = 20f; // Metadata: 0x0068D618
	internal int ChienTich; // 0x400

	// Properties
	private HubButtonRegistry HubButtons { get; } // 0x000000018063DF10-0x000000018063DF60 
	private Transform HubEventStrip { get; } // 0x000000018063DF60-0x000000018063E020 
	public IList<GiftDTO> PendingGifts { get; } // 0x000000018039C370-0x000000018039C380 
	public string LastGiftClaimError { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018063E020-0x000000018063E030 0x000000018063E030-0x000000018063E050

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1658
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static UnityAction<bool> __9__125_0; // 0x08
		public static Action<GameObject> __9__131_0; // 0x10
		public static Action<GameObject> __9__132_0; // 0x18
		public static Action<GameObject> __9__133_0; // 0x20
		public static Action<GameObject> __9__136_0; // 0x28
		public static Action<GameObject> __9__137_0; // 0x30
		public static Action<GameObject> __9__142_0; // 0x38
		public static Action<GameObject> __9__144_0; // 0x40
		public static Action<GameObject> __9__146_0; // 0x48
		public static Action<GameObject> __9__163_0; // 0x50
		public static Action<GameObject> __9__164_0; // 0x58
		public static Action<GameObject> __9__166_0; // 0x60
		public static Action<GameObject> __9__195_0; // 0x68
		public static Action<GameObject> __9__196_0; // 0x70
		public static Action<GameObject> __9__197_0; // 0x78
		public static Action<GameObject> __9__200_0; // 0x80
		public static Action<GameObject> __9__201_0; // 0x88
		public static Action<GameObject> __9__203_0; // 0x90
		public static Action<GameObject> __9__206_0; // 0x98
		public static Action<string> __9__221_1; // 0xA0
		public static Action<string> __9__226_1; // 0xA8
		public static Action<string> __9__250_1; // 0xB0
		public static Action<GameObject> __9__265_0; // 0xB8
		public static Action<string> __9__291_1; // 0xC0
		public static Action<string> __9__310_1; // 0xC8
		public static Action<string> __9__339_1; // 0xD0

		// Constructors
		static __c(); // 0x00000001806714F0-0x0000000180671560
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Start_b__125_0(bool busy); // 0x0000000180670420-0x0000000180670480
		internal void _OpenEvent_b__131_0(GameObject panel); // 0x000000018066F8F0-0x000000018066F950
		internal void _OpenEventFest_b__132_0(GameObject panel); // 0x000000018066F890-0x000000018066F8F0
		internal void _OpenUpdateCard_b__133_0(GameObject panel); // 0x00000001806701B0-0x0000000180670210
		internal void _OpenMiniGame_b__136_0(GameObject panel); // 0x000000018066FD50-0x000000018066FDB0
		internal void _OpenNapTichLuy_b__137_0(GameObject panel); // 0x000000018066FDB0-0x000000018066FE10
		internal void _OpenOnlineGift_b__142_0(GameObject panel); // 0x000000018066FE10-0x000000018066FE70
		internal void _OpenHuongDan_b__144_0(GameObject panel); // 0x000000018066FBB0-0x000000018066FC80
		internal void _OpenFriend_b__146_0(GameObject panel); // 0x000000018066FA20-0x000000018066FA80
		internal void _OpenWheelTab_b__163_0(GameObject panel); // 0x0000000180670210-0x00000001806702E0
		internal void _OpenGachaPanel_b__164_0(GameObject panel); // 0x000000018066FA80-0x000000018066FAE0
		internal void _OpenFirstPay_b__166_0(GameObject panel); // 0x000000018066F950-0x000000018066FA20
		internal void _OpenTienHoa_b__195_0(GameObject panel); // 0x00000001806700E0-0x00000001806701B0
		internal void _OpenMega_b__196_0(GameObject panel); // 0x000000018066FC80-0x000000018066FD50
		internal void _OpenQuest_b__197_0(GameObject panel); // 0x000000018066FE70-0x000000018066FF40
		internal void _OpenGiftCode_b__200_0(GameObject panel); // 0x000000018066FAE0-0x000000018066FBB0
		internal void _OpenThuVien_b__201_0(GameObject panel); // 0x0000000180670010-0x00000001806700E0
		internal void _OpenXepHang_b__203_0(GameObject panel); // 0x00000001806702E0-0x00000001806703B0
		internal void _OpenShop_b__206_0(GameObject panel); // 0x000000018066FF40-0x0000000180670010
		internal void _NoticePushRefreshAfter_b__221_1(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
		internal void _LoadGiftDetailsCoroutine_b__226_1(string error); // 0x000000018066F670-0x000000018066F6E0
		internal void _RequestPendingGiftsCoroutine_b__250_1(string error); // 0x00000001806703B0-0x0000000180670420
		internal void _OnGiftIconClicked_b__265_0(GameObject panel); // 0x000000018066F7C0-0x000000018066F890
		internal void _LoadSceneAfterDelay_b__291_1(string e); // 0x000000018066F6E0-0x000000018066F750
		internal void _FastRestorePVPLobby_b__310_1(string err); // 0x000000018066F600-0x000000018066F670
		internal void _LoadUserData_b__339_1(string error); // 0x000000018066F750-0x000000018066F7C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 1659
	{
		// Fields
		public ThongBaoListData prefill; // 0x10

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenThongBao_b__0(GameObject panel); // 0x0000000180670480-0x00000001806704F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass161_0 // TypeDefIndex: 1660
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool stopAfterFade; // 0x18

		// Constructors
		public __c__DisplayClass161_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FadeOutBGM_b__0(float val); // 0x00000001806704F0-0x0000000180670590
		internal void _FadeOutBGM_b__1(); // 0x0000000180670590-0x0000000180670630
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass184_0 // TypeDefIndex: 1661
	{
		// Fields
		public string panelKey; // 0x10

		// Constructors
		public __c__DisplayClass184_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenPokyEventPanel_b__0(GameObject panel); // 0x0000000180670630-0x0000000180670710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass191_0 // TypeDefIndex: 1662
	{
		// Fields
		public string panelKey; // 0x10
		public Action<GameObject> onReady; // 0x18

		// Constructors
		public __c__DisplayClass191_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenLazyPanel_b__0(GameObject panel); // 0x0000000180670710-0x0000000180670800
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass193_0 // TypeDefIndex: 1663
	{
		// Fields
		public RemoteEventItem ev; // 0x10
		public ManagerQuangTruong __4__this; // 0x18

		// Constructors
		public __c__DisplayClass193_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShowRemoteEventWhenReady_b__0(GameObject panel); // 0x0000000180670800-0x0000000180670940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass202_0 // TypeDefIndex: 1664
	{
		// Fields
		public UIPanelManager pm; // 0x10

		// Constructors
		public __c__DisplayClass202_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenKhoPet_b__0(GameObject panel); // 0x0000000180670940-0x0000000180670B00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass204_0 // TypeDefIndex: 1665
	{
		// Fields
		public long targetUserId; // 0x10

		// Constructors
		public __c__DisplayClass204_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenInfoPlayer_b__0(GameObject panel); // 0x0000000180670B00-0x0000000180670D00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass207_0 // TypeDefIndex: 1666
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public int category; // 0x18

		// Constructors
		public __c__DisplayClass207_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenShopAvatar_b__0(GameObject panel); // 0x0000000180670D00-0x0000000180671030
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass210_0 // TypeDefIndex: 1667
	{
		// Fields
		public bool apiCompleted; // 0x10
		public GiftCountResponse responseData; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass210_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CheckGiftsCoroutine_b__0(GiftCountResponse response); // 0x0000000180316FC0-0x0000000180316FE0
		internal void _CheckGiftsCoroutine_b__1(string error); // 0x0000000180671030-0x00000001806710D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass221_0 // TypeDefIndex: 1668
	{
		// Fields
		public ManagerThongBao.ThongBaoResponse data; // 0x10

		// Constructors
		public __c__DisplayClass221_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _NoticePushRefreshAfter_b__0(ManagerThongBao.ThongBaoResponse resp); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass226_0 // TypeDefIndex: 1669
	{
		// Fields
		public List<GiftDTO> giftsData; // 0x10

		// Constructors
		public __c__DisplayClass226_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadGiftDetailsCoroutine_b__0(List<GiftDTO> gifts); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass250_0 // TypeDefIndex: 1670
	{
		// Fields
		public List<GiftDTO> data; // 0x10

		// Constructors
		public __c__DisplayClass250_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RequestPendingGiftsCoroutine_b__0(List<GiftDTO> gifts); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass256_0 // TypeDefIndex: 1671
	{
		// Fields
		public bool ok; // 0x10
		public GiftDTO result; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Constructors
		public __c__DisplayClass256_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ClaimGiftCoroutine_b__0(GiftDTO g); // 0x0000000180316FC0-0x0000000180316FE0
		internal void _ClaimGiftCoroutine_b__1(string e); // 0x00000001806710D0-0x0000000180671170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass258_0 // TypeDefIndex: 1672
	{
		// Fields
		public bool done; // 0x10
		public bool good; // 0x11
		public GiftDTO res; // 0x18

		// Constructors
		public __c__DisplayClass258_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ClaimGiftsSequentialCoroutine_b__0(bool s, GiftDTO r); // 0x0000000180671170-0x0000000180671190
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass263_0 // TypeDefIndex: 1673
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public CanvasGroup canvasGroup; // 0x18

		// Constructors
		public __c__DisplayClass263_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CloseGiftBoxWithAnimation_b__0(); // 0x0000000180671190-0x0000000180671220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass275_0 // TypeDefIndex: 1674
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool useSilent; // 0x18

		// Constructors
		public __c__DisplayClass275_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshUserCoroutine_b__0(UserDTO user); // 0x0000000180671220-0x0000000180671250
		internal void _RefreshUserCoroutine_b__1(string error); // 0x0000000180671250-0x0000000180671280
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass291_0 // TypeDefIndex: 1675
	{
		// Fields
		public bool hubLoaded; // 0x10

		// Constructors
		public __c__DisplayClass291_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadSceneAfterDelay_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass293_0 // TypeDefIndex: 1676
	{
		// Fields
		public bool pvpLoaded; // 0x10

		// Constructors
		public __c__DisplayClass293_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RestorePVPRoomWithLoading_b__0(); // 0x000000018034AB40-0x000000018034AB50
		internal bool _RestorePVPRoomWithLoading_b__1(); // 0x0000000180671280-0x0000000180671290
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass302_0 // TypeDefIndex: 1677
	{
		// Fields
		public bool chinhPhucLoaded; // 0x10

		// Constructors
		public __c__DisplayClass302_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RestorePanelStateWithLoading_b__0(); // 0x000000018034AB40-0x000000018034AB50
		internal bool _RestorePanelStateWithLoading_b__1(); // 0x0000000180671280-0x0000000180671290
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass303_0 // TypeDefIndex: 1678
	{
		// Fields
		public bool chinhPhucDone; // 0x10
		public ManagerRoom roomManager; // 0x18
		public bool userDone; // 0x20
		public bool roomDone; // 0x21

		// Constructors
		public __c__DisplayClass303_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FastRestoreCoopRoom_b__0(); // 0x000000018034AB40-0x000000018034AB50
		internal void _FastRestoreCoopRoom_b__1(UserDTO user); // 0x0000000180671290-0x0000000180671300
		internal void _FastRestoreCoopRoom_b__2(string err); // 0x0000000180671300-0x0000000180671380
		internal void _FastRestoreCoopRoom_b__3(); // 0x0000000180671380-0x0000000180671390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass305_0 // TypeDefIndex: 1679
	{
		// Fields
		public ManagerRoom roomManager; // 0x10
		public bool roomLoaded; // 0x18
		public int retry; // 0x1C
		public Action<RoomDTO> __9__0; // 0x20
		public Action<string> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass305_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FastRestoreRoomDataWithRetry_b__0(RoomDTO room); // 0x0000000180671390-0x0000000180671450
		internal void _FastRestoreRoomDataWithRetry_b__1(string err); // 0x0000000180671450-0x00000001806714F0
	}

	[CompilerGenerated]
	private sealed class _AnnounceNewGiftWhenHubVisible_d__216 : IEnumerator<object> // TypeDefIndex: 1680
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _guard_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnnounceNewGiftWhenHubVisible_d__216(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180666500-0x0000000180666710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180666710-0x0000000180666750
	}

	[CompilerGenerated]
	private sealed class _AttachButtonSoundsAsync_d__155 : IEnumerator<object> // TypeDefIndex: 1681
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private Button[] _allButtons_5__2; // 0x28
		private int _count_5__3; // 0x30
		private int _i_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AttachButtonSoundsAsync_d__155(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180666750-0x00000001806669D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806669D0-0x0000000180666A10
	}

	[CompilerGenerated]
	private sealed class _AutoOpenNoticeAfterLogin_d__219 : IEnumerator<object> // TypeDefIndex: 1682
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoOpenNoticeAfterLogin_d__219(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180666A10-0x0000000180666EE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180666EE0-0x0000000180666F20
	}

	[CompilerGenerated]
	private sealed class _CheckGiftsCoroutine_d__210 : IEnumerator<object> // TypeDefIndex: 1683
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass210_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckGiftsCoroutine_d__210(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180666F20-0x00000001806671B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806671B0-0x00000001806671F0
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftCoroutine_d__256 : IEnumerator<object> // TypeDefIndex: 1684
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public GiftDTO gift; // 0x28
		public int userId; // 0x30
		private __c__DisplayClass256_0 __8__1; // 0x38
		public Action<bool, GiftDTO> onDone; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftCoroutine_d__256(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001806671F0-0x0000000180667470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180667470-0x00000001806674B0
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftsSequentialCoroutine_d__258 : IEnumerator<object> // TypeDefIndex: 1685
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<GiftDTO> gifts; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass258_0 __8__1; // 0x30
		public Action<GiftDTO> onEach; // 0x38
		public Action<int, int> onDone; // 0x40
		private int _ok_5__2; // 0x48
		private int _fail_5__3; // 0x4C
		private int _i_5__4; // 0x50
		private GiftDTO _g_5__5; // 0x58
		private float _guard_5__6; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftsSequentialCoroutine_d__258(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806677F0-0x0000000180667830
		private bool MoveNext(); // 0x00000001806674B0-0x00000001806677B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806677B0-0x00000001806677F0
	}

	[CompilerGenerated]
	private sealed class _ConsumeHomeDeepLink_d__126 : IEnumerator<object> // TypeDefIndex: 1686
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private string _key_5__2; // 0x28
		private float _waited_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeHomeDeepLink_d__126(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180667990-0x0000000180668980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180668980-0x00000001806689C0
	}

	[CompilerGenerated]
	private sealed class _DeferChinhPhucPreload_d__292 : IEnumerator<object> // TypeDefIndex: 1687
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DeferChinhPhucPreload_d__292(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806689C0-0x0000000180668AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180668AF0-0x0000000180668B30
	}

	[CompilerGenerated]
	private sealed class _FastRestoreCoopRoom_d__303 : IEnumerator<object> // TypeDefIndex: 1688
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass303_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30
		private int _selectedPetId_5__3; // 0x34
		private bool _guildRoom_5__4; // 0x38
		private CanvasGroup _chinhPhucCG_5__5; // 0x40
		private ManagerChinhPhuc _chinhPhucManager_5__6; // 0x48
		private int _panelIndex_5__7; // 0x50
		private bool _petsDone_5__8; // 0x54
		private float _waitTimeout_5__9; // 0x58
		private float _waitElapsed_5__10; // 0x5C
		private float _keepTopTimer_5__11; // 0x60
		private int _i_5__12; // 0x64

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreCoopRoom_d__303(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180669E30-0x0000000180669E80
		private bool MoveNext(); // 0x0000000180668B30-0x0000000180669DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180669DF0-0x0000000180669E30
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPLobby_d__310 : IEnumerator<object> // TypeDefIndex: 1689
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPLobby_d__310(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180669E80-0x000000018066A400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066A400-0x000000018066A440
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPRoom_d__309 : IEnumerator<object> // TypeDefIndex: 1690
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private ManagerRoomPVP _pvpManager_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPRoom_d__309(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066A440-0x000000018066AC10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066AC10-0x000000018066AC50
	}

	[CompilerGenerated]
	private sealed class _FastRestoreRoomDataWithRetry_d__305 : IEnumerator<object> // TypeDefIndex: 1691
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom roomManager; // 0x20
		public Action onDone; // 0x28
		public int userId; // 0x30
		public int selectedPetId; // 0x34
		private __c__DisplayClass305_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreRoomDataWithRetry_d__305(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x000000018066AC50-0x000000018066B0A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066B0A0-0x000000018066B0E0
	}

	[CompilerGenerated]
	private sealed class _GiftFallbackPollLoop_d__217 : IEnumerator<object> // TypeDefIndex: 1692
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GiftFallbackPollLoop_d__217(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066B0E0-0x000000018066B270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066B270-0x000000018066B2B0
	}

	[CompilerGenerated]
	private sealed class _GiftPushRefreshAfter_d__215 : IEnumerator<object> // TypeDefIndex: 1693
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GiftPushRefreshAfter_d__215(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066B2B0-0x000000018066B450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066B450-0x000000018066B490
	}

	[CompilerGenerated]
	private sealed class _LoadGiftDetailsCoroutine_d__226 : IEnumerator<object> // TypeDefIndex: 1694
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass226_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadGiftDetailsCoroutine_d__226(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066B490-0x000000018066B740
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066B740-0x000000018066B780
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__291 : IEnumerator<object> // TypeDefIndex: 1695
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass291_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__291(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066B780-0x000000018066C220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066C220-0x000000018066C260
	}

	[CompilerGenerated]
	private sealed class _LoadUserData_d__339 : IEnumerator<object> // TypeDefIndex: 1696
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserData_d__339(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066C260-0x000000018066C450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066C450-0x000000018066C490
	}

	[CompilerGenerated]
	private sealed class _LoadingWatchdog_d__315 : IEnumerator<object> // TypeDefIndex: 1697
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadingWatchdog_d__315(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066C490-0x000000018066C640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066C640-0x000000018066C680
	}

	[CompilerGenerated]
	private sealed class _NoticeFallbackPollLoop_d__225 : IEnumerator<object> // TypeDefIndex: 1698
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _NoticeFallbackPollLoop_d__225(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066C680-0x000000018066C810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066C810-0x000000018066C850
	}

	[CompilerGenerated]
	private sealed class _NoticePushRefreshAfter_d__221 : IEnumerator<object> // TypeDefIndex: 1699
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass221_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _NoticePushRefreshAfter_d__221(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018066C850-0x000000018066CDD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066CDD0-0x000000018066CE10
	}

	[CompilerGenerated]
	private sealed class _RefreshDebouncedCoroutine_d__274 : IEnumerator<object> // TypeDefIndex: 1700
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshDebouncedCoroutine_d__274(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066CE10-0x000000018066CF30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066CF30-0x000000018066CF70
	}

	[CompilerGenerated]
	private sealed class _RefreshUserCoroutine_d__275 : IEnumerator<object> // TypeDefIndex: 1701
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public bool silent; // 0x28
		private __c__DisplayClass275_0 __8__1; // 0x30
		public int userId; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshUserCoroutine_d__275(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018066CF70-0x000000018066D210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066D210-0x000000018066D250
	}

	[CompilerGenerated]
	private sealed class _RequestPendingGiftsCoroutine_d__250 : IEnumerator<object> // TypeDefIndex: 1702
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass250_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30
		public Action<List<GiftDTO>> onDone; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RequestPendingGiftsCoroutine_d__250(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066DAE0-0x000000018066DDC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066DDC0-0x000000018066DE00
	}

	[CompilerGenerated]
	private sealed class _RestartGiftPulseNextFrame_d__230 : IEnumerator<object> // TypeDefIndex: 1703
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RestartGiftPulseNextFrame_d__230(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066DE00-0x000000018066DEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066DEE0-0x000000018066DF20
	}

	[CompilerGenerated]
	private sealed class _RestorePVPRoomWithLoading_d__293 : IEnumerator<object> // TypeDefIndex: 1704
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private CanvasGroup _pvpCG_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RestorePVPRoomWithLoading_d__293(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066DF20-0x000000018066E340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066E340-0x000000018066E380
	}

	[CompilerGenerated]
	private sealed class _RestorePanelStateWithLoading_d__302 : IEnumerator<object> // TypeDefIndex: 1705
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private int _panelIndex_5__2; // 0x28
		private CanvasGroup _chinhPhucCG_5__3; // 0x30
		private ManagerChinhPhuc _chinhPhucManager_5__4; // 0x38
		private CanvasGroup _roomCG_5__5; // 0x40
		private int _i_5__6; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RestorePanelStateWithLoading_d__302(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018066EBD0-0x000000018066EC20
		private bool MoveNext(); // 0x000000018066E380-0x000000018066EB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066EB90-0x000000018066EBD0
	}

	[CompilerGenerated]
	private sealed class _ShakeNoticeIconUntilSeen_d__222 : IEnumerator<object> // TypeDefIndex: 1706
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public int uid; // 0x28
		private float _guard_5__2; // 0x2C
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShakeNoticeIconUntilSeen_d__222(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066EC20-0x000000018066EE90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066EE90-0x000000018066EED0
	}

	[CompilerGenerated]
	private sealed class _ShowGiftDetailAfterAnimation_d__232 : IEnumerator<object> // TypeDefIndex: 1707
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowGiftDetailAfterAnimation_d__232(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066EED0-0x000000018066EFE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066EFE0-0x000000018066F020
	}

	[CompilerGenerated]
	private sealed class _ShowRemoteEventWhenReady_d__193 : IEnumerator<object> // TypeDefIndex: 1708
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass193_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowRemoteEventWhenReady_d__193(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018066F020-0x000000018066F2F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066F2F0-0x000000018066F330
	}

	[CompilerGenerated]
	private sealed class _SweepOrphanLoadingAfterRestore_d__304 : IEnumerator<object> // TypeDefIndex: 1709
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SweepOrphanLoadingAfterRestore_d__304(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018066F330-0x000000018066F5C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066F5C0-0x000000018066F600
	}

	[CompilerGenerated]
	private sealed class _WaitForPVPLoad_d__295 : IEnumerator<object> // TypeDefIndex: 1710
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP pvpManager; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForPVPLoad_d__295(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180671560-0x0000000180671770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180671770-0x00000001806717B0
	}

	// Constructors
	public ManagerQuangTruong(); // 0x000000018063DD90-0x000000018063DF10

	// Methods
	private void Awake(); // 0x000000018062A220-0x000000018062A630
	private void WireEnergyPurchaseButton(); // 0x000000018063C1B0-0x000000018063C580
	private void OpenEnergyPurchasePopup(); // 0x000000018049A450-0x000000018049A460
	private void Start(); // 0x0000000180638830-0x000000018063A370
	[IteratorStateMachine(typeof(_ConsumeHomeDeepLink_d__126))]
	private IEnumerator ConsumeHomeDeepLink(); // 0x000000018062B840-0x000000018062B8B0
	private void LateUpdate(); // 0x0000000180630730-0x0000000180630930
	private void CheckHubStuckDisabled(); // 0x000000018062A820-0x000000018062A960
	public void OpenEvent(); // 0x0000000180632F00-0x0000000180633010
	public void OpenEventFest(); // 0x0000000180632A30-0x0000000180632F00
	public void OpenUpdateCard(); // 0x0000000180634F90-0x00000001806350A0
	public void OpenThongBao(); // 0x00000001806349D0-0x0000000180634CB0
	public void OpenThueTinh(); // 0x0000000180633AF0-0x0000000180633C30
	public void OpenMiniGame(); // 0x0000000180633C70-0x0000000180633D90
	public void OpenNapTichLuy(); // 0x0000000180633D90-0x0000000180633EA0
	public void OpenNapSafia(); // 0x00000001803E42E0-0x00000001803E42F0
	public void OpenDoiMatKhau(); // 0x0000000180632A20-0x0000000180632A30
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x000000018062EC40-0x000000018062EC70
	private void HandlePasswordChanged(); // 0x000000018062EB70-0x000000018062EC40
	public void OpenOnlineGift(); // 0x0000000180633EA0-0x0000000180633FB0
	private void WireOnlineGiftButton(); // 0x000000018063D410-0x000000018063D8C0
	public void OpenHuongDan(); // 0x0000000180633580-0x0000000180633690
	private void WireGuideButton(); // 0x000000018063CE40-0x000000018063D160
	public void OpenFriend(); // 0x0000000180633120-0x0000000180633230
	private void WireFriendButton(); // 0x000000018063C8E0-0x000000018063CE40
	public bool IsHubViewActive(); // 0x0000000180630230-0x0000000180630560
	private void SetupDailyCheckIn(); // 0x0000000180637200-0x0000000180637310
	public void OpenDailyCheckIn(); // 0x0000000180632960-0x0000000180632A20
	public void OpenWorldChat(); // 0x00000001806352D0-0x0000000180635420
	private void LoadAudioSettings(); // 0x0000000180630930-0x0000000180630A00
	private void PlayBackgroundMusic(); // 0x00000001806355E0-0x0000000180635770
	private void SetupButtonSounds(); // 0x00000001806370A0-0x0000000180637200
	[IteratorStateMachine(typeof(_AttachButtonSoundsAsync_d__155))]
	private IEnumerator AttachButtonSoundsAsync(); // 0x000000018062A140-0x000000018062A1B0
	public void StopBackgroundMusic(); // 0x000000018063A370-0x000000018063A410
	public void PauseBackgroundMusic(); // 0x0000000180635540-0x00000001806355E0
	public void ResumeBackgroundMusic(); // 0x0000000180636720-0x00000001806368B0
	public void SetBGMVolume(float volume); // 0x0000000180636BA0-0x0000000180636C50
	public void FadeInBGM(float duration = 2f /* Metadata: 0x0068D57D */); // 0x000000018062D8C0-0x000000018062DA40
	public void FadeOutBGM(float duration = 2f /* Metadata: 0x0068D581 */, bool stopAfterFade = true /* Metadata: 0x0068D585 */); // 0x000000018062DA40-0x000000018062DC30
	public void OpenWheelDay(); // 0x0000000180635150-0x0000000180635160
	private void OpenWheelTab(WheelKind kind); // 0x0000000180635160-0x00000001806352D0
	public void OpenGachaPanel(); // 0x0000000180633230-0x00000001806333E0
	public void OpenGalaxyWheel(); // 0x00000001806333E0-0x00000001806333F0
	public void OpenFirstPay(); // 0x0000000180633010-0x0000000180633120
	private bool CheckLevelGate(int requiredLevel, string featureName); // 0x000000018062A960-0x000000018062AA60
	public void OpenTower(); // 0x0000000180634F10-0x0000000180634F80
	public void OpenTreasureWheel(); // 0x0000000180634F80-0x0000000180634F90
	public void OpenRechargeEvent(); // 0x00000001806345F0-0x0000000180634630
	public void OpenMidAutumn(); // 0x0000000180633C30-0x0000000180633C70
	public void OpenGuild(); // 0x0000000180633510-0x0000000180633580
	private void OpenPokyEventPanel(string panelKey); // 0x0000000180634410-0x00000001806344E0
	private void WireGuildButton(); // 0x000000018063D160-0x000000018063D410
	private void WireShopAvatarButton(); // 0x000000018063D8C0-0x000000018063DD90
	private static void DisablePersistentClicks(Button button); // 0x000000018062BC70-0x000000018062BD40
	private void WireFeatureButton(string buttonName, string prefabPath, UnityAction onClick); // 0x000000018063C580-0x000000018063C8E0
	private void OpenLazyPanel(string panelKey, Action<GameObject> onReady); // 0x0000000180633940-0x0000000180633AF0
	[IteratorStateMachine(typeof(_ShowRemoteEventWhenReady_d__193))]
	private IEnumerator ShowRemoteEventWhenReady(); // 0x0000000180638540-0x00000001806385B0
	private void HandleRemoteEventCta(RemoteEventItem ev); // 0x000000018062EC70-0x000000018062FB80
	public void OpenTienHoa(); // 0x0000000180634DD0-0x0000000180634F10
	public void OpenMega(); // 0x0000000180633AF0-0x0000000180633C30
	public void OpenQuest(); // 0x00000001806344E0-0x00000001806345F0
	public void OpenVongQuay(); // 0x00000001806350A0-0x0000000180635150
	private static UnityEngine.UI.Text FindStarText(Transform panelRoot, string gemName); // 0x000000018062E1B0-0x000000018062E2B0
	public void OpenGiftCode(); // 0x00000001806333F0-0x0000000180633510
	public void OpenThuVien(); // 0x0000000180634CB0-0x0000000180634DD0
	public void OpenKhoPet(); // 0x0000000180633820-0x0000000180633940
	public void OpenXepHang(); // 0x0000000180635420-0x0000000180635540
	public void OpenInfoPlayer(long targetUserId = 0 /* Metadata: 0x0068D586 */); // 0x0000000180633690-0x0000000180633820
	public void OpenChinhPhucPanel(); // 0x0000000180632650-0x0000000180632960
	public void OpenShop(); // 0x00000001806348B0-0x00000001806349D0
	public void OpenShopAvatar(int category = 0 /* Metadata: 0x0068D58E */); // 0x00000001806347D0-0x00000001806348B0
	private void InitializeGiftBox(); // 0x000000018062FFC0-0x00000001806301C0
	public void CheckForGifts(int userId); // 0x000000018062A630-0x000000018062A7A0
	[IteratorStateMachine(typeof(_CheckGiftsCoroutine_d__210))]
	private IEnumerator CheckGiftsCoroutine(int userId); // 0x000000018062A7A0-0x000000018062A820
	private void OnGiftCountReceived(GiftCountResponse response, int userId); // 0x0000000180631350-0x00000001806315A0
	private void HandleGiftPush(ChatMessageDTO m); // 0x000000018062E870-0x000000018062EA30
	private bool IsMatchBlockingHubUi(); // 0x0000000180630560-0x0000000180630620
	private void ApplyOptimisticGiftBadge(); // 0x0000000180629B50-0x0000000180629BE0
	[IteratorStateMachine(typeof(_GiftPushRefreshAfter_d__215))]
	private IEnumerator GiftPushRefreshAfter(float delay); // 0x000000018062E7F0-0x000000018062E870
	[IteratorStateMachine(typeof(_AnnounceNewGiftWhenHubVisible_d__216))]
	private IEnumerator AnnounceNewGiftWhenHubVisible(); // 0x0000000180629450-0x00000001806294C0
	[IteratorStateMachine(typeof(_GiftFallbackPollLoop_d__217))]
	private IEnumerator GiftFallbackPollLoop(); // 0x000000018062E780-0x000000018062E7F0
	[IteratorStateMachine(typeof(_AutoOpenNoticeAfterLogin_d__219))]
	private IEnumerator AutoOpenNoticeAfterLogin(); // 0x000000018062A1B0-0x000000018062A220
	private void HandleNoticePush(ChatMessageDTO m); // 0x000000018062EA30-0x000000018062EB70
	[IteratorStateMachine(typeof(_NoticePushRefreshAfter_d__221))]
	private IEnumerator NoticePushRefreshAfter(float delay); // 0x0000000180630C50-0x0000000180630CD0
	[IteratorStateMachine(typeof(_ShakeNoticeIconUntilSeen_d__222))]
	private IEnumerator ShakeNoticeIconUntilSeen(int uid); // 0x00000001806379B0-0x0000000180637A30
	private void PlayNoticeShakeOnce(); // 0x0000000180635BD0-0x0000000180635DB0
	private void StopNoticeShake(); // 0x000000018063A410-0x000000018063A560
	[IteratorStateMachine(typeof(_NoticeFallbackPollLoop_d__225))]
	private IEnumerator NoticeFallbackPollLoop(); // 0x0000000180630BE0-0x0000000180630C50
	[IteratorStateMachine(typeof(_LoadGiftDetailsCoroutine_d__226))]
	private IEnumerator LoadGiftDetailsCoroutine(int userId); // 0x0000000180630A00-0x0000000180630A80
	private void PlayGiftNotificationAnimation(); // 0x00000001806359F0-0x0000000180635BD0
	private void StartGiftIdlePulse(); // 0x00000001806385B0-0x00000001806386F0
	private void PlayGiftArrivalFx(); // 0x0000000180635770-0x00000001806359F0
	[IteratorStateMachine(typeof(_RestartGiftPulseNextFrame_d__230))]
	private IEnumerator RestartGiftPulseNextFrame(); // 0x00000001806365D0-0x0000000180636640
	public void ShowGiftBoxAnimation(GiftDTO gift); // 0x0000000180637D80-0x0000000180637EF0
	[IteratorStateMachine(typeof(_ShowGiftDetailAfterAnimation_d__232))]
	private IEnumerator ShowGiftDetailAfterAnimation(float delay); // 0x0000000180637EF0-0x0000000180637F70
	private void ShowGiftDetail(GiftDTO gift); // 0x0000000180637F70-0x00000001806381C0
	private void DisplayRewards(GiftDTO gift); // 0x000000018062BD40-0x000000018062CEE0
	private void UpdateShardRewardUI(GameObject obj, ShardRewardItem shard); // 0x000000018063B9A0-0x000000018063BB90
	private Image EnsurePieceOverlay(GameObject obj, Image mainImg); // 0x000000018062D210-0x000000018062D550
	private void SetRewardVisual(GameObject obj, Sprite icon, string label, bool showPiece = false /* Metadata: 0x0068D58F */); // 0x0000000180636C50-0x00000001806370A0
	private Image FindRewardImage(GameObject obj, params string[] names); // 0x000000018062DE20-0x000000018062E010
	private UnityEngine.UI.Text FindRewardText(GameObject obj); // 0x000000018062E010-0x000000018062E1B0
	private void ClearListReward(); // 0x000000018062B180-0x000000018062B480
	private void UpdateRewardUI(GameObject rewardObj, int amount); // 0x000000018063B7E0-0x000000018063B8F0
	private void UpdatePetRewardUI(GameObject petObj, int petId, string petName); // 0x000000018063B610-0x000000018063B7E0
	private void UpdateAVTRewardUI(GameObject petObj, int avtId); // 0x000000018063ABE0-0x000000018063ADC0
	private void UpdateCardRewardUI(GameObject cardObj, int cardId, string cardName); // 0x000000018063ADC0-0x000000018063AFB0
	private void UpdateStoneRewardUI(GameObject stoneObj, StoneRewardDTO stone); // 0x000000018063BDA0-0x000000018063C020
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x000000018062E4F0-0x000000018062E780
	public void RequestPendingGifts(Action<List<GiftDTO>> onDone); // 0x00000001806362C0-0x0000000180636410
	[IteratorStateMachine(typeof(_RequestPendingGiftsCoroutine_d__250))]
	private IEnumerator RequestPendingGiftsCoroutine(int userId, Action<List<GiftDTO>> onDone); // 0x0000000180636220-0x00000001806362C0
	public void ClaimGift(GiftDTO gift, Action<bool, GiftDTO> onDone); // 0x000000018062ADD0-0x000000018062AF60
	[IteratorStateMachine(typeof(_ClaimGiftCoroutine_d__256))]
	private IEnumerator ClaimGiftCoroutine(GiftDTO gift, int userId, Action<bool, GiftDTO> onDone); // 0x000000018062AD10-0x000000018062ADD0
	public void ClaimGiftsSequential(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x000000018062B030-0x000000018062B180
	[IteratorStateMachine(typeof(_ClaimGiftsSequentialCoroutine_d__258))]
	private IEnumerator ClaimGiftsSequentialCoroutine(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x000000018062AF60-0x000000018062B030
	private void ApplyGiftClaimed(GiftDTO source, GiftDTO claimedGift); // 0x0000000180629580-0x0000000180629790
	private void UpdateGiftIconBadge(int count); // 0x000000018063AFB0-0x000000018063B200
	public void ClaimCurrentGift(); // 0x000000018062AA60-0x000000018062AD10
	public void ShowClaimedExtras(GiftDTO gift); // 0x0000000180637A30-0x0000000180637D80
	private void CloseGiftBoxWithAnimation(); // 0x000000018062B480-0x000000018062B780
	public void CloseGiftBox(); // 0x000000018062B780-0x000000018062B840
	public void OnGiftIconClicked(); // 0x00000001806315A0-0x00000001806319D0
	public void RefreshUserInfo(bool silent = false /* Metadata: 0x0068D590 */); // 0x0000000180635EC0-0x0000000180636160
	[IteratorStateMachine(typeof(_RefreshDebouncedCoroutine_d__274))]
	private IEnumerator RefreshDebouncedCoroutine(int userId); // 0x0000000180635DB0-0x0000000180635E30
	[IteratorStateMachine(typeof(_RefreshUserCoroutine_d__275))]
	private IEnumerator RefreshUserCoroutine(int userId, bool silent); // 0x0000000180635E30-0x0000000180635EC0
	private void OnUserRefreshed(UserDTO user, bool silent = false /* Metadata: 0x0068D591 */); // 0x0000000180632050-0x00000001806324B0
	private void ApplyWeaponBadge(UserDTO user); // 0x000000018062A060-0x000000018062A140
	public static string FormatVND(long amount); // 0x000000018062E3E0-0x000000018062E460
	private void OnRefreshError(string error, bool silent); // 0x0000000180631C70-0x0000000180631D40
	public void ShowPanelBoss(); // 0x00000001806383D0-0x0000000180638540
	private void EnsureBossCoversHeader(); // 0x000000018062CEE0-0x000000018062D210
	private void ApplyHonorIconLegacyHeader(); // 0x0000000180629790-0x00000001806299D0
	private static bool IsHonorNode(string n); // 0x00000001806301C0-0x0000000180630230
	private static Image FirstChildImage(Transform root, Transform skip); // 0x000000018062E2B0-0x000000018062E3E0
	public void HidePanelBoss(); // 0x000000018062FF40-0x000000018062FFC0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__291))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180630A80-0x0000000180630AF0
	[IteratorStateMachine(typeof(_DeferChinhPhucPreload_d__292))]
	private IEnumerator DeferChinhPhucPreload(); // 0x000000018062BC20-0x000000018062BC70
	[IteratorStateMachine(typeof(_RestorePVPRoomWithLoading_d__293))]
	private IEnumerator RestorePVPRoomWithLoading(); // 0x0000000180636640-0x00000001806366B0
	private CanvasGroup OpenPVPRoomHidden(); // 0x00000001806341D0-0x0000000180634410
	[IteratorStateMachine(typeof(_WaitForPVPLoad_d__295))]
	private IEnumerator WaitForPVPLoad(ManagerRoomPVP pvpManager, Action onDone); // 0x000000018063C120-0x000000018063C1B0
	public void OpenPVPPanel(string roomName); // 0x0000000180633FB0-0x00000001806341D0
	public void HidePVPPanel(); // 0x000000018062FD80-0x000000018062FF40
	public void ExitPVPToHub(); // 0x000000018062D550-0x000000018062D8C0
	public void OnPVPMatchSceneUnloaded(); // 0x0000000180631A60-0x0000000180631C70
	public void ReturnToPVPLobbyFromRoom(); // 0x00000001806368B0-0x0000000180636BA0
	public void ShowPVPRoomFromLobby(); // 0x00000001806381C0-0x00000001806383D0
	[IteratorStateMachine(typeof(_RestorePanelStateWithLoading_d__302))]
	private IEnumerator RestorePanelStateWithLoading(); // 0x00000001806366B0-0x0000000180636720
	[IteratorStateMachine(typeof(_FastRestoreCoopRoom_d__303))]
	private IEnumerator FastRestoreCoopRoom(); // 0x000000018062DC30-0x000000018062DCA0
	[IteratorStateMachine(typeof(_SweepOrphanLoadingAfterRestore_d__304))]
	private IEnumerator SweepOrphanLoadingAfterRestore(); // 0x000000018063A560-0x000000018063A5B0
	[IteratorStateMachine(typeof(_FastRestoreRoomDataWithRetry_d__305))]
	private IEnumerator FastRestoreRoomDataWithRetry(ManagerRoom roomManager, int userId, int selectedPetId, Action onDone); // 0x000000018062DD80-0x000000018062DE20
	private void StartHubBackgroundRefresh(int userId); // 0x00000001806386F0-0x0000000180638830
	private int ResolveRoomPanelIndex(ManagerChinhPhuc chinhPhucManager); // 0x0000000180636410-0x00000001806365D0
	public void NotifyReturnFromAdditiveMatchPVP(); // 0x0000000180630CD0-0x0000000180630E50
	[IteratorStateMachine(typeof(_FastRestorePVPRoom_d__309))]
	private IEnumerator FastRestorePVPRoom(); // 0x000000018062DD10-0x000000018062DD80
	[IteratorStateMachine(typeof(_FastRestorePVPLobby_d__310))]
	private IEnumerator FastRestorePVPLobby(); // 0x000000018062DCA0-0x000000018062DD10
	private void SetupLoadingPanel(bool useLoadingRoom = false /* Metadata: 0x0068D592 */); // 0x00000001806373E0-0x00000001806379B0
	[IteratorStateMachine(typeof(_LoadingWatchdog_d__315))]
	private IEnumerator LoadingWatchdog(); // 0x0000000180630B70-0x0000000180630BE0
	private GameObject CreateFallbackLoadingPanel(); // 0x000000018062B8B0-0x000000018062BC20
	private void KeepLoadingOnTop(); // 0x0000000180630620-0x0000000180630730
	private CanvasGroup OpenChinhPhucHidden(); // 0x00000001806324B0-0x0000000180632650
	private CanvasGroup OpenRoomHidden(ManagerRoom roomManager); // 0x0000000180634630-0x00000001806347D0
	private void HideLoadingPanel(); // 0x000000018062FC60-0x000000018062FD80
	private void UpdateMedalImage(int userLevel, int rankPvp = 0 /* Metadata: 0x0068D593 */); // 0x000000018063B2B0-0x000000018063B610
	private int GetMedalLevel(int userLevel); // 0x000000018062E460-0x000000018062E4F0
	private void OnUserReceived(UserDTO user); // 0x0000000180631D40-0x0000000180632050
	private void ApplyUserUi(UserDTO user); // 0x0000000180629BE0-0x000000018062A060
	private void ApplyExpBar(float expPercent); // 0x00000001806294C0-0x0000000180629580
	private void SetupImgLevel(int level, Image imgLv); // 0x0000000180637310-0x00000001806373E0
	private void ApplyHubAvatar(UserDTO user); // 0x00000001806299D0-0x0000000180629B50
	private void HandleSelfAvatarChanged(); // 0x000000018062FB80-0x000000018062FC60
	private void OnDestroy(); // 0x0000000180630E50-0x00000001806312E0
	public void OnHubSuspend(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void OnHubResume(); // 0x00000001806319D0-0x0000000180631A60
	public void UpdateWheelFlag(int wheelCount); // 0x000000018063C020-0x000000018063C120
	public void UpdateStarUI(int starWhite, int starBlue, int starRed); // 0x000000018063BB90-0x000000018063BDA0
	public void UpdateGoldUI(int gold); // 0x000000018063B200-0x000000018063B2B0
	public void UpdateSafiaUI(int safia); // 0x000000018063B8F0-0x000000018063B9A0
	private void OnError(string error); // 0x00000001806312E0-0x0000000180631350
	public void ReloadUserInfo(); // 0x0000000180636160-0x0000000180636220
	[IteratorStateMachine(typeof(_LoadUserData_d__339))]
	private IEnumerator LoadUserData(int userId); // 0x0000000180630AF0-0x0000000180630B70
	[CompilerGenerated]
	private void _Start_b__125_1(); // 0x000000018063AA40-0x000000018063ABD0
	[CompilerGenerated]
	private void _FadeInBGM_b__160_0(float val); // 0x000000018063A6E0-0x000000018063A770
	[CompilerGenerated]
	private void _WireShopAvatarButton_b__188_0(); // 0x000000018063ABD0-0x000000018063ABE0
	[CompilerGenerated]
	private void _OpenVongQuay_b__198_0(GameObject panel); // 0x000000018063A780-0x000000018063A9C0
	[CompilerGenerated]
	private void _PlayGiftArrivalFx_b__229_0(); // 0x000000018063A9C0-0x000000018063AA40
	[CompilerGenerated]
	private void _ClaimCurrentGift_b__261_0(bool ok, GiftDTO claimed); // 0x000000018063A5B0-0x000000018063A6E0
	[CompilerGenerated]
	private void _FastRestorePVPLobby_b__310_0(UserDTO user); // 0x000000018063A770-0x000000018063A780
	[CompilerGenerated]
	private void _LoadUserData_b__339_0(UserDTO user); // 0x000000018063A770-0x000000018063A780
}

