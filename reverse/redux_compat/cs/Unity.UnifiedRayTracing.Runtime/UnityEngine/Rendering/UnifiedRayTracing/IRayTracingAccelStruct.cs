/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	public interface IRayTracingAccelStruct : IDisposable // TypeDefIndex: 14314
	{
		// Methods
		int AddInstance(MeshInstanceDesc meshInstance);
		int AddInstance(ProceduralInstanceDesc proceduralInstance);
		void RemoveInstance(int instanceHandle);
		void ClearInstances();
		void UpdateInstanceTransform(int instanceHandle, Matrix4x4 localToWorldMatrix);
		void UpdateInstanceID(int instanceHandle, uint instanceID);
		void UpdateInstanceMask(int instanceHandle, uint mask);
		void Build(CommandBuffer cmd, GraphicsBuffer scratchBuffer);
		ulong GetBuildScratchBufferRequiredSizeInBytes();
	}
}
