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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	public class PokyFxSelfTest : MonoBehaviour // TypeDefIndex: 2665
	{
		// Fields
		public const string PREF_KEY = "PokyFxSelfTest"; // Metadata: 0x005F1345
		public const string REPORT_PATH = "Temp/PokyFxSelfTest.txt"; // Metadata: 0x005F1354
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x005F136C
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x005F137F
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x005F1383
		private const float SETTLE_SEC = 1.2f; // Metadata: 0x005F1387
		private const float SHOT_SEC = 0.6f; // Metadata: 0x005F138B
		private const int CYCLES = 10; // Metadata: 0x005F138F
		private readonly StringBuilder _report; // 0x20
		private int _fail; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Run_d__11 : IEnumerator<object> // TypeDefIndex: 2666
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C30DC0-0x0000000180C31AC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C31AC0-0x0000000180C31EF0
		}
	
		[CompilerGenerated]
		private sealed class _Shot_d__17 : IEnumerator<object> // TypeDefIndex: 2667
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string name; // 0x20
			public PokyFxSelfTest __4__this; // 0x28
			private string _path_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Shot_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180C31EF0-0x0000000180C321A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C321A0-0x0000000180C321E0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelFx_d__14 : IEnumerator<object> // TypeDefIndex: 2668
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private ManagerQuangTruong _hub_5__2; // 0x28
			private UIPanelManager _mgr_5__3; // 0x30
			private float _t0_5__4; // 0x38
			private int _i_5__5; // 0x3C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelFx_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
			private bool MoveNext(); // 0x0000000180C321E0-0x0000000180C32D40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C32D40-0x0000000180C32D80
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelTooltips_d__15 : IEnumerator<object> // TypeDefIndex: 2669
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private ManagerQuangTruong _hub_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelTooltips_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180C32D80-0x0000000180C33250
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C33250-0x0000000180C33290
		}
	
		[CompilerGenerated]
		private sealed class _TestTooltips_d__12 : IEnumerator<object> // TypeDefIndex: 2670
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private GameObject _anchorGo_5__2; // 0x28
			private RectTransform _anchor_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TestTooltips_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
			private bool MoveNext(); // 0x0000000180C33290-0x0000000180C33E00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C33E00-0x0000000180C33E40
		}
	
		[CompilerGenerated]
		private sealed class _TooltipOnPanel_d__16 : IEnumerator<object> // TypeDefIndex: 2671
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Action open; // 0x20
			public string panelKey; // 0x28
			public PokyFxSelfTest __4__this; // 0x30
			public int pick; // 0x38
			public string shot; // 0x40
			private UIPanelManager _mgr_5__2; // 0x48
			private int _nRewards_5__3; // 0x50
			private GameObject _grid_5__4; // 0x58
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TooltipOnPanel_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180C33E40-0x0000000180C33F00
			private bool MoveNext(); // 0x0000000180C33F00-0x0000000180C35080
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C35080-0x0000000180C350C0
		}
	
		// Constructors
		public PokyFxSelfTest(); // 0x0000000180C30D00-0x0000000180C30DC0
	
		// Methods
		private void Start(); // 0x0000000180C2EFA0-0x0000000180C2F110
		[IteratorStateMachine(typeof(_Run_d__11))]
		private IEnumerator Run(); // 0x0000000180C2F110-0x0000000180C2F1B0
		[IteratorStateMachine(typeof(_TestTooltips_d__12))]
		private IEnumerator TestTooltips(); // 0x0000000180C2F1B0-0x0000000180C2F250
		private void ReportTooltip(string goName, string label); // 0x0000000180C2F250-0x0000000180C304E0
		[IteratorStateMachine(typeof(_TestPanelFx_d__14))]
		private IEnumerator TestPanelFx(); // 0x0000000180C304E0-0x0000000180C30580
		[IteratorStateMachine(typeof(_TestPanelTooltips_d__15))]
		private IEnumerator TestPanelTooltips(); // 0x0000000180C30580-0x0000000180C30620
		[IteratorStateMachine(typeof(_TooltipOnPanel_d__16))]
		private IEnumerator TooltipOnPanel(Action open, string panelKey, string shot, int pick); // 0x0000000180C30620-0x0000000180C307F0
		[IteratorStateMachine(typeof(_Shot_d__17))]
		private IEnumerator Shot(string name); // 0x0000000180C307F0-0x0000000180C30900
		private static string Stats(); // 0x0000000180C30900-0x0000000180C30940
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C30940-0x0000000180C30A70
		private void Line(string s); // 0x0000000180C30A70-0x0000000180C30B30
		private void Finish(); // 0x0000000180C30B30-0x0000000180C30D00
	}
}
