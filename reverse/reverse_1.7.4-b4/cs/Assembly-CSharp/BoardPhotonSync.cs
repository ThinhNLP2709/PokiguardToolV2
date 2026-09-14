/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class BoardPhotonSync : MonoBehaviour // TypeDefIndex: 3
{
	// Fields
	[SerializeField]
	internal Board board; // 0x20
	private Active active; // 0x28
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30
	private int _masterDragTurnPauseDepth; // 0x34
	private const float BOOTSTRAP_WAIT_SEC = 6f; // Metadata: 0x005EE5E8
	private const float RESCUE_WAIT_SEC = 6f; // Metadata: 0x005EE5EC

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028CE40-0x000000018028CE50 0x000000018028CE50-0x000000018028CE60
	internal bool IsDragTurnPauseActive { get; } // 0x000000018028DDF0-0x000000018028DE00 

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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatch_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018028E1E0-0x000000018028EDE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018028EDF0-0x000000018028EE30
	}

	// Constructors
	public BoardPhotonSync(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x000000018028CE60-0x000000018028D210
	private void Start(); // 0x000000018028D210-0x000000018028D2C0
	[IteratorStateMachine(typeof(_WsBootstrapMatch_d__11))]
	private IEnumerator WsBootstrapMatch(); // 0x000000018028D2C0-0x000000018028D360
	private bool WsBoardHasDots(); // 0x000000018028D360-0x000000018028D5B0
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x000000018028D5B0-0x000000018028DB20
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x000000018028DB20-0x000000018028DD70
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x000000018028DD70-0x000000018028DDE0
	internal void ResetMasterDragTurnPauseTracking(); // 0x000000018028DDE0-0x000000018028DDF0
	private void MasterApplyDragTurnPause(); // 0x000000018028DE00-0x000000018028DE70
	private void MasterApplyDragTurnResume(); // 0x000000018028DD70-0x000000018028DDE0
	internal bool IsBoardFullyStable(); // 0x000000018028DE70-0x000000018028E160
}

