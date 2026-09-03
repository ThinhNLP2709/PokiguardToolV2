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
	[Obsolete("RenderGraphContext is deprecated, use RasterGraphContext/ComputeGraphContext/UnsafeGraphContext instead.", true)]
	public struct RenderGraphContext : IDerivedRendergraphContext // TypeDefIndex: 5901
	{
		// Fields
		private InternalRenderGraphContext wrappedContext; // 0x00
	
		// Properties
		public ScriptableRenderContext renderContext { get; } // 0x0000000181433720-0x0000000181433740 
		public CommandBuffer cmd { get; } // 0x0000000181A23EB0-0x0000000181A23ED0 
		public RenderGraphObjectPool renderGraphPool { get; } // 0x0000000181A23F00-0x0000000181A23F20 
		public RenderGraphDefaultResources defaultResources { get; } // 0x0000000181D956F0-0x0000000181D95710 
	
		// Methods
		public void FromInternalContext(InternalRenderGraphContext context); // 0x0000000180E02C90-0x0000000180E02CA0
		[IsReadOnly]
		public TextureUVOrigin GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x00000001802E7860-0x00000001802E7870
		TextureUVOrigin IDerivedRendergraphContext.GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x00000001802E7860-0x00000001802E7870
	}
}
