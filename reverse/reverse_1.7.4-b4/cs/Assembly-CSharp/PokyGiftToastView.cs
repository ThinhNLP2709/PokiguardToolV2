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

public class PokyGiftToastView : MonoBehaviour // TypeDefIndex: 1170
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
	public const float FADE = 0.22f; // Metadata: 0x005F08D0
	private const float SLIDE = 26f; // Metadata: 0x005F08D4

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__8 : IEnumerator<object> // TypeDefIndex: 1171
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PokyGiftToastView __4__this; // 0x20
		public float duration; // 0x28
		private Vector2 _basePos_5__2; // 0x2C
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806BF8C0-0x00000001806C0180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806C0180-0x00000001806C01C0
	}

	// Constructors
	public PokyGiftToastView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Play(string message, Sprite icon, string amount, float duration, float offsetY = 0f /* Metadata: 0x005F08CC */); // 0x00000001806BEE60-0x00000001806BF800
	[IteratorStateMachine(typeof(_CoPlay_d__8))]
	private IEnumerator CoPlay(float duration); // 0x00000001806BF800-0x00000001806BF8C0
}

