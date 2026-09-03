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

public class UpdateRankIcon : MonoBehaviour, IHubSuspendable // TypeDefIndex: 234
{
	// Fields
	public UnityEngine.UI.Text txtSource; // 0x20
	public Image imgRankIcon; // 0x28
	private string _appliedIconName; // 0x30
	private Coroutine _loop; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _UpdateLoop_d__8 : IEnumerator<object> // TypeDefIndex: 235
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public UpdateRankIcon __4__this; // 0x20
		private WaitForSeconds _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateLoop_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001806A5F90-0x00000001806A6060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A6060-0x00000001806A60A0
	}

	// Constructors
	public UpdateRankIcon(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void OnEnable(); // 0x00000001806A8CA0-0x00000001806A8D00
	private void OnDisable(); // 0x00000001806A8C20-0x00000001806A8CA0
	private void StartLoop(); // 0x00000001806A8D80-0x00000001806A8E90
	private void StopLoop(); // 0x00000001806A8D40-0x00000001806A8D80
	[IteratorStateMachine(typeof(_UpdateLoop_d__8))]
	private IEnumerator UpdateLoop(); // 0x00000001806A91E0-0x00000001806A9250
	private void UpdateIcon(); // 0x00000001806A8E90-0x00000001806A91E0
	public void OnHubSuspend(); // 0x00000001806A8D40-0x00000001806A8D80
	public void OnHubResume(); // 0x00000001806A8D00-0x00000001806A8D40
	private string GetIconName(int points); // 0x00000001806A8A40-0x00000001806A8C20
}

