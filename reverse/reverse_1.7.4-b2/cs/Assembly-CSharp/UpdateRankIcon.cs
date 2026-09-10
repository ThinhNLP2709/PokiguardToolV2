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

public class UpdateRankIcon : MonoBehaviour, IHubSuspendable // TypeDefIndex: 260
{
	// Fields
	public UnityEngine.UI.Text txtSource; // 0x20
	public Image imgRankIcon; // 0x28
	private string _appliedIconName; // 0x30
	private Coroutine _loop; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _UpdateLoop_d__8 : IEnumerator<object> // TypeDefIndex: 261
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public UpdateRankIcon __4__this; // 0x20
		private WaitForSeconds _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateLoop_d__8(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180853A40-0x0000000180853B10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180853B10-0x0000000180853B50
	}

	// Constructors
	public UpdateRankIcon(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void OnEnable(); // 0x0000000180856510-0x0000000180856570
	private void OnDisable(); // 0x0000000180856490-0x0000000180856510
	private void StartLoop(); // 0x00000001808565F0-0x0000000180856700
	private void StopLoop(); // 0x00000001808565B0-0x00000001808565F0
	[IteratorStateMachine(typeof(_UpdateLoop_d__8))]
	private IEnumerator UpdateLoop(); // 0x0000000180856A50-0x0000000180856AC0
	private void UpdateIcon(); // 0x0000000180856700-0x0000000180856A50
	public void OnHubSuspend(); // 0x00000001808565B0-0x00000001808565F0
	public void OnHubResume(); // 0x0000000180856570-0x00000001808565B0
	private string GetIconName(int points); // 0x00000001808562B0-0x0000000180856490
}

