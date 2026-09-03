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
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	internal static class MeshRendererProcessorBurst // TypeDefIndex: 12945
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void ComputeInstanceGPUArchetypes_00000334_PostfixBurstDelegate([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, MeshRendererUpdateBatch* updateBatch, [IsReadOnly] in GPUComponentSet overrideComponentSet, bool useSharedGPUArchetype, ref NativeArray<GPUArchetypeHandle> archetypes); // TypeDefIndex: 12946; 0x0000000181F31BC0-0x0000000181F31BE0
	
		internal static class ComputeInstanceGPUArchetypes_00000334_BurstDirectCall // TypeDefIndex: 12947
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F31550-0x0000000181F31590
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001888b); // 0x0000000181F31590-0x0000000181F31700
			private static IntPtr GetFunctionPointer(); // 0x0000000181F31700-0x0000000181F31860
			public static unsafe void Invoke([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, MeshRendererUpdateBatch* updateBatch, [IsReadOnly] in GPUComponentSet overrideComponentSet, bool useSharedGPUArchetype, ref NativeArray<GPUArchetypeHandle> archetypes); // 0x0000000181F31860-0x0000000181F31A90
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void BuildGPUComponentOverrideUploadSources_00000335_PostfixBurstDelegate([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in NativeArray<GPUComponentJaggedUpdate> componentUpdates, ref NativeArray<MeshRendererProcessor.GPUComponentUploadSource> uploadSources, GPUComponentSet* overrideComponentSet); // TypeDefIndex: 12948; 0x000000018043A200-0x000000018043A220
	
		internal static class BuildGPUComponentOverrideUploadSources_00000335_BurstDirectCall // TypeDefIndex: 12949
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F30F50-0x0000000181F30F90
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001889f); // 0x0000000181F30F90-0x0000000181F31100
			private static IntPtr GetFunctionPointer(); // 0x0000000181F31100-0x0000000181F31260
			public static unsafe void Invoke([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in NativeArray<GPUComponentJaggedUpdate> componentUpdates, ref NativeArray<MeshRendererProcessor.GPUComponentUploadSource> uploadSources, GPUComponentSet* overrideComponentSet); // 0x0000000181F31260-0x0000000181F31460
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool AnyInstanceUseBlendProbes_00000336_PostfixBurstDelegate([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld); // TypeDefIndex: 12950; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class AnyInstanceUseBlendProbes_00000336_BurstDirectCall // TypeDefIndex: 12951
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F308D0-0x0000000181F30910
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000188ad); // 0x0000000181F30910-0x0000000181F30A80
			private static IntPtr GetFunctionPointer(); // 0x0000000181F30A80-0x0000000181F30BE0
			public static bool Invoke([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld); // 0x0000000181F30BE0-0x0000000181F30DC0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate bool DidGPUArchetypeChange_00000337_PostfixBurstDelegate([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, [IsReadOnly] in NativeArray<InstanceHandle> instances, MeshRendererUpdateBatch* updateBatch, ref RenderWorld renderWorld, [IsReadOnly] in GPUComponentSet overrideComponentSet); // TypeDefIndex: 12952; 0x0000000180ED8BF0-0x0000000180ED8C10
	
		internal static class DidGPUArchetypeChange_00000337_BurstDirectCall // TypeDefIndex: 12953
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F339E0-0x0000000181F33A20
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000188c1); // 0x0000000181F33A20-0x0000000181F33B90
			private static IntPtr GetFunctionPointer(); // 0x0000000181F33B90-0x0000000181F33CF0
			public static unsafe bool Invoke([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, [IsReadOnly] in NativeArray<InstanceHandle> instances, MeshRendererUpdateBatch* updateBatch, ref RenderWorld renderWorld, [IsReadOnly] in GPUComponentSet overrideComponentSet); // 0x0000000181F33CF0-0x0000000181F33F20
		}
	
		// Methods
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static unsafe void ComputeInstanceGPUArchetypes([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, MeshRendererUpdateBatch* updateBatch, [IsReadOnly] in GPUComponentSet overrideComponentSet, bool useSharedGPUArchetype, ref NativeArray<GPUArchetypeHandle> archetypes); // 0x0000000181F3B430-0x0000000181F3B450
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static unsafe void BuildGPUComponentOverrideUploadSources([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in NativeArray<GPUComponentJaggedUpdate> componentUpdates, ref NativeArray<MeshRendererProcessor.GPUComponentUploadSource> uploadSources, GPUComponentSet* overrideComponentSet); // 0x0000000181F31260-0x0000000181F31460
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static bool AnyInstanceUseBlendProbes([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld); // 0x0000000181F30BE0-0x0000000181F30DC0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static unsafe bool DidGPUArchetypeChange([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, [IsReadOnly] in NativeArray<InstanceHandle> instances, MeshRendererUpdateBatch* updateBatch, ref RenderWorld renderWorld, [IsReadOnly] in GPUComponentSet overrideComponentSet); // 0x0000000181F3B920-0x0000000181F3B930
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(ComputeInstanceGPUArchetypes_00000334_PostfixBurstDelegate))]
		internal static unsafe void ComputeInstanceGPUArchetypes_BurstManaged([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, MeshRendererUpdateBatch* updateBatch, [IsReadOnly] in GPUComponentSet overrideComponentSet, bool useSharedGPUArchetype, ref NativeArray<GPUArchetypeHandle> archetypes); // 0x0000000181F3B030-0x0000000181F3B430
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(BuildGPUComponentOverrideUploadSources_00000335_PostfixBurstDelegate))]
		internal static unsafe void BuildGPUComponentOverrideUploadSources_BurstManaged([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in NativeArray<GPUComponentJaggedUpdate> componentUpdates, ref NativeArray<MeshRendererProcessor.GPUComponentUploadSource> uploadSources, GPUComponentSet* overrideComponentSet); // 0x0000000181F3AEB0-0x0000000181F3B030
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(AnyInstanceUseBlendProbes_00000336_PostfixBurstDelegate))]
		internal static bool AnyInstanceUseBlendProbes_BurstManaged([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld); // 0x0000000181F3AD40-0x0000000181F3AEB0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(DidGPUArchetypeChange_00000337_PostfixBurstDelegate))]
		internal static unsafe bool DidGPUArchetypeChange_BurstManaged([IsReadOnly] in NativeReference<GPUArchetypeManager> archetypeManager, [IsReadOnly] in DefaultGPUComponents defaultGPUComponents, [IsReadOnly] in NativeArray<InstanceHandle> instances, MeshRendererUpdateBatch* updateBatch, ref RenderWorld renderWorld, [IsReadOnly] in GPUComponentSet overrideComponentSet); // 0x0000000181F3B450-0x0000000181F3B920
	}
}
