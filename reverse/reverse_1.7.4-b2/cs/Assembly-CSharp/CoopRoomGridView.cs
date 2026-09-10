/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class CoopRoomGridView : MonoBehaviour // TypeDefIndex: 15
{
	// Fields
	public const int PAGE_SIZE = 20; // Metadata: 0x0068A8C5
	public const int SORTING_ORDER = 940; // Metadata: 0x0068A8C6
	[CompilerGenerated]
	private Action OnCloseClicked; // 0x20
	[CompilerGenerated]
	private Action OnRefreshClicked; // 0x28
	[CompilerGenerated]
	private Action<string, int, int> OnJoinClicked; // 0x30
	private RectTransform _gridRt; // 0x38
	private GridLayoutGroup _grid; // 0x40
	private UnityEngine.UI.Text _txtStatus; // 0x48
	private UnityEngine.UI.Text _txtPage; // 0x50
	private UnityEngine.UI.Text _txtCount; // 0x58
	private Button _btnPrev; // 0x60
	private Button _btnNext; // 0x68
	private readonly List<CoopRoomCardUI> _cards; // 0x70
	private List<RoomSummaryDTO> _rooms; // 0x78
	private int _page; // 0x80
	private string _status; // 0x88
	private Vector2 _laidOutSize; // 0x90

	// Properties
	public int Page { get; } // 0x00000001802F5BF0-0x00000001802F5C00 
	public int PageCount { get; } // 0x00000001802F5BB0-0x00000001802F5BF0 

	// Events
	public event Action OnCloseClicked {
		add; // 0x00000001802F59B0-0x00000001802F5A50
		remove; // 0x00000001802F5C00-0x00000001802F5CA0
	}
	public event Action OnRefreshClicked {
		add; // 0x00000001802F5B10-0x00000001802F5BB0
		remove; // 0x00000001802F5D60-0x00000001802F5E00
	}
	public event Action<string, int, int> OnJoinClicked {
		add; // 0x00000001802F5A50-0x00000001802F5B10
		remove; // 0x00000001802F5CA0-0x00000001802F5D60
	}

	// Constructors
	public CoopRoomGridView(); // 0x00000001802F58D0-0x00000001802F59B0

	// Methods
	public static CoopRoomGridView Create(Transform canvasRoot); // 0x00000001802F4540-0x00000001802F4610
	private void Build(); // 0x00000001802F2A60-0x00000001802F4540
	public void Show(); // 0x00000001802F5720-0x00000001802F5790
	public void Hide(); // 0x00000001802F4D60-0x00000001802F4DB0
	public void SetRooms(List<RoomSummaryDTO> rooms); // 0x00000001802F5610-0x00000001802F56C0
	public void SetStatus(string text); // 0x00000001802F56C0-0x00000001802F5720
	public void GoTo(int page); // 0x00000001802F4CF0-0x00000001802F4D60
	public string DescribeLayout(); // 0x00000001802F4610-0x00000001802F4CF0
	private void LateUpdate(); // 0x00000001802F4DB0-0x00000001802F4EB0
	private void Relayout(); // 0x00000001802F4F90-0x00000001802F5260
	private void RenderPage(); // 0x00000001802F5260-0x00000001802F5610
	private void RefreshStatus(); // 0x00000001802F4ED0-0x00000001802F4F90
	private void RaiseJoin(string roomId, int enemyPetId, int enemyPetLevel); // 0x00000001802F4EB0-0x00000001802F4ED0
	[CompilerGenerated]
	private void _Build_b__28_0(); // 0x00000001802F5790-0x00000001802F57B0
	[CompilerGenerated]
	private void _Build_b__28_1(); // 0x00000001802F57B0-0x00000001802F57D0
	[CompilerGenerated]
	private void _Build_b__28_2(); // 0x00000001802F57D0-0x00000001802F5850
	[CompilerGenerated]
	private void _Build_b__28_3(); // 0x00000001802F5850-0x00000001802F58D0
}

