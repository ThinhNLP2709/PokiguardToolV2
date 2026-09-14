/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class SettingsUi // TypeDefIndex: 1232
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
	public struct PillUi // TypeDefIndex: 1233
	{
		// Fields
		public Image bg; // 0x00
		public RectTransform knob; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1234
	{
		// Fields
		public UnityAction onTap; // 0x10

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MakeButton_b__0(); // 0x00000001806F3150-0x00000001806F31D0
	}

	// Constructors
	static SettingsUi(); // 0x00000001806F2F90-0x00000001806F3150

	// Methods
	public static RectTransform TL(Transform parent, string name, float x, float y, float w, float h); // 0x00000001806EE280-0x00000001806EE7A0
	public static RectTransform Center(Transform parent, string name, float w, float h); // 0x00000001806EE7A0-0x00000001806EEC50
	public static Image NewImage(Transform parent, string name, Color color); // 0x00000001806EEC50-0x00000001806EF0D0
	public static Image NewImage(Transform parent, string name, Vector2 pos, Vector2 size, Color color); // 0x00000001806EF0D0-0x00000001806EF200
	public static void Stretch(RectTransform rt); // 0x00000001806EF200-0x00000001806EF390
	public static void Stretch(RectTransform rt, float pad); // 0x00000001806EF390-0x00000001806EF530
	public static int FontSize(float raw); // 0x00000001806EF530-0x00000001806EF610
	public static UnityEngine.UI.Text Text(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005F0A02 */); // 0x00000001806EF610-0x00000001806EF740
	public static UnityEngine.UI.Text Title(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleCenter /* Metadata: 0x005F0A03 */); // 0x00000001806EF740-0x00000001806EF880
	public static UnityEngine.UI.Text TextOnWhite(Transform parent, string name, float x, float y, float w, float h, string value, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005F0A04 */); // 0x00000001806EF880-0x00000001806EF9B0
	private static UnityEngine.UI.Text Fill(GameObject go, string value, float fontSize, Color color, TextAnchor align, bool outline, Color outlineColor); // 0x00000001806EF9B0-0x00000001806EFD10
	public static UnityEngine.UI.Text Fit(UnityEngine.UI.Text t, float minSize); // 0x00000001806EFD10-0x00000001806EFFA0
	public static void SetText(UnityEngine.UI.Text label, string value); // 0x00000001806EFFA0-0x00000001806F00B0
	public static string Ellipsis(string s, int max); // 0x00000001806F00B0-0x00000001806F02D0
	public static Image Icon(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite); // 0x00000001806F02D0-0x00000001806F0470
	public static Image Sliced(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite, Color waiting, Color ready); // 0x00000001806F0470-0x00000001806F0610
	public static Image Chip(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h); // 0x00000001806F0610-0x00000001806F0720
	public static Image Shell(MonoBehaviour host, RectTransform box); // 0x00000001806F0720-0x00000001806F0790
	public static void Divider(Transform parent, float x, float y, float w, Color color); // 0x00000001806F0790-0x00000001806F0850
	public static Button MakeButton(GameObject host, UnityAction onTap); // 0x00000001806F0850-0x00000001806F0B90
	public static Button Button(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float fontSize, Color tint, UnityAction onTap, out UnityEngine.UI.Text labelText); // 0x00000001806F0B90-0x00000001806F0F80
	public static Button Button(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float fontSize, Color tint, UnityAction onTap); // 0x00000001806F0F80-0x00000001806F10A0
	public static Button IconButton(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string sprite, UnityAction onTap); // 0x00000001806F10A0-0x00000001806F1290
	public static UnityEngine.UI.Text LabelOf(Button btn); // 0x00000001806F1290-0x00000001806F14B0
	public static void SetEnabled(Button btn, bool on); // 0x00000001806F14B0-0x00000001806F1700
	public static void SetAlpha(Graphic g, float alpha); // 0x00000001806F1700-0x00000001806F1850
	public static Slider Slider(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, float value); // 0x00000001806F1850-0x00000001806F24A0
	public static PillUi Pill(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, Color tint, UnityAction onTap); // 0x00000001806F24A0-0x00000001806F2910
	public static float KnobX(bool on, float w = 100f /* Metadata: 0x005F0A05 */); // 0x00000001806F2910-0x00000001806F2940
	public static void Bind(Component node, string key); // 0x00000001806F2940-0x00000001806F2B80
	public static string Num(long v); // 0x00000001806F2B80-0x00000001806F2C70
	public static string Duration(int seconds); // 0x00000001806F2C70-0x00000001806F2F90
}

