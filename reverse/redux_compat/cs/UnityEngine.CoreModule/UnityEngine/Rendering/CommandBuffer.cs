/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Profiling;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Shaders/RayTracing/RayTracingShader.h")]
	[NativeHeader("Runtime/Export/Graphics/RenderingCommandBuffer.bindings.h")]
	[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[UsedByNativeCode]
	public class CommandBuffer : IDisposable // TypeDefIndex: 8326
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		public static bool ThrowOnSetRenderTarget; // 0x00
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public string name { get; set; } // 0x0000000182245E80-0x0000000182245F70 0x0000000182246060-0x00000001822461D0
		public int sizeInBytes { [NativeMethod("GetBufferSize")] get; } // 0x0000000182245FB0-0x0000000182246010 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 8327
		{
			// Methods
			public static IntPtr ConvertToNative(CommandBuffer commandBuffer); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public CommandBuffer(); // 0x0000000182245DF0-0x0000000182245E30
	
		// Methods
		[NativeMethod("AddWaitAllAsyncReadbackRequests")]
		public void WaitAllAsyncReadbackRequests(); // 0x0000000182245BB0-0x0000000182245C10
		public void RequestAsyncReadback(ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A070-0x000000018223A1B0
		public void RequestAsyncReadback(GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A4B0-0x000000018223A5F0
		public void RequestAsyncReadback(ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223ABD0-0x000000018223AD20
		public void RequestAsyncReadback(GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A7D0-0x000000018223A920
		public void RequestAsyncReadback(Texture src, Action<AsyncGPUReadbackRequest> callback); // 0x0000000182239F30-0x000000018223A070
		public void RequestAsyncReadback(Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223AA80-0x000000018223ABD0
		public void RequestAsyncReadback(Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A1B0-0x000000018223A350
		public void RequestAsyncReadback(Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223AD20-0x000000018223AE70
		public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A920-0x000000018223AA80
		public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A5F0-0x000000018223A7D0
		public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback); // 0x000000018223A350-0x000000018223A4B0
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback)
			where T : struct;
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_1([NotNull] ComputeBuffer src, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236120-0x0000000182236220
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_2([NotNull] ComputeBuffer src, int size, int offset, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236290-0x00000001822363A0
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_3([NotNull] Texture src, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236410-0x0000000182236520
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_4([NotNull] Texture src, int mipIndex, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236590-0x00000001822366A0
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_5([NotNull] Texture src, int mipIndex, GraphicsFormat dstFormat, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236710-0x0000000182236820
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_6([NotNull] Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236890-0x00000001822369B0
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_7([NotNull] Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236A20-0x0000000182236B40
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_8([NotNull] GraphicsBuffer src, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236BB0-0x0000000182236CB0
		[NativeMethod("AddRequestAsyncReadback")]
		private unsafe void Internal_RequestAsyncReadback_9([NotNull] GraphicsBuffer src, int size, int offset, [NotNull] Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null); // 0x0000000182236D20-0x0000000182236E30
		[NativeMethod("AddSetInvertCulling")]
		public void SetInvertCulling(bool invertCulling); // 0x000000018223FE20-0x000000018223FE80
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetSinglePassStereo", HasExplicitThis = true)]
		private void Internal_SetSinglePassStereo(SinglePassStereoMode mode); // 0x00000001822392E0-0x0000000182239340
		[FreeFunction("RenderingCommandBuffer_Bindings::InitBuffer")]
		private static IntPtr InitBuffer(); // 0x0000000182233950-0x0000000182233980
		[FreeFunction("RenderingCommandBuffer_Bindings::CreateGPUFence_Internal", HasExplicitThis = true)]
		private IntPtr CreateGPUFence_Internal(GraphicsFenceType fenceType, SynchronisationStageFlags stage); // 0x000000018222D630-0x000000018222D6A0
		[FreeFunction("RenderingCommandBuffer_Bindings::WaitOnGPUFence_Internal", HasExplicitThis = true)]
		private void WaitOnGPUFence_Internal(IntPtr fencePtr, SynchronisationStageFlags stage); // 0x0000000182245D80-0x0000000182245DF0
		[FreeFunction("RenderingCommandBuffer_Bindings::ReleaseBuffer", HasExplicitThis = true, IsThreadSafe = true)]
		private void ReleaseBuffer(); // 0x0000000182239E30-0x0000000182239E90
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeFloatParam", HasExplicitThis = true)]
		public void SetComputeFloatParam([NotNull] ComputeShader computeShader, int nameID, float val); // 0x000000018223C060-0x000000018223C140
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeIntParam", HasExplicitThis = true)]
		public void SetComputeIntParam([NotNull] ComputeShader computeShader, int nameID, int val); // 0x000000018223C3F0-0x000000018223C4D0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeVectorParam", HasExplicitThis = true)]
		public void SetComputeVectorParam([NotNull] ComputeShader computeShader, int nameID, Vector4 val); // 0x000000018223D730-0x000000018223D810
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeVectorArrayParam", HasExplicitThis = true)]
		public void SetComputeVectorArrayParam([NotNull] ComputeShader computeShader, int nameID, Vector4[] values); // 0x000000018223D430-0x000000018223D570
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeMatrixParam", HasExplicitThis = true)]
		public void SetComputeMatrixParam([NotNull] ComputeShader computeShader, int nameID, Matrix4x4 val); // 0x000000018223CCA0-0x000000018223CD80
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeMatrixArrayParam", HasExplicitThis = true)]
		public void SetComputeMatrixArrayParam([NotNull] ComputeShader computeShader, int nameID, Matrix4x4[] values); // 0x000000018223C9E0-0x000000018223CB20
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeFloats", HasExplicitThis = true)]
		private void Internal_SetComputeFloats([NotNull] ComputeShader computeShader, int nameID, float[] values); // 0x00000001822372D0-0x0000000182237410
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeInts", HasExplicitThis = true)]
		private void Internal_SetComputeInts([NotNull] ComputeShader computeShader, int nameID, int[] values); // 0x0000000182237750-0x0000000182237890
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeTextureParam", HasExplicitThis = true)]
		private void Internal_SetComputeTextureParam([NotNull] ComputeShader computeShader, int kernelIndex, int nameID, ref RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element); // 0x0000000182237C00-0x0000000182237CE0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = true)]
		private void Internal_SetComputeBufferParam([NotNull] ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer); // 0x0000000182236EA0-0x0000000182236FA0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = true)]
		private void Internal_SetComputeGraphicsBufferHandleParam([NotNull] ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle); // 0x0000000182237480-0x0000000182237570
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = true)]
		private void Internal_SetComputeGraphicsBufferParam([NotNull] ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer); // 0x00000001822375E0-0x00000001822376E0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeConstantBufferParam", HasExplicitThis = true)]
		private void Internal_SetComputeConstantComputeBufferParam([NotNull] ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182237010-0x0000000182237100
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeConstantBufferParam", HasExplicitThis = true)]
		private void Internal_SetComputeConstantGraphicsBufferParam([NotNull] ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000182237170-0x0000000182237260
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeParamsFromMaterial", HasExplicitThis = true)]
		private void Internal_SetComputeParamsFromMaterial([NotNull] ComputeShader computeShader, int kernelIndex, Material material); // 0x0000000182237900-0x00000001822379F0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchCompute", HasExplicitThis = true, ThrowsException = true)]
		private void Internal_DispatchCompute([NotNull] ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x000000018222E130-0x000000018222E210
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchComputeIndirect", HasExplicitThis = true, ThrowsException = true)]
		private void Internal_DispatchComputeIndirect([NotNull] ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset); // 0x0000000182234500-0x00000001822345F0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchComputeIndirect", HasExplicitThis = true, ThrowsException = true)]
		private void Internal_DispatchComputeIndirectGraphicsBuffer([NotNull] ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset); // 0x00000001822343A0-0x0000000182234490
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingComputeBufferParam([NotNull] RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer); // 0x0000000182237EF0-0x0000000182237FE0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingGraphicsBufferParam([NotNull] RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer); // 0x0000000182238760-0x0000000182238850
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingGraphicsBufferHandleParam([NotNull] RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle); // 0x0000000182238610-0x00000001822386F0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingConstantBufferParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingConstantComputeBufferParam([NotNull] RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182238050-0x0000000182238140
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingConstantBufferParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingConstantGraphicsBufferParam([NotNull] RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x00000001822381B0-0x00000001822382A0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingTextureParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingTextureParam([NotNull] RayTracingShader rayTracingShader, int nameID, ref RenderTargetIdentifier rt); // 0x0000000182238EC0-0x0000000182238FA0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingFloatParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingFloatParam([NotNull] RayTracingShader rayTracingShader, int nameID, float val); // 0x0000000182238310-0x00000001822383F0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingIntParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingIntParam([NotNull] RayTracingShader rayTracingShader, int nameID, int val); // 0x00000001822388C0-0x00000001822389A0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingVectorParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingVectorParam([NotNull] RayTracingShader rayTracingShader, int nameID, Vector4 val); // 0x00000001822391C0-0x00000001822392A0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingVectorArrayParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingVectorArrayParam([NotNull] RayTracingShader rayTracingShader, int nameID, Vector4[] values); // 0x0000000182239010-0x0000000182239150
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingMatrixParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingMatrixParam([NotNull] RayTracingShader rayTracingShader, int nameID, Matrix4x4 val); // 0x0000000182238D70-0x0000000182238E50
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingMatrixArrayParam", HasExplicitThis = true)]
		private void Internal_SetRayTracingMatrixArrayParam([NotNull] RayTracingShader rayTracingShader, int nameID, Matrix4x4[] values); // 0x0000000182238BC0-0x0000000182238D00
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingFloats", HasExplicitThis = true)]
		private void Internal_SetRayTracingFloats([NotNull] RayTracingShader rayTracingShader, int nameID, float[] values); // 0x0000000182238460-0x00000001822385A0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingInts", HasExplicitThis = true)]
		private void Internal_SetRayTracingInts([NotNull] RayTracingShader rayTracingShader, int nameID, int[] values); // 0x0000000182238A10-0x0000000182238B50
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_BuildRayTracingAccelerationStructure", HasExplicitThis = true)]
		private void Internal_BuildRayTracingAccelerationStructure([NotNull] RayTracingAccelerationStructure accelerationStructure, RayTracingAccelerationStructure.BuildSettings buildSettings); // 0x0000000182234260-0x0000000182234330
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingAccelerationStructure", HasExplicitThis = true)]
		private void Internal_SetRayTracingAccelerationStructure([NotNull] RayTracingShader rayTracingShader, int nameID, [NotNull] RayTracingAccelerationStructure accelerationStructure); // 0x0000000182237D50-0x0000000182237E80
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeRayTracingAccelerationStructure", HasExplicitThis = true)]
		private void Internal_SetComputeRayTracingAccelerationStructure([NotNull] ComputeShader computeShader, int kernelIndex, int nameID, [NotNull] RayTracingAccelerationStructure accelerationStructure); // 0x0000000182237A60-0x0000000182237B90
		[NativeMethod("AddSetRayTracingShaderPass")]
		public void SetRayTracingShaderPass([NotNull] RayTracingShader rayTracingShader, string passName); // 0x0000000182241BE0-0x0000000182241DD0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchRays", HasExplicitThis = true, ThrowsException = true)]
		private void Internal_DispatchRays([NotNull] RayTracingShader rayTracingShader, string rayGenShaderName, uint width, uint height, uint depth, Camera camera = null); // 0x00000001822349C0-0x0000000182234C00
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchRaysIndirect", HasExplicitThis = true, ThrowsException = true)]
		private void Internal_DispatchRaysIndirect([NotNull] RayTracingShader rayTracingShader, string rayGenShaderName, [NotNull] GraphicsBuffer argsBuffer, uint argsOffset = 0 /* Metadata: 0x0069DB4B */, Camera camera = null); // 0x00000001822346D0-0x0000000182234950
		[NativeMethod("AddGenerateMips")]
		private void Internal_GenerateMips(RenderTargetIdentifier rt); // 0x0000000182236050-0x00000001822360B0
		[NativeMethod("AddCopyCounterValue")]
		private void CopyCounterValueCC(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x000000018222CBB0-0x000000018222CC60
		[NativeMethod("AddCopyCounterValue")]
		private void CopyCounterValueGC(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x000000018222CDF0-0x000000018222CEA0
		[NativeMethod("AddCopyCounterValue")]
		private void CopyCounterValueCG(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x000000018222CCD0-0x000000018222CD80
		[NativeMethod("AddCopyCounterValue")]
		private void CopyCounterValueGG(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x000000018222CF10-0x000000018222CFC0
		[NativeMethod("ClearCommands")]
		public void Clear(); // 0x000000018222C750-0x000000018222C7B0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMesh", HasExplicitThis = true)]
		private void Internal_DrawMesh([NotNull] Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties); // 0x00000001822351F0-0x0000000182235320
		[NativeMethod("AddDrawMultipleMeshes")]
		private void Internal_DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, int[] subsetIndices, int count, Material material, int shaderPass, MaterialPropertyBlock properties); // 0x0000000182235390-0x0000000182235510
		[NativeMethod("AddDrawRenderer")]
		private void Internal_DrawRenderer([NotNull] Renderer renderer, Material material, int submeshIndex, int shaderPass); // 0x0000000182235F10-0x0000000182236000
		[NativeMethod("AddDrawRendererList")]
		private void Internal_DrawRendererList(RendererList rendererList); // 0x0000000182235E40-0x0000000182235EA0
		[NativeMethod("AddDrawProcedural")]
		private void Internal_DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties); // 0x0000000182235D20-0x0000000182235DF0
		[NativeMethod("AddDrawProceduralIndexed")]
		private void Internal_DrawProceduralIndexed(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties); // 0x0000000182235910-0x0000000182235A10
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndirect", HasExplicitThis = true)]
		private void Internal_DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000182235BD0-0x0000000182235CB0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndexedIndirect", HasExplicitThis = true)]
		private void Internal_DrawProceduralIndexedIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x00000001822357A0-0x00000001822358A0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndirect", HasExplicitThis = true)]
		private void Internal_DrawProceduralIndirectGraphicsBuffer(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000182235A80-0x0000000182235B60
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndexedIndirect", HasExplicitThis = true)]
		private void Internal_DrawProceduralIndexedIndirectGraphicsBuffer(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000182235630-0x0000000182235730
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstanced", HasExplicitThis = true)]
		private void Internal_DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties); // 0x0000000182235040-0x0000000182235180
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedProcedural", HasExplicitThis = true)]
		private void Internal_DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties); // 0x0000000182234F10-0x0000000182234FD0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedIndirect", HasExplicitThis = true)]
		private void Internal_DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000182234DC0-0x0000000182234EA0
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedIndirect", HasExplicitThis = true)]
		private void Internal_DrawMeshInstancedIndirectGraphicsBuffer(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000182234C70-0x0000000182234D50
		[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawOcclusionMesh", HasExplicitThis = true)]
		private void Internal_DrawOcclusionMesh(RectInt normalizedCamViewport); // 0x0000000182235560-0x00000001822355C0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetRandomWriteTarget_Texture", HasExplicitThis = true, ThrowsException = true)]
		private void SetRandomWriteTarget_Texture(int index, ref RenderTargetIdentifier rt); // 0x00000001822405A0-0x0000000182240610
		[FreeFunction("RenderingCommandBuffer_Bindings::SetRandomWriteTarget_Buffer", HasExplicitThis = true, ThrowsException = true)]
		private void SetRandomWriteTarget_Buffer(int index, ComputeBuffer uav, bool preserveCounterValue); // 0x00000001822403A0-0x0000000182240440
		[FreeFunction("RenderingCommandBuffer_Bindings::SetRandomWriteTarget_Buffer", HasExplicitThis = true, ThrowsException = true)]
		private void SetRandomWriteTarget_GraphicsBuffer(int index, GraphicsBuffer uav, bool preserveCounterValue); // 0x00000001822404B0-0x0000000182240550
		[FreeFunction("RenderingCommandBuffer_Bindings::ClearRandomWriteTargets", HasExplicitThis = true, ThrowsException = true)]
		public void ClearRandomWriteTargets(); // 0x000000018222BE50-0x000000018222BEB0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetViewport", HasExplicitThis = true, ThrowsException = true)]
		public void SetViewport(Rect pixelRect); // 0x00000001822456F0-0x0000000182245750
		[FreeFunction("RenderingCommandBuffer_Bindings::EnableScissorRect", HasExplicitThis = true, ThrowsException = true)]
		public void EnableScissorRect(Rect scissor); // 0x0000000182231C70-0x0000000182231CD0
		[FreeFunction("RenderingCommandBuffer_Bindings::DisableScissorRect", HasExplicitThis = true, ThrowsException = true)]
		public void DisableScissorRect(); // 0x000000018222DC70-0x000000018222DCD0
		[FreeFunction("RenderingCommandBuffer_Bindings::CopyTexture_Internal", HasExplicitThis = true)]
		private void CopyTexture_Internal(ref RenderTargetIdentifier src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, ref RenderTargetIdentifier dst, int dstElement, int dstMip, int dstX, int dstY, int mode); // 0x000000018222D030-0x000000018222D0C0
		[FreeFunction("RenderingCommandBuffer_Bindings::Blit_Texture", HasExplicitThis = true)]
		private void Blit_Texture(Texture source, ref RenderTargetIdentifier dest, Material mat, int pass, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice); // 0x000000018222B8A0-0x000000018222B990
		[FreeFunction("RenderingCommandBuffer_Bindings::GetTemporaryRT", HasExplicitThis = true)]
		private void GetTemporaryRT(int nameID, int width, int height, FilterMode filter, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale, ShadowSamplingMode shadowSamplingMode); // 0x0000000182232810-0x00000001822328B0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale); // 0x00000001822328B0-0x0000000182232AA0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode); // 0x0000000182233140-0x0000000182233320
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite); // 0x00000001822334F0-0x00000001822336D0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing); // 0x0000000182232D00-0x0000000182232EE0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite); // 0x0000000182232B30-0x0000000182232D00
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format); // 0x00000001822336D0-0x00000001822338A0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter); // 0x0000000182233320-0x00000001822334F0
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer); // 0x0000000182232F80-0x0000000182233140
		[FreeFunction("RenderingCommandBuffer_Bindings::GetTemporaryRTWithDescriptor", HasExplicitThis = true)]
		private void GetTemporaryRTWithDescriptor(int nameID, RenderTextureDescriptor desc, FilterMode filter); // 0x0000000182232700-0x0000000182232780
		public void GetTemporaryRT(int nameID, RenderTextureDescriptor desc, FilterMode filter); // 0x0000000182232EE0-0x0000000182232F80
		public void GetTemporaryRT(int nameID, RenderTextureDescriptor desc); // 0x0000000182232AA0-0x0000000182232B30
		[FreeFunction("RenderingCommandBuffer_Bindings::ReleaseTemporaryRT", HasExplicitThis = true)]
		public void ReleaseTemporaryRT(int nameID); // 0x0000000182239ED0-0x0000000182239F30
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor); // 0x000000018222C450-0x000000018222C540
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth); // 0x000000018222C540-0x000000018222C630
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth = 1f /* Metadata: 0x0069DB4C */, uint stencil = 0 /* Metadata: 0x0069DB50 */); // 0x000000018222C350-0x000000018222C450
		public void ClearRenderTarget(RTClearFlags clearFlags, Color backgroundColor, float depth = 1f /* Metadata: 0x0069DB51 */, uint stencil = 0 /* Metadata: 0x0069DB55 */); // 0x000000018222C630-0x000000018222C710
		public void ClearRenderTarget(RTClearFlags clearFlags, Color[] backgroundColors, float depth = 1f /* Metadata: 0x0069DB56 */, uint stencil = 0 /* Metadata: 0x0069DB5A */); // 0x000000018222C0D0-0x000000018222C350
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloat", HasExplicitThis = true)]
		public void SetGlobalFloat(int nameID, float value); // 0x000000018223E800-0x000000018223E870
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalInt", HasExplicitThis = true)]
		public void SetGlobalInt(int nameID, int value); // 0x000000018223EA30-0x000000018223EAA0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalInteger", HasExplicitThis = true)]
		public void SetGlobalInteger(int nameID, int value); // 0x000000018223EB80-0x000000018223EBF0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVector", HasExplicitThis = true)]
		public void SetGlobalVector(int nameID, Vector4 value); // 0x000000018223FCC0-0x000000018223FD30
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalColor", HasExplicitThis = true)]
		public void SetGlobalColor(int nameID, Color value); // 0x000000018223DD20-0x000000018223DD90
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrix", HasExplicitThis = true)]
		public void SetGlobalMatrix(int nameID, Matrix4x4 value); // 0x000000018223F260-0x000000018223F2D0
		[FreeFunction("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = true)]
		public void EnableShaderKeyword(string keyword); // 0x0000000182231D20-0x0000000182231E90
		[FreeFunction("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = true)]
		private void EnableGlobalKeyword(GlobalKeyword keyword); // 0x0000000182231950-0x00000001822319B0
		[FreeFunction("RenderingCommandBuffer_Bindings::EnableMaterialKeyword", HasExplicitThis = true)]
		private void EnableMaterialKeyword(Material material, LocalKeyword keyword); // 0x0000000182231B90-0x0000000182231C20
		[FreeFunction("RenderingCommandBuffer_Bindings::EnableComputeKeyword", HasExplicitThis = true)]
		private void EnableComputeKeyword(ComputeShader computeShader, LocalKeyword keyword); // 0x0000000182231870-0x0000000182231900
		public void EnableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x00000001822319B0-0x0000000182231A10
		public void EnableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x0000000182231AA0-0x0000000182231B30
		public void EnableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x0000000182231A10-0x0000000182231AA0
		[FreeFunction("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = true)]
		public void DisableShaderKeyword(string keyword); // 0x000000018222DD20-0x000000018222DE90
		[FreeFunction("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = true)]
		private void DisableGlobalKeyword(GlobalKeyword keyword); // 0x000000018222D960-0x000000018222D9C0
		[FreeFunction("RenderingCommandBuffer_Bindings::DisableMaterialKeyword", HasExplicitThis = true)]
		private void DisableMaterialKeyword(Material material, LocalKeyword keyword); // 0x000000018222DBA0-0x000000018222DC30
		[FreeFunction("RenderingCommandBuffer_Bindings::DisableComputeKeyword", HasExplicitThis = true)]
		private void DisableComputeKeyword(ComputeShader computeShader, LocalKeyword keyword); // 0x000000018222D880-0x000000018222D910
		public void DisableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x000000018222DAE0-0x000000018222DB40
		public void DisableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x000000018222D9C0-0x000000018222DA50
		public void DisableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x000000018222DA50-0x000000018222DAE0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetShaderKeyword", HasExplicitThis = true)]
		private void SetGlobalKeyword(GlobalKeyword keyword, bool value); // 0x000000018223EC50-0x000000018223ECC0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetMaterialKeyword", HasExplicitThis = true)]
		private void SetMaterialKeyword(Material material, LocalKeyword keyword, bool value); // 0x0000000182240290-0x0000000182240330
		[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeKeyword", HasExplicitThis = true)]
		private void SetComputeKeyword(ComputeShader computeShader, LocalKeyword keyword, bool value); // 0x000000018223C780-0x000000018223C820
		[FreeFunction("RenderingCommandBuffer_Bindings::SetRayTracingKeyword", HasExplicitThis = true)]
		private void SetRayTracingKeyword(RayTracingShader rayTracingShader, LocalKeyword keyword, bool value); // 0x0000000182241780-0x0000000182241820
		public void SetKeyword([IsReadOnly] in GlobalKeyword keyword, bool value); // 0x000000018223FF20-0x000000018223FF90
		public void SetKeyword(Material material, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x000000018223FF90-0x0000000182240030
		public void SetKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x000000018223FE80-0x000000018223FF20
		public void SetKeyword(RayTracingShader rayTracingShader, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000182240030-0x00000001822400D0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetViewProjectionMatrices", HasExplicitThis = true, ThrowsException = true)]
		public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj); // 0x0000000182245630-0x00000001822456A0
		[NativeMethod("AddSetGlobalDepthBias")]
		public void SetGlobalDepthBias(float bias, float slopeBias); // 0x000000018223E1E0-0x000000018223E260
		[FreeFunction("RenderingCommandBuffer_Bindings::SetExecutionFlags", HasExplicitThis = true, ThrowsException = true)]
		public void SetExecutionFlags(CommandBufferExecutionFlags flags); // 0x000000018223D940-0x000000018223D9A0
		[FreeFunction("RenderingCommandBuffer_Bindings::ValidateAgainstExecutionFlags", HasExplicitThis = true, ThrowsException = true)]
		private bool ValidateAgainstExecutionFlags(CommandBufferExecutionFlags requiredFlags, CommandBufferExecutionFlags invalidFlags); // 0x0000000182245B00-0x0000000182245B70
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloatArrayListImpl", HasExplicitThis = true)]
		private void SetGlobalFloatArrayListImpl(int nameID, ReadOnlySpan<float> values); // 0x000000018223E2B0-0x000000018223E360
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVectorArrayListImpl", HasExplicitThis = true)]
		private void SetGlobalVectorArrayListImpl(int nameID, ReadOnlySpan<Vector4> values); // 0x000000018223F6E0-0x000000018223F790
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrixArrayListImpl", HasExplicitThis = true)]
		private void SetGlobalMatrixArrayListImpl(int nameID, ReadOnlySpan<Matrix4x4> values); // 0x000000018223ED10-0x000000018223EDC0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloatArray", HasExplicitThis = true, ThrowsException = true)]
		public void SetGlobalFloatArray(int nameID, [NotNull] float[] values); // 0x000000018223E3B0-0x000000018223E4B0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVectorArray", HasExplicitThis = true, ThrowsException = true)]
		public void SetGlobalVectorArray(int nameID, [NotNull] Vector4[] values); // 0x000000018223F820-0x000000018223F920
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrixArray", HasExplicitThis = true, ThrowsException = true)]
		public void SetGlobalMatrixArray(int nameID, [NotNull] Matrix4x4[] values); // 0x000000018223F110-0x000000018223F210
		[FreeFunction("RenderingCommandBuffer_Bindings::SetLateLatchProjectionMatrices", HasExplicitThis = true, ThrowsException = true)]
		public void SetLateLatchProjectionMatrices([NotNull] Matrix4x4[] projectionMat); // 0x0000000182240120-0x0000000182240220
		[FreeFunction("RenderingCommandBuffer_Bindings::MarkLateLatchMatrixShaderPropertyID", HasExplicitThis = true)]
		public void MarkLateLatchMatrixShaderPropertyID(CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID); // 0x0000000182239C40-0x0000000182239CB0
		[FreeFunction("RenderingCommandBuffer_Bindings::UnmarkLateLatchMatrix", HasExplicitThis = true)]
		public void UnmarkLateLatchMatrix(CameraLateLatchMatrixType matrixPropertyType); // 0x0000000182245A50-0x0000000182245AB0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalTexture_Impl", HasExplicitThis = true)]
		private void SetGlobalTexture_Impl(int nameID, ref RenderTargetIdentifier rt, RenderTextureSubElement element); // 0x000000018223F3D0-0x000000018223F450
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalBuffer", HasExplicitThis = true)]
		private void SetGlobalBufferInternal(int nameID, ComputeBuffer value); // 0x000000018223DA90-0x000000018223DB10
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalBuffer", HasExplicitThis = true)]
		private void SetGlobalGraphicsBufferInternal(int nameID, GraphicsBuffer value); // 0x000000018223DBB0-0x000000018223DC30
		[FreeFunction("RenderingCommandBuffer_Bindings::SetShadowSamplingMode_Impl", HasExplicitThis = true)]
		private void SetShadowSamplingMode_Impl(ref RenderTargetIdentifier shadowmap, ShadowSamplingMode mode); // 0x00000001822454A0-0x0000000182245510
		[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginEventInternal", HasExplicitThis = true)]
		private void IssuePluginEventInternal(IntPtr callback, int eventID); // 0x0000000182239AC0-0x0000000182239B30
		[FreeFunction("RenderingCommandBuffer_Bindings::BeginSample", HasExplicitThis = true)]
		[NativeConditional("ENABLE_PROFILER")]
		public void BeginSample(string name); // 0x000000018222B6C0-0x000000018222B830
		[FreeFunction("RenderingCommandBuffer_Bindings::EndSample", HasExplicitThis = true)]
		[NativeConditional("ENABLE_PROFILER")]
		public void EndSample(string name); // 0x0000000182232130-0x00000001822322A0
		public void BeginSample(CustomSampler sampler); // 0x000000018222B5B0-0x000000018222B670
		public void EndSample(CustomSampler sampler); // 0x0000000182232020-0x00000001822320E0
		[FreeFunction("RenderingCommandBuffer_Bindings::BeginSample_CustomSampler", HasExplicitThis = true)]
		[NativeConditional("ENABLE_PROFILER")]
		private void BeginSample_CustomSampler([NotNull] CustomSampler sampler); // 0x000000018222B5B0-0x000000018222B670
		[FreeFunction("RenderingCommandBuffer_Bindings::EndSample_CustomSampler", HasExplicitThis = true)]
		[NativeConditional("ENABLE_PROFILER")]
		private void EndSample_CustomSampler([NotNull] CustomSampler sampler); // 0x0000000182232020-0x00000001822320E0
		[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginEventAndDataInternal", HasExplicitThis = true)]
		private void IssuePluginEventAndDataInternal(IntPtr callback, int eventID, IntPtr data); // 0x00000001822398C0-0x0000000182239940
		[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginCustomBlitInternal", HasExplicitThis = true)]
		private void IssuePluginCustomBlitInternal(IntPtr callback, uint command, ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, uint commandParam, uint commandFlags); // 0x00000001822394F0-0x0000000182239570
		[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginCustomTextureUpdateInternal", HasExplicitThis = true)]
		private void IssuePluginCustomTextureUpdateInternal(IntPtr callback, Texture targetTexture, uint userData, bool useNewUnityRenderingExtTextureUpdateParamsV2); // 0x00000001822396D0-0x0000000182239770
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalConstantBuffer", HasExplicitThis = true)]
		private void SetGlobalConstantBufferInternal(ComputeBuffer buffer, int nameID, int offset, int size); // 0x000000018223DE90-0x000000018223DF30
		[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalConstantBuffer", HasExplicitThis = true)]
		private void SetGlobalConstantGraphicsBufferInternal(GraphicsBuffer buffer, int nameID, int offset, int size); // 0x000000018223DF30-0x000000018223DFD0
		[FreeFunction("RenderingCommandBuffer_Bindings::IncrementUpdateCount", HasExplicitThis = true)]
		public void IncrementUpdateCount(RenderTargetIdentifier dest); // 0x00000001822338F0-0x0000000182233950
		[FreeFunction("RenderingCommandBuffer_Bindings::SetInstanceMultiplier", HasExplicitThis = true)]
		public void SetInstanceMultiplier(uint multiplier); // 0x000000018223FD70-0x000000018223FDD0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetFoveatedRenderingMode", HasExplicitThis = true)]
		public void SetFoveatedRenderingMode(FoveatedRenderingMode foveatedRenderingMode); // 0x000000018223D9E0-0x000000018223DA40
		[FreeFunction("RenderingCommandBuffer_Bindings::SetWireframe", HasExplicitThis = true)]
		public void SetWireframe(bool enable); // 0x00000001822457A0-0x0000000182245800
		[FreeFunction("RenderingCommandBuffer_Bindings::ConfigureFoveatedRendering", HasExplicitThis = true)]
		public void ConfigureFoveatedRendering(IntPtr platformData); // 0x000000018222C800-0x000000018222C860
		private static void CheckThrowOnSetRenderTarget(); // 0x000000018222BD80-0x000000018222BE10
		public void SetRenderTarget(RenderTargetIdentifier rt); // 0x0000000182243B90-0x0000000182243C80
		public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction); // 0x00000001822447F0-0x0000000182244950
		public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction); // 0x0000000182242A10-0x0000000182242B90
		public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel); // 0x0000000182243C80-0x0000000182243E70
		public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace); // 0x0000000182244D40-0x0000000182244F40
		public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182244570-0x00000001822447F0
		public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth); // 0x0000000182244BF0-0x0000000182244D40
		public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel); // 0x0000000182242B90-0x0000000182242DB0
		public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace); // 0x0000000182243270-0x0000000182243490
		public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182244950-0x0000000182244BF0
		public void SetRenderTarget(RenderTargetIdentifier color, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depth, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction); // 0x00000001822430C0-0x0000000182243270
		public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth); // 0x0000000182244F40-0x0000000182245230
		public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182242DB0-0x00000001822430C0
		public void SetRenderTarget(RenderTargetBinding binding, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182243E70-0x0000000182244570
		public void SetRenderTarget(RenderTargetBinding binding); // 0x0000000182243490-0x0000000182243B90
		private void ClearRenderTargetSingle_Internal(RTClearFlags clearFlags, Color color, float depth, uint stencil); // 0x000000018222C050-0x000000018222C0D0
		private void ClearRenderTargetMulti_Internal(RTClearFlags clearFlags, Color[] colors, float depth, uint stencil); // 0x000000018222BF10-0x000000018222BFF0
		private void SetRenderTargetSingle_Internal(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction); // 0x0000000182242980-0x0000000182242A10
		private void SetRenderTargetColorDepth_Internal(RenderTargetIdentifier color, RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags); // 0x0000000182242460-0x0000000182242500
		private void SetRenderTargetMulti_Internal(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, RenderBufferLoadAction[] colorLoadActions, RenderBufferStoreAction[] colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags); // 0x0000000182242780-0x0000000182242910
		private void SetRenderTargetColorDepthSubtarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182242330-0x00000001822423F0
		private void SetRenderTargetMultiSubtarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, RenderBufferLoadAction[] colorLoadActions, RenderBufferStoreAction[] colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182242570-0x0000000182242710
		public void SetBufferData(ComputeBuffer buffer, Array data); // 0x000000018223B760-0x000000018223B9F0
		public void SetBufferData<T>(ComputeBuffer buffer, List<T> data)
			where T : struct;
		public void SetBufferData<T>(ComputeBuffer buffer, NativeArray<T> data)
			where T : struct;
		public void SetBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count); // 0x000000018223B480-0x000000018223B760
		public void SetBufferData<T>(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferData<T>(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferCounterValue(ComputeBuffer buffer, uint counterValue); // 0x00000001822339E0-0x0000000182233AB0
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferNativeData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetComputeBufferNativeData([NotNull] ComputeBuffer buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233CE0-0x0000000182233DC0
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetComputeBufferData([NotNull] ComputeBuffer buffer, Span<byte> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233B20-0x0000000182233C70
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferCounterValue", HasExplicitThis = true)]
		private void InternalSetComputeBufferCounterValue([NotNull] ComputeBuffer buffer, uint counterValue); // 0x00000001822339E0-0x0000000182233AB0
		public void SetBufferData(GraphicsBuffer buffer, Array data); // 0x000000018223B1F0-0x000000018223B480
		public void SetBufferData<T>(GraphicsBuffer buffer, List<T> data)
			where T : struct;
		public void SetBufferData<T>(GraphicsBuffer buffer, NativeArray<T> data)
			where T : struct;
		public void SetBufferData(GraphicsBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count); // 0x000000018223AF10-0x000000018223B1F0
		public void SetBufferData<T>(GraphicsBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferData<T>(GraphicsBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferCounterValue(GraphicsBuffer buffer, uint counterValue); // 0x0000000182233E20-0x0000000182233EF0
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferNativeData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetGraphicsBufferNativeData([NotNull] GraphicsBuffer buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182234120-0x0000000182234200
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetGraphicsBufferData([NotNull] GraphicsBuffer buffer, Span<byte> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233F60-0x00000001822340B0
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferCounterValue", HasExplicitThis = true)]
		private void InternalSetGraphicsBufferCounterValue([NotNull] GraphicsBuffer buffer, uint counterValue); // 0x0000000182233E20-0x0000000182233EF0
		[FreeFunction(Name = "RenderingCommandBuffer_Bindings::CopyBuffer", HasExplicitThis = true, ThrowsException = true)]
		private void CopyBufferImpl([NotNull] GraphicsBuffer source, [NotNull] GraphicsBuffer dest); // 0x000000018222C8C0-0x000000018222C9E0
		[FreeFunction("RenderingCommandBuffer_Bindings::BeginRenderPass", HasExplicitThis = true)]
		private void BeginRenderPass_Internal(int width, int height, int volumeDepth, int samples, ReadOnlySpan<AttachmentDescriptor> attachments, int depthAttachmentIndex, int shadingRateImageAttachmentIndex, ReadOnlySpan<SubPassDescriptor> subPasses, ReadOnlySpan<byte> debugNameUtf8); // 0x000000018222B1F0-0x000000018222B380
		public void BeginRenderPass(int width, int height, int volumeDepth, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex, int shadingRateImageAttachmentIndex, NativeArray<SubPassDescriptor> subPasses, ReadOnlySpan<byte> debugNameUtf8); // 0x000000018222B380-0x000000018222B560
		[FreeFunction("RenderingCommandBuffer_Bindings::NextSubPass", HasExplicitThis = true)]
		private void NextSubPass_Internal(); // 0x0000000182239CF0-0x0000000182239D50
		public void NextSubPass(); // 0x0000000182239D50-0x0000000182239DF0
		[FreeFunction("RenderingCommandBuffer_Bindings::EndRenderPass", HasExplicitThis = true)]
		private void EndRenderPass_Internal(); // 0x0000000182231ED0-0x0000000182231F30
		public void EndRenderPass(); // 0x0000000182231F30-0x0000000182231FD0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetupCameraProperties", HasExplicitThis = true)]
		private void SetupCameraProperties_Internal([NotNull] Camera camera); // 0x0000000182245850-0x0000000182245910
		public void SetupCameraProperties(Camera camera); // 0x0000000182245910-0x0000000182245A10
		[FreeFunction("RenderingCommandBuffer_Bindings::InvokeOnRenderObjectCallbacks", HasExplicitThis = true)]
		private void InvokeOnRenderObjectCallbacks_Internal(); // 0x0000000182239380-0x00000001822393E0
		public void InvokeOnRenderObjectCallbacks(); // 0x00000001822393E0-0x0000000182239480
		public void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize); // 0x0000000182245330-0x0000000182245390
		public void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000182245280-0x00000001822452F0
		public void SetShadingRateImage([IsReadOnly] in RenderTargetIdentifier shadingRateImage); // 0x00000001822453E0-0x0000000182245440
		public void ResetShadingRate(); // 0x000000018223AEB0-0x000000018223AF10
		[FreeFunction("RenderingCommandBuffer_Bindings::SetShadingRateFragmentSize_Impl", HasExplicitThis = true)]
		private void SetShadingRateFragmentSize_Impl(ShadingRateFragmentSize shadingRateFragmentSize); // 0x0000000182245330-0x0000000182245390
		[FreeFunction("RenderingCommandBuffer_Bindings::SetShadingRateCombiner_Impl", HasExplicitThis = true)]
		private void SetShadingRateCombiner_Impl(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000182245280-0x00000001822452F0
		[FreeFunction("RenderingCommandBuffer_Bindings::SetShadingRateImage_Impl", HasExplicitThis = true)]
		private void SetShadingRateImage_Impl([IsReadOnly] in RenderTargetIdentifier shadingRateImage); // 0x00000001822453E0-0x0000000182245440
		[FreeFunction("RenderingCommandBuffer_Bindings::ResetShadingRate_Impl", HasExplicitThis = true)]
		private void ResetShadingRate_Impl(); // 0x000000018223AEB0-0x000000018223AF10
		~CommandBuffer(); // 0x00000001822322A0-0x0000000182232360
		public void Dispose(); // 0x000000018222E230-0x000000018222E2D0
		private void Dispose(bool disposing); // 0x000000018222E2D0-0x000000018222E330
		public void Release(); // 0x000000018222E230-0x000000018222E2D0
		public GraphicsFence CreateAsyncGraphicsFence(); // 0x000000018222D460-0x000000018222D5E0
		public GraphicsFence CreateGraphicsFence(GraphicsFenceType fenceType, SynchronisationStageFlags stage); // 0x000000018222D6A0-0x000000018222D820
		public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStageFlags stage); // 0x0000000182245C10-0x0000000182245D20
		public void SetComputeFloatParam(ComputeShader computeShader, string name, float val); // 0x000000018223C140-0x000000018223C230
		public void SetComputeIntParam(ComputeShader computeShader, string name, int val); // 0x000000018223C4D0-0x000000018223C5C0
		public void SetComputeVectorParam(ComputeShader computeShader, string name, Vector4 val); // 0x000000018223D810-0x000000018223D900
		public void SetComputeVectorArrayParam(ComputeShader computeShader, string name, Vector4[] values); // 0x000000018223D570-0x000000018223D6C0
		public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val); // 0x000000018223CB90-0x000000018223CCA0
		public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values); // 0x000000018223C890-0x000000018223C9E0
		public void SetComputeFloatParams(ComputeShader computeShader, string name, params float[] values); // 0x000000018223C230-0x000000018223C380
		public void SetComputeFloatParams(ComputeShader computeShader, int nameID, params float[] values); // 0x00000001822372D0-0x0000000182237410
		public void SetComputeIntParams(ComputeShader computeShader, string name, params int[] values); // 0x000000018223C5C0-0x000000018223C710
		public void SetComputeIntParams(ComputeShader computeShader, int nameID, params int[] values); // 0x0000000182237750-0x0000000182237890
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt); // 0x000000018223D0A0-0x000000018223D1B0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt); // 0x000000018223CFA0-0x000000018223D0A0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel); // 0x000000018223CD80-0x000000018223CE90
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel); // 0x000000018223D2C0-0x000000018223D3C0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element); // 0x000000018223CE90-0x000000018223CFA0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element); // 0x000000018223D1B0-0x000000018223D2C0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer); // 0x0000000182236EA0-0x0000000182236FA0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer); // 0x000000018223BAF0-0x000000018223BBF0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle); // 0x000000018223B9F0-0x000000018223BAF0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBufferHandle bufferHandle); // 0x000000018223BBF0-0x000000018223BCF0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer); // 0x00000001822375E0-0x00000001822376E0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer); // 0x000000018223BCF0-0x000000018223BDF0
		public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182237010-0x0000000182237100
		public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size); // 0x000000018223BEF0-0x000000018223BFF0
		public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000182237170-0x0000000182237260
		public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, GraphicsBuffer buffer, int offset, int size); // 0x000000018223BDF0-0x000000018223BEF0
		public void SetComputeParamsFromMaterial(ComputeShader computeShader, int kernelIndex, Material material); // 0x0000000182237900-0x00000001822379F0
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x000000018222E130-0x000000018222E210
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset); // 0x000000018222DFE0-0x000000018222E130
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset); // 0x000000018222DE90-0x000000018222DFE0
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure); // 0x000000018222BAC0-0x000000018222BBC0
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin); // 0x000000018222BC90-0x000000018222BD80
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, RayTracingAccelerationStructure.BuildSettings buildSettings); // 0x000000018222BBC0-0x000000018222BC90
		public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000182240B90-0x0000000182240CC0
		public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000182237D50-0x0000000182237E80
		public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000182240A50-0x0000000182240B90
		public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000182237A60-0x0000000182237B90
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer); // 0x0000000182240EB0-0x0000000182240FB0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer); // 0x0000000182237EF0-0x0000000182237FE0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer); // 0x0000000182240CC0-0x0000000182240DC0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer); // 0x0000000182238760-0x0000000182238850
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBufferHandle bufferHandle); // 0x0000000182240DC0-0x0000000182240EB0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle); // 0x0000000182240FB0-0x0000000182241090
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000182238050-0x0000000182238140
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size); // 0x0000000182241090-0x0000000182241190
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x00000001822381B0-0x00000001822382A0
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size); // 0x0000000182241190-0x0000000182241290
		public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, string name, RenderTargetIdentifier rt); // 0x0000000182241EB0-0x0000000182241FA0
		public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, RenderTargetIdentifier rt); // 0x0000000182241DD0-0x0000000182241EB0
		public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, string name, float val); // 0x0000000182241290-0x0000000182241380
		public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val); // 0x0000000182238310-0x00000001822383F0
		public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, string name, params float[] values); // 0x0000000182241380-0x00000001822414D0
		public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, params float[] values); // 0x0000000182238460-0x00000001822385A0
		public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val); // 0x00000001822414D0-0x00000001822415C0
		public void SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val); // 0x00000001822388C0-0x00000001822389A0
		public void SetRayTracingIntParams(RayTracingShader rayTracingShader, string name, params int[] values); // 0x00000001822415C0-0x0000000182241710
		public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, params int[] values); // 0x0000000182238A10-0x0000000182238B50
		public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val); // 0x00000001822421D0-0x00000001822422C0
		public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val); // 0x00000001822420F0-0x00000001822421D0
		public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, params Vector4[] values); // 0x0000000182241FA0-0x00000001822420F0
		public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, params Vector4[] values); // 0x0000000182239010-0x0000000182239150
		public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val); // 0x0000000182241A70-0x0000000182241B80
		public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val); // 0x0000000182241970-0x0000000182241A70
		public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, params Matrix4x4[] values); // 0x0000000182241820-0x0000000182241970
		public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, params Matrix4x4[] values); // 0x0000000182238BC0-0x0000000182238D00
		public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth, Camera camera = null); // 0x000000018222E210-0x000000018222E220
		public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, GraphicsBuffer argsBuffer, uint argsOffset, Camera camera = null); // 0x000000018222E220-0x000000018222E230
		public void GenerateMips(RenderTargetIdentifier rt); // 0x00000001822325D0-0x00000001822326A0
		public void GenerateMips(RenderTexture rt); // 0x0000000182232360-0x00000001822325D0
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, [DefaultValue("0")] int submeshIndex, [DefaultValue("-1")] int shaderPass, [DefaultValue("null")] MaterialPropertyBlock properties); // 0x000000018222F4F0-0x000000018222F820
		[ExcludeFromDocs]
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass); // 0x000000018222F420-0x000000018222F490
		[ExcludeFromDocs]
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex); // 0x000000018222F3C0-0x000000018222F420
		[ExcludeFromDocs]
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material); // 0x000000018222F490-0x000000018222F4F0
		[ExcludeFromDocs]
		public void DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, int[] subsetIndices, int count, Material material, int shaderPass, [DefaultValue("null")] MaterialPropertyBlock properties); // 0x000000018222F820-0x000000018222FA60
		public void DrawRenderer(Renderer renderer, Material material, [DefaultValue("0")] int submeshIndex, [DefaultValue("-1")] int shaderPass); // 0x0000000182231530-0x00000001822317C0
		[ExcludeFromDocs]
		public void DrawRenderer(Renderer renderer, Material material, int submeshIndex); // 0x00000001822317C0-0x00000001822317E0
		[ExcludeFromDocs]
		public void DrawRenderer(Renderer renderer, Material material); // 0x00000001822317E0-0x0000000182231810
		public void DrawRendererList(RendererList rendererList); // 0x00000001822314C0-0x0000000182231530
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, [DefaultValue("1")] int instanceCount, [DefaultValue("null")] MaterialPropertyBlock properties); // 0x0000000182230F20-0x0000000182231110
		[ExcludeFromDocs]
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount); // 0x0000000182230D50-0x0000000182230F20
		[ExcludeFromDocs]
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount); // 0x00000001822312F0-0x00000001822314C0
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties); // 0x0000000182230960-0x0000000182230B70
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount); // 0x0000000182230B70-0x0000000182230D50
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount); // 0x0000000182231110-0x00000001822312F0
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x000000018222FBC0-0x000000018222FE70
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset); // 0x00000001822308F0-0x0000000182230960
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs); // 0x0000000182230130-0x00000001822301A0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x000000018222FE70-0x0000000182230130
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset); // 0x00000001822304D0-0x0000000182230550
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs); // 0x0000000182230550-0x00000001822305D0
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x00000001822305D0-0x0000000182230880
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x0000000182230460-0x00000001822304D0
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs); // 0x0000000182230880-0x00000001822308F0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x00000001822301A0-0x0000000182230460
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x000000018222FAC0-0x000000018222FB40
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs); // 0x000000018222FB40-0x000000018222FBC0
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties); // 0x000000018222EEA0-0x000000018222F3C0
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count); // 0x000000018222EE60-0x000000018222EEA0
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices); // 0x000000018222EE10-0x000000018222EE60
		public void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties = null); // 0x000000018222EAD0-0x000000018222EE10
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x000000018222E740-0x000000018222EA90
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset); // 0x000000018222E680-0x000000018222E6C0
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs); // 0x000000018222EA90-0x000000018222EAD0
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x000000018222E330-0x000000018222E680
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x000000018222E700-0x000000018222E740
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs); // 0x000000018222E6C0-0x000000018222E700
		public void DrawOcclusionMesh(RectInt normalizedCamViewport); // 0x000000018222FA60-0x000000018222FAC0
		public void SetRandomWriteTarget(int index, RenderTargetIdentifier rt); // 0x00000001822407D0-0x0000000182240890
		public void SetRandomWriteTarget(int index, ComputeBuffer buffer, bool preserveCounterValue); // 0x0000000182240970-0x0000000182240A50
		public void SetRandomWriteTarget(int index, ComputeBuffer buffer); // 0x0000000182240610-0x00000001822406F0
		public void SetRandomWriteTarget(int index, GraphicsBuffer buffer, bool preserveCounterValue); // 0x0000000182240890-0x0000000182240970
		public void SetRandomWriteTarget(int index, GraphicsBuffer buffer); // 0x00000001822406F0-0x00000001822407D0
		public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x000000018222CBB0-0x000000018222CC60
		public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x000000018222CDF0-0x000000018222CEA0
		public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x000000018222CCD0-0x000000018222CD80
		public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x000000018222CF10-0x000000018222CFC0
		public void CopyTexture(RenderTargetIdentifier src, RenderTargetIdentifier dst); // 0x000000018222D1C0-0x000000018222D290
		public void CopyTexture(RenderTargetIdentifier src, int srcElement, RenderTargetIdentifier dst, int dstElement); // 0x000000018222D380-0x000000018222D460
		public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, RenderTargetIdentifier dst, int dstElement, int dstMip); // 0x000000018222D290-0x000000018222D380
		public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, RenderTargetIdentifier dst, int dstElement, int dstMip, int dstX, int dstY); // 0x000000018222D0C0-0x000000018222D1C0
		public void Blit(Texture source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset); // 0x000000018222B990-0x000000018222BAC0
		public void SetGlobalFloat(string name, float value); // 0x000000018223E870-0x000000018223E900
		public void SetGlobalInt(string name, int value); // 0x000000018223E9A0-0x000000018223EA30
		public void SetGlobalInteger(string name, int value); // 0x000000018223EAF0-0x000000018223EB80
		public void SetGlobalVector(string name, Vector4 value); // 0x000000018223FC30-0x000000018223FCC0
		public void SetGlobalColor(string name, Color value); // 0x000000018223DD90-0x000000018223DE20
		public void SetGlobalMatrix(string name, Matrix4x4 value); // 0x000000018223F2D0-0x000000018223F370
		public void SetGlobalFloatArray(string propertyName, List<float> values); // 0x000000018223E770-0x000000018223E7B0
		public void SetGlobalFloatArray(int nameID, List<float> values); // 0x000000018223E5C0-0x000000018223E770
		public void SetGlobalFloatArray(string propertyName, float[] values); // 0x000000018223E4B0-0x000000018223E5C0
		public void SetGlobalVectorArray(string propertyName, List<Vector4> values); // 0x000000018223F7E0-0x000000018223F820
		public void SetGlobalVectorArray(int nameID, List<Vector4> values); // 0x000000018223F920-0x000000018223FAD0
		public void SetGlobalVectorArray(string propertyName, Vector4[] values); // 0x000000018223FAD0-0x000000018223FBE0
		public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values); // 0x000000018223EF20-0x000000018223EF60
		public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values); // 0x000000018223EF60-0x000000018223F110
		public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values); // 0x000000018223EE10-0x000000018223EF20
		public void SetGlobalTexture(string name, RenderTargetIdentifier value); // 0x000000018223F5F0-0x000000018223F690
		public void SetGlobalTexture(int nameID, RenderTargetIdentifier value); // 0x000000018223F4D0-0x000000018223F540
		public void SetGlobalTexture(string name, RenderTargetIdentifier value, RenderTextureSubElement element); // 0x000000018223F540-0x000000018223F5F0
		public void SetGlobalTexture(int nameID, RenderTargetIdentifier value, RenderTextureSubElement element); // 0x000000018223F450-0x000000018223F4D0
		public void SetGlobalBuffer(string name, ComputeBuffer value); // 0x000000018223DB10-0x000000018223DBB0
		public void SetGlobalBuffer(int nameID, ComputeBuffer value); // 0x000000018223DA90-0x000000018223DB10
		public void SetGlobalBuffer(string name, GraphicsBuffer value); // 0x000000018223DC30-0x000000018223DCD0
		public void SetGlobalBuffer(int nameID, GraphicsBuffer value); // 0x000000018223DBB0-0x000000018223DC30
		public void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size); // 0x000000018223DE90-0x000000018223DF30
		public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size); // 0x000000018223DFD0-0x000000018223E070
		public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size); // 0x000000018223DF30-0x000000018223DFD0
		public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size); // 0x000000018223E070-0x000000018223E110
		public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode); // 0x0000000182245510-0x00000001822455D0
		public void SetSinglePassStereo(SinglePassStereoMode mode); // 0x00000001822392E0-0x0000000182239340
		public void IssuePluginEvent(IntPtr callback, int eventID); // 0x0000000182239B30-0x0000000182239BF0
		public void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data); // 0x0000000182239940-0x0000000182239A60
		public void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags); // 0x0000000182239570-0x0000000182239660
		public void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData); // 0x0000000182239770-0x0000000182239850
		public void CopyBuffer(GraphicsBuffer source, GraphicsBuffer dest); // 0x000000018222C9E0-0x000000018222CB40
		private static void WaitAllAsyncReadbackRequests_Injected(IntPtr _unity_self); // 0x0000000182245B70-0x0000000182245BB0
		private static unsafe void Internal_RequestAsyncReadback_1_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x00000001822360B0-0x0000000182236120
		private static unsafe void Internal_RequestAsyncReadback_2_Injected(IntPtr _unity_self, IntPtr src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x0000000182236220-0x0000000182236290
		private static unsafe void Internal_RequestAsyncReadback_3_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x00000001822363A0-0x0000000182236410
		private static unsafe void Internal_RequestAsyncReadback_4_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x0000000182236520-0x0000000182236590
		private static unsafe void Internal_RequestAsyncReadback_5_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x00000001822366A0-0x0000000182236710
		private static unsafe void Internal_RequestAsyncReadback_6_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x0000000182236820-0x0000000182236890
		private static unsafe void Internal_RequestAsyncReadback_7_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x00000001822369B0-0x0000000182236A20
		private static unsafe void Internal_RequestAsyncReadback_8_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x0000000182236B40-0x0000000182236BB0
		private static unsafe void Internal_RequestAsyncReadback_9_Injected(IntPtr _unity_self, IntPtr src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData); // 0x0000000182236CB0-0x0000000182236D20
		private static void SetInvertCulling_Injected(IntPtr _unity_self, bool invertCulling); // 0x000000018223FDD0-0x000000018223FE20
		private static void Internal_SetSinglePassStereo_Injected(IntPtr _unity_self, SinglePassStereoMode mode); // 0x00000001822392A0-0x00000001822392E0
		private static IntPtr CreateGPUFence_Internal_Injected(IntPtr _unity_self, GraphicsFenceType fenceType, SynchronisationStageFlags stage); // 0x000000018222D5E0-0x000000018222D630
		private static void WaitOnGPUFence_Internal_Injected(IntPtr _unity_self, IntPtr fencePtr, SynchronisationStageFlags stage); // 0x0000000182245D20-0x0000000182245D80
		private static void ReleaseBuffer_Injected(IntPtr _unity_self); // 0x0000000182239DF0-0x0000000182239E30
		private static void SetComputeFloatParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, float val); // 0x000000018223BFF0-0x000000018223C060
		private static void SetComputeIntParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, int val); // 0x000000018223C380-0x000000018223C3F0
		private static void SetComputeVectorParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, in Vector4 val); // 0x000000018223D6C0-0x000000018223D730
		private static void SetComputeVectorArrayParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values); // 0x000000018223D3C0-0x000000018223D430
		private static void SetComputeMatrixParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, in Matrix4x4 val); // 0x000000018223CB20-0x000000018223CB90
		private static void SetComputeMatrixArrayParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values); // 0x000000018223C820-0x000000018223C890
		private static void Internal_SetComputeFloats_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values); // 0x0000000182237260-0x00000001822372D0
		private static void Internal_SetComputeInts_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values); // 0x00000001822376E0-0x0000000182237750
		private static void Internal_SetComputeTextureParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, ref RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element); // 0x0000000182237B90-0x0000000182237C00
		private static void Internal_SetComputeBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr buffer); // 0x0000000182236E30-0x0000000182236EA0
		private static void Internal_SetComputeGraphicsBufferHandleParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, in GraphicsBufferHandle bufferHandle); // 0x0000000182237410-0x0000000182237480
		private static void Internal_SetComputeGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr buffer); // 0x0000000182237570-0x00000001822375E0
		private static void Internal_SetComputeConstantComputeBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, IntPtr buffer, int offset, int size); // 0x0000000182236FA0-0x0000000182237010
		private static void Internal_SetComputeConstantGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, IntPtr buffer, int offset, int size); // 0x0000000182237100-0x0000000182237170
		private static void Internal_SetComputeParamsFromMaterial_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, IntPtr material); // 0x0000000182237890-0x0000000182237900
		private static void Internal_DispatchCompute_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x00000001822345F0-0x0000000182234660
		private static void Internal_DispatchComputeIndirect_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, IntPtr indirectBuffer, uint argsOffset); // 0x0000000182234490-0x0000000182234500
		private static void Internal_DispatchComputeIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, IntPtr indirectBuffer, uint argsOffset); // 0x0000000182234330-0x00000001822343A0
		private static void Internal_SetRayTracingComputeBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer); // 0x0000000182237E80-0x0000000182237EF0
		private static void Internal_SetRayTracingGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer); // 0x00000001822386F0-0x0000000182238760
		private static void Internal_SetRayTracingGraphicsBufferHandleParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in GraphicsBufferHandle bufferHandle); // 0x00000001822385A0-0x0000000182238610
		private static void Internal_SetRayTracingConstantComputeBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer, int offset, int size); // 0x0000000182237FE0-0x0000000182238050
		private static void Internal_SetRayTracingConstantGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer, int offset, int size); // 0x0000000182238140-0x00000001822381B0
		private static void Internal_SetRayTracingTextureParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref RenderTargetIdentifier rt); // 0x0000000182238E50-0x0000000182238EC0
		private static void Internal_SetRayTracingFloatParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, float val); // 0x00000001822382A0-0x0000000182238310
		private static void Internal_SetRayTracingIntParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, int val); // 0x0000000182238850-0x00000001822388C0
		private static void Internal_SetRayTracingVectorParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in Vector4 val); // 0x0000000182239150-0x00000001822391C0
		private static void Internal_SetRayTracingVectorArrayParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values); // 0x0000000182238FA0-0x0000000182239010
		private static void Internal_SetRayTracingMatrixParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in Matrix4x4 val); // 0x0000000182238D00-0x0000000182238D70
		private static void Internal_SetRayTracingMatrixArrayParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values); // 0x0000000182238B50-0x0000000182238BC0
		private static void Internal_SetRayTracingFloats_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values); // 0x00000001822383F0-0x0000000182238460
		private static void Internal_SetRayTracingInts_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values); // 0x00000001822389A0-0x0000000182238A10
		private static void Internal_BuildRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr accelerationStructure, in RayTracingAccelerationStructure.BuildSettings buildSettings); // 0x0000000182234200-0x0000000182234260
		private static void Internal_SetRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr accelerationStructure); // 0x0000000182237CE0-0x0000000182237D50
		private static void Internal_SetComputeRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr accelerationStructure); // 0x00000001822379F0-0x0000000182237A60
		private static void SetRayTracingShaderPass_Injected(IntPtr _unity_self, IntPtr rayTracingShader, ref ManagedSpanWrapper passName); // 0x0000000182241B80-0x0000000182241BE0
		private static void Internal_DispatchRays_Injected(IntPtr _unity_self, IntPtr rayTracingShader, ref ManagedSpanWrapper rayGenShaderName, uint width, uint height, uint depth, IntPtr camera); // 0x0000000182234950-0x00000001822349C0
		private static void Internal_DispatchRaysIndirect_Injected(IntPtr _unity_self, IntPtr rayTracingShader, ref ManagedSpanWrapper rayGenShaderName, IntPtr argsBuffer, uint argsOffset, IntPtr camera); // 0x0000000182234660-0x00000001822346D0
		private static void Internal_GenerateMips_Injected(IntPtr _unity_self, in RenderTargetIdentifier rt); // 0x0000000182236000-0x0000000182236050
		private static void CopyCounterValueCC_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes); // 0x000000018222CB40-0x000000018222CBB0
		private static void CopyCounterValueGC_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes); // 0x000000018222CD80-0x000000018222CDF0
		private static void CopyCounterValueCG_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes); // 0x000000018222CC60-0x000000018222CCD0
		private static void CopyCounterValueGG_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes); // 0x000000018222CEA0-0x000000018222CF10
		private static void get_name_Injected(IntPtr _unity_self, ); // 0x0000000182245E30-0x0000000182245E80
		private static void set_name_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x0000000182246010-0x0000000182246060
		private static int get_sizeInBytes_Injected(IntPtr _unity_self); // 0x0000000182245F70-0x0000000182245FB0
		private static void Clear_Injected(IntPtr _unity_self); // 0x000000018222C710-0x000000018222C750
		private static void Internal_DrawMesh_Injected(IntPtr _unity_self, IntPtr mesh, in Matrix4x4 matrix, IntPtr material, int submeshIndex, int shaderPass, IntPtr properties); // 0x0000000182235180-0x00000001822351F0
		private static void Internal_DrawMultipleMeshes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper matrices, Mesh[] meshes, ref ManagedSpanWrapper subsetIndices, int count, IntPtr material, int shaderPass, IntPtr properties); // 0x0000000182235320-0x0000000182235390
		private static void Internal_DrawRenderer_Injected(IntPtr _unity_self, IntPtr renderer, IntPtr material, int submeshIndex, int shaderPass); // 0x0000000182235EA0-0x0000000182235F10
		private static void Internal_DrawRendererList_Injected(IntPtr _unity_self, in RendererList rendererList); // 0x0000000182235DF0-0x0000000182235E40
		private static void Internal_DrawProcedural_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, IntPtr properties); // 0x0000000182235CB0-0x0000000182235D20
		private static void Internal_DrawProceduralIndexed_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, IntPtr properties); // 0x00000001822358A0-0x0000000182235910
		private static void Internal_DrawProceduralIndirect_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x0000000182235B60-0x0000000182235BD0
		private static void Internal_DrawProceduralIndexedIndirect_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x0000000182235730-0x00000001822357A0
		private static void Internal_DrawProceduralIndirectGraphicsBuffer_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x0000000182235A10-0x0000000182235A80
		private static void Internal_DrawProceduralIndexedIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x00000001822355C0-0x0000000182235630
		private static void Internal_DrawMeshInstanced_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, ref ManagedSpanWrapper matrices, int count, IntPtr properties); // 0x0000000182234FD0-0x0000000182235040
		private static void Internal_DrawMeshInstancedProcedural_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, int count, IntPtr properties); // 0x0000000182234EA0-0x0000000182234F10
		private static void Internal_DrawMeshInstancedIndirect_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x0000000182234D50-0x0000000182234DC0
		private static void Internal_DrawMeshInstancedIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, IntPtr bufferWithArgs, int argsOffset, IntPtr properties); // 0x0000000182234C00-0x0000000182234C70
		private static void Internal_DrawOcclusionMesh_Injected(IntPtr _unity_self, in RectInt normalizedCamViewport); // 0x0000000182235510-0x0000000182235560
		private static void SetRandomWriteTarget_Texture_Injected(IntPtr _unity_self, int index, ref RenderTargetIdentifier rt); // 0x0000000182240550-0x00000001822405A0
		private static void SetRandomWriteTarget_Buffer_Injected(IntPtr _unity_self, int index, IntPtr uav, bool preserveCounterValue); // 0x0000000182240330-0x00000001822403A0
		private static void SetRandomWriteTarget_GraphicsBuffer_Injected(IntPtr _unity_self, int index, IntPtr uav, bool preserveCounterValue); // 0x0000000182240440-0x00000001822404B0
		private static void ClearRandomWriteTargets_Injected(IntPtr _unity_self); // 0x000000018222BE10-0x000000018222BE50
		private static void SetViewport_Injected(IntPtr _unity_self, in Rect pixelRect); // 0x00000001822456A0-0x00000001822456F0
		private static void EnableScissorRect_Injected(IntPtr _unity_self, in Rect scissor); // 0x0000000182231C20-0x0000000182231C70
		private static void DisableScissorRect_Injected(IntPtr _unity_self); // 0x000000018222DC30-0x000000018222DC70
		private static void CopyTexture_Internal_Injected(IntPtr _unity_self, ref RenderTargetIdentifier src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, ref RenderTargetIdentifier dst, int dstElement, int dstMip, int dstX, int dstY, int mode); // 0x000000018222CFC0-0x000000018222D030
		private static void Blit_Texture_Injected(IntPtr _unity_self, IntPtr source, ref RenderTargetIdentifier dest, IntPtr mat, int pass, in Vector2 scale, in Vector2 offset, int sourceDepthSlice, int destDepthSlice); // 0x000000018222B830-0x000000018222B8A0
		private static void GetTemporaryRT_Injected(IntPtr _unity_self, int nameID, int width, int height, FilterMode filter, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale, ShadowSamplingMode shadowSamplingMode); // 0x0000000182232780-0x0000000182232810
		private static void GetTemporaryRTWithDescriptor_Injected(IntPtr _unity_self, int nameID, in RenderTextureDescriptor desc, FilterMode filter); // 0x00000001822326A0-0x0000000182232700
		private static void ReleaseTemporaryRT_Injected(IntPtr _unity_self, int nameID); // 0x0000000182239E90-0x0000000182239ED0
		private static void SetGlobalFloat_Injected(IntPtr _unity_self, int nameID, float value); // 0x000000018223E7B0-0x000000018223E800
		private static void SetGlobalInt_Injected(IntPtr _unity_self, int nameID, int value); // 0x000000018223E950-0x000000018223E9A0
		private static void SetGlobalInteger_Injected(IntPtr _unity_self, int nameID, int value); // 0x000000018223EAA0-0x000000018223EAF0
		private static void SetGlobalVector_Injected(IntPtr _unity_self, int nameID, in Vector4 value); // 0x000000018223FBE0-0x000000018223FC30
		private static void SetGlobalColor_Injected(IntPtr _unity_self, int nameID, in Color value); // 0x000000018223DCD0-0x000000018223DD20
		private static void SetGlobalMatrix_Injected(IntPtr _unity_self, int nameID, in Matrix4x4 value); // 0x000000018223F210-0x000000018223F260
		private static void EnableShaderKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x0000000182231CD0-0x0000000182231D20
		private static void EnableGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword); // 0x0000000182231900-0x0000000182231950
		private static void EnableMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword); // 0x0000000182231B30-0x0000000182231B90
		private static void EnableComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword); // 0x0000000182231810-0x0000000182231870
		private static void DisableShaderKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x000000018222DCD0-0x000000018222DD20
		private static void DisableGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword); // 0x000000018222D910-0x000000018222D960
		private static void DisableMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword); // 0x000000018222DB40-0x000000018222DBA0
		private static void DisableComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword); // 0x000000018222D820-0x000000018222D880
		private static void SetGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword, bool value); // 0x000000018223EBF0-0x000000018223EC50
		private static void SetMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword, bool value); // 0x0000000182240220-0x0000000182240290
		private static void SetComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword, bool value); // 0x000000018223C710-0x000000018223C780
		private static void SetRayTracingKeyword_Injected(IntPtr _unity_self, IntPtr rayTracingShader, in LocalKeyword keyword, bool value); // 0x0000000182241710-0x0000000182241780
		private static void SetViewProjectionMatrices_Injected(IntPtr _unity_self, in Matrix4x4 view, in Matrix4x4 proj); // 0x00000001822455D0-0x0000000182245630
		private static void SetGlobalDepthBias_Injected(IntPtr _unity_self, float bias, float slopeBias); // 0x000000018223E180-0x000000018223E1E0
		private static void SetExecutionFlags_Injected(IntPtr _unity_self, CommandBufferExecutionFlags flags); // 0x000000018223D900-0x000000018223D940
		private static bool ValidateAgainstExecutionFlags_Injected(IntPtr _unity_self, CommandBufferExecutionFlags requiredFlags, CommandBufferExecutionFlags invalidFlags); // 0x0000000182245AB0-0x0000000182245B00
		private static void SetGlobalFloatArrayListImpl_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223E260-0x000000018223E2B0
		private static void SetGlobalVectorArrayListImpl_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223F690-0x000000018223F6E0
		private static void SetGlobalMatrixArrayListImpl_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223ECC0-0x000000018223ED10
		private static void SetGlobalFloatArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223E360-0x000000018223E3B0
		private static void SetGlobalVectorArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223F790-0x000000018223F7E0
		private static void SetGlobalMatrixArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x000000018223EDC0-0x000000018223EE10
		private static void SetLateLatchProjectionMatrices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper projectionMat); // 0x00000001822400D0-0x0000000182240120
		private static void MarkLateLatchMatrixShaderPropertyID_Injected(IntPtr _unity_self, CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID); // 0x0000000182239BF0-0x0000000182239C40
		private static void UnmarkLateLatchMatrix_Injected(IntPtr _unity_self, CameraLateLatchMatrixType matrixPropertyType); // 0x0000000182245A10-0x0000000182245A50
		private static void SetGlobalTexture_Impl_Injected(IntPtr _unity_self, int nameID, ref RenderTargetIdentifier rt, RenderTextureSubElement element); // 0x000000018223F370-0x000000018223F3D0
		private static void SetGlobalBufferInternal_Injected(IntPtr _unity_self, int nameID, IntPtr value); // 0x000000018223DA40-0x000000018223DA90
		private static void SetGlobalGraphicsBufferInternal_Injected(IntPtr _unity_self, int nameID, IntPtr value); // 0x000000018223E900-0x000000018223E950
		private static void SetShadowSamplingMode_Impl_Injected(IntPtr _unity_self, ref RenderTargetIdentifier shadowmap, ShadowSamplingMode mode); // 0x0000000182245440-0x00000001822454A0
		private static void IssuePluginEventInternal_Injected(IntPtr _unity_self, IntPtr callback, int eventID); // 0x0000000182239A60-0x0000000182239AC0
		private static void BeginSample_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018222B670-0x000000018222B6C0
		private static void EndSample_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x00000001822320E0-0x0000000182232130
		private static void BeginSample_CustomSampler_Injected(IntPtr _unity_self, IntPtr sampler); // 0x000000018222B560-0x000000018222B5B0
		private static void EndSample_CustomSampler_Injected(IntPtr _unity_self, IntPtr sampler); // 0x0000000182231FD0-0x0000000182232020
		private static void IssuePluginEventAndDataInternal_Injected(IntPtr _unity_self, IntPtr callback, int eventID, IntPtr data); // 0x0000000182239850-0x00000001822398C0
		private static void IssuePluginCustomBlitInternal_Injected(IntPtr _unity_self, IntPtr callback, uint command, ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, uint commandParam, uint commandFlags); // 0x0000000182239480-0x00000001822394F0
		private static void IssuePluginCustomTextureUpdateInternal_Injected(IntPtr _unity_self, IntPtr callback, IntPtr targetTexture, uint userData, bool useNewUnityRenderingExtTextureUpdateParamsV2); // 0x0000000182239660-0x00000001822396D0
		private static void SetGlobalConstantBufferInternal_Injected(IntPtr _unity_self, IntPtr buffer, int nameID, int offset, int size); // 0x000000018223DE20-0x000000018223DE90
		private static void SetGlobalConstantGraphicsBufferInternal_Injected(IntPtr _unity_self, IntPtr buffer, int nameID, int offset, int size); // 0x000000018223E110-0x000000018223E180
		private static void IncrementUpdateCount_Injected(IntPtr _unity_self, in RenderTargetIdentifier dest); // 0x00000001822338A0-0x00000001822338F0
		private static void SetInstanceMultiplier_Injected(IntPtr _unity_self, uint multiplier); // 0x000000018223FD30-0x000000018223FD70
		private static void SetFoveatedRenderingMode_Injected(IntPtr _unity_self, FoveatedRenderingMode foveatedRenderingMode); // 0x000000018223D9A0-0x000000018223D9E0
		private static void SetWireframe_Injected(IntPtr _unity_self, bool enable); // 0x0000000182245750-0x00000001822457A0
		private static void ConfigureFoveatedRendering_Injected(IntPtr _unity_self, IntPtr platformData); // 0x000000018222C7B0-0x000000018222C800
		private static void ClearRenderTargetSingle_Internal_Injected(IntPtr _unity_self, RTClearFlags clearFlags, in Color color, float depth, uint stencil); // 0x000000018222BFF0-0x000000018222C050
		private static void ClearRenderTargetMulti_Internal_Injected(IntPtr _unity_self, RTClearFlags clearFlags, ref ManagedSpanWrapper colors, float depth, uint stencil); // 0x000000018222BEB0-0x000000018222BF10
		private static void SetRenderTargetSingle_Internal_Injected(IntPtr _unity_self, in RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction); // 0x0000000182242910-0x0000000182242980
		private static void SetRenderTargetColorDepth_Internal_Injected(IntPtr _unity_self, in RenderTargetIdentifier color, in RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags); // 0x00000001822423F0-0x0000000182242460
		private static void SetRenderTargetMulti_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, in RenderTargetIdentifier depth, ref ManagedSpanWrapper colorLoadActions, ref ManagedSpanWrapper colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags); // 0x0000000182242710-0x0000000182242780
		private static void SetRenderTargetColorDepthSubtarget_Injected(IntPtr _unity_self, in RenderTargetIdentifier color, in RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x00000001822422C0-0x0000000182242330
		private static void SetRenderTargetMultiSubtarget_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, in RenderTargetIdentifier depth, ref ManagedSpanWrapper colorLoadActions, ref ManagedSpanWrapper colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182242500-0x0000000182242570
		private static void InternalSetComputeBufferNativeData_Injected(IntPtr _unity_self, IntPtr buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233C70-0x0000000182233CE0
		private static void InternalSetComputeBufferData_Injected(IntPtr _unity_self, IntPtr buffer, ref ManagedSpanWrapper data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233AB0-0x0000000182233B20
		private static void InternalSetComputeBufferCounterValue_Injected(IntPtr _unity_self, IntPtr buffer, uint counterValue); // 0x0000000182233980-0x00000001822339E0
		private static void InternalSetGraphicsBufferNativeData_Injected(IntPtr _unity_self, IntPtr buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x00000001822340B0-0x0000000182234120
		private static void InternalSetGraphicsBufferData_Injected(IntPtr _unity_self, IntPtr buffer, ref ManagedSpanWrapper data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x0000000182233EF0-0x0000000182233F60
		private static void InternalSetGraphicsBufferCounterValue_Injected(IntPtr _unity_self, IntPtr buffer, uint counterValue); // 0x0000000182233DC0-0x0000000182233E20
		private static void CopyBufferImpl_Injected(IntPtr _unity_self, IntPtr source, IntPtr dest); // 0x000000018222C860-0x000000018222C8C0
		private static void BeginRenderPass_Internal_Injected(IntPtr _unity_self, int width, int height, int volumeDepth, int samples, ref ManagedSpanWrapper attachments, int depthAttachmentIndex, int shadingRateImageAttachmentIndex, ref ManagedSpanWrapper subPasses, ref ManagedSpanWrapper debugNameUtf8); // 0x000000018222B190-0x000000018222B1F0
		private static void NextSubPass_Internal_Injected(IntPtr _unity_self); // 0x0000000182239CB0-0x0000000182239CF0
		private static void EndRenderPass_Internal_Injected(IntPtr _unity_self); // 0x0000000182231E90-0x0000000182231ED0
		private static void SetupCameraProperties_Internal_Injected(IntPtr _unity_self, IntPtr camera); // 0x0000000182245800-0x0000000182245850
		private static void InvokeOnRenderObjectCallbacks_Internal_Injected(IntPtr _unity_self); // 0x0000000182239340-0x0000000182239380
		private static void SetShadingRateFragmentSize_Impl_Injected(IntPtr _unity_self, ShadingRateFragmentSize shadingRateFragmentSize); // 0x00000001822452F0-0x0000000182245330
		private static void SetShadingRateCombiner_Impl_Injected(IntPtr _unity_self, ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000182245230-0x0000000182245280
		private static void SetShadingRateImage_Impl_Injected(IntPtr _unity_self, [IsReadOnly] in RenderTargetIdentifier shadingRateImage); // 0x0000000182245390-0x00000001822453E0
		private static void ResetShadingRate_Impl_Injected(IntPtr _unity_self); // 0x000000018223AE70-0x000000018223AEB0
	}
}
