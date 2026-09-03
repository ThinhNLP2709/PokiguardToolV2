/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.Util
{
	[Serializable]
	[Category("Resources/Render Graph Helper Function Resources")]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal class RenderGraphUtilsResources : IRenderPipelineResources // TypeDefIndex: 5983
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[ResourcePath("Shaders/CoreCopy.shader", SearchType.ProjectPath)]
		[SerializeField]
		internal Shader m_CoreCopyPS; // 0x18
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public Shader coreCopyPS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181EEAA20-0x0000000181EEAA90
	
		// Nested types
		public enum Version // TypeDefIndex: 5984
		{
			Initial = 0,
			Latest = 0,
			Count = 1
		}
	
		// Constructors
		public RenderGraphUtilsResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
