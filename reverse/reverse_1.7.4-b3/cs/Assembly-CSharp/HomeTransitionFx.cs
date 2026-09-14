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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HomeTransitionFx // TypeDefIndex: 991
{
	// Fields
	private static Runner _runner; // 0x00
	private static Canvas _canvas; // 0x08
	private static CanvasGroup _group; // 0x10
	private static RectTransform _spinner; // 0x18
	private static int _generation; // 0x20
	private static Coroutine _job; // 0x28
	private static Coroutine _watchdogCo; // 0x30
	private static bool _hooked; // 0x38

	// Properties
	public static bool IsCovering { get; } // 0x00000001805F1D70-0x00000001805F1EE0 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 992
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _CoverAndLoadRoutine_d__17 : IEnumerator<object> // TypeDefIndex: 993
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoverAndLoadRoutine_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001805F4840-0x00000001805F4C40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F4C40-0x00000001805F4C80
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 994
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _start_5__2; // 0x24
		private float _elapsed_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeOutRoutine_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805F4C80-0x00000001805F5060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F5060-0x00000001805F50A0
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 995
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _elapsed_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogRoutine_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805F50A0-0x00000001805F53F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F53F0-0x00000001805F5430
	}

	// Methods
	public static void CoverAndLoad(string sceneName); // 0x00000001805F1EE0-0x00000001805F2410
	public static void Reveal(); // 0x00000001805F2410-0x00000001805F27A0
	public static void ForceClear(); // 0x00000001805F27A0-0x00000001805F2A60
	[IteratorStateMachine(typeof(_CoverAndLoadRoutine_d__17))]
	private static IEnumerator CoverAndLoadRoutine(int gen, string sceneName); // 0x00000001805F2A60-0x00000001805F2B00
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__18))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001805F2B00-0x00000001805F2B50
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__19))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x00000001805F2B50-0x00000001805F2BA0
	private static void HookSceneLoaded(); // 0x00000001805F2BA0-0x00000001805F2C70
	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001805F2C70-0x00000001805F2DF0
	private static bool EnsureUi(); // 0x00000001805F2DF0-0x00000001805F3E30
	private static void SpinStep(); // 0x00000001805F3E30-0x00000001805F4070
	private static void HideNow(); // 0x00000001805F4070-0x00000001805F4310
	private static void StopJob(); // 0x00000001805F4310-0x00000001805F44B0
	private static void ArmWatchdog(int gen); // 0x00000001805F44B0-0x00000001805F46A0
	private static void StopWatchdog(); // 0x00000001805F46A0-0x00000001805F4840
}

