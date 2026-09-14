/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class PetLibTooltipView : MonoBehaviour // TypeDefIndex: 2136
{
	// Fields
	public const string FLAG = "thuvien.pettip"; // Metadata: 0x005F1A29
	public const string ROOT_NAME = "PetLibTooltip"; // Metadata: 0x005F1A38
	public const string ART_DIR = "Image/Poky/ThuVien/"; // Metadata: 0x005F1A46
	public const string SP_FRAME = "Image/Poky/ThuVien/tipFrame"; // Metadata: 0x005F1A5A
	public const string SP_DECOR = "Image/Poky/ThuVien/tipDecor"; // Metadata: 0x005F1A76
	public const float PANEL_W = 248f; // Metadata: 0x005F1A92
	public const float PANEL_H = 182f; // Metadata: 0x005F1A96
	private static readonly Vector4 FRAME_BORDER; // 0x00
	public const float IN_L = -100f; // Metadata: 0x005F1A9A
	public const float IN_R = 94f; // Metadata: 0x005F1A9E
	public const float IN_B = -65f; // Metadata: 0x005F1AA2
	public const float IN_T = 66f; // Metadata: 0x005F1AA6
	private const float BADGE = 36f; // Metadata: 0x005F1AAA
	private static readonly Vector2 BADGE_POS; // 0x10
	private const float BADGE2 = 18f; // Metadata: 0x005F1AAE
	private static readonly Vector2 BADGE2_POS; // 0x18
	private const float NAME_X = 17f; // Metadata: 0x005F1AB2
	private const float NAME_W = 154f; // Metadata: 0x005F1AB6
	private const float NAME_Y = 52f; // Metadata: 0x005F1ABA
	private const float NAME_H = 22f; // Metadata: 0x005F1ABE
	private const int NAME_FONT_MAX = 17; // Metadata: 0x005F1AC2
	private const int NAME_FONT_MIN = 11; // Metadata: 0x005F1AC3
	private const float LEVEL_Y = 31f; // Metadata: 0x005F1AC4
	private const float LEVEL_H = 18f; // Metadata: 0x005F1AC8
	private const int LEVEL_FONT = 13; // Metadata: 0x005F1ACC
	private static readonly Vector2 DECOR_POS; // 0x20
	private static readonly Vector2 DECOR_SIZE; // 0x28
	private const float CAPTION_Y = 11f; // Metadata: 0x005F1ACD
	private const float CAPTION_H = 15f; // Metadata: 0x005F1AD1
	private const float CAPTION_W = 80f; // Metadata: 0x005F1AD5
	private const float CAP_STATS_X = -60f; // Metadata: 0x005F1AD9
	private const float CAP_RES_X = 45f; // Metadata: 0x005F1ADD
	private const int CAPTION_FONT = 11; // Metadata: 0x005F1AE1
	private const float STAT_Y0 = -9f; // Metadata: 0x005F1AE2
	private const float STAT_PITCH = 21f; // Metadata: 0x005F1AE6
	private const float STAT_H = 21f; // Metadata: 0x005F1AEA
	private const float STAT_LBL_X = -79f; // Metadata: 0x005F1AEE
	private const float STAT_LBL_W = 42f; // Metadata: 0x005F1AF2
	private const float STAT_VAL_X = -33f; // Metadata: 0x005F1AF6
	private const float STAT_VAL_W = 56f; // Metadata: 0x005F1AFA
	private const int STAT_LBL_FONT = 13; // Metadata: 0x005F1AFE
	private const int STAT_VAL_FONT = 16; // Metadata: 0x005F1AFF
	private const int STAT_VAL_FONT_MIN = 11; // Metadata: 0x005F1B00
	private const float RES_CENTER_Y = -30f; // Metadata: 0x005F1B01
	private const float RES_PITCH = 26f; // Metadata: 0x005F1B05
	private const float RES_ICON_X = 17f; // Metadata: 0x005F1B09
	private const float RES_ICON = 24f; // Metadata: 0x005F1B0D
	private const float RES_TXT_X = 62f; // Metadata: 0x005F1B11
	private const float RES_TXT_W = 64f; // Metadata: 0x005F1B15
	private const float RES_TXT_H = 22f; // Metadata: 0x005F1B19
	private const int RES_FONT = 16; // Metadata: 0x005F1B1D
	private const float OUTLINE = 1.2f; // Metadata: 0x005F1B1E
	public const float GAP = 10f; // Metadata: 0x005F1B22
	public const float MARGIN = 10f; // Metadata: 0x005F1B26
	private const float BLOCKER_ALPHA = 0.35f; // Metadata: 0x005F1B2A
	public static readonly string[] ELEMENTS; // 0x30
	private static readonly Color NameColor; // 0x38
	private static readonly Color HpColor; // 0x48
	private static readonly Color AtkColor; // 0x58
	private static readonly Color ManaColor; // 0x68
	private static readonly Color GoodColor; // 0x78
	private static readonly Color CaptionColor; // 0x88
	private static readonly Color FrameInner; // 0x98
	private static readonly Color FrameFallback; // 0xA8
	private const string LEVEL_PREFIX_HEX = "FFD400FF"; // Metadata: 0x005F1B2E
	public RectTransform panel; // 0x20
	public Button blocker; // 0x28
	public Image imgBadge; // 0x30
	public Image imgBadge2; // 0x38
	public UnityEngine.UI.Text txtName; // 0x40
	public UnityEngine.UI.Text txtLevel; // 0x48
	public UnityEngine.UI.Text txtCaptionStats; // 0x50
	public UnityEngine.UI.Text txtCaptionResists; // 0x58
	public UnityEngine.UI.Text lblHp; // 0x60
	public UnityEngine.UI.Text lblAtk; // 0x68
	public UnityEngine.UI.Text lblMana; // 0x70
	public UnityEngine.UI.Text txtHp; // 0x78
	public UnityEngine.UI.Text txtAtk; // 0x80
	public UnityEngine.UI.Text txtMana; // 0x88
	public Image[] imgElem; // 0x90
	public UnityEngine.UI.Text[] txtElem; // 0x98
	private CanvasGroup _group; // 0xA0
	private bool _built; // 0xA8
	private static PetLibTooltipView _instance; // 0xB8

	// Properties
	public static bool Enabled { get; } // 0x0000000180A145F0-0x0000000180A146A0 
	public static bool IsShowing { get; } // 0x0000000180A146A0-0x0000000180A14840 

	// Nested types
	public enum Side : byte // TypeDefIndex: 2137
	{
		Above = 0,
		Below = 1,
		Right = 2,
		Left = 3
	}

	public struct Placement // TypeDefIndex: 2138
	{
		// Fields
		public Vector2 anchoredPosition; // 0x00
		public Vector2 pivot; // 0x08
		public Side side; // 0x10
	}

	// Constructors
	public PetLibTooltipView(); // 0x0000000180A1A560-0x0000000180A1A6C0
	static PetLibTooltipView(); // 0x0000000180A1A6C0-0x0000000180A1A9B0

	// Methods
	public static void Show(RectTransform anchor, PetLibDTO pet); // 0x0000000180A14840-0x0000000180A14980
	public static void Hide(); // 0x0000000180A14980-0x0000000180A14B40
	private static PetLibTooltipView Resolve(); // 0x0000000180A14B40-0x0000000180A14E80
	public static PetLibTooltipView Spawn(); // 0x0000000180A14E80-0x0000000180A15140
	private void Awake(); // 0x0000000180A15140-0x0000000180A15340
	private void OnDestroy(); // 0x0000000180A15340-0x0000000180A15520
	private void OnDisable(); // 0x0000000180A15520-0x0000000180A156A0
	private void EnsureBuilt(); // 0x0000000180A156A0-0x0000000180A16F90
	private UnityEngine.UI.Text StatLabel(Transform parent, string name, int row, string text, Color color); // 0x0000000180A16F90-0x0000000180A170C0
	private UnityEngine.UI.Text StatValue(Transform parent, string name, int row, Color color); // 0x0000000180A170C0-0x0000000180A17330
	private static void ApplyFrame(Image img, Sprite frame); // 0x0000000180A17330-0x0000000180A175D0
	private void Present(RectTransform anchor, PetLibDTO pet); // 0x0000000180A175D0-0x0000000180A17810
	public void Fill(PetLibDTO pet); // 0x0000000180A17810-0x0000000180A17AF0
	private void FillResists(string e1); // 0x0000000180A17AF0-0x0000000180A184B0
	private static void SetIcon(Image img, Sprite sp); // 0x0000000180A184B0-0x0000000180A18690
	public static string Num(int v, bool hidden); // 0x0000000180A18690-0x0000000180A18800
	private void ClosePanel(); // 0x0000000180A18800-0x0000000180A18A10
	public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x0000000180A18A10-0x0000000180A18D80
	private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180A18D80-0x0000000180A18DF0
	private bool TryAnchorRect(RectTransform anchor, out Rect rect); // 0x0000000180A18DF0-0x0000000180A192A0
	private void Place(RectTransform anchor); // 0x0000000180A192A0-0x0000000180A19720
	private static GameObject Node(Transform parent, string name, Vector2 pos, Vector2 size); // 0x0000000180A19720-0x0000000180A19B60
	private static GameObject Stretch(Transform parent, string name); // 0x0000000180A19B60-0x0000000180A19FE0
	private static Image Icon(Transform parent, string name, Vector2 pos, Vector2 size, Sprite sp); // 0x0000000180A19FE0-0x0000000180A1A200
	private static UnityEngine.UI.Text Label(Transform parent, string name, Vector2 pos, Vector2 size, int fontSize, Color color, TextAnchor align); // 0x0000000180A1A200-0x0000000180A1A560
	[CompilerGenerated]
	private void _ClosePanel_b__104_0(); // 0x0000000180A1A9B0-0x0000000180A1AB00
}

