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

public class EnergyPurchasePopup : MonoBehaviour // TypeDefIndex: 1551
{
	// Fields
	private const string PREFAB_PATH = "UI/EnergyShop/EnergyPurchasePopup"; // Metadata: 0x0068D421
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
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1552
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public bool userDone; // 0x18
		public string error; // 0x20
		public bool shopDone; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadDataCoroutine_b__0(UserDTO u); // 0x0000000180609D40-0x0000000180609D70
		internal void _LoadDataCoroutine_b__1(string e); // 0x00000001805EAF20-0x00000001805EAF40
		internal void _LoadDataCoroutine_b__2(ShopDataResponse d); // 0x0000000180609D70-0x0000000180609F10
		internal void _LoadDataCoroutine_b__3(string e); // 0x0000000180609F10-0x0000000180609F30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 1553
	{
		// Fields
		public EnergyPurchasePopup __4__this; // 0x10
		public ShopItemDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildPackRow_b__0(); // 0x000000018060A1E0-0x000000018060A210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1554
	{
		// Fields
		public PurchaseResponse response; // 0x10
		public bool done; // 0x18
		public string error; // 0x20

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuyCoroutine_b__0(PurchaseResponse r); // 0x00000001804F8C00-0x00000001804F8C20
		internal void _BuyCoroutine_b__1(string e); // 0x00000001805EAF20-0x00000001805EAF40
	}

	[CompilerGenerated]
	private sealed class _BuyCoroutine_d__34 : IEnumerator<object> // TypeDefIndex: 1555
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		public ShopItemDTO item; // 0x28
		private __c__DisplayClass34_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BuyCoroutine_d__34(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180604570-0x0000000180604EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180604EA0-0x0000000180604EE0
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 1556
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyPurchasePopup __4__this; // 0x20
		private __c__DisplayClass25_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180605890-0x0000000180605D00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180605D00-0x0000000180605D40
	}

	// Constructors
	public EnergyPurchasePopup(); // 0x00000001805F5FE0-0x00000001805F60A0

	// Methods
	private void OnDisable(); // 0x00000001805F5090-0x00000001805F50A0
	public static void Show(); // 0x00000001805F5A90-0x00000001805F5CF0
	public static void Hide(); // 0x00000001805F4B80-0x00000001805F4D10
	private void Open(); // 0x00000001805F50A0-0x00000001805F53E0
	private void Close(); // 0x00000001805F4280-0x00000001805F43A0
	private void WireStaticButtons(); // 0x00000001805F5E70-0x00000001805F5FE0
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__25))]
	private IEnumerator LoadDataCoroutine(); // 0x00000001805F4D10-0x00000001805F4D80
	private void RefreshUI(); // 0x00000001805F5470-0x00000001805F5A90
	private void ClearRows(); // 0x00000001805F4100-0x00000001805F4280
	private GameObject BuildPackRow(ShopItemDTO item); // 0x00000001805F2780-0x00000001805F2D20
	private int GetBalanceForCurrency(string currency); // 0x00000001805F4940-0x00000001805F4A00
	private static string GetCurrencyDisplayName(string currency); // 0x00000001805F4AD0-0x00000001805F4B80
	private static Color GetCurrencyColor(string currency); // 0x00000001805F4A00-0x00000001805F4AD0
	private static string FormatNumber(long n); // 0x00000001805F4900-0x00000001805F4940
	private void OnBuyClicked(ShopItemDTO item); // 0x00000001805F4ED0-0x00000001805F5090
	[IteratorStateMachine(typeof(_BuyCoroutine_d__34))]
	private IEnumerator BuyCoroutine(ShopItemDTO item); // 0x00000001805F4070-0x00000001805F4100
	private void LoadSprites(); // 0x00000001805F4D80-0x00000001805F4ED0
	private static Font DefaultFont(); // 0x00000001805F4840-0x00000001805F4900
	public void BuildUI(); // 0x00000001805F32C0-0x00000001805F4070
	private GameObject BuildRowTemplate(Transform parent); // 0x00000001805F2D20-0x00000001805F32C0
	private static GameObject CreateImage(Transform parent, string name, Sprite sprite, Color color); // 0x00000001805F43A0-0x00000001805F4560
	private static GameObject CreateText(Transform parent, string name, string content, int size, FontStyle style, Color color); // 0x00000001805F4560-0x00000001805F4840
	private static RectTransform Place(GameObject go, Vector2 pos, Vector2 size); // 0x00000001805F53E0-0x00000001805F5470
	private static void StretchFull(GameObject go); // 0x00000001805F5CF0-0x00000001805F5DF0
	[CompilerGenerated]
	private void _Close_b__23_0(); // 0x00000001805F5DF0-0x00000001805F5E70
}

