/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class MaterialPool : IDisposable // TypeDefIndex: 13595
	{
		// Fields
		private readonly Dictionary<ulong, MaterialEntry> _materialMap; // 0x10
		private readonly Dictionary<ulong, BlockAllocator.Allocation> _lightCookies; // 0x18
		private readonly Dictionary<int, ulong> _cookieHandleToID; // 0x20
		private BlockAllocator _materialSlotAllocator; // 0x28
		public ComputeBuffer MaterialBuffer; // 0x48
		private NativeArray<GpuMaterialEntry> _gpuMaterialList; // 0x50
		private bool _materialArrayDirty; // 0x60
		private readonly TextureSlotAllocator _albedoTextureAllocator; // 0x68
		private readonly TextureSlotAllocator _emissionTextureAllocator; // 0x70
		private readonly TextureSlotAllocator _transmissionTextureAllocator; // 0x78
		private const int k_TextureFlushThreshold = 128; // Metadata: 0x006A7D63
		private int _textureBlitsSinceLastFlush; // 0x80
		private static Mesh _planeMesh; // 0x00
		public RenderTexture LightCookieTextures; // 0x88
		private BlockAllocator _lightCookieTexturesSlotAllocator; // 0x90
		public RenderTexture LightCubemapTextures; // 0xB0
		private BlockAllocator _lightCubemapTexturesSlotAllocator; // 0xB8
		private readonly ComputeShader _setAlphaChannelShader; // 0xD8
		private readonly int _setAlphaChannelKernel; // 0xE0
		private readonly uint3 _alphaShaderThreadGroupSizes; // 0xE4
		private readonly ComputeShader _blitCubemapShader; // 0xF0
		private readonly int _blitCubemapKernel; // 0xF8
		private readonly ComputeShader _blitGrayscaleCookieShader; // 0x100
		private readonly int _blitGrayscaleCookieKernel; // 0x108
		private const int AtlasSize = 256; // Metadata: 0x006A7D65
	
		// Properties
		public int MaterialCount { get; } // 0x0000000180F0C250-0x0000000180F0C270 
		public RenderTexture AlbedoTextures { get; } // 0x0000000181A72D60-0x0000000181A72D80 
		public RenderTexture EmissionTextures { get; } // 0x0000000181DF9820-0x0000000181DF9840 
		public RenderTexture TransmissionTextures { get; } // 0x0000000181DF9840-0x0000000181DF9860 
	
		// Nested types
		internal struct MaterialDescriptor // TypeDefIndex: 13596
		{
			// Fields
			public Texture Albedo; // 0x00
			public Vector2 AlbedoScale; // 0x08
			public Vector2 AlbedoOffset; // 0x10
			public Texture Emission; // 0x18
			public Vector2 EmissionScale; // 0x20
			public Vector2 EmissionOffset; // 0x28
			public Vector3 EmissionColor; // 0x30
			public MaterialPropertyType EmissionType; // 0x3C
			public Texture Transmission; // 0x40
			public Vector2 TransmissionScale; // 0x48
			public Vector2 TransmissionOffset; // 0x50
			public TransmissionChannels TransmissionChannels; // 0x58
			public float Alpha; // 0x5C
			public float AlphaCutoff; // 0x60
			public bool UseAlphaCutoff; // 0x64
			public bool DoubleSidedGI; // 0x65
			public bool PointSampleTransmission; // 0x66
			public bool PointSampleAlbedo; // 0x67
			public bool PointSampleEmission; // 0x68
		}
	
		[Flags]
		private enum MaterialFlags : uint // TypeDefIndex: 13597
		{
			None = 0,
			IsTransmissive = 1,
			DoubleSidedGI = 2,
			PointSampleTransmission = 4,
			PointSampleAlbedo = 8,
			PointSampleEmission = 16
		}
	
		private struct GpuMaterialEntry // TypeDefIndex: 13598
		{
			// Fields
			public int AlbedoTextureIndex; // 0x00
			public int EmissionTextureIndex; // 0x04
			public int TransmissionTextureIndex; // 0x08
			public MaterialFlags Flags; // 0x0C
			public float2 AlbedoScale; // 0x10
			public float2 AlbedoOffset; // 0x18
			public float2 EmissionScale; // 0x20
			public float2 EmissionOffset; // 0x28
			public float2 TransmissionScale; // 0x30
			public float2 TransmissionOffset; // 0x38
			public float3 EmissionColor; // 0x40
			public UVChannel AlbedoAndEmissionUVChannel; // 0x4C
		}
	
		private enum TextureType // TypeDefIndex: 13599
		{
			Albedo = 0,
			Emission = 1,
			Transmission = 2,
			LightCookie = 3,
			LightCubemap = 4
		}
	
		private class MaterialEntry // TypeDefIndex: 13600
		{
			// Fields
			public readonly BlockAllocator.Allocation IndexInBuffer; // 0x10
			public TextureSlotAllocator.TextureLocation AlbedoTextureLocation; // 0x20
			public TextureSlotAllocator.TextureLocation EmissionTextureLocation; // 0x30
			public TextureSlotAllocator.TextureLocation TransmissionTextureLocation; // 0x40
			public float3 EmissionColor; // 0x50
			public UVChannel AlbedoAndEmissionUVChannel; // 0x5C
			public bool DoubleSidedGI; // 0x60
			public bool IsTransmissive; // 0x61
			public bool PointSampleTransmission; // 0x62
			public bool PointSampleAlbedo; // 0x63
			public bool PointSampleEmission; // 0x64
	
			// Constructors
			public MaterialEntry(BlockAllocator.Allocation indexInBufferAlloc); // 0x0000000181E11340-0x0000000181E11420
		}
	
		// Constructors
		public MaterialPool(ComputeShader setAlphaChannelShader, ComputeShader blitCubemapShader, ComputeShader blitGrayscaleCookieShader); // 0x0000000181DF93E0-0x0000000181DF9820
	
		// Methods
		public void Dispose(); // 0x0000000181DF7260-0x0000000181DF7410
		public void AddMaterial(ulong materialHandle, [IsReadOnly] in MaterialDescriptor material, UVChannel albedoAndEmissionUVChannel); // 0x0000000181DF56E0-0x0000000181DF59A0
		public void UpdateMaterial(ulong materialHandle, [IsReadOnly] in MaterialDescriptor material, UVChannel albedoAndEmissionUVChannel); // 0x0000000181DF9350-0x0000000181DF93E0
		public void RemoveMaterial(ulong materialInstanceID); // 0x0000000181DF8940-0x0000000181DF8B90
		public void GetMaterialInfo(ulong materialHandle, out uint materialIndex, out bool isTransmissive); // 0x0000000181DF8470-0x0000000181DF8550
		public bool IsEmissive(ulong materialHandle, out float3 emissionColor); // 0x0000000181DF8580-0x0000000181DF86C0
		public void Build(CommandBuffer cmd); // 0x0000000181DF6740-0x0000000181DF67D0
		private void UpdateMaterial([IsReadOnly] in MaterialDescriptor material, UVChannel albedoAndEmissionUVChannel, MaterialEntry materialEntry); // 0x0000000181DF9050-0x0000000181DF9350
		private void UpdateMaterialList(MaterialEntry entry); // 0x0000000181DF8C50-0x0000000181DF9050
		private static int GetCookieFaces(Texture tex); // 0x0000000181DF8420-0x0000000181DF8460
		private static int GetCookieHandle(int slices, int handle); // 0x0000000181DF8460-0x0000000181DF8470
		public int AddCookieTexture(Texture cookie); // 0x0000000181DF5420-0x0000000181DF56E0
		public void RemoveCookieTexture(int cookieFaces, int cookieIndex); // 0x0000000181DF8810-0x0000000181DF8940
		private void ExpandCookieTextureArray(bool isCubemapCookie, ref BlockAllocator allocator, ref RenderTexture texture, ref BlockAllocator.Allocation textureAlloc); // 0x0000000181DF7AD0-0x0000000181DF7DF0
		private void BlitCubemapCookie(Texture source, RenderTexture dest, int destIndex); // 0x0000000181DF6170-0x0000000181DF6740
		private void Blit2DCookie(Texture source, RenderTexture dest, int destIndex); // 0x0000000181DF5BA0-0x0000000181DF6170
		private void AddOrUpdateTexture([IsReadOnly] in MaterialDescriptor material, TextureType textureType, ref TextureSlotAllocator.TextureLocation location); // 0x0000000181DF59A0-0x0000000181DF5BA0
		private void RemoveTextureIfPresent(TextureType textureType, ref TextureSlotAllocator.TextureLocation location); // 0x0000000181DF8B90-0x0000000181DF8C50
		private void FillAlbedoTextureAlphaWithOpacity([IsReadOnly] in MaterialDescriptor material, TextureSlotAllocator.TextureLocation location); // 0x0000000181DF7DF0-0x0000000181DF8420
		private static Texture EvaluateMetaPass(Material material, TextureType textureType); // 0x0000000181DF7410-0x0000000181DF7AD0
		public static MaterialDescriptor ConvertUnityMaterialToMaterialDescriptor(Material material, EmissionMode emissionMode); // 0x0000000181DF67D0-0x0000000181DF6D30
		private static GraphicsFormat GetTextureFormat(TextureType textureType); // 0x0000000181DF8550-0x0000000181DF8580
		private static RenderTexture CreateTextureArray(int sliceCount, TextureType textureType); // 0x0000000181DF7060-0x0000000181DF7090
		private static RenderTexture CreateTexture(TextureType textureType, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x006A7D61 */, int sliceCount = 1 /* Metadata: 0x006A7D62 */); // 0x0000000181DF7090-0x0000000181DF7260
		private void RecreateGpuMaterialList(); // 0x0000000181DF86C0-0x0000000181DF8810
		private static Mesh CreateQuadMesh(); // 0x0000000181DF6D30-0x0000000181DF7060
	}
}
