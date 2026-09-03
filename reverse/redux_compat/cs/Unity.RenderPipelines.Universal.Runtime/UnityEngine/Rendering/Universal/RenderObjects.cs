/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[ExcludeFromPreset]
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.Universal", null, null)]
	[Tooltip("Render Objects simplifies the injection of additional render passes by exposing a selection of commonly used settings.")]
	public class RenderObjects : ScriptableRendererFeature // TypeDefIndex: 9719
	{
		// Fields
		public RenderObjectsSettings settings; // 0x28
		private RenderObjectsPass renderObjectsPass; // 0x30
	
		// Nested types
		[Serializable]
		public class RenderObjectsSettings // TypeDefIndex: 9720
		{
			// Fields
			public string passTag; // 0x10
			public RenderPassEvent Event; // 0x18
			public FilterSettings filterSettings; // 0x20
			public Material overrideMaterial; // 0x28
			public int overrideMaterialPassIndex; // 0x30
			public Shader overrideShader; // 0x38
			public int overrideShaderPassIndex; // 0x40
			public OverrideMaterialMode overrideMode; // 0x44
			public bool overrideDepthState; // 0x48
			public CompareFunction depthCompareFunction; // 0x4C
			public bool enableWrite; // 0x50
			public StencilStateData stencilSettings; // 0x58
			public CustomCameraSettings cameraSettings; // 0x60
			public bool depthInputAttachment; // 0x68
	
			// Nested types
			public enum OverrideMaterialMode // TypeDefIndex: 9721
			{
				None = 0,
				Material = 1,
				Shader = 2
			}
	
			// Constructors
			public RenderObjectsSettings(); // 0x0000000181FCBAE0-0x0000000181FCBC10
		}
	
		[Serializable]
		public class FilterSettings // TypeDefIndex: 9722
		{
			// Fields
			public RenderQueueType RenderQueueType; // 0x10
			public LayerMask LayerMask; // 0x14
			public string[] PassNames; // 0x18
	
			// Constructors
			public FilterSettings(); // 0x0000000181FC2D70-0x0000000181FC2DA0
		}
	
		[Serializable]
		public class CustomCameraSettings // TypeDefIndex: 9723
		{
			// Fields
			public bool overrideCamera; // 0x10
			public bool restoreCamera; // 0x11
			public Vector4 offset; // 0x14
			public float cameraFieldOfView; // 0x24
	
			// Constructors
			public CustomCameraSettings(); // 0x0000000181FC1660-0x0000000181FC1680
		}
	
		// Constructors
		public RenderObjects(); // 0x0000000181FCBFC0-0x0000000181FCC140
	
		// Methods
		public override void Create(); // 0x0000000181FCBCC0-0x0000000181FCBFC0
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FCBC10-0x0000000181FCBCC0
	}
}
