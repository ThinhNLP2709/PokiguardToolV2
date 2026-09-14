/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GetNameOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2413
{
	// Fields
	private BoardController boardController; // 0x20
	private LoadRoom loadRoom; // 0x28
	private bool isPointerInside; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _CallRoomWaitAPI_d__6 : IEnumerator<object> // TypeDefIndex: 2414
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public int petId; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CallRoomWaitAPI_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B6AB70-0x0000000180B6AC80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B6AC80-0x0000000180B6ACC0
	}

	// Constructors
	public GetNameOnClick(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180B6A460-0x0000000180B6A470
	public void OnPointerUp(PointerEventData eventData); // 0x0000000180B6A470-0x0000000180B6AB00
	public void OnPointerExit(PointerEventData eventData); // 0x0000000180B6AB00-0x0000000180B6AB10
	[IteratorStateMachine(typeof(_CallRoomWaitAPI_d__6))]
	private IEnumerator CallRoomWaitAPI(int userId, int petId); // 0x0000000180B6AB10-0x0000000180B6AB70
}

