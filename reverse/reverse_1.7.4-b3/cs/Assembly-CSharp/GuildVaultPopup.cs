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

public class GuildVaultPopup : GuildInfoPopup // TypeDefIndex: 947
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005EEF6E
	private const float CARD_H = 720f; // Metadata: 0x005EEF72
	private const float CARD_L_X = 64f; // Metadata: 0x005EEF76
	private const float CARD_L_W = 1130f; // Metadata: 0x005EEF7A
	private const float CARD_R_X = 1220f; // Metadata: 0x005EEF7E
	private const float CARD_R_W = 490f; // Metadata: 0x005EEF82
	private const float HINT_Y = 846f; // Metadata: 0x005EEF86
	private const float HINT_H = 30f; // Metadata: 0x005EEF8A
	private const float L_PAD = 36f; // Metadata: 0x005EEF8E
	private const float L_INNER = 1058f; // Metadata: 0x005EEF92
	private const float L_GOLD_X = 36f; // Metadata: 0x005EEF96
	private const float L_GOLD_Y = 22f; // Metadata: 0x005EEF9A
	private const float L_GOLD_D = 96f; // Metadata: 0x005EEF9E
	private const float L_TXT_X = 150f; // Metadata: 0x005EEFA2
	private const float L_LABEL_Y = 26f; // Metadata: 0x005EEFA6
	private const float L_LABEL_W = 600f; // Metadata: 0x005EEFAA
	private const float L_LABEL_H = 30f; // Metadata: 0x005EEFAE
	private const float L_BIG_Y = 58f; // Metadata: 0x005EEFB2
	private const float L_BIG_W = 760f; // Metadata: 0x005EEFB6
	private const float L_BIG_H = 60f; // Metadata: 0x005EEFBA
	private const float L_SUB_Y = 120f; // Metadata: 0x005EEFBE
	private const float L_SUB_H = 28f; // Metadata: 0x005EEFC2
	private const float L_DIV1_Y = 160f; // Metadata: 0x005EEFC6
	private const float L_SEC_Y = 172f; // Metadata: 0x005EEFCA
	private const float L_SEC_W = 600f; // Metadata: 0x005EEFCE
	private const float L_SEC_H = 36f; // Metadata: 0x005EEFD2
	private const float L_HDR_Y = 216f; // Metadata: 0x005EEFD6
	private const float L_HDR_H = 32f; // Metadata: 0x005EEFDA
	private const float L_DIV2_Y = 254f; // Metadata: 0x005EEFDE
	private const float VP_X = 24f; // Metadata: 0x005EEFE2
	private const float VP_Y = 264f; // Metadata: 0x005EEFE6
	private const float VP_W = 1082f; // Metadata: 0x005EEFEA
	private const float VP_H = 432f; // Metadata: 0x005EEFEE
	private const float L_EMPTY_Y = 420f; // Metadata: 0x005EEFF2
	private const float L_EMPTY_H = 60f; // Metadata: 0x005EEFF6
	private const float ROW_W = 1082f; // Metadata: 0x005EEFFA
	private const float ROW_H = 64f; // Metadata: 0x005EEFFE
	private const float ROW_GAP = 6f; // Metadata: 0x005EF002
	private const float C_DATE_X = 12f; // Metadata: 0x005EF006
	private const float C_DATE_W = 170f; // Metadata: 0x005EF00A
	private const float C_WHAT_X = 196f; // Metadata: 0x005EF00E
	private const float C_WHAT_W = 560f; // Metadata: 0x005EF012
	private const float C_AMT_X = 770f; // Metadata: 0x005EF016
	private const float C_AMT_W = 300f; // Metadata: 0x005EF01A
	private const int LOG_MAX = 50; // Metadata: 0x005EF01E
	private const float R_PAD = 36f; // Metadata: 0x005EF01F
	private const float R_INNER = 418f; // Metadata: 0x005EF023
	private const float R_SEC_Y = 22f; // Metadata: 0x005EF027
	private const float R_SEC_H = 40f; // Metadata: 0x005EF02B
	private const float R_STAT_Y0 = 80f; // Metadata: 0x005EF02F
	private const float R_STAT_STEP = 52f; // Metadata: 0x005EF033
	private const float R_STAT_H = 44f; // Metadata: 0x005EF037
	private const float R_DIV1_Y = 240f; // Metadata: 0x005EF03B
	private const float R_MODE_Y = 260f; // Metadata: 0x005EF03F
	private const float R_MODE_W = 200f; // Metadata: 0x005EF043
	private const float R_MODE_H = 60f; // Metadata: 0x005EF047
	private const float R_MODE2_X = 254f; // Metadata: 0x005EF04B
	private const float R_DESC_Y = 336f; // Metadata: 0x005EF04F
	private const float R_DESC_H = 130f; // Metadata: 0x005EF053
	private const float R_GO_X = 95f; // Metadata: 0x005EF057
	private const float R_GO_Y = 486f; // Metadata: 0x005EF05B
	private const float R_GO_W = 300f; // Metadata: 0x005EF05F
	private const float R_GO_H = 64f; // Metadata: 0x005EF063
	private const float R_WAIT_Y = 260f; // Metadata: 0x005EF067
	private const float R_WAIT_H = 120f; // Metadata: 0x005EF06B
	private const float R_LAST_Y = 390f; // Metadata: 0x005EF06F
	private const float R_LAST_H = 60f; // Metadata: 0x005EF073
	private const float R_DIV2_Y = 570f; // Metadata: 0x005EF077
	private const float R_RULE_Y = 582f; // Metadata: 0x005EF07B
	private const float R_RULE_H = 120f; // Metadata: 0x005EF07F
	private const float ARM_SECONDS = 4f; // Metadata: 0x005EF083
	private const int COIN_COUNT = 8; // Metadata: 0x005EF087
	private const float COIN_D = 40f; // Metadata: 0x005EF088
	private const string MODE_EQUAL = "EQUAL"; // Metadata: 0x005EF08C
	private const string MODE_MANUAL = "MANUAL"; // Metadata: 0x005EF092
	private static readonly TimeSpan VN_OFFSET; // 0x00
	private static readonly Color ROW_ODD; // 0x08
	private static readonly Color ROW_EVEN; // 0x18
	private GuildPanelController _owner; // 0x70
	private GuildVaultData _data; // 0x78
	private GuildGuidePopup _guide; // 0x80
	private GuildDistributePopup _distribute; // 0x88
	private bool _built; // 0x90
	private bool _loading; // 0x91
	private bool _sending; // 0x92
	private bool _armed; // 0x93
	private Coroutine _disarmCo; // 0x98
	private string _mode; // 0xA0
	private long _goldShown; // 0xA8
	private readonly List<int> _tweens; // 0xB0
	private Image _imgGoldBig; // 0xB8
	private UnityEngine.UI.Text _txtVaultLabel; // 0xC0
	private UnityEngine.UI.Text _txtVaultGold; // 0xC8
	private UnityEngine.UI.Text _txtVaultSub; // 0xD0
	private UnityEngine.UI.Text _secLog; // 0xD8
	private RectTransform _logContent; // 0xE0
	private ScrollRect _scroll; // 0xE8
	private UnityEngine.UI.Text _txtEmpty; // 0xF0
	private readonly List<LogRow> _pool; // 0xF8
	private UnityEngine.UI.Text _secShare; // 0x100
	private UnityEngine.UI.Text _statMembers; // 0x108
	private UnityEngine.UI.Text _statEach; // 0x110
	private UnityEngine.UI.Text _statRemain; // 0x118
	private RectTransform _grpMaster; // 0x120
	private RectTransform _grpMember; // 0x128
	private Button _btnEqual; // 0x130
	private Button _btnManual; // 0x138
	private Button _btnGo; // 0x140
	private Image _imgEqual; // 0x148
	private Image _imgManual; // 0x150
	private Image _imgGo; // 0x158
	private UnityEngine.UI.Text _txtGoLabel; // 0x160
	private UnityEngine.UI.Text _txtModeDesc; // 0x168
	private UnityEngine.UI.Text _txtWait; // 0x170
	private UnityEngine.UI.Text _txtLast; // 0x178
	private UnityEngine.UI.Text _txtRule; // 0x180
	private readonly Image[] _coins; // 0x188
	private int _countTween; // 0x190

	// Properties
	private static Color DividerColor { get; } // 0x00000001805C7C10-0x00000001805C7C90 

	// Nested types
	private class LogRow // TypeDefIndex: 948
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public UnityEngine.UI.Text date; // 0x20
		public UnityEngine.UI.Text what; // 0x28
		public UnityEngine.UI.Text amount; // 0x30

		// Constructors
		public LogRow(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass161_0 // TypeDefIndex: 949
	{
		// Fields
		public UnityEngine.UI.Text node; // 0x10
		public GuildVaultPopup __4__this; // 0x18
		public long target; // 0x20

		// Constructors
		public __c__DisplayClass161_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CountTo_b__0(float v); // 0x00000001805D1DA0-0x00000001805D1F00
		internal void _CountTo_b__1(); // 0x00000001805D1F00-0x00000001805D2070
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass162_0 // TypeDefIndex: 950
	{
		// Fields
		public Image coin; // 0x10
		public float lift; // 0x18
		public RectTransform rt; // 0x20
		public Vector2 a; // 0x28
		public Vector2 b; // 0x30

		// Constructors
		public __c__DisplayClass162_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayShareFx_b__0(); // 0x00000001805D2070-0x00000001805D21C0
		internal void _PlayShareFx_b__1(float v); // 0x00000001805D21C0-0x00000001805D23A0
		internal void _PlayShareFx_b__2(); // 0x00000001805D23A0-0x00000001805D2540
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__153 : IEnumerator<object> // TypeDefIndex: 951
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public GuildVaultPopup __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisarmAfter_d__153(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805D2540-0x00000001805D26B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D26B0-0x00000001805D26F0
	}

	// Constructors
	public GuildVaultPopup(); // 0x00000001805D1650-0x00000001805D19C0
	static GuildVaultPopup(); // 0x00000001805D19C0-0x00000001805D1AB0

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805C7C90-0x00000001805C7E50
	public void Reload(); // 0x00000001805C7E50-0x00000001805C7E80
	public void RaiseChildren(); // 0x00000001805C7E80-0x00000001805C8030
	public void HideChildren(); // 0x00000001805C8030-0x00000001805C81E0
	public override void Hide(); // 0x00000001805C81E0-0x00000001805C8220
	protected override void OnDisable(); // 0x00000001805C8220-0x00000001805C8260
	private void Build(); // 0x00000001805C8260-0x00000001805C87A0
	private void BuildVaultCard(RectTransform card); // 0x00000001805C87A0-0x00000001805C9380
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x00000001805C9380-0x00000001805C9490
	private void BuildLogList(RectTransform card); // 0x00000001805C9490-0x00000001805C9C10
	private void BuildShareCard(RectTransform card); // 0x00000001805C9C10-0x00000001805CA530
	private void BuildMasterGroup(RectTransform card); // 0x00000001805CA530-0x00000001805CB040
	private void BuildMemberGroup(RectTransform card); // 0x00000001805CB040-0x00000001805CB400
	private void BuildCoins(RectTransform content); // 0x00000001805CB400-0x00000001805CB710
	private void Fetch(); // 0x00000001805CB710-0x00000001805CBA30
	public void Render(GuildVaultData d); // 0x00000001805CBA30-0x00000001805CBE20
	private static string SubLine(GuildVaultData d); // 0x00000001805CBE20-0x00000001805CBFD0
	private string RuleLine(GuildVaultData d); // 0x00000001805CBFD0-0x00000001805CC130
	private void RenderMaster(GuildVaultData d); // 0x00000001805CC130-0x00000001805CC740
	private static bool Enough(GuildVaultData d); // 0x00000001805CC740-0x00000001805CC770
	private static string ModeDesc(GuildVaultData d, bool equal); // 0x00000001805CC770-0x00000001805CCA30
	private static string NotEnough(GuildVaultData d); // 0x00000001805CCA30-0x00000001805CCC20
	private void RenderGoButton(); // 0x00000001805CCC20-0x00000001805CD040
	private void RenderMember(GuildVaultData d, bool live); // 0x00000001805CD040-0x00000001805CD250
	private void RenderLog(GuildVaultData d); // 0x00000001805CD250-0x00000001805CD6E0
	private LogRow EnsureRow(int index); // 0x00000001805CD6E0-0x00000001805CD9D0
	private LogRow BuildLogRow(int index); // 0x00000001805CD9D0-0x00000001805CDF70
	private void BindRow(LogRow r, GuildVaultLogRow row, int index); // 0x00000001805CDF70-0x00000001805CE390
	private static string WhatLine(GuildVaultLogRow row); // 0x00000001805CE390-0x00000001805CE810
	private static string DateVn(long sec); // 0x00000001805CE810-0x00000001805CEA00
	private void OnClickHelp(); // 0x00000001805CEA00-0x00000001805CEDF0
	private void PickMode(string mode); // 0x00000001805CEDF0-0x00000001805CEF20
	private void OnClickGo(); // 0x00000001805CEF20-0x00000001805CF370
	[IteratorStateMachine(typeof(_DisarmAfter_d__153))]
	private IEnumerator DisarmAfter(float sec); // 0x00000001805CF370-0x00000001805CF430
	private void Disarm(); // 0x00000001805CF430-0x00000001805CF540
	private void OpenDistribute(); // 0x00000001805CF540-0x00000001805CF920
	private void DistributeEqual(); // 0x00000001805CF920-0x00000001805CFE10
	private void OnDistributed(GuildVaultDistributeData d); // 0x00000001805CFE10-0x00000001805D01A0
	private void Track(int id); // 0x00000001805D01A0-0x00000001805D0250
	private void CancelFx(); // 0x00000001805D0250-0x00000001805D0A40
	private void CountTo(long target, float sec); // 0x00000001805D0A40-0x00000001805D1020
	private void PlayShareFx(long before); // 0x00000001805D1020-0x00000001805D1650
	[CompilerGenerated]
	private void _BuildMasterGroup_b__131_0(); // 0x00000001805D1AB0-0x00000001805D1B00
	[CompilerGenerated]
	private void _BuildMasterGroup_b__131_1(); // 0x00000001805D1B00-0x00000001805D1B50
	[CompilerGenerated]
	private void _Fetch_b__134_0(GuildVaultData d); // 0x00000001805D1B50-0x00000001805D1B60
	[CompilerGenerated]
	private void _Fetch_b__134_1(string err); // 0x00000001805D1B60-0x00000001805D1BE0
	[CompilerGenerated]
	private void _DistributeEqual_b__156_0(GuildVaultDistributeData d); // 0x00000001805D1BE0-0x00000001805D1C20
	[CompilerGenerated]
	private void _DistributeEqual_b__156_1(); // 0x00000001805D1C20-0x00000001805D1DA0
}

