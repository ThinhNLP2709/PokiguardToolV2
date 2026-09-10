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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public class PokyFxSelfTest : MonoBehaviour // TypeDefIndex: 2229
	{
		// Fields
		public const string PREF_KEY = "PokyFxSelfTest"; // Metadata: 0x0068E291
		public const string REPORT_PATH = "Temp/PokyFxSelfTest.txt"; // Metadata: 0x0068E2A0
		public const string SHOT_DIR = "Temp/PokySkinShots"; // Metadata: 0x0068E2B8
		private const float WAIT_HUB_SEC = 90f; // Metadata: 0x0068E2CB
		private const float WAIT_HUB_READY_SEC = 6f; // Metadata: 0x0068E2CF
		private const float SETTLE_SEC = 1.2f; // Metadata: 0x0068E2D3
		private const float SHOT_SEC = 0.6f; // Metadata: 0x0068E2D7
		private const int CYCLES = 10; // Metadata: 0x0068E2DB
		private readonly StringBuilder _report; // 0x20
		private int _fail; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Run_d__11 : IEnumerator<object> // TypeDefIndex: 2230
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private float _t0_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807913E0-0x0000000180791E30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180791E30-0x0000000180791E70
		}
	
		[CompilerGenerated]
		private sealed class _Shot_d__17 : IEnumerator<object> // TypeDefIndex: 2231
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string name; // 0x20
			public PokyFxSelfTest __4__this; // 0x28
			private string _path_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Shot_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x0000000180791E70-0x0000000180792060
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180792060-0x00000001807920A0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelFx_d__14 : IEnumerator<object> // TypeDefIndex: 2232
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelFx_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
			private bool MoveNext(); // 0x00000001807920A0-0x0000000180792970
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180792970-0x00000001807929B0
		}
	
		[CompilerGenerated]
		private sealed class _TestPanelTooltips_d__15 : IEnumerator<object> // TypeDefIndex: 2233
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private ManagerQuangTruong _hub_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _TestPanelTooltips_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x00000001807929B0-0x0000000180792CC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180792CC0-0x0000000180792D00
		}
	
		[CompilerGenerated]
		private sealed class _TestTooltips_d__12 : IEnumerator<object> // TypeDefIndex: 2234
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyFxSelfTest __4__this; // 0x20
			private GameObject _anchorGo_5__2; // 0x28
			private RectTransform _anchor_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _TestTooltips_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
			private bool MoveNext(); // 0x0000000180792D00-0x0000000180793670
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180793670-0x00000001807936B0
		}
	
		[CompilerGenerated]
		private sealed class _TooltipOnPanel_d__16 : IEnumerator<object> // TypeDefIndex: 2235
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _TooltipOnPanel_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001807944D0-0x0000000180794510
			private bool MoveNext(); // 0x00000001807936B0-0x0000000180794490
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180794490-0x00000001807944D0
		}
	
		// Constructors
		public PokyFxSelfTest(); // 0x000000018077FCD0-0x000000018077FD20
	
		// Methods
		private void Start(); // 0x000000018077F9D0-0x000000018077FA80
		[IteratorStateMachine(typeof(_Run_d__11))]
		private IEnumerator Run(); // 0x000000018077F8D0-0x000000018077F940
		[IteratorStateMachine(typeof(_TestTooltips_d__12))]
		private IEnumerator TestTooltips(); // 0x000000018077FB90-0x000000018077FC00
		private void ReportTooltip(string goName, string label); // 0x000000018077EBC0-0x000000018077F8D0
		[IteratorStateMachine(typeof(_TestPanelFx_d__14))]
		private IEnumerator TestPanelFx(); // 0x000000018077FAB0-0x000000018077FB20
		[IteratorStateMachine(typeof(_TestPanelTooltips_d__15))]
		private IEnumerator TestPanelTooltips(); // 0x000000018077FB20-0x000000018077FB90
		[IteratorStateMachine(typeof(_TooltipOnPanel_d__16))]
		private IEnumerator TooltipOnPanel(Action open, string panelKey, string shot, int pick); // 0x000000018077FC00-0x000000018077FCD0
		[IteratorStateMachine(typeof(_Shot_d__17))]
		private IEnumerator Shot(string name); // 0x000000018077F940-0x000000018077F9D0
		private static string Stats(); // 0x000000018077FA80-0x000000018077FAB0
		private static Transform FindDeep(Transform root, string name); // 0x000000018077E910-0x000000018077E9E0
		private void Line(string s); // 0x000000018077EB30-0x000000018077EBC0
		private void Finish(); // 0x000000018077E9E0-0x000000018077EB30
	}
}
