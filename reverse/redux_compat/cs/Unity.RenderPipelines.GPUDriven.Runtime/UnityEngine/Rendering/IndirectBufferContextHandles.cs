/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct IndirectBufferContextHandles // TypeDefIndex: 12875
	{
		// Fields
		public BufferHandle instanceBuffer; // 0x00
		public BufferHandle instanceInfoBuffer; // 0x0C
		public BufferHandle dispatchArgsBuffer; // 0x18
		public BufferHandle drawArgsBuffer; // 0x24
		public BufferHandle drawInfoBuffer; // 0x30
	
		// Methods
		public void UseForOcclusionTest(IBaseRenderGraphBuilder builder); // 0x0000000181F389F0-0x0000000181F38D80
	}
}
