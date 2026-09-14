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

[DisallowMultipleComponent]
public class WeaponTooltip : MonoBehaviour // TypeDefIndex: 1504
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponTooltip"; // Metadata: 0x005F1160
	public const string PREFAB_PATH_POKY = "Prefabs/UI/WeaponTooltip_Poky"; // Metadata: 0x005F1179
	public const string SKIN_KEY = "WeaponTooltip"; // Metadata: 0x005F1197
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
	private const float FIT_MARGIN = 12f; // Metadata: 0x005F11A5
	private const float FIT_PAD_BOTTOM = 24f; // Metadata: 0x005F11A9
	private const string NODE_LINE = "line"; // Metadata: 0x005F11AD

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1505
	{
		// Fields
		public WeaponTooltip __4__this; // 0x10
		public long targetUserId; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchEquipped_b__0(EquippedWeaponResponse resp); // 0x000000018082E0D0-0x000000018082E1E0
		internal void _FetchEquipped_b__1(string err); // 0x000000018082E1E0-0x000000018082E350
	}

	[CompilerGenerated]
	private sealed class _FetchEquipped_d__40 : IEnumerator<object> // TypeDefIndex: 1506
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018082E350-0x000000018082E8E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018082E8E0-0x000000018082E920
	}

	// Constructors
	public WeaponTooltip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(RectTransform anchor, UserWeaponDTO data); // 0x00000001808277B0-0x0000000180827990
	public static void Show(RectTransform anchor, EquippedWeaponResponse data); // 0x0000000180827990-0x0000000180827B70
	public static void ShowForUser(RectTransform anchor, long targetUserId); // 0x0000000180827B70-0x0000000180827E00
	public static void HideTooltip(); // 0x0000000180827E00-0x0000000180827F20
	private static WeaponTooltip Resolve(); // 0x0000000180827F20-0x00000001808284D0
	private void Awake(); // 0x00000001808284D0-0x0000000180828640
	private void OnDestroy(); // 0x0000000180828640-0x0000000180828800
	private void EnsureWired(); // 0x0000000180828800-0x0000000180829590
	private void Present(RectTransform anchor); // 0x0000000180829590-0x0000000180829820
	private void EnsureScrollRig(); // 0x0000000180829820-0x0000000180829E70
	private static void Add(List<RectTransform> list, Graphic g); // 0x0000000180829E70-0x0000000180829FC0
	private void ApplyFit(); // 0x0000000180829FC0-0x000000018082A730
	private void ClosePanel(); // 0x000000018082A730-0x000000018082A940
	private void OnDisable(); // 0x000000018082A940-0x000000018082AB20
	private void PositionNear(RectTransform anchor); // 0x000000018082AB20-0x000000018082B2C0
	private void Fill(string name, string rarity, int star, int imageId, int atk, int hp, int mana, int crit, int resist, int rate, string element, int power, string source); // 0x000000018082B2C0-0x000000018082BFA0
	[IteratorStateMachine(typeof(_FetchEquipped_d__40))]
	private IEnumerator FetchEquipped(long targetUserId); // 0x000000018082BFA0-0x000000018082C060
	private static string Summarize(string name, string rarity, int star, int power); // 0x000000018082C060-0x000000018082C2D0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x000000018082C2D0-0x000000018082D6D0
	private static GameObject CreateChild(Transform parent, string name); // 0x000000018082D6D0-0x000000018082D950
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018082D950-0x000000018082DAE0
	private static void CreateIcon(Transform parent, string name, Vector2 pos, Vector2 size); // 0x000000018082DAE0-0x000000018082DC60
	private static UnityEngine.UI.Text CreateLabel(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta); // 0x000000018082DC60-0x000000018082DF80
	[CompilerGenerated]
	private void _ClosePanel_b__36_0(); // 0x000000018082DF80-0x000000018082E0D0
}

