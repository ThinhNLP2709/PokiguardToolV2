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
public class GachaRevealPopup : MonoBehaviour // TypeDefIndex: 752
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GachaRevealPopup"; // Metadata: 0x005EE663
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
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x005EE67F
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x005EE683

	// Properties
	public static bool IsBusy { get; } // 0x00000001804D37E0-0x00000001804D3940 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 753
	{
		// Fields
		public GachaRevealPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x00000001804DAD50-0x00000001804DAF90
		internal void _PlayRevealFx_b__1(); // 0x00000001804DAF90-0x00000001804DB110
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 754
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public int n; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayAmountCount_b__0(float v); // 0x00000001804DB110-0x00000001804DB2B0
		internal void _PlayAmountCount_b__1(); // 0x00000001804DB2B0-0x00000001804DB3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 755
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlaySweep_b__0(); // 0x00000001804DB3F0-0x00000001804DB530
	}

	[CompilerGenerated]
	private sealed class _FlipCo_d__51 : IEnumerator<object> // TypeDefIndex: 756
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GachaRevealPopup __4__this; // 0x28
		public int rank; // 0x30
		private GameObject _card_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlipCo_d__51(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001804DB530-0x00000001804DBB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DBB20-0x00000001804DBB60
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__60 : IEnumerator<object> // TypeDefIndex: 757
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRevealPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogCo_d__60(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804DBB60-0x00000001804DC1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DC1D0-0x00000001804DC210
	}

	// Constructors
	public GachaRevealPopup(); // 0x00000001804DA8F0-0x00000001804DA970
	static GachaRevealPopup(); // 0x00000001804DA970-0x00000001804DAA50

	// Methods
	public static void Show(GachaRollItemDTO item); // 0x00000001804D3450-0x00000001804D37E0
	private static GachaRevealPopup Resolve(); // 0x00000001804D3940-0x00000001804D3D70
	private void Awake(); // 0x00000001804D3D70-0x00000001804D3F00
	private void OnDestroy(); // 0x00000001804D3F00-0x00000001804D40D0
	private void EnsureWired(); // 0x00000001804D40D0-0x00000001804D5400
	private void OnDimClicked(); // 0x00000001804D5400-0x00000001804D5420
	private void Present(GachaRollItemDTO item); // 0x00000001804D5420-0x00000001804D58B0
	private void OpenPanel(); // 0x00000001804D58B0-0x00000001804D5CD0
	private static string TitleText(); // 0x00000001804D5CD0-0x00000001804D5E20
	private void RefreshTitle(); // 0x00000001804D5E20-0x00000001804D5F60
	private void Fill(GachaRollItemDTO item); // 0x00000001804D5F60-0x00000001804D6EB0
	private static string BuildNote(GachaRollItemDTO item); // 0x00000001804D6EB0-0x00000001804D7320
	private void PlayRevealFx(GachaRollItemDTO item); // 0x00000001804D7320-0x00000001804D7E10
	[IteratorStateMachine(typeof(_FlipCo_d__51))]
	private IEnumerator FlipCo(float delay, int rank); // 0x00000001804D7E10-0x00000001804D7ED0
	private void PlayAmountCount(); // 0x00000001804D7ED0-0x00000001804D81B0
	private void SkipToEnd(); // 0x00000001804D81B0-0x00000001804D8B10
	private void PlaySweep(Image img, float dir, float delay); // 0x00000001804D8B10-0x00000001804D8E20
	private void PulseTwinkle(Image img, float delay); // 0x00000001804D8E20-0x00000001804D9150
	private void TryVibrate(); // 0x00000001804D9150-0x00000001804D92A0
	private void CancelFx(); // 0x00000001804D92A0-0x00000001804DA0A0
	private void RestartWatchdog(); // 0x00000001804DA0A0-0x00000001804DA1C0
	private void StopWatchdog(); // 0x00000001804DA1C0-0x00000001804DA240
	[IteratorStateMachine(typeof(_WatchdogCo_d__60))]
	private IEnumerator WatchdogCo(); // 0x00000001804DA240-0x00000001804DA2E0
	private void Update(); // 0x00000001804DA2E0-0x00000001804DA360
	private void ClosePopup(); // 0x00000001804DA360-0x00000001804DA530
	private void OnDisable(); // 0x00000001804DA530-0x00000001804DA690
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804DA690-0x00000001804DA8F0
	[CompilerGenerated]
	private void _ClosePopup_b__62_0(); // 0x00000001804DAA50-0x00000001804DAD50
}

