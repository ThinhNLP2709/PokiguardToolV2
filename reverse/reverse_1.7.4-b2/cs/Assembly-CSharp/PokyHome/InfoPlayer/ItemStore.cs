/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public class ItemStore : PagedStore<PokyHome.InfoPlayer.InventoryItemDTO> // TypeDefIndex: 2408
	{
		// Fields
		[CompilerGenerated]
		private long _TotalAmount_k__BackingField; // 0x38
		private static readonly string[] HIDDEN_RESOURCE_CODES; // 0x00
	
		// Properties
		public long TotalAmount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AB0-0x0000000180308AC0 0x00000001807DCCF0-0x00000001807DCD00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2409
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<KeyValuePair<int, InventoryItemDTO>> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001807F6810-0x00000001807F6880
			public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal int _Sort_b__9_0(KeyValuePair<int, InventoryItemDTO> a, KeyValuePair<int, InventoryItemDTO> b); // 0x00000001807F54D0-0x00000001807F55F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2410
		{
			// Fields
			public ItemStore __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Fetch_b__0(InventoryDTO resp); // 0x00000001807F5E30-0x00000001807F5F20
			internal void _Fetch_b__1(string err); // 0x00000001807F5F20-0x00000001807F5FD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_1 // TypeDefIndex: 2411
		{
			// Fields
			public InventoryDTO resp; // 0x10
			public __c__DisplayClass5_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass5_1(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Fetch_b__2(); // 0x00000001807F6160-0x00000001807F62D0
		}
	
		[CompilerGenerated]
		private sealed class _Fetch_d__5 : IEnumerator<object> // TypeDefIndex: 2412
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ItemStore __4__this; // 0x20
			public int rid; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Fetch_d__5(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807F4AF0-0x00000001807F4CC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F4D00-0x00000001807F4D40
		}
	
		// Constructors
		public ItemStore(); // 0x00000001807F2190-0x00000001807F21D0
		static ItemStore(); // 0x00000001807F2090-0x00000001807F2190
	
		// Methods
		public override void Reset(); // 0x00000001807DCAA0-0x00000001807DCAC0
		[IteratorStateMachine(typeof(_Fetch_d__5))]
		protected override IEnumerator Fetch(int rid); // 0x00000001807F1BA0-0x00000001807F1C20
		private static bool IsHiddenResource(InventoryItemDTO d); // 0x00000001807F1C20-0x00000001807F1D40
		private void Apply(InventoryDTO resp); // 0x00000001807F1A50-0x00000001807F1BA0
		protected override void Sort(); // 0x00000001807F1D40-0x00000001807F2090
	}
}
