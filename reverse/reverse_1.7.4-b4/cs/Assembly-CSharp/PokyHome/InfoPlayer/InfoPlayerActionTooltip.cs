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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerActionTooltip : MonoBehaviour // TypeDefIndex: 2802
	{
		// Fields
		public const string ROOT_NAME = "StorageTooltip"; // Metadata: 0x005F2FCF
		public const int MAX_CHIPS = 4; // Metadata: 0x005F2FDE
		public const int MAX_BUTTONS = 3; // Metadata: 0x005F2FDF
		public const int SORT_ORDER = 9313; // Metadata: 0x005F2FE0
		private const float D_W = 575f; // Metadata: 0x005F2FE4
		private const float D_PAD = 22f; // Metadata: 0x005F2FE8
		private const float D_FRAME_X = 18f; // Metadata: 0x005F2FEC
		private const float D_FRAME_Y = 12f; // Metadata: 0x005F2FF0
		private const float D_FRAME = 68f; // Metadata: 0x005F2FF4
		private const float D_ICON_INSET = 7f; // Metadata: 0x005F2FF8
		public const float ICON_INSET_FULL_BLEED = 10f; // Metadata: 0x005F2FFC
		private const float D_NAME_X = 98f; // Metadata: 0x005F3000
		private const float D_NAME_Y = 12f; // Metadata: 0x005F3004
		private const float D_NAME_W = 430f; // Metadata: 0x005F3008
		private const float D_NAME_H = 36f; // Metadata: 0x005F300C
		private const float D_NAME_FS = 30f; // Metadata: 0x005F3010
		private const float D_STAR_Y = 49f; // Metadata: 0x005F3014
		private const float D_STAR = 22f; // Metadata: 0x005F3018
		private const float D_STAR_GAP = 3f; // Metadata: 0x005F301C
		private const float D_SUB_H = 26f; // Metadata: 0x005F3020
		private const float D_SUB_FS = 18f; // Metadata: 0x005F3024
		private const float D_DIV_Y = 90f; // Metadata: 0x005F3028
		private const float D_CHIP_Y = 100f; // Metadata: 0x005F302C
		private const float D_CHIP_H = 36f; // Metadata: 0x005F3030
		private const float D_CHIP_GAP = 8f; // Metadata: 0x005F3034
		private const float D_CHIP_ICON = 30f; // Metadata: 0x005F3038
		private const float D_CHIP_FS = 22f; // Metadata: 0x005F303C
		private const float D_LINE_H = 27f; // Metadata: 0x005F3040
		private const float D_LINE_FS = 20f; // Metadata: 0x005F3044
		private const float D_FOOT = 70f; // Metadata: 0x005F3048
		private const float D_BTN_W = 150f; // Metadata: 0x005F304C
		private const float D_BTN_H = 44f; // Metadata: 0x005F3050
		private const float D_BTN_FS = 21f; // Metadata: 0x005F3054
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F3058
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F305C
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F3060
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F3064
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
		public static bool IsShowing { get; } // 0x0000000180CEFDB0-0x0000000180CEFF40 
	
		// Nested types
		public struct Chip // TypeDefIndex: 2803
		{
			// Fields
			public string iconPath; // 0x00
			public string value; // 0x08
		}
	
		public class ButtonSpec // TypeDefIndex: 2804
		{
			// Fields
			public string label; // 0x10
			public Color tint; // 0x18
			public bool enabled; // 0x28
			public bool closeAfter; // 0x29
			public Action onClick; // 0x30
	
			// Constructors
			public ButtonSpec(); // 0x0000000180CF5460-0x0000000180CF5480
		}
	
		public class Model // TypeDefIndex: 2805
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
			public Model(); // 0x0000000180CF5840-0x0000000180CF5BA0
	
			// Methods
			public Model AddChip(string iconPath, string value); // 0x0000000180CF5480-0x0000000180CF55D0
			public Model AddLine(string line); // 0x0000000180CF55D0-0x0000000180CF5680
			public Model AddButton(string label, Color tint, bool enabled, Action onClick, bool closeAfter = false /* Metadata: 0x005F3068 */); // 0x0000000180CF5680-0x0000000180CF5840
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass75_0 // TypeDefIndex: 2806
		{
			// Fields
			public int idx; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EnsureBuilt_b__1(); // 0x0000000180CF5BA0-0x0000000180CF5C50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass81_0 // TypeDefIndex: 2807
		{
			// Fields
			public int token; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass81_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x0000000180CF5C50-0x0000000180CF5E50
		}
	
		// Constructors
		public InfoPlayerActionTooltip(); // 0x0000000180CF4FF0-0x0000000180CF53E0
		static InfoPlayerActionTooltip(); // 0x0000000180CF53E0-0x0000000180CF5460
	
		// Methods
		public static void Show(RectTransform anchor, Model model); // 0x0000000180CEFF40-0x0000000180CF0080
		public static void Refresh(Model model); // 0x0000000180CF0080-0x0000000180CF0420
		public static void Hide(); // 0x0000000180CF0420-0x0000000180CF0640
		private static InfoPlayerActionTooltip Resolve(); // 0x0000000180CF0640-0x0000000180CF0A30
		private void Awake(); // 0x0000000180CF0A30-0x0000000180CF0C30
		private void OnDestroy(); // 0x0000000180CF0C30-0x0000000180CF0E10
		private void OnDisable(); // 0x0000000180CF0E10-0x0000000180CF1050
		private void EnsureBuilt(); // 0x0000000180CF1050-0x0000000180CF29D0
		private void Present(RectTransform anchor, Model model); // 0x0000000180CF29D0-0x0000000180CF2D00
		public void Fill(Model m); // 0x0000000180CF2D00-0x0000000180CF3D30
		public void Relayout(); // 0x0000000180CF3D30-0x0000000180CF3DD0
		private void ApplyIconRect(float inset, bool iconInsideOverlay); // 0x0000000180CF3DD0-0x0000000180CF4230
		private void ApplyIcon(Model m); // 0x0000000180CF4230-0x0000000180CF4730
		private bool ApplyStars(int star, int maxStar); // 0x0000000180CF4730-0x0000000180CF4F30
		private void OnButton(int index); // 0x0000000180CF4F30-0x0000000180CF4FF0
		[CompilerGenerated]
		private void _EnsureBuilt_b__75_0(); // 0x00000001804BF740-0x00000001804BF7C0
	}
}
