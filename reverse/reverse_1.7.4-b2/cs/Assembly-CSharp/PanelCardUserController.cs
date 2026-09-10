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

public class PanelCardUserController : MonoBehaviour // TypeDefIndex: 1162
{
	// Fields
	public Image onImageCard; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _ShowEffect_d__3 : IEnumerator<object> // TypeDefIndex: 1163
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PanelCardUserController __4__this; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _t_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowEffect_d__3(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x0000000180562110-0x00000001805623A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805623A0-0x00000001805623E0
	}

	// Constructors
	public PanelCardUserController(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Start(); // 0x0000000180561400-0x0000000180561490
	public void ShowOnImageCard(Sprite sprite); // 0x0000000180561320-0x0000000180561400
	[IteratorStateMachine(typeof(_ShowEffect_d__3))]
	private IEnumerator ShowEffect(); // 0x00000001805612B0-0x0000000180561320
}

