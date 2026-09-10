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

public sealed class MegaIcarusFrameFx : MonoBehaviour // TypeDefIndex: 1971
{
	// Fields
	private const string ResourcePath = "Image/Effects/MegaIcarus"; // Metadata: 0x0068DDB6
	private const float FramesPerSecond = 24f; // Metadata: 0x0068DDCF
	private const float FrameSeconds = 0.041666668f; // Metadata: 0x0068DDD3
	public const int FxSortingOrder = 12; // Metadata: 0x0068DDD7
	public const int MarkSortingOrder = 14; // Metadata: 0x0068DDD8
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
	public bool IsPlaying { get; } // 0x000000018070A510-0x000000018070A520 
	public static Sprite[] Frames { get; } // 0x000000018070A500-0x000000018070A510 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1972
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<Sprite> __9__27_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180710640-0x00000001807106B0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _LoadFrames_b__27_0(Sprite a, Sprite b); // 0x000000018070FE50-0x000000018070FEA0
	}

	[CompilerGenerated]
	private sealed class _PlayFrames_d__29 : IEnumerator<object> // TypeDefIndex: 1973
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MegaIcarusFrameFx __4__this; // 0x20
		public Sprite[] frames; // 0x28
		private float _nextFrameAt_5__2; // 0x30
		private int _i_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayFrames_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018070DF80-0x000000018070E1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070E1D0-0x000000018070E210
	}

	// Constructors
	public MegaIcarusFrameFx(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static bool PlayOn(Transform host, bool autoHide); // 0x0000000180709DC0-0x0000000180709EB0
	public static bool RequestHide(Transform host); // 0x000000018070A120-0x000000018070A1D0
	public static void StopAndRestore(Transform host); // 0x000000018070A3A0-0x000000018070A470
	private bool Play(bool autoHide); // 0x0000000180709EB0-0x000000018070A120
	public static void ClearCache(); // 0x0000000180709B00-0x0000000180709B50
	private static Sprite[] LoadFrames(); // 0x0000000180709B50-0x0000000180709CE0
	private void CaptureOriginalState(); // 0x0000000180709840-0x0000000180709B00
	[IteratorStateMachine(typeof(_PlayFrames_d__29))]
	private IEnumerator PlayFrames(Sprite[] frames); // 0x0000000180709D30-0x0000000180709DC0
	private void StopInternal(bool restore, bool hide); // 0x000000018070A470-0x000000018070A500
	private void RestoreOriginalState(); // 0x000000018070A1D0-0x000000018070A3A0
	private void OnDisable(); // 0x0000000180709CE0-0x0000000180709D30
}

