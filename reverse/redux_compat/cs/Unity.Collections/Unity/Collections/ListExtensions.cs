/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public static class ListExtensions // TypeDefIndex: 11548
	{
		// Extension methods
		public static bool RemoveSwapBack<T>(this List<T> list, T value);
		public static bool RemoveSwapBack<T>(this List<T> list, Predicate<T> matcher);
		public static void RemoveAtSwapBack<T>(this List<T> list, int index);
		public static NativeList<T> ToNativeList<T>(this List<T> list, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		public static NativeArray<T> ToNativeArray<T>(this List<T> list, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
	}
}
