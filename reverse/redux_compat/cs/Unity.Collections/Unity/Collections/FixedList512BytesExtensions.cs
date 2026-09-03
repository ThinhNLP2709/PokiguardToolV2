/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class FixedList512BytesExtensions // TypeDefIndex: 11510
	{
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static int IndexOf<T, U>(this ref FixedList512Bytes<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Contains<T, U>(this ref FixedList512Bytes<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Remove<T, U>(this ref FixedList512Bytes<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool RemoveSwapBack<T, U>(this ref FixedList512Bytes<T> container, U value)
			where T : struct, IEquatable<U>;
	}
}
