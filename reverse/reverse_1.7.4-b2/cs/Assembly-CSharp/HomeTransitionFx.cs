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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HomeTransitionFx // TypeDefIndex: 824
{
	// Fields
	private const float FADE_IN_SEC = 0.2f; // Metadata: 0x0068BCD0
	private const float FADE_OUT_SEC = 0.25f; // Metadata: 0x0068BCD4
	private const float WATCHDOG_SEC = 8f; // Metadata: 0x0068BCD8
	private const int SORTING_ORDER = 32000; // Metadata: 0x0068BCDC
	private static Runner _runner; // 0x00
	private static Canvas _canvas; // 0x08
	private static CanvasGroup _group; // 0x10
	private static RectTransform _spinner; // 0x18
	private static int _generation; // 0x20
	private static Coroutine _job; // 0x28
	private static Coroutine _watchdogCo; // 0x30
	private static bool _hooked; // 0x38

	// Properties
	public static bool IsCovering { get; } // 0x000000018049BED0-0x000000018049BF70 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 825
	{
		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0
	}

	[CompilerGenerated]
	private sealed class _CoverAndLoadRoutine_d__17 : IEnumerator<object> // TypeDefIndex: 826
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CoverAndLoadRoutine_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001804A9DA0-0x00000001804AA0A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AA0A0-0x00000001804AA0E0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 827
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _start_5__2; // 0x24
		private float _elapsed_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeOutRoutine_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804AC840-0x00000001804ACA90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804ACA90-0x00000001804ACAD0
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 828
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _elapsed_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogRoutine_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804B1050-0x00000001804B1220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804B1220-0x00000001804B1260
	}

	// Methods
	public static void CoverAndLoad(string sceneName); // 0x000000018049A730-0x000000018049AA90
	public static void Reveal(); // 0x000000018049BA40-0x000000018049BBF0
	public static void ForceClear(); // 0x000000018049B550-0x000000018049B650
	[IteratorStateMachine(typeof(_CoverAndLoadRoutine_d__17))]
	private static IEnumerator CoverAndLoadRoutine(int gen, string sceneName); // 0x000000018049A6B0-0x000000018049A730
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__18))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x000000018049B4F0-0x000000018049B550
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__19))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x000000018049BE70-0x000000018049BED0
	private static void HookSceneLoaded(); // 0x000000018049B740-0x000000018049B800
	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x000000018049B800-0x000000018049BA40
	private static bool EnsureUi(); // 0x000000018049AA90-0x000000018049B4F0
	private static void SpinStep(); // 0x000000018049BBF0-0x000000018049BCD0
	private static void HideNow(); // 0x000000018049B650-0x000000018049B740
	private static void StopJob(); // 0x000000018049BCD0-0x000000018049BDA0
	private static void ArmWatchdog(int gen); // 0x000000018049A590-0x000000018049A6B0
	private static void StopWatchdog(); // 0x000000018049BDA0-0x000000018049BE70
}

