/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HealCellFx // TypeDefIndex: 1953
{
	// Fields
	private const string NODE_NAME = "HealCellFx"; // Metadata: 0x0068DD78
	private const float PET_ANIM_SECONDS = 1.2f; // Metadata: 0x0068DD83
	private const float FLASH_SECONDS = 0.35f; // Metadata: 0x0068DD87
	private const float CLIP_WAIT_SECONDS = 0.6f; // Metadata: 0x0068DD8B
	private const int ORDER_ABOVE_HOST = 1; // Metadata: 0x0068DD8F
	private const float Z_TOWARD_CAM = -3f; // Metadata: 0x0068DD90
	private const float FLASH_Z_TOWARD_CAM = -2.5f; // Metadata: 0x0068DD94
	private const string FLASH_SPRITE = "Image/FusionUI/haoquang"; // Metadata: 0x0068DD98
	private const float LUNGE_CAP_RATIO = 0.5f; // Metadata: 0x0068DDB0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1954
	{
		// Fields
		public AnimationClip[] clips; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayInner_b__0(AnimationClip[] c); // 0x00000001804F8C00-0x00000001804F8C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1955
	{
		// Fields
		public GameObject fx; // 0x10
		public SpriteRenderer fsr; // 0x18
		public Vector3 s0; // 0x20

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Flash_b__0(float k); // 0x000000018070FF80-0x0000000180710110
	}

	[CompilerGenerated]
	private sealed class _Flash_d__13 : IEnumerator<object> // TypeDefIndex: 1956
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject parent; // 0x20
		public SpriteRenderer host; // 0x28
		public Vector3 boardCenterWorld; // 0x30
		private __c__DisplayClass13_0 __8__1; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x000000018070C8F0-0x000000018070CEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070CEE0-0x000000018070CF20
	}

	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 1957
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SpriteRenderer host; // 0x20
		public Vector3 boardCenterWorld; // 0x28
		public int petId; // 0x34
		private GameObject _go_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018070F280-0x000000018070F300
		private bool MoveNext(); // 0x000000018070EBF0-0x000000018070F240
		private void __m__Finally1(); // 0x000000018070F300-0x000000018070F370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070F240-0x000000018070F280
	}

	[CompilerGenerated]
	private sealed class _PlayInner_d__12 : IEnumerator<object> // TypeDefIndex: 1958
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayInner_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018070EBB0-0x000000018070EBF0
		private bool MoveNext(); // 0x000000018070E210-0x000000018070EB70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070EB70-0x000000018070EBB0
	}

	[CompilerGenerated]
	private sealed class _WaitRealtime_d__14 : IEnumerator<object> // TypeDefIndex: 1959
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20
		private float _t0_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitRealtime_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180710790-0x0000000180710810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180710810-0x0000000180710850
	}

	// Methods
	public static void Prewarm(int petId); // 0x00000001807071F0-0x0000000180707280
	[IteratorStateMachine(typeof(_Play_d__10))]
	public static IEnumerator Play(int petId, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180707150-0x00000001807071F0
	private static void PinPet(Transform petTf, Sprite s); // 0x0000000180706E40-0x0000000180707070
	[IteratorStateMachine(typeof(_PlayInner_d__12))]
	private static IEnumerator PlayInner(GameObject go, GameObject petGo, SpriteRenderer sr, SpriteRenderer host, int petId, Vector3 boardCenterWorld); // 0x0000000180707070-0x0000000180707150
	[IteratorStateMachine(typeof(_Flash_d__13))]
	private static IEnumerator Flash(GameObject parent, SpriteRenderer host, Vector3 boardCenterWorld); // 0x0000000180706DA0-0x0000000180706E40
	[IteratorStateMachine(typeof(_WaitRealtime_d__14))]
	private static IEnumerator WaitRealtime(float seconds); // 0x0000000180707280-0x00000001807072E0
}

