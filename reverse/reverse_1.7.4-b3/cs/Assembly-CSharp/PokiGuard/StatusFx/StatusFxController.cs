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

namespace PokiGuard.StatusFx
{
	public class StatusFxController : MonoBehaviour // TypeDefIndex: 2518
	{
		// Fields
		private static StatusFxController _instance; // 0x00
		private static bool _isQuitting; // 0x08
		[SerializeField]
		private Vector2 selfBarViewport; // 0x20
		[SerializeField]
		private Vector2 enemyBarViewport; // 0x28
		[SerializeField]
		[Tooltip("T\u1ED5ng s\u1ED1 icon t\u1ED1i \u0111a 1 bar (pool t\u1EA1o s\u1EB5n). Grid 6 c\u1ED9t \u00D7 2 h\u00E0ng = 12.")]
		private int maxIconsPerBar; // 0x30
		[SerializeField]
		[Tooltip("S\u1ED1 C\u1ED8T c\u1EE7a grid icon status. Qu\u00E1 1 h\u00E0ng th\u00EC t\u1EF1 xu\u1ED1ng h\u00E0ng (xem BuildBar).")]
		private int gridColumns; // 0x34
		private const int GridMinRows = 2; // Metadata: 0x005F0FBB
		public const int SortingOrder = 890; // Metadata: 0x005F0FBC
		[Header("Ghim h\u00E0ng icon l\u00EAn TR\u00CAN nh\u00E3n t\u00EAn (09/09). T\u1EAFt = bar \u0111\u1EE9ng t\u1EA1i anchor nh\u01B0 c\u0169.")]
		[SerializeField]
		private bool pinBarsAboveNameLabels; // 0x38
		[SerializeField]
		[Tooltip("T\u00EAn GameObject nh\u00E3n t\u00EAn NG\u01AF\u1EDCI CH\u01A0I trong rig tr\u1EADn. Text n\u00E0y c\u0103n PH\u1EA2I \u21D2 bar ghim m\u00E9p ph\u1EA3i, m\u1ECDc sang tr\u00E1i.")]
		private string selfNameLabel; // 0x40
		[SerializeField]
		[Tooltip("T\u00EAn GameObject nh\u00E3n t\u00EAn \u0110\u1ED0I TH\u1EE6/BOSS trong rig tr\u1EADn. Text n\u00E0y c\u0103n TR\u00C1I \u21D2 bar ghim m\u00E9p tr\u00E1i, m\u1ECDc sang ph\u1EA3i.")]
		private string enemyNameLabel; // 0x48
		[SerializeField]
		[Tooltip("Khe h\u1EDF gi\u1EEFa m\u00E9p tr\u00EAn nh\u00E3n t\u00EAn v\u00E0 \u0111\u00E1y h\u00E0ng icon (\u0111\u01A1n v\u1ECB canvas rig).")]
		private float nameLabelGap; // 0x50
		[SerializeField]
		private int popupPoolSize; // 0x54
		[SerializeField]
		private int vfxPoolSize; // 0x58
		[SerializeField]
		private float castVfxFps; // 0x5C
		[SerializeField]
		[Tooltip("Chu\u1ED7i VFX n\u1ED5 khi ra chi\u00EAu (Resources/Image/SkillVfx/{key}_0001..).")]
		private string castVfxKey; // 0x60
		[SerializeField]
		private string counterVfxKey; // 0x68
		[SerializeField]
		[Tooltip("Chu\u1ED7i VFX khi qu\u00E1i \u0111\u1EA3o TI\u1EBEN H\u00D3A (b\u1ED9 fx_0002..fx_0031 \u2014 kh\u00F4ng c\u00F3 _0001).")]
		private string bossEvolveVfxKey; // 0x70
		[Header("Designer wiring (optional) \u2014 \u0111\u1EB7t controller trong scene/prefab Match v\u00E0 wire 2 node d\u01B0\u1EDBi \u0111\u00E2y \u0111\u1EC3 t\u1EF1 quy\u1EBFt v\u1ECB tr\u00ED bar; b\u1ECF tr\u1ED1ng = t\u1EF1 d\u1EF1ng canvas.")]
		[SerializeField]
		private RectTransform selfBarParent; // 0x78
		[SerializeField]
		private RectTransform enemyBarParent; // 0x80
		[Header("K\u00EDch th\u01B0\u1EDBc \u2014 t\u00EDnh theo \u0110\u01A0N V\u1ECA CANVAS \u0111ang ch\u1EE9a bar, KH\u00D4NG ph\u1EA3i pixel m\u00E0n h\u00ECnh. CanvasAnimation c\u1EE7a tr\u1EADn chu\u1EA9n 800x600, icon khi\u00EAn PDef s\u1EB5n c\u00F3 l\u00E0 61x70 \u2192 ch\u1EC9nh c\u00E1c s\u1ED1 d\u01B0\u1EDBi \u0111\u00E2y cho c\u00E2n v\u1EDBi n\u00F3 khi xem th\u1EF1c t\u1EBF.")]
		[SerializeField]
		private float iconSize; // 0x88
		[SerializeField]
		private float iconSpacing; // 0x8C
		[SerializeField]
		private int turnFontSize; // 0x90
		[SerializeField]
		private int popupFontSize; // 0x94
		[SerializeField]
		private int popupBigFontSize; // 0x98
		[SerializeField]
		private float castVfxSize; // 0x9C
		[SerializeField]
		private float castVfxBigSize; // 0xA0
		[SerializeField]
		private int evolveLabelFontSize; // 0xA4
		[SerializeField]
		private Color evolveLabelColor; // 0xA8
		[SerializeField]
		private int critLabelFontSize; // 0xB8
		[SerializeField]
		private Color critLabelColor; // 0xBC
		private Canvas _canvas; // 0xD0
		private Font _font; // 0xD8
		private RectTransform _selfAnchor; // 0xE0
		private RectTransform _enemyAnchor; // 0xE8
		private RectTransform _selfNameRt; // 0xF0
		private RectTransform _enemyNameRt; // 0xF8
		private int _nameSearchFrame; // 0x100
		private readonly Vector3[] _cornerBuf; // 0x108
		private int _pinScreenW; // 0x110
		private int _pinScreenH; // 0x114
		private readonly List<int> _clearNotifyBuffer; // 0x118
		private readonly Dictionary<int, Dictionary<string, StatusEntry>> _model; // 0x120
		private const int UNBOUND = 2147483647; // Metadata: 0x005F0FBE
		private int _selfActor; // 0x128
		private int _enemyActor; // 0x12C
		private BarView _selfBar; // 0x130
		private BarView _enemyBar; // 0x138
		private readonly List<PopupWidget> _popupPool; // 0x140
		private readonly List<VfxWidget> _vfxPool; // 0x148
		private int _popupCursor; // 0x150
		private int _vfxCursor; // 0x154
		[CompilerGenerated]
		private static Action<int> OnStatusModelChanged; // 0x10
		private const int CritLabelMaxPerSecond = 2; // Metadata: 0x005F0FBF
		private float _critWindowStartUnscaled; // 0x158
		private int _critLabelsInWindow; // 0x15C
		private static readonly Color TimingPerfectColor; // 0x18
		private static readonly Color TimingGoodColor; // 0x28
		private static readonly Color TimingGreatColor; // 0x38
		private static readonly Color TimingCoolColor; // 0x48
		private static readonly Color TimingBadV3Color; // 0x58
		private static readonly Color TimingMissColor; // 0x68
		private const int TimingLabelMaxPerSecond = 2; // Metadata: 0x005F0FC0
		private float _timingWindowStartUnscaled; // 0x160
		private int _timingLabelsInWindow; // 0x164
		private static readonly Color GuildMateLabelColor; // 0x78
		private const int GuildMateLabelFontSize = 40; // Metadata: 0x005F0FC1
		private const int GuildMateLabelMaxPerSecond = 2; // Metadata: 0x005F0FC2
		private float _mateWindowStartUnscaled; // 0x168
		private int _mateLabelsInWindow; // 0x16C
	
		// Properties
		public static StatusFxController Existing { get; } // 0x0000000180B9E1C0-0x0000000180B9E220 
		public static StatusFxController Instance { get; } // 0x0000000180B9E220-0x0000000180B9E660 
		private int EffectiveMaxIcons { get; } // 0x0000000180B9E890-0x0000000180B9E8B0 
		public RectTransform OverlayRoot { get; } // 0x0000000180B9EB50-0x0000000180B9ED50 
		public Canvas OverlayCanvas { get; } // 0x0000000180B9ED50-0x0000000180B9EF20 
		public int CritLabelFontSize { get; } // 0x000000018029B0F0-0x000000018029B100 
		public MonoBehaviour Host { get; } // 0x0000000180422710-0x0000000180422720 
	
		// Events
		public static event Action<int> OnStatusModelChanged {
			add; // 0x0000000180BA0A50-0x0000000180BA0BA0
			remove; // 0x0000000180BA0BA0-0x0000000180BA0CF0
		}
	
		// Nested types
		private class StatusEntry // TypeDefIndex: 2519
		{
			// Fields
			public int turnsLeft; // 0x10
			public double value; // 0x18
	
			// Constructors
			public StatusEntry(); // 0x000000018028A320-0x000000018028A330
		}
	
		private class IconWidget // TypeDefIndex: 2520
		{
			// Fields
			public string type; // 0x10
			public GameObject go; // 0x18
			public Image bg; // 0x20
			public Image icon; // 0x28
			public UnityEngine.UI.Text turnText; // 0x30
			public CanvasGroup cg; // 0x38
			public Coroutine anim; // 0x40
	
			// Constructors
			public IconWidget(); // 0x000000018028A320-0x000000018028A330
		}
	
		private class BarView // TypeDefIndex: 2521
		{
			// Fields
			public RectTransform root; // 0x10
			public GridLayoutGroup grid; // 0x18
			public bool isSelf; // 0x20
			public bool pinned; // 0x21
			public Vector3 pinWorld; // 0x24
			public readonly List<IconWidget> pool; // 0x30
			public readonly Dictionary<string, IconWidget> shown; // 0x38
	
			// Constructors
			public BarView(); // 0x0000000180BA9FF0-0x0000000180BAA160
		}
	
		private class PopupWidget // TypeDefIndex: 2522
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public UnityEngine.UI.Text text; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public PopupWidget(); // 0x000000018028A320-0x000000018028A330
		}
	
		private class VfxWidget // TypeDefIndex: 2523
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public Image img; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public VfxWidget(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass133_0 // TypeDefIndex: 2524
		{
			// Fields
			public bool ignoreTimeScale; // 0x10
			public GameObject go; // 0x18
			public UnityEngine.UI.Text txt; // 0x20
	
			// Constructors
			public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SpawnFloatingLabel_b__0(); // 0x0000000180BAA160-0x0000000180BAA2D0
			internal void _SpawnFloatingLabel_b__1(float a); // 0x0000000180BAA2D0-0x0000000180BAA450
			internal void _SpawnFloatingLabel_b__2(); // 0x0000000180BAA450-0x0000000180BAA580
		}
	
		[CompilerGenerated]
		private sealed class _FadeOutAndRelease_d__106 : IEnumerator<object> // TypeDefIndex: 2525
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			public StatusFxController __4__this; // 0x28
			public BarView bar; // 0x30
			private float _d_5__2; // 0x38
			private float _e_5__3; // 0x3C
			private Transform _t_5__4; // 0x40
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _FadeOutAndRelease_d__106(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
			private bool MoveNext(); // 0x0000000180BAA580-0x0000000180BAAE40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BAAE40-0x0000000180BAAE80
		}
	
		[CompilerGenerated]
		private sealed class _FloatPopup_d__107 : IEnumerator<object> // TypeDefIndex: 2526
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PopupWidget p; // 0x20
			public bool big; // 0x28
			private float _life_5__2; // 0x2C
			private float _e_5__3; // 0x30
			private Vector2 _start_5__4; // 0x34
			private float _rise_5__5; // 0x3C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _FloatPopup_d__107(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180BAAED0-0x0000000180BAB680
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BAB680-0x0000000180BAB6C0
		}
	
		[CompilerGenerated]
		private sealed class _PlayFrames_d__134 : IEnumerator<object> // TypeDefIndex: 2527
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public StatusFxController __4__this; // 0x20
			public VfxWidget v; // 0x28
			public Sprite[] frames; // 0x30
			private float _frameDur_5__2; // 0x38
			private float _e_5__3; // 0x3C
			private float _d_5__4; // 0x40
			private int _i_5__5; // 0x44
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _PlayFrames_d__134(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180BAB6C0-0x0000000180BABDE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BABDE0-0x0000000180BABE20
		}
	
		[CompilerGenerated]
		private sealed class _PopIn_d__104 : IEnumerator<object> // TypeDefIndex: 2528
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _PopIn_d__104(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180BABE20-0x0000000180BAC3B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BAC3B0-0x0000000180BAC3F0
		}
	
		[CompilerGenerated]
		private sealed class _Pulse_d__105 : IEnumerator<object> // TypeDefIndex: 2529
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Pulse_d__105(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180BAC3F0-0x0000000180BAC920
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BAC920-0x0000000180BAC960
		}
	
		// Constructors
		public StatusFxController(); // 0x0000000180BA9870-0x0000000180BA9F00
		static StatusFxController(); // 0x0000000180BA9F00-0x0000000180BA9FF0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics(); // 0x0000000180B9E100-0x0000000180B9E1C0
		public static void Shutdown(); // 0x0000000180B9E660-0x0000000180B9E890
		private void Awake(); // 0x0000000180B9E8B0-0x0000000180B9EB50
		public RectTransform AnchorFor(bool atSelf); // 0x0000000180B9EF20-0x0000000180B9EF40
		private void OnEnable(); // 0x0000000180B9EF40-0x0000000180B9F060
		private void OnDisable(); // 0x0000000180B9F060-0x0000000180B9F180
		private void LateUpdate(); // 0x0000000180B9F180-0x0000000180B9F190
		private void OnDestroy(); // 0x0000000180B9F190-0x0000000180B9F360
		private void OnApplicationQuit(); // 0x0000000180B9F360-0x0000000180B9F3C0
		private void HandleSceneUnloaded(Scene s); // 0x0000000180B9F3C0-0x0000000180B9F4C0
		private void HandleMatchExit(MatchKind kind); // 0x0000000180B9F4C0-0x0000000180B9F510
		public void BindActors(int selfActor, int enemyActor); // 0x0000000180B9F510-0x0000000180B9F590
		public void NotifySelfDisplayActor(int actor); // 0x0000000180B9F590-0x0000000180B9F5C0
		public void ApplyStatusOp(string action, int actorNumber, bool isSelf, string type, int turnsLeft, double value, string source); // 0x0000000180B9F5C0-0x0000000180BA0050
		public void ClearAll(); // 0x0000000180BA0050-0x0000000180BA0830
		public void ResetForNewMatch(); // 0x0000000180BA0830-0x0000000180BA0860
		public static bool IsActive(int actorNumber, string type); // 0x0000000180BA0860-0x0000000180BA0A50
		private void NotifyModelChanged(int actor); // 0x0000000180BA0CF0-0x0000000180BA0DE0
		public static int CollectStatusTypes(int actorNumber, List<string> outTypes); // 0x0000000180BA0DE0-0x0000000180BA10F0
		private void ModelUpsert(int actor, string key, int turnsLeft, double value, bool upsertOnlyIfExists = false /* Metadata: 0x005F0FB6 */); // 0x0000000180BA10F0-0x0000000180BA12F0
		private void ModelRemove(int actor, string key); // 0x0000000180BA12F0-0x0000000180BA13A0
		private BarView ResolveBar(int actor, bool isSelfHint); // 0x0000000180BA13A0-0x0000000180BA13E0
		private void RenderBar(BarView bar, int actor); // 0x0000000180BA13E0-0x0000000180BA1600
		private void ShowOrRefreshIcon(BarView bar, string key, int turnsLeft, bool animate = true /* Metadata: 0x005F0FB7 */); // 0x0000000180BA1600-0x0000000180BA1D50
		private void UpdateIconTurns(BarView bar, string key, int turnsLeft); // 0x0000000180BA1D50-0x0000000180BA1E00
		private void HideIcon(BarView bar, string key); // 0x0000000180BA1E00-0x0000000180BA2090
		private void HideAllInBar(BarView bar); // 0x0000000180BA2090-0x0000000180BA2450
		private void SetTurns(IconWidget w, string key, int turnsLeft); // 0x0000000180BA2450-0x0000000180BA2610
		private void RestartAnim(IconWidget w, IEnumerator routine); // 0x0000000180BA2610-0x0000000180BA26C0
		private void SpawnPopup(RectTransform anchor, string text, string type, bool big = false /* Metadata: 0x005F0FB8 */); // 0x0000000180BA26C0-0x0000000180BA2C80
		[IteratorStateMachine(typeof(_PopIn_d__104))]
		private IEnumerator PopIn(IconWidget w); // 0x0000000180BA2C80-0x0000000180BA2D20
		[IteratorStateMachine(typeof(_Pulse_d__105))]
		private IEnumerator Pulse(IconWidget w); // 0x0000000180BA2D20-0x0000000180BA2DC0
		[IteratorStateMachine(typeof(_FadeOutAndRelease_d__106))]
		private IEnumerator FadeOutAndRelease(IconWidget w, BarView bar = null); // 0x0000000180BA2DC0-0x0000000180BA2F20
		[IteratorStateMachine(typeof(_FloatPopup_d__107))]
		private IEnumerator FloatPopup(PopupWidget p, bool big); // 0x0000000180BA2F20-0x0000000180BA2FD0
		public void PlayCastVfx(bool atSelf, string key = null, bool big = false /* Metadata: 0x005F0FB9 */); // 0x0000000180BA2FD0-0x0000000180BA3740
		public void PlayCounterVfx(bool atSelf); // 0x0000000180BA3740-0x0000000180BA3760
		public void PlayBossEvolveVfx(); // 0x0000000180BA3760-0x0000000180BA3840
		private void SpawnEvolveLabel(); // 0x0000000180BA3840-0x0000000180BA3910
		public void SpawnCritLabel(bool atSelf); // 0x0000000180BA3910-0x0000000180BA3A70
		public void SpawnTimingLabel(bool atSelf, string verdict); // 0x0000000180BA3A70-0x0000000180BA3EC0
		public void SpawnGuildMateDamageLabel(string content); // 0x0000000180BA3EC0-0x0000000180BA4060
		public void SpawnGuildBossStateLabel(string content, Color color); // 0x0000000180BA4060-0x0000000180BA4140
		public void SpawnFloatingLabel(RectTransform anchor, string goName, string content, int fontSize, Color color, float riseY, float riseDur, float fadeDelay, float fadeDur, bool ignoreTimeScale = false /* Metadata: 0x005F0FBA */); // 0x0000000180BA4140-0x0000000180BA4DE0
		[IteratorStateMachine(typeof(_PlayFrames_d__134))]
		private IEnumerator PlayFrames(VfxWidget v, Sprite[] frames); // 0x0000000180BA4DE0-0x0000000180BA4F40
		private void BuildHierarchy(); // 0x0000000180BA4F40-0x0000000180BA5790
		private RectTransform MakeAnchor(string name, Vector2 viewport); // 0x0000000180BA5790-0x0000000180BA5A40
		private BarView BuildBar(RectTransform anchor, string name, bool isSelf); // 0x0000000180BA5A40-0x0000000180BA61E0
		private void SyncGridColumns(BarView bar); // 0x0000000180BA61E0-0x0000000180BA6600
		private void PinBarsAboveNameLabels(); // 0x0000000180BA6600-0x0000000180BA6B80
		private bool ShouldSearchLabels(); // 0x0000000180BA6B80-0x0000000180BA6C30
		private RectTransform FindLabel(string name); // 0x0000000180BA6C30-0x0000000180BA70D0
		private static Transform FindDeep(Transform root, string name); // 0x0000000180BA70D0-0x0000000180BA7370
		private void PinBar(BarView bar, RectTransform label, bool alignRight, bool force); // 0x0000000180BA7370-0x0000000180BA7B20
		private static void UnpinBar(BarView bar); // 0x0000000180BA7B20-0x0000000180BA7C80
		private static Camera CameraOf(RectTransform label, out bool ready); // 0x0000000180BA7C80-0x0000000180BA7FC0
		private IconWidget BuildIconWidget(RectTransform parent, int index); // 0x0000000180BA7FC0-0x0000000180BA8C40
		private PopupWidget BuildPopupWidget(int index); // 0x0000000180BA8C40-0x0000000180BA9230
		private VfxWidget BuildVfxWidget(int index); // 0x0000000180BA9230-0x0000000180BA9680
		private Font GetFont(); // 0x0000000180BA9680-0x0000000180BA97D0
		private void AddOutline(GameObject go); // 0x0000000180BA97D0-0x0000000180BA9870
	}
}
