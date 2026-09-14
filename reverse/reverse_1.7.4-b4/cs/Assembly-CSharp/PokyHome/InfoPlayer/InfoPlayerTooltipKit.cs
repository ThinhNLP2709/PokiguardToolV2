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

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerTooltipKit // TypeDefIndex: 2881
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
		public struct Chip // TypeDefIndex: 2882
		{
			// Fields
			public RectTransform root; // 0x00
			public Image bg; // 0x08
			public Image icon; // 0x10
			public UnityEngine.UI.Text value; // 0x18
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2883
		{
			// Fields
			public Image img; // 0x10
			public Color ready; // 0x18
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sp); // 0x0000000180D2E670-0x0000000180D2E840
		}
	
		// Constructors
		static InfoPlayerTooltipKit(); // 0x0000000180D2E410-0x0000000180D2E670
	
		// Methods
		public static string RaritySlotSprite(int rarity); // 0x0000000180D2A900-0x0000000180D2A9B0
		public static float S(float design); // 0x0000000180D2A9B0-0x0000000180D2A9C0
		public static Canvas OverlayCanvas(GameObject root, int sortingOrder); // 0x0000000180D2A9C0-0x0000000180D2AB60
		public static Button Blocker(Transform root, float alpha, UnityAction onClick); // 0x0000000180D2AB60-0x0000000180D2AE60
		public static GameObject Node(Transform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 pos, Vector2 size); // 0x0000000180D2AE60-0x0000000180D2B310
		public static GameObject TopLeft(Transform parent, string name, float dx, float dy, float dw, float dh); // 0x0000000180D2B310-0x0000000180D2B420
		public static GameObject Stretch(Transform parent, string name, float dx = 0f /* Metadata: 0x005F3419 */, float dy = 0f /* Metadata: 0x005F341D */); // 0x0000000180D2B420-0x0000000180D2B640
		public static Image MakeImage(Transform parent, string name, float dx, float dy, float dw, float dh, Color color); // 0x0000000180D2B640-0x0000000180D2B770
		public static Sprite LoadSprite(string path); // 0x0000000180D2B770-0x0000000180D2B940
		public static void Bind(MonoBehaviour host, Image img, string path, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005F3421 */); // 0x0000000180D2B940-0x0000000180D2BE40
		public static UnityEngine.UI.Text Label(Transform parent, string name, float dx, float dy, float dw, float dh, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x005F3422 */); // 0x0000000180D2BE40-0x0000000180D2BF20
		public static UnityEngine.UI.Text MakeText(GameObject go, float designFontSize, Color color, TextAnchor align); // 0x0000000180D2BF20-0x0000000180D2C210
		public static int FontSize(float designFontSize); // 0x0000000180D2C210-0x0000000180D2C2A0
		public static void Shrinkable(UnityEngine.UI.Text t, float designFontSize); // 0x0000000180D2C2A0-0x0000000180D2C540
		public static void SetText(UnityEngine.UI.Text label, string value); // 0x0000000180D2C540-0x0000000180D2C650
		public static void SetAlpha(Graphic g, float alpha); // 0x0000000180D2C650-0x0000000180D2C7A0
		public static Chip MakeChip(MonoBehaviour host, Transform parent, string name, float dx, float dy, float dw, float dh, string iconPath, float iconSize, float fontSize); // 0x0000000180D2C7A0-0x0000000180D2CCF0
		public static Button MakeButton(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float labelFs, Color tint, out UnityEngine.UI.Text labelText); // 0x0000000180D2CCF0-0x0000000180D2D120
		public static void Toggle(Button b, bool on); // 0x0000000180D2D120-0x0000000180D2D300
		public static Image Shell(MonoBehaviour host, RectTransform panel, out Image shadow); // 0x0000000180D2D300-0x0000000180D2D620
		public static void Divider(Transform parent, float dx, float dy, float dw, Color color); // 0x0000000180D2D620-0x0000000180D2D880
		public static bool TryAnchorRect(RectTransform space, RectTransform anchor, out Rect rect); // 0x0000000180D2D880-0x0000000180D2DE10
		public static void Place(RectTransform space, RectTransform panel, RectTransform anchor, float gap, float margin, float scale = 1f /* Metadata: 0x005F3423 */); // 0x0000000180D2DE10-0x0000000180D2E280
		public static Color RarityColor(int rarity); // 0x0000000180D2E280-0x0000000180D2E2F0
		public static string RarityName(int rarity); // 0x0000000180D2E2F0-0x0000000180D2E410
	}
}
