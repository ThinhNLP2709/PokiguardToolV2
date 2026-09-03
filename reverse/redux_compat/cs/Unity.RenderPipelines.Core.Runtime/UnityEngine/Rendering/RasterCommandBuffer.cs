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
	public class RasterCommandBuffer : BaseCommandBuffer, IRasterCommandBuffer // TypeDefIndex: 5336
	{
		// Constructors
		internal RasterCommandBuffer(CommandBuffer wrapped, RenderGraphPass executingPass, bool isAsync); // 0x0000000181E21870-0x0000000181E21880
	
		// Methods
		public void SetInvertCulling(bool invertCulling); // 0x0000000181E20E70-0x0000000181E20E90
		public void SetViewport(Rect pixelRect); // 0x0000000181E21800-0x0000000181E21830
		public void EnableScissorRect(Rect scissor); // 0x0000000181E1F800-0x0000000181E1F830
		public void DisableScissorRect(); // 0x0000000181E1F670-0x0000000181E1F690
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor); // 0x0000000181E25DA0-0x0000000181E25DE0
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth); // 0x0000000181E25DE0-0x0000000181E25E20
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth, uint stencil); // 0x0000000181E25D50-0x0000000181E25DA0
		public void ClearRenderTarget(RTClearFlags clearFlags, Color backgroundColor, float depth, uint stencil); // 0x0000000181E25E20-0x0000000181E25E60
		public void ClearRenderTarget(RTClearFlags clearFlags, Color[] backgroundColors, float depth, uint stencil); // 0x0000000181E25E60-0x0000000181E25E90
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
		public void SetInstanceMultiplier(uint multiplier); // 0x0000000181E27010-0x0000000181E27030
		public void SetFoveatedRenderingMode(FoveatedRenderingMode foveatedRenderingMode); // 0x0000000181E26CD0-0x0000000181E26CF0
		public void SetWireframe(bool enable); // 0x0000000181E27070-0x0000000181E27090
		public void ConfigureFoveatedRendering(IntPtr platformData); // 0x0000000181E25E90-0x0000000181E25EB0
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
		public void SetupCameraProperties(Camera camera); // 0x0000000181E21830-0x0000000181E21850
		public void InvokeOnRenderObjectCallbacks(); // 0x0000000181E1F8E0-0x0000000181E1F900
		public void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize); // 0x0000000181E27050-0x0000000181E27070
		public void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000181E27030-0x0000000181E27050
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties); // 0x0000000181E261C0-0x0000000181E26240
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass); // 0x0000000181E26090-0x0000000181E26100
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex); // 0x0000000181E26100-0x0000000181E26160
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material); // 0x0000000181E26160-0x0000000181E261C0
		public void DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, int[] subsetIndices, int count, Material material, int shaderPass, MaterialPropertyBlock properties); // 0x0000000181E26240-0x0000000181E26270
		public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass); // 0x0000000181E26CA0-0x0000000181E26CD0
		public void DrawRenderer(Renderer renderer, Material material, int submeshIndex); // 0x0000000181E26C70-0x0000000181E26CA0
		public void DrawRenderer(Renderer renderer, Material material); // 0x0000000181E26C50-0x0000000181E26C70
		public void DrawRendererList(RendererList rendererList); // 0x0000000181E26C10-0x0000000181E26C50
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties); // 0x0000000181E26A90-0x0000000181E26B10
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount); // 0x0000000181E26B90-0x0000000181E26C10
		public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount); // 0x0000000181E26A20-0x0000000181E26A90
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties); // 0x0000000181E26900-0x0000000181E26990
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount); // 0x0000000181E26990-0x0000000181E26A20
		public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount); // 0x0000000181E26B10-0x0000000181E26B90
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E262A0-0x0000000181E26330
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset); // 0x0000000181E267F0-0x0000000181E26870
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs); // 0x0000000181E26440-0x0000000181E264B0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E26530-0x0000000181E265D0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset); // 0x0000000181E26760-0x0000000181E267F0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs); // 0x0000000181E264B0-0x0000000181E26530
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E26870-0x0000000181E26900
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x0000000181E266E0-0x0000000181E26760
		public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs); // 0x0000000181E26670-0x0000000181E266E0
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E265D0-0x0000000181E26670
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x0000000181E263B0-0x0000000181E26440
		public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs); // 0x0000000181E26330-0x0000000181E263B0
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties); // 0x0000000181E26060-0x0000000181E26090
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count); // 0x0000000181E26000-0x0000000181E26030
		public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices); // 0x0000000181E26030-0x0000000181E26060
		public void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties); // 0x0000000181E25FD0-0x0000000181E26000
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E25EB0-0x0000000181E25EE0
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset); // 0x0000000181E25EE0-0x0000000181E25F10
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs); // 0x0000000181E25F40-0x0000000181E25F70
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties); // 0x0000000181E25F10-0x0000000181E25F40
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset); // 0x0000000181E25FA0-0x0000000181E25FD0
		public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs); // 0x0000000181E25F70-0x0000000181E25FA0
		public void DrawOcclusionMesh(RectInt normalizedCamViewport); // 0x0000000181E26270-0x0000000181E262A0
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
		public void SetGlobalTexture(string name, TextureHandle value); // 0x0000000181E26CF0-0x0000000181E26DB0
		public void SetGlobalTexture(int nameID, TextureHandle value); // 0x0000000181E26E80-0x0000000181E26F40
		public void SetGlobalTexture(string name, TextureHandle value, RenderTextureSubElement element); // 0x0000000181E26DB0-0x0000000181E26E80
		public void SetGlobalTexture(int nameID, TextureHandle value, RenderTextureSubElement element); // 0x0000000181E26F40-0x0000000181E27010
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
