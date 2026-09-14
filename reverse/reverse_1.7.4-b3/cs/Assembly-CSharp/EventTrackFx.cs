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

public static class EventTrackFx // TypeDefIndex: 614
{
	// Fields
	private static readonly List<GameObject> _temp; // 0x00
	private static readonly List<int> _ids; // 0x08
	private static readonly List<Transform> _pulsed; // 0x10
	private static readonly List<Drop> _rain; // 0x18
	private static bool _rainOn; // 0x20
	private static Image _lightFlash; // 0x28
	private static RectTransform _lightShake; // 0x30
	private static System.Random _lightRnd; // 0x38
	private static Func<bool> _lightBusy; // 0x40
	private static GameObject _lightHost; // 0x48
	private static int _lightId; // 0x50
	private static int _shakeId; // 0x54

	// Properties
	public static bool Enabled { get; } // 0x0000000180435390-0x00000001804353E0 
	private static bool LowTier { get; } // 0x00000001804353E0-0x0000000180435440 

	// Nested types
	private class Drop // TypeDefIndex: 615
	{
		// Fields
		public Image img; // 0x10
		public int id; // 0x18
		public float areaW; // 0x1C
		public float areaH; // 0x20
		public Color tint; // 0x24
		public System.Random rnd; // 0x38

		// Constructors
		public Drop(); // 0x000000018043A9C0-0x000000018043A9D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 616
	{
		// Fields
		public Image img; // 0x10
		public RectTransform rt; // 0x18
		public float x0; // 0x20
		public float drift; // 0x24
		public float y0; // 0x28
		public float y1; // 0x2C
		public Drop d; // 0x30

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fall_b__0(float k); // 0x000000018043A9D0-0x000000018043AB20
		internal void _Fall_b__1(); // 0x000000018043AB20-0x000000018043AB80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 617
	{
		// Fields
		public Image f; // 0x10

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Strike_b__0(float k); // 0x000000018043AB80-0x000000018043AD20
		internal void _Strike_b__1(); // 0x000000018043AD20-0x000000018043AD80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_1 // TypeDefIndex: 618
	{
		// Fields
		public RectTransform sh; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass25_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Strike_b__2(float k); // 0x000000018043AD80-0x000000018043AED0
		internal void _Strike_b__3(); // 0x000000018043AED0-0x000000018043AFE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 619
	{
		// Fields
		public Image fill; // 0x10

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GaugeTo_b__0(float v); // 0x000000018043AFE0-0x000000018043B0F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 620
	{
		// Fields
		public Image flash; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__0(float a); // 0x000000018043B0F0-0x000000018043B270
		internal void _ClaimBurst_b__1(); // 0x000000018043B270-0x000000018043B3A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_1 // TypeDefIndex: 621
	{
		// Fields
		public Image g; // 0x10
		public RectTransform grt; // 0x18

		// Constructors
		public __c__DisplayClass31_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__2(float k); // 0x000000018043B3A0-0x000000018043B610
		internal void _ClaimBurst_b__3(); // 0x000000018043B610-0x000000018043B740
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_2 // TypeDefIndex: 622
	{
		// Fields
		public Image sp; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 dir; // 0x20

		// Constructors
		public __c__DisplayClass31_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__4(float k); // 0x000000018043B740-0x000000018043B9D0
		internal void _ClaimBurst_b__5(); // 0x000000018043B9D0-0x000000018043BB00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 623
	{
		// Fields
		public UnityEngine.UI.Text label; // 0x10
		public RectTransform lrt; // 0x18
		public Vector2 home; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BonusFloat_b__0(float k); // 0x000000018043BB00-0x000000018043BCC0
		internal void _BonusFloat_b__1(); // 0x000000018043BCC0-0x000000018043BDF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_1 // TypeDefIndex: 624
	{
		// Fields
		public Image sp; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 start; // 0x20

		// Constructors
		public __c__DisplayClass32_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BonusFloat_b__2(float k); // 0x000000018043BDF0-0x000000018043BFB0
		internal void _BonusFloat_b__3(); // 0x000000018043BFB0-0x000000018043C0E0
	}

	// Constructors
	static EventTrackFx(); // 0x000000018043A510-0x000000018043A9C0

	// Methods
	public static void RefreshFlag(); // 0x000000018028A320-0x000000018028A330
	private static bool Sub(string name); // 0x0000000180435440-0x0000000180435680
	public static void Rain(MonoBehaviour host, RectTransform area, Sprite streak, Color tint, int count = 24 /* Metadata: 0x005EE438 */, int seed = 0 /* Metadata: 0x005EE439 */); // 0x0000000180435680-0x0000000180435C50
	private static void Fall(Drop d, float delay); // 0x0000000180435C50-0x00000001804361B0
	public static void StopRain(); // 0x00000001804361B0-0x0000000180436430
	public static void Lightning(MonoBehaviour host, Image flash, RectTransform shake, int seed, Func<bool> busy = null); // 0x0000000180436430-0x0000000180436760
	private static void Schedule(); // 0x0000000180436760-0x0000000180436A40
	private static void Strike(); // 0x0000000180436A40-0x0000000180436FF0
	public static void StopLightning(); // 0x0000000180436FF0-0x0000000180437360
	private static void Rest(Image flash); // 0x0000000180437360-0x00000001804374B0
	public static void GaugeTo(Image fill, float target, float time = 0.4f /* Metadata: 0x005EE43A */); // 0x00000001804374B0-0x0000000180437820
	public static void PulseButton(RectTransform node, bool on); // 0x0000000180437820-0x0000000180437C10
	public static void StopPulse(RectTransform node); // 0x0000000180437C10-0x0000000180437EA0
	public static void ClaimBurst(RectTransform anchor, Sprite glow, Sprite drop, Color primary); // 0x0000000180437EA0-0x0000000180438E00
	public static void BonusFloat(RectTransform from, string text, Sprite drop, Color primary); // 0x0000000180438E00-0x00000001804398D0
	public static void CancelAll(); // 0x00000001804398D0-0x0000000180439E40
	private static Image Temp(Transform parent, string name, Vector2 pos, Vector2 size, Color color, Sprite sprite); // 0x0000000180439E40-0x000000018043A0C0
	private static void Track(int id); // 0x000000018043A0C0-0x000000018043A1E0
	private static void Kill(GameObject go); // 0x000000018043A1E0-0x000000018043A3B0
	private static void SafeDestroy(GameObject go); // 0x000000018043A3B0-0x000000018043A510
}

