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
public class WeaponTooltip : MonoBehaviour // TypeDefIndex: 897
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponTooltip"; // Metadata: 0x0064CD0C
	public const string PREFAB_PATH_POKY = "Prefabs/UI/WeaponTooltip_Poky"; // Metadata: 0x0064CD25
	public const string SKIN_KEY = "WeaponTooltip"; // Metadata: 0x0064CD43
	[SerializeField]
	private RectTransform panel; // 0x20
	[SerializeField]
	private Button btnBlocker; // 0x28
	[SerializeField]
	private Button btnClose; // 0x30
	[SerializeField]
	private Image imgIcon; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtRarity; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtStar; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtStats; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtElement; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtSource; // 0x70
	private static WeaponTooltip _instance; // 0x00
	private CanvasGroup _panelGroup; // 0x78
	private Coroutine _fetchCo; // 0x80
	private bool _wired; // 0x88

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 898
	{
		// Fields
		public WeaponTooltip __4__this; // 0x10
		public long targetUserId; // 0x18

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FetchEquipped_b__0(EquippedWeaponResponse resp); // 0x00000001804580F0-0x0000000180458200
		internal void _FetchEquipped_b__1(string err); // 0x0000000180458200-0x0000000180458310
	}

	[CompilerGenerated]
	private sealed class _FetchEquipped_d__31 : IEnumerator<object> // TypeDefIndex: 899
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTooltip __4__this; // 0x20
		public long targetUserId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchEquipped_d__31(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804553D0-0x0000000180455670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180455670-0x00000001804556B0
	}

	// Constructors
	public WeaponTooltip(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static void Show(RectTransform anchor, UserWeaponDTO data); // 0x0000000180460DD0-0x0000000180460F40
	public static void Show(RectTransform anchor, EquippedWeaponResponse data); // 0x0000000180460F40-0x00000001804610A0
	public static void ShowForUser(RectTransform anchor, long targetUserId); // 0x0000000180460C30-0x0000000180460DD0
	public static void HideTooltip(); // 0x0000000180460090-0x0000000180460250
	private static WeaponTooltip Resolve(); // 0x0000000180460950-0x0000000180460C30
	private void Awake(); // 0x000000018045DD20-0x000000018045DDD0
	private void OnDestroy(); // 0x0000000180460250-0x0000000180460300
	private void EnsureWired(); // 0x000000018045F170-0x000000018045F7A0
	private void Present(RectTransform anchor); // 0x0000000180460840-0x0000000180460950
	private void ClosePanel(); // 0x000000018045EB50-0x000000018045EC90
	private void OnDisable(); // 0x0000000180460300-0x00000001804603D0
	private void PositionNear(RectTransform anchor); // 0x00000001804603D0-0x0000000180460840
	private void Fill(string name, string rarity, int star, int imageId, int atk, int hp, int mana, int crit, int resist, int rate, string element, int power, string source); // 0x000000018045F820-0x000000018045FFE0
	[IteratorStateMachine(typeof(_FetchEquipped_d__31))]
	private IEnumerator FetchEquipped(long targetUserId); // 0x000000018045F7A0-0x000000018045F820
	private static string Summarize(string name, string rarity, int star, int power); // 0x00000001804610A0-0x00000001804612E0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x000000018045DDD0-0x000000018045EB50
	private static GameObject CreateChild(Transform parent, string name); // 0x000000018045EC90-0x000000018045EE00
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018045FFE0-0x0000000180460090
	private static void CreateIcon(Transform parent, string name, Vector2 pos, Vector2 size); // 0x000000018045EE00-0x000000018045EF80
	private static UnityEngine.UI.Text CreateLabel(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta); // 0x000000018045EF80-0x000000018045F170
	[CompilerGenerated]
	private void _ClosePanel_b__27_0(); // 0x00000001804612E0-0x0000000180461360
}

