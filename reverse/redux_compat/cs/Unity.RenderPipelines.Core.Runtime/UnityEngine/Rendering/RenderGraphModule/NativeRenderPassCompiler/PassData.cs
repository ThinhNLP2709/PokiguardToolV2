/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal struct PassData // TypeDefIndex: 5999
	{
		// Fields
		public int passId; // 0x00
		public RenderGraphPassType type; // 0x04
		public bool hasFoveatedRasterization; // 0x08
		public ExtendedFeatureFlags extendedFeatureFlags; // 0x0C
		public int tag; // 0x10
		public ShadingRateFragmentSize shadingRateFragmentSize; // 0x14
		public ShadingRateCombiner primitiveShadingRateCombiner; // 0x18
		public ShadingRateCombiner fragmentShadingRateCombiner; // 0x1C
		public PassMergeState mergeState; // 0x20
		public int nativePassIndex; // 0x24
		public int nativeSubPassIndex; // 0x28
		public int firstInput; // 0x2C
		public int numInputs; // 0x30
		public int firstOutput; // 0x34
		public int numOutputs; // 0x38
		public int firstFragment; // 0x3C
		public int numFragments; // 0x40
		public int firstFragmentInput; // 0x44
		public int numFragmentInputs; // 0x48
		public int firstSampledOnlyRaster; // 0x4C
		public int numSampledOnlyRaster; // 0x50
		public int firstRandomAccessResource; // 0x54
		public int numRandomAccessResources; // 0x58
		public int firstCreate; // 0x5C
		public int numCreated; // 0x60
		public int firstDestroy; // 0x64
		public int numDestroyed; // 0x68
		public int shadingRateImageIndex; // 0x6C
		public int fragmentInfoWidth; // 0x70
		public int fragmentInfoHeight; // 0x74
		public int fragmentInfoVolumeDepth; // 0x78
		public int fragmentInfoSamples; // 0x7C
		public int waitOnGraphicsFencePassId; // 0x80
		public int awaitingMyGraphicsFencePassId; // 0x84
		public bool asyncCompute; // 0x88
		public bool hasSideEffects; // 0x89
		public bool culled; // 0x8A
		public bool beginNativeSubpass; // 0x8B
		public bool fragmentInfoValid; // 0x8C
		public bool fragmentInfoHasDepth; // 0x8D
		public bool insertGraphicsFence; // 0x8E
		public bool hasShadingRateStates; // 0x8F
	
		// Properties
		public bool fragmentInfoHasShadingRateImage { get; } // 0x0000000181F01C90-0x0000000181F01CA0 
	
		// Constructors
		public PassData([IsReadOnly] in RenderGraphPass pass, int passIndex); // 0x0000000181F01B70-0x0000000181F01C90
	
		// Methods
		public Name GetName(CompilerContextData ctx); // 0x0000000181F014F0-0x0000000181F01530
		public void ResetAndInitialize([IsReadOnly] in RenderGraphPass pass, int passIndex); // 0x0000000181F01820-0x0000000181F01940
		[IsReadOnly]
		public ReadOnlySpan<PassOutputData> Outputs(CompilerContextData ctx); // 0x0000000181F01740-0x0000000181F017B0
		[IsReadOnly]
		public ReadOnlySpan<PassInputData> Inputs(CompilerContextData ctx); // 0x0000000181F01530-0x0000000181F015A0
		[IsReadOnly]
		public ReadOnlySpan<PassFragmentData> Fragments(CompilerContextData ctx); // 0x0000000181F01480-0x0000000181F014F0
		[IsReadOnly]
		public ReadOnlySpan<ResourceHandle> SampledTexturesIfRaster(CompilerContextData ctx); // 0x0000000181F01940-0x0000000181F019B0
		[IsReadOnly]
		public PassFragmentData ShadingRateImage(CompilerContextData ctx); // 0x0000000181F019B0-0x0000000181F019F0
		[IsReadOnly]
		public ReadOnlySpan<PassFragmentData> FragmentInputs(CompilerContextData ctx); // 0x0000000181F01410-0x0000000181F01480
		[IsReadOnly]
		public ReadOnlySpan<ResourceHandle> FirstUsedResources(CompilerContextData ctx); // 0x0000000181F013A0-0x0000000181F01410
		public ReadOnlySpan<PassRandomWriteData> RandomWriteTextures(CompilerContextData ctx); // 0x0000000181F017B0-0x0000000181F01820
		[IsReadOnly]
		public ReadOnlySpan<ResourceHandle> LastUsedResources(CompilerContextData ctx); // 0x0000000181F016D0-0x0000000181F01740
		private bool TrySetupAndValidateFragmentInfo([IsReadOnly] in ResourceHandle h, CompilerContextData ctx, out string errorMessage); // 0x0000000181F01A50-0x0000000181F01B70
		internal void TryAddFragment([IsReadOnly] in ResourceHandle h, CompilerContextData ctx, out string errorMessage); // 0x0000000181F01A20-0x0000000181F01A50
		internal void TryAddFragmentInput([IsReadOnly] in ResourceHandle h, CompilerContextData ctx, out string errorMessage); // 0x0000000181F019F0-0x0000000181F01A20
		internal void AddRandomAccessResource(); // 0x0000000181F010B0-0x0000000181F010C0
		internal void AddFirstUse([IsReadOnly] in ResourceHandle h, CompilerContextData ctx); // 0x0000000181F00E50-0x0000000181F00F80
		internal void AddLastUse([IsReadOnly] in ResourceHandle h, CompilerContextData ctx); // 0x0000000181F00F80-0x0000000181F010B0
		[IsReadOnly]
		internal bool IsUsedAsFragment([IsReadOnly] in ResourceHandle h, CompilerContextData ctx); // 0x0000000181F015A0-0x0000000181F016D0
		internal void DisconnectFromResources(CompilerContextData ctx, Stack<ResourceHandle> unusedVersionedResourceIdCullingStack = null, int type = 0 /* Metadata: 0x00662CFE */); // 0x0000000181F010C0-0x0000000181F013A0
	}
}
