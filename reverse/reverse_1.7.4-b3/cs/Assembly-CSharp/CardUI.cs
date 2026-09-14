/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokiGuard.Audition;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class CardUI : MonoBehaviour, IAuditionHost // TypeDefIndex: 2248
{
	// Fields
	private CardData cardData; // 0x20
	public Button btn; // 0x28
	private Board board; // 0x30
	private Active active; // 0x38
	private bool hasUsedThisMatch; // 0x40
	private bool hasUsedThisTurn; // 0x41
	private int lastTurnUsed; // 0x44
	private bool isActionPending; // 0x48
	private float pendingSince; // 0x4C
	private const float PENDING_QUIET_SEC = 2f; // Metadata: 0x005F0882
	internal int lastBuffUsedTurn; // 0x50
	internal bool hasUsedBuffThisTurn; // 0x54
	private int currentDotSkillActorNumber; // 0x58
	[Header("Placeholder Settings")]
	[Tooltip("Sprite hi\u1EC3n th\u1ECB khi card \u0111\u00E3 \u0111\u01B0\u1EE3c s\u1EED d\u1EE5ng")]
	public Sprite placeholderSprite; // 0x60
	[Tooltip("M\u00E0u c\u1EE7a placeholder (default: gray v\u1EDBi alpha 0.5)")]
	public Color placeholderColor; // 0x68
	private Sprite originalSprite; // 0x78
	private bool isPlaceholder; // 0x80
	[Header("Card Animation Settings")]
	[Tooltip("Th\u1EDDi gian hi\u1EC3n th\u1ECB card animation (gi\u00E2y)")]
	public float animationDuration; // 0x84
	[Tooltip("Scale c\u1EE7a card khi \u1EDF gi\u1EEFa m\u00E0n h\u00ECnh")]
	public float centerCardScale; // 0x88
	[Tooltip("K\u00EDch th\u01B0\u1EDBc card gi\u1EEFa m\u00E0n h\u00ECnh")]
	private Vector2 centerCardSize; // 0x8C
	[Header("Card Visual")]
	[Tooltip("Image object hi\u1EC3n th\u1ECB card (child object)")]
	public Image imgtCard; // 0x98
	private Canvas animationCanvas; // 0xA0
	private Image centerCardImage; // 0xA8
	[Header("Dot Skill Settings")]
	[Tooltip("Panel ch\u1EE9a 7 n\u00FAt m\u0169i t\u00EAn (t\u1EF1 \u0111\u1ED9ng t\u00ECm ho\u1EB7c t\u1EA1o)")]
	public Transform dotSkillPanel; // 0xB0
	[Tooltip("Prefab Image \u0111\u1EC3 hi\u1EC3n th\u1ECB m\u0169i t\u00EAn")]
	public GameObject arrowPrefab; // 0xB8
	[Tooltip("Th\u1EDDi gian cho ph\u00E9p ng\u01B0\u1EDDi ch\u01A1i g\u00F5 ph\u00EDm (gi\u00E2y)")]
	public float dotSkillDuration; // 0xC0
	[Header("Dot Skill Time Slider")]
	[Tooltip("Slider hi\u1EC3n th\u1ECB th\u1EDDi gian (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Slider timeSlider; // 0xC8
	[Tooltip("M\u00E0u slider khi c\u00F2n nhi\u1EC1u th\u1EDDi gian")]
	public Color sliderColorNormal; // 0xD0
	[CompilerGenerated]
	private static CardUI _ActiveDotSkillCard_k__BackingField; // 0x00
	private bool _auditionV3; // 0xE0
	private int _auditionV3ElapsedMs; // 0xE4
	[Tooltip("M\u00E0u slider khi s\u1EAFp h\u1EBFt th\u1EDDi gian")]
	public Color sliderColorWarning; // 0xE8
	[Range(0f, 1f)]
	[Tooltip("Ng\u01B0\u1EE1ng chuy\u1EC3n m\u00E0u c\u1EA3nh b\u00E1o (% th\u1EDDi gian c\u00F2n l\u1EA1i)")]
	public float warningThreshold; // 0xF8
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Text hi\u1EC3n th\u1ECB Perfect/Good/Bad (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public UnityEngine.UI.Text timingText; // 0x100
	[Tooltip("M\u00E0u text Perfect")]
	public Color perfectColor; // 0x108
	[Tooltip("M\u00E0u text Good")]
	public Color goodColor; // 0x118
	[Tooltip("M\u00E0u text Bad")]
	public Color badColor; // 0x128
	[Header("Damage Multipliers")]
	[Range(1f, 3f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Perfect")]
	public float perfectMultiplier; // 0x138
	[Range(1f, 2f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Good")]
	public float goodMultiplier; // 0x13C
	[Range(0.5f, 1f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Bad")]
	public float badMultiplier; // 0x140
	private List<Image> currentArrows; // 0x148
	private string[] directions; // 0x150
	private int currentDotIndex; // 0x158
	private int correctDotCount; // 0x15C
	private bool isDotSkillActive; // 0x160
	private float currentTimeValue; // 0x164
	private float damageMultiplier; // 0x168
	private Dictionary<string, Sprite> blueArrows; // 0x170
	private Dictionary<string, Sprite> purpleArrows; // 0x178
	private bool hasFinishedDotSkill; // 0x180
	private const string QTE_ZONE_PREFIX = "QteZone_"; // Metadata: 0x005F0886
	private bool _qteForgiving; // 0x181
	private Image _qteShakeArrow; // 0x188
	private Vector3 _qteShakeHome; // 0x190
	private static readonly Color QteArrowIdle; // 0x08
	private static readonly Color QteArrowActive; // 0x18
	private static readonly Color QteArrowWrong; // 0x28
	private static readonly Color QteZoneGood; // 0x38
	private static readonly Color QteZonePerfect; // 0x48
	private static readonly Color QteSliderColorPerfect; // 0x58
	private bool _dotSkillPanelRuntimeCreated; // 0x19C
	private const string AUDITION_TIMELINE_NAME = "AuditionTimeline"; // Metadata: 0x005F088F
	private const string POKY_AUDITION_FRAME_NAME = "PokyAuditionFrame"; // Metadata: 0x005F08A0
	private const string POKY_TIMELINE_BG = "Image/FriendUI/bgList"; // Metadata: 0x005F08B2
	private const string POKY_PANEL_FRAME = "Image/FriendUI/bgPopupAlert"; // Metadata: 0x005F08C8
	private const string POKY_BTN_OK = "Image/Common/btnOk"; // Metadata: 0x005F08E4
	private const string POKY_TIMELINE_PLATE = "Image/Common/Gameplay-bgDialog"; // Metadata: 0x005F08F7
	private const string POKY_AUDITION_RIBBON = "Image/Common/bar_ribbon1"; // Metadata: 0x005F0916
	private const string POKY_PERFECT_STAR = "Image/FriendUI/gold_star"; // Metadata: 0x005F092F
	private const string POKY_PERFECT_LINE = "Image/Common/linePower"; // Metadata: 0x005F0948
	private const string POKY_NEEDLE_CAP = "Image/Common/btnNextPet0001"; // Metadata: 0x005F095F
	private const string POKY_ELAPSED_COMET = "Image/Common/fullMana"; // Metadata: 0x005F097B
	private const string POKY_NEEDLE_BALL = "Image/FriendUI/redDot"; // Metadata: 0x005F0991
	private const string DPAD_NEON_PREFIX = "DotSkillNeon/"; // Metadata: 0x005F09A7
	private const string POKY_BTN_SPACE = "Image/petK/btnkhamht"; // Metadata: 0x005F09B5
	private const string VOLUME_ATLAS_PATH = "Image/petK/fframe"; // Metadata: 0x005F09CA
	private const string VOLUME_TRACK_SPRITE = "fframe_4"; // Metadata: 0x005F09DC
	private const string VOLUME_KNOB_SPRITE = "fframe_0"; // Metadata: 0x005F09E5
	private const string AUDITION_BALL_NAME = "NeedleBall"; // Metadata: 0x005F09EE
	private const string AUDITION_JUDGE_NAME = "LiveJudgeText"; // Metadata: 0x005F09F9
	private const string AUDITION_FRAME_GLOW_NAME = "FrameGlow"; // Metadata: 0x005F0A07
	private const string AUDITION_FRAME_CORE_NAME = "FrameCore"; // Metadata: 0x005F0A11
	private const string AUDITION_RIBBON_NAME = "AuditionRibbon"; // Metadata: 0x005F0A1B
	private const string AUDITION_HIT_BURST_NAME = "ArrowHitBurst"; // Metadata: 0x005F0A2A
	private RectTransform _auditionTimeline; // 0x1A0
	private RectTransform _auditionNeedle; // 0x1A8
	private Image _auditionNeedleImg; // 0x1B0
	private Image _auditionTrackImg; // 0x1B8
	private RectTransform _auditionComet; // 0x1C0
	private RectTransform _auditionStar; // 0x1C8
	private RectTransform _auditionRibbon; // 0x1D0
	private RectTransform _auditionNeedleBall; // 0x1D8
	private UnityEngine.UI.Text _auditionJudgeText; // 0x1E0
	private Color _auditionTrackIdleColor; // 0x1E8
	private Color _auditionTrackPerfectColor; // 0x1F8
	private Color _auditionNeedleIdleColor; // 0x208
	private Color _auditionNeedlePerfectColor; // 0x218
	private int _auditionStarTweenId; // 0x228
	private Image _frameGlowImg; // 0x230
	private bool _qteTimelineV2; // 0x238
	private bool _qteBtnLayoutV2; // 0x239
	private static readonly Color TimelineBg; // 0x68
	private static readonly Color TimelineTrackIdle; // 0x78
	private static readonly Color TimelineTrackPerfect; // 0x88
	private static readonly Color TimelineZoneGood; // 0x98
	private static readonly Color TimelineZonePerfect; // 0xA8
	private static readonly Color TimelineNeedleIdle; // 0xB8
	private static readonly Color TimelineNeedlePerfect; // 0xC8
	private static readonly Color TimelinePlateTint; // 0xD8
	private static readonly Color TimelineUnderlineTint; // 0xE8
	private static readonly Color TimelineCometTint; // 0xF8
	private static readonly Color TimelineTrackLit; // 0x108
	private static readonly Color TimelineTrackVolume; // 0x118
	private static readonly Color TimelineTrackVolumePerfect; // 0x128
	private static readonly Color TimelineTrackLitPerfect; // 0x138
	private static readonly Color TimelineNeedleLit; // 0x148
	private static readonly Color TimelineNeedleOnLit; // 0x158
	private static readonly Color TimelineJudgePerfect; // 0x168
	private static readonly Color TimelineJudgeGood; // 0x178
	private static readonly Color AuditionFrameGlow; // 0x188
	private static readonly Color AuditionFrameCore; // 0x198
	private QteButtonSlot[] _qteBtnSlots; // 0x240
	private bool _qteBtnLayoutApplied; // 0x248
	private const string AUDITION_SCRIM_NAME = "AuditionScrim"; // Metadata: 0x005F0A38
	private const float AuditionScrimAlpha = 0.62f; // Metadata: 0x005F0A46
	private const float AuditionScrimFadeSec = 0.15f; // Metadata: 0x005F0A4A
	private Image _auditionScrim; // 0x250
	private QteModalSlot _qteModalPanelSlot; // 0x258
	private QteModalSlot _qteModalTextSlot; // 0x2A0
	private bool _qteModalApplied; // 0x2E8
	[Header("Control Buttons")]
	[Tooltip("N\u00FAt Up (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnUp; // 0x2F0
	[Tooltip("N\u00FAt Down (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnDown; // 0x2F8
	[Tooltip("N\u00FAt Left (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnLeft; // 0x300
	[Tooltip("N\u00FAt Right (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnRight; // 0x308
	[Tooltip("N\u00FAt Enter (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnEnter; // 0x310
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float perfectStartTime; // 0x318
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float perfectEndTime; // 0x31C
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 2.5s")]
	public float goodStart1Time; // 0x320
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float goodEnd1Time; // 0x324
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float goodStart2Time; // 0x328
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 4.2s")]
	public float goodEnd2Time; // 0x32C
	private int timingBonus; // 0x330
	[Header("Timing Bonus (for ATTACK_LEGEND_)")]
	[Tooltip("Bonus correctCount khi Perfect (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int perfectBonus; // 0x334
	[Tooltip("Bonus correctCount khi Good (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int goodBonus; // 0x338
	[Tooltip("Bonus correctCount khi Bad (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int badBonus; // 0x33C
	[Tooltip("M\u00E0u text Perfect")]
	private Coroutine blinkCoroutine; // 0x340
	[Header("Legend Card Background Effects")]
	[Tooltip("\u1EA2nh n\u1EC1n c\u1EA7n \u00E1p d\u1EE5ng hi\u1EC7u \u1EE9ng")]
	public Image backgroundImage; // 0x348
	[Tooltip("M\u00E0u flash effect (default: tr\u1EAFng)")]
	public Color flashColor; // 0x350
	[Tooltip("S\u1ED1 l\u1EA7n flash")]
	public int flashCount; // 0x360
	[Tooltip("Th\u1EDDi gian m\u1ED7i l\u1EA7n flash (gi\u00E2y)")]
	public float flashDuration; // 0x364
	[Tooltip("C\u01B0\u1EDDng \u0111\u1ED9 rung (shake magnitude)")]
	public float shakeMagnitude; // 0x368
	[Tooltip("Th\u1EDDi gian rung (gi\u00E2y)")]
	public float shakeDuration; // 0x36C
	private Color originalBackgroundColor; // 0x370
	private bool isBackgroundEffectActive; // 0x380
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	[Tooltip("Panel ch\u1EE9a 8 toggle \u0111\u1EC3 ch\u1ECDn h\u00E0ng (n\u00EAn c\u00F3 Canvas sortingOrder cao)")]
	public GameObject mega1TogglePanel; // 0x388
	[Tooltip("8 Toggle t\u01B0\u01A1ng \u1EE9ng h\u00E0ng 0-7 (row 0 = h\u00E0ng d\u01B0\u1EDBi c\u00F9ng)")]
	public Toggle[] mega1RowToggles; // 0x390
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 h\u00E0ng \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x398
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x3A0
	private List<int> mega1SelectedRows; // 0x3A8
	private bool isMega1PanelOpen; // 0x3B0
	private Coroutine mega1WatchCoroutine; // 0x3B8
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x3C0
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x3C8
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x3D0
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x3D8
	private List<Toggle> _mega2Toggles; // 0x3E0
	private List<Animator> _mega2Animators; // 0x3E8
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x3F0
	private bool isMega2PanelOpen; // 0x3F8
	private bool isMegaIcarusSelectionMode; // 0x3F9
	private Coroutine mega2WatchCoroutine; // 0x400
	[Header("MEGA_ICARUS Card Settings (ch\u1ECDn t\u00E2m + b\u00E1n k\u00EDnh)")]
	[Tooltip("Panel ch\u1EE9a toggle \u0111\u1EC3 ch\u1ECDn t\u00E2m tr\u00EAn b\u00E0n (gi\u1ED1ng MEGA2 nh\u01B0ng ch\u1EC9 ch\u1ECDn 1 t\u00E2m)")]
	public GameObject megaIcarusTogglePanel; // 0x408
	[Tooltip("Toggle m\u1EABu \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle megaIcarusTogglePrefab; // 0x410
	[Tooltip("Text hi\u1EC3n th\u1ECB h\u01B0\u1EDBng d\u1EABn ch\u1ECDn t\u00E2m")]
	public UnityEngine.UI.Text megaIcarusSelectedCountText; // 0x418
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA_ICARUS")]
	public GameObject txtInfoMegaIcarus; // 0x420
	private List<Toggle> _megaIcarusToggles; // 0x428
	private List<Animator> _megaIcarusAnimators; // 0x430
	[TupleElementNames(new string[2] {"col", "row" })]
	private ValueTuple<int, int>? megaIcarusSelectedCenter; // 0x438
	private bool isMegaIcarusPanelOpen; // 0x444
	private bool isMegaIcarusAutoSelected; // 0x445
	private Coroutine megaIcarusWatchCoroutine; // 0x448
	[Tooltip("B\u00E1n k\u00EDnh m\u1EB7c \u0111\u1ECBnh c\u1EE7a Mega Icarus (s\u1ED1 \u00F4 t\u1EEB t\u00E2m)")]
	public int megaIcarusDefaultRadius; // 0x450
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x454
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x458
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x468
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x478
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x47C
	private static Sprite[] _volumeAtlasSprites; // 0x1A8
	private static readonly List<CardUI> _registry; // 0x1B0
	private string _elemTypeSrc; // 0x480
	private string _elemTypeUpper; // 0x488
	private int currentArrowSeed; // 0x490
	private readonly List<string> qtePresses; // 0x498
	private bool _qteArrowsFromServer; // 0x4A0
	private bool _isLegendEffectActive; // 0x4A1
	private Camera _matchCameraCache; // 0x4A8
	private GameObject _mega1AlignOwner; // 0x4B0
	private VerticalLayoutGroup _mega1Vlg; // 0x4B8
	private ContentSizeFitter _mega1Csf; // 0x4C0
	private RectTransform _mega1PanelRt; // 0x4C8
	private Canvas _mega1Canvas; // 0x4D0
	private RectTransform[] _mega1ToggleRt; // 0x4D8
	private RectTransform[] _mega1ToggleParentRt; // 0x4E0
	private const float SkillHintMinIntervalSec = 0.1f; // Metadata: 0x005F0A4E
	private static float _lastSkillHintAt; // 0x1B8
	private static readonly Dictionary<string, Dictionary<string, object>> _pendingSkillHints; // 0x1C0

	// Properties
	public bool IsActionPending { get; } // 0x00000001806D8E70-0x00000001806D8E80 
	public static CardUI ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A8D3F0-0x0000000180A8D450 0x0000000180A8D450-0x0000000180A8D500
	CardData IAuditionHost.Card { get; } // 0x00000001802A8720-0x00000001802A8730 
	Transform IAuditionHost.OverlayRoot { get; } // 0x0000000180A8D580-0x0000000180A8D690 
	bool IAuditionHost.IsActive { get; } // 0x0000000180A8D690-0x0000000180A8D780 
	private static float QteChallengeWaitSec { get; } // 0x0000000180AA40A0-0x0000000180AA40F0 

	// Nested types
	private struct QteButtonSlot // TypeDefIndex: 2249
	{
		// Fields
		public Button btn; // 0x00
		public Transform parent; // 0x08
		public int siblingIndex; // 0x10
		public Vector2 anchorMin; // 0x14
		public Vector2 anchorMax; // 0x1C
		public Vector2 pivot; // 0x24
		public Vector2 anchoredPosition; // 0x2C
		public Vector2 sizeDelta; // 0x34
		public Vector3 localScale; // 0x3C
		public Quaternion localRotation; // 0x48
		public Image img; // 0x58
		public Sprite sprite; // 0x60
		public Image.Type imgType; // 0x68
		public bool preserveAspect; // 0x6C
		public Color imgColor; // 0x70
		public UnityEngine.UI.Text label; // 0x80
		public int labelFontSize; // 0x88
		public string labelText; // 0x90
	}

	private struct QteModalSlot // TypeDefIndex: 2250
	{
		// Fields
		public Transform node; // 0x00
		public Transform parent; // 0x08
		public int siblingIndex; // 0x10
		public Vector2 anchorMin; // 0x14
		public Vector2 anchorMax; // 0x1C
		public Vector2 pivot; // 0x24
		public Vector2 anchoredPosition; // 0x2C
		public Vector2 sizeDelta; // 0x34
		public Vector3 localScale; // 0x3C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass246_0 // TypeDefIndex: 2251
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass246_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseAuditionFrameGlow_b__0(float v); // 0x0000000180ACB290-0x0000000180ACB300
		internal void _PulseAuditionFrameGlow_b__1(); // 0x0000000180ACB300-0x0000000180ACB370
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass251_0 // TypeDefIndex: 2252
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass251_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ReleaseAuditionScrim_b__0(float v); // 0x0000000180ACB370-0x0000000180ACB4F0
		internal void _ReleaseAuditionScrim_b__1(); // 0x0000000180ACB4F0-0x0000000180ACB800
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass306_0 // TypeDefIndex: 2253
	{
		// Fields
		public Image cue; // 0x10
		public CardUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass306_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayArrowIntro_b__0(); // 0x0000000180ACB800-0x0000000180ACBA60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass307_0 // TypeDefIndex: 2254
	{
		// Fields
		public CardUI __4__this; // 0x10
		public string captured; // 0x18

		// Constructors
		public __c__DisplayClass307_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachArrowTapButton_b__0(); // 0x0000000180ACBA60-0x0000000180ACBAB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass312_0 // TypeDefIndex: 2255
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass312_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnArrowHitBurst_b__0(); // 0x0000000180ACBAB0-0x0000000180ACBBE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass314_0 // TypeDefIndex: 2256
	{
		// Fields
		public Image arrow; // 0x10
		public Vector3 originalPos; // 0x18
		public CardUI __4__this; // 0x28

		// Constructors
		public __c__DisplayClass314_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeArrowWrong_b__0(Color c); // 0x0000000180ACBBE0-0x0000000180ACBD00
		internal void _ShakeArrowWrong_b__1(); // 0x0000000180ACBD00-0x0000000180ACC210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass322_0 // TypeDefIndex: 2257
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass322_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x0000000180ACC210-0x0000000180ACC380
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass347_0 // TypeDefIndex: 2258
	{
		// Fields
		public int idx; // 0x10
		public CardUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass347_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x0000000180ACC380-0x0000000180ACC3B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass365_0 // TypeDefIndex: 2259
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass365_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x0000000180ACC3B0-0x0000000180ACC3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass370_0 // TypeDefIndex: 2260
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass370_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x0000000180ACC3F0-0x0000000180ACC410
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass377_0 // TypeDefIndex: 2261
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass377_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupMegaIcarusPanelOnce_b__0(bool on); // 0x0000000180ACC410-0x0000000180ACC450
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__335 : IEnumerator<object> // TypeDefIndex: 2262
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private RectTransform _rt_5__2; // 0x28
		private Vector2 _origPos_5__3; // 0x30
		private Color _origColor_5__4; // 0x38
		private Color _darkColor_5__5; // 0x48
		private float _shakeDuration_5__6; // 0x58
		private float _t_5__7; // 0x5C
		private float _restDuration_5__8; // 0x60
		private float _restElapsed_5__9; // 0x64

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BackgroundFlickerShake_d__335(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180ACC450-0x0000000180ACCB00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACCB00-0x0000000180ACCB40
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__323 : IEnumerator<object> // TypeDefIndex: 2263
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__323(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180ACCB40-0x0000000180ACCEF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACCEF0-0x0000000180ACCF30
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__363 : IEnumerator<object> // TypeDefIndex: 2264
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__363(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ACCF30-0x0000000180ACD850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACD850-0x0000000180ACD890
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__374 : IEnumerator<object> // TypeDefIndex: 2265
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__374(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ACD890-0x0000000180ACE680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACE680-0x0000000180ACE6C0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMegaIcarusDotDestruction_d__386 : IEnumerator<object> // TypeDefIndex: 2266
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private int _col_5__2; // 0x28
		private int _row_5__3; // 0x2C
		private float _guardOff_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMegaIcarusDotDestruction_d__386(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ACE6C0-0x0000000180ACF190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACF190-0x0000000180ACF1D0
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__292 : IEnumerator<object> // TypeDefIndex: 2267
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		public int userActorNumber; // 0x28
		private string _elementType_5__2; // 0x30
		private bool __pausedTurnForSkill_5__3; // 0x38
		private float _timeLeft_5__4; // 0x3C
		private float _totalTime_5__5; // 0x40
		private bool _wasInPerfectZone_5__6; // 0x44
		private bool _wasInGoodZone_5__7; // 0x45
		private float _qteWait_5__8; // 0x48
		private int _finalDamage_5__9; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__292(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180ACF1D0-0x0000000180AD1200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD1200-0x0000000180AD1240
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__267 : IEnumerator<object> // TypeDefIndex: 2268
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private GameObject _centerObj_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _fadeDuration_5__4; // 0x38
		private float _t_5__5; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__267(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
		private bool MoveNext(); // 0x0000000180AD12B0-0x0000000180AD1870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD1870-0x0000000180AD18B0
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__362 : IEnumerator<object> // TypeDefIndex: 2269
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__362(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD18B0-0x0000000180AD1A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD1A50-0x0000000180AD1A90
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__349 : IEnumerator<object> // TypeDefIndex: 2270
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__349(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD1A90-0x0000000180AD2390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD2390-0x0000000180AD23D0
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__369 : IEnumerator<object> // TypeDefIndex: 2271
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__369(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD23D0-0x0000000180AD2BF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD2BF0-0x0000000180AD2C30
	}

	[CompilerGenerated]
	private sealed class _OpenMegaIcarusPanel_d__381 : IEnumerator<object> // TypeDefIndex: 2272
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenMegaIcarusPanel_d__381(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD2C30-0x0000000180AD3570
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD3570-0x0000000180AD35B0
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__290 : IEnumerator<object> // TypeDefIndex: 2273
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__290(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD35B0-0x0000000180AD3D70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD3D70-0x0000000180AD3DB0
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__289 : IEnumerator<object> // TypeDefIndex: 2274
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__289(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180AD3DB0-0x0000000180AD4780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD4780-0x0000000180AD47C0
	}

	[CompilerGenerated]
	private sealed class _PlayCardEffectAnimation_d__291 : IEnumerator<object> // TypeDefIndex: 2275
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		public int userActorNumber; // 0x28
		private Active _active_5__2; // 0x30
		private int _damage_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardEffectAnimation_d__291(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180AD47C0-0x0000000180AD5580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD5580-0x0000000180AD55C0
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__221 : IEnumerator<object> // TypeDefIndex: 2276
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__221(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD55C0-0x0000000180AD58D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD58D0-0x0000000180AD5910
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__380 : IEnumerator<object> // TypeDefIndex: 2277
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__380(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD5910-0x0000000180AD5E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD5E40-0x0000000180AD5E80
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__220 : IEnumerator<object> // TypeDefIndex: 2278
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__220(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD5E80-0x0000000180AD6400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD6400-0x0000000180AD6440
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__371 : IEnumerator<object> // TypeDefIndex: 2279
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__371(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD6440-0x0000000180AD6860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD6860-0x0000000180AD68A0
	}

	[CompilerGenerated]
	private sealed class _TriggerMegaIcarusExplosion_d__383 : IEnumerator<object> // TypeDefIndex: 2280
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMegaIcarusExplosion_d__383(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AD68A0-0x0000000180AD6B10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD6B10-0x0000000180AD6B50
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__361 : IEnumerator<object> // TypeDefIndex: 2281
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float resWaitSec; // 0x20
		public float renderWaitSec; // 0x24
		private MatchService _ms_5__2; // 0x28
		private float _waited_5__3; // 0x30
		private float _rendering_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForWsSkillResolution_d__361(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180AD6B50-0x0000000180AD6E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD6E20-0x0000000180AD6E60
	}

	// Constructors
	public CardUI(); // 0x0000000180AB5D60-0x0000000180AB6740
	static CardUI(); // 0x0000000180AB6740-0x0000000180AB6BE0

	// Methods
	public void BeginPendingAction(); // 0x0000000180A8D380-0x0000000180A8D3E0
	public void ClearPendingAction(); // 0x0000000180A8D3E0-0x0000000180A8D3F0
	public static void ResetStaticState(); // 0x0000000180A8D500-0x0000000180A8D580
	IEnumerator IAuditionHost.HideCenterCardCo(); // 0x0000000180A8D780-0x0000000180A8D790
	void IAuditionHost.OnAuditionPress(string dir); // 0x0000000180A8D790-0x0000000180A8D840
	void IAuditionHost.OnAuditionTap(int elapsedMs); // 0x0000000180A8D840-0x0000000180A8D8A0
	public Image GetCenterCardImage(); // 0x00000001802D8E90-0x00000001802D8EA0
	private void Start(); // 0x0000000180A8D8A0-0x0000000180A8E140
	public static bool IsRowSkillType(string upperType); // 0x0000000180A8E140-0x0000000180A8E210
	public static bool IsGalaxySkillType(string upperType); // 0x0000000180A8E210-0x0000000180A8E290
	public static bool IsGalaxyRickyType(string upperType); // 0x0000000180A8E290-0x0000000180A8E310
	public static bool IsMegaIcarusType(string upperType); // 0x0000000180A8E310-0x0000000180A8E390
	public static bool IsHealConvertSkillType(string upperType); // 0x0000000180A8E390-0x0000000180A8E410
	public int SkillCooldownLeft(); // 0x0000000180A8E410-0x0000000180A8E570
	public static bool IsAuditionSkillType(string upperType); // 0x0000000180A8E570-0x0000000180A8E640
	private bool IsSkillCard(); // 0x0000000180A8E640-0x0000000180A8E800
	private bool IsLocalSilenced(); // 0x0000000180A8E800-0x0000000180A8E960
	public int GetHandIndex(); // 0x0000000180A8E960-0x0000000180A8EAE0
	public bool IsDownedBuffAssist(); // 0x0000000180A8EAE0-0x0000000180A8ED70
	public bool ValidateCardUsage(); // 0x0000000180A8ED70-0x0000000180A8F390
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__220))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x0000000180A8F390-0x0000000180A8F430
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__221))]
	private IEnumerator RestoreBackgroundColor(); // 0x0000000180A8F430-0x0000000180A8F4D0
	private void SetupControlButtonListeners(); // 0x0000000180A8F4D0-0x0000000180A8FAC0
	private void HideDotSkillUI(); // 0x0000000180A8FAC0-0x0000000180A90170
	private void ShowDotSkillUI(); // 0x0000000180A90170-0x0000000180A90A00
	private void OnDestroy(); // 0x0000000180A90A00-0x0000000180A90D70
	private void CreateDotSkillPanel(); // 0x0000000180A90D70-0x0000000180A913E0
	private void ApplyQteArrowMetrics(); // 0x0000000180A913E0-0x0000000180A916F0
	private void CreateTimeSliderWithZones(); // 0x0000000180A916F0-0x0000000180A923E0
	private void RemoveZonesFromSlider(); // 0x0000000180A923E0-0x0000000180A92790
	private Transform GetQteZoneParent(); // 0x0000000180A92790-0x0000000180A92B60
	private void ClearQteZones(Transform parent); // 0x0000000180A92B60-0x0000000180A92DC0
	private void RebuildQteZones(); // 0x0000000180A92DC0-0x0000000180A93160
	private void CreateQteZone(Transform parent, float fromSec, float toSec, float total, Color color, string suffix, bool sendToBack); // 0x0000000180A93160-0x0000000180A934C0
	private static Sprite LoadVolumeSprite(string name); // 0x0000000180A934C0-0x0000000180A93790
	private void BuildAuditionTimeline(); // 0x0000000180A93790-0x0000000180A95980
	private void BuildPerfectMarkers(RectTransform track, float total); // 0x0000000180A95980-0x0000000180A960F0
	private void BuildAuditionRibbon(Transform host, Vector2 panelPos, float panelH); // 0x0000000180A960F0-0x0000000180A968E0
	private void BuildAuditionJudgeText(RectTransform root); // 0x0000000180A968E0-0x0000000180A96DE0
	private void PulseAuditionStar(bool on); // 0x0000000180A96DE0-0x0000000180A97390
	private void CreateTimelineZone(RectTransform track, float fromSec, float toSec, float total, Color color, string nodeName); // 0x0000000180A97390-0x0000000180A97770
	private void ResetAuditionNeedle(); // 0x0000000180A97770-0x0000000180A97CD0
	private void ReleaseAuditionTimeline(bool destroy); // 0x0000000180A97CD0-0x0000000180A98400
	private void EnsurePokyAuditionFrame(); // 0x0000000180A98400-0x0000000180A98D40
	private static Image AddAuditionFrameLayer(RectTransform host, string nodeName, Sprite sprite, Color color, float pad); // 0x0000000180A98D40-0x0000000180A99070
	private void PulseAuditionFrameGlow(); // 0x0000000180A99070-0x0000000180A993B0
	private static void SetAuditionGlowAlpha(Image img, float a); // 0x0000000180A993B0-0x0000000180A99500
	private void ApplyQteModalLayout(); // 0x0000000180A99500-0x0000000180A99D20
	private void EnsureAuditionScrim(); // 0x0000000180A99D20-0x0000000180A9A580
	private void SetAuditionScrimAlpha(float a); // 0x0000000180A9A580-0x0000000180A9A700
	private void ReleaseAuditionScrim(bool immediate); // 0x0000000180A9A700-0x0000000180A9AC20
	private QteModalSlot CaptureQteModalNode(Transform node); // 0x0000000180A9AC20-0x0000000180A9AFA0
	private void RestoreQteModalLayout(bool immediate); // 0x0000000180A9AFA0-0x0000000180A9B2F0
	private void RestoreQteModalNode(ref QteModalSlot slot); // 0x0000000180A9B2F0-0x0000000180A9B770
	private void RaiseQteOverlayOrder(); // 0x0000000180A9B770-0x0000000180A9BC20
	private static void RaiseQteButtonNode(Transform canvasT, Button btn); // 0x0000000180A9BC20-0x0000000180A9BE60
	private void ApplyQteButtonLayout(); // 0x0000000180A9BE60-0x0000000180A9C5E0
	private void CaptureQteButton(int index, Button btn); // 0x0000000180A9C5E0-0x0000000180A9CFD0
	private static void SkinDpadButton(Button btn, string dir); // 0x0000000180A9CFD0-0x0000000180A9D370
	private void PlaceDpadButton(Button btn, Vector2 pos, float size); // 0x0000000180A9D370-0x0000000180A9D750
	private void PlaceEnterButton(); // 0x0000000180A9D750-0x0000000180A9E050
	private void RestoreQteButtonLayout(); // 0x0000000180A9E050-0x0000000180A9E8B0
	private void CreateTimingText(); // 0x0000000180A9E8B0-0x0000000180A9F160
	private void LoadDotSkillSprites(); // 0x0000000180A9F160-0x0000000180A9F480
	private GameObject CreateDefaultArrowPrefab(); // 0x0000000180A9F480-0x0000000180A9F5D0
	private void CreateAnimationCanvas(); // 0x0000000180A9F5D0-0x0000000180AA0240
	[IteratorStateMachine(typeof(_HideCenterCard_d__267))]
	private IEnumerator HideCenterCard(); // 0x0000000180AA0240-0x0000000180AA02E0
	private void OnTurnStart(int entityIndex); // 0x0000000180AA02E0-0x0000000180AA04F0
	public void MarkAsUsed(); // 0x0000000180AA04F0-0x0000000180AA0800
	public void RevertOptimisticUse(); // 0x0000000180AA0800-0x0000000180AA0EC0
	public void SetCardData(CardData data); // 0x0000000180AA0EC0-0x0000000180AA1550
	public CardData GetCardData(); // 0x00000001802A8720-0x00000001802A8730
	private void RegisterInLookup(); // 0x0000000180AA1550-0x0000000180AA16F0
	public static CardUI FindByCardId(int cardId); // 0x0000000180AA16F0-0x0000000180AA19F0
	public void AdoptSharedSkillRefs(CardUI src); // 0x0000000180AA19F0-0x0000000180AA2430
	private static bool HasNoToggles(Toggle[] arr); // 0x0000000180AA2430-0x0000000180AA2580
	private bool RequiresDotSkillUI(); // 0x0000000180AA2580-0x0000000180AA2680
	private bool ValidateDotSkillComponents(); // 0x0000000180AA2680-0x0000000180AA2D20
	private string ElementTypeUpper(); // 0x0000000180AA2D20-0x0000000180AA2E50
	private bool IsBuffCard(); // 0x0000000180AA2E50-0x0000000180AA2E80
	private bool IsAttackCard(); // 0x0000000180AA2E80-0x0000000180AA3040
	private bool IsMega1Card(); // 0x0000000180AA3040-0x0000000180AA30D0
	private bool ValidateMega1CardUsage(); // 0x0000000180AA30D0-0x0000000180AA3310
	public void RefreshCardButtonState(); // 0x0000000180AA3310-0x0000000180AA3320
	public bool IsDotSkillCard(); // 0x0000000180AA3320-0x0000000180AA3410
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__289))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x0000000180AA3410-0x0000000180AA34B0
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__290))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x0000000180AA34B0-0x0000000180AA3550
	[IteratorStateMachine(typeof(_PlayCardEffectAnimation_d__291))]
	public IEnumerator PlayCardEffectAnimation(int userActorNumber); // 0x0000000180AA3550-0x0000000180AA3600
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__292))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x0000000180AA3600-0x0000000180AA36B0
	private void ApplyServerQteWindow(); // 0x0000000180AA36B0-0x0000000180AA3940
	private int CurrentQteElapsedMs(); // 0x0000000180AA3940-0x0000000180AA39D0
	private long? CurrentQteChallengeId(); // 0x0000000180AA39D0-0x0000000180AA3B40
	private int CalculateDotsToDestroy(); // 0x0000000180AA3B40-0x0000000180AA3D20
	private void SetLegendMultiplier(float multiplier); // 0x0000000180AA3D20-0x0000000180AA3EF0
	private string GetLastTimingResult(); // 0x0000000180AA3EF0-0x0000000180AA40A0
	private string NormalizeArrowDir(string raw); // 0x0000000180AA40F0-0x0000000180AA4460
	private void GenerateDotArrows(); // 0x0000000180AA4460-0x0000000180AA4E10
	private void PlayArrowIntro(); // 0x0000000180AA4E10-0x0000000180AA5250
	private void AttachArrowTapButton(Image arrow, string dir); // 0x0000000180AA5250-0x0000000180AA5590
	private void ApplyArrowSize(Image arrow); // 0x0000000180AA5590-0x0000000180AA5750
	private void RefreshArrowCue(); // 0x0000000180AA5750-0x0000000180AA5AC0
	private Color ArrowRestColor(Image arrow); // 0x0000000180AA5AC0-0x0000000180AA5BC0
	private void PulseArrow(Image arrow); // 0x0000000180AA5BC0-0x0000000180AA5D90
	private void SpawnArrowHitBurst(RectTransform arrow); // 0x0000000180AA5D90-0x0000000180AA6390
	private void RestoreShakenArrow(); // 0x0000000180AA6390-0x0000000180AA6570
	private void ShakeArrowWrong(Image arrow); // 0x0000000180AA6570-0x0000000180AA6B70
	private void ClearDotArrows(); // 0x0000000180AA6B70-0x0000000180AA7060
	private int CountMatchingDotsOnBoard(); // 0x0000000180AA7060-0x0000000180AA7510
	public void ResetCardVisual(); // 0x0000000180AA7510-0x0000000180AA7840
	private void OnEnterButtonPress(); // 0x0000000180AA7840-0x0000000180AA78B0
	private void OnDirectionButtonPress(string direction); // 0x0000000180AA78B0-0x0000000180AA78F0
	private void ShowTimingResult(); // 0x0000000180AA78F0-0x0000000180AA7E40
	private void Update(); // 0x0000000180AA7E40-0x0000000180AA80A0
	private void CheckDotArrow(string dir); // 0x0000000180AA80A0-0x0000000180AA88A0
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__323))]
	private IEnumerator BlinkEnterButton(); // 0x0000000180AA88A0-0x0000000180AA8940
	private void ResetDotCombo(); // 0x0000000180AA8940-0x0000000180AA8AB0
	private string GetDirectionFromInput(); // 0x0000000180AA8AB0-0x0000000180AA8C00
	public void ConsumeCardCondition(int actorNumber); // 0x0000000180AA8C00-0x0000000180AA9250
	public string GetDisabledReason(); // 0x0000000180AA9250-0x0000000180AA9AF0
	private bool IsHandCurtainClosed(); // 0x0000000180AA9AF0-0x0000000180AA9D60
	public bool CanUseCard(); // 0x0000000180AA9D60-0x0000000180AAA1E0
	private bool CheckConditionUse(); // 0x0000000180AAA1E0-0x0000000180AAAF10
	private void UpdateCardVisual(); // 0x0000000180AAAF10-0x0000000180AAB120
	public void ConvertToPlaceholder(); // 0x0000000180AAB120-0x0000000180AAB610
	public static void ResetAllCardsForNewMatch(); // 0x0000000180AAB610-0x0000000180AAB6D0
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__335))]
	private IEnumerator BackgroundFlickerShake(); // 0x0000000180AAB6D0-0x0000000180AAB770
	private Camera GetMatchCamera(); // 0x0000000180AAB770-0x0000000180AABBB0
	private bool EnsureMega1AlignCache(); // 0x0000000180AABBB0-0x0000000180AAC6C0
	private void LateUpdate(); // 0x0000000180AAC6C0-0x0000000180AACFE0
	private void SetupMega1PanelOnce(); // 0x0000000180AACFE0-0x0000000180AAD6C0
	public void StartMega1Panel(); // 0x0000000180AAD6C0-0x0000000180AAD770
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__349))]
	private IEnumerator OpenMega1Panel(); // 0x0000000180AAD770-0x0000000180AAD810
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x0000000180AAD810-0x0000000180AADEA0
	private static void SendSkillHintSafe(Dictionary<string, object> payload); // 0x0000000180AADEA0-0x0000000180AAE150
	private static string SkillHintKey(Dictionary<string, object> p); // 0x0000000180AAE150-0x0000000180AAE2C0
	private static void SendSkillHintNow(Dictionary<string, object> payload); // 0x0000000180AAE2C0-0x0000000180AAE480
	private static void FlushPendingSkillHints(); // 0x0000000180AAE480-0x0000000180AAE760
	private static void SendQteEventSafe(Dictionary<string, object> payload); // 0x0000000180AAE760-0x0000000180AAE920
	private void UpdateMega1UI(); // 0x0000000180AAE920-0x0000000180AAEC30
	private void CloseMega1Panel(bool executeDestroy); // 0x0000000180AAEC30-0x0000000180AAF110
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__361))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x005F087A */, float renderWaitSec = 14f /* Metadata: 0x005F087E */); // 0x0000000180AAF110-0x0000000180AAF180
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__362))]
	private IEnumerator Mega1WatchTurnTime(); // 0x0000000180AAF180-0x0000000180AAF220
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__363))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x0000000180AAF220-0x0000000180AAF2C0
	private void AccumulateMega1WaveIntoDestroyedCountByTag(); // 0x0000000180AAF2C0-0x0000000180AAF8D0
	private void SetupMega2PanelOnce(); // 0x0000000180AAF8D0-0x0000000180AB00C0
	private void AlignMega2TogglesToBoard(); // 0x0000000180AB00C0-0x0000000180AB0A80
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x0000000180AB0A80-0x0000000180AB0C10
	public void StartMega2Panel(); // 0x0000000180AB0C10-0x0000000180AB0CC0
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__369))]
	private IEnumerator OpenMega2Panel(); // 0x0000000180AB0CC0-0x0000000180AB0D60
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x0000000180AB0D60-0x0000000180AB17D0
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__371))]
	private IEnumerator TriggerMega2Explosion(); // 0x0000000180AB17D0-0x0000000180AB1870
	private void CloseMega2Panel(bool executeDestroy); // 0x0000000180AB1870-0x0000000180AB2020
	public void ForceCloseMega2Panel(); // 0x0000000180AB2020-0x0000000180AB2790
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__374))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x0000000180AB2790-0x0000000180AB2830
	private HashSet<ValueTuple<int, int>> Collect3x3Positions([TupleElementNames(new string[2] {"col", "row" })] List<ValueTuple<int, int>> dots, int W, int H); // 0x0000000180AB2830-0x0000000180AB2AD0
	private void AccumulateMega2WaveIntoDestroyedCountByTag(HashSet<ValueTuple<int, int>> positions); // 0x0000000180AB2AD0-0x0000000180AB2F80
	private void SetupMegaIcarusPanelOnce(); // 0x0000000180AB2F80-0x0000000180AB3770
	private void AlignMegaIcarusTogglesToBoard(); // 0x0000000180AB3770-0x0000000180AB4130
	public void StartMegaIcarusPanel(); // 0x0000000180AB4130-0x0000000180AB4360
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__380))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x0000000180AB4360-0x0000000180AB4400
	[IteratorStateMachine(typeof(_OpenMegaIcarusPanel_d__381))]
	private IEnumerator OpenMegaIcarusPanel(); // 0x0000000180AB4400-0x0000000180AB44A0
	private void OnMegaIcarusToggleChanged(int col, int row, int idx, bool isOn); // 0x0000000180AB44A0-0x0000000180AB4C50
	[IteratorStateMachine(typeof(_TriggerMegaIcarusExplosion_d__383))]
	private IEnumerator TriggerMegaIcarusExplosion(); // 0x0000000180AB4C50-0x0000000180AB4CF0
	private void CloseMegaIcarusPanel(bool executeDestroy); // 0x0000000180AB4CF0-0x0000000180AB5450
	public void ForceCloseMegaIcarusPanel(); // 0x0000000180AB5450-0x0000000180AB5B90
	[IteratorStateMachine(typeof(_ExecuteMegaIcarusDotDestruction_d__386))]
	private IEnumerator ExecuteMegaIcarusDotDestruction(); // 0x0000000180AB5B90-0x0000000180AB5C30
	private HashSet<ValueTuple<int, int>> CollectRadiusPositions(int centerCol, int centerRow, int radius, int W, int H); // 0x0000000180AB5C30-0x0000000180AB5D60
	[CompilerGenerated]
	private void _Start_b__207_0(); // 0x0000000180AB6BE0-0x0000000180AB6FE0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__222_0(); // 0x0000000180AB6FE0-0x0000000180AB7050
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__222_1(); // 0x0000000180AB7050-0x0000000180AB70C0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__222_2(); // 0x0000000180AB70C0-0x0000000180AB7130
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__222_3(); // 0x0000000180AB7130-0x0000000180AB71A0
	[CompilerGenerated]
	private void _EnsureAuditionScrim_b__249_0(float v); // 0x0000000180AB71A0-0x0000000180AB7260
}

