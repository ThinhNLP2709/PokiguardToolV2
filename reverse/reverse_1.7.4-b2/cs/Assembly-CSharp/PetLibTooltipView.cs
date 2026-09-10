/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class PetLibTooltipView : MonoBehaviour // TypeDefIndex: 1771
{
	// Fields
	public const string FLAG = "thuvien.pettip"; // Metadata: 0x0068D825
	public const string ROOT_NAME = "PetLibTooltip"; // Metadata: 0x0068D834
	public const string ART_DIR = "Image/Poky/ThuVien/"; // Metadata: 0x0068D842
	public const string SP_FRAME = "Image/Poky/ThuVien/tipFrame"; // Metadata: 0x0068D856
	public const string SP_DECOR = "Image/Poky/ThuVien/tipDecor"; // Metadata: 0x0068D872
	public const float PANEL_W = 248f; // Metadata: 0x0068D88E
	public const float PANEL_H = 182f; // Metadata: 0x0068D892
	private static readonly Vector4 FRAME_BORDER; // 0x00
	public const float IN_L = -100f; // Metadata: 0x0068D896
	public const float IN_R = 94f; // Metadata: 0x0068D89A
	public const float IN_B = -65f; // Metadata: 0x0068D89E
	public const float IN_T = 66f; // Metadata: 0x0068D8A2
	private const float BADGE = 36f; // Metadata: 0x0068D8A6
	private static readonly Vector2 BADGE_POS; // 0x10
	private const float BADGE2 = 18f; // Metadata: 0x0068D8AA
	private static readonly Vector2 BADGE2_POS; // 0x18
	private const float NAME_X = 17f; // Metadata: 0x0068D8AE
	private const float NAME_W = 154f; // Metadata: 0x0068D8B2
	private const float NAME_Y = 52f; // Metadata: 0x0068D8B6
	private const float NAME_H = 22f; // Metadata: 0x0068D8BA
	private const int NAME_FONT_MAX = 17; // Metadata: 0x0068D8BE
	private const int NAME_FONT_MIN = 11; // Metadata: 0x0068D8BF
	private const float LEVEL_Y = 31f; // Metadata: 0x0068D8C0
	private const float LEVEL_H = 18f; // Metadata: 0x0068D8C4
	private const int LEVEL_FONT = 13; // Metadata: 0x0068D8C8
	private static readonly Vector2 DECOR_POS; // 0x20
	private static readonly Vector2 DECOR_SIZE; // 0x28
	private const float CAPTION_Y = 11f; // Metadata: 0x0068D8C9
	private const float CAPTION_H = 15f; // Metadata: 0x0068D8CD
	private const float CAPTION_W = 80f; // Metadata: 0x0068D8D1
	private const float CAP_STATS_X = -60f; // Metadata: 0x0068D8D5
	private const float CAP_RES_X = 45f; // Metadata: 0x0068D8D9
	private const int CAPTION_FONT = 11; // Metadata: 0x0068D8DD
	private const float STAT_Y0 = -9f; // Metadata: 0x0068D8DE
	private const float STAT_PITCH = 21f; // Metadata: 0x0068D8E2
	private const float STAT_H = 21f; // Metadata: 0x0068D8E6
	private const float STAT_LBL_X = -79f; // Metadata: 0x0068D8EA
	private const float STAT_LBL_W = 42f; // Metadata: 0x0068D8EE
	private const float STAT_VAL_X = -33f; // Metadata: 0x0068D8F2
	private const float STAT_VAL_W = 56f; // Metadata: 0x0068D8F6
	private const int STAT_LBL_FONT = 13; // Metadata: 0x0068D8FA
	private const int STAT_VAL_FONT = 16; // Metadata: 0x0068D8FB
	private const int STAT_VAL_FONT_MIN = 11; // Metadata: 0x0068D8FC
	private const float RES_CENTER_Y = -30f; // Metadata: 0x0068D8FD
	private const float RES_PITCH = 26f; // Metadata: 0x0068D901
	private const float RES_ICON_X = 17f; // Metadata: 0x0068D905
	private const float RES_ICON = 24f; // Metadata: 0x0068D909
	private const float RES_TXT_X = 62f; // Metadata: 0x0068D90D
	private const float RES_TXT_W = 64f; // Metadata: 0x0068D911
	private const float RES_TXT_H = 22f; // Metadata: 0x0068D915
	private const int RES_FONT = 16; // Metadata: 0x0068D919
	private const float OUTLINE = 1.2f; // Metadata: 0x0068D91A
	public const float GAP = 10f; // Metadata: 0x0068D91E
	public const float MARGIN = 10f; // Metadata: 0x0068D922
	private const float BLOCKER_ALPHA = 0.35f; // Metadata: 0x0068D926
	public static readonly string[] ELEMENTS; // 0x30
	private static readonly Color NameColor; // 0x38
	private static readonly Color HpColor; // 0x48
	private static readonly Color AtkColor; // 0x58
	private static readonly Color ManaColor; // 0x68
	private static readonly Color GoodColor; // 0x78
	private static readonly Color CaptionColor; // 0x88
	private static readonly Color FrameInner; // 0x98
	private static readonly Color FrameFallback; // 0xA8
	private const string LEVEL_PREFIX_HEX = "FFD400FF"; // Metadata: 0x0068D92A
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
	public static bool Enabled { get; } // 0x000000018067DD00-0x000000018067DD90 
	public static bool IsShowing { get; } // 0x000000018067DD90-0x000000018067DE60 

	// Nested types
	public enum Side : byte // TypeDefIndex: 1772
	{
		Above = 0,
		Below = 1,
		Right = 2,
		Left = 3
	}

	public struct Placement // TypeDefIndex: 1773
	{
		// Fields
		public Vector2 anchoredPosition; // 0x00
		public Vector2 pivot; // 0x08
		public Side side; // 0x10
	}

	// Constructors
	public PetLibTooltipView(); // 0x000000018067DC70-0x000000018067DD00
	static PetLibTooltipView(); // 0x000000018067D9B0-0x000000018067DC70

	// Methods
	public static void Show(RectTransform anchor, PetLibDTO pet); // 0x000000018067C7E0-0x000000018067CAE0
	public static void Hide(); // 0x000000018067B7F0-0x000000018067BA00
	private static PetLibTooltipView Resolve(); // 0x000000018067C5C0-0x000000018067C740
	public static PetLibTooltipView Spawn(); // 0x000000018067CE40-0x000000018067D060
	private void Awake(); // 0x0000000180679BA0-0x0000000180679CA0
	private void OnDestroy(); // 0x000000018067C060-0x000000018067C130
	private void OnDisable(); // 0x000000018067C130-0x000000018067C1E0
	private void EnsureBuilt(); // 0x0000000180679E40-0x000000018067AE10
	private UnityEngine.UI.Text StatLabel(Transform parent, string name, int row, string text, Color color); // 0x000000018067D060-0x000000018067D180
	private UnityEngine.UI.Text StatValue(Transform parent, string name, int row, Color color); // 0x000000018067D180-0x000000018067D2D0
	private static void ApplyFrame(Image img, Sprite frame); // 0x0000000180679A10-0x0000000180679BA0
	private void Present(RectTransform anchor, PetLibDTO pet); // 0x000000018067C4A0-0x000000018067C5C0
	public void Fill(PetLibDTO pet); // 0x000000018067B470-0x000000018067B7F0
	private void FillResists(string e1); // 0x000000018067AE10-0x000000018067B470
	private static void SetIcon(Image img, Sprite sp); // 0x000000018067C740-0x000000018067C7E0
	public static string Num(int v, bool hidden); // 0x000000018067BFC0-0x000000018067C060
	private void ClosePanel(); // 0x0000000180679D10-0x0000000180679E40
	public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x000000018067CAE0-0x000000018067CE40
	private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180679CA0-0x0000000180679D10
	private bool TryAnchorRect(RectTransform anchor, out Rect rect); // 0x000000018067D590-0x000000018067D930
	private void Place(RectTransform anchor); // 0x000000018067C1E0-0x000000018067C4A0
	private static GameObject Node(Transform parent, string name, Vector2 pos, Vector2 size); // 0x000000018067BD30-0x000000018067BFC0
	private static GameObject Stretch(Transform parent, string name); // 0x000000018067D2D0-0x000000018067D590
	private static Image Icon(Transform parent, string name, Vector2 pos, Vector2 size, Sprite sp); // 0x000000018067BA00-0x000000018067BB40
	private static UnityEngine.UI.Text Label(Transform parent, string name, Vector2 pos, Vector2 size, int fontSize, Color color, TextAnchor align); // 0x000000018067BB40-0x000000018067BD30
	[CompilerGenerated]
	private void _ClosePanel_b__104_0(); // 0x000000018067D930-0x000000018067D9B0
}

