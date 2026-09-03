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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PanelCardUserController : MonoBehaviour // TypeDefIndex: 965
{
	// Fields
	public Image onImageCard; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _ShowEffect_d__3 : IEnumerator<object> // TypeDefIndex: 966
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PanelCardUserController __4__this; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _t_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowEffect_d__3(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
		private bool MoveNext(); // 0x00000001804780D0-0x0000000180478360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180478360-0x00000001804783A0
	}

	// Constructors
	public PanelCardUserController(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x0000000180474AA0-0x0000000180474B30
	public void ShowOnImageCard(Sprite sprite); // 0x00000001804749C0-0x0000000180474AA0
	[IteratorStateMachine(typeof(_ShowEffect_d__3))]
	private IEnumerator ShowEffect(); // 0x0000000180474950-0x00000001804749C0
}

