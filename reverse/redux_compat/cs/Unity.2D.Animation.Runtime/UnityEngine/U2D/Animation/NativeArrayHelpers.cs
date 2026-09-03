/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal static class NativeArrayHelpers // TypeDefIndex: 14371
	{
		// Methods
		public static void ResizeIfNeeded<T>(ref NativeArray<T> nativeArray, int size, Allocator allocator = Allocator.Persistent /* Metadata: 0x006A96C3 */, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A96C4 */)
			where T : struct;
		public static void ResizeAndCopyIfNeeded<T>(ref NativeArray<T> nativeArray, int size, Allocator allocator = Allocator.Persistent /* Metadata: 0x006A96C5 */, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A96C6 */)
			where T : struct;
	
		// Extension methods
		public static void DisposeIfCreated<T>(this ref NativeArray<T> nativeArray)
			where T : struct;
		[WriteAccessRequired]
		public static void CopyFromNativeSlice<T, S>(this NativeArray<T> nativeArray, int dstStartIndex, int dstEndIndex, NativeSlice<S> slice, int srcStartIndex, int srcEndIndex)
			where T : struct
			where S : struct;
	}
}
