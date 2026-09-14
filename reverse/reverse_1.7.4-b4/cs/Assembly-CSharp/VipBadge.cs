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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class VipBadge : MonoBehaviour // TypeDefIndex: 1462
{
	// Fields
	public const string NODE = "vipBadge"; // Metadata: 0x005F0F81
	private const string NODE_TEXT = "txt"; // Metadata: 0x005F0F8A
	private const string NODE_DOT = "dot"; // Metadata: 0x005F0F8E
	private const string NODE_SHINE_MASK = "shineMask"; // Metadata: 0x005F0F92
	private const string NODE_SHINE = "shine"; // Metadata: 0x005F0F9C
	private const string NODE_SPARKLE = "sparkle"; // Metadata: 0x005F0FA2
	private const float SPARKLE_PULSE = 0.6f; // Metadata: 0x005F0FAA
	private const float SHINE_SWEEP = 0.6f; // Metadata: 0x005F0FAE
	private const float SHINE_PERIOD = 3f; // Metadata: 0x005F0FB2
	private const float DOT_SIZE = 12f; // Metadata: 0x005F0FB6
	private const int ART_POLL_TIMES = 10; // Metadata: 0x005F0FBA
	private const int ALIGN_LEFT = 0; // Metadata: 0x005F0FBB
	private const int ALIGN_CENTER = 1; // Metadata: 0x005F0FBC
	private const int ALIGN_RIGHT = 2; // Metadata: 0x005F0FBD
	private const int VALIGN_TOP = 0; // Metadata: 0x005F0FBE
	private const int VALIGN_MIDDLE = 1; // Metadata: 0x005F0FBF
	private const int VALIGN_BOTTOM = 2; // Metadata: 0x005F0FC0
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
	public int Level { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F1540-0x00000001807F1550 0x00000001807F1550-0x00000001807F1560
	public float PushAmount { get; } // 0x00000001807F1560-0x00000001807F1570 
	public float PushOrigin { get; } // 0x00000001807F1570-0x00000001807F1580 
	public bool IsSelfBadge { get; } // 0x00000001807F1980-0x00000001807F1990 
	private RectTransform LabelRect { get; } // 0x00000001807F2CD0-0x00000001807F2E80 
	private Component LabelComp { get; } // 0x00000001807F2E80-0x00000001807F3010 
	private bool NeedsTierText { get; } // 0x00000001807F5D60-0x00000001807F5DC0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1463
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
		internal void _BuildShine_b__0(float t); // 0x00000001807FB570-0x00000001807FB7F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 1464
	{
		// Fields
		public Image sp; // 0x10

		// Constructors
		public __c__DisplayClass86_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildSparkle_b__0(float a); // 0x00000001807FB7F0-0x00000001807FB970
	}

	[CompilerGenerated]
	private sealed class _WatchArt_d__77 : IEnumerator<object> // TypeDefIndex: 1465
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807FB970-0x00000001807FBC90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807FBC90-0x00000001807FBCD0
	}

	// Constructors
	public VipBadge(); // 0x00000001807FB2D0-0x00000001807FB330

	// Methods
	public static VipBadge Find(UnityEngine.UI.Text label); // 0x00000001807F1580-0x00000001807F1670
	public static VipBadge Find(TMP_Text label); // 0x00000001807F1670-0x00000001807F1760
	private static VipBadge FindUnder(Transform label); // 0x00000001807F1760-0x00000001807F18F0
	private static bool ShouldShow(int level, Action onTap); // 0x00000001807F18F0-0x00000001807F1980
	public static VipBadge Attach(UnityEngine.UI.Text label, int level, Action onTap = null, float sizeMul = 1f /* Metadata: 0x005F0F76 */, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005F0F7A */); // 0x00000001807F1990-0x00000001807F1D90
	public static VipBadge Attach(TMP_Text label, int level, Action onTap = null, float sizeMul = 1f /* Metadata: 0x005F0F7B */, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005F0F7F */); // 0x00000001807F1D90-0x00000001807F2190
	public static void Detach(UnityEngine.UI.Text label); // 0x00000001807F2190-0x00000001807F2280
	public static void Detach(TMP_Text label); // 0x00000001807F2280-0x00000001807F2370
	public void SetLevel(int level); // 0x00000001807F2370-0x00000001807F2420
	public void SetDot(bool on); // 0x00000001807F2420-0x00000001807F2770
	public void Pulse(); // 0x00000001807F2770-0x00000001807F2AC0
	public void Reposition(); // 0x00000001807F2AC0-0x00000001807F2CD0
	private float ResolveFontSize(); // 0x00000001807F3010-0x00000001807F3220
	private int ResolveAlign(); // 0x00000001807F3220-0x00000001807F3430
	private int ResolveVAlign(); // 0x00000001807F3430-0x00000001807F3630
	private float TextWidth(); // 0x00000001807F3630-0x00000001807F39A0
	private static VipBadge Create(RectTransform labelRect); // 0x00000001807F39A0-0x00000001807F3FB0
	private void ApplyInternal(int level, Action onTap, float sizeMul, VipBadgeStyle style = VipBadgeStyle.Compact /* Metadata: 0x005F0F80 */); // 0x00000001807F3FB0-0x00000001807F4400
	private void RefreshSize(); // 0x00000001807F4400-0x00000001807F46F0
	private float CurrentAspect(); // 0x00000001807F46F0-0x00000001807F4900
	private void Layout(float w, float h); // 0x00000001807F4900-0x00000001807F4EF0
	private bool CanPush(); // 0x00000001807F4EF0-0x00000001807F5200
	private void EnsurePush(float amount); // 0x00000001807F5200-0x00000001807F53D0
	private void ReleasePush(); // 0x00000001807F53D0-0x00000001807F5530
	private void ApplySprite(); // 0x00000001807F5530-0x00000001807F5AE0
	private Sprite ResolveRealSprite(); // 0x00000001807F5AE0-0x00000001807F5CC0
	[IteratorStateMachine(typeof(_WatchArt_d__77))]
	private IEnumerator WatchArt(); // 0x00000001807F5CC0-0x00000001807F5D60
	private void ShowFallbackText(bool on); // 0x00000001807F5DC0-0x00000001807F6320
	private void LayoutText(bool compact); // 0x00000001807F6320-0x00000001807F6560
	private UnityEngine.UI.Text BuildText(); // 0x00000001807F6560-0x00000001807F6DD0
	private Font ResolveFont(); // 0x00000001807F6DD0-0x00000001807F70B0
	private void ApplyRoomFx(); // 0x00000001807F70B0-0x00000001807F7250
	private void BuildShine(float w, float h); // 0x00000001807F7250-0x00000001807F8590
	private void BuildSparkle(float w, float h, Color tier); // 0x00000001807F8590-0x00000001807F8F30
	private Image EnsureFxNode(string node, bool asFirstSibling); // 0x00000001807F8F30-0x00000001807F9570
	private void ClearRoomFx(); // 0x00000001807F9570-0x00000001807F96E0
	private static void HideFx(Image img); // 0x00000001807F96E0-0x00000001807F9950
	private Image BuildDot(); // 0x00000001807F9950-0x00000001807F9FC0
	private float DotSize(); // 0x00000001807F9FC0-0x00000001807FA030
	private void LayoutDot(); // 0x00000001807FA030-0x00000001807FA1D0
	private void ApplyTap(); // 0x00000001807FA1D0-0x00000001807FA620
	private void HideAndRestore(); // 0x00000001807FA620-0x00000001807FAAA0
	private void StartFollow(); // 0x00000001807FAAA0-0x00000001807FAC00
	private void StopFollow(); // 0x00000001807FAC00-0x00000001807FAD50
	private void Subscribe(bool on); // 0x00000001807FAD50-0x00000001807FB010
	private void OnVipStateChanged(); // 0x00000001807FB010-0x00000001807FB210
	private void OnEnable(); // 0x00000001807FB210-0x00000001807FB220
	private void OnDisable(); // 0x00000001807FB220-0x00000001807FB2A0
	private void OnDestroy(); // 0x00000001807FB2A0-0x00000001807FB2D0
	[CompilerGenerated]
	private void _Pulse_b__57_0(); // 0x00000001807FB330-0x00000001807FB550
	[CompilerGenerated]
	private void _ApplyTap_b__93_0(); // 0x00000001807FB550-0x00000001807FB570
}

