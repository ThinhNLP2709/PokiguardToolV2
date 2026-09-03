/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal enum PassBreakReason // TypeDefIndex: 6005
	{
		NotOptimized = 0,
		TargetSizeMismatch = 1,
		NextPassReadsTexture = 2,
		NextPassTargetsTexture = 3,
		NonRasterPass = 4,
		DifferentDepthTextures = 5,
		AttachmentLimitReached = 6,
		SubPassLimitReached = 7,
		EndOfGraph = 8,
		FRStateMismatch = 9,
		DifferentShadingRateImages = 10,
		DifferentShadingRateStates = 11,
		MultisampledShaderResolveMustBeLastPass = 12,
		ExtendedFeatureFlagsIncompatible = 13,
		PassMergingDisabled = 14,
		BackbufferInMultipleRenderTargetsNotSupported = 15,
		MixedAllDepthSlicesAndSingleDepthSlice = 16,
		Merged = 17,
		Count = 18
	}
}
