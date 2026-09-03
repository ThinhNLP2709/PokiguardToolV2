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
	public struct ReadOnlySpan<T> // TypeDefIndex: 2328
	{
		// Fields
		internal readonly ByReference<T> _pointer;
		private readonly int _length;
	
		// Properties
		[IsReadOnly]
		public ref T this[int index] { [NonVersionable] [Intrinsic] get => default; }
		public int Length { [NonVersionable] get; }
		public bool IsEmpty { [NonVersionable] get; }
		public static ReadOnlySpan<T> Empty { get; }
	
		// Constructors
		public ReadOnlySpan(T[] array);
		public ReadOnlySpan(T[] array, int start, int length);
		[CLSCompliant(false)]
		public unsafe ReadOnlySpan(void* pointer, int length);
		internal ReadOnlySpan(ref ref T ptr, int length);
	
		// Methods
		public ref ref T GetPinnableReference();
		public void CopyTo(Span<T> destination);
		public bool TryCopyTo(Span<T> destination);
		public static bool operator ==(ReadOnlySpan<T> left, ReadOnlySpan<T> right);
		public override string ToString();
		public ReadOnlySpan<T> Slice(int start);
		public ReadOnlySpan<T> Slice(int start, int length);
		public T[] ToArray();
		public static bool operator !=(ReadOnlySpan<T> left, ReadOnlySpan<T> right);
		[Obsolete("Equals() on ReadOnlySpan will always throw an exception. Use == instead.")]
		public override bool Equals(object obj);
		[Obsolete("GetHashCode() on ReadOnlySpan will always throw an exception.")]
		public override int GetHashCode();
		public static implicit operator ReadOnlySpan<T>(T[] array);
	}
}
