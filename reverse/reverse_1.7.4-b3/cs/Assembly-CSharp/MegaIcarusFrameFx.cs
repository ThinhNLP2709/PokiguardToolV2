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

public sealed class MegaIcarusFrameFx : MonoBehaviour // TypeDefIndex: 2355
{
	// Fields
	private const string ResourcePath = "Image/Effects/MegaIcarus"; // Metadata: 0x005F0B38
	private const float FramesPerSecond = 24f; // Metadata: 0x005F0B51
	private const float FrameSeconds = 0.041666668f; // Metadata: 0x005F0B55
	public const int FxSortingOrder = 12; // Metadata: 0x005F0B59
	public const int MarkSortingOrder = 14; // Metadata: 0x005F0B5A
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
	public bool IsPlaying { get; } // 0x0000000180B45720-0x0000000180B45730 
	public static Sprite[] Frames { get; } // 0x0000000180B45CE0-0x0000000180B45CF0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2356
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<Sprite> __9__27_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180B47570-0x0000000180B47610
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _LoadFrames_b__27_0(Sprite a, Sprite b); // 0x0000000180B47610-0x0000000180B476D0
	}

	[CompilerGenerated]
	private sealed class _PlayFrames_d__29 : IEnumerator<object> // TypeDefIndex: 2357
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MegaIcarusFrameFx __4__this; // 0x20
		public Sprite[] frames; // 0x28
		private float _nextFrameAt_5__2; // 0x30
		private int _i_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayFrames_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B476D0-0x0000000180B47B60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B47B60-0x0000000180B47BA0
	}

	// Constructors
	public MegaIcarusFrameFx(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static bool PlayOn(Transform host, bool autoHide); // 0x0000000180B45730-0x0000000180B45930
	public static bool RequestHide(Transform host); // 0x0000000180B45930-0x0000000180B45AD0
	public static void StopAndRestore(Transform host); // 0x0000000180B45AD0-0x0000000180B45CE0
	private bool Play(bool autoHide); // 0x0000000180B45CF0-0x0000000180B46320
	public static void ClearCache(); // 0x0000000180B46320-0x0000000180B463C0
	private static Sprite[] LoadFrames(); // 0x0000000180B463C0-0x0000000180B466E0
	private void CaptureOriginalState(); // 0x0000000180B466E0-0x0000000180B46DC0
	[IteratorStateMachine(typeof(_PlayFrames_d__29))]
	private IEnumerator PlayFrames(Sprite[] frames); // 0x0000000180B46DC0-0x0000000180B46ED0
	private void StopInternal(bool restore, bool hide); // 0x0000000180B46ED0-0x0000000180B46FF0
	private void RestoreOriginalState(); // 0x0000000180B46FF0-0x0000000180B474E0
	private void OnDisable(); // 0x0000000180B474E0-0x0000000180B47570
}

