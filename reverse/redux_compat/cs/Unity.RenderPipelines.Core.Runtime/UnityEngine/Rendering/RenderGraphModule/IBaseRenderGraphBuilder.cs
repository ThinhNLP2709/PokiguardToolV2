/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public interface IBaseRenderGraphBuilder : IDisposable // TypeDefIndex: 5903
	{
		// Methods
		void UseTexture([IsReadOnly] in TextureHandle input, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662BFD */);
		void UseGlobalTexture(int propertyId, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662BFE */);
		void UseAllGlobalTextures(bool enable);
		void SetGlobalTextureAfterPass([IsReadOnly] in TextureHandle input, int propertyId);
		BufferHandle UseBuffer([IsReadOnly] in BufferHandle input, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662BFF */);
		TextureHandle CreateTransientTexture([IsReadOnly] in TextureDesc desc);
		TextureHandle CreateTransientTexture([IsReadOnly] in TextureHandle texture);
		BufferHandle CreateTransientBuffer([IsReadOnly] in BufferDesc desc);
		BufferHandle CreateTransientBuffer([IsReadOnly] in BufferHandle computebuffer);
		void UseRendererList([IsReadOnly] in RendererListHandle input);
		void EnableAsyncCompute(bool value);
		void AllowPassCulling(bool value);
		void AllowGlobalStateModification(bool value);
		void EnableFoveatedRasterization(bool value);
		void GenerateDebugData(bool value);
	}
}
