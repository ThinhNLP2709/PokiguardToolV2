/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal class NativePassCompiler : IDisposable // TypeDefIndex: 5991
	{
		// Fields
		internal static readonly ProfilerMarker k_SetupContextData; // 0x00
		internal static readonly ProfilerMarker k_BuildGraph; // 0x08
		internal static readonly ProfilerMarker k_CullNodes; // 0x10
		internal static readonly ProfilerMarker k_TryMergeNativePasses; // 0x18
		internal static readonly ProfilerMarker k_FindResourceUsageRanges; // 0x20
		internal static readonly ProfilerMarker k_PropagateTextureUVOrigin; // 0x28
		internal static readonly ProfilerMarker k_DetectMemorylessResources; // 0x30
		internal static readonly ProfilerMarker k_ExecuteInitializeResources; // 0x38
		internal static readonly ProfilerMarker k_PrepareNativePass; // 0x40
		internal static readonly ProfilerMarker k_ExecuteBeginRenderPassCommand; // 0x48
		internal static readonly ProfilerMarker k_ExecuteDestroyResources; // 0x50
		internal RenderGraphInputInfo graph; // 0x10
		internal CompilerContextData contextData; // 0x30
		internal CompilerContextData defaultContextData; // 0x38
		internal CommandBuffer previousCommandBuffer; // 0x40
		private Stack<int> m_HasSideEffectPassIdCullingStack; // 0x48
		private List<Stack<ResourceHandle>> m_UnusedVersionedResourceIdCullingStacks; // 0x50
		private Dictionary<int, List<ResourceHandle>> m_DelayedLastUseListPerPassMap; // 0x58
		private RenderGraphCompilationCache m_CompilationCache; // 0x60
		private RenderTargetIdentifier[][] m_TempMRTArrays; // 0x68
		internal const int k_EstimatedPassCount = 100; // Metadata: 0x00662CEB
		internal const int k_MaxSubpass = 8; // Metadata: 0x00662CED
		private NativeList<AttachmentDescriptor> m_BeginRenderPassAttachments; // 0x70
		internal NativeList<int> m_NonCulledPassIndicesForRasterPasses; // 0x78
		[NoAutoStaticsCleanup]
		internal static bool s_ForceGenerateAuditsForTests; // 0x58
		private const int ArbitraryMaxNbMergedPasses = 16; // Metadata: 0x00662CEE
		private DynamicArray<Name> graphPassNamesForDebug; // 0x80
	
		// Nested types
		internal struct RenderGraphInputInfo // TypeDefIndex: 5992
		{
			// Fields
			public RenderGraphResourceRegistry m_ResourcesForDebugOnly; // 0x00
			public List<RenderGraphPass> m_RenderPasses; // 0x08
			public string debugName; // 0x10
			public bool disablePassCulling; // 0x18
			public bool disablePassMerging; // 0x19
			public RenderTextureUVOriginStrategy renderTextureUVOriginStrategy; // 0x1C
		}
	
		[Obsolete("This enum is deprecated and will be removed in a future release. Please use ProfilerMarkers NRPRGComp_* instead.")]
		internal enum NativeCompilerProfileId // TypeDefIndex: 5993
		{
			NRPRGComp_PrepareNativePass = 0,
			NRPRGComp_SetupContextData = 1,
			NRPRGComp_BuildGraph = 2,
			NRPRGComp_CullNodes = 3,
			NRPRGComp_TryMergeNativePasses = 4,
			NRPRGComp_FindResourceUsageRanges = 5,
			NRPRGComp_DetectMemorylessResources = 6,
			NRPRGComp_PropagateTextureUVOrigin = 7,
			NRPRGComp_ExecuteInitializeResources = 8,
			NRPRGComp_ExecuteBeginRenderpassCommand = 9,
			NRPRGComp_ExecuteDestroyResources = 10
		}
	
		// Constructors
		public NativePassCompiler(RenderGraphCompilationCache cache); // 0x0000000181EFD590-0x0000000181EFD960
		static NativePassCompiler(); // 0x0000000181EFD290-0x0000000181EFD590
	
		// Methods
		private static RenderGraph.DebugData.PassData.NRPInfo.NativeRenderPassInfo.AttachmentInfo MakeAttachmentInfo(CompilerContextData ctx, [IsReadOnly] in NativePassData nativePass, int attachmentIndex); // 0x0000000181EFA500-0x0000000181EFAA90
		internal static string MakePassBreakInfoMessage(CompilerContextData ctx, [IsReadOnly] in NativePassData nativePass); // 0x0000000181EFAA90-0x0000000181EFABB0
		internal static string MakePassMergeMessage(CompilerContextData ctx, [IsReadOnly] in PassData pass, [IsReadOnly] in PassData prevPass, [IsReadOnly] in PassBreakAudit mergeResult); // 0x0000000181EFABB0-0x0000000181EFB600
		private static string InjectSpaces(string camelCaseString); // 0x0000000181EFA130-0x0000000181EFA2B0
		internal void GenerateNativeCompilerDebugData(ref RenderGraph.DebugData debugData); // 0x0000000181EF7700-0x0000000181EF9C00
		public void Dispose(); // 0x0000000181EF40D0-0x0000000181EF4160
		public void Cleanup(); // 0x0000000181EF24B0-0x0000000181EF2510
		public bool Initialize(RenderGraphResourceRegistry resources, List<RenderGraphPass> renderPasses, RenderGraphDebugParams debugParams, string debugName, bool useCompilationCaching, int graphHash, int frameIndex, RenderTextureUVOriginStrategy renderTextureUVOriginStrategy); // 0x0000000181EFA030-0x0000000181EFA130
		private void HandleExtendedFeatureFlags(); // 0x0000000181EF9C00-0x0000000181EFA030
		public void Compile(RenderGraphResourceRegistry resources); // 0x0000000181EF29A0-0x0000000181EF2B80
		public void Clear(bool clearContextData); // 0x0000000181EF2590-0x0000000181EF2700
		private void SetPassStatesForNativePass(int nativePassId); // 0x0000000181EFB980-0x0000000181EFB990
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidatePasses(); // 0x0000000181EFCFE0-0x0000000181EFD290
		private void SetupContextData(RenderGraphResourceRegistry resources); // 0x0000000181EFB990-0x0000000181EFBAA0
		private bool TrySetupRasterFragmentList(ref PassData ctxPass, ref RenderGraphPass inputPass, out string errorMessage); // 0x0000000181EFBF50-0x0000000181EFC8D0
		private void BuildGraph(); // 0x0000000181EF1B80-0x0000000181EF24B0
		private void CullUnusedRenderGraphPasses(); // 0x0000000181EF3270-0x0000000181EF3370
		private void CullRenderGraphPassesWithNoSideEffect(); // 0x0000000181EF2B80-0x0000000181EF2DF0
		private void CullRenderGraphPassesWritingOnlyUnusedResources(); // 0x0000000181EF2DF0-0x0000000181EF3270
		private void TryMergeNativePasses(); // 0x0000000181EFBAA0-0x0000000181EFBF50
		private void CollectNonCulledPassIndicesForRasterPasses(int currentPassIdx, int indexSinceLastCulledPass, bool usePreviousNativePass = false /* Metadata: 0x00662CE8 */, bool clearList = false /* Metadata: 0x00662CE9 */); // 0x0000000181EF2700-0x0000000181EF2850
		private void CompactNonCulledPassesForRasterPasses(); // 0x0000000181EF2850-0x0000000181EF29A0
		private bool FindFirstPassIdOnGraphicsQueueAwaitingFenceGoingForward(ref PassData startAsyncPass, out int firstPassIdAwaiting); // 0x0000000181EF6A40-0x0000000181EF6AE0
		private int FindFirstNonCulledPassIdGoingBackward(int startPassId, bool startPassIsIncluded); // 0x0000000181EF6980-0x0000000181EF6A40
		private void FindResourceUsageRangeAndSynchronization(); // 0x0000000181EF6AE0-0x0000000181EF7700
		private void ClearDelayedLastUseListAtPass(int passId); // 0x0000000181EF2510-0x0000000181EF2590
		private void AddDelayedLastUseToPass([IsReadOnly] in ResourceHandle releaseResource, int passId); // 0x0000000181EF1750-0x0000000181EF18C0
		public void AddLastUseFromDelayedList(ref PassData passData); // 0x0000000181EF18C0-0x0000000181EF1B80
		private void PrepareNativeRenderPasses(); // 0x0000000181EFB600-0x0000000181EFB670
		private void PropagateTextureUVOrigin(); // 0x0000000181EFB670-0x0000000181EFB980
		private static bool IsGlobalTextureInPass(RenderGraphPass pass, [IsReadOnly] in ResourceHandle handle); // 0x0000000181EFA2B0-0x0000000181EFA400
		private void DetectMemoryLessResources(); // 0x0000000181EF3370-0x0000000181EF38E0
		internal static bool IsSameNativeSubPass(ref SubPassDescriptor a, ref SubPassDescriptor b); // 0x0000000181EFA400-0x0000000181EFA500
		private bool ExecuteInitializeResource(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, [IsReadOnly] in PassData pass); // 0x0000000181EF5980-0x0000000181EF5F80
		private void DetermineLoadStoreActions(ref NativePassData nativePass); // 0x0000000181EF38E0-0x0000000181EF40D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateConflictingUVOrigins(ref NativePassData nativePassData, ref NativePassAttachment nativePassAttachment, ref ResourceUnversionedData resData, TextureUVOriginSelection storeUVOrigin, int firstStoreAttachmentIndex); // 0x0000000181EFCA40-0x0000000181EFCDE0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateNativePass([IsReadOnly] in NativePassData nativePass, int width, int height, int depth, int samples, int attachmentCount); // 0x0000000181EFCDE0-0x0000000181EFCFE0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateAttachment([IsReadOnly] in RenderTargetInfo attRenderTargetInfo, RenderGraphResourceRegistry resources, int nativePassWidth, int nativePassHeight, int nativePassMSAASamples, bool isVrs, bool isShaderResolve); // 0x0000000181EFC8D0-0x0000000181EFCA40
		internal void ExecuteBeginRenderPass(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, ref NativePassData nativePass); // 0x0000000181EF4480-0x0000000181EF4F10
		private void ExecuteDestroyResource(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, ref PassData pass); // 0x0000000181EF4F10-0x0000000181EF53F0
		private void ExecuteSetRenderTargets(RenderGraphPass pass, InternalRenderGraphContext rgContext); // 0x0000000181EF64B0-0x0000000181EF6980
		internal void ExecuteSetRandomWriteTarget([IsReadOnly] in CommandBuffer cmd, RenderGraphResourceRegistry resources, int index, [IsReadOnly] in ResourceHandle resource, bool preserveCounterValue = true /* Metadata: 0x00662CEA */); // 0x0000000181EF62B0-0x0000000181EF64B0
		internal void ExecuteRenderGraphPass(ref InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, RenderGraphPass pass); // 0x0000000181EF5F80-0x0000000181EF62B0
		public void ExecuteGraph(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, [IsReadOnly] in List<RenderGraphPass> passes); // 0x0000000181EF53F0-0x0000000181EF5980
		private void EndRenderGraphPass(ref InternalRenderGraphContext rgContext, ref PassData passData, ref bool inRenderPass, RenderGraphResourceRegistry resources, bool nrpBegan); // 0x0000000181EF4160-0x0000000181EF4480
	}
}
