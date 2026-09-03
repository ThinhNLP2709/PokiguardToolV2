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

public class BoardController : MonoBehaviour // TypeDefIndex: 1729
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
	private sealed class _SlideIn_d__12 : IEnumerator<object> // TypeDefIndex: 1730
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SlideIn_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E8330-0x00000001805E8360
		private bool MoveNext(); // 0x00000001805E8120-0x00000001805E82F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E82F0-0x00000001805E8330
	}

	[CompilerGenerated]
	private sealed class _SlideOut_d__13 : IEnumerator<object> // TypeDefIndex: 1731
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SlideOut_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E8330-0x00000001805E8360
		private bool MoveNext(); // 0x00000001805E8360-0x00000001805E8550
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8550-0x00000001805E8590
	}

	// Constructors
	public BoardController(); // 0x00000001805D4FD0-0x00000001805D5010

	// Methods
	public void LoadBoardCard(); // 0x00000001805D4D40-0x00000001805D4DD0
	public void LoadBoardUpdate(); // 0x00000001805D4DD0-0x00000001805D4E40
	public void LoadBoard(); // 0x00000001805D4E40-0x00000001805D4EB0
	public void CloseBoard(); // 0x00000001805D4C10-0x00000001805D4CF0
	public void CloseUpdateBoard(); // 0x00000001805D4CF0-0x00000001805D4D40
	[IteratorStateMachine(typeof(_SlideIn_d__12))]
	private IEnumerator SlideIn(GameObject board); // 0x00000001805D4EB0-0x00000001805D4F40
	[IteratorStateMachine(typeof(_SlideOut_d__13))]
	private IEnumerator SlideOut(GameObject board); // 0x00000001805D4F40-0x00000001805D4FD0
}

