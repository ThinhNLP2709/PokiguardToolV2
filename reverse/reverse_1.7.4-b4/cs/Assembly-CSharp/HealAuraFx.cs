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

public static class HealAuraFx // TypeDefIndex: 2336
{
	// Fields
	private static readonly SideFx[] _sides; // 0x00
	private static readonly float[] _mStart; // 0x08
	private static readonly float[] _mLife; // 0x10
	private static readonly float[] _mX0; // 0x18
	private static readonly float[] _mPhase; // 0x20
	private static readonly float[] _mSize; // 0x28
	private static readonly bool[] _mPlus; // 0x30
	private static readonly bool[] _mLight; // 0x38
	private static readonly AuraKind[] _mKind; // 0x40
	private static readonly AuraKind[] _kindOrder; // 0x48

	// Nested types
	private class SideFx // TypeDefIndex: 2337
	{
		// Fields
		public SpriteRenderer host; // 0x10
		public GameObject root; // 0x18
		public SpriteRenderer glow; // 0x20
		public SpriteRenderer ring; // 0x28
		public SpriteRenderer[] motes; // 0x30
		public Vector3 glowBase; // 0x38
		public Vector3 ringBase; // 0x44
		public float petW; // 0x50
		public float petH; // 0x54
		public Coroutine co; // 0x58
		public AuraKind kinds; // 0x60
		public float startedAt; // 0x64

		// Constructors
		public SideFx(); // 0x0000000180B3DF00-0x0000000180B3DFA0
	}

	[CompilerGenerated]
	private sealed class _Routine_d__36 : IEnumerator<object> // TypeDefIndex: 2338
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SideFx s; // 0x20
		private float _D_5__2; // 0x28
		private int _n_5__3; // 0x2C
		private float _t_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Routine_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B3DFA0-0x0000000180B3E010
		private bool MoveNext(); // 0x0000000180B3E010-0x0000000180B3FBC0
		private void __m__Finally1(); // 0x0000000180B3FBC0-0x0000000180B401B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B401B0-0x0000000180B401F0
	}

	// Constructors
	static HealAuraFx(); // 0x0000000180B3D880-0x0000000180B3DF00

	// Methods
	public static AuraKind KindForTag(string tag); // 0x0000000180B3A5A0-0x0000000180B3A740
	public static bool Play(bool enemySide, AuraKind kind = AuraKind.None | AuraKind.Heal /* Metadata: 0x005F1F42 */); // 0x0000000180B3A740-0x0000000180B3A8C0
	public static bool PlayAt(SpriteRenderer host, bool enemySide, AuraKind kind = AuraKind.None | AuraKind.Heal /* Metadata: 0x005F1F43 */); // 0x0000000180B3A8C0-0x0000000180B3ABF0
	public static void ResetForMatchExit(); // 0x0000000180B3ABF0-0x0000000180B3AF60
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B3AF60-0x0000000180B3B170
	private static Color ColorOf(AuraKind k); // 0x0000000180B3B170-0x0000000180B3B3A0
	private static Color BlendColor(AuraKind kinds); // 0x0000000180B3B3A0-0x0000000180B3B610
	private static bool EnsureNode(SideFx s, SpriteRenderer host); // 0x0000000180B3B610-0x0000000180B3C900
	private static SpriteRenderer MakeChild(Transform parent, string name, Sprite sprite, SpriteRenderer host, int orderAbove, Vector3 localPos); // 0x0000000180B3C900-0x0000000180B3CD40
	private static float Fit(Sprite sp, float wantH); // 0x0000000180B3CD40-0x0000000180B3CED0
	private static void SyncAnchor(SideFx s, SpriteRenderer host); // 0x0000000180B3CED0-0x0000000180B3D260
	private static float Envelope(float k, float inFrac, float outFrac); // 0x0000000180B3D260-0x0000000180B3D330
	private static void ReseedKinds(SideFx s); // 0x0000000180B3D330-0x0000000180B3D7E0
	[IteratorStateMachine(typeof(_Routine_d__36))]
	private static IEnumerator Routine(SideFx s); // 0x0000000180B3D7E0-0x0000000180B3D880
}

