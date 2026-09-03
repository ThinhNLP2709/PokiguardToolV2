/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct RenderGraphParameters // TypeDefIndex: 5921
	{
		// Fields
		[Obsolete("Not used anymore. The debugging tools use the name of the object identified by executionId. #from(6000.3)")]
		public string executionName; // 0x00
		public EntityId executionId; // 0x08
		public bool generateDebugData; // 0x10
		public int currentFrameIndex; // 0x14
		[Obsolete("Not supported anymore. Syncing with culling system brings performance regressions in most cases. #from(6000.5)")]
		public bool rendererListCulling; // 0x18
		public ScriptableRenderContext scriptableRenderContext; // 0x20
		public CommandBuffer commandBuffer; // 0x28
		internal bool invalidContextForTesting; // 0x30
		public RenderTextureUVOriginStrategy renderTextureUVOriginStrategy; // 0x34
	}
}
