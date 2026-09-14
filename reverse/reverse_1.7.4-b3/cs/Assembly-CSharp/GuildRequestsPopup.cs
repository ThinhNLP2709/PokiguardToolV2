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

public class GuildRequestsPopup : GuildInfoPopup // TypeDefIndex: 920
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005EED3C
	private const float CARD_H = 720f; // Metadata: 0x005EED40
	private const float CARD_L_X = 64f; // Metadata: 0x005EED44
	private const float CARD_L_W = 1130f; // Metadata: 0x005EED48
	private const float CARD_R_X = 1220f; // Metadata: 0x005EED4C
	private const float CARD_R_W = 490f; // Metadata: 0x005EED50
	private const float HDR_Y = 22f; // Metadata: 0x005EED54
	private const float HDR_H = 40f; // Metadata: 0x005EED58
	private const float HDR_FS = 22f; // Metadata: 0x005EED5C
	private const float DIV_Y = 70f; // Metadata: 0x005EED60
	private const float VP_X = 24f; // Metadata: 0x005EED64
	private const float VP_Y = 80f; // Metadata: 0x005EED68
	private const float VP_W = 1082f; // Metadata: 0x005EED6C
	private const float VP_H = 536f; // Metadata: 0x005EED70
	private const float ROW_W = 1082f; // Metadata: 0x005EED74
	private const float ROW_H = 96f; // Metadata: 0x005EED78
	private const float ROW_GAP = 12f; // Metadata: 0x005EED7C
	private const int PAGE_SIZE = 5; // Metadata: 0x005EED80
	private const float PG_Y = 634f; // Metadata: 0x005EED81
	private const float PG_H = 62f; // Metadata: 0x005EED85
	private const float PG_BTN_W = 180f; // Metadata: 0x005EED89
	private const float PG_PREV_X = 24f; // Metadata: 0x005EED8D
	private const float PG_NEXT_X = 926f; // Metadata: 0x005EED91
	private const float PG_LBL_X = 220f; // Metadata: 0x005EED95
	private const float PG_LBL_W = 690f; // Metadata: 0x005EED99
	private const float C_AVA_X = 24f; // Metadata: 0x005EED9D
	private const float C_AVA_Y = 12f; // Metadata: 0x005EEDA1
	private const float C_AVA_D = 72f; // Metadata: 0x005EEDA5
	private const float C_NAME_X = 116f; // Metadata: 0x005EEDA9
	private const float C_NAME_Y = 8f; // Metadata: 0x005EEDAD
	private const float C_NAME_W = 384f; // Metadata: 0x005EEDB1
	private const float C_NAME_H = 38f; // Metadata: 0x005EEDB5
	private const float C_SUB_Y = 48f; // Metadata: 0x005EEDB9
	private const float C_SUB_H = 30f; // Metadata: 0x005EEDBD
	private const float C_WHEN_X = 520f; // Metadata: 0x005EEDC1
	private const float C_WHEN_W = 160f; // Metadata: 0x005EEDC5
	private const float C_WHEN_Y = 30f; // Metadata: 0x005EEDC9
	private const float C_WHEN_H = 36f; // Metadata: 0x005EEDCD
	private const float C_BTN_Y = 18f; // Metadata: 0x005EEDD1
	private const float C_BTN_W = 168f; // Metadata: 0x005EEDD5
	private const float C_BTN_H = 60f; // Metadata: 0x005EEDD9
	private const float C_OK_X = 700f; // Metadata: 0x005EEDDD
	private const float C_NO_X = 890f; // Metadata: 0x005EEDE1
	private const float C_DOT_X = 80f; // Metadata: 0x005EEDE5
	private const float C_DOT_Y = 8f; // Metadata: 0x005EEDE9
	private const float C_DOT_D = 20f; // Metadata: 0x005EEDED
	private const int MAX_ROWS = 100; // Metadata: 0x005EEDF1
	private const float R_PAD = 36f; // Metadata: 0x005EEDF3
	private const float R_INNER = 418f; // Metadata: 0x005EEDF7
	private const float R_SEC_Y = 22f; // Metadata: 0x005EEDFB
	private const float R_SEC_H = 40f; // Metadata: 0x005EEDFF
	private const float R_STAT_Y = 84f; // Metadata: 0x005EEE03
	private const float R_STAT_H = 44f; // Metadata: 0x005EEE07
	private const float R_LBL_Y = 150f; // Metadata: 0x005EEE0B
	private const float R_LBL_H = 32f; // Metadata: 0x005EEE0F
	private const float R_INPUT_Y = 190f; // Metadata: 0x005EEE13
	private const float R_INPUT_H = 150f; // Metadata: 0x005EEE17
	private const float R_COUNT_Y = 348f; // Metadata: 0x005EEE1B
	private const float R_COUNT_H = 28f; // Metadata: 0x005EEE1F
	private const float R_BTN_Y = 392f; // Metadata: 0x005EEE23
	private const float R_BTN_W = 340f; // Metadata: 0x005EEE27
	private const float R_BTN_H = 64f; // Metadata: 0x005EEE2B
	private const float R_CD_Y = 462f; // Metadata: 0x005EEE2F
	private const float R_CD_H = 34f; // Metadata: 0x005EEE33
	private const float R_DIV_Y = 502f; // Metadata: 0x005EEE37
	private const float R_NOTE_Y = 516f; // Metadata: 0x005EEE3B
	private const float R_NOTE_H = 196f; // Metadata: 0x005EEE3F
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color DOT_ON; // 0x20
	private static readonly Color DOT_OFF; // 0x30
	private static readonly Color INPUT_BG; // 0x40
	private static readonly Color PLACEHOLDER_DIM; // 0x50
	private GuildPanelController _owner; // 0x70
	private bool _built; // 0x78
	private bool _canManage; // 0x79
	private readonly HashSet<long> _resolving; // 0x80
	private Coroutine _cdCo; // 0x88
	private RectTransform _listContent; // 0x90
	private ScrollRect _scroll; // 0x98
	private UnityEngine.UI.Text _txtEmpty; // 0xA0
	private UnityEngine.UI.Text _hdrAction; // 0xA8
	private readonly List<RowUi> _pool; // 0xB0
	private readonly List<GuildRequestItem> _items; // 0xB8
	private int _page; // 0xC0
	private long _serverNowSec; // 0xC8
	private Button _btnPrev; // 0xD0
	private Button _btnNext; // 0xD8
	private UnityEngine.UI.Text _txtPage; // 0xE0
	private RectTransform _recruitBox; // 0xE8
	private UnityEngine.UI.Text _statPending; // 0xF0
	private InputField _input; // 0xF8
	private UnityEngine.UI.Text _txtCounter; // 0x100
	private UnityEngine.UI.Text _txtCd; // 0x108
	private UnityEngine.UI.Text _txtNoRight; // 0x110
	private Button _btnRecruit; // 0x118
	private UnityEngine.UI.Text _txtRecruitLabel; // 0x120
	private GuildGuidePopup _guide; // 0x128

	// Nested types
	private class RowUi // TypeDefIndex: 921
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public Image dot; // 0x20
		public UnityEngine.UI.Text name; // 0x28
		public UnityEngine.UI.Text sub; // 0x30
		public UnityEngine.UI.Text when; // 0x38
		public Button ok; // 0x40
		public Button no; // 0x48
		public GuildRequestItem data; // 0x50

		// Constructors
		public RowUi(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 922
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__112_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805A6530-0x00000001805A65D0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__112_0(string err); // 0x00000001805A65D0-0x00000001805A6640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass119_0 // TypeDefIndex: 923
	{
		// Fields
		public GuildRequestsPopup __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass119_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x00000001805A6640-0x00000001805A6700
		internal void _BuildRow_b__1(); // 0x00000001805A6700-0x00000001805A67C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass123_0 // TypeDefIndex: 924
	{
		// Fields
		public GuildRequestsPopup __4__this; // 0x10
		public GuildRequestItem it; // 0x18
		public bool accept; // 0x20

		// Constructors
		public __c__DisplayClass123_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Resolve_b__0(GuildActionData d); // 0x00000001805A67C0-0x00000001805A6B00
		internal void _Resolve_b__1(); // 0x00000001805A6B00-0x00000001805A6BA0
	}

	[CompilerGenerated]
	private sealed class _CountdownLoop_d__128 : IEnumerator<object> // TypeDefIndex: 925
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildRequestsPopup __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CountdownLoop_d__128(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001805A6BA0-0x00000001805A7020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A7020-0x00000001805A7060
	}

	// Constructors
	public GuildRequestsPopup(); // 0x00000001805A5FD0-0x00000001805A6270
	static GuildRequestsPopup(); // 0x00000001805A6270-0x00000001805A6370

	// Methods
	public void Open(GuildPanelController owner); // 0x000000018059EBD0-0x000000018059ED70
	public override void Hide(); // 0x000000018059ED70-0x000000018059ED90
	protected override void OnDisable(); // 0x000000018059ED90-0x000000018059EDD0
	public void RaiseChildren(); // 0x000000018059EDD0-0x000000018059EED0
	public void HideChildren(); // 0x000000018059EED0-0x000000018059EFD0
	private void Build(); // 0x000000018059EFD0-0x000000018059F440
	private void BuildHeader(RectTransform card); // 0x000000018059F440-0x000000018059F7F0
	private UnityEngine.UI.Text Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x000000018059F7F0-0x000000018059F8F0
	private void BuildList(RectTransform card); // 0x000000018059F8F0-0x00000001805A02A0
	private void BuildPager(RectTransform card); // 0x00000001805A02A0-0x00000001805A0820
	private void BuildRecruitCard(RectTransform card); // 0x00000001805A0820-0x00000001805A15B0
	private void BuildInput(RectTransform host); // 0x00000001805A15B0-0x00000001805A1FF0
	private void OnNoteChanged(string v); // 0x00000001805A1FF0-0x00000001805A2140
	public void Reload(); // 0x00000001805A2140-0x00000001805A2430
	private void Render(GuildRequestsData d); // 0x00000001805A2430-0x00000001805A2DC0
	private static int PageCount(int n); // 0x00000001805A2DC0-0x00000001805A2DF0
	private void GoPage(int page); // 0x00000001805A2DF0-0x00000001805A2EB0
	private void RenderPage(); // 0x00000001805A2EB0-0x00000001805A32C0
	private void UpdatePager(int n); // 0x00000001805A32C0-0x00000001805A35C0
	private RowUi EnsureRow(int index); // 0x00000001805A35C0-0x00000001805A38B0
	private RowUi BuildRow(int index); // 0x00000001805A38B0-0x00000001805A4610
	private void BindRow(RowUi r, GuildRequestItem it, int index, long now); // 0x00000001805A4610-0x00000001805A4C00
	private static string SubLine(GuildRequestItem it); // 0x00000001805A4C00-0x00000001805A4D80
	private static string WhenLine(GuildRequestItem it, long now); // 0x00000001805A4D80-0x00000001805A4EB0
	private void Resolve(GuildRequestItem it, Func<int, string> urlOf, bool accept); // 0x00000001805A4EB0-0x00000001805A5270
	private void SetRowEnabled(long userId, bool on); // 0x00000001805A5270-0x00000001805A5370
	private void OnClickRecruit(); // 0x00000001805A5370-0x00000001805A5730
	private void StartCountdown(long remainSec); // 0x00000001805A5730-0x00000001805A5B00
	private static string CdText(long sec); // 0x00000001805A5B00-0x00000001805A5BE0
	[IteratorStateMachine(typeof(_CountdownLoop_d__128))]
	private IEnumerator CountdownLoop(long seconds); // 0x00000001805A5BE0-0x00000001805A5CA0
	private void StopCountdown(); // 0x00000001805A5CA0-0x00000001805A5D20
	private void OnClickHelp(); // 0x00000001805A5D20-0x00000001805A5FD0
	[CompilerGenerated]
	private void _BuildPager_b__108_0(); // 0x00000001805A6370-0x00000001805A6380
	[CompilerGenerated]
	private void _BuildPager_b__108_1(); // 0x00000001805A6380-0x00000001805A6390
	[CompilerGenerated]
	private void _OnClickRecruit_b__125_0(GuildRequestsData d); // 0x00000001805A6390-0x00000001805A64C0
	[CompilerGenerated]
	private void _OnClickRecruit_b__125_1(); // 0x00000001805A64C0-0x00000001805A6530
}

