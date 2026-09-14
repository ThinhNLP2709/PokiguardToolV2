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

public static class LoginFx // TypeDefIndex: 1055
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
	public static bool Enabled { get; } // 0x0000000180654640-0x00000001806547C0 
	private static float FadeTime { get; } // 0x0000000180654820-0x00000001806548A0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1056
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Glow_b__0(float k); // 0x000000018065D460-0x000000018065D600
		internal void _Glow_b__1(); // 0x000000018065D600-0x000000018065D7C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1057
	{
		// Fields
		public RectTransform hero; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HeroFloat_b__0(float dy); // 0x000000018065D7C0-0x000000018065D8E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 1058
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
	private sealed class __c__DisplayClass21_1 // TypeDefIndex: 1059
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass21_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass21_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchTab_b__0(float a); // 0x000000018065D8E0-0x000000018065DB40
		internal void _SwitchTab_b__1(); // 0x000000018065DB40-0x000000018065DD80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_2 // TypeDefIndex: 1060
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass21_0 CS___8__locals2; // 0x18

		// Constructors
		public __c__DisplayClass21_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchTab_b__2(float a); // 0x000000018065DD80-0x000000018065DFE0
		internal void _SwitchTab_b__3(); // 0x000000018065DFE0-0x000000018065E220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1061
	{
		// Fields
		public Image rim; // 0x10
		public Color start; // 0x18
		public Color target; // 0x28

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Focus_b__0(float k); // 0x000000018065E220-0x000000018065E3E0
		internal void _Focus_b__1(); // 0x000000018065E3E0-0x000000018065E4F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1062
	{
		// Fields
		public Graphic errorText; // 0x10
		public Color from; // 0x18
		public Color to; // 0x28

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Error_b__0(float k); // 0x000000018065E4F0-0x000000018065E6B0
		internal void _Error_b__1(); // 0x000000018065E6B0-0x000000018065E7C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_1 // TypeDefIndex: 1063
	{
		// Fields
		public Image captured; // 0x10
		public Color hot; // 0x18
		public Color cold; // 0x28

		// Constructors
		public __c__DisplayClass23_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Error_b__2(float k); // 0x000000018065E7C0-0x000000018065E980
		internal void _Error_b__3(); // 0x000000018065E980-0x000000018065EAD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1064
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x000000018065EAD0-0x000000018065EC10
		internal void _Shake_b__1(); // 0x000000018065EC10-0x000000018065ED20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 1065
	{
		// Fields
		public Graphic flash; // 0x10
		public RectTransform hero; // 0x18
		public Action onDone; // 0x20

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__2(float k); // 0x000000018065ED20-0x000000018065EEC0
		internal void _LoginSuccess_b__3(); // 0x000000018065EEC0-0x000000018065F040
		internal void _LoginSuccess_b__0(); // 0x0000000180337920-0x0000000180337940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_1 // TypeDefIndex: 1066
	{
		// Fields
		public RectTransform brt; // 0x10

		// Constructors
		public __c__DisplayClass27_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__1(); // 0x000000018065F040-0x000000018065F1D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_2 // TypeDefIndex: 1067
	{
		// Fields
		public Vector2 home; // 0x10
		public __c__DisplayClass27_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass27_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoginSuccess_b__4(float dy); // 0x000000018065F1D0-0x000000018065F300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 1068
	{
		// Fields
		public Vector2 center; // 0x10

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_1 // TypeDefIndex: 1069
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
		internal void _RegisterBurst_b__0(float k); // 0x000000018065F300-0x000000018065F5C0
		internal void _RegisterBurst_b__1(); // 0x000000018065F5C0-0x000000018065F710
	}

	// Constructors
	static LoginFx(); // 0x000000018065CCC0-0x000000018065D460

	// Methods
	public static void RefreshFlag(); // 0x00000001806547C0-0x0000000180654820
	public static void Enter(CanvasGroup formGroup, RectTransform content, Image logo, RectTransform hero); // 0x00000001806548A0-0x0000000180655380
	private static void Glow(Image logo); // 0x0000000180655380-0x0000000180655D90
	public static void HeroFloat(RectTransform hero); // 0x0000000180655D90-0x0000000180656080
	public static void SwitchTab(CanvasGroup from, RectTransform fromRt, CanvasGroup to, RectTransform toRt); // 0x0000000180656080-0x0000000180656F50
	public static void Focus(Image rim, RectTransform chip, bool on); // 0x0000000180656F50-0x0000000180657630
	public static void Error(RectTransform card, Graphic errorText, Image rim); // 0x0000000180657630-0x0000000180657D40
	public static void ShowRimError(Image rim); // 0x0000000180657D40-0x0000000180657EF0
	public static void RimWide(Image rim, bool wide); // 0x0000000180657EF0-0x0000000180658480
	public static void Shake(RectTransform node); // 0x0000000180658480-0x00000001806587B0
	public static void LoginSuccess(Graphic loginButton, Graphic flash, RectTransform content, CanvasGroup formGroup, RectTransform hero, Action onDone); // 0x00000001806587B0-0x0000000180659530
	public static void RegisterBurst(RectTransform anchor, RectTransform parent); // 0x0000000180659530-0x000000018065A000
	private static void EnsurePool(RectTransform parent, Sprite star); // 0x000000018065A000-0x000000018065ADB0
	private static void ClearPool(); // 0x000000018065ADB0-0x000000018065B0D0
	public static void CancelAll(); // 0x000000018065B0D0-0x000000018065BD10
	private static void Kill(GameObject go); // 0x000000018065BD10-0x000000018065BEA0
	private static void Track(Transform t); // 0x000000018065BEA0-0x000000018065C280
	private static void TrackMove(RectTransform rt); // 0x000000018065C280-0x000000018065C5E0
	private static void TrackFade(CanvasGroup g); // 0x000000018065C5E0-0x000000018065C9A0
	private static Vector2 Home(RectTransform rt); // 0x000000018065C9A0-0x000000018065CCC0
}

