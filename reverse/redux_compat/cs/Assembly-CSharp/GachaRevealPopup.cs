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
public class GachaRevealPopup : MonoBehaviour // TypeDefIndex: 584
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GachaRevealPopup"; // Metadata: 0x0064C54F
	[SerializeField]
	private RectTransform panel; // 0x20
	[SerializeField]
	private Image imgGlow; // 0x28
	[SerializeField]
	private Image imgTwinkle1; // 0x30
	[SerializeField]
	private Image imgTwinkle2; // 0x38
	[SerializeField]
	private Image imgCard; // 0x40
	[SerializeField]
	private Image imgPrize; // 0x48
	[SerializeField]
	private Image imgSweepL; // 0x50
	[SerializeField]
	private Image imgSweepR; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtRarity; // 0x70
	[SerializeField]
	private UnityEngine.UI.Text txtNote; // 0x78
	[SerializeField]
	private UnityEngine.UI.Text txtPityBadge; // 0x80
	[SerializeField]
	private UnityEngine.UI.Text txtAmount; // 0x88
	[SerializeField]
	private Image imgRays; // 0x90
	[SerializeField]
	private Button btnClaim; // 0x98
	[SerializeField]
	private Button btnClose; // 0xA0
	[SerializeField]
	private Image imgPiece; // 0xA8
	[SerializeField]
	private GameObject vibrateMarker; // 0xB0
	private static GachaRevealPopup _instance; // 0x00
	private static readonly Queue<GachaRollItemDTO> _pending; // 0x08
	private static int _batchIndex; // 0x10
	private static int _batchTotal; // 0x14
	private CanvasGroup _group; // 0xB8
	private Button _btnDim; // 0xC0
	private bool _wired; // 0xC8
	private bool _showing; // 0xC9
	private bool _canDismiss; // 0xCA
	private int _shakeTweenId; // 0xCC
	private Coroutine _watchdog; // 0xD0
	private GachaRollItemDTO _current; // 0xD8
	private Vector3 _panelBaseScale; // 0xE0
	private Vector3 _panelBasePos; // 0xEC
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x0064C56B
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x0064C56F

	// Properties
	public static bool IsBusy { get; } // 0x000000018039E0B0-0x000000018039E180 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 585
	{
		// Fields
		public GachaRevealPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass50_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x00000001803BE940-0x00000001803BEAA0
		internal void _PlayRevealFx_b__1(); // 0x00000001803BEAA0-0x00000001803BEB40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 586
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public int n; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayAmountCount_b__0(float v); // 0x00000001803BEB40-0x00000001803BEC20
		internal void _PlayAmountCount_b__1(); // 0x00000001803BEC20-0x00000001803BECD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 587
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlaySweep_b__0(); // 0x00000001803BECD0-0x00000001803BED50
	}

	[CompilerGenerated]
	private sealed class _FlipCo_d__51 : IEnumerator<object> // TypeDefIndex: 588
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GachaRevealPopup __4__this; // 0x28
		public int rank; // 0x30
		private GameObject _card_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FlipCo_d__51(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001803BD410-0x00000001803BD7C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BD7C0-0x00000001803BD800
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__60 : IEnumerator<object> // TypeDefIndex: 589
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRevealPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__60(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803BEDC0-0x00000001803BF150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BF150-0x00000001803BF190
	}

	// Constructors
	public GachaRevealPopup(); // 0x000000018039E070-0x000000018039E0B0
	static GachaRevealPopup(); // 0x000000018039DFE0-0x000000018039E070

	// Methods
	public static void Show(GachaRollItemDTO item); // 0x000000018039D560-0x000000018039D7C0
	private static GachaRevealPopup Resolve(); // 0x000000018039D260-0x000000018039D4A0
	private void Awake(); // 0x0000000180399EE0-0x0000000180399FA0
	private void OnDestroy(); // 0x000000018039BEB0-0x000000018039BF70
	private void EnsureWired(); // 0x000000018039A800-0x000000018039B550
	private void OnDimClicked(); // 0x000000018039BF70-0x000000018039BF90
	private void Present(GachaRollItemDTO item); // 0x000000018039CDA0-0x000000018039CFB0
	private void OpenPanel(); // 0x000000018039C090-0x000000018039C270
	private static string TitleText(); // 0x000000018039DC60-0x000000018039DD50
	private void RefreshTitle(); // 0x000000018039D1B0-0x000000018039D260
	private void Fill(GachaRollItemDTO item); // 0x000000018039B550-0x000000018039BD10
	private static string BuildNote(GachaRollItemDTO item); // 0x0000000180399FA0-0x000000018039A1C0
	private void PlayRevealFx(GachaRollItemDTO item); // 0x000000018039C4B0-0x000000018039CB90
	[IteratorStateMachine(typeof(_FlipCo_d__51))]
	private IEnumerator FlipCo(float delay, int rank); // 0x000000018039BE20-0x000000018039BEB0
	private void PlayAmountCount(); // 0x000000018039C270-0x000000018039C4B0
	private void SkipToEnd(); // 0x000000018039D7C0-0x000000018039DC10
	private void PlaySweep(Image img, float dir, float delay); // 0x000000018039CB90-0x000000018039CDA0
	private void PulseTwinkle(Image img, float delay); // 0x000000018039CFB0-0x000000018039D1B0
	private void TryVibrate(); // 0x000000018039DD50-0x000000018039DDD0
	private void CancelFx(); // 0x000000018039A1C0-0x000000018039A6A0
	private void RestartWatchdog(); // 0x000000018039D4A0-0x000000018039D560
	private void StopWatchdog(); // 0x000000018039DC10-0x000000018039DC60
	[IteratorStateMachine(typeof(_WatchdogCo_d__60))]
	private IEnumerator WatchdogCo(); // 0x000000018039DF70-0x000000018039DFE0
	private void Update(); // 0x000000018039DEF0-0x000000018039DF70
	private void ClosePopup(); // 0x000000018039A6A0-0x000000018039A800
	private void OnDisable(); // 0x000000018039BF90-0x000000018039C090
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018039BD10-0x000000018039BE20
	[CompilerGenerated]
	private void _ClosePopup_b__62_0(); // 0x000000018039DDD0-0x000000018039DEF0
}

