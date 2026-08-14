namespace UnityEngine.Rendering;

[Extension]
internal static class SceneExtensions
{
	private static PropertyInfo s_SceneGUID; //Field offset: 0x0

	private static SceneExtensions() { }

	[Extension]
	public static string GetGUID(Scene scene) { }

}

