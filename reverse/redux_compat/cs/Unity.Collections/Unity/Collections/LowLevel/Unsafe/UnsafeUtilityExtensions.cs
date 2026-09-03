/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	public static class UnsafeUtilityExtensions // TypeDefIndex: 11754
	{
		// Methods
		internal static unsafe void MemSwap(void* ptr, void* otherPtr, long size); // 0x0000000181CAD210-0x0000000181CAD2D0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe T ReadArrayElementBoundsChecked<T>(void* source, int index, int capacity)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe void WriteArrayElementBoundsChecked<T>(void* destination, int index, T value, int capacity)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe void* AddressOf<T>([IsReadOnly] in ref T value)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static ref ref T AsRef<T>([IsReadOnly] in ref T value)
			where T : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static unsafe void CheckMemSwapOverlap(byte* dst, byte* src, long size); // 0x0000000181CAD1A0-0x0000000181CAD210
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckIndexRange(int index, int capacity); // 0x0000000181CAD0D0-0x0000000181CAD1A0
	}
}
