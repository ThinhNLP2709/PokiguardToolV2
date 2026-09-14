/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class SettingsUi // TypeDefIndex: 1230
{
	// Fields
	public static readonly Color Cyan; // 0x00
	public static readonly Color Gold; // 0x10
	public static readonly Color Dim; // 0x20
	public static readonly Color Green; // 0x30
	public static readonly Color Red; // 0x40
	public static readonly Color Divide; // 0x50
	public static readonly Color SCREEN_DIM; // 0x60
	public static readonly Color DIALOG_DIM; // 0x70
	public static readonly Color NAVY_TEXT; // 0x80
	public static readonly Color TITLE_OUTLINE; // 0x90
	public static readonly Color BG_TINT; // 0xA0

	// Nested types
	public struct PillUi // TypeDefIndex: 1231
	{
		// Fields
		public Image bg; // 0x00
		public RectTransform knob; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1232
	{
		// Fields
		public UnityAction onTap; // 0x10

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MakeButton_b__0(); // 0x00000001806F1420-0x00000001806F14A0
	}

	// Constructors
	static SettingsUi(); // 0x00000001806F1260-0x00000001806F1420

	// Methods
	public static RectTransform TL(Transform parent, string name, float x, float y, float w, float h); // 0x00000001806EC550-0x00000001806ECA70
	public static RectTransform Center(Transform parent, string name, float w, float h); // 0x00000001806ECA70-0x00000001806ECF20
	public static Image NewImage(Transform parent, string name, Color color); // 0x00000001806ECF20-0x00000001806ED3A0
	public static Image NewImage(Transform parent, string name, Vector2 pos, Vector2 size, Color color); // 0x00000001806ED3A0-0x00000001806ED4D0
	public static void Stretch(RectTransform rt); // 0x00000001806ED4D0-0x00000001806ED660
	public static void Stretch(RectTransform rt, float pad); // 0x00000001806ED660-0x00000001806ED800
	public static int FontSize(float raw); // 0x00000001806ED800-0x00000001806ED8E0
	public static UnityEngine.UI.Text Text(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005EF635 */); // 0x00000001806ED8E0-0x00000001806EDA10
	public static UnityEngine.UI.Text Title(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleCenter /* Metadata: 0x005EF636 */); // 0x00000001806EDA10-0x00000001806EDB50
	public static UnityEngine.UI.Text TextOnWhite(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005EF637 */); // 0x00000001806EDB50-0x00000001806EDC80
	private static UnityEngine.UI.Text Fill(GameObject go, string value, float fontSize, Color color, TextAnchor align, bool outline, Color outlineColor); // 0x00000001806EDC80-0x00000001806EDFE0
	public static UnityEngine.UI.Text Fit(UnityEngine.UI.Text t, float minSize); // 0x00000001806EDFE0-0x00000001806EE270
	public static void SetText(UnityEngine.UI.Text label, string value); // 0x00000001806EE270-0x00000001806EE380
	public static string Ellipsis(string s, int max); // 0x00000001806EE380-0x00000001806EE5A0
	public static Image Icon(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite); // 0x00000001806EE5A0-0x00000001806EE740
	public static Image Sliced(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite, Color waiting, Color ready); // 0x00000001806EE740-0x00000001806EE8E0
	public static Image Chip(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h); // 0x00000001806EE8E0-0x00000001806EE9F0
	public static Image Shell(MonoBehaviour host, RectTransform box); // 0x00000001806EE9F0-0x00000001806EEA60
	public static void Divider(Transform parent, float x, float y, float w, Color color); // 0x00000001806EEA60-0x00000001806EEB20
	public static Button MakeButton(GameObject host, UnityAction onTap); // 0x00000001806EEB20-0x00000001806EEE60
	public static Button Button(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float fontSize, Color tint, UnityAction onTap, out UnityEngine.UI.Text labelText); // 0x00000001806EEE60-0x00000001806EF250
	public static Button Button(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float fontSize, Color tint, UnityAction onTap); // 0x00000001806EF250-0x00000001806EF370
	public static Button IconButton(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite, UnityAction onTap); // 0x00000001806EF370-0x00000001806EF560
	public static UnityEngine.UI.Text LabelOf(Button btn); // 0x00000001806EF560-0x00000001806EF780
	public static void SetEnabled(Button btn, bool on); // 0x00000001806EF780-0x00000001806EF9D0
	public static void SetAlpha(Graphic g, float alpha); // 0x00000001806EF9D0-0x00000001806EFB20
	public static Slider Slider(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, float value); // 0x00000001806EFB20-0x00000001806F0770
	public static PillUi Pill(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, Color tint, UnityAction onTap); // 0x00000001806F0770-0x00000001806F0BE0
	public static float KnobX(bool on, float w = 100f /* Metadata: 0x005EF638 */); // 0x00000001806F0BE0-0x00000001806F0C10
	public static void Bind(Component node, string key); // 0x00000001806F0C10-0x00000001806F0E50
	public static string Num(long v); // 0x00000001806F0E50-0x00000001806F0F40
	public static string Duration(int seconds); // 0x00000001806F0F40-0x00000001806F1260
}

