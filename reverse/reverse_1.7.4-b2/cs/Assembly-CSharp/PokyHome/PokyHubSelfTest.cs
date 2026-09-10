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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public class PokyHubSelfTest : MonoBehaviour // TypeDefIndex: 2188
	{
		// Fields
		public const string PREF_KEY = "PokyHubSelfTest"; // Metadata: 0x0068E107
		public const string REPORT_PATH = "Temp/PokyHubSelfTest.txt"; // Metadata: 0x0068E117
		public const string PREF_CONTROL = "PokyHubSelfTestControl"; // Metadata: 0x0068E130
		public const string REPORT_CONTROL_PATH = "Temp/PokyHubSelfTest_control.txt"; // Metadata: 0x0068E147
		private static readonly string[] CONTROL_ROUTES; // 0x00
		private bool _control; // 0x20
		private const float WAIT_SHELL_SEC = 90f; // Metadata: 0x0068E168
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0068E16C
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x0068E170
		private const float OPEN_TIMEOUT_SEC = 5f; // Metadata: 0x0068E174
		private const float SETTLE_SEC = 0.6f; // Metadata: 0x0068E178
		private const float ROUTER_COOLDOWN_SEC = 0.8f; // Metadata: 0x0068E17C
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
		private sealed class _CloseEverything_d__36 : IEnumerator<object> // TypeDefIndex: 2189
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__36(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807785F0-0x0000000180778BA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180778BA0-0x0000000180778BE0
		}
	
		[CompilerGenerated]
		private sealed class _OpenDirectAndVerify_d__27 : IEnumerator<object> // TypeDefIndex: 2190
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenDirectAndVerify_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805D38F0-0x00000001805D3940
			private bool MoveNext(); // 0x0000000180778DF0-0x0000000180779860
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180779860-0x00000001807798A0
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__25 : IEnumerator<object> // TypeDefIndex: 2191
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180425260-0x00000001804252A0
			private bool MoveNext(); // 0x000000018077A050-0x000000018077AAA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018077AAA0-0x000000018077AAE0
		}
	
		[CompilerGenerated]
		private sealed class _RunControl_d__26 : IEnumerator<object> // TypeDefIndex: 2192
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _RunControl_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x0000000180779AA0-0x000000018077A010
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018077A010-0x000000018077A050
		}
	
		[CompilerGenerated]
		private sealed class _StaticChecks_d__28 : IEnumerator<object> // TypeDefIndex: 2193
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHubSelfTest __4__this; // 0x20
			private PokyHomeFloatAnim _anim_5__2; // 0x28
			private float _y1_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _StaticChecks_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x000000018077AAE0-0x000000018077C2F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018077C2F0-0x000000018077C330
		}
	
		[CompilerGenerated]
		private sealed class _TapAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 2194
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _TapAndVerify_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018077CE00-0x000000018077CE50
			private bool MoveNext(); // 0x000000018077C330-0x000000018077CDC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018077CDC0-0x000000018077CE00
		}
	
		// Constructors
		public PokyHubSelfTest(); // 0x0000000180775D00-0x0000000180775DA0
		static PokyHubSelfTest(); // 0x0000000180775A90-0x0000000180775D00
	
		// Methods
		private bool AllErrorsPreexisting(); // 0x0000000180773DF0-0x0000000180773FB0
		private void OnEnable(); // 0x00000001807749C0-0x0000000180774A50
		private void OnDisable(); // 0x0000000180774930-0x00000001807749C0
		private void OnLog(string condition, string stackTrace, LogType type); // 0x0000000180774A50-0x0000000180774B50
		private void Start(); // 0x0000000180775630-0x0000000180775740
		[IteratorStateMachine(typeof(_Run_d__25))]
		private IEnumerator Run(); // 0x0000000180774C50-0x0000000180774CC0
		[IteratorStateMachine(typeof(_RunControl_d__26))]
		private IEnumerator RunControl(); // 0x0000000180774BE0-0x0000000180774C50
		[IteratorStateMachine(typeof(_OpenDirectAndVerify_d__27))]
		private IEnumerator OpenDirectAndVerify(string route); // 0x0000000180774B50-0x0000000180774BE0
		[IteratorStateMachine(typeof(_StaticChecks_d__28))]
		private IEnumerator StaticChecks(); // 0x0000000180775740-0x00000001807757B0
		[IteratorStateMachine(typeof(_TapAndVerify_d__29))]
		private IEnumerator TapAndVerify(string moduleId, string route, GameObject tap, string note); // 0x00000001807757B0-0x0000000180775890
		private static GameObject TapTarget(PokyHomeModuleView v); // 0x0000000180775890-0x00000001807759E0
		private static void SimulateTap(GameObject go); // 0x0000000180774CC0-0x0000000180774ED0
		private static HashSet<GameObject> Snapshot(); // 0x0000000180774ED0-0x00000001807752F0
		private static List<string> Diff(HashSet<GameObject> before); // 0x0000000180774270-0x0000000180774480
		private static bool ChatOpen(); // 0x0000000180773FB0-0x0000000180774050
		private bool SpecialOpened(string route, bool chatBefore); // 0x00000001807752F0-0x0000000180775630
		[IteratorStateMachine(typeof(_CloseEverything_d__36))]
		private IEnumerator CloseEverything(); // 0x0000000180774200-0x0000000180774270
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180774640-0x0000000180774850
		private void Check(string what, bool ok, string detail); // 0x0000000180774050-0x0000000180774200
		private static bool HasText(UnityEngine.UI.Text t); // 0x0000000180774850-0x0000000180774910
		private static string TextOf(UnityEngine.UI.Text t); // 0x00000001807759E0-0x0000000180775A90
		private void Line(string s); // 0x0000000180774910-0x0000000180774930
		private void Finish(); // 0x0000000180774480-0x0000000180774640
	}
}
