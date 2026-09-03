/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal struct ResourceUnversionedData // TypeDefIndex: 6009
	{
		// Fields
		public int versionedDataOffset; // 0x00
		public int versionedDataCount; // 0x04
		public int readerDataOffset; // 0x08
		public int maxReadersPerVersion; // 0x0C
		public int lastUsePassID; // 0x10
		public int lastWritePassID; // 0x14
		public int firstUsePassID; // 0x18
		public int latestVersionNumber; // 0x1C
		public readonly bool isImported; // 0x20
		public bool memoryLess; // 0x21
		public int tag; // 0x24
		public readonly int width; // 0x28
		public readonly int height; // 0x2C
		public readonly int volumeDepth; // 0x30
		public readonly int msaaSamples; // 0x34
		public readonly GraphicsFormat graphicsFormat; // 0x38
		public readonly bool clear; // 0x3C
		public readonly bool discard; // 0x3D
		public readonly bool bindMS; // 0x3E
		public readonly bool isBackBuffer; // 0x3F
		public TextureUVOriginSelection textureUVOrigin; // 0x40
	
		// Constructors
		public ResourceUnversionedData(TextureResource rll, ref RenderTargetInfo info, ref TextureDesc desc, bool isResBackBuffer); // 0x0000000181F01FA0-0x0000000181F02030
		public ResourceUnversionedData(IRenderGraphResource rll, ref BufferDesc _, bool isResBackBuffer); // 0x0000000181F01F30-0x0000000181F01FA0
		public ResourceUnversionedData(IRenderGraphResource rll, ref RayTracingAccelerationStructureDesc _, bool isResBackBuffer); // 0x0000000181F01F30-0x0000000181F01FA0
	
		// Methods
		public string GetName(CompilerContextData ctx, [IsReadOnly] in ResourceHandle h); // 0x0000000181F01EE0-0x0000000181F01F10
		public void InitializeNullResource(); // 0x0000000181F01F10-0x0000000181F01F30
	}
}
