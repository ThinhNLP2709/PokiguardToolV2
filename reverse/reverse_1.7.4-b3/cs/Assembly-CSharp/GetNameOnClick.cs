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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GetNameOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2406
{
	// Fields
	private BoardController boardController; // 0x20
	private LoadRoom loadRoom; // 0x28
	private bool isPointerInside; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _CallRoomWaitAPI_d__6 : IEnumerator<object> // TypeDefIndex: 2407
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B5D830-0x0000000180B5D940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B5D940-0x0000000180B5D980
	}

	// Constructors
	public GetNameOnClick(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180B5D120-0x0000000180B5D130
	public void OnPointerUp(PointerEventData eventData); // 0x0000000180B5D130-0x0000000180B5D7C0
	public void OnPointerExit(PointerEventData eventData); // 0x0000000180B5D7C0-0x0000000180B5D7D0
	[IteratorStateMachine(typeof(_CallRoomWaitAPI_d__6))]
	private IEnumerator CallRoomWaitAPI(int userId, int petId); // 0x0000000180B5D7D0-0x0000000180B5D830
}

