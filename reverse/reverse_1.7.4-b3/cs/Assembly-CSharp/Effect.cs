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

public class Effect : MonoBehaviour // TypeDefIndex: 2297
{
	// Nested types
	[CompilerGenerated]
	private sealed class _FadeAndMoveUp_d__0 : IEnumerator<object> // TypeDefIndex: 2298
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUp_d__0(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180469F80-0x000000018046A040
		private bool MoveNext(); // 0x0000000180AE9F80-0x0000000180AEA5B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AEA5B0-0x0000000180AEA5F0
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__1 : IEnumerator<object> // TypeDefIndex: 2299
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject item; // 0x20
		private CanvasGroup _canvasGroup_5__2; // 0x28
		private float _alpha_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__1(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180AEA5F0-0x0000000180AEA940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AEA940-0x0000000180AEA980
	}

	// Constructors
	public Effect(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[IteratorStateMachine(typeof(_FadeAndMoveUp_d__0))]
	public IEnumerator FadeAndMoveUp(GameObject target); // 0x0000000180AE9E40-0x0000000180AE9EE0
	[IteratorStateMachine(typeof(_FadeOut_d__1))]
	public IEnumerator FadeOut(GameObject item); // 0x0000000180AE9EE0-0x0000000180AE9F80
}

