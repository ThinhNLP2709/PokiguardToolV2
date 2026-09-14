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

public class delayAndRender : MonoBehaviour // TypeDefIndex: 2400
{
	// Fields
	public GameObject offBoardParent; // 0x20
	public GameObject onListDot; // 0x28

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayedRendering_d__3 : IEnumerator<object> // TypeDefIndex: 2401
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public delayAndRender __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DelayedRendering_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B680A0-0x0000000180B68340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B68340-0x0000000180B68380
	}

	// Constructors
	public delayAndRender(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void CheckForStableBoardAfterFill(); // 0x0000000180B67F50-0x0000000180B68000
	[IteratorStateMachine(typeof(_DelayedRendering_d__3))]
	private IEnumerator DelayedRendering(); // 0x0000000180B68000-0x0000000180B680A0
}

