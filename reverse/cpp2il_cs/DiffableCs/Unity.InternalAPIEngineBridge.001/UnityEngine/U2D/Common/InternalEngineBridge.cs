namespace UnityEngine.U2D.Common;

internal static class InternalEngineBridge
{

	public static int ConvertFloatToInt(float f) { }

	public static float ConvertIntToFloat(int i) { }

	public static Rect GetGUIClipTopMostRect() { }

	public static Rect GetGUIClipTopRect() { }

	public static Rect GetGUIClipVisibleRect() { }

	public static Vector2 GUIUnclip(Vector2 v) { }

	public static bool IsGPUSkinningEnabled() { }

	public static bool IsUsingDeformableBuffer(SpriteRenderer spriteRenderer, IntPtr buffer) { }

	public static void SetBatchBoneTransformsAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<Int32> bufferSizes, NativeArray<Bounds> bounds) { }

	public static void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<Int32> bufferSizes, NativeArray<Bounds> bounds) { }

	public static void SetBoneTransforms(SpriteRenderer spriteRenderer, NativeArray<Matrix4x4> src) { }

	public static void SetDeformableBuffer(SpriteRenderer spriteRenderer, NativeArray<Byte> src) { }

	public static void SetLocalAABB(SpriteRenderer spriteRenderer, Bounds aabb) { }

	public static void SetupMaterialProperties(SpriteRenderer spriteRenderer) { }

}

