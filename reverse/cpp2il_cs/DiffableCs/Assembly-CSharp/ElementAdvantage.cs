//Type is in global namespace

public static class ElementAdvantage
{
	public const int ADVANTAGE_PCT = 50; //Field offset: 0x0
	public const int DISADVANTAGE_PCT = -25; //Field offset: 0x0

	private static bool Beats(string att, string def) { }

	public static string Label(int level, int pct) { }

	public static string Normalize(string element) { }

	public static int Pct(string attackerElement, string defenderElement) { }

	public static int PctFromMultiplier(double multiplier) { }

}

