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

public static class EventTrackFx // TypeDefIndex: 615
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
	public static bool Enabled { get; } // 0x0000000180436460-0x00000001804364B0 
	private static bool LowTier { get; } // 0x00000001804364B0-0x0000000180436510 

	// Nested types
	private class Drop // TypeDefIndex: 616
	{
		// Fields
		public Image img; // 0x10
		public int id; // 0x18
		public float areaW; // 0x1C
		public float areaH; // 0x20
		public Color tint; // 0x24
		public System.Random rnd; // 0x38

		// Constructors
		public Drop(); // 0x000000018043BA90-0x000000018043BAA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 617
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
		internal void _Fall_b__0(float k); // 0x000000018043BAA0-0x000000018043BBF0
		internal void _Fall_b__1(); // 0x000000018043BBF0-0x000000018043BC50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 618
	{
		// Fields
		public Image f; // 0x10

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Strike_b__0(float k); // 0x000000018043BC50-0x000000018043BDF0
		internal void _Strike_b__1(); // 0x000000018043BDF0-0x000000018043BE50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_1 // TypeDefIndex: 619
	{
		// Fields
		public RectTransform sh; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass25_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Strike_b__2(float k); // 0x000000018043BE50-0x000000018043BFA0
		internal void _Strike_b__3(); // 0x000000018043BFA0-0x000000018043C0B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 620
	{
		// Fields
		public Image fill; // 0x10

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GaugeTo_b__0(float v); // 0x000000018043C0B0-0x000000018043C1C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 621
	{
		// Fields
		public Image flash; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__0(float a); // 0x000000018043C1C0-0x000000018043C340
		internal void _ClaimBurst_b__1(); // 0x000000018043C340-0x000000018043C470
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_1 // TypeDefIndex: 622
	{
		// Fields
		public Image g; // 0x10
		public RectTransform grt; // 0x18

		// Constructors
		public __c__DisplayClass31_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__2(float k); // 0x000000018043C470-0x000000018043C6E0
		internal void _ClaimBurst_b__3(); // 0x000000018043C6E0-0x000000018043C810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_2 // TypeDefIndex: 623
	{
		// Fields
		public Image sp; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 dir; // 0x20

		// Constructors
		public __c__DisplayClass31_2(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__4(float k); // 0x000000018043C810-0x000000018043CAA0
		internal void _ClaimBurst_b__5(); // 0x000000018043CAA0-0x000000018043CBD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 624
	{
		// Fields
		public UnityEngine.UI.Text label; // 0x10
		public RectTransform lrt; // 0x18
		public Vector2 home; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BonusFloat_b__0(float k); // 0x000000018043CBD0-0x000000018043CD90
		internal void _BonusFloat_b__1(); // 0x000000018043CD90-0x000000018043CEC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_1 // TypeDefIndex: 625
	{
		// Fields
		public Image sp; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 start; // 0x20

		// Constructors
		public __c__DisplayClass32_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BonusFloat_b__2(float k); // 0x000000018043CEC0-0x000000018043D080
		internal void _BonusFloat_b__3(); // 0x000000018043D080-0x000000018043D1B0
	}

	// Constructors
	static EventTrackFx(); // 0x000000018043B5E0-0x000000018043BA90

	// Methods
	public static void RefreshFlag(); // 0x000000018028A320-0x000000018028A330
	private static bool Sub(string name); // 0x0000000180436510-0x0000000180436750
	public static void Rain(MonoBehaviour host, RectTransform area, Sprite streak, Color tint, int count = 24 /* Metadata: 0x005EF809 */, int seed = 0 /* Metadata: 0x005EF80A */); // 0x0000000180436750-0x0000000180436D20
	private static void Fall(Drop d, float delay); // 0x0000000180436D20-0x0000000180437280
	public static void StopRain(); // 0x0000000180437280-0x0000000180437500
	public static void Lightning(MonoBehaviour host, Image flash, RectTransform shake, int seed, Func<bool> busy = null); // 0x0000000180437500-0x0000000180437830
	private static void Schedule(); // 0x0000000180437830-0x0000000180437B10
	private static void Strike(); // 0x0000000180437B10-0x00000001804380C0
	public static void StopLightning(); // 0x00000001804380C0-0x0000000180438430
	private static void Rest(Image flash); // 0x0000000180438430-0x0000000180438580
	public static void GaugeTo(Image fill, float target, float time = 0.4f /* Metadata: 0x005EF80B */); // 0x0000000180438580-0x00000001804388F0
	public static void PulseButton(RectTransform node, bool on); // 0x00000001804388F0-0x0000000180438CE0
	public static void StopPulse(RectTransform node); // 0x0000000180438CE0-0x0000000180438F70
	public static void ClaimBurst(RectTransform anchor, Sprite glow, Sprite drop, Color primary); // 0x0000000180438F70-0x0000000180439ED0
	public static void BonusFloat(RectTransform from, string text, Sprite drop, Color primary); // 0x0000000180439ED0-0x000000018043A9A0
	public static void CancelAll(); // 0x000000018043A9A0-0x000000018043AF10
	private static Image Temp(Transform parent, string name, Vector2 pos, Vector2 size, Color color, Sprite sprite); // 0x000000018043AF10-0x000000018043B190
	private static void Track(int id); // 0x000000018043B190-0x000000018043B2B0
	private static void Kill(GameObject go); // 0x000000018043B2B0-0x000000018043B480
	private static void SafeDestroy(GameObject go); // 0x000000018043B480-0x000000018043B5E0
}

