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

public static class SettingsFx // TypeDefIndex: 1216
{
	// Fields
	private static int _flag; // 0x00
	private static readonly List<KeyValuePair<Transform, Vector3>> _scaled; // 0x08
	private static readonly List<KeyValuePair<RectTransform, Vector2>> _moved; // 0x10
	private static readonly List<GameObject> _temp; // 0x18

	// Properties
	public static bool Enabled { get; } // 0x00000001806D9C80-0x00000001806D9DC0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1217
	{
		// Fields
		public RectTransform knob; // 0x10
		public float y; // 0x18
		public Image bg; // 0x20
		public Color targetColor; // 0x28

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ToggleKnob_b__0(float x); // 0x00000001806DDC30-0x00000001806DDD40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass11_1 // TypeDefIndex: 1218
	{
		// Fields
		public Color from; // 0x10
		public __c__DisplayClass11_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass11_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ToggleKnob_b__1(float k); // 0x00000001806DDD40-0x00000001806DDF20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1219
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x00000001806DDF20-0x00000001806DE060
		internal void _Shake_b__1(); // 0x00000001806DE060-0x00000001806DE170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1220
	{
		// Fields
		public RectTransform host; // 0x10
		public Image sweep; // 0x18
		public RectTransform srt; // 0x20
		public float w; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _NameChanged_b__0(); // 0x00000001806DE170-0x00000001806DE300
		internal void _NameChanged_b__1(float k); // 0x00000001806DE300-0x00000001806DE510
		internal void _NameChanged_b__2(); // 0x00000001806DE510-0x00000001806DE640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_1 // TypeDefIndex: 1221
	{
		// Fields
		public Image spark; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 dir; // 0x20

		// Constructors
		public __c__DisplayClass13_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _NameChanged_b__3(float k); // 0x00000001806DE640-0x00000001806DE8D0
		internal void _NameChanged_b__4(); // 0x00000001806DE8D0-0x00000001806DEA00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1222
	{
		// Fields
		public RectTransform box; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass9_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopOut_b__0(); // 0x00000001806DEA00-0x00000001806DEB80
	}

	// Constructors
	static SettingsFx(); // 0x00000001806DD890-0x00000001806DDC30

	// Methods
	public static void RefreshFlag(); // 0x00000001806D9DC0-0x00000001806D9E20
	public static void FadeIn(CanvasGroup group); // 0x00000001806D9E20-0x00000001806DA0E0
	public static void PopIn(RectTransform box); // 0x00000001806DA0E0-0x00000001806DA440
	public static void PopOut(RectTransform box, Action onDone); // 0x00000001806DA440-0x00000001806DA790
	public static void HandlePress(Transform handle, bool down); // 0x00000001806DA790-0x00000001806DA9B0
	public static void ToggleKnob(RectTransform knob, Image bg, float targetX, Color targetColor); // 0x00000001806DA9B0-0x00000001806DAFF0
	public static void Shake(RectTransform node); // 0x00000001806DAFF0-0x00000001806DB6B0
	public static void NameChanged(UnityEngine.UI.Text nameText); // 0x00000001806DB6B0-0x00000001806DC820
	public static void CancelAll(); // 0x00000001806DC820-0x00000001806DCFC0
	private static void Kill(GameObject go); // 0x00000001806DCFC0-0x00000001806DD150
	private static void Track(Transform t); // 0x00000001806DD150-0x00000001806DD530
	private static void TrackMove(RectTransform rt); // 0x00000001806DD530-0x00000001806DD890
}

