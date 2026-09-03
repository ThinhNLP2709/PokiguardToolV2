/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
	internal abstract class RenderGraphPass // TypeDefIndex: 5930
	{
		// Fields
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _index_k__BackingField; // 0x18
		[CompilerGenerated]
		private RenderGraphPassType _type_k__BackingField; // 0x1C
		[CompilerGenerated]
		private ProfilingSampler _customSampler_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _enableAsyncCompute_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _allowPassCulling_k__BackingField; // 0x29
		[CompilerGenerated]
		private bool _allowGlobalState_k__BackingField; // 0x2A
		[CompilerGenerated]
		private bool _enableFoveatedRasterization_k__BackingField; // 0x2B
		[CompilerGenerated]
		private ExtendedFeatureFlags _extendedFeatureFlags_k__BackingField; // 0x2C
		[CompilerGenerated]
		private TextureAccess _depthAccess_k__BackingField; // 0x30
		[CompilerGenerated]
		private TextureAccess[] _colorBufferAccess_k__BackingField; // 0x50
		[CompilerGenerated]
		private int _colorBufferMaxIndex_k__BackingField; // 0x58
		[CompilerGenerated]
		private bool _hasShadingRateImage_k__BackingField; // 0x5C
		[CompilerGenerated]
		private TextureAccess _shadingRateAccess_k__BackingField; // 0x60
		[CompilerGenerated]
		private bool _hasShadingRateStates_k__BackingField; // 0x7C
		[CompilerGenerated]
		private ShadingRateFragmentSize _shadingRateFragmentSize_k__BackingField; // 0x80
		[CompilerGenerated]
		private ShadingRateCombiner _primitiveShadingRateCombiner_k__BackingField; // 0x84
		[CompilerGenerated]
		private ShadingRateCombiner _fragmentShadingRateCombiner_k__BackingField; // 0x88
		[CompilerGenerated]
		private TextureAccess[] _fragmentInputAccess_k__BackingField; // 0x90
		[CompilerGenerated]
		private int _fragmentInputMaxIndex_k__BackingField; // 0x98
		[CompilerGenerated]
		private RandomWriteResourceInfo[] _randomAccessResource_k__BackingField; // 0xA0
		[CompilerGenerated]
		private int _randomAccessResourceMaxIndex_k__BackingField; // 0xA8
		[CompilerGenerated]
		private bool _generateDebugData_k__BackingField; // 0xAC
		[CompilerGenerated]
		private bool _allowRendererListCulling_k__BackingField; // 0xAD
		public List<ResourceHandle>[] resourceReadLists; // 0xB0
		public List<ResourceHandle>[] resourceWriteLists; // 0xB8
		public List<ResourceHandle>[] transientResourceList; // 0xC0
		public List<RendererListHandle> usedRendererListList; // 0xC8
		public List<ValueTuple<TextureHandle, int>> setGlobalsList; // 0xD0
		public bool useAllGlobalTextures; // 0xD8
		public List<ResourceHandle> implicitReadsList; // 0xE0
	
		// Properties
		public string name { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public int index { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public RenderGraphPassType type { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public ProfilingSampler customSampler { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public bool enableAsyncCompute { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public bool allowPassCulling { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018052D500-0x000000018052D510 0x000000018052D7C0-0x000000018052D7D0
		public bool allowGlobalState { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018052D510-0x000000018052D520 0x000000018052D7D0-0x000000018052D910
		public bool enableFoveatedRasterization { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181EE3C10-0x0000000181EE3C20 0x0000000181EE2460-0x0000000181EE2470
		public ExtendedFeatureFlags extendedFeatureFlags { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public TextureAccess depthAccess { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181EE3BF0-0x0000000181EE3C10 0x0000000181EE3C50-0x0000000181EE3C70
		public TextureAccess[] colorBufferAccess { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public int colorBufferMaxIndex { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		public bool hasShadingRateImage { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001815D7D00-0x00000001815D7D10 0x0000000181EE3C70-0x0000000181EE3C80
		public TextureAccess shadingRateAccess { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181EE3C30-0x0000000181EE3C50 0x0000000181EE3C90-0x0000000181EE3CB0
		public bool hasShadingRateStates { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018198E6D0-0x000000018198E6E0 0x00000001819DD470-0x00000001819DD480
		public ShadingRateFragmentSize shadingRateFragmentSize { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x0000000180CC3E80-0x0000000180CC3E90
		public ShadingRateCombiner primitiveShadingRateCombiner { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
		public ShadingRateCombiner fragmentShadingRateCombiner { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public TextureAccess[] fragmentInputAccess { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public int fragmentInputMaxIndex { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
		public RandomWriteResourceInfo[] randomAccessResource { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public int randomAccessResourceMaxIndex { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001806671D0-0x00000001806671E0 0x0000000181EE3C80-0x0000000181EE3C90
		public bool generateDebugData { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181EE3C20-0x0000000181EE3C30 0x0000000181EE2470-0x0000000181EE2480
		public bool allowRendererListCulling { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181EE3BE0-0x0000000181EE3BF0 0x0000000181EE1370-0x0000000181EE1380
	
		// Nested types
		public struct RandomWriteResourceInfo // TypeDefIndex: 5931
		{
			// Fields
			public ResourceHandle h; // 0x00
			public bool preserveCounterValue; // 0x0C
		}
	
		// Constructors
		public RenderGraphPass(); // 0x0000000181EE37B0-0x0000000181EE3BE0
	
		// Methods
		public abstract void Execute(InternalRenderGraphContext renderGraphContext);
		public abstract void Release(RenderGraphObjectPool pool);
		public abstract bool HasRenderFunc();
		public abstract int GetRenderFuncHash();
		public void Clear(); // 0x0000000181EE1380-0x0000000181EE1530
		public bool HasRenderAttachments(); // 0x0000000181EE2480-0x0000000181EE2530
		public bool IsTransient([IsReadOnly] in ResourceHandle res); // 0x0000000181EE28F0-0x0000000181EE2A90
		public bool IsWritten([IsReadOnly] in ResourceHandle res); // 0x0000000181EE2A90-0x0000000181EE2C30
		public bool IsRead([IsReadOnly] in ResourceHandle res); // 0x0000000181EE26D0-0x0000000181EE28F0
		public bool IsAttachment([IsReadOnly] in TextureHandle res); // 0x0000000181EE2530-0x0000000181EE26D0
		public void AddResourceWrite([IsReadOnly] in ResourceHandle res); // 0x0000000181EE1110-0x0000000181EE1240
		public void AddResourceRead([IsReadOnly] in ResourceHandle res); // 0x0000000181EE0FE0-0x0000000181EE1110
		public void AddTransientResource([IsReadOnly] in ResourceHandle res); // 0x0000000181EE1240-0x0000000181EE1370
		public void UseRendererList([IsReadOnly] in RendererListHandle rendererList); // 0x0000000181EE36F0-0x0000000181EE37B0
		public void EnableAsyncCompute(bool value); // 0x00000001804AE490-0x00000001804AE4A0
		public void AllowPassCulling(bool value); // 0x000000018052D7C0-0x000000018052D7D0
		public void EnableFoveatedRasterization(bool value); // 0x0000000181EE2460-0x0000000181EE2470
		public void AllowRendererListCulling(bool value); // 0x0000000181EE1370-0x0000000181EE1380
		public void AllowGlobalState(bool value); // 0x000000018052D7D0-0x000000018052D910
		public void GenerateDebugData(bool value); // 0x0000000181EE2470-0x0000000181EE2480
		public void SetColorBuffer([IsReadOnly] in TextureHandle resource, int index); // 0x0000000181EE2DF0-0x0000000181EE2ED0
		public void SetColorBufferRaw([IsReadOnly] in TextureHandle resource, int index, AccessFlags accessFlags, int mipLevel, int depthSlice); // 0x0000000181EE2C30-0x0000000181EE2DF0
		public void SetFragmentInputRaw([IsReadOnly] in TextureHandle resource, int index, AccessFlags accessFlags, int mipLevel, int depthSlice); // 0x0000000181EE30E0-0x0000000181EE32B0
		public void SetRandomWriteResourceRaw([IsReadOnly] in ResourceHandle resource, int index, bool preserveCounterValue, AccessFlags accessFlags); // 0x0000000181EE32B0-0x0000000181EE3580
		public void SetDepthBuffer([IsReadOnly] in TextureHandle resource, DepthAccess flags); // 0x0000000181EE3060-0x0000000181EE30D0
		public void SetDepthBufferRaw([IsReadOnly] in TextureHandle resource, AccessFlags accessFlags, int mipLevel, int depthSlice); // 0x0000000181EE2ED0-0x0000000181EE3060
		private void ComputeTextureHash(ref HashFNV1A32 generator, [IsReadOnly] in ResourceHandle handle, RenderGraphResourceRegistry resources); // 0x0000000181EE1FC0-0x0000000181EE2460
		private static void ComputeHashForTextureAccess(ref HashFNV1A32 generator, [IsReadOnly] in ResourceHandle handle, [IsReadOnly] in TextureAccess textureAccess); // 0x0000000181EE1530-0x0000000181EE15C0
		public void ComputeHash(ref HashFNV1A32 generator, RenderGraphResourceRegistry resources); // 0x0000000181EE15C0-0x0000000181EE1FC0
		public void SetShadingRateImageRaw([IsReadOnly] in TextureHandle shadingRateImage); // 0x0000000181EE3600-0x0000000181EE3650
		public void SetShadingRateImage([IsReadOnly] in TextureHandle shadingRateImage, AccessFlags accessFlags, int mipLevel, int depthSlice); // 0x0000000181EE3650-0x0000000181EE36F0
		public void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize); // 0x0000000181EE35D0-0x0000000181EE3600
		public void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000181EE3580-0x0000000181EE35D0
		public void SetExtendedFeatureFlags(ExtendedFeatureFlags value); // 0x0000000181EE30D0-0x0000000181EE30E0
	}
}
