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

public class Effect : MonoBehaviour // TypeDefIndex: 1658
{
	// Nested types
	[CompilerGenerated]
	private sealed class _FadeAndMoveUp_d__0 : IEnumerator<object> // TypeDefIndex: 1659
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUp_d__0(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
		private bool MoveNext(); // 0x00000001805CEFB0-0x00000001805CF250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CF250-0x00000001805CF290
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__1 : IEnumerator<object> // TypeDefIndex: 1660
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject item; // 0x20
		private CanvasGroup _canvasGroup_5__2; // 0x28
		private float _alpha_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__1(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805CF290-0x00000001805CF3F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CF3F0-0x00000001805CF430
	}

	// Constructors
	public Effect(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[IteratorStateMachine(typeof(_FadeAndMoveUp_d__0))]
	public IEnumerator FadeAndMoveUp(GameObject target); // 0x00000001805C8AC0-0x00000001805C8B30
	[IteratorStateMachine(typeof(_FadeOut_d__1))]
	public IEnumerator FadeOut(GameObject item); // 0x00000001805C8B30-0x00000001805C8BA0
}

