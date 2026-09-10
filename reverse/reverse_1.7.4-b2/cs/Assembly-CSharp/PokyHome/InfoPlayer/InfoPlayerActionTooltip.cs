/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerActionTooltip : MonoBehaviour // TypeDefIndex: 2352
	{
		// Fields
		public const string ROOT_NAME = "StorageTooltip"; // Metadata: 0x0068ED04
		public const int MAX_CHIPS = 4; // Metadata: 0x0068ED13
		public const int MAX_BUTTONS = 3; // Metadata: 0x0068ED14
		public const int SORT_ORDER = 9313; // Metadata: 0x0068ED15
		private const float D_W = 575f; // Metadata: 0x0068ED19
		private const float D_PAD = 22f; // Metadata: 0x0068ED1D
		private const float D_FRAME_X = 18f; // Metadata: 0x0068ED21
		private const float D_FRAME_Y = 12f; // Metadata: 0x0068ED25
		private const float D_FRAME = 68f; // Metadata: 0x0068ED29
		private const float D_ICON_INSET = 7f; // Metadata: 0x0068ED2D
		public const float ICON_INSET_FULL_BLEED = 10f; // Metadata: 0x0068ED31
		private const float D_NAME_X = 98f; // Metadata: 0x0068ED35
		private const float D_NAME_Y = 12f; // Metadata: 0x0068ED39
		private const float D_NAME_W = 430f; // Metadata: 0x0068ED3D
		private const float D_NAME_H = 36f; // Metadata: 0x0068ED41
		private const float D_NAME_FS = 30f; // Metadata: 0x0068ED45
		private const float D_STAR_Y = 49f; // Metadata: 0x0068ED49
		private const float D_STAR = 22f; // Metadata: 0x0068ED4D
		private const float D_STAR_GAP = 3f; // Metadata: 0x0068ED51
		private const float D_SUB_H = 26f; // Metadata: 0x0068ED55
		private const float D_SUB_FS = 18f; // Metadata: 0x0068ED59
		private const float D_DIV_Y = 90f; // Metadata: 0x0068ED5D
		private const float D_CHIP_Y = 100f; // Metadata: 0x0068ED61
		private const float D_CHIP_H = 36f; // Metadata: 0x0068ED65
		private const float D_CHIP_GAP = 8f; // Metadata: 0x0068ED69
		private const float D_CHIP_ICON = 30f; // Metadata: 0x0068ED6D
		private const float D_CHIP_FS = 22f; // Metadata: 0x0068ED71
		private const float D_LINE_H = 27f; // Metadata: 0x0068ED75
		private const float D_LINE_FS = 20f; // Metadata: 0x0068ED79
		private const float D_FOOT = 70f; // Metadata: 0x0068ED7D
		private const float D_BTN_W = 150f; // Metadata: 0x0068ED81
		private const float D_BTN_H = 44f; // Metadata: 0x0068ED85
		private const float D_BTN_FS = 21f; // Metadata: 0x0068ED89
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x0068ED8D
		private const float D_BTN_GAP = 8f; // Metadata: 0x0068ED91
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x0068ED95
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x0068ED99
		private static readonly Color StarOn; // 0x00
		private static readonly Color StarOff; // 0x10
		private static readonly Color DisabledTint; // 0x20
		public RectTransform panel; // 0x20
		public Button blocker; // 0x28
		public Image imgShadow; // 0x30
		public Image imgPanel; // 0x38
		public Image imgIconFrame; // 0x40
		public Image imgIcon; // 0x48
		public Image imgOverlay; // 0x50
		public UnityEngine.UI.Text txtName; // 0x58
		public UnityEngine.UI.Text txtSubtitle; // 0x60
		public UnityEngine.UI.Text txtStarsFallback; // 0x68
		public Image[] imgStars; // 0x70
		public InfoPlayerTooltipKit.Chip[] chips; // 0x78
		public UnityEngine.UI.Text[] lines; // 0x80
		public Button[] buttons; // 0x88
		public UnityEngine.UI.Text[] buttonLabels; // 0x90
		public Image[] buttonImages; // 0x98
		private CanvasGroup _group; // 0xA0
		private bool _built; // 0xA8
		private int _iconToken; // 0xAC
		private RectTransform _anchor; // 0xB0
		private Model _model; // 0xB8
		private readonly StringBuilder _sb; // 0xC0
		private static InfoPlayerActionTooltip _instance; // 0x30
		private float _contentEnd; // 0xC8
	
		// Properties
		public static bool IsShowing { get; } // 0x00000001807D7DB0-0x00000001807D7E70 
	
		// Nested types
		public struct Chip // TypeDefIndex: 2353
		{
			// Fields
			public string iconPath; // 0x00
			public string value; // 0x08
		}
	
		public class ButtonSpec // TypeDefIndex: 2354
		{
			// Fields
			public string label; // 0x10
			public Color tint; // 0x18
			public bool enabled; // 0x28
			public bool closeAfter; // 0x29
			public Action onClick; // 0x30
	
			// Constructors
			public ButtonSpec(); // 0x00000001807C7600-0x00000001807C7620
		}
	
		public class Model // TypeDefIndex: 2355
		{
			// Fields
			public string title; // 0x10
			public Color titleColor; // 0x18
			public string subtitle; // 0x28
			public int frameRarity; // 0x30
			public Sprite icon; // 0x38
			public string iconPath; // 0x40
			public float iconInset; // 0x48
			public Sprite overlay; // 0x50
			public bool iconInsideOverlay; // 0x58
			public int star; // 0x5C
			public int maxStar; // 0x60
			public readonly List<Chip> chips; // 0x68
			public readonly List<string> lines; // 0x70
			public readonly List<ButtonSpec> buttons; // 0x78
	
			// Constructors
			public Model(); // 0x00000001807DC1E0-0x00000001807DC340
	
			// Methods
			public Model AddChip(string iconPath, string value); // 0x00000001807DC010-0x00000001807DC120
			public Model AddLine(string line); // 0x00000001807DC120-0x00000001807DC1E0
			public Model AddButton(string label, Color tint, bool enabled, Action onClick, bool closeAfter = false /* Metadata: 0x0068ED9D */); // 0x00000001807DBEC0-0x00000001807DC010
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass75_0 // TypeDefIndex: 2356
		{
			// Fields
			public int idx; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass75_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _EnsureBuilt_b__1(); // 0x00000001807DC7B0-0x00000001807DC850
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass81_0 // TypeDefIndex: 2357
		{
			// Fields
			public int token; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass81_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x00000001807DC850-0x00000001807DC950
		}
	
		// Constructors
		public InfoPlayerActionTooltip(); // 0x00000001807D7C30-0x00000001807D7DB0
		static InfoPlayerActionTooltip(); // 0x00000001807D7BB0-0x00000001807D7C30
	
		// Methods
		public static void Show(RectTransform anchor, Model model); // 0x00000001807D7AF0-0x00000001807D7BB0
		public static void Refresh(Model model); // 0x00000001807D75A0-0x00000001807D77D0
		public static void Hide(); // 0x00000001807D70B0-0x00000001807D71A0
		private static InfoPlayerActionTooltip Resolve(); // 0x00000001807D7880-0x00000001807D7AF0
		private void Awake(); // 0x00000001807D5330-0x00000001807D5430
		private void OnDestroy(); // 0x00000001807D7230-0x00000001807D72F0
		private void OnDisable(); // 0x00000001807D72F0-0x00000001807D73D0
		private void EnsureBuilt(); // 0x00000001807D5430-0x00000001807D6470
		private void Present(RectTransform anchor, Model model); // 0x00000001807D73D0-0x00000001807D75A0
		public void Fill(Model m); // 0x00000001807D6470-0x00000001807D70B0
		public void Relayout(); // 0x00000001807D77D0-0x00000001807D7880
		private void ApplyIconRect(float inset, bool iconInsideOverlay); // 0x00000001807D4870-0x00000001807D4BE0
		private void ApplyIcon(Model m); // 0x00000001807D4BE0-0x00000001807D4F10
		private bool ApplyStars(int star, int maxStar); // 0x00000001807D4F10-0x00000001807D5330
		private void OnButton(int index); // 0x00000001807D71A0-0x00000001807D7230
		[CompilerGenerated]
		private void _EnsureBuilt_b__75_0(); // 0x00000001803F8240-0x00000001803F8270
	}
}
