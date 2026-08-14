namespace UnityEngine.UIElements.StyleSheets;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal struct SelectorMatchRecord
{
	public StyleSheet sheet; //Field offset: 0x0
	public int styleSheetIndexInStack; //Field offset: 0x8
	public StyleComplexSelector complexSelector; //Field offset: 0x10

	public SelectorMatchRecord(StyleSheet sheet, int styleSheetIndexInStack) { }

	public static int Compare(SelectorMatchRecord a, SelectorMatchRecord b) { }

}

