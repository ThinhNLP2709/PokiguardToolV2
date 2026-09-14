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

public static class SettingsFx // TypeDefIndex: 1218
{
	// Fields
	private static int _flag; // 0x00
	private static readonly List<KeyValuePair<Transform, Vector3>> _scaled; // 0x08
	private static readonly List<KeyValuePair<RectTransform, Vector2>> _moved; // 0x10
	private static readonly List<GameObject> _temp; // 0x18

	// Properties
	public static bool Enabled { get; } // 0x00000001806DB8F0-0x00000001806DBA30 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1219
	{
		// Fields
		public RectTransform knob; // 0x10
		public float y; // 0x18
		public Image bg; // 0x20
		public Color targetColor; // 0x28

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ToggleKnob_b__0(float x); // 0x00000001806DF8A0-0x00000001806DF9B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass11_1 // TypeDefIndex: 1220
	{
		// Fields
		public Color from; // 0x10
		public __c__DisplayClass11_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass11_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ToggleKnob_b__1(float k); // 0x00000001806DF9B0-0x00000001806DFB90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1221
	{
		// Fields
		public RectTransform node; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float k); // 0x00000001806DFB90-0x00000001806DFCD0
		internal void _Shake_b__1(); // 0x00000001806DFCD0-0x00000001806DFDE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1222
	{
		// Fields
		public RectTransform host; // 0x10
		public Image sweep; // 0x18
		public RectTransform srt; // 0x20
		public float w; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _NameChanged_b__0(); // 0x00000001806DFDE0-0x00000001806DFF70
		internal void _NameChanged_b__1(float k); // 0x00000001806DFF70-0x00000001806E0180
		internal void _NameChanged_b__2(); // 0x00000001806E0180-0x00000001806E02B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_1 // TypeDefIndex: 1223
	{
		// Fields
		public Image spark; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 dir; // 0x20

		// Constructors
		public __c__DisplayClass13_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _NameChanged_b__3(float k); // 0x00000001806E02B0-0x00000001806E0540
		internal void _NameChanged_b__4(); // 0x00000001806E0540-0x00000001806E0670
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1224
	{
		// Fields
		public RectTransform box; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass9_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopOut_b__0(); // 0x00000001806E0670-0x00000001806E07F0
	}

	// Constructors
	static SettingsFx(); // 0x00000001806DF500-0x00000001806DF8A0

	// Methods
	public static void RefreshFlag(); // 0x00000001806DBA30-0x00000001806DBA90
	public static void FadeIn(CanvasGroup group); // 0x00000001806DBA90-0x00000001806DBD50
	public static void PopIn(RectTransform box); // 0x00000001806DBD50-0x00000001806DC0B0
	public static void PopOut(RectTransform box, Action onDone); // 0x00000001806DC0B0-0x00000001806DC400
	public static void HandlePress(Transform handle, bool down); // 0x00000001806DC400-0x00000001806DC620
	public static void ToggleKnob(RectTransform knob, Image bg, float targetX, Color targetColor); // 0x00000001806DC620-0x00000001806DCC60
	public static void Shake(RectTransform node); // 0x00000001806DCC60-0x00000001806DD320
	public static void NameChanged(UnityEngine.UI.Text nameText); // 0x00000001806DD320-0x00000001806DE490
	public static void CancelAll(); // 0x00000001806DE490-0x00000001806DEC30
	private static void Kill(GameObject go); // 0x00000001806DEC30-0x00000001806DEDC0
	private static void Track(Transform t); // 0x00000001806DEDC0-0x00000001806DF1A0
	private static void TrackMove(RectTransform rt); // 0x00000001806DF1A0-0x00000001806DF500
}

