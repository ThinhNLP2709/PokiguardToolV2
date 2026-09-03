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
	public class UniversalRenderingData : ContextItem // TypeDefIndex: 9480
	{
		// Fields
		public CullingResults cullResults; // 0x10
		internal bool reuseCullingResult; // 0x20
		[Obsolete("supportsDynamicBatching is obsolete.", true)]
		public bool supportsDynamicBatching; // 0x21
		public PerObjectData perObjectData; // 0x24
		[CompilerGenerated]
		private RenderingMode _renderingMode_k__BackingField; // 0x28
		[CompilerGenerated]
		private LayerMask _prepassLayerMask_k__BackingField; // 0x2C
		[CompilerGenerated]
		private LayerMask _opaqueLayerMask_k__BackingField; // 0x30
		[CompilerGenerated]
		private LayerMask _transparentLayerMask_k__BackingField; // 0x34
		[CompilerGenerated]
		private bool _stencilLodCrossFadeEnabled_k__BackingField; // 0x38
		[CompilerGenerated]
		private bool _writesSmoothnessToDepthNormalsAlpha_k__BackingField; // 0x39
	
		// Properties
		public RenderingMode renderingMode { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public LayerMask prepassLayerMask { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public LayerMask opaqueLayerMask { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public LayerMask transparentLayerMask { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public bool stencilLodCrossFadeEnabled { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public bool writesSmoothnessToDepthNormalsAlpha { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
	
		// Constructors
		public UniversalRenderingData(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(); // 0x0000000181F9E540-0x0000000181F9E5A0
	}
}
