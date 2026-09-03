/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct Char : IComparable, IComparable<char>, IEquatable<char>, IConvertible // TypeDefIndex: 2225
	{
		// Fields
		private readonly char m_value; // 0x00
		private static readonly byte[] s_categoryForLatin1; // 0x00
	
		// Constructors
		static Char(); // 0x0000000181562300-0x00000001815623D0
	
		// Methods
		private static bool IsLatin1(char ch); // 0x0000000181560DB0-0x0000000181560DC0
		private static bool IsAscii(char ch); // 0x0000000181560B90-0x0000000181560BA0
		private static UnicodeCategory GetLatin1UnicodeCategory(char ch); // 0x0000000181560980-0x00000001815609E0
		public override int GetHashCode(); // 0x0000000181560970-0x0000000181560980
		public override bool Equals(object obj); // 0x0000000181560900-0x0000000181560960
		[NonVersionable]
		public bool Equals(char obj); // 0x0000000181560960-0x0000000181560970
		public int CompareTo(object value); // 0x0000000181560730-0x00000001815607E0
		public int CompareTo(char value); // 0x0000000181560720-0x0000000181560730
		public override string ToString(); // 0x0000000181562110-0x0000000181562140
		public string ToString(IFormatProvider provider); // 0x0000000181562110-0x0000000181562140
		public static string ToString(char c); // 0x0000000181562140-0x0000000181562150
		public static char Parse(string s); // 0x0000000181561830-0x00000001815618F0
		public static bool TryParse(string s, out char result); // 0x00000001815622D0-0x0000000181562300
		public static bool IsDigit(char c); // 0x0000000181560C30-0x0000000181560C90
		internal static bool CheckLetter(UnicodeCategory uc); // 0x00000001815606E0-0x00000001815606F0
		public static bool IsLetter(char c); // 0x0000000181560F90-0x0000000181561050
		private static bool IsWhiteSpaceLatin1(char c); // 0x0000000181561640-0x0000000181561670
		public static bool IsWhiteSpace(char c); // 0x0000000181561670-0x00000001815616E0
		public static bool IsUpper(char c); // 0x0000000181561590-0x0000000181561640
		public static bool IsLower(char c); // 0x0000000181561070-0x0000000181561120
		internal static bool CheckPunctuation(UnicodeCategory uc); // 0x0000000181560700-0x0000000181560710
		public static bool IsPunctuation(char c); // 0x0000000181561330-0x00000001815613D0
		internal static bool CheckLetterOrDigit(UnicodeCategory uc); // 0x00000001815606D0-0x00000001815606E0
		public static bool IsLetterOrDigit(char c); // 0x0000000181560DC0-0x0000000181560E60
		public static char ToUpper(char c, CultureInfo culture); // 0x0000000181562230-0x00000001815622D0
		public static char ToUpper(char c); // 0x00000001815621C0-0x0000000181562230
		public static char ToUpperInvariant(char c); // 0x0000000181562150-0x00000001815621C0
		public static char ToLower(char c, CultureInfo culture); // 0x0000000181562000-0x00000001815620A0
		public static char ToLower(char c); // 0x00000001815620A0-0x0000000181562110
		public static char ToLowerInvariant(char c); // 0x0000000181561F90-0x0000000181562000
		public TypeCode GetTypeCode(); // 0x00000001804CB980-0x00000001804CB990
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815618F0-0x0000000181561980
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018123AD30-0x000000018123AD40
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000181561CF0-0x0000000181561D80
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000181561980-0x0000000181561A10
		short IConvertible.ToInt16(IFormatProvider provider); // 0x0000000181561BC0-0x0000000181561C50
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x0000000181561EA0-0x0000000181561EF0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000181561C50-0x0000000181561CA0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000181561EF0-0x0000000181561F40
		long IConvertible.ToInt64(IFormatProvider provider); // 0x0000000181561CA0-0x0000000181561CF0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x0000000181561F40-0x0000000181561F90
		float IConvertible.ToSingle(IFormatProvider provider); // 0x0000000181561D80-0x0000000181561E10
		double IConvertible.ToDouble(IFormatProvider provider); // 0x0000000181561B30-0x0000000181561BC0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x0000000181561AA0-0x0000000181561B30
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x0000000181561A10-0x0000000181561AA0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x0000000181561E10-0x0000000181561EA0
		public static bool IsControl(char c); // 0x0000000181560BA0-0x0000000181560C30
		public static bool IsLetterOrDigit(string s, int index); // 0x0000000181560E60-0x0000000181560F90
		internal static bool CheckNumber(UnicodeCategory uc); // 0x00000001815606F0-0x0000000181560700
		public static bool IsNumber(char c); // 0x0000000181561120-0x00000001815611E0
		public static bool IsNumber(string s, int index); // 0x00000001815611E0-0x0000000181561330
		internal static bool CheckSeparator(UnicodeCategory uc); // 0x0000000181560710-0x0000000181560720
		private static bool IsSeparatorLatin1(char c); // 0x00000001815613D0-0x00000001815613F0
		public static bool IsSeparator(char c); // 0x00000001815613F0-0x0000000181561450
		public static bool IsSurrogate(char c); // 0x0000000181561570-0x0000000181561590
		public static bool IsSurrogate(string s, int index); // 0x0000000181561480-0x0000000181561570
		public static bool IsWhiteSpace(string s, int index); // 0x00000001815616E0-0x0000000181561830
		public static UnicodeCategory GetUnicodeCategory(char c); // 0x00000001815609E0-0x0000000181560A70
		public static UnicodeCategory GetUnicodeCategory(string s, int index); // 0x0000000181560A70-0x0000000181560B90
		public static bool IsHighSurrogate(char c); // 0x0000000181560D90-0x0000000181560DB0
		public static bool IsHighSurrogate(string s, int index); // 0x0000000181560C90-0x0000000181560D90
		public static bool IsLowSurrogate(char c); // 0x0000000181561050-0x0000000181561070
		public static bool IsSurrogatePair(char highSurrogate, char lowSurrogate); // 0x0000000181561450-0x0000000181561480
		public static int ConvertToUtf32(char highSurrogate, char lowSurrogate); // 0x00000001815607E0-0x0000000181560900
	}
}
