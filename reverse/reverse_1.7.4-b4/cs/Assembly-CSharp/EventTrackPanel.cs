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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class EventTrackPanel : MonoBehaviour // TypeDefIndex: 643
{
	// Fields
	public const string N_ROOT = "[EventTrackPanel]"; // Metadata: 0x005EF836
	private const int SORT_ORDER = 400; // Metadata: 0x005EF848
	private const float BOX_X = 187f; // Metadata: 0x005EF84A
	private const float BOX_Y = 53f; // Metadata: 0x005EF84E
	private const float BOX_W = 1400f; // Metadata: 0x005EF852
	private const float BOX_H = 780f; // Metadata: 0x005EF856
	private const float TITLE_X = 0f; // Metadata: 0x005EF85A
	private const float TITLE_Y = 26f; // Metadata: 0x005EF85E
	private const float TITLE_W = 1400f; // Metadata: 0x005EF862
	private const float TITLE_H = 60f; // Metadata: 0x005EF866
	private const float CD_X = 0f; // Metadata: 0x005EF86A
	private const float CD_Y = 90f; // Metadata: 0x005EF86E
	private const float CD_W = 1400f; // Metadata: 0x005EF872
	private const float CD_H = 34f; // Metadata: 0x005EF876
	private const float CLOSE_X = 1316f; // Metadata: 0x005EF87A
	private const float CLOSE_Y = 20f; // Metadata: 0x005EF87E
	private const float CLOSE_W = 64f; // Metadata: 0x005EF882
	private const float CLOSE_H = 64f; // Metadata: 0x005EF886
	private const float CLOSE_HIT = 96f; // Metadata: 0x005EF88A
	private const float JAR_X = 90f; // Metadata: 0x005EF88E
	private const float JAR_Y = 150f; // Metadata: 0x005EF892
	private const float JAR_W = 300f; // Metadata: 0x005EF896
	private const float JAR_H = 360f; // Metadata: 0x005EF89A
	private const float TOTAL_X = 60f; // Metadata: 0x005EF89E
	private const float TOTAL_Y = 522f; // Metadata: 0x005EF8A2
	private const float TOTAL_W = 360f; // Metadata: 0x005EF8A6
	private const float TOTAL_H = 72f; // Metadata: 0x005EF8AA
	private const float UNIT_X = 60f; // Metadata: 0x005EF8AE
	private const float UNIT_Y = 590f; // Metadata: 0x005EF8B2
	private const float UNIT_W = 360f; // Metadata: 0x005EF8B6
	private const float UNIT_H = 30f; // Metadata: 0x005EF8BA
	private const float PILL_X = 110f; // Metadata: 0x005EF8BE
	private const float PILL_Y = 632f; // Metadata: 0x005EF8C2
	private const float PILL_W = 260f; // Metadata: 0x005EF8C6
	private const float PILL_H = 56f; // Metadata: 0x005EF8CA
	private const float HINT_X = 40f; // Metadata: 0x005EF8CE
	private const float HINT_Y = 700f; // Metadata: 0x005EF8D2
	private const float HINT_W = 420f; // Metadata: 0x005EF8D6
	private const float HINT_H = 60f; // Metadata: 0x005EF8DA
	private const float TRACK_X = 480f; // Metadata: 0x005EF8DE
	private const float TRACK_Y = 130f; // Metadata: 0x005EF8E2
	private const float TRACK_W = 880f; // Metadata: 0x005EF8E6
	private const float TRACK_H = 600f; // Metadata: 0x005EF8EA
	private const float NOTE_X = 480f; // Metadata: 0x005EF8EE
	private const float NOTE_Y = 742f; // Metadata: 0x005EF8F2
	private const float NOTE_W = 880f; // Metadata: 0x005EF8F6
	private const float NOTE_H = 28f; // Metadata: 0x005EF8FA
	private const float ROW_GAP = 10f; // Metadata: 0x005EF8FE
	private const float DROP_SIZE = 120f; // Metadata: 0x005EF902
	private const float RING_X = 10f; // Metadata: 0x005EF906
	private const float RING_Y = 0f; // Metadata: 0x005EF90A
	private const float RING_D = 280f; // Metadata: 0x005EF90E
	private const float ORB_X = 38f; // Metadata: 0x005EF912
	private const float ORB_Y = 28f; // Metadata: 0x005EF916
	private const float ORB_D = 224f; // Metadata: 0x005EF91A
	private const float PED_X = 35f; // Metadata: 0x005EF91E
	private const float PED_Y = 180f; // Metadata: 0x005EF922
	private const float PED_W = 230f; // Metadata: 0x005EF926
	private const float PED_H = 96f; // Metadata: 0x005EF92A
	private const float HERO_X = 75f; // Metadata: 0x005EF92E
	private const float HERO_Y = 46f; // Metadata: 0x005EF932
	private const float HERO_W = 150f; // Metadata: 0x005EF936
	private const float HERO_H = 188f; // Metadata: 0x005EF93A
	private const long SOON_SEC = 172800; // Metadata: 0x005EF93E
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
	public static bool IsOpen { get; } // 0x00000001804440A0-0x00000001804442F0 
	public static string OpenKey { get; } // 0x00000001804442F0-0x0000000180444440 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 644
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, string> __9__130_0; // 0x08

		// Constructors
		static __c(); // 0x000000018044FA10-0x000000018044FAB0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal string _Render_b__130_0(long v); // 0x000000018044FAB0-0x000000018044FB40
	}

	[CompilerGenerated]
	private sealed class _TickLoop_d__139 : IEnumerator<object> // TypeDefIndex: 645
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
		private bool MoveNext(); // 0x000000018044FB40-0x000000018044FE60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044FE60-0x000000018044FEA0
	}

	// Constructors
	public EventTrackPanel(); // 0x000000018044F740-0x000000018044F920
	static EventTrackPanel(); // 0x000000018044F920-0x000000018044FA00

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x0000000180444440-0x00000001804445F0
	public static bool Open(string key); // 0x00000001804445F0-0x0000000180444EB0
	public static void CloseIfOpen(); // 0x0000000180444EB0-0x0000000180444FF0
	public void Close(); // 0x0000000180444FF0-0x00000001804453A0
	private void SetShown(bool on); // 0x00000001804453A0-0x00000001804456C0
	private void OnDisable(); // 0x00000001804456C0-0x0000000180445780
	private void OnDestroy(); // 0x0000000180445780-0x00000001804459D0
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001804459D0-0x00000001804459E0
	private bool AliveUi(); // 0x00000001804459E0-0x0000000180445BC0
	private static bool ConfigEnabled(); // 0x0000000180445BC0-0x0000000180445C10
	private static EventTrackPanel Build(string key); // 0x0000000180445C10-0x0000000180446430
	private void BuildBody(RectTransform root); // 0x0000000180446430-0x0000000180447170
	private void BuildCloseHit(); // 0x0000000180447170-0x0000000180447360
	private void BuildJar(); // 0x0000000180447360-0x0000000180448400
	private void BuildTrack(); // 0x0000000180448400-0x0000000180448BE0
	private void RenderCached(); // 0x0000000180448BE0-0x0000000180448C80
	private void ShowSkeleton(); // 0x0000000180448C80-0x0000000180449070
	private void Render(EventTrackState s); // 0x0000000180449070-0x000000018044A150
	private void BindShowcase(object theme, Color primary); // 0x000000018044A150-0x000000018044A700
	private static float GaugeRatio(EventTrackState s, long total); // 0x000000018044A700-0x000000018044A850
	private void RenderRows(EventTrackState s); // 0x000000018044A850-0x000000018044AE50
	private void RenderCountdown(bool active); // 0x000000018044AE50-0x000000018044B2B0
	private void RenderSurge(EventTrackState s, Color accent); // 0x000000018044B2B0-0x000000018044B7D0
	private void RenderWeather(EventTrackState s, object theme, Color primary); // 0x000000018044B7D0-0x000000018044BA50
	private void StartTick(); // 0x000000018044BA50-0x000000018044BBD0
	private void StopTick(); // 0x000000018044BBD0-0x000000018044BC50
	[IteratorStateMachine(typeof(_TickLoop_d__139))]
	private IEnumerator TickLoop(); // 0x000000018044BC50-0x000000018044BCF0
	private void TickOnce(); // 0x000000018044BCF0-0x000000018044BE80
	private long NowMs(); // 0x000000018044BE80-0x000000018044BF10
	private void RequestState(); // 0x000000018044BF10-0x000000018044C070
	private void Refresh(); // 0x000000018044C070-0x000000018044C090
	private void OnState(EventTrackState s); // 0x000000018044C090-0x000000018044C120
	private void OnStateError(string err); // 0x000000018044C120-0x000000018044C200
	private void OnClickClaim(long milestoneId); // 0x000000018044C200-0x000000018044C540
	private void OnClaimOk(EventTrackClaimResult r); // 0x000000018044C540-0x000000018044CA60
	private void OnClaimErr(string err); // 0x000000018044CA60-0x000000018044CC60
	private void SyncButtons(); // 0x000000018044CC60-0x000000018044CE20
	private void Burst(long milestoneId); // 0x000000018044CE20-0x000000018044D580
	private static bool FxOn(string name); // 0x000000018044D580-0x000000018044D5E0
	public static void BindArt(MonoBehaviour host, Image img, object theme, string name, Color tint, Color primary); // 0x000000018044D5E0-0x000000018044DA10
	public static Sprite RealArt(object theme, string name); // 0x000000018044DA10-0x000000018044DAD0
	private static Sprite ArtSprite(object theme, string name, Color primary); // 0x000000018044DAD0-0x000000018044DCD0
	public static float FontOf(float raw); // 0x000000018044DCD0-0x000000018044DDB0
	public static string Num(long v); // 0x000000018044DDB0-0x000000018044DE00
	public static string Fmt(string tpl, params string[] pairs); // 0x000000018044DE00-0x000000018044E100
	private static string FormatRemain(long seconds); // 0x000000018044E100-0x000000018044E370
	private static string ClockVn(long epochMs); // 0x000000018044E370-0x000000018044E530
	private static EventTrackEvent EvOf(EventTrackState s); // 0x000000018044E530-0x000000018044E540
	public static object ThemeOf(EventTrackState s); // 0x000000018044E540-0x000000018044E5B0
	private static EventTrackStrings StringsOf(EventTrackState s); // 0x000000018044E5B0-0x000000018044E620
	private static string EventNameOf(EventTrackState s); // 0x000000018044E620-0x000000018044E6A0
	private static long StartAtOf(EventTrackState s); // 0x000000018044E6A0-0x000000018044E710
	private static long EndAtOf(EventTrackState s); // 0x000000018044E710-0x000000018044E780
	private static long ServerTimeOf(EventTrackState s); // 0x000000018044E780-0x000000018044E790
	private static bool ActiveOf(EventTrackState s); // 0x000000018044E790-0x000000018044E7A0
	private static bool EndedOf(EventTrackState s); // 0x000000018044E7A0-0x000000018044E7B0
	private static long SecondsLeftOf(EventTrackState s); // 0x000000018044E7B0-0x000000018044E7C0
	public static long TotalOf(EventTrackState s); // 0x000000018044E7C0-0x000000018044E7E0
	private static long TodayOf(EventTrackState s); // 0x000000018044E7E0-0x000000018044E800
	private static long BonusJustGrantedOf(EventTrackState s); // 0x000000018044E800-0x000000018044E820
	private static long DailyCapOf(EventTrackState s); // 0x000000018044E820-0x000000018044E840
	private static long DailyBonusOf(EventTrackState s); // 0x000000018044E840-0x000000018044E860
	private static int SurgeMultOf(EventTrackState s); // 0x000000018044E860-0x000000018044E8A0
	private static bool SurgeActiveOf(EventTrackState s); // 0x000000018044E8A0-0x000000018044E8C0
	private static long SurgeEndsAtOf(EventTrackState s); // 0x000000018044E8C0-0x000000018044E8E0
	private static long SurgeNextAtOf(EventTrackState s); // 0x000000018044E8E0-0x000000018044E900
	public static IList<EventTrackMilestone> MilestonesOf(EventTrackState s); // 0x000000018044E900-0x000000018044E910
	public static string Str(EventTrackState s, string key, string fallback); // 0x000000018044E910-0x000000018044EF40
	public static Color PrimaryOf(EventTrackState s); // 0x000000018044EF40-0x000000018044F000
	public static Color AccentOf(EventTrackState s); // 0x000000018044F000-0x000000018044F0D0
	public static Color BgTintOf(EventTrackState s); // 0x000000018044F0D0-0x000000018044F160
	private static string ThemeHex(EventTrackState s, int which); // 0x000000018044F160-0x000000018044F280
	private static Color ColorOf(string hex, Color fallback); // 0x000000018044F280-0x000000018044F330
	public static long MsId(EventTrackMilestone m); // 0x000000018044E780-0x000000018044E790
	public static long MsRequired(EventTrackMilestone m); // 0x000000018044F330-0x000000018044F340
	public static string MsTitle(EventTrackMilestone m); // 0x000000018044F340-0x000000018044F390
	public static int MsTier(EventTrackMilestone m, EventTrackState s); // 0x000000018044F390-0x000000018044F510
	public static string MsStatus(EventTrackMilestone m); // 0x000000018044F510-0x000000018044F560
	public static List<RewardDisplayHelper.Entry> Entries(EventTrackMilestone m); // 0x000000018044F560-0x000000018044F690
	public static string RewardDescription(EventTrackMilestone m); // 0x000000018044F690-0x000000018044F700
	private static EventTrackState StateOf(EventTrackClaimResult r); // 0x0000000180423470-0x0000000180423480
	private static List<GameNotice.GiftLine> ToastLinesOf(EventTrackClaimResult r); // 0x000000018044F700-0x000000018044F720
	private static List<GachaRollItemDTO> RevealItemsOf(EventTrackClaimResult r); // 0x000000018044F720-0x000000018044F740
	[CompilerGenerated]
	private bool _RenderWeather_b__136_0(); // 0x000000018044FA00-0x000000018044FA10
}

