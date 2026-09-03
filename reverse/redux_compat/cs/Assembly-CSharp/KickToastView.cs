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

public class KickToastView : MonoBehaviour // TypeDefIndex: 829
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text label; // 0x28
	private const float FADE = 0.2f; // Metadata: 0x0064CA5C

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__5 : IEnumerator<object> // TypeDefIndex: 830
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public KickToastView __4__this; // 0x20
		public float duration; // 0x28
		private float _t_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__5(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804365A0-0x00000001804368E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804368E0-0x0000000180436920
	}

	// Constructors
	public KickToastView(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void SetRefs(CanvasGroup group, UnityEngine.UI.Text labelComp); // 0x0000000180427390-0x00000001804273D0
	public void Play(string message, float duration); // 0x0000000180427200-0x0000000180427390
	[IteratorStateMachine(typeof(_CoPlay_d__5))]
	private IEnumerator CoPlay(float duration); // 0x0000000180427180-0x0000000180427200
}

