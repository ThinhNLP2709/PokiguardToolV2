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

public class BoardController : MonoBehaviour // TypeDefIndex: 2008
{
	// Fields
	public GameObject boardPet; // 0x20
	public GameObject boardUpdate; // 0x28
	public float slideDuration; // 0x30
	public Vector3 hiddenPosition; // 0x34
	public Vector3 visiblePosition; // 0x40
	public GameObject btnDown; // 0x50
	public GameObject boardCard; // 0x58

	// Nested types
	[CompilerGenerated]
	private sealed class _SlideIn_d__12 : IEnumerator<object> // TypeDefIndex: 2009
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardController __4__this; // 0x20
		public GameObject board; // 0x28
		private float _elapsed_5__2; // 0x30
		private Vector3 _startPos_5__3; // 0x34
		private Vector3 _endPos_5__4; // 0x40
		private RectTransform _rectTransform_5__5; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SlideIn_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180725850-0x0000000180725880
		private bool MoveNext(); // 0x0000000180725640-0x0000000180725810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180725810-0x0000000180725850
	}

	[CompilerGenerated]
	private sealed class _SlideOut_d__13 : IEnumerator<object> // TypeDefIndex: 2010
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardController __4__this; // 0x20
		public GameObject board; // 0x28
		private float _elapsed_5__2; // 0x30
		private Vector3 _startPos_5__3; // 0x34
		private Vector3 _endPos_5__4; // 0x40
		private RectTransform _rectTransform_5__5; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SlideOut_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180725850-0x0000000180725880
		private bool MoveNext(); // 0x0000000180725880-0x0000000180725A70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180725A70-0x0000000180725AB0
	}

	// Constructors
	public BoardController(); // 0x0000000180712890-0x00000001807128D0

	// Methods
	public void LoadBoardCard(); // 0x0000000180712600-0x0000000180712690
	public void LoadBoardUpdate(); // 0x0000000180712690-0x0000000180712700
	public void LoadBoard(); // 0x0000000180712700-0x0000000180712770
	public void CloseBoard(); // 0x00000001807124D0-0x00000001807125B0
	public void CloseUpdateBoard(); // 0x00000001807125B0-0x0000000180712600
	[IteratorStateMachine(typeof(_SlideIn_d__12))]
	private IEnumerator SlideIn(GameObject board); // 0x0000000180712770-0x0000000180712800
	[IteratorStateMachine(typeof(_SlideOut_d__13))]
	private IEnumerator SlideOut(GameObject board); // 0x0000000180712800-0x0000000180712890
}

