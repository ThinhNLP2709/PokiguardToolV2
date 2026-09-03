/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.PathTracing.Integration;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class LightmapIntegrationResourceCache : IDisposable // TypeDefIndex: 13646
	{
		// Fields
		private static readonly ProfilerMarker k_BuildUVAccelerationStructure; // 0x00
		private Dictionary<ulong, UVMesh> _meshToUVMesh; // 0x10
		private Dictionary<ulong, UVAccelerationStructure> _meshToUVAccelerationStructure; // 0x18
		private Dictionary<UVFallbackBufferKey, UVFallbackBuffer> _meshToUVFallbackBuffer; // 0x20
	
		// Nested types
		private struct UVFallbackBufferKey : IEquatable<UVFallbackBufferKey> // TypeDefIndex: 13647
		{
			// Fields
			private int width; // 0x00
			private int height; // 0x04
			private ulong meshInstanceID; // 0x08
	
			// Constructors
			public UVFallbackBufferKey(int width, int height, EntityId meshInstanceID); // 0x0000000181E14640-0x0000000181E14650
	
			// Methods
			public bool Equals(UVFallbackBufferKey other); // 0x0000000181E14510-0x0000000181E14530
			public override bool Equals(object obj); // 0x0000000181E14530-0x0000000181E145D0
			public override int GetHashCode(); // 0x0000000181E145D0-0x0000000181E14640
			public static bool operator ==(UVFallbackBufferKey left, UVFallbackBufferKey right); // 0x0000000181E14650-0x0000000181E14680
			public static bool operator !=(UVFallbackBufferKey left, UVFallbackBufferKey right); // 0x0000000181E14680-0x0000000181E146B0
		}
	
		// Constructors
		public LightmapIntegrationResourceCache(); // 0x0000000181E0F630-0x0000000181E0F740
		static LightmapIntegrationResourceCache(); // 0x0000000181E0F5C0-0x0000000181E0F630
	
		// Methods
		public int UVMeshCount(); // 0x0000000180F0C250-0x0000000180F0C270
		public int UVAccelerationStructureCount(); // 0x0000000181E0F580-0x0000000181E0F5A0
		public int UVFallbackBufferCount(); // 0x0000000181E0F5A0-0x0000000181E0F5C0
		internal bool CacheIsHot(BakeInstance[] instances); // 0x0000000181E0E5B0-0x0000000181E0E870
		internal bool AddResources(BakeInstance[] instances, RayTracingContext context, CommandBuffer cmd, UVFallbackBufferBuilder uvFallbackBufferBuilder); // 0x0000000181E0E0F0-0x0000000181E0E5B0
		internal void FreeResources(BakeInstance[] instancesToKeep); // 0x0000000181E0EB70-0x0000000181E0F090
		internal bool GetResources(BakeInstance[] instances, out UVMesh[] uvMeshes, out UVAccelerationStructure[] uvAccelerationStructures, out UVFallbackBuffer[] uvFallbackBuffers); // 0x0000000181E0F090-0x0000000181E0F580
		private void Clear(); // 0x0000000181E0E870-0x0000000181E0EB60
		public void Dispose(); // 0x0000000181E0EB60-0x0000000181E0EB70
	}
}
