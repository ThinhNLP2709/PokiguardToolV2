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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	public class PokySkinSelfTest : MonoBehaviour // TypeDefIndex: 2703
	{
		// Fields
		public const string PREF_KEY = "PokySkinSelfTest"; // Metadata: 0x005F1523
		public const string KEYS_PATH = "Temp/PokySkinSelfTestKeys.txt"; // Metadata: 0x005F1534
		public const string REPORT_PATH = "Temp/PokySkinSelfTest.txt"; // Metadata: 0x005F1552
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x005F156C
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x005F157F
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x005F1583
		private const float OPEN_POLL_SEC = 0.25f; // Metadata: 0x005F1587
		private const float OPEN_TIMEOUT_SEC = 6f; // Metadata: 0x005F158B
		private const float SETTLE_SEC = 3f; // Metadata: 0x005F158F
		private const float SHOT_SEC = 0.6f; // Metadata: 0x005F1593
		private const float COOLDOWN_SEC = 0.8f; // Metadata: 0x005F1597
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
		private sealed class __c // TypeDefIndex: 2704
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<GameObject> __9__31_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180C54680-0x0000000180C54720
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _GenericOpen_b__31_0(GameObject p); // 0x0000000180C54720-0x0000000180C54B00
			internal void _.cctor_b__44_0(ManagerQuangTruong h); // 0x0000000180C54B00-0x0000000180C54B20
			internal void _.cctor_b__44_1(ManagerQuangTruong h); // 0x0000000180C54B20-0x0000000180C54B40
			internal void _.cctor_b__44_2(ManagerQuangTruong h); // 0x0000000180C54B40-0x0000000180C54B60
			internal void _.cctor_b__44_3(ManagerQuangTruong h); // 0x0000000180C54B60-0x0000000180C54B80
			internal void _.cctor_b__44_4(ManagerQuangTruong h); // 0x0000000180C54B80-0x0000000180C54BA0
			internal void _.cctor_b__44_5(ManagerQuangTruong h); // 0x0000000180C54BA0-0x0000000180C54BC0
			internal void _.cctor_b__44_6(ManagerQuangTruong h); // 0x0000000180C54BC0-0x0000000180C54BE0
			internal void _.cctor_b__44_7(ManagerQuangTruong h); // 0x0000000180C54BE0-0x0000000180C54C00
			internal void _.cctor_b__44_8(ManagerQuangTruong h); // 0x0000000180C54C00-0x0000000180C54C20
			internal void _.cctor_b__44_9(ManagerQuangTruong h); // 0x0000000180C54C20-0x0000000180C54C40
			internal void _.cctor_b__44_10(ManagerQuangTruong h); // 0x0000000180C54C40-0x0000000180C54C60
			internal void _.cctor_b__44_11(ManagerQuangTruong h); // 0x0000000180C54C60-0x0000000180C54C80
			internal void _.cctor_b__44_12(ManagerQuangTruong h); // 0x0000000180C54C80-0x0000000180C54CB0
			internal void _.cctor_b__44_13(ManagerQuangTruong h); // 0x0000000180C54CB0-0x0000000180C54CD0
			internal void _.cctor_b__44_14(ManagerQuangTruong h); // 0x0000000180C54CD0-0x0000000180C54CF0
			internal void _.cctor_b__44_15(ManagerQuangTruong h); // 0x0000000180C54CF0-0x0000000180C54D10
			internal void _.cctor_b__44_16(ManagerQuangTruong h); // 0x0000000180C54D10-0x0000000180C54D30
			internal void _.cctor_b__44_17(ManagerQuangTruong h); // 0x0000000180C54D30-0x0000000180C54D50
			internal void _.cctor_b__44_18(ManagerQuangTruong h); // 0x0000000180C54D50-0x0000000180C54D70
			internal void _.cctor_b__44_19(ManagerQuangTruong h); // 0x0000000180C54D70-0x0000000180C54D90
			internal void _.cctor_b__44_20(ManagerQuangTruong h); // 0x0000000180C54D90-0x0000000180C54DB0
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverything_d__39 : IEnumerator<object> // TypeDefIndex: 2705
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C54DB0-0x0000000180C555C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C555C0-0x0000000180C55600
		}
	
		[CompilerGenerated]
		private sealed class _CloseEverythingStatic_d__26 : IEnumerator<object> // TypeDefIndex: 2706
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C55600-0x0000000180C55D80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C55D80-0x0000000180C55DC0
		}
	
		[CompilerGenerated]
		private sealed class _KhamNgocStep_d__30 : IEnumerator<object> // TypeDefIndex: 2707
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
			void IDisposable.Dispose(); // 0x0000000180C55DC0-0x0000000180C55ED0
			private bool MoveNext(); // 0x0000000180C55ED0-0x0000000180C57340
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C57340-0x0000000180C57380
		}
	
		[CompilerGenerated]
		private sealed class _OpenAndVerify_d__29 : IEnumerator<object> // TypeDefIndex: 2708
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
			void IDisposable.Dispose(); // 0x0000000180C57380-0x0000000180C575D0
			private bool MoveNext(); // 0x0000000180C575D0-0x0000000180C58E70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C58E70-0x0000000180C58EB0
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__23 : IEnumerator<object> // TypeDefIndex: 2709
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
			private bool MoveNext(); // 0x0000000180C58EB0-0x0000000180C59840
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C59840-0x0000000180C59880
		}
	
		// Constructors
		public PokySkinSelfTest(); // 0x0000000180C53760-0x0000000180C538E0
		static PokySkinSelfTest(); // 0x0000000180C538E0-0x0000000180C54680
	
		// Methods
		private void OnEnable(); // 0x0000000180C50750-0x0000000180C50800
		private void OnDisable(); // 0x0000000180C50800-0x0000000180C508B0
		private void OnLog(string condition, string stackTrace, LogType type); // 0x0000000180C508B0-0x0000000180C50A00
		private void Start(); // 0x0000000180C50A00-0x0000000180C50B70
		[IteratorStateMachine(typeof(_Run_d__23))]
		private IEnumerator Run(); // 0x0000000180C50B70-0x0000000180C50C10
		public static string[] LoadKeysStatic(); // 0x0000000180C50C10-0x0000000180C50C60
		public static void OpenRoute(string key); // 0x0000000180C50C60-0x0000000180C50D50
		[IteratorStateMachine(typeof(_CloseEverythingStatic_d__26))]
		public static IEnumerator CloseEverythingStatic(); // 0x0000000180C50D50-0x0000000180C50D90
		public static bool HasRuntimeListenerStatic(Button b); // 0x0000000180C50D90-0x0000000180C50DE0
		private static string[] LoadKeys(); // 0x0000000180C50DE0-0x0000000180C51180
		[IteratorStateMachine(typeof(_OpenAndVerify_d__29))]
		private IEnumerator OpenAndVerify(string key); // 0x0000000180C51180-0x0000000180C51290
		[IteratorStateMachine(typeof(_KhamNgocStep_d__30))]
		private IEnumerator KhamNgocStep(); // 0x0000000180C51290-0x0000000180C51330
		private static void GenericOpen(string key); // 0x0000000180C51330-0x0000000180C51500
		private static bool HasRuntimeListener(Button b); // 0x0000000180C51500-0x0000000180C516B0
		private static PokySkinCanvasFit ActiveFit(); // 0x0000000180C516B0-0x0000000180C51820
		private static GameObject PanelRootOf(Transform fitNode); // 0x0000000180C51820-0x0000000180C51950
		private static bool CheckinOpen(); // 0x0000000180C51950-0x0000000180C51E20
		private bool AllErrorsPreexisting(); // 0x0000000180C51E20-0x0000000180C521C0
		private static HashSet<GameObject> Snapshot(); // 0x0000000180C521C0-0x0000000180C52C90
		private static List<string> Diff(HashSet<GameObject> before); // 0x0000000180C52C90-0x0000000180C52FC0
		[IteratorStateMachine(typeof(_CloseEverything_d__39))]
		private IEnumerator CloseEverything(); // 0x0000000180C52FC0-0x0000000180C53060
		private void ForceClose(HashSet<GameObject> before); // 0x0000000180C53060-0x0000000180C53590
		private void Line(string s); // 0x00000001803E08A0-0x00000001803E08E0
		private void Finish(); // 0x0000000180C53590-0x0000000180C53760
	}
}
