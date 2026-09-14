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

public static class StealFlowFx // TypeDefIndex: 2339
{
	// Fields
	private static readonly Fx _fx; // 0x00
	private static readonly float[] _cStart; // 0x08
	private static readonly float[] _cSize; // 0x10
	private static readonly Vector2[] _cP0; // 0x18
	private static readonly Vector2[] _cP1; // 0x20
	private static readonly Vector2[] _cP2; // 0x28
	private static readonly bool[] _cLight; // 0x30
	[CompilerGenerated]
	private static bool _IsWeak_k__BackingField; // 0x38

	// Properties
	private static bool IsWeak { [CompilerGenerated] set; } // 0x0000000180B40790-0x0000000180B407F0

	// Nested types
	private class Fx // TypeDefIndex: 2340
	{
		// Fields
		public SpriteRenderer attacker; // 0x10
		public GameObject root; // 0x18
		public SpriteRenderer implode; // 0x20
		public SpriteRenderer flash; // 0x28
		public SpriteRenderer[] comets; // 0x30
		public float petW; // 0x38
		public float petH; // 0x3C
		public Coroutine co; // 0x40

		// Constructors
		public Fx(); // 0x0000000180B42D30-0x0000000180B42DD0
	}

	[CompilerGenerated]
	private sealed class _Routine_d__27 : IEnumerator<object> // TypeDefIndex: 2341
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool weak; // 0x20
		public bool isPower; // 0x21
		public SpriteRenderer victim; // 0x28
		private float _D_5__2; // 0x30
		private int _n_5__3; // 0x34
		private float _alphaMul_5__4; // 0x38
		private Color _col_5__5; // 0x3C
		private Color _light_5__6; // 0x4C
		private float _travel_5__7; // 0x5C
		private float _implodeBase_5__8; // 0x60
		private float _flashBase_5__9; // 0x64
		private float _t_5__10; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Routine_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B42DD0-0x0000000180B42E40
		private bool MoveNext(); // 0x0000000180B42E40-0x0000000180B45220
		private void __m__Finally1(); // 0x0000000180B45220-0x0000000180B45770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B45770-0x0000000180B457B0
	}

	// Constructors
	static StealFlowFx(); // 0x0000000180B428A0-0x0000000180B42D30

	// Methods
	public static bool Play(bool victimEnemySide, bool isPower, int amount = 1 /* Metadata: 0x005F1F44 */); // 0x0000000180B401F0-0x0000000180B403A0
	public static bool PlayAt(SpriteRenderer victim, SpriteRenderer attacker, bool isPower, int amount = 1 /* Metadata: 0x005F1F45 */); // 0x0000000180B403A0-0x0000000180B40790
	public static void ResetForMatchExit(); // 0x0000000180B407F0-0x0000000180B40D60
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B40D60-0x0000000180B40F70
	private static bool EnsureNode(SpriteRenderer attacker); // 0x0000000180B40F70-0x0000000180B421A0
	private static SpriteRenderer MakeChild(Transform parent, string name, Sprite sprite, SpriteRenderer host); // 0x0000000180B421A0-0x0000000180B42550
	private static float Fit(Sprite sp, float wantH); // 0x0000000180B42550-0x0000000180B426E0
	private static Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, float k); // 0x0000000180B426E0-0x0000000180B42760
	private static Vector2 BezierTangent(Vector2 p0, Vector2 p1, Vector2 p2, float k); // 0x0000000180B42760-0x0000000180B427E0
	[IteratorStateMachine(typeof(_Routine_d__27))]
	private static IEnumerator Routine(SpriteRenderer victim, bool isPower, bool weak); // 0x0000000180B427E0-0x0000000180B428A0
}

