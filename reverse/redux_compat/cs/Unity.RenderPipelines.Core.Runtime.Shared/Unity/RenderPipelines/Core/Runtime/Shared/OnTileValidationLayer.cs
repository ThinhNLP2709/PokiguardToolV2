/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 77: Unity.RenderPipelines.Core.Runtime.Shared.dll - Assembly: Unity.RenderPipelines.Core.Runtime.Shared, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15888-15894

namespace Unity.RenderPipelines.Core.Runtime.Shared
{
	internal sealed class OnTileValidationLayer : RenderGraphValidationLayer // TypeDefIndex: 15892
	{
		// Fields
		private const int k_InitialTextureHandleSize = 20; // Metadata: 0x006AA1EC
		private const int k_InitialGlobalTexturesAfterPass = 6; // Metadata: 0x006AA1ED
		private const int k_NotTracked = 0; // Metadata: 0x006AA1EE
		private const int k_TrackedNotYetUsed = -1; // Metadata: 0x006AA1EF
		private Pass m_CurrentPass; // 0x10
		private RenderPassInfo m_LastNonRasterPassInfo; // 0x48
		private bool m_InputAttachmentsHaveOnTileResource; // 0x58
		private int m_NumberOfPasses; // 0x5C
		private int m_LastNonRasterPassIndex; // 0x60
		[CompilerGenerated]
		private RenderGraph _renderGraph_k__BackingField; // 0x68
		private DynamicArray<int> m_HandleStates; // 0x70
		private const string k_ErrorMessageValidationIssue = "The On-Tile Validation layer has detected an issue: "; // Metadata: 0x006AA1F0
		private const string k_ErrorMessageHowToResolveDefault = "Disable the On-Tile Validation Layer or ensure that all render passes meet the constraints of this layer.\n"; // Metadata: 0x006AA225
		[CompilerGenerated]
		private string _errorMessageHowToResolve_k__BackingField; // 0x78
		private const string k_UseTexture = "UseTexture"; // Metadata: 0x006AA291
		private const string k_SetRenderAttachment = "SetRenderAttachment"; // Metadata: 0x006AA29C
		private const string k_SetRenderAttachmentDepth = "SetRenderAttachmentDepth"; // Metadata: 0x006AA2B0
		private const string k_SetGlobalTextureAfterPass = "SetGlobalTextureAfterPass"; // Metadata: 0x006AA2C9
	
		// Properties
		internal RenderGraph renderGraph { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public string errorMessageHowToResolve { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
	
		// Nested types
		private struct Pass // TypeDefIndex: 15893
		{
			// Fields
			public RenderGraphValidationLayer.RenderPassInfo info; // 0x00
			public TextureHandle[] renderAttachments; // 0x10
			public NativeList<TextureHandle> globalTexturesAfterPass; // 0x18
			public TextureHandle renderAttachmentDepth; // 0x20
			public int renderCount; // 0x30
	
			// Methods
			public void Init(); // 0x0000000181E38290-0x0000000181E38370
			public void Clear(); // 0x0000000181E381E0-0x0000000181E38290
		}
	
		// Constructors
		public OnTileValidationLayer(); // 0x0000000181E38060-0x0000000181E381E0
	
		// Methods
		private void ValidateNoNonRasterPassInbetween([IsReadOnly] in TextureHandle input); // 0x0000000181E36D20-0x0000000181E36DD0
		private void ThrowNoNonRasterPassInBetween([IsReadOnly] in TextureHandle input); // 0x0000000181E37A80-0x0000000181E37C30
		private void ThrowTextureSamplingException([IsReadOnly] in TextureHandle input, string methodName); // 0x0000000181E37DE0-0x0000000181E37F90
		private void ThrowNotRasterPassException([IsReadOnly] in TextureHandle input, string methodName); // 0x0000000181E37C30-0x0000000181E37DE0
		public override void UseTexture([IsReadOnly] in TextureHandle input, AccessFlags flags); // 0x0000000181E37F90-0x0000000181E38000
		public override void SetGlobalTextureAfterPass([IsReadOnly] in TextureHandle input, int propertyId); // 0x0000000181E377A0-0x0000000181E377B0
		private void ValidateRenderAttachment([IsReadOnly] in TextureHandle tex, string methodName); // 0x0000000181E38000-0x0000000181E38060
		public override void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181E37960-0x0000000181E37A80
		public override void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181E378B0-0x0000000181E37960
		public override void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181E377B0-0x0000000181E37830
		public override void OnPassAddedBegin([IsReadOnly] in RenderPassInfo renderPassInfo); // 0x0000000181E37470-0x0000000181E37540
		public override void OnPassAddedDispose(); // 0x0000000181E37540-0x0000000181E37710
		public void Add([IsReadOnly] in TextureHandle handle); // 0x0000000181E371B0-0x0000000181E37220
		private void AddFast([IsReadOnly] in TextureHandle handle); // 0x0000000181E37120-0x0000000181E371B0
		public void Remove([IsReadOnly] in TextureHandle handle); // 0x0000000181E37710-0x0000000181E377A0
		public override void Clear(); // 0x0000000181E37220-0x0000000181E37280
		private void EnsureHandleStateCapacity([IsReadOnly] in TextureHandle handle); // 0x0000000181E37290-0x0000000181E37360
		private int GetHandleState([IsReadOnly] in TextureHandle handle); // 0x0000000181E37360-0x0000000181E373E0
		private bool IsTrackedOnTile([IsReadOnly] in TextureHandle handle); // 0x0000000181E37450-0x0000000181E37470
		private int GetLastRasterPass([IsReadOnly] in TextureHandle handle); // 0x0000000181E373E0-0x0000000181E37450
		private void SetLastRasterPass([IsReadOnly] in TextureHandle handle, int lastRasterPass); // 0x0000000181E37830-0x0000000181E378B0
		public override void Dispose(); // 0x0000000181E37280-0x0000000181E37290
	}
}
