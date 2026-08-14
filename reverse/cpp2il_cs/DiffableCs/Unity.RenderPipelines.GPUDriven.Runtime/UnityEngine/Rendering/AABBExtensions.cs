namespace UnityEngine.Rendering;

[Extension]
internal static class AABBExtensions
{

	[Extension]
	public static AABB ToAABB(Bounds bounds) { }

	[Extension]
	public static Bounds ToBounds(AABB aabb) { }

}

