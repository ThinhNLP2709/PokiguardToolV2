/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class BoardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 139
{
	// Fields
	[SerializeField]
	internal BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	internal static BoardPhotonSyncPVP Instance; // 0x00
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30
	private const float BOOTSTRAP_WAIT_SEC = 6f; // Metadata: 0x005ED742
	private const float RESCUE_WAIT_SEC = 6f; // Metadata: 0x005ED746

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028CE40-0x000000018028CE50 0x000000018028CE50-0x000000018028CE60

	// Nested types
	[CompilerGenerated]
	private sealed class _WsBootstrapMatchPvp_d__12 : IEnumerator<object> // TypeDefIndex: 140
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatchPvp_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001807B3680-0x00000001807B43F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B43F0-0x00000001807B4430
	}

	// Constructors
	public BoardPhotonSyncPVP(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001807B2560-0x00000001807B2A90
	private void Start(); // 0x00000001807B2A90-0x00000001807B2B40
	private void OnDestroy(); // 0x00000001807B2B40-0x00000001807B2D20
	[IteratorStateMachine(typeof(_WsBootstrapMatchPvp_d__12))]
	private IEnumerator WsBootstrapMatchPvp(); // 0x00000001807B2D20-0x00000001807B2DC0
	private bool WsBoardHasDots(); // 0x00000001807B2DC0-0x00000001807B3010
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x00000001807B3010-0x00000001807B3520
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x00000001807B3520-0x00000001807B35D0
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x00000001807B35D0-0x00000001807B3680
}

