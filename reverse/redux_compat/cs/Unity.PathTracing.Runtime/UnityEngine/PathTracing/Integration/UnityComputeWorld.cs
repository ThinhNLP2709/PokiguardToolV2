/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.PathTracing.Core;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UnityComputeWorld : IWorld // TypeDefIndex: 13564
	{
		// Fields
		internal World PathTracingWorld; // 0x10
		internal GraphicsBuffer ScratchBuffer; // 0x18
		internal Mesh[] Meshes; // 0x20
		internal Handle<World.LightDescriptor>[] LightHandles; // 0x28
		internal RayTracingContext RayTracingContext; // 0x30
		internal readonly List<UnityEngine.Object> TemporaryObjects; // 0x38
		internal const uint RenderingObjectLayer = 1; // Metadata: 0x006A7D30
	
		// Constructors
		public UnityComputeWorld(); // 0x0000000181E026B0-0x0000000181E02920
	
		// Methods
		internal void BuildAccelerationStructure(CommandBuffer cmd); // 0x0000000181E02490-0x0000000181E024C0
		public void Init(RayTracingContext rayTracingContext, WorldResourceSet worldResources); // 0x0000000181E02600-0x0000000181E026B0
		public void Dispose(); // 0x0000000181E024C0-0x0000000181E02600
	}
}
