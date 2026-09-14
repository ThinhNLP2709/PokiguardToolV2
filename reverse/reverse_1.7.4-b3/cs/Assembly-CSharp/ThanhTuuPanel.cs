/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public sealed class ThanhTuuPanel : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1288
{
	// Fields
	public const string N_ROOT = "[ThanhTuuPanel]"; // Metadata: 0x005EF68E
	public const int SORT_ORDER = 400; // Metadata: 0x005EF69E
	public const string PREF_LAST_GROUP = "ThanhTuu.lastGroup"; // Metadata: 0x005EF6A0
	public const float SPINNER_MIN = 0.35f; // Metadata: 0x005EF6B3
	public const float BG_ASPECT = 2f; // Metadata: 0x005EF6B7
	public const int MAX_SHORTCUTS = 4; // Metadata: 0x005EF6BB
	public const int MAX_ROWS = 100; // Metadata: 0x005EF6BC
	public const float FILL_MIN = 60f; // Metadata: 0x005EF6BE
	public const float HIT = 96f; // Metadata: 0x005EF6C2
	public const string NOT_IN_HUB = "H\u00E3y v\u1EC1 Qu\u1EA3ng Tr\u01B0\u1EDDng \u0111\u1EC3 v\u00E0o Chinh Ph\u1EE5c"; // Metadata: 0x005EF6C6
	public const string DEFAULT_SOURCE = "Ho\u00E0n th\u00E0nh th\u00E0nh t\u1EF1u"; // Metadata: 0x005EF6FA
	public static readonly Color DIM; // 0x00
	public static readonly Color TITLE_TOP; // 0x10
	public static readonly Color TITLE_BOTTOM; // 0x20
	public static readonly Color TITLE_OUTLINE; // 0x30
	public static readonly Color TITLE_SHADOW; // 0x40
	public static readonly Color WALLET_OUTLINE; // 0x50
	public static readonly Color ENERGY_COLOR; // 0x60
	public static readonly Color PROGRESS_LABEL; // 0x70
	public static readonly Color NAVY_OUTLINE; // 0x80
	public static readonly Color SC_LABEL; // 0x90
	private const float SC_LABEL_W = 132f; // Metadata: 0x005EF714
	public static readonly Color SC_LINE; // 0xA0
	public static readonly Color TAG_OUTLINE; // 0xB0
	private static readonly string[] OTHER_PANELS; // 0xC0
	private static ThanhTuuPanel _instance; // 0xC8
	private bool _built; // 0x20
	private int _builtVersion; // 0x24
	private Canvas _canvas; // 0x28
	private GraphicRaycaster _raycaster; // 0x30
	private CanvasGroup _group; // 0x38
	private RectTransform _root; // 0x40
	private RectTransform _content; // 0x48
	private RectTransform _fxAnchor; // 0x50
	private Image _dim; // 0x58
	private Image _imgBg; // 0x60
	private Image _titlePlate; // 0x68
	private UnityEngine.UI.Text _txtTitle; // 0x70
	private RectTransform _walletRt; // 0x78
	private Image _walletImg; // 0x80
	private Image _icEnergy; // 0x88
	private UnityEngine.UI.Text _txtWalletLabel; // 0x90
	private UnityEngine.UI.Text _txtEnergy; // 0x98
	private RectTransform _progressRt; // 0xA0
	private RectTransform _barFrameRt; // 0xA8
	private RectTransform _barFillRt; // 0xB0
	private RectTransform _txtProgressRt; // 0xB8
	private RectTransform _marqueeRt; // 0xC0
	private Image _progressImg; // 0xC8
	private Image _barFrame; // 0xD0
	private Image _barFill; // 0xD8
	private UnityEngine.UI.Text _txtProgressLabel; // 0xE0
	private UnityEngine.UI.Text _txtProgress; // 0xE8
	private ThanhTuuMarquee _marquee; // 0xF0
	private RectTransform _chestGlowRt; // 0xF8
	private RectTransform _chestRt; // 0x100
	private RectTransform _chestTagRt; // 0x108
	private RectTransform _homeRt; // 0x110
	private RectTransform _helpRt; // 0x118
	private Image _chestGlow; // 0x120
	private Image _chestImg; // 0x128
	private Image _chestTagImg; // 0x130
	private Image _homeImg; // 0x138
	private Image _helpImg; // 0x140
	private UnityEngine.UI.Text _txtChestTag; // 0x148
	private RectTransform _panelLeftRt; // 0x150
	private RectTransform _panelListRt; // 0x158
	private RectTransform _panelRightRt; // 0x160
	private RectTransform _dividerRt; // 0x168
	private Image _panelLeft; // 0x170
	private Image _panelList; // 0x178
	private Image _panelRight; // 0x180
	private Image _divider; // 0x188
	private ThanhTuuTabList _tabs; // 0x190
	private RectTransform _svRowsRt; // 0x198
	private RectTransform _rowsContent; // 0x1A0
	private RectTransform _rowsTrack; // 0x1A8
	private RectTransform _rowsKnob; // 0x1B0
	private ScrollRect _rowsScroll; // 0x1B8
	private readonly List<ThanhTuuRowView> _rows; // 0x1C0
	private readonly Shortcut[] _shortcuts; // 0x1C8
	private ThanhTuuRewardPopup _rewardPopup; // 0x1D0
	private ThanhTuuPreviewPopup _previewPopup; // 0x1D8
	private ThanhTuuTooltip _tooltip; // 0x1E0
	private ThanhTuuSpinner _spinner; // 0x1E8
	private RectTransform _guideRt; // 0x1F0
	private RectTransform _guideContent; // 0x1F8
	private RectTransform _guideView; // 0x200
	private UnityEngine.UI.Text _guideTitle; // 0x208
	private UnityEngine.UI.Text _guideBody; // 0x210
	private ScrollRect _guideScroll; // 0x218
	private Vector4 _rWallet; // 0x220
	private Vector4 _rProgress; // 0x230
	private Vector4 _rBarFrame; // 0x240
	private Vector4 _rBarFill; // 0x250
	private Vector4 _rTxtProgress; // 0x260
	private Vector4 _rMarquee; // 0x270
	private Vector4 _rChestGlow; // 0x280
	private Vector4 _rChest; // 0x290
	private Vector4 _rChestTag; // 0x2A0
	private Vector4 _rDivider; // 0x2B0
	private Vector4 _rLeft; // 0x2C0
	private Vector4 _rList; // 0x2D0
	private Vector4 _rSvRows; // 0x2E0
	private Vector4 _rRight; // 0x2F0
	private Vector4 _rHome; // 0x300
	private Vector4 _rHelp; // 0x310
	private float _rowsKnobX; // 0x320
	private float _bleedX; // 0x324
	private float _bleedY; // 0x328
	private ThanhTuuState _state; // 0x330
	private ThanhTuuState _deferred; // 0x338
	private ThanhTuuStrings _str; // 0x340
	private string _boundPrefix; // 0x348
	private int _selectedGroupId; // 0x350
	private float _progressP; // 0x354
	private long _shownEnergy; // 0x358
	private bool _hasEnergy; // 0x360
	private int _stateOwner; // 0x364
	private bool _busy; // 0x368
	private bool _closing; // 0x369
	private bool _refetching; // 0x36A
	private ThanhTuuRowView _busyRow; // 0x370
	private int _energyId; // 0x378
	private int _barId; // 0x37C
	private int _glowId; // 0x380
	private int _wobbleId; // 0x384
	private int _rowsScrollId; // 0x388
	private int _closeId; // 0x38C
	private Coroutine _backLoop; // 0x390
	private int _reqGen; // 0x398
	private bool _suspendHooked; // 0x39C
	private readonly List<GraphicRaycaster> _subRaycasters; // 0x3A0

	// Properties
	public static ThanhTuuPanel Instance { get; } // 0x000000018071B100-0x000000018071B160 
	public static bool IsOpen { get; } // 0x000000018071B160-0x000000018071B3F0 
	internal ThanhTuuState State { get; } // 0x000000018071B3F0-0x000000018071B400 
	internal int SelectedGroupId { get; } // 0x000000018071B400-0x000000018071B410 
	internal bool Busy { get; } // 0x000000018071B410-0x000000018071B420 
	internal ThanhTuuRewardPopup RewardPopup { get; } // 0x000000018071B420-0x000000018071B430 
	internal ThanhTuuPreviewPopup PreviewPopup { get; } // 0x000000018071B430-0x000000018071B440 
	internal ThanhTuuTooltip Tooltip { get; } // 0x000000018071B440-0x000000018071B450 
	internal ThanhTuuSpinner Spinner { get; } // 0x000000018071B450-0x000000018071B460 
	internal ThanhTuuTabList Tabs { get; } // 0x000000018071B460-0x000000018071B470 
	internal float BleedX { get; } // 0x000000018071B470-0x000000018071B480 
	private bool CloseBlocked { get; } // 0x000000018071CA40-0x000000018071CB60 

	// Nested types
	private sealed class Shortcut // TypeDefIndex: 1289
	{
		// Fields
		public RectTransform rt; // 0x10
		public Image icon; // 0x18
		public Image line; // 0x20
		public UnityEngine.UI.Text label; // 0x28
		public ThanhTuuShortcut data; // 0x30
		public string art; // 0x38

		// Constructors
		public Shortcut(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1290
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<bool> __9__156_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180731B50-0x0000000180731BF0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RegisterOpener_b__156_0(); // 0x0000000180731BF0-0x0000000180731C40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass189_0 // TypeDefIndex: 1291
	{
		// Fields
		public int slot; // 0x10
		public ThanhTuuPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass189_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildColumns_b__0(); // 0x0000000180731C40-0x0000000180731C70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass230_0 // TypeDefIndex: 1292
	{
		// Fields
		public ThanhTuuPanel __4__this; // 0x10
		public int owner; // 0x18

		// Constructors
		public __c__DisplayClass230_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestState_b__0(ThanhTuuState s); // 0x0000000180731C70-0x0000000180731CA0
		internal void _RequestState_b__1(string err); // 0x0000000180731CA0-0x0000000180731CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass236_0 // TypeDefIndex: 1293
	{
		// Fields
		public ThanhTuuPanel __4__this; // 0x10
		public int gen; // 0x18
		public int owner; // 0x1C

		// Constructors
		public __c__DisplayClass236_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClaimTap_b__0(ThanhTuuClaimResult r); // 0x0000000180731CD0-0x0000000180731D10
		internal void _OnClaimTap_b__1(string err); // 0x0000000180731D10-0x0000000180731D50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass237_0 // TypeDefIndex: 1294
	{
		// Fields
		public ThanhTuuPanel __4__this; // 0x10
		public int gen; // 0x18
		public int owner; // 0x1C

		// Constructors
		public __c__DisplayClass237_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnChestTap_b__0(ThanhTuuClaimResult r); // 0x0000000180731CD0-0x0000000180731D10
		internal void _OnChestTap_b__1(string err); // 0x0000000180731D10-0x0000000180731D50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass243_0 // TypeDefIndex: 1295
	{
		// Fields
		public ThanhTuuPanel __4__this; // 0x10
		public int gen; // 0x18
		public ThanhTuuClaimResult r; // 0x20
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass243_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClaimOk_b__0(); // 0x0000000180731D50-0x0000000180731FE0
		internal void _OnClaimOk_b__1(); // 0x0000000180731FE0-0x0000000180732010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass244_0 // TypeDefIndex: 1296
	{
		// Fields
		public ThanhTuuPanel __4__this; // 0x10
		public int gen; // 0x18
		public string code; // 0x20
		public string err; // 0x28

		// Constructors
		public __c__DisplayClass244_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClaimErr_b__0(); // 0x0000000180732010-0x0000000180732270
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass246_0 // TypeDefIndex: 1297
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass246_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlyEnergy_b__0(); // 0x0000000180732270-0x0000000180732420
	}

	[CompilerGenerated]
	private sealed class _BackLoop_d__184 : IEnumerator<object> // TypeDefIndex: 1298
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ThanhTuuPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BackLoop_d__184(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180732420-0x0000000180732590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180732590-0x00000001807325D0
	}

	// Constructors
	public ThanhTuuPanel(); // 0x0000000180731110-0x00000001807314C0
	static ThanhTuuPanel(); // 0x00000001807314C0-0x0000000180731B50

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x000000018071B480-0x000000018071B6A0
	public static void Open(); // 0x000000018071B6A0-0x000000018071BD20
	public static void CloseIfOpen(); // 0x000000018071BD20-0x000000018071BFA0
	public void Close(); // 0x000000018071BFA0-0x000000018071C850
	private void FinishClose(); // 0x000000018071C850-0x000000018071C9C0
	private void CloseNow(); // 0x000000018071C9C0-0x000000018071CA40
	private void OnHomeTap(); // 0x000000018071CB60-0x000000018071CBA0
	private void ShowPanel(); // 0x000000018071CBA0-0x000000018071CEC0
	private void SetShown(bool on); // 0x000000018071CEC0-0x000000018071D820
	private void HookSuspend(); // 0x000000018071D820-0x000000018071D8F0
	private void UnhookSuspend(); // 0x000000018071D8F0-0x000000018071D960
	public void OnHubSuspend(); // 0x000000018071D960-0x000000018071DBB0
	public void OnHubResume(); // 0x000000018028A320-0x000000018028A330
	private void HidePopups(); // 0x000000018071DBB0-0x000000018071DDE0
	private void ResetFxIds(); // 0x000000018071DDE0-0x000000018071DE10
	private void Awake(); // 0x000000018071DE10-0x000000018071DFA0
	private void OnDisable(); // 0x000000018071DFA0-0x000000018071E080
	private void OnDestroy(); // 0x000000018071E080-0x000000018071E2F0
	private void OnRectTransformDimensionsChange(); // 0x000000018071E2F0-0x000000018071E3E0
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x000000018071E3E0-0x000000018071E530
	private bool AliveUi(); // 0x000000018071E530-0x000000018071E710
	private static bool FlagOn(); // 0x000000018071E710-0x000000018071E760
	private static int LayoutVersion(); // 0x000000018071E760-0x000000018071E800
	private static void CloseOthers(); // 0x000000018071E800-0x000000018071EBD0
	private void StartBackLoop(); // 0x000000018071EBD0-0x000000018071ED50
	private void StopBackLoop(); // 0x000000018071ED50-0x000000018071EDD0
	[IteratorStateMachine(typeof(_BackLoop_d__184))]
	private IEnumerator BackLoop(); // 0x000000018071EDD0-0x000000018071EE70
	private void OnBack(); // 0x000000018071EE70-0x000000018071F640
	private void Build(); // 0x000000018071F640-0x0000000180720240
	private void BuildBody(); // 0x0000000180720240-0x00000001807209F0
	private void BuildHeader(); // 0x00000001807209F0-0x0000000180722D60
	private void BuildColumns(); // 0x0000000180722D60-0x0000000180724860
	private void BuildCornerButtons(); // 0x0000000180724860-0x0000000180724D30
	private void BuildGuide(); // 0x0000000180724D30-0x00000001807259F0
	private static Vector4 Local(Vector4 abs, Vector4 parent); // 0x00000001807259F0-0x0000000180725A20
	private void SubCanvas(GameObject go, bool input); // 0x0000000180725A20-0x0000000180725EF0
	private void BindStatics(bool force); // 0x0000000180725EF0-0x0000000180726990
	private void BindEnergyIcon(); // 0x0000000180726990-0x0000000180726CB0
	private void RefreshSlices(); // 0x0000000180726CB0-0x0000000180726D80
	private void ApplyBleed(); // 0x0000000180726D80-0x0000000180727A70
	private Vector2 RootSize(); // 0x0000000180727A70-0x0000000180727DE0
	private static void PlaceCentered(RectTransform rt, float x, float y, float w, float h); // 0x0000000180727DE0-0x0000000180727F60
	private void RenderState(ThanhTuuState s); // 0x0000000180727F60-0x0000000180727F70
	private void Render(ThanhTuuState s, bool animate); // 0x0000000180727F70-0x00000001807284A0
	private void RenderEmpty(); // 0x00000001807284A0-0x0000000180728DC0
	private void SetChestShown(bool on); // 0x0000000180728DC0-0x0000000180729140
	private static int SelfId(); // 0x0000000180729140-0x0000000180729190
	private int PickGroup(ThanhTuuState s); // 0x0000000180729190-0x0000000180729400
	private ThanhTuuGroup SelectedGroup(); // 0x0000000180729400-0x0000000180729430
	private void SelectGroup(int groupId, bool animate); // 0x0000000180729430-0x0000000180729920
	private void RenderRows(ThanhTuuGroup g, bool slide); // 0x0000000180729920-0x0000000180729EE0
	private ThanhTuuRowView EnsureRow(int i); // 0x0000000180729EE0-0x000000018072A0F0
	private ThanhTuuRowView FindRow(int taskId); // 0x000000018072A0F0-0x000000018072A2B0
	private void RenderProgress(ThanhTuuGroup g, bool animate); // 0x000000018072A2B0-0x000000018072A480
	private void ApplyFill(bool animate); // 0x000000018072A480-0x000000018072A8E0
	private void RenderChest(ThanhTuuGroup g); // 0x000000018072A8E0-0x000000018072AE80
	private void RenderShortcuts(ThanhTuuGroup g); // 0x000000018072AE80-0x000000018072B380
	private static bool KnownShortcut(string key); // 0x000000018072B380-0x000000018072B430
	private void SetEnergy(long value, bool animate); // 0x000000018072B430-0x000000018072B7B0
	private float RowsViewH(); // 0x000000018072B7B0-0x000000018072BA90
	private void ScrollToFirstReady(bool animate); // 0x000000018072BA90-0x000000018072C190
	private void OnRowsScroll(Vector2 _); // 0x000000018072C190-0x000000018072C1A0
	private void UpdateRowsKnob(); // 0x000000018072C1A0-0x000000018072C630
	private void OnTabTap(int groupId); // 0x000000018072C630-0x000000018072C770
	private void OnRowSlotTap(ThanhTuuRowView row); // 0x000000018072C770-0x000000018072C890
	private void OnPreviewSlotTap(RectTransform slot, RewardDisplayHelper.Entry e); // 0x000000018072C890-0x000000018072C910
	private void ShowTip(RectTransform anchor, RewardDisplayHelper.Entry e, RechargeEventReward reward); // 0x000000018072C910-0x000000018072CC30
	private void OnChestPreview(); // 0x000000018072CC30-0x000000018072CE40
	private void OnShortcut(int slot); // 0x000000018072CE40-0x000000018072D0E0
	private void OpenGuide(); // 0x000000018072D0E0-0x000000018072D610
	private void HideGuide(); // 0x000000018072D610-0x000000018072D890
	private void FillGuide(); // 0x000000018072D890-0x000000018072DCA0
	private void RequestState(); // 0x000000018072DCA0-0x000000018072DEC0
	private void OnState(int owner, ThanhTuuState s); // 0x000000018072DEC0-0x000000018072E070
	private void OnStateError(int owner, string err); // 0x000000018072E070-0x000000018072E270
	private void ApplyFetched(ThanhTuuState s); // 0x000000018072E270-0x000000018072E4E0
	private void OnGlobalRefetched(); // 0x000000018072E4E0-0x000000018072E620
	private void FlushDeferred(); // 0x000000018072E620-0x000000018072E6A0
	private void OnClaimTap(ThanhTuuRowView row); // 0x000000018072E6A0-0x000000018072EAA0
	private void OnChestTap(); // 0x000000018072EAA0-0x000000018072EE00
	private int BeginBusy(ThanhTuuRowView row); // 0x000000018072EE00-0x000000018072F120
	private void EndBusy(); // 0x000000018072F120-0x000000018072F290
	private void ShowSpinner(bool on); // 0x000000018072F290-0x000000018072F3D0
	private float SpinnerWait(); // 0x000000018072F3D0-0x000000018072F550
	private void ApplyClaimGlobals(int owner, ThanhTuuState state, bool refreshWallet, bool refetch); // 0x000000018072F550-0x000000018072F990
	private void OnClaimOk(int gen, int owner, ThanhTuuClaimResult r); // 0x000000018072F990-0x000000018072FCE0
	private void OnClaimErr(int gen, int owner, string err); // 0x000000018072FCE0-0x00000001807301A0
	private void AfterClaim(int gen, ThanhTuuClaimResult r); // 0x00000001807301A0-0x0000000180730920
	private void FlyEnergy(Vector3 fromWorld); // 0x0000000180730920-0x0000000180731110
}

