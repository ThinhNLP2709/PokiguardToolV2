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

public class delayAndRender : MonoBehaviour // TypeDefIndex: 1717
{
	// Fields
	public GameObject offBoardParent; // 0x20
	public GameObject onListDot; // 0x28

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayedRendering_d__3 : IEnumerator<object> // TypeDefIndex: 1718
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public delayAndRender __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DelayedRendering_d__3(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E4A90-0x00000001805E4BA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E4BA0-0x00000001805E4BE0
	}

	// Constructors
	public delayAndRender(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void CheckForStableBoardAfterFill(); // 0x00000001805E9D30-0x00000001805E9DB0
	[IteratorStateMachine(typeof(_DelayedRendering_d__3))]
	private IEnumerator DelayedRendering(); // 0x00000001805E9DB0-0x00000001805E9E20
}

