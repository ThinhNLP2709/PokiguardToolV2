/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	internal class ConcurrentMask // TypeDefIndex: 11486
	{
		// Fields
		internal const int ErrorFailedToFree = -1; // Metadata: 0x006A1BDF
		internal const int ErrorFailedToAllocate = -2; // Metadata: 0x006A1BE0
		internal const int ErrorAllocationCrossesWordBoundary = -3; // Metadata: 0x006A1BE1
		internal const int EmptyBeforeAllocation = 0; // Metadata: 0x006A1BE2
		internal const int EmptyAfterFree = 0; // Metadata: 0x006A1BE3
	
		// Constructors
		public ConcurrentMask(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal static long AtomicOr(ref long destination, long source); // 0x0000000181C8CF30-0x0000000181C8CF70
		internal static long AtomicAnd(ref long destination, long source); // 0x0000000181C8CEF0-0x0000000181C8CF30
		internal static void longestConsecutiveOnes(long value, out int offset, out int count); // 0x0000000181C8D5D0-0x0000000181C8D670
		internal static bool foundAtLeastThisManyConsecutiveOnes(long value, int minimum, out int offset, out int count); // 0x0000000181C8D340-0x0000000181C8D480
		internal static bool foundAtLeastThisManyConsecutiveZeroes(long value, int minimum, out int offset, out int count); // 0x0000000181C8D480-0x0000000181C8D5D0
		internal static bool Succeeded(int error); // 0x0000000181C8CFA0-0x0000000181C8CFB0
		internal static long MakeMask(int offset, int bits); // 0x0000000181C8CF70-0x0000000181C8CFA0
		internal static int TryAllocate(ref long l, int offset, int bits); // 0x0000000181C8D1A0-0x0000000181C8D260
		internal static int TryFree(ref long l, int offset, int bits); // 0x0000000181C8D260-0x0000000181C8D340
		internal static int TryAllocate(ref long l, out int offset, int bits); // 0x0000000181C8CFB0-0x0000000181C8D1A0
		internal static int TryAllocate<T>(ref ref T t, int offset, int bits)
			where T : IIndexable<long>;
		internal static int TryFree<T>(ref ref T t, int offset, int bits)
			where T : IIndexable<long>;
		internal static int TryAllocate<T>(ref ref T t, out int offset, int begin, int end, int bits)
			where T : IIndexable<long>;
		internal static int TryAllocate<T>(ref ref T t, out int offset, int begin, int bits)
			where T : IIndexable<long>;
		internal static int TryAllocate<T>(ref ref T t, out int offset, int bits)
			where T : IIndexable<long>;
	}
}
