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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokiGuard.StatusFx
{
	public class StatusFxController : MonoBehaviour // TypeDefIndex: 2120
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
		private const int GridMinRows = 3; // Metadata: 0x0068E0BF
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
		private readonly List<int> _clearNotifyBuffer; // 0xD8
		private readonly Dictionary<int, Dictionary<string, StatusEntry>> _model; // 0xE0
		private const int UNBOUND = 2147483647; // Metadata: 0x0068E0C0
		private int _selfActor; // 0xE8
		private int _enemyActor; // 0xEC
		private BarView _selfBar; // 0xF0
		private BarView _enemyBar; // 0xF8
		private readonly List<PopupWidget> _popupPool; // 0x100
		private readonly List<VfxWidget> _vfxPool; // 0x108
		private int _popupCursor; // 0x110
		private int _vfxCursor; // 0x114
		[CompilerGenerated]
		private static Action<int> OnStatusModelChanged; // 0x10
		private const int CritLabelMaxPerSecond = 2; // Metadata: 0x0068E0C1
		private float _critWindowStartUnscaled; // 0x118
		private int _critLabelsInWindow; // 0x11C
		private static readonly Color TimingPerfectColor; // 0x18
		private static readonly Color TimingGoodColor; // 0x28
		private static readonly Color TimingBadColor; // 0x38
		private const int TimingLabelMaxPerSecond = 2; // Metadata: 0x0068E0C2
		private float _timingWindowStartUnscaled; // 0x120
		private int _timingLabelsInWindow; // 0x124
		private static readonly Color GuildMateLabelColor; // 0x48
		private const int GuildMateLabelFontSize = 40; // Metadata: 0x0068E0C3
		private const int GuildMateLabelMaxPerSecond = 2; // Metadata: 0x0068E0C4
		private float _mateWindowStartUnscaled; // 0x128
		private int _mateLabelsInWindow; // 0x12C
	
		// Properties
		public static StatusFxController Existing { get; } // 0x0000000180763FC0-0x0000000180764010 
		public static StatusFxController Instance { get; } // 0x0000000180764010-0x0000000180764280 
		private int EffectiveMaxIcons { get; } // 0x0000000180763FA0-0x0000000180763FC0 
	
		// Events
		public static event Action<int> OnStatusModelChanged {
			add; // 0x0000000180763EB0-0x0000000180763FA0
			remove; // 0x0000000180764280-0x0000000180764370
		}
	
		// Nested types
		private class StatusEntry // TypeDefIndex: 2121
		{
			// Fields
			public int turnsLeft; // 0x10
			public double value; // 0x18
	
			// Constructors
			public StatusEntry(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		private class IconWidget // TypeDefIndex: 2122
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
			public IconWidget(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		private class BarView // TypeDefIndex: 2123
		{
			// Fields
			public RectTransform root; // 0x10
			public GridLayoutGroup grid; // 0x18
			public bool isSelf; // 0x20
			public readonly List<IconWidget> pool; // 0x28
			public readonly Dictionary<string, IconWidget> shown; // 0x30
	
			// Constructors
			public BarView(); // 0x0000000180750290-0x0000000180750350
		}
	
		private class PopupWidget // TypeDefIndex: 2124
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public UnityEngine.UI.Text text; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public PopupWidget(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		private class VfxWidget // TypeDefIndex: 2125
		{
			// Fields
			public GameObject go; // 0x10
			public RectTransform rt; // 0x18
			public Image img; // 0x20
			public Coroutine anim; // 0x28
	
			// Constructors
			public VfxWidget(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass109_0 // TypeDefIndex: 2126
		{
			// Fields
			public GameObject go; // 0x10
			public UnityEngine.UI.Text txt; // 0x18
	
			// Constructors
			public __c__DisplayClass109_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _SpawnFloatingLabel_b__0(); // 0x0000000180766BF0-0x0000000180766CC0
			internal void _SpawnFloatingLabel_b__1(float a); // 0x0000000180766CC0-0x0000000180766DB0
			internal void _SpawnFloatingLabel_b__2(); // 0x0000000180766DB0-0x0000000180766E20
		}
	
		[CompilerGenerated]
		private sealed class _FadeOutAndRelease_d__85 : IEnumerator<object> // TypeDefIndex: 2127
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _FadeOutAndRelease_d__85(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
			private bool MoveNext(); // 0x0000000180764370-0x0000000180764770
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180764770-0x00000001807647B0
		}
	
		[CompilerGenerated]
		private sealed class _FloatPopup_d__86 : IEnumerator<object> // TypeDefIndex: 2128
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _FloatPopup_d__86(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807647B0-0x0000000180764C70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180764C70-0x0000000180764CB0
		}
	
		[CompilerGenerated]
		private sealed class _PlayFrames_d__110 : IEnumerator<object> // TypeDefIndex: 2129
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _PlayFrames_d__110(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180765940-0x0000000180765DA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180765DA0-0x0000000180765DE0
		}
	
		[CompilerGenerated]
		private sealed class _PopIn_d__83 : IEnumerator<object> // TypeDefIndex: 2130
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _PopIn_d__83(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x0000000180765DE0-0x00000001807660B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807660B0-0x00000001807660F0
		}
	
		[CompilerGenerated]
		private sealed class _Pulse_d__84 : IEnumerator<object> // TypeDefIndex: 2131
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IconWidget w; // 0x20
			private Transform _t_5__2; // 0x28
			private float _d_5__3; // 0x30
			private float _e_5__4; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Pulse_d__84(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x0000000180766880-0x0000000180766AF0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180766AF0-0x0000000180766B30
		}
	
		// Constructors
		public StatusFxController(); // 0x0000000180763BF0-0x0000000180763EB0
		static StatusFxController(); // 0x0000000180763B60-0x0000000180763BF0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics(); // 0x0000000180761D30-0x0000000180761DB0
		public static void Shutdown(); // 0x00000001807624F0-0x00000001807625E0
		private void Awake(); // 0x000000018075E3B0-0x000000018075E4B0
		private void OnEnable(); // 0x00000001807612C0-0x00000001807613C0
		private void OnDisable(); // 0x00000001807611C0-0x00000001807612C0
		private void OnDestroy(); // 0x0000000180761100-0x00000001807611C0
		private void OnApplicationQuit(); // 0x00000001807610B0-0x0000000180761100
		private void HandleSceneUnloaded(Scene s); // 0x0000000180760530-0x00000001807605E0
		private void HandleMatchExit(MatchKind kind); // 0x00000001807604F0-0x0000000180760530
		public void BindActors(int selfActor, int enemyActor); // 0x000000018075E4B0-0x000000018075E530
		public void NotifySelfDisplayActor(int actor); // 0x0000000180761080-0x00000001807610B0
		public void ApplyStatusOp(string action, int actorNumber, bool isSelf, string type, int turnsLeft, double value, string source); // 0x000000018075DB00-0x000000018075E3B0
		public void ClearAll(); // 0x000000018075FB90-0x0000000180760100
		public void ResetForNewMatch(); // 0x0000000180761D00-0x0000000180761D30
		public static bool IsActive(int actorNumber, string type); // 0x00000001807609C0-0x0000000180760B10
		private void NotifyModelChanged(int actor); // 0x0000000180760FA0-0x0000000180761080
		public static int CollectStatusTypes(int actorNumber, List<string> outTypes); // 0x0000000180760100-0x0000000180760330
		private void ModelUpsert(int actor, string key, int turnsLeft, double value, bool upsertOnlyIfExists = false /* Metadata: 0x0068E0BB */); // 0x0000000180760DE0-0x0000000180760FA0
		private void ModelRemove(int actor, string key); // 0x0000000180760D40-0x0000000180760DE0
		private BarView ResolveBar(int actor, bool isSelfHint); // 0x0000000180761DB0-0x0000000180761DF0
		private void RenderBar(BarView bar, int actor); // 0x0000000180761B10-0x0000000180761D00
		private void ShowOrRefreshIcon(BarView bar, string key, int turnsLeft, bool animate = true /* Metadata: 0x0068E0BC */); // 0x0000000180761F80-0x00000001807624F0
		private void UpdateIconTurns(BarView bar, string key, int turnsLeft); // 0x00000001807639D0-0x0000000180763B60
		private void HideIcon(BarView bar, string key); // 0x0000000180760850-0x00000001807609C0
		private void HideAllInBar(BarView bar); // 0x00000001807605E0-0x0000000180760850
		private void SetTurns(IconWidget w, string key, int turnsLeft); // 0x0000000180761E60-0x0000000180761F80
		private void RestartAnim(IconWidget w, IEnumerator routine); // 0x0000000180761DF0-0x0000000180761E60
		private void SpawnPopup(RectTransform anchor, string text, string type, bool big = false /* Metadata: 0x0068E0BD */); // 0x0000000180763210-0x00000001807635C0
		[IteratorStateMachine(typeof(_PopIn_d__83))]
		private IEnumerator PopIn(IconWidget w); // 0x0000000180761A30-0x0000000180761AA0
		[IteratorStateMachine(typeof(_Pulse_d__84))]
		private IEnumerator Pulse(IconWidget w); // 0x0000000180761AA0-0x0000000180761B10
		[IteratorStateMachine(typeof(_FadeOutAndRelease_d__85))]
		private IEnumerator FadeOutAndRelease(IconWidget w, BarView bar = null); // 0x0000000180760330-0x00000001807603E0
		[IteratorStateMachine(typeof(_FloatPopup_d__86))]
		private IEnumerator FloatPopup(PopupWidget p, bool big); // 0x00000001807603E0-0x0000000180760460
		public void PlayCastVfx(bool atSelf, string key = null, bool big = false /* Metadata: 0x0068E0BE */); // 0x0000000180761490-0x0000000180761960
		public void PlayCounterVfx(bool atSelf); // 0x0000000180761960-0x0000000180761980
		public void PlayBossEvolveVfx(); // 0x00000001807613C0-0x0000000180761490
		private void SpawnEvolveLabel(); // 0x00000001807626F0-0x00000001807627B0
		public void SpawnCritLabel(bool atSelf); // 0x00000001807625E0-0x00000001807626F0
		public void SpawnTimingLabel(bool atSelf, string verdict); // 0x00000001807635C0-0x0000000180763870
		public void SpawnGuildMateDamageLabel(string content); // 0x00000001807630B0-0x0000000180763210
		public void SpawnGuildBossStateLabel(string content, Color color); // 0x0000000180762FE0-0x00000001807630B0
		private void SpawnFloatingLabel(RectTransform anchor, string goName, string content, int fontSize, Color color, float riseY, float riseDur, float fadeDelay, float fadeDur); // 0x00000001807627B0-0x0000000180762FE0
		[IteratorStateMachine(typeof(_PlayFrames_d__110))]
		private IEnumerator PlayFrames(VfxWidget v, Sprite[] frames); // 0x0000000180761980-0x0000000180761A30
		private void BuildHierarchy(); // 0x000000018075E9D0-0x000000018075EEA0
		private RectTransform MakeAnchor(string name, Vector2 viewport); // 0x0000000180760B10-0x0000000180760D40
		private BarView BuildBar(RectTransform anchor, string name, bool isSelf); // 0x000000018075E530-0x000000018075E9D0
		private void SyncGridColumns(BarView bar); // 0x0000000180763870-0x00000001807639D0
		private IconWidget BuildIconWidget(RectTransform parent, int index); // 0x000000018075EEA0-0x000000018075F610
		private PopupWidget BuildPopupWidget(int index); // 0x000000018075F610-0x000000018075F930
		private VfxWidget BuildVfxWidget(int index); // 0x000000018075F930-0x000000018075FB90
		private Font GetFont(); // 0x0000000180760460-0x00000001807604F0
		private void AddOutline(GameObject go); // 0x000000018075DA70-0x000000018075DB00
	}
}
