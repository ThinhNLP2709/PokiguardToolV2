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
	internal class HardwareRayTracingShader : IRayTracingShader // TypeDefIndex: 14311
	{
		// Fields
		private readonly RayTracingShader m_Shader; // 0x10
		private readonly string m_ShaderDispatchFuncName; // 0x18
	
		// Constructors
		internal HardwareRayTracingShader(RayTracingShader shader, string dispatchFuncName, GraphicsBuffer unused); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public uint3 GetThreadGroupSizes(); // 0x00000001821265B0-0x00000001821265D0
		public void SetAccelerationStructure(CommandBuffer cmd, string name, IRayTracingAccelStruct accelStruct); // 0x00000001821265D0-0x00000001821266C0
		public void SetIntParam(CommandBuffer cmd, int nameID, int val); // 0x00000001821267B0-0x00000001821267E0
		public void SetFloatParam(CommandBuffer cmd, int nameID, float val); // 0x0000000182126780-0x00000001821267B0
		public void SetVectorParam(CommandBuffer cmd, int nameID, Vector4 val); // 0x00000001821268C0-0x0000000182126900
		public void SetMatrixParam(CommandBuffer cmd, int nameID, Matrix4x4 val); // 0x0000000182126810-0x0000000182126870
		public void SetTextureParam(CommandBuffer cmd, int nameID, RenderTargetIdentifier rt); // 0x0000000182126870-0x00000001821268C0
		public void SetBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer); // 0x00000001821266C0-0x00000001821266F0
		public void SetBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer); // 0x00000001821266F0-0x0000000182126720
		public void SetConstantBufferParam(CommandBuffer cmd, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000182126720-0x0000000182126750
		public void SetConstantBufferParam(CommandBuffer cmd, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182126750-0x0000000182126780
		public void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, uint width, uint height, uint depth); // 0x0000000182126520-0x0000000182126570
		public void Dispatch(CommandBuffer cmd, GraphicsBuffer scratchBuffer, GraphicsBuffer argsBuffer); // 0x0000000182126570-0x00000001821265B0
		public ulong GetTraceScratchBufferRequiredSizeInBytes(uint width, uint height, uint depth); // 0x00000001802E7860-0x00000001802E7870
		public void SetKeyword(CommandBuffer cmd, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x00000001821267E0-0x0000000182126810
		public LocalKeyword CreateLocalKeyword(string name); // 0x00000001821264F0-0x0000000182126520
		void IRayTracingShader.SetKeyword(CommandBuffer cmd, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x00000001821267E0-0x0000000182126810
	}
}
