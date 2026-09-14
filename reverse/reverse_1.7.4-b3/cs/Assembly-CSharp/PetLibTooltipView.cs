/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class PetLibTooltipView : MonoBehaviour // TypeDefIndex: 2134
{
	// Fields
	public const string FLAG = "thuvien.pettip"; // Metadata: 0x005F0658
	public const string ROOT_NAME = "PetLibTooltip"; // Metadata: 0x005F0667
	public const string ART_DIR = "Image/Poky/ThuVien/"; // Metadata: 0x005F0675
	public const string SP_FRAME = "Image/Poky/ThuVien/tipFrame"; // Metadata: 0x005F0689
	public const string SP_DECOR = "Image/Poky/ThuVien/tipDecor"; // Metadata: 0x005F06A5
	public const float PANEL_W = 248f; // Metadata: 0x005F06C1
	public const float PANEL_H = 182f; // Metadata: 0x005F06C5
	private static readonly Vector4 FRAME_BORDER; // 0x00
	public const float IN_L = -100f; // Metadata: 0x005F06C9
	public const float IN_R = 94f; // Metadata: 0x005F06CD
	public const float IN_B = -65f; // Metadata: 0x005F06D1
	public const float IN_T = 66f; // Metadata: 0x005F06D5
	private const float BADGE = 36f; // Metadata: 0x005F06D9
	private static readonly Vector2 BADGE_POS; // 0x10
	private const float BADGE2 = 18f; // Metadata: 0x005F06DD
	private static readonly Vector2 BADGE2_POS; // 0x18
	private const float NAME_X = 17f; // Metadata: 0x005F06E1
	private const float NAME_W = 154f; // Metadata: 0x005F06E5
	private const float NAME_Y = 52f; // Metadata: 0x005F06E9
	private const float NAME_H = 22f; // Metadata: 0x005F06ED
	private const int NAME_FONT_MAX = 17; // Metadata: 0x005F06F1
	private const int NAME_FONT_MIN = 11; // Metadata: 0x005F06F2
	private const float LEVEL_Y = 31f; // Metadata: 0x005F06F3
	private const float LEVEL_H = 18f; // Metadata: 0x005F06F7
	private const int LEVEL_FONT = 13; // Metadata: 0x005F06FB
	private static readonly Vector2 DECOR_POS; // 0x20
	private static readonly Vector2 DECOR_SIZE; // 0x28
	private const float CAPTION_Y = 11f; // Metadata: 0x005F06FC
	private const float CAPTION_H = 15f; // Metadata: 0x005F0700
	private const float CAPTION_W = 80f; // Metadata: 0x005F0704
	private const float CAP_STATS_X = -60f; // Metadata: 0x005F0708
	private const float CAP_RES_X = 45f; // Metadata: 0x005F070C
	private const int CAPTION_FONT = 11; // Metadata: 0x005F0710
	private const float STAT_Y0 = -9f; // Metadata: 0x005F0711
	private const float STAT_PITCH = 21f; // Metadata: 0x005F0715
	private const float STAT_H = 21f; // Metadata: 0x005F0719
	private const float STAT_LBL_X = -79f; // Metadata: 0x005F071D
	private const float STAT_LBL_W = 42f; // Metadata: 0x005F0721
	private const float STAT_VAL_X = -33f; // Metadata: 0x005F0725
	private const float STAT_VAL_W = 56f; // Metadata: 0x005F0729
	private const int STAT_LBL_FONT = 13; // Metadata: 0x005F072D
	private const int STAT_VAL_FONT = 16; // Metadata: 0x005F072E
	private const int STAT_VAL_FONT_MIN = 11; // Metadata: 0x005F072F
	private const float RES_CENTER_Y = -30f; // Metadata: 0x005F0730
	private const float RES_PITCH = 26f; // Metadata: 0x005F0734
	private const float RES_ICON_X = 17f; // Metadata: 0x005F0738
	private const float RES_ICON = 24f; // Metadata: 0x005F073C
	private const float RES_TXT_X = 62f; // Metadata: 0x005F0740
	private const float RES_TXT_W = 64f; // Metadata: 0x005F0744
	private const float RES_TXT_H = 22f; // Metadata: 0x005F0748
	private const int RES_FONT = 16; // Metadata: 0x005F074C
	private const float OUTLINE = 1.2f; // Metadata: 0x005F074D
	public const float GAP = 10f; // Metadata: 0x005F0751
	public const float MARGIN = 10f; // Metadata: 0x005F0755
	private const float BLOCKER_ALPHA = 0.35f; // Metadata: 0x005F0759
	public static readonly string[] ELEMENTS; // 0x30
	private static readonly Color NameColor; // 0x38
	private static readonly Color HpColor; // 0x48
	private static readonly Color AtkColor; // 0x58
	private static readonly Color ManaColor; // 0x68
	private static readonly Color GoodColor; // 0x78
	private static readonly Color CaptionColor; // 0x88
	private static readonly Color FrameInner; // 0x98
	private static readonly Color FrameFallback; // 0xA8
	private const string LEVEL_PREFIX_HEX = "FFD400FF"; // Metadata: 0x005F075D
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
	public static bool Enabled { get; } // 0x0000000180A10A00-0x0000000180A10AB0 
	public static bool IsShowing { get; } // 0x0000000180A10AB0-0x0000000180A10C50 

	// Nested types
	public enum Side : byte // TypeDefIndex: 2135
	{
		Above = 0,
		Below = 1,
		Right = 2,
		Left = 3
	}

	public struct Placement // TypeDefIndex: 2136
	{
		// Fields
		public Vector2 anchoredPosition; // 0x00
		public Vector2 pivot; // 0x08
		public Side side; // 0x10
	}

	// Constructors
	public PetLibTooltipView(); // 0x0000000180A16970-0x0000000180A16AD0
	static PetLibTooltipView(); // 0x0000000180A16AD0-0x0000000180A16DC0

	// Methods
	public static void Show(RectTransform anchor, PetLibDTO pet); // 0x0000000180A10C50-0x0000000180A10D90
	public static void Hide(); // 0x0000000180A10D90-0x0000000180A10F50
	private static PetLibTooltipView Resolve(); // 0x0000000180A10F50-0x0000000180A11290
	public static PetLibTooltipView Spawn(); // 0x0000000180A11290-0x0000000180A11550
	private void Awake(); // 0x0000000180A11550-0x0000000180A11750
	private void OnDestroy(); // 0x0000000180A11750-0x0000000180A11930
	private void OnDisable(); // 0x0000000180A11930-0x0000000180A11AB0
	private void EnsureBuilt(); // 0x0000000180A11AB0-0x0000000180A133A0
	private UnityEngine.UI.Text StatLabel(Transform parent, string name, int row, string text, Color color); // 0x0000000180A133A0-0x0000000180A134D0
	private UnityEngine.UI.Text StatValue(Transform parent, string name, int row, Color color); // 0x0000000180A134D0-0x0000000180A13740
	private static void ApplyFrame(Image img, Sprite frame); // 0x0000000180A13740-0x0000000180A139E0
	private void Present(RectTransform anchor, PetLibDTO pet); // 0x0000000180A139E0-0x0000000180A13C20
	public void Fill(PetLibDTO pet); // 0x0000000180A13C20-0x0000000180A13F00
	private void FillResists(string e1); // 0x0000000180A13F00-0x0000000180A148C0
	private static void SetIcon(Image img, Sprite sp); // 0x0000000180A148C0-0x0000000180A14AA0
	public static string Num(int v, bool hidden); // 0x0000000180A14AA0-0x0000000180A14C10
	private void ClosePanel(); // 0x0000000180A14C10-0x0000000180A14E20
	public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x0000000180A14E20-0x0000000180A15190
	private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180A15190-0x0000000180A15200
	private bool TryAnchorRect(RectTransform anchor, out Rect rect); // 0x0000000180A15200-0x0000000180A156B0
	private void Place(RectTransform anchor); // 0x0000000180A156B0-0x0000000180A15B30
	private static GameObject Node(Transform parent, string name, Vector2 pos, Vector2 size); // 0x0000000180A15B30-0x0000000180A15F70
	private static GameObject Stretch(Transform parent, string name); // 0x0000000180A15F70-0x0000000180A163F0
	private static Image Icon(Transform parent, string name, Vector2 pos, Vector2 size, Sprite sp); // 0x0000000180A163F0-0x0000000180A16610
	private static UnityEngine.UI.Text Label(Transform parent, string name, Vector2 pos, Vector2 size, int fontSize, Color color, TextAnchor align); // 0x0000000180A16610-0x0000000180A16970
	[CompilerGenerated]
	private void _ClosePanel_b__104_0(); // 0x0000000180A16DC0-0x0000000180A16F10
}

