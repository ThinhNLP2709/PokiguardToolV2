/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct IndirectBufferContextStorage : IDisposable // TypeDefIndex: 12876
	{
		// Fields
		private const int kAllocatorCount = 2; // Metadata: 0x006A7608
		internal const int kInstanceInfoGpuOffsetMultiplier = 2; // Metadata: 0x006A7609
		private IndirectBufferLimits m_BufferLimits; // 0x00
		private GraphicsBuffer m_InstanceBuffer; // 0x08
		private GraphicsBuffer m_InstanceInfoBuffer; // 0x10
		private NativeArray<IndirectInstanceInfo> m_InstanceInfoStaging; // 0x18
		private GraphicsBuffer m_DispatchArgsBuffer; // 0x28
		private GraphicsBuffer m_DrawArgsBuffer; // 0x30
		private GraphicsBuffer m_DrawInfoBuffer; // 0x38
		private NativeArray<IndirectDrawInfo> m_DrawInfoStaging; // 0x40
		private int m_ContextAllocCounter; // 0x50
		private NativeHashMap<EntityId, int> m_ContextIndexFromViewID; // 0x58
		private NativeList<IndirectBufferContext> m_Contexts; // 0x60
		private NativeArray<IndirectBufferAllocInfo> m_ContextAllocInfo; // 0x68
		private NativeArray<int> m_AllocationCounters; // 0x78
	
		// Properties
		public GraphicsBuffer instanceBuffer { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public GraphicsBuffer instanceInfoBuffer { get; } // 0x0000000180377550-0x0000000180377560 
		public GraphicsBuffer dispatchArgsBuffer { get; } // 0x000000018033D240-0x000000018033D250 
		public GraphicsBuffer drawArgsBuffer { get; } // 0x000000018031E110-0x000000018031E120 
		public GraphicsBuffer drawInfoBuffer { get; } // 0x00000001803272A0-0x00000001803272B0 
		public GraphicsBufferHandle visibleInstanceBufferHandle { get; } // 0x0000000181F399E0-0x0000000181F39A00 
		public GraphicsBufferHandle indirectDrawArgsBufferHandle { get; } // 0x0000000181F399C0-0x0000000181F399E0 
		public NativeArray<IndirectInstanceInfo> instanceInfoGlobalArray { get; } // 0x0000000180A5E120-0x0000000180A5E130 
		public NativeArray<IndirectDrawInfo> drawInfoGlobalArray { get; } // 0x0000000181E304C0-0x0000000181E304D0 
		public NativeArray<int> allocationCounters { get; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 
	
		// Methods
		public IndirectBufferContextHandles ImportBuffers(RenderGraph renderGraph); // 0x0000000181F39580-0x0000000181F39680
		public void Init(); // 0x0000000181F39680-0x0000000181F397B0
		private void AllocateInstanceBuffers(int maxInstanceCount); // 0x0000000181F38EF0-0x0000000181F39020
		private void FreeInstanceBuffers(); // 0x0000000181F392E0-0x0000000181F39350
		private void AllocateDrawBuffers(int maxDrawCount); // 0x0000000181F38D80-0x0000000181F38EF0
		private void FreeDrawBuffers(); // 0x0000000181F39260-0x0000000181F392E0
		public void Dispose(); // 0x0000000181F39170-0x0000000181F39260
		private void SyncContexts(); // 0x0000000181F39840-0x0000000181F398C0
		private void ResetAllocators(); // 0x0000000181F397B0-0x0000000181F39810
		private void GrowBuffers(); // 0x0000000181F39410-0x0000000181F39580
		public void ClearContextsAndGrowBuffers(); // 0x0000000181F39020-0x0000000181F39090
		public int TryAllocateContext(EntityId viewID); // 0x0000000181F398C0-0x0000000181F39990
		public int TryGetContextIndex(EntityId viewID); // 0x0000000181F39990-0x0000000181F399C0
		public NativeArray<IndirectBufferAllocInfo> GetAllocInfoSubArray(int contextIndex); // 0x0000000181F39350-0x0000000181F39390
		public IndirectBufferAllocInfo GetAllocInfo(int contextIndex); // 0x0000000181F39390-0x0000000181F393C0
		public void CopyFromStaging(CommandBuffer cmd, [IsReadOnly] in IndirectBufferAllocInfo allocInfo); // 0x0000000181F39090-0x0000000181F39170
		public IndirectBufferLimits GetLimits(int contextIndex); // 0x0000000181F39400-0x0000000181F39410
		public IndirectBufferContext GetBufferContext(int contextIndex); // 0x0000000181F393C0-0x0000000181F39400
		public void SetBufferContext(int contextIndex, IndirectBufferContext ctx); // 0x0000000181F39810-0x0000000181F39840
	}
}
