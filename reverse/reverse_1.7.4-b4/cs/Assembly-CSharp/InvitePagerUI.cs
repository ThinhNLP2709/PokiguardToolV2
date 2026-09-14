/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class InvitePagerUI : MonoBehaviour // TypeDefIndex: 44
{
	// Fields
	public const int PAGE_SIZE = 10; // Metadata: 0x005EE9B5
	private const string ROOT_NAME = "pagerBar"; // Metadata: 0x005EE9B6
	private const float BAR_H = 30f; // Metadata: 0x005EE9BF
	private const float BAR_GAP = 4f; // Metadata: 0x005EE9C3
	private const float LIST_GAP = 4f; // Metadata: 0x005EE9C7
	private const float BTN = 28f; // Metadata: 0x005EE9CB
	private const string SPR_PREV = "Image/Common/btnPrePet0001"; // Metadata: 0x005EE9CF
	private const string SPR_NEXT = "Image/Common/btnNextPet0001"; // Metadata: 0x005EE9EA
	private const float ROW_H = 86.6f; // Metadata: 0x005EEA06
	private const float ROW_H_MIN = 78f; // Metadata: 0x005EEA0A
	private const float GRID_SPACING_Y = 2f; // Metadata: 0x005EEA0E
	private const float SCREEN_MARGIN_Y = 4f; // Metadata: 0x005EEA12
	private const float PANEL_MAX_H = 602f; // Metadata: 0x005EEA16
	private const float PANEL_MAX_W = 990f; // Metadata: 0x005EEA1A
	private const float SCREEN_MARGIN_X = 40f; // Metadata: 0x005EEA1E
	private const float FRAME_RESERVE_X = 64f; // Metadata: 0x005EEA22
	private const float FRAME_RESERVE_Y = 40f; // Metadata: 0x005EEA26
	private const float ROW_W = 316.7f; // Metadata: 0x005EEA2A
	private const float GRID_SPACING_X = 10f; // Metadata: 0x005EEA2E
	private const float GRID_PAD = 4f; // Metadata: 0x005EEA32
	private const int ROWS_WANTED = 4; // Metadata: 0x005EEA36
	private const int COLS_WANTED = 2; // Metadata: 0x005EEA37
	private const string SPR_PANEL_BG = "Image/Poky/PanelFramePoky"; // Metadata: 0x005EEA38
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
	private const int SORT_HEADROOM = 12; // Metadata: 0x005EEA52
	private const int SORT_SYSTEM_MIN = 100; // Metadata: 0x005EEA53
	private const string EXTERNAL_CLOSE = "btnOFFInvite"; // Metadata: 0x005EEA55
	private const int MIN_ROWS_PER_PAGE = 2; // Metadata: 0x005EEA62
	private const string FRAME_NODE = "pokyFrame"; // Metadata: 0x005EEA63
	private const float FRAME_PAD_X = 20f; // Metadata: 0x005EEA6D
	private const float FRAME_PAD_BOTTOM = 12f; // Metadata: 0x005EEA71
	private const float FRAME_PAD_TOP = 24f; // Metadata: 0x005EEA75
	private float _headerH; // 0x4C

	// Properties
	public Button BtnPrev { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public Button BtnNext { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA510-0x00000001802BA570
	public UnityEngine.UI.Text TxtPageInfo { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA570-0x00000001802BA5D0
	public UnityEngine.UI.Text TxtTotal { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x00000001802BA5E0-0x00000001802BA640
	public ScrollRect Scroll { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA640-0x00000001802BA650 0x00000001802BA650-0x00000001802BA6B0
	public int PageSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA6B0-0x00000001802BA6C0 0x00000001802BA6C0-0x00000001802BA6D0
	private static bool ExpandEnabled { get; } // 0x00000001802BDF50-0x00000001802BDFA0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 45
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bounce_b__0(); // 0x00000001802C3560-0x00000001802C36E0
	}

	// Constructors
	public InvitePagerUI(); // 0x00000001802C3510-0x00000001802C3560

	// Methods
	public static InvitePagerUI EnsureAttached(Component listOwner); // 0x00000001802BA6D0-0x00000001802BA970
	private void EnsureBuilt(ScrollRect scroll); // 0x00000001802BA970-0x00000001802BAE00
	private void OnEnable(); // 0x00000001802BAE00-0x00000001802BAE60
	private static void RaiseAboveRoom(RectTransform frame); // 0x00000001802BAE60-0x00000001802BBED0
	private static RectTransform FindExternalClose(RectTransform host); // 0x00000001802BBED0-0x00000001802BC1F0
	private static void PlaceExternalCloseButton(RectTransform frame); // 0x00000001802BC1F0-0x00000001802BC9B0
	private static void ClampClusterInsideCanvas(RectTransform frame); // 0x00000001802BC9B0-0x00000001802BD3A0
	private void ComputePageSize(ScrollRect scroll, RectTransform frame); // 0x00000001802BD3A0-0x00000001802BDF50
	private void BuildBar(ScrollRect scroll, RectTransform frame); // 0x00000001802BDFA0-0x00000001802BE560
	private void ExpandPanel(RectTransform frame); // 0x00000001802BE560-0x00000001802BF270
	private static void MoveClusterToCanvasCenter(RectTransform frame, RectTransform canvasRect); // 0x00000001802BF270-0x00000001802BFA30
	private static void ShiftSiblingsWithPanel(RectTransform frame, Vector3 panelCenterBefore, float dW, float dH); // 0x00000001802BFA30-0x00000001802C0240
	private static void BuildPokyFrame(RectTransform panel); // 0x00000001802C0240-0x00000001802C0F20
	private void ReserveSpaceForBar(ScrollRect scroll); // 0x00000001802C0F20-0x00000001802C1110
	private void ApplyViewportTop(ScrollRect scroll); // 0x00000001802C1110-0x00000001802C1310
	private void MeasureHeader(ScrollRect scroll, RectTransform frame); // 0x00000001802C1310-0x00000001802C18D0
	public void SetPage(int page, int totalPages); // 0x00000001802C18D0-0x00000001802C1C10
	public void SetTotalLabel(string text); // 0x00000001802C1C10-0x00000001802C1D40
	public void ScrollToTop(); // 0x00000001802C1D40-0x00000001802C1E60
	public static void Bounce(Button button); // 0x00000001802C1E60-0x00000001802C2150
	private static RectTransform NewNode(string name, Transform parent); // 0x00000001802C2150-0x00000001802C23C0
	private static UnityEngine.UI.Text EnsureText(RectTransform bar, string name, Font font, TextAnchor align, int size, Vector2 anchor, Vector2 pos, Vector2 dim); // 0x00000001802C23C0-0x00000001802C28F0
	private static Button EnsureArrow(RectTransform bar, string name, string spritePath, string fallbackGlyph, Font font, Vector2 pos); // 0x00000001802C28F0-0x00000001802C3250
	private static Font PickFont(RectTransform panel); // 0x00000001802C3250-0x00000001802C3510
}

