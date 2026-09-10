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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GetNameOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2012
{
	// Fields
	private BoardController boardController; // 0x20
	private LoadRoom loadRoom; // 0x28
	private bool isPointerInside; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _CallRoomWaitAPI_d__6 : IEnumerator<object> // TypeDefIndex: 2013
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public int petId; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CallRoomWaitAPI_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807235D0-0x0000000180723690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180723690-0x00000001807236D0
	}

	// Constructors
	public GetNameOnClick(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180714680-0x0000000180714690
	public void OnPointerUp(PointerEventData eventData); // 0x00000001807146A0-0x0000000180714A20
	public void OnPointerExit(PointerEventData eventData); // 0x0000000180714690-0x00000001807146A0
	[IteratorStateMachine(typeof(_CallRoomWaitAPI_d__6))]
	private IEnumerator CallRoomWaitAPI(int userId, int petId); // 0x0000000180714610-0x0000000180714680
}

