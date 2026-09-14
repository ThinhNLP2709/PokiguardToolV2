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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public class PokyFxSelfTest : MonoBehaviour // TypeDefIndex: 2672
	{
		// Fields
		public const string PREF_KEY = "PokyFxSelfTest"; // Metadata: 0x005F275C
		public const string REPORT_PATH = "Temp/PokyFxSelfTest.txt"; // Metadata: 0x005F276B
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x005F2783
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x005F2796
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x005F279A
		private const float SETTLE_SEC = 1.2f; // Metadata: 0x005F279E
		private const float SHOT_SEC = 0.6f; // Metadata: 0x005F27A2
		private const int CYCLES = 10; // Metadata: 0x005F27A6
		private readonly StringBuilder _report; // 0x20
		private int _fail; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Run_d__11 : IEnumerator<object> // TypeDefIndex: 2673
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
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C3E610-0x0000000180C3F310
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C3F310-0x0000000180C3F350
		}
	
		[CompilerGenerated]
		private sealed class _Shot_d__17 : IEnumerator<object> // TypeDefIndex: 2674
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
			private bool MoveNext(); // 0x0000000180C3F350-0x0000000180C3F600
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C3F600-0x0000000180C3F640
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelFx_d__14 : IEnumerator<object> // TypeDefIndex: 2675
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
			void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
			private bool MoveNext(); // 0x0000000180C3F640-0x0000000180C401A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C401A0-0x0000000180C401E0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelTooltips_d__15 : IEnumerator<object> // TypeDefIndex: 2676
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
			private bool MoveNext(); // 0x0000000180C401E0-0x0000000180C406B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C406B0-0x0000000180C406F0
		}
	
		[CompilerGenerated]
		private sealed class _TestTooltips_d__12 : IEnumerator<object> // TypeDefIndex: 2677
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
			void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
			private bool MoveNext(); // 0x0000000180C406F0-0x0000000180C41260
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C41260-0x0000000180C412A0
		}
	
		[CompilerGenerated]
		private sealed class _TooltipOnPanel_d__16 : IEnumerator<object> // TypeDefIndex: 2678
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
			void IDisposable.Dispose(); // 0x0000000180C412A0-0x0000000180C41360
			private bool MoveNext(); // 0x0000000180C41360-0x0000000180C424E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C424E0-0x0000000180C42520
		}
	
		// Constructors
		public PokyFxSelfTest(); // 0x0000000180C3E550-0x0000000180C3E610
	
		// Methods
		private void Start(); // 0x0000000180C3C7F0-0x0000000180C3C960
		[IteratorStateMachine(typeof(_Run_d__11))]
		private IEnumerator Run(); // 0x0000000180C3C960-0x0000000180C3CA00
		[IteratorStateMachine(typeof(_TestTooltips_d__12))]
		private IEnumerator TestTooltips(); // 0x0000000180C3CA00-0x0000000180C3CAA0
		private void ReportTooltip(string goName, string label); // 0x0000000180C3CAA0-0x0000000180C3DD30
		[IteratorStateMachine(typeof(_TestPanelFx_d__14))]
		private IEnumerator TestPanelFx(); // 0x0000000180C3DD30-0x0000000180C3DDD0
		[IteratorStateMachine(typeof(_TestPanelTooltips_d__15))]
		private IEnumerator TestPanelTooltips(); // 0x0000000180C3DDD0-0x0000000180C3DE70
		[IteratorStateMachine(typeof(_TooltipOnPanel_d__16))]
		private IEnumerator TooltipOnPanel(Action open, string panelKey, string shot, int pick); // 0x0000000180C3DE70-0x0000000180C3E040
		[IteratorStateMachine(typeof(_Shot_d__17))]
		private IEnumerator Shot(string name); // 0x0000000180C3E040-0x0000000180C3E150
		private static string Stats(); // 0x0000000180C3E150-0x0000000180C3E190
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C3E190-0x0000000180C3E2C0
		private void Line(string s); // 0x0000000180C3E2C0-0x0000000180C3E380
		private void Finish(); // 0x0000000180C3E380-0x0000000180C3E550
	}
}
