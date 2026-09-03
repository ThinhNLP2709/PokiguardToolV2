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

public class TurnManagerPVP : MonoBehaviour // TypeDefIndex: 220
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
	private const float TimerNewTurnJumpSec = 1.5f; // Metadata: 0x0064C060
	private float _srvRemainingAtTick; // 0x60
	private float _srvTickAt; // 0x64
	private bool _srvClockFrozen; // 0x68
	private int _lastShownSec; // 0x6C
	private static readonly string[] SecStr; // 0x08

	// Properties
	public static TurnManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806A3F40-0x00000001806A3F90 0x00000001806A3F90-0x00000001806A4000

	// Nested types
	[CompilerGenerated]
	private sealed class _ClientDisplayTimerCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 221
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TurnManagerPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClientDisplayTimerCoroutine_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4750-0x00000001806A49B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A49B0-0x00000001806A49F0
	}

	// Constructors
	public TurnManagerPVP(); // 0x00000001806A3F20-0x00000001806A3F40
	static TurnManagerPVP(); // 0x00000001806A3E30-0x00000001806A3F20

	// Methods
	private void Awake(); // 0x00000001806A2A60-0x00000001806A2B50
	private void Start(); // 0x00000001806A34F0-0x00000001806A37E0
	private void OnDestroy(); // 0x00000001806A31C0-0x00000001806A34B0
	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec); // 0x00000001806A2C70-0x00000001806A2E10
	private void ResetWsClockAnchor(float remainingSec); // 0x00000001806A34C0-0x00000001806A34F0
	private void HandleWsTurnEnd(); // 0x00000001806A2E10-0x00000001806A31C0
	public void PauseTurn(); // 0x00000001802E76C0-0x00000001802E76D0
	public void ResumeTurn(); // 0x00000001802E76C0-0x00000001802E76D0
	private void TriggerYourTurnEffect(int actorNumber); // 0x00000001806A37E0-0x00000001806A3A80
	private void StopTurnTimer(); // 0x000000018030CEC0-0x000000018030CF00
	[IteratorStateMachine(typeof(_ClientDisplayTimerCoroutine_d__27))]
	private IEnumerator ClientDisplayTimerCoroutine(); // 0x00000001806A2C00-0x00000001806A2C70
	private static string[] BuildSecStr(); // 0x00000001806A2B50-0x00000001806A2C00
	internal void ResetTurnTimerDisplayCache(); // 0x00000001806A34B0-0x00000001806A34C0
	private void UpdateTurnTimerUI(float time); // 0x00000001806A3C20-0x00000001806A3E30
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_0(); // 0x00000001806A3A80-0x00000001806A3B00
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_1(); // 0x00000001806A3B00-0x00000001806A3BF0
	[CompilerGenerated]
	private void _TriggerYourTurnEffect_b__25_2(); // 0x00000001806A3BF0-0x00000001806A3C20
}

