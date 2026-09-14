/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class DotAffixHudLayout // TypeDefIndex: 2183
{
	// Fields
	private static readonly Dictionary<long, Vector2[]> _offsetCache; // 0x00
	private static readonly List<Rect> _near; // 0x08
	private static int _lastHit; // 0x10
	private static readonly Dictionary<Vector2[], Rect> _spanCache; // 0x18

	// Nested types
	public struct Variant // TypeDefIndex: 2184
	{
		// Fields
		public float w; // 0x00
		public float h; // 0x04
		public float scale; // 0x08
		public int cols; // 0x0C
		public float penalty; // 0x10
		public int tag; // 0x14

		// Constructors
		public Variant(float w, float h, float scale, int cols, float penalty = 0f /* Metadata: 0x005F078F */, int tag = 0 /* Metadata: 0x005F0793 */); // 0x0000000180A78750-0x0000000180A78780
	}

	public struct Result // TypeDefIndex: 2185
	{
		// Fields
		public bool placed; // 0x00
		public bool clean; // 0x01
		public int variant; // 0x04
		public Rect rect; // 0x08
		public float overlap; // 0x18
		public Vector2 offset; // 0x1C
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2186
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<float, Vector2>> __9__8_0; // 0x08
		public static Comparison<int> __9__22_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180A78780-0x0000000180A78820
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _Offsets_b__8_0(KeyValuePair<float, Vector2> a, KeyValuePair<float, Vector2> b); // 0x0000000180A78820-0x0000000180A78960
		internal int _ColumnChoices_b__22_0(int a, int b); // 0x0000000180A78960-0x0000000180A78980
	}

	// Constructors
	static DotAffixHudLayout(); // 0x0000000180A78490-0x0000000180A78750

	// Methods
	public static float PenaltyFor(float relScale, int colsDropped); // 0x0000000180A75950-0x0000000180A759B0
	public static float CostOf(Vector2 o); // 0x0000000180A759B0-0x0000000180A75A00
	public static Vector2[] Offsets(int step, int maxUp, int maxDown, int maxSide); // 0x0000000180A75A00-0x0000000180A75EF0
	public static Result Solve(Vector2 anchor, IList<Variant> variants, Rect bounds, IList<Rect> obstacles, Vector2[] offsets); // 0x0000000180A75EF0-0x0000000180A76C60
	private static Rect SpanOf(Vector2[] offsets); // 0x0000000180A76C60-0x0000000180A76E70
	private static bool AnyCleanForMin(Vector2 anchor, IList<Variant> variants, Rect bounds, IList<Rect> obstacles, Vector2[] offsets, Rect span); // 0x0000000180A76E70-0x0000000180A774F0
	private static void GatherNear(Vector2 anchor, Rect span, float w, float h, IList<Rect> obstacles); // 0x0000000180A774F0-0x0000000180A77920
	private static bool HitsNear(Rect r); // 0x0000000180A77920-0x0000000180A77BE0
	public static bool Inside(Rect r, Rect bounds); // 0x0000000180A77BE0-0x0000000180A77CB0
	public static bool Intersects(Rect a, Rect b); // 0x0000000180A77CB0-0x0000000180A77D50
	public static float OverlapArea(Rect r, IList<Rect> obstacles); // 0x0000000180A77D50-0x0000000180A77FE0
	public static Rect Inflate(Rect r, float m); // 0x0000000180A77FE0-0x0000000180A78080
	public static List<int> ColumnChoices(int entries, int prefCols); // 0x0000000180A78080-0x0000000180A78380
	private static void AddUnique(List<int> list, int v); // 0x0000000180A78380-0x0000000180A78490
}

