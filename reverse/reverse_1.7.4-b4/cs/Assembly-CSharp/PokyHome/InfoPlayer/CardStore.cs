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
	public class CardStore : PagedStore<PokyHome.InfoPlayer.UserCardDTO> // TypeDefIndex: 2865
	{
		// Fields
		[CompilerGenerated]
		private long _TotalCards_k__BackingField; // 0x38
	
		// Properties
		public long TotalCards { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x0000000180D11840-0x0000000180D11850
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2866
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<UserCardDTO> __9__7_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D131A0-0x0000000180D13240
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal int _Sort_b__7_0(UserCardDTO a, UserCardDTO b); // 0x0000000180D13240-0x0000000180D132A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2867
		{
			// Fields
			public CardStore __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(List<UserCardDTO> resp); // 0x0000000180D132A0-0x0000000180D134A0
			internal void _Fetch_b__1(string err); // 0x0000000180D134A0-0x0000000180D13560
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_1 // TypeDefIndex: 2868
		{
			// Fields
			public List<UserCardDTO> resp; // 0x10
			public __c__DisplayClass5_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass5_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__2(); // 0x0000000180D13560-0x0000000180D13670
		}
	
		[CompilerGenerated]
		private sealed class _Fetch_d__5 : IEnumerator<object> // TypeDefIndex: 2869
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public CardStore __4__this; // 0x20
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
			private bool MoveNext(); // 0x0000000180D13670-0x0000000180D13920
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D13920-0x0000000180D13960
		}
	
		// Constructors
		public CardStore(); // 0x0000000180D13160-0x0000000180D131A0
	
		// Methods
		public override void Reset(); // 0x0000000180D11850-0x0000000180D118B0
		[IteratorStateMachine(typeof(_Fetch_d__5))]
		protected override IEnumerator Fetch(int rid); // 0x0000000180D12CA0-0x0000000180D12D50
		private void Apply(List<UserCardDTO> resp); // 0x0000000180D12D50-0x0000000180D12E50
		protected override void Sort(); // 0x0000000180D12E50-0x0000000180D13090
		public static string SafeName(UserCardDTO d); // 0x0000000180D13090-0x0000000180D13160
	}
}
