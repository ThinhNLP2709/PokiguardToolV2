/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class HardwareRayTracingAccelStruct : IRayTracingAccelStruct // TypeDefIndex: 14309
	{
		// Fields
		[CompilerGenerated]
		private readonly RayTracingAccelerationStructure _accelStruct_k__BackingField; // 0x10
		private readonly RayTracingAccelerationStructureBuildFlags m_BuildFlags; // 0x18
		private readonly Dictionary<int, Mesh> m_Meshes; // 0x20
		private readonly ReferenceCounter m_Counter; // 0x28
	
		// Properties
		public RayTracingAccelerationStructure accelStruct { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal HardwareRayTracingAccelStruct(AccelerationStructureOptions options, ReferenceCounter counter); // 0x0000000182126120-0x0000000182126290
	
		// Methods
		public void Dispose(); // 0x0000000182125FF0-0x0000000182126020
		public int AddInstance(MeshInstanceDesc meshInstance); // 0x0000000182125CC0-0x0000000182125F30
		public int AddInstance(ProceduralInstanceDesc proceduralInstance); // 0x0000000182125B50-0x0000000182125CC0
		public void RemoveInstance(int instanceHandle); // 0x0000000182126020-0x0000000182126090
		public void ClearInstances(); // 0x0000000182125FB0-0x0000000182125FF0
		public void UpdateInstanceTransform(int instanceHandle, Matrix4x4 localToWorldMatrix); // 0x00000001821260D0-0x0000000182126120
		public void UpdateInstanceID(int instanceHandle, uint instanceID); // 0x0000000182126090-0x00000001821260B0
		public void UpdateInstanceMask(int instanceHandle, uint mask); // 0x00000001821260B0-0x00000001821260D0
		public void Build(CommandBuffer cmd, GraphicsBuffer scratchBuffer); // 0x0000000182125F30-0x0000000182125FB0
		public ulong GetBuildScratchBufferRequiredSizeInBytes(); // 0x00000001802E7860-0x00000001802E7870
		[Conditional("UNITY_ASSERTIONS")]
		private void CheckInstanceHandleIsValid(int instanceHandle); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
