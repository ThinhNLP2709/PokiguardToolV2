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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	public class PokyHubSelfTest : MonoBehaviour // TypeDefIndex: 1861
	{
		// Fields
		public const string PREF_KEY = "PokyHubSelfTest"; // Metadata: 0x0064DC87
		public const string REPORT_PATH = "Temp/PokyHubSelfTest.txt"; // Metadata: 0x0064DC97
		public const string PREF_CONTROL = "PokyHubSelfTestControl"; // Metadata: 0x0064DCB0
		public const string REPORT_CONTROL_PATH = "Temp/PokyHubSelfTest_control.txt"; // Metadata: 0x0064DCC7
		private static readonly string[] CONTROL_ROUTES; // 0x00
		private bool _control; // 0x20
		private const float WAIT_SHELL_SEC = 90f; // Metadata: 0x0064DCE8
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0064DCEC
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x0064DCF0
		private const float OPEN_TIMEOUT_SEC = 5f; // Metadata: 0x0064DCF4
		private const float SETTLE_SEC = 0.6f; // Metadata: 0x0064DCF8
		private const float ROUTER_COOLDOWN_SEC = 0.8f; // Metadata: 0x0064DCFC
		private readonly StringBuilder _report; // 0x28
		private readonly List<string> _stepErrors; // 0x30
		private int _stepErrorCount; // 0x38
		private int _pass; // 0x3C
		private int _fail; // 0x40
		private int _skip; // 0x44
		private int _preexisting; // 0x48
		private static readonly string[] PREEXISTING_ERROR_PATTERNS; // 0x08
	
		// Nested types
		[CompilerGenerated]
		private sealed class _CloseEverything_d__36 : IEnumerator<object> // TypeDefIndex: 1862
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__36(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018063B5D0-0x000000018063BB60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018063BB60-0x000000018063BBA0
		}
	
		[CompilerGenerated]
		private sealed class _OpenDirectAndVerify_d__27 : IEnumerator<object> // TypeDefIndex: 1863
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			public string route; // 0x28
			private HashSet<GameObject> _before_5__2; // 0x30
			private float _t0_5__3; // 0x38
			private List<string> _opened_5__4; // 0x40
			private string _errTxt_5__5; // 0x48
			private bool _ok_5__6; // 0x50
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenDirectAndVerify_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001804D5EF0-0x00000001804D5F40
			private bool MoveNext(); // 0x000000018063C6D0-0x000000018063D140
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018063D140-0x000000018063D180
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__25 : IEnumerator<object> // TypeDefIndex: 1864
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private PokyHomeModuleView[] _views_5__3; // 0x30
			private HashSet<string> _seenRoutes_5__4; // 0x38
			private int _i_5__5; // 0x40
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
			private bool MoveNext(); // 0x000000018063DE50-0x000000018063E8A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018063E8A0-0x000000018063E8E0
		}
	
		[CompilerGenerated]
		private sealed class _RunControl_d__26 : IEnumerator<object> // TypeDefIndex: 1865
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _RunControl_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x000000018063D8A0-0x000000018063DE10
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018063DE10-0x000000018063DE50
		}
	
		[CompilerGenerated]
		private sealed class _StaticChecks_d__28 : IEnumerator<object> // TypeDefIndex: 1866
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private PokyHomeFloatAnim _anim_5__2; // 0x28
			private float _y1_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _StaticChecks_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x000000018063E8E0-0x00000001806400F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806400F0-0x0000000180640130
		}
	
		[CompilerGenerated]
		private sealed class _TapAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 1867
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			public GameObject tap; // 0x28
			public string route; // 0x30
			public string moduleId; // 0x38
			public string note; // 0x40
			private HashSet<GameObject> _before_5__2; // 0x48
			private bool _chatBefore_5__3; // 0x50
			private float _t0_5__4; // 0x54
			private List<string> _opened_5__5; // 0x58
			private bool _special_5__6; // 0x60
			private string _errTxt_5__7; // 0x68
			private bool _preexisting_5__8; // 0x70
			private bool _ok_5__9; // 0x71
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TapAndVerify_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180640C00-0x0000000180640C50
			private bool MoveNext(); // 0x0000000180640130-0x0000000180640BC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180640BC0-0x0000000180640C00
		}
	
		// Constructors
		public PokyHubSelfTest(); // 0x0000000180639230-0x00000001806392D0
		static PokyHubSelfTest(); // 0x0000000180638FC0-0x0000000180639230
	
		// Methods
		private bool AllErrorsPreexisting(); // 0x0000000180637320-0x00000001806374E0
		private void OnEnable(); // 0x0000000180637EF0-0x0000000180637F80
		private void OnDisable(); // 0x0000000180637E60-0x0000000180637EF0
		private void OnLog(string condition, string stackTrace, LogType type); // 0x0000000180637F80-0x0000000180638080
		private void Start(); // 0x0000000180638B60-0x0000000180638C70
		[IteratorStateMachine(typeof(_Run_d__25))]
		private IEnumerator Run(); // 0x0000000180638180-0x00000001806381F0
		[IteratorStateMachine(typeof(_RunControl_d__26))]
		private IEnumerator RunControl(); // 0x0000000180638110-0x0000000180638180
		[IteratorStateMachine(typeof(_OpenDirectAndVerify_d__27))]
		private IEnumerator OpenDirectAndVerify(string route); // 0x0000000180638080-0x0000000180638110
		[IteratorStateMachine(typeof(_StaticChecks_d__28))]
		private IEnumerator StaticChecks(); // 0x0000000180638C70-0x0000000180638CE0
		[IteratorStateMachine(typeof(_TapAndVerify_d__29))]
		private IEnumerator TapAndVerify(string moduleId, string route, GameObject tap, string note); // 0x0000000180638CE0-0x0000000180638DC0
		private static GameObject TapTarget(PokyHomeModuleView v); // 0x0000000180638DC0-0x0000000180638F10
		private static void SimulateTap(GameObject go); // 0x00000001806381F0-0x0000000180638400
		private static HashSet<GameObject> Snapshot(); // 0x0000000180638400-0x0000000180638820
		private static List<string> Diff(HashSet<GameObject> before); // 0x00000001806377A0-0x00000001806379B0
		private static bool ChatOpen(); // 0x00000001806374E0-0x0000000180637580
		private bool SpecialOpened(string route, bool chatBefore); // 0x0000000180638820-0x0000000180638B60
		[IteratorStateMachine(typeof(_CloseEverything_d__36))]
		private IEnumerator CloseEverything(); // 0x0000000180637730-0x00000001806377A0
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180637B70-0x0000000180637D80
		private void Check(string what, bool ok, string detail); // 0x0000000180637580-0x0000000180637730
		private static bool HasText(UnityEngine.UI.Text t); // 0x0000000180637D80-0x0000000180637E40
		private static string TextOf(UnityEngine.UI.Text t); // 0x0000000180638F10-0x0000000180638FC0
		private void Line(string s); // 0x0000000180637E40-0x0000000180637E60
		private void Finish(); // 0x00000001806379B0-0x0000000180637B70
	}
}
