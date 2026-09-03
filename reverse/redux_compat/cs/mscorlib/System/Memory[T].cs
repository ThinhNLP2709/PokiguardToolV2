/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Buffers;
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
	public struct Memory<T> : IEquatable<System.Memory<T>> // TypeDefIndex: 2300
	{
		// Fields
		private readonly object _object;
		private readonly int _index;
		private readonly int _length;
	
		// Properties
		public int Length { get; }
		public Span<T> Span { get; }
	
		// Constructors
		public Memory(T[] array);
		public Memory(T[] array, int start, int length);
		internal Memory(object obj, int start, int length);
	
		// Methods
		public static implicit operator Memory<T>(T[] array);
		public static implicit operator ReadOnlyMemory<T>(Memory<T> memory);
		public override string ToString();
		public Memory<T> Slice(int start, int length);
		public MemoryHandle Pin();
		public T[] ToArray();
		public override bool Equals(object obj);
		public bool Equals(Memory<T> other);
		public override int GetHashCode();
		private static int CombineHashCodes(int left, int right);
		private static int CombineHashCodes(int h1, int h2, int h3);
	}
}
