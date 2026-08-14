namespace UnityEngine.Rendering;

public interface IComputeCommandBuffer : IBaseCommandBuffer
{

	public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin) { }

	public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure) { }

	public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset) { }

	public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth, Camera camera) { }

	public void SetBufferCounterValue(GraphicsBuffer buffer, uint counterValue) { }

	public void SetBufferCounterValue(ComputeBuffer buffer, uint counterValue) { }

	public void SetBufferData(GraphicsBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, NativeArray<T> data) { }

	public void SetBufferData(GraphicsBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, Array data) { }

	public void SetBufferData(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(ComputeBuffer buffer, NativeArray<T> data) { }

	public void SetBufferData(ComputeBuffer buffer, List<T> data) { }

	public void SetBufferData(GraphicsBuffer buffer, List<T> data) { }

	public void SetBufferData(ComputeBuffer buffer, Array data) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBufferHandle bufferHandle) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, GraphicsBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size) { }

	public void SetComputeFloatParam(ComputeShader computeShader, int nameID, float val) { }

	public void SetComputeFloatParam(ComputeShader computeShader, string name, float val) { }

	public void SetComputeFloatParams(ComputeShader computeShader, int nameID, Single[] values) { }

	public void SetComputeFloatParams(ComputeShader computeShader, string name, Single[] values) { }

	public void SetComputeIntParam(ComputeShader computeShader, int nameID, int val) { }

	public void SetComputeIntParam(ComputeShader computeShader, string name, int val) { }

	public void SetComputeIntParams(ComputeShader computeShader, int nameID, Int32[] values) { }

	public void SetComputeIntParams(ComputeShader computeShader, string name, Int32[] values) { }

	public void SetComputeMatrixArrayParam(ComputeShader computeShader, int nameID, Matrix4x4[] values) { }

	public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values) { }

	public void SetComputeMatrixParam(ComputeShader computeShader, int nameID, Matrix4x4 val) { }

	public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt, int mipLevel) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt, int mipLevel, RenderTextureSubElement element) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, TextureHandle rt, int mipLevel, RenderTextureSubElement element) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, TextureHandle rt, int mipLevel) { }

	public void SetComputeVectorArrayParam(ComputeShader computeShader, string name, Vector4[] values) { }

	public void SetComputeVectorArrayParam(ComputeShader computeShader, int nameID, Vector4[] values) { }

	public void SetComputeVectorParam(ComputeShader computeShader, int nameID, Vector4 val) { }

	public void SetComputeVectorParam(ComputeShader computeShader, string name, Vector4 val) { }

	public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBufferHandle bufferHandle) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size) { }

	public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, string name, float val) { }

	public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val) { }

	public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, string name, Single[] values) { }

	public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, Single[] values) { }

	public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val) { }

	public void SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val) { }

	public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, Int32[] values) { }

	public void SetRayTracingIntParams(RayTracingShader rayTracingShader, string name, Int32[] values) { }

	public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, Matrix4x4[] values) { }

	public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4[] values) { }

	public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val) { }

	public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val) { }

	public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, TextureHandle rt) { }

	public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, string name, TextureHandle rt) { }

	public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, Vector4[] values) { }

	public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, Vector4[] values) { }

	public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val) { }

	public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val) { }

}

