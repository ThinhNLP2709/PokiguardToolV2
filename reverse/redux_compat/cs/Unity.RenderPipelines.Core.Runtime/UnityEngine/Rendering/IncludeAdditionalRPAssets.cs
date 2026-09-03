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
	[CategoryInfo(Name = "H: RP Assets Inclusion", Order = 990)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	public class IncludeAdditionalRPAssets : IRenderPipelineGraphicsSettings // TypeDefIndex: 5678
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_version; // 0x10
		[SerializeField]
		private bool m_IncludeReferencedInScenes; // 0x14
		[SerializeField]
		private bool m_IncludeAssetsByLabel; // 0x15
		[SerializeField]
		private string m_LabelToInclude; // 0x18
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool includeReferencedInScenes { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E8E560-0x0000000181E8E5D0
		public bool includeAssetsByLabel { get; set; } // 0x000000018155D200-0x000000018155D210 0x0000000181E8E4F0-0x0000000181E8E560
		public string labelToInclude { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181E8E5D0-0x0000000181E8E640
	
		// Nested types
		private enum Version // TypeDefIndex: 5679
		{
			Initial = 0,
			Last = 0,
			Count = 1
		}
	
		// Constructors
		public IncludeAdditionalRPAssets(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
