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
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct ReflectionProbeManager : IDisposable // TypeDefIndex: 9687
	{
		// Fields
		private int2 m_Resolution; // 0x00
		private RenderTexture m_AtlasTexture0; // 0x08
		private RenderTexture m_AtlasTexture1; // 0x10
		private RTHandle m_AtlasTexture0Handle; // 0x18
		private BuddyAllocator m_AtlasAllocator; // 0x20
		private Dictionary<EntityId, CachedProbe> m_Cache; // 0x48
		private Dictionary<EntityId, int> m_WarningCache; // 0x50
		private List<EntityId> m_NeedsUpdate; // 0x58
		private List<EntityId> m_NeedsRemove; // 0x60
		private const string k_ReflectionProbeCBName = "URP Reflection Probe Buffer"; // Metadata: 0x0069EEA3
		private const int k_BoxMaxChannel = 0; // Metadata: 0x0069EEBF
		private const int k_BoxMinChannel = 1; // Metadata: 0x0069EEC0
		private const int k_ProbePositionChannel = 2; // Metadata: 0x0069EEC1
		private const int k_MipScaleOffsetChannel = 3; // Metadata: 0x0069EEC2
		private const int k_RotationChannel = 10; // Metadata: 0x0069EEC3
		private const int k_ReflectionProbeChannelCount = 11; // Metadata: 0x0069EEC4
		private NativeArray<Vector4> m_ReflectionProbeData; // 0x68
		private GraphicsBuffer m_ReflectionProbeBuffer; // 0x78
		private Vector4[] m_BoxMax; // 0x80
		private Vector4[] m_BoxMin; // 0x88
		private Vector4[] m_ProbePosition; // 0x90
		private Vector4[] m_MipScaleOffset; // 0x98
		private Vector4[] m_Rotations; // 0xA0
		private int m_MaxReflectionProbes; // 0xA8
		private bool m_UseConstantBuffer; // 0xAC
		private const int k_MaxMipCount = 7; // Metadata: 0x0069EEC5
		private const string k_ReflectionProbeAtlasName = "URP Reflection Probe Atlas"; // Metadata: 0x0069EEC6
	
		// Properties
		public RenderTexture atlasRT { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public RTHandle atlasRTHandle { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		private struct CachedProbe // TypeDefIndex: 9688
		{
			// Fields
			public uint updateCount; // 0x00
			public Hash128 imageContentsHash; // 0x08
			public int size; // 0x18
			public int mipCount; // 0x1C
			public unsafe fixed /* 0x00000000-0x00000000 */ int dataIndices[0]; // 0x20
			public unsafe fixed /* 0x00000000-0x00000000 */ int levels[0]; // 0x3C
			public Texture texture; // 0x58
			public int lastUsed; // 0x60
			public Vector4 hdrData; // 0x64
			public ReflectionProbe sourceProbe; // 0x78
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _dataIndices_e__FixedBuffer // TypeDefIndex: 9689
			{
				// Fields
				public int FixedElementField; // 0x00
			}
	
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _levels_e__FixedBuffer // TypeDefIndex: 9690
			{
				// Fields
				public int FixedElementField; // 0x00
			}
		}
	
		private static class ShaderProperties // TypeDefIndex: 9691
		{
			// Fields
			public static readonly int ReflectionProbeBuffer; // 0x00
			public static readonly int BoxMin; // 0x04
			public static readonly int BoxMax; // 0x08
			public static readonly int ProbePosition; // 0x0C
			public static readonly int MipScaleOffset; // 0x10
			public static readonly int Rotation; // 0x14
			public static readonly int Count; // 0x18
			public static readonly int Atlas; // 0x1C
	
			// Constructors
			static ShaderProperties(); // 0x0000000181FD45F0-0x0000000181FD4770
		}
	
		// Methods
		public void PreSetup(); // 0x0000000181FC9620-0x0000000181FC96A0
		public static ReflectionProbeManager Create(); // 0x0000000181FC8E20-0x0000000181FC8E50
		private void Init(); // 0x0000000181FC9120-0x0000000181FC9620
		private void CreateReflectionProbeConstantBuffer(); // 0x0000000181FC8C30-0x0000000181FC8D20
		private void DisposeReflectionProbeConstantBuffer(); // 0x0000000181FC8E50-0x0000000181FC8F10
		private void CreateReflectionProbeLooseUniformArrays(); // 0x0000000181FC8D20-0x0000000181FC8E20
		public void UpdateGpuData(CommandBuffer cmd, ref CullingResults cullResults); // 0x0000000181FC96A0-0x0000000181FCBAE0
		private float4 GetScaleOffset(int level, int dataIndex, bool includePadding, bool yflip); // 0x0000000181FC8FD0-0x0000000181FC9120
		public void Dispose(); // 0x0000000181FC8F10-0x0000000181FC8FD0
	}
}
