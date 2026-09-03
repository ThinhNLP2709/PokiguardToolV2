/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class GPUInstanceDataBuffer : IDisposable // TypeDefIndex: 12768
	{
		// Fields
		private static readonly ProfilerMarker k_QueryInstanceGPUIndices; // 0x00
		private static readonly ProfilerMarker k_UploadGPUInstanceData; // 0x08
		public const int MaxGPUInstancDataBufferSize = 1073741824; // Metadata: 0x006A759A
		internal const int InvalidIndex = -1; // Metadata: 0x006A759F
		private const int ThreadGroupSize = 128; // Metadata: 0x006A75A0
		private const int UIntPerThread = 16; // Metadata: 0x006A75A2
		private const int UIntPerThreadGroup = 2048; // Metadata: 0x006A75A3
		private const int MaxThreadGroupsPerDispatch = 65535; // Metadata: 0x006A75A5
		private int m_MainUploadScatterInstancesKernelID; // 0x10
		private int m_MainCopyInstancesKernelID; // 0x14
		private InternalGPUInstanceDataBuffer m_InternalBuffer; // 0x18
		private int m_LayoutVersion; // 0x20
		private uint3 m_UploaKernelThreadGroupSize; // 0x24
		private ComputeShader m_InstanceDataBufferUploadKernels; // 0x30
		private ComputeShader m_InstanceDataBufferCopyKernels; // 0x38
		private GraphicsBuffer m_InputInstanceIndicesBuffer; // 0x40
		private GraphicsBuffer m_InputComponentAddressesBuffer; // 0x48
		private GraphicsBuffer m_OutputComponentIndicesBuffer; // 0x50
	
		// Properties
		public NativeArray<int> componentPerInstance { get; } // 0x0000000181F0B500-0x0000000181F0B550 
		public NativeArray<int> componentsGPUAddress { get; } // 0x0000000181F0B550-0x0000000181F0B5A0 
		public NativeArray<int> componentByteSizes { get; } // 0x0000000181F0B460-0x0000000181F0B4B0 
		public NativeArray<int2> componentInstanceIndexRanges { get; } // 0x0000000181F0B4B0-0x0000000181F0B500 
		public NativeArray<MetadataValue> componentsMetadata { get; } // 0x0000000181F0B5A0-0x0000000181F0B5F0 
		public NativeArray<GPUComponentHandle> components { get; } // 0x0000000181F0B5F0-0x0000000181F0B640 
		public int gpuBufferByteSize { get; } // 0x0000000181F0B640-0x0000000181F0B660 
		public GraphicsBuffer nativeBuffer { get; } // 0x0000000181F0B660-0x0000000181F0B680 
		public int layoutVersion { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Nested types
		[IsReadOnly]
		internal struct ReadOnly // TypeDefIndex: 12769
		{
			// Fields
			public readonly GPUInstanceDataBufferLayout.ReadOnly layout; // 0x00
			public readonly NativeArray<int> componentsGPUAddress; // 0x30
			public readonly NativeArray<int> instancesCountPrefixSum; // 0x40
			public readonly NativeArray<int> componentIndices; // 0x50
	
			// Constructors
			public ReadOnly(GPUInstanceDataBuffer buffer); // 0x0000000181F19C20-0x0000000181F19D70
	
			// Methods
			public int GetComponentIndex(GPUComponentHandle component); // 0x0000000181F199B0-0x0000000181F19A20
			public int GetComponentGPUAddress(GPUComponentHandle component); // 0x0000000181F19930-0x0000000181F199B0
			public GPUInstanceIndex InstanceGPUHandleToGPUIndex(InstanceGPUHandle gpuHandle); // 0x0000000181F19A20-0x0000000181F19BC0
		}
	
		internal class InternalGPUInstanceDataBuffer // TypeDefIndex: 12770
		{
			// Fields
			public const int kComponentAddressAlignment = 128; // Metadata: 0x006A75A9
			internal readonly GPUInstanceDataBufferLayout layout; // 0x10
			internal readonly NativeList<GPUComponentHandle> components; // 0x28
			internal readonly NativeList<int2> componentsArchetypeIndexSpan; // 0x30
			internal readonly NativeArray<MetadataValue> componentsMetadata; // 0x38
			internal readonly NativeArray<int> componentsGPUAddress; // 0x48
			internal readonly NativeArray<int> componentPerInstance; // 0x58
			internal readonly NativeArray<int> componentByteSizes; // 0x68
			internal readonly NativeArray<int2> componentInstanceIndexRanges; // 0x78
			internal readonly NativeArray<int> componentIndices; // 0x88
			internal readonly NativeArray<int> instancesCountPrefixSum; // 0x98
			internal readonly int gpuBufferByteSize; // 0xA8
			internal readonly GraphicsBuffer gpuBuffer; // 0xB0
			internal readonly GraphicsBuffer componentsPerInstanceGPUBuffer; // 0xB8
			internal readonly GraphicsBuffer componentsGPUAddressGPUBuffer; // 0xC0
			internal readonly GraphicsBuffer componentGPUInstanceIndexRangesGPUBuffer; // 0xC8
			internal readonly GraphicsBuffer componentByteCountsGPUBuffer; // 0xD0
	
			// Constructors
			public InternalGPUInstanceDataBuffer(ref GPUArchetypeManager archetypeManager, [IsReadOnly] in GPUInstanceDataBufferLayout layout); // 0x0000000181F18490-0x0000000181F19050
	
			// Methods
			public void Dispose(); // 0x0000000181F181D0-0x0000000181F183B0
			public int FindComponentIndex(GPUComponentHandle component); // 0x0000000181F18420-0x0000000181F18490
			public int FindArchetypeIndex(GPUArchetypeHandle archetype); // 0x0000000181F183B0-0x0000000181F18420
		}
	
		[IsReadOnly]
		internal struct ComponentIndex // TypeDefIndex: 12771
		{
			// Fields
			public readonly int index; // 0x00
			public readonly int layoutVersion; // 0x04
	
			// Constructors
			public ComponentIndex(int index, int layoutVersion); // 0x0000000180C55C70-0x0000000180C55C80
		}
	
		[IsReadOnly]
		internal struct ArchetypeIndex // TypeDefIndex: 12772
		{
			// Fields
			public readonly int index; // 0x00
			public readonly int layoutVersion; // 0x04
	
			// Constructors
			public ArchetypeIndex(int index, int layoutVersion); // 0x0000000180C55C70-0x0000000180C55C80
		}
	
		internal static class UploadKernelID // TypeDefIndex: 12773
		{
			// Fields
			public static readonly int kInputComponentsCount; // 0x00
			public static readonly int kInputInstancesCount; // 0x04
			public static readonly int kInputInstanceData; // 0x08
			public static readonly int kInputInstanceIndices; // 0x0C
			public static readonly int kInputComponentAddresses; // 0x10
			public static readonly int kOutputComponentByteCounts; // 0x14
			public static readonly int kOutputComponentIndices; // 0x18
			public static readonly int kOutputComponentInstanceIndexRanges; // 0x1C
			public static readonly int kOutputComponentIsPerInstance; // 0x20
			public static readonly int kOutputComponentAddresses; // 0x24
			public static readonly int kOutputBuffer; // 0x28
	
			// Constructors
			static UploadKernelID(); // 0x0000000181F1C040-0x0000000181F1C250
		}
	
		internal static class CopyKernelID // TypeDefIndex: 12774
		{
			// Fields
			public static readonly int kDispatchThreadGroupBase; // 0x00
			public static readonly int kInputComponentsCount; // 0x04
			public static readonly int kInputThreadGroupBeginIndices; // 0x08
			public static readonly int kInputComponentDataAddresses; // 0x0C
			public static readonly int kOutputComponentDataAddresses; // 0x10
			public static readonly int kOutputComponentDataUIntSizes; // 0x14
			public static readonly int kInputBuffer; // 0x18
			public static readonly int kOutputBuffer; // 0x1C
	
			// Constructors
			static CopyKernelID(); // 0x0000000181F04D60-0x0000000181F04EE0
		}
	
		// Constructors
		public GPUInstanceDataBuffer(ref GPUArchetypeManager archetypeManager, [IsReadOnly] in GPUInstanceDataBufferLayout layout, GPUResidentDrawerResources resources); // 0x0000000181F0B320-0x0000000181F0B460
		static GPUInstanceDataBuffer(); // 0x0000000181F0B270-0x0000000181F0B320
	
		// Methods
		public void Dispose(); // 0x0000000181F092A0-0x0000000181F09310
		private static MetadataValue CreateMetadataValue(int nameID, int gpuAddress, bool isPerInstance); // 0x0000000181F09270-0x0000000181F092A0
		public ComponentIndex GetComponentIndex(GPUComponentHandle component); // 0x0000000181F09510-0x0000000181F095A0
		public int GetComponentGPUAddress(ComponentIndex compIndex); // 0x0000000181F094A0-0x0000000181F094D0
		public int GetComponentGPUAddress(GPUComponentHandle component); // 0x0000000181F09460-0x0000000181F094A0
		public int GetComponentGPUUIntOffset(GPUComponentHandle component); // 0x0000000181F094D0-0x0000000181F09510
		public bool IsArchetypeAllocated(GPUArchetypeHandle archetype); // 0x0000000181F09700-0x0000000181F09790
		public ArchetypeIndex GetArchetypeIndex(GPUArchetypeHandle archetype); // 0x0000000181F093D0-0x0000000181F09460
		public int GetInstancesCount([IsReadOnly] in ArchetypeIndex archIndex); // 0x0000000181F095A0-0x0000000181F09600
		public GPUInstanceIndex InstanceToGPUIndex([IsReadOnly] in ArchetypeIndex archIndex, int instanceIndex); // 0x0000000181F09600-0x0000000181F09700
		public void QueryInstanceGPUIndices([IsReadOnly] in RenderWorld renderWorld, NativeArray<InstanceHandle> instances, NativeArray<GPUInstanceIndex> gpuIndices); // 0x0000000181F09790-0x0000000181F09A50
		public void UploadDataToGPU(CommandBuffer cmd, GraphicsBuffer uploadBuffer, [IsReadOnly] in GPUInstanceUploadData uploadData, NativeArray<GPUInstanceIndex> scatterGPUIndices); // 0x0000000181F0A6D0-0x0000000181F0B270
		public void SetGPULayout(CommandBuffer cmd, ref GPUArchetypeManager archetypeManager, [IsReadOnly] in GPUInstanceDataBufferLayout newLayout, bool submitCmdBuffer); // 0x0000000181F09A50-0x0000000181F0A6D0
		public ReadOnly AsReadOnly(); // 0x0000000181F09100-0x0000000181F09270
		private static GraphicsBuffer EnsureBufferCountOrResize(GraphicsBuffer buffer, int requestedCount, int stride); // 0x0000000181F09310-0x0000000181F093D0
	}
}
