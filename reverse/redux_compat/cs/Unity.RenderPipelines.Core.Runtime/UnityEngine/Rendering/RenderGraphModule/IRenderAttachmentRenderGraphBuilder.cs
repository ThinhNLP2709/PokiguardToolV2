/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	public interface IRenderAttachmentRenderGraphBuilder : IBaseRenderGraphBuilder // TypeDefIndex: 5904
	{
		// Methods
		void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Write /* Metadata: 0x00662C00 */); // 0x0000000181ED9C40-0x0000000181ED9D40
		void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice);
		void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags = AccessFlags.None | AccessFlags.Read | AccessFlags.Write | AccessFlags.ReadWrite /* Metadata: 0x00662C01 */); // 0x0000000181ED9B60-0x0000000181ED9C40
		void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice);
		TextureHandle SetRandomAccessAttachment(TextureHandle tex, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read | AccessFlags.Write | AccessFlags.ReadWrite /* Metadata: 0x00662C02 */);
		BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C03 */);
		BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, bool preserveCounterValue, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C04 */);
	}
}
