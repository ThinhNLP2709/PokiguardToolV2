/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class ConnectionLostPanel : MonoBehaviour // TypeDefIndex: 1384
{
	// Fields
	[CompilerGenerated]
	private static ConnectionLostPanel _Instance_k__BackingField; // 0x00
	[Header("UI References (drag t\u1EEB prefab hierarchy)")]
	[SerializeField]
	private GameObject card; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text bodyText; // 0x28
	[SerializeField]
	private Image spinner; // 0x30
	[SerializeField]
	private Button retryButton; // 0x38
	[SerializeField]
	private float spinSpeed; // 0x40
	private Coroutine _spinnerCoroutine; // 0x48
	private int _attemptCount; // 0x50
	private Canvas _rootCanvas; // 0x58
	private GraphicRaycaster _rootRaycaster; // 0x60
	private CanvasGroup _rootGroup; // 0x68
	private ChatService _subscribedChat; // 0x70
	private MatchService _subscribedMatch; // 0x78
	private const float RESULT_SUPPRESS_SEC = 90f; // Metadata: 0x005EFA33
	private float _resultSuppressUntil; // 0x80
	private const float SHOW_DEBOUNCE_SEC = 3f; // Metadata: 0x005EFA37
	private Coroutine _pendingShowCoroutine; // 0x88
	private Coroutine _forceHideCoroutine; // 0x90
	private bool _hiding; // 0x98
	private const float WATCHDOG_INTERVAL_SEC = 0.5f; // Metadata: 0x005EFA3B
	private float _nextWatchdogAt; // 0x9C

	// Properties
	public static ConnectionLostPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180780470-0x00000001807804B0 0x00000001807804B0-0x0000000180780550
	private bool InResultPhase { get; } // 0x0000000180782530-0x0000000180782590 

	// Nested types
	[CompilerGenerated]
	private sealed class _ForceHideAfter_d__40 : IEnumerator<object> // TypeDefIndex: 1385
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ForceHideAfter_d__40(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180783D80-0x0000000180784020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180784020-0x0000000180784060
	}

	[CompilerGenerated]
	private sealed class _ShowAfterDelay_d__33 : IEnumerator<object> // TypeDefIndex: 1386
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowAfterDelay_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180784060-0x0000000180784380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180784380-0x00000001807843C0
	}

	[CompilerGenerated]
	private sealed class _SpinSpinner_d__44 : IEnumerator<object> // TypeDefIndex: 1387
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ConnectionLostPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinSpinner_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001807843C0-0x00000001807845B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807845B0-0x00000001807845F0
	}

	// Constructors
	public ConnectionLostPanel(); // 0x0000000180783D20-0x0000000180783D80

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x0000000180780550-0x00000001807807C0
	private void Awake(); // 0x00000001807807C0-0x00000001807810D0
	private void OnActiveSceneChanged(Scene from, Scene to); // 0x00000001807810D0-0x0000000180781190
	private static bool IsSuppressedScene(string sceneName); // 0x0000000180781190-0x0000000180781260
	private bool IsOverlayVisible(); // 0x0000000180781260-0x00000001807813B0
	private void SetOverlayVisible(bool visible); // 0x00000001807813B0-0x0000000180781740
	private void OnDestroy(); // 0x0000000180781740-0x0000000180781930
	private void TrySubscribe(); // 0x0000000180781930-0x00000001807821D0
	private void Unsubscribe(); // 0x00000001807821D0-0x0000000180782530
	private void HandleGameOver(string winner); // 0x0000000180782590-0x0000000180782680
	private void HandleConnectionChanged(bool connected); // 0x0000000180782680-0x0000000180782880
	[IteratorStateMachine(typeof(_ShowAfterDelay_d__33))]
	private IEnumerator ShowAfterDelay(float delay); // 0x0000000180782880-0x0000000180782940
	private void HandleReconnecting(int attempt); // 0x0000000180782940-0x0000000180782AE0
	public void Show(); // 0x0000000180782AE0-0x0000000180783090
	public void Hide(); // 0x0000000180783090-0x0000000180783670
	private void FinishHide(); // 0x0000000180783670-0x00000001807837D0
	[IteratorStateMachine(typeof(_ForceHideAfter_d__40))]
	private IEnumerator ForceHideAfter(float delay); // 0x00000001807837D0-0x0000000180783890
	private void Update(); // 0x0000000180783890-0x0000000180783A70
	[IteratorStateMachine(typeof(_SpinSpinner_d__44))]
	private IEnumerator SpinSpinner(); // 0x0000000180783A70-0x0000000180783B10
	private void OnRetryClicked(); // 0x0000000180783B10-0x0000000180783D20
}

