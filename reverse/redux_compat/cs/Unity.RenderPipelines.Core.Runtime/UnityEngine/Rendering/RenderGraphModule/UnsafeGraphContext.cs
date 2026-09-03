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
	public class UnsafeGraphContext : IDerivedRendergraphContext // TypeDefIndex: 5920
	{
		// Fields
		private InternalRenderGraphContext wrappedContext; // 0x10
		public UnsafeCommandBuffer cmd; // 0x18
		internal static readonly UnsafeCommandBuffer unsCmd; // 0x00
	
		// Properties
		public RenderGraphDefaultResources defaultResources { get; } // 0x0000000181ED9A20-0x0000000181ED9A40 
		public RenderGraphObjectPool renderGraphPool { get; } // 0x0000000181ED9A40-0x0000000181ED9A60 
	
		// Constructors
		public UnsafeGraphContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static UnsafeGraphContext(); // 0x0000000181EF09A0-0x0000000181EF0B90
	
		// Methods
		public void FromInternalContext(InternalRenderGraphContext context); // 0x0000000181EF08C0-0x0000000181EF09A0
		public TextureUVOrigin GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x0000000181ED9930-0x0000000181ED9990
		TextureUVOrigin IDerivedRendergraphContext.GetTextureUVOrigin([IsReadOnly] in TextureHandle textureHandle); // 0x0000000181ED9930-0x0000000181ED9990
	}
}
