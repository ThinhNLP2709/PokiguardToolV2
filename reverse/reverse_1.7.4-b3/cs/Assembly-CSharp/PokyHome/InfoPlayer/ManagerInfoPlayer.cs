/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class ManagerInfoPlayer : MonoBehaviour // TypeDefIndex: 2879
	{
		// Fields
		public const string PANEL_KEY = "PanelInfoPlayer"; // Metadata: 0x005F21C0
		public const string FLAG_EQUIP = "infoplayer.equip"; // Metadata: 0x005F21D0
		public const string FLAG_SHOP_AVATAR_LINK = "shopavatar.infoplayer.link"; // Metadata: 0x005F21E1
		public const string N_BTN_SHOP_AVATAR = "btn_ShopAvatar"; // Metadata: 0x005F21FC
		public const string N_INFO_ROOT = "InfoRoot"; // Metadata: 0x005F220B
		public const string N_ITEM_PANEL = "sec_ItemPanel"; // Metadata: 0x005F2214
		public const string N_BTN_CLOSE = "btn_Close"; // Metadata: 0x005F2222
		public const string N_BTN_EQUIPMENT = "btn_EquipmentChar"; // Metadata: 0x005F222C
		public const string N_BTN_VIEW_PETS = "btn_ViewPets"; // Metadata: 0x005F223E
		public const string N_BTN_VIEW_CARDS = "btn_ViewCards"; // Metadata: 0x005F224B
		public const string N_BTN_VIEW_ITEMS = "btn_ViewItems"; // Metadata: 0x005F2259
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
		public bool IsShowingBag { get; } // 0x0000000180D2A270-0x0000000180D2A280 
		public bool IsShowingStorage { get; } // 0x0000000180D2A280-0x0000000180D2A290 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2880
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__67_0; // 0x08
			public static Action<GameObject> __9__72_0; // 0x10
			public static Action<GameObject> __9__104_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000180D32870-0x0000000180D32910
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OpenWeaponBag_b__67_0(GameObject panel); // 0x0000000180D32910-0x0000000180D32B10
			internal void _OpenShardStorage_b__72_0(GameObject panel); // 0x0000000180D32B10-0x0000000180D32D20
			internal void _OpenLibraryCards_b__104_0(GameObject panel); // 0x0000000180D32D20-0x0000000180D32F40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass100_0 // TypeDefIndex: 2881
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass100_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _UpgradeStar_b__0(EquipBookDTO book); // 0x0000000180D32F40-0x0000000180D332E0
			internal void _UpgradeStar_b__1(string message, long code); // 0x0000000180D332E0-0x0000000180D333A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass101_0 // TypeDefIndex: 2882
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public int before; // 0x18
	
			// Constructors
			public __c__DisplayClass101_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Salvage_b__0(EquipBookDTO book); // 0x0000000180D333A0-0x0000000180D335F0
			internal void _Salvage_b__1(string message, long code); // 0x0000000180D335F0-0x0000000180D336B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass83_0 // TypeDefIndex: 2883
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public EquipSlot slot; // 0x18
			public long wornRowId; // 0x20
	
			// Constructors
			public __c__DisplayClass83_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnSlotClicked_b__0(); // 0x0000000180D336B0-0x0000000180D336E0
			internal void _OnSlotClicked_b__1(); // 0x0000000180D336E0-0x0000000180D33710
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass84_0 // TypeDefIndex: 2884
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public RectTransform anchor; // 0x18
	
			// Constructors
			public __c__DisplayClass84_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnSetMemberTapped_b__0(EquipItemDTO item); // 0x0000000180D33710-0x0000000180D33880
			internal void _OnSetMemberTapped_b__1(string message, long code); // 0x0000000180D33880-0x0000000180D33930
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass85_0 // TypeDefIndex: 2885
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass85_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ShowMemberTooltip_b__0(); // 0x0000000180D33930-0x0000000180D33960
			internal void _ShowMemberTooltip_b__1(); // 0x0000000180D33960-0x0000000180D33990
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass91_0 // TypeDefIndex: 2886
		{
			// Fields
			public string shownName; // 0x10
			public ManagerInfoPlayer __4__this; // 0x18
			public long shownId; // 0x20
	
			// Constructors
			public __c__DisplayClass91_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnAvatarClicked_b__0(); // 0x0000000180D33990-0x0000000180D339F0
			internal void _OnAvatarClicked_b__1(); // 0x0000000180D339F0-0x0000000180D33BA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass95_0 // TypeDefIndex: 2887
		{
			// Fields
			public int rid; // 0x10
			public ManagerInfoPlayer __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass95_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _RequestBag_b__0(EquipBagDTO d); // 0x0000000180D33BA0-0x0000000180D33DA0
			internal void _RequestBag_b__1(string message, long code); // 0x0000000180D33DA0-0x0000000180D33E60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass96_0 // TypeDefIndex: 2888
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass96_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnBagCellClicked_b__0(); // 0x0000000180D33930-0x0000000180D33960
			internal void _OnBagCellClicked_b__1(); // 0x0000000180D33960-0x0000000180D33990
			internal void _OnBagCellClicked_b__2(); // 0x0000000180D33E60-0x0000000180D33E90
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass97_0 // TypeDefIndex: 2889
		{
			// Fields
			public ManagerInfoPlayer __4__this; // 0x10
			public long rowId; // 0x18
	
			// Constructors
			public __c__DisplayClass97_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EquipFromBag_b__0(EquipBookDTO book); // 0x0000000180D33E90-0x0000000180D340B0
			internal void _EquipFromBag_b__1(string message, long code); // 0x0000000180D340B0-0x0000000180D34170
		}
	
		// Constructors
		public ManagerInfoPlayer(); // 0x0000000180D31EC0-0x0000000180D31FA0
		static ManagerInfoPlayer(); // 0x0000000180D31FA0-0x0000000180D32100
	
		// Methods
		private void Awake(); // 0x0000000180D271E0-0x0000000180D271F0
		private void OnEnable(); // 0x0000000180D271F0-0x0000000180D27300
		private void OnDisable(); // 0x0000000180D27300-0x0000000180D27650
		public void AutoWire(); // 0x0000000180D27650-0x0000000180D28B50
		private Button FindButton(string node); // 0x0000000180D28B50-0x0000000180D28CB0
		private void EnsureShopAvatarLink(); // 0x0000000180D28CB0-0x0000000180D29A40
		private void OnShopAvatarLinkClicked(); // 0x0000000180D29A40-0x0000000180D29C10
		public void Open(long targetUserId = 0 /* Metadata: 0x005F21B8 */, Action onFeatureMissing = null); // 0x0000000180D29C10-0x0000000180D29FC0
		public void Close(); // 0x0000000180D29FC0-0x0000000180D2A250
		private void OnCloseClicked(); // 0x0000000180D2A250-0x0000000180D2A270
		public void ShowProfileFace(); // 0x0000000180D2A290-0x0000000180D2A6E0
		public void ShowBagFace(); // 0x0000000180D2A6E0-0x0000000180D2ABE0
		public void ShowWeaponBag(); // 0x0000000180D2ABE0-0x0000000180D2AD00
		public static void OpenWeaponBag(); // 0x0000000180D2AD00-0x0000000180D2AEE0
		public void ShowStorage(StorageTab tab); // 0x0000000180D2AEE0-0x0000000180D2B430
		public void ShowShardStorage(); // 0x0000000180D2B430-0x0000000180D2B440
		public void ShowItemStorage(); // 0x0000000180D2B440-0x0000000180D2B450
		public void ShowCardStorage(); // 0x0000000180D2B450-0x0000000180D2B460
		public static void OpenShardStorage(); // 0x0000000180D2B460-0x0000000180D2B640
		public void RefreshProfileFromOutside(); // 0x0000000180D2B640-0x0000000180D2B650
		public void OpenKhoPetForStar(); // 0x0000000180D2B650-0x0000000180D2B7C0
		private void RequestProfile(); // 0x0000000180D2B7C0-0x0000000180D2BCC0
		private void OnProfileOk(ProfileDTO dto); // 0x0000000180D2BCC0-0x0000000180D2C020
		private void OnPetChosen(PetUserDTO pet); // 0x0000000180D2C020-0x0000000180D2C2E0
		private void OnProfileError(string message, long httpCode); // 0x0000000180D2C2E0-0x0000000180D2C570
		private void RefreshCombatStats(); // 0x0000000180D2B640-0x0000000180D2B650
		private void ApplyBook(EquipBookDTO book, EquipSlot changedSlot, bool showDelta); // 0x0000000180D2C570-0x0000000180D2CE90
		private EquipSlotDTO FindSlot(EquipSlot slot); // 0x0000000180D2CE90-0x0000000180D2CF10
		private bool IsAvatarSetRow(long rowId); // 0x0000000180D2CF10-0x0000000180D2CF50
		private void OnSlotClicked(EquipSlot slot); // 0x0000000180D2CF50-0x0000000180D2D7C0
		private void OnSetMemberTapped(EquipSetMemberDTO member, RectTransform anchor); // 0x0000000180D2D7C0-0x0000000180D2DE30
		private void ShowMemberTooltip(RectTransform anchor, EquipItemDTO item, long rowId, bool equipped); // 0x0000000180D2DE30-0x0000000180D2E280
		private EquipSlotDTO FindSlotByItem(long itemId); // 0x0000000180D2E280-0x0000000180D2E2E0
		private bool IsWorn(long rowId); // 0x0000000180D2E2E0-0x0000000180D2E350
		private EquipItemDTO FindBagItem(long itemId, out long rowId, out bool equipped); // 0x0000000180D2E350-0x0000000180D2E4D0
		private static bool CanUpgrade(EquipItemDTO item); // 0x0000000180D2E4D0-0x0000000180D2E500
		private void OnSlotCloseClicked(EquipSlot slot); // 0x0000000180D2E500-0x0000000180D2E520
		private void OnAvatarClicked(); // 0x0000000180D2E520-0x0000000180D2ED40
		private static void CopyPlayerName(string rawName); // 0x0000000180D2ED40-0x0000000180D2EF90
		private void SendFriendRequest(long targetId); // 0x0000000180D2EF90-0x0000000180D2F130
		private void OnSlotUpgradeClicked(EquipSlot slot); // 0x0000000180D2F130-0x0000000180D2F2A0
		private void RequestBag(); // 0x0000000180D2F2A0-0x0000000180D2F670
		private void OnBagCellClicked(int index, RectTransform anchor); // 0x0000000180D2F670-0x0000000180D2FCB0
		public void EquipFromBag(long rowId); // 0x0000000180D2FCB0-0x0000000180D30040
		public void Unequip(EquipSlot slot); // 0x0000000180D30040-0x0000000180D30360
		public void ToggleAvatarHidden(); // 0x0000000180D30360-0x0000000180D306A0
		public void UpgradeStar(long rowId); // 0x0000000180D306A0-0x0000000180D30A30
		public void Salvage(long rowId); // 0x0000000180D30A30-0x0000000180D30DC0
		private static EquipSlot SlotOfRow(EquipBookDTO book, long rowId); // 0x0000000180D30DC0-0x0000000180D30E40
		private void OpenRoute(string route); // 0x0000000180D30E40-0x0000000180D315B0
		private void OpenLibraryCards(); // 0x0000000180D315B0-0x0000000180D31790
		public void Clear(); // 0x0000000180D31790-0x0000000180D31E80
		private static long CurrentUserId(); // 0x0000000180D31E80-0x0000000180D31EC0
		[CompilerGenerated]
		private void _AutoWire_b__53_0(); // 0x0000000180D32100-0x0000000180D32170
		[CompilerGenerated]
		private void _AutoWire_b__53_1(); // 0x0000000180D32170-0x0000000180D321E0
		[CompilerGenerated]
		private void _AutoWire_b__53_2(); // 0x0000000180D321E0-0x0000000180D32250
		[CompilerGenerated]
		private void _SendFriendRequest_b__93_0(); // 0x0000000180D32250-0x0000000180D32300
		[CompilerGenerated]
		private void _SendFriendRequest_b__93_1(string message, long code); // 0x0000000180D32300-0x0000000180D323B0
		[CompilerGenerated]
		private void _Unequip_b__98_0(EquipBookDTO book); // 0x0000000180D323B0-0x0000000180D32600
		[CompilerGenerated]
		private void _Unequip_b__98_1(string message, long code); // 0x0000000180D32600-0x0000000180D326C0
		[CompilerGenerated]
		private void _ToggleAvatarHidden_b__99_0(EquipBookDTO book); // 0x0000000180D326C0-0x0000000180D327B0
		[CompilerGenerated]
		private void _ToggleAvatarHidden_b__99_1(string message, long code); // 0x0000000180D327B0-0x0000000180D32870
	}
}
