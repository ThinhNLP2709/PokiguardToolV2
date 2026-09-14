/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	public class ItemStore : PagedStore<PokyHome.InfoPlayer.InventoryItemDTO> // TypeDefIndex: 2853
	{
		// Fields
		[CompilerGenerated]
		private long _TotalAmount_k__BackingField; // 0x38
		private static readonly string[] HIDDEN_RESOURCE_CODES; // 0x00
	
		// Properties
		public long TotalAmount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x0000000180D03EE0-0x0000000180D03EF0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2854
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<KeyValuePair<int, InventoryItemDTO>> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D048E0-0x0000000180D04980
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal int _Sort_b__9_0(KeyValuePair<int, InventoryItemDTO> a, KeyValuePair<int, InventoryItemDTO> b); // 0x0000000180D04980-0x0000000180D04A60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2855
		{
			// Fields
			public ItemStore __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(InventoryDTO resp); // 0x0000000180D04A60-0x0000000180D04C60
			internal void _Fetch_b__1(string err); // 0x0000000180D04C60-0x0000000180D04D20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_1 // TypeDefIndex: 2856
		{
			// Fields
			public InventoryDTO resp; // 0x10
			public __c__DisplayClass5_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass5_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__2(); // 0x0000000180D04D20-0x0000000180D04E90
		}
	
		[CompilerGenerated]
		private sealed class _Fetch_d__5 : IEnumerator<object> // TypeDefIndex: 2857
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180D04E90-0x0000000180D05200
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D05200-0x0000000180D05240
		}
	
		// Constructors
		public ItemStore(); // 0x0000000180D04760-0x0000000180D047A0
		static ItemStore(); // 0x0000000180D047A0-0x0000000180D048E0
	
		// Methods
		public override void Reset(); // 0x0000000180D03EF0-0x0000000180D03F50
		[IteratorStateMachine(typeof(_Fetch_d__5))]
		protected override IEnumerator Fetch(int rid); // 0x0000000180D03F50-0x0000000180D04000
		private static bool IsHiddenResource(InventoryItemDTO d); // 0x0000000180D04000-0x0000000180D04190
		private void Apply(InventoryDTO resp); // 0x0000000180D04190-0x0000000180D042E0
		protected override void Sort(); // 0x0000000180D042E0-0x0000000180D04760
	}
}
