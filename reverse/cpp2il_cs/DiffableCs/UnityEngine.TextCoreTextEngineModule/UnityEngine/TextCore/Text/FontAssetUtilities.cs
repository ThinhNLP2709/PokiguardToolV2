namespace UnityEngine.TextCore.Text;

internal static class FontAssetUtilities
{
	private static HashSet<Int32> k_SearchedAssets; //Field offset: 0x0

	internal static Character GetCharacterFromFontAsset(uint unicode, FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures) { }

	private static Character GetCharacterFromFontAsset_Internal(uint unicode, FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures) { }

	internal static Character GetCharacterFromFontAssetsInternal(uint unicode, FontAsset sourceFontAsset, List<FontAsset> fontAssets, List<FontAsset> OSFallbackList, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures = true) { }

	private static Character GetCharacterFromFontAssetsInternal(uint unicode, List<FontAsset> fontAssets, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures = true) { }

	public static SpriteCharacter GetSpriteCharacterFromSpriteAsset(uint unicode, SpriteAsset spriteAsset, bool includeFallbacks) { }

	private static SpriteCharacter GetSpriteCharacterFromSpriteAsset_Internal(uint unicode, SpriteAsset spriteAsset, bool includeFallbacks) { }

	internal static TextElement GetTextElementFromTextAssets(uint unicode, FontAsset sourceFontAsset, List<TextAsset> textAssets, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures) { }

}

