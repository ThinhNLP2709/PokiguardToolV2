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
	public class PokyHubSelfTest : MonoBehaviour // TypeDefIndex: 2631
	{
		// Fields
		public const string PREF_KEY = "PokyHubSelfTest"; // Metadata: 0x005F263C
		public const string REPORT_PATH = "Temp/PokyHubSelfTest.txt"; // Metadata: 0x005F264C
		public const string PREF_CONTROL = "PokyHubSelfTestControl"; // Metadata: 0x005F2665
		public const string REPORT_CONTROL_PATH = "Temp/PokyHubSelfTest_control.txt"; // Metadata: 0x005F267C
		private static readonly string[] CONTROL_ROUTES; // 0x00
		private bool _control; // 0x20
		private const float WAIT_SHELL_SEC = 90f; // Metadata: 0x005F269D
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x005F26A1
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x005F26A5
		private const float OPEN_TIMEOUT_SEC = 5f; // Metadata: 0x005F26A9
		private const float SETTLE_SEC = 0.6f; // Metadata: 0x005F26AD
		private const float ROUTER_COOLDOWN_SEC = 0.8f; // Metadata: 0x005F26B1
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
		private sealed class _CloseEverything_d__36 : IEnumerator<object> // TypeDefIndex: 2632
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C21480-0x0000000180C21CE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C21CE0-0x0000000180C21D20
		}
	
		[CompilerGenerated]
		private sealed class _OpenDirectAndVerify_d__27 : IEnumerator<object> // TypeDefIndex: 2633
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenDirectAndVerify_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001808F4EA0-0x00000001808F4FB0
			private bool MoveNext(); // 0x0000000180C21D20-0x0000000180C229C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C229C0-0x0000000180C22A00
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__25 : IEnumerator<object> // TypeDefIndex: 2634
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018046B1F0-0x000000018046B2B0
			private bool MoveNext(); // 0x0000000180C22A00-0x0000000180C23760
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C23760-0x0000000180C237A0
		}
	
		[CompilerGenerated]
		private sealed class _RunControl_d__26 : IEnumerator<object> // TypeDefIndex: 2635
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _RunControl_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180C237A0-0x0000000180C23F00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C23F00-0x0000000180C23F40
		}
	
		[CompilerGenerated]
		private sealed class _StaticChecks_d__28 : IEnumerator<object> // TypeDefIndex: 2636
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private PokyHomeFloatAnim _anim_5__2; // 0x28
			private float _y1_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _StaticChecks_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180C23F40-0x0000000180C256A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C256A0-0x0000000180C256E0
		}
	
		[CompilerGenerated]
		private sealed class _TapAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 2637
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TapAndVerify_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180C256E0-0x0000000180C257F0
			private bool MoveNext(); // 0x0000000180C257F0-0x0000000180C262B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C262B0-0x0000000180C262F0
		}
	
		// Constructors
		public PokyHubSelfTest(); // 0x0000000180C21010-0x0000000180C21190
		static PokyHubSelfTest(); // 0x0000000180C21190-0x0000000180C21480
	
		// Methods
		private bool AllErrorsPreexisting(); // 0x0000000180C1DEE0-0x0000000180C1E280
		private void OnEnable(); // 0x0000000180C1E280-0x0000000180C1E330
		private void OnDisable(); // 0x0000000180C1E330-0x0000000180C1E3E0
		private void OnLog(string condition, string stackTrace, LogType type); // 0x0000000180C1E3E0-0x0000000180C1E530
		private void Start(); // 0x0000000180C1E530-0x0000000180C1E7E0
		[IteratorStateMachine(typeof(_Run_d__25))]
		private IEnumerator Run(); // 0x0000000180C1E7E0-0x0000000180C1E880
		[IteratorStateMachine(typeof(_RunControl_d__26))]
		private IEnumerator RunControl(); // 0x0000000180C1E880-0x0000000180C1E920
		[IteratorStateMachine(typeof(_OpenDirectAndVerify_d__27))]
		private IEnumerator OpenDirectAndVerify(string route); // 0x0000000180C1E920-0x0000000180C1EA30
		[IteratorStateMachine(typeof(_StaticChecks_d__28))]
		private IEnumerator StaticChecks(); // 0x0000000180C1EA30-0x0000000180C1EAD0
		[IteratorStateMachine(typeof(_TapAndVerify_d__29))]
		private IEnumerator TapAndVerify(string moduleId, string route, GameObject tap, string note); // 0x0000000180C1EAD0-0x0000000180C1ECF0
		private static GameObject TapTarget(PokyHomeModuleView v); // 0x0000000180C1ECF0-0x0000000180C1F000
		private static void SimulateTap(GameObject go); // 0x0000000180C1F000-0x0000000180C1F170
		private static HashSet<GameObject> Snapshot(); // 0x0000000180C1F170-0x0000000180C1FC40
		private static List<string> Diff(HashSet<GameObject> before); // 0x0000000180C1FC40-0x0000000180C1FF70
		private static bool ChatOpen(); // 0x0000000180C1FF70-0x0000000180C200D0
		private bool SpecialOpened(string route, bool chatBefore); // 0x0000000180C200D0-0x0000000180C205B0
		[IteratorStateMachine(typeof(_CloseEverything_d__36))]
		private IEnumerator CloseEverything(); // 0x0000000180C205B0-0x0000000180C20650
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180C20650-0x0000000180C209B0
		private void Check(string what, bool ok, string detail); // 0x0000000180C209B0-0x0000000180C20B70
		private static bool HasText(UnityEngine.UI.Text t); // 0x0000000180C20B70-0x0000000180C20CB0
		private static string TextOf(UnityEngine.UI.Text t); // 0x0000000180C20CB0-0x0000000180C20DE0
		private void Line(string s); // 0x0000000180C20DE0-0x0000000180C20E20
		private void Finish(); // 0x0000000180C20E20-0x0000000180C21010
	}
}
