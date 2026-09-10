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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class BossSweepPopup : MonoBehaviour // TypeDefIndex: 365
{
	// Fields
	public const string FLAG_KEY = "bossSweep"; // Metadata: 0x0068AF1B
	private const float CANVAS_REF_W = 1300f; // Metadata: 0x0068AF25
	private const float CANVAS_REF_H = 731f; // Metadata: 0x0068AF29
	private const float PANEL_W = 760f; // Metadata: 0x0068AF2D
	private const float RES_PAD_X = 30f; // Metadata: 0x0068AF31
	private const float RES_PAD_TOP = 24f; // Metadata: 0x0068AF35
	private const float RES_PAD_BOT = 24f; // Metadata: 0x0068AF39
	private const float RES_TITLE_H = 58f; // Metadata: 0x0068AF3D
	private const float RES_SUB_H = 44f; // Metadata: 0x0068AF41
	private const float RES_GAP_SUB = 6f; // Metadata: 0x0068AF45
	private const float RES_CELL = 76f; // Metadata: 0x0068AF49
	private const float RES_REWARD_H = 80f; // Metadata: 0x0068AF4D
	private const float RES_GAP_REWARD = 4f; // Metadata: 0x0068AF51
	private const float RES_NAMES_H = 70f; // Metadata: 0x0068AF55
	private const float RES_GAP_NAMES = 2f; // Metadata: 0x0068AF59
	private const float RES_LEFT_H = 42f; // Metadata: 0x0068AF5D
	private const float RES_GAP_BTN = 10f; // Metadata: 0x0068AF61
	private const float RES_BTN_W = 330f; // Metadata: 0x0068AF65
	private const float RES_BTN_H = 80f; // Metadata: 0x0068AF69
	private const float TIP_W = 560f; // Metadata: 0x0068AF6D
	private const float TIP_PAD_X = 16f; // Metadata: 0x0068AF71
	private const float TIP_PAD_TOP = 34f; // Metadata: 0x0068AF75
	private const float TIP_PAD_BOT = 36f; // Metadata: 0x0068AF79
	private const float TIP_TITLE_H = 50f; // Metadata: 0x0068AF7D
	private const float TIP_ROW_H = 76f; // Metadata: 0x0068AF81
	private const float TIP_ROW_GAP = 6f; // Metadata: 0x0068AF85
	private const float TIP_WARN_H = 64f; // Metadata: 0x0068AF89
	private const float TIP_H = 438f; // Metadata: 0x0068AF8D
	private const float TIP_GAP = 14f; // Metadata: 0x0068AF91
	private const float TIP_MARGIN = 14f; // Metadata: 0x0068AF95
	private const float INFO_W = 480f; // Metadata: 0x0068AF99
	private const float INFO_PAD_X = 18f; // Metadata: 0x0068AF9D
	private const float INFO_PAD_TOP = 34f; // Metadata: 0x0068AFA1
	private const float INFO_PAD_BOT = 36f; // Metadata: 0x0068AFA5
	private const float INFO_HEAD_H = 56f; // Metadata: 0x0068AFA9
	private const float INFO_DESC_H = 100f; // Metadata: 0x0068AFAD
	private const float INFO_LABEL_H = 30f; // Metadata: 0x0068AFB1
	private const float INFO_BODY_H = 68f; // Metadata: 0x0068AFB5
	private const float INFO_COST_H = 34f; // Metadata: 0x0068AFB9
	private const float INFO_H = 520f; // Metadata: 0x0068AFBD
	private const int FS_INFO_TITLE = 32; // Metadata: 0x0068AFC1
	private const int FS_INFO_LABEL = 22; // Metadata: 0x0068AFC2
	private const int FS_INFO_BODY = 24; // Metadata: 0x0068AFC3
	private const int FS_TITLE = 44; // Metadata: 0x0068AFC4
	private const int FS_MAIN = 33; // Metadata: 0x0068AFC5
	private const int FS_BTN = 36; // Metadata: 0x0068AFC6
	private const int FS_SUB = 32; // Metadata: 0x0068AFC7
	private const int FS_NAMES = 26; // Metadata: 0x0068AFC8
	private const int FS_TIP_TITLE = 32; // Metadata: 0x0068AFC9
	private const int FS_TIP_NAME = 32; // Metadata: 0x0068AFCA
	private const int FS_TIP_OWNED = 30; // Metadata: 0x0068AFCB
	private const int FS_TIP_PCT = 52; // Metadata: 0x0068AFCC
	private const int FS_TIP_WARN = 24; // Metadata: 0x0068AFCD
	private static readonly string[] TIERS; // 0x00
	private static readonly string[] TIER_NAMES; // 0x08
	private static readonly long[] TIER_ITEM_IDS; // 0x10
	private static readonly int[] TIER_ENERGY_DEFAULTS; // 0x18
	private const string INFO_DESC = "B\u1ECF qua tr\u1EADn \u0111\u00E1nh \u2014 nh\u1EADn th\u1EB3ng ph\u1EA7n th\u01B0\u1EDFng c\u1EE7a con boss b\u1EA1n \u0110\u00C3 s\u0103n qua. T\u1EF7 l\u1EC7 th\u00E0nh c\u00F4ng do m\u00E1y ch\u1EE7 quy\u1EBFt, xem \u00F4 % \u1EDF t\u1EEBng h\u00E0ng v\u00E9."; // Metadata: 0x0068AFCE
	private static readonly string[] TIER_SOURCES; // 0x20
	private static readonly string[] TIER_FITS; // 0x28
	private static readonly Color[] TIER_COLORS; // 0x30
	private const string SP_PANEL = "Image/item/sweep_panel"; // Metadata: 0x0068B07B
	private const string SP_PANEL2 = "Image/item/sweep_panel2"; // Metadata: 0x0068B092
	private const string SP_ROW = "Image/item/sweep_row"; // Metadata: 0x0068B0AA
	private const string SP_TAG = "Image/item/sweep_tag"; // Metadata: 0x0068B0BF
	private const string SP_LINE = "Image/item/sweep_line"; // Metadata: 0x0068B0D4
	private const string NOT_HUNTED_MESSAGE = "Ph\u1EA3i t\u1EF1 tay h\u1EA1 boss n\u00E0y \u00EDt nh\u1EA5t m\u1ED9t l\u1EA7n r\u1ED3i m\u1EDBi d\u00F9ng v\u00E9 c\u00E0n qu\u00E9t \u0111\u01B0\u1EE3c."; // Metadata: 0x0068B0EA
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
	private class RowUi // TypeDefIndex: 366
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
		public RowUi(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 367
	{
		// Fields
		public BossSweepPopup __4__this; // 0x10
		public int captured; // 0x18
		public int capInfo; // 0x1C
		public RectTransform icrt; // 0x20

		// Constructors
		public __c__DisplayClass124_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildRow_b__0(); // 0x0000000180361230-0x0000000180361260
		internal void _BuildRow_b__1(); // 0x0000000180361260-0x0000000180361290
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass146_0 // TypeDefIndex: 368
	{
		// Fields
		public BossSweepUseDTO result; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass146_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SweepRoutine_b__0(BossSweepUseDTO d); // 0x0000000180317090-0x00000001803170A0
		internal void _SweepRoutine_b__1(string e); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 369
	{
		// Fields
		public RectTransform rt; // 0x10
		public float dur; // 0x18

		// Constructors
		public __c__DisplayClass168_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Punch_b__0(); // 0x0000000180361BC0-0x0000000180361CE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass169_0 // TypeDefIndex: 370
	{
		// Fields
		public RectTransform rt; // 0x10

		// Constructors
		public __c__DisplayClass169_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Shake_b__0(float v); // 0x0000000180361CE0-0x0000000180361DA0
		internal void _Shake_b__1(); // 0x0000000180361DA0-0x0000000180361E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass170_0 // TypeDefIndex: 371
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10

		// Constructors
		public __c__DisplayClass170_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseRed_b__0(float v); // 0x0000000180361E40-0x0000000180361FB0
	}

	[CompilerGenerated]
	private sealed class _FetchInfo_d__143 : IEnumerator<object> // TypeDefIndex: 372
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchInfo_d__143(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018035FA30-0x000000018035FC60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035FC60-0x000000018035FCA0
	}

	[CompilerGenerated]
	private sealed class _FlyRewardsToWallet_d__150 : IEnumerator<object> // TypeDefIndex: 373
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<GameObject> cells; // 0x20
		private RectTransform _wallet_5__2; // 0x28
		private int _i_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlyRewardsToWallet_d__150(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x000000018035FCA0-0x000000018035FF60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035FF60-0x000000018035FFA0
	}

	[CompilerGenerated]
	private sealed class _RepositionNextFrame_d__130 : IEnumerator<object> // TypeDefIndex: 374
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RepositionNextFrame_d__130(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180360480-0x00000001803605D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803605D0-0x0000000180360610
	}

	[CompilerGenerated]
	private sealed class _SpinRoutine_d__153 : IEnumerator<object> // TypeDefIndex: 375
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinRoutine_d__153(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180360610-0x0000000180360700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180360700-0x0000000180360740
	}

	[CompilerGenerated]
	private sealed class _SweepRoutine_d__146 : IEnumerator<object> // TypeDefIndex: 376
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BossSweepPopup __4__this; // 0x20
		public string tier; // 0x28
		private __c__DisplayClass146_0 __8__1; // 0x30
		private float _revealAt_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SweepRoutine_d__146(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180360740-0x0000000180360EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180360EC0-0x0000000180360F00
	}

	// Constructors
	public BossSweepPopup(); // 0x000000018033FDE0-0x000000018033FE40
	static BossSweepPopup(); // 0x000000018033F840-0x000000018033FDE0

	// Methods
	public static void Open(int petId, string petName, int bossLevel, RectTransform anchor = null); // 0x000000018033C8E0-0x000000018033CA50
	public static void CloseIfOpen(); // 0x0000000180339700-0x00000001803397C0
	private static BossSweepPopup Ensure(); // 0x0000000180339BB0-0x000000018033A060
	private void Build(); // 0x00000001803393F0-0x0000000180339700
	private void BuildTip(); // 0x0000000180338860-0x00000001803393F0
	private void BuildInfoTip(); // 0x00000001803367E0-0x0000000180337010
	private static void MakeInfoLabel(RectTransform parent, string name, float y, float w, string value); // 0x000000018033B150-0x000000018033B270
	private RowUi BuildRow(Transform parent, int index, float y); // 0x0000000180337BD0-0x0000000180338860
	private void BuildResultPanel(); // 0x0000000180337010-0x0000000180337BD0
	private void LayoutResult(bool withRewards); // 0x000000018033A9C0-0x000000018033AC80
	private static float PlaceBelow(RectTransform rt, float top, float h); // 0x000000018033CA50-0x000000018033CAB0
	private void OpenInternal(int petId, string petName, int bossLevel, RectTransform anchor); // 0x000000018033C560-0x000000018033C7F0
	private void ShowTip(); // 0x000000018033F000-0x000000018033F1A0
	[IteratorStateMachine(typeof(_RepositionNextFrame_d__130))]
	private IEnumerator RepositionNextFrame(); // 0x000000018033D500-0x000000018033D570
	public static void OpenTicketInfo(int tierIndex, RectTransform anchor); // 0x000000018033C7F0-0x000000018033C8E0
	private void ShowTicketInfo(int tierIndex, RectTransform anchor); // 0x000000018033EAF0-0x000000018033EE60
	private void BindTicketInfo(int i); // 0x0000000180336310-0x00000001803367E0
	private int EnergyCostOf(int i); // 0x0000000180339AC0-0x0000000180339BB0
	private static string EnergyCostLine(int cost); // 0x0000000180339A40-0x0000000180339AC0
	private void HideInfoTip(); // 0x000000018033A8B0-0x000000018033A9C0
	private void PositionTip(); // 0x000000018033D100-0x000000018033D140
	private void PositionInfo(); // 0x000000018033CC20-0x000000018033CC60
	private void PositionNear(RectTransform rt, RectTransform anchorRt, float w, float h); // 0x000000018033CC60-0x000000018033D100
	private void RequestClose(); // 0x000000018033D570-0x000000018033D680
	private void Close(); // 0x00000001803397C0-0x0000000180339960
	private void BackToTip(); // 0x0000000180335B00-0x0000000180335BE0
	[IteratorStateMachine(typeof(_FetchInfo_d__143))]
	private IEnumerator FetchInfo(); // 0x000000018033A280-0x000000018033A2F0
	private void OnInfo(BossSweepInfoDTO d); // 0x000000018033BB50-0x000000018033C040
	private void OnRowClicked(int i); // 0x000000018033C040-0x000000018033C560
	[IteratorStateMachine(typeof(_SweepRoutine_d__146))]
	private IEnumerator SweepRoutine(string tier); // 0x000000018033F480-0x000000018033F510
	private void ShowResult(BossSweepUseDTO d); // 0x000000018033DE70-0x000000018033E330
	private void ShowSuccess(BossSweepUseDTO d); // 0x000000018033E330-0x000000018033EAF0
	private void ShowFail(BossSweepUseDTO d); // 0x000000018033D9F0-0x000000018033DE70
	[IteratorStateMachine(typeof(_FlyRewardsToWallet_d__150))]
	private IEnumerator FlyRewardsToWallet(List<GameObject> cells, List<RewardDisplayHelper.Entry> entries); // 0x000000018033A5C0-0x000000018033A630
	private void BindRow(int i, BossSweepTicketDTO t, bool bossLocked); // 0x0000000180335BE0-0x0000000180336310
	private void ShowTipBusy(bool on, string label); // 0x000000018033EE60-0x000000018033F000
	[IteratorStateMachine(typeof(_SpinRoutine_d__153))]
	private IEnumerator SpinRoutine(); // 0x000000018033F350-0x000000018033F3C0
	private void FailAndClose(string message); // 0x000000018033A170-0x000000018033A280
	private static string Friendly(string err); // 0x000000018033A630-0x000000018033A8B0
	private int CurrentEnergy(); // 0x0000000180339960-0x0000000180339A40
	private static string TierNameOf(string tier); // 0x000000018033F510-0x000000018033F670
	private static void Stretch(RectTransform rt); // 0x000000018033F3C0-0x000000018033F480
	private static Transform MakeBorder(RectTransform parent, string name, float thickness, Color color); // 0x000000018033AC80-0x000000018033B150
	private static void SetBorderColor(Transform border, Color color); // 0x000000018033D680-0x000000018033D790
	private static bool Skin(Image img, string path, Color tint); // 0x000000018033F1A0-0x000000018033F350
	private static void MakeLine(RectTransform parent, string name, float y, float width); // 0x000000018033B270-0x000000018033B3F0
	private static Image NewImage(Transform parent, string name, Color color); // 0x000000018033B810-0x000000018033BA50
	private static UnityEngine.UI.Text MakeText(Transform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style); // 0x000000018033B3F0-0x000000018033B810
	private static UnityEngine.UI.Text Fit(UnityEngine.UI.Text t, int minSize); // 0x000000018033A2F0-0x000000018033A3B0
	private void FadeIn(); // 0x000000018033A060-0x000000018033A170
	private static void PopIn(RectTransform rt); // 0x000000018033CAB0-0x000000018033CC20
	private static void Punch(RectTransform rt, float scale, float dur); // 0x000000018033D2D0-0x000000018033D500
	private void Shake(RectTransform rt); // 0x000000018033D790-0x000000018033D9F0
	private void PulseRed(UnityEngine.UI.Text target); // 0x000000018033D140-0x000000018033D2D0
	private void Flash(float peak, float dur); // 0x000000018033A3B0-0x000000018033A5C0
	private void OnDestroy(); // 0x000000018033BA50-0x000000018033BB50
	[CompilerGenerated]
	private void _FetchInfo_b__143_0(string err); // 0x000000018033F670-0x000000018033F6E0
	[CompilerGenerated]
	private void _Flash_b__171_0(float a); // 0x000000018033F6E0-0x000000018033F7B0
	[CompilerGenerated]
	private void _Flash_b__171_1(); // 0x000000018033F7B0-0x000000018033F840
}

