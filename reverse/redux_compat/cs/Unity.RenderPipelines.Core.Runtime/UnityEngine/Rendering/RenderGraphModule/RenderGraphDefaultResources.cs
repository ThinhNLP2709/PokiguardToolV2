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
	public class RenderGraphDefaultResources // TypeDefIndex: 5925
	{
		// Fields
		private RTHandle m_BlackTexture2D; // 0x10
		private RTHandle m_WhiteTexture2D; // 0x18
		private RTHandle m_ShadowTexture2D; // 0x20
		[CompilerGenerated]
		private TextureHandle _blackTexture_k__BackingField; // 0x28
		[CompilerGenerated]
		private TextureHandle _whiteTexture_k__BackingField; // 0x38
		[CompilerGenerated]
		private TextureHandle _clearTextureXR_k__BackingField; // 0x48
		[CompilerGenerated]
		private TextureHandle _magentaTextureXR_k__BackingField; // 0x58
		[CompilerGenerated]
		private TextureHandle _blackTextureXR_k__BackingField; // 0x68
		[CompilerGenerated]
		private TextureHandle _blackTextureArrayXR_k__BackingField; // 0x78
		[CompilerGenerated]
		private TextureHandle _blackUIntTextureXR_k__BackingField; // 0x88
		[CompilerGenerated]
		private TextureHandle _blackTexture3DXR_k__BackingField; // 0x98
		[CompilerGenerated]
		private TextureHandle _whiteTextureXR_k__BackingField; // 0xA8
		[CompilerGenerated]
		private TextureHandle _defaultShadowTexture_k__BackingField; // 0xB8
	
		// Properties
		public TextureHandle blackTexture { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public TextureHandle whiteTexture { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001817273D0-0x00000001817273E0 0x0000000181727460-0x0000000181727470
		public TextureHandle clearTextureXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001817273C0-0x00000001817273D0 0x0000000181727450-0x0000000181727460
		public TextureHandle magentaTextureXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181B2AD40-0x0000000181B2AD50 0x0000000181E75F40-0x0000000181E75F50
		public TextureHandle blackTextureXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D97A10-0x0000000181D97A20 0x0000000181E75F50-0x0000000181E75F60
		public TextureHandle blackTextureArrayXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 0x0000000181E75F30-0x0000000181E75F40
		public TextureHandle blackUIntTextureXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181C2D2F0-0x0000000181C2D300 0x0000000181E75F60-0x0000000181E75F70
		public TextureHandle blackTexture3DXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E75F10-0x0000000181E75F20 0x0000000181E75F20-0x0000000181E75F30
		public TextureHandle whiteTextureXR { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181EE0880-0x0000000181EE0890 0x0000000181EE08A0-0x0000000181EE08B0
		public TextureHandle defaultShadowTexture { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181EE0870-0x0000000181EE0880 0x0000000181EE0890-0x0000000181EE08A0
	
		// Constructors
		internal RenderGraphDefaultResources(); // 0x0000000181EE0850-0x0000000181EE0870
	
		// Methods
		private void InitDefaultResourcesIfNeeded(); // 0x0000000181EE0310-0x0000000181EE05D0
		internal void Cleanup(); // 0x0000000181EE0290-0x0000000181EE0310
		internal void InitializeForRendering(RenderGraph renderGraph); // 0x0000000181EE05D0-0x0000000181EE0850
	}
}
