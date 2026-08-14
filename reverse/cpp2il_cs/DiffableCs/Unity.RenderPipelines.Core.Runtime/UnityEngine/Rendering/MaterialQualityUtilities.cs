namespace UnityEngine.Rendering;

[Extension]
[MovedFrom("Utilities")]
public static class MaterialQualityUtilities
{
	public static String[] KeywordNames; //Field offset: 0x0
	public static String[] EnumNames; //Field offset: 0x8
	public static ShaderKeyword[] Keywords; //Field offset: 0x10

	private static MaterialQualityUtilities() { }

	public static MaterialQuality FromIndex(int index) { }

	[Extension]
	public static MaterialQuality GetClosestQuality(MaterialQuality availableLevels, MaterialQuality requestedLevel) { }

	[Extension]
	public static MaterialQuality GetHighestQuality(MaterialQuality levels) { }

	[Extension]
	public static void SetGlobalShaderKeywords(MaterialQuality level) { }

	[Extension]
	public static void SetGlobalShaderKeywords(MaterialQuality level, CommandBuffer cmd) { }

	[Extension]
	public static int ToFirstIndex(MaterialQuality level) { }

}

