/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[ExcludeFromPreset]
	[ReloadGroup]
	public class UniversalRendererData : ScriptableRendererData, ISerializationCallbackReceiver // TypeDefIndex: 9467
	{
		// Fields
		[Obsolete("Moved to UniversalRenderPipelineRuntimeXRResources on GraphicsSettings. #from(2023.3)")]
		public XRSystemData xrSystemData; // 0x48
		public PostProcessData postProcessData; // 0x50
		private const int k_LatestAssetVersion = 3; // Metadata: 0x0069EB4A
		[SerializeField]
		private int m_AssetVersion; // 0x58
		[SerializeField]
		private LayerMask m_PrepassLayerMask; // 0x5C
		[SerializeField]
		private LayerMask m_OpaqueLayerMask; // 0x60
		[SerializeField]
		private LayerMask m_TransparentLayerMask; // 0x64
		[SerializeField]
		private StencilStateData m_DefaultStencilState; // 0x68
		[SerializeField]
		private bool m_ShadowTransparentReceive; // 0x70
		[SerializeField]
		private RenderingMode m_RenderingMode; // 0x74
		[SerializeField]
		private DepthPrimingMode m_DepthPrimingMode; // 0x78
		[SerializeField]
		private CopyDepthMode m_CopyDepthMode; // 0x7C
		[SerializeField]
		private DepthFormat m_DepthAttachmentFormat; // 0x80
		[SerializeField]
		private DepthFormat m_DepthTextureFormat; // 0x84
		[SerializeField]
		private bool m_ShadowmapStencil; // 0x88
		[SerializeField]
		private bool m_AccurateGbufferNormals; // 0x89
		[SerializeField]
		private IntermediateTextureMode m_IntermediateTextureMode; // 0x8C
		[SerializeField]
		private bool m_TileOnlyMode; // 0x90
		[NonSerialized]
		private bool m_StripShadowsOffVariants; // 0x91
		[NonSerialized]
		private bool m_StripAdditionalLightOffVariants; // 0x92
	
		// Properties
		public LayerMask prepassLayerMask { get; set; } // 0x000000018033D270-0x000000018033D280 0x0000000181F9E4D0-0x0000000181F9E4E0
		public LayerMask opaqueLayerMask { get; set; } // 0x000000018150C180-0x000000018150C190 0x0000000181F9E4C0-0x0000000181F9E4D0
		public LayerMask transparentLayerMask { get; set; } // 0x00000001802F2020-0x00000001802F2030 0x0000000181F9E530-0x0000000181F9E540
		public StencilStateData defaultStencilState { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000181F9E3B0-0x0000000181F9E3D0
		public bool shadowTransparentReceive { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000181F9E4F0-0x0000000181F9E500
		public RenderingMode renderingMode { get; set; } // 0x0000000181974810-0x0000000181974820 0x0000000181F9E4E0-0x0000000181F9E4F0
		public DepthPrimingMode depthPrimingMode { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x0000000181F9E490-0x0000000181F9E4A0
		public CopyDepthMode copyDepthMode { get; set; } // 0x00000001816A5830-0x00000001816A5840 0x0000000181F9E3A0-0x0000000181F9E3B0
		public DepthFormat depthAttachmentFormat { get; set; } // 0x0000000181F9E1D0-0x0000000181F9E260 0x0000000181F9E3D0-0x0000000181F9E490
		public DepthFormat depthTextureFormat { get; set; } // 0x0000000181F9E260-0x0000000181F9E350 0x0000000181F9E4A0-0x0000000181F9E4B0
		public bool shadowmapStencil { get; set; } // 0x00000001803B5710-0x00000001803B5720 0x0000000181F9E500-0x0000000181F9E510
		public bool accurateGbufferNormals { get; set; } // 0x0000000181F9E1C0-0x0000000181F9E1D0 0x0000000181F9E390-0x0000000181F9E3A0
		public IntermediateTextureMode intermediateTextureMode { get; set; } // 0x000000018033D640-0x000000018033D650 0x0000000181F9E4B0-0x0000000181F9E4C0
		public bool tileOnlyMode { get; set; } // 0x000000018033D630-0x000000018033D640 0x0000000181F9E510-0x0000000181F9E530
		public bool usesDeferredLighting { get; } // 0x0000000181F9E370-0x0000000181F9E390 
		public bool usesClusterLightLoop { get; } // 0x0000000181F9E350-0x0000000181F9E370 
		internal override bool stripShadowsOffVariants { get; set; } // 0x0000000181845F90-0x0000000181845FA0 0x0000000181DD9C80-0x0000000181DD9C90
		internal override bool stripAdditionalLightOffVariants { get; set; } // 0x0000000181845F80-0x0000000181845F90 0x0000000181DD9C70-0x0000000181DD9C80
	
		// Constructors
		public UniversalRendererData(); // 0x0000000181F9E100-0x0000000181F9E1C0
	
		// Methods
		protected override ScriptableRenderer Create(); // 0x0000000181F9E040-0x0000000181F9E0C0
		protected override void OnEnable(); // 0x000000018060A130-0x000000018060A140
		private void ReloadAllNullProperties(); // 0x00000001802E76C0-0x00000001802E76D0
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181F9E0F0-0x0000000181F9E100
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181F9E0C0-0x0000000181F9E0F0
	}
}
