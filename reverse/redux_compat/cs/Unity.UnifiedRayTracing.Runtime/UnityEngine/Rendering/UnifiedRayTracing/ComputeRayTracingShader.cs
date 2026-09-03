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
	internal class ComputeRayTracingShader : IRayTracingShader // TypeDefIndex: 14308
	{
		// Fields
		private readonly ComputeShader m_Shader; // 0x10
		private readonly int m_KernelIndex; // 0x18
		private readonly int m_ComputeIndirectDispatchDimsKernelIndex; // 0x1C
		private uint3 m_ThreadGroupSizes; // 0x20
		private readonly GraphicsBuffer m_DispatchBuffer; // 0x30
	
		// Constructors
		internal ComputeRayTracingShader(ComputeShader shader, string dispatchFuncName, GraphicsBuffer dispatchBuffer); // 0x0000000182125A70-0x0000000182125B50
	
		// Methods
		public uint3 GetThreadGroupSizes(); // 0x00000001821255F0-0x0000000182125610
		public void SetAccelerationStructure(CommandBuffer cmd, string name, IRayTracingAccelStruct accelStruct); // 0x0000000182125610-0x00000001821256E0
		public void SetIntParam(CommandBuffer cmd, int nameID, int val); // 0x0000000182125910-0x0000000182125940
		public void SetFloatParam(CommandBuffer cmd, int nameID, float val); // 0x00000001821257C0-0x00000001821257F0
		public void SetVectorParam(CommandBuffer cmd, int nameID, Vector4 val); // 0x0000000182125A30-0x0000000182125A70
		public void SetMatrixParam(CommandBuffer cmd, int nameID, Matrix4x4 val); // 0x0000000182125970-0x00000001821259D0
		public void SetTextureParam(CommandBuffer cmd, int nameID, RenderTargetIdentifier rt); // 0x00000001821259D0-0x0000000182125A30
		public void SetBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer); // 0x00000001821256E0-0x0000000182125720
		public void SetBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer); // 0x0000000182125720-0x0000000182125760
		public void SetConstantBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000182125760-0x0000000182125790
		public void SetConstantBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182125790-0x00000001821257C0
		public void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, uint width, uint height, uint depth); // 0x0000000182125410-0x00000001821255F0
		public void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, GraphicsBuffer argsBuffer); // 0x0000000182125240-0x0000000182125410
		internal void SetIndirectDispatchDimensions(CommandBuffer cmd, GraphicsBuffer argsBuffer); // 0x00000001821257F0-0x0000000182125910
		internal void DispatchIndirect(CommandBuffer cmd, GraphicsBuffer scratchBuffer, GraphicsBuffer argsBuffer); // 0x0000000182125130-0x0000000182125240
		public ulong GetTraceScratchBufferRequiredSizeInBytes(uint width, uint height, uint depth); // 0x00000001821250E0-0x0000000182125100
		public void SetKeyword(CommandBuffer cmd, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000182125940-0x0000000182125970
		public LocalKeyword CreateLocalKeyword(string name); // 0x0000000182125100-0x0000000182125130
		void IRayTracingShader.SetKeyword(CommandBuffer cmd, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000182125940-0x0000000182125970
	}
}
