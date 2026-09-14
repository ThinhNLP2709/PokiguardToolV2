/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ManagerShopAvatar : MonoBehaviour // TypeDefIndex: 2727
	{
		// Fields
		public const string PANEL_KEY = "PanelShopAvatar"; // Metadata: 0x005F15FB
		public const string FLAG_ENABLED = "shopavatar.enabled"; // Metadata: 0x005F160B
		public const string FLAG_EQUIP_NOW = "shopavatar.equipnow"; // Metadata: 0x005F161E
		public const string FLAG_PORTRAIT = "shopavatar.portrait"; // Metadata: 0x005F1632
		public const string N_SKIN = "PokySkin"; // Metadata: 0x005F1646
		public const string N_CLOSE = "btn_Close"; // Metadata: 0x005F164F
		public const string N_PREV = "btn_Prev"; // Metadata: 0x005F1659
		public const string N_PAGE = "txt_Page"; // Metadata: 0x005F1662
		public const string N_NEXT = "btn_Next"; // Metadata: 0x005F166B
		public const string N_RECHARGE = "btn_Recharge"; // Metadata: 0x005F1674
		public const string N_HIDE_OWNED = "tog_HideOwned"; // Metadata: 0x005F1681
		public const string N_SORT = "btn_Sort"; // Metadata: 0x005F168F
		public const string N_GRID = "sec_Grid"; // Metadata: 0x005F1698
		public const string N_EMPTY = "txt_Empty"; // Metadata: 0x005F16A1
		public const string N_LOADING = "sec_Loading"; // Metadata: 0x005F16AB
		public const string N_LABEL = "txt_Label"; // Metadata: 0x005F16B7
		public const string N_VALUE = "txt_Value"; // Metadata: 0x005F16C1
		public const string N_ICON = "img_Icon"; // Metadata: 0x005F16CB
		public const string N_TITLE = "txt_Title"; // Metadata: 0x005F16D4
		public static readonly string[] ChipNames; // 0x00
		public const int RARITY_BUTTONS = 5; // Metadata: 0x005F16DE
		public const int CELL_COUNT = 8; // Metadata: 0x005F16DF
		[Header("C\u1EA5u h\u00ECnh OTA (TextAsset trong prefab; b\u1ECF tr\u1ED1ng \u21D2 Resources/ShopAvatarConfig.json)")]
		public TextAsset configJson; // 0x20
		[Header("Icon ba lo\u1EA1i ti\u1EC1n (b\u1ED9 d\u1EF1ng g\u00E1n t\u1EEB bundle cash_shop)")]
		public Sprite spriteGold; // 0x28
		public Sprite spriteRuby; // 0x30
		public Sprite spriteSafia; // 0x38
		[Header("Node (t\u1EF1 d\u00F2 theo t\u00EAn \u2014 b\u1ED9 d\u1EF1ng kh\u00F4ng c\u1EA7n g\u00E1n)")]
		public CanvasGroup canvasGroup; // 0x40
		public RectTransform skinRoot; // 0x48
		public Button btnClose; // 0x50
		public Button btnPrev; // 0x58
		public Button btnNext; // 0x60
		public UnityEngine.UI.Text txtPage; // 0x68
		public Button btnRecharge; // 0x70
		public Toggle togHideOwned; // 0x78
		public UnityEngine.UI.Text txtHideOwnedLabel; // 0x80
		public Button btnSort; // 0x88
		public UnityEngine.UI.Text txtSortLabel; // 0x90
		public UnityEngine.UI.Text txtTitle; // 0x98
		public UnityEngine.UI.Text txtEmpty; // 0xA0
		public GameObject secLoading; // 0xA8
		public RectTransform secGrid; // 0xB0
		private readonly UnityEngine.UI.Text[] _chipValues; // 0xB8
		private readonly Image[] _chipIcons; // 0xC0
		private readonly Button[] _rarityButtons; // 0xC8
		private readonly UnityEngine.UI.Text[] _rarityLabels; // 0xD0
		private readonly Image[] _rarityBgs; // 0xD8
		private readonly List<ShopAvatarCellView> _cells; // 0xE0
		private readonly ShopAvatarTabBar _tabs; // 0xE8
		private readonly ShopAvatarPreviewView _preview; // 0xF0
		private readonly ShopAvatarConfirmView _confirm; // 0xF8
		private ShopAvatarFx _fx; // 0x100
		private int _category; // 0x108
		private int _rarity; // 0x10C
		private bool _hideOwned; // 0x110
		private string _sort; // 0x118
		private int _page; // 0x120
		private int _totalPages; // 0x124
		private long _selectedShopId; // 0x128
		private int _requestId; // 0x130
		private ShopAvatarItemDTO[] _items; // 0x138
		private ShopAvatarPortraitDTO[] _portraits; // 0x140
		private ShopAvatarWalletDTO _wallet; // 0x148
		private string _baseLayers; // 0x150
		private bool _purchaseInFlight; // 0x158
		private bool _portraitAllowed; // 0x159
		private bool _equipNowAllowed; // 0x15A
		private bool _wired; // 0x15B
		private long _sessionUserId; // 0x160
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass103_0 // TypeDefIndex: 2728
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long shopId; // 0x18
			public string itemName; // 0x20
	
			// Constructors
			public __c__DisplayClass103_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnConfirmed_b__0(ShopAvatarPurchaseDTO d); // 0x0000000180C71B20-0x0000000180C71B60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2729
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long boughtId; // 0x18
	
			// Constructors
			public __c__DisplayClass108_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SendPortraitPurchase_b__0(PurchaseResponse r); // 0x0000000180C71B60-0x0000000180C71B90
			internal void _SendPortraitPurchase_b__1(string e); // 0x0000000180C71B90-0x0000000180C71CF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2730
		{
			// Fields
			public int value; // 0x10
			public ManagerShopAvatar __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _WireRarityButtons_b__0(); // 0x0000000180C71CF0-0x0000000180C71D60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass88_0 // TypeDefIndex: 2731
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass88_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(ShopAvatarPortraitDTO[] d); // 0x0000000180C71D60-0x0000000180C71EB0
			internal void _Fetch_b__1(string msg, long code); // 0x0000000180C71EB0-0x0000000180C71EF0
			internal void _Fetch_b__2(ShopAvatarDataDTO d); // 0x0000000180C71EF0-0x0000000180C71F20
			internal void _Fetch_b__3(string msg, long code); // 0x0000000180C71EB0-0x0000000180C71EF0
		}
	
		[CompilerGenerated]
		private sealed class _LoadingDelay_d__90 : IEnumerator<object> // TypeDefIndex: 2732
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerShopAvatar __4__this; // 0x20
			public int rid; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadingDelay_d__90(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C71F20-0x0000000180C720E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C720E0-0x0000000180C72120
		}
	
		// Constructors
		public ManagerShopAvatar(); // 0x0000000180C71100-0x0000000180C719C0
		static ManagerShopAvatar(); // 0x0000000180C719C0-0x0000000180C71B00
	
		// Methods
		private void Awake(); // 0x0000000180C66EE0-0x0000000180C66EF0
		private void OnDisable(); // 0x0000000180C66EF0-0x0000000180C67040
		public void AutoWire(); // 0x0000000180C67040-0x0000000180C682A0
		private void WireChips(); // 0x0000000180C682A0-0x0000000180C68C30
		private void WireRarityButtons(); // 0x0000000180C68C30-0x0000000180C695B0
		private void WireGrid(); // 0x0000000180C695B0-0x0000000180C69AF0
		private void Missing(string node); // 0x0000000180C69AF0-0x0000000180C69B90
		private Button FindButton(string node, bool required); // 0x0000000180C69B90-0x0000000180C69D10
		private UnityEngine.UI.Text FindText(string node, bool required); // 0x0000000180C69D10-0x0000000180C69E90
		public void Open(int category = 0 /* Metadata: 0x005F15FA */); // 0x0000000180C69E90-0x0000000180C6A770
		public void Close(); // 0x0000000180C6A770-0x0000000180C6A990
		private void OnCloseClicked(); // 0x0000000180C6A990-0x0000000180C6AB20
		private void ClearData(); // 0x0000000180C6AB20-0x0000000180C6AF10
		private void OnTabSelected(int tabIndex); // 0x0000000180C6AF10-0x0000000180C6B000
		private void OnRarityClicked(int rarity); // 0x0000000180C6B000-0x0000000180C6B070
		private void OnHideOwnedChanged(bool on); // 0x0000000180C6B070-0x0000000180C6B0D0
		private void OnSortClicked(); // 0x0000000180C6B0D0-0x0000000180C6B340
		private void ChangePage(int delta); // 0x0000000180C6B340-0x0000000180C6B3C0
		private void RefreshRarityButtons(); // 0x0000000180C6B3C0-0x0000000180C6B790
		private void RefreshSortLabel(); // 0x0000000180C6B790-0x0000000180C6B9A0
		private void Fetch(); // 0x0000000180C6B9A0-0x0000000180C6BF20
		private void ShowLoadingSoon(int rid); // 0x0000000180C6BF20-0x0000000180C6C120
		[IteratorStateMachine(typeof(_LoadingDelay_d__90))]
		private IEnumerator LoadingDelay(int rid); // 0x0000000180C6C120-0x0000000180C6C1D0
		private void HideLoading(); // 0x0000000180C6C1D0-0x0000000180C6C390
		private void OnPageOk(int rid, ShopAvatarDataDTO data); // 0x0000000180C6C390-0x0000000180C6C6C0
		private void OnPortraitsOk(int rid, ShopAvatarPortraitDTO[] list); // 0x0000000180C6C6C0-0x0000000180C6C800
		private void OnFetchError(int rid, string message, long httpCode); // 0x0000000180C6C800-0x0000000180C6CA20
		private int PageSize(); // 0x0000000180C6CA20-0x0000000180C6CB00
		private void Redraw(); // 0x0000000180C6CB00-0x0000000180C6D050
		private int DrawItemPage(); // 0x0000000180C6D050-0x0000000180C6D250
		private int DrawPortraitPage(); // 0x0000000180C6D250-0x0000000180C6D4B0
		private ShopAvatarItemDTO ToItem(ShopAvatarPortraitDTO p); // 0x0000000180C6D4B0-0x0000000180C6D7A0
		private void RefreshWallet(bool animate); // 0x0000000180C6D7A0-0x0000000180C6DB60
		private void OnCellClicked(int index); // 0x0000000180C6DB60-0x0000000180C6E1F0
		private void OnBuyClicked(); // 0x0000000180C6E1F0-0x0000000180C6E5E0
		private void OnConfirmed(); // 0x0000000180C6E5E0-0x0000000180C6EB30
		private void OnPurchased(ShopAvatarPurchaseDTO dto, long shopId, string itemName); // 0x0000000180C6EB30-0x0000000180C6F270
		private void OnPurchaseError(string message, long httpCode); // 0x0000000180C6F270-0x0000000180C6F440
		private void MarkOwnedLocally(long shopId); // 0x0000000180C6F440-0x0000000180C6F810
		private void BuyPortrait(); // 0x0000000180C6F810-0x0000000180C6FB10
		private void SendPortraitPurchase(); // 0x0000000180C6FB10-0x0000000180C6FF40
		private void OnPortraitPurchased(PurchaseResponse r, long shopId); // 0x0000000180C6FF40-0x0000000180C70380
		private void OnPortraitPurchaseError(string message); // 0x0000000180C70380-0x0000000180C704D0
		private void OnRechargeClicked(); // 0x0000000180C704D0-0x0000000180C708B0
		public void DebugPreview(ShopAvatarDataDTO fake, int selectedIndex, bool showConfirm); // 0x0000000180C708B0-0x0000000180C71050
		private static bool FlagOn(string key, bool fallback); // 0x0000000180C71050-0x0000000180C710C0
		private static long CurrentUserId(); // 0x0000000180C710C0-0x0000000180C71100
		[CompilerGenerated]
		private void _AutoWire_b__70_0(); // 0x0000000180C71B00-0x0000000180C71B10
		[CompilerGenerated]
		private void _AutoWire_b__70_1(); // 0x0000000180C71B10-0x0000000180C71B20
	}
}
