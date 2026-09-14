/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchImpactFx // TypeDefIndex: 2354
{
	// Fields
	private static Runner _runner; // 0x00
	private static GameObject _cachedRoot; // 0x08
	private static SpriteRenderer[] _cachedRenderers; // 0x10
	private static Color[] _cachedColors; // 0x18
	private static Coroutine _flashCo; // 0x20
	private static Coroutine _shakeCo; // 0x28
	private static Coroutine _bannerCo; // 0x30
	private static RectTransform _bannerRt; // 0x38
	private static Vector2 _bannerHome; // 0x40
	private static Transform _shakeTarget; // 0x48
	private static Vector3 _shakeOrigin; // 0x50

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 2355
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _FlashRoutine_d__15 : IEnumerator<object> // TypeDefIndex: 2356
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private SpriteRenderer[] _renderers_5__2; // 0x20
		private Color[] _originals_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlashRoutine_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B4E0C0-0x0000000180B4E180
		private bool MoveNext(); // 0x0000000180B4E180-0x0000000180B4E6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4E6A0-0x0000000180B4E6E0
	}

	[CompilerGenerated]
	private sealed class _ShakeRoutine_d__22 : IEnumerator<object> // TypeDefIndex: 2357
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Camera cam; // 0x20
		private Transform _t_5__2; // 0x28
		private float _amp_5__3; // 0x30
		private float _dur_5__4; // 0x34
		private float _elapsed_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShakeRoutine_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B4E6E0-0x0000000180B4EF00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4EF00-0x0000000180B4EF40
	}

	[CompilerGenerated]
	private sealed class _TurnBannerRoutine_d__12 : IEnumerator<object> // TypeDefIndex: 2358
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RectTransform rt; // 0x20
		public Vector2 home; // 0x28
		private Vector2 _from_5__2; // 0x30
		private float _dur_5__3; // 0x38
		private float _t_5__4; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TurnBannerRoutine_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B4EF40-0x0000000180B4F510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4F510-0x0000000180B4F550
	}

	// Methods
	public static void PlayHit(GameObject victimPetRoot, int damage, int victimMaxHp); // 0x0000000180B4BFF0-0x0000000180B4C2C0
	public static void ResetForMatchExit(); // 0x0000000180B4C2C0-0x0000000180B4C630
	public static void PlayTurnBanner(GameObject node); // 0x0000000180B4C630-0x0000000180B4CA00
	[IteratorStateMachine(typeof(_TurnBannerRoutine_d__12))]
	private static IEnumerator TurnBannerRoutine(RectTransform rt, Vector2 home); // 0x0000000180B4CA00-0x0000000180B4CAC0
	private static void StopAndRestoreBanner(); // 0x0000000180B4CAC0-0x0000000180B4CDE0
	private static void StartFlash(GameObject root); // 0x0000000180B4CDE0-0x0000000180B4CEF0
	[IteratorStateMachine(typeof(_FlashRoutine_d__15))]
	private static IEnumerator FlashRoutine(); // 0x0000000180B4CEF0-0x0000000180B4CF30
	private static void StopAndRestoreFlash(); // 0x0000000180B4CF30-0x0000000180B4D0F0
	private static void RestoreColors(SpriteRenderer[] renderers, Color[] originals); // 0x0000000180B4D0F0-0x0000000180B4D2D0
	private static bool CacheRenderers(GameObject root); // 0x0000000180B4D2D0-0x0000000180B4D790
	private static void StartShake(); // 0x0000000180B4D790-0x0000000180B4DA20
	[IteratorStateMachine(typeof(_ShakeRoutine_d__22))]
	private static IEnumerator ShakeRoutine(Camera cam); // 0x0000000180B4DA20-0x0000000180B4DAC0
	private static void StopAndRestoreShake(); // 0x0000000180B4DAC0-0x0000000180B4DE50
	private static bool EnsureRunner(); // 0x0000000180B4DE50-0x0000000180B4E0C0
}

