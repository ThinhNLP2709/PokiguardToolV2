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

public class BoardController : MonoBehaviour // TypeDefIndex: 2402
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
	private sealed class _SlideIn_d__12 : IEnumerator<object> // TypeDefIndex: 2403
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
		void IDisposable.Dispose(); // 0x0000000180B5C450-0x0000000180B5C4C0
		private bool MoveNext(); // 0x0000000180B5C4C0-0x0000000180B5C830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B5C830-0x0000000180B5C870
	}

	[CompilerGenerated]
	private sealed class _SlideOut_d__13 : IEnumerator<object> // TypeDefIndex: 2404
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
		void IDisposable.Dispose(); // 0x0000000180B5C450-0x0000000180B5C4C0
		private bool MoveNext(); // 0x0000000180B5C870-0x0000000180B5CC50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B5CC50-0x0000000180B5CC90
	}

	// Constructors
	public BoardController(); // 0x0000000180B5C3D0-0x0000000180B5C450

	// Methods
	public void LoadBoardCard(); // 0x0000000180B5B980-0x0000000180B5BC20
	public void LoadBoardUpdate(); // 0x0000000180B5BC20-0x0000000180B5BD40
	public void LoadBoard(); // 0x0000000180B5BD40-0x0000000180B5BE60
	public void CloseBoard(); // 0x0000000180B5BE60-0x0000000180B5C110
	public void CloseUpdateBoard(); // 0x0000000180B5C110-0x0000000180B5C1B0
	[IteratorStateMachine(typeof(_SlideIn_d__12))]
	private IEnumerator SlideIn(GameObject board); // 0x0000000180B5C1B0-0x0000000180B5C2C0
	[IteratorStateMachine(typeof(_SlideOut_d__13))]
	private IEnumerator SlideOut(GameObject board); // 0x0000000180B5C2C0-0x0000000180B5C3D0
}

