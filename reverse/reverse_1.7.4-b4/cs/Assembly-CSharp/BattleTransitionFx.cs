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

public static class BattleTransitionFx // TypeDefIndex: 1896
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
	public static int WatchdogFireCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180927300-0x0000000180927340 0x0000000180927340-0x0000000180927390

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1897
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _FadeOutRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 1898
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180929E30-0x000000018092A1E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092A1E0-0x000000018092A220
	}

	[CompilerGenerated]
	private sealed class _ProgressLabelRoutine_d__33 : IEnumerator<object> // TypeDefIndex: 1899
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
		private bool MoveNext(); // 0x000000018092A220-0x000000018092A7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092A7F0-0x000000018092A830
	}

	[CompilerGenerated]
	private sealed class _ShowAndWait_d__22 : IEnumerator<object> // TypeDefIndex: 1900
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018092A830-0x000000018092AF60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092AF60-0x000000018092AFA0
	}

	[CompilerGenerated]
	private sealed class _UnloadThenRevealRoutine_d__27 : IEnumerator<object> // TypeDefIndex: 1901
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
		private bool MoveNext(); // 0x000000018092AFA0-0x000000018092B380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092B380-0x000000018092B3C0
	}

	[CompilerGenerated]
	private sealed class _WatchdogRoutine_d__28 : IEnumerator<object> // TypeDefIndex: 1902
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018092B3C0-0x000000018092B8C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092B8C0-0x000000018092B940
	}

	// Methods
	[IteratorStateMachine(typeof(_ShowAndWait_d__22))]
	public static IEnumerator ShowAndWait(); // 0x0000000180927390-0x00000001809273D0
	public static void Reveal(); // 0x00000001809273D0-0x0000000180927720
	public static void RevealAfterUnusedAssetsUnload(); // 0x0000000180927720-0x0000000180927860
	public static void ForceClear(); // 0x0000000180927860-0x0000000180927B20
	[IteratorStateMachine(typeof(_FadeOutRoutine_d__26))]
	private static IEnumerator FadeOutRoutine(int gen); // 0x0000000180927B20-0x0000000180927B70
	[IteratorStateMachine(typeof(_UnloadThenRevealRoutine_d__27))]
	private static IEnumerator UnloadThenRevealRoutine(int gen); // 0x0000000180927B70-0x0000000180927BC0
	[IteratorStateMachine(typeof(_WatchdogRoutine_d__28))]
	private static IEnumerator WatchdogRoutine(int gen); // 0x0000000180927BC0-0x0000000180927C10
	private static bool EnsureUi(); // 0x0000000180927C10-0x0000000180928860
	private static void HideNow(); // 0x0000000180928860-0x0000000180928B00
	private static void ArmProgressLabel(int gen); // 0x0000000180928B00-0x0000000180928CF0
	private static void StopProgressLabel(); // 0x0000000180928CF0-0x0000000180928FC0
	[IteratorStateMachine(typeof(_ProgressLabelRoutine_d__33))]
	private static IEnumerator ProgressLabelRoutine(int gen); // 0x0000000180928FC0-0x0000000180929010
	private static bool EnsureProgressLabel(); // 0x0000000180929010-0x0000000180929900
	private static void StopFade(); // 0x0000000180929900-0x0000000180929AA0
	private static void ArmWatchdog(int gen); // 0x0000000180929AA0-0x0000000180929C90
	private static void StopWatchdog(); // 0x0000000180929C90-0x0000000180929E30
}

