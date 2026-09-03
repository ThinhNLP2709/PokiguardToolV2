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
	internal class ArraySliceFilter : PathFilter // TypeDefIndex: 10349
	{
		// Fields
		[CompilerGenerated]
		private int? _Start_k__BackingField; // 0x10
		[CompilerGenerated]
		private int? _End_k__BackingField; // 0x18
		[CompilerGenerated]
		private int? _Step_k__BackingField; // 0x20
	
		// Properties
		public int? Start { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x0000000180719060-0x0000000180719070
		public int? End { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001804C2E30-0x00000001804C2E40
		public int? Step { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ExecuteFilter_d__12 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10350
		{
			// Fields
			private int __1__state; // 0x10
			[Nullable(1)]
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public ArraySliceFilter __4__this; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerable<JToken> current; // 0x30
			[Nullable(new byte[2] {0, 1 })]
			public IEnumerable<JToken> __3__current; // 0x38
			private JsonSelectSettings settings; // 0x40
			public JsonSelectSettings __3__settings; // 0x48
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x50
			private JArray _a_5__3; // 0x58
			private int _stepCount_5__4; // 0x60
			private int _stopIndex_5__5; // 0x64
			private bool _positiveStep_5__6; // 0x68
			private int _i_5__7; // 0x6C
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ExecuteFilter_d__12(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018176BB50-0x000000018176BBF0
			private bool MoveNext(); // 0x000000018176B150-0x000000018176BA50
			private void __m__Finally1(); // 0x000000018176BBF0-0x000000018176BC40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018176BB10-0x000000018176BB50
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x000000018176BA50-0x000000018176BB10
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018176BA50-0x000000018176BB10
		}
	
		// Constructors
		public ArraySliceFilter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[IteratorStateMachine(typeof(_ExecuteFilter_d__12))]
		[NullableContext(1)]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181755FE0-0x0000000181756090
		private bool IsValid(int index, int stopIndex, bool positiveStep); // 0x0000000181756090-0x00000001817560B0
	}
}
