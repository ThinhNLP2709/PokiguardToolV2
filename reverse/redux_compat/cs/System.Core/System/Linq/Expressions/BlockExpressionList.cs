/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal class BlockExpressionList : IList<Expression> // TypeDefIndex: 12061
	{
		// Fields
		private readonly BlockExpression _block; // 0x10
		private readonly Expression _arg0; // 0x18
	
		// Properties
		public Expression this[int index] { get => default; [ExcludeFromCodeCoverage] set {} } // 0x00000001817AAAC0-0x00000001817AAB00 0x00000001817AAB00-0x00000001817AAB30
		public int Count { get; } // 0x0000000181501AA0-0x0000000181501AD0 
		[ExcludeFromCodeCoverage]
		public bool IsReadOnly { get; } // 0x00000001817AAA90-0x00000001817AAAC0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__18 : IEnumerator<Expression> // TypeDefIndex: 12062
		{
			// Fields
			private int __1__state; // 0x10
			private Expression __2__current; // 0x18
			public BlockExpressionList __4__this; // 0x20
			private int _i_5__2; // 0x28
	
			// Properties
			Expression IEnumerator<System.Linq.Expressions.Expression>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001817C3070-0x00000001817C3180
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001817C3180-0x00000001817C31C0
		}
	
		// Constructors
		internal BlockExpressionList(BlockExpression provider, Expression arg0); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public int IndexOf(Expression item); // 0x00000001817AA950-0x00000001817AAA00
		[ExcludeFromCodeCoverage]
		public void Insert(int index, Expression item); // 0x00000001817AAA00-0x00000001817AAA30
		[ExcludeFromCodeCoverage]
		public void RemoveAt(int index); // 0x00000001817AAA30-0x00000001817AAA60
		[ExcludeFromCodeCoverage]
		public void Add(Expression item); // 0x00000001817AA5A0-0x00000001817AA5D0
		[ExcludeFromCodeCoverage]
		public void Clear(); // 0x00000001817AA5D0-0x00000001817AA600
		public bool Contains(Expression item); // 0x00000001817AA600-0x00000001817AA6B0
		public void CopyTo(Expression[] array, int index); // 0x00000001817AA6B0-0x00000001817AA8E0
		[ExcludeFromCodeCoverage]
		public bool Remove(Expression item); // 0x00000001817AAA60-0x00000001817AAA90
		[IteratorStateMachine(typeof(_GetEnumerator_d__18))]
		public IEnumerator<Expression> GetEnumerator(); // 0x00000001817AA8E0-0x00000001817AA950
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817AA8E0-0x00000001817AA950
	}
}
