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
	public class PokySkinSelfTest : MonoBehaviour // TypeDefIndex: 2267
	{
		// Fields
		public const string PREF_KEY = "PokySkinSelfTest"; // Metadata: 0x0068E4BC
		public const string KEYS_PATH = "Temp/PokySkinSelfTestKeys.txt"; // Metadata: 0x0068E4CD
		public const string REPORT_PATH = "Temp/PokySkinSelfTest.txt"; // Metadata: 0x0068E4EB
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0068E505
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x0068E518
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0068E51C
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x0068E520
		private const float OPEN_TIMEOUT_SEC = 6f; // Metadata: 0x0068E524
		private const float SETTLE_SEC = 3f; // Metadata: 0x0068E528
		private const float SHOT_SEC = 0.6f; // Metadata: 0x0068E52C
		private const float COOLDOWN_SEC = 0.8f; // Metadata: 0x0068E530
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
		private sealed class __c // TypeDefIndex: 2268
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__31_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001807AEDA0-0x00000001807AEE10
			public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _GenericOpen_b__31_0(GameObject p); // 0x00000001807AE290-0x00000001807AE550
			internal void _.cctor_b__44_0(ManagerQuangTruong h); // 0x00000001807AE550-0x00000001807AE570
			internal void _.cctor_b__44_1(ManagerQuangTruong h); // 0x00000001807AE6B0-0x00000001807AE6D0
			internal void _.cctor_b__44_2(ManagerQuangTruong h); // 0x00000001807AE6F0-0x00000001807AE710
			internal void _.cctor_b__44_3(ManagerQuangTruong h); // 0x00000001807AE710-0x00000001807AE730
			internal void _.cctor_b__44_4(ManagerQuangTruong h); // 0x00000001807AE730-0x00000001807AE750
			internal void _.cctor_b__44_5(ManagerQuangTruong h); // 0x00000001807AE750-0x00000001807AE770
			internal void _.cctor_b__44_6(ManagerQuangTruong h); // 0x00000001807AE770-0x00000001807AE790
			internal void _.cctor_b__44_7(ManagerQuangTruong h); // 0x00000001807AE790-0x00000001807AE7B0
			internal void _.cctor_b__44_8(ManagerQuangTruong h); // 0x00000001807AE7B0-0x00000001807AE7D0
			internal void _.cctor_b__44_9(ManagerQuangTruong h); // 0x00000001807AE7D0-0x00000001807AE7F0
			internal void _.cctor_b__44_10(ManagerQuangTruong h); // 0x00000001807AE570-0x00000001807AE590
			internal void _.cctor_b__44_11(ManagerQuangTruong h); // 0x00000001807AE590-0x00000001807AE5B0
			internal void _.cctor_b__44_12(ManagerQuangTruong h); // 0x00000001807AE5B0-0x00000001807AE5D0
			internal void _.cctor_b__44_13(ManagerQuangTruong h); // 0x00000001807AE5D0-0x00000001807AE5F0
			internal void _.cctor_b__44_14(ManagerQuangTruong h); // 0x00000001807AE5F0-0x00000001807AE610
			internal void _.cctor_b__44_15(ManagerQuangTruong h); // 0x00000001807AE610-0x00000001807AE630
			internal void _.cctor_b__44_16(ManagerQuangTruong h); // 0x00000001807AE630-0x00000001807AE650
			internal void _.cctor_b__44_17(ManagerQuangTruong h); // 0x00000001807AE650-0x00000001807AE670
			internal void _.cctor_b__44_18(ManagerQuangTruong h); // 0x00000001807AE670-0x00000001807AE690
			internal void _.cctor_b__44_19(ManagerQuangTruong h); // 0x00000001807AE690-0x00000001807AE6B0
			internal void _.cctor_b__44_20(ManagerQuangTruong h); // 0x00000001807AE6D0-0x00000001807AE6F0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverything_d__39 : IEnumerator<object> // TypeDefIndex: 2269
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__39(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807AA870-0x00000001807AADA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807AADA0-0x00000001807AADE0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverythingStatic_d__26 : IEnumerator<object> // TypeDefIndex: 2270
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverythingStatic_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807AA3A0-0x00000001807AA830
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807AA830-0x00000001807AA870
		}
	
		[CompilerGenerated]
		private sealed class _KhamNgocStep_d__30 : IEnumerator<object> // TypeDefIndex: 2271
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _KhamNgocStep_d__30(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001807AB9F0-0x00000001807ABA40
			private bool MoveNext(); // 0x00000001807AADE0-0x00000001807AB9B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807AB9B0-0x00000001807AB9F0
		}
	
		[CompilerGenerated]
		private sealed class _OpenAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 2272
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenAndVerify_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001807ACED0-0x00000001807ACF60
			private bool MoveNext(); // 0x00000001807ABA40-0x00000001807ACE90
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807ACE90-0x00000001807ACED0
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__23 : IEnumerator<object> // TypeDefIndex: 2273
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x00000001807ADA80-0x00000001807AE250
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807AE250-0x00000001807AE290
		}
	
		// Constructors
		public PokySkinSelfTest(); // 0x00000001807A2280-0x00000001807A2320
		static PokySkinSelfTest(); // 0x00000001807A1810-0x00000001807A2280
	
		// Methods
		private void OnEnable(); // 0x00000001807A0F40-0x00000001807A0FD0
		private void OnDisable(); // 0x00000001807A0EB0-0x00000001807A0F40
		private void OnLog(string condition, string stackTrace, LogType type); // 0x00000001807A0FD0-0x00000001807A10D0
		private void Start(); // 0x00000001807A1760-0x00000001807A1810
		[IteratorStateMachine(typeof(_Run_d__23))]
		private IEnumerator Run(); // 0x00000001807A12D0-0x00000001807A1340
		public static string[] LoadKeysStatic(); // 0x00000001807A0C70-0x00000001807A0CB0
		public static void OpenRoute(string key); // 0x00000001807A1160-0x00000001807A1240
		[IteratorStateMachine(typeof(_CloseEverythingStatic_d__26))]
		public static IEnumerator CloseEverythingStatic(); // 0x00000001807A0120-0x00000001807A0170
		public static bool HasRuntimeListenerStatic(Button b); // 0x00000001807A0A00-0x00000001807A0A50
		private static string[] LoadKeys(); // 0x00000001807A0CB0-0x00000001807A0EB0
		[IteratorStateMachine(typeof(_OpenAndVerify_d__29))]
		private IEnumerator OpenAndVerify(string key); // 0x00000001807A10D0-0x00000001807A1160
		[IteratorStateMachine(typeof(_KhamNgocStep_d__30))]
		private IEnumerator KhamNgocStep(); // 0x00000001807A0C00-0x00000001807A0C70
		private static void GenericOpen(string key); // 0x00000001807A08A0-0x00000001807A0A00
		private static bool HasRuntimeListener(Button b); // 0x00000001807A0A50-0x00000001807A0C00
		private static PokySkinCanvasFit ActiveFit(); // 0x000000018079FD10-0x000000018079FE00
		private static GameObject PanelRootOf(Transform fitNode); // 0x00000001807A1240-0x00000001807A12D0
		private static bool CheckinOpen(); // 0x000000018079FFC0-0x00000001807A0120
		private bool AllErrorsPreexisting(); // 0x000000018079FE00-0x000000018079FFC0
		private static HashSet<GameObject> Snapshot(); // 0x00000001807A1340-0x00000001807A1760
		private static List<string> Diff(HashSet<GameObject> before); // 0x00000001807A01E0-0x00000001807A03F0
		[IteratorStateMachine(typeof(_CloseEverything_d__39))]
		private IEnumerator CloseEverything(); // 0x00000001807A0170-0x00000001807A01E0
		private void ForceClose(HashSet<GameObject> before); // 0x00000001807A05A0-0x00000001807A08A0
		private void Line(string s); // 0x00000001803A24A0-0x00000001803A24C0
		private void Finish(); // 0x00000001807A03F0-0x00000001807A05A0
	}
}
