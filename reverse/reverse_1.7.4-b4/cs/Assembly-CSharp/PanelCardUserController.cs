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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PanelCardUserController : MonoBehaviour // TypeDefIndex: 1569
{
	// Fields
	public Image onImageCard; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _ShowEffect_d__3 : IEnumerator<object> // TypeDefIndex: 1570
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PanelCardUserController __4__this; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _t_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowEffect_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
		private bool MoveNext(); // 0x000000018085A480-0x000000018085A9A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018085A9A0-0x000000018085A9E0
	}

	// Constructors
	public PanelCardUserController(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x0000000180859FF0-0x000000018085A140
	public void ShowOnImageCard(Sprite sprite); // 0x000000018085A140-0x000000018085A2F0
	[IteratorStateMachine(typeof(_ShowEffect_d__3))]
	private IEnumerator ShowEffect(); // 0x000000018085A2F0-0x000000018085A480
}

