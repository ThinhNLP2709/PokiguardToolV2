//Type is in global namespace

public static class WeaponRarity
{
	public const string COMMON = "COMMON"; //Field offset: 0x0
	public const string RARE = "RARE"; //Field offset: 0x0
	public const string EPIC = "EPIC"; //Field offset: 0x0
	public const string LEGENDARY = "LEGENDARY"; //Field offset: 0x0
	private const string WEAPON_ICON_DIR = "Image/weapons/"; //Field offset: 0x0
	public const string UI_DIR = "Image/weaponUI/"; //Field offset: 0x0
	private static readonly Dictionary<Int32, Sprite> _iconCache; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _uiCache; //Field offset: 0x8
	private static readonly Color ColCommon; //Field offset: 0x10
	private static readonly Color ColRare; //Field offset: 0x20
	private static readonly Color ColEpic; //Field offset: 0x30
	private static readonly Color ColLegend; //Field offset: 0x40

	private static WeaponRarity() { }

	public static Color GetColor(string rarity) { }

	public static string GetElementLabel(string element) { }

	public static string GetLabel(string rarity) { }

	public static bool IsValidImageId(int imageId) { }

	public static Sprite LoadIcon(int imageId) { }

	public static Sprite LoadRarityCircle(string rarity) { }

	public static Sprite LoadUI(string fileName) { }

	private static string Normalize(string rarity) { }

	public static string StarText(int star) { }

}

