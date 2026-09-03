/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Profiling.LowLevel.Unsafe
{
	[IgnoredByDeepProfiler]
	[NativeHeader("Runtime/Profiler/ScriptBindings/ProfilerUnsafeUtility.bindings.h")]
	[UsedByNativeCode]
	public static class ProfilerUnsafeUtility // TypeDefIndex: 7361
	{
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		internal static unsafe ushort CreateCategory__Unmanaged(byte* name, int nameLen, ProfilerCategoryColor colorIndex); // 0x0000000182191800-0x0000000182191860
		[NativeMethod(IsThreadSafe = true)]
		public static ProfilerCategoryDescription GetCategoryDescription(ushort categoryId); // 0x0000000182191BF0-0x0000000182191C50
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr CreateMarker(string name, ushort categoryId, MarkerFlags flags, int metadataCount); // 0x00000001821919F0-0x0000000182191B60
		[NativeMethod(IsThreadSafe = true)]
		internal static unsafe IntPtr CreateMarker__Unmanaged(byte* name, int nameLen, ushort categoryId, MarkerFlags flags, int metadataCount); // 0x0000000182191980-0x00000001821919F0
		[NativeMethod(IsThreadSafe = true)]
		public static void SetMarkerMetadata(IntPtr markerPtr, int index, string name, byte type, byte unit); // 0x00000001821920D0-0x0000000182192240
		[NativeMethod(IsThreadSafe = true)]
		internal static unsafe void SetMarkerMetadata__Unmanaged(IntPtr markerPtr, int index, byte* name, int nameLen, byte type, byte unit); // 0x0000000182192050-0x00000001821920D0
		[NativeMethod(IsThreadSafe = true)]
		public static void BeginSample(IntPtr markerPtr); // 0x00000001821917C0-0x0000000182191800
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void BeginSampleWithMetadata(IntPtr markerPtr, int metadataCount, void* metadata); // 0x0000000182191770-0x00000001821917C0
		[NativeMethod(IsThreadSafe = true)]
		public static void EndSample(IntPtr markerPtr); // 0x0000000182191B60-0x0000000182191BA0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void SingleSampleWithMetadata(IntPtr markerPtr, int metadataCount, void* metadata); // 0x0000000182192240-0x0000000182192290
		[NativeMethod(IsThreadSafe = true)]
		internal static unsafe void* CreateCounterValue__Unmanaged(out IntPtr counterPtr, byte* name, int nameLen, ushort categoryId, MarkerFlags flags, byte dataType, byte dataUnit, int dataSize, ProfilerCounterOptions counterOptions); // 0x0000000182191860-0x0000000182191910
		internal static unsafe string Utf8ToString(byte* chars, int charsLen); // 0x0000000182192290-0x0000000182192370
		[NativeMethod(IsThreadSafe = true)]
		internal static void Internal_BeginWithObject(IntPtr markerPtr, UnityEngine.Object contextUnityObject); // 0x0000000182191F90-0x0000000182191FE0
		[NativeConditional("ENABLE_MEM_PROFILER")]
		[NativeMethod(IsThreadSafe = true)]
		internal static IntPtr GetOrCreateMemLabel(string areaName, string objectName); // 0x0000000182191D00-0x0000000182191F40
		[NativeConditional("ENABLE_MEM_PROFILER")]
		[NativeMethod(IsThreadSafe = true)]
		internal static unsafe IntPtr GetOrCreateMemLabel__Unmanaged(byte* areaName, int areaNameLen, byte* objectName, int objectNameLen); // 0x0000000182191CA0-0x0000000182191D00
		private static void GetCategoryDescription_Injected(ushort categoryId, ); // 0x0000000182191BA0-0x0000000182191BF0
		private static IntPtr CreateMarker_Injected(ref ManagedSpanWrapper name, ushort categoryId, MarkerFlags flags, int metadataCount); // 0x0000000182191910-0x0000000182191980
		private static void SetMarkerMetadata_Injected(IntPtr markerPtr, int index, ref ManagedSpanWrapper name, byte type, byte unit); // 0x0000000182191FE0-0x0000000182192050
		private static void Internal_BeginWithObject_Injected(IntPtr markerPtr, IntPtr contextUnityObject); // 0x0000000182191F40-0x0000000182191F90
		private static IntPtr GetOrCreateMemLabel_Injected(ref ManagedSpanWrapper areaName, ref ManagedSpanWrapper objectName); // 0x0000000182191C50-0x0000000182191CA0
	}
}
