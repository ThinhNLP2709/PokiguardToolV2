namespace UnityEngine.TextCore.Text;

[Nullable(0)]
[NullableContext(1)]
internal class FontAssetFactory
{
	private static readonly HashSet<FontAsset> visitedFontAssets; //Field offset: 0x0
	private static readonly string k_SystemFontName; //Field offset: 0x8

	private static FontAssetFactory() { }

	internal static FontAsset CreateDefaultEditorFontAsset(Font font, Shader shader) { }

	public static void SetHideFlags(FontAsset fontAsset) { }

	private static void SetupFontAssetSettings(FontAsset fontAsset, Shader shader) { }

}

