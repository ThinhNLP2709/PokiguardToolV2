/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class ManagerInfoPlayer : MonoBehaviour // TypeDefIndex: 2434
	{
		// Fields
		public const string PANEL_KEY = "PanelInfoPlayer"; // Metadata: 0x0068F474
		public const string FLAG_EQUIP = "infoplayer.equip"; // Metadata: 0x0068F484
		public const string FLAG_SHOP_AVATAR_LINK = "shopavatar.infoplayer.link"; // Metadata: 0x0068F495
		public const string N_BTN_SHOP_AVATAR = "btn_ShopAvatar"; // Metadata: 0x0068F4B0
		public const string N_INFO_ROOT = "InfoRoot"; // Metadata: 0x0068F4BF
		public const string N_ITEM_PANEL = "sec_ItemPanel"; // Metadata: 0x0068F4C8
		public const string N_BTN_CLOSE = "btn_Close"; // Metadata: 0x0068F4D6
		public const string N_BTN_EQUIPMENT = "btn_EquipmentChar"; // Metadata: 0x0068F4E0
		public const string N_BTN_VIEW_PETS = "btn_ViewPets"; // Metadata: 0x0068F4F2
		public const string N_BTN_VIEW_CARDS = "btn_ViewCards"; // Metadata: 0x0068F4FF
		public const string N_BTN_VIEW_ITEMS = "btn_ViewItems"; // Metadata: 0x0068F50D
		public static readonly string[] ProfileSectionNames; // 0x00
		[Header("C\u1EA5u h\u00ECnh (OTA)")]
		[Tooltip("InfoPlayerConfig.json \u2014 chu\u1ED7i, \u0111\u00EDch n\u00FAt, c\u1EDD FX. B\u1ECF tr\u1ED1ng \u21D2 Resources/InfoPlayerConfig.")]
		public TextAsset configJson; // 0x20
		[Header("Th\u00E0nh ph\u1EA7n")]
		public InfoPlayerView view; // 0x28
		public EquipSlotsPresenter slots; // 0x30
		public AvatarLayerPortrait portrait; // 0x38
		public EquipBagView bag; // 0x40
		public InfoPlayerFitRoot fitRoot; // 0x48
		public InfoPlayerFx fx; // 0x50
		public CanvasGroup canvasGroup; // 0x58
		[Header("\u00D4 th\u00FA c\u01B0ng + C\u00E0i \u0111\u1EB7t (d\u1EF1ng node l\u00FAc ch\u1EA1y)")]
		[Tooltip("Con pet chi\u1EBFn \u0111\u1EE9ng d\u01B0\u1EDBi ch\u00E2n nh\u00E2n v\u1EADt, v\u00E0 \u1EA3nh c\u1EE7a n\u00F3 trong \u00F4 6.")]
		public InfoPlayerPetStage petStage; // 0x60
		[Tooltip("B\u1EA3ng ch\u1ECDn th\u00FA c\u01B0ng \u2014 l\u01B0\u1EDBi 5\u00D74, 20 con m\u1ED7i trang.")]
		public InfoPlayerPetPicker petPicker; // 0x68
		[Tooltip("N\u00FAt b\u00E1nh r\u0103ng m\u1EDF b\u1EA3ng C\u00E0i \u0111\u1EB7t c\u1EE7a b\u1EA3ng th\u00F4ng tin c\u0169.")]
		public InfoPlayerSettingsLink settingsLink; // 0x70
		[Tooltip("V\u00F9ng ch\u1EA1m ph\u1EE7 \u1EA3nh nh\u00E2n v\u1EADt \u2014 bung tooltip nh\u00E2n v\u1EADt (05/09).")]
		public InfoPlayerAvatarTap avatarTap; // 0x78
		[Tooltip("M\u1EB7t KHO \u0110\u1ED2 \u2014 V\u1EADt ph\u1EA9m \u00B7 M\u1EA3nh pet \u00B7 Th\u1EBB b\u00E0i (05/09), thay hai tab c\u1EE7a b\u1EA3ng c\u0169; d\u1EF1ng node l\u00FAc ch\u1EA1y.")]
		public InfoPlayerStorageView storage; // 0x80
		[Header("Hai m\u1EB7t")]
		public GameObject[] profileSections; // 0x88
		public GameObject itemPanel; // 0x90
		[Header("N\u00FAt")]
		public Button btnClose; // 0x98
		public Button btnEquipmentChar; // 0xA0
		public Button btnViewPets; // 0xA8
		public Button btnViewCards; // 0xB0
		public Button btnViewItems; // 0xB8
		private long _sessionUserId; // 0xC0
		private long _targetUserId; // 0xC8
		private bool _isOther; // 0xD0
		private Action _onFeatureMissing; // 0xD8
		private ProfileDTO _profile; // 0xE0
		private EquipSlotDTO[] _slotBook; // 0xE8
		private bool _avatarSetHidden; // 0xF0
		private long _equipPower; // 0xF8
		private int _shardCount; // 0x100
		private bool _hasRealData; // 0x104
		private bool _profileInFlight; // 0x105
		private bool _writeInFlight; // 0x106
		private bool _avatarInFlight; // 0x107
		private bool _bagFaceOpen; // 0x108
		private bool _storageFaceOpen; // 0x109
		private bool _bagRequested; // 0x10A
		private int _bagRequestId; // 0x10C
		private bool _wired; // 0x110
	
		// Properties
		public bool IsShowingBag { get; } // 0x000000018080B590-0x000000018080B5A0 
		public bool IsShowingStorage { get; } // 0x000000018080B5A0-0x000000018080B5B0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2435
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__66_0; // 0x08
			public static Action<GameObject> __9__71_0; // 0x10
			public static Action<GameObject> __9__98_0; // 0x18
	
			// Constructors
			static __c(); // 0x000000018080EE60-0x000000018080EED0
			public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OpenWeaponBag_b__66_0(GameObject panel); // 0x000000018080C910-0x000000018080CA10
			internal void _OpenShardStorage_b__71_0(GameObject panel); // 0x000000018080C810-0x000000018080C910
			internal void _OpenLibraryCards_b__98_0(GameObject panel); // 0x000000018080C710-0x000000018080C810
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass82_0 // TypeDefIndex: 2436
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public EquipSlot slot; // 0x18
			public long wornRowId; // 0x20
	
			// Constructors
			public __c__DisplayClass82_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OnSlotClicked_b__0(); // 0x000000018080D8A0-0x000000018080D8D0
			internal void _OnSlotClicked_b__1(); // 0x000000018080D8D0-0x000000018080D900
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass85_0 // TypeDefIndex: 2437
		{
			// Fields
			public string shownName; // 0x10
			public ManagerInfoPlayer __4__this; // 0x18
			public long shownId; // 0x20
	
			// Constructors
			public __c__DisplayClass85_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OnAvatarClicked_b__0(); // 0x000000018080D900-0x000000018080D950
			internal void _OnAvatarClicked_b__1(); // 0x000000018080D950-0x000000018080DAD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass89_0 // TypeDefIndex: 2438
		{
			// Fields
			public int rid; // 0x10
			public ManagerInfoPlayer __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass89_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _RequestBag_b__0(EquipBagDTO d); // 0x000000018080DAD0-0x000000018080DCC0
			internal void _RequestBag_b__1(string message, long code); // 0x000000018080DCC0-0x000000018080DD80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass90_0 // TypeDefIndex: 2439
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass90_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OnBagCellClicked_b__0(); // 0x000000018080E0A0-0x000000018080E280
			internal void _OnBagCellClicked_b__1(); // 0x000000018080E280-0x000000018080E2B0
			internal void _OnBagCellClicked_b__2(); // 0x000000018080E2B0-0x000000018080E490
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass91_0 // TypeDefIndex: 2440
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass91_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _EquipFromBag_b__0(EquipBookDTO book); // 0x000000018080E490-0x000000018080E6A0
			internal void _EquipFromBag_b__1(string message, long code); // 0x000000018080E6A0-0x000000018080E750
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass94_0 // TypeDefIndex: 2441
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass94_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _UpgradeStar_b__0(EquipBookDTO book); // 0x000000018080E750-0x000000018080EA60
			internal void _UpgradeStar_b__1(string message, long code); // 0x000000018080EA60-0x000000018080EB10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass95_0 // TypeDefIndex: 2442
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public int before; // 0x18
	
			// Constructors
			public __c__DisplayClass95_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Salvage_b__0(EquipBookDTO book); // 0x000000018080EB10-0x000000018080ED30
			internal void _Salvage_b__1(string message, long code); // 0x000000018080ED30-0x000000018080EDF0
		}
	
		// Constructors
		public ManagerInfoPlayer(); // 0x000000018080B520-0x000000018080B590
		static ManagerInfoPlayer(); // 0x000000018080B400-0x000000018080B520
	
		// Methods
		private void Awake(); // 0x00000001808060E0-0x00000001808060F0
		private void OnDisable(); // 0x0000000180807BA0-0x0000000180807CD0
		public void AutoWire(); // 0x00000001808050E0-0x00000001808060E0
		private Button FindButton(string node); // 0x0000000180807290-0x0000000180807360
		private void EnsureShopAvatarLink(); // 0x0000000180806750-0x00000001808070C0
		private void OnShopAvatarLinkClicked(); // 0x00000001808081B0-0x0000000180808290
		public void Open(long targetUserId = 0 /* Metadata: 0x0068F46C */, Action onFeatureMissing = null); // 0x0000000180809450-0x00000001808097C0
		public void Close(); // 0x0000000180806350-0x0000000180806530
		private void OnCloseClicked(); // 0x0000000180807B80-0x0000000180807BA0
		public void ShowProfileFace(); // 0x000000018080A230-0x000000018080A450
		public void ShowBagFace(); // 0x0000000180809F50-0x000000018080A210
		public void ShowWeaponBag(); // 0x000000018080A740-0x000000018080A7E0
		public static void OpenWeaponBag(); // 0x00000001808092E0-0x0000000180809450
		public void ShowStorage(StorageTab tab); // 0x000000018080A460-0x000000018080A740
		public void ShowShardStorage(); // 0x000000018080A450-0x000000018080A460
		public void ShowItemStorage(); // 0x000000018080A220-0x000000018080A230
		public void ShowCardStorage(); // 0x000000018080A210-0x000000018080A220
		public static void OpenShardStorage(); // 0x0000000180809170-0x00000001808092E0
		public void RefreshProfileFromOutside(); // 0x00000001808097C0-0x00000001808097D0
		public void OpenKhoPetForStar(); // 0x0000000180808920-0x0000000180808A10
		private void RequestProfile(); // 0x0000000180809A20-0x0000000180809C10
		private void OnProfileOk(ProfileDTO dto); // 0x0000000180808020-0x00000001808081B0
		private void OnPetChosen(PetUserDTO pet); // 0x0000000180807CD0-0x0000000180807DF0
		private void OnProfileError(string message, long httpCode); // 0x0000000180807DF0-0x0000000180808020
		private void RefreshCombatStats(); // 0x00000001808097C0-0x00000001808097D0
		private void ApplyBook(EquipBookDTO book, EquipSlot changedSlot, bool showDelta); // 0x0000000180804DD0-0x00000001808050E0
		private EquipSlotDTO FindSlot(EquipSlot slot); // 0x0000000180807360-0x00000001808073E0
		private bool IsAvatarSetRow(long rowId); // 0x00000001808073E0-0x0000000180807420
		private void OnSlotClicked(EquipSlot slot); // 0x0000000180808290-0x00000001808087A0
		private static bool CanUpgrade(EquipItemDTO item); // 0x00000001808060F0-0x0000000180806120
		private void OnSlotCloseClicked(EquipSlot slot); // 0x00000001808087A0-0x00000001808087C0
		private void OnAvatarClicked(); // 0x0000000180807420-0x0000000180807700
		private static void CopyPlayerName(string rawName); // 0x0000000180806530-0x0000000180806710
		private void SendFriendRequest(long targetId); // 0x0000000180809DE0-0x0000000180809F50
		private void OnSlotUpgradeClicked(EquipSlot slot); // 0x00000001808087C0-0x0000000180808920
		private void RequestBag(); // 0x00000001808097D0-0x0000000180809A20
		private void OnBagCellClicked(int index, RectTransform anchor); // 0x0000000180807700-0x0000000180807B80
		public void EquipFromBag(long rowId); // 0x00000001808070C0-0x0000000180807290
		public void Unequip(EquipSlot slot); // 0x000000018080B0A0-0x000000018080B230
		public void ToggleAvatarHidden(); // 0x000000018080A860-0x000000018080A9E0
		public void UpgradeStar(long rowId); // 0x000000018080B230-0x000000018080B400
		public void Salvage(long rowId); // 0x0000000180809C10-0x0000000180809DE0
		private static EquipSlot SlotOfRow(EquipBookDTO book, long rowId); // 0x000000018080A7E0-0x000000018080A860
		private void OpenRoute(string route); // 0x0000000180808B80-0x0000000180809170
		private void OpenLibraryCards(); // 0x0000000180808A10-0x0000000180808B80
		public void Clear(); // 0x0000000180806120-0x0000000180806350
		private static long CurrentUserId(); // 0x0000000180806710-0x0000000180806750
		[CompilerGenerated]
		private void _AutoWire_b__52_0(); // 0x000000018080A9E0-0x000000018080AA40
		[CompilerGenerated]
		private void _AutoWire_b__52_1(); // 0x000000018080AA40-0x000000018080AAA0
		[CompilerGenerated]
		private void _AutoWire_b__52_2(); // 0x000000018080AAA0-0x000000018080AB00
		[CompilerGenerated]
		private void _SendFriendRequest_b__87_0(); // 0x000000018080AB00-0x000000018080ABA0
		[CompilerGenerated]
		private void _SendFriendRequest_b__87_1(string message, long code); // 0x000000018080ABA0-0x000000018080AC40
		[CompilerGenerated]
		private void _Unequip_b__92_0(EquipBookDTO book); // 0x000000018080ADD0-0x000000018080AFF0
		[CompilerGenerated]
		private void _Unequip_b__92_1(string message, long code); // 0x000000018080AFF0-0x000000018080B0A0
		[CompilerGenerated]
		private void _ToggleAvatarHidden_b__93_0(EquipBookDTO book); // 0x000000018080AC40-0x000000018080AD20
		[CompilerGenerated]
		private void _ToggleAvatarHidden_b__93_1(string message, long code); // 0x000000018080AD20-0x000000018080ADD0
	}
}
