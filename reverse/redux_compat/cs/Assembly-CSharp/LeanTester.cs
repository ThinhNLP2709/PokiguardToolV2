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

public class LeanTester : MonoBehaviour // TypeDefIndex: 290
{
	// Fields
	public float timeout; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _timeoutCheck_d__2 : IEnumerator<object> // TypeDefIndex: 291
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LeanTester __4__this; // 0x20
		private float _pauseEndTime_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _timeoutCheck_d__2(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806E3D20-0x00000001806E3EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E3EA0-0x00000001806E3EE0
	}

	// Constructors
	public LeanTester(); // 0x00000001806D2ED0-0x00000001806D2EE0

	// Methods
	public void Start(); // 0x00000001806D2E50-0x00000001806D2ED0
	[IteratorStateMachine(typeof(_timeoutCheck_d__2))]
	private IEnumerator timeoutCheck(); // 0x00000001806D2EE0-0x00000001806D2F50
}

