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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ManagerShopAvatar : MonoBehaviour // TypeDefIndex: 2734
	{
		// Fields
		public const string PANEL_KEY = "PanelShopAvatar"; // Metadata: 0x005F2A12
		public const string FLAG_ENABLED = "shopavatar.enabled"; // Metadata: 0x005F2A22
		public const string FLAG_EQUIP_NOW = "shopavatar.equipnow"; // Metadata: 0x005F2A35
		public const string FLAG_PORTRAIT = "shopavatar.portrait"; // Metadata: 0x005F2A49
		public const string N_SKIN = "PokySkin"; // Metadata: 0x005F2A5D
		public const string N_CLOSE = "btn_Close"; // Metadata: 0x005F2A66
		public const string N_PREV = "btn_Prev"; // Metadata: 0x005F2A70
		public const string N_PAGE = "txt_Page"; // Metadata: 0x005F2A79
		public const string N_NEXT = "btn_Next"; // Metadata: 0x005F2A82
		public const string N_RECHARGE = "btn_Recharge"; // Metadata: 0x005F2A8B
		public const string N_HIDE_OWNED = "tog_HideOwned"; // Metadata: 0x005F2A98
		public const string N_SORT = "btn_Sort"; // Metadata: 0x005F2AA6
		public const string N_GRID = "sec_Grid"; // Metadata: 0x005F2AAF
		public const string N_EMPTY = "txt_Empty"; // Metadata: 0x005F2AB8
		public const string N_LOADING = "sec_Loading"; // Metadata: 0x005F2AC2
		public const string N_LABEL = "txt_Label"; // Metadata: 0x005F2ACE
		public const string N_VALUE = "txt_Value"; // Metadata: 0x005F2AD8
		public const string N_ICON = "img_Icon"; // Metadata: 0x005F2AE2
		public const string N_TITLE = "txt_Title"; // Metadata: 0x005F2AEB
		public static readonly string[] ChipNames; // 0x00
		public const int RARITY_BUTTONS = 5; // Metadata: 0x005F2AF5
		public const int CELL_COUNT = 8; // Metadata: 0x005F2AF6
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
		private sealed class __c__DisplayClass103_0 // TypeDefIndex: 2735
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long shopId; // 0x18
			public string itemName; // 0x20
	
			// Constructors
			public __c__DisplayClass103_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnConfirmed_b__0(ShopAvatarPurchaseDTO d); // 0x0000000180CA5180-0x0000000180CA51C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass108_0 // TypeDefIndex: 2736
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public long boughtId; // 0x18
	
			// Constructors
			public __c__DisplayClass108_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SendPortraitPurchase_b__0(PurchaseResponse r); // 0x0000000180CA51C0-0x0000000180CA51F0
			internal void _SendPortraitPurchase_b__1(string e); // 0x0000000180CA51F0-0x0000000180CA5370
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 2737
		{
			// Fields
			public int value; // 0x10
			public ManagerShopAvatar __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _WireRarityButtons_b__0(); // 0x0000000180CA5370-0x0000000180CA53E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass88_0 // TypeDefIndex: 2738
		{
			// Fields
			public ManagerShopAvatar __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass88_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(ShopAvatarPortraitDTO[] d); // 0x0000000180CA53E0-0x0000000180CA5560
			internal void _Fetch_b__1(string msg, long code); // 0x0000000180CA5560-0x0000000180CA55A0
			internal void _Fetch_b__2(ShopAvatarDataDTO d); // 0x0000000180CA55A0-0x0000000180CA55D0
			internal void _Fetch_b__3(string msg, long code); // 0x0000000180CA5560-0x0000000180CA55A0
		}
	
		[CompilerGenerated]
		private sealed class _LoadingDelay_d__90 : IEnumerator<object> // TypeDefIndex: 2739
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
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180CA55D0-0x0000000180CA5790
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CA5790-0x0000000180CA57D0
		}
	
		// Constructors
		public ManagerShopAvatar(); // 0x0000000180C7E850-0x0000000180C7F110
		static ManagerShopAvatar(); // 0x0000000180C7F110-0x0000000180C7F250
	
		// Methods
		private void Awake(); // 0x0000000180C744A0-0x0000000180C744B0
		private void OnDisable(); // 0x0000000180C744B0-0x0000000180C74600
		public void AutoWire(); // 0x0000000180C74600-0x0000000180C75860
		private void WireChips(); // 0x0000000180C75860-0x0000000180C761F0
		private void WireRarityButtons(); // 0x0000000180C761F0-0x0000000180C76B70
		private void WireGrid(); // 0x0000000180C76B70-0x0000000180C770B0
		private void Missing(string node); // 0x0000000180C770B0-0x0000000180C77150
		private Button FindButton(string node, bool required); // 0x0000000180C77150-0x0000000180C772D0
		private UnityEngine.UI.Text FindText(string node, bool required); // 0x0000000180C772D0-0x0000000180C77450
		public void Open(int category = 0 /* Metadata: 0x005F2A11 */); // 0x0000000180C77450-0x0000000180C77D30
		public void Close(); // 0x0000000180C77D30-0x0000000180C77F50
		private void OnCloseClicked(); // 0x0000000180C77F50-0x0000000180C780E0
		private void ClearData(); // 0x0000000180C780E0-0x0000000180C784D0
		private void OnTabSelected(int tabIndex); // 0x0000000180C784D0-0x0000000180C785C0
		private void OnRarityClicked(int rarity); // 0x0000000180C785C0-0x0000000180C78630
		private void OnHideOwnedChanged(bool on); // 0x0000000180C78630-0x0000000180C78690
		private void OnSortClicked(); // 0x0000000180C78690-0x0000000180C78900
		private void ChangePage(int delta); // 0x0000000180C78900-0x0000000180C78980
		private void RefreshRarityButtons(); // 0x0000000180C78980-0x0000000180C78D50
		private void RefreshSortLabel(); // 0x0000000180C78D50-0x0000000180C78F60
		private void Fetch(); // 0x0000000180C78F60-0x0000000180C794E0
		private void ShowLoadingSoon(int rid); // 0x0000000180C794E0-0x0000000180C796E0
		[IteratorStateMachine(typeof(_LoadingDelay_d__90))]
		private IEnumerator LoadingDelay(int rid); // 0x0000000180C796E0-0x0000000180C79790
		private void HideLoading(); // 0x0000000180C79790-0x0000000180C79950
		private void OnPageOk(int rid, ShopAvatarDataDTO data); // 0x0000000180C79950-0x0000000180C79CB0
		private void OnPortraitsOk(int rid, ShopAvatarPortraitDTO[] list); // 0x0000000180C79CB0-0x0000000180C79E20
		private void OnFetchError(int rid, string message, long httpCode); // 0x0000000180C79E20-0x0000000180C7A070
		private int PageSize(); // 0x0000000180C7A070-0x0000000180C7A150
		private void Redraw(); // 0x0000000180C7A150-0x0000000180C7A6A0
		private int DrawItemPage(); // 0x0000000180C7A6A0-0x0000000180C7A8A0
		private int DrawPortraitPage(); // 0x0000000180C7A8A0-0x0000000180C7AB00
		private ShopAvatarItemDTO ToItem(ShopAvatarPortraitDTO p); // 0x0000000180C7AB00-0x0000000180C7ADF0
		private void RefreshWallet(bool animate); // 0x0000000180C7ADF0-0x0000000180C7B1B0
		private void OnCellClicked(int index); // 0x0000000180C7B1B0-0x0000000180C7B840
		private void OnBuyClicked(); // 0x0000000180C7B840-0x0000000180C7BC30
		private void OnConfirmed(); // 0x0000000180C7BC30-0x0000000180C7C180
		private void OnPurchased(ShopAvatarPurchaseDTO dto, long shopId, string itemName); // 0x0000000180C7C180-0x0000000180C7C910
		private void OnPurchaseError(string message, long httpCode); // 0x0000000180C7C910-0x0000000180C7CB00
		private void MarkOwnedLocally(long shopId); // 0x0000000180C7CB00-0x0000000180C7CED0
		private void BuyPortrait(); // 0x0000000180C7CED0-0x0000000180C7D1D0
		private void SendPortraitPurchase(); // 0x0000000180C7D1D0-0x0000000180C7D620
		private void OnPortraitPurchased(PurchaseResponse r, long shopId); // 0x0000000180C7D620-0x0000000180C7DAA0
		private void OnPortraitPurchaseError(string message); // 0x0000000180C7DAA0-0x0000000180C7DC20
		private void OnRechargeClicked(); // 0x0000000180C7DC20-0x0000000180C7E000
		public void DebugPreview(ShopAvatarDataDTO fake, int selectedIndex, bool showConfirm); // 0x0000000180C7E000-0x0000000180C7E7A0
		private static bool FlagOn(string key, bool fallback); // 0x0000000180C7E7A0-0x0000000180C7E810
		private static long CurrentUserId(); // 0x0000000180C7E810-0x0000000180C7E850
		[CompilerGenerated]
		private void _AutoWire_b__70_0(); // 0x0000000180C7F250-0x0000000180C7F260
		[CompilerGenerated]
		private void _AutoWire_b__70_1(); // 0x0000000180C7F260-0x0000000180C7F270
	}
}
