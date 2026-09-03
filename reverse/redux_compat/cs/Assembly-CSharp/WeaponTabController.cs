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

[DisallowMultipleComponent]
public class WeaponTabController : MonoBehaviour // TypeDefIndex: 889
{
	// Fields
	[Header("Root")]
	public GameObject panelWeapon; // 0x20
	[Header("Danh s\u00E1ch kho (grid) \u2014 itemTemplate PH\u1EA2I inactive")]
	public Transform gridContent; // 0x28
	public GameObject itemTemplate; // 0x30
	[Header("Ph\u00E2n trang")]
	public Button btnPrevPage; // 0x38
	public Button btnNextPage; // 0x40
	public UnityEngine.UI.Text txtPageInfo; // 0x48
	[Header("M\u1EA3nh v\u0169 kh\u00ED")]
	public UnityEngine.UI.Text txtShardCount; // 0x50
	public Image imgShardIcon; // 0x58
	[Header("Khung chi ti\u1EBFt")]
	public Image imgDetailIcon; // 0x60
	public Image imgDetailFrame; // 0x68
	public UnityEngine.UI.Text txtDetailName; // 0x70
	public UnityEngine.UI.Text txtDetailRarity; // 0x78
	public UnityEngine.UI.Text txtDetailStar; // 0x80
	public UnityEngine.UI.Text txtDetailStats; // 0x88
	public UnityEngine.UI.Text txtDetailPower; // 0x90
	public UnityEngine.UI.Text txtDetailSource; // 0x98
	public UnityEngine.UI.Text txtDetailElement; // 0xA0
	[Header("N\u00FAt thao t\u00E1c")]
	public Button btnEquip; // 0xA8
	public UnityEngine.UI.Text txtEquipLabel; // 0xB0
	public Button btnUpgrade; // 0xB8
	public UnityEngine.UI.Text txtUpgradeLabel; // 0xC0
	public Button btnSalvage; // 0xC8
	public UnityEngine.UI.Text txtSalvageLabel; // 0xD0
	private const int PAGE_SIZE = 8; // Metadata: 0x0064CD07
	private const float SALVAGE_CONFIRM_SEC = 4f; // Metadata: 0x0064CD08
	private static readonly Color ColorAtk; // 0x00
	private static readonly Color ColorHp; // 0x10
	private static readonly Color ColorMana; // 0x20
	private static readonly Color ColorCrit; // 0x30
	private static readonly Color ColorPower; // 0x40
	private static readonly Color ColorStar; // 0x50
	private static readonly Color ColorShard; // 0x60
	private static readonly Color ColorGood; // 0x70
	private static readonly Color ColorBad; // 0x80
	private static readonly Color ColorWarn; // 0x90
	private static readonly Color ColorMuted; // 0xA0
	private int _userId; // 0xD8
	private int _page; // 0xDC
	private int _totalPages; // 0xE0
	private int _shardCount; // 0xE4
	private long _equippedId; // 0xE8
	private bool _busy; // 0xF0
	private readonly List<UserWeaponDTO> _weapons; // 0xF8
	private readonly List<GameObject> _spawned; // 0x100
	private UserWeaponDTO _selected; // 0x108
	private bool _salvagePending; // 0x110
	private float _salvagePendingUntil; // 0x114

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 890
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__52_0; // 0x08
		public static Action<string> __9__62_1; // 0x10
		public static Action<string> __9__64_1; // 0x18
		public static Action<string> __9__66_1; // 0x20

		// Constructors
		static __c(); // 0x0000000180458CB0-0x0000000180458D20
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadListCo_b__52_0(string err); // 0x0000000180457DD0-0x0000000180457E40
		internal void _EquipCo_b__62_1(string err); // 0x0000000180457D20-0x0000000180457DD0
		internal void _UpgradeCo_b__64_1(string err); // 0x0000000180457EF0-0x0000000180457FA0
		internal void _SalvageCo_b__66_1(string err); // 0x0000000180457E40-0x0000000180457EF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 891
	{
		// Fields
		public WeaponTabController __4__this; // 0x10
		public UserWeaponDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BindItem_b__0(); // 0x0000000180458AB0-0x0000000180458AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass62_0 // TypeDefIndex: 892
	{
		// Fields
		public WeaponTabController __4__this; // 0x10
		public bool unequip; // 0x18

		// Constructors
		public __c__DisplayClass62_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EquipCo_b__0(WeaponActionResponse resp); // 0x0000000180458AE0-0x0000000180458CB0
	}

	[CompilerGenerated]
	private sealed class _EquipCo_d__62 : IEnumerator<object> // TypeDefIndex: 893
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTabController __4__this; // 0x20
		public bool unequip; // 0x28
		public long userWeaponId; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EquipCo_d__62(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180455090-0x0000000180455390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180455390-0x00000001804553D0
	}

	[CompilerGenerated]
	private sealed class _LoadListCo_d__52 : IEnumerator<object> // TypeDefIndex: 894
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTabController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadListCo_d__52(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804556B0-0x00000001804558F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804558F0-0x0000000180455930
	}

	[CompilerGenerated]
	private sealed class _SalvageCo_d__66 : IEnumerator<object> // TypeDefIndex: 895
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTabController __4__this; // 0x20
		public long userWeaponId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SalvageCo_d__66(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180456070-0x0000000180456310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180456310-0x0000000180456350
	}

	[CompilerGenerated]
	private sealed class _UpgradeCo_d__64 : IEnumerator<object> // TypeDefIndex: 896
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTabController __4__this; // 0x20
		public long userWeaponId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCo_d__64(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180458D20-0x0000000180458FC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180458FC0-0x0000000180459000
	}

	// Constructors
	public WeaponTabController(); // 0x000000018045DC40-0x000000018045DD20
	static WeaponTabController(); // 0x000000018045DAF0-0x000000018045DC40

	// Methods
	private static string Hex(Color c); // 0x000000018045B170-0x000000018045B1D0
	private void Awake(); // 0x000000018045A010-0x000000018045A450
	public void OpenTab(); // 0x000000018045BCD0-0x000000018045BD70
	public void CloseTab(); // 0x000000018045AF30-0x000000018045AFC0
	private void Reload(); // 0x000000018045BD70-0x000000018045BE80
	[IteratorStateMachine(typeof(_LoadListCo_d__52))]
	private IEnumerator LoadListCo(); // 0x000000018045B1D0-0x000000018045B240
	private void OnListLoaded(WeaponListResponse resp); // 0x000000018045B430-0x000000018045B8E0
	private void RenderGrid(); // 0x000000018045BE80-0x000000018045C210
	private void BindItem(GameObject go, UserWeaponDTO w); // 0x000000018045A450-0x000000018045AEE0
	private void ShowDetail(UserWeaponDTO w); // 0x000000018045C2C0-0x000000018045CD30
	private void UpdateActionButtons(); // 0x000000018045D0B0-0x000000018045D7B0
	private void UpdateShardText(); // 0x000000018045D910-0x000000018045DA70
	private void UpdatePageUI(); // 0x000000018045D7B0-0x000000018045D910
	private void ChangePage(int delta); // 0x000000018045AEE0-0x000000018045AF30
	private void OnEquipClicked(); // 0x000000018045B320-0x000000018045B430
	[IteratorStateMachine(typeof(_EquipCo_d__62))]
	private IEnumerator EquipCo(long userWeaponId, bool unequip); // 0x000000018045AFC0-0x000000018045B050
	private void OnUpgradeClicked(); // 0x000000018045BAD0-0x000000018045BCD0
	[IteratorStateMachine(typeof(_UpgradeCo_d__64))]
	private IEnumerator UpgradeCo(long userWeaponId); // 0x000000018045DA70-0x000000018045DAF0
	private void OnSalvageClicked(); // 0x000000018045B8E0-0x000000018045BAD0
	[IteratorStateMachine(typeof(_SalvageCo_d__66))]
	private IEnumerator SalvageCo(long userWeaponId); // 0x000000018045C230-0x000000018045C2B0
	private void ResetSalvageConfirm(); // 0x000000018045C210-0x000000018045C230
	private void SetBusy(bool busy); // 0x000000018045C2B0-0x000000018045C2C0
	private void NotifyEquipChanged(int imageId, string rarity, int star); // 0x000000018045B240-0x000000018045B300
	private void OnDisable(); // 0x000000018045B300-0x000000018045B320
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static GameObject FindDeepGo(Transform root, string nodeName); // 0x000000018045B050-0x000000018045B170
	[CompilerGenerated]
	private void _Awake_b__48_0(); // 0x000000018045CD30-0x000000018045CD70
	[CompilerGenerated]
	private void _Awake_b__48_1(); // 0x000000018045CD70-0x000000018045CDB0
	[CompilerGenerated]
	private void _UpgradeCo_b__64_0(WeaponUpgradeResponse resp); // 0x000000018045CEE0-0x000000018045D0B0
	[CompilerGenerated]
	private void _SalvageCo_b__66_0(WeaponSalvageResponse resp); // 0x000000018045CDB0-0x000000018045CEE0
}

