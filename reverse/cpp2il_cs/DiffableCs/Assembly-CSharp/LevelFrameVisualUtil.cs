//Type is in global namespace

public static class LevelFrameVisualUtil
{
	private const string FallbackPath = "Image/hclv/lv_0001"; //Field offset: 0x0
	private static readonly Color[] TierTextColors; //Field offset: 0x0

	private static LevelFrameVisualUtil() { }

	public static void ApplyToImage(Image img, int level, Text txtLv, Sprite spriteOverride = null) { }

	public static int ClampLevel(int level) { }

	public static Text FindLevelText(Transform frameRoot) { }

	public static int GetTierIndex(int level) { }

	public static Color GetTierTextColor(int level) { }

	public static Sprite LoadFrameSprite(int level) { }

}

