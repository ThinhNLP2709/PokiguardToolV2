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

public sealed class MegaIcarusFrameFx : MonoBehaviour // TypeDefIndex: 1693
{
	// Fields
	private const string ResourcePath = "Image/Effects/MegaIcarus"; // Metadata: 0x0064D987
	private const float FramesPerSecond = 24f; // Metadata: 0x0064D9A0
	private const float FrameSeconds = 0.041666668f; // Metadata: 0x0064D9A4
	public const int FxSortingOrder = 12; // Metadata: 0x0064D9A8
	public const int MarkSortingOrder = 14; // Metadata: 0x0064D9A9
	private static Sprite[] cachedFrames; // 0x00
	private Image target; // 0x20
	private SpriteRenderer spriteTarget; // 0x28
	private Animator targetAnimator; // 0x30
	private Coroutine playRoutine; // 0x38
	private Sprite originalSprite; // 0x40
	private Color originalColor; // 0x48
	private Vector2 originalSize; // 0x58
	private bool originalPreserveAspect; // 0x60
	private bool originalRaycastTarget; // 0x61
	private bool originalAnimatorEnabled; // 0x62
	private bool hideAfterPlayback; // 0x63
	private bool stateCaptured; // 0x64

	// Properties
	public bool IsPlaying { get; } // 0x00000001805DFAC0-0x00000001805DFAD0 
	public static Sprite[] Frames { get; } // 0x00000001805DFAB0-0x00000001805DFAC0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1694
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<Sprite> __9__26_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805E9070-0x00000001805E90E0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _LoadFrames_b__26_0(Sprite a, Sprite b); // 0x00000001805E8750-0x00000001805E87A0
	}

	[CompilerGenerated]
	private sealed class _PlayFrames_d__28 : IEnumerator<object> // TypeDefIndex: 1695
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MegaIcarusFrameFx __4__this; // 0x20
		public Sprite[] frames; // 0x28
		private float _nextFrameAt_5__2; // 0x30
		private int _i_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayFrames_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E6900-0x00000001805E6B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E6B50-0x00000001805E6B90
	}

	// Constructors
	public MegaIcarusFrameFx(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static bool PlayOn(Transform host, bool autoHide); // 0x00000001805DF370-0x00000001805DF460
	public static bool RequestHide(Transform host); // 0x00000001805DF6D0-0x00000001805DF780
	public static void StopAndRestore(Transform host); // 0x00000001805DF950-0x00000001805DFA20
	private bool Play(bool autoHide); // 0x00000001805DF460-0x00000001805DF6D0
	private static Sprite[] LoadFrames(); // 0x00000001805DF100-0x00000001805DF290
	private void CaptureOriginalState(); // 0x00000001805DEE40-0x00000001805DF100
	[IteratorStateMachine(typeof(_PlayFrames_d__28))]
	private IEnumerator PlayFrames(Sprite[] frames); // 0x00000001805DF2E0-0x00000001805DF370
	private void StopInternal(bool restore, bool hide); // 0x00000001805DFA20-0x00000001805DFAB0
	private void RestoreOriginalState(); // 0x00000001805DF780-0x00000001805DF950
	private void OnDisable(); // 0x00000001805DF290-0x00000001805DF2E0
}

