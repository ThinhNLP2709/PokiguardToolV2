/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal struct BakeInstance // TypeDefIndex: 13626
	{
		// Fields
		public Mesh Mesh; // 0x00
		public Vector4 NormalizedOccupiedST; // 0x08
		public Vector4 SourceLightmapST; // 0x18
		public Vector2Int TexelSize; // 0x28
		public Vector2Int TexelOffset; // 0x30
		public Matrix4x4 LocalToWorldMatrix; // 0x38
		public Matrix4x4 LocalToWorldMatrixNormals; // 0x78
		public bool ReceiveShadows; // 0xB8
		public LodIdentifier LodIdentifier; // 0xBC
		public uint InstanceIndex; // 0xC8
		public bool IsProceduralTerrain; // 0xCC
		public int TerrainIndex; // 0xD0
	
		// Methods
		private static float4x4 NormalMatrix(float4x4 m); // 0x0000000181E03540-0x0000000181E036B0
		public BoundingSphere GetBoundingSphere(); // 0x0000000181E032A0-0x0000000181E03540
		public void Build(Mesh mesh, Vector4 normalizedOccupiedST, Vector4 sourceLightmapST, Vector2Int texelSize, Vector2Int texelOffset, Matrix4x4 localToWorldMatrix, bool receiveShadows, LodIdentifier lodIdentifier, uint instanceIndex, bool isProceduralTerrain, int terrainIndex); // 0x0000000181E02E60-0x0000000181E032A0
	}
}
