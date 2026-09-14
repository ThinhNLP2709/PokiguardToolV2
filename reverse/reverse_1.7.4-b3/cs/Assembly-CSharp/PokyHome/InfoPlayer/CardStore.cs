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
	public class CardStore : PagedStore<PokyHome.InfoPlayer.UserCardDTO> // TypeDefIndex: 2858
	{
		// Fields
		[CompilerGenerated]
		private long _TotalCards_k__BackingField; // 0x38
	
		// Properties
		public long TotalCards { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x0000000180D03EE0-0x0000000180D03EF0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2859
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<UserCardDTO> __9__7_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000180D05740-0x0000000180D057E0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal int _Sort_b__7_0(UserCardDTO a, UserCardDTO b); // 0x0000000180D057E0-0x0000000180D05840
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2860
		{
			// Fields
			public CardStore __4__this; // 0x10
			public int rid; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__0(List<UserCardDTO> resp); // 0x0000000180D05840-0x0000000180D05A40
			internal void _Fetch_b__1(string err); // 0x0000000180D05A40-0x0000000180D05B00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_1 // TypeDefIndex: 2861
		{
			// Fields
			public List<UserCardDTO> resp; // 0x10
			public __c__DisplayClass5_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass5_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fetch_b__2(); // 0x0000000180D05B00-0x0000000180D05C10
		}
	
		[CompilerGenerated]
		private sealed class _Fetch_d__5 : IEnumerator<object> // TypeDefIndex: 2862
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180D05C10-0x0000000180D05EA0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D05EA0-0x0000000180D05EE0
		}
	
		// Constructors
		public CardStore(); // 0x0000000180D05700-0x0000000180D05740
	
		// Methods
		public override void Reset(); // 0x0000000180D03EF0-0x0000000180D03F50
		[IteratorStateMachine(typeof(_Fetch_d__5))]
		protected override IEnumerator Fetch(int rid); // 0x0000000180D05240-0x0000000180D052F0
		private void Apply(List<UserCardDTO> resp); // 0x0000000180D052F0-0x0000000180D053F0
		protected override void Sort(); // 0x0000000180D053F0-0x0000000180D05630
		public static string SafeName(UserCardDTO d); // 0x0000000180D05630-0x0000000180D05700
	}
}
