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

public class GuildRequestsPopup : GuildInfoPopup // TypeDefIndex: 922
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005F010A
	private const float CARD_H = 720f; // Metadata: 0x005F010E
	private const float CARD_L_X = 64f; // Metadata: 0x005F0112
	private const float CARD_L_W = 1130f; // Metadata: 0x005F0116
	private const float CARD_R_X = 1220f; // Metadata: 0x005F011A
	private const float CARD_R_W = 490f; // Metadata: 0x005F011E
	private const float HDR_Y = 22f; // Metadata: 0x005F0122
	private const float HDR_H = 40f; // Metadata: 0x005F0126
	private const float HDR_FS = 22f; // Metadata: 0x005F012A
	private const float DIV_Y = 70f; // Metadata: 0x005F012E
	private const float VP_X = 24f; // Metadata: 0x005F0132
	private const float VP_Y = 80f; // Metadata: 0x005F0136
	private const float VP_W = 1082f; // Metadata: 0x005F013A
	private const float VP_H = 536f; // Metadata: 0x005F013E
	private const float ROW_W = 1082f; // Metadata: 0x005F0142
	private const float ROW_H = 96f; // Metadata: 0x005F0146
	private const float ROW_GAP = 12f; // Metadata: 0x005F014A
	private const int PAGE_SIZE = 5; // Metadata: 0x005F014E
	private const float PG_Y = 634f; // Metadata: 0x005F014F
	private const float PG_H = 62f; // Metadata: 0x005F0153
	private const float PG_BTN_W = 180f; // Metadata: 0x005F0157
	private const float PG_PREV_X = 24f; // Metadata: 0x005F015B
	private const float PG_NEXT_X = 926f; // Metadata: 0x005F015F
	private const float PG_LBL_X = 220f; // Metadata: 0x005F0163
	private const float PG_LBL_W = 690f; // Metadata: 0x005F0167
	private const float C_AVA_X = 24f; // Metadata: 0x005F016B
	private const float C_AVA_Y = 12f; // Metadata: 0x005F016F
	private const float C_AVA_D = 72f; // Metadata: 0x005F0173
	private const float C_NAME_X = 116f; // Metadata: 0x005F0177
	private const float C_NAME_Y = 8f; // Metadata: 0x005F017B
	private const float C_NAME_W = 384f; // Metadata: 0x005F017F
	private const float C_NAME_H = 38f; // Metadata: 0x005F0183
	private const float C_SUB_Y = 48f; // Metadata: 0x005F0187
	private const float C_SUB_H = 30f; // Metadata: 0x005F018B
	private const float C_WHEN_X = 520f; // Metadata: 0x005F018F
	private const float C_WHEN_W = 160f; // Metadata: 0x005F0193
	private const float C_WHEN_Y = 30f; // Metadata: 0x005F0197
	private const float C_WHEN_H = 36f; // Metadata: 0x005F019B
	private const float C_BTN_Y = 18f; // Metadata: 0x005F019F
	private const float C_BTN_W = 168f; // Metadata: 0x005F01A3
	private const float C_BTN_H = 60f; // Metadata: 0x005F01A7
	private const float C_OK_X = 700f; // Metadata: 0x005F01AB
	private const float C_NO_X = 890f; // Metadata: 0x005F01AF
	private const float C_DOT_X = 80f; // Metadata: 0x005F01B3
	private const float C_DOT_Y = 8f; // Metadata: 0x005F01B7
	private const float C_DOT_D = 20f; // Metadata: 0x005F01BB
	private const int MAX_ROWS = 100; // Metadata: 0x005F01BF
	private const float R_PAD = 36f; // Metadata: 0x005F01C1
	private const float R_INNER = 418f; // Metadata: 0x005F01C5
	private const float R_SEC_Y = 22f; // Metadata: 0x005F01C9
	private const float R_SEC_H = 40f; // Metadata: 0x005F01CD
	private const float R_STAT_Y = 84f; // Metadata: 0x005F01D1
	private const float R_STAT_H = 44f; // Metadata: 0x005F01D5
	private const float R_LBL_Y = 150f; // Metadata: 0x005F01D9
	private const float R_LBL_H = 32f; // Metadata: 0x005F01DD
	private const float R_INPUT_Y = 190f; // Metadata: 0x005F01E1
	private const float R_INPUT_H = 150f; // Metadata: 0x005F01E5
	private const float R_COUNT_Y = 348f; // Metadata: 0x005F01E9
	private const float R_COUNT_H = 28f; // Metadata: 0x005F01ED
	private const float R_BTN_Y = 392f; // Metadata: 0x005F01F1
	private const float R_BTN_W = 340f; // Metadata: 0x005F01F5
	private const float R_BTN_H = 64f; // Metadata: 0x005F01F9
	private const float R_CD_Y = 462f; // Metadata: 0x005F01FD
	private const float R_CD_H = 34f; // Metadata: 0x005F0201
	private const float R_DIV_Y = 502f; // Metadata: 0x005F0205
	private const float R_NOTE_Y = 516f; // Metadata: 0x005F0209
	private const float R_NOTE_H = 196f; // Metadata: 0x005F020D
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
	private class RowUi // TypeDefIndex: 923
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
	private sealed class __c // TypeDefIndex: 924
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__112_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805A7E90-0x00000001805A7F30
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__112_0(string err); // 0x00000001805A7F30-0x00000001805A7FA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass119_0 // TypeDefIndex: 925
	{
		// Fields
		public GuildRequestsPopup __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass119_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x00000001805A7FA0-0x00000001805A8060
		internal void _BuildRow_b__1(); // 0x00000001805A8060-0x00000001805A8120
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass123_0 // TypeDefIndex: 926
	{
		// Fields
		public GuildRequestsPopup __4__this; // 0x10
		public GuildRequestItem it; // 0x18
		public bool accept; // 0x20

		// Constructors
		public __c__DisplayClass123_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Resolve_b__0(GuildActionData d); // 0x00000001805A8120-0x00000001805A8460
		internal void _Resolve_b__1(); // 0x00000001805A8460-0x00000001805A8500
	}

	[CompilerGenerated]
	private sealed class _CountdownLoop_d__128 : IEnumerator<object> // TypeDefIndex: 927
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
		private bool MoveNext(); // 0x00000001805A8500-0x00000001805A8980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A8980-0x00000001805A89C0
	}

	// Constructors
	public GuildRequestsPopup(); // 0x00000001805A7930-0x00000001805A7BD0
	static GuildRequestsPopup(); // 0x00000001805A7BD0-0x00000001805A7CD0

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805A0530-0x00000001805A06D0
	public override void Hide(); // 0x00000001805A06D0-0x00000001805A06F0
	protected override void OnDisable(); // 0x00000001805A06F0-0x00000001805A0730
	public void RaiseChildren(); // 0x00000001805A0730-0x00000001805A0830
	public void HideChildren(); // 0x00000001805A0830-0x00000001805A0930
	private void Build(); // 0x00000001805A0930-0x00000001805A0DA0
	private void BuildHeader(RectTransform card); // 0x00000001805A0DA0-0x00000001805A1150
	private UnityEngine.UI.Text Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x00000001805A1150-0x00000001805A1250
	private void BuildList(RectTransform card); // 0x00000001805A1250-0x00000001805A1C00
	private void BuildPager(RectTransform card); // 0x00000001805A1C00-0x00000001805A2180
	private void BuildRecruitCard(RectTransform card); // 0x00000001805A2180-0x00000001805A2F10
	private void BuildInput(RectTransform host); // 0x00000001805A2F10-0x00000001805A3950
	private void OnNoteChanged(string v); // 0x00000001805A3950-0x00000001805A3AA0
	public void Reload(); // 0x00000001805A3AA0-0x00000001805A3D90
	private void Render(GuildRequestsData d); // 0x00000001805A3D90-0x00000001805A4720
	private static int PageCount(int n); // 0x00000001805A4720-0x00000001805A4750
	private void GoPage(int page); // 0x00000001805A4750-0x00000001805A4810
	private void RenderPage(); // 0x00000001805A4810-0x00000001805A4C20
	private void UpdatePager(int n); // 0x00000001805A4C20-0x00000001805A4F20
	private RowUi EnsureRow(int index); // 0x00000001805A4F20-0x00000001805A5210
	private RowUi BuildRow(int index); // 0x00000001805A5210-0x00000001805A5F70
	private void BindRow(RowUi r, GuildRequestItem it, int index, long now); // 0x00000001805A5F70-0x00000001805A6560
	private static string SubLine(GuildRequestItem it); // 0x00000001805A6560-0x00000001805A66E0
	private static string WhenLine(GuildRequestItem it, long now); // 0x00000001805A66E0-0x00000001805A6810
	private void Resolve(GuildRequestItem it, Func<int, string> urlOf, bool accept); // 0x00000001805A6810-0x00000001805A6BD0
	private void SetRowEnabled(long userId, bool on); // 0x00000001805A6BD0-0x00000001805A6CD0
	private void OnClickRecruit(); // 0x00000001805A6CD0-0x00000001805A7090
	private void StartCountdown(long remainSec); // 0x00000001805A7090-0x00000001805A7460
	private static string CdText(long sec); // 0x00000001805A7460-0x00000001805A7540
	[IteratorStateMachine(typeof(_CountdownLoop_d__128))]
	private IEnumerator CountdownLoop(long seconds); // 0x00000001805A7540-0x00000001805A7600
	private void StopCountdown(); // 0x00000001805A7600-0x00000001805A7680
	private void OnClickHelp(); // 0x00000001805A7680-0x00000001805A7930
	[CompilerGenerated]
	private void _BuildPager_b__108_0(); // 0x00000001805A7CD0-0x00000001805A7CE0
	[CompilerGenerated]
	private void _BuildPager_b__108_1(); // 0x00000001805A7CE0-0x00000001805A7CF0
	[CompilerGenerated]
	private void _OnClickRecruit_b__125_0(GuildRequestsData d); // 0x00000001805A7CF0-0x00000001805A7E20
	[CompilerGenerated]
	private void _OnClickRecruit_b__125_1(); // 0x00000001805A7E20-0x00000001805A7E90
}

