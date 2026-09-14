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

public class BoardController : MonoBehaviour // TypeDefIndex: 2409
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
	private sealed class _SlideIn_d__12 : IEnumerator<object> // TypeDefIndex: 2410
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SlideIn_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B69790-0x0000000180B69800
		private bool MoveNext(); // 0x0000000180B69800-0x0000000180B69B70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B69B70-0x0000000180B69BB0
	}

	[CompilerGenerated]
	private sealed class _SlideOut_d__13 : IEnumerator<object> // TypeDefIndex: 2411
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SlideOut_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B69790-0x0000000180B69800
		private bool MoveNext(); // 0x0000000180B69BB0-0x0000000180B69F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B69F90-0x0000000180B69FD0
	}

	// Constructors
	public BoardController(); // 0x0000000180B69710-0x0000000180B69790

	// Methods
	public void LoadBoardCard(); // 0x0000000180B68CC0-0x0000000180B68F60
	public void LoadBoardUpdate(); // 0x0000000180B68F60-0x0000000180B69080
	public void LoadBoard(); // 0x0000000180B69080-0x0000000180B691A0
	public void CloseBoard(); // 0x0000000180B691A0-0x0000000180B69450
	public void CloseUpdateBoard(); // 0x0000000180B69450-0x0000000180B694F0
	[IteratorStateMachine(typeof(_SlideIn_d__12))]
	private IEnumerator SlideIn(GameObject board); // 0x0000000180B694F0-0x0000000180B69600
	[IteratorStateMachine(typeof(_SlideOut_d__13))]
	private IEnumerator SlideOut(GameObject board); // 0x0000000180B69600-0x0000000180B69710
}

