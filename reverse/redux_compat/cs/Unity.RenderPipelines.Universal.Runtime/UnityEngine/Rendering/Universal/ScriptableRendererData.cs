/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public abstract class ScriptableRendererData : ScriptableObject // TypeDefIndex: 9461
	{
		// Fields
		[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)")]
		public DebugShaderResources debugShaders; // 0x18
		[Obsolete("Probe volume debug resource are now in the ProbeVolumeDebugResources class. #from(2023.3)")]
		public ProbeVolumeResources probeVolumeResources; // 0x20
		[CompilerGenerated]
		private bool _isInvalidated_k__BackingField; // 0x28
		[SerializeField]
		internal List<ScriptableRendererFeature> m_RendererFeatures; // 0x30
		[SerializeField]
		internal List<long> m_RendererFeatureMap; // 0x38
		[NonSerialized]
		private bool m_StripShadowsOffVariants; // 0x40
		[NonSerialized]
		private bool m_StripAdditionalLightOffVariants; // 0x41
	
		// Properties
		[Obsolete("Native Render Pass is automatically enabled through Render Graph, useNativeRenderPass is not considered anymore. #from(6000.5)")]
		public bool useNativeRenderPass { get; set; } // 0x00000001802E7990-0x00000001802E79A0 0x00000001802E76C0-0x00000001802E76D0
		internal bool isInvalidated { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		internal virtual bool stripShadowsOffVariants { get; set; } // 0x00000001803B1170-0x00000001803B1180 0x000000018042B340-0x000000018042B350
		internal virtual bool stripAdditionalLightOffVariants { get; set; } // 0x00000001815B1190-0x00000001815B11A0 0x00000001819C0450-0x00000001819C0460
		public List<ScriptableRendererFeature> rendererFeatures { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		[Serializable]
		[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)")]
		[ReloadGroup]
		public sealed class DebugShaderResources // TypeDefIndex: 9462
		{
			// Fields
			[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)")]
			[Reload("Shaders/Debug/DebugReplacement.shader", ReloadAttribute.Package.Root)]
			public Shader debugReplacementPS; // 0x10
			[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)")]
			[Reload("Shaders/Debug/HDRDebugView.shader", ReloadAttribute.Package.Root)]
			public Shader hdrDebugViewPS; // 0x18
	
			// Constructors
			public DebugShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[Obsolete("Probe volume debug resource are now in the ProbeVolumeDebugResources class. #from(2023.3)")]
		[ReloadGroup]
		public sealed class ProbeVolumeResources // TypeDefIndex: 9463
		{
			// Fields
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Shader probeVolumeDebugShader; // 0x10
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Shader probeVolumeFragmentationDebugShader; // 0x18
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Shader probeVolumeOffsetDebugShader; // 0x20
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Shader probeVolumeSamplingDebugShader; // 0x28
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Mesh probeSamplingDebugMesh; // 0x30
			[Obsolete("This shader is now in the ProbeVolumeDebugResources class. #from(2023.3)")]
			public Texture2D probeSamplingDebugTexture; // 0x38
			[Obsolete("This shader is now in the ProbeVolumeRuntimeResources class. #from(2023.3)")]
			public ComputeShader probeVolumeBlendStatesCS; // 0x40
	
			// Constructors
			public ProbeVolumeResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		protected ScriptableRendererData(); // 0x0000000181F97E80-0x0000000181F97F50
	
		// Methods
		protected abstract ScriptableRenderer Create();
		public void SetDirty(); // 0x000000018060A130-0x000000018060A140
		internal ScriptableRenderer InternalCreateRenderer(); // 0x0000000181F97E60-0x0000000181F97E80
		protected virtual void OnValidate(); // 0x000000018060A130-0x000000018060A140
		protected virtual void OnEnable(); // 0x000000018060A130-0x000000018060A140
		public bool TryGetRendererFeature<T>(out ref T rendererFeature)
			where T : ScriptableRendererFeature;
	}
}
