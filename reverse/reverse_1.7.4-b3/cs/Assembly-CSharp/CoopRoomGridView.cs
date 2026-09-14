/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class CoopRoomGridView : MonoBehaviour // TypeDefIndex: 16
{
	// Fields
	public const int PAGE_SIZE = 20; // Metadata: 0x005ED391
	public const int COLS = 5; // Metadata: 0x005ED392
	public const int SORTING_ORDER = 940; // Metadata: 0x005ED393
	private const float FRAME_W = 1774f; // Metadata: 0x005ED395
	private const float FRAME_H = 887f; // Metadata: 0x005ED399
	private const float DIM_OVERSCAN = 600f; // Metadata: 0x005ED39D
	private const float BOX_W = 1700f; // Metadata: 0x005ED3A1
	private const float BOX_H = 838f; // Metadata: 0x005ED3A5
	private const float BOX_X = 37f; // Metadata: 0x005ED3A9
	private const float BOX_Y = 25f; // Metadata: 0x005ED3AD
	private const float TITLE_Y = 16f; // Metadata: 0x005ED3B1
	private const float TITLE_H = 56f; // Metadata: 0x005ED3B5
	private const float TITLE_FS = 40f; // Metadata: 0x005ED3B9
	private const float HELP_X = 1502f; // Metadata: 0x005ED3BD
	private const float HELP_Y = 12f; // Metadata: 0x005ED3C1
	private const float HELP_D = 74f; // Metadata: 0x005ED3C5
	private const float CLOSE_X = 1600f; // Metadata: 0x005ED3C9
	private const float CLOSE_Y = 10f; // Metadata: 0x005ED3CD
	private const float CLOSE_W = 78f; // Metadata: 0x005ED3D1
	private const float CLOSE_H = 80f; // Metadata: 0x005ED3D5
	private const float DIV_X = 40f; // Metadata: 0x005ED3D9
	private const float DIV_Y = 82f; // Metadata: 0x005ED3DD
	private const float DIV_W = 1620f; // Metadata: 0x005ED3E1
	private const float GRID_X = 26f; // Metadata: 0x005ED3E5
	private const float GRID_Y = 96f; // Metadata: 0x005ED3E9
	private const float GRID_W = 1648f; // Metadata: 0x005ED3ED
	private const float GRID_H = 616f; // Metadata: 0x005ED3F1
	private const float GRID_GAP = 14f; // Metadata: 0x005ED3F5
	private const float STATUS_W = 1048f; // Metadata: 0x005ED3F9
	private const float STATUS_H = 120f; // Metadata: 0x005ED3FD
	private const float STATUS_FS = 26f; // Metadata: 0x005ED401
	private const float STATUS_X = 326f; // Metadata: 0x005ED405
	private const float STATUS_Y = 344f; // Metadata: 0x005ED409
	private const float FOOT_Y = 724f; // Metadata: 0x005ED40D
	private const float FOOT_H = 60f; // Metadata: 0x005ED411
	private const float REFRESH_X = 26f; // Metadata: 0x005ED415
	private const float REFRESH_W = 220f; // Metadata: 0x005ED419
	private const float REFRESH_FS = 26f; // Metadata: 0x005ED41D
	private const float PREV_X = 700f; // Metadata: 0x005ED421
	private const float ARROW_W = 64f; // Metadata: 0x005ED425
	private const float PAGE_X = 780f; // Metadata: 0x005ED429
	private const float PAGE_W = 140f; // Metadata: 0x005ED42D
	private const float PAGE_FS = 30f; // Metadata: 0x005ED431
	private const float NEXT_X = 934f; // Metadata: 0x005ED435
	private const float COUNT_X = 1160f; // Metadata: 0x005ED439
	private const float COUNT_Y = 730f; // Metadata: 0x005ED43D
	private const float COUNT_W = 514f; // Metadata: 0x005ED441
	private const float COUNT_H = 48f; // Metadata: 0x005ED445
	private const float COUNT_FS = 24f; // Metadata: 0x005ED449
	private const float HINT_Y = 792f; // Metadata: 0x005ED44D
	private const float HINT_H = 30f; // Metadata: 0x005ED451
	private const float HINT_FS = 22f; // Metadata: 0x005ED455
	private const string HINT_TEXT = "Ch\u1EA1m v\u00E0o m\u1ED9t th\u1EBB ph\u00F2ng \u0111\u1EC3 v\u00E0o ph\u00F2ng \u00B7 ch\u1EA1m ra ngo\u00E0i khung \u0111\u1EC3 \u0111\u00F3ng"; // Metadata: 0x005ED459
	[CompilerGenerated]
	private Action OnCloseClicked; // 0x20
	[CompilerGenerated]
	private Action OnRefreshClicked; // 0x28
	[CompilerGenerated]
	private Action<string, int, int> OnJoinClicked; // 0x30
	private RectTransform _infoRoot; // 0x38
	private RectTransform _content; // 0x40
	private RectTransform _box; // 0x48
	private RectTransform _gridRt; // 0x50
	private CanvasGroup _group; // 0x58
	private GridLayoutGroup _grid; // 0x60
	private UnityEngine.UI.Text _txtStatus; // 0x68
	private UnityEngine.UI.Text _txtPage; // 0x70
	private UnityEngine.UI.Text _txtCount; // 0x78
	private Button _btnPrev; // 0x80
	private Button _btnNext; // 0x88
	private Button _btnClose; // 0x90
	private Button _btnHelp; // 0x98
	private CoopRoomGuidePopup _guide; // 0xA0
	private readonly List<CoopRoomCardUI> _cards; // 0xA8
	private List<RoomSummaryDTO> _rooms; // 0xB0
	private int _page; // 0xB8
	private string _status; // 0xC0
	private bool _closing; // 0xC8

	// Properties
	public int Page { get; } // 0x000000018029B0F0-0x000000018029B100 
	public int PageCount { get; } // 0x000000018029B100-0x000000018029B140 

	// Events
	public event Action OnCloseClicked {
		add; // 0x000000018029AAF0-0x000000018029ABE0
		remove; // 0x000000018029ABE0-0x000000018029ACD0
	}
	public event Action OnRefreshClicked {
		add; // 0x000000018029ACD0-0x000000018029ADC0
		remove; // 0x000000018029ADC0-0x000000018029AEB0
	}
	public event Action<string, int, int> OnJoinClicked {
		add; // 0x000000018029AEB0-0x000000018029AFD0
		remove; // 0x000000018029AFD0-0x000000018029B0F0
	}

	// Constructors
	public CoopRoomGridView(); // 0x000000018029FAA0-0x000000018029FCA0

	// Methods
	public static CoopRoomGridView Create(Transform canvasRoot); // 0x000000018029B140-0x000000018029B540
	private void Build(); // 0x000000018029B540-0x000000018029C010
	private Button BuildHelpButton(); // 0x000000018029C010-0x000000018029C430
	private void BuildGrid(); // 0x000000018029C430-0x000000018029CE50
	private void BuildFooter(); // 0x000000018029CE50-0x000000018029D3F0
	public void Show(); // 0x000000018029D3F0-0x000000018029D980
	public void Hide(); // 0x000000018029D980-0x000000018029DD20
	public void SetRooms(List<RoomSummaryDTO> rooms); // 0x000000018029DD20-0x000000018029DE70
	public void SetStatus(string text); // 0x000000018029DE70-0x000000018029DF60
	public void GoTo(int page); // 0x000000018029DF60-0x000000018029DFD0
	public string DescribeLayout(); // 0x000000018029DFD0-0x000000018029EF70
	private void RequestClose(); // 0x000000018029EF70-0x000000018029F190
	private void OnHelp(); // 0x000000018029F190-0x000000018029F3C0
	private void RenderPage(); // 0x000000018029F3C0-0x000000018029F970
	private void RefreshStatus(); // 0x000000018029F970-0x000000018029FA80
	private void RaiseJoin(string roomId, int enemyPetId, int enemyPetLevel); // 0x000000018029FA80-0x000000018029FAA0
	[CompilerGenerated]
	private void _BuildFooter_b__89_0(); // 0x000000018029FCA0-0x000000018029FCC0
	[CompilerGenerated]
	private void _BuildFooter_b__89_1(); // 0x000000018029FCC0-0x000000018029FD40
	[CompilerGenerated]
	private void _BuildFooter_b__89_2(); // 0x000000018029FD40-0x000000018029FD50
	[CompilerGenerated]
	private void _RequestClose_b__96_0(); // 0x000000018029FD50-0x000000018029FEF0
}

