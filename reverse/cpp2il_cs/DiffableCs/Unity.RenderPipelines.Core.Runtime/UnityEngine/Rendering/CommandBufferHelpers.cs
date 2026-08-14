namespace UnityEngine.Rendering;

public struct CommandBufferHelpers
{
	internal static RasterCommandBuffer rasterCmd; //Field offset: 0x0
	internal static ComputeCommandBuffer computeCmd; //Field offset: 0x8
	internal static UnsafeCommandBuffer unsafeCmd; //Field offset: 0x10

	private static CommandBufferHelpers() { }

	public static ComputeCommandBuffer GetComputeCommandBuffer(CommandBuffer baseBuffer) { }

	public static CommandBuffer GetNativeCommandBuffer(UnsafeCommandBuffer baseBuffer) { }

	public static RasterCommandBuffer GetRasterCommandBuffer(CommandBuffer baseBuffer) { }

	public static UnsafeCommandBuffer GetUnsafeCommandBuffer(CommandBuffer baseBuffer) { }

	public static void VFXManager_ProcessCameraCommand(Camera cam, UnsafeCommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results) { }

}

