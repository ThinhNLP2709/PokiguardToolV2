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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

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
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x0068AD78
	private float _srvRemainingAtTick; // 0x60
	private float _srvTickAt; // 0x64
	private bool _srvClockFrozen; // 0x68
	private int _lastShownSec; // 0x6C
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180851670-0x00000001808516C0 0x00000001808516C0-0x0000000180851730

	// Nested types
	[CompilerGenerated]
	private sealed class _ClientDisplayTimerCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 247
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TurnManagerPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClientDisplayTimerCoroutine_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180851E90-0x00000001808520F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808520F0-0x0000000180852130
	}

	// Constructors
	public TurnManagerPVP(); // 0x0000000180851650-0x0000000180851670
	static TurnManagerPVP(); // 0x0000000180851560-0x0000000180851650

	// Methods
	private void Awake(); // 0x00000001808500C0-0x00000001808501B0
	private void Start(); // 0x0000000180850BF0-0x0000000180850EE0
	private void OnDestroy(); // 0x00000001808508C0-0x0000000180850BB0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x00000001808502D0-0x0000000180850470
	private void ResetWsClockAnchor(float remainingSec); // 0x0000000180850BC0-0x0000000180850BF0
	private void HandleWsTurnEnd(); // 0x0000000180850470-0x00000001808508C0
	public void PauseTurn(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void ResumeTurn(); // 0x00000001802EB6C0-0x00000001802EB6D0
	private void TriggerYourTurnEffect(int actorNumber); // 0x0000000180850EE0-0x00000001808511B0
	private void StopTurnTimer(); // 0x0000000180423640-0x0000000180423680
	[IteratorStateMachine(typeof(_ClientDisplayTimerCoroutine_d__27))]
	private IEnumerator ClientDisplayTimerCoroutine(); // 0x0000000180850260-0x00000001808502D0
	private static string[] BuildSecStr(); // 0x00000001808501B0-0x0000000180850260
	internal void ResetTurnTimerDisplayCache(); // 0x0000000180850BB0-0x0000000180850BC0
	private void UpdateTurnTimerUI(float time); // 0x0000000180851350-0x0000000180851560
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_0(); // 0x00000001808511B0-0x0000000180851230
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_1(); // 0x0000000180851230-0x0000000180851320
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_2(); // 0x0000000180851320-0x0000000180851350
}

