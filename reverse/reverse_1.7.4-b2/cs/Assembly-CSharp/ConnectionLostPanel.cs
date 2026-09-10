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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class ConnectionLostPanel : MonoBehaviour // TypeDefIndex: 1013
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
	private const float RESULT_SUPPRESS_SEC = 90f; // Metadata: 0x0068C05B
	private float _resultSuppressUntil; // 0x80
	private const float SHOW_DEBOUNCE_SEC = 3f; // Metadata: 0x0068C05F
	private Coroutine _pendingShowCoroutine; // 0x88
	private Coroutine _forceHideCoroutine; // 0x90
	private bool _hiding; // 0x98
	private const float WATCHDOG_INTERVAL_SEC = 0.5f; // Metadata: 0x0068C063
	private float _nextWatchdogAt; // 0x9C

	// Properties
	public static ConnectionLostPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804FA9B0-0x00000001804FA9F0 0x00000001804FA9F0-0x00000001804FAA50
	private bool InResultPhase { get; } // 0x00000001804FA980-0x00000001804FA9B0 

	// Nested types
	[CompilerGenerated]
	private sealed class _ForceHideAfter_d__40 : IEnumerator<object> // TypeDefIndex: 1014
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ForceHideAfter_d__40(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050F030-0x000000018050F180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F180-0x000000018050F1C0
	}

	[CompilerGenerated]
	private sealed class _ShowAfterDelay_d__33 : IEnumerator<object> // TypeDefIndex: 1015
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ConnectionLostPanel __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowAfterDelay_d__33(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050F1C0-0x000000018050F3C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F3C0-0x000000018050F400
	}

	[CompilerGenerated]
	private sealed class _SpinSpinner_d__44 : IEnumerator<object> // TypeDefIndex: 1016
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ConnectionLostPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinSpinner_d__44(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050F400-0x000000018050F520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F520-0x000000018050F560
	}

	// Constructors
	public ConnectionLostPanel(); // 0x00000001804FA960-0x00000001804FA980

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001804F8E70-0x00000001804F8FC0
	private void Awake(); // 0x00000001804F8FC0-0x00000001804F9340
	private void OnActiveSceneChanged(Scene from, Scene to); // 0x00000001804F9B20-0x00000001804F9BF0
	private static bool IsSuppressedScene(string sceneName); // 0x00000001804F9AB0-0x00000001804F9B20
	private bool IsOverlayVisible(); // 0x00000001804F9A30-0x00000001804F9AB0
	private void SetOverlayVisible(bool visible); // 0x00000001804F9E20-0x00000001804F9F10
	private void OnDestroy(); // 0x00000001804F9BF0-0x00000001804F9D30
	private void TrySubscribe(); // 0x00000001804FA2F0-0x00000001804FA6B0
	private void Unsubscribe(); // 0x00000001804FA6B0-0x00000001804FA860
	private void HandleGameOver(string winner); // 0x00000001804F9620-0x00000001804F96A0
	private void HandleConnectionChanged(bool connected); // 0x00000001804F9460-0x00000001804F9620
	[IteratorStateMachine(typeof(_ShowAfterDelay_d__33))]
	private IEnumerator ShowAfterDelay(float delay); // 0x00000001804F9F10-0x00000001804F9F90
	private void HandleReconnecting(int attempt); // 0x00000001804F96A0-0x00000001804F9770
	public void Show(); // 0x00000001804F9F90-0x00000001804FA280
	public void Hide(); // 0x00000001804F9770-0x00000001804F9A30
	private void FinishHide(); // 0x00000001804F9340-0x00000001804F93E0
	[IteratorStateMachine(typeof(_ForceHideAfter_d__40))]
	private IEnumerator ForceHideAfter(float delay); // 0x00000001804F93E0-0x00000001804F9460
	private void Update(); // 0x00000001804FA860-0x00000001804FA960
	[IteratorStateMachine(typeof(_SpinSpinner_d__44))]
	private IEnumerator SpinSpinner(); // 0x00000001804FA280-0x00000001804FA2F0
	private void OnRetryClicked(); // 0x00000001804F9D30-0x00000001804F9E20
}

