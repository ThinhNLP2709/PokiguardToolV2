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

public static class HealCellFx // TypeDefIndex: 1680
{
	// Fields
	private const string NODE_NAME = "HealCellFx"; // Metadata: 0x0064D949
	private const float PET_ANIM_SECONDS = 1.2f; // Metadata: 0x0064D954
	private const float FLASH_SECONDS = 0.35f; // Metadata: 0x0064D958
	private const float CLIP_WAIT_SECONDS = 0.6f; // Metadata: 0x0064D95C
	private const int ORDER_ABOVE_HOST = 1; // Metadata: 0x0064D960
	private const float Z_TOWARD_CAM = -3f; // Metadata: 0x0064D961
	private const float FLASH_Z_TOWARD_CAM = -2.5f; // Metadata: 0x0064D965
	private const string FLASH_SPRITE = "Image/FusionUI/haoquang"; // Metadata: 0x0064D969
	private const float LUNGE_CAP_RATIO = 0.5f; // Metadata: 0x0064D981

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1681
	{
		// Fields
		public AnimationClip[] clips; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayInner_b__0(AnimationClip[] c); // 0x0000000180439DF0-0x0000000180439E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1682
	{
		// Fields
		public GameObject fx; // 0x10
		public SpriteRenderer fsr; // 0x18
		public Vector3 s0; // 0x20

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Flash_b__0(float k); // 0x00000001805E87B0-0x00000001805E8940
	}

	[CompilerGenerated]
	private sealed class _Flash_d__13 : IEnumerator<object> // TypeDefIndex: 1683
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject parent; // 0x20
		public SpriteRenderer host; // 0x28
		public Vector3 boardCenterWorld; // 0x30
		private __c__DisplayClass13_0 __8__1; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x00000001805E5050-0x00000001805E5640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E5640-0x00000001805E5680
	}

	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 1684
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SpriteRenderer host; // 0x20
		public Vector3 boardCenterWorld; // 0x28
		public int petId; // 0x34
		private GameObject _go_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E7C00-0x00000001805E7C80
		private bool MoveNext(); // 0x00000001805E7570-0x00000001805E7BC0
		private void __m__Finally1(); // 0x00000001805E7C80-0x00000001805E7CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E7BC0-0x00000001805E7C00
	}

	[CompilerGenerated]
	private sealed class _PlayInner_d__12 : IEnumerator<object> // TypeDefIndex: 1685
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayInner_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E7530-0x00000001805E7570
		private bool MoveNext(); // 0x00000001805E6B90-0x00000001805E74F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E74F0-0x00000001805E7530
	}

	[CompilerGenerated]
	private sealed class _WaitRealtime_d__14 : IEnumerator<object> // TypeDefIndex: 1686
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20
		private float _t0_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitRealtime_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E9230-0x00000001805E92B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E92B0-0x00000001805E92F0
	}

	// Methods
	public static void Prewarm(int petId); // 0x00000001805DD2E0-0x00000001805DD370
	[IteratorStateMachine(typeof(_Play_d__10))]
	public static IEnumerator Play(int petId, SpriteRenderer host, Vector3 boardCenterWorld); // 0x00000001805DD240-0x00000001805DD2E0
	private static void PinPet(Transform petTf, Sprite s); // 0x00000001805DCF30-0x00000001805DD160
	[IteratorStateMachine(typeof(_PlayInner_d__12))]
	private static IEnumerator PlayInner(GameObject go, GameObject petGo, SpriteRenderer sr, SpriteRenderer host, int petId, Vector3 boardCenterWorld); // 0x00000001805DD160-0x00000001805DD240
	[IteratorStateMachine(typeof(_Flash_d__13))]
	private static IEnumerator Flash(GameObject parent, SpriteRenderer host, Vector3 boardCenterWorld); // 0x00000001805DCE90-0x00000001805DCF30
	[IteratorStateMachine(typeof(_WaitRealtime_d__14))]
	private static IEnumerator WaitRealtime(float seconds); // 0x00000001805DD370-0x00000001805DD3D0
}

