/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[Flags]
	internal enum MeshRendererComponentMask // TypeDefIndex: 12954
	{
		None = 0,
		LocalToWorld = 1,
		PrevLocalToWorld = 2,
		Mesh = 4,
		Material = 8,
		SubMeshStartIndex = 16,
		LocalBounds = 32,
		RendererSettings = 64,
		ParentLODGroup = 128,
		LODMask = 256,
		MeshLodSettings = 512,
		Lightmap = 1024,
		RendererPriority = 2048,
		SceneCullingMask = 4096,
		RenderingEnabled = 8192,
		GPUComponent = 16384,
		StaticBatchSubMeshCount = 32768
	}
}
