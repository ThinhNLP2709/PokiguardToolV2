/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[DebuggerDisplay("{ToString(),raw}")]
	[DebuggerTypeProxy(typeof(SpanDebugView<T>))]
	[IsByRefLike]
	[IsReadOnly]
	[NonVersionable]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	public struct Span<T> // TypeDefIndex: 2334
	{
		// Fields
		internal readonly ByReference<T> _pointer;
		private readonly int _length;
	
		// Properties
		public ref T this[int index] { [Intrinsic] [NonVersionable] get => default; }
		public int Length { [NonVersionable] get; }
	
		// Constructors
		public Span(T[] array);
		public Span(T[] array, int start, int length);
		[CLSCompliant(false)]
		public unsafe Span(void* pointer, int length);
		internal Span(ref ref T ptr, int length);
	
		// Methods
		public ref ref T GetPinnableReference();
		public void Clear();
		public void Fill(T value);
		public void CopyTo(Span<T> destination);
		public bool TryCopyTo(Span<T> destination);
		public static bool operator ==(Span<T> left, Span<T> right);
		public static implicit operator ReadOnlySpan<T>(Span<T> span);
		public override string ToString();
		public Span<T> Slice(int start);
		public Span<T> Slice(int start, int length);
		public T[] ToArray();
		[Obsolete("Equals() on Span will always throw an exception. Use == instead.")]
		public override bool Equals(object obj);
		[Obsolete("GetHashCode() on Span will always throw an exception.")]
		public override int GetHashCode();
		public static implicit operator Span<T>(T[] array);
	}
}
