/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class HomeTransitionFx // TypeDefIndex: 628
{
	// Fields
	private const float FADE_IN_SEC = 0.2f; // Metadata: 0x0064C6A5
	private const float FADE_OUT_SEC = 0.25f; // Metadata: 0x0064C6A9
	private const float WATCHDOG_SEC = 8f; // Metadata: 0x0064C6AD
	private const int SORTING_ORDER = 32000; // Metadata: 0x0064C6B1
	private static Runner _runner; // 0x00
	private static Canvas _canvas; // 0x08
	private static CanvasGroup _group; // 0x10
	private static RectTransform _spinner; // 0x18
	private static int _generation; // 0x20
	private static Coroutine _job; // 0x28
	private static Coroutine _watchdogCo; // 0x30
	private static bool _hooked; // 0x38

	// Properties
	public static bool IsCovering { get; } // 0x00000001803BA820-0x00000001803BA8C0 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 629
	{
		// Constructors
		public Runner(); // 0x00000001802E7A70-0x00000001802E7BC0
	}

	[CompilerGenerated]
	private sealed class _CoverAndLoadRoutine_d__17 : IEnumerator<object> // TypeDefIndex: 630
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		public string sceneName; // 0x28
		private float _start_5__2; // 0x30
		private float _elapsed_5__3; // 0x34
		private AsyncOperation _op_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoverAndLoadRoutine_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001803BCA70-0x00000001803BCD70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BCD70-0x00000001803BCDB0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 631
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _start_5__2; // 0x24
		private float _elapsed_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeOutRoutine_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803BD180-0x00000001803BD3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BD3D0-0x00000001803BD410
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 632
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _elapsed_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogRoutine_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803BF190-0x00000001803BF360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BF360-0x00000001803BF5C0
	}

	// Methods
	public static void CoverAndLoad(string sceneName); // 0x00000001803B9080-0x00000001803B93E0
	public static void Reveal(); // 0x00000001803BA390-0x00000001803BA540
	public static void ForceClear(); // 0x00000001803B9EA0-0x00000001803B9FA0
	[IteratorStateMachine(typeof(_CoverAndLoadRoutine_d__17))]
	private static IEnumerator CoverAndLoadRoutine(int gen, string sceneName); // 0x00000001803B9000-0x00000001803B9080
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__18))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001803B9E40-0x00000001803B9EA0
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__19))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x00000001803BA7C0-0x00000001803BA820
	private static void HookSceneLoaded(); // 0x00000001803BA090-0x00000001803BA150
	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001803BA150-0x00000001803BA390
	private static bool EnsureUi(); // 0x00000001803B93E0-0x00000001803B9E40
	private static void SpinStep(); // 0x00000001803BA540-0x00000001803BA620
	private static void HideNow(); // 0x00000001803B9FA0-0x00000001803BA090
	private static void StopJob(); // 0x00000001803BA620-0x00000001803BA6F0
	private static void ArmWatchdog(int gen); // 0x00000001803B8EE0-0x00000001803B9000
	private static void StopWatchdog(); // 0x00000001803BA6F0-0x00000001803BA7C0
}

