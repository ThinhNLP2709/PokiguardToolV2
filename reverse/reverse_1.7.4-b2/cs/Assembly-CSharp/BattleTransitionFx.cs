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

public static class BattleTransitionFx // TypeDefIndex: 1511
{
	// Fields
	private const float FADE_IN_SEC = 0.22f; // Metadata: 0x0068D3DB
	private const float SHOW_WAIT_CAP_SEC = 0.35f; // Metadata: 0x0068D3DF
	private const float FADE_OUT_SEC = 0.3f; // Metadata: 0x0068D3E3
	private const float UNLOAD_TIMEOUT_SEC = 2f; // Metadata: 0x0068D3E7
	private const float WATCHDOG_SEC = 8f; // Metadata: 0x0068D3EB
	private const float PROGRESS_LABEL_AFTER_SEC = 3f; // Metadata: 0x0068D3EF
	private const float PROGRESS_LABEL_STEP_SEC = 0.25f; // Metadata: 0x0068D3F3
	private const int SORTING_ORDER = 32000; // Metadata: 0x0068D3F7
	private static Runner _runner; // 0x00
	private static Canvas _canvas; // 0x08
	private static CanvasGroup _group; // 0x10
	private static UnityEngine.UI.Text _progressLabel; // 0x18
	private static Coroutine _progressCo; // 0x20
	[CompilerGenerated]
	private static int _WatchdogFireCount_k__BackingField; // 0x28
	private static int _generation; // 0x2C
	private static Coroutine _fadeCo; // 0x30
	private static Coroutine _watchdogCo; // 0x38

	// Properties
	public static int WatchdogFireCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805DB310-0x00000001805DB350 0x00000001805DB350-0x00000001805DB390
	public static bool IsCovering { get; } // 0x00000001805DB270-0x00000001805DB310 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1512
	{
		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 1513
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
		public _FadeOutRoutine_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E8340-0x00000001805E8560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8560-0x00000001805E85A0
	}

	[CompilerGenerated]
	private sealed class _ProgressLabelRoutine_d__33 : IEnumerator<object> // TypeDefIndex: 1514
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _elapsed_5__2; // 0x24
		private WaitForSecondsRealtime _wait_5__3; // 0x28
		private int _lastShown_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ProgressLabelRoutine_d__33(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805E8DE0-0x00000001805E9230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9230-0x00000001805E9270
	}

	[CompilerGenerated]
	private sealed class _ShowAndWait_d__22 : IEnumerator<object> // TypeDefIndex: 1515
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _gen_5__2; // 0x20
		private float _start_5__3; // 0x24
		private float _elapsed_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowAndWait_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E9C00-0x00000001805EA010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EA010-0x00000001805EA050
	}

	[CompilerGenerated]
	private sealed class _UnloadThenRevealRoutine_d__27 : IEnumerator<object> // TypeDefIndex: 1516
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private AsyncOperation _op_5__2; // 0x28
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UnloadThenRevealRoutine_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805EB3B0-0x00000001805EB590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EB590-0x00000001805EB5D0
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__28 : IEnumerator<object> // TypeDefIndex: 1517
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
		public _WatchdogRoutine_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805EBEE0-0x00000001805EC170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EC170-0x00000001805EC1B0
	}

	// Methods
	[IteratorStateMachine(typeof(_ShowAndWait_d__22))]
	public static IEnumerator ShowAndWait(); // 0x00000001805DAE70-0x00000001805DAEC0
	public static void Reveal(); // 0x00000001805DAD10-0x00000001805DAE70
	public static void RevealAfterUnusedAssetsUnload(); // 0x00000001805DAC10-0x00000001805DAD10
	public static void ForceClear(); // 0x00000001805DA9B0-0x00000001805DAAC0
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__26))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001805DA950-0x00000001805DA9B0
	[IteratorStateMachine(typeof(_UnloadThenRevealRoutine_d__27))]
	private static IEnumerator UnloadThenRevealRoutine(int gen); // 0x00000001805DB1B0-0x00000001805DB210
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__28))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x00000001805DB210-0x00000001805DB270
	private static bool EnsureUi(); // 0x00000001805DA210-0x00000001805DA950
	private static void HideNow(); // 0x00000001805DAAC0-0x00000001805DABB0
	private static void ArmProgressLabel(int gen); // 0x00000001805D9A30-0x00000001805D9B50
	private static void StopProgressLabel(); // 0x00000001805DAF90-0x00000001805DB0E0
	[IteratorStateMachine(typeof(_ProgressLabelRoutine_d__33))]
	private static IEnumerator ProgressLabelRoutine(int gen); // 0x00000001805DABB0-0x00000001805DAC10
	private static bool EnsureProgressLabel(); // 0x00000001805D9C70-0x00000001805DA210
	private static void StopFade(); // 0x00000001805DAEC0-0x00000001805DAF90
	private static void ArmWatchdog(int gen); // 0x00000001805D9B50-0x00000001805D9C70
	private static void StopWatchdog(); // 0x00000001805DB0E0-0x00000001805DB1B0
}

