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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802DC860-0x00000001802DCB10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802DCB10-0x00000001802DCB50
	}

	// Constructors
	public LeanTester(); // 0x00000001802DC810-0x00000001802DC860

	// Methods
	public void Start(); // 0x00000001802DC6C0-0x00000001802DC770
	[IteratorStateMachine(typeof(_timeoutCheck_d__2))]
	private IEnumerator timeoutCheck(); // 0x00000001802DC770-0x00000001802DC810
}

