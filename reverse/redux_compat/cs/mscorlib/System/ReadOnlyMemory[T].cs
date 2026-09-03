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

namespace System
{
	[DebuggerDisplay("{ToString(),raw}")]
	[DebuggerTypeProxy(typeof(MemoryDebugView<T>))]
	[IsReadOnly]
	public struct ReadOnlyMemory<T> : IEquatable<System.ReadOnlyMemory<T>> // TypeDefIndex: 2327
	{
		// Fields
		private readonly object _object;
		private readonly int _index;
		private readonly int _length;
	
		// Properties
		public int Length { get; }
		public ReadOnlySpan<T> Span { get; }
	
		// Constructors
		public ReadOnlyMemory(T[] array);
		public ReadOnlyMemory(T[] array, int start, int length);
	
		// Methods
		public override string ToString();
		public override bool Equals(object obj);
		public bool Equals(ReadOnlyMemory<T> other);
		public override int GetHashCode();
		private static int CombineHashCodes(int left, int right);
		private static int CombineHashCodes(int h1, int h2, int h3);
		internal object GetObjectStartLength(out int start, out int length);
	}
}
