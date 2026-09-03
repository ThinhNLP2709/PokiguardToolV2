/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class ComputeCommandBuffer : BaseCommandBuffer, IComputeCommandBuffer // TypeDefIndex: 5331
	{
		// Constructors
		internal ComputeCommandBuffer(CommandBuffer wrapped, RenderGraphPass executingPass, bool isAsync); // 0x0000000181E21870-0x0000000181E21880
	
		// Methods
		public void SetInvertCulling(bool invertCulling); // 0x0000000181E20E70-0x0000000181E20E90
		public void SetComputeFloatParam(ComputeShader computeShader, int nameID, float val); // 0x0000000181E1FD30-0x0000000181E1FD60
		public void SetComputeIntParam(ComputeShader computeShader, int nameID, int val); // 0x0000000181E1FDC0-0x0000000181E1FDF0
		public void SetComputeVectorParam(ComputeShader computeShader, int nameID, Vector4 val); // 0x0000000181E20610-0x0000000181E20650
		public void SetComputeVectorArrayParam(ComputeShader computeShader, int nameID, Vector4[] values); // 0x0000000181E20570-0x0000000181E205A0
		public void SetComputeMatrixParam(ComputeShader computeShader, int nameID, Matrix4x4 val); // 0x0000000181E1FF40-0x0000000181E1FFA0
		public void SetComputeMatrixArrayParam(ComputeShader computeShader, int nameID, Matrix4x4[] values); // 0x0000000181E1FE80-0x0000000181E1FEB0
		public void SetRayTracingShaderPass(RayTracingShader rayTracingShader, string passName); // 0x0000000181E21470-0x0000000181E21490
		public void SetViewport(Rect pixelRect); // 0x0000000181E21800-0x0000000181E21830
		public void EnableScissorRect(Rect scissor); // 0x0000000181E1F800-0x0000000181E1F830
		public void DisableScissorRect(); // 0x0000000181E1F670-0x0000000181E1F690
		public void SetGlobalFloat(int nameID, float value); // 0x0000000181E20890-0x0000000181E208B0
		public void SetGlobalInt(int nameID, int value); // 0x0000000181E208D0-0x0000000181E208F0
		public void SetGlobalInteger(int nameID, int value); // 0x0000000181E20930-0x0000000181E20950
		public void SetGlobalVector(int nameID, Vector4 value); // 0x0000000181E20E10-0x0000000181E20E40
		public void SetGlobalColor(int nameID, Color value); // 0x0000000181E206D0-0x0000000181E20700
		public void SetGlobalMatrix(int nameID, Matrix4x4 value); // 0x0000000181E209D0-0x0000000181E20A20
		public void EnableShaderKeyword(string keyword); // 0x0000000181E1F830-0x0000000181E1F850
		public void EnableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x0000000181E1F7A0-0x0000000181E1F7C0
		public void EnableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F7E0-0x0000000181E1F800
		public void EnableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F7C0-0x0000000181E1F7E0
		public void DisableShaderKeyword(string keyword); // 0x0000000181E1F690-0x0000000181E1F6B0
		public void DisableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x0000000181E1F610-0x0000000181E1F630
		public void DisableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F650-0x0000000181E1F670
		public void DisableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F630-0x0000000181E1F650
		public void SetKeyword([IsReadOnly] in GlobalKeyword keyword, bool value); // 0x0000000181E20E90-0x0000000181E20EB0
		public void SetKeyword(Material material, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000181E20EE0-0x0000000181E20F10
		public void SetKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000181E20EB0-0x0000000181E20EE0
		public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj); // 0x0000000181E21780-0x0000000181E21800
		public void SetGlobalDepthBias(float bias, float slopeBias); // 0x0000000181E207F0-0x0000000181E20810
		public void SetGlobalFloatArray(int nameID, float[] values); // 0x0000000181E20850-0x0000000181E20870
		public void SetGlobalVectorArray(int nameID, Vector4[] values); // 0x0000000181E20DD0-0x0000000181E20DF0
		public void SetGlobalMatrixArray(int nameID, Matrix4x4[] values); // 0x0000000181E20990-0x0000000181E209B0
		public void SetLateLatchProjectionMatrices(Matrix4x4[] projectionMat); // 0x0000000181E20F10-0x0000000181E20F30
		public void MarkLateLatchMatrixShaderPropertyID(CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID); // 0x0000000181E1FA20-0x0000000181E1FA40
		public void UnmarkLateLatchMatrix(CameraLateLatchMatrixType matrixPropertyType); // 0x0000000181E21850-0x0000000181E21870
		public void BeginSample(string name); // 0x0000000181E1F480-0x0000000181E1F4A0
		public void EndSample(string name); // 0x0000000181E1F850-0x0000000181E1F870
		public void BeginSample(CustomSampler sampler); // 0x0000000181E1F4A0-0x0000000181E1F4C0
		public void EndSample(CustomSampler sampler); // 0x0000000181E1F870-0x0000000181E1F890
		public void BeginSample(ProfilerMarker marker); // 0x00000001802E76C0-0x00000001802E76D0
		public void EndSample(ProfilerMarker marker); // 0x00000001802E76C0-0x00000001802E76D0
		public void IncrementUpdateCount(RenderTargetIdentifier dest); // 0x0000000181E1F890-0x0000000181E1F8E0
		public void SetBufferData(ComputeBuffer buffer, Array data); // 0x0000000181E1FB00-0x0000000181E1FB20
		public void SetBufferData<T>(ComputeBuffer buffer, List<T> data)
			where T : struct;
		public void SetBufferData<T>(ComputeBuffer buffer, NativeArray<T> data)
			where T : struct;
		public void SetBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count); // 0x0000000181E1FAB0-0x0000000181E1FAE0
		public void SetBufferData<T>(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferData<T>(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferCounterValue(ComputeBuffer buffer, uint counterValue); // 0x0000000181E1FA60-0x0000000181E1FA80
		public void SetBufferData(GraphicsBuffer buffer, Array data); // 0x0000000181E1FAE0-0x0000000181E1FB00
		public void SetBufferData<T>(GraphicsBuffer buffer, List<T> data)
			where T : struct;
		public void SetBufferData<T>(GraphicsBuffer buffer, NativeArray<T> data)
			where T : struct;
		public void SetBufferData(GraphicsBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count); // 0x0000000181E1FA80-0x0000000181E1FAB0
		public void SetBufferData<T>(GraphicsBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferData<T>(GraphicsBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		public void SetBufferCounterValue(GraphicsBuffer buffer, uint counterValue); // 0x0000000181E1FA40-0x0000000181E1FA60
		public void SetupCameraProperties(Camera camera); // 0x0000000181E21830-0x0000000181E21850
		public void InvokeOnRenderObjectCallbacks(); // 0x0000000181E1F8E0-0x0000000181E1F900
		public void SetComputeFloatParam(ComputeShader computeShader, string name, float val); // 0x0000000181E1FD00-0x0000000181E1FD30
		public void SetComputeIntParam(ComputeShader computeShader, string name, int val); // 0x0000000181E1FDF0-0x0000000181E1FE20
		public void SetComputeVectorParam(ComputeShader computeShader, string name, Vector4 val); // 0x0000000181E205D0-0x0000000181E20610
		public void SetComputeVectorArrayParam(ComputeShader computeShader, string name, Vector4[] values); // 0x0000000181E205A0-0x0000000181E205D0
		public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val); // 0x0000000181E1FEE0-0x0000000181E1FF40
		public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values); // 0x0000000181E1FEB0-0x0000000181E1FEE0
		public void SetComputeFloatParams(ComputeShader computeShader, string name, params float[] values); // 0x0000000181E1FD90-0x0000000181E1FDC0
		public void SetComputeFloatParams(ComputeShader computeShader, int nameID, params float[] values); // 0x0000000181E1FD60-0x0000000181E1FD90
		public void SetComputeIntParams(ComputeShader computeShader, string name, params int[] values); // 0x0000000181E1FE20-0x0000000181E1FE50
		public void SetComputeIntParams(ComputeShader computeShader, int nameID, params int[] values); // 0x0000000181E1FE50-0x0000000181E1FE80
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt); // 0x0000000181E202A0-0x0000000181E20380
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt); // 0x0000000181E201C0-0x0000000181E202A0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt, int mipLevel); // 0x0000000181E1FFD0-0x0000000181E200C0
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt, int mipLevel); // 0x0000000181E20480-0x0000000181E20570
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt, int mipLevel, RenderTextureSubElement element); // 0x0000000181E20380-0x0000000181E20480
		public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt, int mipLevel, RenderTextureSubElement element); // 0x0000000181E200C0-0x0000000181E201C0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer); // 0x0000000181E1FBE0-0x0000000181E1FC10
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer); // 0x0000000181E1FB50-0x0000000181E1FB80
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle); // 0x0000000181E1FBB0-0x0000000181E1FBE0
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBufferHandle bufferHandle); // 0x0000000181E1FC10-0x0000000181E1FC40
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer); // 0x0000000181E1FB20-0x0000000181E1FB50
		public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer); // 0x0000000181E1FB80-0x0000000181E1FBB0
		public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000181E1FC40-0x0000000181E1FC70
		public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size); // 0x0000000181E1FCD0-0x0000000181E1FD00
		public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000181E1FC70-0x0000000181E1FCA0
		public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, GraphicsBuffer buffer, int offset, int size); // 0x0000000181E1FCA0-0x0000000181E1FCD0
		public void SetComputeParamsFromMaterial(ComputeShader computeShader, int kernelIndex, Material material); // 0x0000000181E1FFA0-0x0000000181E1FFD0
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x0000000181E1F710-0x0000000181E1F740
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset); // 0x0000000181E1F6B0-0x0000000181E1F6E0
		public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset); // 0x0000000181E1F6E0-0x0000000181E1F710
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure); // 0x0000000181E1F4F0-0x0000000181E1F510
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin); // 0x0000000181E1F510-0x0000000181E1F550
		public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, RayTracingAccelerationStructure.BuildSettings buildSettings); // 0x0000000181E1F4C0-0x0000000181E1F4F0
		public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000181E20FC0-0x0000000181E20FF0
		public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000181E20F60-0x0000000181E20F90
		public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000181E20F90-0x0000000181E20FC0
		public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x0000000181E20F30-0x0000000181E20F60
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer); // 0x0000000181E210B0-0x0000000181E210E0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer); // 0x0000000181E210E0-0x0000000181E21110
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer); // 0x0000000181E21020-0x0000000181E21050
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer); // 0x0000000181E21080-0x0000000181E210B0
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBufferHandle bufferHandle); // 0x0000000181E20FF0-0x0000000181E21020
		public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle); // 0x0000000181E21050-0x0000000181E21080
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size); // 0x0000000181E211A0-0x0000000181E211D0
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size); // 0x0000000181E21140-0x0000000181E21170
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size); // 0x0000000181E21170-0x0000000181E211A0
		public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size); // 0x0000000181E21110-0x0000000181E21140
		public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, string name, TextureHandle rt); // 0x0000000181E21490-0x0000000181E21560
		public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, TextureHandle rt); // 0x0000000181E21560-0x0000000181E21630
		public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, string name, float val); // 0x0000000181E211D0-0x0000000181E21200
		public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val); // 0x0000000181E21200-0x0000000181E21230
		public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, string name, params float[] values); // 0x0000000181E21230-0x0000000181E21260
		public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, params float[] values); // 0x0000000181E21260-0x0000000181E21290
		public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val); // 0x0000000181E21290-0x0000000181E212C0
		public void SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val); // 0x0000000181E212C0-0x0000000181E212F0
		public void SetRayTracingIntParams(RayTracingShader rayTracingShader, string name, params int[] values); // 0x0000000181E21320-0x0000000181E21350
		public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, params int[] values); // 0x0000000181E212F0-0x0000000181E21320
		public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val); // 0x0000000181E216D0-0x0000000181E21710
		public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val); // 0x0000000181E21690-0x0000000181E216D0
		public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, params Vector4[] values); // 0x0000000181E21630-0x0000000181E21660
		public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, params Vector4[] values); // 0x0000000181E21660-0x0000000181E21690
		public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val); // 0x0000000181E21410-0x0000000181E21470
		public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val); // 0x0000000181E213B0-0x0000000181E21410
		public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, params Matrix4x4[] values); // 0x0000000181E21350-0x0000000181E21380
		public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, params Matrix4x4[] values); // 0x0000000181E21380-0x0000000181E213B0
		public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth, Camera camera); // 0x0000000181E1F740-0x0000000181E1F770
		public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, GraphicsBuffer argsBuffer, uint argsOffset, Camera camera); // 0x0000000181E1F770-0x0000000181E1F7A0
		public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x0000000181E1F580-0x0000000181E1F5B0
		public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes); // 0x0000000181E1F5B0-0x0000000181E1F5E0
		public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x0000000181E1F5E0-0x0000000181E1F610
		public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes); // 0x0000000181E1F550-0x0000000181E1F580
		public void SetGlobalFloat(string name, float value); // 0x0000000181E208B0-0x0000000181E208D0
		public void SetGlobalInt(string name, int value); // 0x0000000181E208F0-0x0000000181E20910
		public void SetGlobalInteger(string name, int value); // 0x0000000181E20910-0x0000000181E20930
		public void SetGlobalVector(string name, Vector4 value); // 0x0000000181E20E40-0x0000000181E20E70
		public void SetGlobalColor(string name, Color value); // 0x0000000181E20700-0x0000000181E20730
		public void SetGlobalMatrix(string name, Matrix4x4 value); // 0x0000000181E20A20-0x0000000181E20A70
		public void SetGlobalFloatArray(string propertyName, List<float> values); // 0x0000000181E20870-0x0000000181E20890
		public void SetGlobalFloatArray(int nameID, List<float> values); // 0x0000000181E20830-0x0000000181E20850
		public void SetGlobalFloatArray(string propertyName, float[] values); // 0x0000000181E20810-0x0000000181E20830
		public void SetGlobalVectorArray(string propertyName, List<Vector4> values); // 0x0000000181E20D90-0x0000000181E20DB0
		public void SetGlobalVectorArray(int nameID, List<Vector4> values); // 0x0000000181E20DF0-0x0000000181E20E10
		public void SetGlobalVectorArray(string propertyName, Vector4[] values); // 0x0000000181E20DB0-0x0000000181E20DD0
		public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values); // 0x0000000181E20950-0x0000000181E20970
		public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values); // 0x0000000181E209B0-0x0000000181E209D0
		public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values); // 0x0000000181E20970-0x0000000181E20990
		public void SetGlobalTexture(string name, TextureHandle value); // 0x0000000181E20B40-0x0000000181E20C00
		public void SetGlobalTexture(int nameID, TextureHandle value); // 0x0000000181E20CD0-0x0000000181E20D90
		public void SetGlobalTexture(string name, TextureHandle value, RenderTextureSubElement element); // 0x0000000181E20A70-0x0000000181E20B40
		public void SetGlobalTexture(int nameID, TextureHandle value, RenderTextureSubElement element); // 0x0000000181E20C00-0x0000000181E20CD0
		public void SetGlobalBuffer(string name, ComputeBuffer value); // 0x0000000181E20670-0x0000000181E20690
		public void SetGlobalBuffer(int nameID, ComputeBuffer value); // 0x0000000181E20650-0x0000000181E20670
		public void SetGlobalBuffer(string name, GraphicsBuffer value); // 0x0000000181E206B0-0x0000000181E206D0
		public void SetGlobalBuffer(int nameID, GraphicsBuffer value); // 0x0000000181E20690-0x0000000181E206B0
		public void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size); // 0x0000000181E207C0-0x0000000181E207F0
		public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size); // 0x0000000181E20760-0x0000000181E20790
		public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size); // 0x0000000181E20730-0x0000000181E20760
		public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size); // 0x0000000181E20790-0x0000000181E207C0
		public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode); // 0x0000000181E21710-0x0000000181E21760
		public void SetSinglePassStereo(SinglePassStereoMode mode); // 0x0000000181E21760-0x0000000181E21780
		public void IssuePluginEvent(IntPtr callback, int eventID); // 0x0000000181E1FA00-0x0000000181E1FA20
		public void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data); // 0x0000000181E1F9D0-0x0000000181E1FA00
		public void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags); // 0x0000000181E1F900-0x0000000181E1F9A0
		public void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData); // 0x0000000181E1F9A0-0x0000000181E1F9D0
		void IBaseCommandBuffer.EnableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x0000000181E1F7A0-0x0000000181E1F7C0
		void IBaseCommandBuffer.EnableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F7E0-0x0000000181E1F800
		void IBaseCommandBuffer.EnableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F7C0-0x0000000181E1F7E0
		void IBaseCommandBuffer.DisableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x0000000181E1F610-0x0000000181E1F630
		void IBaseCommandBuffer.DisableKeyword(Material material, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F650-0x0000000181E1F670
		void IBaseCommandBuffer.DisableKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword); // 0x0000000181E1F630-0x0000000181E1F650
		void IBaseCommandBuffer.SetKeyword([IsReadOnly] in GlobalKeyword keyword, bool value); // 0x0000000181E20E90-0x0000000181E20EB0
		void IBaseCommandBuffer.SetKeyword(Material material, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000181E20EE0-0x0000000181E20F10
		void IBaseCommandBuffer.SetKeyword(ComputeShader computeShader, [IsReadOnly] in LocalKeyword keyword, bool value); // 0x0000000181E20EB0-0x0000000181E20EE0
	}
}
