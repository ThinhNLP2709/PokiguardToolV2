/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	internal static class JaggedJobRangeBurst // TypeDefIndex: 12987
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ComputeRanges_000003BD_PostfixBurstDelegate(int workerThreadCount, int batchSizeHint, int totalLength, bool canExceedBatchSizeHint, [IsReadOnly] in NativeArray<UntypedUnsafeList> sections, ref NativeList<JaggedJobRange> jobRanges); // TypeDefIndex: 12988; 0x0000000181F4CCC0-0x0000000181F4CCE0
	
		internal static class ComputeRanges_000003BD_BurstDirectCall // TypeDefIndex: 12989
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F4C6A0-0x0000000181F4C6E0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000189f8); // 0x0000000181F4C6E0-0x0000000181F4C840
			private static IntPtr GetFunctionPointer(); // 0x0000000181F4C840-0x0000000181F4C990
			public static void Invoke(int workerThreadCount, int batchSizeHint, int totalLength, bool canExceedBatchSizeHint, [IsReadOnly] in NativeArray<UntypedUnsafeList> sections, ref NativeList<JaggedJobRange> jobRanges); // 0x0000000181F4C990-0x0000000181F4CBB0
		}
	
		// Methods
		private static int ComputeIdealJobCount(int totalLength, int batchSizeHint, int workerThreadCount); // 0x0000000181F4E580-0x0000000181F4E610
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void ComputeRanges(int workerThreadCount, int batchSizeHint, int totalLength, bool canExceedBatchSizeHint, [IsReadOnly] in NativeArray<UntypedUnsafeList> sections, ref NativeList<JaggedJobRange> jobRanges); // 0x0000000181F4C990-0x0000000181F4CBB0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(ComputeRanges_000003BD_PostfixBurstDelegate))]
		internal static void ComputeRanges_BurstManaged(int workerThreadCount, int batchSizeHint, int totalLength, bool canExceedBatchSizeHint, [IsReadOnly] in NativeArray<UntypedUnsafeList> sections, ref NativeList<JaggedJobRange> jobRanges); // 0x0000000181F4E610-0x0000000181F4E790
	}
}
