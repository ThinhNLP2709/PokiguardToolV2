/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[Obsolete("Moved to UniversalRenderPipelineRuntimeXRResources on GraphicsSettings. #from(2023.3)")]
	public class XRSystemData : ScriptableObject // TypeDefIndex: 9465
	{
		// Fields
		[Obsolete("Moved to UniversalRenderPipelineRuntimeXRResources on GraphicsSettings. #from(2023.3)")]
		public ShaderResources shaders; // 0x18
	
		// Nested types
		[Serializable]
		[Obsolete("Moved to UniversalRenderPipelineRuntimeXRResources on GraphicsSettings. #from(2023.3)")]
		[ReloadGroup]
		public sealed class ShaderResources // TypeDefIndex: 9466
		{
			// Fields
			[Reload("Shaders/XR/XROcclusionMesh.shader", ReloadAttribute.Package.Root)]
			public Shader xrOcclusionMeshPS; // 0x10
			[Reload("Shaders/XR/XRMirrorView.shader", ReloadAttribute.Package.Root)]
			public Shader xrMirrorViewPS; // 0x18
	
			// Constructors
			public ShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public XRSystemData(); // 0x00000001805F5FD0-0x00000001805F5FE0
	}
}
