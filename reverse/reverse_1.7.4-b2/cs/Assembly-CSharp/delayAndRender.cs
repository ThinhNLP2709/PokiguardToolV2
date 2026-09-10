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

public class delayAndRender : MonoBehaviour // TypeDefIndex: 1996
{
	// Fields
	public GameObject offBoardParent; // 0x20
	public GameObject onListDot; // 0x28

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayedRendering_d__3 : IEnumerator<object> // TypeDefIndex: 1997
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public delayAndRender __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DelayedRendering_d__3(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807239A0-0x0000000180723AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180723AB0-0x0000000180723AF0
	}

	// Constructors
	public delayAndRender(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void CheckForStableBoardAfterFill(); // 0x0000000180727DC0-0x0000000180727E40
	[IteratorStateMachine(typeof(_DelayedRendering_d__3))]
	private IEnumerator DelayedRendering(); // 0x0000000180727E40-0x0000000180727EB0
}

