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

public class EnergyPurchasePopup : MonoBehaviour // TypeDefIndex: 1936
{
	// Fields
	private const string PREFAB_PATH = "UI/EnergyShop/EnergyPurchasePopup"; // Metadata: 0x005F16B8
	private static EnergyPurchasePopup _instance; // 0x00
	[Header("Refs (prefab t\u1EF1 wire \u2014 ch\u1EC9nh layout tho\u1EA3i m\u00E1i, gi\u1EEF nguy\u00EAn t\u00EAn field)")]
	public GameObject canvasRoot; // 0x20
	public GameObject panel; // 0x28
	public Button backdropButton; // 0x30
	public Button btnClose; // 0x38
	public UnityEngine.UI.Text txtEnergyBalance; // 0x40
	public UnityEngine.UI.Text txtMoneyBalance; // 0x48
	public UnityEngine.UI.Text txtMessage; // 0x50
	public Transform rowsParent; // 0x58
	public GameObject rowTemplate; // 0x60
	private UserDTO _user; // 0x68
	private readonly List<ShopItemDTO> _energyItems; // 0x70
	private readonly List<GameObject> _rows; // 0x78
	private bool _isBuying; // 0x80
	private Sprite _spPopupBg; // 0x88
	private Sprite _spBtnClose; // 0x90
	private Sprite _spBtnBuy; // 0x98
	private Sprite _spEnergy; // 0xA0
	private static Font _gameFont; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1937
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public bool userDone; // 0x18
		public string error; // 0x20
		public bool shopDone; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadDataCoroutine_b__0(UserDTO u); // 0x000000018093E5B0-0x000000018093E630
		internal void _LoadDataCoroutine_b__1(string e); // 0x000000018091E390-0x000000018091E3F0
		internal void _LoadDataCoroutine_b__2(ShopDataResponse d); // 0x000000018093E630-0x000000018093E840
		internal void _LoadDataCoroutine_b__3(string e); // 0x000000018093E840-0x000000018093E8A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 1938
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public ShopItemDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildPackRow_b__0(); // 0x000000018093E8A0-0x000000018093E8D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1939
	{
		// Fields
		public PurchaseResponse response; // 0x10
		public bool done; // 0x18
		public string error; // 0x20

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuyCoroutine_b__0(PurchaseResponse r); // 0x000000018076F420-0x000000018076F480
		internal void _BuyCoroutine_b__1(string e); // 0x000000018091E390-0x000000018091E3F0
	}

	[CompilerGenerated]
	private sealed class _BuyCoroutine_d__34 : IEnumerator<object> // TypeDefIndex: 1940
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		public ShopItemDTO item; // 0x28
		private __c__DisplayClass34_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BuyCoroutine_d__34(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018093E8D0-0x000000018093F7A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018093F7A0-0x000000018093F7E0
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 1941
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		private __c__DisplayClass25_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018093F7E0-0x000000018093FEF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018093FEF0-0x000000018093FF30
	}

	// Constructors
	public EnergyPurchasePopup(); // 0x000000018093E2C0-0x000000018093E470

	// Methods
	private void OnDisable(); // 0x0000000180938F30-0x0000000180938F40
	public static void Show(); // 0x0000000180938F40-0x0000000180939430
	public static void Hide(); // 0x0000000180939430-0x0000000180939550
	private void Open(); // 0x0000000180939550-0x0000000180939960
	private void Close(); // 0x0000000180939960-0x0000000180939BE0
	private void WireStaticButtons(); // 0x0000000180939BE0-0x0000000180939E70
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__25))]
	private IEnumerator LoadDataCoroutine(); // 0x0000000180939E70-0x0000000180939F10
	private void RefreshUI(); // 0x0000000180939F10-0x000000018093A590
	private void ClearRows(); // 0x000000018093A590-0x000000018093A7F0
	private GameObject BuildPackRow(ShopItemDTO item); // 0x000000018093A7F0-0x000000018093B3A0
	private int GetBalanceForCurrency(string currency); // 0x000000018093B3A0-0x000000018093B4D0
	private static string GetCurrencyDisplayName(string currency); // 0x000000018093B4D0-0x000000018093B5F0
	private static Color GetCurrencyColor(string currency); // 0x000000018093B5F0-0x000000018093B710
	private static string FormatNumber(long n); // 0x000000018093B710-0x000000018093B7E0
	private void OnBuyClicked(ShopItemDTO item); // 0x000000018093B7E0-0x000000018093BAE0
	[IteratorStateMachine(typeof(_BuyCoroutine_d__34))]
	private IEnumerator BuyCoroutine(ShopItemDTO item); // 0x000000018093BAE0-0x000000018093BBF0
	private void LoadSprites(); // 0x000000018093BBF0-0x000000018093BEE0
	private static Font DefaultFont(); // 0x000000018093BEE0-0x000000018093C060
	public void BuildUI(); // 0x000000018093C060-0x000000018093D2C0
	private GameObject BuildRowTemplate(Transform parent); // 0x000000018093D2C0-0x000000018093D9A0
	private static GameObject CreateImage(Transform parent, string name, Sprite sprite, Color color); // 0x000000018093D9A0-0x000000018093DBE0
	private static GameObject CreateText(Transform parent, string name, string content, int size, FontStyle style, Color color); // 0x000000018093DBE0-0x000000018093E110
	private static RectTransform Place(GameObject go, Vector2 pos, Vector2 size); // 0x000000018093E110-0x000000018093E1B0
	private static void StretchFull(GameObject go); // 0x000000018093E1B0-0x000000018093E2C0
	[CompilerGenerated]
	private void _Close_b__23_0(); // 0x000000018093E470-0x000000018093E5B0
}

