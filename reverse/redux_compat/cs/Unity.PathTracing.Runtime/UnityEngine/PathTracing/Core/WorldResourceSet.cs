/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class WorldResourceSet // TypeDefIndex: 13620
	{
		// Fields
		public ComputeShader BlitCubemap; // 0x10
		public ComputeShader BlitGrayScaleCookie; // 0x18
		public ComputeShader SetAlphaChannelShader; // 0x20
		public ComputeShader EnvironmentImportanceSamplingBuild; // 0x28
		public Mesh SkyBoxMesh; // 0x30
		public Mesh SixFaceSkyBoxMesh; // 0x38
		public ComputeShader BuildLightGridShader; // 0x40
		public Shader SolidColorShader; // 0x48
	
		// Constructors
		public WorldResourceSet(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool LoadFromRenderPipelineResources(); // 0x0000000181E18540-0x0000000181E186A0
	}
}
