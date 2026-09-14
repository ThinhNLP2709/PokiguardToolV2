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

public class TurnManager : MonoBehaviour // TypeDefIndex: 83
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
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x005ED6C3
	private bool hasGameStarted; // 0x71
	private int _lastYourTurnFxTurn; // 0x74
	private int _lastShownSec; // 0x78
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180474B70-0x0000000180474BD0 0x0000000180474BD0-0x0000000180474C80
	public bool HasGameStarted { get; } // 0x00000001802A8640-0x00000001802A8650 

	// Nested types
	[CompilerGenerated]
	private sealed class _WsDisplayTimerCoroutine_d__20 : IEnumerator<object> // TypeDefIndex: 84
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TurnManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsDisplayTimerCoroutine_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180478320-0x00000001804787B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804787B0-0x00000001804787F0
	}

	// Constructors
	public TurnManager(); // 0x0000000180477DB0-0x0000000180477E20
	static TurnManager(); // 0x0000000180477E20-0x0000000180478020

	// Methods
	private void Awake(); // 0x0000000180474C80-0x0000000180474E40
	private void Start(); // 0x0000000180474E40-0x0000000180475240
	private void TrySubscribeWs(); // 0x0000000180475240-0x0000000180475490
	private void OnDestroy(); // 0x0000000180475490-0x0000000180475870
	public void StartGameWs(); // 0x0000000180475870-0x0000000180476180
	[IteratorStateMachine(typeof(_WsDisplayTimerCoroutine_d__20))]
	private IEnumerator WsDisplayTimerCoroutine(); // 0x0000000180476180-0x0000000180476220
	private void HandleWsTurnEnd(); // 0x0000000180476220-0x0000000180476CC0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x0000000180476CC0-0x0000000180476FA0
	private void ResetWsClockAnchor(float remainingSec); // 0x0000000180476FA0-0x0000000180477000
	public void StartGameCoOp(); // 0x0000000180477000-0x0000000180477010
	private void TriggerYourTurnEffect(int actorNumber); // 0x0000000180477010-0x0000000180477610
	public void PauseTurn(); // 0x0000000180477610-0x0000000180477720
	public void ResumeTurn(); // 0x0000000180477720-0x00000001804778F0
	public void RequestEndTurnFromClient(); // 0x000000018028A320-0x000000018028A330
	private void StopTurnTimer(); // 0x00000001804778F0-0x0000000180477970
	private static string[] BuildSecStr(); // 0x0000000180477970-0x0000000180477AC0
	internal void ResetTurnTimerDisplayCache(); // 0x0000000180477AC0-0x0000000180477AD0
	private void UpdateTurnTimerUI(float time); // 0x0000000180477AD0-0x0000000180477DB0
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_0(); // 0x0000000180478020-0x00000001804780B0
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_1(); // 0x00000001804780B0-0x0000000180478290
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__33_2(); // 0x0000000180478290-0x0000000180478320
}

