/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ComboBanner // TypeDefIndex: 1917
{
	// Fields
	private const string CANVAS_NAME = "CardAnimationCanvas"; // Metadata: 0x0068DBEC
	private const string NODE_NAME = "ComboBanner"; // Metadata: 0x0068DC00
	private static readonly Vector2 ANCHORED_POS; // 0x00
	private static readonly Vector2 SIZE; // 0x08
	private const float POP_SEC = 0.22f; // Metadata: 0x0068DC0C
	private const float HOLD_SEC = 0.35f; // Metadata: 0x0068DC10
	private const float FADE_SEC = 0.2f; // Metadata: 0x0068DC14
	private const int MIN_ROUND = 2; // Metadata: 0x0068DC18
	private static UnityEngine.UI.Text _text; // 0x10
	private static CanvasGroup _group; // 0x18
	private static float _shownAt; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1918
	{
		// Fields
		public float capturedAt; // 0x10

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Show_b__0(); // 0x00000001806FA080-0x00000001806FA2F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1919
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FadeOut_b__0(); // 0x00000001806FA2F0-0x00000001806FA370
	}

	// Constructors
	static ComboBanner(); // 0x00000001806E8980-0x00000001806E8A00

	// Methods
	public static void Show(int round); // 0x00000001806E84C0-0x00000001806E8980
	public static void HideNow(); // 0x00000001806E83A0-0x00000001806E84C0
	private static void FadeOut(); // 0x00000001806E81D0-0x00000001806E83A0
	private static UnityEngine.UI.Text EnsureNode(); // 0x00000001806E7C90-0x00000001806E81D0
	private static Canvas EnsureAnimationCanvas(); // 0x00000001806E78E0-0x00000001806E7C90
}

