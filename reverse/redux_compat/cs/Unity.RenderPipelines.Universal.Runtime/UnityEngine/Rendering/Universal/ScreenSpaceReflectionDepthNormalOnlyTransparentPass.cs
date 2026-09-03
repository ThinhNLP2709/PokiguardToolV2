/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal.Internal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class ScreenSpaceReflectionDepthNormalOnlyTransparentPass : DepthNormalOnlyPass // TypeDefIndex: 9737
	{
		// Fields
		private static readonly ProfilingSampler m_ProfilingSampler; // 0x00
		private readonly CopyDepthPass m_CopyDepthPass; // 0x90
	
		// Constructors
		public ScreenSpaceReflectionDepthNormalOnlyTransparentPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask); // 0x0000000181FCE4B0-0x0000000181FCE680
		static ScreenSpaceReflectionDepthNormalOnlyTransparentPass(); // 0x0000000181FCE420-0x0000000181FCE4B0
	
		// Methods
		public void UpdateRenderPassEvent(RenderPassEvent evt); // 0x00000001805D5560-0x00000001805D5570
		protected override SortingCriteria GetSortingCriteria(UniversalCameraData cameraData); // 0x0000000181FCDE10-0x0000000181FCDE30
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FCDE30-0x0000000181FCE420
	}
}
