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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ManagerShopAvatar : MonoBehaviour // TypeDefIndex: 2291
	{
		// Fields
		public const string PANEL_KEY = "PanelShopAvatar"; // Metadata: 0x0068E5A5
		public const string FLAG_ENABLED = "shopavatar.enabled"; // Metadata: 0x0068E5B5
		public const string FLAG_EQUIP_NOW = "shopavatar.equipnow"; // Metadata: 0x0068E5C8
		public const string FLAG_PORTRAIT = "shopavatar.portrait"; // Metadata: 0x0068E5DC
		public const string N_SKIN = "PokySkin"; // Metadata: 0x0068E5F0
		public const string N_CLOSE = "btn_Close"; // Metadata: 0x0068E5F9
		public const string N_PREV = "btn_Prev"; // Metadata: 0x0068E603
		public const string N_PAGE = "txt_Page"; // Metadata: 0x0068E60C
		public const string N_NEXT = "btn_Next"; // Metadata: 0x0068E615
		public const string N_RECHARGE = "btn_Recharge"; // Metadata: 0x0068E61E
		public const string N_HIDE_OWNED = "tog_HideOwned"; // Metadata: 0x0068E62B
		public const string N_SORT = "btn_Sort"; // Metadata: 0x0068E639
		public const string N_GRID = "sec_Grid"; // Metadata: 0x0068E642
		public const string N_EMPTY = "txt_Empty"; // Metadata: 0x0068E64B
		public const string N_LOADING = "sec_Loading"; // Metadata: 0x0068E655
		public const string N_LABEL = "txt_Label"; // Metadata: 0x0068E661
		public const string N_VALUE = "txt_Value"; // Metadata: 0x0068E66B
		public const string N_ICON = "img_Icon"; // Metadata: 0x0068E675
		public const string N_TITLE = "txt_Title"; // Metadata: 0x0068E67E
		public static readonly string[] ChipNames; // 0x00
		public const int RARITY_BUTTONS = 5; // Metadata: 0x0068E688
		public const int CELL_COUNT = 8; // Metadata: 0x0068E689
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
		private sealed class __c__DisplayClass103_0 // TypeDefIndex: 2292
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long shopId; // 0x18
			public string itemName; // 0x20
	
			// Constructors
			public __c__DisplayClass103_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OnConfirmed_b__0(ShopAvatarPurchaseDTO d); // 0x00000001807C6C70-0x00000001807C6CB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2293
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long boughtId; // 0x18
	
			// Constructors
			public __c__DisplayClass108_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _SendPortraitPurchase_b__0(PurchaseResponse r); // 0x00000001807C6CB0-0x00000001807C6CE0
			internal void _SendPortraitPurchase_b__1(string e); // 0x00000001807C6CE0-0x00000001807C6D00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2294
		{
			// Fields
			public int value; // 0x10
			public ManagerShopAvatar __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _WireRarityButtons_b__0(); // 0x00000001807C7160-0x00000001807C7190
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass88_0 // TypeDefIndex: 2295
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass88_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Fetch_b__0(ShopAvatarPortraitDTO[] d); // 0x00000001807C7560-0x00000001807C7590
			internal void _Fetch_b__1(string msg, long code); // 0x00000001807C7590-0x00000001807C75D0
			internal void _Fetch_b__2(ShopAvatarDataDTO d); // 0x00000001807C75D0-0x00000001807C7600
			internal void _Fetch_b__3(string msg, long code); // 0x00000001807C7590-0x00000001807C75D0
		}
	
		[CompilerGenerated]
		private sealed class _LoadingDelay_d__90 : IEnumerator<object> // TypeDefIndex: 2296
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerShopAvatar __4__this; // 0x20
			public int rid; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadingDelay_d__90(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807C6B30-0x00000001807C6C30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807C6C30-0x00000001807C6C70
		}
	
		// Constructors
		public ManagerShopAvatar(); // 0x000000018079B520-0x000000018079B890
		static ManagerShopAvatar(); // 0x000000018079B420-0x000000018079B520
	
		// Methods
		private void Awake(); // 0x0000000180795290-0x00000001807952A0
		private void OnDisable(); // 0x0000000180797940-0x0000000180797A10
		public void AutoWire(); // 0x0000000180794730-0x0000000180795290
		private void WireChips(); // 0x000000018079A570-0x000000018079AB20
		private void WireRarityButtons(); // 0x000000018079AE30-0x000000018079B420
		private void WireGrid(); // 0x000000018079AB20-0x000000018079AE30
		private void Missing(string node); // 0x0000000180796DE0-0x0000000180796E60
		private Button FindButton(string node, bool required); // 0x0000000180796780-0x0000000180796880
		private UnityEngine.UI.Text FindText(string node, bool required); // 0x0000000180796880-0x0000000180796980
		public void Open(int category = 0 /* Metadata: 0x0068E5A4 */); // 0x0000000180798F90-0x0000000180799490
		public void Close(); // 0x0000000180795810-0x0000000180795980
		private void OnCloseClicked(); // 0x0000000180797660-0x00000001807976B0
		private void ClearData(); // 0x0000000180795600-0x0000000180795810
		private void OnTabSelected(int tabIndex); // 0x0000000180798EB0-0x0000000180798F90
		private void OnRarityClicked(int rarity); // 0x0000000180798AE0-0x0000000180798B50
		private void OnHideOwnedChanged(bool on); // 0x0000000180797C10-0x0000000180797C70
		private void OnSortClicked(); // 0x0000000180798D80-0x0000000180798EB0
		private void ChangePage(int delta); // 0x0000000180795580-0x0000000180795600
		private void RefreshRarityButtons(); // 0x00000001807998C0-0x0000000180799BB0
		private void RefreshSortLabel(); // 0x0000000180799BB0-0x0000000180799CC0
		private void Fetch(); // 0x00000001807963E0-0x0000000180796780
		private void ShowLoadingSoon(int rid); // 0x000000018079A2A0-0x000000018079A380
		[IteratorStateMachine(typeof(_LoadingDelay_d__90))]
		private IEnumerator LoadingDelay(int rid); // 0x0000000180796A90-0x0000000180796B10
		private void HideLoading(); // 0x00000001807969F0-0x0000000180796A90
		private void OnPageOk(int rid, ShopAvatarDataDTO data); // 0x0000000180797C70-0x0000000180797EB0
		private void OnPortraitsOk(int rid, ShopAvatarPortraitDTO[] list); // 0x0000000180798300-0x0000000180798450
		private void OnFetchError(int rid, string message, long httpCode); // 0x0000000180797A10-0x0000000180797C10
		private int PageSize(); // 0x0000000180799490-0x0000000180799510
		private void Redraw(); // 0x0000000180799510-0x00000001807998C0
		private int DrawItemPage(); // 0x00000001807960A0-0x0000000180796220
		private int DrawPortraitPage(); // 0x0000000180796220-0x00000001807963E0
		private ShopAvatarItemDTO ToItem(ShopAvatarPortraitDTO p); // 0x000000018079A380-0x000000018079A550
		private void RefreshWallet(bool animate); // 0x0000000180799CC0-0x0000000180799F70
		private void OnCellClicked(int index); // 0x0000000180797240-0x0000000180797660
		private void OnBuyClicked(); // 0x0000000180796E60-0x0000000180797240
		private void OnConfirmed(); // 0x00000001807976B0-0x0000000180797940
		private void OnPurchased(ShopAvatarPurchaseDTO dto, long shopId, string itemName); // 0x0000000180798600-0x0000000180798AE0
		private void OnPurchaseError(string message, long httpCode); // 0x0000000180798450-0x0000000180798600
		private void MarkOwnedLocally(long shopId); // 0x0000000180796B10-0x0000000180796DE0
		private void BuyPortrait(); // 0x00000001807952A0-0x0000000180795580
		private void SendPortraitPurchase(); // 0x0000000180799F70-0x000000018079A2A0
		private void OnPortraitPurchased(PurchaseResponse r, long shopId); // 0x0000000180797FE0-0x0000000180798300
		private void OnPortraitPurchaseError(string message); // 0x0000000180797EB0-0x0000000180797FE0
		private void OnRechargeClicked(); // 0x0000000180798B50-0x0000000180798D80
		public void DebugPreview(ShopAvatarDataDTO fake, int selectedIndex, bool showConfirm); // 0x00000001807959C0-0x00000001807960A0
		private static bool FlagOn(string key, bool fallback); // 0x0000000180796980-0x00000001807969F0
		private static long CurrentUserId(); // 0x0000000180795980-0x00000001807959C0
		[CompilerGenerated]
		private void _AutoWire_b__70_0(); // 0x000000018079A550-0x000000018079A560
		[CompilerGenerated]
		private void _AutoWire_b__70_1(); // 0x000000018079A560-0x000000018079A570
	}
}
