/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	public interface IRayTracingShader // TypeDefIndex: 14316
	{
		// Methods
		void SetAccelerationStructure(CommandBuffer cmd, string name, IRayTracingAccelStruct accelStruct);
		void SetIntParam(CommandBuffer cmd, int nameID, int val);
		void SetFloatParam(CommandBuffer cmd, int nameID, float val);
		void SetVectorParam(CommandBuffer cmd, int nameID, Vector4 val);
		void SetMatrixParam(CommandBuffer cmd, int nameID, Matrix4x4 val);
		void SetTextureParam(CommandBuffer cmd, int nameID, RenderTargetIdentifier rt);
		void SetBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer);
		void SetBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer);
		void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, uint width, uint height, uint depth);
		void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, GraphicsBuffer argsBuffer);
		void SetConstantBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer, int offset, int size);
		void SetConstantBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer, int offset, int size);
		ulong GetTraceScratchBufferRequiredSizeInBytes(uint width, uint height, uint depth);
		uint3 GetThreadGroupSizes();
		void SetKeyword(CommandBuffer cmd, [IsReadOnly] in LocalKeyword keyword, bool value);
		LocalKeyword CreateLocalKeyword(string name);
	}
}
