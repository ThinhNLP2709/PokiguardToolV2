/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class NativeListExtensions // TypeDefIndex: 11577
	{
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static bool ArraysEqual<T>(this NativeArray<T> container, [IsReadOnly] in NativeList<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static bool ArraysEqual<T>(this NativeList<T> container, [IsReadOnly] in NativeArray<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static bool ArraysEqual<T>(this NativeList<T> container, [IsReadOnly] in NativeList<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static bool ArraysEqual<T>(this NativeList<T> container, [IsReadOnly] in UnsafeList<T> other)
			where T : struct, IEquatable<T>;
	}
}
