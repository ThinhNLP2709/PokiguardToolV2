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
	public static class NativeSliceUnsafeUtility // TypeDefIndex: 7452
	{
		// Methods
		public static unsafe NativeSlice<T> ConvertExistingDataToNativeSlice<T>(void* dataPointer, int stride, int length)
			where T : struct;
	
		// Extension methods
		public static unsafe void* GetUnsafePtr<T>(this NativeSlice<T> nativeSlice)
			where T : struct;
		public static unsafe void* GetUnsafeReadOnlyPtr<T>(this NativeSlice<T> nativeSlice)
			where T : struct;
	}
}
