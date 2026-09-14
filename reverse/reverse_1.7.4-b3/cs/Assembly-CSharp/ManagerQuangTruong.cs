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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerQuangTruong : MonoBehaviour, IHubSuspendable // TypeDefIndex: 2022
{
	// Fields
	[Header("Donate T\u00EDch L\u0169y")]
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
	public const string PANEL_TOWER = "PanelTower"; // Metadata: 0x005F0409
	public const string PANEL_TREASURE_WHEEL = "PanelTreasureWheel"; // Metadata: 0x005F0414
	public const string PANEL_RECHARGE_EVENT = "PanelRechargeEvent"; // Metadata: 0x005F0427
	public const string PANEL_MID_AUTUMN = "PanelMidAutumn"; // Metadata: 0x005F043A
	public const string PANEL_GUILD = "PanelGuild"; // Metadata: 0x005F0449
	private const int LEVEL_REQUIRED_TOWER = 20; // Metadata: 0x005F0454
	private const int LEVEL_REQUIRED_WORLD_BOSS = 10; // Metadata: 0x005F0455
	private const int LEVEL_REQUIRED_EVOLUTION = 15; // Metadata: 0x005F0456
	private const int LEVEL_REQUIRED_AWAKENING = 25; // Metadata: 0x005F0457
	private const int LEVEL_REQUIRED_GUILD = 20; // Metadata: 0x005F0458
	private const int LEVEL_REQUIRED_WHEEL = 15; // Metadata: 0x005F0459
	private const string OWNER_SHOP_AVATAR_BUTTON = "btnShopAvt"; // Metadata: 0x005F045A
	private UnityAction _openShopAvatarFromHub; // 0x3B8
	private const float REMOTE_EVENT_DELAY = 2.5f; // Metadata: 0x005F0465
	private const float NOTICE_AUTO_OPEN_DELAY = 1.2f; // Metadata: 0x005F0469
	[CompilerGenerated]
	private string _LastGiftClaimError_k__BackingField; // 0x3C0
	private bool _refreshInFlight; // 0x3C8
	private bool _refreshPending; // 0x3C9
	private bool _refreshWantsLoading; // 0x3CA
	private Coroutine _refreshDebounceCo; // 0x3D0
	private const float REFRESH_DEBOUNCE_SEC = 0.25f; // Metadata: 0x005F046D
	private float _refreshStartedAt; // 0x3D8
	private const float REFRESH_STUCK_SEC = 30f; // Metadata: 0x005F0471
	private ManagerBoss _managerBoss; // 0x3E0
	public const string FLAG_BOSS_COVER_HEADER = "panelboss.coverheader"; // Metadata: 0x005F0475
	private const int BOSS_PANEL_ORDER = 100; // Metadata: 0x005F048B
	private static bool _bossOrderApplied; // 0x08
	private bool _honorIconApplied; // 0x3E8
	private GameObject _activeLoadingTarget; // 0x3F0
	private Coroutine _loadingWatchdog; // 0x3F8
	private const float LOADING_WATCHDOG_TIMEOUT = 20f; // Metadata: 0x005F048D
	internal int ChienTich; // 0x400

	// Properties
	private HubButtonRegistry HubButtons { get; } // 0x00000001809ADDF0-0x00000001809ADE80 
	private Transform HubEventStrip { get; } // 0x00000001809ADE80-0x00000001809AE060 
	public IList<GiftDTO> PendingGifts { get; } // 0x00000001809C3020-0x00000001809C3030 
	public string LastGiftClaimError { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001809C35B0-0x00000001809C35C0 0x00000001809C35C0-0x00000001809C3620

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2023
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static UnityAction<bool> __9__125_0; // 0x08
		public static Action<GameObject> __9__131_0; // 0x10
		public static Action<GameObject> __9__132_0; // 0x18
		public static Action<GameObject> __9__133_0; // 0x20
		public static Action<GameObject> __9__136_0; // 0x28
		public static Action<GameObject> __9__137_0; // 0x30
		public static Action<GameObject> __9__144_0; // 0x38
		public static Action<GameObject> __9__146_0; // 0x40
		public static Action<GameObject> __9__148_0; // 0x48
		public static Action<GameObject> __9__165_0; // 0x50
		public static Action<GameObject> __9__166_0; // 0x58
		public static Action<GameObject> __9__168_0; // 0x60
		public static Action<GameObject> __9__197_0; // 0x68
		public static Action<GameObject> __9__198_0; // 0x70
		public static Action<GameObject> __9__199_0; // 0x78
		public static Action<GameObject> __9__202_0; // 0x80
		public static Action<GameObject> __9__203_0; // 0x88
		public static Action<GameObject> __9__205_0; // 0x90
		public static Action<GameObject> __9__208_0; // 0x98
		public static Action<string> __9__223_1; // 0xA0
		public static Action<string> __9__228_1; // 0xA8
		public static Action<string> __9__252_1; // 0xB0
		public static Action<GameObject> __9__267_0; // 0xB8
		public static Action<string> __9__293_1; // 0xC0
		public static Action<string> __9__312_1; // 0xC8
		public static Action<string> __9__341_1; // 0xD0

		// Constructors
		static __c(); // 0x00000001809D14C0-0x00000001809D1560
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Start_b__125_0(bool busy); // 0x00000001809D1560-0x00000001809D15C0
		internal void _OpenEvent_b__131_0(GameObject panel); // 0x00000001809D15C0-0x00000001809D1620
		internal void _OpenEventFest_b__132_0(GameObject panel); // 0x00000001809D1620-0x00000001809D1680
		internal void _OpenUpdateCard_b__133_0(GameObject panel); // 0x00000001809D1680-0x00000001809D16E0
		internal void _OpenMiniGame_b__136_0(GameObject panel); // 0x00000001809D16E0-0x00000001809D1740
		internal void _OpenNapTichLuy_b__137_0(GameObject panel); // 0x00000001809D1740-0x00000001809D17A0
		internal void _OpenOnlineGift_b__144_0(GameObject panel); // 0x00000001809D17A0-0x00000001809D1800
		internal void _OpenHuongDan_b__146_0(GameObject panel); // 0x00000001809D1800-0x00000001809D1AE0
		internal void _OpenFriend_b__148_0(GameObject panel); // 0x00000001809D1AE0-0x00000001809D1B40
		internal void _OpenWheelTab_b__165_0(GameObject panel); // 0x00000001809D1B40-0x00000001809D1CA0
		internal void _OpenGachaPanel_b__166_0(GameObject panel); // 0x00000001809D1CA0-0x00000001809D1D00
		internal void _OpenFirstPay_b__168_0(GameObject panel); // 0x00000001809D1D00-0x00000001809D1E60
		internal void _OpenTienHoa_b__197_0(GameObject panel); // 0x00000001809D1E60-0x00000001809D2110
		internal void _OpenMega_b__198_0(GameObject panel); // 0x00000001809D2110-0x00000001809D23C0
		internal void _OpenQuest_b__199_0(GameObject panel); // 0x00000001809D23C0-0x00000001809D2520
		internal void _OpenGiftCode_b__202_0(GameObject panel); // 0x00000001809D2520-0x00000001809D2680
		internal void _OpenThuVien_b__203_0(GameObject panel); // 0x00000001809D2680-0x00000001809D2810
		internal void _OpenXepHang_b__205_0(GameObject panel); // 0x00000001809D2810-0x00000001809D2970
		internal void _OpenShop_b__208_0(GameObject panel); // 0x00000001809D2970-0x00000001809D2C20
		internal void _NoticePushRefreshAfter_b__223_1(string err); // 0x000000018028A320-0x000000018028A330
		internal void _LoadGiftDetailsCoroutine_b__228_1(string error); // 0x00000001809D2C20-0x00000001809D2CA0
		internal void _RequestPendingGiftsCoroutine_b__252_1(string error); // 0x00000001809D2CA0-0x00000001809D2D20
		internal void _OnGiftIconClicked_b__267_0(GameObject panel); // 0x00000001809D2D20-0x00000001809D2E80
		internal void _LoadSceneAfterDelay_b__293_1(string e); // 0x00000001809D2E80-0x00000001809D2F00
		internal void _FastRestorePVPLobby_b__312_1(string err); // 0x00000001809D2F00-0x00000001809D2F80
		internal void _LoadUserData_b__341_1(string error); // 0x00000001809D2F80-0x00000001809D3000
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 2024
	{
		// Fields
		public ThongBaoListData prefill; // 0x10

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenThongBao_b__0(GameObject panel); // 0x00000001809D3000-0x00000001809D3070
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass163_0 // TypeDefIndex: 2025
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool stopAfterFade; // 0x18

		// Constructors
		public __c__DisplayClass163_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeOutBGM_b__0(float val); // 0x00000001809D3070-0x00000001809D31E0
		internal void _FadeOutBGM_b__1(); // 0x00000001809D31E0-0x00000001809D3350
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass186_0 // TypeDefIndex: 2026
	{
		// Fields
		public string panelKey; // 0x10

		// Constructors
		public __c__DisplayClass186_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenPokyEventPanel_b__0(GameObject panel); // 0x00000001809D3350-0x00000001809D3450
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass193_0 // TypeDefIndex: 2027
	{
		// Fields
		public string panelKey; // 0x10
		public Action<GameObject> onReady; // 0x18

		// Constructors
		public __c__DisplayClass193_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenLazyPanel_b__0(GameObject panel); // 0x00000001809D3450-0x00000001809D35D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass195_0 // TypeDefIndex: 2028
	{
		// Fields
		public RemoteEventItem ev; // 0x10
		public ManagerQuangTruong __4__this; // 0x18

		// Constructors
		public __c__DisplayClass195_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowRemoteEventWhenReady_b__0(GameObject panel); // 0x00000001809D35D0-0x00000001809D37B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass204_0 // TypeDefIndex: 2029
	{
		// Fields
		public UIPanelManager pm; // 0x10

		// Constructors
		public __c__DisplayClass204_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenKhoPet_b__0(GameObject panel); // 0x00000001809D37B0-0x00000001809D3BA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass206_0 // TypeDefIndex: 2030
	{
		// Fields
		public long targetUserId; // 0x10

		// Constructors
		public __c__DisplayClass206_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenInfoPlayer_b__0(GameObject panel); // 0x00000001809D3BA0-0x00000001809D3EF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 2031
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public int category; // 0x18

		// Constructors
		public __c__DisplayClass209_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenShopAvatar_b__0(GameObject panel); // 0x00000001809D3EF0-0x00000001809D4300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass212_0 // TypeDefIndex: 2032
	{
		// Fields
		public bool apiCompleted; // 0x10
		public GiftCountResponse responseData; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass212_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CheckGiftsCoroutine_b__0(GiftCountResponse response); // 0x00000001802B9410-0x00000001802B9470
		internal void _CheckGiftsCoroutine_b__1(string error); // 0x00000001809D4300-0x00000001809D43F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass223_0 // TypeDefIndex: 2033
	{
		// Fields
		public ManagerThongBao.ThongBaoResponse data; // 0x10

		// Constructors
		public __c__DisplayClass223_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _NoticePushRefreshAfter_b__0(ManagerThongBao.ThongBaoResponse resp); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass228_0 // TypeDefIndex: 2034
	{
		// Fields
		public List<GiftDTO> giftsData; // 0x10

		// Constructors
		public __c__DisplayClass228_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadGiftDetailsCoroutine_b__0(List<GiftDTO> gifts); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass252_0 // TypeDefIndex: 2035
	{
		// Fields
		public List<GiftDTO> data; // 0x10

		// Constructors
		public __c__DisplayClass252_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestPendingGiftsCoroutine_b__0(List<GiftDTO> gifts); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass258_0 // TypeDefIndex: 2036
	{
		// Fields
		public bool ok; // 0x10
		public GiftDTO result; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Constructors
		public __c__DisplayClass258_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimGiftCoroutine_b__0(GiftDTO g); // 0x00000001802B9410-0x00000001802B9470
		internal void _ClaimGiftCoroutine_b__1(string e); // 0x00000001809D43F0-0x00000001809D44E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass260_0 // TypeDefIndex: 2037
	{
		// Fields
		public bool done; // 0x10
		public bool good; // 0x11
		public GiftDTO res; // 0x18

		// Constructors
		public __c__DisplayClass260_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimGiftsSequentialCoroutine_b__0(bool s, GiftDTO r); // 0x00000001809D44E0-0x00000001809D4540
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass265_0 // TypeDefIndex: 2038
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public CanvasGroup canvasGroup; // 0x18

		// Constructors
		public __c__DisplayClass265_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseGiftBoxWithAnimation_b__0(); // 0x00000001809D4540-0x00000001809D46E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass277_0 // TypeDefIndex: 2039
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool useSilent; // 0x18

		// Constructors
		public __c__DisplayClass277_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshUserCoroutine_b__0(UserDTO user); // 0x00000001809D46E0-0x00000001809D4710
		internal void _RefreshUserCoroutine_b__1(string error); // 0x00000001809D4710-0x00000001809D4800
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass293_0 // TypeDefIndex: 2040
	{
		// Fields
		public bool hubLoaded; // 0x10

		// Constructors
		public __c__DisplayClass293_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadSceneAfterDelay_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass295_0 // TypeDefIndex: 2041
	{
		// Fields
		public bool pvpLoaded; // 0x10

		// Constructors
		public __c__DisplayClass295_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RestorePVPRoomWithLoading_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal bool _RestorePVPRoomWithLoading_b__1(); // 0x00000001809D4800-0x00000001809D4810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass304_0 // TypeDefIndex: 2042
	{
		// Fields
		public bool chinhPhucLoaded; // 0x10

		// Constructors
		public __c__DisplayClass304_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RestorePanelStateWithLoading_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal bool _RestorePanelStateWithLoading_b__1(); // 0x00000001809D4800-0x00000001809D4810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass305_0 // TypeDefIndex: 2043
	{
		// Fields
		public bool chinhPhucDone; // 0x10
		public ManagerRoom roomManager; // 0x18
		public bool userDone; // 0x20
		public bool roomDone; // 0x21

		// Constructors
		public __c__DisplayClass305_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FastRestoreCoopRoom_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal void _FastRestoreCoopRoom_b__1(UserDTO user); // 0x00000001809D4810-0x00000001809D48A0
		internal void _FastRestoreCoopRoom_b__2(string err); // 0x00000001809D48A0-0x00000001809D4930
		internal void _FastRestoreCoopRoom_b__3(); // 0x00000001809D4930-0x00000001809D4940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass307_0 // TypeDefIndex: 2044
	{
		// Fields
		public ManagerRoom roomManager; // 0x10
		public bool roomLoaded; // 0x18
		public int retry; // 0x1C
		public Action<RoomDTO> __9__0; // 0x20
		public Action<string> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass307_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FastRestoreRoomDataWithRetry_b__0(RoomDTO room); // 0x00000001809D4940-0x00000001809D4A50
		internal void _FastRestoreRoomDataWithRetry_b__1(string err); // 0x00000001809D4A50-0x00000001809D4B30
	}

	[CompilerGenerated]
	private sealed class _AnnounceNewGiftWhenHubVisible_d__218 : IEnumerator<object> // TypeDefIndex: 2045
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _guard_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnnounceNewGiftWhenHubVisible_d__218(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809D4B30-0x00000001809D4EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D4EF0-0x00000001809D4F30
	}

	[CompilerGenerated]
	private sealed class _AttachButtonSoundsAsync_d__157 : IEnumerator<object> // TypeDefIndex: 2046
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private Button[] _allButtons_5__2; // 0x28
		private int _count_5__3; // 0x30
		private int _i_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AttachButtonSoundsAsync_d__157(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809D4F30-0x00000001809D52E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D52E0-0x00000001809D5320
	}

	[CompilerGenerated]
	private sealed class _AutoOpenNoticeAfterLogin_d__221 : IEnumerator<object> // TypeDefIndex: 2047
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoOpenNoticeAfterLogin_d__221(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809D5320-0x00000001809D58E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D58E0-0x00000001809D5920
	}

	[CompilerGenerated]
	private sealed class _CheckGiftsCoroutine_d__212 : IEnumerator<object> // TypeDefIndex: 2048
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass212_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckGiftsCoroutine_d__212(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809D5920-0x00000001809D5FA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D5FA0-0x00000001809D5FE0
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftCoroutine_d__258 : IEnumerator<object> // TypeDefIndex: 2049
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public GiftDTO gift; // 0x28
		public int userId; // 0x30
		private __c__DisplayClass258_0 __8__1; // 0x38
		public Action<bool, GiftDTO> onDone; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftCoroutine_d__258(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001809D5FE0-0x00000001809D64C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D64C0-0x00000001809D6500
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftsSequentialCoroutine_d__260 : IEnumerator<object> // TypeDefIndex: 2050
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<GiftDTO> gifts; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass260_0 __8__1; // 0x30
		public Action<GiftDTO> onEach; // 0x38
		public Action<int, int> onDone; // 0x40
		private int _ok_5__2; // 0x48
		private int _fail_5__3; // 0x4C
		private int _i_5__4; // 0x50
		private GiftDTO _g_5__5; // 0x58
		private float _guard_5__6; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftsSequentialCoroutine_d__260(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001809D6500-0x00000001809D65C0
		private bool MoveNext(); // 0x00000001809D65C0-0x00000001809D6AA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D6AA0-0x00000001809D6AE0
	}

	[CompilerGenerated]
	private sealed class _ConsumeHomeDeepLink_d__126 : IEnumerator<object> // TypeDefIndex: 2051
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private string _key_5__2; // 0x28
		private float _waited_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeHomeDeepLink_d__126(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809D6AE0-0x00000001809D8440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D8440-0x00000001809D8480
	}

	[CompilerGenerated]
	private sealed class _DeferChinhPhucPreload_d__294 : IEnumerator<object> // TypeDefIndex: 2052
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DeferChinhPhucPreload_d__294(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809D8480-0x00000001809D8660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D8660-0x00000001809D86A0
	}

	[CompilerGenerated]
	private sealed class _FastRestoreCoopRoom_d__305 : IEnumerator<object> // TypeDefIndex: 2053
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass305_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30
		private int _selectedPetId_5__3; // 0x34
		private ManagerChinhPhuc _chinhPhucManager_5__4; // 0x38
		private CanvasGroup _chinhPhucCG_5__5; // 0x40
		private int _panelIndex_5__6; // 0x48
		private bool _petsDone_5__7; // 0x4C
		private float _waitTimeout_5__8; // 0x50
		private float _waitElapsed_5__9; // 0x54
		private float _keepTopTimer_5__10; // 0x58
		private int _i_5__11; // 0x5C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreCoopRoom_d__305(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018092D510-0x000000018092D620
		private bool MoveNext(); // 0x00000001809D86A0-0x00000001809D9E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809D9E50-0x00000001809D9E90
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPLobby_d__312 : IEnumerator<object> // TypeDefIndex: 2054
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPLobby_d__312(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809D9E90-0x00000001809DA8E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DA8E0-0x00000001809DA920
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPRoom_d__311 : IEnumerator<object> // TypeDefIndex: 2055
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private ManagerRoomPVP _pvpManager_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPRoom_d__311(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809DA920-0x00000001809DB540
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DB540-0x00000001809DB580
	}

	[CompilerGenerated]
	private sealed class _FastRestoreRoomDataWithRetry_d__307 : IEnumerator<object> // TypeDefIndex: 2056
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom roomManager; // 0x20
		public Action onDone; // 0x28
		public int userId; // 0x30
		public int selectedPetId; // 0x34
		private __c__DisplayClass307_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreRoomDataWithRetry_d__307(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001809DB580-0x00000001809DBC30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DBC30-0x00000001809DBC70
	}

	[CompilerGenerated]
	private sealed class _GiftFallbackPollLoop_d__219 : IEnumerator<object> // TypeDefIndex: 2057
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GiftFallbackPollLoop_d__219(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DBC70-0x00000001809DBEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DBEC0-0x00000001809DBF00
	}

	[CompilerGenerated]
	private sealed class _GiftPushRefreshAfter_d__217 : IEnumerator<object> // TypeDefIndex: 2058
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GiftPushRefreshAfter_d__217(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DBF00-0x00000001809DC180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DC180-0x00000001809DC1C0
	}

	[CompilerGenerated]
	private sealed class _LoadGiftDetailsCoroutine_d__228 : IEnumerator<object> // TypeDefIndex: 2059
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass228_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadGiftDetailsCoroutine_d__228(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809DC1C0-0x00000001809DC5A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DC5A0-0x00000001809DC5E0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__293 : IEnumerator<object> // TypeDefIndex: 2060
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass293_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__293(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809DC5E0-0x00000001809DD320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DD320-0x00000001809DD360
	}

	[CompilerGenerated]
	private sealed class _LoadUserData_d__341 : IEnumerator<object> // TypeDefIndex: 2061
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserData_d__341(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DD360-0x00000001809DD610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DD610-0x00000001809DD650
	}

	[CompilerGenerated]
	private sealed class _LoadingWatchdog_d__317 : IEnumerator<object> // TypeDefIndex: 2062
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadingWatchdog_d__317(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DD650-0x00000001809DD980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DD980-0x00000001809DD9C0
	}

	[CompilerGenerated]
	private sealed class _NoticeFallbackPollLoop_d__227 : IEnumerator<object> // TypeDefIndex: 2063
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _NoticeFallbackPollLoop_d__227(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DD9C0-0x00000001809DDC00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DDC00-0x00000001809DDC40
	}

	[CompilerGenerated]
	private sealed class _NoticePushRefreshAfter_d__223 : IEnumerator<object> // TypeDefIndex: 2064
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass223_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _NoticePushRefreshAfter_d__223(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001809DDC40-0x00000001809DE510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DE510-0x00000001809DE550
	}

	[CompilerGenerated]
	private sealed class _RefreshDebouncedCoroutine_d__276 : IEnumerator<object> // TypeDefIndex: 2065
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshDebouncedCoroutine_d__276(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DE550-0x00000001809DE7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DE7F0-0x00000001809DE830
	}

	[CompilerGenerated]
	private sealed class _RefreshUserCoroutine_d__277 : IEnumerator<object> // TypeDefIndex: 2066
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public bool silent; // 0x28
		private __c__DisplayClass277_0 __8__1; // 0x30
		public int userId; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshUserCoroutine_d__277(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001809DE830-0x00000001809DEC10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DEC10-0x00000001809DEC50
	}

	[CompilerGenerated]
	private sealed class _RequestPendingGiftsCoroutine_d__252 : IEnumerator<object> // TypeDefIndex: 2067
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass252_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30
		public Action<List<GiftDTO>> onDone; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RequestPendingGiftsCoroutine_d__252(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809DEC50-0x00000001809DF080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DF080-0x00000001809DF0C0
	}

	[CompilerGenerated]
	private sealed class _RestartGiftPulseNextFrame_d__232 : IEnumerator<object> // TypeDefIndex: 2068
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RestartGiftPulseNextFrame_d__232(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809DF0C0-0x00000001809DF2B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DF2B0-0x00000001809DF2F0
	}

	[CompilerGenerated]
	private sealed class _RestorePVPRoomWithLoading_d__295 : IEnumerator<object> // TypeDefIndex: 2069
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private CanvasGroup _pvpCG_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RestorePVPRoomWithLoading_d__295(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809DF2F0-0x00000001809DF990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809DF990-0x00000001809DF9D0
	}

	[CompilerGenerated]
	private sealed class _RestorePanelStateWithLoading_d__304 : IEnumerator<object> // TypeDefIndex: 2070
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RestorePanelStateWithLoading_d__304(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001809DF9D0-0x00000001809DFAE0
		private bool MoveNext(); // 0x00000001809DFAE0-0x00000001809E06A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E06A0-0x00000001809E06E0
	}

	[CompilerGenerated]
	private sealed class _ShakeNoticeIconUntilSeen_d__224 : IEnumerator<object> // TypeDefIndex: 2071
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public int uid; // 0x28
		private float _guard_5__2; // 0x2C
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShakeNoticeIconUntilSeen_d__224(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809E06E0-0x00000001809E0AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E0AF0-0x00000001809E0B30
	}

	[CompilerGenerated]
	private sealed class _ShowGiftDetailAfterAnimation_d__234 : IEnumerator<object> // TypeDefIndex: 2072
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowGiftDetailAfterAnimation_d__234(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809E0B30-0x00000001809E0D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E0D50-0x00000001809E0D90
	}

	[CompilerGenerated]
	private sealed class _ShowRemoteEventWhenReady_d__195 : IEnumerator<object> // TypeDefIndex: 2073
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass195_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowRemoteEventWhenReady_d__195(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001809E0D90-0x00000001809E1260
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E1260-0x00000001809E12A0
	}

	[CompilerGenerated]
	private sealed class _SweepOrphanLoadingAfterRestore_d__306 : IEnumerator<object> // TypeDefIndex: 2074
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SweepOrphanLoadingAfterRestore_d__306(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809E12A0-0x00000001809E16E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E16E0-0x00000001809E1720
	}

	[CompilerGenerated]
	private sealed class _WaitForPVPLoad_d__297 : IEnumerator<object> // TypeDefIndex: 2075
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP pvpManager; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForPVPLoad_d__297(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809E1720-0x00000001809E1A40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809E1A40-0x00000001809E1A80
	}

	// Constructors
	public ManagerQuangTruong(); // 0x00000001809D06B0-0x00000001809D0A10

	// Methods
	private void Awake(); // 0x00000001809AE060-0x00000001809AE5C0
	private void WireEnergyPurchaseButton(); // 0x00000001809AE5C0-0x00000001809AEC20
	private void OpenEnergyPurchasePopup(); // 0x00000001805F1C50-0x00000001805F1C60
	private void Start(); // 0x00000001809AEC20-0x00000001809B0C90
	[IteratorStateMachine(typeof(_ConsumeHomeDeepLink_d__126))]
	private IEnumerator ConsumeHomeDeepLink(); // 0x00000001809B0C90-0x00000001809B0D30
	private void LateUpdate(); // 0x00000001809B0D30-0x00000001809B1170
	private void CheckHubStuckDisabled(); // 0x00000001809B1170-0x00000001809B1340
	public void OpenEvent(); // 0x00000001809B1340-0x00000001809B14B0
	public void OpenEventFest(); // 0x00000001809B14B0-0x00000001809B1C90
	public void OpenUpdateCard(); // 0x00000001809B1C90-0x00000001809B1E00
	public void OpenThongBao(); // 0x00000001809B1E00-0x00000001809B1F80
	public void OpenThueTinh(); // 0x00000001809B1F80-0x00000001809B1F90
	public void OpenMiniGame(); // 0x00000001809B1F90-0x00000001809B2110
	public void OpenNapTichLuy(); // 0x00000001809B2110-0x00000001809B2280
	public void OpenNapSafia(); // 0x0000000180490530-0x0000000180490560
	public void OpenDoiMatKhau(); // 0x00000001809B2280-0x00000001809B22B0
	public void OpenBaoVeTaiKhoan(); // 0x00000001809B22B0-0x00000001809B22E0
	public void OpenTroGiup(); // 0x00000001809B22E0-0x00000001809B2310
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x00000001809B2310-0x00000001809B2340
	private void HandlePasswordChanged(); // 0x00000001809B2340-0x00000001809B23D0
	public void OpenOnlineGift(); // 0x00000001809B23D0-0x00000001809B2540
	private void WireOnlineGiftButton(); // 0x00000001809B2540-0x00000001809B2FE0
	public void OpenHuongDan(); // 0x00000001809B2FE0-0x00000001809B3150
	private void WireGuideButton(); // 0x00000001809B3150-0x00000001809B3870
	public void OpenFriend(); // 0x00000001809B3870-0x00000001809B39E0
	private void WireFriendButton(); // 0x00000001809B39E0-0x00000001809B4510
	public bool IsHubViewActive(); // 0x00000001809B4510-0x00000001809B4E90
	private void SetupDailyCheckIn(); // 0x00000001809B4E90-0x00000001809B5100
	public void OpenDailyCheckIn(); // 0x00000001809B5100-0x00000001809B5250
	public void OpenWorldChat(); // 0x00000001809B5250-0x00000001809B53F0
	private void LoadAudioSettings(); // 0x00000001809B53F0-0x00000001809B5430
	private void PlayBackgroundMusic(); // 0x00000001809B5430-0x00000001809B5870
	private void SetupButtonSounds(); // 0x00000001809B5870-0x00000001809B5AF0
	[IteratorStateMachine(typeof(_AttachButtonSoundsAsync_d__157))]
	private IEnumerator AttachButtonSoundsAsync(); // 0x00000001809B5AF0-0x00000001809B5B90
	public void StopBackgroundMusic(); // 0x00000001809B5B90-0x00000001809B5D50
	public void PauseBackgroundMusic(); // 0x00000001809B5D50-0x00000001809B5F10
	public void ResumeBackgroundMusic(); // 0x00000001809B5F10-0x00000001809B6450
	public void SetBGMVolume(float volume); // 0x00000001809B6450-0x00000001809B65D0
	public void FadeInBGM(float duration = 2f /* Metadata: 0x005F03F2 */); // 0x00000001809B65D0-0x00000001809B6840
	public void FadeOutBGM(float duration = 2f /* Metadata: 0x005F03F6 */, bool stopAfterFade = true /* Metadata: 0x005F03FA */); // 0x00000001809B6840-0x00000001809B6B60
	public void OpenWheelDay(); // 0x00000001809B6B60-0x00000001809B6B70
	private void OpenWheelTab(WheelKind kind); // 0x00000001809B6B70-0x00000001809B6D60
	public void OpenGachaPanel(); // 0x00000001809B6D60-0x00000001809B6F80
	public void OpenGalaxyWheel(); // 0x00000001809B6F80-0x00000001809B6F90
	public void OpenFirstPay(); // 0x00000001809B6F90-0x00000001809B7100
	private bool CheckLevelGate(int requiredLevel, string featureName); // 0x00000001809B7100-0x00000001809B7260
	public void OpenTower(); // 0x00000001809B7260-0x00000001809B72E0
	public void OpenTreasureWheel(); // 0x00000001809B72E0-0x00000001809B72F0
	public void OpenRechargeEvent(); // 0x00000001809B72F0-0x00000001809B7340
	public void OpenMidAutumn(); // 0x00000001809B7340-0x00000001809B7390
	public void OpenGuild(); // 0x00000001809B7390-0x00000001809B7410
	private void OpenPokyEventPanel(string panelKey); // 0x00000001809B7410-0x00000001809B7530
	private void WireGuildButton(); // 0x00000001809B7530-0x00000001809B7900
	private void WireShopAvatarButton(); // 0x00000001809B7900-0x00000001809B80E0
	private static void DisablePersistentClicks(Button button); // 0x00000001809B80E0-0x00000001809B8350
	private void WireFeatureButton(string buttonName, string prefabPath, UnityAction onClick); // 0x00000001809B8350-0x00000001809B8AB0
	private void OpenLazyPanel(string panelKey, Action<GameObject> onReady); // 0x00000001809B8AB0-0x00000001809B8D70
	[IteratorStateMachine(typeof(_ShowRemoteEventWhenReady_d__195))]
	private IEnumerator ShowRemoteEventWhenReady(); // 0x00000001809B8D70-0x00000001809B8E10
	private void HandleRemoteEventCta(RemoteEventItem ev); // 0x00000001809B8E10-0x00000001809B9BC0
	public void OpenTienHoa(); // 0x00000001809B9BC0-0x00000001809B9D60
	public void OpenMega(); // 0x00000001809B9D60-0x00000001809B9F00
	public void OpenQuest(); // 0x00000001809B9F00-0x00000001809BA070
	public void OpenVongQuay(); // 0x00000001809BA070-0x00000001809BA140
	private static UnityEngine.UI.Text FindStarText(Transform panelRoot, string gemName); // 0x00000001809BA140-0x00000001809BA390
	public void OpenGiftCode(); // 0x00000001809BA390-0x00000001809BA500
	public void OpenThuVien(); // 0x00000001809BA500-0x00000001809BA670
	public void OpenKhoPet(); // 0x00000001809BA670-0x00000001809BA7F0
	public void OpenXepHang(); // 0x00000001809BA7F0-0x00000001809BA960
	public void OpenInfoPlayer(long targetUserId = 0 /* Metadata: 0x005F03FB */); // 0x00000001809BA960-0x00000001809BAB80
	public void OpenChinhPhucPanel(); // 0x00000001809BAB80-0x00000001809BB1F0
	public void OpenShop(); // 0x00000001809BB1F0-0x00000001809BB360
	public void OpenShopAvatar(int category = 0 /* Metadata: 0x005F0403 */); // 0x00000001809BB360-0x00000001809BB490
	private void InitializeGiftBox(); // 0x00000001809BB490-0x00000001809BB950
	public void CheckForGifts(int userId); // 0x00000001809BB950-0x00000001809BBB90
	[IteratorStateMachine(typeof(_CheckGiftsCoroutine_d__212))]
	private IEnumerator CheckGiftsCoroutine(int userId); // 0x00000001809BBB90-0x00000001809BBC40
	private void OnGiftCountReceived(GiftCountResponse response, int userId); // 0x00000001809BBC40-0x00000001809BBF00
	private void HandleGiftPush(ChatMessageDTO m); // 0x00000001809BBF00-0x00000001809BC260
	private bool IsMatchBlockingHubUi(); // 0x00000001809BC260-0x00000001809BC2E0
	private void ApplyOptimisticGiftBadge(); // 0x00000001809BC2E0-0x00000001809BC3F0
	[IteratorStateMachine(typeof(_GiftPushRefreshAfter_d__217))]
	private IEnumerator GiftPushRefreshAfter(float delay); // 0x00000001809BC3F0-0x00000001809BC4B0
	[IteratorStateMachine(typeof(_AnnounceNewGiftWhenHubVisible_d__218))]
	private IEnumerator AnnounceNewGiftWhenHubVisible(); // 0x00000001809BC4B0-0x00000001809BC550
	[IteratorStateMachine(typeof(_GiftFallbackPollLoop_d__219))]
	private IEnumerator GiftFallbackPollLoop(); // 0x00000001809BC550-0x00000001809BC5F0
	[IteratorStateMachine(typeof(_AutoOpenNoticeAfterLogin_d__221))]
	private IEnumerator AutoOpenNoticeAfterLogin(); // 0x00000001809BC5F0-0x00000001809BC690
	private void HandleNoticePush(ChatMessageDTO m); // 0x00000001809BC690-0x00000001809BC840
	[IteratorStateMachine(typeof(_NoticePushRefreshAfter_d__223))]
	private IEnumerator NoticePushRefreshAfter(float delay); // 0x00000001809BC840-0x00000001809BC900
	[IteratorStateMachine(typeof(_ShakeNoticeIconUntilSeen_d__224))]
	private IEnumerator ShakeNoticeIconUntilSeen(int uid); // 0x00000001809BC900-0x00000001809BC9B0
	private void PlayNoticeShakeOnce(); // 0x00000001809BC9B0-0x00000001809BCCA0
	private void StopNoticeShake(); // 0x00000001809BCCA0-0x00000001809BCF60
	[IteratorStateMachine(typeof(_NoticeFallbackPollLoop_d__227))]
	private IEnumerator NoticeFallbackPollLoop(); // 0x00000001809BCF60-0x00000001809BD000
	[IteratorStateMachine(typeof(_LoadGiftDetailsCoroutine_d__228))]
	private IEnumerator LoadGiftDetailsCoroutine(int userId); // 0x00000001809BD000-0x00000001809BD0B0
	private void PlayGiftNotificationAnimation(); // 0x00000001809BD0B0-0x00000001809BD200
	private void StartGiftIdlePulse(); // 0x00000001809BD200-0x00000001809BD4E0
	private void PlayGiftArrivalFx(); // 0x00000001809BD4E0-0x00000001809BD9C0
	[IteratorStateMachine(typeof(_RestartGiftPulseNextFrame_d__232))]
	private IEnumerator RestartGiftPulseNextFrame(); // 0x00000001809BD9C0-0x00000001809BDA60
	public void ShowGiftBoxAnimation(GiftDTO gift); // 0x00000001809BDA60-0x00000001809BDDB0
	[IteratorStateMachine(typeof(_ShowGiftDetailAfterAnimation_d__234))]
	private IEnumerator ShowGiftDetailAfterAnimation(float delay); // 0x00000001809BDDB0-0x00000001809BDE70
	private void ShowGiftDetail(GiftDTO gift); // 0x00000001809BDE70-0x00000001809BE2B0
	private void DisplayRewards(GiftDTO gift); // 0x00000001809BE2B0-0x00000001809BFA10
	private void UpdateShardRewardUI(GameObject obj, ShardRewardItem shard); // 0x00000001809BFA10-0x00000001809BFC80
	private Image EnsurePieceOverlay(GameObject obj, Image mainImg); // 0x00000001809BFC80-0x00000001809C0410
	private void SetRewardVisual(GameObject obj, Sprite icon, string label, bool showPiece = false /* Metadata: 0x005F0404 */); // 0x00000001809C0410-0x00000001809C0CD0
	private Image FindRewardImage(GameObject obj, params string[] names); // 0x00000001809C0CD0-0x00000001809C10C0
	private UnityEngine.UI.Text FindRewardText(GameObject obj); // 0x00000001809C10C0-0x00000001809C1500
	private void ClearListReward(); // 0x00000001809C1500-0x00000001809C18F0
	private void UpdateRewardUI(GameObject rewardObj, int amount); // 0x00000001809C18F0-0x00000001809C1B40
	private void UpdatePetRewardUI(GameObject petObj, int petId, string petName); // 0x00000001809C1B40-0x00000001809C1EC0
	private void UpdateAVTRewardUI(GameObject petObj, int avtId); // 0x00000001809C1EC0-0x00000001809C22D0
	private void UpdateCardRewardUI(GameObject cardObj, int cardId, string cardName); // 0x00000001809C22D0-0x00000001809C2770
	private void UpdateStoneRewardUI(GameObject stoneObj, StoneRewardDTO stone); // 0x00000001809C2770-0x00000001809C2C70
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x00000001809C2C70-0x00000001809C3020
	public void RequestPendingGifts(Action<List<GiftDTO>> onDone); // 0x00000001809C3030-0x00000001809C3200
	[IteratorStateMachine(typeof(_RequestPendingGiftsCoroutine_d__252))]
	private IEnumerator RequestPendingGiftsCoroutine(int userId, Action<List<GiftDTO>> onDone); // 0x00000001809C3200-0x00000001809C3310
	public void ClaimGift(GiftDTO gift, Action<bool, GiftDTO> onDone); // 0x00000001809C3310-0x00000001809C35B0
	[IteratorStateMachine(typeof(_ClaimGiftCoroutine_d__258))]
	private IEnumerator ClaimGiftCoroutine(GiftDTO gift, int userId, Action<bool, GiftDTO> onDone); // 0x00000001809C3620-0x00000001809C37A0
	public void ClaimGiftsSequential(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x00000001809C37A0-0x00000001809C3A00
	[IteratorStateMachine(typeof(_ClaimGiftsSequentialCoroutine_d__260))]
	private IEnumerator ClaimGiftsSequentialCoroutine(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x00000001809C3A00-0x00000001809C3BD0
	private void ApplyGiftClaimed(GiftDTO source, GiftDTO claimedGift); // 0x00000001809C3BD0-0x00000001809C3F40
	private void UpdateGiftIconBadge(int count); // 0x00000001809C3F40-0x00000001809C4430
	public void ClaimCurrentGift(); // 0x00000001809C4430-0x00000001809C4650
	public void ShowClaimedExtras(GiftDTO gift); // 0x00000001809C4650-0x00000001809C4B90
	private void CloseGiftBoxWithAnimation(); // 0x00000001809C4B90-0x00000001809C4FE0
	public void CloseGiftBox(); // 0x00000001809C4FE0-0x00000001809C5240
	public void OnGiftIconClicked(); // 0x00000001809C5240-0x00000001809C5700
	public void RefreshUserInfo(bool silent = false /* Metadata: 0x005F0405 */); // 0x00000001809C5700-0x00000001809C5A50
	[IteratorStateMachine(typeof(_RefreshDebouncedCoroutine_d__276))]
	private IEnumerator RefreshDebouncedCoroutine(int userId); // 0x00000001809C5A50-0x00000001809C5B00
	[IteratorStateMachine(typeof(_RefreshUserCoroutine_d__277))]
	private IEnumerator RefreshUserCoroutine(int userId, bool silent); // 0x00000001809C5B00-0x00000001809C5BC0
	private void OnUserRefreshed(UserDTO user, bool silent = false /* Metadata: 0x005F0406 */); // 0x00000001809C5BC0-0x00000001809C6440
	private void ApplyWeaponBadge(UserDTO user); // 0x00000001809C6440-0x00000001809C6620
	public static string FormatVND(long amount); // 0x00000001809C6620-0x00000001809C6730
	private void OnRefreshError(string error, bool silent); // 0x00000001809C6730-0x00000001809C6810
	public void ShowPanelBoss(); // 0x00000001809C6810-0x00000001809C6CB0
	private void EnsureBossCoversHeader(); // 0x00000001809C6CB0-0x00000001809C7260
	private void ApplyHonorIconLegacyHeader(); // 0x00000001809C7260-0x00000001809C75E0
	private static bool IsHonorNode(string n); // 0x00000001809C75E0-0x00000001809C77F0
	private static Image FirstChildImage(Transform root, Transform skip); // 0x00000001809C77F0-0x00000001809C7BB0
	public void HidePanelBoss(); // 0x00000001809C7BB0-0x00000001809C7D00
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__293))]
	private IEnumerator LoadSceneAfterDelay(); // 0x00000001809C7D00-0x00000001809C7DA0
	[IteratorStateMachine(typeof(_DeferChinhPhucPreload_d__294))]
	private IEnumerator DeferChinhPhucPreload(); // 0x00000001809C7DA0-0x00000001809C7DE0
	[IteratorStateMachine(typeof(_RestorePVPRoomWithLoading_d__295))]
	private IEnumerator RestorePVPRoomWithLoading(); // 0x00000001809C7DE0-0x00000001809C7E80
	private CanvasGroup OpenPVPRoomHidden(); // 0x00000001809C7E80-0x00000001809C8410
	[IteratorStateMachine(typeof(_WaitForPVPLoad_d__297))]
	private IEnumerator WaitForPVPLoad(ManagerRoomPVP pvpManager, Action onDone); // 0x00000001809C8410-0x00000001809C8520
	public void OpenPVPPanel(string roomName); // 0x00000001809C8520-0x00000001809C89E0
	public void HidePVPPanel(); // 0x00000001809C89E0-0x00000001809C8E50
	public void ExitPVPToHub(); // 0x00000001809C8E50-0x00000001809C9710
	public void OnPVPMatchSceneUnloaded(); // 0x00000001809C9710-0x00000001809C9A30
	public void ReturnToPVPLobbyFromRoom(); // 0x00000001809C9A30-0x00000001809CA260
	public void ShowPVPRoomFromLobby(); // 0x00000001809CA260-0x00000001809CA890
	[IteratorStateMachine(typeof(_RestorePanelStateWithLoading_d__304))]
	private IEnumerator RestorePanelStateWithLoading(); // 0x00000001809CA890-0x00000001809CA930
	[IteratorStateMachine(typeof(_FastRestoreCoopRoom_d__305))]
	private IEnumerator FastRestoreCoopRoom(); // 0x00000001809CA930-0x00000001809CA9D0
	[IteratorStateMachine(typeof(_SweepOrphanLoadingAfterRestore_d__306))]
	private IEnumerator SweepOrphanLoadingAfterRestore(); // 0x00000001809CA9D0-0x00000001809CAA10
	[IteratorStateMachine(typeof(_FastRestoreRoomDataWithRetry_d__307))]
	private IEnumerator FastRestoreRoomDataWithRetry(ManagerRoom roomManager, int userId, int selectedPetId, Action onDone); // 0x00000001809CAA10-0x00000001809CAB30
	private void StartHubBackgroundRefresh(int userId); // 0x00000001809CAB30-0x00000001809CAD10
	private int ResolveRoomPanelIndex(ManagerChinhPhuc chinhPhucManager); // 0x00000001809CAD10-0x00000001809CB080
	public void NotifyReturnFromAdditiveMatchPVP(); // 0x00000001809CB080-0x00000001809CB170
	[IteratorStateMachine(typeof(_FastRestorePVPRoom_d__311))]
	private IEnumerator FastRestorePVPRoom(); // 0x00000001809CB170-0x00000001809CB210
	[IteratorStateMachine(typeof(_FastRestorePVPLobby_d__312))]
	private IEnumerator FastRestorePVPLobby(); // 0x00000001809CB210-0x00000001809CB2B0
	private void SetupLoadingPanel(bool useLoadingRoom = false /* Metadata: 0x005F0407 */); // 0x00000001809CB2B0-0x00000001809CC0D0
	[IteratorStateMachine(typeof(_LoadingWatchdog_d__317))]
	private IEnumerator LoadingWatchdog(); // 0x00000001809CC0D0-0x00000001809CC170
	private GameObject CreateFallbackLoadingPanel(); // 0x00000001809CC170-0x00000001809CC660
	private void KeepLoadingOnTop(); // 0x00000001809CC660-0x00000001809CC970
	private CanvasGroup OpenChinhPhucHidden(); // 0x00000001809CC970-0x00000001809CCD20
	private CanvasGroup OpenRoomHidden(ManagerRoom roomManager); // 0x00000001809CCD20-0x00000001809CD0C0
	private void HideLoadingPanel(); // 0x00000001809CD0C0-0x00000001809CD360
	private void UpdateMedalImage(int userLevel, int rankPvp = 0 /* Metadata: 0x005F0408 */); // 0x00000001809CD360-0x00000001809CD910
	private int GetMedalLevel(int userLevel); // 0x00000001809CD910-0x00000001809CD9A0
	private void OnUserReceived(UserDTO user); // 0x00000001809CD9A0-0x00000001809CDE70
	private void ApplyUserUi(UserDTO user); // 0x00000001809CDE70-0x00000001809CE770
	private void ApplyExpBar(float expPercent); // 0x00000001809CE770-0x00000001809CE8B0
	private void SetupImgLevel(int level, Image imgLv); // 0x00000001809CE8B0-0x00000001809CE9F0
	private void ApplyHubAvatar(UserDTO user); // 0x00000001809CE9F0-0x00000001809CEC50
	private void HandleSelfAvatarChanged(); // 0x00000001809CEC50-0x00000001809CEDD0
	private void OnDestroy(); // 0x00000001809CEDD0-0x00000001809CF990
	public void OnHubSuspend(); // 0x000000018028A320-0x000000018028A330
	public void OnHubResume(); // 0x00000001809CF990-0x00000001809CFAF0
	public void UpdateWheelFlag(int wheelCount); // 0x00000001809CFAF0-0x00000001809CFD10
	public void UpdateStarUI(int starWhite, int starBlue, int starRed); // 0x00000001809CFD10-0x00000001809D0230
	public void UpdateGoldUI(int gold); // 0x00000001809D0230-0x00000001809D0360
	public void UpdateSafiaUI(int safia); // 0x00000001809D0360-0x00000001809D0490
	private void OnError(string error); // 0x00000001809D0490-0x00000001809D0510
	public void ReloadUserInfo(); // 0x00000001809D0510-0x00000001809D0600
	[IteratorStateMachine(typeof(_LoadUserData_d__341))]
	private IEnumerator LoadUserData(int userId); // 0x00000001809D0600-0x00000001809D06B0
	[CompilerGenerated]
	private void _Start_b__125_1(); // 0x00000001809D0A10-0x00000001809D0A20
	[CompilerGenerated]
	private void _FadeInBGM_b__162_0(float val); // 0x00000001809D0A20-0x00000001809D0B80
	[CompilerGenerated]
	private void _WireShopAvatarButton_b__190_0(); // 0x00000001809D0B80-0x00000001809D0B90
	[CompilerGenerated]
	private void _OpenVongQuay_b__200_0(GameObject panel); // 0x00000001809D0B90-0x00000001809D1100
	[CompilerGenerated]
	private void _PlayGiftArrivalFx_b__231_0(); // 0x00000001809D1100-0x00000001809D11B0
	[CompilerGenerated]
	private void _ClaimCurrentGift_b__263_0(bool ok, GiftDTO claimed); // 0x00000001809D11B0-0x00000001809D1410
	[CompilerGenerated]
	private void _FastRestorePVPLobby_b__312_0(UserDTO user); // 0x00000001809D1410-0x00000001809D14C0
	[CompilerGenerated]
	private void _LoadUserData_b__341_0(UserDTO user); // 0x00000001809D1410-0x00000001809D14C0
}

