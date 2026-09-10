/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class InvitePagerUI : MonoBehaviour // TypeDefIndex: 43
{
	// Fields
	public const int PAGE_SIZE = 10; // Metadata: 0x0068A990
	private const string ROOT_NAME = "pagerBar"; // Metadata: 0x0068A991
	private const float BAR_H = 30f; // Metadata: 0x0068A99A
	private const float BAR_GAP = 4f; // Metadata: 0x0068A99E
	private const float LIST_GAP = 4f; // Metadata: 0x0068A9A2
	private const float BTN = 28f; // Metadata: 0x0068A9A6
	private const string SPR_PREV = "Image/Common/btnPrePet0001"; // Metadata: 0x0068A9AA
	private const string SPR_NEXT = "Image/Common/btnNextPet0001"; // Metadata: 0x0068A9C5
	private const float ROW_H = 86.6f; // Metadata: 0x0068A9E1
	private const float ROW_H_MIN = 78f; // Metadata: 0x0068A9E5
	private const float GRID_SPACING_Y = 2f; // Metadata: 0x0068A9E9
	private const float SCREEN_MARGIN_Y = 4f; // Metadata: 0x0068A9ED
	private const float PANEL_MAX_H = 602f; // Metadata: 0x0068A9F1
	private const float PANEL_MAX_W = 990f; // Metadata: 0x0068A9F5
	private const float SCREEN_MARGIN_X = 40f; // Metadata: 0x0068A9F9
	private const float FRAME_RESERVE_X = 64f; // Metadata: 0x0068A9FD
	private const float FRAME_RESERVE_Y = 40f; // Metadata: 0x0068AA01
	private const float ROW_W = 316.7f; // Metadata: 0x0068AA05
	private const float GRID_SPACING_X = 10f; // Metadata: 0x0068AA09
	private const float GRID_PAD = 4f; // Metadata: 0x0068AA0D
	private const int ROWS_WANTED = 4; // Metadata: 0x0068AA11
	private const int COLS_WANTED = 2; // Metadata: 0x0068AA12
	private const string SPR_PANEL_BG = "Image/Poky/PanelFramePoky"; // Metadata: 0x0068AA13
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
	private const int SORT_HEADROOM = 12; // Metadata: 0x0068AA2D
	private const int SORT_SYSTEM_MIN = 100; // Metadata: 0x0068AA2E
	private const string EXTERNAL_CLOSE = "btnOFFInvite"; // Metadata: 0x0068AA30
	private const int MIN_ROWS_PER_PAGE = 2; // Metadata: 0x0068AA3D
	private const string FRAME_NODE = "pokyFrame"; // Metadata: 0x0068AA3E
	private const float FRAME_PAD_X = 20f; // Metadata: 0x0068AA48
	private const float FRAME_PAD_BOTTOM = 12f; // Metadata: 0x0068AA4C
	private const float FRAME_PAD_TOP = 24f; // Metadata: 0x0068AA50
	private float _headerH; // 0x4C

	// Properties
	public Button BtnPrev { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF660-0x00000001802FF670 0x0000000180308AD0-0x0000000180308AE0
	public Button BtnNext { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF640-0x00000001802FF650 0x0000000180308AC0-0x0000000180308AD0
	public UnityEngine.UI.Text TxtPageInfo { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AA0-0x0000000180308AB0 0x0000000180308B00-0x0000000180308B10
	public UnityEngine.UI.Text TxtTotal { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20
	public ScrollRect Scroll { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308A90-0x0000000180308AA0 0x0000000180308AF0-0x0000000180308B00
	public int PageSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308A80-0x0000000180308A90 0x0000000180308AE0-0x0000000180308AF0
	private static bool ExpandEnabled { get; } // 0x0000000180308A40-0x0000000180308A80 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 44
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bounce_b__0(); // 0x0000000180317170-0x0000000180317260
	}

	// Constructors
	public InvitePagerUI(); // 0x0000000180308A30-0x0000000180308A40

	// Methods
	public static InvitePagerUI EnsureAttached(Component listOwner); // 0x0000000180305E30-0x0000000180305F60
	private void EnsureBuilt(ScrollRect scroll); // 0x0000000180305F60-0x00000001803063F0
	private void OnEnable(); // 0x0000000180307710-0x0000000180307770
	private static void RaiseAboveRoom(RectTransform frame); // 0x0000000180307C20-0x0000000180308210
	private static RectTransform FindExternalClose(RectTransform host); // 0x0000000180306CF0-0x0000000180306E20
	private static void PlaceExternalCloseButton(RectTransform frame); // 0x00000001803078F0-0x0000000180307C20
	private static void ClampClusterInsideCanvas(RectTransform frame); // 0x0000000180304EC0-0x00000001803053F0
	private void ComputePageSize(ScrollRect scroll, RectTransform frame); // 0x00000001803053F0-0x0000000180305940
	private void BuildBar(ScrollRect scroll, RectTransform frame); // 0x0000000180304640-0x00000001803049D0
	private void ExpandPanel(RectTransform frame); // 0x0000000180306660-0x0000000180306CF0
	private static void MoveClusterToCanvasCenter(RectTransform frame, RectTransform canvasRect); // 0x00000001803071D0-0x0000000180307570
	private static void ShiftSiblingsWithPanel(RectTransform frame, Vector3 panelCenterBefore, float dW, float dH); // 0x0000000180308630-0x0000000180308A30
	private static void BuildPokyFrame(RectTransform panel); // 0x00000001803049D0-0x0000000180304EC0
	private void ReserveSpaceForBar(ScrollRect scroll); // 0x0000000180308210-0x0000000180308380
	private void ApplyViewportTop(ScrollRect scroll); // 0x00000001803042F0-0x0000000180304470
	private void MeasureHeader(ScrollRect scroll, RectTransform frame); // 0x0000000180306E20-0x00000001803071D0
	public void SetPage(int page, int totalPages); // 0x0000000180308410-0x0000000180308580
	public void SetTotalLabel(string text); // 0x0000000180308580-0x0000000180308630
	public void ScrollToTop(); // 0x0000000180308380-0x0000000180308410
	public static void Bounce(Button button); // 0x0000000180304470-0x0000000180304640
	private static RectTransform NewNode(string name, Transform parent); // 0x0000000180307570-0x0000000180307710
	private static UnityEngine.UI.Text EnsureText(RectTransform bar, string name, Font font, TextAnchor align, int size, Vector2 anchor, Vector2 pos, Vector2 dim); // 0x00000001803063F0-0x0000000180306660
	private static Button EnsureArrow(RectTransform bar, string name, string spritePath, string fallbackGlyph, Font font, Vector2 pos); // 0x0000000180305940-0x0000000180305E30
	private static Font PickFont(RectTransform panel); // 0x0000000180307770-0x00000001803078F0
}

