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

public class KickToastView : MonoBehaviour // TypeDefIndex: 1024
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text label; // 0x28
	private const float FADE = 0.2f; // Metadata: 0x0068C132

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__5 : IEnumerator<object> // TypeDefIndex: 1025
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public KickToastView __4__this; // 0x20
		public float duration; // 0x28
		private float _t_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__5(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050E7E0-0x000000018050EB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050EB20-0x000000018050EB60
	}

	// Constructors
	public KickToastView(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void SetRefs(CanvasGroup group, UnityEngine.UI.Text labelComp); // 0x00000001804FCB00-0x00000001804FCB40
	public void Play(string message, float duration); // 0x00000001804FC970-0x00000001804FCB00
	[IteratorStateMachine(typeof(_CoPlay_d__5))]
	private IEnumerator CoPlay(float duration); // 0x00000001804FC8F0-0x00000001804FC970
}

