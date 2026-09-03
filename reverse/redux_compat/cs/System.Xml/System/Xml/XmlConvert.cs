/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlConvert // TypeDefIndex: 6870
	{
		// Fields
		private static XmlCharType xmlCharType; // 0x00
		internal static char[] crt; // 0x08
		private static readonly int c_EncodedCharLength; // 0x10
		private static Regex c_EncodeCharPattern; // 0x18
		private static Regex c_DecodeCharPattern; // 0x20
		private static string[] s_allDateTimeFormats; // 0x28
		internal static readonly char[] WhitespaceChars; // 0x30
	
		// Properties
		private static string[] AllDateTimeFormats { get; } // 0x0000000181AA2210-0x0000000181AA2290 
	
		// Constructors
		static XmlConvert(); // 0x0000000181AA20E0-0x0000000181AA2210
	
		// Methods
		public static string EncodeName(string name); // 0x0000000181A9C510-0x0000000181A9C560
		public static string EncodeLocalName(string name); // 0x0000000181A9C4B0-0x0000000181A9C510
		public static string DecodeName(string name); // 0x0000000181A9BCE0-0x0000000181A9C4B0
		private static string EncodeName(string name, bool first, bool local); // 0x0000000181A9C560-0x0000000181A9CE00
		private static int FromHex(char digit); // 0x0000000181A9CF30-0x0000000181A9CF60
		internal static byte[] FromBinHexString(string s); // 0x0000000181A9CE00-0x0000000181A9CEB0
		internal static byte[] FromBinHexString(string s, bool allowOddCount); // 0x0000000181A9CEB0-0x0000000181A9CF30
		internal static string ToBinHexString(byte[] inArray); // 0x0000000181A9D250-0x0000000181A9D2C0
		public static string VerifyName(string name); // 0x0000000181AA1C80-0x0000000181AA1DF0
		internal static Exception TryVerifyName(string name); // 0x0000000181AA1320-0x0000000181AA14C0
		internal static string VerifyQName(string name, ExceptionType exceptionType); // 0x0000000181AA1DF0-0x0000000181AA1FB0
		public static string VerifyNCName(string name); // 0x0000000181AA1960-0x0000000181AA1B00
		internal static string VerifyNCName(string name, ExceptionType exceptionType); // 0x0000000181AA1B00-0x0000000181AA1C80
		internal static Exception TryVerifyNCName(string name); // 0x0000000181AA1040-0x0000000181AA10F0
		public static string VerifyTOKEN(string token); // 0x0000000181AA1FB0-0x0000000181AA20E0
		internal static Exception TryVerifyTOKEN(string token); // 0x0000000181AA1590-0x0000000181AA16B0
		internal static Exception TryVerifyNMTOKEN(string name); // 0x0000000181AA10F0-0x0000000181AA1320
		internal static Exception TryVerifyNormalizedString(string str); // 0x0000000181AA14C0-0x0000000181AA1590
		public static string ToString(bool value); // 0x0000000181A9E690-0x0000000181A9E6E0
		public static string ToString(char value); // 0x0000000181A9E340-0x0000000181A9E380
		public static string ToString(decimal value); // 0x0000000181A9E2D0-0x0000000181A9E340
		[CLSCompliant(false)]
		public static string ToString(sbyte value); // 0x0000000181A9E7E0-0x0000000181A9E810
		public static string ToString(short value); // 0x0000000181A9E230-0x0000000181A9E260
		public static string ToString(int value); // 0x0000000181A9E260-0x0000000181A9E290
		public static string ToString(long value); // 0x0000000181A9E810-0x0000000181A9E840
		public static string ToString(byte value); // 0x0000000181A9E2A0-0x0000000181A9E2D0
		[CLSCompliant(false)]
		public static string ToString(ushort value); // 0x0000000181A9E200-0x0000000181A9E230
		[CLSCompliant(false)]
		public static string ToString(uint value); // 0x0000000181A9E380-0x0000000181A9E3B0
		[CLSCompliant(false)]
		public static string ToString(ulong value); // 0x0000000181A9E420-0x0000000181A9E450
		public static string ToString(float value); // 0x0000000181A9E110-0x0000000181A9E200
		public static string ToString(double value); // 0x0000000181A9E010-0x0000000181A9E110
		public static string ToString(TimeSpan value); // 0x0000000181A9E6E0-0x0000000181A9E750
		public static string ToString(DateTime value, string format); // 0x0000000181A9E750-0x0000000181A9E7E0
		public static string ToString(DateTime value, XmlDateTimeSerializationMode dateTimeOption); // 0x0000000181A9E450-0x0000000181A9E690
		public static string ToString(DateTimeOffset value); // 0x0000000181A9E3B0-0x0000000181A9E420
		public static string ToString(Guid value); // 0x0000000181A9E290-0x0000000181A9E2A0
		public static bool ToBoolean(string s); // 0x0000000181A9D2C0-0x0000000181A9D4E0
		internal static Exception TryToBoolean(string s, out bool result); // 0x0000000181A9F0A0-0x0000000181A9F340
		public static char ToChar(string s); // 0x0000000181A9D510-0x0000000181A9D5E0
		internal static Exception TryToChar(string s, out char result); // 0x0000000181A9F4D0-0x0000000181A9F660
		public static decimal ToDecimal(string s); // 0x0000000181A9DB10-0x0000000181A9DBA0
		internal static Exception TryToDecimal(string s, out decimal result); // 0x0000000181A9F660-0x0000000181A9F820
		internal static decimal ToInteger(string s); // 0x0000000181A9DDD0-0x0000000181A9DE60
		internal static Exception TryToInteger(string s, out decimal result); // 0x0000000181AA01D0-0x0000000181AA0390
		[CLSCompliant(false)]
		public static sbyte ToSByte(string s); // 0x0000000181A9DE60-0x0000000181A9DE90
		internal static Exception TryToSByte(string s, out sbyte result); // 0x0000000181AA0390-0x0000000181AA0520
		public static short ToInt16(string s); // 0x0000000181A9DD40-0x0000000181A9DD70
		internal static Exception TryToInt16(string s, out short result); // 0x0000000181A9FD20-0x0000000181A9FEB0
		public static int ToInt32(string s); // 0x0000000181A9DD70-0x0000000181A9DDA0
		internal static Exception TryToInt32(string s, out int result); // 0x0000000181A9FEB0-0x0000000181AA0040
		public static long ToInt64(string s); // 0x0000000181A9DDA0-0x0000000181A9DDD0
		internal static Exception TryToInt64(string s, out long result); // 0x0000000181AA0040-0x0000000181AA01D0
		public static byte ToByte(string s); // 0x0000000181A9D4E0-0x0000000181A9D510
		internal static Exception TryToByte(string s, out byte result); // 0x0000000181A9F340-0x0000000181A9F4D0
		[CLSCompliant(false)]
		public static ushort ToUInt16(string s); // 0x0000000181A9E9A0-0x0000000181A9E9D0
		internal static Exception TryToUInt16(string s, out ushort result); // 0x0000000181AA0880-0x0000000181AA0A10
		[CLSCompliant(false)]
		public static uint ToUInt32(string s); // 0x0000000181A9E9D0-0x0000000181A9EA00
		internal static Exception TryToUInt32(string s, out uint result); // 0x0000000181AA0A10-0x0000000181AA0BA0
		[CLSCompliant(false)]
		public static ulong ToUInt64(string s); // 0x0000000181A9EA00-0x0000000181A9EA30
		internal static Exception TryToUInt64(string s, out ulong result); // 0x0000000181AA0BA0-0x0000000181AA0D30
		public static float ToSingle(string s); // 0x0000000181A9DE90-0x0000000181A9E010
		internal static Exception TryToSingle(string s, out float result); // 0x0000000181AA0520-0x0000000181AA07D0
		public static double ToDouble(string s); // 0x0000000181A9DBA0-0x0000000181A9DD20
		internal static Exception TryToDouble(string s, out double result); // 0x0000000181A9F820-0x0000000181A9FAF0
		internal static double ToXPathDouble(object o); // 0x0000000181A9ED20-0x0000000181A9EF50
		public static TimeSpan ToTimeSpan(string s); // 0x0000000181A9E840-0x0000000181A9E9A0
		internal static Exception TryToTimeSpan(string s, out TimeSpan result); // 0x0000000181AA07D0-0x0000000181AA0880
		private static void CreateAllDateTimeFormats(); // 0x0000000181A9A8D0-0x0000000181A9ADD0
		[Obsolete("Use XmlConvert.ToDateTime() that takes in XmlDateTimeSerializationMode")]
		public static DateTime ToDateTime(string s); // 0x0000000181A9D920-0x0000000181A9DA70
		public static DateTime ToDateTime(string s, string[] formats); // 0x0000000181A9DA70-0x0000000181A9DB10
		public static DateTime ToDateTime(string s, XmlDateTimeSerializationMode dateTimeOption); // 0x0000000181A9D6C0-0x0000000181A9D920
		public static DateTimeOffset ToDateTimeOffset(string s); // 0x0000000181A9D5E0-0x0000000181A9D6C0
		public static Guid ToGuid(string s); // 0x0000000181A9DD20-0x0000000181A9DD40
		internal static Exception TryToGuid(string s, out Guid result); // 0x0000000181A9FAF0-0x0000000181A9FD20
		private static DateTime SwitchToLocalTime(DateTime value); // 0x0000000181A9D0F0-0x0000000181A9D1A0
		private static DateTime SwitchToUtcTime(DateTime value); // 0x0000000181A9D1A0-0x0000000181A9D250
		internal static Uri ToUri(string s); // 0x0000000181A9EA30-0x0000000181A9ED20
		internal static Exception TryToUri(string s, out Uri result); // 0x0000000181AA0D30-0x0000000181AA1040
		internal static bool StrEqual(char[] chars, int strPos1, int strLen1, string str2); // 0x0000000181A9D040-0x0000000181A9D0F0
		internal static string TrimString(string value); // 0x0000000181A9F030-0x0000000181A9F0A0
		internal static string TrimStringStart(string value); // 0x0000000181A9EFC0-0x0000000181A9F030
		internal static string TrimStringEnd(string value); // 0x0000000181A9EF50-0x0000000181A9EFC0
		internal static string[] SplitString(string value); // 0x0000000181A9CFD0-0x0000000181A9D040
		internal static bool IsNegativeZero(double value); // 0x0000000181A9CF60-0x0000000181A9CFD0
		private static long DoubleToInt64Bits(double value); // 0x000000018155D7D0-0x000000018155D7E0
		internal static void VerifyCharData(string data, ExceptionType invCharExceptionType, ExceptionType invSurrogateExceptionType); // 0x0000000181AA16B0-0x0000000181AA1960
		internal static Exception CreateException(string res, ExceptionType exceptionType, int lineNo, int linePos); // 0x0000000181A9B000-0x0000000181A9B0D0
		internal static Exception CreateException(string res, string arg, ExceptionType exceptionType, int lineNo, int linePos); // 0x0000000181A9ADD0-0x0000000181A9AF20
		internal static Exception CreateException(string res, string[] args, ExceptionType exceptionType); // 0x0000000181A9B0D0-0x0000000181A9B150
		internal static Exception CreateException(string res, string[] args, ExceptionType exceptionType, int lineNo, int linePos); // 0x0000000181A9AF20-0x0000000181A9B000
		internal static Exception CreateInvalidSurrogatePairException(char low, char hi); // 0x0000000181A9BA50-0x0000000181A9BAF0
		internal static Exception CreateInvalidSurrogatePairException(char low, char hi, ExceptionType exceptionType); // 0x0000000181A9BAF0-0x0000000181A9BB70
		internal static Exception CreateInvalidSurrogatePairException(char low, char hi, ExceptionType exceptionType, int lineNo, int linePos); // 0x0000000181A9BB70-0x0000000181A9BCE0
		internal static Exception CreateInvalidHighSurrogateCharException(char hi); // 0x0000000181A9B830-0x0000000181A9B880
		internal static Exception CreateInvalidHighSurrogateCharException(char hi, ExceptionType exceptionType); // 0x0000000181A9B450-0x0000000181A9B650
		internal static Exception CreateInvalidHighSurrogateCharException(char hi, ExceptionType exceptionType, int lineNo, int linePos); // 0x0000000181A9B650-0x0000000181A9B830
		internal static Exception CreateInvalidCharException(string data, int invCharPos, ExceptionType exceptionType); // 0x0000000181A9B230-0x0000000181A9B310
		internal static Exception CreateInvalidCharException(char invChar, char nextChar); // 0x0000000181A9B310-0x0000000181A9B450
		internal static Exception CreateInvalidCharException(char invChar, char nextChar, ExceptionType exceptionType); // 0x0000000181A9B150-0x0000000181A9B230
		internal static Exception CreateInvalidNameCharException(string name, int index, ExceptionType exceptionType); // 0x0000000181A9B940-0x0000000181A9BA50
		internal static ArgumentException CreateInvalidNameArgumentException(string name, string argumentName); // 0x0000000181A9B880-0x0000000181A9B940
	}
}
