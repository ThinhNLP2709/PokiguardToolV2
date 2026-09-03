/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct ProbeVolumeSystemParameters // TypeDefIndex: 5587
	{
		// Fields
		public ProbeVolumeTextureMemoryBudget memoryBudget; // 0x00
		public ProbeVolumeBlendingTextureMemoryBudget blendingMemoryBudget; // 0x04
		public ProbeVolumeSHBands shBands; // 0x08
		public bool supportScenarios; // 0x0C
		public bool supportScenarioBlending; // 0x0D
		public bool supportGPUStreaming; // 0x0E
		public bool supportDiskStreaming; // 0x0F
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Shader probeDebugShader; // 0x10
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Shader probeSamplingDebugShader; // 0x18
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Texture probeSamplingDebugTexture; // 0x20
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Mesh probeSamplingDebugMesh; // 0x28
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Shader offsetDebugShader; // 0x30
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public Shader fragmentationDebugShader; // 0x38
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public ComputeShader scenarioBlendingShader; // 0x40
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public ComputeShader streamingUploadShader; // 0x48
		[Obsolete("This field is not used anymore. #from(2023.3)")]
		public ProbeVolumeSceneData sceneData; // 0x50
		[Obsolete("This field is not used anymore. Used with the current Shader Stripping Settings. #from(2023.3)")]
		public bool supportsRuntimeDebug; // 0x58
	}
}
