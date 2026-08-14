namespace UnityEngine;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule"})]
internal static class UINumericFieldsUtils
{
	public static readonly string k_AllowedCharactersForFloat; //Field offset: 0x0
	public static readonly string k_AllowedCharactersForInt; //Field offset: 0x8
	public static readonly string k_DoubleFieldFormatString; //Field offset: 0x10
	public static readonly string k_FloatFieldFormatString; //Field offset: 0x18
	public static readonly string k_IntFieldFormatString; //Field offset: 0x20

	private static UINumericFieldsUtils() { }

	public static bool TryConvertStringToDouble(string str, out double value, out Expression expr) { }

	public static bool TryConvertStringToDouble(string str, string initialValueAsString, out double value) { }

	public static bool TryConvertStringToFloat(string str, string initialValueAsString, out float value) { }

	public static bool TryConvertStringToInt(string str, string initialValueAsString, out int value) { }

	public static bool TryConvertStringToLong(string str, out long value, out Expression expr) { }

	public static bool TryConvertStringToLong(string str, string initialValueAsString, out long value) { }

	public static bool TryConvertStringToUInt(string str, string initialValueAsString, out uint value) { }

	public static bool TryConvertStringToULong(string str, out ulong value, out Expression expr) { }

	public static bool TryConvertStringToULong(string str, string initialValueAsString, out ulong value) { }

}

