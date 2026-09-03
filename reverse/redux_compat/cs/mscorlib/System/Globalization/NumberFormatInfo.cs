/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public sealed class NumberFormatInfo : ICloneable, IFormatProvider // TypeDefIndex: 3433
	{
		// Fields
		private static NumberFormatInfo invariantInfo; // 0x00
		internal int[] numberGroupSizes; // 0x10
		internal int[] currencyGroupSizes; // 0x18
		internal int[] percentGroupSizes; // 0x20
		internal string positiveSign; // 0x28
		internal string negativeSign; // 0x30
		internal string numberDecimalSeparator; // 0x38
		internal string numberGroupSeparator; // 0x40
		internal string currencyGroupSeparator; // 0x48
		internal string currencyDecimalSeparator; // 0x50
		internal string currencySymbol; // 0x58
		internal string ansiCurrencySymbol; // 0x60
		internal string nanSymbol; // 0x68
		internal string positiveInfinitySymbol; // 0x70
		internal string negativeInfinitySymbol; // 0x78
		internal string percentDecimalSeparator; // 0x80
		internal string percentGroupSeparator; // 0x88
		internal string percentSymbol; // 0x90
		internal string perMilleSymbol; // 0x98
		[OptionalField(VersionAdded = 2)]
		internal string[] nativeDigits; // 0xA0
		[OptionalField(VersionAdded = 1)]
		internal int m_dataItem; // 0xA8
		internal int numberDecimalDigits; // 0xAC
		internal int currencyDecimalDigits; // 0xB0
		internal int currencyPositivePattern; // 0xB4
		internal int currencyNegativePattern; // 0xB8
		internal int numberNegativePattern; // 0xBC
		internal int percentPositivePattern; // 0xC0
		internal int percentNegativePattern; // 0xC4
		internal int percentDecimalDigits; // 0xC8
		[OptionalField(VersionAdded = 2)]
		internal int digitSubstitution; // 0xCC
		internal bool isReadOnly; // 0xD0
		[OptionalField(VersionAdded = 1)]
		internal bool m_useUserOverride; // 0xD1
		[OptionalField(VersionAdded = 2)]
		internal bool m_isInvariant; // 0xD2
		[OptionalField(VersionAdded = 1)]
		internal bool validForParseAsNumber; // 0xD3
		[OptionalField(VersionAdded = 1)]
		internal bool validForParseAsCurrency; // 0xD4
		private const NumberStyles InvalidNumberStyles = NumberStyles.None; // Metadata: 0x0064EFEF
	
		// Properties
		public static NumberFormatInfo InvariantInfo { get; } // 0x000000018158AE50-0x000000018158AF70 
		public int CurrencyDecimalDigits { get; } // 0x000000018158ACB0-0x000000018158ACC0 
		public string CurrencyDecimalSeparator { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public bool IsReadOnly { get; } // 0x000000018158AF70-0x000000018158AF80 
		public int[] CurrencyGroupSizes { get; } // 0x000000018158ACC0-0x000000018158AD40 
		public int[] NumberGroupSizes { get; } // 0x000000018158AF90-0x000000018158B010 
		public int[] PercentGroupSizes { get; } // 0x000000018158B030-0x000000018158B0B0 
		public string CurrencyGroupSeparator { get; } // 0x00000001803272B0-0x00000001803272C0 
		public string CurrencySymbol { get; } // 0x00000001802F4000-0x00000001802F4010 
		public static NumberFormatInfo CurrentInfo { get; } // 0x000000018158AD50-0x000000018158AE50 
		public string NaNSymbol { get; set; } // 0x0000000180316960-0x0000000180316970 0x000000018158B0B0-0x000000018158B1A0
		public int CurrencyNegativePattern { get; } // 0x00000001806342B0-0x00000001806342C0 
		public int NumberNegativePattern { get; } // 0x000000018158B010-0x000000018158B020 
		public int PercentPositivePattern { get; } // 0x0000000181239340-0x0000000181239350 
		public int PercentNegativePattern { get; } // 0x0000000180CC3970-0x0000000180CC3980 
		public string NegativeInfinitySymbol { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public string NegativeSign { get; } // 0x000000018031E110-0x000000018031E120 
		public int NumberDecimalDigits { get; } // 0x000000018158AF80-0x000000018158AF90 
		public string NumberDecimalSeparator { get; } // 0x00000001803272A0-0x00000001803272B0 
		public string NumberGroupSeparator { get; } // 0x0000000180377940-0x0000000180377950 
		public int CurrencyPositivePattern { get; } // 0x000000018158AD40-0x000000018158AD50 
		public string PositiveInfinitySymbol { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		public string PositiveSign { get; } // 0x000000018033D240-0x000000018033D250 
		public int PercentDecimalDigits { get; } // 0x000000018158B020-0x000000018158B030 
		public string PercentDecimalSeparator { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public string PercentGroupSeparator { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public string PercentSymbol { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public string PerMilleSymbol { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public NumberFormatInfo(); // 0x000000018158A6D0-0x000000018158A6E0
		internal NumberFormatInfo(CultureData cultureData); // 0x000000018158A6E0-0x000000018158ACB0
	
		// Methods
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx); // 0x000000018158A320-0x000000018158A3B0
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x00000001802E76C0-0x00000001802E76D0
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x00000001802E76C0-0x00000001802E76D0
		private void VerifyWritable(); // 0x000000018158A650-0x000000018158A6D0
		public static NumberFormatInfo GetInstance(IFormatProvider formatProvider); // 0x000000018158A090-0x000000018158A320
		public object Clone(); // 0x0000000181589FB0-0x000000018158A020
		public object GetFormat(Type formatType); // 0x000000018158A020-0x000000018158A090
		public static NumberFormatInfo ReadOnly(NumberFormatInfo nfi); // 0x000000018158A3B0-0x000000018158A480
		internal static void ValidateParseStyleInteger(NumberStyles style); // 0x000000018158A560-0x000000018158A650
		internal static void ValidateParseStyleFloatingPoint(NumberStyles style); // 0x000000018158A480-0x000000018158A560
	}
}
