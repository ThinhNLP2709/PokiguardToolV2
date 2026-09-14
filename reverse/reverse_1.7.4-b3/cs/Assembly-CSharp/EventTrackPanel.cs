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
public class EventTrackPanel : MonoBehaviour // TypeDefIndex: 642
{
	// Fields
	public const string N_ROOT = "[EventTrackPanel]"; // Metadata: 0x005EE465
	private const int SORT_ORDER = 400; // Metadata: 0x005EE477
	private const float BOX_X = 187f; // Metadata: 0x005EE479
	private const float BOX_Y = 53f; // Metadata: 0x005EE47D
	private const float BOX_W = 1400f; // Metadata: 0x005EE481
	private const float BOX_H = 780f; // Metadata: 0x005EE485
	private const float TITLE_X = 0f; // Metadata: 0x005EE489
	private const float TITLE_Y = 26f; // Metadata: 0x005EE48D
	private const float TITLE_W = 1400f; // Metadata: 0x005EE491
	private const float TITLE_H = 60f; // Metadata: 0x005EE495
	private const float CD_X = 0f; // Metadata: 0x005EE499
	private const float CD_Y = 90f; // Metadata: 0x005EE49D
	private const float CD_W = 1400f; // Metadata: 0x005EE4A1
	private const float CD_H = 34f; // Metadata: 0x005EE4A5
	private const float CLOSE_X = 1316f; // Metadata: 0x005EE4A9
	private const float CLOSE_Y = 20f; // Metadata: 0x005EE4AD
	private const float CLOSE_W = 64f; // Metadata: 0x005EE4B1
	private const float CLOSE_H = 64f; // Metadata: 0x005EE4B5
	private const float CLOSE_HIT = 96f; // Metadata: 0x005EE4B9
	private const float JAR_X = 90f; // Metadata: 0x005EE4BD
	private const float JAR_Y = 150f; // Metadata: 0x005EE4C1
	private const float JAR_W = 300f; // Metadata: 0x005EE4C5
	private const float JAR_H = 360f; // Metadata: 0x005EE4C9
	private const float TOTAL_X = 60f; // Metadata: 0x005EE4CD
	private const float TOTAL_Y = 522f; // Metadata: 0x005EE4D1
	private const float TOTAL_W = 360f; // Metadata: 0x005EE4D5
	private const float TOTAL_H = 72f; // Metadata: 0x005EE4D9
	private const float UNIT_X = 60f; // Metadata: 0x005EE4DD
	private const float UNIT_Y = 590f; // Metadata: 0x005EE4E1
	private const float UNIT_W = 360f; // Metadata: 0x005EE4E5
	private const float UNIT_H = 30f; // Metadata: 0x005EE4E9
	private const float PILL_X = 110f; // Metadata: 0x005EE4ED
	private const float PILL_Y = 632f; // Metadata: 0x005EE4F1
	private const float PILL_W = 260f; // Metadata: 0x005EE4F5
	private const float PILL_H = 56f; // Metadata: 0x005EE4F9
	private const float HINT_X = 40f; // Metadata: 0x005EE4FD
	private const float HINT_Y = 700f; // Metadata: 0x005EE501
	private const float HINT_W = 420f; // Metadata: 0x005EE505
	private const float HINT_H = 60f; // Metadata: 0x005EE509
	private const float TRACK_X = 480f; // Metadata: 0x005EE50D
	private const float TRACK_Y = 130f; // Metadata: 0x005EE511
	private const float TRACK_W = 880f; // Metadata: 0x005EE515
	private const float TRACK_H = 600f; // Metadata: 0x005EE519
	private const float NOTE_X = 480f; // Metadata: 0x005EE51D
	private const float NOTE_Y = 742f; // Metadata: 0x005EE521
	private const float NOTE_W = 880f; // Metadata: 0x005EE525
	private const float NOTE_H = 28f; // Metadata: 0x005EE529
	private const float ROW_GAP = 10f; // Metadata: 0x005EE52D
	private const float DROP_SIZE = 120f; // Metadata: 0x005EE531
	private const float RING_X = 10f; // Metadata: 0x005EE535
	private const float RING_Y = 0f; // Metadata: 0x005EE539
	private const float RING_D = 280f; // Metadata: 0x005EE53D
	private const float ORB_X = 38f; // Metadata: 0x005EE541
	private const float ORB_Y = 28f; // Metadata: 0x005EE545
	private const float ORB_D = 224f; // Metadata: 0x005EE549
	private const float PED_X = 35f; // Metadata: 0x005EE54D
	private const float PED_Y = 180f; // Metadata: 0x005EE551
	private const float PED_W = 230f; // Metadata: 0x005EE555
	private const float PED_H = 96f; // Metadata: 0x005EE559
	private const float HERO_X = 75f; // Metadata: 0x005EE55D
	private const float HERO_Y = 46f; // Metadata: 0x005EE561
	private const float HERO_W = 150f; // Metadata: 0x005EE565
	private const float HERO_H = 188f; // Metadata: 0x005EE569
	private const long SOON_SEC = 172800; // Metadata: 0x005EE56D
	private static readonly TimeSpan VN_OFFSET; // 0x00
	private static readonly Color RED; // 0x08
	private static EventTrackPanel _instance; // 0x18
	private Canvas _canvas; // 0x20
	private GraphicRaycaster _raycaster; // 0x28
	private CanvasGroup _group; // 0x30
	private RectTransform _content; // 0x38
	private RectTransform _box; // 0x40
	private long _builtConfigVersion; // 0x48
	private Image _imgBg; // 0x50
	private Image _imgFlash; // 0x58
	private Image _jarFill; // 0x60
	private Image _imgDrop; // 0x68
	private Image _pillBg; // 0x70
	private Image _imgRing; // 0x78
	private Image _imgPedestal; // 0x80
	private RectTransform _rainArea; // 0x88
	private RectTransform _jarFrame; // 0x90
	private RectTransform _trackContent; // 0x98
	private RectTransform _burstAnchor; // 0xA0
	private UnityEngine.UI.Text _txtTitle; // 0xA8
	private UnityEngine.UI.Text _txtCountdown; // 0xB0
	private UnityEngine.UI.Text _txtTotal; // 0xB8
	private UnityEngine.UI.Text _txtUnit; // 0xC0
	private UnityEngine.UI.Text _txtPill; // 0xC8
	private UnityEngine.UI.Text _txtHint; // 0xD0
	private UnityEngine.UI.Text _txtNote; // 0xD8
	private Button _btnClose; // 0xE0
	private readonly List<EventTrackRow> _rows; // 0xE8
	private string _key; // 0xF0
	private EventTrackState _state; // 0xF8
	private bool _busy; // 0x100
	private bool _ended; // 0x101
	private long _milestoneInFlight; // 0x108
	private long _serverMs; // 0x110
	private float _syncAt; // 0x118
	private long _endMs; // 0x120
	private long _startMs; // 0x128
	private long _surgeEndMs; // 0x130
	private long _surgeNextMs; // 0x138
	private bool _surgeActive; // 0x140
	private int _surgeMult; // 0x144
	private bool _refetching; // 0x148
	private bool _weatherStarted; // 0x149
	private Coroutine _tick; // 0x150

	// Properties
	public static bool IsOpen { get; } // 0x0000000180442FD0-0x0000000180443220 
	public static string OpenKey { get; } // 0x0000000180443220-0x0000000180443370 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 643
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, string> __9__130_0; // 0x08

		// Constructors
		static __c(); // 0x000000018044E890-0x000000018044E930
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal string _Render_b__130_0(long v); // 0x000000018044E930-0x000000018044E9C0
	}

	[CompilerGenerated]
	private sealed class _TickLoop_d__139 : IEnumerator<object> // TypeDefIndex: 644
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EventTrackPanel __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TickLoop_d__139(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018044E9C0-0x000000018044ECE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044ECE0-0x000000018044ED20
	}

	// Constructors
	public EventTrackPanel(); // 0x000000018044E5C0-0x000000018044E7A0
	static EventTrackPanel(); // 0x000000018044E7A0-0x000000018044E880

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x0000000180443370-0x0000000180443520
	public static bool Open(string key); // 0x0000000180443520-0x0000000180443DE0
	public static void CloseIfOpen(); // 0x0000000180443DE0-0x0000000180443F20
	public void Close(); // 0x0000000180443F20-0x00000001804442D0
	private void SetShown(bool on); // 0x00000001804442D0-0x00000001804445F0
	private void OnDisable(); // 0x00000001804445F0-0x00000001804446B0
	private void OnDestroy(); // 0x00000001804446B0-0x0000000180444900
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180444900-0x0000000180444910
	private bool AliveUi(); // 0x0000000180444910-0x0000000180444AF0
	private static bool ConfigEnabled(); // 0x0000000180444AF0-0x0000000180444B40
	private static EventTrackPanel Build(string key); // 0x0000000180444B40-0x0000000180445360
	private void BuildBody(RectTransform root); // 0x0000000180445360-0x00000001804460A0
	private void BuildCloseHit(); // 0x00000001804460A0-0x0000000180446290
	private void BuildJar(); // 0x0000000180446290-0x0000000180447330
	private void BuildTrack(); // 0x0000000180447330-0x0000000180447B10
	private void RenderCached(); // 0x0000000180447B10-0x0000000180447BB0
	private void ShowSkeleton(); // 0x0000000180447BB0-0x0000000180447FA0
	private void Render(EventTrackState s); // 0x0000000180447FA0-0x0000000180449080
	private void BindShowcase(object theme, Color primary); // 0x0000000180449080-0x0000000180449630
	private static float GaugeRatio(EventTrackState s, long total); // 0x0000000180449630-0x0000000180449780
	private void RenderRows(EventTrackState s); // 0x0000000180449780-0x0000000180449D80
	private void RenderCountdown(bool active); // 0x0000000180449D80-0x000000018044A1E0
	private void RenderSurge(EventTrackState s, Color accent); // 0x000000018044A1E0-0x000000018044A700
	private void RenderWeather(EventTrackState s, object theme, Color primary); // 0x000000018044A700-0x000000018044A980
	private void StartTick(); // 0x000000018044A980-0x000000018044AB00
	private void StopTick(); // 0x000000018044AB00-0x000000018044AB80
	[IteratorStateMachine(typeof(_TickLoop_d__139))]
	private IEnumerator TickLoop(); // 0x000000018044AB80-0x000000018044AC20
	private void TickOnce(); // 0x000000018044AC20-0x000000018044ADB0
	private long NowMs(); // 0x000000018044ADB0-0x000000018044AE40
	private void RequestState(); // 0x000000018044AE40-0x000000018044AFA0
	private void Refresh(); // 0x000000018044AFA0-0x000000018044AFC0
	private void OnState(EventTrackState s); // 0x000000018044AFC0-0x000000018044B010
	private void OnStateError(string err); // 0x000000018044B010-0x000000018044B0C0
	private void OnClickClaim(long milestoneId); // 0x000000018044B0C0-0x000000018044B400
	private void OnClaimOk(EventTrackClaimResult r); // 0x000000018044B400-0x000000018044B900
	private void OnClaimErr(string err); // 0x000000018044B900-0x000000018044BAE0
	private void SyncButtons(); // 0x000000018044BAE0-0x000000018044BCA0
	private void Burst(long milestoneId); // 0x000000018044BCA0-0x000000018044C400
	private static bool FxOn(string name); // 0x000000018044C400-0x000000018044C460
	public static void BindArt(MonoBehaviour host, Image img, object theme, string name, Color tint, Color primary); // 0x000000018044C460-0x000000018044C890
	public static Sprite RealArt(object theme, string name); // 0x000000018044C890-0x000000018044C950
	private static Sprite ArtSprite(object theme, string name, Color primary); // 0x000000018044C950-0x000000018044CB50
	public static float FontOf(float raw); // 0x000000018044CB50-0x000000018044CC30
	public static string Num(long v); // 0x000000018044CC30-0x000000018044CC80
	public static string Fmt(string tpl, params string[] pairs); // 0x000000018044CC80-0x000000018044CF80
	private static string FormatRemain(long seconds); // 0x000000018044CF80-0x000000018044D1F0
	private static string ClockVn(long epochMs); // 0x000000018044D1F0-0x000000018044D3B0
	private static EventTrackEvent EvOf(EventTrackState s); // 0x000000018044D3B0-0x000000018044D3C0
	public static object ThemeOf(EventTrackState s); // 0x000000018044D3C0-0x000000018044D430
	private static EventTrackStrings StringsOf(EventTrackState s); // 0x000000018044D430-0x000000018044D4A0
	private static string EventNameOf(EventTrackState s); // 0x000000018044D4A0-0x000000018044D520
	private static long StartAtOf(EventTrackState s); // 0x000000018044D520-0x000000018044D590
	private static long EndAtOf(EventTrackState s); // 0x000000018044D590-0x000000018044D600
	private static long ServerTimeOf(EventTrackState s); // 0x000000018044D600-0x000000018044D610
	private static bool ActiveOf(EventTrackState s); // 0x000000018044D610-0x000000018044D620
	private static bool EndedOf(EventTrackState s); // 0x000000018044D620-0x000000018044D630
	private static long SecondsLeftOf(EventTrackState s); // 0x000000018044D630-0x000000018044D640
	public static long TotalOf(EventTrackState s); // 0x000000018044D640-0x000000018044D660
	private static long TodayOf(EventTrackState s); // 0x000000018044D660-0x000000018044D680
	private static long BonusJustGrantedOf(EventTrackState s); // 0x000000018044D680-0x000000018044D6A0
	private static long DailyCapOf(EventTrackState s); // 0x000000018044D6A0-0x000000018044D6C0
	private static long DailyBonusOf(EventTrackState s); // 0x000000018044D6C0-0x000000018044D6E0
	private static int SurgeMultOf(EventTrackState s); // 0x000000018044D6E0-0x000000018044D720
	private static bool SurgeActiveOf(EventTrackState s); // 0x000000018044D720-0x000000018044D740
	private static long SurgeEndsAtOf(EventTrackState s); // 0x000000018044D740-0x000000018044D760
	private static long SurgeNextAtOf(EventTrackState s); // 0x000000018044D760-0x000000018044D780
	public static IList<EventTrackMilestone> MilestonesOf(EventTrackState s); // 0x000000018044D780-0x000000018044D790
	public static string Str(EventTrackState s, string key, string fallback); // 0x000000018044D790-0x000000018044DDC0
	public static Color PrimaryOf(EventTrackState s); // 0x000000018044DDC0-0x000000018044DE80
	public static Color AccentOf(EventTrackState s); // 0x000000018044DE80-0x000000018044DF50
	public static Color BgTintOf(EventTrackState s); // 0x000000018044DF50-0x000000018044DFE0
	private static string ThemeHex(EventTrackState s, int which); // 0x000000018044DFE0-0x000000018044E100
	private static Color ColorOf(string hex, Color fallback); // 0x000000018044E100-0x000000018044E1B0
	public static long MsId(EventTrackMilestone m); // 0x000000018044D600-0x000000018044D610
	public static long MsRequired(EventTrackMilestone m); // 0x000000018044E1B0-0x000000018044E1C0
	public static string MsTitle(EventTrackMilestone m); // 0x000000018044E1C0-0x000000018044E210
	public static int MsTier(EventTrackMilestone m, EventTrackState s); // 0x000000018044E210-0x000000018044E390
	public static string MsStatus(EventTrackMilestone m); // 0x000000018044E390-0x000000018044E3E0
	public static List<RewardDisplayHelper.Entry> Entries(EventTrackMilestone m); // 0x000000018044E3E0-0x000000018044E510
	public static string RewardDescription(EventTrackMilestone m); // 0x000000018044E510-0x000000018044E580
	private static EventTrackState StateOf(EventTrackClaimResult r); // 0x0000000180422710-0x0000000180422720
	private static List<GameNotice.GiftLine> ToastLinesOf(EventTrackClaimResult r); // 0x000000018044E580-0x000000018044E5A0
	private static List<GachaRollItemDTO> RevealItemsOf(EventTrackClaimResult r); // 0x000000018044E5A0-0x000000018044E5C0
	[CompilerGenerated]
	private bool _RenderWeather_b__136_0(); // 0x000000018044E880-0x000000018044E890
}

