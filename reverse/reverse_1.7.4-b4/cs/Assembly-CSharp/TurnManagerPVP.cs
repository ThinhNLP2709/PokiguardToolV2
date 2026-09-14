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

public class TurnManagerPVP : MonoBehaviour // TypeDefIndex: 246
{
	// Fields
	[CompilerGenerated]
	private static TurnManagerPVP _Instance_k__BackingField; // 0x00
	[Header("References")]
	[SerializeField]
	private ActivePVP active; // 0x20
	[SerializeField]
	private BoardPVP board; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text countdownText; // 0x30
	public YourTurnEffect yourTurnEffect; // 0x38
	public GameObject LoadingPanel; // 0x40
	[Header("Turn Settings")]
	[SerializeField]
	private float turnDuration; // 0x48
	[SerializeField]
	[Tooltip("Legacy \u2014 kh\u00F4ng d\u00F9ng \u1EDF WS (timer server-side). Gi\u1EEF field \u0111\u1EC3 scene kh\u00F4ng m\u1EA5t serialized data.")]
	private float turnTransitionDelay; // 0x4C
	private float syncedTurnTime; // 0x50
	private Coroutine turnTimerCoroutine; // 0x58
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x005EED73
	private float _srvRemainingAtTick; // 0x60
	private float _srvTickAt; // 0x64
	private bool _srvClockFrozen; // 0x68
	private int _lastShownSec; // 0x6C
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D66350-0x0000000180D663B0 0x0000000180D663B0-0x0000000180D66460

	// Nested types
	[CompilerGenerated]
	private sealed class _ClientDisplayTimerCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 247
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TurnManagerPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClientDisplayTimerCoroutine_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D689A0-0x0000000180D68D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D68D30-0x0000000180D68D70
	}

	// Constructors
	public TurnManagerPVP(); // 0x0000000180D68440-0x0000000180D684A0
	static TurnManagerPVP(); // 0x0000000180D684A0-0x0000000180D686A0

	// Methods
	private void Awake(); // 0x0000000180D66460-0x0000000180D66620
	private void Start(); // 0x0000000180D66620-0x0000000180D66BF0
	private void OnDestroy(); // 0x0000000180D66BF0-0x0000000180D66FB0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x0000000180D66FB0-0x0000000180D67270
	private void ResetWsClockAnchor(float remainingSec); // 0x0000000180D67270-0x0000000180D672D0
	private void HandleWsTurnEnd(); // 0x0000000180D672D0-0x0000000180D67AD0
	public void PauseTurn(); // 0x000000018028A320-0x000000018028A330
	public void ResumeTurn(); // 0x000000018028A320-0x000000018028A330
	private void TriggerYourTurnEffect(int actorNumber); // 0x0000000180D67AD0-0x0000000180D68060
	private void StopTurnTimer(); // 0x0000000180478B60-0x0000000180478BE0
	[IteratorStateMachine(typeof(_ClientDisplayTimerCoroutine_d__27))]
	private IEnumerator ClientDisplayTimerCoroutine(); // 0x0000000180D68060-0x0000000180D68100
	private static string[] BuildSecStr(); // 0x0000000180D68100-0x0000000180D68250
	internal void ResetTurnTimerDisplayCache(); // 0x0000000180D68250-0x0000000180D68260
	private void UpdateTurnTimerUI(float time); // 0x0000000180D68260-0x0000000180D68440
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_0(); // 0x0000000180D686A0-0x0000000180D68730
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_1(); // 0x0000000180D68730-0x0000000180D68910
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_2(); // 0x0000000180D68910-0x0000000180D689A0
}

