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
public class WeaponDropPopup : MonoBehaviour // TypeDefIndex: 885
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/WeaponDropPopup"; // Metadata: 0x0064CCAA
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
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x0064CCC5
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x0064CCC9

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass45_0 // TypeDefIndex: 886
	{
		// Fields
		public WeaponDropPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass45_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x0000000180458770-0x00000001804588D0
		internal void _PlayRevealFx_b__1(); // 0x00000001804588D0-0x0000000180458970
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__40 : IEnumerator<object> // TypeDefIndex: 887
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WeaponDropPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__40(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180459000-0x0000000180459390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180459390-0x00000001804593D0
	}

	// Constructors
	public WeaponDropPopup(); // 0x0000000180450AE0-0x0000000180450B20
	static WeaponDropPopup(); // 0x0000000180450A50-0x0000000180450AE0

	// Methods
	public static void Show(WeaponDropDTO drop); // 0x00000001804503E0-0x00000001804506E0
	private static WeaponDropPopup Resolve(); // 0x00000001804500E0-0x0000000180450320
	private static string FallbackText(WeaponDropDTO d); // 0x000000018044E560-0x000000018044E660
	private void Awake(); // 0x000000018044C880-0x000000018044C940
	private void OnDestroy(); // 0x000000018044F330-0x000000018044F3F0
	private void EnsureWired(); // 0x000000018044DC40-0x000000018044E560
	private void OnDimClicked(); // 0x000000018044F3F0-0x000000018044F410
	private void Present(WeaponDropDTO drop); // 0x000000018044FC10-0x000000018044FE20
	private void OpenPanel(); // 0x000000018044F510-0x000000018044F6F0
	private void RestartWatchdog(); // 0x0000000180450320-0x00000001804503E0
	private void StopWatchdog(); // 0x00000001804506E0-0x0000000180450730
	[IteratorStateMachine(typeof(_WatchdogCo_d__40))]
	private IEnumerator WatchdogCo(); // 0x00000001804509E0-0x0000000180450A50
	private void Update(); // 0x0000000180450960-0x00000001804509E0
	private static string TitleText(WeaponDropDTO drop); // 0x0000000180450730-0x0000000180450840
	private void RefreshTitle(); // 0x0000000180450020-0x00000001804500E0
	private void Fill(WeaponDropDTO drop); // 0x000000018044E660-0x000000018044ED50
	private void PlayRevealFx(WeaponDropDTO drop); // 0x000000018044F6F0-0x000000018044FC10
	private void PulseTwinkle(Image img, float delay); // 0x000000018044FE20-0x0000000180450020
	private void CancelFx(); // 0x000000018044D890-0x000000018044DAE0
	private void ClosePopup(); // 0x000000018044DAE0-0x000000018044DC40
	private void OnDisable(); // 0x000000018044F410-0x000000018044F510
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	public void BuildHierarchy(); // 0x000000018044C940-0x000000018044D890
	private static GameObject NewChild(Transform parent, string name); // 0x000000018044F1C0-0x000000018044F330
	private static void MakeCenterImage(Transform parent, string name, Vector2 pos, Vector2 size, string uiSprite); // 0x000000018044ED50-0x000000018044EFA0
	private static UnityEngine.UI.Text MakeText(Transform parent, string name, Font font, int size, FontStyle style, Vector2 pos, Vector2 sizeDelta, TextAnchor align); // 0x000000018044EFA0-0x000000018044F1C0
	[CompilerGenerated]
	private void _ClosePopup_b__48_0(); // 0x0000000180450840-0x0000000180450960
}

