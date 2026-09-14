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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerActionTooltip : MonoBehaviour // TypeDefIndex: 2795
	{
		// Fields
		public const string ROOT_NAME = "StorageTooltip"; // Metadata: 0x005F1BB8
		public const int MAX_CHIPS = 4; // Metadata: 0x005F1BC7
		public const int MAX_BUTTONS = 3; // Metadata: 0x005F1BC8
		public const int SORT_ORDER = 9313; // Metadata: 0x005F1BC9
		private const float D_W = 575f; // Metadata: 0x005F1BCD
		private const float D_PAD = 22f; // Metadata: 0x005F1BD1
		private const float D_FRAME_X = 18f; // Metadata: 0x005F1BD5
		private const float D_FRAME_Y = 12f; // Metadata: 0x005F1BD9
		private const float D_FRAME = 68f; // Metadata: 0x005F1BDD
		private const float D_ICON_INSET = 7f; // Metadata: 0x005F1BE1
		public const float ICON_INSET_FULL_BLEED = 10f; // Metadata: 0x005F1BE5
		private const float D_NAME_X = 98f; // Metadata: 0x005F1BE9
		private const float D_NAME_Y = 12f; // Metadata: 0x005F1BED
		private const float D_NAME_W = 430f; // Metadata: 0x005F1BF1
		private const float D_NAME_H = 36f; // Metadata: 0x005F1BF5
		private const float D_NAME_FS = 30f; // Metadata: 0x005F1BF9
		private const float D_STAR_Y = 49f; // Metadata: 0x005F1BFD
		private const float D_STAR = 22f; // Metadata: 0x005F1C01
		private const float D_STAR_GAP = 3f; // Metadata: 0x005F1C05
		private const float D_SUB_H = 26f; // Metadata: 0x005F1C09
		private const float D_SUB_FS = 18f; // Metadata: 0x005F1C0D
		private const float D_DIV_Y = 90f; // Metadata: 0x005F1C11
		private const float D_CHIP_Y = 100f; // Metadata: 0x005F1C15
		private const float D_CHIP_H = 36f; // Metadata: 0x005F1C19
		private const float D_CHIP_GAP = 8f; // Metadata: 0x005F1C1D
		private const float D_CHIP_ICON = 30f; // Metadata: 0x005F1C21
		private const float D_CHIP_FS = 22f; // Metadata: 0x005F1C25
		private const float D_LINE_H = 27f; // Metadata: 0x005F1C29
		private const float D_LINE_FS = 20f; // Metadata: 0x005F1C2D
		private const float D_FOOT = 70f; // Metadata: 0x005F1C31
		private const float D_BTN_W = 150f; // Metadata: 0x005F1C35
		private const float D_BTN_H = 44f; // Metadata: 0x005F1C39
		private const float D_BTN_FS = 21f; // Metadata: 0x005F1C3D
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F1C41
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F1C45
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F1C49
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F1C4D
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
		public static bool IsShowing { get; } // 0x0000000180CE2530-0x0000000180CE26C0 
	
		// Nested types
		public struct Chip // TypeDefIndex: 2796
		{
			// Fields
			public string iconPath; // 0x00
			public string value; // 0x08
		}
	
		public class ButtonSpec // TypeDefIndex: 2797
		{
			// Fields
			public string label; // 0x10
			public Color tint; // 0x18
			public bool enabled; // 0x28
			public bool closeAfter; // 0x29
			public Action onClick; // 0x30
	
			// Constructors
			public ButtonSpec(); // 0x0000000180CE7BE0-0x0000000180CE7C00
		}
	
		public class Model // TypeDefIndex: 2798
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
			public Model(); // 0x0000000180CE7FC0-0x0000000180CE8320
	
			// Methods
			public Model AddChip(string iconPath, string value); // 0x0000000180CE7C00-0x0000000180CE7D50
			public Model AddLine(string line); // 0x0000000180CE7D50-0x0000000180CE7E00
			public Model AddButton(string label, Color tint, bool enabled, Action onClick, bool closeAfter = false /* Metadata: 0x005F1C51 */); // 0x0000000180CE7E00-0x0000000180CE7FC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass75_0 // TypeDefIndex: 2799
		{
			// Fields
			public int idx; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EnsureBuilt_b__1(); // 0x0000000180CE8320-0x0000000180CE83D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass81_0 // TypeDefIndex: 2800
		{
			// Fields
			public int token; // 0x10
			public InfoPlayerActionTooltip __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass81_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x0000000180CE83D0-0x0000000180CE85D0
		}
	
		// Constructors
		public InfoPlayerActionTooltip(); // 0x0000000180CE7770-0x0000000180CE7B60
		static InfoPlayerActionTooltip(); // 0x0000000180CE7B60-0x0000000180CE7BE0
	
		// Methods
		public static void Show(RectTransform anchor, Model model); // 0x0000000180CE26C0-0x0000000180CE2800
		public static void Refresh(Model model); // 0x0000000180CE2800-0x0000000180CE2BA0
		public static void Hide(); // 0x0000000180CE2BA0-0x0000000180CE2DC0
		private static InfoPlayerActionTooltip Resolve(); // 0x0000000180CE2DC0-0x0000000180CE31B0
		private void Awake(); // 0x0000000180CE31B0-0x0000000180CE33B0
		private void OnDestroy(); // 0x0000000180CE33B0-0x0000000180CE3590
		private void OnDisable(); // 0x0000000180CE3590-0x0000000180CE37D0
		private void EnsureBuilt(); // 0x0000000180CE37D0-0x0000000180CE5150
		private void Present(RectTransform anchor, Model model); // 0x0000000180CE5150-0x0000000180CE5480
		public void Fill(Model m); // 0x0000000180CE5480-0x0000000180CE64B0
		public void Relayout(); // 0x0000000180CE64B0-0x0000000180CE6550
		private void ApplyIconRect(float inset, bool iconInsideOverlay); // 0x0000000180CE6550-0x0000000180CE69B0
		private void ApplyIcon(Model m); // 0x0000000180CE69B0-0x0000000180CE6EB0
		private bool ApplyStars(int star, int maxStar); // 0x0000000180CE6EB0-0x0000000180CE76B0
		private void OnButton(int index); // 0x0000000180CE76B0-0x0000000180CE7770
		[CompilerGenerated]
		private void _EnsureBuilt_b__75_0(); // 0x00000001804BE180-0x00000001804BE200
	}
}
