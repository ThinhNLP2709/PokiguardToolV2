/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class World : IDisposable // TypeDefIndex: 13613
	{
		// Fields
		internal const int DIRECTIONAL_LIGHT = 1; // Metadata: 0x006A7DA1
		internal const int EMISSIVE_MESH = 8; // Metadata: 0x006A7DA2
		private readonly HandleSet<InstanceKey> _instanceHandleSet; // 0x10
		private readonly HandleSet<MaterialPool.MaterialDescriptor> _materialHandleSet; // 0x18
		private LightState _lightState; // 0x20
		private readonly Dictionary<Handle<InstanceKey>, List<int>> _subMeshIndices; // 0x28
		private MaterialPool _materialPool; // 0x30
		private AccelStructAdapter _rayTracingAccelerationStructure; // 0x38
		private CubemapRender _cubemapRender; // 0x40
		private EnvironmentImportanceSampling _environmentSampling; // 0x48
		private int _currentSkyboxHash; // 0x50
		private RegirLightGrid _reservoirGrid; // 0x58
		private ConservativeLightGrid _conservativeLightGrid; // 0x60
	
		// Properties
		public LightPickingMethod lightPickingMethod { get; set; } // 0x000000018167FC20-0x000000018167FC40 0x0000000181E1BAB0-0x0000000181E1BAD0
		public int MaterialCount { get; } // 0x0000000181E1B9D0-0x0000000181E1B9F0 
		public int LightCount { get; } // 0x0000000181E1B680-0x0000000181E1B6B0 
		public int NonMeshLightCount { get; } // 0x0000000181E1BA80-0x0000000181E1BAB0 
		public int MeshLightCount { get; } // 0x0000000181E1BA50-0x0000000181E1BA80 
		public int EnvLightCount { get; } // 0x0000000181E1B620-0x0000000181E1B640 
		public int MaxLightsInAnyCell { get; } // 0x0000000181E1B9F0-0x0000000181E1BA50 
		public List<PTLight> LightList { get; } // 0x0000000181A65550-0x0000000181A65570 
		public Dictionary<Handle<LightDescriptor>, int> LightHandleToLightListIndex { get; } // 0x0000000181E1B6F0-0x0000000181E1B710 
		public ComputeBuffer LightListBuffer { get; } // 0x0000000181A65590-0x0000000181A655B0 
		public Handle<LightDescriptor> MainDirectionaLightHandle { get; } // 0x0000000181E1B990-0x0000000181E1B9B0 
		public ComputeBuffer MainDirectionalLightBuffer { get; } // 0x0000000181E1B9B0-0x0000000181E1B9D0 
		public bool HasMainDirectionalLight { get; } // 0x0000000181E1B660-0x0000000181E1B680 
		public bool HasEnvironmentLight { get; } // 0x0000000181E1B640-0x0000000181E1B660 
		public ComputeBuffer LightFalloffBuffer { get; } // 0x0000000181E1B6B0-0x0000000181E1B6D0 
		public ComputeBuffer LightFalloffLUTRangeBuffer { get; } // 0x0000000181E1B6D0-0x0000000181E1B6F0 
		public uint LightFalloffLUTLength { get; } // 0x0000000180A2FBC0-0x0000000180A2FBD0 
		public int LightListHashCode { get; } // 0x0000000181E1B710-0x0000000181E1B990 
	
		// Nested types
		[IsReadOnly]
		internal struct InstanceKey // TypeDefIndex: 13614
		{
		}
	
		internal struct LightDescriptor // TypeDefIndex: 13615
		{
			// Fields
			public UnityEngine.LightType Type; // 0x00
			public Vector3 LinearLightColor; // 0x04
			public LightShadows Shadows; // 0x10
			public Matrix4x4 Transform; // 0x14
			public float ColorTemperature; // 0x54
			public LightmapBakeType LightmapBakeType; // 0x58
			public FalloffType FalloffType; // 0x5C
			public Vector2 AreaSize; // 0x60
			public float SpotAngle; // 0x68
			public float InnerSpotAngle; // 0x6C
			public uint CullingMask; // 0x70
			public float BounceIntensity; // 0x74
			public float Range; // 0x78
			public int ShadowMaskChannel; // 0x7C
			public bool UseColorTemperature; // 0x80
			public float ShadowRadius; // 0x84
			public Texture CookieTexture; // 0x88
			public float CookieSize; // 0x90
		}
	
		internal struct PTLight // TypeDefIndex: 13616
		{
			// Fields
			public Vector3 position; // 0x00
			public int type; // 0x0C
			public Vector3 intensity; // 0x10
			public int castShadows; // 0x1C
			public Vector3 forward; // 0x20
			public int contributesToDirectLighting; // 0x2C
			public Vector4 attenuation; // 0x30
			public Vector3 up; // 0x40
			public float width; // 0x4C
			public Vector3 right; // 0x50
			public float height; // 0x5C
			public uint layerMask; // 0x60
			public float indirectScale; // 0x64
			public float spotAngle; // 0x68
			public float innerSpotAngle; // 0x6C
			public float range; // 0x70
			public int shadowMaskChannel; // 0x74
			public int falloffIndex; // 0x78
			public float shadowRadius; // 0x7C
			public int cookieIndex; // 0x80
	
			// Methods
			[IsReadOnly]
			public override int GetHashCode(); // 0x0000000181E11740-0x0000000181E118F0
		}
	
		internal struct ThinReservoir // TypeDefIndex: 13617
		{
			// Fields
			public int LightIndex; // 0x00
			public float Weight; // 0x04
		}
	
		internal class LightState // TypeDefIndex: 13618
		{
			// Fields
			public LightPickingMethod lightPickingMethod; // 0x10
			public readonly List<PTLight> LightList; // 0x18
			public ComputeBuffer LightListBuffer; // 0x20
			public const uint LightFalloffLUTLength = 1024; // Metadata: 0x006A7DA3
			public List<LightFalloffDesc> LightFalloffDescs; // 0x28
			public float[] LightFalloff; // 0x30
			public float[] LightFalloffLUTRanges; // 0x38
			public ComputeBuffer LightFalloffBuffer; // 0x40
			public ComputeBuffer LightFalloffLUTRangeBuffer; // 0x48
			public Dictionary<Handle<LightDescriptor>, PTLight> LightHandleToLightListEntry; // 0x50
			public Dictionary<Handle<LightDescriptor>, int> LightHandleToLightListIndex; // 0x58
			public Dictionary<int, PTLight> MeshLights; // 0x60
			public HandleSet<LightDescriptor> LightHandleSet; // 0x68
			public bool HasEnvironmentLight; // 0x70
			public bool HasMainDirectionalLight; // 0x71
			public PTLight MainDirectionalLight; // 0x74
			public Handle<LightDescriptor> MainDirectionalLightHandle; // 0xF8
			public ComputeBuffer MainDirectionalLightBuffer; // 0x100
	
			// Properties
			public int MeshLightCount { get; } // 0x0000000181E0A7D0-0x0000000181E0A7F0 
			public int LightCount { get; } // 0x00000001814EA450-0x00000001814EA470 
	
			// Constructors
			public LightState(); // 0x0000000181E0A5F0-0x0000000181E0A7D0
	
			// Methods
			public void Build(Bounds sceneBounds, CommandBuffer cmdBuf, bool addEnvironmentLight); // 0x0000000181E09990-0x0000000181E0A1D0
			private static void BuildLightFalloffLUTs(LightState lightState); // 0x0000000181E097D0-0x0000000181E09990
			private static void SetLightDataOnCommandBuffer(LightState lightState, CommandBuffer cmdBuf); // 0x0000000181E0A1D0-0x0000000181E0A5F0
		}
	
		// Constructors
		public World(); // 0x0000000181E1B510-0x0000000181E1B620
	
		// Methods
		public void Init(RayTracingContext ctx, WorldResourceSet worldResources); // 0x0000000181E196F0-0x0000000181E19BD0
		private static float Luminance(Color color); // 0x0000000181E0BDB0-0x0000000181E0BDE0
		public void SetEnvironmentMaterial(Material mat); // 0x0000000181E1A8D0-0x0000000181E1A900
		public ComputeBuffer GetMaterialListBuffer(); // 0x0000000181E19630-0x0000000181E19650
		public RenderTexture GetMaterialAlbedoTextures(); // 0x0000000181E195F0-0x0000000181E19610
		public RenderTexture GetMaterialEmissionTextures(); // 0x0000000181E19610-0x0000000181E19630
		public RenderTexture GetMaterialTransmissionTextures(); // 0x0000000181E19650-0x0000000181E19670
		public RenderTexture GetLightCookieTextures(); // 0x0000000181E195B0-0x0000000181E195D0
		public RenderTexture GetLightCubemapTextures(); // 0x0000000181E195D0-0x0000000181E195F0
		public Texture GetEnvironmentTexture(CommandBuffer cmd, out EnvironmentCDF environmentCDF); // 0x0000000181E19450-0x0000000181E19500
		public bool HasTerrains(); // 0x0000000181E196D0-0x0000000181E196F0
		public void BindLightAccelerationStructure(CommandBuffer cmd, IRayTracingShader shader); // 0x0000000181E18F00-0x0000000181E18F50
		public void Dispose(); // 0x0000000181E19170-0x0000000181E19310
		public AccelStructAdapter GetAccelerationStructure(); // 0x00000001803272A0-0x00000001803272B0
		public void NextFrame(); // 0x0000000181E19F20-0x0000000181E19F40
		private static int GetSubMeshHash(Handle<InstanceKey> instance, int subMeshIndex); // 0x0000000181E19670-0x0000000181E196D0
		public void RemoveInstance(Handle<InstanceKey> instance); // 0x0000000181E1A5C0-0x0000000181E1A680
		private void RemoveEmissiveMeshes(Handle<InstanceKey> instance); // 0x0000000181E1A380-0x0000000181E1A5C0
		public void RemoveMaterial(Handle<MaterialPool.MaterialDescriptor> materialHandle); // 0x0000000181E1A820-0x0000000181E1A8D0
		public Handle<MaterialPool.MaterialDescriptor> AddMaterial([IsReadOnly] in MaterialPool.MaterialDescriptor material, UVChannel albedoAndEmissionUVChannel); // 0x0000000181E18C50-0x0000000181E18D30
		public void UpdateMaterial(Handle<MaterialPool.MaterialDescriptor> materialHandle, [IsReadOnly] in MaterialPool.MaterialDescriptor material, UVChannel albedoAndEmissionUVChannel); // 0x0000000181E1B4A0-0x0000000181E1B510
		private void LogException(string message, Exception e, UnityEngine.Object obj); // 0x0000000181E19C50-0x0000000181E19E50
		private void LogException(string message, Exception e, ulong instanceHandle); // 0x0000000181E19E50-0x0000000181E19F20
		private void LogError(string message); // 0x0000000181E19BD0-0x0000000181E19C50
		public Handle<InstanceKey> AddInstance(Mesh mesh, Span<Handle<MaterialPool.MaterialDescriptor>> materials, Span<uint> masks, uint renderingLayerMask, [IsReadOnly] in Matrix4x4 localToWorldMatrix, Bounds bounds, bool isStatic, RenderedGameObjectsFilter filter, bool enableEmissiveSampling); // 0x0000000181E186A0-0x0000000181E18B10
		public Handle<InstanceKey> AddTerrainInstance(short[] heightData, int resolution, float3 heightmapScale, byte[] holeData, int holeResolution, Handle<MaterialPool.MaterialDescriptor> material, uint mask, uint renderingLayerMask, [IsReadOnly] in Matrix4x4 localToWorldMatrix); // 0x0000000181E18D30-0x0000000181E18F00
		public void UpdateInstanceTransform(Handle<InstanceKey> instance, Matrix4x4 localToWorldMatrix); // 0x0000000181E1ABE0-0x0000000181E1AC30
		public void UpdateInstanceMask(Handle<InstanceKey> instance, Span<uint> perSubMeshMask); // 0x0000000181E1AA60-0x0000000181E1AA90
		public void UpdateInstanceMask(Handle<InstanceKey> instance, uint mask); // 0x0000000181E1AA40-0x0000000181E1AA60
		public void UpdateInstanceMaterials(Handle<InstanceKey> instance, Span<Handle<MaterialPool.MaterialDescriptor>> materials); // 0x0000000181E1AA90-0x0000000181E1ABE0
		public void UpdateInstanceEmission(Handle<InstanceKey> instance, Mesh mesh, Bounds bounds, Span<Handle<MaterialPool.MaterialDescriptor>> materials, bool isStatic, RenderedGameObjectsFilter filter); // 0x0000000181E1A900-0x0000000181E1AA40
		internal static uint GetInstanceMask(ShadowCastingMode shadowMode, bool isStatic, RenderedGameObjectsFilter filter, bool hasLightmaps = true /* Metadata: 0x006A7D9C */); // 0x0000000181E19550-0x0000000181E195B0
		private static bool ProcessEmissiveMeshes(Handle<InstanceKey> instance, Mesh mesh, Bounds bounds, Span<Handle<MaterialPool.MaterialDescriptor>> materials, bool isStatic, AccelStructAdapter rtAccelStruct, MaterialPool sceneMaterials, RenderedGameObjectsFilter filter, Dictionary<int, PTLight> meshLights, Dictionary<Handle<InstanceKey>, List<int>> subMeshIndexMap); // 0x0000000181E19F40-0x0000000181E1A380
		public Handle<LightDescriptor>[] AddLights(Span<LightDescriptor> lights, bool respectLightLayers, bool autoEstimateLUTRange, MixedLightingMode mixedLightingMode); // 0x0000000181E18B10-0x0000000181E18C50
		private static float EstimateLUTRange(float range, float luminance, FalloffType falloffType, float threshold = 0.01f /* Metadata: 0x006A7D9D */); // 0x0000000181E19310-0x0000000181E19450
		public void UpdateLights(Handle<LightDescriptor>[] lightHandles, Span<LightDescriptor> lightDescriptors, bool respectLightLayers, bool autoEstimateLUTRange, MixedLightingMode mixedLightingMode); // 0x0000000181E1AC30-0x0000000181E1B4A0
		public void RemoveLights(Span<Handle<LightDescriptor>> lights); // 0x0000000181E1A680-0x0000000181E1A820
		public void Build(Bounds sceneBounds, CommandBuffer cmdBuf, ref GraphicsBuffer scratchBuffer, SamplingResources samplingResources, bool emissiveSampling, int envCubemapResolution, int maxLightGridCellCount); // 0x0000000181E18F50-0x0000000181E19170
		public ulong GetInstanceHandles(Handle<InstanceKey> handle); // 0x0000000181E19500-0x0000000181E19550
	}
}
