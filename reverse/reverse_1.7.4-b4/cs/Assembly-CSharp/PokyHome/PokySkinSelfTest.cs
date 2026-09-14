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
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public class PokySkinSelfTest : MonoBehaviour // TypeDefIndex: 2710
	{
		// Fields
		public const string PREF_KEY = "PokySkinSelfTest"; // Metadata: 0x005F293A
		public const string KEYS_PATH = "Temp/PokySkinSelfTestKeys.txt"; // Metadata: 0x005F294B
		public const string REPORT_PATH = "Temp/PokySkinSelfTest.txt"; // Metadata: 0x005F2969
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x005F2983
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x005F2996
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x005F299A
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x005F299E
		private const float OPEN_TIMEOUT_SEC = 6f; // Metadata: 0x005F29A2
		private const float SETTLE_SEC = 3f; // Metadata: 0x005F29A6
		private const float SHOT_SEC = 0.6f; // Metadata: 0x005F29AA
		private const float COOLDOWN_SEC = 0.8f; // Metadata: 0x005F29AE
		private readonly StringBuilder _report; // 0x20
		private readonly List<string> _stepErrors; // 0x28
		private int _stepErrorCount; // 0x30
		private int _pass; // 0x34
		private int _fail; // 0x38
		private int _preexisting; // 0x3C
		private static readonly string[] PREEXISTING_ERROR_PATTERNS; // 0x00
		public static readonly Dictionary<string, Action<ManagerQuangTruong>> ROUTES; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2711
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__31_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180C61C40-0x0000000180C61CE0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _GenericOpen_b__31_0(GameObject p); // 0x0000000180C61CE0-0x0000000180C620C0
			internal void _.cctor_b__44_0(ManagerQuangTruong h); // 0x0000000180C620C0-0x0000000180C620E0
			internal void _.cctor_b__44_1(ManagerQuangTruong h); // 0x0000000180C620E0-0x0000000180C62100
			internal void _.cctor_b__44_2(ManagerQuangTruong h); // 0x0000000180C62100-0x0000000180C62120
			internal void _.cctor_b__44_3(ManagerQuangTruong h); // 0x0000000180C62120-0x0000000180C62140
			internal void _.cctor_b__44_4(ManagerQuangTruong h); // 0x0000000180C62140-0x0000000180C62160
			internal void _.cctor_b__44_5(ManagerQuangTruong h); // 0x0000000180C62160-0x0000000180C62180
			internal void _.cctor_b__44_6(ManagerQuangTruong h); // 0x0000000180C62180-0x0000000180C621A0
			internal void _.cctor_b__44_7(ManagerQuangTruong h); // 0x0000000180C621A0-0x0000000180C621C0
			internal void _.cctor_b__44_8(ManagerQuangTruong h); // 0x0000000180C621C0-0x0000000180C621E0
			internal void _.cctor_b__44_9(ManagerQuangTruong h); // 0x0000000180C621E0-0x0000000180C62200
			internal void _.cctor_b__44_10(ManagerQuangTruong h); // 0x0000000180C62200-0x0000000180C62220
			internal void _.cctor_b__44_11(ManagerQuangTruong h); // 0x0000000180C62220-0x0000000180C62240
			internal void _.cctor_b__44_12(ManagerQuangTruong h); // 0x0000000180C62240-0x0000000180C62270
			internal void _.cctor_b__44_13(ManagerQuangTruong h); // 0x0000000180C62270-0x0000000180C62290
			internal void _.cctor_b__44_14(ManagerQuangTruong h); // 0x0000000180C62290-0x0000000180C622B0
			internal void _.cctor_b__44_15(ManagerQuangTruong h); // 0x0000000180C622B0-0x0000000180C622D0
			internal void _.cctor_b__44_16(ManagerQuangTruong h); // 0x0000000180C622D0-0x0000000180C622F0
			internal void _.cctor_b__44_17(ManagerQuangTruong h); // 0x0000000180C622F0-0x0000000180C62310
			internal void _.cctor_b__44_18(ManagerQuangTruong h); // 0x0000000180C62310-0x0000000180C62330
			internal void _.cctor_b__44_19(ManagerQuangTruong h); // 0x0000000180C62330-0x0000000180C62350
			internal void _.cctor_b__44_20(ManagerQuangTruong h); // 0x0000000180C62350-0x0000000180C62370
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverything_d__39 : IEnumerator<object> // TypeDefIndex: 2712
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__39(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C62370-0x0000000180C62B80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C62B80-0x0000000180C62BC0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverythingStatic_d__26 : IEnumerator<object> // TypeDefIndex: 2713
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverythingStatic_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C62BC0-0x0000000180C63340
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C63340-0x0000000180C63380
		}
	
		[CompilerGenerated]
		private sealed class _KhamNgocStep_d__30 : IEnumerator<object> // TypeDefIndex: 2714
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
			private GameObject _vq_5__2; // 0x28
			private Transform _kham_5__3; // 0x30
			private bool _shown_5__4; // 0x38
			private int _iKham_5__5; // 0x3C
			private int _iSkin_5__6; // 0x40
			private bool _orderOk_5__7; // 0x44
			private int _texts_5__8; // 0x48
			private int _images_5__9; // 0x4C
			private string _shot_5__10; // 0x50
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _KhamNgocStep_d__30(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180C63380-0x0000000180C63490
			private bool MoveNext(); // 0x0000000180C63490-0x0000000180C64900
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C64900-0x0000000180C64940
		}
	
		[CompilerGenerated]
		private sealed class _OpenAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 2715
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
			public string key; // 0x28
			private HashSet<GameObject> _before_5__2; // 0x30
			private string _how_5__3; // 0x38
			private float _t0_5__4; // 0x40
			private List<string> _opened_5__5; // 0x48
			private PokySkinCanvasFit _fit_5__6; // 0x50
			private bool _anyOpen_5__7; // 0x58
			private string _shot_5__8; // 0x60
			private bool _preexisting_5__9; // 0x68
			private string _errTxt_5__10; // 0x70
			private string _skinInfo_5__11; // 0x78
			private bool _ok_5__12; // 0x80
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenAndVerify_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180C64940-0x0000000180C64B90
			private bool MoveNext(); // 0x0000000180C64B90-0x0000000180C66430
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C66430-0x0000000180C66470
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__23 : IEnumerator<object> // TypeDefIndex: 2716
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180C66470-0x0000000180C66E00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C66E00-0x0000000180C66E40
		}
	
		// Constructors
		public PokySkinSelfTest(); // 0x0000000180C60D20-0x0000000180C60EA0
		static PokySkinSelfTest(); // 0x0000000180C60EA0-0x0000000180C61C40
	
		// Methods
		private void OnEnable(); // 0x0000000180C5DD10-0x0000000180C5DDC0
		private void OnDisable(); // 0x0000000180C5DDC0-0x0000000180C5DE70
		private void OnLog(string condition, string stackTrace, LogType type); // 0x0000000180C5DE70-0x0000000180C5DFC0
		private void Start(); // 0x0000000180C5DFC0-0x0000000180C5E130
		[IteratorStateMachine(typeof(_Run_d__23))]
		private IEnumerator Run(); // 0x0000000180C5E130-0x0000000180C5E1D0
		public static string[] LoadKeysStatic(); // 0x0000000180C5E1D0-0x0000000180C5E220
		public static void OpenRoute(string key); // 0x0000000180C5E220-0x0000000180C5E310
		[IteratorStateMachine(typeof(_CloseEverythingStatic_d__26))]
		public static IEnumerator CloseEverythingStatic(); // 0x0000000180C5E310-0x0000000180C5E350
		public static bool HasRuntimeListenerStatic(Button b); // 0x0000000180C5E350-0x0000000180C5E3A0
		private static string[] LoadKeys(); // 0x0000000180C5E3A0-0x0000000180C5E740
		[IteratorStateMachine(typeof(_OpenAndVerify_d__29))]
		private IEnumerator OpenAndVerify(string key); // 0x0000000180C5E740-0x0000000180C5E850
		[IteratorStateMachine(typeof(_KhamNgocStep_d__30))]
		private IEnumerator KhamNgocStep(); // 0x0000000180C5E850-0x0000000180C5E8F0
		private static void GenericOpen(string key); // 0x0000000180C5E8F0-0x0000000180C5EAC0
		private static bool HasRuntimeListener(Button b); // 0x0000000180C5EAC0-0x0000000180C5EC70
		private static PokySkinCanvasFit ActiveFit(); // 0x0000000180C5EC70-0x0000000180C5EDE0
		private static GameObject PanelRootOf(Transform fitNode); // 0x0000000180C5EDE0-0x0000000180C5EF10
		private static bool CheckinOpen(); // 0x0000000180C5EF10-0x0000000180C5F3E0
		private bool AllErrorsPreexisting(); // 0x0000000180C5F3E0-0x0000000180C5F780
		private static HashSet<GameObject> Snapshot(); // 0x0000000180C5F780-0x0000000180C60250
		private static List<string> Diff(HashSet<GameObject> before); // 0x0000000180C60250-0x0000000180C60580
		[IteratorStateMachine(typeof(_CloseEverything_d__39))]
		private IEnumerator CloseEverything(); // 0x0000000180C60580-0x0000000180C60620
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180C60620-0x0000000180C60B50
		private void Line(string s); // 0x00000001803E15E0-0x00000001803E1620
		private void Finish(); // 0x0000000180C60B50-0x0000000180C60D20
	}
}
