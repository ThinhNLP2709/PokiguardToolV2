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

public static class LoginFx // TypeDefIndex: 1053
{
	// Fields
	private static int _flag; // 0x00
	private static readonly List<KeyValuePair<Transform, Vector3>> _scaled; // 0x08
	private static readonly List<KeyValuePair<RectTransform, Vector2>> _moved; // 0x10
	private static readonly List<KeyValuePair<CanvasGroup, float>> _faded; // 0x18
	private static readonly List<GameObject> _temp; // 0x20
	private static readonly List<KeyValuePair<RectTransform, Vector4>> _rims; // 0x28
	private static readonly List<Image> _stars; // 0x30
	private static Transform _starHost; // 0x38

	// Properties
	public static bool Enabled { get; } // 0x0000000180652C50-0x0000000180652DD0 
	private static float FadeTime { get; } // 0x0000000180652E30-0x0000000180652EB0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1054
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Glow_b__0(float k); // 0x000000018065BA70-0x000000018065BC10
		internal void _Glow_b__1(); // 0x000000018065BC10-0x000000018065BDD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1055
	{
		// Fields
		public RectTransform hero; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HeroFloat_b__0(float dy); // 0x000000018065BDD0-0x000000018065BEF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 1056
	{
		// Fields
		public CanvasGroup from; // 0x10
		public RectTransform fromRt; // 0x18
		public CanvasGroup to; // 0x20
		public RectTransform toRt; // 0x28

		// Constructors
		public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_1 // TypeDefIndex: 1057
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass21_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass21_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchTab_b__0(float a); // 0x000000018065BEF0-0x000000018065C150
		internal void _SwitchTab_b__1(); // 0x000000018065C150-0x000000018065C390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_2 // TypeDefIndex: 1058
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass21_0 CS___8__locals2; // 0x18

		// Constructors
		public __c__DisplayClass21_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchTab_b__2(float a); // 0x000000018065C390-0x000000018065C5F0
		internal void _SwitchTab_b__3(); // 0x000000018065C5F0-0x000000018065C830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1059
	{
		// Fields
		public Image rim; // 0x10
		public Color start; // 0x18
		public Color target; // 0x28

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Focus_b__0(float k); // 0x000000018065C830-0x000000018065C9F0
		internal void _Focus_b__1(); // 0x000000018065C9F0-0x000000018065CB00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1060
	{
		// Fields
		public Graphic errorText; // 0x10
		public Color from; // 0x18
		public Color to; // 0x28

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Error_b__0(float k); // 0x000000018065CB00-0x000000018065CCC0
		internal void _Error_b__1(); // 0x000000018065CCC0-0x000000018065CDD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_1 // TypeDefIndex: 1061
	{
		// Fields
		public Image captured; // 0x10
		public Color hot; // 0x18
		public Color cold; // 0x28

		// Constructors
		public __c__DisplayClass23_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Error_b__2(float k); // 0x000000018065CDD0-0x000000018065CF90
		internal void _Error_b__3(); // 0x000000018065CF90-0x000000018065D0E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1062
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x000000018065D0E0-0x000000018065D220
		internal void _Shake_b__1(); // 0x000000018065D220-0x000000018065D330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 1063
	{
		// Fields
		public Graphic flash; // 0x10
		public RectTransform hero; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__2(float k); // 0x000000018065D330-0x000000018065D4D0
		internal void _LoginSuccess_b__3(); // 0x000000018065D4D0-0x000000018065D650
		internal void _LoginSuccess_b__0(); // 0x0000000180337800-0x0000000180337820
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_1 // TypeDefIndex: 1064
	{
		// Fields
		public RectTransform brt; // 0x10

		// Constructors
		public __c__DisplayClass27_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__1(); // 0x000000018065D650-0x000000018065D7E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_2 // TypeDefIndex: 1065
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass27_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass27_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__4(float dy); // 0x000000018065D7E0-0x000000018065D910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 1066
	{
		// Fields
		public Vector2 center; // 0x10

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_1 // TypeDefIndex: 1067
	{
		// Fields
		public Image sp; // 0x10
		public RectTransform rt; // 0x18
		public Vector2 dir; // 0x20
		public float spin; // 0x28
		public __c__DisplayClass28_0 CS___8__locals1; // 0x30

		// Constructors
		public __c__DisplayClass28_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterBurst_b__0(float k); // 0x000000018065D910-0x000000018065DBD0
		internal void _RegisterBurst_b__1(); // 0x000000018065DBD0-0x000000018065DD20
	}

	// Constructors
	static LoginFx(); // 0x000000018065B2D0-0x000000018065BA70

	// Methods
	public static void RefreshFlag(); // 0x0000000180652DD0-0x0000000180652E30
	public static void Enter(CanvasGroup formGroup, RectTransform content, Image logo, RectTransform hero); // 0x0000000180652EB0-0x0000000180653990
	private static void Glow(Image logo); // 0x0000000180653990-0x00000001806543A0
	public static void HeroFloat(RectTransform hero); // 0x00000001806543A0-0x0000000180654690
	public static void SwitchTab(CanvasGroup from, RectTransform fromRt, CanvasGroup to, RectTransform toRt); // 0x0000000180654690-0x0000000180655560
	public static void Focus(Image rim, RectTransform chip, bool on); // 0x0000000180655560-0x0000000180655C40
	public static void Error(RectTransform card, Graphic errorText, Image rim); // 0x0000000180655C40-0x0000000180656350
	public static void ShowRimError(Image rim); // 0x0000000180656350-0x0000000180656500
	public static void RimWide(Image rim, bool wide); // 0x0000000180656500-0x0000000180656A90
	public static void Shake(RectTransform node); // 0x0000000180656A90-0x0000000180656DC0
	public static void LoginSuccess(Graphic loginButton, Graphic flash, RectTransform content, CanvasGroup formGroup, RectTransform hero, Action onDone); // 0x0000000180656DC0-0x0000000180657B40
	public static void RegisterBurst(RectTransform anchor, RectTransform parent); // 0x0000000180657B40-0x0000000180658610
	private static void EnsurePool(RectTransform parent, Sprite star); // 0x0000000180658610-0x00000001806593C0
	private static void ClearPool(); // 0x00000001806593C0-0x00000001806596E0
	public static void CancelAll(); // 0x00000001806596E0-0x000000018065A320
	private static void Kill(GameObject go); // 0x000000018065A320-0x000000018065A4B0
	private static void Track(Transform t); // 0x000000018065A4B0-0x000000018065A890
	private static void TrackMove(RectTransform rt); // 0x000000018065A890-0x000000018065ABF0
	private static void TrackFade(CanvasGroup g); // 0x000000018065ABF0-0x000000018065AFB0
	private static Vector2 Home(RectTransform rt); // 0x000000018065AFB0-0x000000018065B2D0
}

