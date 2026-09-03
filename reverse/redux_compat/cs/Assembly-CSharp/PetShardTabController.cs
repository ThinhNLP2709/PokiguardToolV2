/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class PetShardTabController : MonoBehaviour // TypeDefIndex: 678
{
	// Fields
	[Header("Root")]
	public GameObject panelShard; // 0x20
	[Header("L\u01B0\u1EDBi m\u1EA3nh \u2014 itemTemplate PH\u1EA2I inactive")]
	public Transform gridContent; // 0x28
	public GameObject itemTemplate; // 0x30
	[Header("Tr\u1EA1ng th\u00E1i r\u1ED7ng")]
	public UnityEngine.UI.Text txtEmpty; // 0x38
	[Header("T\u1ED5ng quan")]
	public UnityEngine.UI.Text txtSummary; // 0x40
	[Header("Ph\u00E2n trang \u2014 2 n\u00FAt null \u21D2 tab ch\u1EA1y ch\u1EBF \u0111\u1ED9 c\u0169 (hi\u1EC7n t\u1EA5t c\u1EA3, kh\u00F4ng ph\u00E2n trang)")]
	public Button btnPrevPage; // 0x48
	public Button btnNextPage; // 0x50
	public UnityEngine.UI.Text txtPageInfo; // 0x58
	[Header("L\u1ECDc nhanh")]
	public Button btnFilterReady; // 0x60
	public UnityEngine.UI.Text txtFilterLabel; // 0x68
	[Header("Popup x\u00E1c nh\u1EADn \u0110\u1ED4I PET \u2014 inactive m\u1EB7c \u0111\u1ECBnh, null \u21D2 \u0111\u1ED5i th\u1EB3ng kh\u00F4ng h\u1ECFi")]
	public GameObject panelConfirm; // 0x70
	public Transform confirmFrame; // 0x78
	public UnityEngine.UI.Text txtConfirm; // 0x80
	public Image imgPetConfirm; // 0x88
	public Button btnConfirmYes; // 0x90
	public Button btnConfirmNo; // 0x98
	private const int PAGE_SIZE = 8; // Metadata: 0x0064C755
	private const int MAX_APPEAR_TWEEN = 8; // Metadata: 0x0064C756
	private int _userId; // 0xA0
	private int _maxStar; // 0xA4
	private bool _wired; // 0xA8
	private bool _loading; // 0xA9
	private int _exchangeCost; // 0xAC
	private int _page; // 0xB0
	private int _readyCount; // 0xB4
	private int _upgradeCount; // 0xB8
	private int _exchangeCount; // 0xBC
	private int _totalShards; // 0xC0
	private bool _filterReady; // 0xC4
	private bool _exchanging; // 0xC5
	private PetShardDTO _pendingDto; // 0xC8
	private PetShardItemUI _pendingCell; // 0xD0
	private readonly List<PetShardDTO> _sorted; // 0xD8
	private readonly List<PetShardItemUI> _pool; // 0xE0
	private readonly List<CanvasGroup> _poolCg; // 0xE8
	private readonly List<Button> _poolBtn; // 0xF0
	private ShardSwipePager _swipe; // 0xF8

	// Properties
	private bool HasPagination { get; } // 0x00000001803CF620-0x00000001803CF6A0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 679
	{
		// Fields
		public PetShardDTO captured; // 0x10
		public PetShardTabController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass48_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RenderPage_b__0(); // 0x00000001803EF860-0x00000001803EF890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_1 // TypeDefIndex: 680
	{
		// Fields
		public PetShardDTO capturedEx; // 0x10
		public PetShardItemUI capturedCell; // 0x18
		public PetShardTabController __4__this; // 0x20

		// Constructors
		public __c__DisplayClass48_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RenderPage_b__1(); // 0x00000001803EF890-0x00000001803EF8C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 681
	{
		// Fields
		public PetShardTabController __4__this; // 0x10
		public PetShardDTO dto; // 0x18
		public PetShardItemUI cell; // 0x20

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ExchangeCo_b__0(PetExchangeResponse resp); // 0x00000001803EF8C0-0x00000001803EF900
		internal void _ExchangeCo_b__1(string err); // 0x00000001803EF900-0x00000001803EF9D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 682
	{
		// Fields
		public Image piece; // 0x10
		public Color pieceHome; // 0x18
		public GameObject petGo; // 0x28

		// Constructors
		public __c__DisplayClass68_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SuccessFxThenReload_b__0(float v); // 0x00000001803EF9D0-0x00000001803EFAA0
		internal void _SuccessFxThenReload_b__1(); // 0x00000001803EFAA0-0x00000001803EFB80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 683
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector3 home; // 0x18

		// Constructors
		public __c__DisplayClass72_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShakeCell_b__0(float t); // 0x00000001803EFC30-0x00000001803EFD30
		internal void _ShakeCell_b__1(); // 0x00000001803EFD30-0x00000001803EFDC0
	}

	[CompilerGenerated]
	private sealed class _ExchangeCo_d__66 : IEnumerator<object> // TypeDefIndex: 684
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetShardTabController __4__this; // 0x20
		public PetShardDTO dto; // 0x28
		public PetShardItemUI cell; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExchangeCo_d__66(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803EDDD0-0x00000001803EE080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EE080-0x00000001803EE0C0
	}

	[CompilerGenerated]
	private sealed class _LoadCo_d__44 : IEnumerator<object> // TypeDefIndex: 685
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetShardTabController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803EE2F0-0x00000001803EE4C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EE4C0-0x00000001803EE500
	}

	[CompilerGenerated]
	private sealed class _SuccessFxThenReload_d__68 : IEnumerator<object> // TypeDefIndex: 686
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetShardItemUI cell; // 0x20
		private __c__DisplayClass68_0 __8__1; // 0x28
		public PetShardTabController __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SuccessFxThenReload_d__68(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001803EEAD0-0x00000001803EF150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EF150-0x00000001803EF190
	}

	// Constructors
	public PetShardTabController(); // 0x00000001803CF4A0-0x00000001803CF620

	// Methods
	private void Awake(); // 0x00000001803CB3D0-0x00000001803CB3E0
	private void WireOnce(); // 0x00000001803CEF60-0x00000001803CF4A0
	public void OpenTab(); // 0x00000001803CD0F0-0x00000001803CD1A0
	public void CloseTab(); // 0x00000001803CB5C0-0x00000001803CB640
	private void Reload(); // 0x00000001803CD4C0-0x00000001803CD620
	[IteratorStateMachine(typeof(_LoadCo_d__44))]
	private IEnumerator LoadCo(); // 0x00000001803CBF40-0x00000001803CBFB0
	private void OnLoaded(PetShardListResponse resp); // 0x00000001803CCA10-0x00000001803CD0F0
	private int FilteredCount(); // 0x00000001803CB950-0x00000001803CB990
	private int TotalPages(); // 0x00000001803CEA50-0x00000001803CEAC0
	private void RenderPage(bool animate); // 0x00000001803CD620-0x00000001803CDC60
	private void EnsurePool(int target); // 0x00000001803CB640-0x00000001803CB8A0
	private void HideCell(int i); // 0x00000001803CBBA0-0x00000001803CBD80
	private void HideAllCells(); // 0x00000001803CB990-0x00000001803CBBA0
	private void ChangePage(int delta); // 0x00000001803CB500-0x00000001803CB5C0
	private void UpdatePageUI(); // 0x00000001803CEDC0-0x00000001803CEF60
	private void SetPaginationVisible(bool show); // 0x00000001803CDF10-0x00000001803CDFF0
	private void SetFilterVisible(bool show); // 0x00000001803CDDD0-0x00000001803CDDE0
	private static void SetButtonVisible(Button btn, bool show); // 0x00000001803CDCB0-0x00000001803CDDD0
	private void ToggleFilter(); // 0x00000001803CE9F0-0x00000001803CEA50
	private void UpdateFilterUI(); // 0x00000001803CEC80-0x00000001803CEDC0
	private bool CanExchange(PetShardDTO dto); // 0x00000001803CB3E0-0x00000001803CB410
	private bool IsActionable(PetShardDTO dto); // 0x00000001803CBED0-0x00000001803CBF40
	private void OnItemClicked(PetShardDTO dto); // 0x00000001803CC810-0x00000001803CCA10
	private void OnExchangeClicked(PetShardDTO dto, PetShardItemUI cell); // 0x00000001803CC210-0x00000001803CC5D0
	private void ShowConfirm(PetShardDTO dto); // 0x00000001803CE4D0-0x00000001803CE830
	private void HideConfirm(); // 0x00000001803CBD80-0x00000001803CBED0
	private void OnConfirmYes(); // 0x00000001803CBFB0-0x00000001803CC040
	[IteratorStateMachine(typeof(_ExchangeCo_d__66))]
	private IEnumerator ExchangeCo(PetShardDTO dto, PetShardItemUI cell); // 0x00000001803CB8A0-0x00000001803CB950
	private void OnExchanged(PetExchangeResponse resp, PetShardDTO dto, PetShardItemUI cell); // 0x00000001803CC5D0-0x00000001803CC810
	[IteratorStateMachine(typeof(_SuccessFxThenReload_d__68))]
	private IEnumerator SuccessFxThenReload(PetShardItemUI cell); // 0x00000001803CE960-0x00000001803CE9F0
	private void SetGridInteractable(bool on); // 0x00000001803CDDE0-0x00000001803CDF10
	private static string SafeName(PetShardDTO dto); // 0x00000001803CDC60-0x00000001803CDCB0
	private static void PunchCell(PetShardItemUI cell); // 0x00000001803CD320-0x00000001803CD4C0
	private static void ShakeCell(PetShardItemUI cell); // 0x00000001803CE240-0x00000001803CE4D0
	private void SetSummary(int totalShards); // 0x00000001803CDFF0-0x00000001803CE240
	private void ShowErrorState(string message); // 0x00000001803CE910-0x00000001803CE960
	private void ShowEmpty(string message); // 0x00000001803CE830-0x00000001803CE910
	private static void AnimateAppear(GameObject go, int slot); // 0x00000001803CB200-0x00000001803CB3D0
	private static void PunchButton(Button btn); // 0x00000001803CD1A0-0x00000001803CD320
	private void OnDisable(); // 0x00000001803CC040-0x00000001803CC210
	private static void CancelButtonTween(Button btn); // 0x00000001803CB410-0x00000001803CB500
	[CompilerGenerated]
	private void _WireOnce_b__40_0(); // 0x00000001803CEB80-0x00000001803CEBB0
	[CompilerGenerated]
	private void _WireOnce_b__40_1(); // 0x00000001803CEBB0-0x00000001803CEBE0
	[CompilerGenerated]
	private void _WireOnce_b__40_2(); // 0x00000001803CEBE0-0x00000001803CEC50
	[CompilerGenerated]
	private void _WireOnce_b__40_3(); // 0x00000001803CEC50-0x00000001803CEC80
	[CompilerGenerated]
	private void _LoadCo_b__44_0(string err); // 0x00000001803CEAC0-0x00000001803CEB80
}

