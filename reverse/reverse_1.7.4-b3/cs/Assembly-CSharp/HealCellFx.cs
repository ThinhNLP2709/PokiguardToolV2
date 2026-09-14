/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HealCellFx // TypeDefIndex: 2335
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2336
	{
		// Fields
		public AnimationClip[] clips; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayInner_b__0(AnimationClip[] c); // 0x000000018076D550-0x000000018076D5B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 2337
	{
		// Fields
		public GameObject fx; // 0x10
		public SpriteRenderer fsr; // 0x18
		public Vector3 s0; // 0x20

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Flash_b__0(float k); // 0x0000000180B38DB0-0x0000000180B39150
	}

	[CompilerGenerated]
	private sealed class _Flash_d__13 : IEnumerator<object> // TypeDefIndex: 2338
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject parent; // 0x20
		public SpriteRenderer host; // 0x28
		public Vector3 boardCenterWorld; // 0x30
		private __c__DisplayClass13_0 __8__1; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x0000000180B39150-0x0000000180B39DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B39DF0-0x0000000180B39E30
	}

	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 2339
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SpriteRenderer host; // 0x20
		public Vector3 boardCenterWorld; // 0x28
		public int petId; // 0x34
		private GameObject _go_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B39E30-0x0000000180B39EF0
		private bool MoveNext(); // 0x0000000180B39EF0-0x0000000180B3ABC0
		private void __m__Finally1(); // 0x0000000180B3ABC0-0x0000000180B3AD00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B3AD00-0x0000000180B3AD40
	}

	[CompilerGenerated]
	private sealed class _PlayInner_d__12 : IEnumerator<object> // TypeDefIndex: 2340
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int petId; // 0x20
		public SpriteRenderer sr; // 0x28
		public GameObject petGo; // 0x30
		public SpriteRenderer host; // 0x38
		private __c__DisplayClass12_0 __8__1; // 0x40
		public GameObject go; // 0x48
		public Vector3 boardCenterWorld; // 0x50
		private Animator _anim_5__2; // 0x60
		private float _animSeconds_5__3; // 0x68
		private float _t1_5__4; // 0x6C
		private float _t0_5__5; // 0x70

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayInner_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B3AD40-0x0000000180B3AE00
		private bool MoveNext(); // 0x0000000180B3AE00-0x0000000180B3C1B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B3C1B0-0x0000000180B3C1F0
	}

	[CompilerGenerated]
	private sealed class _WaitRealtime_d__14 : IEnumerator<object> // TypeDefIndex: 2341
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20
		private float _t0_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitRealtime_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B3C1F0-0x0000000180B3C320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B3C320-0x0000000180B3C360
	}

	// Methods
	public static void Prewarm(int petId); // 0x0000000180B38470-0x0000000180B38580
	[IteratorStateMachine(typeof(_Play_d__10))]
	public static IEnumerator Play(int petId, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180B38580-0x0000000180B38650
	private static void PinPet(Transform petTf, Sprite s); // 0x0000000180B38650-0x0000000180B38A50
	[IteratorStateMachine(typeof(_PlayInner_d__12))]
	private static IEnumerator PlayInner(GameObject go, GameObject petGo, SpriteRenderer sr, SpriteRenderer host, int petId, Vector3 boardCenterWorld); // 0x0000000180B38A50-0x0000000180B38C30
	[IteratorStateMachine(typeof(_Flash_d__13))]
	private static IEnumerator Flash(GameObject parent, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180B38C30-0x0000000180B38D50
	[IteratorStateMachine(typeof(_WaitRealtime_d__14))]
	private static IEnumerator WaitRealtime(float seconds); // 0x0000000180B38D50-0x0000000180B38DB0
}

