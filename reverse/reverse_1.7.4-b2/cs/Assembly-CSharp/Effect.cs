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

public class Effect : MonoBehaviour // TypeDefIndex: 1931
{
	// Nested types
	[CompilerGenerated]
	private sealed class _FadeAndMoveUp_d__0 : IEnumerator<object> // TypeDefIndex: 1932
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject target; // 0x20
		private float _duration_5__2; // 0x28
		private float _timeElapsed_5__3; // 0x2C
		private CanvasGroup _canvasGroup_5__4; // 0x30
		private RectTransform _rect_5__5; // 0x38
		private Vector2 _startPos_5__6; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUp_d__0(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180425260-0x00000001804252A0
		private bool MoveNext(); // 0x00000001806F48D0-0x00000001806F4B70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F4B70-0x00000001806F4BB0
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__1 : IEnumerator<object> // TypeDefIndex: 1933
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject item; // 0x20
		private CanvasGroup _canvasGroup_5__2; // 0x28
		private float _alpha_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__1(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018070C3C0-0x000000018070C520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070C520-0x000000018070C560
	}

	// Constructors
	public Effect(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[IteratorStateMachine(typeof(_FadeAndMoveUp_d__0))]
	public IEnumerator FadeAndMoveUp(GameObject target); // 0x00000001806F2690-0x00000001806F2700
	[IteratorStateMachine(typeof(_FadeOut_d__1))]
	public IEnumerator FadeOut(GameObject item); // 0x00000001806F2700-0x00000001806F2770
}

