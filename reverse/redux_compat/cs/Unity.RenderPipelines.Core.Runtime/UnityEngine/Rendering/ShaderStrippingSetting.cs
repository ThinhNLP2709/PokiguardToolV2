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
	[CategoryInfo(Name = "Additional Shader Stripping Settings", Order = 40)]
	[ElementInfo(Order = 0)]
	[SupportedOnRenderPipeline(new Type[0])]
	public class ShaderStrippingSetting : IRenderPipelineGraphicsSettings // TypeDefIndex: 5684
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[SerializeField]
		[Tooltip("Controls whether to output shader variant information to a file.")]
		private bool m_ExportShaderVariants; // 0x14
		[SerializeField]
		[Tooltip("Controls the level of logging of shader variant information outputted during the build process. Information appears in the Unity Console when the build finishes.")]
		private ShaderVariantLogLevel m_ShaderVariantLogLevel; // 0x18
		[SerializeField]
		[Tooltip("When enabled, all debug display shader variants are removed when you build for the Unity Player. This decreases build time, but prevents the use of most Rendering Debugger features in Player builds.")]
		private bool m_StripRuntimeDebugShaders; // 0x1C
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool exportShaderVariants { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E9E510-0x0000000181E9E580
		public ShaderVariantLogLevel shaderVariantLogLevel { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181E9E580-0x0000000181E9E5F0
		public bool stripRuntimeDebugShaders { get; set; } // 0x0000000180E38E30-0x0000000180E38E40 0x0000000181E9E5F0-0x0000000181E9E660
	
		// Nested types
		internal enum Version // TypeDefIndex: 5685
		{
			Initial = 0
		}
	
		// Constructors
		public ShaderStrippingSetting(); // 0x0000000181E9E500-0x0000000181E9E510
	}
}
