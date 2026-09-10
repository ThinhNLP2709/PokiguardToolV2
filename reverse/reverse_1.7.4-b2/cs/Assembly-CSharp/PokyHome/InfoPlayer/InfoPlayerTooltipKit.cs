/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerTooltipKit // TypeDefIndex: 2429
	{
		// Fields
		public const float K = 0.65f; // Metadata: 0x0068F1D0
		public const float OUTLINE = 2f; // Metadata: 0x0068F1D4
		public const string ART = "Image/InfoPlayer/"; // Metadata: 0x0068F1D8
		public const string SP_PANEL = "Image/InfoPlayer/tooltip_panel"; // Metadata: 0x0068F1EA
		public const string SP_BTN = "Image/InfoPlayer/btn"; // Metadata: 0x0068F209
		public const string SP_CARD = "Image/InfoPlayer/card_elo"; // Metadata: 0x0068F21E
		public const string SP_EXP_BG = "Image/InfoPlayer/x2_exp_bg"; // Metadata: 0x0068F238
		public const string SP_PILL = "Image/InfoPlayer/field_white"; // Metadata: 0x0068F253
		public const string SP_STAR = "Image/InfoPlayer/star_gold"; // Metadata: 0x0068F270
		public const string SP_BADGE_LEVEL = "Image/InfoPlayer/badge_level"; // Metadata: 0x0068F28B
		public const string SP_ICON_MANA = "Image/InfoPlayer/icon_mana"; // Metadata: 0x0068F2A8
		public const string SP_ICON_HP = "Image/InfoPlayer/icon_hp"; // Metadata: 0x0068F2C3
		public const string SP_ICON_ATK = "Image/InfoPlayer/icon_atk"; // Metadata: 0x0068F2DC
		public static readonly string[] SP_ELEMENTS; // 0x00
		public const float SLICE_PPU_MULT = 1.5f; // Metadata: 0x0068F2F6
		public static readonly Color Cyan; // 0x08
		public static readonly Color Gold; // 0x18
		public static readonly Color Dim; // 0x28
		public static readonly Color Green; // 0x38
		public static readonly Color Red; // 0x48
		public static readonly Color Divide; // 0x58
		public static readonly Color FrameFallback; // 0x68
		public static readonly Color SetViolet; // 0x78
	
		// Nested types
		public struct Chip // TypeDefIndex: 2430
		{
			// Fields
			public RectTransform root; // 0x00
			public Image bg; // 0x08
			public Image icon; // 0x10
			public UnityEngine.UI.Text value; // 0x18
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2431
		{
			// Fields
			public Image img; // 0x10
			public Color ready; // 0x18
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Bind_b__0(Sprite sp); // 0x000000018080D120-0x000000018080D1E0
		}
	
		// Constructors
		static InfoPlayerTooltipKit(); // 0x00000001808020A0-0x00000001808022D0
	
		// Methods
		public static string RaritySlotSprite(int rarity); // 0x0000000180801370-0x0000000180801400
		public static float S(float design); // 0x0000000180801400-0x0000000180801410
		public static Canvas OverlayCanvas(GameObject root, int sortingOrder); // 0x0000000180800E40-0x0000000180800F70
		public static Button Blocker(Transform root, float alpha, UnityAction onClick); // 0x00000001807FF920-0x00000001807FFB90
		public static GameObject Node(Transform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 pos, Vector2 size); // 0x0000000180800B30-0x0000000180800E40
		public static GameObject TopLeft(Transform parent, string name, float dx, float dy, float dw, float dh); // 0x0000000180801C10-0x0000000180801D10
		public static GameObject Stretch(Transform parent, string name, float dx = 0f /* Metadata: 0x0068F1C6 */, float dy = 0f /* Metadata: 0x0068F1CA */); // 0x0000000180801940-0x0000000180801B50
		public static Image MakeImage(Transform parent, string name, float dx, float dy, float dw, float dh, Color color); // 0x0000000180800850-0x0000000180800970
		public static Sprite LoadSprite(string path); // 0x00000001807FFF40-0x0000000180800040
		public static void Bind(MonoBehaviour host, Image img, string path, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x0068F1CE */); // 0x00000001807FF560-0x00000001807FF920
		public static UnityEngine.UI.Text Label(Transform parent, string name, float dx, float dy, float dw, float dh, float fontSize, Color color, TextAnchor align = TextAnchor.MiddleLeft /* Metadata: 0x0068F1CF */); // 0x00000001807FFE60-0x00000001807FFF40
		public static UnityEngine.UI.Text MakeText(GameObject go, float designFontSize, Color color, TextAnchor align); // 0x0000000180800970-0x0000000180800B30
		public static int FontSize(float designFontSize); // 0x00000001807FFDD0-0x00000001807FFE60
		public static void Shrinkable(UnityEngine.UI.Text t, float designFontSize); // 0x0000000180801850-0x0000000180801940
		public static void SetText(UnityEngine.UI.Text label, string value); // 0x00000001808014F0-0x0000000180801590
		public static void SetAlpha(Graphic g, float alpha); // 0x0000000180801410-0x00000001808014F0
		public static Chip MakeChip(MonoBehaviour host, Transform parent, string name, float dx, float dy, float dw, float dh, string iconPath, float iconSize, float fontSize); // 0x0000000180800390-0x0000000180800850
		public static Button MakeButton(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string label, float labelFs, Color tint, out UnityEngine.UI.Text labelText); // 0x0000000180800040-0x0000000180800390
		public static void Toggle(Button b, bool on); // 0x0000000180801B50-0x0000000180801C10
		public static Image Shell(MonoBehaviour host, RectTransform panel, out Image shadow); // 0x0000000180801590-0x0000000180801850
		public static void Divider(Transform parent, float dx, float dy, float dw, Color color); // 0x00000001807FFB90-0x00000001807FFDD0
		public static bool TryAnchorRect(RectTransform space, RectTransform anchor, out Rect rect); // 0x0000000180801D10-0x00000001808020A0
		public static void Place(RectTransform space, RectTransform panel, RectTransform anchor, float gap, float margin); // 0x0000000180800F70-0x0000000180801200
		public static Color RarityColor(int rarity); // 0x0000000180801200-0x0000000180801270
		public static string RarityName(int rarity); // 0x0000000180801270-0x0000000180801370
	}
}
