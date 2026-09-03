/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.NotBurstCompatible
{
	public static class Extensions // TypeDefIndex: 11674
	{
		// Extension methods
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public static T[] ToArray<T>(this NativeHashSet<T> set)
			where T : struct, IEquatable<T>;
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public static T[] ToArray<T>(this NativeParallelHashSet<T> set)
			where T : struct, IEquatable<T>;
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public static T[] ToArrayNBC<T>(this NativeList<T> list)
			where T : struct;
		[ExcludeFromBurstCompatTesting("Takes managed array")]
		public static void CopyFromNBC<T>(this NativeList<T> list, T[] array)
			where T : struct;
	}
}
