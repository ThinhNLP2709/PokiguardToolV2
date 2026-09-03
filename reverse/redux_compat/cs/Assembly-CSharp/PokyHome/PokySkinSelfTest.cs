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
	public class PokySkinSelfTest : MonoBehaviour // TypeDefIndex: 1941
	{
		// Fields
		public const string PREF_KEY = "PokySkinSelfTest"; // Metadata: 0x0064E03C
		public const string KEYS_PATH = "Temp/PokySkinSelfTestKeys.txt"; // Metadata: 0x0064E04D
		public const string REPORT_PATH = "Temp/PokySkinSelfTest.txt"; // Metadata: 0x0064E06B
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0064E085
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x0064E098
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0064E09C
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x0064E0A0
		private const float OPEN_TIMEOUT_SEC = 6f; // Metadata: 0x0064E0A4
		private const float SETTLE_SEC = 3f; // Metadata: 0x0064E0A8
		private const float SHOT_SEC = 0.6f; // Metadata: 0x0064E0AC
		private const float COOLDOWN_SEC = 0.8f; // Metadata: 0x0064E0B0
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
		private sealed class __c // TypeDefIndex: 1942
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__31_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180670BB0-0x0000000180670C20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _GenericOpen_b__31_0(GameObject p); // 0x000000018066FB70-0x000000018066FE30
			internal void _.cctor_b__44_0(ManagerQuangTruong h); // 0x000000018066FE30-0x000000018066FE50
			internal void _.cctor_b__44_1(ManagerQuangTruong h); // 0x000000018066FF90-0x000000018066FFB0
			internal void _.cctor_b__44_2(ManagerQuangTruong h); // 0x000000018066FFF0-0x0000000180670010
			internal void _.cctor_b__44_3(ManagerQuangTruong h); // 0x0000000180670010-0x0000000180670030
			internal void _.cctor_b__44_4(ManagerQuangTruong h); // 0x0000000180670030-0x0000000180670050
			internal void _.cctor_b__44_5(ManagerQuangTruong h); // 0x0000000180670050-0x0000000180670070
			internal void _.cctor_b__44_6(ManagerQuangTruong h); // 0x0000000180670070-0x0000000180670090
			internal void _.cctor_b__44_7(ManagerQuangTruong h); // 0x0000000180670090-0x00000001806700B0
			internal void _.cctor_b__44_8(ManagerQuangTruong h); // 0x00000001806700B0-0x00000001806700D0
			internal void _.cctor_b__44_9(ManagerQuangTruong h); // 0x00000001806700D0-0x00000001806700F0
			internal void _.cctor_b__44_10(ManagerQuangTruong h); // 0x000000018066FE50-0x000000018066FE70
			internal void _.cctor_b__44_11(ManagerQuangTruong h); // 0x000000018066FE70-0x000000018066FE90
			internal void _.cctor_b__44_12(ManagerQuangTruong h); // 0x000000018066FE90-0x000000018066FEB0
			internal void _.cctor_b__44_13(ManagerQuangTruong h); // 0x000000018066FEB0-0x000000018066FED0
			internal void _.cctor_b__44_14(ManagerQuangTruong h); // 0x000000018066FED0-0x000000018066FEF0
			internal void _.cctor_b__44_15(ManagerQuangTruong h); // 0x000000018066FEF0-0x000000018066FF10
			internal void _.cctor_b__44_16(ManagerQuangTruong h); // 0x000000018066FF10-0x000000018066FF30
			internal void _.cctor_b__44_17(ManagerQuangTruong h); // 0x000000018066FF30-0x000000018066FF50
			internal void _.cctor_b__44_18(ManagerQuangTruong h); // 0x000000018066FF50-0x000000018066FF70
			internal void _.cctor_b__44_19(ManagerQuangTruong h); // 0x000000018066FF70-0x000000018066FF90
			internal void _.cctor_b__44_20(ManagerQuangTruong h); // 0x000000018066FFB0-0x000000018066FFD0
			internal void _.cctor_b__44_21(ManagerQuangTruong h); // 0x000000018066FFD0-0x000000018066FFF0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverything_d__39 : IEnumerator<object> // TypeDefIndex: 1943
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverything_d__39(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018066BF70-0x000000018066C460
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066C460-0x000000018066C4A0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverythingStatic_d__26 : IEnumerator<object> // TypeDefIndex: 1944
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _CloseEverythingStatic_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018066BAC0-0x000000018066BF30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066BF30-0x000000018066BF70
		}
	
		[CompilerGenerated]
		private sealed class _KhamNgocStep_d__30 : IEnumerator<object> // TypeDefIndex: 1945
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _KhamNgocStep_d__30(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018066DD00-0x000000018066DD50
			private bool MoveNext(); // 0x000000018066D130-0x000000018066DCC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066DCC0-0x000000018066DD00
		}
	
		[CompilerGenerated]
		private sealed class _OpenAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 1946
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _OpenAndVerify_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018066F160-0x000000018066F1F0
			private bool MoveNext(); // 0x000000018066DD50-0x000000018066F120
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066F120-0x000000018066F160
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__23 : IEnumerator<object> // TypeDefIndex: 1947
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokySkinSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
			private string[] __7__wrap2; // 0x30
			private int __7__wrap3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x000000018066F370-0x000000018066FA70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066FA70-0x000000018066FAB0
		}
	
		// Constructors
		public PokySkinSelfTest(); // 0x0000000180652720-0x00000001806527C0
		static PokySkinSelfTest(); // 0x0000000180651C50-0x0000000180652720
	
		// Methods
		private void OnEnable(); // 0x0000000180651240-0x00000001806512D0
		private void OnDisable(); // 0x00000001806511B0-0x0000000180651240
		private void OnLog(string condition, string stackTrace, LogType type); // 0x00000001806512D0-0x00000001806513D0
		private void Start(); // 0x0000000180651BA0-0x0000000180651C50
		[IteratorStateMachine(typeof(_Run_d__23))]
		private IEnumerator Run(); // 0x0000000180651710-0x0000000180651780
		public static string[] LoadKeysStatic(); // 0x0000000180650F70-0x0000000180650FB0
		public static void OpenRoute(string key); // 0x0000000180651460-0x0000000180651680
		[IteratorStateMachine(typeof(_CloseEverythingStatic_d__26))]
		public static IEnumerator CloseEverythingStatic(); // 0x0000000180650300-0x0000000180650350
		public static bool HasRuntimeListenerStatic(Button b); // 0x0000000180650C90-0x0000000180650CE0
		private static string[] LoadKeys(); // 0x0000000180650FB0-0x00000001806511B0
		[IteratorStateMachine(typeof(_OpenAndVerify_d__29))]
		private IEnumerator OpenAndVerify(string key); // 0x00000001806513D0-0x0000000180651460
		[IteratorStateMachine(typeof(_KhamNgocStep_d__30))]
		private IEnumerator KhamNgocStep(); // 0x0000000180650F00-0x0000000180650F70
		private static void GenericOpen(string key); // 0x0000000180650B30-0x0000000180650C90
		private static bool HasRuntimeListener(Button b); // 0x0000000180650CE0-0x0000000180650F00
		private static PokySkinCanvasFit ActiveFit(); // 0x000000018064FEF0-0x000000018064FFE0
		private static GameObject PanelRootOf(Transform fitNode); // 0x0000000180651680-0x0000000180651710
		private static bool CheckinOpen(); // 0x00000001806501A0-0x0000000180650300
		private bool AllErrorsPreexisting(); // 0x000000018064FFE0-0x00000001806501A0
		private static HashSet<GameObject> Snapshot(); // 0x0000000180651780-0x0000000180651BA0
		private static List<string> Diff(HashSet<GameObject> before); // 0x00000001806503C0-0x00000001806505D0
		[IteratorStateMachine(typeof(_CloseEverything_d__39))]
		private IEnumerator CloseEverything(); // 0x0000000180650350-0x00000001806503C0
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180650780-0x0000000180650B30
		private void Line(string s); // 0x0000000180348890-0x00000001803488B0
		private void Finish(); // 0x00000001806505D0-0x0000000180650780
	}
}
