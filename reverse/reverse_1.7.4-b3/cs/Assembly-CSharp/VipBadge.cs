/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VipBadge : MonoBehaviour // TypeDefIndex: 1460
{
	// Fields
	public const string NODE = "vipBadge"; // Metadata: 0x005EFBB4
	private const string NODE_TEXT = "txt"; // Metadata: 0x005EFBBD
	private const string NODE_DOT = "dot"; // Metadata: 0x005EFBC1
	private const string NODE_SHINE_MASK = "shineMask"; // Metadata: 0x005EFBC5
	private const string NODE_SHINE = "shine"; // Metadata: 0x005EFBCF
	private const string NODE_SPARKLE = "sparkle"; // Metadata: 0x005EFBD5
	private const float SPARKLE_PULSE = 0.6f; // Metadata: 0x005EFBDD
	private const float SHINE_SWEEP = 0.6f; // Metadata: 0x005EFBE1
	private const float SHINE_PERIOD = 3f; // Metadata: 0x005EFBE5
	private const float DOT_SIZE = 12f; // Metadata: 0x005EFBE9
	private const int ART_POLL_TIMES = 10; // Metadata: 0x005EFBED
	private const int ALIGN_LEFT = 0; // Metadata: 0x005EFBEE
	private const int ALIGN_CENTER = 1; // Metadata: 0x005EFBEF
	private const int ALIGN_RIGHT = 2; // Metadata: 0x005EFBF0
	private const int VALIGN_TOP = 0; // Metadata: 0x005EFBF1
	private const int VALIGN_MIDDLE = 1; // Metadata: 0x005EFBF2
	private const int VALIGN_BOTTOM = 2; // Metadata: 0x005EFBF3
	private UnityEngine.UI.Text _label; // 0x20
	private TMP_Text _tmp; // 0x28
	private RectTransform _rt; // 0x30
	private Image _img; // 0x38
	private UnityEngine.UI.Text _txt; // 0x40
	private Image _dot; // 0x48
	private Button _btn; // 0x50
	private VipBadgeStyle _style; // 0x58
	private RectTransform _shineMask; // 0x60
	private Image _shine; // 0x68
	private Image _sparkle; // 0x70
	private Action _onTap; // 0x78
	private float _sizeMul; // 0x80
	private Sprite _fallback; // 0x88
	private string _artPath; // 0x90
	private Coroutine _artWatch; // 0x98
	private bool _listening; // 0xA0
	private float _frameToLocal; // 0xA4
	private float _pushAmount; // 0xA8
	private float _pushOrigin; // 0xAC
	[CompilerGenerated]
	private int _Level_k__BackingField; // 0xB0

	// Properties
	public int Level { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807EF450-0x00000001807EF460 0x00000001807EF460-0x00000001807EF470
	public float PushAmount { get; } // 0x00000001807EF470-0x00000001807EF480 
	public float PushOrigin { get; } // 0x00000001807EF480-0x00000001807EF490 
	public bool IsSelfBadge { get; } // 0x00000001807EF890-0x00000001807EF8A0 
	private RectTransform LabelRect { get; } // 0x00000001807F0BE0-0x00000001807F0D90 
	private Component LabelComp { get; } // 0x00000001807F0D90-0x00000001807F0F20 
	private bool NeedsTierText { get; } // 0x00000001807F3C70-0x00000001807F3CD0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1461
	{
		// Fields
		public Image shine; // 0x10
		public float sweepPart; // 0x18
		public RectTransform srt; // 0x20
		public float from; // 0x28
		public float to; // 0x2C

		// Constructors
		public __c__DisplayClass85_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildShine_b__0(float t); // 0x00000001807F9480-0x00000001807F9700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 1462
	{
		// Fields
		public Image sp; // 0x10

		// Constructors
		public __c__DisplayClass86_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildSparkle_b__0(float a); // 0x00000001807F9700-0x00000001807F9880
	}

	[CompilerGenerated]
	private sealed class _WatchArt_d__77 : IEnumerator<object> // TypeDefIndex: 1463
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public VipBadge __4__this; // 0x20
		private int _i_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchArt_d__77(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001807F9880-0x00000001807F9BA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807F9BA0-0x00000001807F9BE0
	}

	// Constructors
	public VipBadge(); // 0x00000001807F91E0-0x00000001807F9240

	// Methods
	public static VipBadge Find(UnityEngine.UI.Text label); // 0x00000001807EF490-0x00000001807EF580
	public static VipBadge Find(TMP_Text label); // 0x00000001807EF580-0x00000001807EF670
	private static VipBadge FindUnder(Transform label); // 0x00000001807EF670-0x00000001807EF800
	private static bool ShouldShow(int level, Action onTap); // 0x00000001807EF800-0x00000001807EF890
	public static VipBadge Attach(UnityEngine.UI.Text label, int level, Action onTap = null, float sizeMul = 1f /* Metadata: 0x005EFBA9 */, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005EFBAD */); // 0x00000001807EF8A0-0x00000001807EFCA0
	public static VipBadge Attach(TMP_Text label, int level, Action onTap = null, float sizeMul = 1f /* Metadata: 0x005EFBAE */, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005EFBB2 */); // 0x00000001807EFCA0-0x00000001807F00A0
	public static void Detach(UnityEngine.UI.Text label); // 0x00000001807F00A0-0x00000001807F0190
	public static void Detach(TMP_Text label); // 0x00000001807F0190-0x00000001807F0280
	public void SetLevel(int level); // 0x00000001807F0280-0x00000001807F0330
	public void SetDot(bool on); // 0x00000001807F0330-0x00000001807F0680
	public void Pulse(); // 0x00000001807F0680-0x00000001807F09D0
	public void Reposition(); // 0x00000001807F09D0-0x00000001807F0BE0
	private float ResolveFontSize(); // 0x00000001807F0F20-0x00000001807F1130
	private int ResolveAlign(); // 0x00000001807F1130-0x00000001807F1340
	private int ResolveVAlign(); // 0x00000001807F1340-0x00000001807F1540
	private float TextWidth(); // 0x00000001807F1540-0x00000001807F18B0
	private static VipBadge Create(RectTransform labelRect); // 0x00000001807F18B0-0x00000001807F1EC0
	private void ApplyInternal(int level, Action onTap, float sizeMul, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005EFBB3 */); // 0x00000001807F1EC0-0x00000001807F2310
	private void RefreshSize(); // 0x00000001807F2310-0x00000001807F2600
	private float CurrentAspect(); // 0x00000001807F2600-0x00000001807F2810
	private void Layout(float w, float h); // 0x00000001807F2810-0x00000001807F2E00
	private bool CanPush(); // 0x00000001807F2E00-0x00000001807F3110
	private void EnsurePush(float amount); // 0x00000001807F3110-0x00000001807F32E0
	private void ReleasePush(); // 0x00000001807F32E0-0x00000001807F3440
	private void ApplySprite(); // 0x00000001807F3440-0x00000001807F39F0
	private Sprite ResolveRealSprite(); // 0x00000001807F39F0-0x00000001807F3BD0
	[IteratorStateMachine(typeof(_WatchArt_d__77))]
	private IEnumerator WatchArt(); // 0x00000001807F3BD0-0x00000001807F3C70
	private void ShowFallbackText(bool on); // 0x00000001807F3CD0-0x00000001807F4230
	private void LayoutText(bool compact); // 0x00000001807F4230-0x00000001807F4470
	private UnityEngine.UI.Text BuildText(); // 0x00000001807F4470-0x00000001807F4CE0
	private Font ResolveFont(); // 0x00000001807F4CE0-0x00000001807F4FC0
	private void ApplyRoomFx(); // 0x00000001807F4FC0-0x00000001807F5160
	private void BuildShine(float w, float h); // 0x00000001807F5160-0x00000001807F64A0
	private void BuildSparkle(float w, float h, Color tier); // 0x00000001807F64A0-0x00000001807F6E40
	private Image EnsureFxNode(string node, bool asFirstSibling); // 0x00000001807F6E40-0x00000001807F7480
	private void ClearRoomFx(); // 0x00000001807F7480-0x00000001807F75F0
	private static void HideFx(Image img); // 0x00000001807F75F0-0x00000001807F7860
	private Image BuildDot(); // 0x00000001807F7860-0x00000001807F7ED0
	private float DotSize(); // 0x00000001807F7ED0-0x00000001807F7F40
	private void LayoutDot(); // 0x00000001807F7F40-0x00000001807F80E0
	private void ApplyTap(); // 0x00000001807F80E0-0x00000001807F8530
	private void HideAndRestore(); // 0x00000001807F8530-0x00000001807F89B0
	private void StartFollow(); // 0x00000001807F89B0-0x00000001807F8B10
	private void StopFollow(); // 0x00000001807F8B10-0x00000001807F8C60
	private void Subscribe(bool on); // 0x00000001807F8C60-0x00000001807F8F20
	private void OnVipStateChanged(); // 0x00000001807F8F20-0x00000001807F9120
	private void OnEnable(); // 0x00000001807F9120-0x00000001807F9130
	private void OnDisable(); // 0x00000001807F9130-0x00000001807F91B0
	private void OnDestroy(); // 0x00000001807F91B0-0x00000001807F91E0
	[CompilerGenerated]
	private void _Pulse_b__57_0(); // 0x00000001807F9240-0x00000001807F9460
	[CompilerGenerated]
	private void _ApplyTap_b__93_0(); // 0x00000001807F9460-0x00000001807F9480
}

