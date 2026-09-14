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

public static class ThanhTuuFx // TypeDefIndex: 1253
{
	// Fields
	public static readonly Color FLASH_YELLOW; // 0x00
	private static readonly List<int> _ids; // 0x10
	private static readonly List<KeyValuePair<Transform, Vector3>> _scaled; // 0x18
	private static readonly List<KeyValuePair<Transform, Quaternion>> _rotated; // 0x20
	private static readonly List<KeyValuePair<RectTransform, Vector2>> _moved; // 0x28
	private static readonly List<GameObject> _temp; // 0x30
	private static Sprite _white; // 0x38
	private static Sprite _ring; // 0x40
	private static Sprite _arrow; // 0x48
	private static Sprite _frame; // 0x50
	private static Sprite _starField; // 0x58

	// Properties
	public static bool Live { get; } // 0x0000000180705AC0-0x0000000180705B40 
	public static bool Enabled { get; } // 0x0000000180705B40-0x0000000180705B90 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1254
	{
		// Fields
		public CanvasGroup group; // 0x10
		public RectTransform box; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeIn_b__0(float a); // 0x000000018070DEF0-0x000000018070E040
		internal void _FadeIn_b__1(float s); // 0x000000018070E040-0x000000018070E1B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 1255
	{
		// Fields
		public CanvasGroup group; // 0x10

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeOut_b__0(float a); // 0x000000018070E1B0-0x000000018070E300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1256
	{
		// Fields
		public RectTransform node; // 0x10
		public float from; // 0x18
		public float peak; // 0x1C
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Pop_b__0(float k); // 0x000000018070E300-0x000000018070E560
		internal void _Pop_b__1(); // 0x000000018070E560-0x000000018070E6E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 1257
	{
		// Fields
		public RectTransform node; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopIn_b__0(float s); // 0x000000018070E6E0-0x000000018070E850
		internal void _PopIn_b__1(); // 0x000000018070E850-0x000000018070E9C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass51_0 // TypeDefIndex: 1258
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SlideX_b__0(float x); // 0x000000018070E9C0-0x000000018070EAF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 1259
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MoveY_b__0(float y); // 0x000000018070EAF0-0x000000018070EC20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass53_0 // TypeDefIndex: 1260
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass53_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Width_b__0(float w); // 0x000000018070EC20-0x000000018070ED50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 1261
	{
		// Fields
		public UnityEngine.UI.Text t; // 0x10
		public long from; // 0x18
		public long to; // 0x20
		public RectTransform rt; // 0x28
		public Color baseColor; // 0x30
		public Action onDone; // 0x40

		// Constructors
		public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CountUp_b__0(float k); // 0x000000018070ED50-0x000000018070F1A0
		internal void _CountUp_b__1(); // 0x000000018070F1A0-0x000000018070F400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 1262
	{
		// Fields
		public RectTransform icon; // 0x10
		public Vector2 from; // 0x18
		public Vector2 ctrl; // 0x20
		public Vector2 to; // 0x28
		public Action onDone; // 0x30

		// Constructors
		public __c__DisplayClass55_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fly_b__0(float k); // 0x000000018070F400-0x000000018070F610
		internal void _Fly_b__1(); // 0x000000018070F610-0x000000018070F730
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 1263
	{
		// Fields
		public RectTransform stamp; // 0x10
		public RectTransform tab; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass56_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StampSlam_b__0(float k); // 0x000000018070F730-0x000000018070F8B0
		internal void _StampSlam_b__1(); // 0x000000018070F8B0-0x000000018070FA60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 1264
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x000000018070FA60-0x000000018070FBB0
		internal void _Shake_b__1(); // 0x000000018070FBB0-0x000000018070FCD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass58_0 // TypeDefIndex: 1265
	{
		// Fields
		public RectTransform node; // 0x10
		public float amp; // 0x18

		// Constructors
		public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Pulse_b__0(float k); // 0x000000018070FCD0-0x000000018070FE70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 1266
	{
		// Fields
		public Graphic g; // 0x10
		public float hi; // 0x18
		public float lo; // 0x1C

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AlphaPulse_b__0(float k); // 0x000000018070FE70-0x000000018070FFF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass60_0 // TypeDefIndex: 1267
	{
		// Fields
		public RectTransform node; // 0x10
		public float span; // 0x18
		public float deg; // 0x1C

		// Constructors
		public __c__DisplayClass60_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Wobble_b__0(float k); // 0x000000018070FFF0-0x0000000180710200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1268
	{
		// Fields
		public RectTransform node; // 0x10

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Spin_b__0(float k); // 0x0000000180710200-0x00000001807103E0
	}

	// Constructors
	static ThanhTuuFx(); // 0x000000018070D8B0-0x000000018070DEF0

	// Methods
	public static bool On(string name); // 0x0000000180705B90-0x0000000180705CD0
	public static int Value(GameObject host, float from, float to, float dur, Action<float> onUpdate, Action onDone = null, LeanTweenType ease = LeanTweenType.linear /* Metadata: 0x005F0A09 */, float delay = 0f /* Metadata: 0x005F0A0A */); // 0x0000000180705CD0-0x0000000180705F50
	public static int Loop(GameObject host, float period, Action<float> onUpdate); // 0x0000000180705F50-0x0000000180706150
	public static int Delay(GameObject host, float sec, Action fn); // 0x0000000180706150-0x0000000180706300
	public static void Cancel(ref int id); // 0x0000000180706300-0x0000000180706420
	public static void FadeIn(CanvasGroup group, RectTransform box); // 0x0000000180706420-0x0000000180706B80
	public static int FadeOut(CanvasGroup group, float dur, Action onDone); // 0x0000000180706B80-0x0000000180706E80
	public static int Pop(RectTransform node, float from, float peak, float dur, Action onDone = null); // 0x0000000180706E80-0x00000001807071F0
	public static int PopIn(RectTransform node); // 0x00000001807071F0-0x0000000180707610
	public static int SlideX(RectTransform rt, float fromX, float toX, float dur, float delay); // 0x0000000180707610-0x0000000180707920
	public static int MoveY(RectTransform rt, float toY, float dur, Action onDone = null); // 0x0000000180707920-0x0000000180707C80
	public static int Width(RectTransform rt, float toW, float dur); // 0x0000000180707C80-0x0000000180707FD0
	public static int CountUp(UnityEngine.UI.Text t, long from, long to, Color baseColor, Action onDone = null); // 0x0000000180707FD0-0x0000000180708520
	public static int Fly(RectTransform icon, Vector2 from, Vector2 to, Action onDone); // 0x0000000180708520-0x00000001807089D0
	public static int StampSlam(RectTransform stamp, RectTransform tab, Action onDone = null); // 0x00000001807089D0-0x0000000180708ED0
	public static int Shake(RectTransform node, Action onDone = null); // 0x0000000180708ED0-0x0000000180709460
	public static int Pulse(RectTransform node, float amp, float halfPeriod); // 0x0000000180709460-0x0000000180709750
	public static int AlphaPulse(Graphic g, float lo, float hi, float halfPeriod); // 0x0000000180709750-0x00000001807099D0
	public static int Wobble(RectTransform node, float deg, float period); // 0x00000001807099D0-0x0000000180709CF0
	public static int Spin(RectTransform node, float period); // 0x0000000180709CF0-0x0000000180709F20
	public static int Burst(GameObject host, float duration, Action<float> pose, Action onDone); // 0x0000000180709F20-0x0000000180709FC0
	public static void CancelAll(); // 0x0000000180709FC0-0x000000018070ABD0
	public static void RegisterTemp(GameObject go); // 0x000000018070ABD0-0x000000018070AD20
	public static void Kill(GameObject go); // 0x000000018070AD20-0x000000018070AE90
	private static int Track(int id); // 0x000000018070AE90-0x000000018070AFD0
	private static void RememberScale(Transform t); // 0x000000018070AFD0-0x000000018070B3A0
	private static void RememberRotation(Transform t); // 0x000000018070B3A0-0x000000018070B770
	private static void RememberPos(RectTransform t); // 0x000000018070B770-0x000000018070BB20
	public static void SetAlpha(Graphic g, float a); // 0x000000018070BB20-0x000000018070BC70
	public static float EaseOutBack(float t); // 0x0000000180335460-0x00000001803354A0
	public static float EaseOutQuad(float t); // 0x000000018070BC70-0x000000018070BCA0
	public static float EaseOutCubic(float t); // 0x000000018070BCA0-0x000000018070BCE0
	public static Sprite White(); // 0x000000018070BCE0-0x000000018070BF30
	public static Sprite Ring(); // 0x000000018070BF30-0x000000018070C540
	public static Sprite Arrow(); // 0x000000018070C540-0x000000018070C990
	public static Sprite Frame(); // 0x000000018070C990-0x000000018070CC20
	public static Sprite StarField(); // 0x000000018070CC20-0x000000018070D600
	private static byte ToByte(float v); // 0x00000001806FF6D0-0x00000001806FF700
	private static Sprite MakeSprite(Color32[] px, int w, int h, string name, Vector4 border); // 0x000000018070D600-0x000000018070D8B0
}

