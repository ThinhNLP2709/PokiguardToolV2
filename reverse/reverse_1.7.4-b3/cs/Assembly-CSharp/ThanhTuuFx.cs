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

public static class ThanhTuuFx // TypeDefIndex: 1251
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
	public static bool Live { get; } // 0x0000000180703D10-0x0000000180703D90 
	public static bool Enabled { get; } // 0x0000000180703D90-0x0000000180703DE0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1252
	{
		// Fields
		public CanvasGroup group; // 0x10
		public RectTransform box; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeIn_b__0(float a); // 0x000000018070C140-0x000000018070C290
		internal void _FadeIn_b__1(float s); // 0x000000018070C290-0x000000018070C400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 1253
	{
		// Fields
		public CanvasGroup group; // 0x10

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeOut_b__0(float a); // 0x000000018070C400-0x000000018070C550
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1254
	{
		// Fields
		public RectTransform node; // 0x10
		public float from; // 0x18
		public float peak; // 0x1C
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Pop_b__0(float k); // 0x000000018070C550-0x000000018070C7B0
		internal void _Pop_b__1(); // 0x000000018070C7B0-0x000000018070C930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 1255
	{
		// Fields
		public RectTransform node; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopIn_b__0(float s); // 0x000000018070C930-0x000000018070CAA0
		internal void _PopIn_b__1(); // 0x000000018070CAA0-0x000000018070CC10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass51_0 // TypeDefIndex: 1256
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SlideX_b__0(float x); // 0x000000018070CC10-0x000000018070CD40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 1257
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MoveY_b__0(float y); // 0x000000018070CD40-0x000000018070CE70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass53_0 // TypeDefIndex: 1258
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass53_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Width_b__0(float w); // 0x000000018070CE70-0x000000018070CFA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 1259
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
		internal void _CountUp_b__0(float k); // 0x000000018070CFA0-0x000000018070D3F0
		internal void _CountUp_b__1(); // 0x000000018070D3F0-0x000000018070D650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 1260
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
		internal void _Fly_b__0(float k); // 0x000000018070D650-0x000000018070D860
		internal void _Fly_b__1(); // 0x000000018070D860-0x000000018070D980
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 1261
	{
		// Fields
		public RectTransform stamp; // 0x10
		public RectTransform tab; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass56_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StampSlam_b__0(float k); // 0x000000018070D980-0x000000018070DB00
		internal void _StampSlam_b__1(); // 0x000000018070DB00-0x000000018070DCB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 1262
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x000000018070DCB0-0x000000018070DE00
		internal void _Shake_b__1(); // 0x000000018070DE00-0x000000018070DF20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass58_0 // TypeDefIndex: 1263
	{
		// Fields
		public RectTransform node; // 0x10
		public float amp; // 0x18

		// Constructors
		public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Pulse_b__0(float k); // 0x000000018070DF20-0x000000018070E0C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 1264
	{
		// Fields
		public Graphic g; // 0x10
		public float hi; // 0x18
		public float lo; // 0x1C

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AlphaPulse_b__0(float k); // 0x000000018070E0C0-0x000000018070E240
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass60_0 // TypeDefIndex: 1265
	{
		// Fields
		public RectTransform node; // 0x10
		public float span; // 0x18
		public float deg; // 0x1C

		// Constructors
		public __c__DisplayClass60_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Wobble_b__0(float k); // 0x000000018070E240-0x000000018070E450
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1266
	{
		// Fields
		public RectTransform node; // 0x10

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Spin_b__0(float k); // 0x000000018070E450-0x000000018070E630
	}

	// Constructors
	static ThanhTuuFx(); // 0x000000018070BB00-0x000000018070C140

	// Methods
	public static bool On(string name); // 0x0000000180703DE0-0x0000000180703F20
	public static int Value(GameObject host, float from, float to, float dur, Action<float> onUpdate, Action onDone = null, LeanTweenType ease = LeanTweenType.linear /* Metadata: 0x005EF63C */, float delay = 0f /* Metadata: 0x005EF63D */); // 0x0000000180703F20-0x00000001807041A0
	public static int Loop(GameObject host, float period, Action<float> onUpdate); // 0x00000001807041A0-0x00000001807043A0
	public static int Delay(GameObject host, float sec, Action fn); // 0x00000001807043A0-0x0000000180704550
	public static void Cancel(ref int id); // 0x0000000180704550-0x0000000180704670
	public static void FadeIn(CanvasGroup group, RectTransform box); // 0x0000000180704670-0x0000000180704DD0
	public static int FadeOut(CanvasGroup group, float dur, Action onDone); // 0x0000000180704DD0-0x00000001807050D0
	public static int Pop(RectTransform node, float from, float peak, float dur, Action onDone = null); // 0x00000001807050D0-0x0000000180705440
	public static int PopIn(RectTransform node); // 0x0000000180705440-0x0000000180705860
	public static int SlideX(RectTransform rt, float fromX, float toX, float dur, float delay); // 0x0000000180705860-0x0000000180705B70
	public static int MoveY(RectTransform rt, float toY, float dur, Action onDone = null); // 0x0000000180705B70-0x0000000180705ED0
	public static int Width(RectTransform rt, float toW, float dur); // 0x0000000180705ED0-0x0000000180706220
	public static int CountUp(UnityEngine.UI.Text t, long from, long to, Color baseColor, Action onDone = null); // 0x0000000180706220-0x0000000180706770
	public static int Fly(RectTransform icon, Vector2 from, Vector2 to, Action onDone); // 0x0000000180706770-0x0000000180706C20
	public static int StampSlam(RectTransform stamp, RectTransform tab, Action onDone = null); // 0x0000000180706C20-0x0000000180707120
	public static int Shake(RectTransform node, Action onDone = null); // 0x0000000180707120-0x00000001807076B0
	public static int Pulse(RectTransform node, float amp, float halfPeriod); // 0x00000001807076B0-0x00000001807079A0
	public static int AlphaPulse(Graphic g, float lo, float hi, float halfPeriod); // 0x00000001807079A0-0x0000000180707C20
	public static int Wobble(RectTransform node, float deg, float period); // 0x0000000180707C20-0x0000000180707F40
	public static int Spin(RectTransform node, float period); // 0x0000000180707F40-0x0000000180708170
	public static int Burst(GameObject host, float duration, Action<float> pose, Action onDone); // 0x0000000180708170-0x0000000180708210
	public static void CancelAll(); // 0x0000000180708210-0x0000000180708E20
	public static void RegisterTemp(GameObject go); // 0x0000000180708E20-0x0000000180708F70
	public static void Kill(GameObject go); // 0x0000000180708F70-0x00000001807090E0
	private static int Track(int id); // 0x00000001807090E0-0x0000000180709220
	private static void RememberScale(Transform t); // 0x0000000180709220-0x00000001807095F0
	private static void RememberRotation(Transform t); // 0x00000001807095F0-0x00000001807099C0
	private static void RememberPos(RectTransform t); // 0x00000001807099C0-0x0000000180709D70
	public static void SetAlpha(Graphic g, float a); // 0x0000000180709D70-0x0000000180709EC0
	public static float EaseOutBack(float t); // 0x0000000180335340-0x0000000180335380
	public static float EaseOutQuad(float t); // 0x0000000180709EC0-0x0000000180709EF0
	public static float EaseOutCubic(float t); // 0x0000000180709EF0-0x0000000180709F30
	public static Sprite White(); // 0x0000000180709F30-0x000000018070A180
	public static Sprite Ring(); // 0x000000018070A180-0x000000018070A790
	public static Sprite Arrow(); // 0x000000018070A790-0x000000018070ABE0
	public static Sprite Frame(); // 0x000000018070ABE0-0x000000018070AE70
	public static Sprite StarField(); // 0x000000018070AE70-0x000000018070B850
	private static byte ToByte(float v); // 0x00000001806FD920-0x00000001806FD950
	private static Sprite MakeSprite(Color32[] px, int w, int h, string name, Vector4 border); // 0x000000018070B850-0x000000018070BB00
}

