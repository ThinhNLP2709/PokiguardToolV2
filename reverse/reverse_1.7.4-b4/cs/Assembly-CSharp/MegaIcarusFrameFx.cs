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

public sealed class MegaIcarusFrameFx : MonoBehaviour // TypeDefIndex: 2362
{
	// Fields
	private const string ResourcePath = "Image/Effects/MegaIcarus"; // Metadata: 0x005F1F4F
	private const float FramesPerSecond = 24f; // Metadata: 0x005F1F68
	private const float FrameSeconds = 0.041666668f; // Metadata: 0x005F1F6C
	public const int FxSortingOrder = 12; // Metadata: 0x005F1F70
	public const int MarkSortingOrder = 14; // Metadata: 0x005F1F71
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
	public bool IsPlaying { get; } // 0x0000000180B529A0-0x0000000180B529B0 
	public static Sprite[] Frames { get; } // 0x0000000180B52F60-0x0000000180B52F70 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2363
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<Sprite> __9__27_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180B547F0-0x0000000180B54890
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _LoadFrames_b__27_0(Sprite a, Sprite b); // 0x0000000180B54890-0x0000000180B54950
	}

	[CompilerGenerated]
	private sealed class _PlayFrames_d__29 : IEnumerator<object> // TypeDefIndex: 2364
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B54950-0x0000000180B54DE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B54DE0-0x0000000180B54E20
	}

	// Constructors
	public MegaIcarusFrameFx(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static bool PlayOn(Transform host, bool autoHide); // 0x0000000180B529B0-0x0000000180B52BB0
	public static bool RequestHide(Transform host); // 0x0000000180B52BB0-0x0000000180B52D50
	public static void StopAndRestore(Transform host); // 0x0000000180B52D50-0x0000000180B52F60
	private bool Play(bool autoHide); // 0x0000000180B52F70-0x0000000180B535A0
	public static void ClearCache(); // 0x0000000180B535A0-0x0000000180B53640
	private static Sprite[] LoadFrames(); // 0x0000000180B53640-0x0000000180B53960
	private void CaptureOriginalState(); // 0x0000000180B53960-0x0000000180B54040
	[IteratorStateMachine(typeof(_PlayFrames_d__29))]
	private IEnumerator PlayFrames(Sprite[] frames); // 0x0000000180B54040-0x0000000180B54150
	private void StopInternal(bool restore, bool hide); // 0x0000000180B54150-0x0000000180B54270
	private void RestoreOriginalState(); // 0x0000000180B54270-0x0000000180B54760
	private void OnDisable(); // 0x0000000180B54760-0x0000000180B547F0
}

