namespace UnityEngine.U2D.Animation;

internal static class SpriteSkinHelpers
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string boneHash; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal bool <GetSpriteBonesTransforms>b__0(Bone x) { }

	}


	public static void CacheChildren(Transform current, Dictionary<Int32, List`1<TransformData>> cache) { }

	private static void CalculateBoneTransformsPath(int index, SpriteBone[] spriteBones, String[] paths) { }

	public static string GenerateTransformPath(Transform rootBone, Transform child) { }

	private static bool GetSpriteBonesTransformFromPath(SpriteBone[] spriteBones, Dictionary<Int32, List`1<TransformData>> hierarchyCache, Transform[] outNewBoneTransform) { }

	public static bool GetSpriteBonesTransforms(SpriteSkin spriteSkin, out Transform[] outTransform) { }

}

