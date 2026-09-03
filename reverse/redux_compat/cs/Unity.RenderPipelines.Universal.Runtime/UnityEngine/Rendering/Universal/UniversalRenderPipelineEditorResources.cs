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
	[Obsolete("Moved to GraphicsSettings. #from(2023.3)")]
	public class UniversalRenderPipelineEditorResources : ScriptableObject // TypeDefIndex: 9468
	{
		// Fields
		[Obsolete("UniversalRenderPipelineEditorResources.ShaderResources is obsolete GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineEditorShaders>(). #from(2023.3)")]
		public ShaderResources shaders; // 0x18
		[Obsolete("UniversalRenderPipelineEditorResources.MaterialResources is obsolete GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineEditorMaterials>(). #from(2023.3)")]
		public MaterialResources materials; // 0x20
	
		// Nested types
		[Serializable]
		[Obsolete("UniversalRenderPipelineEditorResources.ShaderResources is obsolete GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineEditorShaders>(). #from(2023.3)")]
		[ReloadGroup]
		public sealed class ShaderResources // TypeDefIndex: 9469
		{
			// Fields
			[Reload("Shaders/AutodeskInteractive/AutodeskInteractive.shadergraph", ReloadAttribute.Package.Root)]
			public Shader autodeskInteractivePS; // 0x10
			[Reload("Shaders/AutodeskInteractive/AutodeskInteractiveTransparent.shadergraph", ReloadAttribute.Package.Root)]
			public Shader autodeskInteractiveTransparentPS; // 0x18
			[Reload("Shaders/AutodeskInteractive/AutodeskInteractiveMasked.shadergraph", ReloadAttribute.Package.Root)]
			public Shader autodeskInteractiveMaskedPS; // 0x20
			[Reload("Shaders/Terrain/TerrainDetailLit.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailLitPS; // 0x28
			[Reload("Shaders/Terrain/WavingGrass.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailGrassPS; // 0x30
			[Reload("Shaders/Terrain/WavingGrassBillboard.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailGrassBillboardPS; // 0x38
			[Reload("Shaders/Nature/SpeedTree7.shader", ReloadAttribute.Package.Root)]
			public Shader defaultSpeedTree7PS; // 0x40
			[Reload("Shaders/Nature/SpeedTree8_PBRLit.shadergraph", ReloadAttribute.Package.Root)]
			public Shader defaultSpeedTree8PS; // 0x48
	
			// Constructors
			public ShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[Obsolete("UniversalRenderPipelineEditorResources.MaterialResources is obsolete GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineEditorMaterials>(). #from(2023.3)")]
		[ReloadGroup]
		public sealed class MaterialResources // TypeDefIndex: 9470
		{
			// Fields
			[Reload("Runtime/Materials/Lit.mat", ReloadAttribute.Package.Root)]
			public Material lit; // 0x10
			[Reload("Runtime/Materials/ParticlesUnlit.mat", ReloadAttribute.Package.Root)]
			public Material particleLit; // 0x18
			[Reload("Runtime/Materials/TerrainLit.mat", ReloadAttribute.Package.Root)]
			public Material terrainLit; // 0x20
			[Reload("Runtime/Materials/Decal.mat", ReloadAttribute.Package.Root)]
			public Material decal; // 0x28
	
			// Constructors
			public MaterialResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public UniversalRenderPipelineEditorResources(); // 0x00000001805F5FD0-0x00000001805F5FE0
	}
}
