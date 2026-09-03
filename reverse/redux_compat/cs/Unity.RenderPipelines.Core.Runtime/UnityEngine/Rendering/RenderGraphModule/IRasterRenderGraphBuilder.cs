/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public interface IRasterRenderGraphBuilder : IRenderAttachmentRenderGraphBuilder // TypeDefIndex: 5907
	{
		// Methods
		void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C05 */); // 0x0000000181ED9A60-0x0000000181ED9B60
		void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice);
		void SetShadingRateImageAttachment([IsReadOnly] in TextureHandle tex);
		void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize);
		void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner);
		void SetExtendedFeatureFlags(ExtendedFeatureFlags extendedFeatureFlags);
		void SetRenderFunc<PassData>(BaseRenderFunc<PassData, RasterGraphContext> renderFunc)
			where PassData : class, new();
	}
}
