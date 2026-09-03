/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal struct NativePassData // TypeDefIndex: 6007
	{
		// Fields
		public FixedAttachmentArray<LoadAudit> loadAudit; // 0x00
		public FixedAttachmentArray<StoreAudit> storeAudit; // 0x44
		public PassBreakAudit breakAudit; // 0xC8
		public FixedAttachmentArray<PassFragmentData> fragments; // 0xD0
		public FixedAttachmentArray<NativePassAttachment> attachments; // 0x194
		public int firstGraphPass; // 0x298
		public int lastGraphPass; // 0x29C
		public int numGraphPasses; // 0x2A0
		public int firstCompactedNonCulledRasterPass; // 0x2A4
		public int lastCompactedNonCulledRasterPass; // 0x2A8
		public int firstNativeSubPass; // 0x2AC
		public int numNativeSubPasses; // 0x2B0
		public int width; // 0x2B4
		public int height; // 0x2B8
		public int volumeDepth; // 0x2BC
		public int samples; // 0x2C0
		public int shadingRateImageIndex; // 0x2C4
		public bool hasDepth; // 0x2C8
		public bool hasFoveatedRasterization; // 0x2C9
		public bool hasShadingRateStates; // 0x2CA
		public ExtendedFeatureFlags extendedFeatureFlags; // 0x2CC
		public ShadingRateFragmentSize shadingRateFragmentSize; // 0x2D0
		public ShadingRateCombiner primitiveShadingRateCombiner; // 0x2D4
		public ShadingRateCombiner fragmentShadingRateCombiner; // 0x2D8
	
		// Properties
		public bool hasShadingRateImage { get; } // 0x0000000181F009C0-0x0000000181F009D0 
	
		// Constructors
		public NativePassData(ref PassData pass, CompilerContextData ctx); // 0x0000000181F005C0-0x0000000181F009C0
	
		// Methods
		public SubPassFlags GetSubPassFlagForMerging(); // 0x0000000181EFF690-0x0000000181EFF700
		public void Clear(); // 0x0000000181EFF4B0-0x0000000181EFF5A0
		[IsReadOnly]
		public bool IsValid(); // 0x0000000181EFF700-0x0000000181EFF710
		[IsReadOnly]
		public ReadOnlySpan<PassData> GraphPasses(CompilerContextData ctx); // 0x0000000181EF0B90-0x0000000181EF0CC0
		[IsReadOnly]
		public void GetGraphPassNames(CompilerContextData ctx, DynamicArray<Name> dest); // 0x0000000181EFF5A0-0x0000000181EFF690
		private static bool CanMergeMSAASamples(ref NativePassData nativePass, ref PassData passToMerge); // 0x0000000181EFE2B0-0x0000000181EFE2D0
		private static bool AreExtendedFeatureFlagsCompatible(ExtendedFeatureFlags flags0, ExtendedFeatureFlags flags1); // 0x00000001802E7990-0x00000001802E79A0
		public static PassBreakAudit CanMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge); // 0x0000000181EFE8C0-0x0000000181EFF4B0
		private static bool CanMergeBackBufferAndCustomRenderTargets(CompilerContextData contextData, ref NativePassData nativePass, ref PassData passToMerge, int passIdToMerge); // 0x0000000181EFDFE0-0x0000000181EFE2B0
		private static bool TotalAttachmentsSizeExceedPixelStorageLimit(CompilerContextData contextData, ref NativePassData nativePass, ref FixedAttachmentArray<PassFragmentData> attachmentsToTryAdding); // 0x0000000181EFF710-0x0000000181EFFA40
		private static bool CanMergeNativeSubPass(CompilerContextData contextData, ref NativePassData nativePass, ref PassData passToMerge); // 0x0000000181EFE2D0-0x0000000181EFE8C0
		public static void TryMergeNativeSubPass(CompilerContextData contextData, ref NativePassData nativePass, ref PassData passToMerge); // 0x0000000181EFFA40-0x0000000181EFFFC0
		private void AddDepthAttachmentFromDepthInputAttachment(CompilerContextData contextData, [IsReadOnly] in PassFragmentData depthInputAttachment); // 0x0000000181EFDC60-0x0000000181EFDFE0
		private void AddDepthAttachmentFirstDuringMerge(CompilerContextData contextData, [IsReadOnly] in PassFragmentData depthAttachment); // 0x0000000181EFD960-0x0000000181EFDC60
		public static PassBreakAudit TryMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge); // 0x0000000181EFFFC0-0x0000000181F005C0
		public static void SetPassStatesForNativePass(CompilerContextData contextData, int nativePassId); // 0x0000000181EF0CC0-0x0000000181EF15A0
	}
}
