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

[DisallowMultipleComponent]
public class WeaponTooltip : MonoBehaviour // TypeDefIndex: 1091
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponTooltip"; // Metadata: 0x0068C4A5
	public const string PREFAB_PATH_POKY = "Prefabs/UI/WeaponTooltip_Poky"; // Metadata: 0x0068C4BE
	public const string SKIN_KEY = "WeaponTooltip"; // Metadata: 0x0068C4DC
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
	private ScrollRect _scroll; // 0x90
	private Vector2 _baseSize; // 0x98
	private RectTransform _lastAnchor; // 0xA0
	private const float FIT_MARGIN = 12f; // Metadata: 0x0068C4EA
	private const float FIT_PAD_BOTTOM = 24f; // Metadata: 0x0068C4EE
	private const string NODE_LINE = "line"; // Metadata: 0x0068C4F2

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1092
	{
		// Fields
		public WeaponTooltip __4__this; // 0x10
		public long targetUserId; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FetchEquipped_b__0(EquippedWeaponResponse resp); // 0x000000018054AEE0-0x000000018054AFF0
		internal void _FetchEquipped_b__1(string err); // 0x000000018054AFF0-0x000000018054B100
	}

	[CompilerGenerated]
	private sealed class _FetchEquipped_d__40 : IEnumerator<object> // TypeDefIndex: 1093
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTooltip __4__this; // 0x20
		public long targetUserId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchEquipped_d__40(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180546B60-0x0000000180546E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180546E00-0x0000000180546E40
	}

	// Constructors
	public WeaponTooltip(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void Show(RectTransform anchor, UserWeaponDTO data); // 0x000000018054FD40-0x000000018054FEB0
	public static void Show(RectTransform anchor, EquippedWeaponResponse data); // 0x000000018054FEB0-0x0000000180550010
	public static void ShowForUser(RectTransform anchor, long targetUserId); // 0x000000018054FBA0-0x000000018054FD40
	public static void HideTooltip(); // 0x000000018054EFE0-0x000000018054F1A0
	private static WeaponTooltip Resolve(); // 0x000000018054F8C0-0x000000018054FBA0
	private void Awake(); // 0x000000018054C960-0x000000018054CA10
	private void OnDestroy(); // 0x000000018054F1A0-0x000000018054F250
	private void EnsureWired(); // 0x000000018054E090-0x000000018054E6C0
	private void Present(RectTransform anchor); // 0x000000018054F790-0x000000018054F8C0
	private void EnsureScrollRig(); // 0x000000018054DDB0-0x000000018054E090
	private static void Add(List<RectTransform> list, Graphic g); // 0x000000018054C440-0x000000018054C530
	private void ApplyFit(); // 0x000000018054C530-0x000000018054C960
	private void ClosePanel(); // 0x000000018054D790-0x000000018054D8D0
	private void OnDisable(); // 0x000000018054F250-0x000000018054F320
	private void PositionNear(RectTransform anchor); // 0x000000018054F320-0x000000018054F790
	private void Fill(string name, string rarity, int star, int imageId, int atk, int hp, int mana, int crit, int resist, int rate, string element, int power, string source); // 0x000000018054E740-0x000000018054EF30
	[IteratorStateMachine(typeof(_FetchEquipped_d__40))]
	private IEnumerator FetchEquipped(long targetUserId); // 0x000000018054E6C0-0x000000018054E740
	private static string Summarize(string name, string rarity, int star, int power); // 0x0000000180550010-0x0000000180550250
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x000000018054CA10-0x000000018054D790
	private static GameObject CreateChild(Transform parent, string name); // 0x000000018054D8D0-0x000000018054DA40
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018054EF30-0x000000018054EFE0
	private static void CreateIcon(Transform parent, string name, Vector2 pos, Vector2 size); // 0x000000018054DA40-0x000000018054DBC0
	private static UnityEngine.UI.Text CreateLabel(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta); // 0x000000018054DBC0-0x000000018054DDB0
	[CompilerGenerated]
	private void _ClosePanel_b__36_0(); // 0x0000000180550250-0x00000001805502D0
}

