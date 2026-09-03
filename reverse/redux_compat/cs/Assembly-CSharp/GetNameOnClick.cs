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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GetNameOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 1733
{
	// Fields
	private BoardController boardController; // 0x20
	private LoadRoom loadRoom; // 0x28
	private bool isPointerInside; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _CallRoomWaitAPI_d__6 : IEnumerator<object> // TypeDefIndex: 1734
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public int petId; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CallRoomWaitAPI_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E4990-0x00000001805E4A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E4A50-0x00000001805E4A90
	}

	// Constructors
	public GetNameOnClick(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void OnPointerDown(PointerEventData eventData); // 0x00000001805DCB00-0x00000001805DCB10
	public void OnPointerUp(PointerEventData eventData); // 0x00000001805DCB10-0x00000001805DCE90
	public void OnPointerExit(PointerEventData eventData); // 0x00000001803ED880-0x00000001803ED890
	[IteratorStateMachine(typeof(_CallRoomWaitAPI_d__6))]
	private IEnumerator CallRoomWaitAPI(int userId, int petId); // 0x00000001805DCA90-0x00000001805DCB00
}

