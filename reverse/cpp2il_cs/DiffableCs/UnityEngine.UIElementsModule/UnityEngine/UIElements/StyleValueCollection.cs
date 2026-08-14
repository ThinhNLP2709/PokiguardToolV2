namespace UnityEngine.UIElements;

internal class StyleValueCollection
{
	internal List<StyleValue> m_Values; //Field offset: 0x10

	public StyleValueCollection() { }

	public StyleBackground GetStyleBackground(StylePropertyId id) { }

	public StyleBackgroundPosition GetStyleBackgroundPosition(StylePropertyId id) { }

	public StyleBackgroundRepeat GetStyleBackgroundRepeat(StylePropertyId id) { }

	public StyleColor GetStyleColor(StylePropertyId id) { }

	public StyleFloat GetStyleFloat(StylePropertyId id) { }

	public StyleFont GetStyleFont(StylePropertyId id) { }

	public StyleFontDefinition GetStyleFontDefinition(StylePropertyId id) { }

	public StyleInt GetStyleInt(StylePropertyId id) { }

	public StyleLength GetStyleLength(StylePropertyId id) { }

	public void SetStyleValue(StyleValue value) { }

	public bool TryGetStyleValue(StylePropertyId id, ref StyleValue value) { }

}

