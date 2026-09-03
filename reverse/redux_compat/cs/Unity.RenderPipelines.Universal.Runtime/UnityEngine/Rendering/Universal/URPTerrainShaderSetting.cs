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
	[CategoryInfo(Name = "Terrain Shader Inclusion Settings", Order = 50)]
	[ElementInfo(Order = 10)]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class URPTerrainShaderSetting : IRenderPipelineGraphicsSettings // TypeDefIndex: 9776
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[SerializeField]
		[Tooltip("Include terrain shaders in build even if not referenced.")]
		private bool m_IncludeTerrainShaders; // 0x14
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool includeTerrainShaders { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181FF46D0-0x0000000181FF4740
	
		// Nested types
		internal enum Version // TypeDefIndex: 9777
		{
			Initial = 0
		}
	
		// Constructors
		public URPTerrainShaderSetting(); // 0x0000000181FF46C0-0x0000000181FF46D0
	}
}
