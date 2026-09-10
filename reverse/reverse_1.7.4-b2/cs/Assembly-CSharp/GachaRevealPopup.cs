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
public class GachaRevealPopup : MonoBehaviour // TypeDefIndex: 661
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GachaRevealPopup"; // Metadata: 0x0068B702
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
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x0068B71E
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x0068B722

	// Properties
	public static bool IsBusy { get; } // 0x0000000180407890-0x0000000180407960 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 662
	{
		// Fields
		public GachaRevealPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass50_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x000000018044F550-0x000000018044F6B0
		internal void _PlayRevealFx_b__1(); // 0x000000018044F6B0-0x000000018044F750
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 663
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public int n; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayAmountCount_b__0(float v); // 0x000000018044F750-0x000000018044F830
		internal void _PlayAmountCount_b__1(); // 0x000000018044F830-0x000000018044F8E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 664
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlaySweep_b__0(); // 0x000000018044F8E0-0x000000018044F960
	}

	[CompilerGenerated]
	private sealed class _FlipCo_d__51 : IEnumerator<object> // TypeDefIndex: 665
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GachaRevealPopup __4__this; // 0x28
		public int rank; // 0x30
		private GameObject _card_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlipCo_d__51(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x000000018044EFE0-0x000000018044F390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044F390-0x000000018044F3D0
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__60 : IEnumerator<object> // TypeDefIndex: 666
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRevealPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__60(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018044FA80-0x000000018044FE10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044FE10-0x000000018044FE50
	}

	// Constructors
	public GachaRevealPopup(); // 0x0000000180407850-0x0000000180407890
	static GachaRevealPopup(); // 0x00000001804077C0-0x0000000180407850

	// Methods
	public static void Show(GachaRollItemDTO item); // 0x0000000180406D40-0x0000000180406FA0
	private static GachaRevealPopup Resolve(); // 0x0000000180406A40-0x0000000180406C80
	private void Awake(); // 0x0000000180403560-0x0000000180403620
	private void OnDestroy(); // 0x0000000180405690-0x0000000180405750
	private void EnsureWired(); // 0x0000000180403FE0-0x0000000180404D30
	private void OnDimClicked(); // 0x0000000180405750-0x0000000180405770
	private void Present(GachaRollItemDTO item); // 0x0000000180406580-0x0000000180406790
	private void OpenPanel(); // 0x0000000180405870-0x0000000180405A50
	private static string TitleText(); // 0x0000000180407440-0x0000000180407530
	private void RefreshTitle(); // 0x0000000180406990-0x0000000180406A40
	private void Fill(GachaRollItemDTO item); // 0x0000000180404D30-0x00000001804054F0
	private static string BuildNote(GachaRollItemDTO item); // 0x0000000180403620-0x00000001804039A0
	private void PlayRevealFx(GachaRollItemDTO item); // 0x0000000180405C90-0x0000000180406370
	[IteratorStateMachine(typeof(_FlipCo_d__51))]
	private IEnumerator FlipCo(float delay, int rank); // 0x0000000180405600-0x0000000180405690
	private void PlayAmountCount(); // 0x0000000180405A50-0x0000000180405C90
	private void SkipToEnd(); // 0x0000000180406FA0-0x00000001804073F0
	private void PlaySweep(Image img, float dir, float delay); // 0x0000000180406370-0x0000000180406580
	private void PulseTwinkle(Image img, float delay); // 0x0000000180406790-0x0000000180406990
	private void TryVibrate(); // 0x0000000180407530-0x00000001804075B0
	private void CancelFx(); // 0x00000001804039A0-0x0000000180403E80
	private void RestartWatchdog(); // 0x0000000180406C80-0x0000000180406D40
	private void StopWatchdog(); // 0x00000001804073F0-0x0000000180407440
	[IteratorStateMachine(typeof(_WatchdogCo_d__60))]
	private IEnumerator WatchdogCo(); // 0x0000000180407750-0x00000001804077C0
	private void Update(); // 0x00000001804076D0-0x0000000180407750
	private void ClosePopup(); // 0x0000000180403E80-0x0000000180403FE0
	private void OnDisable(); // 0x0000000180405770-0x0000000180405870
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804054F0-0x0000000180405600
	[CompilerGenerated]
	private void _ClosePopup_b__62_0(); // 0x00000001804075B0-0x00000001804076D0
}

