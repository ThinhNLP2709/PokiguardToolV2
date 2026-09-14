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

public static class RageBurstFx // TypeDefIndex: 2368
{
	// Fields
	private static readonly SideFx[] _sides; // 0x00
	private static Sprite _ringSprite; // 0x08

	// Nested types
	private class SideFx // TypeDefIndex: 2369
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
	private sealed class _BurstRoutine_d__14 : IEnumerator<object> // TypeDefIndex: 2370
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
		void IDisposable.Dispose(); // 0x0000000180B4DDE0-0x0000000180B4DEA0
		private bool MoveNext(); // 0x0000000180B4DEA0-0x0000000180B4E830
		private void __m__Finally1(); // 0x0000000180B4E830-0x0000000180B4EAA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4EAA0-0x0000000180B4EAE0
	}

	// Constructors
	static RageBurstFx(); // 0x0000000180B4DC60-0x0000000180B4DDE0

	// Methods
	public static void Play(bool enemySide); // 0x0000000180B4BFF0-0x0000000180B4C160
	public static void ResetForMatchExit(); // 0x0000000180B4C160-0x0000000180B4C550
	private static void PlayInner(int idx, bool enemySide); // 0x0000000180B4C550-0x0000000180B4C820
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B4C820-0x0000000180B4CA30
	private static Sprite RingSprite(); // 0x0000000180B4CA30-0x0000000180B4CBF0
	private static bool EnsureNode(SideFx s, SpriteRenderer host); // 0x0000000180B4CBF0-0x0000000180B4DBC0
	private static void SyncAnchor(SideFx s, SpriteRenderer host); // 0x0000000180B2FB90-0x0000000180B2FF20
	[IteratorStateMachine(typeof(_BurstRoutine_d__14))]
	private static IEnumerator BurstRoutine(SideFx s); // 0x0000000180B4DBC0-0x0000000180B4DC60
}

