/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DebugRendererLists // TypeDefIndex: 9396
	{
		// Fields
		private readonly DebugHandler m_DebugHandler; // 0x10
		private readonly FilteringSettings m_FilteringSettings; // 0x18
		private List<DebugRenderSetup> m_DebugRenderSetups; // 0x38
		private List<RendererList> m_ActiveDebugRendererList; // 0x40
		private List<RendererListHandle> m_ActiveDebugRendererListHdl; // 0x48
	
		// Constructors
		public DebugRendererLists(DebugHandler debugHandler, FilteringSettings filteringSettings); // 0x0000000181F72A30-0x0000000181F72B80
	
		// Methods
		private void CreateDebugRenderSetups(FilteringSettings filteringSettings); // 0x0000000181F71920-0x0000000181F71AA0
		private void DisposeDebugRenderLists(); // 0x0000000181F723F0-0x0000000181F72520
		internal void CreateRendererListsWithDebugRenderState(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock); // 0x0000000181F71AA0-0x0000000181F723F0
		internal void PrepareRendererListForRasterPass(IRasterRenderGraphBuilder builder); // 0x0000000181F72890-0x0000000181F72A30
		internal void DrawWithRendererList(RasterCommandBuffer cmd); // 0x0000000181F72520-0x0000000181F72890
	}
}
