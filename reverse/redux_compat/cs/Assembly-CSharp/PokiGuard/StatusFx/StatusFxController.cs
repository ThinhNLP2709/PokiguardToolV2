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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokiGuard.StatusFx
{
	public class StatusFxController : MonoBehaviour // TypeDefIndex: 1840
	{
		// Fields
		private static StatusFxController _instance; // 0x00
		private static bool _isQuitting; // 0x08
		[SerializeField]
		private Vector2 selfBarViewport; // 0x20
		[SerializeField]
		private Vector2 enemyBarViewport; // 0x28
		[SerializeField]
		[Tooltip("T\u1ED5ng s\u1ED1 icon t\u1ED1i \u0111a 1 bar (pool t\u1EA1o s\u1EB5n). Grid 4 c\u1ED9t \u00D7 3 h\u00E0ng = 12.")]
		private int maxIconsPerBar; // 0x30
		[SerializeField]
		[Tooltip("S\u1ED1 C\u1ED8T c\u1EE7a grid icon status. Qu\u00E1 1 h\u00E0ng th\u00EC t\u1EF1 xu\u1ED1ng h\u00E0ng (xem BuildBar).")]
		private int gridColumns; // 0x34
		private const int GridMinRows = 3; // Metadata: 0x0064DC5B
		[SerializeField]
		private int popupPoolSize; // 0x38
		[SerializeField]
		private int vfxPoolSize; // 0x3C
		[SerializeField]
		private float castVfxFps; // 0x40
		[SerializeField]
		[Tooltip("Chu\u1ED7i VFX n\u1ED5 khi ra chi\u00EAu (Resources/Image/SkillVfx/{key}_0001..).")]
		private string castVfxKey; // 0x48
		[SerializeField]
		private string counterVfxKey; // 0x50
		[SerializeField]
		[Tooltip("Chu\u1ED7i VFX khi qu\u00E1i \u0111\u1EA3o TI\u1EBEN H\u00D3A (b\u1ED9 fx_0002..fx_0031 \u2014 kh\u00F4ng c\u00F3 _0001).")]
		private string bossEvolveVfxKey; // 0x58
		[Header("Designer wiring (optional) \u2014 \u0111\u1EB7t controller trong scene/prefab Match v\u00E0 wire 2 node d\u01B0\u1EDBi \u0111\u00E2y \u0111\u1EC3 t\u1EF1 quy\u1EBFt v\u1ECB tr\u00ED bar; b\u1ECF tr\u1ED1ng = t\u1EF1 d\u1EF1ng canvas.")]
		[SerializeField]
		private RectTransform selfBarParent; // 0x60
		[SerializeField]
		private RectTransform enemyBarParent; // 0x68
		[Header("K\u00EDch th\u01B0\u1EDBc \u2014 t\u00EDnh theo \u0110\u01A0N V\u1ECA CANVAS \u0111ang ch\u1EE9a bar, KH\u00D4NG ph\u1EA3i pixel m\u00E0n h\u00ECnh. CanvasAnimation c\u1EE7a tr\u1EADn chu\u1EA9n 800x600, icon khi\u00EAn PDef s\u1EB5n c\u00F3 l\u00E0 61x70 \u2192 ch\u1EC9nh c\u00E1c s\u1ED1 d\u01B0\u1EDBi \u0111\u00E2y cho c\u00E2n v\u1EDBi n\u00F3 khi xem th\u1EF1c t\u1EBF.")]
		[SerializeField]
		private float iconSize; // 0x70
		[SerializeField]
		private float iconSpacing; // 0x74
		[SerializeField]
		private int turnFontSize; // 0x78
		[SerializeField]
		private int popupFontSize; // 0x7C
		[SerializeField]
		private int popupBigFontSize; // 0x80
		[SerializeField]
		private float castVfxSize; // 0x84
		[SerializeField]
		private float castVfxBigSize; // 0x88
		[SerializeField]
		private int evolveLabelFontSize; // 0x8C
		[SerializeField]
		private Color evolveLabelColor; // 0x90
		[SerializeField]
		private int critLabelFontSize; // 0xA0
		[SerializeField]
		private Color critLabelColor; // 0xA4
		private Canvas _canvas; // 0xB8
		private Font _font; // 0xC0
		private RectTransform _selfAnchor; // 0xC8
		private RectTransform _enemyAnchor; // 0xD0
		private readonly Dictionary<int, Dictionary<string, StatusEntry>> _model; // 0xD8
		private const int UNBOUND = 2147483647; // Metadata: 0x0064DC5C
		private int _selfActor; // 0xE0
		private int _enemyActor; // 0xE4
		private BarView _selfBar; // 0xE8
		private BarView _enemyBar; // 0xF0
		private readonly List<PopupWidget> _popupPool; // 0xF8
		private readonly List<VfxWidget> _vfxPool; // 0x100
		private int _popupCursor; // 0x108
		private int _vfxCursor; // 0x10C
		private const int CritLabelMaxPerSecond = 2; // Metadata: 0x0064DC5D
		private float _critWindowStartUnscaled; // 0x110
		private int _critLabelsInWindow; // 0x114
	
		// Properties
		public static StatusFxController Existing { get; } // 0x00000001806091F0-0x0000000180609230 
		public static StatusFxController Instance { get; } // 0x0000000180609230-0x0000000180609490 
		private int EffectiveMaxIcons { get; } // 0x00000001806091D0-0x00000001806091F0 
	
		// Nested types
		private class StatusEntry // TypeDefIndex: 1841
		{
			// Fields
			public int turnsLeft; // 0x10
			public double value; // 0x18
	
			// Constructors
			public StatusEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class IconWidget // TypeDefIndex: 1842
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
			public IconWidget(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class BarView // TypeDefIndex: 1843
		{
			// Fields
			public RectTransform root; // 0x10
			public GridLayoutGroup grid; // 0x18
			public bool isSelf; // 0x20
			public readonly List<IconWidget> pool; // 0x28
			public readonly Dictionary<string, IconWidget> shown; // 0x30
	
			// Constructors
			public BarView(); // 0x00000001805FFE00-0x00000001805FFEC0
		}
	
		private class PopupWidget // TypeDefIndex: 1844
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public UnityEngine.UI.Text text; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public PopupWidget(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class VfxWidget // TypeDefIndex: 1845
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public Image img; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public VfxWidget(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass89_0 // TypeDefIndex: 1846
		{
			// Fields
			public GameObject go; // 0x10
			public UnityEngine.UI.Text txt; // 0x18
	
			// Constructors
			public __c__DisplayClass89_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SpawnFloatingLabel_b__0(); // 0x0000000180612860-0x0000000180612930
			internal void _SpawnFloatingLabel_b__1(float a); // 0x0000000180612930-0x0000000180612A20
			internal void _SpawnFloatingLabel_b__2(); // 0x0000000180612A20-0x0000000180612A90
		}
	
		[CompilerGenerated]
		private sealed class _FadeOutAndRelease_d__79 : IEnumerator<object> // TypeDefIndex: 1847
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _FadeOutAndRelease_d__79(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
			private bool MoveNext(); // 0x0000000180610D30-0x0000000180611130
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180611130-0x0000000180611170
		}
	
		[CompilerGenerated]
		private sealed class _FloatPopup_d__80 : IEnumerator<object> // TypeDefIndex: 1848
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _FloatPopup_d__80(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000180611170-0x0000000180611630
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180611630-0x0000000180611670
		}
	
		[CompilerGenerated]
		private sealed class _PlayFrames_d__90 : IEnumerator<object> // TypeDefIndex: 1849
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _PlayFrames_d__90(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000180611670-0x0000000180611AD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180611AD0-0x0000000180611B10
		}
	
		[CompilerGenerated]
		private sealed class _PopIn_d__77 : IEnumerator<object> // TypeDefIndex: 1850
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _PopIn_d__77(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x0000000180611B10-0x0000000180611DE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180611DE0-0x0000000180611E20
		}
	
		[CompilerGenerated]
		private sealed class _Pulse_d__78 : IEnumerator<object> // TypeDefIndex: 1851
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Pulse_d__78(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x0000000180611E20-0x0000000180612090
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180612090-0x00000001806120D0
		}
	
		// Constructors
		public StatusFxController(); // 0x0000000180608F70-0x00000001806091D0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics(); // 0x0000000180607650-0x00000001806076B0
		public static void Shutdown(); // 0x0000000180607DF0-0x0000000180607ED0
		private void Awake(); // 0x00000001806042D0-0x00000001806043C0
		private void OnEnable(); // 0x0000000180606BE0-0x0000000180606CE0
		private void OnDisable(); // 0x0000000180606AE0-0x0000000180606BE0
		private void OnDestroy(); // 0x0000000180606A30-0x0000000180606AE0
		private void OnApplicationQuit(); // 0x00000001806069F0-0x0000000180606A30
		private void HandleSceneUnloaded(Scene s); // 0x0000000180605F80-0x0000000180606010
		private void HandleMatchExit(MatchKind kind); // 0x0000000180605F70-0x0000000180605F80
		public void BindActors(int selfActor, int enemyActor); // 0x00000001806043C0-0x0000000180604440
		public void NotifySelfDisplayActor(int actor); // 0x00000001806069C0-0x00000001806069F0
		public void ApplyStatusOp(string action, int actorNumber, bool isSelf, string type, int turnsLeft, double value, string source); // 0x0000000180603A90-0x00000001806042D0
		public void ClearAll(); // 0x0000000180605AA0-0x0000000180605DB0
		public void ResetForNewMatch(); // 0x0000000180607620-0x0000000180607650
		public static bool IsActive(int actorNumber, string type); // 0x00000001806063F0-0x0000000180606530
		private void ModelUpsert(int actor, string key, int turnsLeft, double value, bool upsertOnlyIfExists = false /* Metadata: 0x0064DC57 */); // 0x0000000180606800-0x00000001806069C0
		private void ModelRemove(int actor, string key); // 0x0000000180606760-0x0000000180606800
		private BarView ResolveBar(int actor, bool isSelfHint); // 0x00000001806076B0-0x00000001806076F0
		private void RenderBar(BarView bar, int actor); // 0x0000000180607430-0x0000000180607620
		private void ShowOrRefreshIcon(BarView bar, string key, int turnsLeft, bool animate = true /* Metadata: 0x0064DC58 */); // 0x0000000180607880-0x0000000180607DF0
		private void UpdateIconTurns(BarView bar, string key, int turnsLeft); // 0x0000000180608DE0-0x0000000180608F70
		private void HideIcon(BarView bar, string key); // 0x0000000180606280-0x00000001806063F0
		private void HideAllInBar(BarView bar); // 0x0000000180606010-0x0000000180606280
		private void SetTurns(IconWidget w, string key, int turnsLeft); // 0x0000000180607760-0x0000000180607880
		private void RestartAnim(IconWidget w, IEnumerator routine); // 0x00000001806076F0-0x0000000180607760
		private void SpawnPopup(RectTransform anchor, string text, string type, bool big = false /* Metadata: 0x0064DC59 */); // 0x00000001806088D0-0x0000000180608C80
		[IteratorStateMachine(typeof(_PopIn_d__77))]
		private IEnumerator PopIn(IconWidget w); // 0x0000000180607350-0x00000001806073C0
		[IteratorStateMachine(typeof(_Pulse_d__78))]
		private IEnumerator Pulse(IconWidget w); // 0x00000001806073C0-0x0000000180607430
		[IteratorStateMachine(typeof(_FadeOutAndRelease_d__79))]
		private IEnumerator FadeOutAndRelease(IconWidget w, BarView bar = null); // 0x0000000180605DB0-0x0000000180605E60
		[IteratorStateMachine(typeof(_FloatPopup_d__80))]
		private IEnumerator FloatPopup(PopupWidget p, bool big); // 0x0000000180605E60-0x0000000180605EE0
		public void PlayCastVfx(bool atSelf, string key = null, bool big = false /* Metadata: 0x0064DC5A */); // 0x0000000180606DB0-0x0000000180607280
		public void PlayCounterVfx(bool atSelf); // 0x0000000180607280-0x00000001806072A0
		public void PlayBossEvolveVfx(); // 0x0000000180606CE0-0x0000000180606DB0
		private void SpawnEvolveLabel(); // 0x0000000180607FE0-0x00000001806080A0
		public void SpawnCritLabel(bool atSelf); // 0x0000000180607ED0-0x0000000180607FE0
		private void SpawnFloatingLabel(RectTransform anchor, string goName, string content, int fontSize, Color color, float riseY, float riseDur, float fadeDelay, float fadeDur); // 0x00000001806080A0-0x00000001806088D0
		[IteratorStateMachine(typeof(_PlayFrames_d__90))]
		private IEnumerator PlayFrames(VfxWidget v, Sprite[] frames); // 0x00000001806072A0-0x0000000180607350
		private void BuildHierarchy(); // 0x00000001806048E0-0x0000000180604DB0
		private RectTransform MakeAnchor(string name, Vector2 viewport); // 0x0000000180606530-0x0000000180606760
		private BarView BuildBar(RectTransform anchor, string name, bool isSelf); // 0x0000000180604440-0x00000001806048E0
		private void SyncGridColumns(BarView bar); // 0x0000000180608C80-0x0000000180608DE0
		private IconWidget BuildIconWidget(RectTransform parent, int index); // 0x0000000180604DB0-0x0000000180605520
		private PopupWidget BuildPopupWidget(int index); // 0x0000000180605520-0x0000000180605840
		private VfxWidget BuildVfxWidget(int index); // 0x0000000180605840-0x0000000180605AA0
		private Font GetFont(); // 0x0000000180605EE0-0x0000000180605F70
		private void AddOutline(GameObject go); // 0x0000000180603A00-0x0000000180603A90
	}
}
