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

public class GuildHornPopup : GuildInfoPopup // TypeDefIndex: 955
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005EF099
	private const float CARD_H = 720f; // Metadata: 0x005EF09D
	private const float CARD_L_X = 64f; // Metadata: 0x005EF0A1
	private const float CARD_L_W = 1100f; // Metadata: 0x005EF0A5
	private const float CARD_R_X = 1190f; // Metadata: 0x005EF0A9
	private const float CARD_R_W = 520f; // Metadata: 0x005EF0AD
	private const float HDR_Y = 22f; // Metadata: 0x005EF0B1
	private const float HDR_H = 40f; // Metadata: 0x005EF0B5
	private const float HDR_FS = 22f; // Metadata: 0x005EF0B9
	private const float DIV_Y = 70f; // Metadata: 0x005EF0BD
	private const float VP_X = 24f; // Metadata: 0x005EF0C1
	private const float VP_Y = 80f; // Metadata: 0x005EF0C5
	private const float VP_W = 1052f; // Metadata: 0x005EF0C9
	private const float VP_H = 616f; // Metadata: 0x005EF0CD
	private const float ROW_W = 1052f; // Metadata: 0x005EF0D1
	private const float ROW_H = 124f; // Metadata: 0x005EF0D5
	private const float ROW_GAP = 6f; // Metadata: 0x005EF0D9
	private const float C_ICON_X = 18f; // Metadata: 0x005EF0DD
	private const float C_ICON_Y = 14f; // Metadata: 0x005EF0E1
	private const float C_ICON_D = 64f; // Metadata: 0x005EF0E5
	private const float C_NAME_X = 96f; // Metadata: 0x005EF0E9
	private const float C_NAME_Y = 10f; // Metadata: 0x005EF0ED
	private const float C_NAME_W = 600f; // Metadata: 0x005EF0F1
	private const float C_NAME_H = 36f; // Metadata: 0x005EF0F5
	private const float C_WHEN_X = 716f; // Metadata: 0x005EF0F9
	private const float C_WHEN_Y = 12f; // Metadata: 0x005EF0FD
	private const float C_WHEN_W = 314f; // Metadata: 0x005EF101
	private const float C_WHEN_H = 32f; // Metadata: 0x005EF105
	private const float C_MSG_X = 96f; // Metadata: 0x005EF109
	private const float C_MSG_Y = 48f; // Metadata: 0x005EF10D
	private const float C_MSG_W = 934f; // Metadata: 0x005EF111
	private const float C_MSG_H = 68f; // Metadata: 0x005EF115
	private const int MAX_ROWS = 50; // Metadata: 0x005EF119
	private const int ROWS_PER_FRAME = 8; // Metadata: 0x005EF11A
	private const float R_PAD = 36f; // Metadata: 0x005EF11B
	private const float R_INNER = 448f; // Metadata: 0x005EF11F
	private const float R_SEC_Y = 22f; // Metadata: 0x005EF123
	private const float R_SEC_H = 40f; // Metadata: 0x005EF127
	private const float R_STAT1_Y = 80f; // Metadata: 0x005EF12B
	private const float R_STAT2_Y = 126f; // Metadata: 0x005EF12F
	private const float R_STAT_H = 42f; // Metadata: 0x005EF133
	private const float R_LBL_Y = 184f; // Metadata: 0x005EF137
	private const float R_LBL_H = 32f; // Metadata: 0x005EF13B
	private const float R_INPUT_Y = 220f; // Metadata: 0x005EF13F
	private const float R_INPUT_H = 150f; // Metadata: 0x005EF143
	private const float R_COUNT_Y = 374f; // Metadata: 0x005EF147
	private const float R_COUNT_H = 28f; // Metadata: 0x005EF14B
	private const float R_BTN_Y = 410f; // Metadata: 0x005EF14F
	private const float R_BTN_W = 340f; // Metadata: 0x005EF153
	private const float R_BTN_H = 64f; // Metadata: 0x005EF157
	private const float R_CD_Y = 480f; // Metadata: 0x005EF15B
	private const float R_CD_H = 34f; // Metadata: 0x005EF15F
	private const float R_DIV_Y = 524f; // Metadata: 0x005EF163
	private const float R_NOTE_Y = 536f; // Metadata: 0x005EF167
	private const float R_NOTE_H = 176f; // Metadata: 0x005EF16B
	private const int FALLBACK_MAX = 100; // Metadata: 0x005EF16F
	private const int FALLBACK_MIN = 2; // Metadata: 0x005EF171
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color ROW_NEW; // 0x20
	private static readonly Color INPUT_BG; // 0x30
	private static readonly Color PLACEHOLDER_DIM; // 0x40
	private GuildPanelController _owner; // 0x70
	private bool _built; // 0x78
	private GuildHornState _state; // 0x80
	private bool _isMaster; // 0x88
	private long _cooldownLeft; // 0x90
	private Coroutine _fillCo; // 0x98
	private Coroutine _cdCo; // 0xA0
	private Coroutine _reloadCo; // 0xA8
	private RectTransform _listContent; // 0xB0
	private ScrollRect _scroll; // 0xB8
	private UnityEngine.UI.Text _txtEmpty; // 0xC0
	private readonly List<RowUi> _pool; // 0xC8
	private RectTransform _composeBox; // 0xD0
	private UnityEngine.UI.Text _statUsed; // 0xD8
	private UnityEngine.UI.Text _statCd; // 0xE0
	private InputField _input; // 0xE8
	private UnityEngine.UI.Text _txtCounter; // 0xF0
	private UnityEngine.UI.Text _txtCd; // 0xF8
	private UnityEngine.UI.Text _txtNoRight; // 0x100
	private UnityEngine.UI.Text _txtNote; // 0x108
	private Button _btnSend; // 0x110

	// Properties
	private int MaxChars { get; } // 0x00000001805D84F0-0x00000001805D8520 
	private int MinChars { get; } // 0x00000001805D8520-0x00000001805D8550 

	// Nested types
	private class RowUi // TypeDefIndex: 956
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public UnityEngine.UI.Text name; // 0x20
		public UnityEngine.UI.Text when; // 0x28
		public UnityEngine.UI.Text msg; // 0x30

		// Constructors
		public RowUi(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 957
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__101_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805DBC20-0x00000001805DBCC0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__101_0(string err); // 0x00000001805DBCC0-0x00000001805DBD30
	}

	[CompilerGenerated]
	private sealed class _CooldownLoop_d__109 : IEnumerator<object> // TypeDefIndex: 958
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHornPopup __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CooldownLoop_d__109(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001805DBD30-0x00000001805DBF20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DBF20-0x00000001805DBF60
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__103 : IEnumerator<object> // TypeDefIndex: 959
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHornPopup __4__this; // 0x20
		public List<GuildHornItem> items; // 0x28
		public long now; // 0x30
		public long sentId; // 0x38
		public int n; // 0x40
		private int _i_5__2; // 0x44

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FillRows_d__103(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805DBF60-0x00000001805DC2A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DC2A0-0x00000001805DC2E0
	}

	[CompilerGenerated]
	private sealed class _ReloadSoon_d__90 : IEnumerator<object> // TypeDefIndex: 960
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHornPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ReloadSoon_d__90(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805DC2E0-0x00000001805DC430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DC430-0x00000001805DC470
	}

	// Constructors
	public GuildHornPopup(); // 0x00000001805DB7D0-0x00000001805DB930
	static GuildHornPopup(); // 0x00000001805DB930-0x00000001805DB9E0

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805D5580-0x00000001805D5710
	private void OnEnable(); // 0x00000001805D5710-0x00000001805D5910
	public override void Hide(); // 0x00000001805D5910-0x00000001805D5930
	protected override void OnDisable(); // 0x00000001805D5930-0x00000001805D59F0
	private void StopAll(); // 0x00000001805D59F0-0x00000001805D5B70
	private void HandleAnnounce(ChatMessageDTO _); // 0x00000001805D5B70-0x00000001805D5D50
	[IteratorStateMachine(typeof(_ReloadSoon_d__90))]
	private IEnumerator ReloadSoon(); // 0x00000001805D5D50-0x00000001805D5DF0
	private void Build(); // 0x00000001805D5DF0-0x00000001805D6300
	private void BuildList(RectTransform card); // 0x00000001805D6300-0x00000001805D6BB0
	private void BuildSendCard(RectTransform card); // 0x00000001805D6BB0-0x00000001805D79C0
	private static string NoteText(int ttlHours); // 0x00000001805D79C0-0x00000001805D7AB0
	private void BuildInput(RectTransform host); // 0x00000001805D7AB0-0x00000001805D84F0
	private void OnTextChanged(string v); // 0x00000001805D8550-0x00000001805D86D0
	public void Reload(); // 0x00000001805D86D0-0x00000001805D8A50
	public void Render(GuildHornState d); // 0x00000001805D8A50-0x00000001805D9830
	[IteratorStateMachine(typeof(_FillRows_d__103))]
	private IEnumerator FillRows(List<GuildHornItem> items, int n, long now, long sentId); // 0x00000001805D9830-0x00000001805D9970
	private RowUi EnsureRow(int index); // 0x00000001805D9970-0x00000001805D9C60
	private RowUi BuildRow(int index); // 0x00000001805D9C60-0x00000001805DA490
	private void BindRow(RowUi r, GuildHornItem it, int index, long now, long sentId); // 0x00000001805DA490-0x00000001805DA720
	private static string WhenLine(long at, long now); // 0x00000001805DA720-0x00000001805DA970
	private void StartCooldown(long remainSec); // 0x00000001805DA970-0x00000001805DABD0
	[IteratorStateMachine(typeof(_CooldownLoop_d__109))]
	private IEnumerator CooldownLoop(); // 0x00000001805DABD0-0x00000001805DAC70
	private void RefreshSendState(); // 0x00000001805DAC70-0x00000001805DB190
	private void OnClickSend(); // 0x00000001805DB190-0x00000001805DB7D0
	[CompilerGenerated]
	private void _OnClickSend_b__111_0(GuildHornState d); // 0x00000001805DB9E0-0x00000001805DBBF0
	[CompilerGenerated]
	private void _OnClickSend_b__111_1(); // 0x00000001805DBBF0-0x00000001805DBC20
}

