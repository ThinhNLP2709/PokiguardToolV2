namespace UnityEngine.U2D;

[Extension]
[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
public static class SpriteDataAccessExtensions
{

	private static void CheckAttributeTypeMatchesAndThrow(VertexAttribute channel) { }

	private static SpriteChannelInfo GetBindPoseInfo(Sprite sprite) { }

	private static void GetBindPoseInfo_Injected(IntPtr sprite, out SpriteChannelInfo ret) { }

	[Extension]
	public static NativeArray<Matrix4x4> GetBindPoses(Sprite sprite) { }

	private static SpriteBone[] GetBoneInfo(Sprite sprite) { }

	private static SpriteBone[] GetBoneInfo_Injected(IntPtr sprite) { }

	[Extension]
	public static SpriteBone[] GetBones(Sprite sprite) { }

	private static SpriteChannelInfo GetChannelInfo(Sprite sprite, VertexAttribute channel) { }

	private static void GetChannelInfo_Injected(IntPtr sprite, VertexAttribute channel, out SpriteChannelInfo ret) { }

	[Extension]
	public static NativeArray<UInt16> GetIndices(Sprite sprite) { }

	private static SpriteChannelInfo GetIndicesInfo(Sprite sprite) { }

	private static void GetIndicesInfo_Injected(IntPtr sprite, out SpriteChannelInfo ret) { }

	internal static int GetPrimaryVertexStreamSize(Sprite sprite) { }

	private static int GetPrimaryVertexStreamSize_Injected(IntPtr sprite) { }

	[Extension]
	public static NativeSlice<T> GetVertexAttribute(Sprite sprite, VertexAttribute channel) { }

	[Extension]
	public static int GetVertexCount(Sprite sprite) { }

	private static int GetVertexCount_Injected(IntPtr sprite) { }

	[Extension]
	[NativeName("HasChannel")]
	public static bool HasVertexAttribute(Sprite sprite, VertexAttribute channel) { }

	private static bool HasVertexAttribute_Injected(IntPtr sprite, VertexAttribute channel) { }

}

