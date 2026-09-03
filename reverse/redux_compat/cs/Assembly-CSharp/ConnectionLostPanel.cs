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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class ConnectionLostPanel : MonoBehaviour // TypeDefIndex: 818
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
	private const float RESULT_SUPPRESS_SEC = 90f; // Metadata: 0x0064C985
	private float _resultSuppressUntil; // 0x80
	private const float SHOW_DEBOUNCE_SEC = 3f; // Metadata: 0x0064C989
	private Coroutine _pendingShowCoroutine; // 0x88
	private Coroutine _forceHideCoroutine; // 0x90
	private bool _hiding; // 0x98
	private const float WATCHDOG_INTERVAL_SEC = 0.5f; // Metadata: 0x0064C98D
	private float _nextWatchdogAt; // 0x9C

	// Properties
	public static ConnectionLostPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180425650-0x0000000180425690 0x0000000180425690-0x00000001804256F0
	private bool InResultPhase { get; } // 0x0000000180425620-0x0000000180425650 

	// Nested types
	[CompilerGenerated]
	private sealed class _ForceHideAfter_d__40 : IEnumerator<object> // TypeDefIndex: 819
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ForceHideAfter_d__40(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180437240-0x0000000180437390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180437390-0x00000001804373D0
	}

	[CompilerGenerated]
	private sealed class _ShowAfterDelay_d__33 : IEnumerator<object> // TypeDefIndex: 820
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowAfterDelay_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180438690-0x0000000180438890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180438890-0x00000001804388D0
	}

	[CompilerGenerated]
	private sealed class _SpinSpinner_d__44 : IEnumerator<object> // TypeDefIndex: 821
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ConnectionLostPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpinSpinner_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804388D0-0x00000001804389F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804389F0-0x0000000180438A30
	}

	// Constructors
	public ConnectionLostPanel(); // 0x0000000180425600-0x0000000180425620

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x0000000180423B10-0x0000000180423C60
	private void Awake(); // 0x0000000180423C60-0x0000000180423FE0
	private void OnActiveSceneChanged(Scene from, Scene to); // 0x00000001804247C0-0x0000000180424890
	private static bool IsSuppressedScene(string sceneName); // 0x0000000180424750-0x00000001804247C0
	private bool IsOverlayVisible(); // 0x00000001804246D0-0x0000000180424750
	private void SetOverlayVisible(bool visible); // 0x0000000180424AC0-0x0000000180424BB0
	private void OnDestroy(); // 0x0000000180424890-0x00000001804249D0
	private void TrySubscribe(); // 0x0000000180424F90-0x0000000180425350
	private void Unsubscribe(); // 0x0000000180425350-0x0000000180425500
	private void HandleGameOver(string winner); // 0x00000001804242C0-0x0000000180424340
	private void HandleConnectionChanged(bool connected); // 0x0000000180424100-0x00000001804242C0
	[IteratorStateMachine(typeof(_ShowAfterDelay_d__33))]
	private IEnumerator ShowAfterDelay(float delay); // 0x0000000180424BB0-0x0000000180424C30
	private void HandleReconnecting(int attempt); // 0x0000000180424340-0x0000000180424410
	public void Show(); // 0x0000000180424C30-0x0000000180424F20
	public void Hide(); // 0x0000000180424410-0x00000001804246D0
	private void FinishHide(); // 0x0000000180423FE0-0x0000000180424080
	[IteratorStateMachine(typeof(_ForceHideAfter_d__40))]
	private IEnumerator ForceHideAfter(float delay); // 0x0000000180424080-0x0000000180424100
	private void Update(); // 0x0000000180425500-0x0000000180425600
	[IteratorStateMachine(typeof(_SpinSpinner_d__44))]
	private IEnumerator SpinSpinner(); // 0x0000000180424F20-0x0000000180424F90
	private void OnRetryClicked(); // 0x00000001804249D0-0x0000000180424AC0
}

