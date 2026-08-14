//Type is in global namespace

public static class PetStarUtil
{
	private const string PET_ICON_DIR = "Image/IconsPet/"; //Field offset: 0x0
	public static readonly Color ColorStarOn; //Field offset: 0x0
	public const float PIECE_ALPHA = 0.55; //Field offset: 0x0
	public const float STAR_OFF_SCALE = 0.82; //Field offset: 0x0
	public const string UI_DIR = "Image/petStarUI/"; //Field offset: 0x0
	public const string PIECE_SPRITE = "Image/piece/pet_piece"; //Field offset: 0x0
	public const string SHARED_UI_DIR = "Image/weaponUI/"; //Field offset: 0x0
	public static readonly Color ColorStarOff; //Field offset: 0x10
	public static readonly Color ColorHp; //Field offset: 0x20
	public static readonly Color ColorAtk; //Field offset: 0x30
	public static readonly Color ColorMana; //Field offset: 0x40
	public static readonly Color ColorGain; //Field offset: 0x50
	public static readonly Color ColorMuted; //Field offset: 0x60
	public static readonly Color ColorShard; //Field offset: 0x70
	private static readonly Dictionary<Int64, Sprite> _petCache; //Field offset: 0x80
	private static readonly Dictionary<String, Sprite> _uiCache; //Field offset: 0x88
	private static Sprite _pieceSprite; //Field offset: 0x90
	private static bool _pieceLoaded; //Field offset: 0x98

	private static PetStarUtil() { }

	public static void ApplyPieceOverlay(GameObject item, Image mainImg, bool showPiece) { }

	public static void ApplyShardVisual(Image imgPet, Image imgPiece, long petId) { }

	public static Image EnsurePieceOverlay(GameObject item, Image mainImg) { }

	public static string GetElementLabel(string element) { }

	public static string Hex(Color c) { }

	public static Sprite LoadPetIcon(long petId) { }

	public static Sprite LoadPieceOverlay() { }

	public static Sprite LoadUI(string fileName) { }

	public static void PaintStarRow(Transform row, int star, int maxStar = 6) { }

	public static string StarText(int star) { }

}

