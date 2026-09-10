/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchImpactFx // TypeDefIndex: 1965
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
	private class Runner : MonoBehaviour // TypeDefIndex: 1966
	{
		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0
	}

	[CompilerGenerated]
	private sealed class _FlashRoutine_d__15 : IEnumerator<object> // TypeDefIndex: 1967
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private SpriteRenderer[] _renderers_5__2; // 0x20
		private Color[] _originals_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlashRoutine_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018070C8B0-0x000000018070C8F0
		private bool MoveNext(); // 0x000000018070C560-0x000000018070C870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070C870-0x000000018070C8B0
	}

	[CompilerGenerated]
	private sealed class _ShakeRoutine_d__22 : IEnumerator<object> // TypeDefIndex: 1968
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShakeRoutine_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018070F5D0-0x000000018070FA70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070FA70-0x000000018070FAB0
	}

	[CompilerGenerated]
	private sealed class _TurnBannerRoutine_d__12 : IEnumerator<object> // TypeDefIndex: 1969
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TurnBannerRoutine_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018070FAB0-0x000000018070FDD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070FDD0-0x000000018070FE10
	}

	// Methods
	public static void PlayHit(GameObject victimPetRoot, int damage, int victimMaxHp); // 0x0000000180708850-0x0000000180708C30
	public static void ResetForMatchExit(); // 0x0000000180708E70-0x0000000180708F60
	public static void PlayTurnBanner(GameObject node); // 0x0000000180708C30-0x0000000180708E70
	[IteratorStateMachine(typeof(_TurnBannerRoutine_d__12))]
	private static IEnumerator TurnBannerRoutine(RectTransform rt, Vector2 home); // 0x00000001807097B0-0x0000000180709840
	private static void StopAndRestoreBanner(); // 0x00000001807093C0-0x0000000180709540
	private static void StartFlash(GameObject root); // 0x00000001807090D0-0x00000001807091B0
	[IteratorStateMachine(typeof(_FlashRoutine_d__15))]
	private static IEnumerator FlashRoutine(); // 0x0000000180708800-0x0000000180708850
	private static void StopAndRestoreFlash(); // 0x0000000180709540-0x0000000180709630
	private static void RestoreColors(SpriteRenderer[] renderers, Color[] originals); // 0x0000000180708F60-0x0000000180709060
	private static bool CacheRenderers(GameObject root); // 0x0000000180708490-0x00000001807086C0
	private static void StartShake(); // 0x00000001807091B0-0x00000001807093C0
	[IteratorStateMachine(typeof(_ShakeRoutine_d__22))]
	private static IEnumerator ShakeRoutine(Camera cam); // 0x0000000180709060-0x00000001807090D0
	private static void StopAndRestoreShake(); // 0x0000000180709630-0x00000001807097B0
	private static bool EnsureRunner(); // 0x00000001807086C0-0x0000000180708800
}

