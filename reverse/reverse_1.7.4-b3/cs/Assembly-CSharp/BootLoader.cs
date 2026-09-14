/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class BootLoader : MonoBehaviour // TypeDefIndex: 1901
{
	// Fields
	[Header("UI c\u01A1 b\u1EA3n (\u0111\u00E3 c\u00F3 s\u1EB5n trong BootScene)")]
	public Slider progressBar; // 0x20
	[Tooltip("Text t\u1ED5ng h\u1EE3p: \'32.5 MB / 48.7 MB  \u2022  67%  \u2022  C\u00F2n ~15s\' ho\u1EB7c text l\u1ED7i")]
	public UnityEngine.UI.Text progressText; // 0x28
	[Header("T\u01B0\u1EDDng ch\u1EB7n \u2014 T\u00D9Y CH\u1ECCN, thi\u1EBFu th\u00EC d\u1ED3n th\u00F4ng \u0111i\u1EC7p v\u1EC1 progressText")]
	[Tooltip("Panel hi\u1EC7n khi bu\u1ED9c c\u1EADp nh\u1EADt / b\u1EA3o tr\u00EC / h\u1ECFi x\u00E1c nh\u1EADn t\u1EA3i")]
	public GameObject blockPanel; // 0x30
	public UnityEngine.UI.Text blockTitleText; // 0x38
	public UnityEngine.UI.Text blockMessageText; // 0x40
	[Tooltip("N\u00FAt h\u00E0nh \u0111\u1ED9ng ch\u00EDnh: C\u1EADp nh\u1EADt ngay / T\u1EA3i xu\u1ED1ng / Th\u1EED l\u1EA1i")]
	public Button blockPrimaryButton; // 0x48
	public UnityEngine.UI.Text blockPrimaryLabel; // 0x50
	[Tooltip("N\u00FAt ph\u1EE5: \u0110\u1EC3 sau / H\u1EE7y. \u1EA8n \u1EDF tr\u1EA1ng th\u00E1i ch\u1EB7n c\u1EE9ng.")]
	public Button blockSecondaryButton; // 0x58
	public UnityEngine.UI.Text blockSecondaryLabel; // 0x60
	[Header("Hi\u1EC7u \u1EE9ng \u2014 T\u00D9Y CH\u1ECCN")]
	[Tooltip("Logo nh\u1EA5p nh\u00F4 nh\u1EB9 trong l\u00FAc ch\u1EDD")]
	public Transform logoTransform; // 0x68
	[Tooltip("D\u00F9ng \u0111\u1EC3 fade khi chuy\u1EC3n sang Login (che kho\u1EA3ng lag c\u1EE7a LoadScene)")]
	public CanvasGroup fadeCanvasGroup; // 0x70
	[Tooltip("D\u00F2ng m\u1EB9o xoay v\u00F2ng cho \u0111\u1EE1 s\u1ED1t ru\u1ED9t")]
	public UnityEngine.UI.Text tipText; // 0x78
	[Header("N\u1ED9i dung c\u1EA7n t\u1EA3i")]
	[Tooltip("Label/\u0111\u1ECBa ch\u1EC9 Addressables B\u1EAET BU\u1ED8C ph\u1EA3i t\u1EA3i xong tr\u01B0\u1EDBc khi cho v\u00E0o game.\n\n\u0110\u1EC2 TR\u1ED0NG l\u00E0 l\u1EF1a ch\u1ECDn \u0111\u00FAng cho h\u1EA7u h\u1EBFt tr\u01B0\u1EDDng h\u1EE3p: ng\u01B0\u1EDDi ch\u01A1i v\u00E0o game ngay, n\u1ED9i dung t\u1EA3i n\u1EC1n, v\u00E0 th\u1EE9 n\u00E0o c\u1EA7n cho m\u1ED9t tr\u1EADn c\u1EE5 th\u1EC3 th\u00EC \u0111\u00E3 c\u00F3 ch\u1ED1t ch\u1EB7n ri\u00EAng \u1EDF ph\u00F2ng ch\u1EDD (MatchAssetGate).\n\nCH\u1EC8 th\u00EAm key v\u00E0o \u0111\u00E2y n\u1EBFu thi\u1EBFu n\u00F3 th\u00EC m\u00E0n h\u00ECnh \u0111\u1EA7u ti\u00EAn \u0111\u00E3 h\u1ECFng. M\u1ED7i key th\u00EAm v\u00E0o l\u00E0 b\u1EAFt M\u1ECCI ng\u01B0\u1EDDi ch\u01A1i ng\u1ED3i ch\u1EDD tr\u01B0\u1EDBc khi \u0111\u01B0\u1EE3c v\u00E0o game.")]
	public string[] addressableKeys; // 0x80
	[Header("T\u1EA3i xu\u1ED1ng")]
	[Tooltip("S\u1ED1 l\u1EA7n th\u1EED l\u1EA1i t\u1ED1i \u0111a khi t\u1EA3i h\u1ECFng")]
	public int maxRetry; // 0x88
	[Tooltip("Ch\u1EDD bao l\u00E2u tr\u01B0\u1EDBc l\u1EA7n th\u1EED l\u1EA1i \u0111\u1EA7u ti\u00EAn (gi\u00E2y). C\u00E1c l\u1EA7n sau nh\u00E2n \u0111\u00F4i.")]
	public float retryDelaySeconds; // 0x8C
	[Tooltip("N\u1EBFu s\u1ED1 byte kh\u00F4ng t\u0103ng trong (gi\u00E2y) \u2192 coi l\u00E0 ngh\u1EBDn, hi\u1EC7n c\u1EA3nh b\u00E1o")]
	public float stallThresholdSeconds; // 0x90
	[Tooltip("G\u00F3i l\u1EDBn h\u01A1n ng\u01B0\u1EE1ng n\u00E0y (MB) m\u00E0 \u0111ang d\u00F9ng d\u1EEF li\u1EC7u di \u0111\u1ED9ng th\u00EC h\u1ECFi tr\u01B0\u1EDBc khi t\u1EA3i. 0 = kh\u00F4ng h\u1ECFi.")]
	public float confirmOverCellularMB; // 0x94
	[Header("Tr\u1EA3i nghi\u1EC7m")]
	[Tooltip("Gi\u1EEF m\u00E0n h\u00ECnh kh\u1EDFi \u0111\u1ED9ng \u00EDt nh\u1EA5t b\u1EA5y nhi\u00EAu gi\u00E2y \u2014 ch\u1ED1ng \'nh\u00E1y qua\' khi kh\u00F4ng c\u1EA7n t\u1EA3i")]
	public float minDisplaySeconds; // 0x98
	[Tooltip("Th\u1EDDi gian fade khi chuy\u1EC3n sang Login")]
	public float fadeOutSeconds; // 0x9C
	[Tooltip("B\u1ECF qua c\u1ED5ng phi\u00EAn b\u1EA3n (ch\u1EC9 d\u00F9ng khi ph\u00E1t tri\u1EC3n offline)")]
	public bool skipVersionGateInEditor; // 0xA0
	[Header("\u0110i\u1EC1u h\u01B0\u1EDBng")]
	public string nextSceneName; // 0xA8
	private const float SPEED_EMA_ALPHA = 0.2f; // Metadata: 0x005F02C1
	private const float TEXT_REFRESH_INTERVAL = 0.25f; // Metadata: 0x005F02C5
	private const float PROGRESS_LERP_SPEED = 3.5f; // Metadata: 0x005F02C9
	private const float TIP_INTERVAL = 4f; // Metadata: 0x005F02CD
	private const float AUTO_RETRY_SECONDS = 5f; // Metadata: 0x005F02D1
	private const float MAINTENANCE_POLL_SECONDS = 15f; // Metadata: 0x005F02D5
	private static readonly string[] TIPS; // 0x00
	private readonly StringBuilder _sb; // 0xB0
	private float _bootStartTime; // 0xB8
	private float _displayedProgress; // 0xBC
	private float _targetProgress; // 0xC0
	private bool _downloadCancelled; // 0xC4
	private int _logoTweenId; // 0xC8
	private Coroutine _tipRoutine; // 0xD0

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1902
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__39_0; // 0x08

		// Constructors
		static __c(); // 0x000000018092B810-0x000000018092B8B0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowSoftUpdatePrompt_b__39_0(); // 0x000000018092B8B0-0x000000018092B900
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 1903
	{
		// Fields
		public bool ready; // 0x10
		public Action<bool> __9__0; // 0x18
		public Action<bool> __9__1; // 0x20

		// Constructors
		public __c__DisplayClass37_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Start_b__0(bool ok); // 0x0000000180290F20-0x0000000180290F30
		internal void _Start_b__1(bool ok); // 0x0000000180290F20-0x0000000180290F30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 1904
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowSoftUpdatePrompt_b__1(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1905
	{
		// Fields
		public bool manualRecheck; // 0x10

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunBlockWall_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 1906
	{
		// Fields
		public List<object> validKeys; // 0x10
		public bool verified; // 0x18

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunDownloadFlow_b__0(List<object> list); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _RunDownloadFlow_b__1(bool ok); // 0x00000001808D7CA0-0x00000001808D7CB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_1 // TypeDefIndex: 1907
	{
		// Fields
		public bool accepted; // 0x10

		// Constructors
		public __c__DisplayClass42_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunDownloadFlow_b__2(bool ok); // 0x0000000180290F20-0x0000000180290F30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 1908
	{
		// Fields
		public bool? choice; // 0x10

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ConfirmLargeDownload_b__0(); // 0x000000018092B900-0x000000018092B920
		internal void _ConfirmLargeDownload_b__1(); // 0x000000018092B920-0x000000018092B940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1909
	{
		// Fields
		public bool retry; // 0x10

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowRetryWall_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass51_0 // TypeDefIndex: 1910
	{
		// Fields
		public Action onPrimary; // 0x10
		public Action onSecondary; // 0x18

		// Constructors
		public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowBlockPanel_b__0(); // 0x000000018092B940-0x000000018092B970
		internal void _ShowBlockPanel_b__1(); // 0x000000018092B970-0x000000018092B9A0
	}

	[CompilerGenerated]
	private sealed class _ConfirmLargeDownload_d__48 : IEnumerator<object> // TypeDefIndex: 1911
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long totalBytes; // 0x20
		public BootLoader __4__this; // 0x28
		public Action<bool> done; // 0x30
		private __c__DisplayClass48_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConfirmLargeDownload_d__48(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x000000018092B9A0-0x000000018092BF30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092BF30-0x000000018092BF70
	}

	[CompilerGenerated]
	private sealed class _CountdownText_d__50 : IEnumerator<object> // TypeDefIndex: 1912
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20
		public BootLoader __4__this; // 0x28
		public string formatWithPlaceholder; // 0x30
		private float _left_5__2; // 0x38
		private int _lastShown_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CountdownText_d__50(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018092BF70-0x000000018092C160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092C160-0x000000018092C1A0
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__57 : IEnumerator<object> // TypeDefIndex: 1913
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__57(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018092C1A0-0x000000018092C470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092C470-0x000000018092C4B0
	}

	[CompilerGenerated]
	private sealed class _ResolveValidKeys_d__43 : IEnumerator<object> // TypeDefIndex: 1914
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		public Action<List<object>> done; // 0x28
		private List<object> _result_5__2; // 0x30
		private string[] __7__wrap2; // 0x38
		private int __7__wrap3; // 0x40
		private string _key_5__5; // 0x48
		private AsyncOperationHandle<IList<IResourceLocation>> _h_5__6; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResolveValidKeys_d__43(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018092C4B0-0x000000018092C5C0
		private bool MoveNext(); // 0x000000018092C5C0-0x000000018092CD10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092CD10-0x000000018092CD50
	}

	[CompilerGenerated]
	private sealed class _RotateTips_d__54 : IEnumerator<object> // TypeDefIndex: 1915
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private int _i_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RotateTips_d__54(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018092CD50-0x000000018092CFA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092CFA0-0x000000018092CFE0
	}

	[CompilerGenerated]
	private sealed class _RunAppGate_d__38 : IEnumerator<object> // TypeDefIndex: 1916
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunAppGate_d__38(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018092CFE0-0x000000018092D4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092D4D0-0x000000018092D510
	}

	[CompilerGenerated]
	private sealed class _RunBlockWall_d__40 : IEnumerator<object> // TypeDefIndex: 1917
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private __c__DisplayClass40_0 __8__1; // 0x28
		private bool _maintenance_5__2; // 0x30
		private string _title_5__3; // 0x38
		private string _msg_5__4; // 0x40
		private float _nextPoll_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunBlockWall_d__40(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018092D510-0x000000018092D620
		private bool MoveNext(); // 0x000000018092D620-0x000000018092E0E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092E0E0-0x000000018092E120
	}

	[CompilerGenerated]
	private sealed class _RunDownloadFlow_d__42 : IEnumerator<object> // TypeDefIndex: 1918
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		public int attempt; // 0x28
		public Action<bool> done; // 0x30
		private __c__DisplayClass42_0 __8__1; // 0x38
		private __c__DisplayClass42_1 __8__2; // 0x40
		private AsyncOperationHandle<long> _sizeHandle_5__2; // 0x48
		private long _totalBytes_5__3; // 0x60
		private AsyncOperationHandle _downloadHandle_5__4; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunDownloadFlow_d__42(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018092E120-0x000000018092E1F0
		private bool MoveNext(); // 0x000000018092E1F0-0x000000018092F360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092F360-0x000000018092F3A0
	}

	[CompilerGenerated]
	private sealed class _ShowRetryWall_d__49 : IEnumerator<object> // TypeDefIndex: 1919
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		public string message; // 0x28
		private __c__DisplayClass49_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowRetryWall_d__49(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018092F3A0-0x000000018092F850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092F850-0x000000018092F890
	}

	[CompilerGenerated]
	private sealed class _ShowSoftUpdatePrompt_d__39 : IEnumerator<object> // TypeDefIndex: 1920
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private __c__DisplayClass39_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowSoftUpdatePrompt_d__39(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018092F890-0x000000018092FE70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018092FE70-0x000000018092FEB0
	}

	[CompilerGenerated]
	private sealed class _Start_d__37 : IEnumerator<object> // TypeDefIndex: 1921
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private __c__DisplayClass37_0 __8__1; // 0x28
		private float _delay_5__2; // 0x30
		private int _attempt_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__37(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018092FEB0-0x0000000180930AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180930AF0-0x0000000180930B30
	}

	[CompilerGenerated]
	private sealed class _TrackDownload_d__45 : IEnumerator<object> // TypeDefIndex: 1922
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public AsyncOperationHandle handle; // 0x20
		public long fallbackTotal; // 0x38
		public BootLoader __4__this; // 0x40
		private float _elapsed_5__2; // 0x48
		private long _lastBytes_5__3; // 0x50
		private float _speedEma_5__4; // 0x58
		private float _lastSampleTime_5__5; // 0x5C
		private float _lastTextTime_5__6; // 0x60
		private long _lastObservedBytes_5__7; // 0x68
		private float _lastByteChangeTime_5__8; // 0x70
		private bool _stalled_5__9; // 0x74

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TrackDownload_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180930B30-0x0000000180931000
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180931000-0x0000000180931040
	}

	[CompilerGenerated]
	private sealed class _UpdateCatalogIfNeeded_d__41 : IEnumerator<object> // TypeDefIndex: 1923
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private AsyncOperationHandle<List<string>> _checkHandle_5__2; // 0x28
		private AsyncOperationHandle<List<IResourceLocator>> _updateHandle_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateCatalogIfNeeded_d__41(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180931040-0x0000000180931060
		private bool MoveNext(); // 0x0000000180931060-0x00000001809318E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809318E0-0x0000000180931920
	}

	[CompilerGenerated]
	private sealed class _VerifyNothingLeft_d__44 : IEnumerator<object> // TypeDefIndex: 1924
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<object> keys; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<long> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _VerifyNothingLeft_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808D7CC0-0x00000001808D7CE0
		private bool MoveNext(); // 0x0000000180931920-0x0000000180931DD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180931DD0-0x0000000180931E10
	}

	[CompilerGenerated]
	private sealed class _WaitForMinDisplayTime_d__56 : IEnumerator<object> // TypeDefIndex: 1925
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BootLoader __4__this; // 0x20
		private float _guard_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForMinDisplayTime_d__56(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180931E10-0x0000000180932060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180932060-0x00000001809320A0
	}

	// Constructors
	public BootLoader(); // 0x000000018092B410-0x000000018092B680
	static BootLoader(); // 0x000000018092B680-0x000000018092B810

	// Methods
	private void Awake(); // 0x0000000180928400-0x00000001809287B0
	private void Update(); // 0x00000001809287B0-0x0000000180928970
	[IteratorStateMachine(typeof(_Start_d__37))]
	private IEnumerator Start(); // 0x0000000180928970-0x0000000180928A10
	[IteratorStateMachine(typeof(_RunAppGate_d__38))]
	private IEnumerator RunAppGate(); // 0x0000000180928A10-0x0000000180928AB0
	[IteratorStateMachine(typeof(_ShowSoftUpdatePrompt_d__39))]
	private IEnumerator ShowSoftUpdatePrompt(); // 0x0000000180928AB0-0x0000000180928B50
	[IteratorStateMachine(typeof(_RunBlockWall_d__40))]
	private IEnumerator RunBlockWall(); // 0x0000000180928B50-0x0000000180928BF0
	[IteratorStateMachine(typeof(_UpdateCatalogIfNeeded_d__41))]
	private IEnumerator UpdateCatalogIfNeeded(); // 0x0000000180928BF0-0x0000000180928C90
	[IteratorStateMachine(typeof(_RunDownloadFlow_d__42))]
	private IEnumerator RunDownloadFlow(int attempt, Action<bool> done); // 0x0000000180928C90-0x0000000180928DA0
	[IteratorStateMachine(typeof(_ResolveValidKeys_d__43))]
	private IEnumerator ResolveValidKeys(Action<List<object>> done); // 0x0000000180928DA0-0x0000000180928EB0
	[IteratorStateMachine(typeof(_VerifyNothingLeft_d__44))]
	private IEnumerator VerifyNothingLeft(List<object> keys, Action<bool> done); // 0x0000000180928EB0-0x0000000180928FC0
	[IteratorStateMachine(typeof(_TrackDownload_d__45))]
	private IEnumerator TrackDownload(AsyncOperationHandle handle, long fallbackTotal); // 0x0000000180928FC0-0x00000001809290E0
	private string BuildProgressLine(long done, long total, float percent01, float speed, bool stalled); // 0x00000001809290E0-0x00000001809293D0
	private bool NeedsCellularConfirm(long totalBytes); // 0x00000001809293D0-0x00000001809294B0
	[IteratorStateMachine(typeof(_ConfirmLargeDownload_d__48))]
	private IEnumerator ConfirmLargeDownload(long totalBytes, Action<bool> done); // 0x00000001809294B0-0x00000001809295C0
	[IteratorStateMachine(typeof(_ShowRetryWall_d__49))]
	private IEnumerator ShowRetryWall(string message); // 0x00000001809295C0-0x00000001809296D0
	[IteratorStateMachine(typeof(_CountdownText_d__50))]
	private IEnumerator CountdownText(string formatWithPlaceholder, float seconds); // 0x00000001809296D0-0x00000001809297F0
	private void ShowBlockPanel(string title, string message, string primaryLabel, Action onPrimary, string secondaryLabel, Action onSecondary); // 0x00000001809297F0-0x000000018092A040
	private void HideBlockPanel(); // 0x000000018092A040-0x000000018092A180
	private void StartLogoPulse(); // 0x000000018092A180-0x000000018092A3E0
	[IteratorStateMachine(typeof(_RotateTips_d__54))]
	private IEnumerator RotateTips(); // 0x000000018092A3E0-0x000000018092A480
	private void StopProgressUi(); // 0x000000018092A480-0x000000018092A670
	[IteratorStateMachine(typeof(_WaitForMinDisplayTime_d__56))]
	private IEnumerator WaitForMinDisplayTime(); // 0x000000018092A670-0x000000018092A710
	[IteratorStateMachine(typeof(_FadeOut_d__57))]
	private IEnumerator FadeOut(); // 0x000000018092A710-0x000000018092A7B0
	private void ShowError(string msg); // 0x000000018092A7B0-0x000000018092A920
	private void SetProgressText(string msg); // 0x000000018092A920-0x000000018092AA30
	private static string FirstNonEmpty(string a, string b); // 0x0000000180343570-0x0000000180343590
	private static string Truncate(string s, int max); // 0x000000018092AA30-0x000000018092AAE0
	private static void AppendBytes(StringBuilder sb, long bytes); // 0x000000018092AAE0-0x000000018092ADA0
	private static string FormatBytes(long bytes); // 0x000000018092ADA0-0x000000018092B030
	private static string FormatTime(int seconds); // 0x000000018092B030-0x000000018092B410
}

