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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class EnergyPurchasePopup : MonoBehaviour // TypeDefIndex: 1317
{
	// Fields
	private const string PREFAB_PATH = "UI/EnergyShop/EnergyPurchasePopup"; // Metadata: 0x0064D600
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
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1318
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public bool userDone; // 0x18
		public string error; // 0x20
		public bool shopDone; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadDataCoroutine_b__0(UserDTO u); // 0x0000000180512640-0x0000000180512670
		internal void _LoadDataCoroutine_b__1(string e); // 0x00000001804EA9A0-0x00000001804EA9C0
		internal void _LoadDataCoroutine_b__2(ShopDataResponse d); // 0x0000000180512670-0x0000000180512810
		internal void _LoadDataCoroutine_b__3(string e); // 0x0000000180512810-0x0000000180512830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 1319
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public ShopItemDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildPackRow_b__0(); // 0x00000001805128A0-0x00000001805128D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1320
	{
		// Fields
		public PurchaseResponse response; // 0x10
		public bool done; // 0x18
		public string error; // 0x20

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuyCoroutine_b__0(PurchaseResponse r); // 0x0000000180439DF0-0x0000000180439E10
		internal void _BuyCoroutine_b__1(string e); // 0x00000001804EA9A0-0x00000001804EA9C0
	}

	[CompilerGenerated]
	private sealed class _BuyCoroutine_d__34 : IEnumerator<object> // TypeDefIndex: 1321
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		public ShopItemDTO item; // 0x28
		private __c__DisplayClass34_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BuyCoroutine_d__34(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018050FF10-0x0000000180510840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180510840-0x0000000180510880
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 1322
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		private __c__DisplayClass25_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180510A10-0x0000000180510E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180510E80-0x0000000180510EC0
	}

	// Constructors
	public EnergyPurchasePopup(); // 0x00000001804F4580-0x00000001804F4640

	// Methods
	private void OnDisable(); // 0x00000001804F3630-0x00000001804F3640
	public static void Show(); // 0x00000001804F4030-0x00000001804F4290
	public static void Hide(); // 0x00000001804F3120-0x00000001804F32B0
	private void Open(); // 0x00000001804F3640-0x00000001804F3980
	private void Close(); // 0x00000001804F2820-0x00000001804F2940
	private void WireStaticButtons(); // 0x00000001804F4410-0x00000001804F4580
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__25))]
	private IEnumerator LoadDataCoroutine(); // 0x00000001804F32B0-0x00000001804F3320
	private void RefreshUI(); // 0x00000001804F3A10-0x00000001804F4030
	private void ClearRows(); // 0x00000001804F26A0-0x00000001804F2820
	private GameObject BuildPackRow(ShopItemDTO item); // 0x00000001804F0D20-0x00000001804F12C0
	private int GetBalanceForCurrency(string currency); // 0x00000001804F2EE0-0x00000001804F2FA0
	private static string GetCurrencyDisplayName(string currency); // 0x00000001804F3070-0x00000001804F3120
	private static Color GetCurrencyColor(string currency); // 0x00000001804F2FA0-0x00000001804F3070
	private static string FormatNumber(long n); // 0x00000001804F2EA0-0x00000001804F2EE0
	private void OnBuyClicked(ShopItemDTO item); // 0x00000001804F3470-0x00000001804F3630
	[IteratorStateMachine(typeof(_BuyCoroutine_d__34))]
	private IEnumerator BuyCoroutine(ShopItemDTO item); // 0x00000001804F2610-0x00000001804F26A0
	private void LoadSprites(); // 0x00000001804F3320-0x00000001804F3470
	private static Font DefaultFont(); // 0x00000001804F2DE0-0x00000001804F2EA0
	public void BuildUI(); // 0x00000001804F1860-0x00000001804F2610
	private GameObject BuildRowTemplate(Transform parent); // 0x00000001804F12C0-0x00000001804F1860
	private static GameObject CreateImage(Transform parent, string name, Sprite sprite, Color color); // 0x00000001804F2940-0x00000001804F2B00
	private static GameObject CreateText(Transform parent, string name, string content, int size, FontStyle style, Color color); // 0x00000001804F2B00-0x00000001804F2DE0
	private static RectTransform Place(GameObject go, Vector2 pos, Vector2 size); // 0x00000001804F3980-0x00000001804F3A10
	private static void StretchFull(GameObject go); // 0x00000001804F4290-0x00000001804F4390
	[CompilerGenerated]
	private void _Close_b__23_0(); // 0x00000001804F4390-0x00000001804F4410
}

