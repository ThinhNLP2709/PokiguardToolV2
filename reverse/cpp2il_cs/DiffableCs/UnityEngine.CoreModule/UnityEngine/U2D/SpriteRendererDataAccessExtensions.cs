namespace UnityEngine.U2D;

[Extension]
[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
[NativeHeader("Runtime/Graphics/Mesh/SpriteRenderer.h")]
public static class SpriteRendererDataAccessExtensions
{

	[Extension]
	public static void DeactivateDeformableBuffer(SpriteRenderer renderer) { }

	private static void DeactivateDeformableBuffer_Injected(IntPtr renderer) { }

	internal static bool IsGPUSkinningEnabled() { }

	private static bool IsUsingDeformableBuffer(SpriteRenderer spriteRenderer, Void* buffer) { }

	[Extension]
	internal static bool IsUsingDeformableBuffer(SpriteRenderer spriteRenderer, IntPtr buffer) { }

	private static bool IsUsingDeformableBuffer_Injected(IntPtr spriteRenderer, Void* buffer) { }

	internal static void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<Int32> bufferSizes, NativeArray<Bounds> bounds) { }

	private static void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, Void* buffers, Void* bufferSizes, Void* bounds, int count) { }

	[Extension]
	internal static void SetBoneTransforms(SpriteRenderer spriteRenderer, NativeArray<Matrix4x4> src) { }

	private static void SetBoneTransforms(SpriteRenderer spriteRenderer, Void* src, int count) { }

	private static void SetBoneTransforms_Injected(IntPtr spriteRenderer, Void* src, int count) { }

	internal static void SetBoneTransformsArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<Int32> bufferSizes, NativeArray<Bounds> bounds) { }

	private static void SetBoneTransformsArray(SpriteRenderer[] spriteRenderers, Void* buffers, Void* bufferSizes, Void* bounds, int count) { }

	[Extension]
	internal static void SetDeformableBuffer(SpriteRenderer spriteRenderer, NativeArray<Byte> src) { }

	private static void SetDeformableBuffer(SpriteRenderer spriteRenderer, Void* src, int count) { }

	private static void SetDeformableBuffer_Injected(IntPtr spriteRenderer, Void* src, int count) { }

	[Extension]
	internal static void SetLocalAABB(SpriteRenderer renderer, Bounds aabb) { }

	private static void SetLocalAABB_Injected(IntPtr renderer, in Bounds aabb) { }

	internal static void SetupMaterialProperties(SpriteRenderer spriteRenderer) { }

	private static void SetupMaterialProperties_Injected(IntPtr spriteRenderer) { }

}

