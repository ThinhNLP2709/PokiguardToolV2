/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildDistributePopup : GuildInfoPopup // TypeDefIndex: 781
{
	// Fields
	private const float BOX_W = 1400f; // Metadata: 0x005EFB3C
	private const float BOX_H = 780f; // Metadata: 0x005EFB40
	private const float SUM_X = 40f; // Metadata: 0x005EFB44
	private const float SUM_Y = 84f; // Metadata: 0x005EFB48
	private const float SUM_W = 1150f; // Metadata: 0x005EFB4C
	private const float SUM_H = 40f; // Metadata: 0x005EFB50
	private const float VP_X = 40f; // Metadata: 0x005EFB54
	private const float VP_Y = 134f; // Metadata: 0x005EFB58
	private const float VP_W = 1320f; // Metadata: 0x005EFB5C
	private const float VP_H = 520f; // Metadata: 0x005EFB60
	private const float ROW_W = 1320f; // Metadata: 0x005EFB64
	private const float ROW_H = 72f; // Metadata: 0x005EFB68
	private const float ROW_GAP = 6f; // Metadata: 0x005EFB6C
	private const float C_AVA_X = 8f; // Metadata: 0x005EFB70
	private const float C_AVA_Y = 8f; // Metadata: 0x005EFB74
	private const float C_AVA_D = 56f; // Metadata: 0x005EFB78
	private const float C_NAME_X = 76f; // Metadata: 0x005EFB7C
	private const float C_NAME_Y = 4f; // Metadata: 0x005EFB80
	private const float C_NAME_W = 380f; // Metadata: 0x005EFB84
	private const float C_NAME_H = 34f; // Metadata: 0x005EFB88
	private const float C_ROLE_Y = 40f; // Metadata: 0x005EFB8C
	private const float C_ROLE_H = 28f; // Metadata: 0x005EFB90
	private const float C_MINUS_X = 620f; // Metadata: 0x005EFB94
	private const float C_BTN_Y = 8f; // Metadata: 0x005EFB98
	private const float C_BTN_W = 64f; // Metadata: 0x005EFB9C
	private const float C_BTN_H = 56f; // Metadata: 0x005EFBA0
	private const float C_AMT_X = 692f; // Metadata: 0x005EFBA4
	private const float C_AMT_W = 260f; // Metadata: 0x005EFBA8
	private const float C_PLUS_X = 960f; // Metadata: 0x005EFBAC
	private const float C_EQ_X = 1040f; // Metadata: 0x005EFBB0
	private const float FOOT_EQ_X = 40f; // Metadata: 0x005EFBB4
	private const float FOOT_Y = 668f; // Metadata: 0x005EFBB8
	private const float FOOT_EQ_W = 240f; // Metadata: 0x005EFBBC
	private const float FOOT_H = 60f; // Metadata: 0x005EFBC0
	private const float FOOT_VALID_X = 300f; // Metadata: 0x005EFBC4
	private const float FOOT_VALID_W = 700f; // Metadata: 0x005EFBC8
	private const float FOOT_GO_X = 1060f; // Metadata: 0x005EFBCC
	private const float FOOT_GO_Y = 664f; // Metadata: 0x005EFBD0
	private const float FOOT_GO_W = 300f; // Metadata: 0x005EFBD4
	private const float FOOT_GO_H = 64f; // Metadata: 0x005EFBD8
	private const int MAX_ROWS = 100; // Metadata: 0x005EFBDC
	private const int ROWS_PER_FRAME = 8; // Metadata: 0x005EFBDE
	private const float ARM_SECONDS = 4f; // Metadata: 0x005EFBDF
	private const float HOLD_DELAY = 0.4f; // Metadata: 0x005EFBE3
	private const float HOLD_TICK = 0.1f; // Metadata: 0x005EFBE7
	private const float HOLD_BOOST_AT = 2f; // Metadata: 0x005EFBEB
	private const int HOLD_BOOST = 10; // Metadata: 0x005EFBEF
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color ROW_BAD; // 0x20
	private static readonly Color BAD_EDGE; // 0x30
	private GuildPanelController _owner; // 0x70
	private GuildVaultData _data; // 0x78
	private Action<GuildVaultDistributeData> _onDone; // 0x80
	private GuildGuidePopup _guide; // 0x88
	private bool _built; // 0x90
	private bool _sending; // 0x91
	private bool _armed; // 0x92
	private Coroutine _disarmCo; // 0x98
	private Coroutine _fillCo; // 0xA0
	private readonly List<long> _shares; // 0xA8
	private readonly List<GuildVaultMember> _members; // 0xB0
	private long _step; // 0xB8
	private long _min; // 0xC0
	private long _max; // 0xC8
	private Coroutine _holdCo; // 0xD0
	private int _holdIndex; // 0xD8
	private int _holdDir; // 0xDC
	private bool _holdFired; // 0xE0
	private bool _suppressClick; // 0xE1
	private UnityEngine.UI.Text _txtSum; // 0xE8
	private UnityEngine.UI.Text _txtValid; // 0xF0
	private RectTransform _listContent; // 0xF8
	private ScrollRect _scroll; // 0x100
	private Button _btnEqualize; // 0x108
	private Button _btnGo; // 0x110
	private Image _imgGo; // 0x118
	private UnityEngine.UI.Text _txtGoLabel; // 0x120
	private readonly List<Row> _pool; // 0x128

	// Nested types
	private class Row // TypeDefIndex: 782
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public Outline edge; // 0x20
		public UnityEngine.UI.Text name; // 0x28
		public UnityEngine.UI.Text role; // 0x30
		public UnityEngine.UI.Text amount; // 0x38
		public int index; // 0x40

		// Constructors
		public Row(); // 0x000000018050C450-0x000000018050C460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass101_0 // TypeDefIndex: 783
	{
		// Fields
		public GuildDistributePopup __4__this; // 0x10
		public int index; // 0x18
		public int dir; // 0x1C

		// Constructors
		public __c__DisplayClass101_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HoldRepeat_b__0(BaseEventData _); // 0x000000018050C460-0x000000018050C640
		internal void _HoldRepeat_b__1(BaseEventData _); // 0x000000018050C640-0x000000018050C660
		internal void _HoldRepeat_b__2(BaseEventData _); // 0x000000018050C640-0x000000018050C660
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass93_0 // TypeDefIndex: 784
	{
		// Fields
		public GuildDistributePopup __4__this; // 0x10
		public int self; // 0x18

		// Constructors
		public __c__DisplayClass93_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x000000018050C660-0x000000018050C6B0
		internal void _BuildRow_b__1(); // 0x000000018050C6B0-0x000000018050C700
		internal void _BuildRow_b__2(); // 0x000000018050C700-0x000000018050C800
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__112 : IEnumerator<object> // TypeDefIndex: 785
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public GuildDistributePopup __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisarmAfter_d__112(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018050C800-0x000000018050C970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050C970-0x000000018050C9B0
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__91 : IEnumerator<object> // TypeDefIndex: 786
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildDistributePopup __4__this; // 0x20
		private int _n_5__2; // 0x28
		private int _i_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FillRows_d__91(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018050C9B0-0x000000018050CE50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050CE50-0x000000018050CE90
	}

	[CompilerGenerated]
	private sealed class _HoldLoop_d__104 : IEnumerator<object> // TypeDefIndex: 787
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildDistributePopup __4__this; // 0x20
		private int _index_5__2; // 0x28
		private int _dir_5__3; // 0x2C
		private float _held_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HoldLoop_d__104(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018050CE90-0x000000018050D030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050D030-0x000000018050D070
	}

	// Constructors
	public GuildDistributePopup(); // 0x000000018050BD10-0x000000018050C0B0
	static GuildDistributePopup(); // 0x000000018050C0B0-0x000000018050C150

	// Methods
	public void Open(GuildPanelController owner, GuildVaultData data, Action<GuildVaultDistributeData> onDone); // 0x0000000180505E60-0x00000001805060D0
	public override void Hide(); // 0x00000001805060D0-0x00000001805061F0
	protected override void OnDisable(); // 0x00000001805061F0-0x0000000180506230
	private void StopFill(); // 0x0000000180506230-0x0000000180506330
	private void Build(); // 0x0000000180506330-0x00000001805066C0
	private void BuildList(RectTransform box); // 0x00000001805066C0-0x0000000180506E40
	private void BuildFooter(RectTransform box); // 0x0000000180506E40-0x00000001805074E0
	private void Reset(GuildVaultData d); // 0x00000001805074E0-0x0000000180507830
	private static long StepFor(long equalShare); // 0x0000000180507830-0x0000000180507890
	private long Clamp(long v); // 0x0000000180507890-0x00000001805078C0
	private void FillRowsSafely(); // 0x00000001805078C0-0x0000000180507A70
	[IteratorStateMachine(typeof(_FillRows_d__91))]
	private IEnumerator FillRows(); // 0x0000000180507A70-0x0000000180507B10
	private Row EnsureRow(int index); // 0x0000000180507B10-0x0000000180507E00
	private Row BuildRow(int index); // 0x0000000180507E00-0x0000000180508A70
	private void BindRow(Row r, int index); // 0x0000000180508A70-0x0000000180508C40
	private void RenderAmount(Row r, int index); // 0x0000000180508C40-0x0000000180508F40
	private Row RowOf(int index); // 0x0000000180508F40-0x0000000180508FA0
	private void Tap(int index, int dir); // 0x0000000180508FA0-0x0000000180508FE0
	private void Step(int index, int dir, int mult); // 0x0000000180508FE0-0x00000001805090F0
	private void ResetOne(int index); // 0x00000001805090F0-0x00000001805091F0
	private void Equalize(); // 0x00000001805091F0-0x0000000180509380
	private void HoldRepeat(Button btn, int index, int dir); // 0x0000000180509380-0x0000000180509900
	private void StartHold(int index, int dir); // 0x0000000180509900-0x0000000180509AC0
	private void StopHold(); // 0x0000000180509AC0-0x0000000180509BF0
	[IteratorStateMachine(typeof(_HoldLoop_d__104))]
	private IEnumerator HoldLoop(); // 0x0000000180509BF0-0x0000000180509C90
	private void RenderAll(); // 0x0000000180509C90-0x0000000180509D40
	private long Sum(); // 0x0000000180509D40-0x0000000180509DC0
	private void RenderSummary(); // 0x0000000180509DC0-0x000000018050A210
	private bool Validate(out string reason); // 0x000000018050A210-0x000000018050A730
	private void RenderGoButton(bool ok); // 0x000000018050A730-0x000000018050AA70
	private void OnClickHelp(); // 0x000000018050AA70-0x000000018050AE30
	private void OnClickGo(); // 0x000000018050AE30-0x000000018050B1E0
	[IteratorStateMachine(typeof(_DisarmAfter_d__112))]
	private IEnumerator DisarmAfter(float sec); // 0x000000018050B1E0-0x000000018050B2A0
	private void Disarm(); // 0x000000018050B2A0-0x000000018050B3B0
	private void Send(); // 0x000000018050B3B0-0x000000018050BA70
	private void Done(GuildVaultDistributeData d); // 0x000000018050BA70-0x000000018050BBE0
	public bool SetShareForTest(long userId, long gold); // 0x000000018050BBE0-0x000000018050BD10
	[CompilerGenerated]
	private void _Send_b__114_0(GuildVaultDistributeData d); // 0x000000018050C150-0x000000018050C2D0
	[CompilerGenerated]
	private void _Send_b__114_1(); // 0x000000018050C2D0-0x000000018050C450
}

