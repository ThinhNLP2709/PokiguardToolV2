namespace UnityEngine.U2D.Animation;

[Extension]
internal static class SpriteSkinUtility
{

	[Extension]
	internal static void Bake(SpriteSkin spriteSkin, NativeArray<Byte> deformVertexData) { }

	[Extension]
	internal static void CalculateBounds(SpriteSkin spriteSkin) { }

	internal static Bounds CalculateSpriteSkinBounds(NativeSlice<float3> deformablePositions) { }

	[Extension]
	internal static int CalculateTransformHash(SpriteSkin spriteSkin) { }

	internal static bool CanSpriteSkinUseGpuDeformation(SpriteSkin spriteSkin) { }

	internal static bool CanUseGpuDeformation() { }

	[Extension]
	internal static void CreateBoneHierarchy(SpriteSkin spriteSkin) { }

	private static void CreateGameObject(int index, SpriteBone[] spriteBones, Transform[] transforms, Transform root) { }

	internal static void Deform(Sprite sprite, Matrix4x4 invRoot, Transform[] boneTransformsArray, NativeArray<Byte> deformVertexData) { }

	internal static void Deform(float4x4 rootInv, NativeSlice<float3> vertices, NativeSlice<float4> tangents, NativeSlice<BoneWeight> boneWeights, NativeArray<float4x4> boneTransforms, NativeSlice<float4x4> bindPoses, NativeSlice<float3> deformed, NativeSlice<float4> deformedTangents) { }

	internal static void Deform(Sprite sprite, Matrix4x4 rootInv, NativeSlice<Vector3> vertices, NativeSlice<Vector4> tangents, NativeSlice<BoneWeight> boneWeights, NativeArray<Matrix4x4> boneTransforms, NativeSlice<Matrix4x4> bindPoses, NativeArray<Byte> deformableVertices) { }

	internal static void Deform(float4x4 rootInv, NativeSlice<float3> vertices, NativeSlice<BoneWeight> boneWeights, NativeArray<float4x4> boneTransforms, NativeSlice<float4x4> bindPoses, NativeSlice<float3> deformed) { }

	private static int GetHash(Matrix4x4 matrix) { }

	[Extension]
	internal static int GetVertexStreamOffset(Sprite sprite, VertexAttribute channel) { }

	[Extension]
	internal static int GetVertexStreamSize(Sprite sprite) { }

	internal static bool IsUsingGpuDeformation() { }

	[Extension]
	internal static void UpdateBounds(SpriteSkin spriteSkin, NativeArray<Byte> deformedVertices) { }

	[Extension]
	internal static SpriteSkinState Validate(SpriteSkin spriteSkin) { }

}

