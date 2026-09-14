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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HomeTransitionFx // TypeDefIndex: 993
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
	public static bool IsCovering { get; } // 0x00000001805F3760-0x00000001805F38D0 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 994
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _CoverAndLoadRoutine_d__17 : IEnumerator<object> // TypeDefIndex: 995
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
		private bool MoveNext(); // 0x00000001805F6230-0x00000001805F6630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F6630-0x00000001805F6670
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 996
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805F6670-0x00000001805F6A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F6A50-0x00000001805F6A90
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 997
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805F6A90-0x00000001805F6DE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805F6DE0-0x00000001805F6E20
	}

	// Methods
	public static void CoverAndLoad(string sceneName); // 0x00000001805F38D0-0x00000001805F3E00
	public static void Reveal(); // 0x00000001805F3E00-0x00000001805F4190
	public static void ForceClear(); // 0x00000001805F4190-0x00000001805F4450
	[IteratorStateMachine(typeof(_CoverAndLoadRoutine_d__17))]
	private static IEnumerator CoverAndLoadRoutine(int gen, string sceneName); // 0x00000001805F4450-0x00000001805F44F0
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__18))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001805F44F0-0x00000001805F4540
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__19))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x00000001805F4540-0x00000001805F4590
	private static void HookSceneLoaded(); // 0x00000001805F4590-0x00000001805F4660
	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001805F4660-0x00000001805F47E0
	private static bool EnsureUi(); // 0x00000001805F47E0-0x00000001805F5820
	private static void SpinStep(); // 0x00000001805F5820-0x00000001805F5A60
	private static void HideNow(); // 0x00000001805F5A60-0x00000001805F5D00
	private static void StopJob(); // 0x00000001805F5D00-0x00000001805F5EA0
	private static void ArmWatchdog(int gen); // 0x00000001805F5EA0-0x00000001805F6090
	private static void StopWatchdog(); // 0x00000001805F6090-0x00000001805F6230
}

