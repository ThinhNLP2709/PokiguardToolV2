/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections.LowLevel.Unsafe
{
	public static class NativeArrayUnsafeUtility // TypeDefIndex: 7451
	{
		// Methods
		public static unsafe NativeArray<T> ConvertExistingDataToNativeArray<T>(void* dataPointer, int length, Allocator allocator)
			where T : struct;
		public static NativeArray<T> ConvertExistingDataToNativeArray<T>(Span<T> data, Allocator allocator)
			where T : struct;
		public static unsafe void* GetUnsafeBufferPointerWithoutChecks<T>(NativeArray<T> nativeArray)
			where T : struct;
	
		// Extension methods
		public static unsafe void* GetUnsafePtr<T>(this NativeArray<T> nativeArray)
			where T : struct;
		public static unsafe void* GetUnsafeReadOnlyPtr<T>(this NativeArray<T> nativeArray)
			where T : struct;
	}
}
