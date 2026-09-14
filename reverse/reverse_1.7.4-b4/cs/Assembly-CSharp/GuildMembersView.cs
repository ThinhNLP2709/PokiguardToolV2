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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildMembersView : MonoBehaviour // TypeDefIndex: 819
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
	private const int ROWS_PER_FRAME = 12; // Metadata: 0x005EFF3A
	private const int PAGE_SIZE_FALLBACK = 6; // Metadata: 0x005EFF3B
	private const float ROW_H_FALLBACK = 80f; // Metadata: 0x005EFF3C
	private const string NODE_PAGER = "MemberPager"; // Metadata: 0x005EFF40
	private const string NODE_BTN_SLOT = "btnBuySlot"; // Metadata: 0x005EFF4C
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
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 820
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseTitle_b__0(); // 0x000000018054E910-0x000000018054EA70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 821
	{
		// Fields
		public GuildMemberItem m; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HandleAddFriend_b__0(); // 0x000000018054EA70-0x000000018054EB90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 822
	{
		// Fields
		public GuildMembersView __4__this; // 0x10
		public string url; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildActionData> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass55_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Act_b__0(); // 0x000000018054EB90-0x000000018054ED10
		internal void _Act_b__1(GuildActionData d); // 0x000000018054ED10-0x000000018054EE50
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__47 : IEnumerator<object> // TypeDefIndex: 823
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018054EE50-0x000000018054F390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054F390-0x000000018054F3D0
	}

	// Constructors
	public GuildMembersView(); // 0x000000018054DFC0-0x000000018054E170
	static GuildMembersView(); // 0x000000018054E170-0x000000018054E1D0

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001805466B0-0x0000000180546710
	private void EnsureWired(); // 0x0000000180546710-0x0000000180547440
	public void Open(); // 0x0000000180547440-0x00000001805476F0
	public void Close(); // 0x00000001805476F0-0x00000001805478D0
	private void OnDisable(); // 0x00000001805478D0-0x0000000180547BA0
	private void StopFill(); // 0x000000018053CF90-0x000000018053D010
	public void Render(GuildDetailData detail); // 0x0000000180547BA0-0x0000000180548020
	private static int CapOf(GuildDetailData detail, int count); // 0x0000000180548020-0x0000000180548050
	private void RenderSlotButton(); // 0x0000000180548050-0x0000000180548430
	private void EnsureSlotButton(); // 0x0000000180548430-0x0000000180549490
	private void OnClickBuySlot(); // 0x0000000180549490-0x0000000180549770
	private void BuySlot(); // 0x0000000180549770-0x0000000180549B40
	private void PulseTitle(); // 0x0000000180549B40-0x0000000180549EF0
	private int TotalPages(); // 0x0000000180549EF0-0x0000000180549F40
	private int ComputePageSize(); // 0x0000000180549F40-0x000000018054A8B0
	private void RenderPage(); // 0x000000018054A8B0-0x000000018054B2C0
	private void GoPage(int delta); // 0x000000018054B2C0-0x000000018054B420
	[IteratorStateMachine(typeof(_FillRows_d__47))]
	private IEnumerator FillRows(List<GuildMemberItem> members, int rankOffset); // 0x000000018054B420-0x000000018054B530
	private void EnsurePager(); // 0x000000018054B530-0x000000018054C410
	private static Button MakePagerButton(Transform parent, string name, string glyph, Vector2 pos, UnityEngine.UI.Text sample); // 0x000000018054C410-0x000000018054CD30
	private static void FitTitle(UnityEngine.UI.Text t); // 0x000000018054CD30-0x000000018054CF90
	private GuildMemberRow EnsureRow(int index); // 0x000000018054CF90-0x000000018054D3F0
	private void HandleDetail(GuildMemberItem m, RectTransform anchor); // 0x000000018054D3F0-0x000000018054D770
	private void HandleView(GuildMemberItem m); // 0x000000018054D770-0x000000018054DAC0
	private void HandleAddFriend(GuildMemberItem m); // 0x000000018054DAC0-0x000000018054DD10
	private void Act(string url, GuildMemberItem target, string confirmMsg); // 0x000000018054DD10-0x000000018054DFC0
	[CompilerGenerated]
	private void _BuySlot_b__41_0(GuildBuySlotData d); // 0x000000018054E1D0-0x000000018054E3C0
	[CompilerGenerated]
	private void _BuySlot_b__41_1(); // 0x000000018054E3C0-0x000000018054E4D0
	[CompilerGenerated]
	private void _EnsurePager_b__48_0(); // 0x000000018054E4D0-0x000000018054E4E0
	[CompilerGenerated]
	private void _EnsurePager_b__48_1(); // 0x000000018054E4E0-0x000000018054E4F0
	[CompilerGenerated]
	private void _EnsurePager_b__48_2(); // 0x000000018054E4D0-0x000000018054E4E0
	[CompilerGenerated]
	private void _EnsurePager_b__48_3(); // 0x000000018054E4E0-0x000000018054E4F0
	[CompilerGenerated]
	private void _HandleDetail_b__52_0(GuildMemberItem t); // 0x000000018054E4F0-0x000000018054E650
	[CompilerGenerated]
	private void _HandleDetail_b__52_1(GuildMemberItem t); // 0x000000018054E650-0x000000018054E7B0
	[CompilerGenerated]
	private void _HandleDetail_b__52_2(GuildMemberItem t); // 0x000000018054E7B0-0x000000018054E910
}

