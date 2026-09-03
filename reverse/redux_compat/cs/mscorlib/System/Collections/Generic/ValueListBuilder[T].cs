/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[DefaultMember("Item")]
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct ValueListBuilder<T> // TypeDefIndex: 3586
	{
		// Fields
		private Span<T> _span;
		private T[] _arrayFromPool;
		private int _pos;
	
		// Properties
		public int Length { get; }
	
		// Constructors
		public ValueListBuilder(Span<T> initialSpan);
	
		// Methods
		public void Append(T item);
		public ReadOnlySpan<T> AsSpan();
		public void Dispose();
		private void Grow();
	}
}
