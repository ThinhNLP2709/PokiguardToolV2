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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ShopManager : MonoBehaviour // TypeDefIndex: 1833
{
	// Fields
	public const string PANEL_KEY = "PanelShop"; // Metadata: 0x005F1616
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
	private bool AvatarGridMode { get; } // 0x0000000180900A70-0x0000000180900C10 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1834
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__116_0; // 0x08
		public static Action<string> __9__122_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180909300-0x00000001809093A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseShop_b__116_0(); // 0x00000001809093A0-0x0000000180909530
		internal void _UpdateCurrencyCoroutine_b__122_1(string error); // 0x0000000180909530-0x00000001809095B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1835
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupButtons_b__4(); // 0x00000001809095B0-0x00000001809095E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_1 // TypeDefIndex: 1836
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupButtons_b__5(); // 0x00000001809095E0-0x0000000180909610
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_2 // TypeDefIndex: 1837
	{
		// Fields
		public int index; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass112_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupButtons_b__6(); // 0x0000000180909610-0x00000001809097B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 1838
	{
		// Fields
		public GameObject buttonObj; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddButtonHoverAnimation_b__0(BaseEventData data); // 0x00000001809097B0-0x00000001809098E0
		internal void _AddButtonHoverAnimation_b__1(BaseEventData data); // 0x00000001809098E0-0x00000001809099E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 1839
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass114_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddCategoryButtonAnimation_b__0(BaseEventData data); // 0x00000001809099E0-0x0000000180909B90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass123_0 // TypeDefIndex: 1840
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass123_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateNumberChange_b__0(float val); // 0x0000000180909B90-0x0000000180909BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 1841
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public string category; // 0x18

		// Constructors
		public __c__DisplayClass124_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchCategory_b__0(); // 0x0000000180909BE0-0x0000000180909C30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass126_0 // TypeDefIndex: 1842
	{
		// Fields
		public Action onComplete; // 0x10

		// Constructors
		public __c__DisplayClass126_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeOutList_b__0(); // 0x0000000180335C50-0x0000000180335C70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 1843
	{
		// Fields
		public ShopPackageDTO captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayPackagesAnimated_b__0(); // 0x0000000180909C30-0x0000000180909CB0
	}

	[CompilerGenerated]
	private struct __c__DisplayClass138_0 // TypeDefIndex: 1844
	{
		// Fields
		public List<KeyValuePair<Sprite, string>> list; // 0x00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1845
	{
		// Fields
		public int captured; // 0x10
		public ShopManager __4__this; // 0x18

		// Constructors
		public __c__DisplayClass159_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayAvatarsGrid_b__0(); // 0x0000000180909CB0-0x0000000180909CE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1846
	{
		// Fields
		public ShopManager __4__this; // 0x10
		public CanvasGroup cg; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimatePageTransition_b__0(); // 0x0000000180909CE0-0x0000000180909DD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass169_0 // TypeDefIndex: 1847
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass169_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnItemClicked_b__0(); // 0x0000000180909DD0-0x0000000180909E70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass172_0 // TypeDefIndex: 1848
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass172_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x0000000180909E70-0x0000000180909F10
	}

	[CompilerGenerated]
	private sealed class _DisplayAvatarsAnimated_d__152 : IEnumerator<object> // TypeDefIndex: 1849
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayAvatarsAnimated_d__152(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180909F10-0x000000018090A970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090A970-0x000000018090A9B0
	}

	[CompilerGenerated]
	private sealed class _DisplayCategoryWithAnimation_d__128 : IEnumerator<object> // TypeDefIndex: 1850
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string category; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCategoryWithAnimation_d__128(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090A9B0-0x000000018090ACA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090ACA0-0x000000018090ACE0
	}

	[CompilerGenerated]
	private sealed class _DisplayItemsAnimated_d__132 : IEnumerator<object> // TypeDefIndex: 1851
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayItemsAnimated_d__132(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090ACE0-0x000000018090B760
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090B760-0x000000018090B7A0
	}

	[CompilerGenerated]
	private sealed class _DisplayPackagesAnimated_d__134 : IEnumerator<object> // TypeDefIndex: 1852
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _endIndex_5__3; // 0x2C
		private int _idx_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPackagesAnimated_d__134(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090B7A0-0x000000018090C470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090C470-0x000000018090C4B0
	}

	[CompilerGenerated]
	private sealed class _DisplayPetsAnimated_d__149 : IEnumerator<object> // TypeDefIndex: 1853
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private int _startIndex_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayPetsAnimated_d__149(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090C4B0-0x000000018090CFE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090CFE0-0x000000018090D020
	}

	[CompilerGenerated]
	private sealed class _LoadShopDataCoroutine_d__118 : IEnumerator<object> // TypeDefIndex: 1854
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadShopDataCoroutine_d__118(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090D020-0x000000018090D230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090D230-0x000000018090D270
	}

	[CompilerGenerated]
	private sealed class _PlaySuccessEffect_d__183 : IEnumerator<object> // TypeDefIndex: 1855
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ShopManager __4__this; // 0x20
		private Color _originalColor_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlaySuccessEffect_d__183(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090D270-0x000000018090D550
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090D550-0x000000018090D590
	}

	[CompilerGenerated]
	private sealed class _PurchaseItemCoroutine_d__178 : IEnumerator<object> // TypeDefIndex: 1856
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long shopId; // 0x28
		public int quantity; // 0x30
		public ShopManager __4__this; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PurchaseItemCoroutine_d__178(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090D590-0x000000018090D7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090D7F0-0x000000018090D830
	}

	[CompilerGenerated]
	private sealed class _PurchasePackageCoroutine_d__177 : IEnumerator<object> // TypeDefIndex: 1857
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long packageId; // 0x28
		public ShopManager __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PurchasePackageCoroutine_d__177(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090D830-0x000000018090DAF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090DAF0-0x000000018090DB30
	}

	[CompilerGenerated]
	private sealed class _UpdateCurrencyCoroutine_d__122 : IEnumerator<object> // TypeDefIndex: 1858
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ShopManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCurrencyCoroutine_d__122(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018090DB30-0x000000018090DE00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018090DE00-0x000000018090DE40
	}

	// Constructors
	public ShopManager(); // 0x00000001809078E0-0x0000000180908730

	// Methods
	private int GetBalanceForCurrency(string currencyType); // 0x00000001808F6A80-0x00000001808F6B70
	private string GetCurrencyDisplayName(string currencyType); // 0x00000001808F6B70-0x00000001808F6C90
	private void Awake(); // 0x00000001808F6C90-0x00000001808F7030
	private static bool ShopAvatarTakesOver(); // 0x00000001808F7030-0x00000001808F70A0
	private void HideAvatarTab(); // 0x00000001808F70A0-0x00000001808F7360
	private void Start(); // 0x00000001808F7360-0x00000001808F7750
	private void OnQuantityChanged(string value); // 0x00000001808F7750-0x00000001808F7E40
	private int GetValidQuantity(); // 0x00000001808F7E40-0x00000001808F8000
	private void SetupButtons(); // 0x00000001808F8000-0x00000001808F91E0
	private void AddButtonHoverAnimation(GameObject buttonObj); // 0x00000001808F91E0-0x00000001808F96B0
	private void AddCategoryButtonAnimation(GameObject buttonObj); // 0x00000001808F96B0-0x00000001808F9A00
	public void OpenShop(); // 0x00000001808F9A00-0x00000001808F9B60
	public void CloseShop(); // 0x00000001808F9B60-0x00000001808F9DD0
	private void LoadShopData(); // 0x00000001808F9DD0-0x00000001808F9FC0
	[IteratorStateMachine(typeof(_LoadShopDataCoroutine_d__118))]
	private IEnumerator LoadShopDataCoroutine(int userId); // 0x00000001808F9FC0-0x00000001808FA070
	private void OnShopDataLoaded(ShopDataResponse data); // 0x00000001808FA070-0x00000001808FA300
	private void OnShopDataError(string error); // 0x00000001808FA300-0x00000001808FA400
	private void UpdateCurrencyDisplay(); // 0x00000001808FA400-0x00000001808FA540
	[IteratorStateMachine(typeof(_UpdateCurrencyCoroutine_d__122))]
	private IEnumerator UpdateCurrencyCoroutine(int userId); // 0x00000001808FA540-0x00000001808FA5F0
	private void AnimateNumberChange(UnityEngine.UI.Text textComponent, int targetValue); // 0x00000001808FA5F0-0x00000001808FA910
	private void SwitchCategory(string category, bool resetPage = true /* Metadata: 0x005F1602 */); // 0x00000001808FA910-0x00000001808FACB0
	private GameObject GetCurrentListObject(); // 0x00000001808FACB0-0x00000001808FAE70
	private void FadeOutList(GameObject listObj, Action onComplete); // 0x00000001808FAE70-0x00000001808FB0D0
	private void ShowCategoryContent(string category); // 0x00000001808FB0D0-0x00000001808FBB10
	[IteratorStateMachine(typeof(_DisplayCategoryWithAnimation_d__128))]
	private IEnumerator DisplayCategoryWithAnimation(string category); // 0x00000001808FBB10-0x00000001808FBC20
	private void HideAllLists(); // 0x00000001808FBC20-0x00000001808FC020
	private int PackagesPerPage(); // 0x00000001808FC020-0x00000001808FC030
	private void ResetButtonScales(); // 0x00000001808FC030-0x00000001808FC5C0
	[IteratorStateMachine(typeof(_DisplayItemsAnimated_d__132))]
	private IEnumerator DisplayItemsAnimated(); // 0x00000001808FC5C0-0x00000001808FC660
	private void DisplayItems(); // 0x00000001808FC660-0x00000001808FC6E0
	[IteratorStateMachine(typeof(_DisplayPackagesAnimated_d__134))]
	private IEnumerator DisplayPackagesAnimated(); // 0x00000001808FC6E0-0x00000001808FC780
	private bool TryShowPackageChest(Transform row, ShopPackageDTO pkg); // 0x00000001808FC780-0x00000001808FCB00
	private static int PackageChestTier(string currencyType); // 0x00000001808FCB00-0x00000001808FCBF0
	private void OnPackageCardClicked(ShopPackageDTO pkg); // 0x00000001808FCBF0-0x00000001808FCC60
	private List<KeyValuePair<Sprite, string>> BuildRewardList(ShopPackageDTO pkg); // 0x00000001808FCC60-0x00000001808FD7B0
	private GameObject SpawnRewardIcon(Transform parent, Sprite icon, string amountText); // 0x00000001808FD7B0-0x00000001808FDD70
	private UnityEngine.UI.Text FindDeepText(Transform root, string name); // 0x00000001808FDD70-0x00000001808FDEB0
	private Transform FindDeepChild(Transform root, string name); // 0x00000001808FDEB0-0x00000001808FE0C0
	private void ShowPackageDetail(ShopPackageDTO pkg); // 0x00000001808FE0C0-0x00000001808FEC60
	private Sprite GetCurrencyIcon(string currencyType); // 0x00000001808FEC60-0x00000001808FEED0
	private void OnBuyPackageClicked(); // 0x00000001808FEED0-0x00000001808FF230
	private string BuildShardNote(ShopPackageDTO pkg); // 0x00000001808FF230-0x00000001808FF420
	private void ClosePackageDetail(); // 0x00000001808FF420-0x00000001808FF5A0
	private Sprite GetItemSprite(ShopItemDTO item); // 0x00000001808FF5A0-0x00000001808FFA80
	private Sprite GetStoneSpriteByTypeAndLevel(string elementType, int level); // 0x00000001808FFA80-0x00000001808FFD30
	[IteratorStateMachine(typeof(_DisplayPetsAnimated_d__149))]
	private IEnumerator DisplayPetsAnimated(); // 0x00000001808FFD30-0x00000001808FFDD0
	private bool TrySetupPetAnimation(Image petImage, string petID); // 0x00000001808FFDD0-0x00000001809008D0
	private void DisplayPets(); // 0x00000001809008D0-0x0000000180900950
	[IteratorStateMachine(typeof(_DisplayAvatarsAnimated_d__152))]
	private IEnumerator DisplayAvatarsAnimated(); // 0x0000000180900950-0x00000001809009F0
	private void DisplayAvatars(); // 0x00000001809009F0-0x0000000180900A70
	private int AvatarsPerPage(); // 0x0000000180900C10-0x0000000180900C50
	private void EnsureAvatarCells(int count); // 0x0000000180900C50-0x0000000180900F50
	private void HideLegacyAvatarSlots(); // 0x0000000180900F50-0x0000000180901370
	private void DisplayAvatarsGrid(); // 0x0000000180901370-0x0000000180901B80
	private void SetCellPrice(PokyShopAvatarCell cell, int price, string currencyType, bool owned); // 0x0000000180901B80-0x00000001809022F0
	private static Color CurrencyColor(string currencyType); // 0x00000001809022F0-0x0000000180902400
	private void OnAvatarClickedData(int dataIndex); // 0x0000000180902400-0x00000001809025B0
	private void RunLocal(IEnumerator routine); // 0x00000001809025B0-0x0000000180902630
	private void UpdatePaginationUI(); // 0x0000000180902630-0x0000000180902940
	private void PreviousPage(); // 0x0000000180902940-0x0000000180902960
	private void NextPage(); // 0x0000000180902960-0x0000000180902990
	private void AnimatePageTransition(int direction); // 0x0000000180902990-0x0000000180902D20
	private void RefreshCurrentCategory(); // 0x0000000180902D20-0x0000000180902F50
	private void OnItemClicked(int slotIndex); // 0x0000000180902F50-0x00000001809033B0
	private void OnPetClicked(int slotIndex); // 0x00000001809033B0-0x00000001809035C0
	private void OnAvatarClicked(int slotIndex); // 0x00000001809035C0-0x0000000180903750
	private void AnimateButtonClick(GameObject btnObj); // 0x0000000180903750-0x0000000180903950
	private void ShowPurchaseConfirmation(string itemName, int price, string currencyType, bool isItem = false /* Metadata: 0x005F1603 */); // 0x0000000180903950-0x0000000180904300
	private void ShowNotice(string message); // 0x0000000180904300-0x00000001809048B0
	private void CloseNotice(); // 0x00000001809048B0-0x0000000180904B20
	private void ConfirmPurchase(); // 0x0000000180904B20-0x0000000180904FB0
	[IteratorStateMachine(typeof(_PurchasePackageCoroutine_d__177))]
	private IEnumerator PurchasePackageCoroutine(int userId, long packageId); // 0x0000000180904FB0-0x0000000180905070
	[IteratorStateMachine(typeof(_PurchaseItemCoroutine_d__178))]
	private IEnumerator PurchaseItemCoroutine(int userId, long shopId, int quantity = 1 /* Metadata: 0x005F1604 */); // 0x0000000180905070-0x0000000180905140
	private void OnPurchaseSuccess(PurchaseResponse response); // 0x0000000180905140-0x0000000180905D10
	private void ShowGrantedExtras(PurchaseResponse response); // 0x0000000180905D10-0x0000000180905E30
	public static string FormatVND(long amount); // 0x0000000180905E30-0x0000000180905F40
	private void SetPriceWithPrefab(UnityEngine.UI.Text priceText, int price, string currencyType, ref GameObject cachedPriceObject, bool isOwned = false /* Metadata: 0x005F1605 */, string ownedText = "\u0110\u00E3 s\u1EDF h\u1EEFu" /* Metadata: 0x005F1606 */); // 0x0000000180905F40-0x0000000180906920
	[IteratorStateMachine(typeof(_PlaySuccessEffect_d__183))]
	private IEnumerator PlaySuccessEffect(); // 0x0000000180906920-0x00000001809069C0
	private void OnPurchaseError(string error); // 0x00000001809069C0-0x0000000180906BE0
	private void OnDisable(); // 0x0000000180906BE0-0x00000001809071D0
	private void OnDestroy(); // 0x00000001809071D0-0x00000001809078E0
	[CompilerGenerated]
	private void _SetupButtons_b__112_0(); // 0x0000000180908730-0x0000000180908780
	[CompilerGenerated]
	private void _SetupButtons_b__112_1(); // 0x0000000180908780-0x00000001809087D0
	[CompilerGenerated]
	private void _SetupButtons_b__112_2(); // 0x00000001809087D0-0x0000000180908820
	[CompilerGenerated]
	private void _SetupButtons_b__112_3(); // 0x0000000180908820-0x0000000180908870
	[CompilerGenerated]
	private void _UpdateCurrencyCoroutine_b__122_0(UserDTO user); // 0x0000000180908870-0x0000000180908AD0
	[CompilerGenerated]
	internal static void _BuildRewardList_g__A_138_0(Sprite s, string a, ref __c__DisplayClass138_0 param_00002938); // 0x0000000180908AD0-0x0000000180908C10
	[CompilerGenerated]
	private void _ShowNotice_b__174_0(); // 0x0000000180908C10-0x0000000180908CC0
	[CompilerGenerated]
	private void _CloseNotice_b__175_0(); // 0x0000000180908CC0-0x0000000180908E10
	[CompilerGenerated]
	private void _PlaySuccessEffect_b__183_0(Color val); // 0x0000000180908E10-0x0000000180909240
}

