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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateLoop_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180D68A90-0x0000000180D68BF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D68BF0-0x0000000180D68C30
	}

	// Constructors
	public UpdateRankIcon(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void OnEnable(); // 0x0000000180D67E40-0x0000000180D67EA0
	private void OnDisable(); // 0x0000000180D67EA0-0x0000000180D67F00
	private void StartLoop(); // 0x0000000180D67F00-0x0000000180D68060
	private void StopLoop(); // 0x0000000180D68060-0x0000000180D680E0
	[IteratorStateMachine(typeof(_UpdateLoop_d__8))]
	private IEnumerator UpdateLoop(); // 0x0000000180D680E0-0x0000000180D68180
	private void UpdateIcon(); // 0x0000000180D68180-0x0000000180D687D0
	public void OnHubSuspend(); // 0x0000000180D687D0-0x0000000180D687E0
	public void OnHubResume(); // 0x0000000180D687E0-0x0000000180D68860
	private string GetIconName(int points); // 0x0000000180D68860-0x0000000180D68A90
}

