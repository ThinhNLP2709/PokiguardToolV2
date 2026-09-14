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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildMembersView : MonoBehaviour // TypeDefIndex: 818
{
	// Fields
	[SerializeField]
	private ScrollRect scroll; // 0x20
	[SerializeField]
	private RectTransform content; // 0x28
	[SerializeField]
	private GameObject rowTemplate; // 0x30
	[SerializeField]
	private GuildPermissionTooltip tooltip; // 0x38
	[SerializeField]
	private Button btnClose; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x48
	private const int ROWS_PER_FRAME = 12; // Metadata: 0x005EEB6C
	private const int PAGE_SIZE_FALLBACK = 6; // Metadata: 0x005EEB6D
	private const float ROW_H_FALLBACK = 80f; // Metadata: 0x005EEB6E
	private const string NODE_PAGER = "MemberPager"; // Metadata: 0x005EEB72
	private const string NODE_BTN_SLOT = "btnBuySlot"; // Metadata: 0x005EEB7E
	private static readonly Color SLOT_GOLD; // 0x00
	private static readonly Color SLOT_INK; // 0x10
	private readonly List<GuildMemberRow> _pool; // 0x50
	private readonly List<GuildMemberItem> _all; // 0x58
	private int _pageSize; // 0x60
	private int _page; // 0x64
	private UnityEngine.UI.Text _txtPage; // 0x68
	private Button _btnPrev; // 0x70
	private Button _btnNext; // 0x78
	private GameObject _pagerBar; // 0x80
	private GuildPanelController _owner; // 0x88
	private bool _wired; // 0x90
	private int _myRole; // 0x94
	private Coroutine _fillCo; // 0x98
	private Button _btnSlot; // 0xA0
	private GuildDetailData _detail; // 0xA8
	private bool _buyingSlot; // 0xB0
	private int _slotPrice; // 0xB4
	private int _capMax; // 0xB8

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 819
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseTitle_b__0(); // 0x000000018054D120-0x000000018054D280
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 820
	{
		// Fields
		public GuildMemberItem m; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HandleAddFriend_b__0(); // 0x000000018054D280-0x000000018054D3A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 821
	{
		// Fields
		public GuildMembersView __4__this; // 0x10
		public string url; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildActionData> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass55_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Act_b__0(); // 0x000000018054D3A0-0x000000018054D520
		internal void _Act_b__1(GuildActionData d); // 0x000000018054D520-0x000000018054D660
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__47 : IEnumerator<object> // TypeDefIndex: 822
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildMembersView __4__this; // 0x20
		public List<GuildMemberItem> members; // 0x28
		public int rankOffset; // 0x30
		private int _i_5__2; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FillRows_d__47(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018054D660-0x000000018054DBA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054DBA0-0x000000018054DBE0
	}

	// Constructors
	public GuildMembersView(); // 0x000000018054C7D0-0x000000018054C980
	static GuildMembersView(); // 0x000000018054C980-0x000000018054C9E0

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180544EC0-0x0000000180544F20
	private void EnsureWired(); // 0x0000000180544F20-0x0000000180545C50
	public void Open(); // 0x0000000180545C50-0x0000000180545F00
	public void Close(); // 0x0000000180545F00-0x00000001805460E0
	private void OnDisable(); // 0x00000001805460E0-0x00000001805463B0
	private void StopFill(); // 0x000000018053B7B0-0x000000018053B830
	public void Render(GuildDetailData detail); // 0x00000001805463B0-0x0000000180546830
	private static int CapOf(GuildDetailData detail, int count); // 0x0000000180546830-0x0000000180546860
	private void RenderSlotButton(); // 0x0000000180546860-0x0000000180546C40
	private void EnsureSlotButton(); // 0x0000000180546C40-0x0000000180547CA0
	private void OnClickBuySlot(); // 0x0000000180547CA0-0x0000000180547F80
	private void BuySlot(); // 0x0000000180547F80-0x0000000180548350
	private void PulseTitle(); // 0x0000000180548350-0x0000000180548700
	private int TotalPages(); // 0x0000000180548700-0x0000000180548750
	private int ComputePageSize(); // 0x0000000180548750-0x00000001805490C0
	private void RenderPage(); // 0x00000001805490C0-0x0000000180549AD0
	private void GoPage(int delta); // 0x0000000180549AD0-0x0000000180549C30
	[IteratorStateMachine(typeof(_FillRows_d__47))]
	private IEnumerator FillRows(List<GuildMemberItem> members, int rankOffset); // 0x0000000180549C30-0x0000000180549D40
	private void EnsurePager(); // 0x0000000180549D40-0x000000018054AC20
	private static Button MakePagerButton(Transform parent, string name, string glyph, Vector2 pos, UnityEngine.UI.Text sample); // 0x000000018054AC20-0x000000018054B540
	private static void FitTitle(UnityEngine.UI.Text t); // 0x000000018054B540-0x000000018054B7A0
	private GuildMemberRow EnsureRow(int index); // 0x000000018054B7A0-0x000000018054BC00
	private void HandleDetail(GuildMemberItem m, RectTransform anchor); // 0x000000018054BC00-0x000000018054BF80
	private void HandleView(GuildMemberItem m); // 0x000000018054BF80-0x000000018054C2D0
	private void HandleAddFriend(GuildMemberItem m); // 0x000000018054C2D0-0x000000018054C520
	private void Act(string url, GuildMemberItem target, string confirmMsg); // 0x000000018054C520-0x000000018054C7D0
	[CompilerGenerated]
	private void _BuySlot_b__41_0(GuildBuySlotData d); // 0x000000018054C9E0-0x000000018054CBD0
	[CompilerGenerated]
	private void _BuySlot_b__41_1(); // 0x000000018054CBD0-0x000000018054CCE0
	[CompilerGenerated]
	private void _EnsurePager_b__48_0(); // 0x000000018054CCE0-0x000000018054CCF0
	[CompilerGenerated]
	private void _EnsurePager_b__48_1(); // 0x000000018054CCF0-0x000000018054CD00
	[CompilerGenerated]
	private void _EnsurePager_b__48_2(); // 0x000000018054CCE0-0x000000018054CCF0
	[CompilerGenerated]
	private void _EnsurePager_b__48_3(); // 0x000000018054CCF0-0x000000018054CD00
	[CompilerGenerated]
	private void _HandleDetail_b__52_0(GuildMemberItem t); // 0x000000018054CD00-0x000000018054CE60
	[CompilerGenerated]
	private void _HandleDetail_b__52_1(GuildMemberItem t); // 0x000000018054CE60-0x000000018054CFC0
	[CompilerGenerated]
	private void _HandleDetail_b__52_2(GuildMemberItem t); // 0x000000018054CFC0-0x000000018054D120
}

