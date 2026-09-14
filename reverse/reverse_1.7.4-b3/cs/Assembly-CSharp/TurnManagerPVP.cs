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
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x005ED9A3
	private float _srvRemainingAtTick; // 0x60
	private float _srvTickAt; // 0x64
	private bool _srvClockFrozen; // 0x68
	private int _lastShownSec; // 0x6C
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D58590-0x0000000180D585F0 0x0000000180D585F0-0x0000000180D586A0

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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D5ABE0-0x0000000180D5AF70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D5AF70-0x0000000180D5AFB0
	}

	// Constructors
	public TurnManagerPVP(); // 0x0000000180D5A680-0x0000000180D5A6E0
	static TurnManagerPVP(); // 0x0000000180D5A6E0-0x0000000180D5A8E0

	// Methods
	private void Awake(); // 0x0000000180D586A0-0x0000000180D58860
	private void Start(); // 0x0000000180D58860-0x0000000180D58E30
	private void OnDestroy(); // 0x0000000180D58E30-0x0000000180D591F0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x0000000180D591F0-0x0000000180D594B0
	private void ResetWsClockAnchor(float remainingSec); // 0x0000000180D594B0-0x0000000180D59510
	private void HandleWsTurnEnd(); // 0x0000000180D59510-0x0000000180D59D10
	public void PauseTurn(); // 0x000000018028A320-0x000000018028A330
	public void ResumeTurn(); // 0x000000018028A320-0x000000018028A330
	private void TriggerYourTurnEffect(int actorNumber); // 0x0000000180D59D10-0x0000000180D5A2A0
	private void StopTurnTimer(); // 0x00000001804778F0-0x0000000180477970
	[IteratorStateMachine(typeof(_ClientDisplayTimerCoroutine_d__27))]
	private IEnumerator ClientDisplayTimerCoroutine(); // 0x0000000180D5A2A0-0x0000000180D5A340
	private static string[] BuildSecStr(); // 0x0000000180D5A340-0x0000000180D5A490
	internal void ResetTurnTimerDisplayCache(); // 0x0000000180D5A490-0x0000000180D5A4A0
	private void UpdateTurnTimerUI(float time); // 0x0000000180D5A4A0-0x0000000180D5A680
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_0(); // 0x0000000180D5A8E0-0x0000000180D5A970
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_1(); // 0x0000000180D5A970-0x0000000180D5AB50
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_2(); // 0x0000000180D5AB50-0x0000000180D5ABE0
}

