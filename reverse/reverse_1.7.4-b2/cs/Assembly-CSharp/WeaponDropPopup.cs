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
public class WeaponDropPopup : MonoBehaviour // TypeDefIndex: 1087
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponDropPopup"; // Metadata: 0x0068C448
	[SerializeField]
	private RectTransform panel; // 0x20
	[SerializeField]
	private Image imgGlow; // 0x28
	[SerializeField]
	private Image imgTwinkle1; // 0x30
	[SerializeField]
	private Image imgTwinkle2; // 0x38
	[SerializeField]
	private Image imgCircle; // 0x40
	[SerializeField]
	private Image imgWeapon; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtRarity; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtStats; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtNote; // 0x70
	[SerializeField]
	private Button btnClaim; // 0x78
	private static WeaponDropPopup _instance; // 0x00
	private static readonly Queue<WeaponDropDTO> _pending; // 0x08
	private static int _batchIndex; // 0x10
	private static int _batchTotal; // 0x14
	private CanvasGroup _group; // 0x80
	private Button _btnDim; // 0x88
	private bool _wired; // 0x90
	private bool _showing; // 0x91
	private bool _canDismiss; // 0x92
	private int _shakeTweenId; // 0x94
	private Coroutine _watchdog; // 0x98
	private WeaponDropDTO _current; // 0xA0
	private Vector3 _panelBaseScale; // 0xA8
	private Vector3 _panelBasePos; // 0xB4
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x0068C463
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x0068C467

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1088
	{
		// Fields
		public WeaponDropPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x000000018054B2E0-0x000000018054B440
		internal void _PlayRevealFx_b__1(); // 0x000000018054B440-0x000000018054B4E0
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__40 : IEnumerator<object> // TypeDefIndex: 1089
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponDropPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__40(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018054B550-0x000000018054B8E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054B8E0-0x000000018054B920
	}

	// Constructors
	public WeaponDropPopup(); // 0x0000000180528190-0x00000001805281D0
	static WeaponDropPopup(); // 0x0000000180528100-0x0000000180528190

	// Methods
	public static void Show(WeaponDropDTO drop); // 0x0000000180527B10-0x0000000180527D50
	private static WeaponDropPopup Resolve(); // 0x0000000180527810-0x0000000180527A50
	private static string FallbackText(WeaponDropDTO d); // 0x0000000180525550-0x0000000180525880
	private void Awake(); // 0x0000000180523870-0x0000000180523930
	private void OnDestroy(); // 0x0000000180526820-0x00000001805268E0
	private void EnsureWired(); // 0x0000000180524C30-0x0000000180525550
	private void OnDimClicked(); // 0x00000001805268E0-0x0000000180526900
	private void Present(WeaponDropDTO drop); // 0x0000000180527100-0x0000000180527310
	private void OpenPanel(); // 0x0000000180526A00-0x0000000180526BE0
	private void RestartWatchdog(); // 0x0000000180527A50-0x0000000180527B10
	private void StopWatchdog(); // 0x0000000180473980-0x00000001804739D0
	[IteratorStateMachine(typeof(_WatchdogCo_d__40))]
	private IEnumerator WatchdogCo(); // 0x0000000180528090-0x0000000180528100
	private void Update(); // 0x0000000180528010-0x0000000180528090
	private static string TitleText(WeaponDropDTO drop); // 0x0000000180527D50-0x0000000180527EF0
	private static string RarityLabelOf(WeaponDropDTO drop); // 0x0000000180527620-0x0000000180527750
	private static string RarityKeyOf(WeaponDropDTO drop); // 0x0000000180527510-0x0000000180527620
	private void RefreshTitle(); // 0x0000000180527750-0x0000000180527810
	private void Fill(WeaponDropDTO drop); // 0x0000000180525880-0x0000000180526240
	private void PlayRevealFx(WeaponDropDTO drop); // 0x0000000180526BE0-0x0000000180527100
	private void PulseTwinkle(Image img, float delay); // 0x0000000180527310-0x0000000180527510
	private void CancelFx(); // 0x0000000180524880-0x0000000180524AD0
	private void ClosePopup(); // 0x0000000180524AD0-0x0000000180524C30
	private void OnDisable(); // 0x0000000180526900-0x0000000180526A00
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x0000000180523930-0x0000000180524880
	private static GameObject NewChild(Transform parent, string name); // 0x00000001805266B0-0x0000000180526820
	private static void MakeCenterImage(Transform parent, string name, Vector2 pos, Vector2 size, string uiSprite); // 0x0000000180526240-0x0000000180526490
	private static UnityEngine.UI.Text MakeText(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta, TextAnchor align); // 0x0000000180526490-0x00000001805266B0
	[CompilerGenerated]
	private void _ClosePopup_b__50_0(); // 0x0000000180527EF0-0x0000000180528010
}

