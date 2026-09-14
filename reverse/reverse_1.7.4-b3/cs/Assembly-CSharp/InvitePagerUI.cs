/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class InvitePagerUI : MonoBehaviour // TypeDefIndex: 44
{
	// Fields
	public const int PAGE_SIZE = 10; // Metadata: 0x005ED5E5
	private const string ROOT_NAME = "pagerBar"; // Metadata: 0x005ED5E6
	private const float BAR_H = 30f; // Metadata: 0x005ED5EF
	private const float BAR_GAP = 4f; // Metadata: 0x005ED5F3
	private const float LIST_GAP = 4f; // Metadata: 0x005ED5F7
	private const float BTN = 28f; // Metadata: 0x005ED5FB
	private const string SPR_PREV = "Image/Common/btnPrePet0001"; // Metadata: 0x005ED5FF
	private const string SPR_NEXT = "Image/Common/btnNextPet0001"; // Metadata: 0x005ED61A
	private const float ROW_H = 86.6f; // Metadata: 0x005ED636
	private const float ROW_H_MIN = 78f; // Metadata: 0x005ED63A
	private const float GRID_SPACING_Y = 2f; // Metadata: 0x005ED63E
	private const float SCREEN_MARGIN_Y = 4f; // Metadata: 0x005ED642
	private const float PANEL_MAX_H = 602f; // Metadata: 0x005ED646
	private const float PANEL_MAX_W = 990f; // Metadata: 0x005ED64A
	private const float SCREEN_MARGIN_X = 40f; // Metadata: 0x005ED64E
	private const float FRAME_RESERVE_X = 64f; // Metadata: 0x005ED652
	private const float FRAME_RESERVE_Y = 40f; // Metadata: 0x005ED656
	private const float ROW_W = 316.7f; // Metadata: 0x005ED65A
	private const float GRID_SPACING_X = 10f; // Metadata: 0x005ED65E
	private const float GRID_PAD = 4f; // Metadata: 0x005ED662
	private const int ROWS_WANTED = 4; // Metadata: 0x005ED666
	private const int COLS_WANTED = 2; // Metadata: 0x005ED667
	private const string SPR_PANEL_BG = "Image/Poky/PanelFramePoky"; // Metadata: 0x005ED668
	[CompilerGenerated]
	private Button _BtnPrev_k__BackingField; // 0x20
	[CompilerGenerated]
	private Button _BtnNext_k__BackingField; // 0x28
	[CompilerGenerated]
	private UnityEngine.UI.Text _TxtPageInfo_k__BackingField; // 0x30
	[CompilerGenerated]
	private UnityEngine.UI.Text _TxtTotal_k__BackingField; // 0x38
	[CompilerGenerated]
	private ScrollRect _Scroll_k__BackingField; // 0x40
	[CompilerGenerated]
	private int _PageSize_k__BackingField; // 0x48
	private const int SORT_HEADROOM = 12; // Metadata: 0x005ED682
	private const int SORT_SYSTEM_MIN = 100; // Metadata: 0x005ED683
	private const string EXTERNAL_CLOSE = "btnOFFInvite"; // Metadata: 0x005ED685
	private const int MIN_ROWS_PER_PAGE = 2; // Metadata: 0x005ED692
	private const string FRAME_NODE = "pokyFrame"; // Metadata: 0x005ED693
	private const float FRAME_PAD_X = 20f; // Metadata: 0x005ED69D
	private const float FRAME_PAD_BOTTOM = 12f; // Metadata: 0x005ED6A1
	private const float FRAME_PAD_TOP = 24f; // Metadata: 0x005ED6A5
	private float _headerH; // 0x4C

	// Properties
	public Button BtnPrev { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public Button BtnNext { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA4E0-0x00000001802BA540
	public UnityEngine.UI.Text TxtPageInfo { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA540-0x00000001802BA5A0
	public UnityEngine.UI.Text TxtTotal { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x00000001802BA5B0-0x00000001802BA610
	public ScrollRect Scroll { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA610-0x00000001802BA620 0x00000001802BA620-0x00000001802BA680
	public int PageSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA680-0x00000001802BA690 0x00000001802BA690-0x00000001802BA6A0
	private static bool ExpandEnabled { get; } // 0x00000001802BDF20-0x00000001802BDF70 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 45
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bounce_b__0(); // 0x00000001802C3530-0x00000001802C36B0
	}

	// Constructors
	public InvitePagerUI(); // 0x00000001802C34E0-0x00000001802C3530

	// Methods
	public static InvitePagerUI EnsureAttached(Component listOwner); // 0x00000001802BA6A0-0x00000001802BA940
	private void EnsureBuilt(ScrollRect scroll); // 0x00000001802BA940-0x00000001802BADD0
	private void OnEnable(); // 0x00000001802BADD0-0x00000001802BAE30
	private static void RaiseAboveRoom(RectTransform frame); // 0x00000001802BAE30-0x00000001802BBEA0
	private static RectTransform FindExternalClose(RectTransform host); // 0x00000001802BBEA0-0x00000001802BC1C0
	private static void PlaceExternalCloseButton(RectTransform frame); // 0x00000001802BC1C0-0x00000001802BC980
	private static void ClampClusterInsideCanvas(RectTransform frame); // 0x00000001802BC980-0x00000001802BD370
	private void ComputePageSize(ScrollRect scroll, RectTransform frame); // 0x00000001802BD370-0x00000001802BDF20
	private void BuildBar(ScrollRect scroll, RectTransform frame); // 0x00000001802BDF70-0x00000001802BE530
	private void ExpandPanel(RectTransform frame); // 0x00000001802BE530-0x00000001802BF240
	private static void MoveClusterToCanvasCenter(RectTransform frame, RectTransform canvasRect); // 0x00000001802BF240-0x00000001802BFA00
	private static void ShiftSiblingsWithPanel(RectTransform frame, Vector3 panelCenterBefore, float dW, float dH); // 0x00000001802BFA00-0x00000001802C0210
	private static void BuildPokyFrame(RectTransform panel); // 0x00000001802C0210-0x00000001802C0EF0
	private void ReserveSpaceForBar(ScrollRect scroll); // 0x00000001802C0EF0-0x00000001802C10E0
	private void ApplyViewportTop(ScrollRect scroll); // 0x00000001802C10E0-0x00000001802C12E0
	private void MeasureHeader(ScrollRect scroll, RectTransform frame); // 0x00000001802C12E0-0x00000001802C18A0
	public void SetPage(int page, int totalPages); // 0x00000001802C18A0-0x00000001802C1BE0
	public void SetTotalLabel(string text); // 0x00000001802C1BE0-0x00000001802C1D10
	public void ScrollToTop(); // 0x00000001802C1D10-0x00000001802C1E30
	public static void Bounce(Button button); // 0x00000001802C1E30-0x00000001802C2120
	private static RectTransform NewNode(string name, Transform parent); // 0x00000001802C2120-0x00000001802C2390
	private static UnityEngine.UI.Text EnsureText(RectTransform bar, string name, Font font, TextAnchor align, int size, Vector2 anchor, Vector2 pos, Vector2 dim); // 0x00000001802C2390-0x00000001802C28C0
	private static Button EnsureArrow(RectTransform bar, string name, string spritePath, string fallbackGlyph, Font font, Vector2 pos); // 0x00000001802C28C0-0x00000001802C3220
	private static Font PickFont(RectTransform panel); // 0x00000001802C3220-0x00000001802C34E0
}

