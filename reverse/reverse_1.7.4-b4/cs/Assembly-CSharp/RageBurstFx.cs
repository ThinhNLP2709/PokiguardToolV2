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

public static class RageBurstFx // TypeDefIndex: 2375
{
	// Fields
	private static readonly SideFx[] _sides; // 0x00
	private static Sprite _ringSprite; // 0x08

	// Nested types
	private class SideFx // TypeDefIndex: 2376
	{
		// Fields
		public SpriteRenderer host; // 0x10
		public GameObject root; // 0x18
		public SpriteRenderer ring; // 0x20
		public Vector3 ringBaseScale; // 0x28
		public Coroutine co; // 0x38

		// Constructors
		public SideFx(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _BurstRoutine_d__14 : IEnumerator<object> // TypeDefIndex: 2377
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SideFx s; // 0x20
		private SpriteRenderer _ring_5__2; // 0x28
		private float _ringSec_5__3; // 0x30
		private float _ringTo_5__4; // 0x34
		private Color _col_5__5; // 0x38
		private float _t_5__6; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BurstRoutine_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B5B060-0x0000000180B5B120
		private bool MoveNext(); // 0x0000000180B5B120-0x0000000180B5BAB0
		private void __m__Finally1(); // 0x0000000180B5BAB0-0x0000000180B5BD20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B5BD20-0x0000000180B5BD60
	}

	// Constructors
	static RageBurstFx(); // 0x0000000180B5AEE0-0x0000000180B5B060

	// Methods
	public static void Play(bool enemySide); // 0x0000000180B59270-0x0000000180B593E0
	public static void ResetForMatchExit(); // 0x0000000180B593E0-0x0000000180B597D0
	private static void PlayInner(int idx, bool enemySide); // 0x0000000180B597D0-0x0000000180B59AA0
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B59AA0-0x0000000180B59CB0
	private static Sprite RingSprite(); // 0x0000000180B59CB0-0x0000000180B59E70
	private static bool EnsureNode(SideFx s, SpriteRenderer host); // 0x0000000180B59E70-0x0000000180B5AE40
	private static void SyncAnchor(SideFx s, SpriteRenderer host); // 0x0000000180B3CED0-0x0000000180B3D260
	[IteratorStateMachine(typeof(_BurstRoutine_d__14))]
	private static IEnumerator BurstRoutine(SideFx s); // 0x0000000180B5AE40-0x0000000180B5AEE0
}

