/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public class ItemStore : PagedStore<PokyHome.InfoPlayer.InventoryItemDTO> // TypeDefIndex: 2860
	{
		// Fields
		[CompilerGenerated]
		private long _TotalAmount_k__BackingField; // 0x38
		private static readonly string[] HIDDEN_RESOURCE_CODES; // 0x00
	
		// Properties
		public long TotalAmount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x0000000180D11840-0x0000000180D11850
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2861
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<KeyValuePair<int, InventoryItemDTO>> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D12310-0x0000000180D123B0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal int _Sort_b__9_0(KeyValuePair<int, InventoryItemDTO> a, KeyValuePair<int, InventoryItemDTO> b); // 0x0000000180D123B0-0x0000000180D12490
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2862
		{
			// Fields
			public ItemStore __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(InventoryDTO resp); // 0x0000000180D12490-0x0000000180D12690
			internal void _Fetch_b__1(string err); // 0x0000000180D12690-0x0000000180D12750
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_1 // TypeDefIndex: 2863
		{
			// Fields
			public InventoryDTO resp; // 0x10
			public __c__DisplayClass5_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass5_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__2(); // 0x0000000180D12750-0x0000000180D128C0
		}
	
		[CompilerGenerated]
		private sealed class _Fetch_d__5 : IEnumerator<object> // TypeDefIndex: 2864
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ItemStore __4__this; // 0x20
			public int rid; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Fetch_d__5(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180D128C0-0x0000000180D12C60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D12C60-0x0000000180D12CA0
		}
	
		// Constructors
		public ItemStore(); // 0x0000000180D120C0-0x0000000180D12100
		static ItemStore(); // 0x0000000180D12100-0x0000000180D12240
	
		// Methods
		public override void Reset(); // 0x0000000180D11850-0x0000000180D118B0
		[IteratorStateMachine(typeof(_Fetch_d__5))]
		protected override IEnumerator Fetch(int rid); // 0x0000000180D118B0-0x0000000180D11960
		private static bool IsHiddenResource(InventoryItemDTO d); // 0x0000000180D11960-0x0000000180D11AF0
		private void Apply(InventoryDTO resp); // 0x0000000180D11AF0-0x0000000180D11C40
		protected override void Sort(); // 0x0000000180D11C40-0x0000000180D120C0
	}
}
