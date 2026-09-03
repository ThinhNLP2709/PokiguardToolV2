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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	public class PokyFxSelfTest : MonoBehaviour // TypeDefIndex: 1903
	{
		// Fields
		public const string PREF_KEY = "PokyFxSelfTest"; // Metadata: 0x0064DE11
		public const string REPORT_PATH = "Temp/PokyFxSelfTest.txt"; // Metadata: 0x0064DE20
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0064DE38
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x0064DE4B
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0064DE4F
		private const float SETTLE_SEC = 1.2f; // Metadata: 0x0064DE53
		private const float SHOT_SEC = 0.6f; // Metadata: 0x0064DE57
		private const int CYCLES = 10; // Metadata: 0x0064DE5B
		private readonly StringBuilder _report; // 0x20
		private int _fail; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Run_d__11 : IEnumerator<object> // TypeDefIndex: 1904
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000180653C70-0x00000001806546C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806546C0-0x0000000180654700
		}
	
		[CompilerGenerated]
		private sealed class _Shot_d__17 : IEnumerator<object> // TypeDefIndex: 1905
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string name; // 0x20
			public PokyFxSelfTest __4__this; // 0x28
			private string _path_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Shot_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x0000000180654DB0-0x0000000180654FA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180654FA0-0x0000000180654FE0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelFx_d__14 : IEnumerator<object> // TypeDefIndex: 1906
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelFx_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
			private bool MoveNext(); // 0x0000000180654FE0-0x00000001806558B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806558B0-0x00000001806558F0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelTooltips_d__15 : IEnumerator<object> // TypeDefIndex: 1907
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private ManagerQuangTruong _hub_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelTooltips_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x00000001806558F0-0x0000000180655C00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180655C00-0x0000000180655C40
		}
	
		[CompilerGenerated]
		private sealed class _TestTooltips_d__12 : IEnumerator<object> // TypeDefIndex: 1908
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private GameObject _anchorGo_5__2; // 0x28
			private RectTransform _anchor_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TestTooltips_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
			private bool MoveNext(); // 0x0000000180655C40-0x00000001806565B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806565B0-0x00000001806565F0
		}
	
		[CompilerGenerated]
		private sealed class _TooltipOnPanel_d__16 : IEnumerator<object> // TypeDefIndex: 1909
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TooltipOnPanel_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001806573A0-0x00000001806573E0
			private bool MoveNext(); // 0x00000001806565F0-0x0000000180657360
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180657360-0x00000001806573A0
		}
	
		// Constructors
		public PokyFxSelfTest(); // 0x0000000180642300-0x0000000180642350
	
		// Methods
		private void Start(); // 0x0000000180642000-0x00000001806420B0
		[IteratorStateMachine(typeof(_Run_d__11))]
		private IEnumerator Run(); // 0x0000000180641F00-0x0000000180641F70
		[IteratorStateMachine(typeof(_TestTooltips_d__12))]
		private IEnumerator TestTooltips(); // 0x00000001806421C0-0x0000000180642230
		private void ReportTooltip(string goName, string label); // 0x00000001806411F0-0x0000000180641F00
		[IteratorStateMachine(typeof(_TestPanelFx_d__14))]
		private IEnumerator TestPanelFx(); // 0x00000001806420E0-0x0000000180642150
		[IteratorStateMachine(typeof(_TestPanelTooltips_d__15))]
		private IEnumerator TestPanelTooltips(); // 0x0000000180642150-0x00000001806421C0
		[IteratorStateMachine(typeof(_TooltipOnPanel_d__16))]
		private IEnumerator TooltipOnPanel(Action open, string panelKey, string shot, int pick); // 0x0000000180642230-0x0000000180642300
		[IteratorStateMachine(typeof(_Shot_d__17))]
		private IEnumerator Shot(string name); // 0x0000000180641F70-0x0000000180642000
		private static string Stats(); // 0x00000001806420B0-0x00000001806420E0
		private static Transform FindDeep(Transform root, string name); // 0x0000000180640F40-0x0000000180641010
		private void Line(string s); // 0x0000000180641160-0x00000001806411F0
		private void Finish(); // 0x0000000180641010-0x0000000180641160
	}
}
