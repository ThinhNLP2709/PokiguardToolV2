/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HealCellFx // TypeDefIndex: 2342
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2343
	{
		// Fields
		public AnimationClip[] clips; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayInner_b__0(AnimationClip[] c); // 0x000000018076F420-0x000000018076F480
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 2344
	{
		// Fields
		public GameObject fx; // 0x10
		public SpriteRenderer fsr; // 0x18
		public Vector3 s0; // 0x20

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Flash_b__0(float k); // 0x0000000180B460F0-0x0000000180B46490
	}

	[CompilerGenerated]
	private sealed class _Flash_d__13 : IEnumerator<object> // TypeDefIndex: 2345
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
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x0000000180B46490-0x0000000180B47130
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B47130-0x0000000180B47170
	}

	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 2346
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
		void IDisposable.Dispose(); // 0x0000000180B47170-0x0000000180B47230
		private bool MoveNext(); // 0x0000000180B47230-0x0000000180B47F00
		private void __m__Finally1(); // 0x0000000180B47F00-0x0000000180B48040
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B48040-0x0000000180B48080
	}

	[CompilerGenerated]
	private sealed class _PlayInner_d__12 : IEnumerator<object> // TypeDefIndex: 2347
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
		void IDisposable.Dispose(); // 0x0000000180B48080-0x0000000180B48140
		private bool MoveNext(); // 0x0000000180B48140-0x0000000180B494F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B494F0-0x0000000180B49530
	}

	[CompilerGenerated]
	private sealed class _WaitRealtime_d__14 : IEnumerator<object> // TypeDefIndex: 2348
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B49530-0x0000000180B49660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B49660-0x0000000180B496A0
	}

	// Methods
	public static void Prewarm(int petId); // 0x0000000180B457B0-0x0000000180B458C0
	[IteratorStateMachine(typeof(_Play_d__10))]
	public static IEnumerator Play(int petId, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180B458C0-0x0000000180B45990
	private static void PinPet(Transform petTf, Sprite s); // 0x0000000180B45990-0x0000000180B45D90
	[IteratorStateMachine(typeof(_PlayInner_d__12))]
	private static IEnumerator PlayInner(GameObject go, GameObject petGo, SpriteRenderer sr, SpriteRenderer host, int petId, Vector3 boardCenterWorld); // 0x0000000180B45D90-0x0000000180B45F70
	[IteratorStateMachine(typeof(_Flash_d__13))]
	private static IEnumerator Flash(GameObject parent, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180B45F70-0x0000000180B46090
	[IteratorStateMachine(typeof(_WaitRealtime_d__14))]
	private static IEnumerator WaitRealtime(float seconds); // 0x0000000180B46090-0x0000000180B460F0
}

