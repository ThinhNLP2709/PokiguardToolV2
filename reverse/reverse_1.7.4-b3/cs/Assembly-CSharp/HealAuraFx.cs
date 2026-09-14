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

public static class HealAuraFx // TypeDefIndex: 2329
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
	private class SideFx // TypeDefIndex: 2330
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
		public SideFx(); // 0x0000000180B30BC0-0x0000000180B30C60
	}

	[CompilerGenerated]
	private sealed class _Routine_d__36 : IEnumerator<object> // TypeDefIndex: 2331
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
		void IDisposable.Dispose(); // 0x0000000180B30C60-0x0000000180B30CD0
		private bool MoveNext(); // 0x0000000180B30CD0-0x0000000180B32880
		private void __m__Finally1(); // 0x0000000180B32880-0x0000000180B32E70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B32E70-0x0000000180B32EB0
	}

	// Constructors
	static HealAuraFx(); // 0x0000000180B30540-0x0000000180B30BC0

	// Methods
	public static AuraKind KindForTag(string tag); // 0x0000000180B2D260-0x0000000180B2D400
	public static bool Play(bool enemySide, AuraKind kind = AuraKind.None | AuraKind.Heal /* Metadata: 0x005F0B2B */); // 0x0000000180B2D400-0x0000000180B2D580
	public static bool PlayAt(SpriteRenderer host, bool enemySide, AuraKind kind = AuraKind.None | AuraKind.Heal /* Metadata: 0x005F0B2C */); // 0x0000000180B2D580-0x0000000180B2D8B0
	public static void ResetForMatchExit(); // 0x0000000180B2D8B0-0x0000000180B2DC20
	private static SpriteRenderer ResolveHost(bool enemySide); // 0x0000000180B2DC20-0x0000000180B2DE30
	private static Color ColorOf(AuraKind k); // 0x0000000180B2DE30-0x0000000180B2E060
	private static Color BlendColor(AuraKind kinds); // 0x0000000180B2E060-0x0000000180B2E2D0
	private static bool EnsureNode(SideFx s, SpriteRenderer host); // 0x0000000180B2E2D0-0x0000000180B2F5C0
	private static SpriteRenderer MakeChild(Transform parent, string name, Sprite sprite, SpriteRenderer host, int orderAbove, Vector3 localPos); // 0x0000000180B2F5C0-0x0000000180B2FA00
	private static float Fit(Sprite sp, float wantH); // 0x0000000180B2FA00-0x0000000180B2FB90
	private static void SyncAnchor(SideFx s, SpriteRenderer host); // 0x0000000180B2FB90-0x0000000180B2FF20
	private static float Envelope(float k, float inFrac, float outFrac); // 0x0000000180B2FF20-0x0000000180B2FFF0
	private static void ReseedKinds(SideFx s); // 0x0000000180B2FFF0-0x0000000180B304A0
	[IteratorStateMachine(typeof(_Routine_d__36))]
	private static IEnumerator Routine(SideFx s); // 0x0000000180B304A0-0x0000000180B30540
}

