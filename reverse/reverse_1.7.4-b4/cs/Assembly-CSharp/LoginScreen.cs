/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class LoginScreen : MonoBehaviour // TypeDefIndex: 999
{
	// Fields
	public const string N_ROOT = "[LoginScreen]"; // Metadata: 0x005F05C3
	private const int SORT_BACKDROP = 0; // Metadata: 0x005F05D1
	private const int SORT_FORM = 10; // Metadata: 0x005F05D2
	private const int SORT_OVERLAY = 20; // Metadata: 0x005F05D3
	private static readonly Vector2 REF_RES; // 0x00
	private const float CARD_X = 940f; // Metadata: 0x005F05D4
	private const float CARD_Y = 64f; // Metadata: 0x005F05D8
	private const float CARD_W = 760f; // Metadata: 0x005F05DC
	private const float CARD_H = 780f; // Metadata: 0x005F05E0
	private const float BRAND_X = 0f; // Metadata: 0x005F05E4
	private const float VERSION_X = 24f; // Metadata: 0x005F05E8
	private const float CHIP_X = 646f; // Metadata: 0x005F05EC
	private const float SERVER_X = 1420f; // Metadata: 0x005F05F0
	private const float SUPPORT_X = 1686f; // Metadata: 0x005F05F4
	private const float LOGO_X = 30f; // Metadata: 0x005F05F8
	private const float LOGO_Y = 36f; // Metadata: 0x005F05FC
	private const float LOGO_W = 880f; // Metadata: 0x005F0600
	private const float LOGO_H = 292f; // Metadata: 0x005F0604
	private const float TAGLINE_X = 90f; // Metadata: 0x005F0608
	private const float TAGLINE_Y = 334f; // Metadata: 0x005F060C
	private const float TAGLINE_W = 760f; // Metadata: 0x005F0610
	private const float TAGLINE_H = 36f; // Metadata: 0x005F0614
	private const float HERO_X = 260f; // Metadata: 0x005F0618
	private const float HERO_Y = 374f; // Metadata: 0x005F061C
	private const float HERO_W = 420f; // Metadata: 0x005F0620
	private const float HERO_H = 440f; // Metadata: 0x005F0624
	private const float HEROFX_X = 210f; // Metadata: 0x005F0628
	private const float HEROFX_Y = 344f; // Metadata: 0x005F062C
	private const float HEROFX_W = 520f; // Metadata: 0x005F0630
	private const float HEROFX_H = 500f; // Metadata: 0x005F0634
	private static readonly float SCALE_16X9; // 0x08
	private const string TERMS_DECLINED = "B\u1EA1n c\u1EA7n \u0111\u1ED3ng \u00FD \u0110i\u1EC1u kho\u1EA3n s\u1EED d\u1EE5ng \u0111\u1EC3 v\u00E0o game."; // Metadata: 0x005F0638
	[CompilerGenerated]
	private static LoginScreen _Instance_k__BackingField; // 0x10
	private Canvas _backCanvas; // 0x20
	private Canvas _formCanvas; // 0x28
	private Canvas _overlayCanvas; // 0x30
	private GraphicRaycaster _formRay; // 0x38
	private GraphicRaycaster _overlayRay; // 0x40
	private CanvasGroup _formGroup; // 0x48
	private CanvasGroup _overlayGroup; // 0x50
	private RectTransform _backRect; // 0x58
	private RectTransform _formRect; // 0x60
	private RectTransform _overlayRect; // 0x68
	private LoginBackdrop _backdrop; // 0x70
	private RectTransform _infoRoot; // 0x78
	private RectTransform _content; // 0x80
	private Image _logo; // 0x88
	private UnityEngine.UI.Text _logoFallback; // 0x90
	private UnityEngine.UI.Text _logoFallbackSub; // 0x98
	private UnityEngine.UI.Text _tagline; // 0xA0
	private UnityEngine.UI.Text _announce; // 0xA8
	private RectTransform _announceRt; // 0xB0
	private RectTransform _hero; // 0xB8
	private RectTransform _heroFxBack; // 0xC0
	private RectTransform _heroFxFront; // 0xC8
	private LoginHeroFx _heroFx; // 0xD0
	private RectTransform _secBrand; // 0xD8
	private long _tHero; // 0xE0
	private long _tBrand; // 0xE8
	private long _tCard; // 0xF0
	private Animator _heroAnim; // 0xF8
	private Image _heroImg; // 0x100
	private PetImageFit _heroFit; // 0x108
	private LoginPetRig _heroRig; // 0x110
	private Coroutine _heroWatch; // 0x118
	private string _heroMode; // 0x120
	private RectTransform _card; // 0x128
	private Image _cardFrame; // 0x130
	private Image _tabLoginImg; // 0x138
	private Image _tabRegisterImg; // 0x140
	private UnityEngine.UI.Text _tabLoginTxt; // 0x148
	private UnityEngine.UI.Text _tabRegisterTxt; // 0x150
	private LoginForm _formLogin; // 0x158
	private RegisterForm _formRegister; // 0x160
	private bool _onRegisterTab; // 0x168
	private Button _btnSupport; // 0x170
	private UnityEngine.UI.Text _btnSupportLabel; // 0x178
	private UnityEngine.UI.Text _txtVersion; // 0x180
	private UnityEngine.UI.Text _txtServer; // 0x188
	private Image _dotServer; // 0x190
	private RectTransform _rowServer; // 0x198
	private Button _chipUpdate; // 0x1A0
	private Image _dim; // 0x1A8
	private Image _spinnerImg; // 0x1B0
	private Image _flash; // 0x1B8
	private RectTransform _spinnerRt; // 0x1C0
	private RectTransform _overlayGroupRt; // 0x1C8
	private UnityEngine.UI.Text _txtOverlay; // 0x1D0
	private Button _btnCancel; // 0x1D8
	private GameObject _btnCancelGo; // 0x1E0
	private bool _registerOn; // 0x1E8
	private bool _busy; // 0x1E9
	private long _builtConfigVersion; // 0x1F0
	private int _authGen; // 0x1F8
	private Coroutine _authRoutine; // 0x200
	private int _rateTweenId; // 0x208
	private string _legacyUser; // 0x210
	private string _legacyPass; // 0x218
	private bool _autoMode; // 0x220
	private const float TAB_W = 320f; // Metadata: 0x005F067D
	private const float TAB_H = 64f; // Metadata: 0x005F0681
	private const float TAB_DRAWN_W_FALLBACK = 208f; // Metadata: 0x005F0685
	private const float DOT_GAP = 12f; // Metadata: 0x005F0689
	private const float DOT_SIZE = 16f; // Metadata: 0x005F068D

	// Properties
	public static LoginScreen Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805F7780-0x00000001805F77E0 0x00000001805F77E0-0x00000001805F78A0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass119_0 // TypeDefIndex: 1000
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass119_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnLogoReady_b__0(float a); // 0x0000000180608920-0x0000000180608A70
		internal void _OnLogoReady_b__1(); // 0x0000000180608A70-0x0000000180608B90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass120_0 // TypeDefIndex: 1001
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass120_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartMarqueeIfOverflow_b__0(float dx); // 0x0000000180608B90-0x0000000180608CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass131_0 // TypeDefIndex: 1002
	{
		// Fields
		public Image captured; // 0x10

		// Constructors
		public __c__DisplayClass131_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildSpinnerFallback_b__0(float a); // 0x0000000180608CD0-0x0000000180608E50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass142_0 // TypeDefIndex: 1003
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public bool want; // 0x18
		public GameObject hide; // 0x20

		// Constructors
		public __c__DisplayClass142_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SwitchTab_b__0(); // 0x0000000180608E50-0x0000000180608FB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 1004
	{
		// Fields
		public Image captured; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Blink_b__0(float a); // 0x0000000180608FB0-0x0000000180609130
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass154_0 // TypeDefIndex: 1005
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public int gen; // 0x18
		public string username; // 0x20

		// Constructors
		public __c__DisplayClass154_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartTokenLogin_b__0(AuthResult r); // 0x0000000180609130-0x00000001806091B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1006
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public int gen; // 0x18
		public string user; // 0x20
		public string pass; // 0x28
		public bool remember; // 0x30

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartLogin_b__0(AuthResult r); // 0x00000001806091B0-0x0000000180609200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass158_0 // TypeDefIndex: 1007
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public int gen; // 0x18
		public string user; // 0x20
		public string pass; // 0x28

		// Constructors
		public __c__DisplayClass158_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRegisterSubmit_b__0(AuthResult r); // 0x0000000180609200-0x0000000180609240
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass160_0 // TypeDefIndex: 1008
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public LoginConfig.StringsCfg s; // 0x18
		public AuthResult r; // 0x20
		public string username; // 0x28

		// Constructors
		public __c__DisplayClass160_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnLoginOk_b__0(); // 0x0000000180609240-0x0000000180609500
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass165_0 // TypeDefIndex: 1009
	{
		// Fields
		public LoginScreen __4__this; // 0x10
		public string u; // 0x18
		public string p; // 0x20

		// Constructors
		public __c__DisplayClass165_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRegisterResult_b__0(); // 0x0000000180609500-0x00000001806095B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1010
	{
		// Fields
		public int last; // 0x10
		public LoginScreen __4__this; // 0x18
		public LoginConfig.StringsCfg s; // 0x20

		// Constructors
		public __c__DisplayClass167_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartRateCountdown_b__0(float v); // 0x00000001806095B0-0x00000001806097E0
		internal void _StartRateCountdown_b__1(); // 0x00000001806097E0-0x00000001806099A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass169_0 // TypeDefIndex: 1011
	{
		// Fields
		public Image img; // 0x10
		public Color from; // 0x18

		// Constructors
		public __c__DisplayClass169_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HighlightSupport_b__0(float k); // 0x00000001806099A0-0x0000000180609BE0
		internal void _HighlightSupport_b__1(); // 0x0000000180609BE0-0x0000000180609CF0
	}

	[CompilerGenerated]
	private sealed class _RunPipeline_d__161 : IEnumerator<object> // TypeDefIndex: 1012
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LoginScreen __4__this; // 0x20
		public AuthResult r; // 0x28
		public string username; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunPipeline_d__161(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180609CF0-0x0000000180609E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180609E80-0x0000000180609EC0
	}

	[CompilerGenerated]
	private sealed class _WatchHeroRig_d__117 : IEnumerator<object> // TypeDefIndex: 1013
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LoginScreen __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchHeroRig_d__117(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180609EC0-0x000000018060A0C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018060A0C0-0x000000018060A100
	}

	// Constructors
	public LoginScreen(); // 0x00000001806084B0-0x0000000180608580
	static LoginScreen(); // 0x0000000180608580-0x00000001806085F0

	// Methods
	private void Awake(); // 0x00000001805F78A0-0x00000001805F7A90
	private void Start(); // 0x00000001805F7A90-0x00000001805F7AA0
	private void OnDestroy(); // 0x00000001805F7AA0-0x00000001805F7EC0
	private void ReleaseHero(); // 0x00000001805F7EC0-0x00000001805F8260
	private void ReleaseHeroFx(); // 0x00000001805F8260-0x00000001805F83D0
	private void OnRemoteConfigApplied(); // 0x00000001805F83D0-0x00000001805F8460
	private void Rebuild(); // 0x00000001805F8460-0x00000001805F88C0
	private void Build(); // 0x00000001805F88C0-0x00000001805F8D10
	private void BuildBackdropCanvas(); // 0x00000001805F8D10-0x00000001805F9130
	private void BuildFormCanvas(); // 0x00000001805F9130-0x00000001805F9640
	private void BuildBrand(); // 0x00000001805F9640-0x00000001805FA610
	private void BuildHero(); // 0x00000001805FA610-0x00000001805FAA30
	private void BuildHeroRig(); // 0x00000001805FAA30-0x00000001805FAF40
	private void BuildHeroPet(long petId); // 0x00000001805FAF40-0x00000001805FB280
	private void BuildHeroFx(); // 0x00000001805FB280-0x00000001805FB530
	[IteratorStateMachine(typeof(_WatchHeroRig_d__117))]
	private IEnumerator WatchHeroRig(); // 0x00000001805FB530-0x00000001805FB5D0
	private void FallbackHeroToPet(); // 0x00000001805FB5D0-0x00000001805FBA60
	private void OnLogoReady(); // 0x00000001805FBA60-0x00000001805FC0F0
	private void StartMarqueeIfOverflow(); // 0x00000001805FC0F0-0x00000001805FC5B0
	private void BuildCard(); // 0x00000001805FC5B0-0x00000001805FD3A0
	private Image BuildTab(string name, float x, string label, out UnityEngine.UI.Text text, UnityAction onTap); // 0x00000001805FD3A0-0x00000001805FD6D0
	private static void LayoutTabLabel(Image img, UnityEngine.UI.Text label); // 0x00000001805FD6D0-0x00000001805FDB30
	private void LayoutTabLabels(); // 0x00000001805FDB30-0x00000001805FDBC0
	private void BuildFooter(); // 0x00000001805FDBC0-0x00000001805FE790
	private void BuildOverlayCanvas(); // 0x00000001805FE790-0x00000001805FF7F0
	private void OnSpinnerReady(); // 0x00000001805FF7F0-0x00000001805FFBE0
	private void BuildSpinnerFallback(RectTransform host); // 0x00000001805FFBE0-0x0000000180600150
	private Canvas MakeCanvas(string name, int sort, bool raycaster, bool group, out GraphicRaycaster ray, out CanvasGroup cg); // 0x0000000180600150-0x0000000180600670
	private void OnCanvasResized(); // 0x0000000180600670-0x00000001806006A0
	private float FrameScale(); // 0x00000001806006A0-0x0000000180600910
	private float MeasureWideExtra(); // 0x0000000180600910-0x0000000180600B50
	public void ApplyWideSpread(); // 0x0000000180600670-0x00000001806006A0
	public void ApplyWideSpread(float extra); // 0x0000000180600B50-0x00000001806010A0
	private static void SetX(RectTransform rt, float x); // 0x00000001806010A0-0x0000000180601200
	private void ApplyOverlayLayout(); // 0x0000000180601200-0x0000000180601530
	public void ShowLogin(); // 0x0000000180601530-0x0000000180601540
	public void ShowRegister(); // 0x0000000180601540-0x0000000180601560
	private void SwitchTab(bool register); // 0x0000000180601560-0x0000000180601C40
	private void ApplyTabVisual(bool register); // 0x0000000180601C40-0x0000000180601CB0
	private void SetTab(Image img, UnityEngine.UI.Text label, bool active); // 0x0000000180601CB0-0x0000000180601FE0
	private void RefreshServerRow(); // 0x0000000180601FE0-0x00000001806026B0
	private void LayoutServerDot(); // 0x00000001806026B0-0x0000000180602990
	private static void Blink(Image dot, float from, float to, float half); // 0x0000000180602990-0x0000000180602C90
	public void SetBusy(bool on, string text, bool cancellable); // 0x0000000180602C90-0x0000000180603010
	private void SetOverlayShown(bool on); // 0x0000000180603010-0x0000000180603650
	public void ShowError(string message); // 0x0000000180603650-0x00000001806038C0
	private void BeginAutoLogin(); // 0x00000001806038C0-0x0000000180603FB0
	private void StartTokenLogin(string username); // 0x0000000180603FB0-0x0000000180604420
	private void OnSwitchAccount(); // 0x0000000180604420-0x00000001806046C0
	private void OnLoginSubmit(string user, string pass, bool remember); // 0x00000001806046C0-0x0000000180604780
	private void StartLogin(string user, string pass, bool remember, bool auto, string overlayText); // 0x0000000180604780-0x0000000180604B30
	private void OnRegisterSubmit(string name, string user, string pass); // 0x0000000180604B30-0x0000000180604F50
	private void OnAuthResult(int gen, AuthResult r, string user, string pass, bool remember, bool viaToken); // 0x0000000180604F50-0x00000001806050C0
	private void OnLoginOk(AuthResult r, string username, bool remember, bool viaToken); // 0x00000001806050C0-0x00000001806056F0
	[IteratorStateMachine(typeof(_RunPipeline_d__161))]
	private IEnumerator RunPipeline(AuthResult r, string username); // 0x00000001806056F0-0x0000000180605850
	private void OnTermsDecided(bool accepted); // 0x0000000180605850-0x0000000180605C10
	private void HandleAuthError(AuthResult r, bool duringAuto, string user, string pass); // 0x0000000180605C10-0x00000001806066A0
	private void RetryLastOrSubmit(); // 0x00000001806066A0-0x0000000180606920
	private void OnRegisterResult(int gen, AuthResult r, string user, string pass); // 0x0000000180606920-0x0000000180607310
	private void FillPassword(string pass); // 0x0000000180607310-0x0000000180607530
	private void StartRateCountdown(int seconds); // 0x0000000180607530-0x0000000180607930
	private void SetPrimary(string label, UnityAction action); // 0x0000000180607930-0x0000000180607B50
	private void HighlightSupport(); // 0x0000000180607B50-0x0000000180607F40
	private void OnSupport(); // 0x0000000180607F40-0x0000000180607F70
	private void OnForgot(); // 0x0000000180607F70-0x0000000180608040
	private bool OpenPortalGuest(WebPortalPurpose purpose); // 0x0000000180608040-0x00000001806081E0
	private bool OpenSupport(); // 0x00000001806081E0-0x0000000180608300
	private void OpenUpdate(); // 0x0000000180608300-0x00000001806083A0
	private static string Safe(string format, params object[] args); // 0x00000001806083A0-0x00000001806084B0
	[CompilerGenerated]
	private void _RefreshServerRow_b__145_0(); // 0x00000001806085F0-0x0000000180608620
	[CompilerGenerated]
	private void _HandleAuthError_b__163_0(); // 0x0000000180608620-0x0000000180608720
	[CompilerGenerated]
	private void _HandleAuthError_b__163_1(); // 0x0000000180608720-0x0000000180608820
	[CompilerGenerated]
	private void _HandleAuthError_b__163_2(); // 0x0000000180608820-0x0000000180608920
}

