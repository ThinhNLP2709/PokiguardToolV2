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

public class PokyGiftToastView : MonoBehaviour // TypeDefIndex: 719
{
	// Fields
	public CanvasGroup canvasGroup; // 0x20
	public RectTransform panel; // 0x28
	[Tooltip("T\u00EAn ph\u1EA7n qu\u00E0 \u2014 \u00F4 ch\u1EEF ch\u00EDnh c\u1EE7a thanh.")]
	public UnityEngine.UI.Text txtName; // 0x30
	[Tooltip("S\u1ED1 l\u01B0\u1EE3ng b\u00EAn tr\u00E1i, c\u1EA1nh \u00F4 qu\u00E0. R\u1ED7ng \u21D2 t\u1EAFt.")]
	public UnityEngine.UI.Text txtQuantity; // 0x38
	[Tooltip("\u00D4 qu\u00E0 Poky n\u1EB1m b\u00EAn tr\u00E1i thanh; null \u21D2 ch\u1EC9 hi\u1EC7n ch\u1EEF.")]
	public PokyRewardCellView cell; // 0x40
	private const float FADE = 0.22f; // Metadata: 0x0064C857
	private const float SLIDE = 26f; // Metadata: 0x0064C85B

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__8 : IEnumerator<object> // TypeDefIndex: 720
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PokyGiftToastView __4__this; // 0x20
		public float duration; // 0x28
		private Vector2 _basePos_5__2; // 0x2C
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803ED930-0x00000001803EDD90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EDD90-0x00000001803EDDD0
	}

	// Constructors
	public PokyGiftToastView(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Play(string message, Sprite icon, string amount, float duration); // 0x00000001803E6F00-0x00000001803E7230
	[IteratorStateMachine(typeof(_CoPlay_d__8))]
	private IEnumerator CoPlay(float duration); // 0x00000001803E6E80-0x00000001803E6F00
}

