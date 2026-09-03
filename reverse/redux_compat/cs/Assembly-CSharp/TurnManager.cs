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

public class TurnManager : MonoBehaviour // TypeDefIndex: 73
{
	// Fields
	[CompilerGenerated]
	private static TurnManager _Instance_k__BackingField; // 0x00
	public GameObject LoadingPanel; // 0x20
	[Header("References")]
	[SerializeField]
	private Active active; // 0x28
	[SerializeField]
	private Board board; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text countdownText; // 0x38
	public YourTurnEffect yourTurnEffect; // 0x40
	[Header("Turn Settings")]
	[SerializeField]
	private float turnDuration; // 0x48
	[SerializeField]
	[Tooltip("Legacy \u2014 server WS t\u1EF1 quy\u1EBFt nh\u1ECBp chuy\u1EC3n l\u01B0\u1EE3t, gi\u00E1 tr\u1ECB n\u00E0y kh\u00F4ng c\u00F2n \u0111\u01B0\u1EE3c d\u00F9ng.")]
	private float turnTransitionDelay; // 0x4C
	private float syncedTurnTime; // 0x50
	private Coroutine turnTimerCoroutine; // 0x58
	private float pausedTurnTime; // 0x60
	private bool _wsSubscribed; // 0x64
	private float _srvRemainingAtTick; // 0x68
	private float _srvTickAt; // 0x6C
	private bool _srvClockFrozen; // 0x70
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x0064BF87
	private bool hasGameStarted; // 0x71
	private int _lastYourTurnFxTurn; // 0x74
	private int _lastShownSec; // 0x78
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018030D9E0-0x000000018030DA30 0x000000018030DA30-0x000000018030DAA0
	public bool HasGameStarted { get; } // 0x000000018030D9D0-0x000000018030D9E0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WsDisplayTimerCoroutine_d__20 : IEnumerator<object> // TypeDefIndex: 74
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TurnManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsDisplayTimerCoroutine_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030FF40-0x00000001803101A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803101A0-0x00000001803101E0
	}

	// Constructors
	public TurnManager(); // 0x000000018030D9A0-0x000000018030D9D0
	static TurnManager(); // 0x000000018030D8B0-0x000000018030D9A0

	// Methods
	private void Awake(); // 0x000000018030B9F0-0x000000018030BAE0
	private void Start(); // 0x000000018030CD80-0x000000018030CEC0
	private void TrySubscribeWs(); // 0x000000018030D1E0-0x000000018030D430
	private void OnDestroy(); // 0x000000018030C3C0-0x000000018030C6C0
	public void StartGameWs(); // 0x000000018030C8A0-0x000000018030CD80
	[IteratorStateMachine(typeof(_WsDisplayTimerCoroutine_d__20))]
	private IEnumerator WsDisplayTimerCoroutine(); // 0x000000018030D840-0x000000018030D8B0
	private void HandleWsTurnEnd(); // 0x000000018030BD50-0x000000018030C3C0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x000000018030BB90-0x000000018030BD50
	private void ResetWsClockAnchor(float remainingSec); // 0x000000018030C780-0x000000018030C7B0
	public void StartGameCoOp(); // 0x000000018030C890-0x000000018030C8A0
	private void TriggerYourTurnEffect(int actorNumber); // 0x000000018030CF00-0x000000018030D1E0
	public void PauseTurn(); // 0x000000018030C6C0-0x000000018030C770
	public void ResumeTurn(); // 0x000000018030C7B0-0x000000018030C890
	public void RequestEndTurnFromClient(); // 0x00000001802E76C0-0x00000001802E76D0
	private void StopTurnTimer(); // 0x000000018030CEC0-0x000000018030CF00
	private static string[] BuildSecStr(); // 0x000000018030BAE0-0x000000018030BB90
	internal void ResetTurnTimerDisplayCache(); // 0x000000018030C770-0x000000018030C780
	private void UpdateTurnTimerUI(float time); // 0x000000018030D5D0-0x000000018030D840
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_0(); // 0x000000018030D430-0x000000018030D4B0
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_1(); // 0x000000018030D4B0-0x000000018030D5A0
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_2(); // 0x000000018030D5A0-0x000000018030D5D0
}

