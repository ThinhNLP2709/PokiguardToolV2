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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class ConnectionLostPanel : MonoBehaviour // TypeDefIndex: 1386
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
	private const float RESULT_SUPPRESS_SEC = 90f; // Metadata: 0x005F0E00
	private float _resultSuppressUntil; // 0x80
	private const float SHOW_DEBOUNCE_SEC = 3f; // Metadata: 0x005F0E04
	private Coroutine _pendingShowCoroutine; // 0x88
	private Coroutine _forceHideCoroutine; // 0x90
	private bool _hiding; // 0x98
	private const float WATCHDOG_INTERVAL_SEC = 0.5f; // Metadata: 0x005F0E08
	private float _nextWatchdogAt; // 0x9C

	// Properties
	public static ConnectionLostPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807823C0-0x0000000180782400 0x0000000180782400-0x00000001807824A0
	private bool InResultPhase { get; } // 0x0000000180784480-0x00000001807844E0 

	// Nested types
	[CompilerGenerated]
	private sealed class _ForceHideAfter_d__40 : IEnumerator<object> // TypeDefIndex: 1387
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180785CD0-0x0000000180785F70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180785F70-0x0000000180785FB0
	}

	[CompilerGenerated]
	private sealed class _ShowAfterDelay_d__33 : IEnumerator<object> // TypeDefIndex: 1388
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180785FB0-0x00000001807862D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807862D0-0x0000000180786310
	}

	[CompilerGenerated]
	private sealed class _SpinSpinner_d__44 : IEnumerator<object> // TypeDefIndex: 1389
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180786310-0x0000000180786500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180786500-0x0000000180786540
	}

	// Constructors
	public ConnectionLostPanel(); // 0x0000000180785C70-0x0000000180785CD0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001807824A0-0x0000000180782710
	private void Awake(); // 0x0000000180782710-0x0000000180783020
	private void OnActiveSceneChanged(Scene from, Scene to); // 0x0000000180783020-0x00000001807830E0
	private static bool IsSuppressedScene(string sceneName); // 0x00000001807830E0-0x00000001807831B0
	private bool IsOverlayVisible(); // 0x00000001807831B0-0x0000000180783300
	private void SetOverlayVisible(bool visible); // 0x0000000180783300-0x0000000180783690
	private void OnDestroy(); // 0x0000000180783690-0x0000000180783880
	private void TrySubscribe(); // 0x0000000180783880-0x0000000180784120
	private void Unsubscribe(); // 0x0000000180784120-0x0000000180784480
	private void HandleGameOver(string winner); // 0x00000001807844E0-0x00000001807845D0
	private void HandleConnectionChanged(bool connected); // 0x00000001807845D0-0x00000001807847D0
	[IteratorStateMachine(typeof(_ShowAfterDelay_d__33))]
	private IEnumerator ShowAfterDelay(float delay); // 0x00000001807847D0-0x0000000180784890
	private void HandleReconnecting(int attempt); // 0x0000000180784890-0x0000000180784A30
	public void Show(); // 0x0000000180784A30-0x0000000180784FE0
	public void Hide(); // 0x0000000180784FE0-0x00000001807855C0
	private void FinishHide(); // 0x00000001807855C0-0x0000000180785720
	[IteratorStateMachine(typeof(_ForceHideAfter_d__40))]
	private IEnumerator ForceHideAfter(float delay); // 0x0000000180785720-0x00000001807857E0
	private void Update(); // 0x00000001807857E0-0x00000001807859C0
	[IteratorStateMachine(typeof(_SpinSpinner_d__44))]
	private IEnumerator SpinSpinner(); // 0x00000001807859C0-0x0000000180785A60
	private void OnRetryClicked(); // 0x0000000180785A60-0x0000000180785C70
}

