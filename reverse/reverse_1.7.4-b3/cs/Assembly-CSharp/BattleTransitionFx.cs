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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class BattleTransitionFx // TypeDefIndex: 1894
{
	// Fields
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
	public static int WatchdogFireCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180923DC0-0x0000000180923E00 0x0000000180923E00-0x0000000180923E50

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1895
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 1896
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
		public _FadeOutRoutine_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809268F0-0x0000000180926CA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180926CA0-0x0000000180926CE0
	}

	[CompilerGenerated]
	private sealed class _ProgressLabelRoutine_d__33 : IEnumerator<object> // TypeDefIndex: 1897
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private float _elapsed_5__2; // 0x24
		private WaitForSecondsRealtime _wait_5__3; // 0x28
		private int _lastShown_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ProgressLabelRoutine_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180926CE0-0x00000001809272B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809272B0-0x00000001809272F0
	}

	[CompilerGenerated]
	private sealed class _ShowAndWait_d__22 : IEnumerator<object> // TypeDefIndex: 1898
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _gen_5__2; // 0x20
		private float _start_5__3; // 0x24
		private float _elapsed_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowAndWait_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809272F0-0x0000000180927A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180927A20-0x0000000180927A60
	}

	[CompilerGenerated]
	private sealed class _UnloadThenRevealRoutine_d__27 : IEnumerator<object> // TypeDefIndex: 1899
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int gen; // 0x20
		private AsyncOperation _op_5__2; // 0x28
		private float _elapsed_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UnloadThenRevealRoutine_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180927A60-0x0000000180927E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180927E40-0x0000000180927E80
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__28 : IEnumerator<object> // TypeDefIndex: 1900
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
		public _WatchdogRoutine_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180927E80-0x0000000180928380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180928380-0x0000000180928400
	}

	// Methods
	[IteratorStateMachine(typeof(_ShowAndWait_d__22))]
	public static IEnumerator ShowAndWait(); // 0x0000000180923E50-0x0000000180923E90
	public static void Reveal(); // 0x0000000180923E90-0x00000001809241E0
	public static void RevealAfterUnusedAssetsUnload(); // 0x00000001809241E0-0x0000000180924320
	public static void ForceClear(); // 0x0000000180924320-0x00000001809245E0
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__26))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x00000001809245E0-0x0000000180924630
	[IteratorStateMachine(typeof(_UnloadThenRevealRoutine_d__27))]
	private static IEnumerator UnloadThenRevealRoutine(int gen); // 0x0000000180924630-0x0000000180924680
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__28))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x0000000180924680-0x00000001809246D0
	private static bool EnsureUi(); // 0x00000001809246D0-0x0000000180925320
	private static void HideNow(); // 0x0000000180925320-0x00000001809255C0
	private static void ArmProgressLabel(int gen); // 0x00000001809255C0-0x00000001809257B0
	private static void StopProgressLabel(); // 0x00000001809257B0-0x0000000180925A80
	[IteratorStateMachine(typeof(_ProgressLabelRoutine_d__33))]
	private static IEnumerator ProgressLabelRoutine(int gen); // 0x0000000180925A80-0x0000000180925AD0
	private static bool EnsureProgressLabel(); // 0x0000000180925AD0-0x00000001809263C0
	private static void StopFade(); // 0x00000001809263C0-0x0000000180926560
	private static void ArmWatchdog(int gen); // 0x0000000180926560-0x0000000180926750
	private static void StopWatchdog(); // 0x0000000180926750-0x00000001809268F0
}

