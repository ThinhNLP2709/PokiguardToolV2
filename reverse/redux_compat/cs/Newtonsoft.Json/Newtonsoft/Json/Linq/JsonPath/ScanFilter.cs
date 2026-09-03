/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq.JsonPath
{
	[Nullable(0)]
	[NullableContext(2)]
	internal class ScanFilter : PathFilter // TypeDefIndex: 10367
	{
		// Fields
		internal string Name; // 0x10
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ExecuteFilter_d__2 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10368
		{
			// Fields
			private int __1__state; // 0x10
			[Nullable(1)]
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerable<JToken> current; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			public IEnumerable<JToken> __3__current; // 0x30
			[Nullable(0)]
			public ScanFilter __4__this; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x40
			[Nullable(0)]
			private JToken _c_5__3; // 0x48
			[Nullable(0)]
			private JToken _value_5__4; // 0x50
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ExecuteFilter_d__2(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018176EA30-0x000000018176EAE0
			private bool MoveNext(); // 0x000000018176C610-0x000000018176C9E0
			private void __m__Finally1(); // 0x000000018176EE10-0x000000018176EE60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018176E2D0-0x000000018176E310
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x000000018176DE50-0x000000018176DF00
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018176DE50-0x000000018176DF00
		}
	
		// Constructors
		public ScanFilter(string name); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[IteratorStateMachine(typeof(_ExecuteFilter_d__2))]
		[NullableContext(1)]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings); // 0x000000018176B030-0x000000018176B0C0
	}
}
