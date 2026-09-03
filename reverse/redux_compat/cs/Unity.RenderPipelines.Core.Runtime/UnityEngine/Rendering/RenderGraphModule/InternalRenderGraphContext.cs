/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public class InternalRenderGraphContext // TypeDefIndex: 5916
	{
		// Fields
		internal ScriptableRenderContext renderContext; // 0x10
		internal CommandBuffer cmd; // 0x18
		internal RenderGraphObjectPool renderGraphPool; // 0x20
		internal RenderGraphDefaultResources defaultResources; // 0x28
		internal RenderGraphPass executingPass; // 0x30
		internal CompilerContextData compilerContext; // 0x38
		internal bool contextlessTesting; // 0x40
	
		// Constructors
		public InternalRenderGraphContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
