namespace Unity.VisualScripting.FullSerializer;

public static class fsJsonPrinter
{

	private static void BuildCompressedString(fsData data, TextWriter stream) { }

	private static void BuildPrettyString(fsData data, TextWriter stream, int depth) { }

	public static void CompressedJson(fsData data, StreamWriter outputStream) { }

	public static string CompressedJson(fsData data) { }

	private static string ConvertDoubleToString(double d) { }

	private static string EscapeString(string str) { }

	private static void InsertSpacing(TextWriter stream, int count) { }

	public static void PrettyJson(fsData data, TextWriter outputStream) { }

	public static string PrettyJson(fsData data) { }

}

