/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "Render Graph", Order = 50)]
	[ElementInfo(Order = -10)]
	[Obsolete("These settings are not used. #from(6000.4)", false)]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class RenderGraphSettings : IRenderPipelineGraphicsSettings // TypeDefIndex: 9770
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7840-0x00000001802E7850 
		[Obsolete("This property is not used. #from(6000.4)", false)]
		public bool enableRenderCompatibilityMode { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		internal enum Version // TypeDefIndex: 9771
		{
			Initial = 0
		}
	
		// Constructors
		public RenderGraphSettings(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
