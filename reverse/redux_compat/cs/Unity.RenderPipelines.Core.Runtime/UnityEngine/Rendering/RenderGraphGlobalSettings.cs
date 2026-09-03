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
	[CategoryInfo(Name = "Render Graph", Order = 50)]
	[ElementInfo(Order = 0)]
	[SupportedOnRenderPipeline(new Type[0])]
	public class RenderGraphGlobalSettings : IRenderPipelineGraphicsSettings // TypeDefIndex: 5651
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_version; // 0x10
		[RecreatePipelineOnChange]
		[SerializeField]
		[Tooltip("Enable caching of render graph compilation from one frame to another.")]
		private bool m_EnableCompilationCaching; // 0x14
		[RecreatePipelineOnChange]
		[SerializeField]
		[Tooltip("Enable validity checks of render graph in Editor and Development mode. Always disabled in Release build.")]
		private bool m_EnableValidityChecks; // 0x15
	
		// Properties
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool enableCompilationCaching { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E987B0-0x0000000181E98820
		public bool enableValidityChecks { get; set; } // 0x000000018155D200-0x000000018155D210 0x0000000181E98820-0x0000000181E98890
	
		// Nested types
		private enum Version // TypeDefIndex: 5652
		{
			Initial = 0,
			Last = 0,
			Count = 1
		}
	
		// Constructors
		public RenderGraphGlobalSettings(); // 0x0000000181E987A0-0x0000000181E987B0
	}
}
