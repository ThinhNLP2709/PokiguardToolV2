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

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerTooltipKit // TypeDefIndex: 2874
	{
		// Fields
		public static readonly string[] SP_ELEMENTS; // 0x00
		public static readonly Color Cyan; // 0x08
		public static readonly Color Gold; // 0x18
		public static readonly Color Dim; // 0x28
		public static readonly Color Green; // 0x38
		public static readonly Color Red; // 0x48
		public static readonly Color Divide; // 0x58
		public static readonly Color FrameFallback; // 0x68
		public static readonly Color SetViolet; // 0x78
	
		// Nested types
		public struct Chip // TypeDefIndex: 2875
		{
			// Fields
			public RectTransform root; // 0x00
			public Image bg; // 0x08
			public Image icon; // 0x10
			public UnityEngine.UI.Text value; // 0x18
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2876
		{
			// Fields
			public Image img; // 0x10
			public Color ready; // 0x18
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sp); // 0x0000000180D20C00-0x0000000180D20DD0
		}
	
		// Constructors
		static InfoPlayerTooltipKit(); // 0x0000000180D209A0-0x0000000180D20C00
	
		// Methods
		public static string RaritySlotSprite(int rarity); // 0x0000000180D1CE90-0x0000000180D1CF40
		public static float S(float design); // 0x0000000180D1CF40-0x0000000180D1CF50
		public static Canvas OverlayCanvas(GameObject root, int sortingOrder); // 0x0000000180D1CF50-0x0000000180D1D0F0
		public static Button Blocker(Transform root, float alpha, UnityAction onClick); // 0x0000000180D1D0F0-0x0000000180D1D3F0
		public static GameObject Node(Transform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 pos, Vector2 size); // 0x0000000180D1D3F0-0x0000000180D1D8A0
		public static GameObject TopLeft(Transform parent, string name, float dx, float dy, float dw, float dh); // 0x0000000180D1D8A0-0x0000000180D1D9B0
		public static GameObject Stretch(Transform parent, string name, float dx = 0f /* Metadata: 0x005F2002 */, float dy = 0f /* Metadata: 0x005F2006 */); // 0x0000000180D1D9B0-0x0000000180D1DBD0
		public static Image MakeImage(Transform parent, string name, float dx, float dy, float dw, float dh, Color color); // 0x0000000180D1DBD0-0x0000000180D1DD00
		public static Sprite LoadSprite(string path); // 0x0000000180D1DD00-0x0000000180D1DED0
		public static void Bind(MonoBehaviour host, Image img, string path, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005F200A */); // 0x0000000180D1DED0-0x0000000180D1E3D0
		public static UnityEngine.UI.Text Label(Transform parent, string name, float dx, float dy, float dw, float dh, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005F200B */); // 0x0000000180D1E3D0-0x0000000180D1E4B0
		public static UnityEngine.UI.Text MakeText(GameObject go, float designFontSize, Color color, TextAnchor align); // 0x0000000180D1E4B0-0x0000000180D1E7A0
		public static int FontSize(float designFontSize); // 0x0000000180D1E7A0-0x0000000180D1E830
		public static void Shrinkable(UnityEngine.UI.Text t, float designFontSize); // 0x0000000180D1E830-0x0000000180D1EAD0
		public static void SetText(UnityEngine.UI.Text label, string value); // 0x0000000180D1EAD0-0x0000000180D1EBE0
		public static void SetAlpha(Graphic g, float alpha); // 0x0000000180D1EBE0-0x0000000180D1ED30
		public static Chip MakeChip(MonoBehaviour host, Transform parent, string name, float dx, float dy, float dw, float dh, string iconPath, float iconSize, float fontSize); // 0x0000000180D1ED30-0x0000000180D1F280
		public static Button MakeButton(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float labelFs, Color tint, out UnityEngine.UI.Text labelText); // 0x0000000180D1F280-0x0000000180D1F6B0
		public static void Toggle(Button b, bool on); // 0x0000000180D1F6B0-0x0000000180D1F890
		public static Image Shell(MonoBehaviour host, RectTransform panel, out Image shadow); // 0x0000000180D1F890-0x0000000180D1FBB0
		public static void Divider(Transform parent, float dx, float dy, float dw, Color color); // 0x0000000180D1FBB0-0x0000000180D1FE10
		public static bool TryAnchorRect(RectTransform space, RectTransform anchor, out Rect rect); // 0x0000000180D1FE10-0x0000000180D203A0
		public static void Place(RectTransform space, RectTransform panel, RectTransform anchor, float gap, float margin, float scale = 1f /* Metadata: 0x005F200C */); // 0x0000000180D203A0-0x0000000180D20810
		public static Color RarityColor(int rarity); // 0x0000000180D20810-0x0000000180D20880
		public static string RarityName(int rarity); // 0x0000000180D20880-0x0000000180D209A0
	}
}
