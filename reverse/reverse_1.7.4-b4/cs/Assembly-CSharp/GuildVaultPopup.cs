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

public class GuildVaultPopup : GuildInfoPopup // TypeDefIndex: 949
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005F033B
	private const float CARD_H = 720f; // Metadata: 0x005F033F
	private const float CARD_L_X = 64f; // Metadata: 0x005F0343
	private const float CARD_L_W = 1130f; // Metadata: 0x005F0347
	private const float CARD_R_X = 1220f; // Metadata: 0x005F034B
	private const float CARD_R_W = 490f; // Metadata: 0x005F034F
	private const float HINT_Y = 846f; // Metadata: 0x005F0353
	private const float HINT_H = 30f; // Metadata: 0x005F0357
	private const float L_PAD = 36f; // Metadata: 0x005F035B
	private const float L_INNER = 1058f; // Metadata: 0x005F035F
	private const float L_GOLD_X = 36f; // Metadata: 0x005F0363
	private const float L_GOLD_Y = 22f; // Metadata: 0x005F0367
	private const float L_GOLD_D = 96f; // Metadata: 0x005F036B
	private const float L_TXT_X = 150f; // Metadata: 0x005F036F
	private const float L_LABEL_Y = 26f; // Metadata: 0x005F0373
	private const float L_LABEL_W = 600f; // Metadata: 0x005F0377
	private const float L_LABEL_H = 30f; // Metadata: 0x005F037B
	private const float L_BIG_Y = 58f; // Metadata: 0x005F037F
	private const float L_BIG_W = 760f; // Metadata: 0x005F0383
	private const float L_BIG_H = 60f; // Metadata: 0x005F0387
	private const float L_SUB_Y = 120f; // Metadata: 0x005F038B
	private const float L_SUB_H = 28f; // Metadata: 0x005F038F
	private const float L_DIV1_Y = 160f; // Metadata: 0x005F0393
	private const float L_SEC_Y = 172f; // Metadata: 0x005F0397
	private const float L_SEC_W = 600f; // Metadata: 0x005F039B
	private const float L_SEC_H = 36f; // Metadata: 0x005F039F
	private const float L_HDR_Y = 216f; // Metadata: 0x005F03A3
	private const float L_HDR_H = 32f; // Metadata: 0x005F03A7
	private const float L_DIV2_Y = 254f; // Metadata: 0x005F03AB
	private const float VP_X = 24f; // Metadata: 0x005F03AF
	private const float VP_Y = 264f; // Metadata: 0x005F03B3
	private const float VP_W = 1082f; // Metadata: 0x005F03B7
	private const float VP_H = 432f; // Metadata: 0x005F03BB
	private const float L_EMPTY_Y = 420f; // Metadata: 0x005F03BF
	private const float L_EMPTY_H = 60f; // Metadata: 0x005F03C3
	private const float ROW_W = 1082f; // Metadata: 0x005F03C7
	private const float ROW_H = 64f; // Metadata: 0x005F03CB
	private const float ROW_GAP = 6f; // Metadata: 0x005F03CF
	private const float C_DATE_X = 12f; // Metadata: 0x005F03D3
	private const float C_DATE_W = 170f; // Metadata: 0x005F03D7
	private const float C_WHAT_X = 196f; // Metadata: 0x005F03DB
	private const float C_WHAT_W = 560f; // Metadata: 0x005F03DF
	private const float C_AMT_X = 770f; // Metadata: 0x005F03E3
	private const float C_AMT_W = 300f; // Metadata: 0x005F03E7
	private const int LOG_MAX = 50; // Metadata: 0x005F03EB
	private const float R_PAD = 36f; // Metadata: 0x005F03EC
	private const float R_INNER = 418f; // Metadata: 0x005F03F0
	private const float R_SEC_Y = 22f; // Metadata: 0x005F03F4
	private const float R_SEC_H = 40f; // Metadata: 0x005F03F8
	private const float R_STAT_Y0 = 80f; // Metadata: 0x005F03FC
	private const float R_STAT_STEP = 52f; // Metadata: 0x005F0400
	private const float R_STAT_H = 44f; // Metadata: 0x005F0404
	private const float R_DIV1_Y = 240f; // Metadata: 0x005F0408
	private const float R_MODE_Y = 260f; // Metadata: 0x005F040C
	private const float R_MODE_W = 200f; // Metadata: 0x005F0410
	private const float R_MODE_H = 60f; // Metadata: 0x005F0414
	private const float R_MODE2_X = 254f; // Metadata: 0x005F0418
	private const float R_DESC_Y = 336f; // Metadata: 0x005F041C
	private const float R_DESC_H = 130f; // Metadata: 0x005F0420
	private const float R_GO_X = 95f; // Metadata: 0x005F0424
	private const float R_GO_Y = 486f; // Metadata: 0x005F0428
	private const float R_GO_W = 300f; // Metadata: 0x005F042C
	private const float R_GO_H = 64f; // Metadata: 0x005F0430
	private const float R_WAIT_Y = 260f; // Metadata: 0x005F0434
	private const float R_WAIT_H = 120f; // Metadata: 0x005F0438
	private const float R_LAST_Y = 390f; // Metadata: 0x005F043C
	private const float R_LAST_H = 60f; // Metadata: 0x005F0440
	private const float R_DIV2_Y = 570f; // Metadata: 0x005F0444
	private const float R_RULE_Y = 582f; // Metadata: 0x005F0448
	private const float R_RULE_H = 120f; // Metadata: 0x005F044C
	private const float ARM_SECONDS = 4f; // Metadata: 0x005F0450
	private const int COIN_COUNT = 8; // Metadata: 0x005F0454
	private const float COIN_D = 40f; // Metadata: 0x005F0455
	private const string MODE_EQUAL = "EQUAL"; // Metadata: 0x005F0459
	private const string MODE_MANUAL = "MANUAL"; // Metadata: 0x005F045F
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
	private static Color DividerColor { get; } // 0x00000001805C9590-0x00000001805C9610 

	// Nested types
	private class LogRow // TypeDefIndex: 950
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
	private sealed class __c__DisplayClass161_0 // TypeDefIndex: 951
	{
		// Fields
		public UnityEngine.UI.Text node; // 0x10
		public GuildVaultPopup __4__this; // 0x18
		public long target; // 0x20

		// Constructors
		public __c__DisplayClass161_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CountTo_b__0(float v); // 0x00000001805D3720-0x00000001805D3880
		internal void _CountTo_b__1(); // 0x00000001805D3880-0x00000001805D39F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass162_0 // TypeDefIndex: 952
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
		internal void _PlayShareFx_b__0(); // 0x00000001805D39F0-0x00000001805D3B40
		internal void _PlayShareFx_b__1(float v); // 0x00000001805D3B40-0x00000001805D3D20
		internal void _PlayShareFx_b__2(); // 0x00000001805D3D20-0x00000001805D3EC0
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__153 : IEnumerator<object> // TypeDefIndex: 953
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805D3EC0-0x00000001805D4030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D4030-0x00000001805D4070
	}

	// Constructors
	public GuildVaultPopup(); // 0x00000001805D2FD0-0x00000001805D3340
	static GuildVaultPopup(); // 0x00000001805D3340-0x00000001805D3430

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805C9610-0x00000001805C97D0
	public void Reload(); // 0x00000001805C97D0-0x00000001805C9800
	public void RaiseChildren(); // 0x00000001805C9800-0x00000001805C99B0
	public void HideChildren(); // 0x00000001805C99B0-0x00000001805C9B60
	public override void Hide(); // 0x00000001805C9B60-0x00000001805C9BA0
	protected override void OnDisable(); // 0x00000001805C9BA0-0x00000001805C9BE0
	private void Build(); // 0x00000001805C9BE0-0x00000001805CA120
	private void BuildVaultCard(RectTransform card); // 0x00000001805CA120-0x00000001805CAD00
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x00000001805CAD00-0x00000001805CAE10
	private void BuildLogList(RectTransform card); // 0x00000001805CAE10-0x00000001805CB590
	private void BuildShareCard(RectTransform card); // 0x00000001805CB590-0x00000001805CBEB0
	private void BuildMasterGroup(RectTransform card); // 0x00000001805CBEB0-0x00000001805CC9C0
	private void BuildMemberGroup(RectTransform card); // 0x00000001805CC9C0-0x00000001805CCD80
	private void BuildCoins(RectTransform content); // 0x00000001805CCD80-0x00000001805CD090
	private void Fetch(); // 0x00000001805CD090-0x00000001805CD3B0
	public void Render(GuildVaultData d); // 0x00000001805CD3B0-0x00000001805CD7A0
	private static string SubLine(GuildVaultData d); // 0x00000001805CD7A0-0x00000001805CD950
	private string RuleLine(GuildVaultData d); // 0x00000001805CD950-0x00000001805CDAB0
	private void RenderMaster(GuildVaultData d); // 0x00000001805CDAB0-0x00000001805CE0C0
	private static bool Enough(GuildVaultData d); // 0x00000001805CE0C0-0x00000001805CE0F0
	private static string ModeDesc(GuildVaultData d, bool equal); // 0x00000001805CE0F0-0x00000001805CE3B0
	private static string NotEnough(GuildVaultData d); // 0x00000001805CE3B0-0x00000001805CE5A0
	private void RenderGoButton(); // 0x00000001805CE5A0-0x00000001805CE9C0
	private void RenderMember(GuildVaultData d, bool live); // 0x00000001805CE9C0-0x00000001805CEBD0
	private void RenderLog(GuildVaultData d); // 0x00000001805CEBD0-0x00000001805CF060
	private LogRow EnsureRow(int index); // 0x00000001805CF060-0x00000001805CF350
	private LogRow BuildLogRow(int index); // 0x00000001805CF350-0x00000001805CF8F0
	private void BindRow(LogRow r, GuildVaultLogRow row, int index); // 0x00000001805CF8F0-0x00000001805CFD10
	private static string WhatLine(GuildVaultLogRow row); // 0x00000001805CFD10-0x00000001805D0190
	private static string DateVn(long sec); // 0x00000001805D0190-0x00000001805D0380
	private void OnClickHelp(); // 0x00000001805D0380-0x00000001805D0770
	private void PickMode(string mode); // 0x00000001805D0770-0x00000001805D08A0
	private void OnClickGo(); // 0x00000001805D08A0-0x00000001805D0CF0
	[IteratorStateMachine(typeof(_DisarmAfter_d__153))]
	private IEnumerator DisarmAfter(float sec); // 0x00000001805D0CF0-0x00000001805D0DB0
	private void Disarm(); // 0x00000001805D0DB0-0x00000001805D0EC0
	private void OpenDistribute(); // 0x00000001805D0EC0-0x00000001805D12A0
	private void DistributeEqual(); // 0x00000001805D12A0-0x00000001805D1790
	private void OnDistributed(GuildVaultDistributeData d); // 0x00000001805D1790-0x00000001805D1B20
	private void Track(int id); // 0x00000001805D1B20-0x00000001805D1BD0
	private void CancelFx(); // 0x00000001805D1BD0-0x00000001805D23C0
	private void CountTo(long target, float sec); // 0x00000001805D23C0-0x00000001805D29A0
	private void PlayShareFx(long before); // 0x00000001805D29A0-0x00000001805D2FD0
	[CompilerGenerated]
	private void _BuildMasterGroup_b__131_0(); // 0x00000001805D3430-0x00000001805D3480
	[CompilerGenerated]
	private void _BuildMasterGroup_b__131_1(); // 0x00000001805D3480-0x00000001805D34D0
	[CompilerGenerated]
	private void _Fetch_b__134_0(GuildVaultData d); // 0x00000001805D34D0-0x00000001805D34E0
	[CompilerGenerated]
	private void _Fetch_b__134_1(string err); // 0x00000001805D34E0-0x00000001805D3560
	[CompilerGenerated]
	private void _DistributeEqual_b__156_0(GuildVaultDistributeData d); // 0x00000001805D3560-0x00000001805D35A0
	[CompilerGenerated]
	private void _DistributeEqual_b__156_1(); // 0x00000001805D35A0-0x00000001805D3720
}

