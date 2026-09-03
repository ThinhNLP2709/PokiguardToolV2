/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal static class NumberHelpers // TypeDefIndex: 6616
	{
		// Methods
		public static bool Approximately(double a, double b); // 0x0000000181CFB490-0x0000000181CFB530
		public static float IntToNormalizedFloat(int value, int minValue, int maxValue); // 0x0000000181CFB530-0x0000000181CFB580
		public static int NormalizedFloatToInt(float value, int intMinValue, int intMaxValue); // 0x0000000181CFB580-0x0000000181CFB5D0
		public static float UIntToNormalizedFloat(uint value, uint minValue, uint maxValue); // 0x0000000181CF8130-0x0000000181CF8180
		public static uint NormalizedFloatToUInt(float value, uint uintMinValue, uint uintMaxValue); // 0x0000000181CF80D0-0x0000000181CF8130
		public static uint RemapUIntBitsToNormalizeFloatToUIntBits(uint value, uint inBitSize, uint outBitSize); // 0x0000000181CFB5D0-0x0000000181CFB660
	
		// Extension methods
		public static int AlignToMultipleOf(this int number, int alignment); // 0x0000000181CFB430-0x0000000181CFB450
		public static long AlignToMultipleOf(this long number, long alignment); // 0x0000000181CFB470-0x0000000181CFB490
		public static uint AlignToMultipleOf(this uint number, uint alignment); // 0x0000000181CFB450-0x0000000181CFB470
	}
}
