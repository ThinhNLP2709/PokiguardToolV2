/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ComboBanner // TypeDefIndex: 1646
{
	// Fields
	private const string CANVAS_NAME = "CardAnimationCanvas"; // Metadata: 0x0064D7EF
	private const string NODE_NAME = "ComboBanner"; // Metadata: 0x0064D803
	private static readonly Vector2 ANCHORED_POS; // 0x00
	private static readonly Vector2 SIZE; // 0x08
	private const float POP_SEC = 0.22f; // Metadata: 0x0064D80F
	private const float HOLD_SEC = 0.35f; // Metadata: 0x0064D813
	private const float FADE_SEC = 0.2f; // Metadata: 0x0064D817
	private const int MIN_ROUND = 2; // Metadata: 0x0064D81B
	private static UnityEngine.UI.Text _text; // 0x10
	private static CanvasGroup _group; // 0x18
	private static float _shownAt; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1647
	{
		// Fields
		public float capturedAt; // 0x10

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Show_b__0(); // 0x00000001805D40B0-0x00000001805D4320
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1648
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FadeOut_b__0(); // 0x00000001805D4320-0x00000001805D43A0
	}

	// Constructors
	static ComboBanner(); // 0x00000001805C1750-0x00000001805C17D0

	// Methods
	public static void Show(int round); // 0x00000001805C1390-0x00000001805C1750
	public static void HideNow(); // 0x00000001805C1270-0x00000001805C1390
	private static void FadeOut(); // 0x00000001805C10A0-0x00000001805C1270
	private static UnityEngine.UI.Text EnsureNode(); // 0x00000001805C0B60-0x00000001805C10A0
	private static Canvas EnsureAnimationCanvas(); // 0x00000001805C07B0-0x00000001805C0B60
}

