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
public class WeaponDropPopup : MonoBehaviour // TypeDefIndex: 1500
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponDropPopup"; // Metadata: 0x005F113D
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
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x005F1158
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x005F115C

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1501
	{
		// Fields
		public WeaponDropPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x0000000180825DA0-0x0000000180825FE0
		internal void _PlayRevealFx_b__1(); // 0x0000000180825FE0-0x0000000180826160
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__40 : IEnumerator<object> // TypeDefIndex: 1502
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponDropPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__40(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180826160-0x00000001808267D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808267D0-0x0000000180826810
	}

	// Constructors
	public WeaponDropPopup(); // 0x0000000180825A30-0x0000000180825AB0
	static WeaponDropPopup(); // 0x0000000180825AB0-0x0000000180825B90

	// Methods
	public static void Show(WeaponDropDTO drop); // 0x000000018081E910-0x000000018081EC60
	private static WeaponDropPopup Resolve(); // 0x000000018081EC60-0x000000018081F090
	private static string FallbackText(WeaponDropDTO d); // 0x000000018081F090-0x000000018081F420
	private void Awake(); // 0x000000018081F420-0x000000018081F5B0
	private void OnDestroy(); // 0x000000018081F5B0-0x000000018081F780
	private void EnsureWired(); // 0x000000018081F780-0x00000001808207C0
	private void OnDimClicked(); // 0x00000001808207C0-0x00000001808207E0
	private void Present(WeaponDropDTO drop); // 0x00000001808207E0-0x0000000180820C70
	private void OpenPanel(); // 0x0000000180820C70-0x0000000180821090
	private void RestartWatchdog(); // 0x0000000180821090-0x00000001808211B0
	private void StopWatchdog(); // 0x000000018053CF90-0x000000018053D010
	[IteratorStateMachine(typeof(_WatchdogCo_d__40))]
	private IEnumerator WatchdogCo(); // 0x00000001808211B0-0x0000000180821250
	private void Update(); // 0x0000000180821250-0x00000001808212D0
	private static string TitleText(WeaponDropDTO drop); // 0x00000001808212D0-0x00000001808214F0
	private static string RarityLabelOf(WeaponDropDTO drop); // 0x00000001808214F0-0x00000001808215C0
	private static string RarityKeyOf(WeaponDropDTO drop); // 0x00000001808215C0-0x0000000180821660
	private void RefreshTitle(); // 0x0000000180821660-0x00000001808217A0
	private void Fill(WeaponDropDTO drop); // 0x00000001808217A0-0x0000000180822640
	private void PlayRevealFx(WeaponDropDTO drop); // 0x0000000180822640-0x0000000180822DD0
	private void PulseTwinkle(Image img, float delay); // 0x0000000180822DD0-0x0000000180823100
	private void CancelFx(); // 0x0000000180823100-0x0000000180823710
	private void ClosePopup(); // 0x0000000180823710-0x00000001808238E0
	private void OnDisable(); // 0x00000001808238E0-0x0000000180823A40
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x0000000180823A40-0x0000000180825170
	private static GameObject NewChild(Transform parent, string name); // 0x0000000180825170-0x00000001808253F0
	private static void MakeCenterImage(Transform parent, string name, Vector2 pos, Vector2 size, string uiSprite); // 0x00000001808253F0-0x00000001808256E0
	private static UnityEngine.UI.Text MakeText(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta, TextAnchor align); // 0x00000001808256E0-0x0000000180825A30
	[CompilerGenerated]
	private void _ClosePopup_b__50_0(); // 0x0000000180825B90-0x0000000180825DA0
}

