/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal static class GPUResidentUtils // TypeDefIndex: 12983
	{
		// Extension methods
		public static void RunParallelByRef<T>(this ref ref T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static void RunParallel<T>(this T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static void RunBatchParallelByRef<T>(this ref ref T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static void RunBatchParallel<T>(this T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static ref ref T ElementAtRW<T>(this NativeArray<T> array, int index)
			where T : struct;
		public static ref ref T ElementAt<T>(this NativeArray<T> array, int index)
			where T : struct;
		public static NativeArray<T> AsNativeArray<T>(this UnsafeList<T> list)
			where T : struct;
		public static UnsafeList<T> AsUnsafeList<T>(this NativeArray<T> array)
			where T : struct;
		public static UnsafeList<T> AsUnsafeListReadOnly<T>(this NativeArray<T> array)
			where T : struct;
		public static UnsafeList<UntypedUnsafeList> AsUntypedUnsafeList<T>(this UnsafeList<UnsafeList<T>> list)
			where T : struct;
		public static UnsafeBitArray AsUnsafeBitArray([IsReadOnly] this in NativeBitArray section); // 0x0000000181F4E3C0-0x0000000181F4E3E0
		public static ref ref T GetRef<T>(this NativeReference<T> reference)
			where T : struct;
		public static ref ref T GetRefRO<T>(this NativeReference<T> reference)
			where T : struct;
		public static bool HasAnyBit(this MeshRendererComponentMask mask, MeshRendererComponentMask bits); // 0x0000000181A228E0-0x0000000181A228F0
		public static bool HasAnyBit(this LODGroupComponentMask mask, LODGroupComponentMask bits); // 0x0000000181A228E0-0x0000000181A228F0
	}
}
