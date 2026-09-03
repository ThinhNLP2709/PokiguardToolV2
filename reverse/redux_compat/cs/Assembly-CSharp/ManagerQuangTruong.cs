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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerQuangTruong : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1413
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
	[Header("GiftBox - Optional")]
	public GameObject giftBoxIcon; // 0x238
	public UnityEngine.UI.Text txtGiftCount; // 0x240
	public GameObject giftBoxAnimation; // 0x248
	public Animator giftBoxAnimator; // 0x250
	private bool isClaimingGift; // 0x258
	private List<GiftDTO> pendingGifts; // 0x260
	private GiftDTO currentGift; // 0x268
	private Coroutine _giftPushRefreshCo; // 0x270
	private Coroutine _giftToastCo; // 0x278
	private int _giftCountKnown; // 0x280
	private int _giftOptimisticBump; // 0x284
	private bool _giftToastQueued; // 0x288
	private int _giftCountAtPush; // 0x28C
	private Coroutine _noticePushRefreshCo; // 0x290
	private Coroutine _noticeFxCo; // 0x298
	private long _noticeMaxIdKnown; // 0x2A0
	[Header("Shop Button")]
	public Button btnShop; // 0x2A8
	[Header("Chinh Phuc Panel")]
	public GameObject panelChinhPhuc; // 0x2B0
	public Button btnChinhPhuc; // 0x2B8
	public GameObject loadingPanel; // 0x2C0
	[Tooltip("Panel loading ri\u00EAng cho flow quay v\u1EC1 room t\u1EEB tr\u1EADn (Match \u2192 QuangTruong). N\u1EBFu g\u00E1n, s\u1EBD d\u00F9ng panel n\u00E0y thay cho loadingPanel khi return t\u1EEB match.")]
	public GameObject loadingRoom; // 0x2C8
	private int ruby; // 0x2D0
	[Header("Equipment")]
	public Button btnEquipment; // 0x2D8
	public Image HC; // 0x2E0
	public Image imgAvatar; // 0x2E8
	public WeaponBadgeUI imgWeaponBadge; // 0x2F0
	[Header("Background Music")]
	public AudioSource bgmAudioSource; // 0x2F8
	public AudioClip bgmClip; // 0x300
	[Range(0f, 1f)]
	public float bgmVolume; // 0x308
	public bool loopBGM; // 0x30C
	[Header("Sound Effects")]
	public AudioClip clickSound; // 0x310
	[Range(0f, 1f)]
	public float clickVolume; // 0x318
	[Header("World Chat")]
	public Button btnWorldChat; // 0x320
	[Header("Event")]
	public Button btnEvent; // 0x328
	public Button btnFirstPay; // 0x330
	public GameObject eventBadge; // 0x338
	public Button btnEventFest; // 0x340
	[Header("Update Card")]
	public Button btnUpdateCard; // 0x348
	[Header("Mini Game")]
	public Button btnMiniGame; // 0x350
	[Header("Thong Bao")]
	public Button btnThongBao; // 0x358
	[Header("Th\u1EE9c T\u1EC9nh Mega")]
	public Button btnThueTinh; // 0x360
	[Header("H\u1ED9p qu\u00E0 online (2026-07-29)")]
	[Tooltip("N\u00FAt m\u1EDF h\u1ED9p qu\u00E0 online. B\u1ECF tr\u1ED1ng \u2192 t\u1EF1 t\u00ECm n\u00FAt t\u00EAn btnOnlineGift/btnHopQua, kh\u00F4ng c\u00F3 n\u1EEFa th\u00EC instantiate prefab Resources/Prefabs/UI/OnlineGiftButton.")]
	public Button btnOnlineGift; // 0x368
	[Tooltip("Panel/popup ph\u1EE5 khi\u1EBFn UI ch\u1EC9-hub (n\u00FAt h\u1ED9p qu\u00E0 online) ph\u1EA3i \u1EA9n. D\u00F9ng \u0111\u1EC3 m\u1EDF r\u1ED9ng IsHubViewActive() m\u00E0 kh\u00F4ng c\u1EA7n s\u1EEDa code khi th\u00EAm panel scene m\u1EDBi.")]
	public GameObject[] hubOnlyBlockers; // 0x370
	public GameObject PanelMasterLobby; // 0x378
	public GameObject BtnBackLobby_PVP; // 0x380
	public GameObject BtnBackQuangTruong_PVP; // 0x388
	private float _hubStuckCheckAt; // 0x390
	private bool _hubStuckReported; // 0x394
	public const string PANEL_TOWER = "PanelTower"; // Metadata: 0x0064D6A2
	public const string PANEL_TREASURE_WHEEL = "PanelTreasureWheel"; // Metadata: 0x0064D6AD
	public const string PANEL_RECHARGE_EVENT = "PanelRechargeEvent"; // Metadata: 0x0064D6C0
	public const string PANEL_MID_AUTUMN = "PanelMidAutumn"; // Metadata: 0x0064D6D3
	private const int LEVEL_REQUIRED_TOWER = 20; // Metadata: 0x0064D6E2
	private const int LEVEL_REQUIRED_WORLD_BOSS = 10; // Metadata: 0x0064D6E3
	private const int LEVEL_REQUIRED_EVOLUTION = 15; // Metadata: 0x0064D6E4
	private const int LEVEL_REQUIRED_AWAKENING = 25; // Metadata: 0x0064D6E5
	private const float REMOTE_EVENT_DELAY = 2.5f; // Metadata: 0x0064D6E6
	private const float NOTICE_AUTO_OPEN_DELAY = 1.2f; // Metadata: 0x0064D6EA
	[CompilerGenerated]
	private string _LastGiftClaimError_k__BackingField; // 0x398
	private ManagerBoss _managerBoss; // 0x3A0
	private GameObject _activeLoadingTarget; // 0x3A8
	private Coroutine _loadingWatchdog; // 0x3B0
	private const float LOADING_WATCHDOG_TIMEOUT = 20f; // Metadata: 0x0064D6EE
	internal int ChienTich; // 0x3B8

	// Properties
	public IList<GiftDTO> PendingGifts { get; } // 0x0000000180548570-0x0000000180548580 
	public string LastGiftClaimError { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180548560-0x0000000180548570 0x0000000180548580-0x00000001805485A0

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1414
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static UnityAction<bool> __9__117_0; // 0x08
		public static Action<GameObject> __9__123_0; // 0x10
		public static Action<GameObject> __9__124_0; // 0x18
		public static Action<GameObject> __9__125_0; // 0x20
		public static Action<GameObject> __9__126_0; // 0x28
		public static Action<GameObject> __9__128_0; // 0x30
		public static Action<GameObject> __9__129_0; // 0x38
		public static Action<GameObject> __9__134_0; // 0x40
		public static Action<GameObject> __9__136_0; // 0x48
		public static Action<GameObject> __9__138_0; // 0x50
		public static Action<GameObject> __9__155_0; // 0x58
		public static Action<GameObject> __9__156_0; // 0x60
		public static Action<GameObject> __9__158_0; // 0x68
		public static Action<GameObject> __9__178_0; // 0x70
		public static Action<GameObject> __9__179_0; // 0x78
		public static Action<GameObject> __9__180_0; // 0x80
		public static Action<GameObject> __9__183_0; // 0x88
		public static Action<GameObject> __9__184_0; // 0x90
		public static Action<GameObject> __9__186_0; // 0x98
		public static Action<GameObject> __9__187_0; // 0xA0
		public static Action<GameObject> __9__189_0; // 0xA8
		public static Action<string> __9__203_1; // 0xB0
		public static Action<string> __9__208_1; // 0xB8
		public static Action<string> __9__232_1; // 0xC0
		public static Action<GameObject> __9__247_0; // 0xC8
		public static Action<string> __9__257_1; // 0xD0
		public static Action<string> __9__275_1; // 0xD8
		public static Action<string> __9__302_1; // 0xE0

		// Constructors
		static __c(); // 0x0000000180562E10-0x0000000180562E80
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Start_b__117_0(bool busy); // 0x0000000180561A50-0x0000000180561AB0
		internal void _OpenEvent_b__123_0(GameObject panel); // 0x0000000180560EC0-0x0000000180560F20
		internal void _OpenEventFest_b__124_0(GameObject panel); // 0x0000000180560E60-0x0000000180560EC0
		internal void _OpenUpdateCard_b__125_0(GameObject panel); // 0x00000001805617E0-0x0000000180561840
		internal void _OpenThongBao_b__126_0(GameObject panel); // 0x00000001805615E0-0x0000000180561640
		internal void _OpenMiniGame_b__128_0(GameObject panel); // 0x0000000180561320-0x0000000180561380
		internal void _OpenNapTichLuy_b__129_0(GameObject panel); // 0x0000000180561380-0x00000001805613E0
		internal void _OpenOnlineGift_b__134_0(GameObject panel); // 0x00000001805613E0-0x0000000180561440
		internal void _OpenHuongDan_b__136_0(GameObject panel); // 0x0000000180561180-0x0000000180561250
		internal void _OpenFriend_b__138_0(GameObject panel); // 0x0000000180560FF0-0x0000000180561050
		internal void _OpenWheelTab_b__155_0(GameObject panel); // 0x0000000180561840-0x0000000180561910
		internal void _OpenGachaPanel_b__156_0(GameObject panel); // 0x0000000180561050-0x00000001805610B0
		internal void _OpenFirstPay_b__158_0(GameObject panel); // 0x0000000180560F20-0x0000000180560FF0
		internal void _OpenTienHoa_b__178_0(GameObject panel); // 0x0000000180561710-0x00000001805617E0
		internal void _OpenMega_b__179_0(GameObject panel); // 0x0000000180561250-0x0000000180561320
		internal void _OpenQuest_b__180_0(GameObject panel); // 0x0000000180561440-0x0000000180561510
		internal void _OpenGiftCode_b__183_0(GameObject panel); // 0x00000001805610B0-0x0000000180561180
		internal void _OpenThuVien_b__184_0(GameObject panel); // 0x0000000180561640-0x0000000180561710
		internal void _OpenXepHang_b__186_0(GameObject panel); // 0x0000000180561910-0x00000001805619E0
		internal void _OpenEquipment_b__187_0(GameObject panel); // 0x0000000180560D90-0x0000000180560E60
		internal void _OpenShop_b__189_0(GameObject panel); // 0x0000000180561510-0x00000001805615E0
		internal void _NoticePushRefreshAfter_b__203_1(string err); // 0x00000001802E76C0-0x00000001802E76D0
		internal void _LoadGiftDetailsCoroutine_b__208_1(string error); // 0x0000000180560B00-0x0000000180560B70
		internal void _RequestPendingGiftsCoroutine_b__232_1(string error); // 0x00000001805619E0-0x0000000180561A50
		internal void _OnGiftIconClicked_b__247_0(GameObject panel); // 0x0000000180560CC0-0x0000000180560D90
		internal void _LoadSceneAfterDelay_b__257_1(string e); // 0x0000000180560BE0-0x0000000180560C50
		internal void _FastRestorePVPLobby_b__275_1(string err); // 0x0000000180560A90-0x0000000180560B00
		internal void _LoadUserData_b__302_1(string error); // 0x0000000180560C50-0x0000000180560CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass153_0 // TypeDefIndex: 1415
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool stopAfterFade; // 0x18

		// Constructors
		public __c__DisplayClass153_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FadeOutBGM_b__0(float val); // 0x0000000180561D70-0x0000000180561E10
		internal void _FadeOutBGM_b__1(); // 0x0000000180561E10-0x0000000180561EB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass172_0 // TypeDefIndex: 1416
	{
		// Fields
		public string panelKey; // 0x10

		// Constructors
		public __c__DisplayClass172_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OpenPokyEventPanel_b__0(GameObject panel); // 0x0000000180561EB0-0x0000000180561F90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass174_0 // TypeDefIndex: 1417
	{
		// Fields
		public string panelKey; // 0x10
		public Action<GameObject> onReady; // 0x18

		// Constructors
		public __c__DisplayClass174_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OpenLazyPanel_b__0(GameObject panel); // 0x0000000180561F90-0x0000000180562080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass176_0 // TypeDefIndex: 1418
	{
		// Fields
		public RemoteEventItem ev; // 0x10
		public ManagerQuangTruong __4__this; // 0x18

		// Constructors
		public __c__DisplayClass176_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShowRemoteEventWhenReady_b__0(GameObject panel); // 0x0000000180562080-0x00000001805621C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass185_0 // TypeDefIndex: 1419
	{
		// Fields
		public UIPanelManager pm; // 0x10

		// Constructors
		public __c__DisplayClass185_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OpenKhoPet_b__0(GameObject panel); // 0x00000001805621C0-0x0000000180562380
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass192_0 // TypeDefIndex: 1420
	{
		// Fields
		public bool apiCompleted; // 0x10
		public GiftCountResponse responseData; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass192_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckGiftsCoroutine_b__0(GiftCountResponse response); // 0x00000001802FACB0-0x00000001802FACD0
		internal void _CheckGiftsCoroutine_b__1(string error); // 0x0000000180562380-0x0000000180562420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass203_0 // TypeDefIndex: 1421
	{
		// Fields
		public ManagerThongBao.ThongBaoResponse data; // 0x10

		// Constructors
		public __c__DisplayClass203_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _NoticePushRefreshAfter_b__0(ManagerThongBao.ThongBaoResponse resp); // 0x00000001803780D0-0x00000001803780E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass208_0 // TypeDefIndex: 1422
	{
		// Fields
		public List<GiftDTO> giftsData; // 0x10

		// Constructors
		public __c__DisplayClass208_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadGiftDetailsCoroutine_b__0(List<GiftDTO> gifts); // 0x00000001803780D0-0x00000001803780E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass232_0 // TypeDefIndex: 1423
	{
		// Fields
		public List<GiftDTO> data; // 0x10

		// Constructors
		public __c__DisplayClass232_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestPendingGiftsCoroutine_b__0(List<GiftDTO> gifts); // 0x00000001803780D0-0x00000001803780E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass238_0 // TypeDefIndex: 1424
	{
		// Fields
		public bool ok; // 0x10
		public GiftDTO result; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Constructors
		public __c__DisplayClass238_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ClaimGiftCoroutine_b__0(GiftDTO g); // 0x00000001802FACB0-0x00000001802FACD0
		internal void _ClaimGiftCoroutine_b__1(string e); // 0x0000000180562420-0x00000001805624C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass240_0 // TypeDefIndex: 1425
	{
		// Fields
		public bool done; // 0x10
		public bool good; // 0x11
		public GiftDTO res; // 0x18

		// Constructors
		public __c__DisplayClass240_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ClaimGiftsSequentialCoroutine_b__0(bool s, GiftDTO r); // 0x00000001805624C0-0x00000001805624E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass245_0 // TypeDefIndex: 1426
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public CanvasGroup canvasGroup; // 0x18

		// Constructors
		public __c__DisplayClass245_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CloseGiftBoxWithAnimation_b__0(); // 0x00000001805624E0-0x0000000180562570
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass249_0 // TypeDefIndex: 1427
	{
		// Fields
		public ManagerQuangTruong __4__this; // 0x10
		public bool silent; // 0x18

		// Constructors
		public __c__DisplayClass249_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RefreshUserCoroutine_b__0(UserDTO user); // 0x0000000180562570-0x00000001805625A0
		internal void _RefreshUserCoroutine_b__1(string error); // 0x00000001805625A0-0x00000001805625D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass257_0 // TypeDefIndex: 1428
	{
		// Fields
		public bool hubLoaded; // 0x10

		// Constructors
		public __c__DisplayClass257_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadSceneAfterDelay_b__0(); // 0x000000018030F220-0x000000018030F230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass258_0 // TypeDefIndex: 1429
	{
		// Fields
		public bool pvpLoaded; // 0x10

		// Constructors
		public __c__DisplayClass258_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RestorePVPRoomWithLoading_b__0(); // 0x000000018030F220-0x000000018030F230
		internal bool _RestorePVPRoomWithLoading_b__1(); // 0x00000001805625D0-0x00000001805625E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass267_0 // TypeDefIndex: 1430
	{
		// Fields
		public bool chinhPhucLoaded; // 0x10

		// Constructors
		public __c__DisplayClass267_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RestorePanelStateWithLoading_b__0(); // 0x000000018030F220-0x000000018030F230
		internal bool _RestorePanelStateWithLoading_b__1(); // 0x00000001805625D0-0x00000001805625E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass268_0 // TypeDefIndex: 1431
	{
		// Fields
		public bool chinhPhucDone; // 0x10
		public ManagerRoom roomManager; // 0x18
		public bool userDone; // 0x20
		public bool roomDone; // 0x21

		// Constructors
		public __c__DisplayClass268_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FastRestoreCoopRoom_b__0(); // 0x000000018030F220-0x000000018030F230
		internal void _FastRestoreCoopRoom_b__1(UserDTO user); // 0x00000001805625E0-0x0000000180562650
		internal void _FastRestoreCoopRoom_b__2(string err); // 0x0000000180562650-0x00000001805626D0
		internal void _FastRestoreCoopRoom_b__3(); // 0x00000001805626D0-0x00000001805626E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass270_0 // TypeDefIndex: 1432
	{
		// Fields
		public ManagerRoom roomManager; // 0x10
		public bool roomLoaded; // 0x18
		public int retry; // 0x1C
		public Action<RoomDTO> __9__0; // 0x20
		public Action<string> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass270_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FastRestoreRoomDataWithRetry_b__0(RoomDTO room); // 0x00000001805626E0-0x00000001805627A0
		internal void _FastRestoreRoomDataWithRetry_b__1(string err); // 0x00000001805627A0-0x0000000180562840
	}

	[CompilerGenerated]
	private sealed class _AnnounceNewGiftWhenHubVisible_d__198 : IEnumerator<object> // TypeDefIndex: 1433
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _guard_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnnounceNewGiftWhenHubVisible_d__198(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180558210-0x0000000180558420
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180558420-0x0000000180558460
	}

	[CompilerGenerated]
	private sealed class _AttachButtonSoundsAsync_d__147 : IEnumerator<object> // TypeDefIndex: 1434
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private Button[] _allButtons_5__2; // 0x28
		private int _count_5__3; // 0x30
		private int _i_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AttachButtonSoundsAsync_d__147(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180558460-0x0000000180558630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180558630-0x0000000180558670
	}

	[CompilerGenerated]
	private sealed class _AutoOpenNoticeAfterLogin_d__201 : IEnumerator<object> // TypeDefIndex: 1435
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private float _waited_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoOpenNoticeAfterLogin_d__201(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180558670-0x0000000180558B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180558B40-0x0000000180558B80
	}

	[CompilerGenerated]
	private sealed class _CheckGiftsCoroutine_d__192 : IEnumerator<object> // TypeDefIndex: 1436
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass192_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckGiftsCoroutine_d__192(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180558B80-0x0000000180558E10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180558E10-0x0000000180558E50
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftCoroutine_d__238 : IEnumerator<object> // TypeDefIndex: 1437
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public GiftDTO gift; // 0x28
		public int userId; // 0x30
		private __c__DisplayClass238_0 __8__1; // 0x38
		public Action<bool, GiftDTO> onDone; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftCoroutine_d__238(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180558E50-0x00000001805590D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805590D0-0x0000000180559110
	}

	[CompilerGenerated]
	private sealed class _ClaimGiftsSequentialCoroutine_d__240 : IEnumerator<object> // TypeDefIndex: 1438
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<GiftDTO> gifts; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass240_0 __8__1; // 0x30
		public Action<GiftDTO> onEach; // 0x38
		public Action<int, int> onDone; // 0x40
		private int _ok_5__2; // 0x48
		private int _fail_5__3; // 0x4C
		private int _i_5__4; // 0x50
		private GiftDTO _g_5__5; // 0x58
		private float _guard_5__6; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimGiftsSequentialCoroutine_d__240(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180559450-0x0000000180559490
		private bool MoveNext(); // 0x0000000180559110-0x0000000180559410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180559410-0x0000000180559450
	}

	[CompilerGenerated]
	private sealed class _ConsumeHomeDeepLink_d__118 : IEnumerator<object> // TypeDefIndex: 1439
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private string _key_5__2; // 0x28
		private float _waited_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeHomeDeepLink_d__118(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805595F0-0x000000018055A3F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055A3F0-0x000000018055A430
	}

	[CompilerGenerated]
	private sealed class _FastRestoreCoopRoom_d__268 : IEnumerator<object> // TypeDefIndex: 1440
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass268_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30
		private int _selectedPetId_5__3; // 0x34
		private CanvasGroup _chinhPhucCG_5__4; // 0x38
		private ManagerChinhPhuc _chinhPhucManager_5__5; // 0x40
		private int _panelIndex_5__6; // 0x48
		private bool _petsDone_5__7; // 0x4C
		private float _waitTimeout_5__8; // 0x50
		private float _waitElapsed_5__9; // 0x54
		private float _keepTopTimer_5__10; // 0x58
		private int _i_5__11; // 0x5C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreCoopRoom_d__268(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804E7960-0x00000001804E79B0
		private bool MoveNext(); // 0x000000018055A760-0x000000018055B880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055B880-0x000000018055B8C0
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPLobby_d__275 : IEnumerator<object> // TypeDefIndex: 1441
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPLobby_d__275(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055B8C0-0x000000018055BE40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055BE40-0x000000018055BE80
	}

	[CompilerGenerated]
	private sealed class _FastRestorePVPRoom_d__274 : IEnumerator<object> // TypeDefIndex: 1442
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private ManagerRoomPVP _pvpManager_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FastRestorePVPRoom_d__274(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055BE80-0x000000018055C650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055C650-0x000000018055C690
	}

	[CompilerGenerated]
	private sealed class _FastRestoreRoomDataWithRetry_d__270 : IEnumerator<object> // TypeDefIndex: 1443
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoom roomManager; // 0x20
		public int userId; // 0x28
		public int selectedPetId; // 0x2C
		private __c__DisplayClass270_0 __8__1; // 0x30
		public Action onDone; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FastRestoreRoomDataWithRetry_d__270(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018055C690-0x000000018055C9F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055C9F0-0x000000018055CA30
	}

	[CompilerGenerated]
	private sealed class _GiftFallbackPollLoop_d__199 : IEnumerator<object> // TypeDefIndex: 1444
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GiftFallbackPollLoop_d__199(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055CA30-0x000000018055CBC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055CBC0-0x000000018055CC00
	}

	[CompilerGenerated]
	private sealed class _GiftPushRefreshAfter_d__197 : IEnumerator<object> // TypeDefIndex: 1445
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GiftPushRefreshAfter_d__197(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055CC00-0x000000018055CDA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055CDA0-0x000000018055CDE0
	}

	[CompilerGenerated]
	private sealed class _LoadGiftDetailsCoroutine_d__208 : IEnumerator<object> // TypeDefIndex: 1446
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass208_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadGiftDetailsCoroutine_d__208(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055CDE0-0x000000018055D090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055D090-0x000000018055D0D0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__257 : IEnumerator<object> // TypeDefIndex: 1447
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass257_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__257(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055D0D0-0x000000018055D8F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055D8F0-0x000000018055D930
	}

	[CompilerGenerated]
	private sealed class _LoadUserData_d__302 : IEnumerator<object> // TypeDefIndex: 1448
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserData_d__302(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055D930-0x000000018055DB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055DB20-0x000000018055DB60
	}

	[CompilerGenerated]
	private sealed class _LoadingWatchdog_d__280 : IEnumerator<object> // TypeDefIndex: 1449
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadingWatchdog_d__280(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055DB60-0x000000018055DD10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055DD10-0x000000018055DD50
	}

	[CompilerGenerated]
	private sealed class _NoticeFallbackPollLoop_d__207 : IEnumerator<object> // TypeDefIndex: 1450
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _NoticeFallbackPollLoop_d__207(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055DD50-0x000000018055DEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055DEE0-0x000000018055DF20
	}

	[CompilerGenerated]
	private sealed class _NoticePushRefreshAfter_d__203 : IEnumerator<object> // TypeDefIndex: 1451
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28
		private __c__DisplayClass203_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _NoticePushRefreshAfter_d__203(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018055DF20-0x000000018055E4A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055E4A0-0x000000018055E4E0
	}

	[CompilerGenerated]
	private sealed class _RefreshUserCoroutine_d__249 : IEnumerator<object> // TypeDefIndex: 1452
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public bool silent; // 0x28
		public int userId; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshUserCoroutine_d__249(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055E4E0-0x000000018055E6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055E6A0-0x000000018055E6E0
	}

	[CompilerGenerated]
	private sealed class _RequestPendingGiftsCoroutine_d__232 : IEnumerator<object> // TypeDefIndex: 1453
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass232_0 __8__1; // 0x28
		public ManagerQuangTruong __4__this; // 0x30
		public Action<List<GiftDTO>> onDone; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestPendingGiftsCoroutine_d__232(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055EF70-0x000000018055F250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055F250-0x000000018055F290
	}

	[CompilerGenerated]
	private sealed class _RestartGiftPulseNextFrame_d__212 : IEnumerator<object> // TypeDefIndex: 1454
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RestartGiftPulseNextFrame_d__212(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018055F290-0x000000018055F370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055F370-0x000000018055F3B0
	}

	[CompilerGenerated]
	private sealed class _RestorePVPRoomWithLoading_d__258 : IEnumerator<object> // TypeDefIndex: 1455
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private CanvasGroup _pvpCG_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RestorePVPRoomWithLoading_d__258(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018055F3B0-0x000000018055F7D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055F7D0-0x000000018055F810
	}

	[CompilerGenerated]
	private sealed class _RestorePanelStateWithLoading_d__267 : IEnumerator<object> // TypeDefIndex: 1456
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RestorePanelStateWithLoading_d__267(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180560060-0x00000001805600B0
		private bool MoveNext(); // 0x000000018055F810-0x0000000180560020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180560020-0x0000000180560060
	}

	[CompilerGenerated]
	private sealed class _ShakeNoticeIconUntilSeen_d__204 : IEnumerator<object> // TypeDefIndex: 1457
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		public int uid; // 0x28
		private float _guard_5__2; // 0x2C
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShakeNoticeIconUntilSeen_d__204(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805600B0-0x0000000180560320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180560320-0x0000000180560360
	}

	[CompilerGenerated]
	private sealed class _ShowGiftDetailAfterAnimation_d__214 : IEnumerator<object> // TypeDefIndex: 1458
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerQuangTruong __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowGiftDetailAfterAnimation_d__214(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180560360-0x0000000180560470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180560470-0x00000001805604B0
	}

	[CompilerGenerated]
	private sealed class _ShowRemoteEventWhenReady_d__176 : IEnumerator<object> // TypeDefIndex: 1459
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuangTruong __4__this; // 0x20
		private __c__DisplayClass176_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowRemoteEventWhenReady_d__176(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805604B0-0x0000000180560780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180560780-0x00000001805607C0
	}

	[CompilerGenerated]
	private sealed class _SweepOrphanLoadingAfterRestore_d__269 : IEnumerator<object> // TypeDefIndex: 1460
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SweepOrphanLoadingAfterRestore_d__269(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805607C0-0x0000000180560A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180560A50-0x0000000180560A90
	}

	[CompilerGenerated]
	private sealed class _WaitForPVPLoad_d__260 : IEnumerator<object> // TypeDefIndex: 1461
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRoomPVP pvpManager; // 0x20
		public Action onDone; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForPVPLoad_d__260(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180562E80-0x0000000180563090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180563090-0x0000000180563120
	}

	// Constructors
	public ManagerQuangTruong(); // 0x00000001805483E0-0x0000000180548560

	// Methods
	private void Awake(); // 0x0000000180536080-0x0000000180536370
	private void WireEnergyPurchaseButton(); // 0x0000000180547000-0x00000001805472F0
	private void OpenEnergyPurchasePopup(); // 0x00000001803B8DA0-0x00000001803B8DB0
	private void Start(); // 0x00000001805437D0-0x0000000180545200
	[IteratorStateMachine(typeof(_ConsumeHomeDeepLink_d__118))]
	private IEnumerator ConsumeHomeDeepLink(); // 0x0000000180537580-0x00000001805375F0
	private void LateUpdate(); // 0x000000018053BBD0-0x000000018053BDD0
	private void CheckHubStuckDisabled(); // 0x0000000180536560-0x00000001805366A0
	public void OpenEvent(); // 0x000000018053E430-0x000000018053E540
	public void OpenEventFest(); // 0x000000018053DF60-0x000000018053E430
	public void OpenUpdateCard(); // 0x0000000180540160-0x0000000180540270
	public void OpenThongBao(); // 0x000000018053FC30-0x000000018053FE80
	public void OpenThueTinh(); // 0x000000018053EE20-0x000000018053EF60
	public void OpenMiniGame(); // 0x000000018053EFA0-0x000000018053F0C0
	public void OpenNapTichLuy(); // 0x000000018053F0C0-0x000000018053F1D0
	public void OpenNapSafia(); // 0x000000018037C610-0x000000018037C620
	public void OpenDoiMatKhau(); // 0x000000018053DE30-0x000000018053DE40
	private void HandleRechargeSuccess(int safiaAdded, int newBalance); // 0x000000018053A340-0x000000018053A370
	private void HandlePasswordChanged(); // 0x000000018053A270-0x000000018053A340
	public void OpenOnlineGift(); // 0x000000018053F1D0-0x000000018053F2E0
	private void WireOnlineGiftButton(); // 0x0000000180547F50-0x00000001805483E0
	public void OpenHuongDan(); // 0x000000018053EA40-0x000000018053EB50
	private void WireGuideButton(); // 0x0000000180547C00-0x0000000180547F50
	public void OpenFriend(); // 0x000000018053E650-0x000000018053E760
	private void WireFriendButton(); // 0x0000000180547660-0x0000000180547C00
	public bool IsHubViewActive(); // 0x000000018053B6D0-0x000000018053BA00
	private void SetupDailyCheckIn(); // 0x00000001805421B0-0x00000001805422C0
	public void OpenDailyCheckIn(); // 0x000000018053DD70-0x000000018053DE30
	public void OpenWorldChat(); // 0x0000000180540460-0x0000000180540590
	private void LoadAudioSettings(); // 0x000000018053BDD0-0x000000018053BEA0
	private void PlayBackgroundMusic(); // 0x0000000180540750-0x00000001805408E0
	private void SetupButtonSounds(); // 0x0000000180542060-0x00000001805421B0
	[IteratorStateMachine(typeof(_AttachButtonSoundsAsync_d__147))]
	private IEnumerator AttachButtonSoundsAsync(); // 0x0000000180535FA0-0x0000000180536010
	public void StopBackgroundMusic(); // 0x0000000180545200-0x00000001805452A0
	public void PauseBackgroundMusic(); // 0x00000001805406B0-0x0000000180540750
	public void ResumeBackgroundMusic(); // 0x00000001805416E0-0x0000000180541870
	public void SetBGMVolume(float volume); // 0x0000000180541B60-0x0000000180541C10
	public void FadeInBGM(float duration = 2f /* Metadata: 0x0064D694 */); // 0x00000001805390F0-0x0000000180539270
	public void FadeOutBGM(float duration = 2f /* Metadata: 0x0064D698 */, bool stopAfterFade = true /* Metadata: 0x0064D69C */); // 0x0000000180539270-0x0000000180539460
	public void OpenWheelDay(); // 0x0000000180540300-0x0000000180540310
	private void OpenWheelTab(WheelKind kind); // 0x0000000180540310-0x0000000180540460
	public void OpenGachaPanel(); // 0x000000018053E760-0x000000018053E910
	public void OpenGalaxyWheel(); // 0x000000018053E910-0x000000018053E920
	public void OpenFirstPay(); // 0x000000018053E540-0x000000018053E650
	private bool CheckLevelGate(int requiredLevel, string featureName); // 0x00000001805366A0-0x00000001805367A0
	public void OpenTower(); // 0x00000001805400E0-0x0000000180540150
	public void OpenTreasureWheel(); // 0x0000000180540150-0x0000000180540160
	public void OpenRechargeEvent(); // 0x000000018053F930-0x000000018053F970
	public void OpenMidAutumn(); // 0x000000018053EF60-0x000000018053EFA0
	private void OpenPokyEventPanel(string panelKey); // 0x000000018053F740-0x000000018053F810
	private void WireFeatureButton(string buttonName, string prefabPath, UnityAction onClick); // 0x00000001805472F0-0x0000000180547660
	private void OpenLazyPanel(string panelKey, Action<GameObject> onReady); // 0x000000018053EC70-0x000000018053EE20
	[IteratorStateMachine(typeof(_ShowRemoteEventWhenReady_d__176))]
	private IEnumerator ShowRemoteEventWhenReady(); // 0x00000001805434E0-0x0000000180543550
	private void HandleRemoteEventCta(RemoteEventItem ev); // 0x000000018053A370-0x000000018053B170
	public void OpenTienHoa(); // 0x000000018053FFA0-0x00000001805400E0
	public void OpenMega(); // 0x000000018053EE20-0x000000018053EF60
	public void OpenQuest(); // 0x000000018053F810-0x000000018053F930
	public void OpenVongQuay(); // 0x0000000180540270-0x0000000180540300
	private static UnityEngine.UI.Text FindStarText(Transform panelRoot, string gemName); // 0x00000001805399E0-0x0000000180539AE0
	public void OpenGiftCode(); // 0x000000018053E920-0x000000018053EA40
	public void OpenThuVien(); // 0x000000018053FE80-0x000000018053FFA0
	public void OpenKhoPet(); // 0x000000018053EB50-0x000000018053EC70
	public void OpenXepHang(); // 0x0000000180540590-0x00000001805406B0
	public void OpenEquipment(); // 0x000000018053DE40-0x000000018053DF60
	public void OpenChinhPhucPanel(); // 0x000000018053DAE0-0x000000018053DD70
	public void OpenShop(); // 0x000000018053FB10-0x000000018053FC30
	private void InitializeGiftBox(); // 0x000000018053B4D0-0x000000018053B6D0
	public void CheckForGifts(int userId); // 0x0000000180536370-0x00000001805364E0
	[IteratorStateMachine(typeof(_CheckGiftsCoroutine_d__192))]
	private IEnumerator CheckGiftsCoroutine(int userId); // 0x00000001805364E0-0x0000000180536560
	private void OnGiftCountReceived(GiftCountResponse response, int userId); // 0x000000018053C770-0x000000018053C990
	private void HandleGiftPush(ChatMessageDTO m); // 0x0000000180539F70-0x000000018053A130
	private bool IsMatchBlockingHubUi(); // 0x000000018053BA00-0x000000018053BAC0
	private void ApplyOptimisticGiftBadge(); // 0x0000000180535940-0x00000001805359D0
	[IteratorStateMachine(typeof(_GiftPushRefreshAfter_d__197))]
	private IEnumerator GiftPushRefreshAfter(float delay); // 0x0000000180539EF0-0x0000000180539F70
	[IteratorStateMachine(typeof(_AnnounceNewGiftWhenHubVisible_d__198))]
	private IEnumerator AnnounceNewGiftWhenHubVisible(); // 0x0000000180535600-0x0000000180535670
	[IteratorStateMachine(typeof(_GiftFallbackPollLoop_d__199))]
	private IEnumerator GiftFallbackPollLoop(); // 0x0000000180539E80-0x0000000180539EF0
	[IteratorStateMachine(typeof(_AutoOpenNoticeAfterLogin_d__201))]
	private IEnumerator AutoOpenNoticeAfterLogin(); // 0x0000000180536010-0x0000000180536080
	private void HandleNoticePush(ChatMessageDTO m); // 0x000000018053A130-0x000000018053A270
	[IteratorStateMachine(typeof(_NoticePushRefreshAfter_d__203))]
	private IEnumerator NoticePushRefreshAfter(float delay); // 0x000000018053C0F0-0x000000018053C170
	[IteratorStateMachine(typeof(_ShakeNoticeIconUntilSeen_d__204))]
	private IEnumerator ShakeNoticeIconUntilSeen(int uid); // 0x0000000180542960-0x00000001805429E0
	private void PlayNoticeShakeOnce(); // 0x0000000180540D40-0x0000000180540F20
	private void StopNoticeShake(); // 0x00000001805452A0-0x00000001805453F0
	[IteratorStateMachine(typeof(_NoticeFallbackPollLoop_d__207))]
	private IEnumerator NoticeFallbackPollLoop(); // 0x000000018053C080-0x000000018053C0F0
	[IteratorStateMachine(typeof(_LoadGiftDetailsCoroutine_d__208))]
	private IEnumerator LoadGiftDetailsCoroutine(int userId); // 0x000000018053BEA0-0x000000018053BF20
	private void PlayGiftNotificationAnimation(); // 0x0000000180540B60-0x0000000180540D40
	private void StartGiftIdlePulse(); // 0x0000000180543550-0x0000000180543690
	private void PlayGiftArrivalFx(); // 0x00000001805408E0-0x0000000180540B60
	[IteratorStateMachine(typeof(_RestartGiftPulseNextFrame_d__212))]
	private IEnumerator RestartGiftPulseNextFrame(); // 0x0000000180541590-0x0000000180541600
	public void ShowGiftBoxAnimation(GiftDTO gift); // 0x0000000180542D30-0x0000000180542EA0
	[IteratorStateMachine(typeof(_ShowGiftDetailAfterAnimation_d__214))]
	private IEnumerator ShowGiftDetailAfterAnimation(float delay); // 0x0000000180542EA0-0x0000000180542F20
	private void ShowGiftDetail(GiftDTO gift); // 0x0000000180542F20-0x0000000180543170
	private void DisplayRewards(GiftDTO gift); // 0x0000000180537960-0x0000000180538A40
	private void UpdateShardRewardUI(GameObject obj, ShardRewardItem shard); // 0x00000001805467F0-0x00000001805469E0
	private Image EnsurePieceOverlay(GameObject obj, Image mainImg); // 0x0000000180538A40-0x0000000180538D80
	private void SetRewardVisual(GameObject obj, Sprite icon, string label, bool showPiece = false /* Metadata: 0x0064D69D */); // 0x0000000180541C10-0x0000000180542060
	private Image FindRewardImage(GameObject obj, params string[] names); // 0x0000000180539650-0x0000000180539840
	private UnityEngine.UI.Text FindRewardText(GameObject obj); // 0x0000000180539840-0x00000001805399E0
	private void ClearListReward(); // 0x0000000180536EC0-0x00000001805371C0
	private void UpdateRewardUI(GameObject rewardObj, int amount); // 0x0000000180546630-0x0000000180546740
	private void UpdatePetRewardUI(GameObject petObj, int petId, string petName); // 0x0000000180546460-0x0000000180546630
	private void UpdateAVTRewardUI(GameObject petObj, int avtId); // 0x0000000180545A30-0x0000000180545C10
	private void UpdateCardRewardUI(GameObject cardObj, int cardId, string cardName); // 0x0000000180545C10-0x0000000180545E00
	private void UpdateStoneRewardUI(GameObject stoneObj, StoneRewardDTO stone); // 0x0000000180546BF0-0x0000000180546E70
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x0000000180539BF0-0x0000000180539E80
	public void RequestPendingGifts(Action<List<GiftDTO>> onDone); // 0x0000000180541280-0x00000001805413D0
	[IteratorStateMachine(typeof(_RequestPendingGiftsCoroutine_d__232))]
	private IEnumerator RequestPendingGiftsCoroutine(int userId, Action<List<GiftDTO>> onDone); // 0x00000001805411E0-0x0000000180541280
	public void ClaimGift(GiftDTO gift, Action<bool, GiftDTO> onDone); // 0x0000000180536B10-0x0000000180536CA0
	[IteratorStateMachine(typeof(_ClaimGiftCoroutine_d__238))]
	private IEnumerator ClaimGiftCoroutine(GiftDTO gift, int userId, Action<bool, GiftDTO> onDone); // 0x0000000180536A50-0x0000000180536B10
	public void ClaimGiftsSequential(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x0000000180536D70-0x0000000180536EC0
	[IteratorStateMachine(typeof(_ClaimGiftsSequentialCoroutine_d__240))]
	private IEnumerator ClaimGiftsSequentialCoroutine(List<GiftDTO> gifts, Action<GiftDTO> onEach, Action<int, int> onDone); // 0x0000000180536CA0-0x0000000180536D70
	private void ApplyGiftClaimed(GiftDTO source, GiftDTO claimedGift); // 0x0000000180535730-0x0000000180535940
	private void UpdateGiftIconBadge(int count); // 0x0000000180545E00-0x0000000180546050
	public void ClaimCurrentGift(); // 0x00000001805367A0-0x0000000180536A50
	public void ShowClaimedExtras(GiftDTO gift); // 0x00000001805429E0-0x0000000180542D30
	private void CloseGiftBoxWithAnimation(); // 0x00000001805371C0-0x00000001805374C0
	public void CloseGiftBox(); // 0x00000001805374C0-0x0000000180537580
	public void OnGiftIconClicked(); // 0x000000018053C990-0x000000018053CDC0
	public void RefreshUserInfo(bool silent = false /* Metadata: 0x0064D69E */); // 0x0000000180540FB0-0x0000000180541120
	[IteratorStateMachine(typeof(_RefreshUserCoroutine_d__249))]
	private IEnumerator RefreshUserCoroutine(int userId, bool silent); // 0x0000000180540F20-0x0000000180540FB0
	private void OnUserRefreshed(UserDTO user, bool silent = false /* Metadata: 0x0064D69F */); // 0x000000018053D440-0x000000018053D940
	private void ApplyWeaponBadge(UserDTO user); // 0x0000000180535EC0-0x0000000180535FA0
	public static string FormatVND(long amount); // 0x0000000180539AE0-0x0000000180539B60
	private void OnRefreshError(string error, bool silent); // 0x000000018053D060-0x000000018053D130
	public void ShowPanelBoss(); // 0x0000000180543380-0x00000001805434E0
	public void HidePanelBoss(); // 0x000000018053B450-0x000000018053B4D0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__257))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018053BF20-0x000000018053BF90
	[IteratorStateMachine(typeof(_RestorePVPRoomWithLoading_d__258))]
	private IEnumerator RestorePVPRoomWithLoading(); // 0x0000000180541600-0x0000000180541670
	private CanvasGroup OpenPVPRoomHidden(); // 0x000000018053F500-0x000000018053F740
	[IteratorStateMachine(typeof(_WaitForPVPLoad_d__260))]
	private IEnumerator WaitForPVPLoad(ManagerRoomPVP pvpManager, Action onDone); // 0x0000000180546F70-0x0000000180547000
	public void OpenPVPPanel(string roomName); // 0x000000018053F2E0-0x000000018053F500
	public void HidePVPPanel(); // 0x000000018053B290-0x000000018053B450
	public void ExitPVPToHub(); // 0x0000000180538D80-0x00000001805390F0
	public void OnPVPMatchSceneUnloaded(); // 0x000000018053CE50-0x000000018053D060
	public void ReturnToPVPLobbyFromRoom(); // 0x0000000180541870-0x0000000180541B60
	public void ShowPVPRoomFromLobby(); // 0x0000000180543170-0x0000000180543380
	[IteratorStateMachine(typeof(_RestorePanelStateWithLoading_d__267))]
	private IEnumerator RestorePanelStateWithLoading(); // 0x0000000180541670-0x00000001805416E0
	[IteratorStateMachine(typeof(_FastRestoreCoopRoom_d__268))]
	private IEnumerator FastRestoreCoopRoom(); // 0x0000000180539460-0x00000001805394D0
	[IteratorStateMachine(typeof(_SweepOrphanLoadingAfterRestore_d__269))]
	private IEnumerator SweepOrphanLoadingAfterRestore(); // 0x00000001805453F0-0x0000000180545440
	[IteratorStateMachine(typeof(_FastRestoreRoomDataWithRetry_d__270))]
	private IEnumerator FastRestoreRoomDataWithRetry(ManagerRoom roomManager, int userId, int selectedPetId, Action onDone); // 0x00000001805395B0-0x0000000180539650
	private void StartHubBackgroundRefresh(int userId); // 0x0000000180543690-0x00000001805437D0
	private int ResolveRoomPanelIndex(ManagerChinhPhuc chinhPhucManager); // 0x00000001805413D0-0x0000000180541590
	public void NotifyReturnFromAdditiveMatchPVP(); // 0x000000018053C170-0x000000018053C2F0
	[IteratorStateMachine(typeof(_FastRestorePVPRoom_d__274))]
	private IEnumerator FastRestorePVPRoom(); // 0x0000000180539540-0x00000001805395B0
	[IteratorStateMachine(typeof(_FastRestorePVPLobby_d__275))]
	private IEnumerator FastRestorePVPLobby(); // 0x00000001805394D0-0x0000000180539540
	private void SetupLoadingPanel(bool useLoadingRoom = false /* Metadata: 0x0064D6A0 */); // 0x0000000180542390-0x0000000180542960
	[IteratorStateMachine(typeof(_LoadingWatchdog_d__280))]
	private IEnumerator LoadingWatchdog(); // 0x000000018053C010-0x000000018053C080
	private GameObject CreateFallbackLoadingPanel(); // 0x00000001805375F0-0x0000000180537960
	private void KeepLoadingOnTop(); // 0x000000018053BAC0-0x000000018053BBD0
	private CanvasGroup OpenChinhPhucHidden(); // 0x000000018053D940-0x000000018053DAE0
	private CanvasGroup OpenRoomHidden(ManagerRoom roomManager); // 0x000000018053F970-0x000000018053FB10
	private void HideLoadingPanel(); // 0x000000018053B170-0x000000018053B290
	private void UpdateMedalImage(int userLevel, int rankPvp = 0 /* Metadata: 0x0064D6A1 */); // 0x0000000180546100-0x0000000180546460
	private int GetMedalLevel(int userLevel); // 0x0000000180539B60-0x0000000180539BF0
	private void OnUserReceived(UserDTO user); // 0x000000018053D130-0x000000018053D440
	private void ApplyUserUi(UserDTO user); // 0x00000001805359D0-0x0000000180535EC0
	private void ApplyExpBar(float expPercent); // 0x0000000180535670-0x0000000180535730
	private void SetupImgLevel(int level, Image imgLv); // 0x00000001805422C0-0x0000000180542390
	private void OnDestroy(); // 0x000000018053C2F0-0x000000018053C700
	public void OnHubSuspend(); // 0x00000001802E76C0-0x00000001802E76D0
	public void OnHubResume(); // 0x000000018053CDC0-0x000000018053CE50
	public void UpdateWheelFlag(int wheelCount); // 0x0000000180546E70-0x0000000180546F70
	public void UpdateStarUI(int starWhite, int starBlue, int starRed); // 0x00000001805469E0-0x0000000180546BF0
	public void UpdateGoldUI(int gold); // 0x0000000180546050-0x0000000180546100
	public void UpdateSafiaUI(int safia); // 0x0000000180546740-0x00000001805467F0
	private void OnError(string error); // 0x000000018053C700-0x000000018053C770
	public void ReloadUserInfo(); // 0x0000000180541120-0x00000001805411E0
	[IteratorStateMachine(typeof(_LoadUserData_d__302))]
	private IEnumerator LoadUserData(int userId); // 0x000000018053BF90-0x000000018053C010
	[CompilerGenerated]
	private void _FadeInBGM_b__152_0(float val); // 0x0000000180545570-0x0000000180545600
	[CompilerGenerated]
	private void _OpenVongQuay_b__181_0(GameObject panel); // 0x0000000180545770-0x00000001805459B0
	[CompilerGenerated]
	private void _OpenChinhPhucPanel_b__188_0(); // 0x0000000180545610-0x0000000180545770
	[CompilerGenerated]
	private void _PlayGiftArrivalFx_b__211_0(); // 0x00000001805459B0-0x0000000180545A30
	[CompilerGenerated]
	private void _ClaimCurrentGift_b__243_0(bool ok, GiftDTO claimed); // 0x0000000180545440-0x0000000180545570
	[CompilerGenerated]
	private void _FastRestorePVPLobby_b__275_0(UserDTO user); // 0x0000000180545600-0x0000000180545610
	[CompilerGenerated]
	private void _LoadUserData_b__302_0(UserDTO user); // 0x0000000180545600-0x0000000180545610
}

