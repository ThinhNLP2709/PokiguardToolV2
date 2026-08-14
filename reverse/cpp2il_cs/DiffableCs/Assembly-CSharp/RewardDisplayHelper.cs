//Type is in global namespace

public static class RewardDisplayHelper
{
	internal class Entry
	{
		public string type; //Field offset: 0x10
		public int amount; //Field offset: 0x18
		public long id; //Field offset: 0x20

		public Entry() { }

	}

	private const float NaturalSize = 84; //Field offset: 0x0
	private const float CenterOffsetY = 7.7; //Field offset: 0x0

	private static void Add(List<Entry> list, string type, int amount) { }

	public static List<Entry> BuildEntries(int gold, int ruby, int energy, int exp, int starWhite, int starBlue, int starRed, int wheel, int wheelDay, int eitem1, int eitem2, int eitem3, int eitem4, int crystal, long avt, long pet, long card, string stonesJson) { }

	public static string FormatAmount(int amount) { }

	public static GameObject GetPrefab(string type) { }

	public static void Render(Transform container, List<Entry> rewards, float cellSize = 84) { }

}

