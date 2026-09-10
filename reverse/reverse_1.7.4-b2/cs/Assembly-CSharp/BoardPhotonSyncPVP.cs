/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class BoardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 141
{
	// Fields
	[SerializeField]
	internal BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	internal static BoardPhotonSyncPVP Instance; // 0x00
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30
	private const float BOOTSTRAP_WAIT_SEC = 6f; // Metadata: 0x0068AB1F
	private const float RESCUE_WAIT_SEC = 6f; // Metadata: 0x0068AB23

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802EC8F0-0x00000001802EC900 0x00000001802EC900-0x00000001802EC910

	// Nested types
	[CompilerGenerated]
	private sealed class _WsBootstrapMatchPvp_d__12 : IEnumerator<object> // TypeDefIndex: 142
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPhotonSyncPVP __4__this; // 0x20
		private float _start_5__2; // 0x28
		private MatchService _ms_5__3; // 0x30
		private float _bootStart_5__4; // 0x38
		private float _rescueStart_5__5; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatchPvp_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018065BAA0-0x000000018065C340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018065C340-0x000000018065C3F0
	}

	// Constructors
	public BoardPhotonSyncPVP(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180645A60-0x0000000180645C50
	private void Start(); // 0x0000000180646130-0x00000001806461B0
	private void OnDestroy(); // 0x0000000180645C50-0x0000000180645D00
	[IteratorStateMachine(typeof(_WsBootstrapMatchPvp_d__12))]
	private IEnumerator WsBootstrapMatchPvp(); // 0x00000001806462D0-0x0000000180646340
	private bool WsBoardHasDots(); // 0x00000001806461B0-0x00000001806462D0
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x0000000180645E40-0x0000000180646130
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x0000000180645D00-0x0000000180645DA0
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x0000000180645DA0-0x0000000180645E40
}

