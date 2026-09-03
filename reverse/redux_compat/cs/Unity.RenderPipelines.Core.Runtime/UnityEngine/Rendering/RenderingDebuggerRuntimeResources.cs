/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "R : Rendering Debugger Resources", Order = 100)]
	[ElementInfo(Order = 0)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal class RenderingDebuggerRuntimeResources : IRenderPipelineResources // TypeDefIndex: 5681
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_version; // 0x10
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		private enum Version // TypeDefIndex: 5682
		{
			Initial = 0,
			Last = 0,
			Count = 1
		}
	
		// Constructors
		public RenderingDebuggerRuntimeResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
