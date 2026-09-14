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

public class LeanTester : MonoBehaviour // TypeDefIndex: 313
{
	// Fields
	public float timeout; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _timeoutCheck_d__2 : IEnumerator<object> // TypeDefIndex: 314
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LeanTester __4__this; // 0x20
		private float _pauseEndTime_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _timeoutCheck_d__2(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802DC830-0x00000001802DCAE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802DCAE0-0x00000001802DCB20
	}

	// Constructors
	public LeanTester(); // 0x00000001802DC7E0-0x00000001802DC830

	// Methods
	public void Start(); // 0x00000001802DC690-0x00000001802DC740
	[IteratorStateMachine(typeof(_timeoutCheck_d__2))]
	private IEnumerator timeoutCheck(); // 0x00000001802DC740-0x00000001802DC7E0
}

