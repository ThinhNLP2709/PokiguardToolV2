/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public static bool Enabled { get; } // 0x000000018032E820-0x000000018032E870 
	public static bool LowTier { get; } // 0x000000018032E870-0x000000018032E8D0 
	public static float HopTime { get; } // 0x000000018032E9C0-0x000000018032EA30 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 397
	{
		// Fields
		public Action onDone; // 0x10

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DiceRoll_b__0(); // 0x0000000180335B30-0x0000000180335B50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 398
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Tumble_b__0(float k); // 0x0000000180335B50-0x0000000180335D60
		internal void _Tumble_b__1(); // 0x0000000180335D60-0x0000000180335EC0
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
		internal void _Ripple_b__0(float k); // 0x0000000180335EC0-0x0000000180336100
		internal void _Ripple_b__1(); // 0x0000000180336100-0x00000001803362E0
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
		internal void _Hop_b__0(float k); // 0x00000001803362E0-0x0000000180336720
		internal void _Hop_b__1(); // 0x0000000180336720-0x0000000180336A20
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
		internal void _Alpha_b__0(float a); // 0x0000000180336A20-0x0000000180336BA0
		internal void _Alpha_b__1(); // 0x0000000180336BA0-0x0000000180336BC0
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
		internal void _RewardPop_b__0(float k); // 0x0000000180336BC0-0x0000000180336F60
		internal void _RewardPop_b__1(); // 0x0000000180336F60-0x0000000180337210
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
		internal void _RewardFly_b__0(float k); // 0x0000000180337210-0x0000000180337450
		internal void _RewardFly_b__1(); // 0x0000000180337450-0x0000000180337570
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
		internal void _PopOut_b__0(); // 0x0000000180337570-0x00000001803376F0
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
		internal void _SlideX_b__0(float x); // 0x00000001803376F0-0x0000000180337800
		internal void _SlideX_b__1(); // 0x0000000180337800-0x0000000180337820
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
		internal void _TileGlow_b__0(float k); // 0x0000000180337820-0x0000000180337B40
		internal void _TileGlow_b__1(); // 0x0000000180337B40-0x0000000180337D10
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
		internal void _GiftRays_b__0(float k); // 0x0000000180337D10-0x00000001803380B0
		internal void _GiftRays_b__1(); // 0x00000001803380B0-0x0000000180338440
		internal void _GiftRays_b__2(float z); // 0x0000000180338440-0x0000000180338610
	}

	// Constructors
	static CanDauVanFx(); // 0x0000000180335380-0x0000000180335B30

	// Methods
	public static bool On(string name); // 0x000000018032E8D0-0x000000018032E9C0
	public static void ShowFace(Transform dice, int value); // 0x000000018032EA30-0x000000018032ED90
	public static void HideDots(Transform dice); // 0x000000018032ED90-0x000000018032EDF0
	public static void DiceRoll(Image f0, Image f1, RectTransform ring0, RectTransform ring1, Sprite rollSprite, Action onDone); // 0x000000018032EDF0-0x000000018032F200
	private static void Tumble(Image face, Sprite rollSprite); // 0x000000018032F200-0x000000018032F650
	private static void Ripple(RectTransform ring); // 0x000000018032F650-0x000000018032FD20
	public static void StopDice(Image f0, Image f1, RectTransform ring0, RectTransform ring1); // 0x000000018032FD20-0x00000001803300F0
	private static void StopOne(Image f); // 0x00000001803300F0-0x00000001803302E0
	public static void Hop(RectTransform hero, Vector2 from, Vector2 to, float dur, Image heroImg, Sprite idle, Sprite jump, Action onDone); // 0x00000001803302E0-0x0000000180330A10
	public static void Alpha(Graphic g, float to, float dur, Action onDone); // 0x0000000180330A10-0x0000000180330E80
	public static void RewardPop(CanDauVanTileView tileView, Action onDone); // 0x0000000180330E80-0x0000000180331630
	public static void RewardFly(RectTransform icon, Vector2 from, Vector2 to, Action onDone); // 0x0000000180331630-0x0000000180331B50
	public static void Pop(RectTransform node, float dur = 0.25f /* Metadata: 0x005EDDE2 */); // 0x0000000180331B50-0x0000000180331E50
	public static void PopIn(RectTransform node); // 0x0000000180331E50-0x0000000180331EB0
	public static void PopOut(RectTransform node, Action onDone); // 0x0000000180331EB0-0x0000000180332340
	public static int SlideX(RectTransform node, float toX, float dur, Action onDone); // 0x0000000180332340-0x00000001803323D0
	public static int SlideX(RectTransform node, float toX, float dur, LeanTweenType ease, Action onDone); // 0x00000001803323D0-0x0000000180332800
	public static void TileGlow(Image img); // 0x0000000180332800-0x0000000180332C90
	public static void GiftRays(RectTransform rays); // 0x0000000180332C90-0x0000000180333430
	public static void StopRays(RectTransform rays); // 0x0000000180333430-0x0000000180333710
	public static int Delay(GameObject host, float sec, Action fn); // 0x0000000180333710-0x00000001803338C0
	public static void Cancel(int id); // 0x00000001803338C0-0x00000001803339D0
	public static Sprite Disc(); // 0x00000001803339D0-0x0000000180333FF0
	public static void CancelAll(); // 0x0000000180333FF0-0x0000000180334950
	public static void RegisterTemp(GameObject go); // 0x0000000180334950-0x0000000180334AA0
	public static void Kill(GameObject go); // 0x0000000180334AA0-0x0000000180334CA0
	private static void Track(int id); // 0x0000000180334CA0-0x0000000180334DC0
	private static void RememberScale(Transform t); // 0x0000000180334DC0-0x0000000180335190
	private static void RememberRotation(Transform t); // 0x0000000180335190-0x0000000180335340
	private static float EaseOutBack(float t); // 0x0000000180335340-0x0000000180335380
}

