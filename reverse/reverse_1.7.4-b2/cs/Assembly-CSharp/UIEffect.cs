/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class UIEffect : MonoBehaviour // TypeDefIndex: 1993
{
	// Fields
	public UnityEngine.UI.Text uiText; // 0x20
	public float displayDuration; // 0x28
	public float fadeDuration; // 0x2C
	public float moveUpDistance; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _DisplayAndFade_d__5 : IEnumerator<object> // TypeDefIndex: 1994
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public UIEffect __4__this; // 0x20
		private Vector3 _startPos_5__2; // 0x28
		private Vector3 _targetPos_5__3; // 0x34
		private Color _startColor_5__4; // 0x40
		private Color _targetColor_5__5; // 0x50
		private float _elapsedTime_5__6; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayAndFade_d__5(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180723AF0-0x0000000180723F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180723F20-0x0000000180723F60
	}

	// Constructors
	public UIEffect(); // 0x00000001807277C0-0x00000001807277E0

	// Methods
	public void ShowWithEffect(string text); // 0x0000000180727700-0x00000001807277C0
	[IteratorStateMachine(typeof(_DisplayAndFade_d__5))]
	private IEnumerator DisplayAndFade(); // 0x0000000180727690-0x0000000180727700
}

