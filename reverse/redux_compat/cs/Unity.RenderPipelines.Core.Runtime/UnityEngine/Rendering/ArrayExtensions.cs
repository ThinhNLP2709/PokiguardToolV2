/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Jobs;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class ArrayExtensions // TypeDefIndex: 5728
	{
		// Methods
		public static void ResizeArray<T>(ref ref T[] array, int capacity);
	
		// Extension methods
		public static void ResizeArray<T>(this ref NativeArray<T> array, int capacity)
			where T : struct;
		public static void ResizeArray(this ref TransformAccessArray array, int capacity); // 0x0000000181EA2070-0x0000000181EA2100
		public static void FillArray<T>(this ref NativeArray<T> array, [IsReadOnly] in ref T value, int startIndex = 0 /* Metadata: 0x00661964 */, int length = -1 /* Metadata: 0x00661965 */)
			where T : struct;
	}
}
