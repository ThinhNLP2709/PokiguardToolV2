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
	internal class ArrayIndexFilter : PathFilter // TypeDefIndex: 10345
	{
		// Fields
		[CompilerGenerated]
		private int? _Index_k__BackingField; // 0x10
	
		// Properties
		public int? Index { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x0000000180719060-0x0000000180719070
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ExecuteFilter_d__4 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10346
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
			public ArrayIndexFilter __4__this; // 0x38
			private JsonSelectSettings settings; // 0x40
			public JsonSelectSettings __3__settings; // 0x48
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x50
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap2; // 0x58
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ExecuteFilter_d__4(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018176F520-0x000000018176F6A0
			private bool MoveNext(); // 0x000000018176EF70-0x000000018176F420
			private void __m__Finally1(); // 0x000000018176F6A0-0x000000018176F6F0
			private void __m__Finally2(); // 0x000000018176F6F0-0x000000018176F740
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018176F4E0-0x000000018176F520
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x000000018176F420-0x000000018176F4E0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018176F420-0x000000018176F4E0
		}
	
		// Constructors
		public ArrayIndexFilter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[IteratorStateMachine(typeof(_ExecuteFilter_d__4))]
		[NullableContext(1)]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181755E80-0x0000000181755F30
	}
}
