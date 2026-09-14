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
public class GachaRevealPopup : MonoBehaviour // TypeDefIndex: 753
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GachaRevealPopup"; // Metadata: 0x005EFA34
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
	private const float DISMISS_DELAY_SEC = 0.6f; // Metadata: 0x005EFA50
	private const float WATCHDOG_SEC = 12f; // Metadata: 0x005EFA54

	// Properties
	public static bool IsBusy { get; } // 0x00000001804D4E50-0x00000001804D4FB0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 754
	{
		// Fields
		public GachaRevealPopup __4__this; // 0x10
		public Vector3 basePos; // 0x18

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayRevealFx_b__0(float t); // 0x00000001804DC3C0-0x00000001804DC600
		internal void _PlayRevealFx_b__1(); // 0x00000001804DC600-0x00000001804DC780
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 755
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public int n; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayAmountCount_b__0(float v); // 0x00000001804DC780-0x00000001804DC920
		internal void _PlayAmountCount_b__1(); // 0x00000001804DC920-0x00000001804DCA60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 756
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlaySweep_b__0(); // 0x00000001804DCA60-0x00000001804DCBA0
	}

	[CompilerGenerated]
	private sealed class _FlipCo_d__51 : IEnumerator<object> // TypeDefIndex: 757
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
		private bool MoveNext(); // 0x00000001804DCBA0-0x00000001804DD190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DD190-0x00000001804DD1D0
	}

	[CompilerGenerated]
	private sealed class _WatchdogCo_d__60 : IEnumerator<object> // TypeDefIndex: 758
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804DD1D0-0x00000001804DD840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DD840-0x00000001804DD880
	}

	// Constructors
	public GachaRevealPopup(); // 0x00000001804DBF60-0x00000001804DBFE0
	static GachaRevealPopup(); // 0x00000001804DBFE0-0x00000001804DC0C0

	// Methods
	public static void Show(GachaRollItemDTO item); // 0x00000001804D4AC0-0x00000001804D4E50
	private static GachaRevealPopup Resolve(); // 0x00000001804D4FB0-0x00000001804D53E0
	private void Awake(); // 0x00000001804D53E0-0x00000001804D5570
	private void OnDestroy(); // 0x00000001804D5570-0x00000001804D5740
	private void EnsureWired(); // 0x00000001804D5740-0x00000001804D6A70
	private void OnDimClicked(); // 0x00000001804D6A70-0x00000001804D6A90
	private void Present(GachaRollItemDTO item); // 0x00000001804D6A90-0x00000001804D6F20
	private void OpenPanel(); // 0x00000001804D6F20-0x00000001804D7340
	private static string TitleText(); // 0x00000001804D7340-0x00000001804D7490
	private void RefreshTitle(); // 0x00000001804D7490-0x00000001804D75D0
	private void Fill(GachaRollItemDTO item); // 0x00000001804D75D0-0x00000001804D8520
	private static string BuildNote(GachaRollItemDTO item); // 0x00000001804D8520-0x00000001804D8990
	private void PlayRevealFx(GachaRollItemDTO item); // 0x00000001804D8990-0x00000001804D9480
	[IteratorStateMachine(typeof(_FlipCo_d__51))]
	private IEnumerator FlipCo(float delay, int rank); // 0x00000001804D9480-0x00000001804D9540
	private void PlayAmountCount(); // 0x00000001804D9540-0x00000001804D9820
	private void SkipToEnd(); // 0x00000001804D9820-0x00000001804DA180
	private void PlaySweep(Image img, float dir, float delay); // 0x00000001804DA180-0x00000001804DA490
	private void PulseTwinkle(Image img, float delay); // 0x00000001804DA490-0x00000001804DA7C0
	private void TryVibrate(); // 0x00000001804DA7C0-0x00000001804DA910
	private void CancelFx(); // 0x00000001804DA910-0x00000001804DB710
	private void RestartWatchdog(); // 0x00000001804DB710-0x00000001804DB830
	private void StopWatchdog(); // 0x00000001804DB830-0x00000001804DB8B0
	[IteratorStateMachine(typeof(_WatchdogCo_d__60))]
	private IEnumerator WatchdogCo(); // 0x00000001804DB8B0-0x00000001804DB950
	private void Update(); // 0x00000001804DB950-0x00000001804DB9D0
	private void ClosePopup(); // 0x00000001804DB9D0-0x00000001804DBBA0
	private void OnDisable(); // 0x00000001804DBBA0-0x00000001804DBD00
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804DBD00-0x00000001804DBF60
	[CompilerGenerated]
	private void _ClosePopup_b__62_0(); // 0x00000001804DC0C0-0x00000001804DC3C0
}

