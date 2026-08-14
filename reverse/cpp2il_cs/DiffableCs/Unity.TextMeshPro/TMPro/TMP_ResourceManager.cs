namespace TMPro;

public class TMP_ResourceManager
{
	private struct FontAssetRef
	{
		public int nameHashCode; //Field offset: 0x0
		public int familyNameHashCode; //Field offset: 0x4
		public int styleNameHashCode; //Field offset: 0x8
		public long familyNameAndStyleHashCode; //Field offset: 0x10
		public readonly TMP_FontAsset fontAsset; //Field offset: 0x18

		public FontAssetRef(int nameHashCode, int familyNameHashCode, int styleNameHashCode, TMP_FontAsset fontAsset) { }

	}

	private static TMP_Settings s_TextSettings; //Field offset: 0x0
	private static readonly Dictionary<Int32, FontAssetRef> s_FontAssetReferences; //Field offset: 0x8
	private static readonly Dictionary<Int32, TMP_FontAsset> s_FontAssetNameReferenceLookup; //Field offset: 0x10
	private static readonly Dictionary<Int64, TMP_FontAsset> s_FontAssetFamilyNameAndStyleReferenceLookup; //Field offset: 0x18
	private static readonly List<Int32> s_FontAssetRemovalList; //Field offset: 0x20
	private static readonly int k_RegularStyleHashCode; //Field offset: 0x28

	private static TMP_ResourceManager() { }

	public TMP_ResourceManager() { }

	public static void AddFontAsset(TMP_FontAsset fontAsset) { }

	public static void ClearFontAssetGlyphCache() { }

	internal static TMP_Settings GetTextSettings() { }

	internal static void RebuildFontAssetCache() { }

	public static void RemoveFontAsset(TMP_FontAsset fontAsset) { }

	internal static bool TryGetFontAssetByFamilyName(int familyNameHashCode, int styleNameHashCode, out TMP_FontAsset fontAsset) { }

	internal static bool TryGetFontAssetByName(int nameHashcode, out TMP_FontAsset fontAsset) { }

}

