/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PathTracing.Core;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal struct FatInstance // TypeDefIndex: 13625
	{
		// Fields
		public BoundingSphere BoundingSphere; // 0x00
		public Mesh Mesh; // 0x10
		public Vector2 UVBoundsSize; // 0x18
		public Vector2 UVBoundsOffset; // 0x20
		public Handle<MaterialPool.MaterialDescriptor>[] Materials; // 0x28
		public uint[] SubMeshMasks; // 0x30
		public Matrix4x4 LocalToWorldMatrix; // 0x38
		public Bounds Bounds; // 0x78
		public bool IsStatic; // 0x90
		public LodIdentifier LodIdentifier; // 0x94
		public bool ReceiveShadows; // 0xA0
		public RenderedGameObjectsFilter Filter; // 0xA4
		public uint RenderingObjectLayer; // 0xA8
		public bool EnableEmissiveSampling; // 0xAC
		public bool IsProceduralTerrain; // 0xAD
		public int TerrainIndex; // 0xB0
	}
}
