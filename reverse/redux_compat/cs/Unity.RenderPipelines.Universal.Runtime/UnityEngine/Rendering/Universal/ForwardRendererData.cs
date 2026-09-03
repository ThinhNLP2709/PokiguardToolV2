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
	[Obsolete("ForwardRendererData has been deprecated #from(2021.2) #breakingFrom(2021.2) (UnityUpgradable) -> UniversalRendererData", true)]
	[ReloadGroup]
	public class ForwardRendererData : ScriptableRendererData // TypeDefIndex: 9474
	{
		// Fields
		private const string k_ErrorMessage = "ForwardRendererData has been deprecated. Use UniversalRendererData instead"; // Metadata: 0x0069EB73
		public ShaderResources shaders; // 0x48
		public PostProcessData postProcessData; // 0x50
		public XRSystemData xrSystemData; // 0x58
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
		private bool m_AccurateGbufferNormals; // 0x7C
		[SerializeField]
		private bool m_ClusteredRendering; // 0x7D
		[SerializeField]
		private TileSize m_TileSize; // 0x80
	
		// Properties
		public LayerMask opaqueLayerMask { get; set; } // 0x0000000181F900D0-0x0000000181F90120 0x0000000181F902B0-0x0000000181F90300
		public LayerMask transparentLayerMask { get; set; } // 0x0000000181F901C0-0x0000000181F90210 0x0000000181F903A0-0x0000000181F903F0
		public StencilStateData defaultStencilState { get; set; } // 0x0000000181F90080-0x0000000181F900D0 0x0000000181F90260-0x0000000181F902B0
		public bool shadowTransparentReceive { get; set; } // 0x0000000181F90170-0x0000000181F901C0 0x0000000181F90350-0x0000000181F903A0
		public RenderingMode renderingMode { get; set; } // 0x0000000181F90120-0x0000000181F90170 0x0000000181F90300-0x0000000181F90350
		public bool accurateGbufferNormals { get; set; } // 0x0000000181F90030-0x0000000181F90080 0x0000000181F90210-0x0000000181F90260
	
		// Nested types
		[Serializable]
		[ReloadGroup]
		public sealed class ShaderResources // TypeDefIndex: 9475
		{
			// Fields
			[Reload("Shaders/Utils/Blit.shader", ReloadAttribute.Package.Root)]
			public Shader blitPS; // 0x10
			[Reload("Shaders/Utils/CopyDepth.shader", ReloadAttribute.Package.Root)]
			public Shader copyDepthPS; // 0x18
			[Obsolete("Obsolete, this feature will be supported by new \'ScreenSpaceShadows\' renderer feature. #from(2021.1) #breakingFrom(2023.1)", true)]
			public Shader screenSpaceShadowPS; // 0x20
			[Reload("Shaders/Utils/Sampling.shader", ReloadAttribute.Package.Root)]
			public Shader samplingPS; // 0x28
			[Reload("Shaders/Utils/StencilDeferred.shader", ReloadAttribute.Package.Root)]
			public Shader stencilDeferredPS; // 0x30
			[Reload("Shaders/Utils/FallbackError.shader", ReloadAttribute.Package.Root)]
			public Shader fallbackErrorPS; // 0x38
			[Reload("Shaders/Utils/FallbackLoading.shader", ReloadAttribute.Package.Root)]
			public Shader fallbackLoadingPS; // 0x40
			[Obsolete("Use fallbackErrorPS instead. #from(2022.2) #breakingFrom(2023.1)", true)]
			[Reload("Shaders/Utils/MaterialError.shader", ReloadAttribute.Package.Root)]
			public Shader materialErrorPS; // 0x48
			[Reload("Shaders/Utils/CoreBlit.shader", ReloadAttribute.Package.Root)]
			[SerializeField]
			internal Shader coreBlitPS; // 0x50
			[Reload("Shaders/Utils/CoreBlitColorAndDepth.shader", ReloadAttribute.Package.Root)]
			[SerializeField]
			internal Shader coreBlitColorAndDepthPS; // 0x58
			[Reload("Shaders/CameraMotionVectors.shader", ReloadAttribute.Package.Root)]
			public Shader cameraMotionVector; // 0x60
			[Reload("Shaders/ObjectMotionVectors.shader", ReloadAttribute.Package.Root)]
			public Shader objectMotionVector; // 0x68
	
			// Constructors
			public ShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public ForwardRendererData(); // 0x0000000181F90020-0x0000000181F90030
	
		// Methods
		protected override ScriptableRenderer Create(); // 0x0000000181F8FF90-0x0000000181F90020
	}
}
