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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class KickToastView : MonoBehaviour // TypeDefIndex: 1402
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text label; // 0x28
	private const float FADE = 0.2f; // Metadata: 0x005EFB4D

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__5 : IEnumerator<object> // TypeDefIndex: 1403
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public KickToastView __4__this; // 0x20
		public float duration; // 0x28
		private float _t_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__5(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018078F340-0x000000018078F960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018078F960-0x000000018078F9A0
	}

	// Constructors
	public KickToastView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void SetRefs(CanvasGroup group, UnityEngine.UI.Text labelComp); // 0x000000018078EE20-0x000000018078EED0
	public void Play(string message, float duration); // 0x000000018078EED0-0x000000018078F280
	[IteratorStateMachine(typeof(_CoPlay_d__5))]
	private IEnumerator CoPlay(float duration); // 0x000000018078F280-0x000000018078F340
}

