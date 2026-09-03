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

namespace System.Runtime.InteropServices
{
	public static class MemoryMarshal // TypeDefIndex: 3119
	{
		// Methods
		public static Span<byte> AsBytes<T>(Span<T> span)
			where T : struct;
		public static ReadOnlySpan<byte> AsBytes<T>(ReadOnlySpan<T> span)
			where T : struct;
		public static Memory<T> AsMemory<T>(ReadOnlyMemory<T> memory);
		public static ref ref T GetReference<T>(Span<T> span);
		public static ref ref T GetReference<T>(ReadOnlySpan<T> span);
		internal static ref ref T GetNonNullPinnableReference<T>(Span<T> span);
		internal static ref ref T GetNonNullPinnableReference<T>(ReadOnlySpan<T> span);
		public static ReadOnlySpan<T> CreateReadOnlySpan<T>(ref ref T reference, int length);
		public static bool TryGetArray<T>(ReadOnlyMemory<T> memory, out ArraySegment<T> segment);
	}
}
