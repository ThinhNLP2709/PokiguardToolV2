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

public class BoardPhotonSync : MonoBehaviour // TypeDefIndex: 3
{
	// Fields
	[SerializeField]
	internal Board board; // 0x20
	private Active active; // 0x28
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30
	private int _masterDragTurnPauseDepth; // 0x34
	private const float BOOTSTRAP_WAIT_SEC = 6f; // Metadata: 0x0068A748
	private const float RESCUE_WAIT_SEC = 6f; // Metadata: 0x0068A74C

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802EC8F0-0x00000001802EC900 0x00000001802EC900-0x00000001802EC910
	internal bool IsDragTurnPauseActive { get; } // 0x00000001802EC8E0-0x00000001802EC8F0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WsBootstrapMatch_d__11 : IEnumerator<object> // TypeDefIndex: 4
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPhotonSync __4__this; // 0x20
		private float _start_5__2; // 0x28
		private MatchService _ms_5__3; // 0x30
		private float _bootStart_5__4; // 0x38
		private float _rescueStart_5__5; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatch_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180300AA0-0x00000001803013F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803013F0-0x0000000180301430
	}

	// Constructors
	public BoardPhotonSync(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001802EBD40-0x00000001802EBEA0
	private void Start(); // 0x00000001802EC6C0-0x00000001802EC740
	[IteratorStateMachine(typeof(_WsBootstrapMatch_d__11))]
	private IEnumerator WsBootstrapMatch(); // 0x00000001802EC870-0x00000001802EC8E0
	private bool WsBoardHasDots(); // 0x00000001802EC740-0x00000001802EC870
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x00000001802EC390-0x00000001802EC6B0
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x00000001802EC210-0x00000001802EC390
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x00000001802EC160-0x00000001802EC210
	internal void ResetMasterDragTurnPauseTracking(); // 0x00000001802EC6B0-0x00000001802EC6C0
	private void MasterApplyDragTurnPause(); // 0x00000001802EC0B0-0x00000001802EC160
	private void MasterApplyDragTurnResume(); // 0x00000001802EC160-0x00000001802EC210
	internal bool IsBoardFullyStable(); // 0x00000001802EBEA0-0x00000001802EC0B0
}

