/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class BattleTransitionFx // TypeDefIndex: 1278
{
	// Fields
	private const float FADE_IN_SEC = 0.22f; // Metadata: 0x0064D5C3
	private const float SHOW_WAIT_CAP_SEC = 0.35f; // Metadata: 0x0064D5C7
	private const float FADE_OUT_SEC = 0.3f; // Metadata: 0x0064D5CB
	private const float UNLOAD_TIMEOUT_SEC = 2f; // Metadata: 0x0064D5CF
	private const float WATCHDOG_SEC = 8f; // Metadata: 0x0064D5D3
	private const int SORTING_ORDER = 32000; // Metadata: 0x0064D5D7
	private static Runner _runner; // 0x00
	private static Canvas _canvas; // 0x08
	private static CanvasGroup _group; // 0x10
	private static int _generation; // 0x18
	private static Coroutine _fadeCo; // 0x20
	private static Coroutine _watchdogCo; // 0x28

	// Properties
	public static bool IsCovering { get; } // 0x00000001804DB030-0x00000001804DB0D0 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1279
	{
		// Constructors
		public Runner(); // 0x00000001802E7A70-0x00000001802E7BC0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 1280
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
		private bool MoveNext(); // 0x00000001804E4F70-0x00000001804E5190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5190-0x00000001804E51D0
	}

	[CompilerGenerated]
	private sealed class _ShowAndWait_d__14 : IEnumerator<object> // TypeDefIndex: 1281
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _gen_5__2; // 0x20
		private float _start_5__3; // 0x24
		private float _elapsed_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowAndWait_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E8730-0x00000001804E8A40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E8A40-0x00000001804E8A80
	}

	[CompilerGenerated]
	private sealed class _UnloadThenRevealRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 1282
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private AsyncOperation _op_5__2; // 0x28
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UnloadThenRevealRoutine_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804EAC30-0x00000001804EAE10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EAE10-0x00000001804EAE50
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__20 : IEnumerator<object> // TypeDefIndex: 1283
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
		public _WatchdogRoutine_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804EC3F0-0x00000001804EC5E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EC5E0-0x00000001804EC620
	}

	// Methods
	[IteratorStateMachine(typeof(_ShowAndWait_d__14))]
	public static IEnumerator ShowAndWait(); // 0x00000001804DAD80-0x00000001804DADD0
	public static void Reveal(); // 0x00000001804DAC20-0x00000001804DAD80
	public static void RevealAfterUnusedAssetsUnload(); // 0x00000001804DAB20-0x00000001804DAC20
	public static void ForceClear(); // 0x00000001804DA930-0x00000001804DAA30
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__18))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001804DA8D0-0x00000001804DA930
	[IteratorStateMachine(typeof(_UnloadThenRevealRoutine_d__19))]
	private static IEnumerator UnloadThenRevealRoutine(int gen); // 0x00000001804DAF70-0x00000001804DAFD0
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__20))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x00000001804DAFD0-0x00000001804DB030
	private static bool EnsureUi(); // 0x00000001804DA190-0x00000001804DA8D0
	private static void HideNow(); // 0x00000001804DAA30-0x00000001804DAB20
	private static void StopFade(); // 0x00000001804DADD0-0x00000001804DAEA0
	private static void ArmWatchdog(int gen); // 0x00000001804DA070-0x00000001804DA190
	private static void StopWatchdog(); // 0x00000001804DAEA0-0x00000001804DAF70
}

