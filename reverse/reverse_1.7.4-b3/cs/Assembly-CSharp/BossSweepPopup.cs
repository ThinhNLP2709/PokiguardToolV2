/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class BossSweepPopup : MonoBehaviour // TypeDefIndex: 361
{
	// Fields
	public const string FLAG_KEY = "bossSweep"; // Metadata: 0x005EDB1E
	private const float CANVAS_REF_W = 1300f; // Metadata: 0x005EDB28
	private const float CANVAS_REF_H = 731f; // Metadata: 0x005EDB2C
	private const float PANEL_W = 760f; // Metadata: 0x005EDB30
	private const float RES_PAD_X = 30f; // Metadata: 0x005EDB34
	private const float RES_PAD_TOP = 24f; // Metadata: 0x005EDB38
	private const float RES_PAD_BOT = 24f; // Metadata: 0x005EDB3C
	private const float RES_TITLE_H = 58f; // Metadata: 0x005EDB40
	private const float RES_SUB_H = 44f; // Metadata: 0x005EDB44
	private const float RES_GAP_SUB = 6f; // Metadata: 0x005EDB48
	private const float RES_CELL = 76f; // Metadata: 0x005EDB4C
	private const float RES_REWARD_H = 80f; // Metadata: 0x005EDB50
	private const float RES_GAP_REWARD = 4f; // Metadata: 0x005EDB54
	private const float RES_NAMES_H = 70f; // Metadata: 0x005EDB58
	private const float RES_GAP_NAMES = 2f; // Metadata: 0x005EDB5C
	private const float RES_LEFT_H = 42f; // Metadata: 0x005EDB60
	private const float RES_GAP_BTN = 10f; // Metadata: 0x005EDB64
	private const float RES_BTN_W = 330f; // Metadata: 0x005EDB68
	private const float RES_BTN_H = 80f; // Metadata: 0x005EDB6C
	private const float TIP_W = 560f; // Metadata: 0x005EDB70
	private const float TIP_PAD_X = 16f; // Metadata: 0x005EDB74
	private const float TIP_PAD_TOP = 34f; // Metadata: 0x005EDB78
	private const float TIP_PAD_BOT = 36f; // Metadata: 0x005EDB7C
	private const float TIP_TITLE_H = 50f; // Metadata: 0x005EDB80
	private const float TIP_ROW_H = 76f; // Metadata: 0x005EDB84
	private const float TIP_ROW_GAP = 6f; // Metadata: 0x005EDB88
	private const float TIP_WARN_H = 64f; // Metadata: 0x005EDB8C
	private const float TIP_H = 438f; // Metadata: 0x005EDB90
	private const float TIP_GAP = 14f; // Metadata: 0x005EDB94
	private const float TIP_MARGIN = 14f; // Metadata: 0x005EDB98
	private const float INFO_W = 480f; // Metadata: 0x005EDB9C
	private const float INFO_PAD_X = 18f; // Metadata: 0x005EDBA0
	private const float INFO_PAD_TOP = 34f; // Metadata: 0x005EDBA4
	private const float INFO_PAD_BOT = 36f; // Metadata: 0x005EDBA8
	private const float INFO_HEAD_H = 56f; // Metadata: 0x005EDBAC
	private const float INFO_DESC_H = 100f; // Metadata: 0x005EDBB0
	private const float INFO_LABEL_H = 30f; // Metadata: 0x005EDBB4
	private const float INFO_BODY_H = 68f; // Metadata: 0x005EDBB8
	private const float INFO_COST_H = 34f; // Metadata: 0x005EDBBC
	private const float INFO_H = 520f; // Metadata: 0x005EDBC0
	private const int FS_INFO_TITLE = 32; // Metadata: 0x005EDBC4
	private const int FS_INFO_LABEL = 22; // Metadata: 0x005EDBC5
	private const int FS_INFO_BODY = 24; // Metadata: 0x005EDBC6
	private const int FS_TITLE = 44; // Metadata: 0x005EDBC7
	private const int FS_MAIN = 33; // Metadata: 0x005EDBC8
	private const int FS_BTN = 36; // Metadata: 0x005EDBC9
	private const int FS_SUB = 32; // Metadata: 0x005EDBCA
	private const int FS_NAMES = 26; // Metadata: 0x005EDBCB
	private const int FS_TIP_TITLE = 32; // Metadata: 0x005EDBCC
	private const int FS_TIP_NAME = 32; // Metadata: 0x005EDBCD
	private const int FS_TIP_OWNED = 30; // Metadata: 0x005EDBCE
	private const int FS_TIP_PCT = 52; // Metadata: 0x005EDBCF
	private const int FS_TIP_WARN = 24; // Metadata: 0x005EDBD0
	private static readonly string[] TIERS; // 0x00
	private static readonly string[] TIER_NAMES; // 0x08
	private static readonly long[] TIER_ITEM_IDS; // 0x10
	private static readonly int[] TIER_ENERGY_DEFAULTS; // 0x18
	private const string INFO_DESC = "B\u1ECF qua tr\u1EADn \u0111\u00E1nh \u2014 nh\u1EADn th\u1EB3ng ph\u1EA7n th\u01B0\u1EDFng c\u1EE7a con boss b\u1EA1n \u0110\u00C3 s\u0103n qua. T\u1EF7 l\u1EC7 th\u00E0nh c\u00F4ng do m\u00E1y ch\u1EE7 quy\u1EBFt, xem \u00F4 % \u1EDF t\u1EEBng h\u00E0ng v\u00E9."; // Metadata: 0x005EDBD1
	private static readonly string[] TIER_SOURCES; // 0x20
	private static readonly string[] TIER_FITS; // 0x28
	private static readonly Color[] TIER_COLORS; // 0x30
	private const string SP_PANEL = "Image/item/sweep_panel"; // Metadata: 0x005EDC7E
	private const string SP_PANEL2 = "Image/item/sweep_panel2"; // Metadata: 0x005EDC95
	private const string SP_ROW = "Image/item/sweep_row"; // Metadata: 0x005EDCAD
	private const string SP_TAG = "Image/item/sweep_tag"; // Metadata: 0x005EDCC2
	private const string SP_LINE = "Image/item/sweep_line"; // Metadata: 0x005EDCD7
	private const string NOT_HUNTED_MESSAGE = "Ph\u1EA3i t\u1EF1 tay h\u1EA1 boss n\u00E0y \u00EDt nh\u1EA5t m\u1ED9t l\u1EA7n r\u1ED3i m\u1EDBi d\u00F9ng v\u00E9 c\u00E0n qu\u00E9t \u0111\u01B0\u1EE3c."; // Metadata: 0x005EDCED
	private static readonly Color ROW_NORMAL; // 0x38
	private static readonly Color ROW_SUGGEST; // 0x48
	private static readonly Color ROW_DEAD; // 0x58
	private static readonly Color GOLD; // 0x68
	private static readonly Color TEXT_MAIN; // 0x78
	private static readonly Color TEXT_DIM; // 0x88
	private static readonly Color GREEN; // 0x98
	private static readonly Color RED; // 0xA8
	public static Action<BossSweepInfoDTO> OnInfoLoaded; // 0xB8
	public static Action<string, int> OnTicketUsed; // 0xC0
	private static BossSweepPopup _instance; // 0xC8
	private RectTransform _canvasRect; // 0x20
	private CanvasGroup _rootGroup; // 0x28
	private Image _dim; // 0x30
	private RectTransform _tip; // 0x38
	private UnityEngine.UI.Text _txtTipTitle; // 0x40
	private UnityEngine.UI.Text _txtTipWarn; // 0x48
	private readonly RowUi[] _rows; // 0x50
	private GameObject _tipVeil; // 0x58
	private RectTransform _tipSpin; // 0x60
	private UnityEngine.UI.Text _txtTipVeil; // 0x68
	private RectTransform _infoTip; // 0x70
	private Image _imgInfoIcon; // 0x78
	private UnityEngine.UI.Text _txtInfoTitle; // 0x80
	private UnityEngine.UI.Text _txtInfoDesc; // 0x88
	private UnityEngine.UI.Text _txtInfoSource; // 0x90
	private UnityEngine.UI.Text _txtInfoFit; // 0x98
	private UnityEngine.UI.Text _txtInfoCost; // 0xA0
	private RectTransform _infoAnchor; // 0xA8
	private bool _infoOnly; // 0xB0
	private RectTransform _panel; // 0xB8
	private GameObject _resultPage; // 0xC0
	private UnityEngine.UI.Text _txtResultTitle; // 0xC8
	private UnityEngine.UI.Text _txtResultSub; // 0xD0
	private Transform _rewardBox; // 0xD8
	private RectTransform _rewardBoxRt; // 0xE0
	private RectTransform _btnOkRt; // 0xE8
	private UnityEngine.UI.Text _txtRewardNames; // 0xF0
	private UnityEngine.UI.Text _txtTicketsLeft; // 0xF8
	private Image _flash; // 0x100
	private int _petId; // 0x108
	private string _petName; // 0x110
	private int _bossLevel; // 0x118
	private BossSweepInfoDTO _info; // 0x120
	private bool _busy; // 0x128
	private bool _fake; // 0x129
	private RectTransform _anchor; // 0x130
	private Coroutine _spinRoutine; // 0x138
	private Coroutine _repositionRoutine; // 0x140

	// Nested types
	private class RowUi // TypeDefIndex: 362
	{
		// Fields
		public GameObject go; // 0x10
		public Image bg; // 0x18
		public GameObject badge; // 0x20
		public Transform frame; // 0x28
		public Image icon; // 0x30
		public UnityEngine.UI.Text name; // 0x38
		public UnityEngine.UI.Text owned; // 0x40
		public UnityEngine.UI.Text percent; // 0x48
		public Button button; // 0x50
		public CanvasGroup group; // 0x58
		public PokyShinySweep shine; // 0x60

		// Constructors
		public RowUi(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 363
	{
		// Fields
		public BossSweepPopup __4__this; // 0x10
		public int captured; // 0x18
		public int capInfo; // 0x1C
		public RectTransform icrt; // 0x20

		// Constructors
		public __c__DisplayClass124_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x0000000180319FA0-0x0000000180319FD0
		internal void _BuildRow_b__1(); // 0x0000000180319FD0-0x000000018031A000
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass146_0 // TypeDefIndex: 364
	{
		// Fields
		public BossSweepUseDTO result; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass146_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SweepRoutine_b__0(BossSweepUseDTO d); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _SweepRoutine_b__1(string e); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 365
	{
		// Fields
		public RectTransform rt; // 0x10
		public float dur; // 0x18

		// Constructors
		public __c__DisplayClass168_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Punch_b__0(); // 0x000000018031A000-0x000000018031A1A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass169_0 // TypeDefIndex: 366
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass169_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Shake_b__0(float v); // 0x000000018031A1A0-0x000000018031A2E0
		internal void _Shake_b__1(); // 0x000000018031A2E0-0x000000018031A400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass170_0 // TypeDefIndex: 367
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10

		// Constructors
		public __c__DisplayClass170_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseRed_b__0(float v); // 0x000000018031A400-0x000000018031A600
	}

	[CompilerGenerated]
	private sealed class _FetchInfo_d__143 : IEnumerator<object> // TypeDefIndex: 368
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchInfo_d__143(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018031A600-0x000000018031A900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018031A900-0x000000018031A940
	}

	[CompilerGenerated]
	private sealed class _FlyRewardsToWallet_d__150 : IEnumerator<object> // TypeDefIndex: 369
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<GameObject> cells; // 0x20
		private RectTransform _wallet_5__2; // 0x28
		private int _i_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlyRewardsToWallet_d__150(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018031A940-0x000000018031AF20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018031AF20-0x000000018031AF60
	}

	[CompilerGenerated]
	private sealed class _RepositionNextFrame_d__130 : IEnumerator<object> // TypeDefIndex: 370
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RepositionNextFrame_d__130(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018031B4F0-0x000000018031B850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018031B850-0x000000018031B890
	}

	[CompilerGenerated]
	private sealed class _SpinRoutine_d__153 : IEnumerator<object> // TypeDefIndex: 371
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinRoutine_d__153(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018031B890-0x000000018031BA90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018031BA90-0x000000018031BAD0
	}

	[CompilerGenerated]
	private sealed class _SweepRoutine_d__146 : IEnumerator<object> // TypeDefIndex: 372
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20
		public string tier; // 0x28
		private __c__DisplayClass146_0 __8__1; // 0x30
		private float _revealAt_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SweepRoutine_d__146(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018031BAD0-0x000000018031C4F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018031C4F0-0x000000018031C530
	}

	// Constructors
	public BossSweepPopup(); // 0x0000000180319430-0x0000000180319510
	static BossSweepPopup(); // 0x0000000180319510-0x0000000180319C80

	// Methods
	public static void Open(int petId, string petName, int bossLevel, RectTransform anchor = null); // 0x000000018030A6A0-0x000000018030A8A0
	public static void CloseIfOpen(); // 0x000000018030A8A0-0x000000018030A9E0
	private static BossSweepPopup Ensure(); // 0x000000018030A9E0-0x000000018030B020
	private void Build(); // 0x000000018030B020-0x000000018030B550
	private void BuildTip(); // 0x000000018030B550-0x000000018030C910
	private void BuildInfoTip(); // 0x000000018030C910-0x000000018030D520
	private static void MakeInfoLabel(RectTransform parent, string name, float y, float w, string value); // 0x000000018030D520-0x000000018030D680
	private RowUi BuildRow(Transform parent, int index, float y); // 0x000000018030D680-0x000000018030EA30
	private void BuildResultPanel(); // 0x000000018030EA30-0x000000018030FB30
	private void LayoutResult(bool withRewards); // 0x000000018030FB30-0x000000018030FE50
	private static float PlaceBelow(RectTransform rt, float top, float h); // 0x000000018030FE50-0x000000018030FEB0
	private void OpenInternal(int petId, string petName, int bossLevel, RectTransform anchor); // 0x000000018030FEB0-0x0000000180310390
	private void ShowTip(); // 0x0000000180310390-0x0000000180310620
	[IteratorStateMachine(typeof(_RepositionNextFrame_d__130))]
	private IEnumerator RepositionNextFrame(); // 0x0000000180310620-0x00000001803106C0
	public static void OpenTicketInfo(int tierIndex, RectTransform anchor); // 0x00000001803106C0-0x0000000180310840
	private void ShowTicketInfo(int tierIndex, RectTransform anchor); // 0x0000000180310840-0x0000000180310DD0
	private void BindTicketInfo(int i); // 0x0000000180310DD0-0x0000000180311600
	private int EnergyCostOf(int i); // 0x0000000180311600-0x00000001803116F0
	private static string EnergyCostLine(int cost); // 0x00000001803116F0-0x00000001803117D0
	private void HideInfoTip(); // 0x00000001803117D0-0x0000000180311A60
	private void PositionTip(); // 0x0000000180311A60-0x0000000180311AA0
	private void PositionInfo(); // 0x0000000180311AA0-0x0000000180311AE0
	private void PositionNear(RectTransform rt, RectTransform anchorRt, float w, float h); // 0x0000000180311AE0-0x0000000180312310
	private void RequestClose(); // 0x0000000180312310-0x0000000180312510
	private void Close(); // 0x0000000180312510-0x00000001803129D0
	private void BackToTip(); // 0x00000001803129D0-0x0000000180312B50
	[IteratorStateMachine(typeof(_FetchInfo_d__143))]
	private IEnumerator FetchInfo(); // 0x0000000180312B50-0x0000000180312BF0
	private void OnInfo(BossSweepInfoDTO d); // 0x0000000180312BF0-0x0000000180313150
	private void OnRowClicked(int i); // 0x0000000180313150-0x00000001803137C0
	[IteratorStateMachine(typeof(_SweepRoutine_d__146))]
	private IEnumerator SweepRoutine(string tier); // 0x00000001803137C0-0x00000001803138D0
	private void ShowResult(BossSweepUseDTO d); // 0x00000001803138D0-0x0000000180313EB0
	private void ShowSuccess(BossSweepUseDTO d); // 0x0000000180313EB0-0x0000000180314750
	private void ShowFail(BossSweepUseDTO d); // 0x0000000180314750-0x0000000180314C00
	[IteratorStateMachine(typeof(_FlyRewardsToWallet_d__150))]
	private IEnumerator FlyRewardsToWallet(List<GameObject> cells, List<RewardDisplayHelper.Entry> entries); // 0x0000000180314C00-0x0000000180314CA0
	private void BindRow(int i, BossSweepTicketDTO t, bool bossLocked); // 0x0000000180314CA0-0x00000001803158A0
	private void ShowTipBusy(bool on, string label); // 0x00000001803158A0-0x0000000180315C70
	[IteratorStateMachine(typeof(_SpinRoutine_d__153))]
	private IEnumerator SpinRoutine(); // 0x0000000180315C70-0x0000000180315D10
	private void FailAndClose(string message); // 0x0000000180315D10-0x0000000180315D90
	private static string Friendly(string err); // 0x0000000180315D90-0x0000000180316090
	private int CurrentEnergy(); // 0x0000000180316090-0x00000001803161E0
	private static string TierNameOf(string tier); // 0x00000001803161E0-0x00000001803163D0
	private static void Stretch(RectTransform rt); // 0x00000001803163D0-0x0000000180316490
	private static Transform MakeBorder(RectTransform parent, string name, float thickness, Color color); // 0x0000000180316490-0x0000000180316DA0
	private static void SetBorderColor(Transform border, Color color); // 0x0000000180316DA0-0x0000000180317080
	private static bool Skin(Image img, string path, Color tint); // 0x0000000180317080-0x0000000180317380
	private static void MakeLine(RectTransform parent, string name, float y, float width); // 0x0000000180317380-0x0000000180317510
	private static Image NewImage(Transform parent, string name, Color color); // 0x0000000180317510-0x0000000180317800
	private static UnityEngine.UI.Text MakeText(Transform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style); // 0x0000000180317800-0x0000000180317DE0
	private static UnityEngine.UI.Text Fit(UnityEngine.UI.Text t, int minSize); // 0x0000000180317DE0-0x0000000180318030
	private void FadeIn(); // 0x0000000180318030-0x0000000180318250
	private static void PopIn(RectTransform rt); // 0x0000000180318250-0x00000001803184D0
	private static void Punch(RectTransform rt, float scale, float dur); // 0x00000001803184D0-0x0000000180318860
	private void Shake(RectTransform rt); // 0x0000000180318860-0x0000000180318C30
	private void PulseRed(UnityEngine.UI.Text target); // 0x0000000180318C30-0x0000000180318E80
	private void Flash(float peak, float dur); // 0x0000000180318E80-0x00000001803191C0
	private void OnDestroy(); // 0x00000001803191C0-0x0000000180319430
	[CompilerGenerated]
	private void _FetchInfo_b__143_0(string err); // 0x0000000180319C80-0x0000000180319CF0
	[CompilerGenerated]
	private void _Flash_b__171_0(float a); // 0x0000000180319CF0-0x0000000180319E40
	[CompilerGenerated]
	private void _Flash_b__171_1(); // 0x0000000180319E40-0x0000000180319FA0
}

