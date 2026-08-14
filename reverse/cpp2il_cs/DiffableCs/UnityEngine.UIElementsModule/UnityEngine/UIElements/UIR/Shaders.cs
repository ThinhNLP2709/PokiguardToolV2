namespace UnityEngine.UIElements.UIR;

internal static class Shaders
{
	public static readonly string k_AtlasBlit; //Field offset: 0x0
	public static readonly string k_Editor; //Field offset: 0x8
	public static readonly string k_Runtime; //Field offset: 0x10
	public static readonly string k_RuntimeWorld; //Field offset: 0x18
	public static readonly string k_ColorConversionBlit; //Field offset: 0x20
	public static readonly string k_ForceGammaKeyword; //Field offset: 0x28
	private static Material s_RuntimeMaterial; //Field offset: 0x30
	private static Material s_RuntimeWorldMaterial; //Field offset: 0x38
	private static Material s_EditorMaterial; //Field offset: 0x40
	private static int s_RefCount; //Field offset: 0x48

	public static Material editorMaterial
	{
		 get { } //Length: 87
	}

	public static Material runtimeMaterial
	{
		 get { } //Length: 87
	}

	public static Material runtimeWorldMaterial
	{
		 get { } //Length: 87
	}

	private static Shaders() { }

	public static void Acquire() { }

	public static Material get_editorMaterial() { }

	public static Material get_runtimeMaterial() { }

	public static Material get_runtimeWorldMaterial() { }

	private static Material GetOrCreateMaterial(ref Material material, string shaderName) { }

	public static void Release() { }

}

