/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class CanDauVanFx // TypeDefIndex: 396
{
	// Fields
	public static readonly Color DOT_COLOR; // 0x00
	public static readonly int[][] FACES; // 0x10
	private static readonly List<int> _ids; // 0x18
	private static readonly List<GameObject> _temp; // 0x20
	private static readonly List<KeyValuePair<Transform, Vector3>> _scaled; // 0x28
	private static readonly List<Transform> _rotated; // 0x30
	private static Sprite _disc; // 0x38

	// Properties
	public static bool Enabled { get; } // 0x000000018032E940-0x000000018032E990 
	public static bool LowTier { get; } // 0x000000018032E990-0x000000018032E9F0 
	public static float HopTime { get; } // 0x000000018032EAE0-0x000000018032EB50 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 397
	{
		// Fields
		public Action onDone; // 0x10

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DiceRoll_b__0(); // 0x0000000180335C50-0x0000000180335C70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 398
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Tumble_b__0(float k); // 0x0000000180335C70-0x0000000180335E80
		internal void _Tumble_b__1(); // 0x0000000180335E80-0x0000000180335FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 399
	{
		// Fields
		public RectTransform ring; // 0x10
		public Image img; // 0x18

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Ripple_b__0(float k); // 0x0000000180335FE0-0x0000000180336220
		internal void _Ripple_b__1(); // 0x0000000180336220-0x0000000180336400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 400
	{
		// Fields
		public RectTransform hero; // 0x10
		public Vector2 from; // 0x18
		public Vector2 to; // 0x20
		public bool arc; // 0x28
		public Image heroImg; // 0x30
		public Sprite jump; // 0x38
		public Sprite idle; // 0x40
		public Action onDone; // 0x48

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Hop_b__0(float k); // 0x0000000180336400-0x0000000180336840
		internal void _Hop_b__1(); // 0x0000000180336840-0x0000000180336B40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 401
	{
		// Fields
		public Graphic g; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Alpha_b__0(float a); // 0x0000000180336B40-0x0000000180336CC0
		internal void _Alpha_b__1(); // 0x0000000180336CC0-0x0000000180336CE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 402
	{
		// Fields
		public RectTransform icon; // 0x10
		public RectTransform amount; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RewardPop_b__0(float k); // 0x0000000180336CE0-0x0000000180337080
		internal void _RewardPop_b__1(); // 0x0000000180337080-0x0000000180337330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass35_0 // TypeDefIndex: 403
	{
		// Fields
		public RectTransform icon; // 0x10
		public Vector2 from; // 0x18
		public Vector2 ctrl; // 0x20
		public Vector2 to; // 0x28
		public Action onDone; // 0x30

		// Constructors
		public __c__DisplayClass35_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RewardFly_b__0(float k); // 0x0000000180337330-0x0000000180337570
		internal void _RewardFly_b__1(); // 0x0000000180337570-0x0000000180337690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 404
	{
		// Fields
		public RectTransform node; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass38_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopOut_b__0(); // 0x0000000180337690-0x0000000180337810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 405
	{
		// Fields
		public RectTransform node; // 0x10
		public float y; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SlideX_b__0(float x); // 0x0000000180337810-0x0000000180337920
		internal void _SlideX_b__1(); // 0x0000000180337920-0x0000000180337940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 406
	{
		// Fields
		public Image img; // 0x10
		public RectTransform rt; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TileGlow_b__0(float k); // 0x0000000180337940-0x0000000180337C60
		internal void _TileGlow_b__1(); // 0x0000000180337C60-0x0000000180337E30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 407
	{
		// Fields
		public RectTransform rays; // 0x10
		public Image img; // 0x18
		public Action<float> __9__2; // 0x20

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GiftRays_b__0(float k); // 0x0000000180337E30-0x00000001803381D0
		internal void _GiftRays_b__1(); // 0x00000001803381D0-0x0000000180338560
		internal void _GiftRays_b__2(float z); // 0x0000000180338560-0x0000000180338730
	}

	// Constructors
	static CanDauVanFx(); // 0x00000001803354A0-0x0000000180335C50

	// Methods
	public static bool On(string name); // 0x000000018032E9F0-0x000000018032EAE0
	public static void ShowFace(Transform dice, int value); // 0x000000018032EB50-0x000000018032EEB0
	public static void HideDots(Transform dice); // 0x000000018032EEB0-0x000000018032EF10
	public static void DiceRoll(Image f0, Image f1, RectTransform ring0, RectTransform ring1, Sprite rollSprite, Action onDone); // 0x000000018032EF10-0x000000018032F320
	private static void Tumble(Image face, Sprite rollSprite); // 0x000000018032F320-0x000000018032F770
	private static void Ripple(RectTransform ring); // 0x000000018032F770-0x000000018032FE40
	public static void StopDice(Image f0, Image f1, RectTransform ring0, RectTransform ring1); // 0x000000018032FE40-0x0000000180330210
	private static void StopOne(Image f); // 0x0000000180330210-0x0000000180330400
	public static void Hop(RectTransform hero, Vector2 from, Vector2 to, float dur, Image heroImg, Sprite idle, Sprite jump, Action onDone); // 0x0000000180330400-0x0000000180330B30
	public static void Alpha(Graphic g, float to, float dur, Action onDone); // 0x0000000180330B30-0x0000000180330FA0
	public static void RewardPop(CanDauVanTileView tileView, Action onDone); // 0x0000000180330FA0-0x0000000180331750
	public static void RewardFly(RectTransform icon, Vector2 from, Vector2 to, Action onDone); // 0x0000000180331750-0x0000000180331C70
	public static void Pop(RectTransform node, float dur = 0.25f /* Metadata: 0x005EF1B2 */); // 0x0000000180331C70-0x0000000180331F70
	public static void PopIn(RectTransform node); // 0x0000000180331F70-0x0000000180331FD0
	public static void PopOut(RectTransform node, Action onDone); // 0x0000000180331FD0-0x0000000180332460
	public static int SlideX(RectTransform node, float toX, float dur, Action onDone); // 0x0000000180332460-0x00000001803324F0
	public static int SlideX(RectTransform node, float toX, float dur, LeanTweenType ease, Action onDone); // 0x00000001803324F0-0x0000000180332920
	public static void TileGlow(Image img); // 0x0000000180332920-0x0000000180332DB0
	public static void GiftRays(RectTransform rays); // 0x0000000180332DB0-0x0000000180333550
	public static void StopRays(RectTransform rays); // 0x0000000180333550-0x0000000180333830
	public static int Delay(GameObject host, float sec, Action fn); // 0x0000000180333830-0x00000001803339E0
	public static void Cancel(int id); // 0x00000001803339E0-0x0000000180333AF0
	public static Sprite Disc(); // 0x0000000180333AF0-0x0000000180334110
	public static void CancelAll(); // 0x0000000180334110-0x0000000180334A70
	public static void RegisterTemp(GameObject go); // 0x0000000180334A70-0x0000000180334BC0
	public static void Kill(GameObject go); // 0x0000000180334BC0-0x0000000180334DC0
	private static void Track(int id); // 0x0000000180334DC0-0x0000000180334EE0
	private static void RememberScale(Transform t); // 0x0000000180334EE0-0x00000001803352B0
	private static void RememberRotation(Transform t); // 0x00000001803352B0-0x0000000180335460
	private static float EaseOutBack(float t); // 0x0000000180335460-0x00000001803354A0
}

