namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class NumberHelpers
{

	[Extension]
	public static int AlignToMultipleOf(int number, int alignment) { }

	[Extension]
	public static long AlignToMultipleOf(long number, long alignment) { }

	[Extension]
	public static uint AlignToMultipleOf(uint number, uint alignment) { }

	public static bool Approximately(double a, double b) { }

	public static float IntToNormalizedFloat(int value, int minValue, int maxValue) { }

	public static int NormalizedFloatToInt(float value, int intMinValue, int intMaxValue) { }

	public static uint NormalizedFloatToUInt(float value, uint uintMinValue, uint uintMaxValue) { }

	public static uint RemapUIntBitsToNormalizeFloatToUIntBits(uint value, uint inBitSize, uint outBitSize) { }

	public static float UIntToNormalizedFloat(uint value, uint minValue, uint maxValue) { }

}

