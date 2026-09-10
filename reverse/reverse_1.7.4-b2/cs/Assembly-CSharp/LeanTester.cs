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

public class LeanTester : MonoBehaviour // TypeDefIndex: 316
{
	// Fields
	public float timeout; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _timeoutCheck_d__2 : IEnumerator<object> // TypeDefIndex: 317
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LeanTester __4__this; // 0x20
		private float _pauseEndTime_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _timeoutCheck_d__2(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180330BA0-0x0000000180330D20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180330D20-0x0000000180331010
	}

	// Constructors
	public LeanTester(); // 0x000000018031FD50-0x000000018031FD60

	// Methods
	public void Start(); // 0x000000018031FCD0-0x000000018031FD50
	[IteratorStateMachine(typeof(_timeoutCheck_d__2))]
	private IEnumerator timeoutCheck(); // 0x000000018031FD60-0x000000018031FDD0
}

