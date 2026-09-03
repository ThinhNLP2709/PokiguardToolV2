/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Generic
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct ValueListBuilder<T> // TypeDefIndex: 8968
	{
		// Fields
		private Span<T> _span;
		private T[] _arrayFromPool;
		private int _pos;
	
		// Properties
		public int Length { get; }
		public ref T this[int index] { get => default; }
	
		// Constructors
		public ValueListBuilder(Span<T> initialSpan);
	
		// Methods
		public void Append(T item);
		public ReadOnlySpan<T> AsSpan();
		public void Dispose();
		private void Grow();
		public T Pop();
	}
}
