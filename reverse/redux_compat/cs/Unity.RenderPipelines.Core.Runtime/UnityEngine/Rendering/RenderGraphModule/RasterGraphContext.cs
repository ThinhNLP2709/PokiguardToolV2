/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct RasterGraphContext : IDerivedRendergraphContext // TypeDefIndex: 5918
	{
		// Fields
		private InternalRenderGraphContext wrappedContext; // 0x00
		public RasterCommandBuffer cmd; // 0x08
		[NoAutoStaticsCleanup]
		internal static readonly RasterCommandBuffer rastercmd; // 0x00
	
		// Properties
		public RenderGraphDefaultResources defaultResources { get; } // 0x0000000181D956F0-0x0000000181D95710 
		public RenderGraphObjectPool renderGraphPool { get; } // 0x0000000181A23F00-0x0000000181A23F20 
	
		// Constructors
		static RasterGraphContext(); // 0x0000000181EDA050-0x0000000181EDA0E0
	
		// Methods
		public void FromInternalContext(InternalRenderGraphContext context); // 0x0000000181ED9E80-0x0000000181ED9F60
		[IsReadOnly]
		public TextureUVOrigin GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x0000000181ED9F60-0x0000000181ED9FC0
		TextureUVOrigin IDerivedRendergraphContext.GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x0000000181ED9FC0-0x0000000181EDA050
	}
}
