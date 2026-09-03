/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class StackGuard // TypeDefIndex: 12137
	{
		// Fields
		private int _executionStackCount; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__3<T1, T2> // TypeDefIndex: 12138
		{
			// Fields
			public static readonly __c__3<T1, T2> __9;
			public static Func<object, object> __9__3_0;
	
			// Constructors
			static __c__3();
			public __c__3();
	
			// Methods
			internal object _RunOnEmptyStack_b__3_0(object s);
		}
	
		// Constructors
		public StackGuard(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool TryEnterOnCurrentStack(); // 0x00000001817C0720-0x00000001817C0790
		public void RunOnEmptyStack<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2);
		private R RunOnEmptyStackCore<R>(Func<object, R> action, object state);
	}
}
