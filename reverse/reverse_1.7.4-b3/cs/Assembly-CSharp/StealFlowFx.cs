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

public static class StealFlowFx // TypeDefIndex: 2332
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
	private static bool IsWeak { [CompilerGenerated] set; } // 0x0000000180B33450-0x0000000180B334B0

	// Nested types
	private class Fx // TypeDefIndex: 2333
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
		public Fx(); // 0x0000000180B359F0-0x0000000180B35A90
	}

	[CompilerGenerated]
	private sealed class _Routine_d__27 : IEnumerator<object> // TypeDefIndex: 2334
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
		void IDisposable.Dispose(); // 0x0000000180B35A90-0x0000000180B35B00
		private bool MoveNext(); // 0x0000000180B35B00-0x0000000180B37EE0
		private void __m__Finally1(); // 0x0000000180B37EE0-0x0000000180B38430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B38430-0x0000000180B38470
	}

	// Constructors
	static StealFlowFx(); // 0x0000000180B35560-0x0000000180B359F0

	// Methods
	public static bool Play(bool victimEnemySide, bool isPower, int amount = 1 /* Metadata: 0x005F0B2D */); // 0x0000000180B32EB0-0x0000000180B33060
	public static bool PlayAt(SpriteRenderer victim, SpriteRenderer attacker, bool isPower, int amount = 1 /* Metadata: 0x005F0B2E */); // 0x0000000180B33060-0x0000000180B33450
	public static void ResetForMatchExit(); // 0x0000000180B334B0-0x0000000180B33A20
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B33A20-0x0000000180B33C30
	private static bool EnsureNode(SpriteRenderer attacker); // 0x0000000180B33C30-0x0000000180B34E60
	private static SpriteRenderer MakeChild(Transform parent, string name, Sprite sprite, SpriteRenderer host); // 0x0000000180B34E60-0x0000000180B35210
	private static float Fit(Sprite sp, float wantH); // 0x0000000180B35210-0x0000000180B353A0
	private static Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, float k); // 0x0000000180B353A0-0x0000000180B35420
	private static Vector2 BezierTangent(Vector2 p0, Vector2 p1, Vector2 p2, float k); // 0x0000000180B35420-0x0000000180B354A0
	[IteratorStateMachine(typeof(_Routine_d__27))]
	private static IEnumerator Routine(SpriteRenderer victim, bool isPower, bool weak); // 0x0000000180B354A0-0x0000000180B35560
}

