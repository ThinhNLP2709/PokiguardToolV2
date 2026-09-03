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

public class BoardPhotonSync : MonoBehaviour // TypeDefIndex: 3
{
	// Fields
	[SerializeField]
	internal Board board; // 0x20
	private Active active; // 0x28
	[CompilerGenerated]
	private bool _isPendingServerResponse_k__BackingField; // 0x30
	private int _masterDragTurnPauseDepth; // 0x34

	// Properties
	public bool isPendingServerResponse { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
	internal bool IsDragTurnPauseActive { get; } // 0x00000001802E8940-0x00000001802E8950 

	// Nested types
	[CompilerGenerated]
	private sealed class _WsBootstrapMatch_d__9 : IEnumerator<object> // TypeDefIndex: 4
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPhotonSync __4__this; // 0x20
		private float _start_5__2; // 0x28
		private MatchService _ms_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsBootstrapMatch_d__9(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001802FB2B0-0x00000001802FB860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FB860-0x00000001802FB8A0
	}

	// Constructors
	public BoardPhotonSync(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001802E7DA0-0x00000001802E7F00
	private void Start(); // 0x00000001802E8720-0x00000001802E87A0
	[IteratorStateMachine(typeof(_WsBootstrapMatch_d__9))]
	private IEnumerator WsBootstrapMatch(); // 0x00000001802E88D0-0x00000001802E8940
	private bool WsBoardHasDots(); // 0x00000001802E87A0-0x00000001802E88D0
	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null); // 0x00000001802E83F0-0x00000001802E8710
	public void RequestPauseTurnTimerForDrag(int actorNumber); // 0x00000001802E8270-0x00000001802E83F0
	public void RequestResumeTurnTimerAfterDrag(int actorNumber); // 0x00000001802E81C0-0x00000001802E8270
	internal void ResetMasterDragTurnPauseTracking(); // 0x00000001802E8710-0x00000001802E8720
	private void MasterApplyDragTurnPause(); // 0x00000001802E8110-0x00000001802E81C0
	private void MasterApplyDragTurnResume(); // 0x00000001802E81C0-0x00000001802E8270
	internal bool IsBoardFullyStable(); // 0x00000001802E7F00-0x00000001802E8110
}

