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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildMembersView : MonoBehaviour // TypeDefIndex: 718
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
	private const int ROWS_PER_FRAME = 12; // Metadata: 0x0068BA9D
	private const int PAGE_SIZE_FALLBACK = 6; // Metadata: 0x0068BA9E
	private const float ROW_H_FALLBACK = 80f; // Metadata: 0x0068BA9F
	private const string NODE_PAGER = "MemberPager"; // Metadata: 0x0068BAA3
	private const string NODE_BTN_SLOT = "btnBuySlot"; // Metadata: 0x0068BAAF
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
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 719
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass42_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseTitle_b__0(); // 0x000000018047EE70-0x000000018047EF50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass54_0 // TypeDefIndex: 720
	{
		// Fields
		public GuildMemberItem m; // 0x10

		// Constructors
		public __c__DisplayClass54_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _HandleAddFriend_b__0(); // 0x000000018047EFC0-0x000000018047F0D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 721
	{
		// Fields
		public GuildMembersView __4__this; // 0x10
		public string url; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildActionData> __9__1; // 0x28

		// Constructors
		public __c__DisplayClass55_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Act_b__0(); // 0x000000018047F0D0-0x000000018047F200
		internal void _Act_b__1(GuildActionData d); // 0x000000018047F200-0x000000018047F320
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__47 : IEnumerator<object> // TypeDefIndex: 722
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildMembersView __4__this; // 0x20
		public List<GuildMemberItem> members; // 0x28
		public int rankOffset; // 0x30
		private int _i_5__2; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FillRows_d__47(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018047D920-0x000000018047DBE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018047DBE0-0x000000018047DC20
	}

	// Constructors
	public GuildMembersView(); // 0x00000001804741B0-0x0000000180474280
	static GuildMembersView(); // 0x0000000180474150-0x00000001804741B0

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180472070-0x00000001804720A0
	private void EnsureWired(); // 0x0000000180471000-0x00000001804716E0
	public void Open(); // 0x0000000180472AA0-0x0000000180472BE0
	public void Close(); // 0x000000018046F3D0-0x000000018046F510
	private void OnDisable(); // 0x0000000180472900-0x0000000180472AA0
	private void StopFill(); // 0x0000000180473980-0x00000001804739D0
	public void Render(GuildDetailData detail); // 0x0000000180473580-0x0000000180473980
	private static int CapOf(GuildDetailData detail, int count); // 0x000000018046F3A0-0x000000018046F3D0
	private void RenderSlotButton(); // 0x00000001804733D0-0x0000000180473580
	private void EnsureSlotButton(); // 0x0000000180470510-0x0000000180471000
	private void OnClickBuySlot(); // 0x0000000180472730-0x0000000180472900
	private void BuySlot(); // 0x000000018046F110-0x000000018046F3A0
	private void PulseTitle(); // 0x0000000180472BE0-0x0000000180472E30
	private int TotalPages(); // 0x00000001804739D0-0x0000000180473A60
	private int ComputePageSize(); // 0x000000018046F510-0x000000018046F8B0
	private void RenderPage(); // 0x0000000180472E30-0x00000001804733D0
	private void GoPage(int delta); // 0x0000000180471840-0x00000001804718F0
	[IteratorStateMachine(typeof(_FillRows_d__47))]
	private IEnumerator FillRows(List<GuildMemberItem> members, int rankOffset); // 0x00000001804716E0-0x0000000180471780
	private void EnsurePager(); // 0x000000018046F8B0-0x0000000180470310
	private static Button MakePagerButton(Transform parent, string name, string glyph, Vector2 pos, UnityEngine.UI.Text sample); // 0x00000001804720A0-0x0000000180472730
	private static void FitTitle(UnityEngine.UI.Text t); // 0x0000000180471780-0x0000000180471840
	private GuildMemberRow EnsureRow(int index); // 0x0000000180470310-0x0000000180470510
	private void HandleDetail(GuildMemberItem m, RectTransform anchor); // 0x0000000180471BF0-0x0000000180471E40
	private void HandleView(GuildMemberItem m); // 0x0000000180471E40-0x0000000180472070
	private void HandleAddFriend(GuildMemberItem m); // 0x00000001804718F0-0x0000000180471BF0
	private void Act(string url, GuildMemberItem target, string confirmMsg); // 0x000000018046EFC0-0x000000018046F110
	[CompilerGenerated]
	private void _BuySlot_b__41_0(GuildBuySlotData d); // 0x0000000180473A60-0x0000000180473C80
	[CompilerGenerated]
	private void _BuySlot_b__41_1(); // 0x0000000180473C80-0x0000000180473D10
	[CompilerGenerated]
	private void _EnsurePager_b__48_0(); // 0x0000000180473D10-0x0000000180473D20
	[CompilerGenerated]
	private void _EnsurePager_b__48_1(); // 0x0000000180473D20-0x0000000180473D30
	[CompilerGenerated]
	private void _EnsurePager_b__48_2(); // 0x0000000180473D10-0x0000000180473D20
	[CompilerGenerated]
	private void _EnsurePager_b__48_3(); // 0x0000000180473D20-0x0000000180473D30
	[CompilerGenerated]
	private void _HandleDetail_b__52_0(GuildMemberItem t); // 0x0000000180473D30-0x0000000180473E90
	[CompilerGenerated]
	private void _HandleDetail_b__52_1(GuildMemberItem t); // 0x0000000180473E90-0x0000000180473FF0
	[CompilerGenerated]
	private void _HandleDetail_b__52_2(GuildMemberItem t); // 0x0000000180473FF0-0x0000000180474150
}

