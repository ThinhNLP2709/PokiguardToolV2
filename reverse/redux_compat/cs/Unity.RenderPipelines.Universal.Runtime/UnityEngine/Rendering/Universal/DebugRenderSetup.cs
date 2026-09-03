/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DebugRenderSetup : IDisposable // TypeDefIndex: 9397
	{
		// Fields
		private readonly DebugHandler m_DebugHandler; // 0x10
		private readonly FilteringSettings m_FilteringSettings; // 0x18
		private readonly int m_Index; // 0x38
	
		// Properties
		private DebugDisplaySettingsMaterial MaterialSettings { get; } // 0x0000000181F718C0-0x0000000181F718F0 
		private DebugDisplaySettingsRendering RenderingSettings { get; } // 0x0000000181F718F0-0x0000000181F71920 
		private DebugDisplaySettingsLighting LightingSettings { get; } // 0x0000000181F71890-0x0000000181F718C0 
	
		// Constructors
		internal DebugRenderSetup(DebugHandler debugHandler, int index, FilteringSettings filteringSettings); // 0x0000000181F71830-0x0000000181F71890
	
		// Methods
		internal void Begin(RasterCommandBuffer cmd); // 0x0000000181F70DA0-0x0000000181F70E10
		internal void End(RasterCommandBuffer cmd); // 0x0000000181F714C0-0x0000000181F71530
		internal void CreateRendererList(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock, ref RendererListHandle rendererListHdl); // 0x0000000181F71160-0x0000000181F71430
		internal void DrawWithRendererList(RasterCommandBuffer cmd, ref RendererList rendererList); // 0x0000000181F71430-0x0000000181F714C0
		internal DrawingSettings CreateDrawingSettings(DrawingSettings drawingSettings); // 0x0000000181F70E10-0x0000000181F71160
		internal RenderStateBlock GetRenderStateBlock(RenderStateBlock renderStateBlock); // 0x0000000181F71530-0x0000000181F71830
		internal int GetIndex(); // 0x000000018047EDE0-0x000000018047EDF0
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
