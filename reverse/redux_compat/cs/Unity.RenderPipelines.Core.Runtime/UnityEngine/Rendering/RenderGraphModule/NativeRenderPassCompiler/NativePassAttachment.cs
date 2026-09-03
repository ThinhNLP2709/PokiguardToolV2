/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	[DebuggerDisplay("Res({handle.index}) : {loadAction} : {storeAction} : {memoryless}")]
	[IsReadOnly]
	internal struct NativePassAttachment // TypeDefIndex: 6000
	{
		// Fields
		public readonly ResourceHandle handle; // 0x00
		public readonly RenderBufferLoadAction loadAction; // 0x0C
		public readonly RenderBufferStoreAction storeAction; // 0x10
		public readonly bool memoryless; // 0x14
		public readonly int mipLevel; // 0x18
		public readonly int depthSlice; // 0x1C
	
		// Constructors
		public NativePassAttachment([IsReadOnly] in ResourceHandle handle, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, bool memoryless, int mipLevel, int depthSlice); // 0x0000000181EF1720-0x0000000181EF1750
	}
}
