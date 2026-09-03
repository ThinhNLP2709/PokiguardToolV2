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
	internal struct OccluderHandles // TypeDefIndex: 12862
	{
		// Fields
		public TextureHandle occluderDepthPyramid; // 0x00
		public BufferHandle occlusionDebugOverlay; // 0x10
	
		// Methods
		public bool IsValid(); // 0x0000000181F41D90-0x0000000181F41DE0
		public void UseForOcclusionTest(IBaseRenderGraphBuilder builder); // 0x0000000181F41EA0-0x0000000181F41F60
		public void UseForOccluderUpdate(IBaseRenderGraphBuilder builder); // 0x0000000181F41DE0-0x0000000181F41EA0
	}
}
