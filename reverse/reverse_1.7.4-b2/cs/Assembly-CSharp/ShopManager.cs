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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ShopManager : MonoBehaviour // TypeDefIndex: 1448
{
	// Fields
	public const string PANEL_KEY = "PanelShop"; // Metadata: 0x0068D11B
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
	private bool AvatarGridMode { get; } // 0x00000001805CF6B0-0x00000001805CF730 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1449
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__116_0; // 0x08
		public static Action<string> __9__122_1; // 0x10

		// Constructors
		static __c(); // 0x00000001805EB2D0-0x00000001805EB340
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CloseShop_b__116_0(); // 0x00000001805EA050-0x00000001805EA190
		internal void _UpdateCurrencyCoroutine_b__122_1(string error); // 0x00000001805EA460-0x00000001805EA4D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1450
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupButtons_b__4(); // 0x00000001805EA4D0-0x00000001805EA500
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_1 // TypeDefIndex: 1451
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupButtons_b__5(); // 0x00000001805EA500-0x00000001805EA530
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_2 // TypeDefIndex: 1452
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_2(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupButtons_b__6(); // 0x00000001805EA530-0x00000001805EA560
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 1453
	{
		// Fields
		public GameObject buttonObj; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AddButtonHoverAnimation_b__0(BaseEventData data); // 0x00000001805EA560-0x00000001805EA640
		internal void _AddButtonHoverAnimation_b__1(BaseEventData data); // 0x00000001805EA640-0x00000001805EA6F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 1454
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass114_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AddCategoryButtonAnimation_b__0(BaseEventData data); // 0x00000001805EA6F0-0x00000001805EA7F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass123_0 // TypeDefIndex: 1455
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass123_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateNumberChange_b__0(float val); // 0x00000001805EA7F0-0x00000001805EA880
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 1456
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public string category; // 0x18

		// Constructors
		public __c__DisplayClass124_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SwitchCategory_b__0(); // 0x00000001805EA880-0x00000001805EA8D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass126_0 // TypeDefIndex: 1457
	{
		// Fields
		public Action onComplete; // 0x10

		// Constructors
		public __c__DisplayClass126_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FadeOutList_b__0(); // 0x0000000180410BE0-0x0000000180410C00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 1458
	{
		// Fields
		public ShopPackageDTO captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayPackagesAnimated_b__0(); // 0x00000001805EA8D0-0x00000001805EA900
	}

	[CompilerGenerated]
	private struct __c__DisplayClass138_0 // TypeDefIndex: 1459
	{
		// Fields
		public List<KeyValuePair<Sprite, string>> list; // 0x00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1460
	{
		// Fields
		public int captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass159_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayAvatarsGrid_b__0(); // 0x00000001805EA900-0x00000001805EA930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1461
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public CanvasGroup cg; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimatePageTransition_b__0(); // 0x00000001805EABC0-0x00000001805EAC50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass169_0 // TypeDefIndex: 1462
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass169_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnItemClicked_b__0(); // 0x00000001805EAC50-0x00000001805EACE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass172_0 // TypeDefIndex: 1463
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass172_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x00000001805EADD0-0x00000001805EAE60
	}

	[CompilerGenerated]
	private sealed class _DisplayAvatarsAnimated_d__152 : IEnumerator<object> // TypeDefIndex: 1464
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayAvatarsAnimated_d__152(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E5CF0-0x00000001805E6560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E6560-0x00000001805E65A0
	}

	[CompilerGenerated]
	private sealed class _DisplayCategoryWithAnimation_d__128 : IEnumerator<object> // TypeDefIndex: 1465
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string category; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCategoryWithAnimation_d__128(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E65A0-0x00000001805E67C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E67C0-0x00000001805E6800
	}

	[CompilerGenerated]
	private sealed class _DisplayItemsAnimated_d__132 : IEnumerator<object> // TypeDefIndex: 1466
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayItemsAnimated_d__132(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E6800-0x00000001805E70B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E70B0-0x00000001805E70F0
	}

	[CompilerGenerated]
	private sealed class _DisplayPackagesAnimated_d__134 : IEnumerator<object> // TypeDefIndex: 1467
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _endIndex_5__3; // 0x2C
		private int _idx_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPackagesAnimated_d__134(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E70F0-0x00000001805E7A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E7A80-0x00000001805E7AC0
	}

	[CompilerGenerated]
	private sealed class _DisplayPetsAnimated_d__149 : IEnumerator<object> // TypeDefIndex: 1468
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPetsAnimated_d__149(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E7AC0-0x00000001805E8300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8300-0x00000001805E8340
	}

	[CompilerGenerated]
	private sealed class _LoadShopDataCoroutine_d__118 : IEnumerator<object> // TypeDefIndex: 1469
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadShopDataCoroutine_d__118(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E89D0-0x00000001805E8B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8B50-0x00000001805E8B90
	}

	[CompilerGenerated]
	private sealed class _PlaySuccessEffect_d__183 : IEnumerator<object> // TypeDefIndex: 1470
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private Color _originalColor_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlaySuccessEffect_d__183(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E8B90-0x00000001805E8DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8DA0-0x00000001805E8DE0
	}

	[CompilerGenerated]
	private sealed class _PurchaseItemCoroutine_d__178 : IEnumerator<object> // TypeDefIndex: 1471
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long shopId; // 0x28
		public int quantity; // 0x30
		public ShopManager __4__this; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PurchaseItemCoroutine_d__178(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E9270-0x00000001805E9430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9430-0x00000001805E9470
	}

	[CompilerGenerated]
	private sealed class _PurchasePackageCoroutine_d__177 : IEnumerator<object> // TypeDefIndex: 1472
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long packageId; // 0x28
		public ShopManager __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PurchasePackageCoroutine_d__177(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E9470-0x00000001805E9630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9630-0x00000001805E9670
	}

	[CompilerGenerated]
	private sealed class _UpdateCurrencyCoroutine_d__122 : IEnumerator<object> // TypeDefIndex: 1473
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCurrencyCoroutine_d__122(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805EB5D0-0x00000001805EB7B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EB7B0-0x00000001805EB7F0
	}

	// Constructors
	public ShopManager(); // 0x00000001805CF0C0-0x00000001805CF6B0

	// Methods
	private int GetBalanceForCurrency(string currencyType); // 0x00000001805C7BD0-0x00000001805C7C70
	private string GetCurrencyDisplayName(string currencyType); // 0x00000001805C7C70-0x00000001805C7D20
	private void Awake(); // 0x00000001805C5880-0x00000001805C5980
	private static bool ShopAvatarTakesOver(); // 0x00000001805CC4A0-0x00000001805CC500
	private void HideAvatarTab(); // 0x00000001805C8620-0x00000001805C8730
	private void Start(); // 0x00000001805CDA80-0x00000001805CDD20
	private void OnQuantityChanged(string value); // 0x00000001805CA3D0-0x00000001805CA750
	private int GetValidQuantity(); // 0x00000001805C8470-0x00000001805C8520
	private void SetupButtons(); // 0x00000001805CBA70-0x00000001805CC4A0
	private void AddButtonHoverAnimation(GameObject buttonObj); // 0x00000001805C4DE0-0x00000001805C5110
	private void AddCategoryButtonAnimation(GameObject buttonObj); // 0x00000001805C5110-0x00000001805C5340
	public void OpenShop(); // 0x00000001805CA9E0-0x00000001805CAAB0
	public void CloseShop(); // 0x00000001805C66D0-0x00000001805C6850
	private void LoadShopData(); // 0x00000001805C8A30-0x00000001805C8B90
	[IteratorStateMachine(typeof(_LoadShopDataCoroutine_d__118))]
	private IEnumerator LoadShopDataCoroutine(int userId); // 0x00000001805C89B0-0x00000001805C8A30
	private void OnShopDataLoaded(ShopDataResponse data); // 0x00000001805CA840-0x00000001805CA9E0
	private void OnShopDataError(string error); // 0x00000001805CA750-0x00000001805CA840
	private void UpdateCurrencyDisplay(); // 0x00000001805CEE80-0x00000001805CEF50
	[IteratorStateMachine(typeof(_UpdateCurrencyCoroutine_d__122))]
	private IEnumerator UpdateCurrencyCoroutine(int userId); // 0x00000001805CEE00-0x00000001805CEE80
	private void AnimateNumberChange(UnityEngine.UI.Text textComponent, int targetValue); // 0x00000001805C54B0-0x00000001805C5680
	private void SwitchCategory(string category, bool resetPage = true /* Metadata: 0x0068D107 */); // 0x00000001805CDD20-0x00000001805CE180
	private GameObject GetCurrentListObject(); // 0x00000001805C7E40-0x00000001805C7F40
	private void FadeOutList(GameObject listObj, Action onComplete); // 0x00000001805C7800-0x00000001805C7980
	private void ShowCategoryContent(string category); // 0x00000001805CC500-0x00000001805CCAF0
	[IteratorStateMachine(typeof(_DisplayCategoryWithAnimation_d__128))]
	private IEnumerator DisplayCategoryWithAnimation(string category); // 0x00000001805C72F0-0x00000001805C7380
	private void HideAllLists(); // 0x00000001805C8520-0x00000001805C8620
	private int PackagesPerPage(); // 0x00000001805CAB30-0x00000001805CAB40
	private void ResetButtonScales(); // 0x00000001805CAF10-0x00000001805CB1A0
	[IteratorStateMachine(typeof(_DisplayItemsAnimated_d__132))]
	private IEnumerator DisplayItemsAnimated(); // 0x00000001805C7380-0x00000001805C73F0
	private void DisplayItems(); // 0x00000001805C73F0-0x00000001805C7480
	[IteratorStateMachine(typeof(_DisplayPackagesAnimated_d__134))]
	private IEnumerator DisplayPackagesAnimated(); // 0x00000001805C7480-0x00000001805C74F0
	private bool TryShowPackageChest(Transform row, ShopPackageDTO pkg); // 0x00000001805CE7C0-0x00000001805CE9F0
	private static int PackageChestTier(string currencyType); // 0x00000001805CAAB0-0x00000001805CAB30
	private void OnPackageCardClicked(ShopPackageDTO pkg); // 0x00000001805C9B50-0x00000001805C9BC0
	private List<KeyValuePair<Sprite, string>> BuildRewardList(ShopPackageDTO pkg); // 0x00000001805C5980-0x00000001805C6360
	private GameObject SpawnRewardIcon(Transform parent, Sprite icon, string amountText); // 0x00000001805CD860-0x00000001805CDA80
	private UnityEngine.UI.Text FindDeepText(Transform root, string name); // 0x00000001805C7A90-0x00000001805C7B50
	private Transform FindDeepChild(Transform root, string name); // 0x00000001805C7980-0x00000001805C7A90
	private void ShowPackageDetail(ShopPackageDTO pkg); // 0x00000001805CCE60-0x00000001805CD410
	private Sprite GetCurrencyIcon(string currencyType); // 0x00000001805C7D20-0x00000001805C7E40
	private void OnBuyPackageClicked(); // 0x00000001805C8F00-0x00000001805C92B0
	private string BuildShardNote(ShopPackageDTO pkg); // 0x00000001805C6360-0x00000001805C64C0
	private void ClosePackageDetail(); // 0x00000001805C6610-0x00000001805C66D0
	private Sprite GetItemSprite(ShopItemDTO item); // 0x00000001805C7F40-0x00000001805C82B0
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x00000001805C82B0-0x00000001805C8470
	[IteratorStateMachine(typeof(_DisplayPetsAnimated_d__149))]
	private IEnumerator DisplayPetsAnimated(); // 0x00000001805C74F0-0x00000001805C7560
	private bool TrySetupPetAnimation(Image petImage, string petID); // 0x00000001805CE180-0x00000001805CE7C0
	private void DisplayPets(); // 0x00000001805C7560-0x00000001805C75F0
	[IteratorStateMachine(typeof(_DisplayAvatarsAnimated_d__152))]
	private IEnumerator DisplayAvatarsAnimated(); // 0x00000001805C6C10-0x00000001805C6C80
	private void DisplayAvatars(); // 0x00000001805C7260-0x00000001805C72F0
	private int AvatarsPerPage(); // 0x00000001805C5840-0x00000001805C5880
	private void EnsureAvatarCells(int count); // 0x00000001805C75F0-0x00000001805C7800
	private void HideLegacyAvatarSlots(); // 0x00000001805C8730-0x00000001805C89B0
	private void DisplayAvatarsGrid(); // 0x00000001805C6C80-0x00000001805C7260
	private void SetCellPrice(PokyShopAvatarCell cell, int price, string currencyType, bool owned); // 0x00000001805CB1E0-0x00000001805CB570
	private static Color CurrencyColor(string currencyType); // 0x00000001805C6B40-0x00000001805C6C10
	private void OnAvatarClickedData(int dataIndex); // 0x00000001805C8BC0-0x00000001805C8CD0
	private void RunLocal(IEnumerator routine); // 0x00000001805CB1A0-0x00000001805CB1E0
	private void UpdatePaginationUI(); // 0x00000001805CEF50-0x00000001805CF0C0
	private void PreviousPage(); // 0x00000001805CABB0-0x00000001805CABD0
	private void NextPage(); // 0x00000001805C8B90-0x00000001805C8BC0
	private void AnimatePageTransition(int direction); // 0x00000001805C5680-0x00000001805C5840
	private void RefreshCurrentCategory(); // 0x00000001805CAD10-0x00000001805CAF10
	private void OnItemClicked(int slotIndex); // 0x00000001805C9840-0x00000001805C9B50
	private void OnPetClicked(int slotIndex); // 0x00000001805C9BC0-0x00000001805C9D40
	private void OnAvatarClicked(int slotIndex); // 0x00000001805C8CD0-0x00000001805C8F00
	private void AnimateButtonClick(GameObject btnObj); // 0x00000001805C5340-0x00000001805C54B0
	private void ShowPurchaseConfirmation(string itemName, int price, string currencyType, bool isItem = false /* Metadata: 0x0068D108 */); // 0x00000001805CD410-0x00000001805CD860
	private void ShowNotice(string message); // 0x00000001805CCC10-0x00000001805CCE60
	private void CloseNotice(); // 0x00000001805C64C0-0x00000001805C6610
	private void ConfirmPurchase(); // 0x00000001805C6850-0x00000001805C6B40
	[IteratorStateMachine(typeof(_PurchasePackageCoroutine_d__177))]
	private IEnumerator PurchasePackageCoroutine(int userId, long packageId); // 0x00000001805CAC80-0x00000001805CAD10
	[IteratorStateMachine(typeof(_PurchaseItemCoroutine_d__178))]
	private IEnumerator PurchaseItemCoroutine(int userId, long shopId, int quantity = 1 /* Metadata: 0x0068D109 */); // 0x00000001805CABD0-0x00000001805CAC80
	private void OnPurchaseSuccess(PurchaseResponse response); // 0x00000001805C9E90-0x00000001805CA3D0
	private void ShowGrantedExtras(PurchaseResponse response); // 0x00000001805CCAF0-0x00000001805CCC10
	public static string FormatVND(long amount); // 0x00000001805C7B50-0x00000001805C7BD0
	private void SetPriceWithPrefab(UnityEngine.UI.Text priceText, int price, string currencyType, ref GameObject cachedPriceObject, bool isOwned = false /* Metadata: 0x0068D10A */, string ownedText = "\u0110\u00E3 s\u1EDF h\u1EEFu" /* Metadata: 0x0068D10B */); // 0x00000001805CB570-0x00000001805CBA70
	[IteratorStateMachine(typeof(_PlaySuccessEffect_d__183))]
	private IEnumerator PlaySuccessEffect(); // 0x00000001805CAB40-0x00000001805CABB0
	private void OnPurchaseError(string error); // 0x00000001805C9D40-0x00000001805C9E90
	private void OnDisable(); // 0x00000001805C9630-0x00000001805C9840
	private void OnDestroy(); // 0x00000001805C92B0-0x00000001805C9630
	[CompilerGenerated]
	private void _SetupButtons_b__112_0(); // 0x00000001805CEBA0-0x00000001805CEBE0
	[CompilerGenerated]
	private void _SetupButtons_b__112_1(); // 0x00000001805CEBE0-0x00000001805CEC20
	[CompilerGenerated]
	private void _SetupButtons_b__112_2(); // 0x00000001805CEC20-0x00000001805CEC60
	[CompilerGenerated]
	private void _SetupButtons_b__112_3(); // 0x00000001805CEC60-0x00000001805CECA0
	[CompilerGenerated]
	private void _UpdateCurrencyCoroutine_b__122_0(UserDTO user); // 0x00000001805CECF0-0x00000001805CEE00
	[CompilerGenerated]
	internal static void _BuildRewardList_g__A_138_0(Sprite s, string a, ref __c__DisplayClass138_0 param_00001eec); // 0x00000001805CE9F0-0x00000001805CEAE0
	[CompilerGenerated]
	private void _ShowNotice_b__174_0(); // 0x00000001805CECA0-0x00000001805CECF0
	[CompilerGenerated]
	private void _CloseNotice_b__175_0(); // 0x00000001805CEAE0-0x00000001805CEB60
	[CompilerGenerated]
	private void _PlaySuccessEffect_b__183_0(Color val); // 0x00000001805CEB60-0x00000001805CEBA0
}

