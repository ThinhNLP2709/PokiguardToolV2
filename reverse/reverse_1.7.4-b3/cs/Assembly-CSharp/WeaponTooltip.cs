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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class WeaponTooltip : MonoBehaviour // TypeDefIndex: 1502
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponTooltip"; // Metadata: 0x005EFD93
	public const string PREFAB_PATH_POKY = "Prefabs/UI/WeaponTooltip_Poky"; // Metadata: 0x005EFDAC
	public const string SKIN_KEY = "WeaponTooltip"; // Metadata: 0x005EFDCA
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
	private const float FIT_MARGIN = 12f; // Metadata: 0x005EFDD8
	private const float FIT_PAD_BOTTOM = 24f; // Metadata: 0x005EFDDC
	private const string NODE_LINE = "line"; // Metadata: 0x005EFDE0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1503
	{
		// Fields
		public WeaponTooltip __4__this; // 0x10
		public long targetUserId; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchEquipped_b__0(EquippedWeaponResponse resp); // 0x000000018082BFE0-0x000000018082C0F0
		internal void _FetchEquipped_b__1(string err); // 0x000000018082C0F0-0x000000018082C260
	}

	[CompilerGenerated]
	private sealed class _FetchEquipped_d__40 : IEnumerator<object> // TypeDefIndex: 1504
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponTooltip __4__this; // 0x20
		public long targetUserId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchEquipped_d__40(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018082C260-0x000000018082C7D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018082C7D0-0x000000018082C810
	}

	// Constructors
	public WeaponTooltip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(RectTransform anchor, UserWeaponDTO data); // 0x00000001808256C0-0x00000001808258A0
	public static void Show(RectTransform anchor, EquippedWeaponResponse data); // 0x00000001808258A0-0x0000000180825A80
	public static void ShowForUser(RectTransform anchor, long targetUserId); // 0x0000000180825A80-0x0000000180825D10
	public static void HideTooltip(); // 0x0000000180825D10-0x0000000180825E30
	private static WeaponTooltip Resolve(); // 0x0000000180825E30-0x00000001808263E0
	private void Awake(); // 0x00000001808263E0-0x0000000180826550
	private void OnDestroy(); // 0x0000000180826550-0x0000000180826710
	private void EnsureWired(); // 0x0000000180826710-0x00000001808274A0
	private void Present(RectTransform anchor); // 0x00000001808274A0-0x0000000180827730
	private void EnsureScrollRig(); // 0x0000000180827730-0x0000000180827D80
	private static void Add(List<RectTransform> list, Graphic g); // 0x0000000180827D80-0x0000000180827ED0
	private void ApplyFit(); // 0x0000000180827ED0-0x0000000180828640
	private void ClosePanel(); // 0x0000000180828640-0x0000000180828850
	private void OnDisable(); // 0x0000000180828850-0x0000000180828A30
	private void PositionNear(RectTransform anchor); // 0x0000000180828A30-0x00000001808291D0
	private void Fill(string name, string rarity, int star, int imageId, int atk, int hp, int mana, int crit, int resist, int rate, string element, int power, string source); // 0x00000001808291D0-0x0000000180829EB0
	[IteratorStateMachine(typeof(_FetchEquipped_d__40))]
	private IEnumerator FetchEquipped(long targetUserId); // 0x0000000180829EB0-0x0000000180829F70
	private static string Summarize(string name, string rarity, int star, int power); // 0x0000000180829F70-0x000000018082A1E0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x000000018082A1E0-0x000000018082B5E0
	private static GameObject CreateChild(Transform parent, string name); // 0x000000018082B5E0-0x000000018082B860
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018082B860-0x000000018082B9F0
	private static void CreateIcon(Transform parent, string name, Vector2 pos, Vector2 size); // 0x000000018082B9F0-0x000000018082BB70
	private static UnityEngine.UI.Text CreateLabel(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta); // 0x000000018082BB70-0x000000018082BE90
	[CompilerGenerated]
	private void _ClosePanel_b__36_0(); // 0x000000018082BE90-0x000000018082BFE0
}

