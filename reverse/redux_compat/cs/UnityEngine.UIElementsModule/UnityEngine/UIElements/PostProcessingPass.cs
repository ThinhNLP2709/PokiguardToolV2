/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct PostProcessingPass // TypeDefIndex: 4153
	{
		// Fields
		[DontCreateProperty]
		[SerializeField]
		private Material m_Material; // 0x00
		[DontCreateProperty]
		[SerializeField]
		private int m_PassIndex; // 0x08
		[DontCreateProperty]
		[SerializeField]
		private ParameterBinding[] m_ParameterBindings; // 0x10
		[SerializeField]
		private PostProcessingMargins m_ReadMargins; // 0x18
		[DontCreateProperty]
		[SerializeField]
		private PostProcessingMargins m_WriteMargins; // 0x28
		[CompilerGenerated]
		private ApplyFilterPassSettingsDelegate _applySettingsCallback_k__BackingField; // 0x38
		[CompilerGenerated]
		private ComputeRequiredMarginsDelegate _computeRequiredReadMarginsCallback_k__BackingField; // 0x40
		[CompilerGenerated]
		private ComputeRequiredMarginsDelegate _computeRequiredWriteMarginsCallback_k__BackingField; // 0x48
		[SerializeField]
		private string m_OutputTextureName; // 0x50
		[SerializeField]
		private string m_RequiredInputTextureName; // 0x58
	
		// Properties
		[CreateProperty]
		public Material material { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		[CreateProperty]
		public int passIndex { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		[CreateProperty]
		public ParameterBinding[] parameterBindings { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal PostProcessingMargins readMargins { get; set; } // 0x0000000180A5E120-0x0000000180A5E130 0x0000000180F9EBA0-0x0000000180F9EBB0
		[CreateProperty]
		public PostProcessingMargins writeMargins { get; set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public ApplyFilterPassSettingsDelegate applySettingsCallback { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public ComputeRequiredMarginsDelegate computeRequiredReadMarginsCallback { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public ComputeRequiredMarginsDelegate computeRequiredWriteMarginsCallback { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal string outputTextureName { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal string requiredInputTextureName { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
	
		// Nested types
		public delegate void ApplyFilterPassSettingsDelegate(MaterialPropertyBlock mpb, FilterPassContext context); // TypeDefIndex: 4154; 0x000000018248DB60-0x000000018248DBD0
	
		public delegate PostProcessingMargins ComputeRequiredMarginsDelegate(FilterFunction func); // TypeDefIndex: 4155; 0x000000018248E2D0-0x000000018248E350
	}
}
