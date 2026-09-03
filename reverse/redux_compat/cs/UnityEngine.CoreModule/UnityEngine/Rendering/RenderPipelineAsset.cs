/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public abstract class RenderPipelineAsset : ScriptableObject // TypeDefIndex: 8424
	{
		// Fields
		[CompilerGenerated]
		private readonly bool _requiresCompatibleRenderPipelineGlobalSettings_k__BackingField; // 0x18
	
		// Properties
		public virtual Material defaultMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader autodeskInteractiveShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader autodeskInteractiveTransparentShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader autodeskInteractiveMaskedShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader terrainDetailLitShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader terrainDetailGrassShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader terrainDetailGrassBillboardShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultParticleMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultLineMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultTerrainMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultUIMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultUIOverdrawMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material defaultUIETC1SupportedMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material default2DMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Material default2DMaskMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader defaultShader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader defaultSpeedTree7Shader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader defaultSpeedTree8Shader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual Shader defaultSpeedTree9Shader { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual string renderPipelineShaderTag { get; } // 0x000000018225EAD0-0x000000018225EB40 
		public virtual Type pipelineType { get; } // 0x000000018225EA70-0x000000018225EAD0 
		internal string pipelineTypeFullName { get; } // 0x000000018225EA20-0x000000018225EA70 
		protected internal virtual bool requiresCompatibleRenderPipelineGlobalSettings { [CompilerGenerated] get; } // 0x0000000180F9E350-0x0000000180F9E360 
		[Obsolete("This property is obsolete. Use pipelineType instead. #from(23.2)", false)]
		protected internal virtual Type renderPipelineType { get; } // 0x000000018225EB40-0x000000018225EBA0 
		[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(23.3)", false)]
		public virtual string[] renderingLayerMaskNames { get; } // 0x00000001802E7860-0x00000001802E7870 
		[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(23.3)", false)]
		public virtual string[] prefixedRenderingLayerMaskNames { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		protected RenderPipelineAsset(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		internal RenderPipeline InternalCreatePipeline(); // 0x000000018225E890-0x000000018225E900
		protected abstract RenderPipeline CreatePipeline();
		protected virtual void EnsureGlobalSettings(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnValidate(); // 0x000000018225E940-0x000000018225EA20
		protected virtual void OnDisable(); // 0x000000018225E900-0x000000018225E940
	}
}
