namespace UnityEngine.UIElements;

[Extension]
internal static class TextUtilities
{

	internal static FontAsset GetFontAsset(VisualElement ve) { }

	internal static TextCoreSettings GetTextCoreSettingsForElement(VisualElement ve, bool ignoreColors) { }

	internal static TextSettings GetTextSettingsFrom(VisualElement ve) { }

	internal static bool IsAdvancedTextEnabledForElement(TextElement te) { }

	internal static bool IsFontAssigned(VisualElement ve) { }

	internal static Vector2 MeasureVisualElementTextSize(TextElement te, in RenderedText textToMeasure, float width, MeasureMode widthMode, float height, MeasureMode heightMode) { }

	[Extension]
	public static WhiteSpace toTextCore(WhiteSpace whiteSpace) { }

	[Extension]
	public static TextOverflow toTextCore(TextOverflow textOverflow, OverflowInternal overflow) { }

	[Extension]
	public static TextWrappingMode toTextWrappingMode(WhiteSpace whiteSpace) { }

}

