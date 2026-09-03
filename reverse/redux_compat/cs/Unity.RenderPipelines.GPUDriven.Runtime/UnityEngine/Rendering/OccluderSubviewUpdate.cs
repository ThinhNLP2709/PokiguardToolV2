/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	public struct OccluderSubviewUpdate // TypeDefIndex: 12932
	{
		// Fields
		public int subviewIndex; // 0x00
		public int depthSliceIndex; // 0x04
		public Vector2Int depthOffset; // 0x08
		public Matrix4x4 viewMatrix; // 0x10
		public Matrix4x4 invViewMatrix; // 0x50
		public Matrix4x4 gpuProjMatrix; // 0x90
		public Vector3 viewOffsetWorldSpace; // 0xD0
	
		// Constructors
		public OccluderSubviewUpdate(int subviewIndex); // 0x0000000181F42030-0x0000000181F42120
	}
}
