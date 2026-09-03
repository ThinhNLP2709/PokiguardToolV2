/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class BoardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 130
{
	// Fields
	[SerializeField]
	internal BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	internal static BoardPhotonSyncPVP Instance; // 0x00
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970

	// Nested types
	[CompilerGenerated]
	private sealed class _WsBootstrapMatchPvp_d__10 : IEnumerator<object> // TypeDefIndex: 131
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPhotonSyncPVP __4__this; // 0x20
		private float _start_5__2; // 0x28
		private MatchService _ms_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatchPvp_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018052C970-0x000000018052CEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052CEC0-0x000000018052CF00
	}

	// Constructors
	public BoardPhotonSyncPVP(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x0000000180517E30-0x0000000180518020
	private void Start(); // 0x0000000180518500-0x0000000180518580
	private void OnDestroy(); // 0x0000000180518020-0x00000001805180D0
	[IteratorStateMachine(typeof(_WsBootstrapMatchPvp_d__10))]
	private IEnumerator WsBootstrapMatchPvp(); // 0x00000001805186A0-0x0000000180518710
	private bool WsBoardHasDots(); // 0x0000000180518580-0x00000001805186A0
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x0000000180518210-0x0000000180518500
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x00000001805180D0-0x0000000180518170
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x0000000180518170-0x0000000180518210
}

