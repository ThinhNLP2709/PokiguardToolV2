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

public class GuildHornPopup : GuildInfoPopup // TypeDefIndex: 957
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005F0466
	private const float CARD_H = 720f; // Metadata: 0x005F046A
	private const float CARD_L_X = 64f; // Metadata: 0x005F046E
	private const float CARD_L_W = 1100f; // Metadata: 0x005F0472
	private const float CARD_R_X = 1190f; // Metadata: 0x005F0476
	private const float CARD_R_W = 520f; // Metadata: 0x005F047A
	private const float HDR_Y = 22f; // Metadata: 0x005F047E
	private const float HDR_H = 40f; // Metadata: 0x005F0482
	private const float HDR_FS = 22f; // Metadata: 0x005F0486
	private const float DIV_Y = 70f; // Metadata: 0x005F048A
	private const float VP_X = 24f; // Metadata: 0x005F048E
	private const float VP_Y = 80f; // Metadata: 0x005F0492
	private const float VP_W = 1052f; // Metadata: 0x005F0496
	private const float VP_H = 616f; // Metadata: 0x005F049A
	private const float ROW_W = 1052f; // Metadata: 0x005F049E
	private const float ROW_H = 124f; // Metadata: 0x005F04A2
	private const float ROW_GAP = 6f; // Metadata: 0x005F04A6
	private const float C_ICON_X = 18f; // Metadata: 0x005F04AA
	private const float C_ICON_Y = 14f; // Metadata: 0x005F04AE
	private const float C_ICON_D = 64f; // Metadata: 0x005F04B2
	private const float C_NAME_X = 96f; // Metadata: 0x005F04B6
	private const float C_NAME_Y = 10f; // Metadata: 0x005F04BA
	private const float C_NAME_W = 600f; // Metadata: 0x005F04BE
	private const float C_NAME_H = 36f; // Metadata: 0x005F04C2
	private const float C_WHEN_X = 716f; // Metadata: 0x005F04C6
	private const float C_WHEN_Y = 12f; // Metadata: 0x005F04CA
	private const float C_WHEN_W = 314f; // Metadata: 0x005F04CE
	private const float C_WHEN_H = 32f; // Metadata: 0x005F04D2
	private const float C_MSG_X = 96f; // Metadata: 0x005F04D6
	private const float C_MSG_Y = 48f; // Metadata: 0x005F04DA
	private const float C_MSG_W = 934f; // Metadata: 0x005F04DE
	private const float C_MSG_H = 68f; // Metadata: 0x005F04E2
	private const int MAX_ROWS = 50; // Metadata: 0x005F04E6
	private const int ROWS_PER_FRAME = 8; // Metadata: 0x005F04E7
	private const float R_PAD = 36f; // Metadata: 0x005F04E8
	private const float R_INNER = 448f; // Metadata: 0x005F04EC
	private const float R_SEC_Y = 22f; // Metadata: 0x005F04F0
	private const float R_SEC_H = 40f; // Metadata: 0x005F04F4
	private const float R_STAT1_Y = 80f; // Metadata: 0x005F04F8
	private const float R_STAT2_Y = 126f; // Metadata: 0x005F04FC
	private const float R_STAT_H = 42f; // Metadata: 0x005F0500
	private const float R_LBL_Y = 184f; // Metadata: 0x005F0504
	private const float R_LBL_H = 32f; // Metadata: 0x005F0508
	private const float R_INPUT_Y = 220f; // Metadata: 0x005F050C
	private const float R_INPUT_H = 150f; // Metadata: 0x005F0510
	private const float R_COUNT_Y = 374f; // Metadata: 0x005F0514
	private const float R_COUNT_H = 28f; // Metadata: 0x005F0518
	private const float R_BTN_Y = 410f; // Metadata: 0x005F051C
	private const float R_BTN_W = 340f; // Metadata: 0x005F0520
	private const float R_BTN_H = 64f; // Metadata: 0x005F0524
	private const float R_CD_Y = 480f; // Metadata: 0x005F0528
	private const float R_CD_H = 34f; // Metadata: 0x005F052C
	private const float R_DIV_Y = 524f; // Metadata: 0x005F0530
	private const float R_NOTE_Y = 536f; // Metadata: 0x005F0534
	private const float R_NOTE_H = 176f; // Metadata: 0x005F0538
	private const int FALLBACK_MAX = 100; // Metadata: 0x005F053C
	private const int FALLBACK_MIN = 2; // Metadata: 0x005F053E
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
	private int MaxChars { get; } // 0x00000001805D9E70-0x00000001805D9EA0 
	private int MinChars { get; } // 0x00000001805D9EA0-0x00000001805D9ED0 

	// Nested types
	private class RowUi // TypeDefIndex: 958
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
	private sealed class __c // TypeDefIndex: 959
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__101_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805DD5A0-0x00000001805DD640
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__101_0(string err); // 0x00000001805DD640-0x00000001805DD6B0
	}

	[CompilerGenerated]
	private sealed class _CooldownLoop_d__109 : IEnumerator<object> // TypeDefIndex: 960
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
		private bool MoveNext(); // 0x00000001805DD6B0-0x00000001805DD8A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DD8A0-0x00000001805DD8E0
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__103 : IEnumerator<object> // TypeDefIndex: 961
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805DD8E0-0x00000001805DDC20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DDC20-0x00000001805DDC60
	}

	[CompilerGenerated]
	private sealed class _ReloadSoon_d__90 : IEnumerator<object> // TypeDefIndex: 962
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805DDC60-0x00000001805DDDB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DDDB0-0x00000001805DDDF0
	}

	// Constructors
	public GuildHornPopup(); // 0x00000001805DD150-0x00000001805DD2B0
	static GuildHornPopup(); // 0x00000001805DD2B0-0x00000001805DD360

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805D6F00-0x00000001805D7090
	private void OnEnable(); // 0x00000001805D7090-0x00000001805D7290
	public override void Hide(); // 0x00000001805D7290-0x00000001805D72B0
	protected override void OnDisable(); // 0x00000001805D72B0-0x00000001805D7370
	private void StopAll(); // 0x00000001805D7370-0x00000001805D74F0
	private void HandleAnnounce(ChatMessageDTO _); // 0x00000001805D74F0-0x00000001805D76D0
	[IteratorStateMachine(typeof(_ReloadSoon_d__90))]
	private IEnumerator ReloadSoon(); // 0x00000001805D76D0-0x00000001805D7770
	private void Build(); // 0x00000001805D7770-0x00000001805D7C80
	private void BuildList(RectTransform card); // 0x00000001805D7C80-0x00000001805D8530
	private void BuildSendCard(RectTransform card); // 0x00000001805D8530-0x00000001805D9340
	private static string NoteText(int ttlHours); // 0x00000001805D9340-0x00000001805D9430
	private void BuildInput(RectTransform host); // 0x00000001805D9430-0x00000001805D9E70
	private void OnTextChanged(string v); // 0x00000001805D9ED0-0x00000001805DA050
	public void Reload(); // 0x00000001805DA050-0x00000001805DA3D0
	public void Render(GuildHornState d); // 0x00000001805DA3D0-0x00000001805DB1B0
	[IteratorStateMachine(typeof(_FillRows_d__103))]
	private IEnumerator FillRows(List<GuildHornItem> items, int n, long now, long sentId); // 0x00000001805DB1B0-0x00000001805DB2F0
	private RowUi EnsureRow(int index); // 0x00000001805DB2F0-0x00000001805DB5E0
	private RowUi BuildRow(int index); // 0x00000001805DB5E0-0x00000001805DBE10
	private void BindRow(RowUi r, GuildHornItem it, int index, long now, long sentId); // 0x00000001805DBE10-0x00000001805DC0A0
	private static string WhenLine(long at, long now); // 0x00000001805DC0A0-0x00000001805DC2F0
	private void StartCooldown(long remainSec); // 0x00000001805DC2F0-0x00000001805DC550
	[IteratorStateMachine(typeof(_CooldownLoop_d__109))]
	private IEnumerator CooldownLoop(); // 0x00000001805DC550-0x00000001805DC5F0
	private void RefreshSendState(); // 0x00000001805DC5F0-0x00000001805DCB10
	private void OnClickSend(); // 0x00000001805DCB10-0x00000001805DD150
	[CompilerGenerated]
	private void _OnClickSend_b__111_0(GuildHornState d); // 0x00000001805DD360-0x00000001805DD570
	[CompilerGenerated]
	private void _OnClickSend_b__111_1(); // 0x00000001805DD570-0x00000001805DD5A0
}

