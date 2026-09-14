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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
		private bool MoveNext(); // 0x0000000180D76870-0x0000000180D769D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D769D0-0x0000000180D76A10
	}

	// Constructors
	public UpdateRankIcon(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void OnEnable(); // 0x0000000180D75C20-0x0000000180D75C80
	private void OnDisable(); // 0x0000000180D75C80-0x0000000180D75CE0
	private void StartLoop(); // 0x0000000180D75CE0-0x0000000180D75E40
	private void StopLoop(); // 0x0000000180D75E40-0x0000000180D75EC0
	[IteratorStateMachine(typeof(_UpdateLoop_d__8))]
	private IEnumerator UpdateLoop(); // 0x0000000180D75EC0-0x0000000180D75F60
	private void UpdateIcon(); // 0x0000000180D75F60-0x0000000180D765B0
	public void OnHubSuspend(); // 0x0000000180D765B0-0x0000000180D765C0
	public void OnHubResume(); // 0x0000000180D765C0-0x0000000180D76640
	private string GetIconName(int points); // 0x0000000180D76640-0x0000000180D76870
}

