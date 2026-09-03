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
	[NullableContext(1)]
	internal class ScanMultipleFilter : PathFilter // TypeDefIndex: 10369
	{
		// Fields
		private List<string> _names; // 0x10
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ExecuteFilter_d__2 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10370
		{
			// Fields
			private int __1__state; // 0x10
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerable<JToken> current; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			public IEnumerable<JToken> __3__current; // 0x30
			[Nullable(0)]
			public ScanMultipleFilter __4__this; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x40
			[Nullable(0)]
			private JToken _c_5__3; // 0x48
			[Nullable(0)]
			private JToken _value_5__4; // 0x50
			[Nullable(0)]
			private JProperty _property_5__5; // 0x58
			[Nullable(new byte[2] {0, 1 })]
			private List<string> __7__wrap5; // 0x60
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ExecuteFilter_d__2(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018176E310-0x000000018176E460
			private bool MoveNext(); // 0x000000018176D760-0x000000018176DC10
			private void __m__Finally1(); // 0x000000018176EC80-0x000000018176ECD0
			private void __m__Finally2(); // 0x000000018176EE60-0x000000018176EE80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018176E190-0x000000018176E1D0
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x000000018176DC10-0x000000018176DCC0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018176DC10-0x000000018176DCC0
		}
	
		// Constructors
		public ScanMultipleFilter(List<string> names); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[IteratorStateMachine(typeof(_ExecuteFilter_d__2))]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings); // 0x000000018176B0C0-0x000000018176B150
	}
}
