/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ShopManager : MonoBehaviour // TypeDefIndex: 1220
{
	// Fields
	public const string PANEL_KEY = "PanelShop"; // Metadata: 0x0064D530
	public static ShopManager Instance; // 0x00
	[Header("Stone Card")]
	public Sprite spriteStoneCard; // 0x20
	[Header("Main Shop Panel")]
	public GameObject panelShop; // 0x28
	public Button btnClose; // 0x30
	[Header("Category Buttons")]
	public Button btnItem; // 0x38
	public Button btnPet; // 0x40
	public Button btnAvt; // 0x48
	public Button btnPackage; // 0x50
	private Vector3 btnNormalScale; // 0x58
	private Vector3 btnSelectedScale; // 0x64
	[Header("Lists")]
	public GameObject listavt; // 0x70
	public GameObject listpet; // 0x78
	public GameObject listitem; // 0x80
	[Header("Avatar Board - 2 slots")]
	public Image[] avtImages; // 0x88
	public UnityEngine.UI.Text[] avtAtk; // 0x90
	public UnityEngine.UI.Text[] avtMana; // 0x98
	public UnityEngine.UI.Text[] avtHp; // 0xA0
	public UnityEngine.UI.Text[] avtPrice; // 0xA8
	public Button[] avtButtons; // 0xB0
	[Header("Avatar Grid (ban skin Poky) - de TRONG de giu 2 o cu")]
	public Transform avtGridContent; // 0xB8
	public GameObject avtCellPrefab; // 0xC0
	public int avatarsPerPageGrid; // 0xC8
	private readonly List<PokyShopAvatarCell> _avtCells; // 0xD0
	private bool _purchaseInFlight; // 0xD8
	[Header("Pet Board - 3 slots")]
	public Image[] petImages; // 0xE0
	public UnityEngine.UI.Text[] petAtk; // 0xE8
	public UnityEngine.UI.Text[] petMana; // 0xF0
	public UnityEngine.UI.Text[] petHp; // 0xF8
	public UnityEngine.UI.Text[] petPrice; // 0x100
	public Button[] petButtons; // 0x108
	[Header("Item Board - 15 slots")]
	public Image[] itemImages; // 0x110
	public UnityEngine.UI.Text[] itemCount; // 0x118
	public UnityEngine.UI.Text[] itemPrice; // 0x120
	public Button[] itemButtons; // 0x128
	[Header("Package Board - G\u00F3i (bundle)")]
	public GameObject listpackage; // 0x130
	public Image[] packageImages; // 0x138
	public UnityEngine.UI.Text[] packageName; // 0x140
	public UnityEngine.UI.Text[] packagePrice; // 0x148
	public Button[] packageButtons; // 0x150
	public Sprite spritePackageDefault; // 0x158
	[Header("Package Cards \u2014 th\u1EBB g\u00F3i (hi\u1EC7n icon v\u1EADt ph\u1EA9m b\u00EAn trong)")]
	public Transform packageCardContainer; // 0x160
	public GameObject packageCardTemplate; // 0x168
	public int maxRewardIconsPerCard; // 0x170
	[Header("Package Detail Popup \u2014 hi\u1EC7n n\u1ED9i dung g\u00F3i")]
	public GameObject panelPackageDetail; // 0x178
	public UnityEngine.UI.Text txtPackageDetailTitle; // 0x180
	public Transform packageRewardContainer; // 0x188
	public GameObject packageRewardEntryTemplate; // 0x190
	public UnityEngine.UI.Text txtPackageDetailPrice; // 0x198
	public Button btnBuyPackage; // 0x1A0
	public Button btnClosePackageDetail; // 0x1A8
	public Sprite spriteExp; // 0x1B0
	[Header("Pagination")]
	public Button btnLeft; // 0x1B8
	public Button btnRight; // 0x1C0
	public UnityEngine.UI.Text txtPageInfo; // 0x1C8
	[Header("Currency Display")]
	public UnityEngine.UI.Text txtGold; // 0x1D0
	public UnityEngine.UI.Text txtRuby; // 0x1D8
	public UnityEngine.UI.Text txtSafia; // 0x1E0
	[Header("Notice Panel")]
	public GameObject panelNotice; // 0x1E8
	public UnityEngine.UI.Text txtNotice; // 0x1F0
	public UnityEngine.UI.Text txtNoticeTotalPrice; // 0x1F8
	public Button btnNoticeClose; // 0x200
	public Button btnNoticeConfirm; // 0x208
	[Header("Notice - Quantity Input (ch\u1EC9 cho ITEM)")]
	public GameObject quantityInputContainer; // 0x210
	public InputField inputQuantity; // 0x218
	[Header("Stone Sprites - 5 H\u1EC7 x 7 Levels")]
	public Sprite[] stoneFire; // 0x220
	public Sprite[] stoneWater; // 0x228
	public Sprite[] stoneWind; // 0x230
	public Sprite[] stoneEarth; // 0x238
	public Sprite[] stoneThunder; // 0x240
	private ShopDataResponse shopData; // 0x248
	private List<ShopItemDTO> currentItems; // 0x250
	private List<ShopPetDTO> currentPets; // 0x258
	private List<ShopAvatarDTO> currentAvatars; // 0x260
	private List<ShopPackageDTO> currentPackages; // 0x268
	private int currentPage; // 0x270
	private int totalPages; // 0x274
	private string currentCategory; // 0x278
	private object pendingPurchaseItem; // 0x280
	private string pendingPurchaseType; // 0x288
	private long pendingShopId; // 0x290
	private bool pendingIsPackage; // 0x298
	private long pendingPackageId; // 0x2A0
	private ShopPackageDTO detailPackage; // 0x2A8
	private string pendingShardNote; // 0x2B0
	private readonly List<GameObject> spawnedRewardEntries; // 0x2B8
	private readonly List<GameObject> spawnedPackageCards; // 0x2C0
	private int pendingUnitPrice; // 0x2C8
	private string pendingCurrencyType; // 0x2D0
	private string pendingItemName; // 0x2D8
	private int currentGold; // 0x2E0
	private int currentRuby; // 0x2E4
	private int currentSafia; // 0x2E8
	private bool _loadingVisible; // 0x2EC
	[Header("Item Sprites")]
	public Sprite spriteEnergy; // 0x2F0
	public Sprite spriteWheel; // 0x2F8
	public Sprite spriteStarWhite; // 0x300
	public Sprite spriteStarBlue; // 0x308
	public Sprite spriteStarRed; // 0x310
	[Header("Animation Settings")]
	public float itemPopDelay; // 0x318
	public float buttonHoverScale; // 0x31C
	[Header("Price Prefabs")]
	public GameObject prefabGoldPrice; // 0x320
	public GameObject prefabRubyPrice; // 0x328
	public GameObject prefabSafiaPrice; // 0x330

	// Properties
	private bool AvatarGridMode { get; } // 0x00000001804D0100-0x00000001804D0180 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1221
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__114_0; // 0x08
		public static Action<string> __9__120_1; // 0x10

		// Constructors
		static __c(); // 0x00000001804D7C80-0x00000001804D7CF0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CloseShop_b__114_0(); // 0x00000001804D6F60-0x00000001804D70A0
		internal void _UpdateCurrencyCoroutine_b__120_1(string error); // 0x00000001804D70A0-0x00000001804D7110
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass110_0 // TypeDefIndex: 1222
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass110_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupButtons_b__4(); // 0x00000001804D7110-0x00000001804D7140
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass110_1 // TypeDefIndex: 1223
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass110_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupButtons_b__5(); // 0x00000001804D7140-0x00000001804D72D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass110_2 // TypeDefIndex: 1224
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass110_2(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupButtons_b__6(); // 0x00000001804D72D0-0x00000001804D73E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass111_0 // TypeDefIndex: 1225
	{
		// Fields
		public GameObject buttonObj; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass111_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AddButtonHoverAnimation_b__0(BaseEventData data); // 0x00000001804D73E0-0x00000001804D74C0
		internal void _AddButtonHoverAnimation_b__1(BaseEventData data); // 0x00000001804D74C0-0x00000001804D7570
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1226
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass112_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AddCategoryButtonAnimation_b__0(BaseEventData data); // 0x00000001804D7570-0x00000001804D7670
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 1227
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass121_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateNumberChange_b__0(float val); // 0x00000001804D7670-0x00000001804D7780
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass122_0 // TypeDefIndex: 1228
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public string category; // 0x18

		// Constructors
		public __c__DisplayClass122_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SwitchCategory_b__0(); // 0x00000001804D7780-0x00000001804D77D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 1229
	{
		// Fields
		public Action onComplete; // 0x10

		// Constructors
		public __c__DisplayClass124_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FadeOutList_b__0(); // 0x00000001803A72E0-0x00000001803A7300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass132_0 // TypeDefIndex: 1230
	{
		// Fields
		public ShopPackageDTO captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass132_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayPackagesAnimated_b__0(); // 0x00000001804D77D0-0x00000001804D7850
	}

	[CompilerGenerated]
	private struct __c__DisplayClass136_0 // TypeDefIndex: 1231
	{
		// Fields
		public List<KeyValuePair<Sprite, string>> list; // 0x00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1232
	{
		// Fields
		public int captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass157_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayAvatarsGrid_b__0(); // 0x00000001804D7850-0x00000001804D7880
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass165_0 // TypeDefIndex: 1233
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public CanvasGroup cg; // 0x18

		// Constructors
		public __c__DisplayClass165_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimatePageTransition_b__0(); // 0x00000001804D7880-0x00000001804D7910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1234
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass167_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnItemClicked_b__0(); // 0x00000001804D7910-0x00000001804D79A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass170_0 // TypeDefIndex: 1235
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass170_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x00000001804D79A0-0x00000001804D7A30
	}

	[CompilerGenerated]
	private sealed class _DisplayAvatarsAnimated_d__150 : IEnumerator<object> // TypeDefIndex: 1236
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayAvatarsAnimated_d__150(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D0470-0x00000001804D0CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D0CD0-0x00000001804D0D10
	}

	[CompilerGenerated]
	private sealed class _DisplayCategoryWithAnimation_d__126 : IEnumerator<object> // TypeDefIndex: 1237
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string category; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCategoryWithAnimation_d__126(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D0D10-0x00000001804D0F30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D0F30-0x00000001804D0F70
	}

	[CompilerGenerated]
	private sealed class _DisplayItemsAnimated_d__130 : IEnumerator<object> // TypeDefIndex: 1238
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayItemsAnimated_d__130(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D0F70-0x00000001804D1810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D1810-0x00000001804D1850
	}

	[CompilerGenerated]
	private sealed class _DisplayPackagesAnimated_d__132 : IEnumerator<object> // TypeDefIndex: 1239
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _endIndex_5__3; // 0x2C
		private int _idx_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPackagesAnimated_d__132(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D1850-0x00000001804D21C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D21C0-0x00000001804D2200
	}

	[CompilerGenerated]
	private sealed class _DisplayPetsAnimated_d__147 : IEnumerator<object> // TypeDefIndex: 1240
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPetsAnimated_d__147(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D2200-0x00000001804D2A30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D2A30-0x00000001804D2A70
	}

	[CompilerGenerated]
	private sealed class _LoadShopDataCoroutine_d__116 : IEnumerator<object> // TypeDefIndex: 1241
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadShopDataCoroutine_d__116(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E57C0-0x00000001804E5940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5940-0x00000001804E5980
	}

	[CompilerGenerated]
	private sealed class _PlaySuccessEffect_d__181 : IEnumerator<object> // TypeDefIndex: 1242
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private Color _originalColor_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlaySuccessEffect_d__181(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E5980-0x00000001804E5B90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5B90-0x00000001804E5BD0
	}

	[CompilerGenerated]
	private sealed class _PurchaseItemCoroutine_d__176 : IEnumerator<object> // TypeDefIndex: 1243
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long shopId; // 0x28
		public int quantity; // 0x30
		public ShopManager __4__this; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PurchaseItemCoroutine_d__176(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E5BD0-0x00000001804E5D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5D90-0x00000001804E5DD0
	}

	[CompilerGenerated]
	private sealed class _PurchasePackageCoroutine_d__175 : IEnumerator<object> // TypeDefIndex: 1244
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long packageId; // 0x28
		public ShopManager __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PurchasePackageCoroutine_d__175(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E5DD0-0x00000001804E5F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5F90-0x00000001804E5FD0
	}

	[CompilerGenerated]
	private sealed class _UpdateCurrencyCoroutine_d__120 : IEnumerator<object> // TypeDefIndex: 1245
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCurrencyCoroutine_d__120(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804EB560-0x00000001804EB740
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EB740-0x00000001804EB780
	}

	// Constructors
	public ShopManager(); // 0x00000001804CFB10-0x00000001804D0100

	// Methods
	private int GetBalanceForCurrency(string currencyType); // 0x00000001804C8C70-0x00000001804C8D10
	private string GetCurrencyDisplayName(string currencyType); // 0x00000001804C8D10-0x00000001804C8DC0
	private void Awake(); // 0x00000001804C6A40-0x00000001804C6B40
	private void Start(); // 0x00000001804CE7F0-0x00000001804CE930
	private void OnQuantityChanged(string value); // 0x00000001804CB240-0x00000001804CB5C0
	private int GetValidQuantity(); // 0x00000001804C9510-0x00000001804C95C0
	private void SetupButtons(); // 0x00000001804CC850-0x00000001804CD280
	private void AddButtonHoverAnimation(GameObject buttonObj); // 0x00000001804C5FA0-0x00000001804C62D0
	private void AddCategoryButtonAnimation(GameObject buttonObj); // 0x00000001804C62D0-0x00000001804C6500
	public void OpenShop(); // 0x00000001804CB830-0x00000001804CB900
	public void CloseShop(); // 0x00000001804C7760-0x00000001804C78E0
	private void LoadShopData(); // 0x00000001804C99C0-0x00000001804C9B20
	[IteratorStateMachine(typeof(_LoadShopDataCoroutine_d__116))]
	private IEnumerator LoadShopDataCoroutine(int userId); // 0x00000001804C9940-0x00000001804C99C0
	private void OnShopDataLoaded(ShopDataResponse data); // 0x00000001804CB6B0-0x00000001804CB830
	private void OnShopDataError(string error); // 0x00000001804CB5C0-0x00000001804CB6B0
	private void UpdateCurrencyDisplay(); // 0x00000001804CF8D0-0x00000001804CF9A0
	[IteratorStateMachine(typeof(_UpdateCurrencyCoroutine_d__120))]
	private IEnumerator UpdateCurrencyCoroutine(int userId); // 0x00000001804CF850-0x00000001804CF8D0
	private void AnimateNumberChange(UnityEngine.UI.Text textComponent, int targetValue); // 0x00000001804C6670-0x00000001804C6840
	private void SwitchCategory(string category, bool resetPage = true /* Metadata: 0x0064D51C */); // 0x00000001804CE930-0x00000001804CEC00
	private GameObject GetCurrentListObject(); // 0x00000001804C8EE0-0x00000001804C8FE0
	private void FadeOutList(GameObject listObj, Action onComplete); // 0x00000001804C88A0-0x00000001804C8A20
	private void ShowCategoryContent(string category); // 0x00000001804CD280-0x00000001804CD860
	[IteratorStateMachine(typeof(_DisplayCategoryWithAnimation_d__126))]
	private IEnumerator DisplayCategoryWithAnimation(string category); // 0x00000001804C83B0-0x00000001804C8440
	private void HideAllLists(); // 0x00000001804C95C0-0x00000001804C96C0
	private int PackagesPerPage(); // 0x00000001804CB980-0x00000001804CB990
	private void ResetButtonScales(); // 0x00000001804CBCF0-0x00000001804CBF80
	[IteratorStateMachine(typeof(_DisplayItemsAnimated_d__130))]
	private IEnumerator DisplayItemsAnimated(); // 0x00000001804C8440-0x00000001804C84B0
	private void DisplayItems(); // 0x00000001804C84B0-0x00000001804C8530
	[IteratorStateMachine(typeof(_DisplayPackagesAnimated_d__132))]
	private IEnumerator DisplayPackagesAnimated(); // 0x00000001804C8530-0x00000001804C85A0
	private bool TryShowPackageChest(Transform row, ShopPackageDTO pkg); // 0x00000001804CF240-0x00000001804CF440
	private static int PackageChestTier(string currencyType); // 0x00000001804CB900-0x00000001804CB980
	private void OnPackageCardClicked(ShopPackageDTO pkg); // 0x00000001804CA9C0-0x00000001804CAA30
	private List<KeyValuePair<Sprite, string>> BuildRewardList(ShopPackageDTO pkg); // 0x00000001804C6B40-0x00000001804C73F0
	private GameObject SpawnRewardIcon(Transform parent, Sprite icon, string amountText); // 0x00000001804CE5D0-0x00000001804CE7F0
	private UnityEngine.UI.Text FindDeepText(Transform root, string name); // 0x00000001804C8B30-0x00000001804C8BF0
	private Transform FindDeepChild(Transform root, string name); // 0x00000001804C8A20-0x00000001804C8B30
	private void ShowPackageDetail(ShopPackageDTO pkg); // 0x00000001804CDBD0-0x00000001804CE180
	private Sprite GetCurrencyIcon(string currencyType); // 0x00000001804C8DC0-0x00000001804C8EE0
	private void OnBuyPackageClicked(); // 0x00000001804C9D70-0x00000001804CA120
	private string BuildShardNote(ShopPackageDTO pkg); // 0x00000001804C73F0-0x00000001804C7550
	private void ClosePackageDetail(); // 0x00000001804C76A0-0x00000001804C7760
	private Sprite GetItemSprite(ShopItemDTO item); // 0x00000001804C8FE0-0x00000001804C9350
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x00000001804C9350-0x00000001804C9510
	[IteratorStateMachine(typeof(_DisplayPetsAnimated_d__147))]
	private IEnumerator DisplayPetsAnimated(); // 0x00000001804C85A0-0x00000001804C8610
	private bool TrySetupPetAnimation(Image petImage, string petID); // 0x00000001804CEC00-0x00000001804CF240
	private void DisplayPets(); // 0x00000001804C8610-0x00000001804C8690
	[IteratorStateMachine(typeof(_DisplayAvatarsAnimated_d__150))]
	private IEnumerator DisplayAvatarsAnimated(); // 0x00000001804C7CA0-0x00000001804C7D10
	private void DisplayAvatars(); // 0x00000001804C8330-0x00000001804C83B0
	private int AvatarsPerPage(); // 0x00000001804C6A00-0x00000001804C6A40
	private void EnsureAvatarCells(int count); // 0x00000001804C8690-0x00000001804C88A0
	private void HideLegacyAvatarSlots(); // 0x00000001804C96C0-0x00000001804C9940
	private void DisplayAvatarsGrid(); // 0x00000001804C7D10-0x00000001804C8330
	private void SetCellPrice(PokyShopAvatarCell cell, int price, string currencyType, bool owned); // 0x00000001804CBFC0-0x00000001804CC350
	private static Color CurrencyColor(string currencyType); // 0x00000001804C7BD0-0x00000001804C7CA0
	private void OnAvatarClickedData(int dataIndex); // 0x00000001804C9B50-0x00000001804C9C60
	private void RunLocal(IEnumerator routine); // 0x00000001804CBF80-0x00000001804CBFC0
	private void UpdatePaginationUI(); // 0x00000001804CF9A0-0x00000001804CFB10
	private void PreviousPage(); // 0x00000001804CBA00-0x00000001804CBA20
	private void NextPage(); // 0x00000001804C9B20-0x00000001804C9B50
	private void AnimatePageTransition(int direction); // 0x00000001804C6840-0x00000001804C6A00
	private void RefreshCurrentCategory(); // 0x00000001804CBB60-0x00000001804CBCF0
	private void OnItemClicked(int slotIndex); // 0x00000001804CA6B0-0x00000001804CA9C0
	private void OnPetClicked(int slotIndex); // 0x00000001804CAA30-0x00000001804CABB0
	private void OnAvatarClicked(int slotIndex); // 0x00000001804C9C60-0x00000001804C9D70
	private void AnimateButtonClick(GameObject btnObj); // 0x00000001804C6500-0x00000001804C6670
	private void ShowPurchaseConfirmation(string itemName, int price, string currencyType, bool isItem = false /* Metadata: 0x0064D51D */); // 0x00000001804CE180-0x00000001804CE5D0
	private void ShowNotice(string message); // 0x00000001804CD980-0x00000001804CDBD0
	private void CloseNotice(); // 0x00000001804C7550-0x00000001804C76A0
	private void ConfirmPurchase(); // 0x00000001804C78E0-0x00000001804C7BD0
	[IteratorStateMachine(typeof(_PurchasePackageCoroutine_d__175))]
	private IEnumerator PurchasePackageCoroutine(int userId, long packageId); // 0x00000001804CBAD0-0x00000001804CBB60
	[IteratorStateMachine(typeof(_PurchaseItemCoroutine_d__176))]
	private IEnumerator PurchaseItemCoroutine(int userId, long shopId, int quantity = 1 /* Metadata: 0x0064D51E */); // 0x00000001804CBA20-0x00000001804CBAD0
	private void OnPurchaseSuccess(PurchaseResponse response); // 0x00000001804CAD00-0x00000001804CB240
	private void ShowGrantedExtras(PurchaseResponse response); // 0x00000001804CD860-0x00000001804CD980
	public static string FormatVND(long amount); // 0x00000001804C8BF0-0x00000001804C8C70
	private void SetPriceWithPrefab(UnityEngine.UI.Text priceText, int price, string currencyType, ref GameObject cachedPriceObject, bool isOwned = false /* Metadata: 0x0064D51F */, string ownedText = "\u0110\u00E3 s\u1EDF h\u1EEFu" /* Metadata: 0x0064D520 */); // 0x00000001804CC350-0x00000001804CC850
	[IteratorStateMachine(typeof(_PlaySuccessEffect_d__181))]
	private IEnumerator PlaySuccessEffect(); // 0x00000001804CB990-0x00000001804CBA00
	private void OnPurchaseError(string error); // 0x00000001804CABB0-0x00000001804CAD00
	private void OnDisable(); // 0x00000001804CA4A0-0x00000001804CA6B0
	private void OnDestroy(); // 0x00000001804CA120-0x00000001804CA4A0
	[CompilerGenerated]
	private void _SetupButtons_b__110_0(); // 0x00000001804CF5F0-0x00000001804CF630
	[CompilerGenerated]
	private void _SetupButtons_b__110_1(); // 0x00000001804CF630-0x00000001804CF670
	[CompilerGenerated]
	private void _SetupButtons_b__110_2(); // 0x00000001804CF670-0x00000001804CF6B0
	[CompilerGenerated]
	private void _SetupButtons_b__110_3(); // 0x00000001804CF6B0-0x00000001804CF6F0
	[CompilerGenerated]
	private void _UpdateCurrencyCoroutine_b__120_0(UserDTO user); // 0x00000001804CF740-0x00000001804CF850
	[CompilerGenerated]
	internal static void _BuildRewardList_g__A_136_0(Sprite s, string a, ref __c__DisplayClass136_0 param_0000181d); // 0x00000001804CF440-0x00000001804CF530
	[CompilerGenerated]
	private void _ShowNotice_b__172_0(); // 0x00000001804CF6F0-0x00000001804CF740
	[CompilerGenerated]
	private void _CloseNotice_b__173_0(); // 0x00000001804CF530-0x00000001804CF5B0
	[CompilerGenerated]
	private void _PlaySuccessEffect_b__181_0(Color val); // 0x00000001804CF5B0-0x00000001804CF5F0
}

