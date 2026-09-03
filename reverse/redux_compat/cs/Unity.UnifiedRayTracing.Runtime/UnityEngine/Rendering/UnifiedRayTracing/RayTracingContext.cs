/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	public sealed class RayTracingContext : IDisposable // TypeDefIndex: 14320
	{
		// Fields
		[CompilerGenerated]
		private RayTracingResources _Resources_k__BackingField; // 0x10
		[CompilerGenerated]
		private RayTracingBackend _BackendType_k__BackingField; // 0x18
		private readonly IRayTracingBackend m_Backend; // 0x20
		private readonly ReferenceCounter m_AccelStructCounter; // 0x28
		private readonly GraphicsBuffer m_DispatchBuffer; // 0x30
	
		// Properties
		public RayTracingResources Resources { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public RayTracingBackend BackendType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public RayTracingContext(RayTracingBackend backend, RayTracingResources resources); // 0x0000000182127110-0x0000000182127350
		public RayTracingContext(RayTracingResources resources); // 0x00000001821270D0-0x0000000182127110
	
		// Methods
		public void Dispose(); // 0x0000000182126E80-0x0000000182126F10
		public static bool IsBackendSupported(RayTracingBackend backend); // 0x0000000182126F90-0x0000000182126FB0
		public IRayTracingShader CreateRayTracingShader(UnityEngine.Object shader); // 0x0000000182126D90-0x0000000182126E80
		public IRayTracingShader LoadRayTracingShaderFromAssetBundle(AssetBundle assetBundle, string name); // 0x0000000182126FB0-0x00000001821270D0
		public IRayTracingAccelStruct CreateAccelerationStructure(AccelerationStructureOptions options); // 0x0000000182126CC0-0x0000000182126D90
		public ulong GetRequiredTraceScratchBufferSizeInBytes(uint width, uint height, uint depth); // 0x0000000182126F10-0x0000000182126F90
		public static uint GetScratchBufferStrideInBytes(); // 0x00000001804CB980-0x00000001804CB990
	}
}
