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

public static class RageReadyFx // TypeDefIndex: 2374
{
	// Fields
	private static readonly SideState[] _sides; // 0x00

	// Nested types
	private class SideState // TypeDefIndex: 2375
	{
		// Fields
		public Slider slider; // 0x10
		public Image fill; // 0x18
		public Color baseColor; // 0x20
		public bool pulsing; // 0x30
		public Coroutine co; // 0x38

		// Constructors
		public SideState(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _PulseRoutine_d__8 : IEnumerator<object> // TypeDefIndex: 2376
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SideState s; // 0x20
		private Image _img_5__2; // 0x28
		private Color _baseC_5__3; // 0x30
		private float _hz_5__4; // 0x40
		private float _t_5__5; // 0x44

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PulseRoutine_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B51D60-0x0000000180B51E20
		private bool MoveNext(); // 0x0000000180B51E20-0x0000000180B52300
		private void __m__Finally1(); // 0x0000000180B52300-0x0000000180B52480
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B52480-0x0000000180B524C0
	}

	// Constructors
	static RageReadyFx(); // 0x0000000180B51BE0-0x0000000180B51D60

	// Methods
	public static void Refresh(Slider slider, int power, int threshold, bool npcSide); // 0x0000000180B50EB0-0x0000000180B50FE0
	public static void ResetForMatchExit(); // 0x0000000180B50FE0-0x0000000180B511E0
	private static void RefreshInner(SideState s, Slider slider, int power, int threshold); // 0x0000000180B511E0-0x0000000180B516D0
	private static void StartPulse(SideState s); // 0x0000000180B516D0-0x0000000180B518F0
	private static void StopAndRestore(SideState s); // 0x0000000180B518F0-0x0000000180B51B40
	[IteratorStateMachine(typeof(_PulseRoutine_d__8))]
	private static IEnumerator PulseRoutine(SideState s); // 0x0000000180B51B40-0x0000000180B51BE0
}

