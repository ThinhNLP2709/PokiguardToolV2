/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class AccelStructAdapter : IDisposable // TypeDefIndex: 14265
	{
		// Fields
		private IRayTracingAccelStruct _accelStruct; // 0x10
		private AccelStructInstances _instances; // 0x18
		private Texture2DArray _terrainTextureArray; // 0x20
		private readonly List<GraphicsBuffer> _aabbBuffers; // 0x28
		private int _terrainCount; // 0x30
		private int _maxTerrainResolution; // 0x34
		private static RenderTexture s_EmptyTerrainTexture; // 0x00
		internal static readonly int _terrainTileWidth; // 0x08
		private static readonly int s_TerrainTextureId; // 0x0C
		private static readonly int s_TerrainTextureInvWidthId; // 0x10
		private readonly Dictionary<ulong, IdsOfInstances[]> _objectHandleToInstances; // 0x38
	
		// Properties
		internal AccelStructInstances Instances { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal Texture2DArray TerrainTextureArray { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal int TerrainCount { get; } // 0x000000018033D100-0x000000018033D110 
		public GeometryPool GeometryPool { get; } // 0x0000000181777F30-0x0000000181777F50 
	
		// Nested types
		private struct IdsOfInstances // TypeDefIndex: 14266
		{
			// Fields
			public int IdOfInstance; // 0x00
			public int AccelStructID; // 0x04
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14267
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Converter<IdsOfInstances, int> __9__46_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182124C10-0x0000000182124C80
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _GetInstanceIDs_b__46_0(IdsOfInstances item); // 0x000000018030F1D0-0x000000018030F1E0
		}
	
		// Constructors
		public AccelStructAdapter(IRayTracingAccelStruct accelStruct, GeometryPool geometryPool); // 0x000000018210EC70-0x000000018210EE90
		public AccelStructAdapter(IRayTracingAccelStruct accelStruct, RayTracingResources resources); // 0x000000018210EBA0-0x000000018210EC70
		static AccelStructAdapter(); // 0x000000018210EB10-0x000000018210EBA0
	
		// Methods
		private static RenderTexture GetEmptyTerrainTexture(); // 0x000000018210D5A0-0x000000018210D790
		public IRayTracingAccelStruct GetAccelerationStructure(); // 0x0000000180377550-0x0000000180377560
		public void Bind(CommandBuffer cmd, string propertyName, IRayTracingShader shader); // 0x000000018210CBE0-0x000000018210CCE0
		public void BindTerrainResources(CommandBuffer cmd, IRayTracingShader shader); // 0x000000018210C7C0-0x000000018210CBE0
		public void Dispose(); // 0x000000018210D380-0x000000018210D5A0
		public void AddInstance(ulong objectHandle, Component meshRendererOrTerrain, Span<uint> perSubMeshMask, Span<uint> perSubMeshMaterialIDs, Span<bool> perSubMeshIsOpaque, uint renderingLayerMask); // 0x000000018210B290-0x000000018210B670
		public void AddInstance(ulong objectHandle, Mesh mesh, Matrix4x4 localToWorldMatrix, Span<uint> perSubMeshMask, Span<uint> perSubMeshMaterialIDs, Span<bool> perSubMeshIsOpaque, uint renderingLayerMask); // 0x000000018210B670-0x000000018210BA70
		private void AddInstance(ulong objectHandle, TerrainDesc terrainDesc); // 0x000000018210B110-0x000000018210B290
		private void AddHeightmap(TerrainDesc terrainDesc, ref List<IdsOfInstances> instanceHandles); // 0x000000018210ACB0-0x000000018210B110
		private void AddTrees(TerrainDesc terrainDesc, ref List<IdsOfInstances> instanceHandles); // 0x000000018210C100-0x000000018210C7C0
		private static MinMaxAABB TileAabb(short[] heightData, int resolution, float3 heightmapScale, int2 topLeftCorner); // 0x000000018210E090-0x000000018210E260
		private static GraphicsBuffer CreateTerrainAabbBuffer(short[] heightData, int resolution, float3 heightmapScale); // 0x000000018210CDC0-0x000000018210D150
		internal static Texture2D CreateTerrainTextureForTest(short[] heightData, int resolution, byte[] holeData, int holeResolution); // 0x000000018210D150-0x000000018210D1D0
		private static Texture2D CreateTerrainTexture(short[] heightData, int resolution, byte[] holeData, int holeResolution); // 0x000000018210D1D0-0x000000018210D380
		private void GrowTextureArray(Texture2D newSlice, int newSliceResolution, int previousAtlasWidth); // 0x000000018210D900-0x000000018210DC10
		public void AddTerrainInstance(ulong objectHandle, short[] heightData, int resolution, float3 heightmapScale, byte[] holeData, int holeResolution, Matrix4x4 localToWorldMatrix, uint materialID, uint renderingLayerMask, uint instanceMask = 4294967295 /* Metadata: 0x006A9613 */); // 0x000000018210BBC0-0x000000018210C100
		private IdsOfInstances AddInstance(MeshInstanceDesc instanceDesc, uint materialID, uint renderingLayerMask); // 0x000000018210BA70-0x000000018210BBC0
		public void RemoveInstance(ulong objectHandle); // 0x000000018210DD30-0x000000018210E090
		public void UpdateInstanceTransform(ulong objectHandle, Matrix4x4 localToWorldMatrix); // 0x000000018210E920-0x000000018210EB10
		public void UpdateInstanceMaterialIDs(ulong objectHandle, Span<uint> perSubMeshMaterialIDs); // 0x000000018210E610-0x000000018210E920
		public void UpdateInstanceMask(ulong objectHandle, Span<uint> perSubMeshMask); // 0x000000018210E260-0x000000018210E410
		public void UpdateInstanceMask(ulong objectHandle, uint mask); // 0x000000018210E410-0x000000018210E610
		public void Build(CommandBuffer cmd, ref GraphicsBuffer scratchBuffer); // 0x000000018210CCE0-0x000000018210CDC0
		public void NextFrame(); // 0x000000018210DC10-0x000000018210DD30
		public bool GetInstanceIDs(ulong rendererID, out int[] instanceIDs); // 0x000000018210D790-0x000000018210D900
	}
}
